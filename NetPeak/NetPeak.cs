using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using System.Globalization;

using ZedGraph;

namespace nsNetPeak
{
    public enum Protocol
    {
        TCPv4 = 6,
        TCPv6 = 41,
        UDP = 17,
        Unknown = -1
    };

    /// <summary>
    /// Network Packet volume monitor and graph program.
    /// Author: Dennis Lang 2009
    /// https://landenlabs.com/
    /// 
    /// 
    /// This program was based off of the CodeProject "A Network Sniffer in C#" by Hitesh Sharma
    /// http://www.codeproject.com/KB/IP/CSNetworkSniffer.aspx
    /// 
    /// 
    /// Graph engine "ZedGraph"  provided by JChampion
    /// CodeProject "A flexible charting library for .NET"
    /// http://www.codeproject.com/KB/graphics/zedgraph.aspx
    /// http://zedgraph.org/
    /// 
    /// </summary>
    public partial class NetPeakForm : Form
    {
        #region ==== Data Members

        private Socket mainSocket;                  // The socket which captures all incoming packets
        private byte[] byteData = new byte[4096];
        private bool captureTraffic = false;        // Enable packet captured or not

        int maxTraffic = 100;                       // Max traffic stored in treeNode
        private delegate void AddTreeNode(TreeNode node);

        // Local Machine info.
        private string machineName;
        private string localHostName;
        private string localIpStr;
        private IPAddress localIp;

        class Config
        {
            public int maxTraffic = 100;
            public Throttle throttle;
            public string DoneWav = @"c:\windows\media\Windows XP Ding.wav";
            public string ErrorWav = @"c:\windows\media\Windows XP Error.wav";

            const int maxGraphs = 10;           // max # of active graph curves
            int graphMaxPoints = 1000;          // max points per curve
            TimeSpan graphXtimeSpan = new TimeSpan(0, 1, 0);  // hour, minute, seconds

            // Random colors for curves
            Color[] graphColors = new Color[maxGraphs]{
            Color.Red, Color.Blue, Color.Green, 
            Color.Black, Color.LightBlue, Color.Aquamarine,
            Color.Brown, Color.Orange, Color.DarkGreen,
            Color.Purple};
        };

        #region  ----- Direction stats (read or write)
        class DirStat
        {
            public ulong size;
            public ulong count;
            public DateTime time;

            public DirStat()
            {
                this.size = this.count = 0;
                this.time = DateTime.Now;
            }

            public DirStat Add(ushort val)
            {
                this.size += (ulong)val;
                this.count++;
                this.time = DateTime.Now;
                return this;
            }
            public DirStat Set(DirStat dirStat)
            {
                this.size = dirStat.size;
                this.count = dirStat.count;
                this.time = dirStat.time;
                return this;
            }
            public DirStat Sub(DirStat dirStat)
            {
                this.size -= dirStat.size;
                this.count -= dirStat.count;
                return this;
            }
            public DirStat Delta(DirStat dirStat, bool perSecond)
            {
                ulong seconds = (ulong)(this.time - dirStat.time).TotalSeconds;
                if (seconds <= 0)
                    seconds = 1;

                this.size = (this.size - dirStat.size);
                this.count = (this.count - dirStat.count);

                if (perSecond)
                {
                    this.size /= seconds;
                    this.count /= seconds;
                }

                return this;
            }
            public DirStat Add(DirStat dirStat)
            {
                this.size += dirStat.size;
                this.count += dirStat.count;
                return this;
            }
            public void Clear()
            {
                this.size = 0;
                this.count = 0;
                this.time = DateTime.Now;
            }
        };
        #endregion

        // ----- Data traffic stats
        class DataStat
        {
            public DirStat rdStat;
            public DirStat wrStat;

            public DataStat()
            {
                this.rdStat = new DirStat();
                this.wrStat = new DirStat();
            }
        };

        // ----- Port pair
        struct Portpair
        {
            public uint local;
            public uint remote;
        };

        #region ----- Direction history
        class DirHistory
        {
            public const int MaxHist = 60;
            public DirStat[] hist;
            public int idx;
            public int min;

            public DirHistory()
            {
                hist = new DirStat[MaxHist];
                for (int h = 0; h < hist.Length; h++)
                    hist[h] = new DirStat();
            }

            private DirHistory Add(ushort val)
            {
                int min = DateTime.Now.Minute;
                while (min != idx)
                {
                    idx = (idx + 1) % MaxHist;
                    hist[idx].Clear();
                }

                hist[idx].Add(val);
                return this;
            }

            public DirHistory Set(DirStat dirStat)
            {
                int nowMin = DateTime.Now.Minute;
                if (nowMin != min)
                {
                    idx = (idx + 1) % MaxHist;
                    hist[idx].Clear();
                    min = nowMin;
                }

                hist[idx].Set(dirStat);
                return this;
            }

            public void Clear()
            {
                for (int h = 0; h < MaxHist; h++)
                    hist[h].Clear();
            }
        };
        #endregion

        #region  ----- Time sample history data (used for rolling averages)
        class DataHistory
        {
            // 5, 10, 30, hourly
            public DirHistory rdHist;
            public DirHistory wrHist;

            public DataHistory()
            {
                rdHist = new DirHistory();
                wrHist = new DirHistory();
            }
        };

        // TODO - make method of DirHistory class
        private DirStat HistTotal(DirHistory dirHistory)
        {
            DirStat dirStat = new DirStat();
            DateTime now = DateTime.Now;
            if ((now - dirHistory.hist[dirHistory.idx].time).TotalMinutes > TotalPeriod)
            {
                return dirStat;
            }

            dirStat.Set(dirHistory.hist[dirHistory.idx]);
            int pIdx = dirHistory.idx;
            for (int p = 0; p <= TotalPeriod; p++)
            {
                pIdx = (pIdx - 1 + 60) % 60;
                if ((now - dirHistory.hist[pIdx].time).TotalMinutes > TotalPeriod)
                    break;
            }

            return (TotalPeriod <= 0) ?
                dirStat :
                dirStat.Delta(dirHistory.hist[pIdx], TotalPerSecond);
            // return dirStat;
        }
        #endregion

        // ----- ip Address stats
        class AddressStat
        {
            public Dictionary<Portpair, DataStat> ipDict;
            public DataStat stat;
            public DataHistory hist;

            public AddressStat()
            {
                ipDict = new Dictionary<Portpair, DataStat>();
                stat = new DataStat();
                hist = new DataHistory();
            }
        }

        // ----- Update message
        struct ViewUpd
        {
            public long  address;
            public Portpair ports;
            public IpDir ipDir;
            public DirStat portStat;
            public DirStat addrStat;
            public DirStat histStat;
        };

        struct ViewState
        {
            public bool graph;
            public string graphType;
            public string traffic;
        };

        string ViewKey(ListViewItem vItem)
        {
            return
                vItem.SubItems[nvColHost].Text + "," +
                vItem.SubItems[nvColLocal].Text + "," +
                vItem.SubItems[nvColRemote].Text;
        }

        // ----- ipPattern, remotePortPattern
        class IpFilter
        {
            public Regex ipPattern;
            public Regex lportPattern;
            public Regex rportPattern;

            public string FixPort(string portStr)
            {
                return (portStr == "0" || portStr == "") ?
                    ".+" :    // match anything
                    portStr;
            }

            public IpFilter(string ipPat, string rportPat)
            {
                ipPattern = new Regex(ipPat);
                lportPattern = null;
                rportPattern = new Regex(FixPort(rportPat));
            }

            public IpFilter(string ipPat, string lportPat, string rportPat)
            {
                ipPattern = new Regex(ipPat);
                lportPattern = new Regex(FixPort(lportPat));
                rportPattern = new Regex(FixPort(rportPat));
            }
        }

        List<IpFilter> excludeFilters = new List<IpFilter>();
        List<IpFilter> trafficFilters = new List<IpFilter>();
        const string trafficOnStr = "T";
        const string trafficOffStr = "";

        DateTime startCaptureTime;
        Dictionary<long, string> IpToHostDictionary = new Dictionary<long, string>();
        Dictionary<long, AddressStat> captureStats;

        enum IpDir { eNone, eRead, eWrite };
        delegate void AddListView(long address, Portpair ports);
        delegate void UpdateListView(ViewUpd viewUpd);
        bool showTraffic = false;
        bool showVolume = true;
        UpdateListView updateListView;

        System.Media.SoundPlayer sPlayer = new System.Media.SoundPlayer();
#if false
		// Windows XP
        public string DoneWav = @"c:\windows\media\Windows XP Ding.wav";
        public string ErrorWav = @"c:\windows\media\Windows XP Error.wav";
#else
		// Windows 7
 		public string DoneWav = @"c:\windows\media\Windows Ding.wav";
        public string ErrorWav = @"c:\windows\media\Windows Error.wav";
#endif
        const int nvColG = 0;
        const int nvColGc = 1;
        const int nvColT = 2;
        const int nvColHost = 3;
        const int nvColIp = 4;
        const int nvColLocal = 5;
        const int nvColRemote = 6;
        const int nvColRead = 7;
        const int nvColWrite = 8;
        const int nvColNread = 9;
        const int nvColNwrite = 10;
        const int nvColTime = 11;
        const int nvColRTime = 12;
        const int nvColWTime = 13;
        const int nvCols = 14;

        string[] nvColHint = new string[nvCols] {
            "G = Toggle On to enble Graphing",
            "Gcol = Graph column selection, read, write, read count, write count",
            "T = Toggle On to enable Traffic Detail",
            "Host name associated with IP address if available",
            "IP address of connection",
            "Local Port#",
            "Remote Port#",
            "Total read message lengths, includes IP(20) and TCP(20?) header size.",
            "Total write message lengths, includes IP(20) and TCP(20?) header size.",
            "Total number of read messages",
            "Total number of write messages",
            "Time of last read or write message",
            "Time of last read message",
            "Time of last write message"
        };


        // View state variables - TODO add prefix to mark as ListState variables
        // no, 5, 10, 15, 30, hourly
        int TotalPeriod = 5;            // minutes
        bool TotalPerSecond = true;     // rate when totalPeriod > 0
        string units = string.Empty;
        enum ViewStat { eSummary, eDetail };
        ViewStat viewStat = ViewStat.eSummary;
        string trim = string.Empty;


        GlobalStatDialog globalStatDialog;
        PrintListView printLV = new PrintListView();

        class Throttle
        {
            public int period = 0;              // current period
            public int seconds = 2;             // period interval 
            public int count = 0;               // current invokes per period
            public int maxCount = 20;           // max updates per period
            public bool invokePaused = false;   // flag if invokes are paused due to load
            public int updateSeconds = 2;       // how often to do full update when paused.
        };

        Throttle throttle = new Throttle();


        #region ---- Graph Data
        const int maxGraphs = 10;           // max # of active graph curves
        int graphMaxPoints = 1000;          // max points per curve
        int graphReset = maxGraphs;         // set to -1 to reset all graph curves
        bool graphClear = false;            // set to true to clear points from graph array
        TimeSpan graphXtimeSpan = new TimeSpan(0, 1, 0);  // hour, minute, seconds

        PointPairList[] graphData = new PointPairList[maxGraphs];
        LineItem[] graphCurves;

        // Random colors for curves
        Color[] graphColors = new Color[maxGraphs]{
            Color.Red, Color.Blue, Color.Green, 
            Color.Black, Color.LightBlue, Color.Aquamarine,
            Color.Brown, Color.Orange, Color.DarkGreen,
            Color.Purple};

        int startCaptureSeconds = 0;
        bool graphMultipleAxis = true;
 
        #endregion

        #endregion

        public NetPeakForm()
        {
            InitializeComponent();

            // Set titles & emulate 3d look by double drawing text.
            this.Text = ProductNameAndVersion();
            this.TitleGlow.Text = ProductNameAndVersion();
            this.Title.Text = ProductNameAndVersion();
            this.Title.Parent = this.TitleGlow;
            this.Title.Location = new Point(1, 1);

            // Set traffic capture off
            this.showTraffic = true;
            trafficBtn_Click(null, EventArgs.Empty);    // toggle traffic off.

            // Get local machine info
            machineName = System.Environment.MachineName;
            localHostName = Dns.GetHostName();
            IPHostEntry localHostEntry = Dns.GetHostByName(localHostName);

            localIp = localHostEntry.AddressList[0];
            localIpStr = localIp.ToString();

            // Create local objects.
            captureStats = new Dictionary<long, AddressStat>();
            updateListView = new UpdateListView(OnUpdateListView);
            globalStatDialog = new GlobalStatDialog();
            InitGraph(this.Graph);

            // Set sorters
            this.statView.ListViewItemSorter = new ListViewColumnSorter(ListViewColumnSorter.SortDataType.eAuto);
            this.histView.ListViewItemSorter = new ListViewColumnSorter(ListViewColumnSorter.SortDataType.eAuto);

            // Call statview pulldown menus to set title/icons
            viewSummarylMenu_Click(null, EventArgs.Empty);
            trimMenuItem_Click(this.bySortOrderToolStripMenuItem, EventArgs.Empty);
            totalMitem_ButtonClick(this.total5Mitem, EventArgs.Empty);
            unitMenuItem_Click(this.autoToolStripMenuItem, EventArgs.Empty);

            // Call Graph pulldown menus to set title/icons
            this.graphGitem_Click(lineToolStripMenuItem, EventArgs.Empty);
            this.axisGitem_Click(this.singleToolStripMenuItem, EventArgs.Empty);
            this.dataGitem_Click(this.nonStackedToolStripMenuItem, EventArgs.Empty);
            this.gridlinesGitem_Click(this.majorXGitem, EventArgs.Empty);
            // this.zoomGitem_Click(this.zoomResetGitem, EventArgs.Empty);
            minGBox.Text = graphXtimeSpan.Minutes.ToString();

            // Double buffer statView to prevent flashing.
            ListViewHelper.EnableDoubleBuffer(this.statView);

            // Hide history panel
            historyPanel.Visible = false;

            // Start timer used to animate/update various objects.
            this.timerAnimation.Start();
        }
     
