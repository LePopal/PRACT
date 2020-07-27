using PRACT.Rekordbox6.Data.Readers;
using PRACT.Rekordbox6.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PRACT.Rekordbox6.Data
{
    public class Node : PRACT.Common.Data.Node
    {
        protected override List<PRACT.Common.Data.Node> GetNodes()
        {
            NodesReader nr = new NodesReader(new Classes.Data.MasterDB(ProgramSettings.PASSPHRASE_TO_MINE, ""), this.Id);
            return nr.GetAll();
        }

        protected override void GetTrackNodes()
        {
            throw new NotImplementedException();
        }
    }
}
