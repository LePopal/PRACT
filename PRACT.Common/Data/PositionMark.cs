using System;
using System.Collections.Generic;
using System.Text;

namespace PRACT.Common.Data
{
    [Serializable()]
    public class PositionMark
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public float Start { get; set; }
        public float? End { get; set; }
        public int Num { get; set; }
        public int? Red { get; set; }
        public int? Green { get; set; }
        public int? Blue { get; set; }
    }
}
