using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Reflection;

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
 

namespace nsNetPeak
{

    /// <summary>
    /// Global Network Statistics Dialog.
    /// 
    /// Author: Dennis Lang 2009
    /// https://landenlabs.com/
    /// 
    /// </summary>
    public partial class GlobalStatDialog : Form
    {
        PrintListView printLV = new PrintListView();


        public GlobalStatDialog()
        {
            InitializeComponent();
            this.title.Parent = this.titleGlow;
            this.title.Location = new Point(1, 1);

            FillView();
            ListViewColumnSorter lvSorter = new ListViewColumnSorter(ListViewColumnSorter.SortDataType.eAuto);
            lvSorter.SortColumn1 = 2;
            lvSorter.SortColumn2 = 2;
            this.globalStatView.ListViewItemSorter = lvSorter;

            // Sync UI toggle and print settings.
            fitToPageBtn.Checked = printLV.FitToPage = false;

            // this.globalStatView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            // this.globalStatView.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (this.Visible)
                timer.Start();
            else
                timer.Stop();
        }

        /// <summary>
        /// Hide dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeBtn_Click(object sender, EventArgs e)
        {
            // this.Close();
            this.timer.Stop();
            this.Visible = false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;        // cancel close, just hide dialog and stop timer.
            base.OnClosing(e);
            this.timer.Stop();
            this.Visible = false;
        }

        /// <summary>
        /// Reset stats, change based off of new stat sample.
        /// </summary>
        private void resetBtn_Click(object sender, EventArgs e)
        {
            FillView();
        }

        /// <summary>
        /// Process timer - update stats
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            currentClock.Text = DateTime.Now.ToLongTimeString();
            currentClock.Tag = DateTime.Now;
            UpdateView();
        }

        /// <summary>
        /// Fill listView with initial global network statistics.
        /// </summary>
        public void FillView()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPGlobalStatistics ipStat = properties.GetIPv4GlobalStatistics();
            TcpStatistics tcpStat = properties.GetTcpIPv4Statistics();
            UdpStatistics udpStat = properties.GetUdpIPv4Statistics();
            IcmpV4Statistics icmpStat = properties.GetIcmpV4Statistics();
            TcpConnectionInformation[] tcpConnInfoList = properties.GetActiveTcpConnections();
           


            startClock.Text = DateTime.Now.ToLongTimeString();
            startClock.Tag = DateTime.Now;
            currentClock.Text = DateTime.Now.ToLongTimeString();
            currentClock.Tag = DateTime.Now;

            globalStatView.BeginUpdate();

            globalStatView.Items.Clear();
            if (ipCk.Checked)
                ReflectToList(ipStat, globalStatView, "IP", Color.FromArgb(220, 255, 220));
            if (tcpCk.Checked)
                ReflectToList(tcpStat, globalStatView, "TCP", Color.FromArgb(255, 220, 220));
            if (udpCk.Checked)
                ReflectToList(udpStat, globalStatView, "UDP", Color.FromArgb(255, 255, 220));

            if (interfacesCk.Checked)
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                Color color = Color.FromArgb(220, 220, 255);
                foreach (NetworkInterface adapter in nics)
                {
                    // Only display informatin for interfaces that support IPv4.
                    if (adapter.Supports(NetworkInterfaceComponent.IPv4) == false)
                        continue;

                    IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                    IPv4InterfaceProperties p = adapterProperties.GetIPv4Properties();
                    if (p != null)
                        ReflectToList(p, globalStatView, adapter.Description, color);

                    color = Color.FromArgb(220, 220, Math.Max(0, color.B - 60));
                }
            }

            if (tcpConnCk.Checked)
            {
                foreach (TcpConnectionInformation tcpConnInfo in tcpConnInfoList)
                {
                    ReflectToList(tcpConnInfo, globalStatView, "TcpConn", Color.FromArgb(200, 255, 255));
                }
            }

            ListViewItem item;
#if false
            try
            {
	            string biosDomain = GetMachineNetBiosDomain();
	            item = globalStatView.Items.Add("Misc");
	            item.SubItems.Add("MachineNetBiosDomain");
	            item.SubItems.Add(biosDomain);
            }
            catch { }

            try
            {
	            string netWkstaVn = GetNetWkstaVersion();
	            item = globalStatView.Items.Add("Misc");
	            item.SubItems.Add("NetWkstaVersion");
	            item.SubItems.Add(netWkstaVn);
            }
            catch { }
