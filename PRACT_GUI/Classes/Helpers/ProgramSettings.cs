using PRACT.Properties;
using PRACT.Rekordbox6.Classes.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace PRACT.Classes.Helpers
{
    public class ProgramSettings : PRACT.Rekordbox6.Helpers.ProgramSettings
    {
        public static string InputFolder
        {
            get
            {
                return SystemPaths.MyDocumentsFolder;
            }
        }

        public static string RekordboxXMLFile
        {
            get
            {
                return settings.InputRekordboxXML;
            }
            set
            {
                settings.InputRekordboxXML = value;
                settings.Save();
            }
        }

        public static string MusicFolder
        {
            get
            { return settings.MusicFolder;
            }
            set
            {
                settings.MusicFolder = value;
                settings.Save();
            }
        }

        private static Settings settings
        {
            get
            {
                return Settings.Default;
            }
        }
    }
}
