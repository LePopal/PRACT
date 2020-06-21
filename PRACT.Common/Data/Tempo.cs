using System;
using System.Collections.Generic;
using System.Text;

namespace PRACT.Common.Data
{
    [Serializable()]
    public class Tempo
    {
        public float Inizio { get; set; }
        public float Bpm { get; set; }
        public string Metro { get; set; }
        public int Battito { get; set; }
    }
}
