using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Extensions.CommandLineUtils;
using PRACT.Classes;
using PRACT.Models;

namespace PRACT
{
    class Program
    {
        static void Main(string[] args)
        {
            //XDocument xdoc = 
            //    XDocument.Load(@"C:\Users\Axel\source\repos\PRACT\PRACT\Samples\pc.xml");

            //DJ_PLAYLISTS MyRkbXml = new DJ_PLAYLISTS();
            //MyRkbXml =
            //    (from x in xdoc.Descendants("DJ_PLAYLISTS")
            //     select new DJ_PLAYLISTS
            //     {
            //         Version = (string)x.Attribute("Version"),
            //         Product =
            //         (from p in x.Descendants("PRODUCT")
            //          select new PRODUCT
            //          {
            //              Company = (string)p.Attribute("Company"),
            //              Name = (string)p.Attribute("Name"),
            //              Version = (string)p.Attribute("Version")
            //          }).First(),
            //         Collection =
            //         (from c in x.Descendants("COLLECTION")
            //          select new COLLECTION
            //          {
            //              Entries = (int)c.Attribute("Entries"),
            //              Tracks =
            //              (from e in c.Descendants("TRACK")
            //               select new TRACK
            //               {
            //                   Album = (string)e.Attribute("Album"),
            //                   Artist = (string)e.Attribute("Artist"),
            //                   AverageBpm = (float)e.Attribute("AverageBpm"),
            //                   BitRate = (int)e.Attribute("BitRate"),
            //                   Color = (string)e.Attribute("Color"),
            //                   Comments = (string)e.Attribute("Comments"),
            //                   Composer = (string)e.Attribute("Composer"),
            //                   DateAdded = (DateTime)e.Attribute("DateAdded"),
            //                   DiscNumber = (int)e.Attribute("DiscNumber"),
            //                   Genre = (string)e.Attribute("Genre"),
            //                   Grouping = (string)e.Attribute("Grouping"),
            //                   Kind = (string)e.Attribute("Kind"),
            //                   Label = (string)e.Attribute("Label"),
            //                   Location = (string)e.Attribute("Location"),
            //                   Mix = (string)e.Attribute("Mix"),
            //                   Name = (string)e.Attribute("Name"),
            //                   PlayCount = (int)e.Attribute("PlayCount"),
            //                   Rating = (int)e.Attribute("Rating"),
            //                   Remixer = (string)e.Attribute("Remixer"),
            //                   SampleRate = (int)e.Attribute("SampleRate"),
            //                   Size = (int)e.Attribute("Size"),
            //                   Tonality = (string)e.Attribute("Tonality"),
            //                   TotalTime = (int)e.Attribute("TotalTime"),
            //                   TrackID = (int)e.Attribute("TrackID"),
            //                   TrackNumber = (int)e.Attribute("TrackNumber"),
            //                   Year = (int)e.Attribute("Year"),
            //                   PositionMark =
            //        (
            //            from p in e.Elements("POSITION_MARK")
            //            select new POSITION_MARK
            //            {
            //                Blue = (int?)p.Attribute("Blue"),
            //                End = (float?)p.Attribute("End"),
            //                Green = (int?)p.Attribute("Green"),
            //                Name = (string)p.Attribute("Name"),
            //                Num = (int)p.Attribute("Num"),
            //                Red = (int?)p.Attribute("Red"),
            //                Start = (float)p.Attribute("Start"),
            //                Type = (int)p.Attribute("Type")

            //            }
            //        ).ToArray(),
            //                   Tempo =
            //        (
            //        from t in e.Elements("TEMPO")
            //        select new TEMPO
            //        {
            //            Battito = (int)t.Attribute("Battito"),
            //            Bpm = (float)t.Attribute("Bpm"),
            //            Inizio = (float)t.Attribute("Inizio"),
            //            Metro = (string)t.Attribute("Metro")
            //        }
            //        ).ToArray()
            //               }
            //               ).ToArray()

            //          }
            //         ).First(),
            //         Playlists =(
            //                         from e in x.Descendants("PLAYLISTS").Descendants("NODE")
            //                         select new NODE
            //                         {
            //                             Count = (int?)e.Attribute("Count"),
            //                             Entries = (int?)e.Attribute("Entries"),
            //                             KeyType = (int?)e.Attribute("KeyType"),
            //                             Name = (string)e.Attribute("Name"),
            //                             Type = (int)e.Attribute("Type"),
            //                             Tracks = (
            //                             from t in e.Elements("TRACK")
            //                             select new TRACKNODE
            //                             {
            //                                 Key = (int)t.Attribute("Key")
            //                             }
            //                             ).ToArray()
            //                         }
            //    ).ToArray()
            //     }).First();

            //MyRkbXml.Collection.Tracks = (
            //    from e in xdoc.Descendants("DJ_PLAYLISTS").Descendants("COLLECTION").Descendants("TRACK")
            //    select new TRACK
            //    {
            //        Album = (string)e.Attribute("Album"),
            //        Artist = (string)e.Attribute("Artist"),
            //        AverageBpm = (float)e.Attribute("AverageBpm"),
            //        BitRate = (int)e.Attribute("BitRate"),
            //        Color = (string)e.Attribute("Color"),
            //        Comments = (string)e.Attribute("Comments"),
            //        Composer = (string)e.Attribute("Composer"),
            //        DateAdded = (DateTime)e.Attribute("DateAdded"),
            //        DiscNumber = (int)e.Attribute("DiscNumber"),
            //        Genre = (string)e.Attribute("Genre"),
            //        Grouping = (string)e.Attribute("Grouping"),
            //        Kind = (string)e.Attribute("Kind"),
            //        Label = (string)e.Attribute("Label"),
            //        Location = (string)e.Attribute("Location"),
            //        Mix = (string)e.Attribute("Mix"),
            //        Name = (string)e.Attribute("Name"),
            //        PlayCount = (int)e.Attribute("PlayCount"),
            //        Rating = (int)e.Attribute("Rating"),
            //        Remixer = (string)e.Attribute("Remixer"),
            //        SampleRate = (int)e.Attribute("SampleRate"),
            //        Size = (int)e.Attribute("Size"),
            //        Tonality = (string)e.Attribute("Tonality"),
            //        TotalTime = (int)e.Attribute("TotalTime"),
            //        TrackID = (int)e.Attribute("TrackID"),
            //        TrackNumber = (int)e.Attribute("TrackNumber"),
            //        Year = (int)e.Attribute("Year"),
            //        PositionMark =
            //        (
            //            from p in e.Elements("POSITION_MARK")
            //            select new POSITION_MARK
            //            {
            //                Blue = (int?)p.Attribute("Blue"),
            //                End  = (float?)p.Attribute("End"),
            //                Green = (int?)p.Attribute("Green"),
            //                Name = (string)p.Attribute("Name"),
            //                Num = (int)p.Attribute("Num"),
            //                Red = (int?)p.Attribute("Red"),
            //                Start = (float)p.Attribute("Start"),
            //                Type = (int)p.Attribute("Type")

            //            }
            //        ).ToArray(),
            //        Tempo =
            //        (
            //        from t in e.Elements("TEMPO")
            //        select new TEMPO
            //        {
            //            Battito = (int)t.Attribute("Battito"),
            //            Bpm=(float)t.Attribute("Bpm"),
            //            Inizio=(float)t.Attribute("Inizio"),
            //            Metro=(string)t.Attribute("Metro")
            //        }
            //        ).ToArray()
            //    }

            //    ).ToArray();

            //MyRkbXml.Playlists = (
            //    from e in xdoc.Descendants("DJ_PLAYLISTS").Descendants("PLAYLISTS").Descendants("NODE")
            //    select new NODE
            //    {
            //        Count = (int?)e.Attribute("Count"),
            //        Entries = (int?)e.Attribute("Entries"),
            //        KeyType = (int?)e.Attribute("KeyType"),
            //        Name = (string)e.Attribute("Name"),
            //        Type = (int)e.Attribute("Type"),
            //        Tracks = (
            //        from t in e.Elements("TRACK")
            //        select new TRACKNODE
            //        {
            //            Key= (int)t.Attribute("Key")
            //        }
            //        ).ToArray()
            //    }
            //    ).ToArray();

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            Console.WriteLine("Welcome to PRACT, the Popal's Rekordbox.xml Analysis and Clean up Tool, version {0}"
                , fvi.FileVersion);
            Console.WriteLine("Contact : popal@sboub.com");
            Console.WriteLine("");
            CommandLineApplication cmd = new CommandLineApplication();
            CommandOption argRkbXml = cmd.Option("-r | --rekordboxxml <value>", "Full path to the Rekordbox.xml file including the file"
                , CommandOptionType.SingleValue);
            CommandOption argOutputDir = cmd.Option("-o | --outputdir <value>", "Destination folder where to write the playlists"
                , CommandOptionType.SingleValue);

            
            cmd.OnExecute(() =>
            {
                if (argRkbXml.HasValue() && argOutputDir.HasValue())
                {
                    Console.WriteLine("Loading Rekordbox.xml file in {0}...", argRkbXml.Value());
                    DJ_PLAYLISTS m2 = new DJ_PLAYLISTS(argRkbXml.Value());
                    string Destination;
                    Destination = Path.Combine(argOutputDir.Value(), "Orphans.m3u8");
                    Console.WriteLine("Writing Orphans playlist in {0}...", Destination);
                    PlaylistHelper.WritePlaylist(m2.Orphans, Destination);
                    Destination = Path.Combine(argOutputDir.Value(), "Duplicates.m3u8");
                    Console.WriteLine("Writing Duplicates playlist in {0}...", Destination);
                    PlaylistHelper.WritePlaylist(m2.Duplicates, Destination);
                    Destination = Path.Combine(argOutputDir.Value(), "Unanalyzed.m3u8");
                    Console.WriteLine("Writing Unanalyzed playlist in {0}...", Destination);
                    PlaylistHelper.WritePlaylist(m2.UnAnalyzed, Destination);
                    Console.WriteLine("Job's finished !");
                    //Console.WriteLine(argRkbXml.Value());
                    return 0;
                }
                else
                {
                    cmd.ShowHelp();
                    return -1;
                }
            });
            cmd.Name = "Name";
            cmd.HelpOption("-? | -h | --help");
            cmd.Execute(args);
            


            //Console.ReadLine();
        }
    }
}
