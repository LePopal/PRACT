using PRACT.Rekordbox6.Classes.Data;
using PRACT.Rekordbox6.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace PRACT.Rekordbox6.Data.Readers
{
    public class NodesReader : AbstractReader<PRACT.Common.Data.Node>
    {
        public override List<PRACT.Common.Data.Node> GetAll()
        {
            DbConnection dbConnection = _MasterDB.MasterDBConnection;

            using (var qry = dbConnection.CreateCommand())
            {
                qry.CommandText = this.Query;
                StringBuilder sb = new StringBuilder();
                using (DbDataReader edr = qry.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    this.Result = new List<PRACT.Common.Data.Node>();
                    while (edr.Read())
                    {
                        int i = 0;
                        Node n = new Node();
                        n.Id = DBNullHelper.SafeGetInt32(edr, i++);
                        i++;

                        n.Name = DBNullHelper.SafeGetString(edr, i++);
                        n.KeyType = DBNullHelper.SafeGetInt32(edr, i++);

                        this.Result.Add(n);
                    }

                    return Result;
                }
            }
        }
        public NodesReader(MasterDB masterDB, int nodeID) : base(masterDB, Queries.GetSubPlaylistTree(nodeID)) { }
    }
}