        // On load populate interface choices.
        private void NetPeak_Load(object sender, EventArgs e)
        {
            string strIP = null;

            // IPHostEntry localHostEntry = Dns.GetHostEntry((Dns.GetHostName()));
            IPHostEntry localHostEntry = Dns.GetHostByName(Dns.GetHostName());

            if (localHostEntry.AddressList.Length > 0)
            {
                foreach (IPAddress ip in localHostEntry.AddressList)
                {
                    strIP = ip.ToString();
                    cmbInterfaces.Items.Add(strIP);
                }

                cmbInterfaces.SelectedItem = cmbInterfaces.Items[0];
            }
        }

        // On close stop capture
        private void NetPeak_Closing(object sender, FormClosingEventArgs e)
        {
            this.showTraffic = false;
            if (captureTraffic)
            {
                captureTraffic = false;

                // This may throw exception in background thread.
                mainSocket.Close();
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnResizeBegin(EventArgs e)
        {
            this.statView.BeginUpdate();
            this.trafficTree.BeginUpdate();
            base.OnResizeBegin(e);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            this.statView.EndUpdate();
            this.trafficTree.EndUpdate();
            base.OnResizeEnd(e);
        }

        public string ProductNameAndVersion()
        {
            string appName = Application.ProductName;
            string appVern = Application.ProductVersion;
            return appName + "V" + appVern.Substring(0, 3); //  Get part of versoin string "n.n"
        }

        private void About_Click(object sender, EventArgs e)
        {
            About about = new About(this);
            about.Text = "About - " + ProductNameAndVersion();
            about.Show();
        }

        private void globalCfg_Click(object sender, EventArgs e)
        {
            if (globalStatDialog.IsDisposed)
                globalStatDialog = new GlobalStatDialog();
            globalStatDialog.Visible = true;
            globalStatDialog.Show();
        }

        int ticks = 0;
        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            ticks++;

            if (this.captureTraffic)
            {
                double p = this.titleText.Progress + 0.01;
                if (p > 1)
                    p = 0;
                this.titleText.Progress = p;
            }

            // Animate status bar
            this.statusBar.BackColor = Scale(this.statusBar.BackColor, 1.1);
            if (this.statusBar.BackColor == Color.White)
                this.statusBar.Text = string.Empty;


            int ticksPerSecond = 1000 / timerAnimation.Interval;
            if ((ticks % ticksPerSecond) == 0)
            {
                // Update Clock
                this.timeLabel.Text = DateTime.Now.ToLongTimeString();

                if (excludeListChanged)
                    UpdateFilters();

                if (this.captureTraffic)
                {
                    int deltaSec = (int)(DateTime.Now - startCaptureTime).TotalSeconds;
                    if (deltaSec < 60)
                        elapsedTime.Text = deltaSec.ToString() + " s";
                    else if (deltaSec < 3600)
                        elapsedTime.Text = (deltaSec / 60.0).ToString("F1") + " m";
                    else
                        elapsedTime.Text = (deltaSec / 3600.0).ToString("F1") + " h";

                    UpdateGraph();
                }
            }

            int ticksPerThrottle = ticksPerSecond * throttle.updateSeconds;
            if ((ticks % ticksPerThrottle) == 0)
            {
                if (throttle.invokePaused)
                {
                    UpdateStatView();
                    // this.statView.Sort();
                }
            }

            int ticksPerSort = ticksPerSecond * 2;
            if ((ticks % ticksPerSort) == 0)
            {
                if (this.sortMitem.Checked)
                {
                    this.statView.BeginUpdate();
                    this.statView.Sort();

                    if (this.trim == "Trim/Sort" && this.statView.Items.Count > 0)
                    {
                        int itemHeight = this.statView.GetItemRect(0).Height;

                        for (int idx = this.statView.Items.Count - 1; idx >= 10; idx--)
                        {
                            if (itemHeight * idx > this.statView.DisplayRectangle.Height)
                            {
                                if (this.statView.Items[idx].Checked)
                                {
                                    itemHeight--;   // don't delete any checked items.
                                }
                                else
                                {
                                    this.statView.Items.Remove(this.statView.Items[idx]);
                                }
                            }
                        }
                    }

                    this.statView.EndUpdate();
                }

                this.tableSizeBox.Text = this.statView.Items.Count.ToString();
            }

   
            int ticksPerHist = ticksPerSecond * 10;
            if ((ticks % ticksPerHist) == 0)
            {
                UpdateHistoryView();
            }
        }


 
        /// <summary>
        /// Update data history list (samples per minute)
        /// </summary>
        private void UpdateHistoryView()
        {
            ListViewItem item = null;
            if (this.statView.CheckedItems.Count > 0)
                item = this.statView.CheckedItems[0];
            if (this.statView.SelectedItems.Count > 0)
                item = this.statView.SelectedItems[0];

            if (item != null)
            {
                Monitor.Enter(this.captureStats);
                Portpair noPorts = new Portpair();
                long address = IPAddress.Parse(item.SubItems[nvColIp].Text).Address;
                AddressStat addressStat;
                bool gotHist = this.captureStats.TryGetValue(address, out addressStat);
                Monitor.Exit(this.captureStats);

                if (gotHist)
                {
                    this.titleHitem.Text = "History " + item.SubItems[nvColHost].Text;
                    this.histView.BeginUpdate();
                    this.histView.Items.Clear();
                    DirHistory rdHist = addressStat.hist.rdHist;
                    for (int r = 0; r < rdHist.hist.Length; r++)
                    {
                        DirStat dirStat = rdHist.hist[r];
                        if (dirStat.count > 0)
                        {
                            ListViewItem hItem = this.histView.Items.Add(dirStat.size.ToString());

                            while (hItem.SubItems.Count < 6)
                                hItem.SubItems.Add("");

                            hItem.SubItems[1].Text = dirStat.count.ToString();
                            hItem.SubItems[2].Text = dirStat.time.ToString("T");
                        }
                    }

                    DirHistory wrHist = addressStat.hist.wrHist;
                    int wRow = 0;
                    for (int w = 0; w < wrHist.hist.Length; w++)
                    {
                        DirStat dirStat = wrHist.hist[w];
                        if (dirStat.count > 0)
                        {
                            ListViewItem hItem;
                            if (wRow >= this.histView.Items.Count)
                                hItem = this.histView.Items.Add("");
                            else
                                hItem = this.histView.Items[wRow];

                            while (hItem.SubItems.Count < 6)
                                hItem.SubItems.Add("");

                            hItem.SubItems[3].Text = dirStat.size.ToString();
                            hItem.SubItems[4].Text = dirStat.count.ToString();
                            hItem.SubItems[5].Text = dirStat.time.ToString("T");

                            wRow++;
                        }
                    }

                    DirStat rdHistTot = HistTotal(rdHist);
                    DirStat wrHistTot = HistTotal(wrHist);

                    ListViewItem tItem = this.histView.Items.Add("");
                    tItem.BackColor = Color.LightBlue;

                    while (tItem.SubItems.Count < 6)
                        tItem.SubItems.Add("");

                    tItem.SubItems[0].Text = rdHistTot.size.ToString();
                    tItem.SubItems[1].Text = rdHistTot.count.ToString();
                    tItem.SubItems[2].Text = TotalPeriod.ToString() + " min";

                    tItem.SubItems[3].Text = wrHistTot.size.ToString();
                    tItem.SubItems[4].Text = wrHistTot.count.ToString();
                    tItem.SubItems[5].Text = TotalPeriod.ToString() + " min";

                    this.histView.EndUpdate();
                }
            }
        }

        private void SetStatus(string message, bool isError)
        {
            this.statusBar.Text = message;
            this.statusBar.BackColor = isError ? Color.Pink : Color.Yellow;
        }

        #region ==== Misc Helper routines
        private int Seconds(DateTime dt)
        {
            int seconds = (dt.Hour * 60 + dt.Minute) * 60 + dt.Second;
            return seconds;
        }

        private byte Scale(byte b, double scale)
        {
            return (byte)Math.Min(b * scale + scale, 255.0);
        }

        private Color Scale(Color c, double scale)
        {
            Color c2 = Color.FromArgb(c.A,
                Scale(c.R, scale),
                Scale(c.G, scale),
                Scale(c.B, scale));
            return c2;
        }

        DateTime MaxTime(DateTime dt1, DateTime dt2)
        {
            return DateTime.Compare(dt1, dt2) >= 0 ? dt1 : dt2;
        }


        /// <summary>
        /// Column header click fires sort.
        /// </summary>
        private void ColumnTotalClick(object sender, ColumnClickEventArgs e)
        {
            ListView listView = sender as ListView;

            int lvCnt = listView.Items.Count;
            if (lvCnt > 1)
            {
                ListViewItem lastItem = listView.Items[lvCnt - 1];
                listView.Items.Remove(lastItem);
                ColumnClick(sender, e);
                listView.Items.Add(lastItem);
            }
        }

        /// <summary>
        ///  Special version of ListView column sort click, 
        ///  which knows which Stat columns encode data in tag field.
        /// </summary>
        private void StatColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView listView = sender as ListView;
            ListViewColumnSorter sorter = listView.ListViewItemSorter as ListViewColumnSorter;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == sorter.SortColumn1)
            {
                // Reverse the current sort direction for this column.
                if (sorter.Order == SortOrder.Ascending)
                    sorter.Order = SortOrder.Descending;
                else
                    sorter.Order = SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                sorter.SortColumn1 = e.Column;
                sorter.Order = SortOrder.Ascending;
                sorter.SortType = ListViewColumnSorter.SortDataType.eAuto;

                switch (e.Column)
                {
                    case nvColG:
                    case nvColNwrite:
                    case nvColNread:
                    case nvColRead:
                    case nvColWrite:
                        sorter.SortType = ListViewColumnSorter.SortDataType.eTagUlong;
                        break;

                    case nvColTime:
                        sorter.SortType = ListViewColumnSorter.SortDataType.eTagDateTime;
                        break;
                }
            }

            // Clear old arrows and set new arrow
            foreach (ColumnHeader colHdr in listView.Columns)
                colHdr.ImageIndex = -1;

            listView.Columns[e.Column].ImageIndex = (sorter.Order == SortOrder.Ascending) ? 0 : 1; 


            // Perform the sort with these new sort options.
            if (listView != null)
                listView.Sort();
        }

