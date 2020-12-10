
namespace ThemeEditor
{
    partial class ThemeEditorView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemeEditorView));
            this.lstColorRecords = new System.Windows.Forms.ListBox();
            this.bsColorRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cboTheme = new System.Windows.Forms.ComboBox();
            this.bsThemeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblThemeCaption = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.bsCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblCategoryCaption = new System.Windows.Forms.Label();
            this.lblColorRecordsCaption = new System.Windows.Forms.Label();
            this.lblForegroundCaption = new System.Windows.Forms.Label();
            this.lblBackgroundCaption = new System.Windows.Forms.Label();
            this.cmdSaveColor = new System.Windows.Forms.Button();
            this.lblNotesColorRecords = new System.Windows.Forms.Label();
            this.lblNotes1 = new System.Windows.Forms.Label();
            this.cmdForeground = new System.Windows.Forms.Button();
            this.cmdBackground = new System.Windows.Forms.Button();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            this.lblFG = new System.Windows.Forms.Label();
            this.lblBG = new System.Windows.Forms.Label();
            this.lblColorRecordName = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusBarStatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBarErrorMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBarProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusBarActionIcon = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBarDirtyMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbFileNew = new System.Windows.Forms.ToolStripButton();
            this.tsbFileOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbFileSave = new System.Windows.Forms.ToolStripButton();
            this.tsbFilePrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEditProperties = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbViewPreviousMonth = new System.Windows.Forms.ToolStripButton();
            this.tsbViewPreviousWeek = new System.Windows.Forms.ToolStripButton();
            this.tsbViewNextWeek = new System.Windows.Forms.ToolStripButton();
            this.tsbViewNextMonth = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFilePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuEditProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.lblEditionCaption = new System.Windows.Forms.Label();
            this.lblYearVersionCaption = new System.Windows.Forms.Label();
            this.cboEdition = new System.Windows.Forms.ComboBox();
            this.bsEditionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cboYearVersion = new System.Windows.Forms.ComboBox();
            this.bsVersionYearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmdBackupTheme = new System.Windows.Forms.Button();
            this.cmdResetTheme = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.trkForeground = new System.Windows.Forms.TrackBar();
            this.trkBackground = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.bsColorRecordBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsThemeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCategoryBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsEditionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVersionYearBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkForeground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // lstColorRecords
            // 
            this.lstColorRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstColorRecords.DataSource = this.bsColorRecordBindingSource;
            this.lstColorRecords.DisplayMember = "Name";
            this.lstColorRecords.FormattingEnabled = true;
            this.lstColorRecords.Location = new System.Drawing.Point(12, 187);
            this.lstColorRecords.Name = "lstColorRecords";
            this.lstColorRecords.Size = new System.Drawing.Size(311, 225);
            this.lstColorRecords.TabIndex = 0;
            this.lstColorRecords.SelectedValueChanged += new System.EventHandler(this.lstRecords_SelectedValueChanged);
            this.lstColorRecords.Validating += new System.ComponentModel.CancelEventHandler(this.lstColorRecords_Validating);
            // 
            // bsColorRecordBindingSource
            // 
            this.bsColorRecordBindingSource.DataSource = typeof(ThemeEditorLibrary.ColorRecord);
            this.bsColorRecordBindingSource.CurrentChanged += new System.EventHandler(this.bsColorRecordBindingSource_CurrentChanged);
            // 
            // cboTheme
            // 
            this.cboTheme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTheme.DataSource = this.bsThemeBindingSource;
            this.cboTheme.DisplayMember = "Name";
            this.cboTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTheme.FormattingEnabled = true;
            this.cboTheme.Location = new System.Drawing.Point(76, 106);
            this.cboTheme.Name = "cboTheme";
            this.cboTheme.Size = new System.Drawing.Size(247, 21);
            this.cboTheme.TabIndex = 1;
            this.cboTheme.SelectedValueChanged += new System.EventHandler(this.cboTheme_SelectedValueChanged);
            this.cboTheme.Validating += new System.ComponentModel.CancelEventHandler(this.cboTheme_Validating);
            // 
            // bsThemeBindingSource
            // 
            this.bsThemeBindingSource.DataSource = typeof(ThemeEditorLibrary.ThemeInfo);
            this.bsThemeBindingSource.PositionChanged += new System.EventHandler(this.bsThemeBindingSource_PositionChanged);
            // 
            // lblThemeCaption
            // 
            this.lblThemeCaption.AutoSize = true;
            this.lblThemeCaption.Location = new System.Drawing.Point(16, 109);
            this.lblThemeCaption.Name = "lblThemeCaption";
            this.lblThemeCaption.Size = new System.Drawing.Size(43, 13);
            this.lblThemeCaption.TabIndex = 2;
            this.lblThemeCaption.Text = "Theme:";
            // 
            // cboCategory
            // 
            this.cboCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCategory.DataSource = this.bsCategoryBindingSource;
            this.cboCategory.DisplayMember = "Name";
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(76, 133);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(247, 21);
            this.cboCategory.TabIndex = 1;
            this.cboCategory.SelectedValueChanged += new System.EventHandler(this.cboCategory_SelectedValueChanged);
            this.cboCategory.Validating += new System.ComponentModel.CancelEventHandler(this.cboCategory_Validating);
            // 
            // bsCategoryBindingSource
            // 
            this.bsCategoryBindingSource.DataSource = typeof(ThemeEditorLibrary.ThemeCategory);
            this.bsCategoryBindingSource.PositionChanged += new System.EventHandler(this.bsCategoryBindingSource_PositionChanged);
            // 
            // lblCategoryCaption
            // 
            this.lblCategoryCaption.AutoSize = true;
            this.lblCategoryCaption.Location = new System.Drawing.Point(17, 136);
            this.lblCategoryCaption.Name = "lblCategoryCaption";
            this.lblCategoryCaption.Size = new System.Drawing.Size(52, 13);
            this.lblCategoryCaption.TabIndex = 2;
            this.lblCategoryCaption.Text = "Category:";
            // 
            // lblColorRecordsCaption
            // 
            this.lblColorRecordsCaption.AutoSize = true;
            this.lblColorRecordsCaption.Location = new System.Drawing.Point(12, 166);
            this.lblColorRecordsCaption.Name = "lblColorRecordsCaption";
            this.lblColorRecordsCaption.Size = new System.Drawing.Size(77, 13);
            this.lblColorRecordsCaption.TabIndex = 3;
            this.lblColorRecordsCaption.Text = "Color Records:";
            // 
            // lblForegroundCaption
            // 
            this.lblForegroundCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblForegroundCaption.AutoSize = true;
            this.lblForegroundCaption.Location = new System.Drawing.Point(329, 208);
            this.lblForegroundCaption.Name = "lblForegroundCaption";
            this.lblForegroundCaption.Size = new System.Drawing.Size(64, 13);
            this.lblForegroundCaption.TabIndex = 4;
            this.lblForegroundCaption.Text = "Foreground:";
            // 
            // lblBackgroundCaption
            // 
            this.lblBackgroundCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBackgroundCaption.AutoSize = true;
            this.lblBackgroundCaption.Location = new System.Drawing.Point(329, 269);
            this.lblBackgroundCaption.Name = "lblBackgroundCaption";
            this.lblBackgroundCaption.Size = new System.Drawing.Size(68, 13);
            this.lblBackgroundCaption.TabIndex = 4;
            this.lblBackgroundCaption.Text = "Background:";
            // 
            // cmdSaveColor
            // 
            this.cmdSaveColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSaveColor.Enabled = false;
            this.cmdSaveColor.Location = new System.Drawing.Point(332, 333);
            this.cmdSaveColor.Name = "cmdSaveColor";
            this.cmdSaveColor.Size = new System.Drawing.Size(91, 23);
            this.cmdSaveColor.TabIndex = 11;
            this.cmdSaveColor.Text = "Save Color";
            this.toolTip1.SetToolTip(this.cmdSaveColor, "Save Color to Record");
            this.cmdSaveColor.UseVisualStyleBackColor = true;
            this.cmdSaveColor.Click += new System.EventHandler(this.cmdSaveColor_Click);
            // 
            // lblNotesColorRecords
            // 
            this.lblNotesColorRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotesColorRecords.Location = new System.Drawing.Point(329, 359);
            this.lblNotesColorRecords.Name = "lblNotesColorRecords";
            this.lblNotesColorRecords.Size = new System.Drawing.Size(288, 35);
            this.lblNotesColorRecords.TabIndex = 12;
            this.lblNotesColorRecords.Text = "Note: Save each color before moving onto the next. (Restart Visual Studio for cha" +
    "nges to take effect.)";
            // 
            // lblNotes1
            // 
            this.lblNotes1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotes1.Location = new System.Drawing.Point(336, 136);
            this.lblNotes1.Name = "lblNotes1";
            this.lblNotes1.Size = new System.Drawing.Size(220, 32);
            this.lblNotes1.TabIndex = 12;
            this.lblNotes1.Text = "Note: Most Visual Studio window colors are in the \'Environment\' category.";
            // 
            // cmdForeground
            // 
            this.cmdForeground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdForeground.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdForeground.Location = new System.Drawing.Point(437, 224);
            this.cmdForeground.Name = "cmdForeground";
            this.cmdForeground.Size = new System.Drawing.Size(119, 34);
            this.cmdForeground.TabIndex = 13;
            this.toolTip1.SetToolTip(this.cmdForeground, "Click to edit Foreground color.");
            this.cmdForeground.UseVisualStyleBackColor = true;
            this.cmdForeground.BackColorChanged += new System.EventHandler(this.cmdForeground_BackColorChanged);
            this.cmdForeground.Click += new System.EventHandler(this.cmdForeground_Click);
            // 
            // cmdBackground
            // 
            this.cmdBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBackground.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBackground.Location = new System.Drawing.Point(437, 285);
            this.cmdBackground.Name = "cmdBackground";
            this.cmdBackground.Size = new System.Drawing.Size(119, 34);
            this.cmdBackground.TabIndex = 13;
            this.toolTip1.SetToolTip(this.cmdBackground, "Click to edit Background color.");
            this.cmdBackground.UseVisualStyleBackColor = true;
            this.cmdBackground.BackColorChanged += new System.EventHandler(this.cmdBackground_BackColorChanged);
            this.cmdBackground.Click += new System.EventHandler(this.cmdBackground_Click);
            // 
            // lblFG
            // 
            this.lblFG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFG.AutoSize = true;
            this.lblFG.Location = new System.Drawing.Point(403, 208);
            this.lblFG.Name = "lblFG";
            this.lblFG.Size = new System.Drawing.Size(64, 13);
            this.lblFG.TabIndex = 14;
            this.lblFG.Text = "(A) (R, G, B)";
            // 
            // lblBG
            // 
            this.lblBG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBG.AutoSize = true;
            this.lblBG.Location = new System.Drawing.Point(403, 269);
            this.lblBG.Name = "lblBG";
            this.lblBG.Size = new System.Drawing.Size(64, 13);
            this.lblBG.TabIndex = 14;
            this.lblBG.Text = "(A) (R, G, B)";
            // 
            // lblColorRecordName
            // 
            this.lblColorRecordName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblColorRecordName.AutoSize = true;
            this.lblColorRecordName.Location = new System.Drawing.Point(329, 187);
            this.lblColorRecordName.Name = "lblColorRecordName";
            this.lblColorRecordName.Size = new System.Drawing.Size(94, 13);
            this.lblColorRecordName.TabIndex = 14;
            this.lblColorRecordName.Text = "ColorRecordName";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarStatusMessage,
            this.StatusBarErrorMessage,
            this.StatusBarProgressBar,
            this.StatusBarActionIcon,
            this.StatusBarDirtyMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(632, 22);
            this.statusStrip1.TabIndex = 109;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusBarStatusMessage
            // 
            this.StatusBarStatusMessage.ForeColor = System.Drawing.Color.Green;
            this.StatusBarStatusMessage.Name = "StatusBarStatusMessage";
            this.StatusBarStatusMessage.Size = new System.Drawing.Size(0, 17);
            this.StatusBarStatusMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusBarErrorMessage
            // 
            this.StatusBarErrorMessage.AutoToolTip = true;
            this.StatusBarErrorMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StatusBarErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.StatusBarErrorMessage.Name = "StatusBarErrorMessage";
            this.StatusBarErrorMessage.Size = new System.Drawing.Size(617, 17);
            this.StatusBarErrorMessage.Spring = true;
            this.StatusBarErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusBarProgressBar
            // 
            this.StatusBarProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.StatusBarProgressBar.Name = "StatusBarProgressBar";
            this.StatusBarProgressBar.Size = new System.Drawing.Size(100, 16);
            this.StatusBarProgressBar.Value = 10;
            this.StatusBarProgressBar.Visible = false;
            // 
            // StatusBarActionIcon
            // 
            this.StatusBarActionIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StatusBarActionIcon.Image = ((System.Drawing.Image)(resources.GetObject("StatusBarActionIcon.Image")));
            this.StatusBarActionIcon.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StatusBarActionIcon.Name = "StatusBarActionIcon";
            this.StatusBarActionIcon.Size = new System.Drawing.Size(16, 17);
            this.StatusBarActionIcon.Visible = false;
            // 
            // StatusBarDirtyMessage
            // 
            this.StatusBarDirtyMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StatusBarDirtyMessage.Image = ((System.Drawing.Image)(resources.GetObject("StatusBarDirtyMessage.Image")));
            this.StatusBarDirtyMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StatusBarDirtyMessage.Name = "StatusBarDirtyMessage";
            this.StatusBarDirtyMessage.Size = new System.Drawing.Size(16, 17);
            this.StatusBarDirtyMessage.ToolTipText = "Dirty";
            this.StatusBarDirtyMessage.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFileNew,
            this.tsbFileOpen,
            this.tsbFileSave,
            this.tsbFilePrint,
            this.toolStripSeparator,
            this.tsbEditProperties,
            this.toolStripSeparator2,
            this.tsbViewPreviousMonth,
            this.tsbViewPreviousWeek,
            this.tsbViewNextWeek,
            this.tsbViewNextMonth});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(632, 25);
            this.toolStrip1.TabIndex = 111;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbFileNew
            // 
            this.tsbFileNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFileNew.Enabled = false;
            this.tsbFileNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbFileNew.Image")));
            this.tsbFileNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFileNew.Name = "tsbFileNew";
            this.tsbFileNew.Size = new System.Drawing.Size(23, 22);
            this.tsbFileNew.Text = "&New";
            // 
            // tsbFileOpen
            // 
            this.tsbFileOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFileOpen.Enabled = false;
            this.tsbFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbFileOpen.Image")));
            this.tsbFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFileOpen.Name = "tsbFileOpen";
            this.tsbFileOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbFileOpen.Text = "&Open";
            // 
            // tsbFileSave
            // 
            this.tsbFileSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFileSave.Enabled = false;
            this.tsbFileSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbFileSave.Image")));
            this.tsbFileSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFileSave.Name = "tsbFileSave";
            this.tsbFileSave.Size = new System.Drawing.Size(23, 22);
            this.tsbFileSave.Text = "&Save";
            // 
            // tsbFilePrint
            // 
            this.tsbFilePrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFilePrint.Enabled = false;
            this.tsbFilePrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbFilePrint.Image")));
            this.tsbFilePrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFilePrint.Name = "tsbFilePrint";
            this.tsbFilePrint.Size = new System.Drawing.Size(23, 22);
            this.tsbFilePrint.Text = "&Print...";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbEditProperties
            // 
            this.tsbEditProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditProperties.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditProperties.Image")));
            this.tsbEditProperties.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbEditProperties.Name = "tsbEditProperties";
            this.tsbEditProperties.Size = new System.Drawing.Size(23, 22);
            this.tsbEditProperties.Text = "P&roperties...";
            this.tsbEditProperties.Click += new System.EventHandler(this.menuEditProperties_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbViewPreviousMonth
            // 
            this.tsbViewPreviousMonth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbViewPreviousMonth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbViewPreviousMonth.Name = "tsbViewPreviousMonth";
            this.tsbViewPreviousMonth.Size = new System.Drawing.Size(23, 22);
            this.tsbViewPreviousMonth.Text = "Previous &Month";
            // 
            // tsbViewPreviousWeek
            // 
            this.tsbViewPreviousWeek.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbViewPreviousWeek.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbViewPreviousWeek.Name = "tsbViewPreviousWeek";
            this.tsbViewPreviousWeek.Size = new System.Drawing.Size(23, 22);
            this.tsbViewPreviousWeek.Text = "Previous &Week";
            // 
            // tsbViewNextWeek
            // 
            this.tsbViewNextWeek.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbViewNextWeek.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbViewNextWeek.Name = "tsbViewNextWeek";
            this.tsbViewNextWeek.Size = new System.Drawing.Size(23, 22);
            this.tsbViewNextWeek.Text = "Next W&eek";
            // 
            // tsbViewNextMonth
            // 
            this.tsbViewNextMonth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbViewNextMonth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbViewNextMonth.Name = "tsbViewNextMonth";
            this.tsbViewNextMonth.Size = new System.Drawing.Size(23, 22);
            this.tsbViewNextMonth.Text = "Next M&onth";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
            this.menuStrip1.TabIndex = 110;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileNew,
            this.menuFileOpen,
            this.menuFileSave,
            this.menuFileSaveAs,
            this.toolStripSeparator1,
            this.menuFilePrint,
            this.toolStripSeparator3,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "&File";
            // 
            // menuFileNew
            // 
            this.menuFileNew.Enabled = false;
            this.menuFileNew.Name = "menuFileNew";
            this.menuFileNew.Size = new System.Drawing.Size(146, 22);
            this.menuFileNew.Text = "&New";
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Enabled = false;
            this.menuFileOpen.Name = "menuFileOpen";
            this.menuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuFileOpen.Size = new System.Drawing.Size(146, 22);
            this.menuFileOpen.Text = "&Open";
            // 
            // menuFileSave
            // 
            this.menuFileSave.Enabled = false;
            this.menuFileSave.Name = "menuFileSave";
            this.menuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuFileSave.Size = new System.Drawing.Size(146, 22);
            this.menuFileSave.Text = "&Save";
            // 
            // menuFileSaveAs
            // 
            this.menuFileSaveAs.Enabled = false;
            this.menuFileSaveAs.Name = "menuFileSaveAs";
            this.menuFileSaveAs.Size = new System.Drawing.Size(146, 22);
            this.menuFileSaveAs.Text = "Save &As...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // menuFilePrint
            // 
            this.menuFilePrint.Enabled = false;
            this.menuFilePrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuFilePrint.Name = "menuFilePrint";
            this.menuFilePrint.Size = new System.Drawing.Size(146, 22);
            this.menuFilePrint.Text = "&Print...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(143, 6);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(146, 22);
            this.menuFileExit.Text = "E&xit";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.menuEditProperties});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(39, 20);
            this.menuEdit.Text = "&Edit";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(133, 6);
            // 
            // menuEditProperties
            // 
            this.menuEditProperties.Image = ((System.Drawing.Image)(resources.GetObject("menuEditProperties.Image")));
            this.menuEditProperties.ImageTransparentColor = System.Drawing.Color.Black;
            this.menuEditProperties.Name = "menuEditProperties";
            this.menuEditProperties.Size = new System.Drawing.Size(136, 22);
            this.menuEditProperties.Text = "P&roperties...";
            this.menuEditProperties.Click += new System.EventHandler(this.menuEditProperties_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(44, 20);
            this.menuHelp.Text = "&Help";
            this.menuHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Name = "menuHelpAbout";
            this.menuHelpAbout.Size = new System.Drawing.Size(193, 22);
            this.menuHelpAbout.Text = "&About Theme Editor ...";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            // 
            // lblEditionCaption
            // 
            this.lblEditionCaption.AutoSize = true;
            this.lblEditionCaption.Location = new System.Drawing.Point(17, 82);
            this.lblEditionCaption.Name = "lblEditionCaption";
            this.lblEditionCaption.Size = new System.Drawing.Size(42, 13);
            this.lblEditionCaption.TabIndex = 114;
            this.lblEditionCaption.Text = "Edition:";
            // 
            // lblYearVersionCaption
            // 
            this.lblYearVersionCaption.AutoSize = true;
            this.lblYearVersionCaption.Location = new System.Drawing.Point(17, 55);
            this.lblYearVersionCaption.Name = "lblYearVersionCaption";
            this.lblYearVersionCaption.Size = new System.Drawing.Size(45, 13);
            this.lblYearVersionCaption.TabIndex = 115;
            this.lblYearVersionCaption.Text = "Version:";
            // 
            // cboEdition
            // 
            this.cboEdition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEdition.DataSource = this.bsEditionBindingSource;
            this.cboEdition.DisplayMember = "EditionName";
            this.cboEdition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEdition.FormattingEnabled = true;
            this.cboEdition.Location = new System.Drawing.Point(76, 79);
            this.cboEdition.Name = "cboEdition";
            this.cboEdition.Size = new System.Drawing.Size(247, 21);
            this.cboEdition.TabIndex = 112;
            this.cboEdition.ValueMember = "EditionKey";
            this.cboEdition.SelectedValueChanged += new System.EventHandler(this.cboEdition_SelectedValueChanged);
            this.cboEdition.Validating += new System.ComponentModel.CancelEventHandler(this.cboEdition_Validating);
            // 
            // bsEditionBindingSource
            // 
            this.bsEditionBindingSource.DataSource = typeof(ThemeEditorLibrary.VisualStudioEdition);
            this.bsEditionBindingSource.PositionChanged += new System.EventHandler(this.bsEditionBindingSource_PositionChanged);
            // 
            // cboYearVersion
            // 
            this.cboYearVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboYearVersion.DataSource = this.bsVersionYearBindingSource;
            this.cboYearVersion.DisplayMember = "VersionYear";
            this.cboYearVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYearVersion.FormattingEnabled = true;
            this.cboYearVersion.Location = new System.Drawing.Point(76, 52);
            this.cboYearVersion.Name = "cboYearVersion";
            this.cboYearVersion.Size = new System.Drawing.Size(247, 21);
            this.cboYearVersion.TabIndex = 113;
            this.cboYearVersion.ValueMember = "VersionYear";
            this.cboYearVersion.SelectedValueChanged += new System.EventHandler(this.cboYearVersion_SelectedValueChanged);
            this.cboYearVersion.Validating += new System.ComponentModel.CancelEventHandler(this.cboYearVersion_Validating);
            // 
            // bsVersionYearBindingSource
            // 
            this.bsVersionYearBindingSource.DataSource = typeof(ThemeEditorLibrary.VisualStudioVersion);
            this.bsVersionYearBindingSource.PositionChanged += new System.EventHandler(this.bsVersionYearBindingSource_PositionChanged);
            // 
            // cmdBackupTheme
            // 
            this.cmdBackupTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBackupTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBackupTheme.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdBackupTheme.Location = new System.Drawing.Point(339, 55);
            this.cmdBackupTheme.Name = "cmdBackupTheme";
            this.cmdBackupTheme.Size = new System.Drawing.Size(124, 23);
            this.cmdBackupTheme.TabIndex = 116;
            this.cmdBackupTheme.Text = "Backup Theme ...";
            this.toolTip1.SetToolTip(this.cmdBackupTheme, "Backup Theme to File");
            this.cmdBackupTheme.UseVisualStyleBackColor = true;
            this.cmdBackupTheme.Click += new System.EventHandler(this.cmdBackupTheme_Click);
            // 
            // cmdResetTheme
            // 
            this.cmdResetTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdResetTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdResetTheme.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdResetTheme.Location = new System.Drawing.Point(339, 82);
            this.cmdResetTheme.Name = "cmdResetTheme";
            this.cmdResetTheme.Size = new System.Drawing.Size(124, 23);
            this.cmdResetTheme.TabIndex = 117;
            this.cmdResetTheme.Text = "Reset Theme ...";
            this.toolTip1.SetToolTip(this.cmdResetTheme, "Reset To Stock Theme");
            this.cmdResetTheme.UseVisualStyleBackColor = true;
            this.cmdResetTheme.Click += new System.EventHandler(this.cmdResetTheme_Click);
            // 
            // trkForeground
            // 
            this.trkForeground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trkForeground.LargeChange = 10;
            this.trkForeground.Location = new System.Drawing.Point(329, 224);
            this.trkForeground.Maximum = 255;
            this.trkForeground.Name = "trkForeground";
            this.trkForeground.Size = new System.Drawing.Size(104, 45);
            this.trkForeground.TabIndex = 118;
            this.trkForeground.TickFrequency = 26;
            this.toolTip1.SetToolTip(this.trkForeground, "Slide to change Foreground Alpha (Opacity)");
            this.trkForeground.Scroll += new System.EventHandler(this.trkForeground_Scroll);
            // 
            // trkBackground
            // 
            this.trkBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trkBackground.LargeChange = 10;
            this.trkBackground.Location = new System.Drawing.Point(329, 285);
            this.trkBackground.Maximum = 255;
            this.trkBackground.Name = "trkBackground";
            this.trkBackground.Size = new System.Drawing.Size(104, 45);
            this.trkBackground.TabIndex = 119;
            this.trkBackground.TickFrequency = 26;
            this.toolTip1.SetToolTip(this.trkBackground, "Slide to change Background Alpha (Opacity)");
            this.trkBackground.Scroll += new System.EventHandler(this.trkBackground_Scroll);
            // 
            // ThemeEditorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.trkBackground);
            this.Controls.Add(this.trkForeground);
            this.Controls.Add(this.cmdResetTheme);
            this.Controls.Add(this.cmdBackupTheme);
            this.Controls.Add(this.lblEditionCaption);
            this.Controls.Add(this.lblYearVersionCaption);
            this.Controls.Add(this.cboEdition);
            this.Controls.Add(this.cboYearVersion);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblBG);
            this.Controls.Add(this.lblColorRecordName);
            this.Controls.Add(this.lblFG);
            this.Controls.Add(this.cmdBackground);
            this.Controls.Add(this.cmdForeground);
            this.Controls.Add(this.lblNotes1);
            this.Controls.Add(this.lblNotesColorRecords);
            this.Controls.Add(this.cmdSaveColor);
            this.Controls.Add(this.lblBackgroundCaption);
            this.Controls.Add(this.lblForegroundCaption);
            this.Controls.Add(this.lblColorRecordsCaption);
            this.Controls.Add(this.lblCategoryCaption);
            this.Controls.Add(this.lblThemeCaption);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.cboTheme);
            this.Controls.Add(this.lstColorRecords);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "ThemeEditorView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Theme Editor";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.Load += new System.EventHandler(this.ThemeEditorView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsColorRecordBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsThemeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCategoryBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsEditionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVersionYearBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkForeground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstColorRecords;
        private System.Windows.Forms.ComboBox cboTheme;
        private System.Windows.Forms.Label lblThemeCaption;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblCategoryCaption;
        private System.Windows.Forms.Label lblColorRecordsCaption;
        private System.Windows.Forms.Label lblForegroundCaption;
        private System.Windows.Forms.Label lblBackgroundCaption;
        internal System.Windows.Forms.BindingSource bsThemeBindingSource;
        private System.Windows.Forms.BindingSource bsCategoryBindingSource;
        private System.Windows.Forms.BindingSource bsColorRecordBindingSource;
        internal System.Windows.Forms.Button cmdSaveColor;
        private System.Windows.Forms.Label lblNotesColorRecords;
        private System.Windows.Forms.Label lblNotes1;
        private System.Windows.Forms.Button cmdForeground;
        private System.Windows.Forms.Button cmdBackground;
        private System.Windows.Forms.ColorDialog colorPicker;
        private System.Windows.Forms.Label lblFG;
        private System.Windows.Forms.Label lblBG;
        private System.Windows.Forms.Label lblColorRecordName;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarStatusMessage;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarErrorMessage;
        private System.Windows.Forms.ToolStripProgressBar StatusBarProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarActionIcon;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarDirtyMessage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbFileNew;
        private System.Windows.Forms.ToolStripButton tsbFileOpen;
        private System.Windows.Forms.ToolStripButton tsbFileSave;
        private System.Windows.Forms.ToolStripButton tsbFilePrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton tsbEditProperties;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbViewPreviousMonth;
        private System.Windows.Forms.ToolStripButton tsbViewPreviousWeek;
        private System.Windows.Forms.ToolStripButton tsbViewNextWeek;
        private System.Windows.Forms.ToolStripButton tsbViewNextMonth;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileNew;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem menuFileSave;
        private System.Windows.Forms.ToolStripMenuItem menuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuFilePrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuEditProperties;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
        private System.Windows.Forms.Label lblEditionCaption;
        private System.Windows.Forms.Label lblYearVersionCaption;
        private System.Windows.Forms.ComboBox cboEdition;
        private System.Windows.Forms.ComboBox cboYearVersion;
        private System.Windows.Forms.Button cmdBackupTheme;
        private System.Windows.Forms.Button cmdResetTheme;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.BindingSource bsVersionYearBindingSource;
        private System.Windows.Forms.BindingSource bsEditionBindingSource;
        private System.Windows.Forms.TrackBar trkForeground;
        private System.Windows.Forms.TrackBar trkBackground;
    }
}

