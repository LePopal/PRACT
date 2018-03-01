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
                    Console.WriteLine("Writing Orphans playlist to {0}...", Destination);
                    PlaylistHelper.WritePlaylist(m2.Orphans, Destination);
                    Destination = Path.Combine(argOutputDir.Value(), "Duplicates.m3u8");
                    Console.WriteLine("Writing Duplicates playlist to {0}...", Destination);
                    PlaylistHelper.WritePlaylist(m2.Duplicates, Destination);
                    Destination = Path.Combine(argOutputDir.Value(), "Unanalyzed.m3u8");
                    Console.WriteLine("Writing Unanalyzed playlist to {0}...", Destination);
                    PlaylistHelper.WritePlaylist(m2.UnAnalyzed, Destination);
                    Destination = Path.Combine(argOutputDir.Value(), "Missing.m3u8");
                    Console.WriteLine("Writing Missing playlist to {0}...", Destination);
                    PlaylistHelper.WritePlaylist(m2.Missing, Destination);
                    Destination = Path.Combine(argOutputDir.Value(), "Untagged.m3u8");
                    Console.WriteLine("Writing Untagged playlist to {0}...", Destination);
                    PlaylistHelper.WritePlaylist(m2.Untagged, Destination);
                    Console.WriteLine("Job's finished !");
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
        }
    }
}
