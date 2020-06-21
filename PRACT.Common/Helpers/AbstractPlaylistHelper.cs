using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PRACT.Common.Helpers
{
    public abstract class AbstractPlaylistHelper
    {
        public const string FILENAME_ORPHANS = "Orphans.m3u8";
        public const string FILENAME_DUPLICATES = "Duplicates.m3u8";
        public const string FILENAME_UNANALYZED = "Unanalyzed.m3u8";
        public const string FILENAME_MISSING = "Missing.m3u8";
        public const string FILENAME_UNREFERENCED = "Unreferenced.m3u8";
        public const string FILENAME_UNTAGGED = "Untagged.m3u8";

        public const string PROCESS_TITLE_ORPHANS = "Processing orphans...";
        public const string PROCESS_TITLE_DUPLICATES = "Processing duplicates...";
        public const string PROCESS_TITLE_UNANALYZED = "Processing unanalyzed tracks...";
        public const string PROCESS_TITLE_MISSING = "Processing missing tracks...";
        public const string PROCESS_TITLE_UNREFERENCED = "Processing unreferenced files...";
        public const string PROCESS_TITLE_UNTAGGED = "Processing untagged tracks...";

        public string OutputFolder { get; set; }
        public string MusicFolder { get; set; }
        public static string LocationCleanUp(string Location)
        {
            //Sample : file://localhost/M:/_Pop/Michael%20Jackson/1995%20-%20HIStory_%20Past,%20Present%20and%20Future,%20Book%20I/01%20-%20Billie%20Jean.mp3
            return new Uri(Location).LocalPath.Replace(@"\\localhost\", string.Empty);
        }

        public abstract int TrackCount { get; }
        public abstract int PlaylistCount { get; }


        public abstract void WritePlaylist(PlaylistOptions playlist);

        public static void WritePlaylist(List<string> Playlist, string Destination)
        {
            StreamWriter sw = new StreamWriter(Destination, false, Encoding.UTF8);
            foreach (string s in Playlist)
            {
                sw.WriteLine(s);
            }
            sw.Flush();
            sw.Close();
        }

        public static List<string> MusicFiles(string Dir)
        {
            List<string> tmp = new List<string>();
            MusicFiles(Dir, tmp);
            return tmp;
        }

        private static void MusicFiles(string Dir, List<string> MusicFilesList)
        {
            foreach (string d in Directory.GetDirectories(Dir))
            {
                foreach (string f in Directory.GetFiles(d))
                {
                    if (MusicFileExtensions.Any(x => f.EndsWith(x)))
                        MusicFilesList.Add(f);
                }
                MusicFiles(d, MusicFilesList);
            }
        }

        public static string[] MusicFileExtensions = { ".mp3", ".wav", ".flac", "m4a", "aiff" };
    }
}
