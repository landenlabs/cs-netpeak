namespace nsNetPeak
{
    partial class NetPeakForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetPeakForm));
            this.btnStart = new System.Windows.Forms.Button();
            this.cmbInterfaces = new System.Windows.Forms.ComboBox();
            this.statusBar = new System.Windows.Forms.TextBox();
            this.Title = new System.Windows.Forms.Label();
            this.trafficMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearTitem = new System.Windows.Forms.ToolStripMenuItem();
            this.eToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.timeLabel = new System.Windows.Forms.Label();
            this.captureImage = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitLeftRight = new System.Windows.Forms.SplitContainer();
            this.splitExcludeDetail = new System.Windows.Forms.SplitContainer();
            this.excludeToolBox = new System.Windows.Forms.ToolStripContainer();
            this.excludeList = new System.Windows.Forms.ListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.excludeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteExcludeMitem = new System.Windows.Forms.ToolStripMenuItem();
            this.editExcludeMitem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportExcludeMitem = new System.Windows.Forms.ToolStripMenuItem();
            this.reSizeColumnsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortArrowImages = new System.Windows.Forms.ImageList(this.components);
            this.excludeToolStrip = new System.Windows.Forms.ToolStrip();
            this.exclBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.histBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.trafBtn = new System.Windows.Forms.ToolStripButton();
            this.trafficPanel = new System.Windows.Forms.Panel();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.infoLayer = new System.Windows.Forms.Label();
            this.trafficTree = new System.Windows.Forms.TreeView();
            this.trafficToolStrip = new System.Windows.Forms.ToolStrip();
            this.trafficBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.trafficCnt = new System.Windows.Forms.ToolStripTextBox();
            this.logTitem = new System.Windows.Forms.ToolStripButton();
            this.historyPanel = new System.Windows.Forms.Panel();
            this.toolStripContainer3 = new System.Windows.Forms.ToolStripContainer();
            this.histView = new System.Windows.Forms.ListView();
            this.col_r = new System.Windows.Forms.ColumnHeader();
            this.col_rN = new System.Windows.Forms.ColumnHeader();
            this.col_rTime = new System.Windows.Forms.ColumnHeader();
            this.col_w = new System.Windows.Forms.ColumnHeader();
            this.col_wN = new System.Windows.Forms.ColumnHeader();
            this.col_wTime = new System.Windows.Forms.ColumnHeader();
            this.historyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.histToolstrip = new System.Windows.Forms.ToolStrip();
            this.refreshHitem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.titleHitem = new System.Windows.Forms.ToolStripLabel();
            this.splitViewGraph = new System.Windows.Forms.SplitContainer();
            this.statListToolStrip = new System.Windows.Forms.ToolStripContainer();
            this.statView = new System.Windows.Forms.ListView();
            this.col_g = new System.Windows.Forms.ColumnHeader();
            this.col_gc = new System.Windows.Forms.ColumnHeader();
            this.col_t = new System.Windows.Forms.ColumnHeader();
            this.col_host = new System.Windows.Forms.ColumnHeader();
            this.col_ip = new System.Windows.Forms.ColumnHeader();
            this.col_local = new System.Windows.Forms.ColumnHeader();
            this.col_remote = new System.Windows.Forms.ColumnHeader();
            this.col_read = new System.Windows.Forms.ColumnHeader();
            this.col_write = new System.Windows.Forms.ColumnHeader();
            this.col_Nread = new System.Windows.Forms.ColumnHeader();
            this.col_Nwrite = new System.Windows.Forms.ColumnHeader();
            this.col_time = new System.Windows.Forms.ColumnHeader();
            this.tableMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearTableMitem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTableMitem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportTableMitem = new System.Windows.Forms.ToolStripMenuItem();
            this.reSizeColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkbox = new System.Windows.Forms.ImageList(this.components);
            this.statToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.viewMitem = new System.Windows.Forms.ToolStripSplitButton();
            this.viewSummaryMitem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDetailMitem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.trimMitem = new System.Windows.Forms.ToolStripSplitButton();
            this.bySortOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byMaxReadSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byMaxWriteSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sortMitem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.totalMitem = new System.Windows.Forms.ToolStripSplitButton();
            this.noTotalMitem = new System.Windows.Forms.ToolStripMenuItem();
            this.total5Mitem = new System.Windows.Forms.ToolStripMenuItem();
            this.total10Mitem = new System.Windows.Forms.ToolStripMenuItem();
            this.total30Mitem = new System.Windows.Forms.ToolStripMenuItem();
            this.total60Mitem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.totolPerSecMitem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.clearMitem = new System.Windows.Forms.ToolStripSplitButton();
            this.removeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.unitMitem = new System.Windows.Forms.ToolStripSplitButton();
            this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bytesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kiloBytesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.megaBytesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gigaBytesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tableSizeBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.layoutMitem = new System.Windows.Forms.ToolStripSplitButton();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listAndGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trafficToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Graph = new ZedGraph.ZedGraphControl();
            this.graphToolStrip = new System.Windows.Forms.ToolStrip();
            this.graphGitem = new System.Windows.Forms.ToolStripSplitButton();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineFilledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGitem = new System.Windows.Forms.ToolStripSplitButton();
            this.stackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nonStackedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.axisGitem = new System.Windows.Forms.ToolStripSplitButton();
            this.singleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multipleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.clearGitem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.pauseGitem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomGitem = new System.Windows.Forms.ToolStripSplitButton();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.gridlinesGitem = new System.Windows.Forms.ToolStripSplitButton();
            this.majorXGitem = new System.Windows.Forms.ToolStripMenuItem();
            this.minorXGiItem = new System.Windows.Forms.ToolStripMenuItem();
            this.majorYGitem = new System.Windows.Forms.ToolStripMenuItem();
            this.minorYGitem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.minLabelGitem = new System.Windows.Forms.ToolStripLabel();
            this.minGBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.helpGitem = new System.Windows.Forms.ToolStripButton();
            this.propGitem = new System.Windows.Forms.ToolStripSplitButton();
            this.propertiesGitem = new System.Windows.Forms.ToolStripMenuItem();
            this.symbolGitem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.globalCfgPanel = new System.Windows.Forms.Panel();
            this.elapsedTime = new System.Windows.Forms.Label();
            this.filterBox = new System.Windows.Forms.TextBox();
            this.settingPanel = new System.Windows.Forms.Panel();
            this.exportFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.closeBtn = new System.Windows.Forms.Button();
            this.TitleGlow = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.titleText = new nsNetPeak.TextBar();
            this.trafficMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.splitLeftRight.Panel1.SuspendLayout();
            this.splitLeftRight.Panel2.SuspendLayout();
            this.splitLeftRight.SuspendLayout();
            this.splitExcludeDetail.Panel1.SuspendLayout();
            this.splitExcludeDetail.Panel2.SuspendLayout();
            this.splitExcludeDetail.SuspendLayout();
            this.excludeToolBox.ContentPanel.SuspendLayout();
            this.excludeToolBox.TopToolStripPanel.SuspendLayout();
            this.excludeToolBox.SuspendLayout();
            this.excludeMenu.SuspendLayout();
            this.excludeToolStrip.SuspendLayout();
            this.trafficPanel.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.trafficToolStrip.SuspendLayout();
            this.historyPanel.SuspendLayout();
            this.toolStripContainer3.ContentPanel.SuspendLayout();
            this.toolStripContainer3.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer3.SuspendLayout();
            this.historyMenu.SuspendLayout();
            this.histToolstrip.SuspendLayout();
            this.splitViewGraph.Panel1.SuspendLayout();
            this.splitViewGraph.Panel2.SuspendLayout();
            this.splitViewGraph.SuspendLayout();
            this.statListToolStrip.ContentPanel.SuspendLayout();
            this.statListToolStrip.TopToolStripPanel.SuspendLayout();
            this.statListToolStrip.SuspendLayout();
            this.tableMenu.SuspendLayout();
            this.statToolStrip.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.graphToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.White;
            this.btnStart.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(409, 62);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(56, 22);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "&Start";
            this.toolTip.SetToolTip(this.btnStart, "Press to start/stop network capture");
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cmbInterfaces
            // 
            this.cmbInterfaces.BackColor = System.Drawing.Color.White;
            this.cmbInterfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInterfaces.FormattingEnabled = true;
            this.cmbInterfaces.Location = new System.Drawing.Point(471, 63);
            this.cmbInterfaces.Name = "cmbInterfaces";
            this.cmbInterfaces.Size = new System.Drawing.Size(236, 21);
            this.cmbInterfaces.TabIndex = 2;
            // 
            // statusBar
            // 
            this.statusBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.statusBar.Location = new System.Drawing.Point(104, 545);
            this.statusBar.Name = "statusBar";
            this.statusBar.ReadOnly = true;
            this.statusBar.Size = new System.Drawing.Size(808, 20);
            this.statusBar.TabIndex = 7;
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Title.Font = new System.Drawing.Font("Arial", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Title.Location = new System.Drawing.Point(191, 9);
            this.Title.Margin = new System.Windows.Forms.Padding(2);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(130, 23);
            this.Title.TabIndex = 8;
            this.Title.Text = "NetPeak v1.5";
            // 
            // trafficMenu
            // 
            this.trafficMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearTitem,
            this.eToolStripMenuItem,
            this.printToolStripMenuItem3});
            this.trafficMenu.Name = "trafficMenu";
            this.trafficMenu.Size = new System.Drawing.Size(118, 70);
            // 
            // clearTitem
            // 
            this.clearTitem.Name = "clearTitem";
            this.clearTitem.Size = new System.Drawing.Size(117, 22);
            this.clearTitem.Text = "Clear";
            this.clearTitem.Click += new System.EventHandler(this.trafficTitem_Click);
            // 
            // eToolStripMenuItem
            // 
            this.eToolStripMenuItem.Name = "eToolStripMenuItem";
            this.eToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eToolStripMenuItem.Text = "Export";
            this.eToolStripMenuItem.Click += new System.EventHandler(this.trafficTitem_Click);
            // 
            // printToolStripMenuItem3
            // 
            this.printToolStripMenuItem3.Name = "printToolStripMenuItem3";
            this.printToolStripMenuItem3.Size = new System.Drawing.Size(117, 22);
            this.printToolStripMenuItem3.Text = "Print";
            this.printToolStripMenuItem3.Click += new System.EventHandler(this.trafficTitem_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // timerAnimation
            // 
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // timeLabel
            // 
            this.timeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.Color.White;
            this.timeLabel.Location = new System.Drawing.Point(910, 64);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(97, 18);
            this.timeLabel.TabIndex = 11;
            this.timeLabel.Text = "88:88:88 PM";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.timeLabel, "Current Time");
            // 
            // captureImage
            // 
            this.captureImage.BackColor = System.Drawing.Color.Transparent;
            this.captureImage.BackgroundImage = global::nsNetPeak.Properties.Resources.red24;
            this.captureImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.captureImage.Location = new System.Drawing.Point(374, 56);
            this.captureImage.Margin = new System.Windows.Forms.Padding(0);
            this.captureImage.Name = "captureImage";
            this.captureImage.Size = new System.Drawing.Size(32, 32);
            this.captureImage.TabIndex = 10;
            this.toolTip.SetToolTip(this.captureImage, "Press to start/stop network capture");
            this.captureImage.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(13, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(152, 76);
            this.panel2.TabIndex = 5;
            this.toolTip.SetToolTip(this.panel2, "Press for About");
            this.panel2.Click += new System.EventHandler(this.About_Click);
            // 
            // splitLeftRight
            // 
            this.splitLeftRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitLeftRight.BackColor = System.Drawing.Color.DarkGray;
            this.splitLeftRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitLeftRight.BackgroundImage")));
            this.splitLeftRight.Location = new System.Drawing.Point(12, 91);
            this.splitLeftRight.Name = "splitLeftRight";
            // 
            // splitLeftRight.Panel1
            // 
            this.splitLeftRight.Panel1.Controls.Add(this.splitExcludeDetail);
            this.splitLeftRight.Panel1MinSize = 0;
            // 
            // splitLeftRight.Panel2
            // 
            this.splitLeftRight.Panel2.Controls.Add(this.splitViewGraph);
            this.splitLeftRight.Panel2MinSize = 0;
            this.splitLeftRight.Size = new System.Drawing.Size(995, 443);
            this.splitLeftRight.SplitterDistance = 236;
            this.splitLeftRight.TabIndex = 4;
            // 
            // splitExcludeDetail
            // 
            this.splitExcludeDetail.BackColor = System.Drawing.Color.DarkGray;
            this.splitExcludeDetail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitExcludeDetail.BackgroundImage")));
            this.splitExcludeDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitExcludeDetail.Location = new System.Drawing.Point(0, 0);
            this.splitExcludeDetail.Name = "splitExcludeDetail";
            this.splitExcludeDetail.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitExcludeDetail.Panel1
            // 
            this.splitExcludeDetail.Panel1.Controls.Add(this.excludeToolBox);
            this.splitExcludeDetail.Panel1MinSize = 0;
            // 
            // splitExcludeDetail.Panel2
            // 
            this.splitExcludeDetail.Panel2.Controls.Add(this.trafficPanel);
            this.splitExcludeDetail.Panel2.Controls.Add(this.historyPanel);
            this.splitExcludeDetail.Panel2MinSize = 0;
            this.splitExcludeDetail.Size = new System.Drawing.Size(236, 443);
            this.splitExcludeDetail.SplitterDistance = 134;
            this.splitExcludeDetail.TabIndex = 0;
            // 
            // excludeToolBox
            // 
            // 
            // excludeToolBox.ContentPanel
            // 
            this.excludeToolBox.ContentPanel.Controls.Add(this.excludeList);
            this.excludeToolBox.ContentPanel.Size = new System.Drawing.Size(236, 109);
            this.excludeToolBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excludeToolBox.Location = new System.Drawing.Point(0, 0);
            this.excludeToolBox.Name = "excludeToolBox";
            this.excludeToolBox.Size = new System.Drawing.Size(236, 134);
            this.excludeToolBox.TabIndex = 0;
            this.excludeToolBox.Text = "toolStripContainer4";
            // 
            // excludeToolBox.TopToolStripPanel
            // 
            this.excludeToolBox.TopToolStripPanel.Controls.Add(this.excludeToolStrip);
            // 
            // excludeList
            // 
            this.excludeList.AllowDrop = true;
            this.excludeList.CheckBoxes = true;
            this.excludeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader12,
            this.columnHeader13});
            this.excludeList.ContextMenuStrip = this.excludeMenu;
            this.excludeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excludeList.FullRowSelect = true;
            this.excludeList.GridLines = true;
            this.excludeList.Location = new System.Drawing.Point(0, 0);
            this.excludeList.Margin = new System.Windows.Forms.Padding(1);
            this.excludeList.Name = "excludeList";
            this.excludeList.Size = new System.Drawing.Size(236, 109);
            this.excludeList.SmallImageList = this.sortArrowImages;
            this.excludeList.TabIndex = 0;
            this.toolTip.SetToolTip(this.excludeList, "Exclude filters prevents traffic from being processed");
            this.excludeList.UseCompatibleStateImageBehavior = false;
            this.excludeList.View = System.Windows.Forms.View.Details;
            this.excludeList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.excludeList_ItemChecked);
            this.excludeList.DoubleClick += new System.EventHandler(this.ListViewDbl_Click);
            this.excludeList.DragDrop += new System.Windows.Forms.DragEventHandler(this.excludeList_DragDrop);
            this.excludeList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnClick);
            this.excludeList.DragEnter += new System.Windows.Forms.DragEventHandler(this.excludeList_DragEnter);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Host";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Ip";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Local";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Remote";
            // 
            // excludeMenu
            // 
            this.excludeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteExcludeMitem,
            this.editExcludeMitem,
            this.exportExcludeMitem,
            this.reSizeColumnsToolStripMenuItem1,
            this.toolStripSeparator20,
            this.printToolStripMenuItem});
            this.excludeMenu.Name = "excludeMenu";
            this.excludeMenu.Size = new System.Drawing.Size(160, 120);
            // 
            // deleteExcludeMitem
            // 
            this.deleteExcludeMitem.Name = "deleteExcludeMitem";
            this.deleteExcludeMitem.Size = new System.Drawing.Size(159, 22);
            this.deleteExcludeMitem.Text = "Delete";
            this.deleteExcludeMitem.ToolTipText = "Delete Exclude entries (selected or all)";
            this.deleteExcludeMitem.Click += new System.EventHandler(this.excludeMenu_Click);
            // 
            // editExcludeMitem
            // 
            this.editExcludeMitem.Name = "editExcludeMitem";
            this.editExcludeMitem.Size = new System.Drawing.Size(159, 22);
            this.editExcludeMitem.Text = "Edit";
            this.editExcludeMitem.Click += new System.EventHandler(this.excludeMenu_Click);
            // 
            // exportExcludeMitem
            // 
            this.exportExcludeMitem.Name = "exportExcludeMitem";
            this.exportExcludeMitem.Size = new System.Drawing.Size(159, 22);
            this.exportExcludeMitem.Text = "Export";
            this.exportExcludeMitem.ToolTipText = "Export exclude lst to csv file";
            this.exportExcludeMitem.Click += new System.EventHandler(this.ListViewExport_Click);
            // 
            // reSizeColumnsToolStripMenuItem1
            // 
            this.reSizeColumnsToolStripMenuItem1.Name = "reSizeColumnsToolStripMenuItem1";
            this.reSizeColumnsToolStripMenuItem1.Size = new System.Drawing.Size(159, 22);
            this.reSizeColumnsToolStripMenuItem1.Text = "Resize Columns";
            this.reSizeColumnsToolStripMenuItem1.ToolTipText = "Resize columns to best fit";
            this.reSizeColumnsToolStripMenuItem1.Click += new System.EventHandler(this.excludeMenu_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(156, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.excludeMenu_Click);
            // 
            // sortArrowImages
            // 
            this.sortArrowImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("sortArrowImages.ImageStream")));
            this.sortArrowImages.TransparentColor = System.Drawing.Color.Transparent;
            this.sortArrowImages.Images.SetKeyName(0, "upBW.png");
            this.sortArrowImages.Images.SetKeyName(1, "downBW.png");
            // 
            // excludeToolStrip
            // 
            this.excludeToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.excludeToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exclBtn,
            this.toolStripSeparator22,
            this.histBtn,
            this.toolStripSeparator23,
            this.trafBtn});
            this.excludeToolStrip.Location = new System.Drawing.Point(0, 0);
            this.excludeToolStrip.Name = "excludeToolStrip";
            this.excludeToolStrip.Size = new System.Drawing.Size(236, 25);
            this.excludeToolStrip.Stretch = true;
            this.excludeToolStrip.TabIndex = 0;
            // 
            // exclBtn
            // 
            this.exclBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exclBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exclBtn.Name = "exclBtn";
            this.exclBtn.Size = new System.Drawing.Size(48, 22);
            this.exclBtn.Text = "Exclude";
            this.exclBtn.ToolTipText = "Add new Exclude Ip Filter line";
            this.exclBtn.Click += new System.EventHandler(this.excludeBtn_Click);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            this.toolStripSeparator22.Size = new System.Drawing.Size(6, 25);
            // 
            // histBtn
            // 
            this.histBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.histBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.histBtn.Image = ((System.Drawing.Image)(resources.GetObject("histBtn.Image")));
            this.histBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.histBtn.Name = "histBtn";
            this.histBtn.Size = new System.Drawing.Size(45, 22);
            this.histBtn.Text = "History";
            this.histBtn.ToolTipText = "Display Database History Panel";
            this.histBtn.Click += new System.EventHandler(this.histBtn_Click);
            // 
            // toolStripSeparator23
            // 
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            this.toolStripSeparator23.Size = new System.Drawing.Size(6, 25);
            // 
            // trafBtn
            // 
            this.trafBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.trafBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.trafBtn.Image = ((System.Drawing.Image)(resources.GetObject("trafBtn.Image")));
            this.trafBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.trafBtn.Name = "trafBtn";
            this.trafBtn.Size = new System.Drawing.Size(42, 22);
            this.trafBtn.Text = "Traffic";
            this.trafBtn.ToolTipText = "Display Traffic Panel";
            this.trafBtn.Click += new System.EventHandler(this.trafBtn_Click);
            // 
            // trafficPanel
            // 
            this.trafficPanel.Controls.Add(this.toolStripContainer2);
            this.trafficPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trafficPanel.Location = new System.Drawing.Point(0, 0);
            this.trafficPanel.Name = "trafficPanel";
            this.trafficPanel.Size = new System.Drawing.Size(236, 305);
            this.trafficPanel.TabIndex = 3;
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Controls.Add(this.infoLayer);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.trafficTree);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(236, 280);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(236, 305);
            this.toolStripContainer2.TabIndex = 0;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // toolStripContainer2.TopToolStripPanel
            // 
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.trafficToolStrip);
            // 
            // infoLayer
            // 
            this.infoLayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.infoLayer.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.infoLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoLayer.Location = new System.Drawing.Point(0, 0);
            this.infoLayer.Name = "infoLayer";
            this.infoLayer.Size = new System.Drawing.Size(236, 280);
            this.infoLayer.TabIndex = 1;
            this.infoLayer.Text = ".... Detailed packet capture available here.";
            this.infoLayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trafficTree
            // 
            this.trafficTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.trafficTree.ContextMenuStrip = this.trafficMenu;
            this.trafficTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trafficTree.Location = new System.Drawing.Point(0, 0);
            this.trafficTree.Margin = new System.Windows.Forms.Padding(1);
            this.trafficTree.Name = "trafficTree";
            this.trafficTree.Size = new System.Drawing.Size(236, 280);
            this.trafficTree.TabIndex = 0;
            // 
            // trafficToolStrip
            // 
            this.trafficToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.trafficToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trafficBtn,
            this.toolStripSeparator15,
            this.trafficCnt,
            this.logTitem});
            this.trafficToolStrip.Location = new System.Drawing.Point(0, 0);
            this.trafficToolStrip.Name = "trafficToolStrip";
            this.trafficToolStrip.Size = new System.Drawing.Size(236, 25);
            this.trafficToolStrip.Stretch = true;
            this.trafficToolStrip.TabIndex = 0;
            // 
            // trafficBtn
            // 
            this.trafficBtn.Image = global::nsNetPeak.Properties.Resources.red24;
            this.trafficBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.trafficBtn.Name = "trafficBtn";
            this.trafficBtn.Size = new System.Drawing.Size(58, 22);
            this.trafficBtn.Text = "Traffic";
            this.trafficBtn.Click += new System.EventHandler(this.trafficBtn_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 25);
            // 
            // trafficCnt
            // 
            this.trafficCnt.Name = "trafficCnt";
            this.trafficCnt.ReadOnly = true;
            this.trafficCnt.Size = new System.Drawing.Size(60, 25);
            // 
            // logTitem
            // 
            this.logTitem.CheckOnClick = true;
            this.logTitem.Image = global::nsNetPeak.Properties.Resources.check_off;
            this.logTitem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.logTitem.Name = "logTitem";
            this.logTitem.Size = new System.Drawing.Size(44, 22);
            this.logTitem.Text = "Log";
            this.logTitem.ToolTipText = " Log traffic to disk file";
            this.logTitem.Click += new System.EventHandler(this.logTitem_Click);
            // 
            // historyPanel
            // 
            this.historyPanel.Controls.Add(this.toolStripContainer3);
            this.historyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyPanel.Location = new System.Drawing.Point(0, 0);
            this.historyPanel.Name = "historyPanel";
            this.historyPanel.Size = new System.Drawing.Size(236, 305);
            this.historyPanel.TabIndex = 1;
            // 
            // toolStripContainer3
            // 
            // 
            // toolStripContainer3.ContentPanel
            // 
            this.toolStripContainer3.ContentPanel.Controls.Add(this.histView);
            this.toolStripContainer3.ContentPanel.Size = new System.Drawing.Size(236, 280);
            this.toolStripContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer3.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer3.Name = "toolStripContainer3";
            this.toolStripContainer3.Size = new System.Drawing.Size(236, 305);
            this.toolStripContainer3.TabIndex = 0;
            this.toolStripContainer3.Text = "toolStripContainer3";
            // 
            // toolStripContainer3.TopToolStripPanel
            // 
            this.toolStripContainer3.TopToolStripPanel.Controls.Add(this.histToolstrip);
            // 
            // histView
            // 
            this.histView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.histView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_r,
            this.col_rN,
            this.col_rTime,
            this.col_w,
            this.col_wN,
            this.col_wTime});
            this.histView.ContextMenuStrip = this.historyMenu;
            this.histView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.histView.FullRowSelect = true;
            this.histView.GridLines = true;
            this.histView.Location = new System.Drawing.Point(0, 0);
            this.histView.Name = "histView";
            this.histView.Size = new System.Drawing.Size(236, 280);
            this.histView.SmallImageList = this.sortArrowImages;
            this.histView.TabIndex = 0;
            this.toolTip.SetToolTip(this.histView, "History Details of first item being grap");
            this.histView.UseCompatibleStateImageBehavior = false;
            this.histView.View = System.Windows.Forms.View.Details;
            this.histView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnTotalClick);
            // 
            // col_r
            // 
            this.col_r.Text = "read";
            // 
            // col_rN
            // 
            this.col_rN.Text = "#Read";
            // 
            // col_rTime
            // 
            this.col_rTime.Text = "Time";
            // 
            // col_w
            // 
            this.col_w.Text = "Write";
            // 
            // col_wN
            // 
            this.col_wN.Text = "#write";
            // 
            // col_wTime
            // 
            this.col_wTime.Text = "Time";
            // 
            // historyMenu
            // 
            this.historyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.printToolStripMenuItem1});
            this.historyMenu.Name = "historyMenu";
            this.historyMenu.Size = new System.Drawing.Size(118, 48);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.histMenu_Click);
            // 
            // printToolStripMenuItem1
            // 
            this.printToolStripMenuItem1.Name = "printToolStripMenuItem1";
            this.printToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.printToolStripMenuItem1.Text = "Print";
            this.printToolStripMenuItem1.Click += new System.EventHandler(this.histMenu_Click);
            // 
            // histToolstrip
            // 
            this.histToolstrip.Dock = System.Windows.Forms.DockStyle.None;
            this.histToolstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshHitem,
            this.toolStripSeparator16,
            this.titleHitem});
            this.histToolstrip.Location = new System.Drawing.Point(0, 0);
            this.histToolstrip.Name = "histToolstrip";
            this.histToolstrip.Size = new System.Drawing.Size(236, 25);
            this.histToolstrip.Stretch = true;
            this.histToolstrip.TabIndex = 0;
            // 
            // refreshHitem
            // 
            this.refreshHitem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.refreshHitem.Image = ((System.Drawing.Image)(resources.GetObject("refreshHitem.Image")));
            this.refreshHitem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshHitem.Name = "refreshHitem";
            this.refreshHitem.Size = new System.Drawing.Size(49, 22);
            this.refreshHitem.Text = "Refresh";
            this.refreshHitem.ToolTipText = "Refresh History Table";
            this.refreshHitem.Click += new System.EventHandler(this.refreshHitem_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 25);
            // 
            // titleHitem
            // 
            this.titleHitem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleHitem.ForeColor = System.Drawing.Color.Black;
            this.titleHitem.Name = "titleHitem";
            this.titleHitem.Size = new System.Drawing.Size(48, 22);
            this.titleHitem.Text = "History";
            this.titleHitem.ToolTipText = "History Details of first item being graphed";
            // 
            // splitViewGraph
            // 
            this.splitViewGraph.BackColor = System.Drawing.Color.DarkGray;
            this.splitViewGraph.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitViewGraph.BackgroundImage")));
            this.splitViewGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitViewGraph.Location = new System.Drawing.Point(0, 0);
            this.splitViewGraph.Name = "splitViewGraph";
            this.splitViewGraph.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitViewGraph.Panel1
            // 
            this.splitViewGraph.Panel1.Controls.Add(this.statListToolStrip);
            this.splitViewGraph.Panel1MinSize = 0;
            // 
            // splitViewGraph.Panel2
            // 
            this.splitViewGraph.Panel2.Controls.Add(this.toolStripContainer1);
            this.splitViewGraph.Panel2MinSize = 0;
            this.splitViewGraph.Size = new System.Drawing.Size(755, 443);
            this.splitViewGraph.SplitterDistance = 220;
            this.splitViewGraph.TabIndex = 4;
            // 
            // statListToolStrip
            // 
            // 
            // statListToolStrip.ContentPanel
            // 
            this.statListToolStrip.ContentPanel.Controls.Add(this.statView);
            this.statListToolStrip.ContentPanel.Size = new System.Drawing.Size(755, 191);
            this.statListToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statListToolStrip.Location = new System.Drawing.Point(0, 0);
            this.statListToolStrip.Name = "statListToolStrip";
            this.statListToolStrip.Size = new System.Drawing.Size(755, 220);
            this.statListToolStrip.TabIndex = 0;
            this.statListToolStrip.Text = "toolStripContainer1";
            // 
            // statListToolStrip.TopToolStripPanel
            // 
            this.statListToolStrip.TopToolStripPanel.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.statListToolStrip.TopToolStripPanel.Controls.Add(this.statToolStrip);
            // 
            // statView
            // 
            this.statView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statView.CheckBoxes = true;
            this.statView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_g,
            this.col_gc,
            this.col_t,
            this.col_host,
            this.col_ip,
            this.col_local,
            this.col_remote,
            this.col_read,
            this.col_write,
            this.col_Nread,
            this.col_Nwrite,
            this.col_time});
            this.statView.ContextMenuStrip = this.tableMenu;
            this.statView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statView.FullRowSelect = true;
            this.statView.GridLines = true;
            this.statView.HideSelection = false;
            this.statView.Location = new System.Drawing.Point(0, 0);
            this.statView.Name = "statView";
            this.statView.ShowItemToolTips = true;
            this.statView.Size = new System.Drawing.Size(755, 191);
            this.statView.SmallImageList = this.sortArrowImages;
            this.statView.StateImageList = this.checkbox;
            this.statView.TabIndex = 3;
            this.statView.UseCompatibleStateImageBehavior = false;
            this.statView.View = System.Windows.Forms.View.Details;
            this.statView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.statView_ItemChecked);
            this.statView.SelectedIndexChanged += new System.EventHandler(this.statView_SelectedIndexChanged);
            this.statView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.StatColumnClick);
            this.statView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.statView_MouseMove);
            this.statView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.statView_KeyUp);
            this.statView.Click += new System.EventHandler(this.statView_Click);
            // 
            // col_g
            // 
            this.col_g.Text = "G";
            this.col_g.Width = 30;
            // 
            // col_gc
            // 
            this.col_gc.Text = "Gcol";
            this.col_gc.Width = 40;
            // 
            // col_t
            // 
            this.col_t.Text = "T";
            this.col_t.Width = 30;
            // 
            // col_host
            // 
            this.col_host.Text = "Host";
            this.col_host.Width = 100;
            // 
            // col_ip
            // 
            this.col_ip.Text = "Ip";
            this.col_ip.Width = 80;
            // 
            // col_local
            // 
            this.col_local.Text = "Local";
            this.col_local.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // col_remote
            // 
            this.col_remote.Text = "Remote";
            this.col_remote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // col_read
            // 
            this.col_read.Text = "Read Bytes";
            this.col_read.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_read.Width = 80;
            // 
            // col_write
            // 
            this.col_write.Text = "Write Bytes";
            this.col_write.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_write.Width = 80;
            // 
            // col_Nread
            // 
            this.col_Nread.Text = "#Reads";
            this.col_Nread.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // col_Nwrite
            // 
            this.col_Nwrite.Text = "#Writes";
            this.col_Nwrite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // col_time
            // 
            this.col_time.Text = "Time";
            this.col_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_time.Width = 81;
            // 
            // tableMenu
            // 
            this.tableMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearTableMitem,
            this.deleteTableMitem,
            this.exportTableMitem,
            this.reSizeColumnsToolStripMenuItem,
            this.toolStripSeparator21,
            this.printToolStripMenuItem2});
            this.tableMenu.Name = "tableMenu";
            this.tableMenu.Size = new System.Drawing.Size(160, 120);
            // 
            // clearTableMitem
            // 
            this.clearTableMitem.Name = "clearTableMitem";
            this.clearTableMitem.Size = new System.Drawing.Size(159, 22);
            this.clearTableMitem.Text = "Clear";
            this.clearTableMitem.Click += new System.EventHandler(this.tableMenu_Click);
            // 
            // deleteTableMitem
            // 
            this.deleteTableMitem.Name = "deleteTableMitem";
            this.deleteTableMitem.Size = new System.Drawing.Size(159, 22);
            this.deleteTableMitem.Text = "Delete";
            this.deleteTableMitem.Click += new System.EventHandler(this.tableMenu_Click);
            // 
            // exportTableMitem
            // 
            this.exportTableMitem.Name = "exportTableMitem";
            this.exportTableMitem.Size = new System.Drawing.Size(159, 22);
            this.exportTableMitem.Text = "Export";
            this.exportTableMitem.Click += new System.EventHandler(this.ListViewExport_Click);
            // 
            // reSizeColumnsToolStripMenuItem
            // 
            this.reSizeColumnsToolStripMenuItem.Name = "reSizeColumnsToolStripMenuItem";
            this.reSizeColumnsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.reSizeColumnsToolStripMenuItem.Text = "Resize Columns";
            this.reSizeColumnsToolStripMenuItem.Click += new System.EventHandler(this.tableMenu_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(156, 6);
            // 
            // printToolStripMenuItem2
            // 
            this.printToolStripMenuItem2.Name = "printToolStripMenuItem2";
            this.printToolStripMenuItem2.Size = new System.Drawing.Size(159, 22);
            this.printToolStripMenuItem2.Text = "Print";
            this.printToolStripMenuItem2.Click += new System.EventHandler(this.tableMenu_Click);
            // 
            // checkbox
            // 
            this.checkbox.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("checkbox.ImageStream")));
            this.checkbox.TransparentColor = System.Drawing.Color.Transparent;
            this.checkbox.Images.SetKeyName(0, "check-off.png");
            this.checkbox.Images.SetKeyName(1, "smlCheck-on.png");
            // 
            // statToolStrip
            // 
            this.statToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.statToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.viewMitem,
            this.toolStripSeparator1,
            this.trimMitem,
            this.toolStripSeparator3,
            this.sortMitem,
            this.toolStripSeparator4,
            this.totalMitem,
            this.toolStripSeparator5,
            this.clearMitem,
            this.toolStripSeparator6,
            this.unitMitem,
            this.toolStripSeparator10,
            this.toolStripLabel1,
            this.tableSizeBox,
            this.toolStripSeparator8,
            this.layoutMitem});
            this.statToolStrip.Location = new System.Drawing.Point(0, 0);
            this.statToolStrip.Name = "statToolStrip";
            this.statToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statToolStrip.Size = new System.Drawing.Size(755, 29);
            this.statToolStrip.Stretch = true;
            this.statToolStrip.TabIndex = 0;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // viewMitem
            // 
            this.viewMitem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.viewMitem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewSummaryMitem,
            this.viewDetailMitem});
            this.viewMitem.Image = ((System.Drawing.Image)(resources.GetObject("viewMitem.Image")));
            this.viewMitem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.viewMitem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewMitem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewMitem.Name = "viewMitem";
            this.viewMitem.Size = new System.Drawing.Size(67, 26);
            this.viewMitem.Text = "View";
            this.viewMitem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.viewMitem.ToolTipText = "Summarize addresses or show full port details";
            // 
            // viewSummaryMitem
            // 
            this.viewSummaryMitem.Checked = true;
            this.viewSummaryMitem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewSummaryMitem.Image = ((System.Drawing.Image)(resources.GetObject("viewSummaryMitem.Image")));
            this.viewSummaryMitem.Name = "viewSummaryMitem";
            this.viewSummaryMitem.Size = new System.Drawing.Size(129, 22);
            this.viewSummaryMitem.Text = "Summary";
            this.viewSummaryMitem.Click += new System.EventHandler(this.viewSummarylMenu_Click);
            // 
            // viewDetailMitem
            // 
            this.viewDetailMitem.Image = ((System.Drawing.Image)(resources.GetObject("viewDetailMitem.Image")));
            this.viewDetailMitem.Name = "viewDetailMitem";
            this.viewDetailMitem.Size = new System.Drawing.Size(129, 22);
            this.viewDetailMitem.Text = "Detail";
            this.viewDetailMitem.Click += new System.EventHandler(this.viewDetailMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // trimMitem
            // 
            this.trimMitem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bySortOrderToolStripMenuItem,
            this.byMaxReadSizeToolStripMenuItem,
            this.byMaxWriteSizeToolStripMenuItem,
            this.byTimeToolStripMenuItem});
            this.trimMitem.Image = global::nsNetPeak.Properties.Resources.trim;
            this.trimMitem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.trimMitem.Name = "trimMitem";
            this.trimMitem.Size = new System.Drawing.Size(59, 26);
            this.trimMitem.Text = "Trim";
            this.trimMitem.ToolTipText = "Trim viewable details by trim criteria keeping screen full.";
            // 
            // bySortOrderToolStripMenuItem
            // 
            this.bySortOrderToolStripMenuItem.Image = global::nsNetPeak.Properties.Resources.sort;
            this.bySortOrderToolStripMenuItem.Name = "bySortOrderToolStripMenuItem";
            this.bySortOrderToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.bySortOrderToolStripMenuItem.Text = "Trim/Sort";
            this.bySortOrderToolStripMenuItem.ToolTipText = "Trim by Sort column";
            this.bySortOrderToolStripMenuItem.Click += new System.EventHandler(this.trimMenuItem_Click);
            // 
            // byMaxReadSizeToolStripMenuItem
            // 
            this.byMaxReadSizeToolStripMenuItem.Enabled = false;
            this.byMaxReadSizeToolStripMenuItem.Image = global::nsNetPeak.Properties.Resources.read;
            this.byMaxReadSizeToolStripMenuItem.Name = "byMaxReadSizeToolStripMenuItem";
            this.byMaxReadSizeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.byMaxReadSizeToolStripMenuItem.Text = "Trim/Read";
            this.byMaxReadSizeToolStripMenuItem.ToolTipText = "Keep Max Read Size";
            this.byMaxReadSizeToolStripMenuItem.Click += new System.EventHandler(this.trimMenuItem_Click);
            // 
            // byMaxWriteSizeToolStripMenuItem
            // 
            this.byMaxWriteSizeToolStripMenuItem.Enabled = false;
            this.byMaxWriteSizeToolStripMenuItem.Image = global::nsNetPeak.Properties.Resources.write;
            this.byMaxWriteSizeToolStripMenuItem.Name = "byMaxWriteSizeToolStripMenuItem";
            this.byMaxWriteSizeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.byMaxWriteSizeToolStripMenuItem.Text = "Trim/Write";
            this.byMaxWriteSizeToolStripMenuItem.ToolTipText = "Keep Max Write Size";
            this.byMaxWriteSizeToolStripMenuItem.Click += new System.EventHandler(this.trimMenuItem_Click);
            // 
            // byTimeToolStripMenuItem
            // 
            this.byTimeToolStripMenuItem.Enabled = false;
            this.byTimeToolStripMenuItem.Image = global::nsNetPeak.Properties.Resources.time;
            this.byTimeToolStripMenuItem.Name = "byTimeToolStripMenuItem";
            this.byTimeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.byTimeToolStripMenuItem.Text = "Trim/Time";
            this.byTimeToolStripMenuItem.ToolTipText = "Trim by Time, keeping newest";
            this.byTimeToolStripMenuItem.Click += new System.EventHandler(this.trimMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // sortMitem
            // 
            this.sortMitem.Checked = true;
            this.sortMitem.CheckOnClick = true;
            this.sortMitem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sortMitem.Image = global::nsNetPeak.Properties.Resources.sort;
            this.sortMitem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sortMitem.Name = "sortMitem";
            this.sortMitem.Size = new System.Drawing.Size(70, 26);
            this.sortMitem.Text = "AutoSort";
            this.sortMitem.ToolTipText = "Resort every 5 seconds";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 29);
            // 
            // totalMitem
            // 
            this.totalMitem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noTotalMitem,
            this.total5Mitem,
            this.total10Mitem,
            this.total30Mitem,
            this.total60Mitem,
            this.toolStripSeparator18,
            this.totolPerSecMitem});
            this.totalMitem.Image = global::nsNetPeak.Properties.Resources.total;
            this.totalMitem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.totalMitem.Name = "totalMitem";
            this.totalMitem.Size = new System.Drawing.Size(68, 26);
            this.totalMitem.Text = "Totals";
            this.totalMitem.ToolTipText = "Select Total Interval";
            // 
            // noTotalMitem
            // 
            this.noTotalMitem.Image = global::nsNetPeak.Properties.Resources.check_on;
            this.noTotalMitem.Name = "noTotalMitem";
            this.noTotalMitem.Size = new System.Drawing.Size(139, 22);
            this.noTotalMitem.Text = "No Totals";
            this.noTotalMitem.ToolTipText = "Show accumulated values";
            this.noTotalMitem.Click += new System.EventHandler(this.totalMitem_ButtonClick);
            // 
            // total5Mitem
            // 
            this.total5Mitem.Image = global::nsNetPeak.Properties.Resources.check_off;
            this.total5Mitem.Name = "total5Mitem";
            this.total5Mitem.Size = new System.Drawing.Size(139, 22);
            this.total5Mitem.Text = "5 Minutes";
            this.total5Mitem.ToolTipText = "5 minute delta";
            this.total5Mitem.Click += new System.EventHandler(this.totalMitem_ButtonClick);
            // 
            // total10Mitem
            // 
            this.total10Mitem.Image = global::nsNetPeak.Properties.Resources.check_off;
            this.total10Mitem.Name = "total10Mitem";
            this.total10Mitem.Size = new System.Drawing.Size(139, 22);
            this.total10Mitem.Text = "10 Minutes";
            this.total10Mitem.ToolTipText = "10 minute delta";
            this.total10Mitem.Click += new System.EventHandler(this.totalMitem_ButtonClick);
            // 
            // total30Mitem
            // 
            this.total30Mitem.Image = global::nsNetPeak.Properties.Resources.check_off;
            this.total30Mitem.Name = "total30Mitem";
            this.total30Mitem.Size = new System.Drawing.Size(139, 22);
            this.total30Mitem.Text = "30 Minutes";
            this.total30Mitem.ToolTipText = "30 minute delta";
            this.total30Mitem.Click += new System.EventHandler(this.totalMitem_ButtonClick);
            // 
            // total60Mitem
            // 
            this.total60Mitem.Image = global::nsNetPeak.Properties.Resources.check_off;
            this.total60Mitem.Name = "total60Mitem";
            this.total60Mitem.Size = new System.Drawing.Size(139, 22);
            this.total60Mitem.Text = "Hourly";
            this.total60Mitem.ToolTipText = "Hourly delta";
            this.total60Mitem.Click += new System.EventHandler(this.totalMitem_ButtonClick);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(136, 6);
            // 
            // totolPerSecMitem
            // 
            this.totolPerSecMitem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.totolPerSecMitem.Image = global::nsNetPeak.Properties.Resources.check_on;
            this.totolPerSecMitem.Name = "totolPerSecMitem";
            this.totolPerSecMitem.Size = new System.Drawing.Size(139, 22);
            this.totolPerSecMitem.Tag = "1";
            this.totolPerSecMitem.Text = "Per Second";
            this.totolPerSecMitem.Click += new System.EventHandler(this.totalMitem_ButtonClick);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 29);
            // 
            // clearMitem
            // 
            this.clearMitem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeAllToolStripMenuItem,
            this.deleteAllToolStripMenuItem});
            this.clearMitem.Image = global::nsNetPeak.Properties.Resources.clear;
            this.clearMitem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearMitem.Name = "clearMitem";
            this.clearMitem.Size = new System.Drawing.Size(96, 26);
            this.clearMitem.Text = "Clear/Reset";
            // 
            // removeAllToolStripMenuItem
            // 
            this.removeAllToolStripMenuItem.Name = "removeAllToolStripMenuItem";
            this.removeAllToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.removeAllToolStripMenuItem.Text = "Clear";
            this.removeAllToolStripMenuItem.ToolTipText = "Clear (remove) lines from Stats panel";
            this.removeAllToolStripMenuItem.Click += new System.EventHandler(this.clearMenuItem_Click);
            // 
            // deleteAllToolStripMenuItem
            // 
            this.deleteAllToolStripMenuItem.Name = "deleteAllToolStripMenuItem";
            this.deleteAllToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.deleteAllToolStripMenuItem.Text = "Delete";
            this.deleteAllToolStripMenuItem.ToolTipText = "Delete lines from Database and Stats panel";
            this.deleteAllToolStripMenuItem.Click += new System.EventHandler(this.clearMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 29);
            // 
            // unitMitem
            // 
            this.unitMitem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.unitMitem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoToolStripMenuItem,
            this.bytesToolStripMenuItem,
            this.kiloBytesToolStripMenuItem,
            this.megaBytesToolStripMenuItem,
            this.gigaBytesToolStripMenuItem});
            this.unitMitem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.unitMitem.Name = "unitMitem";
            this.unitMitem.Size = new System.Drawing.Size(47, 26);
            this.unitMitem.Text = "Units";
            // 
            // autoToolStripMenuItem
            // 
            this.autoToolStripMenuItem.Image = global::nsNetPeak.Properties.Resources.check_off;
            this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            this.autoToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.autoToolStripMenuItem.Text = "AutoSize";
            this.autoToolStripMenuItem.Click += new System.EventHandler(this.unitMenuItem_Click);
            // 
            // bytesToolStripMenuItem
            // 
            this.bytesToolStripMenuItem.Image = global::nsNetPeak.Properties.Resources.check_on;
            this.bytesToolStripMenuItem.Name = "bytesToolStripMenuItem";
            this.bytesToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.bytesToolStripMenuItem.Text = "Bytes";
            this.bytesToolStripMenuItem.Click += new System.EventHandler(this.unitMenuItem_Click);
            // 
            // kiloBytesToolStripMenuItem
            // 
            this.kiloBytesToolStripMenuItem.Image = global::nsNetPeak.Properties.Resources.check_off;
            this.kiloBytesToolStripMenuItem.Name = "kiloBytesToolStripMenuItem";
            this.kiloBytesToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.kiloBytesToolStripMenuItem.Text = "KiloBytes";
            this.kiloBytesToolStripMenuItem.Click += new System.EventHandler(this.unitMenuItem_Click);
            // 
            // megaBytesToolStripMenuItem
            // 
            this.megaBytesToolStripMenuItem.Image = global::nsNetPeak.Properties.Resources.check_off;
            this.megaBytesToolStripMenuItem.Name = "megaBytesToolStripMenuItem";
            this.megaBytesToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.megaBytesToolStripMenuItem.Text = "MegaBytes";
            this.megaBytesToolStripMenuItem.Click += new System.EventHandler(this.unitMenuItem_Click);
            // 
            // gigaBytesToolStripMenuItem
            // 
            this.gigaBytesToolStripMenuItem.Image = global::nsNetPeak.Properties.Resources.check_off;
            this.gigaBytesToolStripMenuItem.Name = "gigaBytesToolStripMenuItem";
            this.gigaBytesToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.gigaBytesToolStripMenuItem.Text = "GigaBytes";
            this.gigaBytesToolStripMenuItem.Click += new System.EventHandler(this.unitMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(45, 26);
            this.toolStripLabel1.Text = "#Rows:";
            // 
            // tableSizeBox
            // 
            this.tableSizeBox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tableSizeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableSizeBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableSizeBox.Name = "tableSizeBox";
            this.tableSizeBox.ReadOnly = true;
            this.tableSizeBox.Size = new System.Drawing.Size(100, 29);
            this.tableSizeBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tableSizeBox.ToolTipText = "Length of Table";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 29);
            // 
            // layoutMitem
            // 
            this.layoutMitem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listToolStripMenuItem,
            this.listAndGraphToolStripMenuItem,
            this.trafficToolStripMenuItem});
            this.layoutMitem.Image = global::nsNetPeak.Properties.Resources.layout_table;
            this.layoutMitem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.layoutMitem.Name = "layoutMitem";
            this.layoutMitem.Size = new System.Drawing.Size(72, 26);
            this.layoutMitem.Text = "Layout";
            this.layoutMitem.ToolTipText = "Select panel layout";
            this.layoutMitem.Visible = false;
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Image = global::nsNetPeak.Properties.Resources.layout_table;
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.listToolStripMenuItem.Text = "Table";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.layoutMenuItem_Click);
            // 
            // listAndGraphToolStripMenuItem
            // 
            this.listAndGraphToolStripMenuItem.Image = global::nsNetPeak.Properties.Resources.layout_graph;
            this.listAndGraphToolStripMenuItem.Name = "listAndGraphToolStripMenuItem";
            this.listAndGraphToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.listAndGraphToolStripMenuItem.Text = "Graph";
            this.listAndGraphToolStripMenuItem.Click += new System.EventHandler(this.layoutMenuItem_Click);
            // 
            // trafficToolStripMenuItem
            // 
            this.trafficToolStripMenuItem.Image = global::nsNetPeak.Properties.Resources.layout_traffic;
            this.trafficToolStripMenuItem.Name = "trafficToolStripMenuItem";
            this.trafficToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.trafficToolStripMenuItem.Text = "Traffic";
            this.trafficToolStripMenuItem.Click += new System.EventHandler(this.layoutMenuItem_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(755, 194);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(755, 219);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.graphToolStrip);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(77)))), ((int)(((byte)(138)))));
            this.panel1.Controls.Add(this.Graph);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 194);
            this.panel1.TabIndex = 0;
            // 
            // Graph
            // 
            this.Graph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Graph.Location = new System.Drawing.Point(0, 0);
            this.Graph.Name = "Graph";
            this.Graph.ScrollGrace = 0;
            this.Graph.ScrollMaxX = 0;
            this.Graph.ScrollMaxY = 0;
            this.Graph.ScrollMaxY2 = 0;
            this.Graph.ScrollMinX = 0;
            this.Graph.ScrollMinY = 0;
            this.Graph.ScrollMinY2 = 0;
            this.Graph.Size = new System.Drawing.Size(755, 194);
            this.Graph.TabIndex = 0;
            this.Graph.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Graph_KeyUp);
            // 
            // graphToolStrip
            // 
            this.graphToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.graphToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphGitem,
            this.toolStripSeparator9,
            this.dataGitem,
            this.toolStripSeparator12,
            this.axisGitem,
            this.toolStripSeparator13,
            this.clearGitem,
            this.toolStripSeparator14,
            this.pauseGitem,
            this.toolStripSeparator11,
            this.zoomGitem,
            this.toolStripSeparator7,
            this.gridlinesGitem,
            this.toolStripSeparator17,
            this.minLabelGitem,
            this.minGBox,
            this.toolStripSeparator19,
            this.helpGitem,
            this.propGitem});
            this.graphToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.graphToolStrip.Location = new System.Drawing.Point(0, 0);
            this.graphToolStrip.Name = "graphToolStrip";
            this.graphToolStrip.Size = new System.Drawing.Size(755, 25);
            this.graphToolStrip.Stretch = true;
            this.graphToolStrip.TabIndex = 0;
            // 
            // graphGitem
            // 
            this.graphGitem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem,
            this.lineFilledToolStripMenuItem,
            this.barToolStripMenuItem,
            this.pieToolStripMenuItem});
            this.graphGitem.Image = ((System.Drawing.Image)(resources.GetObject("graphGitem.Image")));
            this.graphGitem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.graphGitem.Name = "graphGitem";
            this.graphGitem.Size = new System.Drawing.Size(95, 22);
            this.graphGitem.Text = "Graph Type";
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Image = global::nsNetPeak.Properties.Resources.layout_graph;
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.graphGitem_Click);
            // 
            // lineFilledToolStripMenuItem
            // 
            this.lineFilledToolStripMenuItem.Image = global::nsNetPeak.Properties.Resources.graph_linefill;
            this.lineFilledToolStripMenuItem.Name = "lineFilledToolStripMenuItem";
            this.lineFilledToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.lineFilledToolStripMenuItem.Text = "Line Filled";
            this.lineFilledToolStripMenuItem.Click += new System.EventHandler(this.graphGitem_Click);
            // 
            // barToolStripMenuItem
            // 
            this.barToolStripMenuItem.Enabled = false;
            this.barToolStripMenuItem.Name = "barToolStripMenuItem";
            this.barToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.barToolStripMenuItem.Text = "Bar";
            this.barToolStripMenuItem.Click += new System.EventHandler(this.graphGitem_Click);
            // 
            // pieToolStripMenuItem
            // 
            this.pieToolStripMenuItem.Enabled = false;
            this.pieToolStripMenuItem.Name = "pieToolStripMenuItem";
            this.pieToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.pieToolStripMenuItem.Text = "Pie";
            this.pieToolStripMenuItem.Click += new System.EventHandler(this.graphGitem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // dataGitem
            // 
            this.dataGitem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stackToolStripMenuItem,
            this.nonStackedToolStripMenuItem});
            this.dataGitem.Image = ((System.Drawing.Image)(resources.GetObject("dataGitem.Image")));
            this.dataGitem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dataGitem.Name = "dataGitem";
            this.dataGitem.Size = new System.Drawing.Size(62, 22);
            this.dataGitem.Text = "Data";
            this.dataGitem.ToolTipText = "Graph Data Properties";
            // 
            // stackToolStripMenuItem
            // 
            this.stackToolStripMenuItem.Image = global::nsNetPeak.Properties.Resources.stacked;
            this.stackToolStripMenuItem.Name = "stackToolStripMenuItem";
            this.stackToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.stackToolStripMenuItem.Text = "Stack";
            this.stackToolStripMenuItem.ToolTipText = "Stack Bar or Line Graph";
            this.stackToolStripMenuItem.Click += new System.EventHandler(this.dataGitem_Click);
            // 
            // nonStackedToolStripMenuItem
            // 
            this.nonStackedToolStripMenuItem.Image = global::nsNetPeak.Properties.Resources.nonstacked;
            this.nonStackedToolStripMenuItem.Name = "nonStackedToolStripMenuItem";
            this.nonStackedToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.nonStackedToolStripMenuItem.Text = "Nonstacked";
            this.nonStackedToolStripMenuItem.Click += new System.EventHandler(this.dataGitem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // axisGitem
            // 
            this.axisGitem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singleToolStripMenuItem,
            this.multipleToolStripMenuItem});
            this.axisGitem.Image = ((System.Drawing.Image)(resources.GetObject("axisGitem.Image")));
            this.axisGitem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.axisGitem.Name = "axisGitem";
            this.axisGitem.Size = new System.Drawing.Size(68, 22);
            this.axisGitem.Text = "Y Axis";
            this.axisGitem.ToolTipText = "Single or multiple Y axis";
            // 
            // singleToolStripMenuItem
            // 
            this.singleToolStripMenuItem.Image = global::nsNetPeak.Properties.Resources.axis1;
            this.singleToolStripMenuItem.Name = "singleToolStripMenuItem";
            this.singleToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.singleToolStripMenuItem.Text = "Single Axis";
            this.singleToolStripMenuItem.Click += new System.EventHandler(this.axisGitem_Click);
            // 
            // multipleToolStripMenuItem
            // 
            this.multipleToolStripMenuItem.Image = global::nsNetPeak.Properties.Resources.axis2;
            this.multipleToolStripMenuItem.Name = "multipleToolStripMenuItem";
            this.multipleToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.multipleToolStripMenuItem.Text = "Multiple Axis";
            this.multipleToolStripMenuItem.Click += new System.EventHandler(this.axisGitem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // clearGitem
            // 
            this.clearGitem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearGitem.Image = ((System.Drawing.Image)(resources.GetObject("clearGitem.Image")));
            this.clearGitem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearGitem.Name = "clearGitem";
            this.clearGitem.Size = new System.Drawing.Size(36, 22);
            this.clearGitem.Text = "Clear";
            this.clearGitem.Click += new System.EventHandler(this.clearGitem_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // pauseGitem
            // 
            this.pauseGitem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.pauseGitem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pauseGitem.Name = "pauseGitem";
            this.pauseGitem.Size = new System.Drawing.Size(40, 22);
            this.pauseGitem.Text = "Pause";
            this.pauseGitem.ToolTipText = "Pause Graph Time Advance (key=space)";
            this.pauseGitem.Click += new System.EventHandler(this.pauseGitem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // zoomGitem
            // 
            this.zoomGitem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomResetToolStripMenuItem,
            this.zoomOutToolStripMenuItem});
            this.zoomGitem.Image = global::nsNetPeak.Properties.Resources.zoomReset;
            this.zoomGitem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomGitem.Name = "zoomGitem";
            this.zoomGitem.Size = new System.Drawing.Size(65, 22);
            this.zoomGitem.Text = "Zoom";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Image = global::nsNetPeak.Properties.Resources.zoomIn;
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom In(+)";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomGitem_Click);
            // 
            // zoomResetToolStripMenuItem
            // 
            this.zoomResetToolStripMenuItem.Enabled = false;
            this.zoomResetToolStripMenuItem.Image = global::nsNetPeak.Properties.Resources.zoomReset;
            this.zoomResetToolStripMenuItem.Name = "zoomResetToolStripMenuItem";
            this.zoomResetToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.zoomResetToolStripMenuItem.Text = "Zoom Reset(1)";
            this.zoomResetToolStripMenuItem.Click += new System.EventHandler(this.zoomGitem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Image = global::nsNetPeak.Properties.Resources.zoomOut;
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out(-)";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomGitem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // gridlinesGitem
            // 
            this.gridlinesGitem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.majorXGitem,
            this.minorXGiItem,
            this.majorYGitem,
            this.minorYGitem});
            this.gridlinesGitem.Image = global::nsNetPeak.Properties.Resources.gridLines;
            this.gridlinesGitem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gridlinesGitem.Name = "gridlinesGitem";
            this.gridlinesGitem.Size = new System.Drawing.Size(82, 22);
            this.gridlinesGitem.Text = "GridLines";
            // 
            // majorXGitem
            // 
            this.majorXGitem.CheckOnClick = true;
            this.majorXGitem.Name = "majorXGitem";
            this.majorXGitem.Size = new System.Drawing.Size(121, 22);
            this.majorXGitem.Text = "Major X";
            this.majorXGitem.Click += new System.EventHandler(this.gridlinesGitem_Click);
            // 
            // minorXGiItem
            // 
            this.minorXGiItem.CheckOnClick = true;
            this.minorXGiItem.Name = "minorXGiItem";
            this.minorXGiItem.Size = new System.Drawing.Size(121, 22);
            this.minorXGiItem.Text = "Minor X";
            this.minorXGiItem.Click += new System.EventHandler(this.gridlinesGitem_Click);
            // 
            // majorYGitem
            // 
            this.majorYGitem.CheckOnClick = true;
            this.majorYGitem.Name = "majorYGitem";
            this.majorYGitem.Size = new System.Drawing.Size(121, 22);
            this.majorYGitem.Text = "Major Y";
            this.majorYGitem.Click += new System.EventHandler(this.gridlinesGitem_Click);
            // 
            // minorYGitem
            // 
            this.minorYGitem.CheckOnClick = true;
            this.minorYGitem.Name = "minorYGitem";
            this.minorYGitem.Size = new System.Drawing.Size(121, 22);
            this.minorYGitem.Text = "Minor Y";
            this.minorYGitem.Click += new System.EventHandler(this.gridlinesGitem_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
            // 
            // minLabelGitem
            // 
            this.minLabelGitem.Name = "minLabelGitem";
            this.minLabelGitem.Size = new System.Drawing.Size(48, 22);
            this.minLabelGitem.Text = "Minutes:";
            // 
            // minGBox
            // 
            this.minGBox.Name = "minGBox";
            this.minGBox.Size = new System.Drawing.Size(100, 25);
            this.minGBox.ToolTipText = "Minutes displayed in graph";
            this.minGBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.minGBox_KeyUp);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 25);
            // 
            // helpGitem
            // 
            this.helpGitem.BackColor = System.Drawing.Color.Lime;
            this.helpGitem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.helpGitem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpGitem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpGitem.Name = "helpGitem";
            this.helpGitem.Size = new System.Drawing.Size(23, 22);
            this.helpGitem.Text = "?";
            this.helpGitem.ToolTipText = resources.GetString("helpGitem.ToolTipText");
            // 
            // propGitem
            // 
            this.propGitem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.propGitem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesGitem,
            this.symbolGitem});
            this.propGitem.Image = ((System.Drawing.Image)(resources.GetObject("propGitem.Image")));
            this.propGitem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.propGitem.Name = "propGitem";
            this.propGitem.Size = new System.Drawing.Size(45, 22);
            this.propGitem.Text = "Prop";
            // 
            // propertiesGitem
            // 
            this.propertiesGitem.Name = "propertiesGitem";
            this.propertiesGitem.Size = new System.Drawing.Size(134, 22);
            this.propertiesGitem.Text = "Properties";
            this.propertiesGitem.ToolTipText = "Popup General Graph Properties Dialog";
            this.propertiesGitem.Click += new System.EventHandler(this.propGitem_Click);
            // 
            // symbolGitem
            // 
            this.symbolGitem.CheckOnClick = true;
            this.symbolGitem.Name = "symbolGitem";
            this.symbolGitem.Size = new System.Drawing.Size(134, 22);
            this.symbolGitem.Text = "Symbols";
            this.symbolGitem.ToolTipText = "Show/Hide symbols on line graphs";
            this.symbolGitem.Click += new System.EventHandler(this.propGitem_Click);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(198, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(50, 50);
            this.panel3.TabIndex = 12;
            this.toolTip.SetToolTip(this.panel3, "Click to activate panels");
            this.panel3.Click += new System.EventHandler(this.panel3_Click);
            // 
            // globalCfgPanel
            // 
            this.globalCfgPanel.BackgroundImage = global::nsNetPeak.Properties.Resources.globe;
            this.globalCfgPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.globalCfgPanel.Location = new System.Drawing.Point(254, 37);
            this.globalCfgPanel.Name = "globalCfgPanel";
            this.globalCfgPanel.Size = new System.Drawing.Size(40, 40);
            this.globalCfgPanel.TabIndex = 15;
            this.toolTip.SetToolTip(this.globalCfgPanel, "Pop open Global Network Statistics");
            this.globalCfgPanel.Click += new System.EventHandler(this.globalCfg_Click);
            // 
            // elapsedTime
            // 
            this.elapsedTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.elapsedTime.BackColor = System.Drawing.Color.Transparent;
            this.elapsedTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.elapsedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elapsedTime.ForeColor = System.Drawing.Color.White;
            this.elapsedTime.Location = new System.Drawing.Point(910, 23);
            this.elapsedTime.Name = "elapsedTime";
            this.elapsedTime.Size = new System.Drawing.Size(81, 18);
            this.elapsedTime.TabIndex = 14;
            this.elapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.elapsedTime, "Elapsed Capture Time ");
            // 
            // filterBox
            // 
            this.filterBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.filterBox.Location = new System.Drawing.Point(13, 545);
            this.filterBox.Name = "filterBox";
            this.filterBox.ReadOnly = true;
            this.filterBox.Size = new System.Drawing.Size(85, 20);
            this.filterBox.TabIndex = 18;
            this.toolTip.SetToolTip(this.filterBox, "Excluded Packets, see Exclude filter list");
            // 
            // settingPanel
            // 
            this.settingPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("settingPanel.BackgroundImage")));
            this.settingPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.settingPanel.Location = new System.Drawing.Point(300, 37);
            this.settingPanel.Name = "settingPanel";
            this.settingPanel.Size = new System.Drawing.Size(48, 48);
            this.settingPanel.TabIndex = 19;
            this.toolTip.SetToolTip(this.settingPanel, "Settings");
            this.settingPanel.Click += new System.EventHandler(this.settingPanel_Click);
            // 
            // exportFileDialog
            // 
            this.exportFileDialog.DefaultExt = "csv";
            this.exportFileDialog.Filter = "CSV|*.csv|Any|*.*";
            this.exportFileDialog.Title = "Export List";
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.BackColor = System.Drawing.Color.Maroon;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Location = new System.Drawing.Point(932, 544);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 20);
            this.closeBtn.TabIndex = 16;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // TitleGlow
            // 
            this.TitleGlow.BackColor = System.Drawing.Color.Transparent;
            this.TitleGlow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TitleGlow.Font = new System.Drawing.Font("Arial", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleGlow.ForeColor = System.Drawing.Color.White;
            this.TitleGlow.Location = new System.Drawing.Point(190, 8);
            this.TitleGlow.Margin = new System.Windows.Forms.Padding(2);
            this.TitleGlow.Name = "TitleGlow";
            this.TitleGlow.Size = new System.Drawing.Size(130, 23);
            this.TitleGlow.TabIndex = 17;
            this.TitleGlow.Text = "NetPeak v1.5";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "csv|*.csv|log|*.log|Text|*.txt|any|*.*";
            this.saveFileDialog.Title = "Log Traffic File";
            // 
            // titleText
            // 
            this.titleText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.titleText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(47)))), ((int)(((byte)(108)))));
            this.titleText.BarSize = 2;
            this.titleText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.titleText.Font = new System.Drawing.Font("Footlight MT Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleText.ForeColor = System.Drawing.Color.Silver;
            this.titleText.Image = global::nsNetPeak.Properties.Resources.none;
            this.titleText.Location = new System.Drawing.Point(374, 9);
            this.titleText.Name = "titleText";
            this.titleText.Progress = 0;
            this.titleText.Size = new System.Drawing.Size(633, 44);
            this.titleText.TabIndex = 9;
            this.titleText.Text = "Monitor and Graph TCP Traffic.";
            this.titleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.titleText, "Product description and active bar when capturing data.");
            this.titleText.Click += new System.EventHandler(this.About_Click);
            // 
            // NetPeakForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(47)))), ((int)(((byte)(108)))));
            this.ClientSize = new System.Drawing.Size(1019, 579);
            this.Controls.Add(this.settingPanel);
            this.Controls.Add(this.filterBox);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.elapsedTime);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.titleText);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.globalCfgPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitLeftRight);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.TitleGlow);
            this.Controls.Add(this.cmbInterfaces);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.captureImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NetPeakForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "NetPeak v1.0 - Dennis Lang";
            this.Load += new System.EventHandler(this.NetPeak_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NetPeak_Closing);
            this.trafficMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.splitLeftRight.Panel1.ResumeLayout(false);
            this.splitLeftRight.Panel2.ResumeLayout(false);
            this.splitLeftRight.ResumeLayout(false);
            this.splitExcludeDetail.Panel1.ResumeLayout(false);
            this.splitExcludeDetail.Panel2.ResumeLayout(false);
            this.splitExcludeDetail.ResumeLayout(false);
            this.excludeToolBox.ContentPanel.ResumeLayout(false);
            this.excludeToolBox.TopToolStripPanel.ResumeLayout(false);
            this.excludeToolBox.TopToolStripPanel.PerformLayout();
            this.excludeToolBox.ResumeLayout(false);
            this.excludeToolBox.PerformLayout();
            this.excludeMenu.ResumeLayout(false);
            this.excludeToolStrip.ResumeLayout(false);
            this.excludeToolStrip.PerformLayout();
            this.trafficPanel.ResumeLayout(false);
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.PerformLayout();
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.trafficToolStrip.ResumeLayout(false);
            this.trafficToolStrip.PerformLayout();
            this.historyPanel.ResumeLayout(false);
            this.toolStripContainer3.ContentPanel.ResumeLayout(false);
            this.toolStripContainer3.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer3.TopToolStripPanel.PerformLayout();
            this.toolStripContainer3.ResumeLayout(false);
            this.toolStripContainer3.PerformLayout();
            this.historyMenu.ResumeLayout(false);
            this.histToolstrip.ResumeLayout(false);
            this.histToolstrip.PerformLayout();
            this.splitViewGraph.Panel1.ResumeLayout(false);
            this.splitViewGraph.Panel2.ResumeLayout(false);
            this.splitViewGraph.ResumeLayout(false);
            this.statListToolStrip.ContentPanel.ResumeLayout(false);
            this.statListToolStrip.TopToolStripPanel.ResumeLayout(false);
            this.statListToolStrip.TopToolStripPanel.PerformLayout();
            this.statListToolStrip.ResumeLayout(false);
            this.statListToolStrip.PerformLayout();
            this.tableMenu.ResumeLayout(false);
            this.statToolStrip.ResumeLayout(false);
            this.statToolStrip.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.graphToolStrip.ResumeLayout(false);
            this.graphToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trafficTree;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cmbInterfaces;
        private System.Windows.Forms.ListView statView;
        private System.Windows.Forms.ColumnHeader col_host;
        private System.Windows.Forms.ColumnHeader col_ip;
        private System.Windows.Forms.ColumnHeader col_local;
        private System.Windows.Forms.ColumnHeader col_remote;
        private System.Windows.Forms.ColumnHeader col_read;
        private System.Windows.Forms.ColumnHeader col_write;
        private System.Windows.Forms.SplitContainer splitLeftRight;
        private System.Windows.Forms.SplitContainer splitExcludeDetail;
        private System.Windows.Forms.SplitContainer splitViewGraph;
        private System.Windows.Forms.ListView excludeList;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox statusBar;
        private System.Windows.Forms.ColumnHeader col_Nread;
        private System.Windows.Forms.ColumnHeader col_Nwrite;
        private System.Windows.Forms.ColumnHeader col_time;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Label Title;
        private TextBar titleText;
        private System.Windows.Forms.ContextMenuStrip trafficMenu;
        private System.Windows.Forms.ToolStripMenuItem clearTitem;
        private System.Windows.Forms.ToolStripContainer statListToolStrip;
        private System.Windows.Forms.ToolStrip statToolStrip;
        private System.Windows.Forms.Panel captureImage;
        private System.Windows.Forms.ToolStripSplitButton viewMitem;
        private System.Windows.Forms.ToolStripMenuItem viewSummaryMitem;
        private System.Windows.Forms.ToolStripMenuItem viewDetailMitem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton trimMitem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton sortMitem;
        private System.Windows.Forms.ToolStripSplitButton totalMitem;
        private System.Windows.Forms.ToolStripMenuItem total5Mitem;
        private System.Windows.Forms.ToolStripMenuItem total10Mitem;
        private System.Windows.Forms.ToolStripMenuItem total30Mitem;
        private System.Windows.Forms.ToolStripMenuItem total60Mitem;
        private System.Windows.Forms.ToolStripMenuItem bySortOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byMaxReadSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byMaxWriteSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton clearMitem;
        private System.Windows.Forms.ToolStripMenuItem removeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Timer timerAnimation;
        private System.Windows.Forms.ToolStripSplitButton layoutMitem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listAndGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trafficToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tableSizeBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.ToolStripSplitButton unitMitem;
        private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bytesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kiloBytesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem megaBytesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gigaBytesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noTotalMitem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip graphToolStrip;
        private System.Windows.Forms.ToolStripSplitButton graphGitem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem barToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pieToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.SaveFileDialog exportFileDialog;
        private System.Windows.Forms.ContextMenuStrip excludeMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteExcludeMitem;
        private System.Windows.Forms.ToolStripMenuItem exportExcludeMitem;
        private System.Windows.Forms.ToolStripMenuItem editExcludeMitem;
        private System.Windows.Forms.ContextMenuStrip tableMenu;
        private System.Windows.Forms.ToolStripMenuItem clearTableMitem;
        private System.Windows.Forms.ToolStripMenuItem deleteTableMitem;
        private System.Windows.Forms.ToolStripMenuItem exportTableMitem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem reSizeColumnsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reSizeColumnsToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader col_t;
        private System.Windows.Forms.ColumnHeader col_g;
        private ZedGraph.ZedGraphControl Graph;
        private System.Windows.Forms.ColumnHeader col_gc;
        private System.Windows.Forms.ToolStripMenuItem lineFilledToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton dataGitem;
        private System.Windows.Forms.ToolStripMenuItem stackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nonStackedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripSplitButton axisGitem;
        private System.Windows.Forms.ToolStripMenuItem singleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multipleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.Label elapsedTime;
        private System.Windows.Forms.ToolStripButton clearGitem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.Panel trafficPanel;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private System.Windows.Forms.ToolStrip trafficToolStrip;
        private System.Windows.Forms.ToolStripButton trafficBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripTextBox trafficCnt;
        private System.Windows.Forms.Panel historyPanel;
        private System.Windows.Forms.ToolStripContainer toolStripContainer3;
        private System.Windows.Forms.ListView histView;
        private System.Windows.Forms.ColumnHeader col_r;
        private System.Windows.Forms.ColumnHeader col_rN;
        private System.Windows.Forms.ColumnHeader col_rTime;
        private System.Windows.Forms.ColumnHeader col_w;
        private System.Windows.Forms.ColumnHeader col_wN;
        private System.Windows.Forms.ColumnHeader col_wTime;
        private System.Windows.Forms.ToolStrip histToolstrip;
        private System.Windows.Forms.ToolStripButton refreshHitem;
        private System.Windows.Forms.ToolStripLabel titleHitem;
        private System.Windows.Forms.ContextMenuStrip historyMenu;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.Panel globalCfgPanel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ImageList sortArrowImages;
        private System.Windows.Forms.ToolStripButton pauseGitem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripSplitButton zoomGitem;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomResetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSplitButton gridlinesGitem;
        private System.Windows.Forms.ToolStripMenuItem majorXGitem;
        private System.Windows.Forms.ToolStripMenuItem minorXGiItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripMenuItem majorYGitem;
        private System.Windows.Forms.ToolStripMenuItem minorYGitem;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Label TitleGlow;
        private System.Windows.Forms.ImageList checkbox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripMenuItem totolPerSecMitem;
        private System.Windows.Forms.ToolStripLabel minLabelGitem;
        private System.Windows.Forms.ToolStripTextBox minGBox;
        private System.Windows.Forms.ToolStripButton helpGitem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem2;
        private System.Windows.Forms.TextBox filterBox;
        private System.Windows.Forms.ToolStripContainer excludeToolBox;
        private System.Windows.Forms.ToolStrip excludeToolStrip;
        private System.Windows.Forms.ToolStripButton exclBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator22;
        private System.Windows.Forms.ToolStripButton histBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator23;
        private System.Windows.Forms.ToolStripButton trafBtn;
        private System.Windows.Forms.ToolStripMenuItem eToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton logTitem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripSplitButton propGitem;
        private System.Windows.Forms.ToolStripMenuItem propertiesGitem;
        private System.Windows.Forms.ToolStripMenuItem symbolGitem;
        private System.Windows.Forms.Panel settingPanel;
        private System.Windows.Forms.Label infoLayer;
    }
}

