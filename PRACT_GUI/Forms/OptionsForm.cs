using PRACT.Classes.Helpers;
using PRACT.Common.UI;
using PRACT.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PRACT_OBS
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            cbLang.Items.AddRange(Languages.SupportedLanguages.ToArray());


            chkMine.Checked = ProgramSettings.PassphraseToMine;
            if (ProgramSettings.PassphraseToMine)
            {
                txtKey.Text = ProgramSettings.PASSPHRASE_TO_MINE;
                txtKey.Enabled = false;
            }
            else
            {
                txtKey.Text = ProgramSettings.Key;
            }
            txtOutputFolder.Text = ProgramSettings.OutputFolder;
            txtMusicFolder.Text = ProgramSettings.MusicFolder;
            txtRekordboxXMLFile.Text = ProgramSettings.RekordboxXMLFile;
            chkCleanStartup.Checked = ProgramSettings.CleanFilesAtStartup;
            chkCleanExit.Checked = ProgramSettings.CleanFilesAtShutDown;
            cbLang.SelectedItem = Languages.GetLanguageByLocale(ProgramSettings.Language);

            this.ttipOptions.AutoPopDelay = 5000;
            this.ttipOptions.InitialDelay = 1000;
            this.ttipOptions.ReshowDelay = 500;
            this.ttipOptions.ShowAlways = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ProgramSettings.PassphraseToMine = chkMine.Checked;
            if (chkMine.Checked)
                ProgramSettings.Key = ProgramSettings.PASSPHRASE_TO_MINE;
            else
                ProgramSettings.Key = txtKey.Text;

            if (!CheckKey())
                Messages.WarningMessage("This key doesn't seem to be valid!");

            ProgramSettings.OutputFolder = txtOutputFolder.Text.Trim();

            if (!CheckOutputFolder() &&
                    (Messages.YesNoMessage("The Output Folder does not exist, would you like to create it ?") ==
                    DialogResult.Yes))
            {
                try
                {
                    Directory.CreateDirectory(txtOutputFolder.Text);
                    ProgramSettings.OutputFolder = txtOutputFolder.Text.Trim();
                }
                catch
                {
                    Messages.ErrorMessage("Error while creating directory");
                }
            }

            ProgramSettings.CleanFilesAtShutDown = chkCleanExit.Checked;
            ProgramSettings.CleanFilesAtStartup = chkCleanStartup.Checked;
            ProgramSettings.MusicFolder = txtMusicFolder.Text;
            ProgramSettings.RekordboxXMLFile = txtRekordboxXMLFile.Text;
            ProgramSettings.Language = ((Language)cbLang.SelectedItem).Locale;
            this.Close();
        }
            
        
        private bool CheckOutputFolder()
        {
            return Directory.Exists(txtOutputFolder.Text);
        }

        private bool CheckKey()
        {
            return !string.IsNullOrWhiteSpace(txtKey.Text);
        }



        private bool CheckInteger(string i)
        {
            return (int.TryParse(i, out int newValue)) && (newValue >= 0);
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        
        private void OptionsForm_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void chkMine_CheckedChanged(object sender, EventArgs e)
        {
            txtKey.Enabled = !chkMine.Checked;
        }

        private void btnDefaultArtwork_Click(object sender, EventArgs e)
        {

        }

        private void btnClearRekordboxXMLFile_Click(object sender, EventArgs e)
        {
            txtRekordboxXMLFile.Text = string.Empty;

        }
        private void btnOutputFolder_Click(object sender, EventArgs e)
        {
            outputFolderDialog.SelectedPath = txtOutputFolder.Text;
            outputFolderDialog.ShowDialog();
            txtOutputFolder.Text = outputFolderDialog.SelectedPath;
        }



        private void btnMusicFolder_Click(object sender, EventArgs e)
        {
            musicFolderDialog.SelectedPath = txtMusicFolder.Text;
            musicFolderDialog.ShowDialog();
            txtMusicFolder.Text = musicFolderDialog.SelectedPath;
        }

        private void btnRekordboxXML_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRekordboxXMLFile.Text))
                openRekordboxXML.InitialDirectory = ProgramSettings.MusicFolder;
            else
                openRekordboxXML.FileName = txtRekordboxXMLFile.Text;
            openRekordboxXML.ShowDialog();
            txtRekordboxXMLFile.Text = openRekordboxXML.FileName;
        }
    }
}
