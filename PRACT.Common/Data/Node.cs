using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRACT.Common.Data
{
    [Serializable()]
    public abstract class Node
    {
        public int Type { get; set; }
        public string Name { get; set; }
        public int Count { get { return Type == 0 ? Nodes.Count() : Tracks.Count(); } }
        public int? KeyType { get; set; }
        public int? Entries { get; set; }
        /// <summary>
        /// Gets new sub folders and playlists on the fly
        /// </summary>
        public List<Node> Nodes 
        { 
            get
            {
                if (_Nodes == null)
                    _Nodes = GetNodes();
                return _Nodes;
            }
            set
            {
                _Nodes = value;
            } 
        }
        /// <summary>
        /// Get Tracks on the fly
        /// </summary>
        public List<TrackNode> Tracks
        {
            get
            {
                if (_Tracks == null)
                    GetTrackNodes();
                return _Tracks;
            }

            set
            {
                _Tracks = value;
            }

        }
        public int Id { get; set; }

        protected abstract List<Node> GetNodes();
        protected abstract void GetTrackNodes();

        private List<Node> _Nodes;
        private List<TrackNode> _Tracks;
    }
}

