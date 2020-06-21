using System;
using System.Collections.Generic;
using System.Text;

namespace PRACT.Common.Data
{
    [Serializable()]
    public class Node
    {
        public int Type { get; set; }
        public string Name { get; set; }
        public int? Count { get; set; }
        public int? KeyType { get; set; }
        public int? Entries { get; set; }
        public Node[] Nodes { get; set; }
        public TrackNode[] Tracks { get; set; }
    }
}
