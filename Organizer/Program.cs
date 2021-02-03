using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.IO;

namespace Organizer
{
    static class Program
    {
        public static MySqlConnection Connection;

        public static Color Color { get; private set; }
        public static bool DarkTheme = true, IsAdmin;
        public static string Login, Language;
        public static int Year;

        private static Dictionary<string, Dictionary<string, string>> translations = new Dictionary<string, Dictionary<string, string>>();

        private const string connectionString = "Server=VH287.spaceweb.ru;" +
                                                ";Database= beavisabra_rasp" +
                                                ";port=3306;User Id=beavisabra_rasp;password=Beavis1989";

        [STAThread]
        static void Main()
        {
            Login = "Admin";//////////\\\\\\\\\\\\\\\

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Connection = new MySqlConnection(connectionString);
            Connection.Open();

            LoadYear();
            LoadOptions();
            LoadTranslations();

            Application.Run(new Main());

            Connection.Close();
        }

        public static List<string> Select(string Text, Dictionary<string, string> parameters = null)
        {
            List<string> results = new List<string>();

            MySqlCommand command = new MySqlCommand(Text, Connection);

            if (parameters != null)
                foreach (var pair in parameters)
                    command.Parameters.AddWithValue(pair.Key, pair.Value);

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
                for (int i = 0; i < reader.FieldCount; i++)
                    results.Add(reader.GetValue(i).ToString());

            reader.Close();

            return results;
        }

        public static Image SelectImage(string Text)
        {
            Image img = null;
            MySqlCommand command = new MySqlCommand(Text, Connection);

            try
            {
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //Предполагается, что в запросе 1 столбец, и в нем картинка
                    byte[] data = (byte[])reader.GetValue(0);
                    try
                    {
                        MemoryStream ms = new MemoryStream(data, 0, data.Length);
                        ms.Write(data, 0, data.Length);
                        img = Image.FromStream(ms, true);//Конвертируем в картинку
                    }
                    catch { }
                }
                reader.Close();
            }
            catch { }

            return img;
        }

        public static void Insert(string Text)
        {
            MySqlCommand command = new MySqlCommand(Text, Connection);

            command.ExecuteNonQuery();
        }

        public static string Translate(string key)
        {
            return translations[Language][key];
        }

        private static void LoadOptions()
        {
            List<string> options = Select($"SELECT Language, Color, DarkTheme, IsAdmin FROM Users Where Login = '{Login}'");

            Language = options[0];
            Color = Color.FromArgb(int.Parse(options[1]));
            DarkTheme = bool.Parse(options[2]);
            IsAdmin = bool.Parse(options[3]);
        }

        private static void LoadYear()
        {
            Year = DateTime.Today.Year - (9 <= DateTime.Today.Month && DateTime.Today.Month <= 12 ? 0 : 1);
        }

        private static void LoadTranslations()
        {
            List<string> languages = Select($"SELECT Name FROM Languages");

            foreach (var language in languages)
            {
                List<string> transList = Select($"SELECT TransKey, TransValue FROM Translations WHERE Language = '{language}'");
                Dictionary<string, string> dict = new Dictionary<string, string>();

                for (int i = 0; i < transList.Count; i += 2)
                    dict.Add(transList[i], transList[i + 1]);

                translations.Add(language, dict);
            }
        }
    }
}
