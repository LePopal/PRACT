using PRACT.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRACT.Rekordbox6.Data
{
    [Serializable()]
    public class Collection
    {
        public int Entries { get { return Tracks.Count(); } }
        public Track[] Tracks { get; set; }
        public TrackNode[] Tracknodes
        {
            get
            {
                return (from t in Tracks
                        select new TrackNode
                        {
                            Key = t.TrackID
                        }).ToArray();
            }
        }
        public Collection()
        {

        }
    }
}
