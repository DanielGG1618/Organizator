﻿using System;
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

            command.Dispose();

            return img;
        }

        public static void Insert(string Text)
        {
            MySqlCommand command = new MySqlCommand(Text, Connection);

            command.ExecuteNonQuery();

            command.Dispose();
        }
    }
}
