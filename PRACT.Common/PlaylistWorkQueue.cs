using PRACT.Rekordbox5.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PRACT.Common
{
    public class PlaylistWorkQueue
    {
        public List<PlaylistWork> Queue = null;
        public PlaylistWorkQueue()
        {
            Queue = new List<PlaylistWork>();
        }
        public void AddWork(PlaylistOptions Option, string Title, int Order)
        {
            this.Queue.Add(new PlaylistWork(Option, Title, Order));
        }
    }
}
