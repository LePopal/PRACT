using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRACT.Common.Data
{
    [Serializable()]
    public class Collection
    {
        public int Entries { get; set; }
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
