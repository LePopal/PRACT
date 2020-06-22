using PRACT.Common.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PRACT.Rekordbox6.Data
{
    [Serializable()]
    public class RekordboxLibrary
    {
        public DjPlaylists djPlaylists { get; set; }
        public Product product { get; set; }
        public Collection collection { get; set; }
        public Playlists playlists { get; set; }
        public RekordboxLibrary()
        {
            djPlaylists = new DjPlaylists();
            djPlaylists.Version = "1.0.0";

            product = new Product();
            product.Version = "6.0.0";

            collection = new Collection();

            playlists = new Playlists();
        }

    }
}
