using PRACT.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PRACT.Common
{
    public class PlaylistWork
    {
        public PlaylistOptions Option { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public PlaylistWork(PlaylistOptions Option, string Title, int Order)
        {
            this.Option = Option;
            this.Title = Title;
            this.Order = Order;
        }

        public void DoWork(AbstractPlaylistHelper Helper)
        {
            if(Option != PlaylistOptions.None)
                Helper.WritePlaylist(Option);
        }
    }
}
