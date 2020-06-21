using System;
using System.Collections.Generic;
using System.Text;

namespace PRACT.Common.Data
{
    [Serializable()]
    public class TrackNode : IEqualityComparer<TrackNode>
    {
        public int Key { get; set; }

        public bool Equals(TrackNode x, TrackNode y)
        {
            return x.Key == y.Key;
        }

        public int GetHashCode(TrackNode obj)
        {
            return obj.GetHashCode();
        }
        public TrackNode()
        {

        }
    }

}
