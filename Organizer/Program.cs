using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Organizer.Properties;

namespace Organizer
{
    static class Program
    {
        public static int Year;

        [STAThread]
        static void Main() 
        {
            //Settings.Default.Role = Roles.Guest;
            //Settings.Default.Login = "Admin";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SQL.Connection = new MySql.Data.MySqlClient.MySqlConnection(
                "server=localhost;port=3306;uid=root;pwd=root;database=beavisabra_rasp;");
            SQL.Connection.Open();

            LoadYear();
            Localization.Load();

            Application.Run(new Main());

            SQL.Connection.Close();
        }

        private static void LoadYear()
        {
            Year = DateTime.Today.Year - (9 <= DateTime.Today.Month && DateTime.Today.Month <= 12 ? 0 : 1);
        }
    }
}
