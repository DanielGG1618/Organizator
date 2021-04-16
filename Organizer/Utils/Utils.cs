using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.IO;

namespace Organizer
{
    static class Utils
    {
        public static Bitmap GetControlScreenshot(Control control)
        {
            Bitmap bmp = new Bitmap(control.Width, control.Height);//создаем картинку нужных размеров
            control.DrawToBitmap(bmp, control.ClientRectangle);//копируем изображение нужного контрола в bmp

            return bmp;
        }

        public static void InDevelop()
        {
            MessageBox.Show(Localization.Translate("In the develop"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void NoEditMode()
        {
            MessageBox.Show(Localization.Translate("Doesn*t work in edit mode"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static bool IsWorkingOLD(DateTime date)
        {
            DateTime generalViewDate = new DateTime(4, date.Month, date.Day);

            bool isWorking = date.DayOfWeek != DayOfWeek.Sunday && date.DayOfWeek != DayOfWeek.Saturday &&
                    !(Main.PrimaryHolydays.Contains<DateTime>(generalViewDate) ||

                    Main.SecondaryHolydays.Contains<DateTime>(generalViewDate) ||

                    Main.ThisYearHolydays.Contains<DateTime>(date));

            if (isWorking)
                isWorking = (!Main.PrimaryHolydays.Contains<DateTime>(generalViewDate) &&
                     (Main.PrimaryHolydays.Contains<DateTime>(generalViewDate.AddDays(1)) ||
                     Main.PrimaryHolydays.Contains<DateTime>(generalViewDate.AddDays(-1)))) ||

                     date.DayOfWeek != DayOfWeek.Sunday && date.DayOfWeek != DayOfWeek.Saturday &&
                    !(Main.PrimaryHolydays.Contains<DateTime>(generalViewDate) ||

                    Main.SecondaryHolydays.Contains<DateTime>(generalViewDate) ||

                    Main.ThisYearHolydays.Contains<DateTime>(date));

            return isWorking;
        }

        public static bool IsWorking(DateTime day)
        {
            return !Holidays.Days.Contains(day);
        }
    }

    static class SQL
    {
        public static MySqlConnection Connection;

        public static List<string> Select(string text, Dictionary<string, string> parameters = null)
        {
            List<string> results = new List<string>();

            MySqlCommand command = new MySqlCommand(text, Connection);

            if (parameters != null)
                foreach (var pair in parameters)
                    command.Parameters.AddWithValue(pair.Key, pair.Value);

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
                for (int i = 0; i < reader.FieldCount; i++)
                    results.Add(reader.GetValue(i).ToString());

            reader.Close();

            command.Dispose();

            return results;
        }

        public static List<bool> SelectBools(string text, Dictionary<string, string> parameters = null)
        {
            List<string> listString = Select(text, parameters);
            List<bool> list = new List<bool>();

            foreach(var one in listString)
            {
                list.Add(bool.Parse(one));
            }

            return list;
        }

        /*public static List<Type> Select<Type>(string text, Dictionary<string, string> parameters = null)
        {
            List<string> listString = Select(text, parameters);
            List<Type> list = new List<Type>();

            foreach (var one in listString)
            {
                list.Add(Type.Parse(one));
            }

            return list;
        }*/

        public static Image SelectImage(string text)
        {
            Image img = null;
            MySqlCommand command = new MySqlCommand(text, Connection);

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

            command.Dispose();

            return img;
        }

        public static List<Image> SelectImages(string text)
        {
            List<Image> img = new List<Image>();
            MySqlCommand command = new MySqlCommand(text, Connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    byte[] data = (byte[])reader.GetValue(0);
                    try
                    {
                        MemoryStream ms = new MemoryStream(data, 0, data.Length);
                        ms.Write(data, 0, data.Length);
                        img.Add(Image.FromStream(ms, true));
                    }
                    catch
                    {
                        img.Add(null);
                    }
                }
            }
            reader.Close();

            command.Dispose();

            return img;
        }

        public static void Insert(string text)
        {
            MySqlCommand command = new MySqlCommand(text, Connection);

            command.ExecuteNonQuery();

            command.Dispose();
        }

        public static void UpdateFile(string text, string address)
        {
            using (FileStream pgFileStream = new FileStream(address, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader pgReader = new BinaryReader(new BufferedStream(pgFileStream)))
                {
                    MySqlCommand command = new MySqlCommand(text, Connection);

                    byte[] blob = pgReader.ReadBytes(Convert.ToInt32(pgFileStream.Length));

                    MySqlParameter param = command.CreateParameter();
                    param.ParameterName = "@File";
                    param.MySqlDbType = MySqlDbType.Blob;
                    param.Value = blob;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
