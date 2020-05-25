using PRACT.Classes.Helpers;
using PRACT.Forms;
using PRACT.Rekordbox5.Data;
using PRACT.Rekordbox5.Helpers;
using PRACT_OBS;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace PRACT_GUI
{
    public partial class MainForm : Form
    {
        private Thread exportThread;
        private TextBoxLogger tbl;
        protected PlaylistHelper PlaylistHelper;

        public MainForm()
        {
            InitializeComponent();
            this.Text = Application.ProductName;
            RefreshStatusBar();

            this.ttipMainform.AutoPopDelay = 5000;
            this.ttipMainform.InitialDelay = 1000;
            this.ttipMainform.ReshowDelay = 500;
            this.ttipMainform.ShowAlways = true;

            tbl = new TextBoxLogger(this.txtLog);

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
            btnProcess.Invoke((Action)delegate
            {
                btnProcess.Enabled = true;
            });

        }
        private void Process()
        {
            tbl.ClearLog();
            tbl.Log("Starting up...");
            tsCurrentProcess.Text = "Starting up...";

            if (Directory.Exists(ProgramSettings.OutputFolder)
                && File.Exists(ProgramSettings.RekordboxXMLFile))
            {

                tbl.Log($"Processing { ProgramSettings.RekordboxXMLFile }");
                
                // On first run, the Playlist Helper is empty 
                if (PlaylistHelper == null)
                    PlaylistHelper = new PlaylistHelper(ProgramSettings.OutputFolder
                        , ProgramSettings.MusicFolder
                        , new DJ_PLAYLISTS(ProgramSettings.RekordboxXMLFile));
                // On the next runs, the XML file may have changed
                else if (PlaylistHelper.Playlists.RekordboxXMLFullPath != ProgramSettings.RekordboxXMLFile)
                    PlaylistHelper.Playlists = new DJ_PLAYLISTS(ProgramSettings.RekordboxXMLFile);

                tbl.Log($"{ PlaylistHelper.TrackCount } track(s) loaded!");
                tbl.Log($"{ PlaylistHelper.PlaylistCount } Playlists loaded!");

                if (radPlaylists.Checked)
                {
                    if (chkOrphans.Checked)
                    {
                        tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_ORPHANS;
                        tbl.Log(PlaylistHelper.PROCESS_TITLE_ORPHANS);
                        PlaylistHelper.WritePlaylist(PlaylistHelper.PlaylistOptions.Orphans);
                    }

                    if (chkDuplicates.Checked)
                    {
                        tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_DUPLICATES;
                        tbl.Log(PlaylistHelper.PROCESS_TITLE_DUPLICATES);
                        PlaylistHelper.WritePlaylist(PlaylistHelper.PlaylistOptions.Duplicates);
                    }
                    if (chkMissing.Checked)
                    {
                        tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_MISSING;
                        tbl.Log(PlaylistHelper.PROCESS_TITLE_MISSING);
                        PlaylistHelper.WritePlaylist(PlaylistHelper.PlaylistOptions.Missing);
                    }
                    if (chkUntagged.Checked)
                    {
                        tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_UNTAGGED;
                        tbl.Log(PlaylistHelper.PROCESS_TITLE_UNTAGGED);
                        PlaylistHelper.WritePlaylist(PlaylistHelper.PlaylistOptions.Untagged);
                    }
                    if (chkUnanalyzed.Checked)
                    {
                        tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_UNANALYZED;
                        tbl.Log(PlaylistHelper.PROCESS_TITLE_UNANALYZED);
                        PlaylistHelper.WritePlaylist(PlaylistHelper.PlaylistOptions.Unanalyzed);
                    }

                    if (chkUnreferenced.Checked)
                    {
                        tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_UNREFERENCED;
                        tbl.Log(PlaylistHelper.PROCESS_TITLE_UNREFERENCED);
                        tbl.Log($"Checking files stored in { ProgramSettings.MusicFolder }, this may take a while...");
                        PlaylistHelper.WritePlaylist(PlaylistHelper.PlaylistOptions.Unreferenced);
                    }
                }
                else if (radStats.Checked)
                {
                    tbl.Log("Calculating music library files size...");
                    tbl.Log(string.Format(new FileSizeFormatProvider(), "Total size : {0:fs}", PlaylistHelper.Playlists.Size));
                }
                tbl.Log("Finished!");
                tsCurrentProcess.Text = "Finished !";
            }
            else
            {
                string msg = $"Impossible to start processing: { ProgramSettings.RekordboxXMLFile } could not be found.";
                tbl.Log(msg);
                Messages.ErrorMessage(msg);
            }
            StopProcess();
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