        /// <summary>
        /// Column header click fires sort.
        /// </summary>
        private void ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView listView = sender as ListView;
            ListViewColumnSorter sorter = listView.ListViewItemSorter as ListViewColumnSorter;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == sorter.SortColumn1)
            {
                // Reverse the current sort direction for this column.
                if (sorter.Order == SortOrder.Ascending)
                    sorter.Order = SortOrder.Descending;
                else
                    sorter.Order = SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                sorter.SortColumn1 = e.Column;
                sorter.Order = SortOrder.Ascending;
            }

            // Clear old arrows and set new arrow
            foreach (ColumnHeader colHdr in listView.Columns)
                colHdr.ImageIndex = -1;

            listView.Columns[e.Column].ImageIndex = (sorter.Order == SortOrder.Ascending) ? 0 : 1; 

            // Perform the sort with these new sort options.
            if (listView != null)
                listView.Sort();
        }


        private void ReSizeColumns(ListView listView)
        {
            listView.BeginUpdate();

            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);

            int colCnt = listView.Columns.Count;
            for (int colIdx = 0; colIdx < colCnt; colIdx++)
            {
                ColumnHeader colHeader = listView.Columns[colIdx];
                if (colHeader.Width < colHeader.Text.Length * 8)
                {
                    listView.AutoResizeColumn(colIdx, ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }

            listView.EndUpdate();
        }

        struct AddrPort
        {
            public long address;
            public Portpair ports;
        };

        private AddrPort[] FillAddrPortList(ListView listView)
        {
            AddrPort[] addrPortList = null;
            int cnt = listView.SelectedItems.Count;
            if (cnt > 0)
            {
                addrPortList = new AddrPort[cnt];
                for (int i = 0; i < cnt; i++)
                {
                    ListViewItem item = listView.SelectedItems[i];
                    AddrPort addrPort = new AddrPort();
                    addrPort.address = IPAddress.Parse(item.SubItems[nvColIp].Text).Address;
                    addrPort.ports.local = uint.Parse(item.SubItems[nvColLocal].Text);
                    addrPort.ports.remote = uint.Parse(item.SubItems[nvColRemote].Text);
                    addrPortList[i] = addrPort;
                }
            }
            else
            {
                cnt = listView.Items.Count;
                addrPortList = new AddrPort[cnt];
                for (int i = 0; i < cnt; i++)
                {
                    ListViewItem item = listView.Items[i];
                    AddrPort addrPort = new AddrPort();
                    addrPort.address = IPAddress.Parse(item.SubItems[nvColIp].Text).Address;
                    addrPort.ports.local = uint.Parse(item.SubItems[nvColLocal].Text);
                    addrPort.ports.remote = uint.Parse(item.SubItems[nvColRemote].Text);
                    addrPortList[i] = addrPort;
                }
            }

            return addrPortList;
        }

        #endregion


        #region ==== ListView Edit/Export

        private void ListViewEdit(ListView listView, ListViewItem item)
        {
            int colCnt = listView.Columns.Count;
            for (int colIdx = 0; colIdx < colCnt; colIdx++)
            {
                ColumnHeader colHeader = listView.Columns[colIdx];
                if (colIdx == item.SubItems.Count)
                    item.SubItems.Add(colHeader.Text);

                if (listView.DisplayRectangle.Contains(item.SubItems[colIdx].Bounds.Location) == false)
                {
                    // Force item in view by scrolling box to the right.

                    item.Selected = true;
                    item.Focused = true;

                    int shift = item.SubItems[colIdx].Bounds.Location.X - listView.DisplayRectangle.X;
                    shift /= 8;
                    for (int i = 0; i < shift; i++)
                    {
                        SendKeys.Send("{RIGHT}");
                        SendKeys.Flush();
                    }
                }

                FieldBox fieldBox = new FieldBox();
                fieldBox.FieldText = item.SubItems[colIdx].Text;
                fieldBox.Location = listView.PointToScreen(item.SubItems[colIdx].Bounds.Location);

                if (fieldBox.ShowDialog() == DialogResult.OK)
                {
                    item.SubItems[colIdx].Text = fieldBox.FieldText;
                }
            }

            if (listView == this.excludeList)
                excludeListChanged = true;
        }

        private void ListViewDbl_Click(object sender, EventArgs e)
        {
            ListView listView = sender as ListView;
            Point p = listView.PointToClient(System.Windows.Forms.Control.MousePosition);
            ListViewItem itemAt = listView.GetItemAt(p.X, p.Y);
            if (itemAt != null)
                ListViewEdit(listView, itemAt);
        }

        /// <summary>
        ///  Save ListView contents in as a CSV file.
        /// </summary>
        private void ListViewExport_Click(object sender, EventArgs e)
        {
            // ToolStripDropDownItem viewItem = (ToolStripDropDownItem)sender;
            // ToolStripDropDownMenu viewItems = viewItem.DropDown.OwnerItem.Owner as ToolStripDropDownMenu;
            Point p;
            ListView listView = null;

            p = excludeList.PointToClient(System.Windows.Forms.Control.MousePosition);
            if (this.excludeList.DisplayRectangle.Contains(p))
                listView = this.excludeList;

            p = statView.PointToClient(System.Windows.Forms.Control.MousePosition);
            if (this.statView.DisplayRectangle.Contains(p))
                listView = this.statView;

            string file = ListViewExt.Export(listView);
            if (file.Length != 0)
                SetStatus("Export to file " + file, false);
            else
                SetStatus("Failed to export", true);
        }

#if false
        private void ExportListView(ListView listView)
        {
            if (listView == null || listView.Items.Count == 0)
                return;

            if (this.exportFileDialog.ShowDialog() == DialogResult.OK)
            {
                String filePath = this.exportFileDialog.FileName;
                TextWriter writer = new StreamWriter(filePath);

                string txtLine = string.Empty;
                foreach (ColumnHeader ch in listView.Columns)
                {
                    if (txtLine.Length != 0)
                        txtLine += ",";
                    txtLine += ch.Text;
                }
                writer.WriteLine(txtLine);

                foreach (ListViewItem item in listView.Items)
                {
                    txtLine = string.Empty;
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        if (txtLine.Length != 0)
                            txtLine += ",";
                        txtLine += subItem.Text.Replace(',', ';');
                    }

                    writer.WriteLine(txtLine);
                }

                writer.Close();

                SetStatus("Saved list to file:" + filePath, false);
            }
        }
