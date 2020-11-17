﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace PRACT.Rekordbox6.Helpers
{
    public static class DBNullHelper
    {
        public static string SafeGetString(DbDataReader dr, int ord)
        { 
            return dr.IsDBNull(ord) ? string.Empty : dr.GetString(ord);
        }

        public static Int32 SafeGetInt32(DbDataReader dr, int ord)
        {
            return dr.IsDBNull(ord) ? Int32.MinValue : dr.GetInt32(ord);
        }
    }
}
