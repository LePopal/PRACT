using Microsoft.Extensions.CommandLineUtils;
using PRACT.Models;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Linq;
using System.IO;
using PRACT.Classes;

namespace PRACT
{
    class Program
    {

        private const string PLAYLIST_TOKEN_MISSING = "m";
        private const string PLAYLIST_TOKEN_UNREFERENCED = "r";
        private const string PLAYLIST_TOKEN_UNTAGGED = "t";
        private const string PLAYLIST_TOKEN_ORPHANS = "o";
        private const string PLAYLIST_TOKEN_DUPLICATES = "d";
        private const string PLAYLIST_TOKEN_UNANALYZED = "a";

        private const string COMMAND_GENERATE_PLAYLISTS = "p";
        private const string COMMAND_SHOW_STATISTICS = "s";
        private const string COMMAND_GENERATE_SCRIPTS = "b";

        static void Main(string[] args)
        {

            #region CommandLine management
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            Console.WriteLine("Welcome to PRACT, the Popal's Rekordbox Analysis and Clean up Tool, version {0}", fvi.FileVersion);
            Console.WriteLine("Contact : dj@popal.fr");
            Console.WriteLine("");

            CommandLineApplication cmd = new CommandLineApplication();

            cmd.Name = "PRACT";
            cmd.Description = string.Format("Welcome to PRACT, {1}, version {0}"
                , fvi.FileVersion
                , fvi.FileDescription);
            cmd.ExtendedHelpText = @"Example : PRACT -r c:\temp\rb.xml -l mortad -o c:\temp -m c:\Music";
            CommandOption argRkbXml = cmd.Option("-r | --rekordboxxml <value>", "Full path to the Rekordbox.xml file including the file"
                , CommandOptionType.SingleValue);
            CommandOption argPlaylists = cmd.Option("-l | --playlists <value>"
                , string.Format("The M3U8 playlists to generate : " +
                                "\n\t{0} = Orphans (tracks in the library but in no playlists at all), " +
                                "\n\t{1} = Duplicates (tracks with same artist and same title), " +
                                "\n\t{2} = UnAnalyzed (tracks with at most 1 memory cue)," +
                                "\n\t{3} = missing (tracks referenced in library butnot found on disk), " +
                                "\n\t{4} = UnTagged (tracks with no title or no artist or the same value for both title and artist), " +
                                "\n\t{5} = UnReferenced (tracks found on disk but not in the Rekordbox library)"
                    , PLAYLIST_TOKEN_ORPHANS
                    , PLAYLIST_TOKEN_DUPLICATES
                    , PLAYLIST_TOKEN_UNANALYZED
                    , PLAYLIST_TOKEN_MISSING
                    , PLAYLIST_TOKEN_UNTAGGED
                    , PLAYLIST_TOKEN_UNREFERENCED)
                , CommandOptionType.SingleValue);
            CommandOption argOutputDir = cmd.Option("-o | --outputdir <value>", "Destination folder where to write the playlists"
                , CommandOptionType.SingleValue);
            CommandOption argMusicDir = cmd.Option("-m | --musicdir <value>", "Root folder containing music files"
                , CommandOptionType.SingleValue);
            CommandOption argCommand = cmd.Option("-c | --command <value>"
                    , string.Format("What to do :" +
                                    "\n\t{0} = Generate playlists (default), " +
                                    "\n\t{1} = Show Statistics"
                                    , COMMAND_GENERATE_PLAYLISTS
                                    , COMMAND_SHOW_STATISTICS
                                    , COMMAND_GENERATE_SCRIPTS)
                    , CommandOptionType.SingleValue);
            cmd.HelpOption("-? | -h | --help");
            cmd.VersionOption("-v | --version", fvi.FileVersion);
            #endregion

            cmd.OnExecute(() =>
            {
                Parameters prms;
                int returnValue = ProcessRbXml(argRkbXml, argCommand, argOutputDir, argPlaylists, argMusicDir, out prms);
                switch(returnValue)
                {
                    case -1:
                        Console.WriteLine("An error occured, check your command line arguments");
                        cmd.ShowHelp();
                        break;
                    case 0:
                        Console.WriteLine("Job's finished successully!");
                        break;
                }
                return returnValue;

            });


            cmd.Execute(args);


        }