#endif
        #endregion


        #region ==== Graph routines

        // Load demo in graph pane.
        public void DemoGraph()
        {
            if (graphData[0] == null)
            {
                // Make up some data arrays based on the Sine function
                graphData[0] = new PointPairList();
                graphData[1] = new PointPairList();
                DateTime now = DateTime.Now;
                for (int i = 0; i < 36; i++)
                {
                    double x = (double)new XDate(now.Year, now.Month, now.Day, now.Hour, 0, i);
                    double y1 = 1.5 + Math.Sin((double)i * 0.2);
                    double y2 = 3.0 * (1.5 + Math.Sin((double)i * 0.2));
                    graphData[0].Add(x, y1);
                    graphData[1].Add(x, y2);
                }
            }

            GraphPane pane = this.Graph.GraphPane;

            if (graphCurves[0] == null)
            {
                graphCurves[0] = pane.AddCurve("Read", graphData[0], graphColors[0]);
                graphCurves[1] = pane.AddCurve("Write", graphData[1], graphColors[1]);
            }

            if (graphMultipleAxis)
            {
                graphCurves[1].YAxisIndex = 1;
                if (pane.YAxisList.Count < 2)
                {
                    YAxis yAxis = new YAxis("Write");
                    pane.YAxisList.Add(yAxis);
                }
            }
            else
            {
                for (int i = 1; i < pane.YAxisList.Count; i++)
                    pane.YAxisList[i].IsVisible = false;
            }

            // Mark to clear demo data prior to adding real data.
            graphClear = true;
        }

        public void InitGraph(ZedGraphControl graphC)
        {
            graphCurves = new LineItem[maxGraphs];

            GraphPane pane = graphC.GraphPane;
            DateTime now = DateTime.Now;
            string mmddyy = now.Month.ToString() + "/" + now.Day.ToString() + "/" + (now.Year % 100).ToString("00");

            // Set the title and axis labels
            pane.Title.Text = ProductNameAndVersion() + "\n" + this.localHostName + " Network Traffic " + "(" + mmddyy + ")";
            pane.YAxis.Title.Text = "Bytes/sec";
            pane.XAxis.Title.Text = "Time (hh:mm:ss)";
            pane.XAxis.Type = AxisType.Date;
        //    pane.XAxis.Scale.MajorStep = 10;
        //    pane.XAxis.Scale.MajorUnit = DateUnit.Second;
            pane.XAxis.Scale.Format = "hh:mm:ss";

            pane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);

            DemoGraph();

            // Calculate the Axis Scale Ranges
            graphC.AxisChange();
         //   graphC.IsAutoScrollRange = false;
        }

        private void GraphAxis(Axis axis, int idx, string title)
        {
            axis.Title.Text = title;
            axis.IsVisible = true;
            axis.Color = graphColors[idx];
            axis.Scale.FontSpec.FontColor = graphColors[idx];
            axis.Title.FontSpec.FontColor = graphColors[idx];
            // axis.Title.FontSpec.IsDropShadow = true;

            bool setGrid = ((graphMultipleAxis == false) || (idx == 0));
            axis.MajorGrid.IsVisible = (setGrid) ? majorYGitem.Checked : false;
            axis.MinorGrid.IsVisible = (setGrid) ? minorYGitem.Checked : false;
        }

        private void GraphAddData(int idx, string title1, string title2, double x, double y)
        {
            GraphPane pane = this.Graph.GraphPane;
            string title = title1;
            if (title2.Length != 0)
                title += " " + title2;

            if (graphClear)
            {
                graphClear = false;
                for (int i = 0; i < graphData.Length && graphData[i] != null; i++)
                    graphData[i].Clear();
                graphReset = -1;
            }

            if (graphData[idx] == null)
            {
                graphData[idx] = new PointPairList();
                graphCurves[idx] = null;
            }

            if (graphCurves[idx] == null)
            {
                switch (graphType)
                {
                    case GraphType.gLine:
                        graphCurves[idx] = pane.AddCurve(title, graphData[idx], graphColors[idx]);// , SymbolType.Diamond);
                        graphCurves[idx].Line.Fill = new Fill();
                        graphCurves[idx].Line.Width = 2;
                        break;

                    case GraphType.gLineFilled:
                        graphCurves[idx] = pane.AddCurve(title, graphData[idx], graphColors[idx]);// , SymbolType.Diamond);
                        graphCurves[idx].Line.Fill = new Fill(Color.FromArgb(128, graphColors[idx]),
                        Color.FromArgb(64, Scale(graphColors[idx], 0.5)), 45f);
                        break;

                    case GraphType.gBar:
                        // graphCurves[idx] = pane.AddBar(title, graphPoints, graphColors[idx]);
                        break;
                    case GraphType.gPie:
                        break;
                }


                // if (graphMultipleAxis)
                {
                    graphCurves[idx].YAxisIndex = idx;

                    if (this.Graph.GraphPane.YAxisList.Count <= idx)
                        this.Graph.GraphPane.YAxisList.Add(new YAxis(title));

                    Axis axis = graphCurves[idx].GetYAxis(Graph.GraphPane);
                    GraphAxis(axis, idx, title);
                    graphCurves[idx].Label.IsVisible = true;
                    graphCurves[idx].Label.Text = title;
                }
                if (graphMultipleAxis == false)
                {
                    // graphCurves[0].Label.IsVisible = false;  // hide single Y legend
                    graphCurves[idx].GetYAxis(Graph.GraphPane).Title.Text = "";
                    graphCurves[idx].YAxisIndex = 0;
                }
            }
            else if (graphReset < idx)
            {
                if (graphReset < idx)
                    graphReset++;

                // if (graphMultipleAxis)
                {
                    graphCurves[idx].YAxisIndex = idx;

                    if (this.Graph.GraphPane.YAxisList.Count <= idx)
                        this.Graph.GraphPane.YAxisList.Add(new YAxis(title));

                    Axis axis = graphCurves[idx].GetYAxis(Graph.GraphPane);
                    GraphAxis(axis, idx, title);
                    graphCurves[idx].Label.IsVisible = true;
                    graphCurves[idx].Label.Text = title;
                }
                if (graphMultipleAxis == false)
                {
                    if (graphCurves[idx].YAxisIndex != 0)
                    {
                        // graphCurves[idx].Label.IsVisible = false;
                        graphCurves[idx].GetYAxis(Graph.GraphPane).IsVisible = false;
                    }

                    graphCurves[idx].YAxisIndex = 0;
                    // graphCurves[0].Label.IsVisible = false;  // hide single Y legend
                    graphCurves[0].GetYAxis(Graph.GraphPane).Title.Text = "";
                }

                graphCurves[idx].IsVisible = true;
                graphCurves[idx].Symbol =
                    new Symbol(symbolGitem.Checked ? SymbolType.Circle : SymbolType.None, graphCurves[idx].Color);

                Axis yAxis = graphCurves[idx].GetYAxis(Graph.GraphPane);
                yAxis.Title.Text = title;
                yAxis.IsVisible = true;

                bool setGrid = ((graphMultipleAxis == false) || (idx == 0));
                yAxis.MajorGrid.IsVisible = (setGrid) ? majorYGitem.Checked : false;
                yAxis.MinorGrid.IsVisible = (setGrid) ? minorYGitem.Checked : false;

                switch (graphType)
                {
                    case GraphType.gLine:
                        graphCurves[idx].Line.Fill = new Fill();
                        break;

                    case GraphType.gLineFilled:
                        graphCurves[idx].Line.Fill = new Fill(Color.FromArgb(128, graphColors[idx]),
                        Color.FromArgb(64, Scale(graphColors[idx], 0.5)), 45f);
                        break;
                }
            }

            while (graphData[idx].Count > graphMaxPoints)
            {
                graphCurves[idx].RemovePoint(0);
            }

            if (graphCurves[idx] != null)
            {
                PointPair pointPair = new PointPair(x, y);
                int cnt =  graphData[idx].Count;

                // Add point if first or not a duplicate and increasing X coordinate.
                if (graphData[idx].Count == 0 || 
                    (graphData[idx][cnt-1] != pointPair && pointPair.X >= graphData[idx][cnt-1].X))
                    graphCurves[idx].AddPoint(pointPair);
            }
        }

        private void RefreshGraph(double minX, double maxX)
        {
            if (graphAutoScroll)
            {
                GraphPane pane = Graph.GraphPane;

                double bInc = 0; //  pane.XAxis.Scale.MajorStep;
                // double dMin = pane.XAxis.Scale.Min;
                // double dMax = pane.XAxis.Scale.Max;

                pane.XAxis.Scale.Min = minX + bInc;
                pane.XAxis.Scale.Max = maxX + bInc;

                Graph.AxisChange();
                Graph.Refresh();
            }
        }

        protected void GraphAddData(int idx, ListViewItem item, int col, double x)
        {
            if (idx < maxGraphs)
            {
                ulong y = (ulong)item.SubItems[col].Tag;
                string title = item.ListView.Columns[col].Text;
                GraphAddData(idx, item.SubItems[nvColHost].Text, title, x, y);
            }
        }

        protected void UpdateGraph()
        {
            int cnt = this.statView.CheckedItems.Count;
            cnt = Math.Min(cnt, maxGraphs);

            int gIdx = 0;
            for (int idx = 0; idx < cnt && gIdx < maxGraphs; idx++)
            {
                ListViewItem item = this.statView.CheckedItems[idx];
                DateTime dt = (DateTime)item.SubItems[nvColTime].Tag;
                if (dt == DateTime.MinValue)
                    continue;

                // int seconds = Seconds(dt) - startCaptureSeconds;
                double xValue = (double)new XDate(dt);

                switch (item.SubItems[nvColGc].Text)
                {
                    case "time":
                        DateTime dtR = (DateTime)item.SubItems[nvColRTime].Tag;
                        DateTime dtW = (DateTime)item.SubItems[nvColWTime].Tag;
                        const string timeTitle = "Time Rd=5,Wr=10";
                        string hostNm = item.SubItems[nvColHost].Text;

                        if (dtR < dtW)
                        {
                            if (dtR != DateTime.MinValue)
                                GraphAddData(gIdx, hostNm, timeTitle, (double)new XDate(dtR), 5);

                            if (dtW != DateTime.MinValue)
                                GraphAddData(gIdx++, hostNm, timeTitle, (double)new XDate(dtW), 10);
                        }
                        else
                        {
                            if (dtW != DateTime.MinValue)
                                GraphAddData(gIdx, hostNm, timeTitle, (double)new XDate(dtW), 10);
                            
                            if (dtR != DateTime.MinValue)
                                GraphAddData(gIdx++, hostNm, timeTitle, (double)new XDate(dtR), 5);
                        }
                        break;

                    case "r/w":
                        GraphAddData(gIdx++, item, nvColRead, xValue);
                        if (gIdx < maxGraphs)
                            GraphAddData(gIdx++, item, nvColWrite, xValue);
                        break;

                    case "r":
                        GraphAddData(gIdx++, item, nvColRead, xValue);
                        break;

                    case "w":
                        GraphAddData(gIdx++, item, nvColWrite, xValue);
                        break;

                    case "#r/#w":
                        GraphAddData(gIdx++, item, nvColNread, xValue);
                        if (gIdx < maxGraphs)
                           GraphAddData(gIdx++, item, nvColNwrite, xValue);
                        break;
                    case "#r":
                        GraphAddData(gIdx++, item, nvColNread, xValue);
                        break;
                    case "#w":
                        GraphAddData(gIdx++, item, nvColNwrite, xValue);
                        break;

                }
            }

            if (cnt > 0)
            {
                // int x = Seconds(DateTime.Now) - startCaptureSeconds;
                double maxX = (double)new XDate(DateTime.Now);
                DateTime minDT = DateTime.Now - graphXtimeSpan;
                double minX = (double)new XDate(minDT);
                RefreshGraph(minX, maxX);
            }

            for (int cIdx = gIdx; cIdx < graphCurves.Length; cIdx++)
            {
                if (graphCurves[cIdx] != null)
                {
                    // graphReset = -1;
                    graphCurves[cIdx].IsVisible = false;
                    graphCurves[cIdx].Label.IsVisible = false;
                    int aIdx = graphCurves[cIdx].GetYAxisIndex(Graph.GraphPane);
                    if (aIdx > 0)
                    {
                        graphCurves[cIdx].GetYAxis(Graph.GraphPane).IsVisible = false;
                    }
                }
            }
        }

        #endregion


        #region ==== Network capture
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cmbInterfaces.Text == "")
            {
                MessageBox.Show("Select an Interface to capture the packets.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                captureTraffic = !captureTraffic;

                if (captureTraffic)
                {
                    //Start capturing the packets...
                    btnStart.Text = "&Stop";
                    captureImage.BackgroundImage = global::nsNetPeak.Properties.Resources.green24;
                    // btnStart.BackColor = Color.FromArgb(255, 192, 192);
                    this.sPlayer.SoundLocation = this.DoneWav;
                    this.sPlayer.Play();

                    startCaptureTime = DateTime.Now;
                    startCaptureSeconds = Seconds(DateTime.Now);

                    //For sniffing the socket to capture the packets has to be a raw socket, with the
                    //address family being of type internetwork, and protocol being IP
                    mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);

                    //Bind the socket to the selected IP address
                    mainSocket.Bind(new IPEndPoint(IPAddress.Parse(cmbInterfaces.Text), 0));

                    //Set the socket  options
                    //Applies only to IP packets, Set the include the header option to true
                    mainSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);

                    byte[] byTrue = new byte[4] { 1, 0, 0, 0 };
                    byte[] byOut = new byte[4] { 1, 0, 0, 0 };     //Capture outgoing packets

                    //Socket.IOControl is analogous to the WSAIoctl method of Winsock 2
                    //Equivalent to SIO_RCVALL constant of Winsock 2
                    int retCode = mainSocket.IOControl(IOControlCode.ReceiveAll, byTrue, byOut);

                    //Start receiving the packets asynchronously
                    mainSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                        new AsyncCallback(OnReceive), null);
                }
                else
                {
                    this.titleText.Progress = 0;
                    captureImage.BackgroundImage = global::nsNetPeak.Properties.Resources.red24;
                    btnStart.Text = "&Start";
                    // btnStart.BackColor = Color.FromArgb(192, 255, 192);

                    //To stop capturing the packets close the socket
                    mainSocket.Close();

                    this.sPlayer.SoundLocation = this.DoneWav;
                    this.sPlayer.Play();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "nsNetPeak", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                if (captureTraffic)
                {
                    // StateObject so = ar.AsyncState;
                    int nReceived = mainSocket.EndReceive(ar);
                    // System.Diagnostics.Debug.WriteLine(nReceived.ToString());   // DEBUG

                    //Analyze the bytes received...
                    try
                    {
                        ParseData(byteData, nReceived);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    //Another call to BeginReceive so that we continue to receive the incoming
                    //packets
                    mainSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                        new AsyncCallback(OnReceive), null);
                }
            }
            catch (ObjectDisposedException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Build exclude & traffic filters 
        /// </summary>
        private void UpdateFilters()
        {
            Monitor.Enter(excludeFilters);
            excludeFilters.Clear();
            foreach (ListViewItem item in this.excludeList.CheckedItems)
            {
                IpFilter exFilter = new IpFilter(
                    item.SubItems[1].Text,  // ip
                    item.SubItems[2].Text,  // local port
                    item.SubItems[3].Text); // remote port 
                excludeFilters.Add(exFilter);
            }
            Monitor.Exit(excludeFilters);

            Monitor.Enter(trafficFilters);
            trafficFilters.Clear();
            foreach (ListViewItem item in this.statView.Items)
            {
                if (item.SubItems[nvColT].Text == trafficOnStr)
                {
                    IpFilter tFilter = new IpFilter(item.SubItems[nvColIp].Text, item.SubItems[nvColRemote].Text);
                    trafficFilters.Add(tFilter);
                }
            }
            Monitor.Exit(trafficFilters);
        }

        private void ParseData(byte[] byteData, int nReceived)
        {
            //Since all protocol packets are encapsulated in the IP datagram
            //so we start by parsing the IP header and see what protocol data
            //is being carried by it
            IPHeader ipHeader = new IPHeader(byteData, nReceived);

            IPAddress ipNum;
            IpDir ipDir = IpDir.eNone;

            // Determine i/o direction (read or write)
            if (ipHeader.SourceAddress.Address == localIp.Address)
            {
                ipDir = IpDir.eWrite;
                ipNum = ipHeader.DestinationAddress;
            }
            else if (ipHeader.DestinationAddress.Address == localIp.Address)
            {
                ipDir = IpDir.eRead;
                ipNum = ipHeader.SourceAddress;
            }
            else
            {
                return;     // ignore packet with no local address.
            }


            TreeNode rootNode = null;
            if (showTraffic)
            {
                rootNode = new TreeNode();
                TreeNode ipNode = MakeIPTreeNode(ipHeader);
                rootNode.Nodes.Add(ipNode);
            }

            //Now according to the protocol being carried by the IP datagram we parse 
            //the data field of the datagram
            switch (ipHeader.ProtocolType)
            {
                case Protocol.TCPv4:
                    //IPHeader.Data stores the data being carried by the IP datagram
                    TCPHeader tcpHeader = new TCPHeader(ipHeader.Data, ipHeader.MessageLength);//Length of the data field                    

                    if (this.showTraffic)
                    {
                        TreeNode tcpNode = MakeTCPTreeNode(tcpHeader);
                        rootNode.Nodes.Add(tcpNode);

                        //If the port is equal to 53 then the underlying protocol is DNS
                        //Note: DNS can use either TCP or UDP thats why the check is done twice
                        if (tcpHeader.DestinationPort == "53" || tcpHeader.SourcePort == "53")
                        {
                            TreeNode dnsNode = MakeDNSTreeNode(tcpHeader.Data, (int)tcpHeader.MessageLength);
                            rootNode.Nodes.Add(dnsNode);
                        }
                    }

                    if (showVolume)
                    {
                        AddressStat addressStat;
                        Monitor.Enter(this.captureStats);

                        if (this.captureStats.TryGetValue(ipNum.Address, out addressStat) == false)
                        {
                            // Add new address
                            addressStat = new AddressStat();
                            this.captureStats.Add(ipNum.Address, addressStat);
                        }

                        // Save port numbers
                        Portpair ports = new Portpair();
                        switch (ipDir)
                        {
                            case IpDir.eRead:
                                ports.remote = tcpHeader.usSourcePort;
                                ports.local = tcpHeader.usDestinationPort;
                                break;
                            case IpDir.eWrite:
                                ports.local = tcpHeader.usSourcePort;
                                ports.remote = tcpHeader.usDestinationPort;
                                break;
                        }

                        DataStat ipStat;
                        if (addressStat.ipDict.TryGetValue(ports, out ipStat) == false)
                        {
                            // Add new port combination

                            ipStat = new DataStat();

                            this.captureStats[ipNum.Address].ipDict.Add(ports, ipStat);
                            addressStat = this.captureStats[ipNum.Address];
                        }

                        ViewUpd viewUpd = new ViewUpd();
                        viewUpd.address = ipNum.Address;
                        viewUpd.ports = ports;
                        viewUpd.ipDir = ipDir;

                        addressStat = captureStats[ipNum.Address];
                        ipStat = addressStat.ipDict[ports];

                        // Update read or write stats.
                        switch (ipDir)
                        {
                            case IpDir.eRead:
                                viewUpd.portStat = ipStat.rdStat.Add(ipHeader.usTotalLength);
                                viewUpd.addrStat = addressStat.stat.rdStat.Add(ipHeader.usTotalLength);
                                //  viewUpd.histStat = HistTotal(addressStat.hist.rdHist.Add(ipHeader.usTotalLength));
                                viewUpd.histStat = HistTotal(addressStat.hist.rdHist.Set(viewUpd.addrStat));
                                break;
                            case IpDir.eWrite:
                                viewUpd.portStat = ipStat.wrStat.Add(ipHeader.usTotalLength);
                                viewUpd.addrStat = addressStat.stat.wrStat.Add(ipHeader.usTotalLength);
                                // viewUpd.histStat = HistTotal(addressStat.hist.wrHist.Add(ipHeader.usTotalLength));
                                viewUpd.histStat = HistTotal(addressStat.hist.wrHist.Set(viewUpd.addrStat));
                                break;
                            default:
                                break;
                        }

                        Monitor.Exit(this.captureStats);

                        // Throttle 'invokes' to avoid swapping UI
                        if (throttle.period != (DateTime.Now.Second / throttle.seconds))
                        {
                            throttle.period = DateTime.Now.Second / throttle.seconds;
                            throttle.count = 0;
                            throttle.invokePaused = false;
                        }

                        if (throttle.count++ < throttle.maxCount)
                        {
                            // statView.BeginInvoke(updateListView, new object[] { viewUpd });
                            statView.Invoke(updateListView, new object[] { viewUpd });
                        }
                        else
                        {
                            throttle.invokePaused = true;
                        }
                    }

                    break;

                case Protocol.UDP:
                    //IPHeader.Data stores the data being carried by the IP datagram
                    UDPHeader udpHeader = new UDPHeader(ipHeader.Data, (int)ipHeader.MessageLength);//Length of the data field                    

                    if (showTraffic)
                    {
                        TreeNode udpNode = MakeUDPTreeNode(udpHeader);
                        rootNode.Nodes.Add(udpNode);

                        //If the port is equal to 53 then the underlying protocol is DNS
                        //Note: DNS can use either TCP or UDP thats why the check is done twice
                        if (udpHeader.DestinationPort == "53" || udpHeader.SourcePort == "53")
                        {
                            TreeNode dnsNode = MakeDNSTreeNode(udpHeader.Data,
                                //Length of UDP header is always eight bytes so we subtract that out of the total 
                                //length to find the length of the data
                                                               Convert.ToInt32(udpHeader.Length) - 8);
                            rootNode.Nodes.Add(dnsNode);
                        }
                    }

                    if (showVolume)
                    {
                        AddressStat addressStat;
                        Monitor.Enter(this.captureStats);

                        if (this.captureStats.TryGetValue(ipNum.Address, out addressStat) == false)
                        {
                            // Add new address
                            addressStat = new AddressStat();
                            this.captureStats.Add(ipNum.Address, addressStat);
                        }

                        // Save port numbers
                        Portpair ports = new Portpair();
                        switch (ipDir)
                        {
                            case IpDir.eRead:
                                ports.remote = udpHeader.usSourcePort;
                                ports.local = udpHeader.usDestinationPort;
                                break;
                            case IpDir.eWrite:
                                ports.local = udpHeader.usSourcePort;
                                ports.remote = udpHeader.usDestinationPort;
                                break;
                        }

                        DataStat ipStat;
                        if (addressStat.ipDict.TryGetValue(ports, out ipStat) == false)
                        {
                            // Add new port combination

                            ipStat = new DataStat();

                            this.captureStats[ipNum.Address].ipDict.Add(ports, ipStat);
                            addressStat = this.captureStats[ipNum.Address];
                        }

                        ViewUpd viewUpd = new ViewUpd();
                        viewUpd.address = ipNum.Address;
                        viewUpd.ports = ports;
                        viewUpd.ipDir = ipDir;

                        addressStat = captureStats[ipNum.Address];
                        ipStat = addressStat.ipDict[ports];

                        // Update read or write stats.
                        switch (ipDir)
                        {
                            case IpDir.eRead:
                                viewUpd.portStat = ipStat.rdStat.Add(ipHeader.usTotalLength);
                                viewUpd.addrStat = addressStat.stat.rdStat.Add(ipHeader.usTotalLength);
                                //  viewUpd.histStat = HistTotal(addressStat.hist.rdHist.Add(ipHeader.usTotalLength));
                                viewUpd.histStat = HistTotal(addressStat.hist.rdHist.Set(viewUpd.addrStat));
                                break;
                            case IpDir.eWrite:
                                viewUpd.portStat = ipStat.wrStat.Add(ipHeader.usTotalLength);
                                viewUpd.addrStat = addressStat.stat.wrStat.Add(ipHeader.usTotalLength);
                                // viewUpd.histStat = HistTotal(addressStat.hist.wrHist.Add(ipHeader.usTotalLength));
                                viewUpd.histStat = HistTotal(addressStat.hist.wrHist.Set(viewUpd.addrStat));
                                break;
                            default:
                                break;
                        }

                        Monitor.Exit(this.captureStats);
                        statView.Invoke(updateListView, new object[] { viewUpd });
                    }


                    break;

                case Protocol.Unknown:
                    break;
            }

            if (showTraffic && rootNode != null)
            {
                bool showIt = true;
                string addressStr = ipNum.ToString();
                foreach (IpFilter ipFilter in trafficFilters)
                {
                    showIt = ipFilter.ipPattern.IsMatch(addressStr);
                    if (showIt)
                        break;
                }

                if (showIt)
                {
                    if (ipHeader.SourceAddress.Address == localIp.Address)
                    {
                        rootNode.Text = "-> " + ipHeader.DestinationAddress.ToString();
                    }
                    else if (ipHeader.DestinationAddress.Address == localIp.Address)
                    {
                        rootNode.Text = "<- " + ipHeader.SourceAddress.ToString();
                    }
                    else
                    {
                        rootNode.Text = "~~ " + ipHeader.SourceAddress.ToString() + "-" +
                            ipHeader.DestinationAddress.ToString();
                    }

                    rootNode.Text += " " + DateTime.Now.ToString("T", DateTimeFormatInfo.InvariantInfo) +"." + DateTime.Now.Millisecond.ToString("D3");
                    
                    //Thread safe adding of the nodes
                    AddTreeNode addTreeNode = new AddTreeNode(OnAddTreeNode);
                    trafficTree.Invoke(addTreeNode, new object[] { rootNode });
                }
            }
        }

        /// <summary>
        /// Get hostname for ip, use local cache to improve performance and avoid side traffic.
        /// </summary>
        private string GetHostFromAddress(IPAddress ipAddress)
        {
            string hostname;
            if (IpToHostDictionary.TryGetValue(ipAddress.Address, out hostname))
                return hostname;

            hostname = ipAddress.ToString();

            bool orgCaptureTraffic = captureTraffic;
            captureTraffic = false;

            try
            {
                IPHostEntry ipentry = Dns.Resolve(ipAddress.ToString());
                hostname = ipentry.HostName;
            }
            catch { }
            captureTraffic = orgCaptureTraffic;

            IpToHostDictionary[ipAddress.Address] = hostname;
            return hostname;
        }

        #endregion


        #region ==== Network Traffic Tree
        //Helper function which returns the information contained in the IP header as a tree node
        private TreeNode MakeIPTreeNode(IPHeader ipHeader)
        {
            TreeNode ipNode = new TreeNode();

            ipNode.Text = "IP";
            ipNode.Nodes.Add("Ver: " + ipHeader.Version);
            ipNode.Nodes.Add("Header Length: " + ipHeader.HeaderLength);
            ipNode.Nodes.Add("Differntiated Services: " + ipHeader.DifferentiatedServices);
            ipNode.Nodes.Add("Total Length: " + ipHeader.TotalLength);
            ipNode.Nodes.Add("Identification: " + ipHeader.Identification);
            ipNode.Nodes.Add("Flags: " + ipHeader.Flags);
            ipNode.Nodes.Add("Fragmentation Offset: " + ipHeader.FragmentationOffset);
            ipNode.Nodes.Add("Time to live: " + ipHeader.TTL);
            switch (ipHeader.ProtocolType)
            {
                case Protocol.TCPv4:
                    ipNode.Nodes.Add("Protocol: " + "TCPv4");
                    break;
                case Protocol.TCPv6:
                    ipNode.Nodes.Add("Protocol: " + "TCPv6");
                    break;
                case Protocol.UDP:
                    ipNode.Nodes.Add("Protocol: " + "UDP");
                    break;
                case Protocol.Unknown:
                    ipNode.Nodes.Add("Protocol: " + "Unknown");
                    break;
            }
            ipNode.Nodes.Add("Checksum: " + ipHeader.Checksum);
            ipNode.Nodes.Add("Source: " + ipHeader.SourceAddress.ToString());
            ipNode.Nodes.Add("Destination: " + ipHeader.DestinationAddress.ToString());

            return ipNode;
        }

        //Helper function which returns the information contained in the TCP header as a tree node
        private TreeNode MakeTCPTreeNode(TCPHeader tcpHeader)
        {
            TreeNode tcpNode = new TreeNode();

            tcpNode.Text = "TCP";

            tcpNode.Nodes.Add("Source Port: " + tcpHeader.SourcePort);
            tcpNode.Nodes.Add("Destination Port: " + tcpHeader.DestinationPort);
            tcpNode.Nodes.Add("Sequence Number: " + tcpHeader.SequenceNumber);

            if (tcpHeader.AcknowledgementNumber != "")
                tcpNode.Nodes.Add("Acknowledgement Number: " + tcpHeader.AcknowledgementNumber);

            tcpNode.Nodes.Add("Header Length: " + tcpHeader.HeaderLength);
            tcpNode.Nodes.Add("Flags: " + tcpHeader.Flags);
            tcpNode.Nodes.Add("Window Size: " + tcpHeader.WindowSize);
            tcpNode.Nodes.Add("Checksum: " + tcpHeader.Checksum);

            if (tcpHeader.UrgentPointer != "")
                tcpNode.Nodes.Add("Urgent Pointer: " + tcpHeader.UrgentPointer);

            return tcpNode;
        }

        //Helper function which returns the information contained in the UDP header as a tree node
        private TreeNode MakeUDPTreeNode(UDPHeader udpHeader)
        {
            TreeNode udpNode = new TreeNode();

            udpNode.Text = "UDP";
            udpNode.Nodes.Add("Source Port: " + udpHeader.SourcePort);
            udpNode.Nodes.Add("Destination Port: " + udpHeader.DestinationPort);
            udpNode.Nodes.Add("Length: " + udpHeader.Length);
            udpNode.Nodes.Add("Checksum: " + udpHeader.Checksum);

            return udpNode;
        }

        //Helper function which returns the information contained in the DNS header as a tree node
        private TreeNode MakeDNSTreeNode(byte[] byteData, int nLength)
        {
            DNSHeader dnsHeader = new DNSHeader(byteData, nLength);

            TreeNode dnsNode = new TreeNode();

            dnsNode.Text = "DNS";
            dnsNode.Nodes.Add("Identification: " + dnsHeader.Identification);
            dnsNode.Nodes.Add("Flags: " + dnsHeader.Flags);
            dnsNode.Nodes.Add("Questions: " + dnsHeader.TotalQuestions);
            dnsNode.Nodes.Add("Answer RRs: " + dnsHeader.TotalAnswerRRs);
            dnsNode.Nodes.Add("Authority RRs: " + dnsHeader.TotalAuthorityRRs);
            dnsNode.Nodes.Add("Additional RRs: " + dnsHeader.TotalAdditionalRRs);

            return dnsNode;
        }

        private void OnAddTreeNode(TreeNode node)
        {
            if (trafficTree.Nodes.Count < this.maxTraffic)
            {
                trafficTree.Nodes.Add(node);
                this.trafficCnt.Text = trafficTree.Nodes.Count.ToString();
            }
            else
            {
                // trafficBtn_Click(null, EventArgs.Empty);    // toggle traffic off.
            }

            if (logTrafficWriter != null)
            {
                try
                {
                    LogTraffic(node, 0);
                }
                catch { }
            }
        }


        private void trafficBtn_Click(object sender, EventArgs e)
        {
            this.showTraffic = !this.showTraffic;
            trafficBtn.Image = this.showTraffic ?
                global::nsNetPeak.Properties.Resources.green24 :
                global::nsNetPeak.Properties.Resources.red24;
            this.infoLayer.Visible = !this.showTraffic;
        }

        private void trafficTitem_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem dropItem = (ToolStripDropDownItem)sender;
            ToolStripDropDownMenu dropMenu = dropItem.DropDown.OwnerItem.Owner as ToolStripDropDownMenu;

            switch (dropItem.Text)
            {
                case "Clear":
                    this.trafficTree.Nodes.Clear();
                    this.trafficCnt.Text = "";
                    break;
                case "Export":
                    // TODO - support node export
                    break;
                case "Print":
                    // TODO - support node print
                    break;
            }
        }

        string logFilename;
        TextWriter logTrafficWriter;
        bool logCsv = false;
        UInt32 logLine = 0;
        ArrayList logCsvName;
        ArrayList logCsvData;

        // List<string> logCsvColumns = new List<string>();

        private void LogTraffic(TreeNode node, int depth)
        {
            if (logCsv)
            {
                // CSV collects all column headers and data in arrays
                // and writes final result on a single line.

                if (depth == 0)
                    logCsvData.Clear();

                string[] nameValue = node.Text.Split(':');
                if (nameValue.Length == 2)
                {
                    string preFix = node.Parent.Text;
                    string name = preFix + " " + nameValue[0];
                    int idx = logCsvName.IndexOf(name);
                    if (idx == -1)
                        idx = logCsvName.Add(name);

                    while (idx >= logCsvData.Count)
                        logCsvData.Add("");
                    logCsvData[idx] += nameValue[1];
                }

                foreach (TreeNode node2 in node.Nodes)
                {
                    LogTraffic(node2, depth + 1);
                }

                if (depth == 0)
                {
                    if (logLine == 0)
                    {
                        logTrafficWriter.Write("Dir, Ip, Time,");
                        for (int idx = 0; idx < logCsvName.Count; idx++)
                        {
                            logTrafficWriter.Write(", ");
                            logTrafficWriter.Write(logCsvName[idx]);
                        }
                        logTrafficWriter.WriteLine();
                    }

                    string[] ipTime = node.Text.Split(' ');
                    logTrafficWriter.Write("{0}, {1}, {2},", ipTime);
                    for (int idx = 0; idx < logCsvData.Count; idx++)
                    {
                        logTrafficWriter.Write(", ");
                        logTrafficWriter.Write(logCsvData[idx]);
                    }
                    logTrafficWriter.WriteLine();
                    logLine++;
                }
            }
            else
            {
                // dump node tree
                for (int i = 0; i < depth; i++)
                    logTrafficWriter.Write("  ");

                logTrafficWriter.WriteLine(node.Text);
                foreach (TreeNode node2 in node.Nodes)
                {
                    LogTraffic(node2, depth + 1);
                }

                logLine++;      // counting packets, not lines
            }

            this.trafficCnt.Text = logLine.ToString();
        }

        private void logTitem_Click(object sender, EventArgs e)
        {
            if (logTitem.Checked)
            {
                logTitem.Checked = (saveFileDialog.ShowDialog() == DialogResult.OK);
            }

            if (logTitem.Checked)
            {
                logFilename = saveFileDialog.FileName;
                try
                {
                    logTrafficWriter = new StreamWriter(logFilename);

                    logCsv = (string.Compare(".csv", Path.GetExtension(logFilename), true) == 0);
                    logLine = 0;
                    if (logCsv)
                    {
                        logCsvName = new ArrayList();
                        logCsvData = new ArrayList();
                    }

                    SetStatus("Started to log traffic to file:" + logFilename, false);
                    
                    if (trafficTree.Nodes.Count > 0)
                        LogTraffic(trafficTree.Nodes[0], 0);
                }
                catch
                {
                    SetStatus("Failed to open Traffic log file:" + logFilename, true);
                    logTrafficWriter = null;
                    logTitem.Checked = false;
                }
            }
            else if (logTrafficWriter != null)
            {
                logTrafficWriter.Close();
                logTrafficWriter = null;
            }


            logTitem.Image = logTitem.Checked ? global::nsNetPeak.Properties.Resources.check_on :
                global::nsNetPeak.Properties.Resources.check_off;

        }

        #endregion

        #region ==== Stat ListView methods
        /// <summary>
        /// Format number per units
        /// </summary>
        string ToUnitString(ulong num)
        {
            double dnum = num;
            const uint KB = 1024;
            const uint MB = KB * 1024;
            const uint GB = MB * 1024;

            switch (units)
            {
                case "":
                case "Bytes":
                    return num.ToString();
                case "KiloBytes":
                    dnum /= KB;
                    break;
                case "MegaBytes":
                    dnum /= MB;
                    break;
                case "GigaBytes":
                    dnum /= GB;
                    break;
                case "AutoSize":
                    if (dnum > GB)
                        return (dnum / GB).ToString("F2") + " GB";
                    else if (dnum > MB)
                        return (dnum / MB).ToString("F2") + " MB";
                    else if (dnum > KB)
                        return (dnum / KB).ToString("F2") + " KB";
                    break;
            }

            return dnum.ToString("F2");
        }

        /// <summary>
        ///  Add basic stuff to ListView
        /// </summary>
        private ListViewItem AddToView(long address, Portpair ports)
        {
            IPAddress ipAddress = new IPAddress(address);
            string hostname = GetHostFromAddress(ipAddress);

            // Disable sorter before add, so add goes to bottom.
            IComparer sorter = this.statView.ListViewItemSorter;
            this.statView.ListViewItemSorter = null;

            ListViewItem item = this.statView.Items.Add("");

            this.tableSizeBox.Text = this.statView.Items.Count.ToString();

            for (int i = 0; i < nvCols; i++)
                item.SubItems.Add(string.Empty);

            item.SubItems[nvColG].Text = "";
            item.SubItems[nvColG].Tag = 0UL;
            item.SubItems[nvColGc].Text = graphColumns[0];
            item.SubItems[nvColT].Text = "";
            item.SubItems[nvColHost].Text = hostname;
            item.SubItems[nvColIp].Text = ipAddress.ToString();
            item.SubItems[nvColLocal].Text = ports.local.ToString();
            item.SubItems[nvColRemote].Text = ports.remote.ToString();

            UpdateReportSize(item.SubItems[nvColRead], 0);      // read
            UpdateReportSize(item.SubItems[nvColWrite], 0);     // write
            UpdateReportCount(item.SubItems[nvColNread], 0);    // #read
            UpdateReportCount(item.SubItems[nvColNwrite], 0);   // #write
            item.SubItems[nvColTime].Text = "";                 //  max time
            item.SubItems[nvColTime].Tag = DateTime.MinValue;   // 
            item.SubItems[nvColRTime].Tag = DateTime.MinValue;  //  read Time
            item.SubItems[nvColWTime].Tag = DateTime.MinValue;  //  write Time

            // restore sorter.
            this.statView.ListViewItemSorter = sorter;
#if false
            // TODO - auto trim on add.
            statView.Sort();
            int itemHeight = this.statView.GetItemRect(0).Height;
            for (int idx = this.statView.Items.Count - 1; idx >= 10; idx--)
            {
                if (itemHeight * idx > this.statView.DisplayRectangle.Height)
                {
                     if (this.statView.Items[idx].Checked)
                     {
                         itemHeight--;   // don't delete any checked items.
                     }
                     else
                     {
                         this.statView.Items.Remove(this.statView.Items[idx]);
                     }
                }
            }
#endif
            return item;
        }

        private void UpdateReportSize(ListViewItem.ListViewSubItem item, ulong num)
        {
            item.Text = ToUnitString(num);
            item.Tag = num;
        }
        private void UpdateReportCount(ListViewItem.ListViewSubItem item, ulong num)
        {
            item.Text = num.ToString();
            item.Tag = num;
        }

        private void AddToView(long address, Portpair ports, DataStat stat)
        {
            ListViewItem item = AddToView(address, ports);

            UpdateReportSize(item.SubItems[nvColRead], stat.rdStat.size);
            UpdateReportSize(item.SubItems[nvColWrite], stat.wrStat.size);
            UpdateReportCount(item.SubItems[nvColNread], stat.rdStat.count);
            UpdateReportCount(item.SubItems[nvColNwrite], stat.wrStat.count);
            DateTime dt = MaxTime(stat.rdStat.time, stat.wrStat.time);
            item.SubItems[nvColTime].Text = dt.ToLongTimeString();
            item.SubItems[nvColTime].Tag = dt;
            item.SubItems[nvColRTime].Tag = stat.rdStat.time;
            item.SubItems[nvColWTime].Tag = stat.wrStat.time;
        }

        private void AddToView(long address, Portpair ports, DataHistory hist)
        {
            ListViewItem item = AddToView(address, ports);
            DirStat rdStat = HistTotal(hist.rdHist);
            DirStat wrStat = HistTotal(hist.wrHist);

            UpdateReportSize(item.SubItems[nvColRead], rdStat.size);
            UpdateReportSize(item.SubItems[nvColWrite], wrStat.size);
            UpdateReportCount(item.SubItems[nvColNread], rdStat.count);
            UpdateReportCount(item.SubItems[nvColNwrite], wrStat.count);

            DateTime dt = MaxTime(rdStat.time, wrStat.time);
            item.SubItems[nvColTime].Text = dt.ToLongTimeString();
            item.SubItems[nvColTime].Tag = dt;
            item.SubItems[nvColRTime].Tag = rdStat.time;
            item.SubItems[nvColWTime].Tag = wrStat.time;
        }

        private ListViewItem Find(ListViewItem item, string host, string local, string remote)
        {
            int idx;
            int cnt = this.statView.Items.Count;
            for (idx = item.Index; idx < cnt; idx++)
            {
                if (item.SubItems[nvColHost].Text == host &&
                    item.SubItems[nvColLocal].Text == local &&
                    item.SubItems[nvColRemote].Text == remote)
                {
                    return item;
                }
            }

            return null;
        }

        UInt32 excludeCount = 0;
        private void OnUpdateListView(ViewUpd viewUpd)
        {
            IPAddress ipAddress = new IPAddress(viewUpd.address);
            string hostname = GetHostFromAddress(ipAddress);

            string ipAddressStr = ipAddress.ToString();
            string localPortStr = viewUpd.ports.local.ToString();
            string remotePortStr = viewUpd.ports.remote.ToString();
            foreach (IpFilter ipFilter in excludeFilters)
            {
                if (ipFilter.ipPattern.IsMatch(ipAddressStr) &&
                    ipFilter.lportPattern.IsMatch(localPortStr) &&
                    ipFilter.rportPattern.IsMatch(remotePortStr))
                {
                    excludeCount++;
                    filterBox.Text = excludeCount.ToString();
                    return;
                }
            }

            // Find first matching list item.
            ListViewItem item = this.statView.FindItemWithText(hostname);

            // Depending on mode, search for specific item.
            switch (viewStat)
            {
                case ViewStat.eSummary:
                    viewUpd.ports = new Portpair();    // in summary mode set ports to zero.
                    break;
                case ViewStat.eDetail:
                    if (item != null)
                    {
                        // Find exact match on ports
                        string localStr = viewUpd.ports.local.ToString();
                        string remoteStr = viewUpd.ports.remote.ToString();
                        item = Find(item, hostname, localStr, remoteStr);
                    }
                    break;
            }

            if (item == null)
            {
                // No match add a new one.
                item = AddToView(viewUpd.address, viewUpd.ports);
            }

            if (item != null)
            {
                // Get correct stat info
                DirStat updStat = null;
                switch (viewStat)
                {
                    case ViewStat.eSummary:
                        // updStat = viewUpd.addrStat;
                        updStat = viewUpd.histStat;
                        break;
                    case ViewStat.eDetail:
                        updStat = viewUpd.portStat;
                        break;
                }

                // Update correct fields
                switch (viewUpd.ipDir)
                {
                    case IpDir.eRead:
                        UpdateReportSize(item.SubItems[nvColRead], updStat.size);
                        UpdateReportCount(item.SubItems[nvColNread], updStat.count);
                        item.SubItems[nvColRTime].Tag = updStat.time;
                        break;
                    case IpDir.eWrite:
                        UpdateReportSize(item.SubItems[nvColWrite], updStat.size);
                        UpdateReportCount(item.SubItems[nvColNwrite], updStat.count);
                        item.SubItems[nvColWTime].Tag = updStat.time;
                        break;
                }

                item.SubItems[nvColTime].Text = updStat.time.ToLongTimeString();
                item.SubItems[nvColTime].Tag = updStat.time;
            }
        }

        private void UpdateStatView()
        {
            // Save currentn state before update.
            int viewCnt = this.statView.Items.Count;
            SortedList<string, ViewState> viewStateList = new SortedList<string, ViewState>();
            for (int vIdx = 0; vIdx < viewCnt; vIdx++)
            {
                ListViewItem vItem = this.statView.Items[vIdx];
                ViewState vState;
              
                if (viewStateList.TryGetValue(ViewKey(vItem), out vState))
                {
                    vState.graph |= vItem.Checked;
                    if (vItem.Checked)
                    {
                        vState.graphType = vItem.SubItems[nvColGc].Text;
                        vState.traffic = vItem.SubItems[nvColT].Text;
                    }
                }
                else
                {
                    vState.graph = vItem.Checked;
                    vState.graphType = vItem.SubItems[nvColGc].Text;
                    vState.traffic = vItem.SubItems[nvColT].Text;
                    viewStateList.Add(ViewKey(vItem), vState);
                }
            }

            this.statView.Items.Clear();
            this.statView.BeginUpdate();

            Monitor.Enter(this.captureStats);
            switch (this.viewStat)
            {
                case ViewStat.eSummary:
                    Portpair noPorts = new Portpair();
                    foreach (long address in this.captureStats.Keys)
                    {
                        AddressStat addressStat = this.captureStats[address];
                        if (TotalPeriod == 0)
                            AddToView(address, noPorts, addressStat.stat);
                        else
                            AddToView(address, noPorts, addressStat.hist);
                    }
                    break;

                case ViewStat.eDetail:
                    foreach (long address in this.captureStats.Keys)
                    {
                        AddressStat addressStat = this.captureStats[address];
                        foreach (Portpair ports in addressStat.ipDict.Keys)
                        {
                            DataStat ipStat = addressStat.ipDict[ports];
                            AddToView(address, ports, ipStat);
                        }
                    }
                    break;
            }
            Monitor.Exit(this.captureStats);

            foreach (ListViewItem vItem in this.statView.Items)
            {
                ViewState vState;
                if (viewStateList.TryGetValue(ViewKey(vItem), out vState))
                {
                    vItem.Checked = vState.graph;
                    vItem.SubItems[nvColG].Tag = vState.graph ? 100UL : 0UL;
                    vItem.SubItems[nvColGc].Text = vState.graphType;
                    vItem.SubItems[nvColT].Text = vState.traffic;
                }
            }
            this.statView.EndUpdate();
        }

        #endregion


        #region ==== Stat ListView Menu/buttons

        private void viewSummarylMenu_Click(object sender, EventArgs e)
        {
            if (this.viewStat != ViewStat.eSummary)
            {
                this.viewDetailMitem.Checked = false;
                this.viewSummaryMitem.Checked = true;
                this.viewStat = ViewStat.eSummary;
                this.viewMitem.Text = "View Summary";
                UpdateStatView();
            }
        }

        private void viewDetailMenu_Click(object sender, EventArgs e)
        {
            if (this.viewStat != ViewStat.eDetail)
            {
                this.viewSummaryMitem.Checked = false;
                this.viewDetailMitem.Checked = true;
                this.viewStat = ViewStat.eDetail;
                this.viewMitem.Text = "View Detail";
                UpdateStatView();
            }
        }

 
        private void trimMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem dropItem = (ToolStripDropDownItem)sender;
            ToolStripDropDownMenu dropMenu = dropItem.DropDown.OwnerItem.Owner as ToolStripDropDownMenu;

            dropMenu.OwnerItem.Text = dropItem.Text;
            dropItem.OwnerItem.Image = dropItem.Image;

            if (trim != dropItem.Text)
            {
                trim = dropItem.Text;
                UpdateStatView();
            }
        }

 
        private void ListViewClear(ListView listView)
        {
            if (listView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listView.SelectedItems)
                    listView.Items.Remove(item);
            }
            else
            {
                listView.Items.Clear();
            }
        }

        private void clearMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem dropItem = (ToolStripDropDownItem)sender;
            switch (dropItem.Text)
            {
                case "Clear":
                    ListViewClear(this.statView);
                    break;
                case "Delete":
                    if (this.statView.SelectedItems.Count == 0)
                        MessageBox.Show("Select one or more stat lines to delete");
                    else
                    {
                        DeleteStats(FillAddrPortList(this.statView));
                        ListViewClear(this.statView);
                    }
                    break;
            }
        }

        private void DeleteStats(AddrPort[] addrPortList)
        {
            // TODO - deal with history

            Monitor.Enter(this.captureStats);
            foreach (AddrPort addrPort in addrPortList)
            {
                if (this.captureStats[addrPort.address].ipDict.ContainsKey(addrPort.ports))
                {
                    this.captureStats[addrPort.address].stat.rdStat.Sub(
                        this.captureStats[addrPort.address].ipDict[addrPort.ports].rdStat);
                    this.captureStats[addrPort.address].stat.wrStat.Sub(
                        this.captureStats[addrPort.address].ipDict[addrPort.ports].wrStat);

                    this.captureStats[addrPort.address].ipDict.Remove(addrPort.ports);
                }
                else
                {
                    this.captureStats.Remove(addrPort.address);
                }
            }

            foreach (AddrPort addrPort in addrPortList)
            {
                if (this.captureStats.ContainsKey(addrPort.address) &&
                    this.captureStats[addrPort.address].ipDict.Keys.Count == 0)
                {
                    this.captureStats.Remove(addrPort.address);
                }
            }

            Monitor.Exit(this.captureStats);
        }


        private void layoutMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem dropItem = (ToolStripDropDownItem)sender;

            switch (dropItem.Text)
            {
                case "Table":
                    this.ViewPanels(WhichPanel.eViewTable, TriState.eToggle);
                    break;
                case "Graph":
                    this.ViewPanels(WhichPanel.eViewGraph, TriState.eToggle);
                    break;
                case "Traffic":
                    this.ViewPanels(WhichPanel.eViewTraffic, TriState.eToggle);
                    break;
            }
        }

        Dictionary<string, string> UnitToHdr = new Dictionary<string, string>();

        private void StatHeaderUnits()
        {
            if (UnitToHdr.Count == 0)
            {
                UnitToHdr.Add("AutoSize", "");
                UnitToHdr.Add("Bytes", "Bytes");
                UnitToHdr.Add("KiloBytes", "KB");
                UnitToHdr.Add("MegaBytes", "MB");
                UnitToHdr.Add("GigaBytes", "GB");
            }

            string unitStr = UnitToHdr[units];
            string perSec = (TotalPeriod > 0) ? "/sec" : "";
            unitStr += perSec;
            this.statView.Columns[nvColRead].Text = "Read" + unitStr;
            this.statView.Columns[nvColWrite].Text = "Write" + unitStr;
            this.statView.Columns[nvColNread].Text = "#Read" + perSec;
            this.statView.Columns[nvColNwrite].Text = "#Write" + perSec;
        }

        /// <summary>
        ///  Process Unit dropdown menu
        /// </summary>
        private void unitMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem dropItem = (ToolStripDropDownItem)sender;
            ToolStripDropDownMenu dropMenu = dropItem.DropDown.OwnerItem.Owner as ToolStripDropDownMenu;

            foreach (ToolStripDropDownItem item in dropMenu.Items)
                item.Image = Properties.Resources.check_off;

            dropItem.Image = Properties.Resources.check_on;
            dropMenu.OwnerItem.Text = dropItem.Text;

            if (units != dropItem.Text)
            {
                units = dropItem.Text;
                StatHeaderUnits();
                UpdateStatView();
            }
        }


        private void totalMitem_ButtonClick(object sender, EventArgs e)
        {
            ToolStripDropDownItem dropItem = (ToolStripDropDownItem)sender;
            ToolStripDropDownMenu dropMenu = dropItem.DropDown.OwnerItem.Owner as ToolStripDropDownMenu;

            int cnt = dropMenu.Items.Count;
            for (int idx = 0; idx < cnt; idx++)
            {
                ToolStripDropDownItem item = dropMenu.Items[idx] as  ToolStripDropDownItem;
                if (item != null && item.Tag == dropItem.Tag)
                    item.Image = Properties.Resources.check_off;
            }

            bool tPerSec = TotalPerSecond;
            int tPeriod = TotalPeriod;
            bool imageOn = true;

            switch (dropItem.Text)
            {
                case "No Totals":
                    tPeriod = 0;
                    break;
                case "5 Minutes":
                    tPeriod = 5;
                    break;
                case "10 Minutes":
                    tPeriod = 10;
                    break;
                case "30 Minutes":
                    tPeriod = 30;
                    break;
                case "Hourly":
                    tPeriod = 60;
                    break;
                case "Per Second":
                    tPerSec = !tPerSec;
                    imageOn = tPerSec;
                    break;
            }

            dropItem.Image = imageOn ? Properties.Resources.check_on : Properties.Resources.check_off;
            if (dropItem.Tag == null)
                dropMenu.OwnerItem.Text = dropItem.Text;

            if (tPeriod != TotalPeriod || tPerSec != TotalPerSecond)
            {
                TotalPerSecond = tPerSec;
                TotalPeriod = tPeriod;
                UpdateStatView();
            }
        }

        private void tableMenu_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem dropItem = (ToolStripDropDownItem)sender;

            switch (dropItem.Text)
            {
                case "Delete":
                    clearMenuItem_Click(sender,  e);
                    break;
                case "Clear":
                    clearMenuItem_Click(sender, e);
                    break;
                case "Resize Columns":
                    ReSizeColumns(this.statView);
                    break;
                case "Print":
                    printLV.Print(this, this.statView, "Network Statistics");
                    break;
            }
        }

        // Stat View graph data selector column.
        string[] graphColumns = new string[7] { "r/w", "r", "w", "#r/#w", "#r", "#w", "time" };
     
        private void statView_Click(object sender, EventArgs e)
        {
            Point p = this.statView.PointToClient(System.Windows.Forms.Control.MousePosition);
            ListViewItem itemAt = this.statView.GetItemAt(p.X, p.Y);
            if (itemAt != null)
            {
                if (itemAt.SubItems[nvColGc].Bounds.Contains(p))
                {
                    string s = itemAt.SubItems[nvColGc].Text;
                    int gcIdx = Array.FindIndex<string>(graphColumns, delegate(string s1) { return s1 == s; });
                    itemAt.SubItems[nvColGc].Text = graphColumns[(gcIdx + 1) % graphColumns.Length];
                }
                else if (itemAt.SubItems[nvColT].Bounds.Contains(p))
                {
                    bool on = (itemAt.SubItems[nvColT].Text == trafficOnStr);
                    on = !on;
                    itemAt.SubItems[nvColT].Text = on ? trafficOnStr : trafficOffStr;
                }
            }
        }

        private void statView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            historyPanel.Visible = (this.statView.CheckedItems.Count != 0);
            e.Item.SubItems[0].Tag = e.Item.Checked ? 100UL : 0UL;
            if (e.Item.Checked == false)
                graphReset = -1;
        }

        private void statView_KeyUp(object sender, KeyEventArgs e)
        {
        
            // General purpose key actions.
            switch (e.KeyCode)
            {
                case Keys.A:
                    if (e.Modifiers == Keys.Control)
                    {
                        this.statView.SelectedItems.Clear();
                        foreach (ListViewItem sItem in this.statView.Items)
                            sItem.Selected = true;
                    }
                    break;
            }

            // Keys acting on list items.
            Point p = statView.PointToClient(Control.MousePosition);
            ListViewItem item = statView.GetItemAt(p.X, p.Y);

            if (item != null)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        if (item.Index > 0)
                        {
                            this.statView.Items[item.Index - 1].Focused = true;
                        }
                        break;
                    case Keys.Down:
                        if (item.Index < this.statView.Items.Count - 1)
                        {
                            this.statView.Items[item.Index + 1].Focused = true;
                        }
                        break;
                    case Keys.Space:
                        item.Selected = !item.Selected;
                        break;
                    case Keys.T:
                        item.SubItems[nvColT].Text = (item.SubItems[nvColT].Text == trafficOnStr) ?
                            trafficOffStr : trafficOnStr;
                        break;
                }
            }
        }

        private void statView_SelectedIndexChanged(object sender, EventArgs e)
        {
            historyPanel.Visible = (this.statView.CheckedItems.Count != 0);

            if (this.statView.SelectedItems.Count > 0)
            {
                ListViewItem item = this.statView.SelectedItems[0];
                ulong rdBytes = (ulong)item.SubItems[nvColRead].Tag;
                ulong wrBytes = (ulong)item.SubItems[nvColWrite].Tag;
                ulong rdCnt = (ulong)item.SubItems[nvColNread].Tag;
                ulong wrCnt = (ulong)item.SubItems[nvColNwrite].Tag;
                DateTime dt = (DateTime)item.SubItems[nvColTime].Tag;
                DateTime dtR = (DateTime)item.SubItems[nvColRTime].Tag;
                DateTime dtW = (DateTime)item.SubItems[nvColWTime].Tag;

                string msg = string.Format("{0} {1} Read:{2:d} #Read:{3:d} {4:G} | Write:{5:d} #Write:{6:d} {7:G}",
                    item.SubItems[nvColHost].Text,              // 0
                    (TotalPerSecond ? "(Per Second)" : ""),     // 1
                    rdBytes,                                    // 2
                    rdCnt,                                      // 3
                    dtR,                                        // 4
                    wrBytes,                                    // 5
                    wrCnt,                                      // 6
                    dtW);                                       // 7

                SetStatus(msg, false);

                historyPanel.Visible = true;
                UpdateHistoryView();
            }

        }


        #endregion


        #region ==== Panel Views

        enum WhichPanel { eViewTable, eViewGraph, eViewTraffic };
        enum TriState { eOff, eOn, eToggle };
        int trafficWidth;
        int tableHeight;
        int graphHeight;

        private int  ViewPanel(TriState triState, SplitContainer split, int which, int dist)
        {
            SplitterPanel panel = (which == 1) ? split.Panel1 : split.Panel2;
            if (triState == TriState.eToggle)
                triState = panel.Visible ? TriState.eOff : TriState.eOn;

            Image bgImage = split.BackgroundImage;
            split.BackgroundImage = null;
            if (triState == TriState.eOn && panel.Visible == false)
            {
                split.SplitterDistance = dist;
                panel.Visible = true;
            }
            else if (triState == TriState.eOff && panel.Visible == true)
            {
                dist = split.SplitterDistance;
                int maxVH = (split.Orientation == Orientation.Vertical) ? split.Height : split.Width;
                split.SplitterDistance = (which == 1) ? 0 : maxVH;
                panel.Visible = false;
            }
            split.BackgroundImage = bgImage;

            return dist;
        }
        private void ViewPanels(WhichPanel viewPanel, TriState triState)
        {
            switch (viewPanel)
            {
                case WhichPanel.eViewTable:
                    tableHeight = ViewPanel(triState, splitViewGraph, 1, tableHeight);
                    break;
                case WhichPanel.eViewGraph:
                    graphHeight = ViewPanel(triState, splitViewGraph, 2, graphHeight);
                    break;
                case WhichPanel.eViewTraffic:
                    trafficWidth = ViewPanel(triState, splitLeftRight, 1, trafficWidth);
                    break;
            }
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            Panel button = sender as Panel;
            Point p = button.PointToClient(Control.MousePosition);
            if (p.X < button.Width / 3)
            {
                ViewPanels(WhichPanel.eViewTraffic, TriState.eToggle);    
            }
            else if (p.Y < button.Height / 2)
            {
                ViewPanels(WhichPanel.eViewTable, TriState.eToggle);
            }
            else
            {
                ViewPanels(WhichPanel.eViewGraph, TriState.eToggle);
            }
        }

        #endregion


        #region ==== Exclude menu/buttons

        private void excludeBtn_Click(object sender, EventArgs e)
        {
            // Button button = sender as Button;
            // ListView listView = button.Tag as ListView;
            ListView listView = this.excludeList;

            ListViewItem item = listView.Items.Add("<new>");
            int cnt = listView.Items.Count;
            if (cnt > 0)
                listView.EnsureVisible(cnt - 1);

            ListViewEdit(listView, item);
        }

        private void excludeMenu_Click(object sender, EventArgs e)
        {
            // clear, delete, edit, expoort, resize columns
            ToolStripDropDownItem dropItem = (ToolStripDropDownItem)sender;

            switch (dropItem.Text)
            {
                case "Delete":
                    if (this.excludeList.SelectedItems.Count == 0)
                        MessageBox.Show("Select one or more exclude filters to delete");
                    else
                    {
                        foreach (ListViewItem item in this.excludeList.SelectedItems)
                        {
                            this.excludeList.Items.Remove(item);
                        }
                    }
                    break;
                case "Edit":
                    ListViewDbl_Click(this.excludeList, EventArgs.Empty);
                    break;
                case "Resize Columns":
                    ReSizeColumns(this.excludeList);
                    break;
                case "Print":
                    printLV.Print(this, this.excludeList, "Exclude Ip list");
                    break;
            }
        }

        private void excludeList_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                string excludeStr =(string)e.Data.GetData(DataFormats.Text);
                if (excludeStr != null && excludeStr.Contains("|"))
                {
                    string[] excludeParts = excludeStr.Split('|');
                    ListViewItem item = this.excludeList.Items.Add(excludeParts[0]);
                    for (int idx = 1; idx < excludeParts.Length; idx++)
                        item.SubItems.Add(excludeParts[idx]);

                    excludeListChanged = true;
                }
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fileNames = null;
                fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string fileName in fileNames)
                {
                    if (fileName != null && fileName.Length > 0)
                    {
                        //  LoadExclude(fileName);
                        excludeListChanged = true;
                    }
                }
            }

            // If we want to drop in at mouse position.
            Point ourPos = this.excludeList.PointToClient(new Point(e.X, e.Y));
            ListViewItem dropItem = this.excludeList.GetItemAt(ourPos.X, ourPos.Y);
        }

        /// <summary>
        /// Drag enter - Support text and file drops.
        /// </summary>
        private void excludeList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text) ||
                e.Data.GetDataPresent(DataFormats.FileDrop) ||
                e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                int keyShift = 4;
                e.Effect = ((e.KeyState & keyShift) != 0) ? DragDropEffects.Move : DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Start a drag (mouse move with left button down)
        /// </summary>
        private void statView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left /* && e.Clicks == 1 */)
            {
                ListViewItem item =
                    this.statView.GetItemAt(e.X, e.Y);

                if (item != null)
                {
                    string itemStr = string.Format("{0}|{1}|{2}|{3}",
                        item.SubItems[nvColHost].Text,      // hostname
                        item.SubItems[nvColIp].Text,      // ip#
                        item.SubItems[nvColLocal].Text,      // loal port#
                        item.SubItems[nvColRemote].Text       // remote port#
                        );

                    if (DoDragDrop(itemStr, DragDropEffects.Copy | DragDropEffects.Move) ==
                        DragDropEffects.Move)
                    {
                        // if required, remove item if move action.
                    }
                }
            }
            else
            {
                int colHeight = (this.statView.Items.Count == 0) ? 20 : this.statView.Items[0].Bounds.Top;
                if (e.Y < colHeight*2)
                {
                    int x = 0;
                    foreach (ColumnHeader colHdr in this.statView.Columns)
                    {
                        int colWidth = colHdr.Width;
                        if (e.X >= x && e.X <= x + colHdr.Width)
                        {
                            this.toolTip.Show(nvColHint[colHdr.Index], this.statView, 
                                e.X+10, e.Y+10, 2000);
                        }
                        x += colWidth;
                    }
                }
            }
        }

        bool excludeListChanged = false;
        private void excludeList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            excludeListChanged = true;
        }

        #endregion

        #region ==== Exclude panel buttons

        private void histBtn_Click(object sender, EventArgs e)
        {
            this.historyPanel.Visible = true;
            this.trafficPanel.Visible = false;
        }

        private void trafBtn_Click(object sender, EventArgs e)
        {
            this.trafficPanel.Visible = true;
            this.historyPanel.Visible = false;
        }

        #endregion


        #region ==== Graph menu/buttons

        enum GraphType { gBar, gPie, gLine, gLineFilled };
        GraphType graphType = GraphType.gLine;
        private void graphGitem_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem dropItem = (ToolStripDropDownItem)sender;
            ToolStripDropDownMenu dropMenu = dropItem.DropDown.OwnerItem.Owner as ToolStripDropDownMenu;

            // foreach (ToolStripDropDownItem item in dropMenu.Items)
            //    item.Image = Properties.Resources.check_off;

            // dropItem.Image = Properties.Resources.check_on;
            dropMenu.OwnerItem.Text = dropItem.Text;
            dropMenu.OwnerItem.Image = dropItem.Image;

            GraphType gtype = graphType;

            switch (dropItem.Text)
            {
               case "Bar":
                    gtype = GraphType.gBar;
                   break;
               case "Pie":
                   gtype = GraphType.gPie;
                   break;
               case "Line":
                   gtype = GraphType.gLine;
                   break;
               case "Line Filled":
                   gtype = GraphType.gLineFilled;
                   break;
            }

            if (gtype != graphType)
            {
                graphType = gtype;
                graphReset = -1;
            }
        }

        private void dataGitem_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem dropItem = (ToolStripDropDownItem)sender;
            ToolStripDropDownMenu dropMenu = dropItem.DropDown.OwnerItem.Owner as ToolStripDropDownMenu;

            // foreach (ToolStripDropDownItem item in dropMenu.Items)
            //  item.Image = Properties.Resources.check_off;

            // dropItem.Image = Properties.Resources.check_on;
            dropMenu.OwnerItem.Text = dropItem.Text;
            dropMenu.OwnerItem.Image = dropItem.Image;

            switch (dropItem.Text)
            {
                case "Stack":
                    this.Graph.GraphPane.BarSettings.Type = BarType.Stack;
                    this.Graph.GraphPane.LineType = LineType.Stack;
                    this.Graph.Refresh();
                    break;
                case "Nonstacked":
                    this.Graph.GraphPane.BarSettings.Type = BarType.Cluster;
                    this.Graph.GraphPane.LineType = LineType.Normal;
                    this.Graph.Refresh();
                    break;
               
            }
        }

        private void axisGitem_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem dropItem = (ToolStripDropDownItem)sender;
            ToolStripDropDownMenu dropMenu = dropItem.DropDown.OwnerItem.Owner as ToolStripDropDownMenu;

            // foreach (ToolStripDropDownItem item in dropMenu.Items)
            //     item.Image = Properties.Resources.check_off;

            // dropItem.Image = Properties.Resources.check_on;
            dropMenu.OwnerItem.Text = dropItem.Text;
            dropMenu.OwnerItem.Image = dropItem.Image;

            bool multipleAxis = graphMultipleAxis;

            switch (dropItem.Text)
            {
                case "Single Axis":
                    multipleAxis = false;
                    break;
                case "Multiple Axis":
                    multipleAxis = true;
                    break;
            }

            if (multipleAxis != graphMultipleAxis)
            {
                graphMultipleAxis = multipleAxis;
                graphReset = -1;
            }
        }

        private void zoomGitem_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem dropItem = (ToolStripDropDownItem)sender;
            ToolStripDropDownMenu dropMenu = dropItem.DropDown.OwnerItem.Owner as ToolStripDropDownMenu;

            switch (dropItem.Text)
            {
                case "Zoom In(+)":
                    this.Graph.ZoomPane(this.Graph.GraphPane, 0.8, PointF.Empty, false);
                    break;
                case "Zoom Reset(1)":
                    // Does not work !
                    this.Graph.ZoomOutAll(this.Graph.GraphPane);
                    this.Graph.Refresh();
                    break;
                case "Zoom Out(-)":
                    this.Graph.ZoomPane(this.Graph.GraphPane, 1.2, PointF.Empty, false);
                    break;
            }
        }

        private void Graph_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Oemplus:
                    this.Graph.ZoomPane(this.Graph.GraphPane, 0.8, PointF.Empty, false);
                    break;
                case Keys.OemMinus:
                    this.Graph.ZoomPane(this.Graph.GraphPane, 1.2, PointF.Empty, false);
                    break;
                case Keys.Oem1:
                    this.Graph.ZoomOutAll(this.Graph.GraphPane);
                    this.Graph.Refresh();
                    break;
            }
            if (e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        graphXtimeSpan += new TimeSpan(0, 1, 0);
                        minGBox.Text = graphXtimeSpan.Minutes.ToString();
                        UpdateGraph();
                        break;
                    case Keys.Right:
                        if (graphXtimeSpan.Minutes > 1)
                            graphXtimeSpan -= new TimeSpan(0, 1, 0);
                        minGBox.Text = graphXtimeSpan.Minutes.ToString();
                        UpdateGraph();
                        break;
                    case Keys.Up:
                        break;
                    case Keys.Down:
                        break;
                }
            }
        }

        private void minGBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int minutes = int.Parse(minGBox.Text);
                if (minutes > 0 && minutes < 60 && minutes != graphXtimeSpan.Minutes)
                {
                    graphXtimeSpan = new TimeSpan(0, minutes, 0);
                    UpdateGraph();
                }
            }
            catch { }
        }

 
        private void clearGitem_Click(object sender, EventArgs e)
        {
            graphClear = true;
        }

        bool graphAutoScroll = true;
        private void pauseGitem_Click(object sender, EventArgs e)
        {
            graphAutoScroll = !graphAutoScroll;
            pauseGitem.Text = (graphAutoScroll) ? "Pause" : "Resume";
            pauseGitem.BackColor = (graphAutoScroll) ? System.Drawing.SystemColors.InactiveCaptionText : Color.Red;
            pauseGitem.ForeColor = (graphAutoScroll) ? Color.Black : Color.White;
        }


        private void gridlinesGitem_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem dropItem = (ToolStripDropDownItem)sender;
            ToolStripDropDownMenu dropMenu = dropItem.DropDown.OwnerItem.Owner as ToolStripDropDownMenu;

            // dropItem.Image = Properties.Resources.check_on;
            // dropMenu.OwnerItem.Text = dropItem.Text;

            switch (dropItem.Text)
            {
                case "Major X":
                    this.Graph.GraphPane.XAxis.MajorGrid.IsVisible =
                        !this.Graph.GraphPane.XAxis.MajorGrid.IsVisible;
                    break;

                case "Minor X":
                    this.Graph.GraphPane.XAxis.MinorGrid.IsVisible =
                        !this.Graph.GraphPane.XAxis.MinorGrid.IsVisible;
                    break;

                case "Major Y":
                    this.Graph.GraphPane.YAxis.MajorGrid.IsVisible =
                        !this.Graph.GraphPane.XAxis.MajorGrid.IsVisible;
                    this.graphReset = -1;
                    break;

                case "Minor Y":
                    this.Graph.GraphPane.YAxis.MinorGrid.IsVisible =
                        !this.Graph.GraphPane.XAxis.MinorGrid.IsVisible;
                    this.graphReset = -1;
                    break;

            }
        }


        private void propGitem_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem dropItem = (ToolStripDropDownItem)sender;
            ToolStripDropDownMenu dropMenu = dropItem.DropDown.OwnerItem.Owner as ToolStripDropDownMenu;

            switch (dropItem.Text)
            {
                case "Properties":
                    GraphProperties gp = new GraphProperties();
                    gp.Show(this.Graph, this.Graph.GraphPane, graphCurves, graphData);
                    break;

                case "Symbols":
                    graphReset = -1;
                    break;
            }
        }



        #endregion


        #region ==== History menu/buttons
        private void refreshHitem_Click(object sender, EventArgs e)
        {
            UpdateHistoryView();
        }

        private void histMenu_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem dropItem = (ToolStripDropDownItem)sender;

            switch (dropItem.Text)
            {
                case "Export":
                    string file = ListViewExt.Export(histView);
                    if (file.Length != 0)
                        SetStatus("Export history to file " + file, false);
                    else
                        SetStatus("Failed to export history", true);
                    break;

                case "Print":
                    printLV.Print(this, this.histView, "Ip History");
                    break;
            }
        }

        #endregion

        private void settingPanel_Click(object sender, EventArgs e)
        {
            // TODO - pass config, get any changes.

            ConfigDlg cfgdlg = new ConfigDlg();
            if (cfgdlg.ShowDialog() == DialogResult.OK)
            {
            }
        }

    }
}