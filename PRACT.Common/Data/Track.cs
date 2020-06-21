using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PRACT.Common.Data
{
    public class Track
    {

        public int TrackID { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Composer { get; set; }
        public string Album { get; set; }
        public string Grouping { get; set; }
        public string Genre { get; set; }
        public string Kind { get; set; }
        public int Size { get; set; }
        public int TotalTime { get; set; }
        public int DiscNumber { get; set; }
        public int TrackNumber { get; set; }
        public int Year { get; set; }
        public float AverageBpm { get; set; }
        public DateTime DateAdded { get; set; }
        public int BitRate { get; set; }
        public int SampleRate { get; set; }
        public string Comments { get; set; }
        public int PlayCount { get; set; }
        public int Rating { get; set; }
        public string Location { get; set; }
        public string Remixer { get; set; }
        public string Tonality { get; set; }
        public string Label { get; set; }
        public string Color { get; set; }
        public string Mix { get; set; }
        public Tempo[] Tempo { get; set; }
        public PositionMark[] PositionMark { get; set; }

        public bool Exists
        {
            get
            {
                return File.Exists(CleanLocation);
            }
        }

        public string CleanLocation
        {
            get
            {
                //return PlaylistHelper.LocationCleanUp(Location);
                return string.Empty;
            }
        }

    }
}
