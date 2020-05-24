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

        public static string OutputFolder
        {
            get
            {
                // If undefined, the OutputFolder will be the MyDocuments directory
                if (settings.OutputFolder == string.Empty)
                    return SystemPaths.MyDocumentsFolder;
                else
                    return settings.OutputFolder.Trim();
            }
            set
            {
                settings.OutputFolder = value;
                settings.Save();
            }
        }
        public static bool PassphraseToMine
        {
            get
            {
                return settings.PassphraseToMine;
            }
            set
            {
                settings.PassphraseToMine = value;
                settings.Key = PASSPHRASE_TO_MINE;
                settings.Save();
            }
        }

        public static bool CleanFilesAtStartup
        {
            get
            {
                return settings.CleanFilesAtStartup;
            }
            set
            {
                settings.CleanFilesAtStartup = value;
                settings.Save();
            }
        }
        public static bool CleanFilesAtShutDown
        {
            get
            {
                return settings.CleanFilesAtShutDown;
            }
            set
            {
                settings.CleanFilesAtShutDown = value;
                settings.Save();
            }
        }

        public static string Key
        {
            get
            {
                // If not set, the program will try to mine for the database passphrase
                // otherwise it will use the key stored in the config file
                if (settings.PassphraseToMine)
                {
                    if (!string.IsNullOrWhiteSpace(EncryptionKey))
                    {
                        MineKey();
                    }
                    return EncryptionKey;
                }
                else
                    return settings.Key;

            }
            set
            {
                settings.Key = value;
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
