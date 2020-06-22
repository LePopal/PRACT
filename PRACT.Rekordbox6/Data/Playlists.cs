using PRACT.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PRACT.Rekordbox6.Data
{
    public class Playlists : PRACT.Common.Data.Playlists
    {
        public Playlists()
        {
            Node = new Node
            {
                Type = (int)NodeTypes.Folder,
                Name = "ROOT",
                Id = 0
            };
        }
    }
}

