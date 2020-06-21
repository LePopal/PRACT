using PRACT.Common.Helpers;
using PRACT.Rekordbox5.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PRACT.Rekordbox5.Helpers
{
    
    public class PlaylistHelper : AbstractPlaylistHelper
    {
        public DJ_PLAYLISTS Playlists { get; set; }
        public PlaylistHelper(string OutputFolder, string MusicFolder, DJ_PLAYLISTS Playlists)
        {
            this.OutputFolder = OutputFolder;
            this.MusicFolder = MusicFolder;
            if (Playlists == null)
            {
                throw new Exception("Playlists are undefined");
            }
            this.Playlists = Playlists;
        }

        public override int TrackCount
        {
            get
            {
                return Playlists.Collection.Tracks.Length;
            }
        }

        public override int PlaylistCount
        {
            get
            {
                return Playlists.Playlists.Where(p => p.Type == 1).Count();
            }
        }

        public override void WritePlaylist(PlaylistOptions playlist)
        {
            switch(playlist)
            {
                case PlaylistOptions.Duplicates:
                    WritePlaylist(Playlists.Duplicates, Path.Combine(OutputFolder, FILENAME_DUPLICATES));
                    break;
                case PlaylistOptions.Missing:
                    WritePlaylist(Playlists.Missing, Path.Combine(OutputFolder, FILENAME_MISSING));
                    break;
                case PlaylistOptions.Orphans:
                    WritePlaylist(Playlists.Orphans, Path.Combine(OutputFolder, FILENAME_ORPHANS));
                    break;
                case PlaylistOptions.Unanalyzed:
                    WritePlaylist(Playlists.UnAnalyzed, Path.Combine(OutputFolder, FILENAME_UNANALYZED));
                    break;
                case PlaylistOptions.Unreferenced:
                    WritePlaylist(Playlists.Unreferenced(MusicFolder), Path.Combine(OutputFolder, FILENAME_UNREFERENCED));
                    break;
                case PlaylistOptions.Untagged:
                    WritePlaylist(Playlists.Untagged, Path.Combine(OutputFolder, FILENAME_UNTAGGED));
                    break;
            }
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

        public List<string> CollectionMusicFiles()
        {
            var Files = from t in Playlists.Collection.Tracks
                        orderby t.CleanLocation
                        select
                            t.CleanLocation;
            return Files.ToList();
        }
    }
}
