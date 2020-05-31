using PRACT.Classes.Helpers;
using PRACT.Common;
using PRACT.Forms;
using PRACT.Rekordbox5.Data;
using PRACT.Rekordbox5.Helpers;
using PRACT_OBS;
using System;
using System.ComponentModel;
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
        private BackgroundWorker backgroundWorker = new BackgroundWorker();
        public MainForm()
        {
            InitializeComponent();
            this.Text = Application.ProductName;
            RefreshStatusBar();

            this.ttipMainform.AutoPopDelay = 5000;
            this.ttipMainform.InitialDelay = 1000;
            this.ttipMainform.ReshowDelay = 500;
            this.ttipMainform.ShowAlways = true;

            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            
            tbl = new TextBoxLogger(this.txtLog);

            openRekordboxXML.InitialDirectory = ProgramSettings.OutputFolder;
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
                tbl.Log(e.UserState.ToString());
            else
                tbl.ClearLog();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            PlaylistWorkQueue queue = new PlaylistWorkQueue();


            tbl.ClearLog();
            worker.ReportProgress(0,"Starting up...");
            tsCurrentProcess.Text = "Starting up...";

            if (Directory.Exists(ProgramSettings.OutputFolder)
                && File.Exists(ProgramSettings.RekordboxXMLFile))
            {

                worker.ReportProgress(0,$"Processing { ProgramSettings.RekordboxXMLFile }");

                // On first run, the Playlist Helper is empty 
                if (PlaylistHelper == null)
                    PlaylistHelper = new PlaylistHelper(ProgramSettings.OutputFolder
                        , ProgramSettings.MusicFolder
                        , new DJ_PLAYLISTS(ProgramSettings.RekordboxXMLFile));
                // On the next runs, the XML file may have changed
                else if (PlaylistHelper.Playlists.RekordboxXMLFullPath != ProgramSettings.RekordboxXMLFile)
                    PlaylistHelper.Playlists = new DJ_PLAYLISTS(ProgramSettings.RekordboxXMLFile);

                worker.ReportProgress(0,$"{ PlaylistHelper.TrackCount } track(s) loaded!");
                worker.ReportProgress(0,$"{ PlaylistHelper.PlaylistCount } Playlists loaded!");

                if (radPlaylists.Checked)
                {
                    if (!worker.CancellationPending)
                    {
                        if (chkOrphans.Checked)
                        {
                            tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_ORPHANS;
                            worker.ReportProgress(0,PlaylistHelper.PROCESS_TITLE_ORPHANS);
                            PlaylistHelper.WritePlaylist(PlaylistOptions.Orphans);
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                        return;
                    }

                    if (!worker.CancellationPending)
                    {
                        if (chkDuplicates.Checked)
                        {
                            tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_DUPLICATES;
                            worker.ReportProgress(0,PlaylistHelper.PROCESS_TITLE_DUPLICATES);
                            PlaylistHelper.WritePlaylist(PlaylistOptions.Duplicates);
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                        return;
                    }
                    if (!worker.CancellationPending)
                    {
                        if (chkMissing.Checked)
                        {
                            tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_MISSING;
                            worker.ReportProgress(0,PlaylistHelper.PROCESS_TITLE_MISSING);
                            PlaylistHelper.WritePlaylist(PlaylistOptions.Missing);
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                        return;
                    }
                    if (!worker.CancellationPending)
                    {
                        if (chkUntagged.Checked)
                        {
                            tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_UNTAGGED;
                            worker.ReportProgress(0,PlaylistHelper.PROCESS_TITLE_UNTAGGED);
                            PlaylistHelper.WritePlaylist(PlaylistOptions.Untagged);
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                        return;
                    }
                    if (!worker.CancellationPending)
                    {
                        if (chkUnanalyzed.Checked)
                        {
                            tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_UNANALYZED;
                            worker.ReportProgress(0,PlaylistHelper.PROCESS_TITLE_UNANALYZED);
                            PlaylistHelper.WritePlaylist(PlaylistOptions.Unanalyzed);
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                        return;
                    }
                    if (!worker.CancellationPending)
                    {
                        if (chkUnreferenced.Checked)
                        {
                            tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_UNREFERENCED;
                            worker.ReportProgress(0,PlaylistHelper.PROCESS_TITLE_UNREFERENCED);
                            worker.ReportProgress(0,$"Checking files stored in { ProgramSettings.MusicFolder }, this may take a while...");
                            PlaylistHelper.WritePlaylist(PlaylistOptions.Unreferenced);
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                        return;
                    }
                }

                else if (radStats.Checked)
                {
                    worker.ReportProgress(0,"Calculating music library files size...");
                    worker.ReportProgress(0,string.Format(new FileSizeFormatProvider(), "Total size : {0:fs}", PlaylistHelper.Playlists.Size));
                }
                worker.ReportProgress(0,"Finished!");
                tsCurrentProcess.Text = "Finished !";
            }
            else
            {
                string msg = $"Impossible to start processing: { ProgramSettings.RekordboxXMLFile } could not be found.";
                worker.ReportProgress(0,msg);
                Messages.ErrorMessage(msg);
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled)
            {
                tbl.Log("Cancelled!");
            }
            else if (e.Error != null)
            {
                tbl.Log("Error!");
                    }
            else
            {
                tbl.Log("Done!");
            }
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
            if (!backgroundWorker.IsBusy)
            {
                //btnProcess.Enabled = false;
                //exportThread = new Thread(new ThreadStart(Process));
                //exportThread.Start();
                //while (exportThread.IsAlive)
                //{
                //    Application.DoEvents();
                //}
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void StopProcess()
        {
            if (backgroundWorker.WorkerSupportsCancellation)
                backgroundWorker.CancelAsync();
            //btnProcess.Invoke((Action)delegate
            //{
            //    btnProcess.Enabled = true;
            //});

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
                        PlaylistHelper.WritePlaylist(PlaylistOptions.Orphans);
                    }

                    if (chkDuplicates.Checked)
                    {
                        tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_DUPLICATES;
                        tbl.Log(PlaylistHelper.PROCESS_TITLE_DUPLICATES);
                        PlaylistHelper.WritePlaylist(PlaylistOptions.Duplicates);
                    }
                    if (chkMissing.Checked)
                    {
                        tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_MISSING;
                        tbl.Log(PlaylistHelper.PROCESS_TITLE_MISSING);
                        PlaylistHelper.WritePlaylist(PlaylistOptions.Missing);
                    }
                    if (chkUntagged.Checked)
                    {
                        tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_UNTAGGED;
                        tbl.Log(PlaylistHelper.PROCESS_TITLE_UNTAGGED);
                        PlaylistHelper.WritePlaylist(PlaylistOptions.Untagged);
                    }
                    if (chkUnanalyzed.Checked)
                    {
                        tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_UNANALYZED;
                        tbl.Log(PlaylistHelper.PROCESS_TITLE_UNANALYZED);
                        PlaylistHelper.WritePlaylist(PlaylistOptions.Unanalyzed);
                    }

                    if (chkUnreferenced.Checked)
                    {
                        tsCurrentProcess.Text = PlaylistHelper.PROCESS_TITLE_UNREFERENCED;
                        tbl.Log(PlaylistHelper.PROCESS_TITLE_UNREFERENCED);
                        tbl.Log($"Checking files stored in { ProgramSettings.MusicFolder }, this may take a while...");
                        PlaylistHelper.WritePlaylist(PlaylistOptions.Unreferenced);
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
