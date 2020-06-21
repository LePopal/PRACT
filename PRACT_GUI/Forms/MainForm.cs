using PRACT.Classes;
using PRACT.Classes.Helpers;
using PRACT.Common;
using PRACT.Common.IO;
using PRACT.Common.UI;
using PRACT.Forms;
using PRACT.Rekordbox5.Data;
using PRACT.Rekordbox5.Helpers;
using PRACT_OBS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace PRACT_GUI
{
    public partial class MainForm : Form
    {
        private TextBoxLogger tbl;
        protected PlaylistHelper PlaylistHelper;
        private BackgroundWorker backgroundWorker = new BackgroundWorker();
        private bool closePending;

        public MainForm()
        {
            InitializeComponent();
            
            this.Text = Application.ProductName;
            RefreshStatusBar();
            ApplyLocalizationToControls(this.Controls);
            ApplyLocalizationToMenu(menuStrip1.Items);

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
            progBar.Value = e.ProgressPercentage;

            if (e.UserState != null)
            {
                if (e.UserState is ProgressUpdate)
                {
                    ProgressUpdate pu = (ProgressUpdate)e.UserState;
                    tbl.Log(pu.LongProgress);
                    
                }
                else
                {
                    tbl.Log(e.UserState.ToString());
                }
            }
            else
            {
                //tbl.ClearLog();
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            PlaylistWorkQueue queue = new PlaylistWorkQueue();
            int WorkOrder = 1;

            tbl.ClearLog();
            worker.ReportProgress(0,rm.GetString("Starting up..."));
            tsCurrentProcess.Text = rm.GetString("Starting up...");

            if (Directory.Exists(ProgramSettings.OutputFolder)
                && File.Exists(ProgramSettings.RekordboxXMLFile))
            {

                worker.ReportProgress(0,$"{ rm.GetString("Processing") } { ProgramSettings.RekordboxXMLFile }");

                // On first run, the Playlist Helper is empty 
                if (PlaylistHelper == null)
                    PlaylistHelper = new PlaylistHelper(ProgramSettings.OutputFolder
                        , ProgramSettings.MusicFolder
                        , new DJ_PLAYLISTS(ProgramSettings.RekordboxXMLFile));
                // On the next runs, the XML file may have changed
                else if (PlaylistHelper.Playlists.RekordboxXMLFullPath != ProgramSettings.RekordboxXMLFile)
                    PlaylistHelper.Playlists = new DJ_PLAYLISTS(ProgramSettings.RekordboxXMLFile);

                worker.ReportProgress(0,$"{ PlaylistHelper.TrackCount } { rm.GetString("track(s) loaded!") }");
                worker.ReportProgress(0,$"{ PlaylistHelper.PlaylistCount } { rm.GetString("Playlists loaded!") }");

                if (radPlaylists.Checked)
                {
                    // First we prepare the work queue
                        if (chkOrphans.Checked)
                        {
                            queue.AddWork(PlaylistOptions.Orphans, rm.GetString(PlaylistHelper.PROCESS_TITLE_ORPHANS), WorkOrder++);
                        }
                        if (chkDuplicates.Checked)
                        {
                            queue.AddWork(PlaylistOptions.Duplicates, rm.GetString(PlaylistHelper.PROCESS_TITLE_DUPLICATES), WorkOrder++);
                        }
                        if (chkMissing.Checked)
                        {
                            queue.AddWork(PlaylistOptions.Missing, rm.GetString(PlaylistHelper.PROCESS_TITLE_MISSING), WorkOrder++);
                        }
                        if (chkUntagged.Checked)
                        {
                            queue.AddWork(PlaylistOptions.Untagged, rm.GetString(PlaylistHelper.PROCESS_TITLE_UNTAGGED), WorkOrder++);
                        }
                        if (chkUnanalyzed.Checked)
                        {
                            queue.AddWork(PlaylistOptions.Unanalyzed, rm.GetString(PlaylistHelper.PROCESS_TITLE_UNANALYZED), WorkOrder++);
                        }
                        if (chkUnreferenced.Checked)
                        {
                            queue.AddWork(PlaylistOptions.None, rm.GetString(PlaylistHelper.PROCESS_TITLE_UNREFERENCED), WorkOrder++);
                            queue.AddWork(PlaylistOptions.Unreferenced, $"{ rm.GetString("Checking files stored in") } { ProgramSettings.MusicFolder }, { rm.GetString("this may take a while...") }", WorkOrder);
                        }

                    foreach(PlaylistWork pw in queue.Queue)
                    {
                        if (!worker.CancellationPending)
                        {
                            tsCurrentProcess.Text = pw.Title;
                            worker.ReportProgress((pw.Order * 100) / WorkOrder, pw.Title);
                            pw.DoWork(PlaylistHelper);
                        }
                        else
                        {
                            e.Cancel = true;
                            return;
                        }
                    }

                }

                else if (radStats.Checked)
                {
                    worker.ReportProgress(0,$"{rm.GetString("Calculating music library files size")}...");
                    worker.ReportProgress(100,rm.GetString("Total size:") + string.Format(new FileSizeFormatProvider(), " {0:fs}", PlaylistHelper.Playlists.Size));
                }
                else if (radBackupMusic.Checked)
                {
                    DialogResult dialogResult =
                        Messages.YesNoCancelMessage(rm.GetString("You're about to copy")  
                                                                + string.Format(new FileSizeFormatProvider(), " {0:fs}. ", PlaylistHelper.Playlists.Size)
                                                                + rm.GetString("This could take a long time. Would you like to overwrite the existing files ?"));
                    bool overwrite = false;
                    switch(dialogResult)
                    {
                        case DialogResult.Yes:
                            overwrite = true;
                            break;
                        case DialogResult.No:
                            overwrite = false;
                            break;
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            return;
                    }
                    worker.ReportProgress(0, $"{ rm.GetString("Starting music files copy from") } { ProgramSettings.MusicFolder } to { ProgramSettings.OutputFolder }...");
                    FileCopier fc = new FileCopier(ProgramSettings.MusicFolder, ProgramSettings.OutputFolder);
                    
                    int count = 1;
                    int total = PlaylistHelper.TrackCount;
                    int errorsCount = 0;

                    foreach (string file in PlaylistHelper.CollectionMusicFiles())
                    {
                        if (!worker.CancellationPending)
                        {
                            if (fc.Copy(file, overwrite))
                            {
                                worker.ReportProgress((count++ * 100) / total);
                            }
                            else
                            {
                                worker.ReportProgress((count++ * 100) / total, $"{ rm.GetString("Error:") } { rm.GetString("impossible to copy") } { file }. { rm.GetString("File not found") }. ");
                                errorsCount++;
                            }
                            tsCurrentProcess.Text = $"{ count } / { total } { rm.GetString("music files processed") }";
                        }
                        else
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                    if (errorsCount > 0)
                        worker.ReportProgress(100, $"{ rm.GetString("Error:") } { errorsCount } { rm.GetString("file(s) could not be copied") }.");
                }
                worker.ReportProgress(100, rm.GetString("Finished!"));
            }
            else
            {
                string msg = $"{ rm.GetString("Impossible to start processing:") } { ProgramSettings.RekordboxXMLFile } { rm.GetString("could not be found.") }";
                worker.ReportProgress(0,msg);
                Messages.ErrorMessage(msg);
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (closePending)
                this.Close();
            closePending = false;

            if (e.Cancelled)
            {
                tbl.Log(rm.GetString("Cancelled!"));
                progBar.Value = 0;
            }
            else if (e.Error != null)
            {
                tbl.Log(rm.GetString("Error!"));
            }
            else
            {
                tbl.Log(rm.GetString("Finished!"));
            }
            tsCurrentProcess.Text = rm.GetString("Idle!") ;
            StopProcess();
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
            if (backgroundWorker.IsBusy)
            {
                tsCurrentProcess.Text = $"{ rm.GetString("Cancelling") }...";
                backgroundWorker.CancelAsync();
            }
            else
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
                btnProcess.Text = rm.GetString("Cancel");
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void StopProcess()
        {
            btnProcess.Text = rm.GetString("Process");
            if (backgroundWorker.WorkerSupportsCancellation)
                backgroundWorker.CancelAsync();
        }
        
        private void RefreshStatusBar()
        {
            tsRekordboxXMLFile.Text = ProgramSettings.RekordboxXMLFile;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopProcess();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                closePending = true;
                tsCurrentProcess.Text = $"{ rm.GetString("Closing program") }...";
                backgroundWorker.CancelAsync();
                e.Cancel = true;
                this.Enabled = false;   // or this.Hide()
                return;
            }
            base.OnFormClosing(e);
        }

        private void radBackupMusic_Click(object sender, EventArgs e)
        {
            grpOptions.Enabled = false;
        }

        private void radStats_Click(object sender, EventArgs e)
        {
            grpOptions.Enabled = false;
        }

        private void radPlaylists_Click(object sender, EventArgs e)
        {
            grpOptions.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlaylistManager playlistManager = new PlaylistManager();
            playlistManager.Show();
            //Trace.WriteLine(TypeDescriptor.GetComponentName(this.btnProcess));

        }

        private void ApplyLocalizationToControls(Control.ControlCollection cc)
        {
            foreach(Control c in cc)
            {
#if DEBUG
                Trace.WriteLine($"{ c.Name } - { c.Text }");
#endif
                c.Text = rm.GetString(c.Text);
                ttipMainform.SetToolTip(c, rm.GetString($"tooltip.{ this.Name }.{ c.Name }"));
                if (c.Controls.Count > 0)
                {
                    ApplyLocalizationToControls(c.Controls);
                }
            }
        }


        private void ApplyLocalizationToMenu(ToolStripItemCollection col)
        {
            foreach (var c in col)
            {
                if (c is ToolStripMenuItem)
                {
                    ToolStripMenuItem i = (ToolStripMenuItem)c;
                    if (i.DropDownItems.Count > 0)
                        ApplyLocalizationToMenu(i.DropDownItems);
                    Trace.WriteLine(c.ToString());
                }
            }
        }

        private System.Resources.ResourceManager rm
        {
            get
            {
                return PRACT.Properties.strings.ResourceManager;
            }
        }
    }
}
