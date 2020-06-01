using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace PRACT.Classes
{
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public class Options
    {
        public Dictionary<string, bool> OptionsList { get; set; }
        public Options()
        {

        }
    }
}
