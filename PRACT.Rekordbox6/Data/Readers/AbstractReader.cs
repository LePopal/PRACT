using PRACT.Rekordbox6.Classes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PRACT.Rekordbox6.Data.Readers
{
    public abstract class AbstractReader<T>
    {
        public abstract List<T> GetAll();
        public abstract List<T> Get(string query);
        public AbstractReader(MasterDB masterDB, string query)
        {
            this._MasterDB = masterDB;
            this.Query = query;
        }
        public AbstractReader(MasterDB masterDB)
        {
            this._MasterDB = masterDB;
        }
        protected List<T> Result { get; set; }
        protected string Query { get; set; }
        [DefaultValue(null)]
        protected MasterDB _MasterDB { get; set; }
    }
}
