using PRACT.Rekordbox5.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PRACT.Rekordbox5.Helpers
{
    public static class PlaylistHelper
    {
        public static string LocationCleanUp(string Location)
        {
            //Sample : file://localhost/M:/_Pop/Michael%20Jackson/1995%20-%20HIStory_%20Past,%20Present%20and%20Future,%20Book%20I/01%20-%20Billie%20Jean.mp3
            return new Uri(Location).LocalPath.Replace(@"\\localhost\", string.Empty);
        }

        public static void WritePlaylist(List<TRACK> Playlist, string Destination)
        {
            StreamWriter sw = new StreamWriter(Destination, false, Encoding.UTF8);
            foreach (TRACK t in Playlist)
            {
                sw.WriteLine(LocationCleanUp(t.Location));
            }
            sw.Flush();
            sw.Close();
        }

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

        public static string[] MusicFileExtensions = { ".mp3", ".wav", ".flac" };
    }
}
