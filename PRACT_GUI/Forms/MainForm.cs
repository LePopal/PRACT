using PRACT.Classes.Helpers;
using PRACT.Rekordbox5.Data;
using PRACT.Rekordbox5.Helpers;
using PRACT_OBS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRACT_GUI
{
    public partial class MainForm : Form
    {
        protected DJ_PLAYLISTS RB5_Playlists;
        
        public MainForm()
        {
            

            InitializeComponent();
            this.Text = Application.ProductName;
            RefreshStatusBar();

            this.ttipMainform.AutoPopDelay = 5000;
            this.ttipMainform.InitialDelay = 1000;
            this.ttipMainform.ReshowDelay = 500;
            this.ttipMainform.ShowAlways = true;

            openRekordboxXML.InitialDirectory = ProgramSettings.OutputFolder;

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openRekordboxXML.FileName = ProgramSettings.RekordboxXMLFile;
            openRekordboxXML.ShowDialog();
            ProgramSettings.RekordboxXMLFile = openRekordboxXML.FileName;
            RefreshStatusBar();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm form = new OptionsForm();
            form.ShowDialog();
            RefreshStatusBar();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(ProgramSettings.OutputFolder)
                && File.Exists(ProgramSettings.RekordboxXMLFile))
            {
                if (RB5_Playlists == null)
                    RB5_Playlists = new DJ_PLAYLISTS(ProgramSettings.RekordboxXMLFile);

                if (chkDuplicates.Checked)
                {
                    //Messages.WarningMessage("Duplicates");
                    PlaylistHelper.WritePlaylist(RB5_Playlists.Duplicates, 
                        Path.Combine(ProgramSettings.OutputFolder, PlaylistHelper.FILENAME_DUPLICATES));
                }
                if (chkOrphans.Checked)
                {
                    //Messages.WarningMessage("Orphans");

                    PlaylistHelper.WritePlaylist(RB5_Playlists.Orphans, 
                        Path.Combine(ProgramSettings.OutputFolder, PlaylistHelper.FILENAME_ORPHANS));
                }
                if (chkUnanalyzed.Checked)
                {
                    //Messages.WarningMessage("UnAnalyzed");
                    PlaylistHelper.WritePlaylist(RB5_Playlists.UnAnalyzed, 
                        Path.Combine(ProgramSettings.OutputFolder, PlaylistHelper.FILENAME_UNANALYZED));
                }
                if (chkMissing.Checked)
                {
                    //Messages.WarningMessage("Missing");
                    PlaylistHelper.WritePlaylist(RB5_Playlists.Missing, 
                        Path.Combine(ProgramSettings.OutputFolder, PlaylistHelper.FILENAME_MISSING));
                }
                if (chkUntagged.Checked)
                {
                    //Messages.WarningMessage("Untagged");
                    PlaylistHelper.WritePlaylist(RB5_Playlists.Untagged, 
                        Path.Combine(ProgramSettings.OutputFolder, PlaylistHelper.FILENAME_UNTAGGED));
                }
                if (chkUnreferenced.Checked)
                {
                    Messages.WarningMessage("Unreferenced");
                    if (Directory.Exists(ProgramSettings.MusicFolder))
                    {
                        PlaylistHelper.WritePlaylist(RB5_Playlists.Unreferenced(ProgramSettings.MusicFolder),
                            Path.Combine(ProgramSettings.OutputFolder, PlaylistHelper.FILENAME_UNREFERENCED));
                    }
                }
                Messages.WarningMessage("Fin");
            }
        }

        private void RefreshStatusBar()
        {
            tsRekordboxXMLFile.Text = ProgramSettings.RekordboxXMLFile;
        }
    }
}
