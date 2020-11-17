using System;
using System.Collections.Generic;
using System.Text;

namespace PRACT.Rekordbox6.Classes.Data
{
    public class Queries
    {
		public const string QRY_ON_AIR = @"select 
											h.ID,
											h.created_at, 
											c.FolderPath, 
											c.Title as TrackTitle, 
											a.Name as ArtistName,
											c.ImagePath,
											c.BPM,
											c.Rating,
											c.ReleaseYear,
											c.ReleaseDate,
											c.Length,
											c.ColorID,
											c.Commnt as TrackComment,
											co.Commnt as ColorName,
											al.Name as AlbumName,
											la.Name as LabelName,
											ge.Name as GenreName,
											k.ScaleName as KeyName,
											rmx.Name as RemixerName,
											c.DeliveryComment as Message
										from djmdSongHistory as h
										join djmdContent as c on h.ContentID = c.ID
										left join djmdColor as co on c.ColorID=co.id
										left join djmdArtist as a on c.ArtistID = a.ID
										left join djmdArtist as rmx on c.RemixerID = rmx.ID
										left join djmdAlbum as al on c.AlbumID = al.ID
										left join djmdLabel as la on c.LabelID = la.ID
										left join djmdGenre as ge on c.GenreID = ge.ID
										left join djmdKey as k on c.KeyID=k.ID
										order by h.created_at desc
										limit 2";
		public static string GetSubPlaylistTree(int ParentID)
        {
			return $"select ID, Seq, Name, Attribute from djmdPlaylist where ParentId = { ParentID } order by Seq";
        }

		public static string GetPlaylistTracks(int PlaylistID)
        {
			return $"select ContentID from djmdSongPlaylist as sp where PlaylistID = { PlaylistID } order by TrackNo";

		}

		public static string GetTracks()
        {
			return @"select 
											c.id,
											c.MasterSongID,
											c.Title as TrackTitle, 
											a.Name as ArtistName,
											comp.Name as ComposerName,
											al.Name as AlbumName,
											co.Commnt as ColorName,
											ge.Name as GenreName,
											""MP3 File"" as Kind,
											FileSize,
											c.length as TotalTime,
											c.DiscNo as DiscNumber,
											c.TrackNo as TrackNumber,
											c.ReleaseYear as Year,
											c.BPM,
											c.DateCreated,
											c.BitRate,
											c.SampleRate,
											c.Commnt as TrackComment,
											c.Rating,
											c.FolderPath, 
											rmx.Name as RemixerName,
											k.ScaleName as Tonality,
											la.Name as LabelName,
											c.ColorID,
											c.DeliveryComment as Message
										from
										djmdContent as c
										left join djmdColor as co on c.ColorID = co.id
										left join djmdArtist as a on c.ArtistID = a.ID
										left join djmdArtist as rmx on c.RemixerID = rmx.ID
										left join djmdAlbum as al on c.AlbumID = al.ID
										left join djmdLabel as la on c.LabelID = la.ID
										left join djmdGenre as ge on c.GenreID = ge.ID
										left join djmdKey as k on c.KeyID = k.ID
										left join djmdArtist as comp on c.ComposerID = comp.ID";
        }

		public static string GetCues(int contentID)
        {
			return $"select Comment as Name,Kind as Num,InMsec as Start,0 as Type from djmdcue where contentid = { contentID }";
		}

		// TODO
		public const string QRY_TRACKS_COMPLETE = "";

		// TODO
		public const string QRY_DUPLICATES = "";

		// TODO
		public const string QRY_ORPHANS = "";

		// TODO
		public const string QRY_UNANALYZED = "";

		// TODO
		public const string QRY_UNTAGGED = "";


	}
}