#endif

            globalStatView.EndUpdate();
        }

        public void UpdateView()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPGlobalStatistics ipStat = properties.GetIPv4GlobalStatistics();
            TcpStatistics tcpStat = properties.GetTcpIPv4Statistics();
            UdpStatistics udpStat = properties.GetUdpIPv4Statistics();
            IcmpV4Statistics icmpStat = properties.GetIcmpV4Statistics();
            TcpConnectionInformation[] tcpConnInfoList = properties.GetActiveTcpConnections();

            globalStatView.BeginUpdate();

            ReflectUpdList(ipStat, ipCk.Checked, globalStatView, "IP", Color.FromArgb(220, 255, 220));
            ReflectUpdList(tcpStat, tcpCk.Checked, globalStatView, "TCP", Color.FromArgb(255, 220, 220));
            ReflectUpdList(udpStat, udpCk.Checked, globalStatView, "UDP", Color.FromArgb(255, 255, 220));

            if (interfacesCk.Checked)
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in nics)
                {
                    if (adapter.Supports(NetworkInterfaceComponent.IPv4) == false)
                        continue;
                    IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                    IPv4InterfaceProperties p = adapterProperties.GetIPv4Properties();
                    if (p != null)
                        RemoveItems(adapter.Description, globalStatView);
                }
            }

            RemoveItems("TcpConn", globalStatView);

            if (tcpConnCk.Checked)
            {
                foreach (TcpConnectionInformation tcpConnInfo in tcpConnInfoList)
                {
                    ReflectToList(tcpConnInfo, globalStatView, "TcpConn", Color.FromArgb(200, 255, 255));
                }
            }

            globalStatView.EndUpdate();
        }

        private void RemoveItems(string key, ListView listView)
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Text == key)
                    listView.Items.Remove(item);
            }
        }

        // Set presentation style based on item contents (such as word Error or Fail).
        private void SetStyle(ListViewItem item)
        {
            if (item.SubItems[1].Text.Contains("Error") ||
                item.SubItems[1].Text.Contains("Fail"))
            {
                item.Font = new Font(item.Font, FontStyle.Bold);
                item.ForeColor = Color.DarkRed;
            }
        }

        // Use reflection to extract info from object add to ListView
        private void ReflectToList(object obj, ListView listView, string f0, Color bgColor)
        {
            Type objectType = obj.GetType();
            PropertyInfo[] props = objectType.GetProperties();
            foreach (PropertyInfo pinfo in props)
            {
                ListViewItem item = listView.Items.Add(f0);
                item.SubItems.Add(pinfo.Name);
                item.SubItems.Add(pinfo.GetValue(obj, null).ToString());
                item.SubItems.Add("");
                item.SubItems.Add(pinfo.GetValue(obj, null).ToString());
                item.BackColor = bgColor;
                SetStyle(item);
            }
        }

        // Use reflection to extract info from object add to ListView and update Change column.
        private void ReflectUpdList(object obj, bool doUpd, ListView listView, string f0, Color bgColor)
        {
            if (doUpd)
            {
                Type objectType = obj.GetType();
                PropertyInfo[] props = objectType.GetProperties();
                foreach (PropertyInfo pinfo in props)
                {
                    ListViewItem item = listView.FindItemWithText(pinfo.Name);
                    if (item != null)
                    {
                        string typName = pinfo.PropertyType.Name;
                        string typName2 = pinfo.ReflectedType.Name;

                        if (typName == "Int32")
                        {
                            Int32 o = Int32.Parse(item.SubItems[2].Text);
                            Int32 n = (Int32)pinfo.GetValue(obj, null);
                            string str = (n - o).ToString();
                            if (item.SubItems[3].Text != str)
                                item.SubItems[3].Text = str;
                        }
                        else if (typName == "Int64")
                        {
                            Int64 o = Int64.Parse(item.SubItems[2].Text);
                            Int64 n = (Int64)pinfo.GetValue(obj, null);
                            string str = (n - o).ToString();
                            if (item.SubItems[3].Text != str)
                                item.SubItems[3].Text = str;
                        }
                        else
                        {
                            // item.SubItems[3].Text = typName;
                            // item.SubItems[3].Text = (pinfo.GetValue(obj, null).ToString());
                        }

                        string str4 = pinfo.GetValue(obj, null).ToString();
                        if (item.SubItems[4].Text != str4)
                            item.SubItems[4].Text = str4;
                        SetStyle(item);
                    }

                }
            }
            else
            {
                RemoveItems(f0, listView);
            }
        }


        /// <summary>
        /// Process ToolStrip buttons
        /// </summary>
        private void toolButton_Click(object sender, EventArgs e)
        {
            ToolStripButton dropItem = sender as ToolStripButton;
            Action(dropItem.Text, sender, e);
        }

        /// <summary>
        /// Process context menu
        /// </summary>
        private void globalMitem_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem dropItem = sender as ToolStripDropDownItem;
            // ToolStripDropDownMenu dropMenu = dropItem.DropDown.OwnerItem.Owner as ToolStripDropDownMenu;
            Action(dropItem.Text, sender, e);
        }

        string PrintTitle()
        {
            return string.Format("{0}\nBegin:{1}   [{2}]   End:{3}\n",
                    this.Text,
                    ((DateTime)this.startClock.Tag).ToString("G"),
                    Dns.GetHostName(),
                    ((DateTime)this.currentClock.Tag).ToString("G"));
        }

        /// <summary>
        /// Common button/menu action execution
        /// </summary>
        private void Action(string cmd, object sender, EventArgs e)
        {
            switch (cmd)
            {
                case "Export(CSV)":
                    ListViewExt.Export(globalStatView);
                    break;

                case "Print":
                    printLV.Print(this, globalStatView, PrintTitle());
                    break;

                case "Print Preview":
                    printLV.PrintPreview(this, globalStatView, PrintTitle());
                    break;

                case "Print Setup":
                    printLV.PageSetup();
                    break;

                case "FitToPage":
                    printLV.FitToPage = fitToPageBtn.Checked;
                    break;

                case "Auto Update":
                    autoUpdateToolStripMenuItem.Checked = !timer.Enabled;
                    autoBtn.Checked = !timer.Enabled;
                    if (timer.Enabled)
                    {
                        timer.Stop();
                        this.currentClock.ForeColor = Color.Red;
                    }
                    else
                    {
                        timer.Start();
                        this.currentClock.ForeColor = Color.DarkGreen;
                    }
                    break;
                case "Refresh":
                    UpdateView();
                    break;

                default:
                    MessageBox.Show(cmd);
                    break;
            }
        }

        /// <summary>
        /// Process keyboard (+/- change font size)
        /// </summary>
        private void globalStatView_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Oemplus:
                    this.globalStatView.Font = new Font(this.globalStatView.Font.FontFamily,
                        this.globalStatView.Font.Size * 1.2f, FontStyle.Regular);
                    break;
                case Keys.OemMinus:
                    this.globalStatView.Font = new Font(this.globalStatView.Font.FontFamily,
                   this.globalStatView.Font.Size * 0.8f, FontStyle.Regular);
                    break;
            }
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

        private void ck_Click(object sender, EventArgs e)
        {
            UpdateView();
        }

        #region ==== Special Workstation api 

        [DllImport("netapi32.dll", CharSet = CharSet.Auto)]
        static extern int NetWkstaGetInfo(string server,
            int level,
            out WKSTA_INFO_100 info);
     
        [DllImport("netapi32.dll")]
        static extern int NetApiBufferFree(WKSTA_INFO_100 info);
         
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        class WKSTA_INFO_100
        {
            public int wki100_platform_id;
            public string wki100_computername;
            public string wki100_langroup;
            public int wki100_ver_major;
            public int wki100_ver_minor;
        }

       
        public static string GetMachineNetBiosDomain()
        {
            WKSTA_INFO_100 info;
            int retval = NetWkstaGetInfo(null, 100, out info);
            if (retval != 0)
                throw new Win32Exception(retval);

            string domainName = info.wki100_langroup;
            NetApiBufferFree(info);
            
            return domainName;
        }

        public static string GetNetWkstaVersion()
        {
            WKSTA_INFO_100 info;
            int retval = NetWkstaGetInfo(null, 100, out info);
            if (retval != 0)
                throw new Win32Exception(retval);

            string version = info.wki100_ver_major.ToString() + "." + info.wki100_ver_minor.ToString();
            NetApiBufferFree(info);

            return version;
        }
        #endregion

    }
}
