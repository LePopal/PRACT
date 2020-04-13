using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace PRACT.Classes
{
    class Parameters
    {
        [DefaultValue(false)]
        public bool MissingPlaylistOption { get; set; }
        [DefaultValue(false)]
        public bool UnreferendcedPlaylistOption { get; set; }
        [DefaultValue(false)]
        public bool UntaggedPlaylistOption { get; set; }
        [DefaultValue(false)]
        public bool OrphanedPlaylistOption { get; set; }
        [DefaultValue(false)]
        public bool UnanalyzedPlaylistOption { get; set; }

        [DefaultValue(false)]
        public bool GeneratePlaylistsCommand { get; set; }
        [DefaultValue(false)]
        public bool ShowStatisticsCommand { get; set; }
        [DefaultValue(false)]
        public bool GenerateScriptsCommand { get; set; }
        public string OutputDirectory
        {
            get
            {
                if (_OutputDirectory == string.Empty)
                    _OutputDirectory = Directory.GetCurrentDirectory();
                return _OutputDirectory;
            }
            set
            {
                _OutputDirectory = value;
            }
        }

        [DefaultValue("")]
        public string MusicDirectory { get; set; }


        #region Private members
        private string _OutputDirectory = string.Empty;
        #endregion
    }
}
