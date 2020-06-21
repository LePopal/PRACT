using System;
using System.Collections.Generic;
using System.Text;

namespace PRACT.Common.Data
{
    [Serializable()]
    public class DjPlaylists
    {
        public Product Product { get; set; }
        public Node[] Playlists { get; set; }
        public Collection Collection { get; set; }
        public string Version { get; set; }
        public DjPlaylists()
        {

        }
    }
}
