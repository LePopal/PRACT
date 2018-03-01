using PRACT.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACT.Classes
{
    public static class PlaylistHelper
    {
        public static string LocationCleanUp(string Location)
        {
            //Sample : file://localhost/M:/_Pop/Michael%20Jackson/1995%20-%20HIStory_%20Past,%20Present%20and%20Future,%20Book%20I/01%20-%20Billie%20Jean.mp3
            return new Uri(Location).LocalPath.Replace(@"\\localhost\",string.Empty);
        }

        public static void WritePlaylist(List<TRACK> Playlist, string Destination)
        {
            StreamWriter sw = new StreamWriter(Destination, false, Encoding.UTF8);
            foreach(TRACK t in Playlist)
            {
                sw.WriteLine(LocationCleanUp(t.Location));
            }
            sw.Flush();
            sw.Close();
        }
    }

    
}