        static int ProcessRbXml(CommandOption argRkbXml, CommandOption argCommand, CommandOption argOutputDir, CommandOption argPlaylists,
            CommandOption argMusicDir, out Parameters parameters)
        {
            Parameters prms = new Parameters();
            if (argRkbXml.HasValue())
            {
                prms.InputRekordboxXML = argRkbXml.Value();
                prms.ShowStatisticsCommand = argCommand.HasValue() && argCommand.Value() == COMMAND_SHOW_STATISTICS;
                prms.GeneratePlaylistsCommand = argCommand.HasValue() && argCommand.Value() == COMMAND_GENERATE_PLAYLISTS;
                prms.GenerateScriptsCommand = argCommand.HasValue() && argCommand.Value() == COMMAND_GENERATE_PLAYLISTS;

                if (argPlaylists.HasValue() && argOutputDir.HasValue())
                {
                    string Playlists = argPlaylists.Value().ToLowerInvariant();
                    prms.GeneratePlaylistsCommand = true;
                    prms.OutputDirectory = argOutputDir.Value();
                    prms.OrphanedPlaylistOption = Playlists.Contains(PLAYLIST_TOKEN_ORPHANS);
                    prms.DuplicatePlaylistOption = Playlists.Contains(PLAYLIST_TOKEN_DUPLICATES);
                    prms.UnanalyzedPlaylistOption = Playlists.Contains(PLAYLIST_TOKEN_UNANALYZED);
                    prms.MissingPlaylistOption = Playlists.Contains(PLAYLIST_TOKEN_MISSING);
                    prms.UntaggedPlaylistOption = Playlists.Contains(PLAYLIST_TOKEN_UNTAGGED);
                    prms.UnreferencedPlaylistOption = Playlists.Contains(PLAYLIST_TOKEN_UNREFERENCED);
                }

                Console.WriteLine("Loading Rekordbox.xml file in {0}...", argRkbXml.Value());
                DJ_PLAYLISTS m2 = new DJ_PLAYLISTS(argRkbXml.Value());

                Console.WriteLine("{0} track(s) loaded !", m2.Collection.Tracks.Length.ToString());
                Console.WriteLine("{0} Playlists loaded !", m2.Playlists.Where(p => p.Type == 1).Count().ToString());
                Console.WriteLine("Starting analysis...");

                if (argCommand.HasValue() && argCommand.Value() == COMMAND_SHOW_STATISTICS)
                {
                    Console.WriteLine("Calculating music library files size...");
                    Console.WriteLine("Total size : {0} Bytes", m2.Size);
                }
                else if (argPlaylists.HasValue() && argOutputDir.HasValue())
                {
                    string Playlists = argPlaylists.Value().ToLowerInvariant();
                    string Destination;
                    if (Playlists.Contains(PLAYLIST_TOKEN_ORPHANS))
                    {
                        Destination = Path.Combine(argOutputDir.Value(), "Orphans.m3u8");
                        Console.WriteLine("Writing Orphans playlist to {0}...", Destination);
                        PlaylistHelper.WritePlaylist(m2.Orphans, Destination);
                    }

                    if (Playlists.Contains(PLAYLIST_TOKEN_DUPLICATES))
                    {
                        Destination = Path.Combine(argOutputDir.Value(), "Duplicates.m3u8");
                        Console.WriteLine("Writing Duplicates playlist to {0}...", Destination);
                        PlaylistHelper.WritePlaylist(m2.Duplicates, Destination);
                    }

                    if (Playlists.Contains(PLAYLIST_TOKEN_UNANALYZED))
                    {
                        Destination = Path.Combine(argOutputDir.Value(), "Unanalyzed.m3u8");
                        Console.WriteLine("Writing Unanalyzed playlist to {0}...", Destination);
                        PlaylistHelper.WritePlaylist(m2.UnAnalyzed, Destination);
                    }

                    if (Playlists.Contains(PLAYLIST_TOKEN_MISSING))
                    {

                        Destination = Path.Combine(argOutputDir.Value(), "Missing.m3u8");
                        Console.WriteLine("Writing Missing playlist to {0}...", Destination);
                        PlaylistHelper.WritePlaylist(m2.Missing, Destination);

                    }

                    if (Playlists.Contains(PLAYLIST_TOKEN_UNTAGGED))
                    {
                        Destination = Path.Combine(argOutputDir.Value(), "Untagged.m3u8");
                        Console.WriteLine("Writing Untagged playlist to {0}...", Destination);
                        PlaylistHelper.WritePlaylist(m2.Untagged, Destination);
                    }

                    if (Playlists.Contains(PLAYLIST_TOKEN_UNREFERENCED))
                    {
                        if (argMusicDir.HasValue())
                        {
                            Destination = Path.Combine(argOutputDir.Value(), "Unreferenced.m3u8");
                            Console.WriteLine("Writing Unreferenced playlist to {0}...", Destination);
                            PlaylistHelper.WritePlaylist(m2.Unreferenced(argMusicDir.Value()), Destination);
                        }
                        else
                            Console.WriteLine("Ignoring Missing playlist : no music folder provided !");
                    }
                }
                parameters = prms;

                return 0;
            }
            else
            {
                parameters = null;
                return -1;
            }
        }

    }
}
