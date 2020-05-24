using PRACT.Classes.Helpers;
using PRACT.Forms;
using PRACT.Rekordbox5.Data;
using PRACT.Rekordbox5.Helpers;
using PRACT_OBS;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PRACT_GUI
{

    public partial class MainForm : Form
    {
        private Thread exportThread;
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
            StartProcess();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }
        private void StartProcess()
        {
            btnProcess.Enabled = false;
            exportThread = new Thread(new ThreadStart(Process));
            exportThread.Start();
            while (exportThread.IsAlive)
            {
                Application.DoEvents();
            }
        }

        private void StopProcess()
        {
            btnProcess.Enabled = true;
        }
        private void Process()
        {
            tsCurrentProcess.Text = "Starting up...";

            if (Directory.Exists(ProgramSettings.OutputFolder)
                && File.Exists(ProgramSettings.RekordboxXMLFile))
            {
                if (RB5_Playlists == null)
                    RB5_Playlists = new DJ_PLAYLISTS(ProgramSettings.RekordboxXMLFile);

                if (chkDuplicates.Checked)
                {
                       tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_DUPLICATES;
                    
                    PlaylistHelper.WritePlaylist(RB5_Playlists.Duplicates,
                        Path.Combine(ProgramSettings.OutputFolder, PlaylistHelper.FILENAME_DUPLICATES));
                }
                if (chkOrphans.Checked)
                {
                    tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_ORPHANS;
                    PlaylistHelper.WritePlaylist(RB5_Playlists.Orphans,
                        Path.Combine(ProgramSettings.OutputFolder, PlaylistHelper.FILENAME_ORPHANS));
                }
                if (chkUnanalyzed.Checked)
                {
                    tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_UNANALYZED;
                    PlaylistHelper.WritePlaylist(RB5_Playlists.UnAnalyzed,
                        Path.Combine(ProgramSettings.OutputFolder, PlaylistHelper.FILENAME_UNANALYZED));
                }
                if (chkMissing.Checked)
                {
                    tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_MISSING;
                    PlaylistHelper.WritePlaylist(RB5_Playlists.Missing,
                        Path.Combine(ProgramSettings.OutputFolder, PlaylistHelper.FILENAME_MISSING));
                }
                if (chkUntagged.Checked)
                {
                    tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_UNTAGGED;
                    PlaylistHelper.WritePlaylist(RB5_Playlists.Untagged,
                        Path.Combine(ProgramSettings.OutputFolder, PlaylistHelper.FILENAME_UNTAGGED));
                }
                if (chkUnreferenced.Checked)
                {
                    tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_UNREFERENCED;
                    if (Directory.Exists(ProgramSettings.MusicFolder))
                    {
                        PlaylistHelper.WritePlaylist(RB5_Playlists.Unreferenced(ProgramSettings.MusicFolder),
                            Path.Combine(ProgramSettings.OutputFolder, PlaylistHelper.FILENAME_UNREFERENCED));
                    }
                }
                tsCurrentProcess.Text = "Finished !";
            }
        }
        private void RefreshStatusBar()
        {
            tsRekordboxXMLFile.Text = ProgramSettings.RekordboxXMLFile;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exportThread != null && exportThread.IsAlive)
            {
                StopProcess();
                e.Cancel = true;
                var timer = new System.Timers.Timer();
                timer.AutoReset = false;
                timer.SynchronizingObject = this;
                timer.Interval = 1000;
                timer.Elapsed +=
                  (sender, args) =>
                  {
                      // Do a fast check to see if the worker thread is still running.
                      if (exportThread.Join(0))
                      {
                          // Reissue the form closing event.
                          Close();
                      }
                      else
                      {
                          // Keep restarting the timer until the worker thread ends.
                          timer.Start();
                      }
                  };
                timer.Start();
            }
        }
    }
}
