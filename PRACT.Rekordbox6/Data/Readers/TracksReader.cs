using PRACT.Common.Data;
using PRACT.Rekordbox6.Classes.Data;
using PRACT.Rekordbox6.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Text;

namespace PRACT.Rekordbox6.Data.Readers
{
    public class TracksReader : AbstractReader<Track>
    {
        public override List<Track> GetAll()
        {
            return Get(Queries.GetTracks());
        }
        public override List<Track> Get(string Query)
        {
            DbConnection dbConnection = _MasterDB.MasterDBConnection;

            using (var qry = dbConnection.CreateCommand())
            {
                qry.CommandText = this.Query;
                using (DbDataReader edr = qry.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    this.Result = new List<Track>();
                    while (edr.Read())
                    {
                        int i = 0;
                        Track t = new Track();
                        t.TrackID = DBNullHelper.SafeGetInt32(edr, i++);
                        t.Name = DBNullHelper.SafeGetString(edr, i++);
                        t.Composer = DBNullHelper.SafeGetString(edr, i++);
                        t.Album = DBNullHelper.SafeGetString(edr, i++);
                        t.Color = DBNullHelper.SafeGetString(edr, i++);
                        t.Genre = DBNullHelper.SafeGetString(edr, i++);
                        t.Kind = DBNullHelper.SafeGetString(edr, i++);
                        t.Size = DBNullHelper.SafeGetInt32(edr, i++);
                        t.TotalTime = DBNullHelper.SafeGetInt32(edr, i++);
                        t.DiscNumber = DBNullHelper.SafeGetInt32(edr, i++);
                        t.TrackNumber = DBNullHelper.SafeGetInt32(edr, i++);
                        t.Year = DBNullHelper.SafeGetInt32(edr, i++);
                        t.AverageBpm= DBNullHelper.SafeGetInt32(edr, i++);
                        t.SampleRate = DBNullHelper.SafeGetInt32(edr, i++);
                        t.Comments = DBNullHelper.SafeGetString(edr, i++);
                        t.Rating = DBNullHelper.SafeGetInt32(edr, i++);
                        t.Location = DBNullHelper.SafeGetString(edr, i++);
                        t.Remixer = DBNullHelper.SafeGetString(edr, i++);
                        t.Label = DBNullHelper.SafeGetString(edr, i++);
                        this.Result.Add(t);
                    }

                    return Result;
                }
            }
        }
        /// <summary>
        /// Gets every tracks
        /// </summary>
        public TracksReader(MasterDB masterDB): base(masterDB, Queries.GetTracks()) { }
    }
}
