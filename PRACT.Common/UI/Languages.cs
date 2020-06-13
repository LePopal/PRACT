using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRACT.Common.UI
{
    public static class Languages
    {
        public static Language GetLanguageByLocale(string locale)
        {
            return SupportedLanguages.Where(x => x.Locale == locale).FirstOrDefault();
        }
        public static List<Language> SupportedLanguages
        {
            get
            {
                if(_SupportedLanguages == null)
                {
                    _SupportedLanguages = new List<Language>();
                    _SupportedLanguages.Add(new Language() { Locale = "en", Name = "English" });
                    _SupportedLanguages.Add(new Language() { Locale = "fr", Name = "Français" });
                }
                return _SupportedLanguages;
            }
        }
        private static List<Language> _SupportedLanguages;

    }
    public class Language
    {
        public string Locale { get; set; }
        public string Name { get; set; }
    }
}
