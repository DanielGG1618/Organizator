using Organizer.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer
{
    static class Localization
    {
        private static Dictionary<string, Dictionary<string, string>> translations = new Dictionary<string, Dictionary<string, string>>();

        public static string Translate(string key)
        {
            try { return translations[Settings.Default.Language][key]; }
            catch { return "ошибка перевода, пж, сообщите"; }
        }

        public static void Load()
        {
            List<string> languages = SQL.Select($"SELECT Name FROM Languages");

            foreach (var language in languages)
            {
                List<string> transList = SQL.Select($"SELECT TransKey, TransValue FROM Translations WHERE Language = '{language}'");
                Dictionary<string, string> dict = new Dictionary<string, string>();

                for (int i = 0; i < transList.Count; i += 2)
                    dict.Add(transList[i], transList[i + 1]);

                translations.Add(language, dict);
            }
        }
    }
}
