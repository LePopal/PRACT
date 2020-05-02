using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace PRACT.Classes
{
    public class Parameters
    {
        [DefaultValue(false)]
        public bool MissingPlaylistOption { get; set; }
        [DefaultValue(false)]
        public bool UnreferencedPlaylistOption { get; set; }
        [DefaultValue(false)]
        public bool UntaggedPlaylistOption { get; set; }
        [DefaultValue(false)]
        public bool OrphanedPlaylistOption { get; set; }
        [DefaultValue(false)]
        public bool UnanalyzedPlaylistOption { get; set; }
        [DefaultValue(false)]
        public bool DuplicatePlaylistOption { get; set; }

        [DefaultValue(false)]
        public bool GeneratePlaylistsCommand { get; set; }
        [DefaultValue(false)]
        public bool ShowStatisticsCommand { get; set; }
        [DefaultValue(false)]
        public bool GenerateScriptsCommand { get; set; }
        
        public string InputRekordboxXML { get; set; }
        
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

        /// <summary>
        /// Returns true if every parameters is valid, especially paths
        /// Returns false otherwise. In this case the details are stored in the ValidationErrors property
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            // Resets previous validation errors
            this._ValidationErrors = string.Empty;
            bool result = true;
            StringBuilder validationErrors = new StringBuilder();

            // Check if the Rekordbox input XML is valid
            if(!File.Exists(this.InputRekordboxXML))
            {
                result = false;
                validationErrors.AppendLine(string.Format("The Rekordbox Input XML does not exist: {0}", this.InputRekordboxXML));
            }
            if(!Directory.Exists(OutputDirectory))
            {
                result = false;
                validationErrors.AppendLine(string.Format("The Output Directory does not exist: {0}", this.OutputDirectory));
            }


            _ValidationErrors = validationErrors.ToString();
            return result;

        }

        public string ValidationErrors
        {
            get
            {
                return _ValidationErrors;
            }
        }

        #region Private members
        private string _OutputDirectory = string.Empty;
        private string _ValidationErrors = string.Empty;
        #endregion
    }
}
