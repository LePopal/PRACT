﻿using PRACT.Classes.Helpers;
using PRACT.Rekordbox5.Data;
using PRACT.Rekordbox5.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PRACT.Forms
{
    public partial class PlaylistManager : Form
    {
        public PlaylistManager()
        {
            InitializeComponent();
        }

        private void PlaylistManager_Load(object sender, EventArgs e)
        {
            DJ_PLAYLISTS dJ_PLAYLISTS = new DJ_PLAYLISTS(ProgramSettings.RekordboxXMLFile);

        }
    }
}