namespace InstagramDownloaderV2.Forms
{
    partial class frmMain
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.gbChangelog = new System.Windows.Forms.GroupBox();
            this.txtChangelog = new System.Windows.Forms.TextBox();
            this.gbCreditsAndVersion = new System.Windows.Forms.GroupBox();
            this.gbCredits = new System.Windows.Forms.GroupBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.gbVersion = new System.Windows.Forms.GroupBox();
            this.lblLatestVersion = new System.Windows.Forms.Label();
            this.lblCurrentVersion = new System.Windows.Forms.Label();
            this.tabPageDownloader = new System.Windows.Forms.TabPage();
            this.gbInputParams = new System.Windows.Forms.GroupBox();
            this.lvInput = new System.Windows.Forms.ListView();
            this.lvInputType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvInputData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvInputDownloads = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripForListBoxInput = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editSelectedRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportSelectedRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.numTotalDownloads = new System.Windows.Forms.NumericUpDown();
            this.lblTotalDownloads = new System.Windows.Forms.Label();
            this.btnLoadInputFromFile = new System.Windows.Forms.Button();
            this.btnAddInput = new System.Windows.Forms.Button();
            this.btnClearAllInput = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.gbDownload = new System.Windows.Forms.GroupBox();
            this.btnStartDownloading = new System.Windows.Forms.Button();
            this.btnStopDownloading = new System.Windows.Forms.Button();
            this.gbInputMethod = new System.Windows.Forms.GroupBox();
            this.rbLocation = new System.Windows.Forms.RadioButton();
            this.rbHashtag = new System.Windows.Forms.RadioButton();
            this.rbUserId = new System.Windows.Forms.RadioButton();
            this.rbMediaId = new System.Windows.Forms.RadioButton();
            this.rbUsername = new System.Windows.Forms.RadioButton();
            this.rbUrl = new System.Windows.Forms.RadioButton();
            this.tabPageFilters = new System.Windows.Forms.TabPage();
            this.gbMediaFilters = new System.Windows.Forms.GroupBox();
            this.cbSkipTopPosts = new System.Windows.Forms.CheckBox();
            this.txtSkipDescriptionStrings = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalDownloads = new System.Windows.Forms.TextBox();
            this.cbTotalDownloads = new System.Windows.Forms.CheckBox();
            this.cbSkipMediaDescription = new System.Windows.Forms.CheckBox();
            this.dtUploadTime = new System.Windows.Forms.DateTimePicker();
            this.cbSkipMediaUploadDate = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSkipVideoViewsCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSkipMediaCommentsCount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSkipVideoViewsMoreLess = new System.Windows.Forms.ComboBox();
            this.cbSkipMediaUploadDateMoreLess = new System.Windows.Forms.ComboBox();
            this.cbSkipVideoViews = new System.Windows.Forms.CheckBox();
            this.cbSkipMediaCommentsMoreLess = new System.Windows.Forms.ComboBox();
            this.cbSkipMediaComments = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSkipMediaLikesCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSkipMediaLikesMoreLess = new System.Windows.Forms.ComboBox();
            this.cbSkipMediaLikes = new System.Windows.Forms.CheckBox();
            this.cbSkipPhotos = new System.Windows.Forms.CheckBox();
            this.cbSkipVideos = new System.Windows.Forms.CheckBox();
            this.btnClearSkipDescriptionStrings = new System.Windows.Forms.Button();
            this.btnLoadDescriptionStrings = new System.Windows.Forms.Button();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.gbAccountSettings = new System.Windows.Forms.GroupBox();
            this.btnAccountLogout = new System.Windows.Forms.Button();
            this.cbHidePassword = new System.Windows.Forms.CheckBox();
            this.btnAccountLogin = new System.Windows.Forms.Button();
            this.lblAccountLoginStatus = new System.Windows.Forms.Label();
            this.lblAccountPassword = new System.Windows.Forms.Label();
            this.lblAccountUsername = new System.Windows.Forms.Label();
            this.txtAccountPassword = new System.Windows.Forms.TextBox();
            this.txtAccountUsername = new System.Windows.Forms.TextBox();
            this.gbDownloadSettings = new System.Windows.Forms.GroupBox();
            this.txtDelimiter = new System.Windows.Forms.TextBox();
            this.cbSaveStats = new System.Windows.Forms.CheckBox();
            this.cbCreateNewFolder = new System.Windows.Forms.CheckBox();
            this.btnBrowseDownloadDirectory = new System.Windows.Forms.Button();
            this.txtDownloadFolder = new System.Windows.Forms.TextBox();
            this.lblDownloadFolder = new System.Windows.Forms.Label();
            this.gbWebSettings = new System.Windows.Forms.GroupBox();
            this.btnRandomizeUserAgent = new System.Windows.Forms.Button();
            this.lblProxy = new System.Windows.Forms.Label();
            this.lblThreads = new System.Windows.Forms.Label();
            this.lblRequestTimeout = new System.Windows.Forms.Label();
            this.lblUserAgent = new System.Windows.Forms.Label();
            this.txtProxy = new System.Windows.Forms.TextBox();
            this.txtThreads = new System.Windows.Forms.TextBox();
            this.txtRequestTimeout = new System.Windows.Forms.TextBox();
            this.txtUserAgent = new System.Windows.Forms.TextBox();
            this.tabPageLogs = new System.Windows.Forms.TabPage();
            this.gbLogs = new System.Windows.Forms.GroupBox();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.btnExportLogs = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetAllFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputTypeTips = new System.Windows.Forms.ToolTip(this.components);
            this.tabMain.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.gbChangelog.SuspendLayout();
            this.gbCreditsAndVersion.SuspendLayout();
            this.gbCredits.SuspendLayout();
            this.gbVersion.SuspendLayout();
            this.tabPageDownloader.SuspendLayout();
            this.gbInputParams.SuspendLayout();
            this.contextMenuStripForListBoxInput.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalDownloads)).BeginInit();
            this.gbDownload.SuspendLayout();
            this.gbInputMethod.SuspendLayout();
            this.tabPageFilters.SuspendLayout();
            this.gbMediaFilters.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.gbAccountSettings.SuspendLayout();
            this.gbDownloadSettings.SuspendLayout();
            this.gbWebSettings.SuspendLayout();
            this.tabPageLogs.SuspendLayout();
            this.gbLogs.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPageGeneral);
            this.tabMain.Controls.Add(this.tabPageDownloader);
            this.tabMain.Controls.Add(this.tabPageFilters);
            this.tabMain.Controls.Add(this.tabPageSettings);
            this.tabMain.Controls.Add(this.tabPageLogs);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 24);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(645, 523);
            this.tabMain.TabIndex = 0;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.gbChangelog);
            this.tabPageGeneral.Controls.Add(this.gbCreditsAndVersion);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(637, 497);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // gbChangelog
            // 
            this.gbChangelog.Controls.Add(this.txtChangelog);
            this.gbChangelog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbChangelog.Location = new System.Drawing.Point(3, 3);
            this.gbChangelog.Name = "gbChangelog";
            this.gbChangelog.Size = new System.Drawing.Size(631, 399);
            this.gbChangelog.TabIndex = 0;
            this.gbChangelog.TabStop = false;
            this.gbChangelog.Text = "Changelog";
            // 
            // txtChangelog
            // 
            this.txtChangelog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChangelog.Location = new System.Drawing.Point(3, 16);
            this.txtChangelog.Multiline = true;
            this.txtChangelog.Name = "txtChangelog";
            this.txtChangelog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtChangelog.Size = new System.Drawing.Size(625, 380);
            this.txtChangelog.TabIndex = 0;
            // 
            // gbCreditsAndVersion
            // 
            this.gbCreditsAndVersion.Controls.Add(this.gbCredits);
            this.gbCreditsAndVersion.Controls.Add(this.gbVersion);
            this.gbCreditsAndVersion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbCreditsAndVersion.Location = new System.Drawing.Point(3, 402);
            this.gbCreditsAndVersion.Name = "gbCreditsAndVersion";
            this.gbCreditsAndVersion.Size = new System.Drawing.Size(631, 92);
            this.gbCreditsAndVersion.TabIndex = 1;
            this.gbCreditsAndVersion.TabStop = false;
            // 
            // gbCredits
            // 
            this.gbCredits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbCredits.Controls.Add(this.linkLabel2);
            this.gbCredits.Controls.Add(this.linkLabel1);
            this.gbCredits.Location = new System.Drawing.Point(6, 19);
            this.gbCredits.Name = "gbCredits";
            this.gbCredits.Size = new System.Drawing.Size(283, 62);
            this.gbCredits.TabIndex = 1;
            this.gbCredits.TabStop = false;
            this.gbCredits.Text = "Credits";
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(155, 24);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(102, 13);
            this.linkLabel2.TabIndex = 0;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "www.smmnova.com";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(25, 24);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(86, 13);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.imristo.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // gbVersion
            // 
            this.gbVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbVersion.Controls.Add(this.lblLatestVersion);
            this.gbVersion.Controls.Add(this.lblCurrentVersion);
            this.gbVersion.Location = new System.Drawing.Point(299, 19);
            this.gbVersion.Name = "gbVersion";
            this.gbVersion.Size = new System.Drawing.Size(326, 62);
            this.gbVersion.TabIndex = 1;
            this.gbVersion.TabStop = false;
            this.gbVersion.Text = "Version details";
            // 
            // lblLatestVersion
            // 
            this.lblLatestVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLatestVersion.AutoSize = true;
            this.lblLatestVersion.Location = new System.Drawing.Point(165, 24);
            this.lblLatestVersion.Name = "lblLatestVersion";
            this.lblLatestVersion.Size = new System.Drawing.Size(79, 13);
            this.lblLatestVersion.TabIndex = 0;
            this.lblLatestVersion.Text = "Latest version: ";
            // 
            // lblCurrentVersion
            // 
            this.lblCurrentVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentVersion.AutoSize = true;
            this.lblCurrentVersion.Location = new System.Drawing.Point(33, 24);
            this.lblCurrentVersion.Name = "lblCurrentVersion";
            this.lblCurrentVersion.Size = new System.Drawing.Size(84, 13);
            this.lblCurrentVersion.TabIndex = 0;
            this.lblCurrentVersion.Text = "Current version: ";
            // 
            // tabPageDownloader
            // 
            this.tabPageDownloader.Controls.Add(this.gbInputParams);
            this.tabPageDownloader.Controls.Add(this.panel1);
            this.tabPageDownloader.Controls.Add(this.gbInputMethod);
            this.tabPageDownloader.Location = new System.Drawing.Point(4, 22);
            this.tabPageDownloader.Name = "tabPageDownloader";
            this.tabPageDownloader.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDownloader.Size = new System.Drawing.Size(637, 497);
            this.tabPageDownloader.TabIndex = 1;
            this.tabPageDownloader.Text = "Downloader";
            this.tabPageDownloader.UseVisualStyleBackColor = true;
            // 
            // gbInputParams
            // 
            this.gbInputParams.Controls.Add(this.lvInput);
            this.gbInputParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInputParams.Location = new System.Drawing.Point(3, 206);
            this.gbInputParams.Name = "gbInputParams";
            this.gbInputParams.Size = new System.Drawing.Size(631, 288);
            this.gbInputParams.TabIndex = 1;
            this.gbInputParams.TabStop = false;
            this.gbInputParams.Text = "Input parameters";
            // 
            // lvInput
            // 
            this.lvInput.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvInputType,
            this.lvInputData,
            this.lvInputDownloads});
            this.lvInput.ContextMenuStrip = this.contextMenuStripForListBoxInput;
            this.lvInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvInput.FullRowSelect = true;
            this.lvInput.LabelEdit = true;
            this.lvInput.Location = new System.Drawing.Point(3, 16);
            this.lvInput.Name = "lvInput";
            this.lvInput.Size = new System.Drawing.Size(625, 269);
            this.lvInput.TabIndex = 0;
            this.lvInput.UseCompatibleStateImageBehavior = false;
            this.lvInput.View = System.Windows.Forms.View.Details;
            // 
            // lvInputType
            // 
            this.lvInputType.Text = "InputType";
            this.lvInputType.Width = 80;
            // 
            // lvInputData
            // 
            this.lvInputData.Text = "Input";
            this.lvInputData.Width = 445;
            // 
            // lvInputDownloads
            // 
            this.lvInputDownloads.Text = "Download Limit";
            this.lvInputDownloads.Width = 85;
            // 
            // contextMenuStripForListBoxInput
            // 
            this.contextMenuStripForListBoxInput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editSelectedRowToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripSeparator2,
            this.exportSelectedRowsToolStripMenuItem,
            this.exportAllToolStripMenuItem});
            this.contextMenuStripForListBoxInput.Name = "contextMenuStripForListBoxInput";
            this.contextMenuStripForListBoxInput.Size = new System.Drawing.Size(194, 126);
            // 
            // editSelectedRowToolStripMenuItem
            // 
            this.editSelectedRowToolStripMenuItem.Name = "editSelectedRowToolStripMenuItem";
            this.editSelectedRowToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.editSelectedRowToolStripMenuItem.Text = "Edit Selected Row";
            this.editSelectedRowToolStripMenuItem.Click += new System.EventHandler(this.editSelectedRowToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(193, 22);
            this.toolStripMenuItem1.Text = "Remove selected";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(193, 22);
            this.toolStripMenuItem2.Text = "Remove All";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(190, 6);
            // 
            // exportSelectedRowsToolStripMenuItem
            // 
            this.exportSelectedRowsToolStripMenuItem.Name = "exportSelectedRowsToolStripMenuItem";
            this.exportSelectedRowsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.exportSelectedRowsToolStripMenuItem.Text = "Export Selected Row(s)";
            this.exportSelectedRowsToolStripMenuItem.Click += new System.EventHandler(this.exportSelectedRowsToolStripMenuItem_Click);
            // 
            // exportAllToolStripMenuItem
            // 
            this.exportAllToolStripMenuItem.Name = "exportAllToolStripMenuItem";
            this.exportAllToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.exportAllToolStripMenuItem.Text = "Export All";
            this.exportAllToolStripMenuItem.Click += new System.EventHandler(this.exportAllToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbInput);
            this.panel1.Controls.Add(this.gbDownload);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 98);
            this.panel1.TabIndex = 3;
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.numTotalDownloads);
            this.gbInput.Controls.Add(this.lblTotalDownloads);
            this.gbInput.Controls.Add(this.btnLoadInputFromFile);
            this.gbInput.Controls.Add(this.btnAddInput);
            this.gbInput.Controls.Add(this.btnClearAllInput);
            this.gbInput.Controls.Add(this.txtInput);
            this.gbInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInput.Location = new System.Drawing.Point(0, 0);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(447, 98);
            this.gbInput.TabIndex = 3;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "Input";
            // 
            // numTotalDownloads
            // 
            this.numTotalDownloads.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numTotalDownloads.Location = new System.Drawing.Point(164, 40);
            this.numTotalDownloads.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numTotalDownloads.Name = "numTotalDownloads";
            this.numTotalDownloads.Size = new System.Drawing.Size(277, 20);
            this.numTotalDownloads.TabIndex = 4;
            // 
            // lblTotalDownloads
            // 
            this.lblTotalDownloads.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalDownloads.AutoSize = true;
            this.lblTotalDownloads.Location = new System.Drawing.Point(3, 42);
            this.lblTotalDownloads.Name = "lblTotalDownloads";
            this.lblTotalDownloads.Size = new System.Drawing.Size(155, 13);
            this.lblTotalDownloads.TabIndex = 4;
            this.lblTotalDownloads.Text = "Total Downloads (0 for no limit):";
            // 
            // btnLoadInputFromFile
            // 
            this.btnLoadInputFromFile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLoadInputFromFile.Location = new System.Drawing.Point(161, 65);
            this.btnLoadInputFromFile.Name = "btnLoadInputFromFile";
            this.btnLoadInputFromFile.Size = new System.Drawing.Size(125, 23);
            this.btnLoadInputFromFile.TabIndex = 2;
            this.btnLoadInputFromFile.Text = "Load";
            this.btnLoadInputFromFile.UseVisualStyleBackColor = true;
            this.btnLoadInputFromFile.Click += new System.EventHandler(this.btnLoadInputFromFile_Click);
            // 
            // btnAddInput
            // 
            this.btnAddInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddInput.Location = new System.Drawing.Point(6, 65);
            this.btnAddInput.Name = "btnAddInput";
            this.btnAddInput.Size = new System.Drawing.Size(125, 23);
            this.btnAddInput.TabIndex = 1;
            this.btnAddInput.Text = "Add";
            this.btnAddInput.UseVisualStyleBackColor = true;
            this.btnAddInput.Click += new System.EventHandler(this.btnAddInput_Click);
            // 
            // btnClearAllInput
            // 
            this.btnClearAllInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnClearAllInput.Location = new System.Drawing.Point(316, 65);
            this.btnClearAllInput.Name = "btnClearAllInput";
            this.btnClearAllInput.Size = new System.Drawing.Size(125, 23);
            this.btnClearAllInput.TabIndex = 3;
            this.btnClearAllInput.Text = "Clear All Input";
            this.btnClearAllInput.UseVisualStyleBackColor = true;
            this.btnClearAllInput.Click += new System.EventHandler(this.btnClearAllInput_Click);
            // 
            // txtInput
            // 
            this.txtInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtInput.Location = new System.Drawing.Point(3, 16);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(438, 20);
            this.txtInput.TabIndex = 0;
            // 
            // gbDownload
            // 
            this.gbDownload.Controls.Add(this.btnStartDownloading);
            this.gbDownload.Controls.Add(this.btnStopDownloading);
            this.gbDownload.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbDownload.Enabled = false;
            this.gbDownload.Location = new System.Drawing.Point(447, 0);
            this.gbDownload.Name = "gbDownload";
            this.gbDownload.Size = new System.Drawing.Size(184, 98);
            this.gbDownload.TabIndex = 4;
            this.gbDownload.TabStop = false;
            this.gbDownload.Text = "Download";
            // 
            // btnStartDownloading
            // 
            this.btnStartDownloading.Location = new System.Drawing.Point(35, 28);
            this.btnStartDownloading.Name = "btnStartDownloading";
            this.btnStartDownloading.Size = new System.Drawing.Size(127, 23);
            this.btnStartDownloading.TabIndex = 0;
            this.btnStartDownloading.Text = "Start downloading...";
            this.btnStartDownloading.UseVisualStyleBackColor = true;
            this.btnStartDownloading.Click += new System.EventHandler(this.btnStartDownloading_Click);
            // 
            // btnStopDownloading
            // 
            this.btnStopDownloading.Enabled = false;
            this.btnStopDownloading.Location = new System.Drawing.Point(35, 56);
            this.btnStopDownloading.Name = "btnStopDownloading";
            this.btnStopDownloading.Size = new System.Drawing.Size(127, 23);
            this.btnStopDownloading.TabIndex = 0;
            this.btnStopDownloading.Text = "Stop downloading...";
            this.btnStopDownloading.UseVisualStyleBackColor = true;
            this.btnStopDownloading.Click += new System.EventHandler(this.btnStopDownloading_Click);
            // 
            // gbInputMethod
            // 
            this.gbInputMethod.Controls.Add(this.rbLocation);
            this.gbInputMethod.Controls.Add(this.rbHashtag);
            this.gbInputMethod.Controls.Add(this.rbUserId);
            this.gbInputMethod.Controls.Add(this.rbMediaId);
            this.gbInputMethod.Controls.Add(this.rbUsername);
            this.gbInputMethod.Controls.Add(this.rbUrl);
            this.gbInputMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbInputMethod.Location = new System.Drawing.Point(3, 3);
            this.gbInputMethod.Name = "gbInputMethod";
            this.gbInputMethod.Size = new System.Drawing.Size(631, 105);
            this.gbInputMethod.TabIndex = 0;
            this.gbInputMethod.TabStop = false;
            this.gbInputMethod.Text = "Input method";
            // 
            // rbLocation
            // 
            this.rbLocation.AutoSize = true;
            this.rbLocation.Location = new System.Drawing.Point(314, 63);
            this.rbLocation.Name = "rbLocation";
            this.rbLocation.Size = new System.Drawing.Size(66, 17);
            this.rbLocation.TabIndex = 0;
            this.rbLocation.TabStop = true;
            this.rbLocation.Text = "Location";
            this.inputTypeTips.SetToolTip(this.rbLocation, "Input takes one location ID per input.\r\n\r\nExample:\r\n212936194\r\n\r\nTo find your loc" +
        "ation ID, visit the following page:\r\nhttps://www.instagram.com/explore/locations" +
        "/");
            this.rbLocation.UseVisualStyleBackColor = true;
            // 
            // rbHashtag
            // 
            this.rbHashtag.AutoSize = true;
            this.rbHashtag.Location = new System.Drawing.Point(314, 31);
            this.rbHashtag.Name = "rbHashtag";
            this.rbHashtag.Size = new System.Drawing.Size(65, 17);
            this.rbHashtag.TabIndex = 0;
            this.rbHashtag.TabStop = true;
            this.rbHashtag.Text = "Hashtag";
            this.inputTypeTips.SetToolTip(this.rbHashtag, "Input takes one hashtag per input.\r\n\r\nDo NOT include # in front of hashtag(s).\r\n\r" +
        "\nExamples:\r\nnature\r\nfitness");
            this.rbHashtag.UseVisualStyleBackColor = true;
            // 
            // rbUserId
            // 
            this.rbUserId.AutoSize = true;
            this.rbUserId.Location = new System.Drawing.Point(148, 63);
            this.rbUserId.Name = "rbUserId";
            this.rbUserId.Size = new System.Drawing.Size(59, 17);
            this.rbUserId.TabIndex = 0;
            this.rbUserId.TabStop = true;
            this.rbUserId.Text = "User Id";
            this.rbUserId.UseVisualStyleBackColor = true;
            // 
            // rbMediaId
            // 
            this.rbMediaId.AutoSize = true;
            this.rbMediaId.Location = new System.Drawing.Point(22, 63);
            this.rbMediaId.Name = "rbMediaId";
            this.rbMediaId.Size = new System.Drawing.Size(66, 17);
            this.rbMediaId.TabIndex = 0;
            this.rbMediaId.TabStop = true;
            this.rbMediaId.Text = "Media Id";
            this.rbMediaId.UseVisualStyleBackColor = true;
            this.rbMediaId.CheckedChanged += new System.EventHandler(this.rbMediaId_CheckedChanged);
            // 
            // rbUsername
            // 
            this.rbUsername.AutoSize = true;
            this.rbUsername.Location = new System.Drawing.Point(148, 31);
            this.rbUsername.Name = "rbUsername";
            this.rbUsername.Size = new System.Drawing.Size(73, 17);
            this.rbUsername.TabIndex = 0;
            this.rbUsername.TabStop = true;
            this.rbUsername.Text = "Username";
            this.inputTypeTips.SetToolTip(this.rbUsername, "Input takes one username per input.\r\n\r\nDo NOT include @ in front of the username." +
        "\r\n\r\nExamples:\r\ninstagram");
            this.rbUsername.UseVisualStyleBackColor = true;
            // 
            // rbUrl
            // 
            this.rbUrl.AutoSize = true;
            this.rbUrl.Location = new System.Drawing.Point(22, 31);
            this.rbUrl.Name = "rbUrl";
            this.rbUrl.Size = new System.Drawing.Size(38, 17);
            this.rbUrl.TabIndex = 0;
            this.rbUrl.TabStop = true;
            this.rbUrl.Text = "Url";
            this.inputTypeTips.SetToolTip(this.rbUrl, "Input takes one URL per input.\r\n\r\nExamples:\r\nhttps://www.instagram.com/p/BeWKx0JB" +
        "DTS/?taken-by=instagram\r\nhttps://www.instagram.com/p/BeWKx0JBDTS\r\nhttps://www.in" +
        "stagram.com/p/BeWKx0JBDTS/");
            this.rbUrl.UseVisualStyleBackColor = true;
            this.rbUrl.CheckedChanged += new System.EventHandler(this.rbUrl_CheckedChanged);
            // 
            // tabPageFilters
            // 
            this.tabPageFilters.Controls.Add(this.gbMediaFilters);
            this.tabPageFilters.Location = new System.Drawing.Point(4, 22);
            this.tabPageFilters.Name = "tabPageFilters";
            this.tabPageFilters.Size = new System.Drawing.Size(637, 497);
            this.tabPageFilters.TabIndex = 4;
            this.tabPageFilters.Text = "Filters";
            this.tabPageFilters.UseVisualStyleBackColor = true;
            // 
            // gbMediaFilters
            // 
            this.gbMediaFilters.Controls.Add(this.cbSkipTopPosts);
            this.gbMediaFilters.Controls.Add(this.txtSkipDescriptionStrings);
            this.gbMediaFilters.Controls.Add(this.label1);
            this.gbMediaFilters.Controls.Add(this.txtTotalDownloads);
            this.gbMediaFilters.Controls.Add(this.cbTotalDownloads);
            this.gbMediaFilters.Controls.Add(this.cbSkipMediaDescription);
            this.gbMediaFilters.Controls.Add(this.dtUploadTime);
            this.gbMediaFilters.Controls.Add(this.cbSkipMediaUploadDate);
            this.gbMediaFilters.Controls.Add(this.label9);
            this.gbMediaFilters.Controls.Add(this.txtSkipVideoViewsCount);
            this.gbMediaFilters.Controls.Add(this.label4);
            this.gbMediaFilters.Controls.Add(this.txtSkipMediaCommentsCount);
            this.gbMediaFilters.Controls.Add(this.label8);
            this.gbMediaFilters.Controls.Add(this.label7);
            this.gbMediaFilters.Controls.Add(this.label5);
            this.gbMediaFilters.Controls.Add(this.cbSkipVideoViewsMoreLess);
            this.gbMediaFilters.Controls.Add(this.cbSkipMediaUploadDateMoreLess);
            this.gbMediaFilters.Controls.Add(this.cbSkipVideoViews);
            this.gbMediaFilters.Controls.Add(this.cbSkipMediaCommentsMoreLess);
            this.gbMediaFilters.Controls.Add(this.cbSkipMediaComments);
            this.gbMediaFilters.Controls.Add(this.label3);
            this.gbMediaFilters.Controls.Add(this.txtSkipMediaLikesCount);
            this.gbMediaFilters.Controls.Add(this.label2);
            this.gbMediaFilters.Controls.Add(this.cbSkipMediaLikesMoreLess);
            this.gbMediaFilters.Controls.Add(this.cbSkipMediaLikes);
            this.gbMediaFilters.Controls.Add(this.cbSkipPhotos);
            this.gbMediaFilters.Controls.Add(this.cbSkipVideos);
            this.gbMediaFilters.Controls.Add(this.btnClearSkipDescriptionStrings);
            this.gbMediaFilters.Controls.Add(this.btnLoadDescriptionStrings);
            this.gbMediaFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMediaFilters.Location = new System.Drawing.Point(0, 0);
            this.gbMediaFilters.Name = "gbMediaFilters";
            this.gbMediaFilters.Size = new System.Drawing.Size(637, 497);
            this.gbMediaFilters.TabIndex = 0;
            this.gbMediaFilters.TabStop = false;
            this.gbMediaFilters.Text = "Media Filters";
            // 
            // cbSkipTopPosts
            // 
            this.cbSkipTopPosts.AutoSize = true;
            this.cbSkipTopPosts.Location = new System.Drawing.Point(21, 161);
            this.cbSkipTopPosts.Name = "cbSkipTopPosts";
            this.cbSkipTopPosts.Size = new System.Drawing.Size(198, 17);
            this.cbSkipTopPosts.TabIndex = 20;
            this.cbSkipTopPosts.Text = "Skip top posts of hashtags/locations";
            this.cbSkipTopPosts.UseVisualStyleBackColor = true;
            // 
            // txtSkipDescriptionStrings
            // 
            this.txtSkipDescriptionStrings.Location = new System.Drawing.Point(21, 43);
            this.txtSkipDescriptionStrings.Multiline = true;
            this.txtSkipDescriptionStrings.Name = "txtSkipDescriptionStrings";
            this.txtSkipDescriptionStrings.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSkipDescriptionStrings.Size = new System.Drawing.Size(468, 103);
            this.txtSkipDescriptionStrings.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "medias total";
            // 
            // txtTotalDownloads
            // 
            this.txtTotalDownloads.Location = new System.Drawing.Point(155, 340);
            this.txtTotalDownloads.Name = "txtTotalDownloads";
            this.txtTotalDownloads.Size = new System.Drawing.Size(100, 20);
            this.txtTotalDownloads.TabIndex = 17;
            // 
            // cbTotalDownloads
            // 
            this.cbTotalDownloads.AutoSize = true;
            this.cbTotalDownloads.Location = new System.Drawing.Point(21, 342);
            this.cbTotalDownloads.Name = "cbTotalDownloads";
            this.cbTotalDownloads.Size = new System.Drawing.Size(141, 17);
            this.cbTotalDownloads.TabIndex = 16;
            this.cbTotalDownloads.Text = "Stop after downloading: ";
            this.cbTotalDownloads.UseVisualStyleBackColor = true;
            // 
            // cbSkipMediaDescription
            // 
            this.cbSkipMediaDescription.AutoSize = true;
            this.cbSkipMediaDescription.Location = new System.Drawing.Point(21, 23);
            this.cbSkipMediaDescription.Name = "cbSkipMediaDescription";
            this.cbSkipMediaDescription.Size = new System.Drawing.Size(377, 17);
            this.cbSkipMediaDescription.TabIndex = 15;
            this.cbSkipMediaDescription.Text = "Skip media if description contains any of the following strings (one per line):";
            this.cbSkipMediaDescription.UseVisualStyleBackColor = true;
            // 
            // dtUploadTime
            // 
            this.dtUploadTime.Location = new System.Drawing.Point(251, 311);
            this.dtUploadTime.Name = "dtUploadTime";
            this.dtUploadTime.Size = new System.Drawing.Size(200, 20);
            this.dtUploadTime.TabIndex = 14;
            // 
            // cbSkipMediaUploadDate
            // 
            this.cbSkipMediaUploadDate.AutoSize = true;
            this.cbSkipMediaUploadDate.Location = new System.Drawing.Point(21, 314);
            this.cbSkipMediaUploadDate.Name = "cbSkipMediaUploadDate";
            this.cbSkipMediaUploadDate.Size = new System.Drawing.Size(92, 17);
            this.cbSkipMediaUploadDate.TabIndex = 13;
            this.cbSkipMediaUploadDate.Text = "Skip media(s) ";
            this.cbSkipMediaUploadDate.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(333, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "video views";
            // 
            // txtSkipVideoViewsCount
            // 
            this.txtSkipVideoViewsCount.Location = new System.Drawing.Point(251, 284);
            this.txtSkipVideoViewsCount.Name = "txtSkipVideoViewsCount";
            this.txtSkipVideoViewsCount.Size = new System.Drawing.Size(77, 20);
            this.txtSkipVideoViewsCount.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "comments";
            // 
            // txtSkipMediaCommentsCount
            // 
            this.txtSkipMediaCommentsCount.Location = new System.Drawing.Point(251, 256);
            this.txtSkipMediaCommentsCount.Name = "txtSkipMediaCommentsCount";
            this.txtSkipMediaCommentsCount.Size = new System.Drawing.Size(77, 20);
            this.txtSkipMediaCommentsCount.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(217, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "than";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(217, 315);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "than";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(217, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "than";
            // 
            // cbSkipVideoViewsMoreLess
            // 
            this.cbSkipVideoViewsMoreLess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkipVideoViewsMoreLess.FormattingEnabled = true;
            this.cbSkipVideoViewsMoreLess.Items.AddRange(new object[] {
            "more",
            "less"});
            this.cbSkipVideoViewsMoreLess.Location = new System.Drawing.Point(132, 284);
            this.cbSkipVideoViewsMoreLess.Name = "cbSkipVideoViewsMoreLess";
            this.cbSkipVideoViewsMoreLess.Size = new System.Drawing.Size(79, 21);
            this.cbSkipVideoViewsMoreLess.TabIndex = 9;
            // 
            // cbSkipMediaUploadDateMoreLess
            // 
            this.cbSkipMediaUploadDateMoreLess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkipMediaUploadDateMoreLess.FormattingEnabled = true;
            this.cbSkipMediaUploadDateMoreLess.Items.AddRange(new object[] {
            "older",
            "newer"});
            this.cbSkipMediaUploadDateMoreLess.Location = new System.Drawing.Point(132, 312);
            this.cbSkipMediaUploadDateMoreLess.Name = "cbSkipMediaUploadDateMoreLess";
            this.cbSkipMediaUploadDateMoreLess.Size = new System.Drawing.Size(79, 21);
            this.cbSkipMediaUploadDateMoreLess.TabIndex = 9;
            // 
            // cbSkipVideoViews
            // 
            this.cbSkipVideoViews.AutoSize = true;
            this.cbSkipVideoViews.Location = new System.Drawing.Point(21, 286);
            this.cbSkipVideoViews.Name = "cbSkipVideoViews";
            this.cbSkipVideoViews.Size = new System.Drawing.Size(114, 17);
            this.cbSkipVideoViews.TabIndex = 8;
            this.cbSkipVideoViews.Text = "Skip media(s) with ";
            this.cbSkipVideoViews.UseVisualStyleBackColor = true;
            // 
            // cbSkipMediaCommentsMoreLess
            // 
            this.cbSkipMediaCommentsMoreLess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkipMediaCommentsMoreLess.FormattingEnabled = true;
            this.cbSkipMediaCommentsMoreLess.Items.AddRange(new object[] {
            "more",
            "less"});
            this.cbSkipMediaCommentsMoreLess.Location = new System.Drawing.Point(132, 256);
            this.cbSkipMediaCommentsMoreLess.Name = "cbSkipMediaCommentsMoreLess";
            this.cbSkipMediaCommentsMoreLess.Size = new System.Drawing.Size(79, 21);
            this.cbSkipMediaCommentsMoreLess.TabIndex = 9;
            // 
            // cbSkipMediaComments
            // 
            this.cbSkipMediaComments.AutoSize = true;
            this.cbSkipMediaComments.Location = new System.Drawing.Point(21, 258);
            this.cbSkipMediaComments.Name = "cbSkipMediaComments";
            this.cbSkipMediaComments.Size = new System.Drawing.Size(114, 17);
            this.cbSkipMediaComments.TabIndex = 8;
            this.cbSkipMediaComments.Text = "Skip media(s) with ";
            this.cbSkipMediaComments.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "likes";
            // 
            // txtSkipMediaLikesCount
            // 
            this.txtSkipMediaLikesCount.Location = new System.Drawing.Point(250, 228);
            this.txtSkipMediaLikesCount.Name = "txtSkipMediaLikesCount";
            this.txtSkipMediaLikesCount.Size = new System.Drawing.Size(77, 20);
            this.txtSkipMediaLikesCount.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "than";
            // 
            // cbSkipMediaLikesMoreLess
            // 
            this.cbSkipMediaLikesMoreLess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkipMediaLikesMoreLess.FormattingEnabled = true;
            this.cbSkipMediaLikesMoreLess.Items.AddRange(new object[] {
            "more",
            "less"});
            this.cbSkipMediaLikesMoreLess.Location = new System.Drawing.Point(132, 228);
            this.cbSkipMediaLikesMoreLess.Name = "cbSkipMediaLikesMoreLess";
            this.cbSkipMediaLikesMoreLess.Size = new System.Drawing.Size(79, 21);
            this.cbSkipMediaLikesMoreLess.TabIndex = 4;
            // 
            // cbSkipMediaLikes
            // 
            this.cbSkipMediaLikes.AutoSize = true;
            this.cbSkipMediaLikes.Location = new System.Drawing.Point(21, 230);
            this.cbSkipMediaLikes.Name = "cbSkipMediaLikes";
            this.cbSkipMediaLikes.Size = new System.Drawing.Size(114, 17);
            this.cbSkipMediaLikes.TabIndex = 3;
            this.cbSkipMediaLikes.Text = "Skip media(s) with ";
            this.cbSkipMediaLikes.UseVisualStyleBackColor = true;
            // 
            // cbSkipPhotos
            // 
            this.cbSkipPhotos.AutoSize = true;
            this.cbSkipPhotos.Location = new System.Drawing.Point(21, 207);
            this.cbSkipPhotos.Name = "cbSkipPhotos";
            this.cbSkipPhotos.Size = new System.Drawing.Size(88, 17);
            this.cbSkipPhotos.TabIndex = 3;
            this.cbSkipPhotos.Text = "Skip photo(s)";
            this.cbSkipPhotos.UseVisualStyleBackColor = true;
            this.cbSkipPhotos.CheckedChanged += new System.EventHandler(this.cbSkipPhotos_CheckedChanged);
            // 
            // cbSkipVideos
            // 
            this.cbSkipVideos.AutoSize = true;
            this.cbSkipVideos.Location = new System.Drawing.Point(21, 184);
            this.cbSkipVideos.Name = "cbSkipVideos";
            this.cbSkipVideos.Size = new System.Drawing.Size(87, 17);
            this.cbSkipVideos.TabIndex = 3;
            this.cbSkipVideos.Text = "Skip video(s)";
            this.cbSkipVideos.UseVisualStyleBackColor = true;
            this.cbSkipVideos.CheckedChanged += new System.EventHandler(this.cbSkipVideos_CheckedChanged);
            // 
            // btnClearSkipDescriptionStrings
            // 
            this.btnClearSkipDescriptionStrings.Location = new System.Drawing.Point(495, 43);
            this.btnClearSkipDescriptionStrings.Name = "btnClearSkipDescriptionStrings";
            this.btnClearSkipDescriptionStrings.Size = new System.Drawing.Size(75, 23);
            this.btnClearSkipDescriptionStrings.TabIndex = 2;
            this.btnClearSkipDescriptionStrings.Text = "Clear";
            this.btnClearSkipDescriptionStrings.UseVisualStyleBackColor = true;
            // 
            // btnLoadDescriptionStrings
            // 
            this.btnLoadDescriptionStrings.Location = new System.Drawing.Point(495, 123);
            this.btnLoadDescriptionStrings.Name = "btnLoadDescriptionStrings";
            this.btnLoadDescriptionStrings.Size = new System.Drawing.Size(75, 23);
            this.btnLoadDescriptionStrings.TabIndex = 2;
            this.btnLoadDescriptionStrings.Text = "Load";
            this.btnLoadDescriptionStrings.UseVisualStyleBackColor = true;
            this.btnLoadDescriptionStrings.Click += new System.EventHandler(this.btnLoadDescriptionStrings_Click);
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.gbAccountSettings);
            this.tabPageSettings.Controls.Add(this.gbDownloadSettings);
            this.tabPageSettings.Controls.Add(this.gbWebSettings);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Size = new System.Drawing.Size(637, 497);
            this.tabPageSettings.TabIndex = 2;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // gbAccountSettings
            // 
            this.gbAccountSettings.Controls.Add(this.btnAccountLogout);
            this.gbAccountSettings.Controls.Add(this.cbHidePassword);
            this.gbAccountSettings.Controls.Add(this.btnAccountLogin);
            this.gbAccountSettings.Controls.Add(this.lblAccountLoginStatus);
            this.gbAccountSettings.Controls.Add(this.lblAccountPassword);
            this.gbAccountSettings.Controls.Add(this.lblAccountUsername);
            this.gbAccountSettings.Controls.Add(this.txtAccountPassword);
            this.gbAccountSettings.Controls.Add(this.txtAccountUsername);
            this.gbAccountSettings.Location = new System.Drawing.Point(14, 377);
            this.gbAccountSettings.Name = "gbAccountSettings";
            this.gbAccountSettings.Size = new System.Drawing.Size(584, 80);
            this.gbAccountSettings.TabIndex = 2;
            this.gbAccountSettings.TabStop = false;
            this.gbAccountSettings.Text = "Account Settings";
            // 
            // btnAccountLogout
            // 
            this.btnAccountLogout.Enabled = false;
            this.btnAccountLogout.Location = new System.Drawing.Point(492, 48);
            this.btnAccountLogout.Name = "btnAccountLogout";
            this.btnAccountLogout.Size = new System.Drawing.Size(75, 23);
            this.btnAccountLogout.TabIndex = 4;
            this.btnAccountLogout.Text = "Logout";
            this.btnAccountLogout.UseVisualStyleBackColor = true;
            this.btnAccountLogout.Click += new System.EventHandler(this.btnAccountLogout_Click);
            // 
            // cbHidePassword
            // 
            this.cbHidePassword.AutoSize = true;
            this.cbHidePassword.Location = new System.Drawing.Point(406, 13);
            this.cbHidePassword.Name = "cbHidePassword";
            this.cbHidePassword.Size = new System.Drawing.Size(48, 17);
            this.cbHidePassword.TabIndex = 3;
            this.cbHidePassword.TabStop = false;
            this.cbHidePassword.Text = "Hide";
            this.cbHidePassword.UseVisualStyleBackColor = true;
            this.cbHidePassword.CheckedChanged += new System.EventHandler(this.cbHidePassword_CheckedChanged);
            // 
            // btnAccountLogin
            // 
            this.btnAccountLogin.Location = new System.Drawing.Point(492, 19);
            this.btnAccountLogin.Name = "btnAccountLogin";
            this.btnAccountLogin.Size = new System.Drawing.Size(75, 23);
            this.btnAccountLogin.TabIndex = 2;
            this.btnAccountLogin.Text = "Login";
            this.btnAccountLogin.UseVisualStyleBackColor = true;
            this.btnAccountLogin.Click += new System.EventHandler(this.btnAccountLogin_Click);
            // 
            // lblAccountLoginStatus
            // 
            this.lblAccountLoginStatus.AutoSize = true;
            this.lblAccountLoginStatus.Location = new System.Drawing.Point(14, 58);
            this.lblAccountLoginStatus.Name = "lblAccountLoginStatus";
            this.lblAccountLoginStatus.Size = new System.Drawing.Size(40, 13);
            this.lblAccountLoginStatus.TabIndex = 1;
            this.lblAccountLoginStatus.Text = "Status:";
            // 
            // lblAccountPassword
            // 
            this.lblAccountPassword.AutoSize = true;
            this.lblAccountPassword.Location = new System.Drawing.Point(257, 17);
            this.lblAccountPassword.Name = "lblAccountPassword";
            this.lblAccountPassword.Size = new System.Drawing.Size(56, 13);
            this.lblAccountPassword.TabIndex = 1;
            this.lblAccountPassword.Text = "Password:";
            // 
            // lblAccountUsername
            // 
            this.lblAccountUsername.AutoSize = true;
            this.lblAccountUsername.Location = new System.Drawing.Point(14, 17);
            this.lblAccountUsername.Name = "lblAccountUsername";
            this.lblAccountUsername.Size = new System.Drawing.Size(58, 13);
            this.lblAccountUsername.TabIndex = 1;
            this.lblAccountUsername.Text = "Username:";
            // 
            // txtAccountPassword
            // 
            this.txtAccountPassword.Location = new System.Drawing.Point(260, 33);
            this.txtAccountPassword.Name = "txtAccountPassword";
            this.txtAccountPassword.Size = new System.Drawing.Size(194, 20);
            this.txtAccountPassword.TabIndex = 1;
            // 
            // txtAccountUsername
            // 
            this.txtAccountUsername.Location = new System.Drawing.Point(17, 33);
            this.txtAccountUsername.Name = "txtAccountUsername";
            this.txtAccountUsername.Size = new System.Drawing.Size(194, 20);
            this.txtAccountUsername.TabIndex = 0;
            // 
            // gbDownloadSettings
            // 
            this.gbDownloadSettings.Controls.Add(this.txtDelimiter);
            this.gbDownloadSettings.Controls.Add(this.cbSaveStats);
            this.gbDownloadSettings.Controls.Add(this.cbCreateNewFolder);
            this.gbDownloadSettings.Controls.Add(this.btnBrowseDownloadDirectory);
            this.gbDownloadSettings.Controls.Add(this.txtDownloadFolder);
            this.gbDownloadSettings.Controls.Add(this.lblDownloadFolder);
            this.gbDownloadSettings.Location = new System.Drawing.Point(14, 237);
            this.gbDownloadSettings.Name = "gbDownloadSettings";
            this.gbDownloadSettings.Size = new System.Drawing.Size(584, 134);
            this.gbDownloadSettings.TabIndex = 1;
            this.gbDownloadSettings.TabStop = false;
            this.gbDownloadSettings.Text = "Download Settings";
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.Location = new System.Drawing.Point(323, 102);
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(32, 20);
            this.txtDelimiter.TabIndex = 4;
            // 
            // cbSaveStats
            // 
            this.cbSaveStats.AutoSize = true;
            this.cbSaveStats.Location = new System.Drawing.Point(17, 104);
            this.cbSaveStats.Name = "cbSaveStats";
            this.cbSaveStats.Size = new System.Drawing.Size(311, 17);
            this.cbSaveStats.TabIndex = 3;
            this.cbSaveStats.TabStop = false;
            this.cbSaveStats.Text = "Save stats to file while downloading (.txt/.csv) with delimiter: ";
            this.cbSaveStats.UseVisualStyleBackColor = true;
            // 
            // cbCreateNewFolder
            // 
            this.cbCreateNewFolder.AutoSize = true;
            this.cbCreateNewFolder.Location = new System.Drawing.Point(17, 81);
            this.cbCreateNewFolder.Name = "cbCreateNewFolder";
            this.cbCreateNewFolder.Size = new System.Drawing.Size(279, 17);
            this.cbCreateNewFolder.TabIndex = 3;
            this.cbCreateNewFolder.TabStop = false;
            this.cbCreateNewFolder.Text = "Create a new folder for each user, hashtag or location";
            this.cbCreateNewFolder.UseVisualStyleBackColor = true;
            // 
            // btnBrowseDownloadDirectory
            // 
            this.btnBrowseDownloadDirectory.Location = new System.Drawing.Point(534, 46);
            this.btnBrowseDownloadDirectory.Name = "btnBrowseDownloadDirectory";
            this.btnBrowseDownloadDirectory.Size = new System.Drawing.Size(33, 20);
            this.btnBrowseDownloadDirectory.TabIndex = 4;
            this.btnBrowseDownloadDirectory.Text = "...";
            this.btnBrowseDownloadDirectory.UseVisualStyleBackColor = true;
            this.btnBrowseDownloadDirectory.Click += new System.EventHandler(this.btnBrowseDownloadDirectory_Click);
            // 
            // txtDownloadFolder
            // 
            this.txtDownloadFolder.Enabled = false;
            this.txtDownloadFolder.Location = new System.Drawing.Point(17, 46);
            this.txtDownloadFolder.Name = "txtDownloadFolder";
            this.txtDownloadFolder.Size = new System.Drawing.Size(511, 20);
            this.txtDownloadFolder.TabIndex = 4;
            this.txtDownloadFolder.TabStop = false;
            // 
            // lblDownloadFolder
            // 
            this.lblDownloadFolder.AutoSize = true;
            this.lblDownloadFolder.Location = new System.Drawing.Point(14, 30);
            this.lblDownloadFolder.Name = "lblDownloadFolder";
            this.lblDownloadFolder.Size = new System.Drawing.Size(87, 13);
            this.lblDownloadFolder.TabIndex = 1;
            this.lblDownloadFolder.Text = "Download folder:";
            // 
            // gbWebSettings
            // 
            this.gbWebSettings.Controls.Add(this.btnRandomizeUserAgent);
            this.gbWebSettings.Controls.Add(this.lblProxy);
            this.gbWebSettings.Controls.Add(this.lblThreads);
            this.gbWebSettings.Controls.Add(this.lblRequestTimeout);
            this.gbWebSettings.Controls.Add(this.lblUserAgent);
            this.gbWebSettings.Controls.Add(this.txtProxy);
            this.gbWebSettings.Controls.Add(this.txtThreads);
            this.gbWebSettings.Controls.Add(this.txtRequestTimeout);
            this.gbWebSettings.Controls.Add(this.txtUserAgent);
            this.gbWebSettings.Location = new System.Drawing.Point(14, 15);
            this.gbWebSettings.Name = "gbWebSettings";
            this.gbWebSettings.Size = new System.Drawing.Size(584, 216);
            this.gbWebSettings.TabIndex = 0;
            this.gbWebSettings.TabStop = false;
            this.gbWebSettings.Text = "Web Settings";
            // 
            // btnRandomizeUserAgent
            // 
            this.btnRandomizeUserAgent.Location = new System.Drawing.Point(534, 41);
            this.btnRandomizeUserAgent.Name = "btnRandomizeUserAgent";
            this.btnRandomizeUserAgent.Size = new System.Drawing.Size(33, 20);
            this.btnRandomizeUserAgent.TabIndex = 2;
            this.btnRandomizeUserAgent.TabStop = false;
            this.btnRandomizeUserAgent.Text = "R";
            this.btnRandomizeUserAgent.UseVisualStyleBackColor = true;
            this.btnRandomizeUserAgent.Click += new System.EventHandler(this.btnRandomizeUserAgent_Click);
            // 
            // lblProxy
            // 
            this.lblProxy.AutoSize = true;
            this.lblProxy.Location = new System.Drawing.Point(14, 163);
            this.lblProxy.Name = "lblProxy";
            this.lblProxy.Size = new System.Drawing.Size(36, 13);
            this.lblProxy.TabIndex = 1;
            this.lblProxy.Text = "Proxy:";
            // 
            // lblThreads
            // 
            this.lblThreads.AutoSize = true;
            this.lblThreads.Location = new System.Drawing.Point(14, 117);
            this.lblThreads.Name = "lblThreads";
            this.lblThreads.Size = new System.Drawing.Size(150, 13);
            this.lblThreads.TabIndex = 1;
            this.lblThreads.Text = "Threads (temporarily disabled):";
            // 
            // lblRequestTimeout
            // 
            this.lblRequestTimeout.AutoSize = true;
            this.lblRequestTimeout.Location = new System.Drawing.Point(14, 70);
            this.lblRequestTimeout.Name = "lblRequestTimeout";
            this.lblRequestTimeout.Size = new System.Drawing.Size(87, 13);
            this.lblRequestTimeout.TabIndex = 1;
            this.lblRequestTimeout.Text = "Request timeout:";
            // 
            // lblUserAgent
            // 
            this.lblUserAgent.AutoSize = true;
            this.lblUserAgent.Location = new System.Drawing.Point(14, 25);
            this.lblUserAgent.Name = "lblUserAgent";
            this.lblUserAgent.Size = new System.Drawing.Size(63, 13);
            this.lblUserAgent.TabIndex = 1;
            this.lblUserAgent.Text = "User Agent:";
            // 
            // txtProxy
            // 
            this.txtProxy.Location = new System.Drawing.Point(17, 179);
            this.txtProxy.Name = "txtProxy";
            this.txtProxy.Size = new System.Drawing.Size(550, 20);
            this.txtProxy.TabIndex = 3;
            // 
            // txtThreads
            // 
            this.txtThreads.Enabled = false;
            this.txtThreads.Location = new System.Drawing.Point(17, 133);
            this.txtThreads.Name = "txtThreads";
            this.txtThreads.Size = new System.Drawing.Size(550, 20);
            this.txtThreads.TabIndex = 2;
            // 
            // txtRequestTimeout
            // 
            this.txtRequestTimeout.Location = new System.Drawing.Point(17, 86);
            this.txtRequestTimeout.Name = "txtRequestTimeout";
            this.txtRequestTimeout.Size = new System.Drawing.Size(550, 20);
            this.txtRequestTimeout.TabIndex = 1;
            // 
            // txtUserAgent
            // 
            this.txtUserAgent.Location = new System.Drawing.Point(17, 41);
            this.txtUserAgent.Name = "txtUserAgent";
            this.txtUserAgent.Size = new System.Drawing.Size(511, 20);
            this.txtUserAgent.TabIndex = 0;
            // 
            // tabPageLogs
            // 
            this.tabPageLogs.Controls.Add(this.gbLogs);
            this.tabPageLogs.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogs.Name = "tabPageLogs";
            this.tabPageLogs.Size = new System.Drawing.Size(637, 497);
            this.tabPageLogs.TabIndex = 3;
            this.tabPageLogs.Text = "Logs";
            this.tabPageLogs.UseVisualStyleBackColor = true;
            // 
            // gbLogs
            // 
            this.gbLogs.Controls.Add(this.txtLogs);
            this.gbLogs.Controls.Add(this.btnClearLogs);
            this.gbLogs.Controls.Add(this.btnExportLogs);
            this.gbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLogs.Location = new System.Drawing.Point(0, 0);
            this.gbLogs.Name = "gbLogs";
            this.gbLogs.Size = new System.Drawing.Size(637, 497);
            this.gbLogs.TabIndex = 2;
            this.gbLogs.TabStop = false;
            this.gbLogs.Text = "Logs";
            // 
            // txtLogs
            // 
            this.txtLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogs.Location = new System.Drawing.Point(3, 16);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ReadOnly = true;
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogs.Size = new System.Drawing.Size(631, 432);
            this.txtLogs.TabIndex = 0;
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClearLogs.Location = new System.Drawing.Point(3, 448);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(631, 23);
            this.btnClearLogs.TabIndex = 1;
            this.btnClearLogs.Text = "Clear";
            this.btnClearLogs.UseVisualStyleBackColor = true;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // btnExportLogs
            // 
            this.btnExportLogs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExportLogs.Location = new System.Drawing.Point(3, 471);
            this.btnExportLogs.Name = "btnExportLogs";
            this.btnExportLogs.Size = new System.Drawing.Size(631, 23);
            this.btnExportLogs.TabIndex = 1;
            this.btnExportLogs.Text = "Export";
            this.btnExportLogs.UseVisualStyleBackColor = true;
            this.btnExportLogs.Click += new System.EventHandler(this.btnExportLogs_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.helpSupportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(645, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetAllFilterToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.filterToolStripMenuItem.Text = "Filter";
            // 
            // resetAllFilterToolStripMenuItem
            // 
            this.resetAllFilterToolStripMenuItem.Name = "resetAllFilterToolStripMenuItem";
            this.resetAllFilterToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.resetAllFilterToolStripMenuItem.Text = "Reset All Filters";
            this.resetAllFilterToolStripMenuItem.Click += new System.EventHandler(this.resetAllFilterToolStripMenuItem_Click);
            // 
            // helpSupportToolStripMenuItem
            // 
            this.helpSupportToolStripMenuItem.Name = "helpSupportToolStripMenuItem";
            this.helpSupportToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.helpSupportToolStripMenuItem.Text = "Help && Support";
            this.helpSupportToolStripMenuItem.Click += new System.EventHandler(this.helpSupportToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 547);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instagram Downloader V2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabMain.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.gbChangelog.ResumeLayout(false);
            this.gbChangelog.PerformLayout();
            this.gbCreditsAndVersion.ResumeLayout(false);
            this.gbCredits.ResumeLayout(false);
            this.gbCredits.PerformLayout();
            this.gbVersion.ResumeLayout(false);
            this.gbVersion.PerformLayout();
            this.tabPageDownloader.ResumeLayout(false);
            this.gbInputParams.ResumeLayout(false);
            this.contextMenuStripForListBoxInput.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalDownloads)).EndInit();
            this.gbDownload.ResumeLayout(false);
            this.gbInputMethod.ResumeLayout(false);
            this.gbInputMethod.PerformLayout();
            this.tabPageFilters.ResumeLayout(false);
            this.gbMediaFilters.ResumeLayout(false);
            this.gbMediaFilters.PerformLayout();
            this.tabPageSettings.ResumeLayout(false);
            this.gbAccountSettings.ResumeLayout(false);
            this.gbAccountSettings.PerformLayout();
            this.gbDownloadSettings.ResumeLayout(false);
            this.gbDownloadSettings.PerformLayout();
            this.gbWebSettings.ResumeLayout(false);
            this.gbWebSettings.PerformLayout();
            this.tabPageLogs.ResumeLayout(false);
            this.gbLogs.ResumeLayout(false);
            this.gbLogs.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageDownloader;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbChangelog;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TabPage tabPageLogs;
        private System.Windows.Forms.GroupBox gbVersion;
        private System.Windows.Forms.GroupBox gbCredits;
        private System.Windows.Forms.GroupBox gbLogs;
        private System.Windows.Forms.GroupBox gbInputMethod;
        private System.Windows.Forms.RadioButton rbUrl;
        private System.Windows.Forms.RadioButton rbUsername;
        private System.Windows.Forms.RadioButton rbLocation;
        private System.Windows.Forms.RadioButton rbHashtag;
        private System.Windows.Forms.GroupBox gbInputParams;
        private System.Windows.Forms.GroupBox gbWebSettings;
        private System.Windows.Forms.Button btnRandomizeUserAgent;
        private System.Windows.Forms.Label lblUserAgent;
        private System.Windows.Forms.TextBox txtThreads;
        private System.Windows.Forms.TextBox txtRequestTimeout;
        private System.Windows.Forms.TextBox txtUserAgent;
        private System.Windows.Forms.Label lblThreads;
        private System.Windows.Forms.Label lblRequestTimeout;
        private System.Windows.Forms.GroupBox gbDownloadSettings;
        private System.Windows.Forms.CheckBox cbSaveStats;
        private System.Windows.Forms.CheckBox cbCreateNewFolder;
        private System.Windows.Forms.Button btnBrowseDownloadDirectory;
        private System.Windows.Forms.TextBox txtDownloadFolder;
        private System.Windows.Forms.Label lblDownloadFolder;
        private System.Windows.Forms.TextBox txtDelimiter;
        private System.Windows.Forms.GroupBox gbAccountSettings;
        private System.Windows.Forms.Label lblProxy;
        private System.Windows.Forms.TextBox txtProxy;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.Button btnExportLogs;
        private System.Windows.Forms.Button btnClearAllInput;
        private System.Windows.Forms.Button btnStopDownloading;
        private System.Windows.Forms.Button btnStartDownloading;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.Button btnAddInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.GroupBox gbDownload;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripForListBoxInput;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.TabPage tabPageFilters;
        private System.Windows.Forms.GroupBox gbMediaFilters;
        private System.Windows.Forms.Button btnClearSkipDescriptionStrings;
        private System.Windows.Forms.CheckBox cbSkipVideos;
        private System.Windows.Forms.CheckBox cbSkipPhotos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSkipMediaCommentsCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbSkipMediaCommentsMoreLess;
        private System.Windows.Forms.CheckBox cbSkipMediaComments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSkipMediaLikesCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSkipMediaLikesMoreLess;
        private System.Windows.Forms.CheckBox cbSkipMediaLikes;
        private System.Windows.Forms.DateTimePicker dtUploadTime;
        private System.Windows.Forms.CheckBox cbSkipMediaUploadDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSkipMediaUploadDateMoreLess;
        private System.Windows.Forms.ListView lvInput;
        private System.Windows.Forms.ColumnHeader lvInputType;
        private System.Windows.Forms.ColumnHeader lvInputData;
        private System.Windows.Forms.CheckBox cbSkipMediaDescription;
        private System.Windows.Forms.Button btnLoadInputFromFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalDownloads;
        private System.Windows.Forms.CheckBox cbTotalDownloads;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLoadDescriptionStrings;
        private System.Windows.Forms.TextBox txtSkipDescriptionStrings;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetAllFilterToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbSkipTopPosts;
        private System.Windows.Forms.TextBox txtAccountPassword;
        private System.Windows.Forms.TextBox txtAccountUsername;
        private System.Windows.Forms.Button btnAccountLogin;
        private System.Windows.Forms.Label lblAccountLoginStatus;
        private System.Windows.Forms.Label lblAccountPassword;
        private System.Windows.Forms.Label lblAccountUsername;
        private System.Windows.Forms.CheckBox cbHidePassword;
        private System.Windows.Forms.ColumnHeader lvInputDownloads;
        private System.Windows.Forms.NumericUpDown numTotalDownloads;
        private System.Windows.Forms.Label lblTotalDownloads;
        private System.Windows.Forms.ToolStripMenuItem editSelectedRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSkipVideoViewsCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbSkipVideoViewsMoreLess;
        private System.Windows.Forms.CheckBox cbSkipVideoViews;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exportSelectedRowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAllToolStripMenuItem;
        private System.Windows.Forms.Button btnAccountLogout;
        private System.Windows.Forms.ToolTip inputTypeTips;
        private System.Windows.Forms.TextBox txtChangelog;
        private System.Windows.Forms.Label lblLatestVersion;
        private System.Windows.Forms.Label lblCurrentVersion;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox gbCreditsAndVersion;
        private System.Windows.Forms.RadioButton rbUserId;
        private System.Windows.Forms.RadioButton rbMediaId;
        private System.Windows.Forms.ToolStripMenuItem helpSupportToolStripMenuItem;
    }
}

