using PRACT.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace PRACT.Models
{
    public class DJ_PLAYLISTS
    {
        public string Version { get; set; }
        public string RekordboxXMLFullPath
        {
            get; private set;
        }
        public PRODUCT Product { get; set; }
        public NODE[] Playlists { get; set; }
        public COLLECTION Collection { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public DJ_PLAYLISTS()
        {
            Collection = new COLLECTION();
        }
        /// <summary>
        /// Constructor based on a Rekordbox.xml file
        /// </summary>
        /// <param name="RekordboxXMLFullPath">Full path to the Rekordbox.xml file</param>
        public DJ_PLAYLISTS(string RekordboxXMLFullPath)
        {
            this.RekordboxXMLFullPath = RekordboxXMLFullPath;
            XDocument xdoc = XDocument.Load(RekordboxXMLFullPath);

            DJ_PLAYLISTS djp = (from x in xdoc.Descendants("DJ_PLAYLISTS")
            select new DJ_PLAYLISTS
             {
                 Version = (string)x.Attribute("Version"),
                 Product =
                 (from p in x.Descendants("PRODUCT")
                  select new PRODUCT
                  {
                      Company = (string)p.Attribute("Company"),
                      Name = (string)p.Attribute("Name"),
                      Version = (string)p.Attribute("Version")
                  }).First(),
                 Collection =
                 (from c in x.Descendants("COLLECTION")
                  select new COLLECTION
                  {
                      Entries = (int)c.Attribute("Entries"),
                      Tracks =
                      (from e in c.Descendants("TRACK")
                       select new TRACK
                       {
                           Album = (string)e.Attribute("Album"),
                           Artist = (string)e.Attribute("Artist"),
                           AverageBpm = (float)e.Attribute("AverageBpm"),
                           BitRate = (int)e.Attribute("BitRate"),
                           Color = (string)e.Attribute("Color"),
                           Comments = (string)e.Attribute("Comments"),
                           Composer = (string)e.Attribute("Composer"),
                           DateAdded = (DateTime)e.Attribute("DateAdded"),
                           DiscNumber = (int)e.Attribute("DiscNumber"),
                           Genre = (string)e.Attribute("Genre"),
                           Grouping = (string)e.Attribute("Grouping"),
                           Kind = (string)e.Attribute("Kind"),
                           Label = (string)e.Attribute("Label"),
                           Location = (string)e.Attribute("Location"),
                           Mix = (string)e.Attribute("Mix"),
                           Name = (string)e.Attribute("Name"),
                           PlayCount = (int)e.Attribute("PlayCount"),
                           Rating = (int)e.Attribute("Rating"),
                           Remixer = (string)e.Attribute("Remixer"),
                           SampleRate = (int)e.Attribute("SampleRate"),
                           Size = (int)e.Attribute("Size"),
                           Tonality = (string)e.Attribute("Tonality"),
                           TotalTime = (int)e.Attribute("TotalTime"),
                           TrackID = (int)e.Attribute("TrackID"),
                           TrackNumber = (int)e.Attribute("TrackNumber"),
                           Year = (int)e.Attribute("Year"),
                           PositionMark =
                (
                    from p in e.Elements("POSITION_MARK")
                    select new POSITION_MARK
                    {
                        Blue = (int?)p.Attribute("Blue"),
                        End = (float?)p.Attribute("End"),
                        Green = (int?)p.Attribute("Green"),
                        Name = (string)p.Attribute("Name"),
                        Num = (int)p.Attribute("Num"),
                        Red = (int?)p.Attribute("Red"),
                        Start = (float)p.Attribute("Start"),
                        Type = (int)p.Attribute("Type")

                    }
                ).ToArray(),
                           Tempo =
                (
                from t in e.Elements("TEMPO")
                select new TEMPO
                {
                    Battito = (int)t.Attribute("Battito"),
                    Bpm = (float)t.Attribute("Bpm"),
                    Inizio = (float)t.Attribute("Inizio"),
                    Metro = (string)t.Attribute("Metro")
                }
                ).ToArray()
                       }
                       ).ToArray()

                  }
                 ).First(),
                 Playlists = (
                                 from e in x.Descendants("PLAYLISTS").Descendants("NODE")
                                 select new NODE
                                 {
                                     Count = (int?)e.Attribute("Count"),
                                     Entries = (int?)e.Attribute("Entries"),
                                     KeyType = (int?)e.Attribute("KeyType"),
                                     Name = (string)e.Attribute("Name"),
                                     Type = (int)e.Attribute("Type"),
                                     Tracks = (
                                     from t in e.Elements("TRACK")
                                     select new TRACKNODE
                                     {
                                         Key = (int)t.Attribute("Key")
                                     }
                                     ).ToArray()
                                 }
            ).ToArray()
             }).First();
            this.Version = djp.Version;
            this.Product = djp.Product;
            this.Playlists = djp.Playlists;
            this.Collection = djp.Collection;
        }

        /// <summary>
        /// List tracks ID not referenced in any playlist
        /// </summary>
        protected List<int> OrphansIDList
        {
            get
            {
                if (_Orphans == null)
                {
                    //Construction d'une liste à plat de toutes les tracks incluses dans les playlists
                    List<int> AllTracks = new List<int>();
                    foreach (NODE Playlist in Playlists)
                        foreach (TRACKNODE track in Playlist.Tracks)
                            AllTracks.Add(track.Key);

                    AllTracks = AllTracks.Distinct().ToList();
                    _Orphans = this.Collection.Tracks.Select(x => x.TrackID).Except(AllTracks).ToList();
                }
                return _Orphans;
            }
        }

        public List<TRACK> Duplicates
        {
            get
            {
                if(_Duplicates == null)
                {
                    var tmp = (from t in Collection.Tracks
                                 orderby t.Artist
                                 group t by new { t.Artist, t.Name } into grp
                                 select new { key = grp.Key, cnt = grp.Count() })
                                 .Where(x => x.cnt >1).ToList();

                    _Duplicates =
                        (
                        from t in Collection.Tracks
                        join s in tmp on new { t.Artist, t.Name } equals new { s.key.Artist, s.key.Name }
                        
                        select t)
                        .OrderBy(x => x.Artist)
                        .ThenBy(y=>y.Name)
                          .ToList();

                    }
                return _Duplicates;
            }
        }

        public List<TRACK> UnAnalyzed
        {
            get
            {
                if(_UnAnalyzed == null)
                {
                    _UnAnalyzed =
                        (
                        from t in Collection.Tracks
                        where t.PositionMark.Count() == 1
                        orderby t.Location
                        select t
                        ).ToList();
                }
                return _UnAnalyzed;
            }
        }

        /// <summary>
        /// List of tracks to properly tag :
        /// - Same title and same artist
        /// - No title and/or no artist
        /// </summary>
        public List<TRACK> Untagged
        {
            get
            {
                if(_Untagged == null)
                {
                    _Untagged =
                    (from t in Collection.Tracks
                     where t.Artist == t.Name
                        || string.IsNullOrWhiteSpace(t.Artist)
                        || string.IsNullOrWhiteSpace(t.Name)
                        || t.Name.ToUpperInvariant().Contains("VARIOUS")
                        || t.Artist.ToUpperInvariant().Contains("VARIOUS")
                    orderby t.Location
                    select t).ToList();
                }
                return _Untagged;
            }
            
        }

        public List<TRACK> Missing
        {
            get
            {
                if(_Missing == null)
                {
                    _Missing = new List<TRACK>();
                    foreach(TRACK t in Collection.Tracks.OrderBy(t=>t.Location))
                    {
                        if (!t.Exists)
                            _Missing.Add(t);
                    }
                }
                return _Missing;
            }
        }

        /// <summary>
        /// Recursively scans for music files present in a directory but absent from the Rekordbox Library
        /// </summary>
        /// <param name="Dir">Directory root</param>
        /// <returns></returns>
        public List<string> Unreferenced(string Dir)
        {
            return (
                from s in PlaylistHelper.MusicFiles(Dir)
                where !(from t in Collection.Tracks
                        select 
                        PlaylistHelper.LocationCleanUp(t.Location.ToUpper()))
                         .Contains(s.ToUpper())
                orderby s
                select s
                
                ).ToList();
        }

        


        /// <summary>
        /// Provides a new list of TRACK objects based on a list of Track IDs
        /// </summary>
        /// <param name="Tracks">List of track IDs</param>
        /// <returns>A list of full tracks</returns>
        public List<TRACK> NewPlaylist(List<int> Tracks)
        {
            List<TRACK> tmp = new List<TRACK>();
            foreach(int i in Tracks)
            {
                tmp.Add(
                    (from t in Collection.Tracks
                    where t.TrackID == i
                    orderby t.Location
                    select t).FirstOrDefault()
                    );
            }
            return tmp;
        }

        public List<TRACK> Orphans
        {
            get
            {
                return NewPlaylist(OrphansIDList);
            }
        }

        public long Size
        {
            get
            {
                return Collection.Tracks.Sum(t => (long)t.Size);
            }
        }

        private List<int> _Orphans = null;
        private List<TRACK> _Duplicates = null;
        private List<TRACK> _UnAnalyzed = null;
        private List<TRACK> _Missing = null;
        private List<TRACK> _Untagged = null;
    }

    public class PRODUCT
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Company { get; set; }
    }
    public class COLLECTION
    {
        public int Entries { get; set; }
        public TRACK[] Tracks { get; set; }
        public TRACKNODE[] Tracknodes
        {
            get
            {
                return (from t in this.Tracks
                 select new TRACKNODE
                 {
                     Key = t.TrackID
                 }).ToArray();
            }
        }
    }


    public class TRACK
    {
        
        public int TrackID { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Composer { get; set; }
        public string Album { get; set; }
        public string Grouping { get; set; }
        public string Genre { get; set; }
        public string Kind { get; set; }
        public int Size { get; set; }
        public int TotalTime { get; set; }
        public int DiscNumber { get; set; }
        public int TrackNumber { get; set; }
        public int Year { get; set; }
        public float AverageBpm { get; set; }
        public DateTime DateAdded { get; set; }
        public int BitRate { get; set; }
        public int SampleRate { get; set; }
        public string Comments { get; set; }
        public int PlayCount { get; set; }
        public int Rating { get; set; }
        public string Location { get; set; }
        public string Remixer { get; set; }
        public string Tonality { get; set; }
        public string Label { get; set; }
        public string Color { get; set; }
        public string Mix { get; set; }
        public TEMPO[] Tempo { get; set; }
        public POSITION_MARK[] PositionMark { get; set; }

        public bool Exists
        {
            get
            {
                return new FileInfo(PlaylistHelper.LocationCleanUp(Location)).Exists;
            }
        }
        
    }

    public class TEMPO
    {
        public float Inizio { get; set; }
        public float Bpm { get; set; }
        public string Metro { get; set; }
        public int Battito { get; set; }
    }

    public class POSITION_MARK
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public float Start { get; set; }
        public float? End { get; set; }
        public int Num { get; set; }
        public int? Red { get; set; }
        public int? Green { get; set; }
        public int? Blue { get; set; }
    }

    public class NODE
    {
        public int Type { get; set; }
        public string Name { get; set; }
        public int? Count { get; set; }
        public int? KeyType { get; set; }
        public int? Entries { get; set; }
        public NODE[] Nodes { get; set; }
        public TRACKNODE[] Tracks {get; set;}
    }

    public class TRACKNODE : IEqualityComparer<TRACKNODE>
    {
        public int Key { get; set; }

        public bool Equals(TRACKNODE x, TRACKNODE y)
        {
            return x.Key == y.Key;
        }

        public int GetHashCode(TRACKNODE obj)
        {
            return obj.GetHashCode();
        }
    }

}
