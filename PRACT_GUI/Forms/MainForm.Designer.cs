namespace PRACT_GUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsRekordboxXMLFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsCurrentProcess = new System.Windows.Forms.ToolStripStatusLabel();
            this.ttipMainform = new System.Windows.Forms.ToolTip(this.components);
            this.chkOrphans = new System.Windows.Forms.CheckBox();
            this.chkDuplicates = new System.Windows.Forms.CheckBox();
            this.chkMissing = new System.Windows.Forms.CheckBox();
            this.chkUntagged = new System.Windows.Forms.CheckBox();
            this.chkUnanalyzed = new System.Windows.Forms.CheckBox();
            this.chkUnreferenced = new System.Windows.Forms.CheckBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.openRekordboxXML = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gtpCommand = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gtpCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentsToolStripMenuItem
            // 
            contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            contentsToolStripMenuItem.Size = new System.Drawing.Size(185, 34);
            contentsToolStripMenuItem.Text = "&Contents";
            contentsToolStripMenuItem.Visible = false;
            // 
            // indexToolStripMenuItem
            // 
            indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            indexToolStripMenuItem.Size = new System.Drawing.Size(185, 34);
            indexToolStripMenuItem.Text = "&Index";
            indexToolStripMenuItem.Visible = false;
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new System.Drawing.Size(185, 34);
            searchToolStripMenuItem.Text = "&Search";
            searchToolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(182, 6);
            toolStripSeparator5.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(616, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Visible = false;
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(220, 6);
            this.toolStripSeparator.Visible = false;
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Visible = false;
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(220, 6);
            this.toolStripSeparator1.Visible = false;
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Visible = false;
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            this.printPreviewToolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(220, 6);
            this.toolStripSeparator2.Visible = false;
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(58, 29);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Visible = false;
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(219, 34);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(219, 34);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(216, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(219, 34);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(219, 34);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(219, 34);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(216, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(219, 34);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(197, 34);
            this.customizeToolStripMenuItem.Text = "&Customize";
            this.customizeToolStripMenuItem.Visible = false;
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(197, 34);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            contentsToolStripMenuItem,
            indexToolStripMenuItem,
            searchToolStripMenuItem,
            toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(185, 34);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRekordboxXMLFile,
            this.tsCurrentProcess});
            this.statusStrip.Location = new System.Drawing.Point(0, 310);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(616, 32);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            this.ttipMainform.SetToolTip(this.statusStrip, "Selected Rekordbox XML File");
            // 
            // tsRekordboxXMLFile
            // 
            this.tsRekordboxXMLFile.Name = "tsRekordboxXMLFile";
            this.tsRekordboxXMLFile.Size = new System.Drawing.Size(0, 25);
            // 
            // tsCurrentProcess
            // 
            this.tsCurrentProcess.Name = "tsCurrentProcess";
            this.tsCurrentProcess.Size = new System.Drawing.Size(41, 25);
            this.tsCurrentProcess.Text = "Idle";
            // 
            // chkOrphans
            // 
            this.chkOrphans.AutoSize = true;
            this.chkOrphans.Location = new System.Drawing.Point(32, 31);
            this.chkOrphans.Name = "chkOrphans";
            this.chkOrphans.Size = new System.Drawing.Size(106, 29);
            this.chkOrphans.TabIndex = 2;
            this.chkOrphans.Text = "Orphans";
            this.ttipMainform.SetToolTip(this.chkOrphans, "Orphans are tracks not listed in any playlist");
            this.chkOrphans.UseVisualStyleBackColor = true;
            // 
            // chkDuplicates
            // 
            this.chkDuplicates.AutoSize = true;
            this.chkDuplicates.Location = new System.Drawing.Point(32, 67);
            this.chkDuplicates.Name = "chkDuplicates";
            this.chkDuplicates.Size = new System.Drawing.Size(120, 29);
            this.chkDuplicates.TabIndex = 3;
            this.chkDuplicates.Text = "Duplicates";
            this.ttipMainform.SetToolTip(this.chkDuplicates, "Duplicates are track with the same artist and title");
            this.chkDuplicates.UseVisualStyleBackColor = true;
            // 
            // chkMissing
            // 
            this.chkMissing.AutoSize = true;
            this.chkMissing.Location = new System.Drawing.Point(32, 103);
            this.chkMissing.Name = "chkMissing";
            this.chkMissing.Size = new System.Drawing.Size(99, 29);
            this.chkMissing.TabIndex = 4;
            this.chkMissing.Text = "Missing";
            this.ttipMainform.SetToolTip(this.chkMissing, "Tracks that can\'t be found on disk");
            this.chkMissing.UseVisualStyleBackColor = true;
            // 
            // chkUntagged
            // 
            this.chkUntagged.AutoSize = true;
            this.chkUntagged.Location = new System.Drawing.Point(32, 139);
            this.chkUntagged.Name = "chkUntagged";
            this.chkUntagged.Size = new System.Drawing.Size(117, 29);
            this.chkUntagged.TabIndex = 5;
            this.chkUntagged.Text = "Untagged";
            this.ttipMainform.SetToolTip(this.chkUntagged, "Tracks without metadata (ID3)");
            this.chkUntagged.UseVisualStyleBackColor = true;
            // 
            // chkUnanalyzed
            // 
            this.chkUnanalyzed.AutoSize = true;
            this.chkUnanalyzed.Location = new System.Drawing.Point(32, 175);
            this.chkUnanalyzed.Name = "chkUnanalyzed";
            this.chkUnanalyzed.Size = new System.Drawing.Size(129, 29);
            this.chkUnanalyzed.TabIndex = 6;
            this.chkUnanalyzed.Text = "Unanalyzed";
            this.ttipMainform.SetToolTip(this.chkUnanalyzed, "Tracks that were not properly prepared and analyzed");
            this.chkUnanalyzed.UseVisualStyleBackColor = true;
            // 
            // chkUnreferenced
            // 
            this.chkUnreferenced.AutoSize = true;
            this.chkUnreferenced.Location = new System.Drawing.Point(32, 211);
            this.chkUnreferenced.Name = "chkUnreferenced";
            this.chkUnreferenced.Size = new System.Drawing.Size(143, 29);
            this.chkUnreferenced.TabIndex = 7;
            this.chkUnreferenced.Text = "Unreferenced";
            this.ttipMainform.SetToolTip(this.chkUnreferenced, "Tracks from the Music folder that have not been imported in the library");
            this.chkUnreferenced.UseVisualStyleBackColor = true;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(12, 242);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(112, 34);
            this.btnProcess.TabIndex = 10;
            this.btnProcess.Text = "Process";
            this.ttipMainform.SetToolTip(this.btnProcess, "Start the analysis");
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // openRekordboxXML
            // 
            this.openRekordboxXML.Filter = "XML Files|*.xml";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkOrphans);
            this.groupBox1.Controls.Add(this.chkDuplicates);
            this.groupBox1.Controls.Add(this.chkMissing);
            this.groupBox1.Controls.Add(this.chkUntagged);
            this.groupBox1.Controls.Add(this.chkUnanalyzed);
            this.groupBox1.Controls.Add(this.chkUnreferenced);
            this.groupBox1.Location = new System.Drawing.Point(318, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 252);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // gtpCommand
            // 
            this.gtpCommand.Controls.Add(this.radioButton3);
            this.gtpCommand.Controls.Add(this.radioButton2);
            this.gtpCommand.Controls.Add(this.radioButton1);
            this.gtpCommand.Location = new System.Drawing.Point(12, 48);
            this.gtpCommand.Name = "gtpCommand";
            this.gtpCommand.Size = new System.Drawing.Size(300, 150);
            this.gtpCommand.TabIndex = 9;
            this.gtpCommand.TabStop = false;
            this.gtpCommand.Text = "Commands";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Enabled = false;
            this.radioButton3.Location = new System.Drawing.Point(16, 100);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(154, 29);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Show Statistics";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Location = new System.Drawing.Point(16, 65);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(165, 29);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Generate Scripts";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(16, 30);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(227, 29);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Generate M3U8 Playlists";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnProcess;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 342);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.gtpCommand);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gtpCommand.ResumeLayout(false);
            this.gtpCommand.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolTip ttipMainform;
        private System.Windows.Forms.OpenFileDialog openRekordboxXML;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkOrphans;
        private System.Windows.Forms.CheckBox chkDuplicates;
        private System.Windows.Forms.CheckBox chkMissing;
        private System.Windows.Forms.CheckBox chkUntagged;
        private System.Windows.Forms.CheckBox chkUnanalyzed;
        private System.Windows.Forms.CheckBox chkUnreferenced;
        private System.Windows.Forms.GroupBox gtpCommand;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripStatusLabel tsRekordboxXMLFile;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ToolStripStatusLabel tsCurrentProcess;
    }
}

