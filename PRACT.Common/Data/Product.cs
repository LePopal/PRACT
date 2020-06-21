using System;
using System.Collections.Generic;
using System.Text;

namespace PRACT.Common.Data
{
    [Serializable()]
    public class Product
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Company { get; set; }
        public Product()
        {

        }
    }
}
