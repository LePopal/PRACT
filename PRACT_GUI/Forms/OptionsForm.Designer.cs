namespace PRACT_OBS
{
    partial class OptionsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.btnOutputFolder = new System.Windows.Forms.Button();
            this.outputFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMusicFolder = new System.Windows.Forms.TextBox();
            this.chkMine = new System.Windows.Forms.CheckBox();
            this.btnRekordboxXML = new System.Windows.Forms.Button();
            this.txtRekordboxXMLFile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.fileRekordboxXML = new System.Windows.Forms.OpenFileDialog();
            this.btnClearRekordboxXMLFile = new System.Windows.Forms.Button();
            this.chkCleanStartup = new System.Windows.Forms.CheckBox();
            this.chkCleanExit = new System.Windows.Forms.CheckBox();
            this.ttipOptions = new System.Windows.Forms.ToolTip(this.components);
            this.btnMusicFolder = new System.Windows.Forms.Button();
            this.musicFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openRekordboxXML = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(218, 13);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(816, 31);
            this.txtKey.TabIndex = 1;
            this.txtKey.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Output Folder";
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Location = new System.Drawing.Point(218, 50);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(928, 31);
            this.txtOutputFolder.TabIndex = 2;
            this.ttipOptions.SetToolTip(this.txtOutputFolder, "Folder where to output the generated playlists");
            // 
            // btnOutputFolder
            // 
            this.btnOutputFolder.Location = new System.Drawing.Point(1152, 50);
            this.btnOutputFolder.Name = "btnOutputFolder";
            this.btnOutputFolder.Size = new System.Drawing.Size(55, 34);
            this.btnOutputFolder.TabIndex = 3;
            this.btnOutputFolder.Text = "...";
            this.ttipOptions.SetToolTip(this.btnOutputFolder, "Choose your output folder");
            this.btnOutputFolder.UseVisualStyleBackColor = true;
            this.btnOutputFolder.Click += new System.EventHandler(this.btnOutputFolder_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(420, 249);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(112, 34);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(655, 249);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 34);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(14, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Music Folder";
            // 
            // txtMusicFolder
            // 
            this.txtMusicFolder.Location = new System.Drawing.Point(218, 87);
            this.txtMusicFolder.Name = "txtMusicFolder";
            this.txtMusicFolder.Size = new System.Drawing.Size(929, 31);
            this.txtMusicFolder.TabIndex = 1;
            this.ttipOptions.SetToolTip(this.txtMusicFolder, "The folder containing your DJ Music");
            // 
            // chkMine
            // 
            this.chkMine.AutoSize = true;
            this.chkMine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkMine.Location = new System.Drawing.Point(1040, 13);
            this.chkMine.Name = "chkMine";
            this.chkMine.Size = new System.Drawing.Size(179, 29);
            this.chkMine.TabIndex = 5;
            this.chkMine.Text = "Mine for the key";
            this.chkMine.UseVisualStyleBackColor = true;
            this.chkMine.CheckedChanged += new System.EventHandler(this.chkMine_CheckedChanged);
            // 
            // btnRekordboxXML
            // 
            this.btnRekordboxXML.Location = new System.Drawing.Point(1152, 124);
            this.btnRekordboxXML.Name = "btnRekordboxXML";
            this.btnRekordboxXML.Size = new System.Drawing.Size(55, 34);
            this.btnRekordboxXML.TabIndex = 3;
            this.btnRekordboxXML.Text = "...";
            this.ttipOptions.SetToolTip(this.btnRekordboxXML, "Choose your exported Rekordbox XML");
            this.btnRekordboxXML.UseVisualStyleBackColor = true;
            this.btnRekordboxXML.Click += new System.EventHandler(this.btnRekordboxXML_Click);
            // 
            // txtRekordboxXMLFile
            // 
            this.txtRekordboxXMLFile.Location = new System.Drawing.Point(218, 124);
            this.txtRekordboxXMLFile.Name = "txtRekordboxXMLFile";
            this.txtRekordboxXMLFile.Size = new System.Drawing.Size(867, 31);
            this.txtRekordboxXMLFile.TabIndex = 2;
            this.ttipOptions.SetToolTip(this.txtRekordboxXMLFile, "Rekordbox collection exported as an XML File");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(13, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Rekordbox XML File";
            // 
            // fileRekordboxXML
            // 
            this.fileRekordboxXML.Filter = "Pictures (*.png, *.jpg)|*.png;*.jpg";
            // 
            // btnClearRekordboxXMLFile
            // 
            this.btnClearRekordboxXMLFile.Location = new System.Drawing.Point(1091, 124);
            this.btnClearRekordboxXMLFile.Name = "btnClearRekordboxXMLFile";
            this.btnClearRekordboxXMLFile.Size = new System.Drawing.Size(55, 34);
            this.btnClearRekordboxXMLFile.TabIndex = 3;
            this.btnClearRekordboxXMLFile.Text = "X";
            this.btnClearRekordboxXMLFile.UseVisualStyleBackColor = true;
            this.btnClearRekordboxXMLFile.Click += new System.EventHandler(this.btnClearRekordboxXMLFile_Click);
            // 
            // chkCleanStartup
            // 
            this.chkCleanStartup.AutoSize = true;
            this.chkCleanStartup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkCleanStartup.Location = new System.Drawing.Point(13, 171);
            this.chkCleanStartup.Name = "chkCleanStartup";
            this.chkCleanStartup.Size = new System.Drawing.Size(216, 29);
            this.chkCleanStartup.TabIndex = 9;
            this.chkCleanStartup.Text = "Clean files at Startup";
            this.ttipOptions.SetToolTip(this.chkCleanStartup, "Future option");
            this.chkCleanStartup.UseVisualStyleBackColor = true;
            // 
            // chkCleanExit
            // 
            this.chkCleanExit.AutoSize = true;
            this.chkCleanExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkCleanExit.Location = new System.Drawing.Point(13, 206);
            this.chkCleanExit.Name = "chkCleanExit";
            this.chkCleanExit.Size = new System.Drawing.Size(189, 29);
            this.chkCleanExit.TabIndex = 10;
            this.chkCleanExit.Text = "Clean files on Exit";
            this.ttipOptions.SetToolTip(this.chkCleanExit, "Future option");
            this.chkCleanExit.UseVisualStyleBackColor = true;
            // 
            // btnMusicFolder
            // 
            this.btnMusicFolder.Location = new System.Drawing.Point(1153, 85);
            this.btnMusicFolder.Name = "btnMusicFolder";
            this.btnMusicFolder.Size = new System.Drawing.Size(55, 34);
            this.btnMusicFolder.TabIndex = 3;
            this.btnMusicFolder.Text = "...";
            this.ttipOptions.SetToolTip(this.btnMusicFolder, "Choose your DJ Music folder");
            this.btnMusicFolder.UseVisualStyleBackColor = true;
            this.btnMusicFolder.Click += new System.EventHandler(this.btnMusicFolder_Click);
            // 
            // openRekordboxXML
            // 
            this.openRekordboxXML.Filter = "XML Files|*.xml";
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1220, 296);
            this.Controls.Add(this.btnMusicFolder);
            this.Controls.Add(this.chkCleanExit);
            this.Controls.Add(this.chkCleanStartup);
            this.Controls.Add(this.btnClearRekordboxXMLFile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRekordboxXMLFile);
            this.Controls.Add(this.btnRekordboxXML);
            this.Controls.Add(this.chkMine);
            this.Controls.Add(this.txtMusicFolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnOutputFolder);
            this.Controls.Add(this.txtOutputFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OptionsForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Button btnOutputFolder;
        private System.Windows.Forms.FolderBrowserDialog outputFolderDialog;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMusicFolder;
        private System.Windows.Forms.CheckBox chkMine;
        private System.Windows.Forms.Button btnRekordboxXML;
        private System.Windows.Forms.TextBox txtRekordboxXMLFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog fileRekordboxXML;
        private System.Windows.Forms.Button btnClearRekordboxXMLFile;
        private System.Windows.Forms.CheckBox chkCleanStartup;
        private System.Windows.Forms.CheckBox chkCleanExit;
        private System.Windows.Forms.ToolTip ttipOptions;
        private System.Windows.Forms.Button btnMusicFolder;
        private System.Windows.Forms.FolderBrowserDialog musicFolderDialog;
        private System.Windows.Forms.OpenFileDialog openRekordboxXML;
    }
}