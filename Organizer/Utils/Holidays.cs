using System;
using System.IO;
using System.Net;
using System.Windows;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organizer.Properties;

namespace Organizer
{
    static class Holidays
    {
        public static List<DateTime> Days = new List<DateTime>();

        private static int firstDBindex;

        public static void Load()
        {
            int month = DateTime.Today.Month;
            int year = DateTime.Today.Year;

            Days.AddRange(GetHolidays(year));

            if (12 >= month && month >= 9)
                Days.AddRange(GetHolidays(year + 1));

            else
                Days.AddRange(GetHolidays(year - 1));

            firstDBindex = Days.Count;

            List<string> dbHolidays = SQL.Select($"SELECT DateFrom, DateTo FROM Holidays WHERE Class = '{Settings.Default.Class}'");

            for (int i = 0; i < dbHolidays.Count; i += 2)
            {
                DateTime dateFrom = DateTime.Parse(dbHolidays[i]);
                DateTime dateTo = DateTime.Parse(dbHolidays[i + 1]);

                for (DateTime date = dateFrom; date <= dateTo; date = date.AddDays(1))
                    Days.Add(date);
            }
        }

        public static List<DateTime> GetHolidays(int year)
        {
            List<DateTime> days = new List<DateTime>();

            HtmlWeb webGet = new HtmlWeb();

            HtmlDocument document = webGet.Load("http://www.consultant.ru/law/ref/calendar/proizvodstvennye/" + year);
            
            var blocks = document.DocumentNode.SelectNodes("//div[contains(@class, 'col-md-3')]");
            foreach(HtmlNode block in blocks)
            {
                var currentMonthNode = HtmlNode.CreateNode(block.InnerHtml);
                var month = currentMonthNode.SelectNodes("//th[contains(@class, 'month')]");
                
                if (month != null)
                {
                    int monthNum = 1;
                    var nodes = currentMonthNode.SelectNodes("//td[contains(@class, 'holiday weekend')]");
                    if (nodes == null)
                        nodes = new HtmlNodeCollection(currentMonthNode);
                    foreach (var node in currentMonthNode.SelectNodes("//td[contains(@class, 'weekend')]"))
                        nodes.Add(node);

                    switch (month[0].InnerText)
                    {
                        case "Январь":
                            monthNum = 1;
                            break;
                        case "Февраль":
                            monthNum = 2;
                            break;
                        case "Март":
                            monthNum = 3;
                            break;
                        case "Апрель":
                            monthNum = 4;
                            break;
                        case "Май":
                            monthNum = 5;
                            break;
                        case "Июнь":
                            monthNum = 6;
                            break;
                        case "Июль":
                            monthNum = 7;
                            break;
                        case "Август":
                            monthNum = 8;
                            break;
                        case "Сентябрь":
                            monthNum = 9;
                            break;
                        case "Октябрь":
                            monthNum = 10;
                            break;
                        case "Ноябрь":
                            monthNum = 11;
                            break;
                        case "Декабрь":
                            monthNum = 12;
                            break;
                    }

                    foreach(var node in nodes)
                        days.Add(new DateTime(year, monthNum, int.Parse(node.InnerText)));
                }
            }

            return days;
        }

        public static void Add(DateTime dateFrom, DateTime dateTo)
        {
            SQL.Insert($"INSERT INTO Holidays (DateFrom, DateTo, Class) " +
                $"VALUES ('{dateFrom.ToString("yyyy-MM-dd")}', '{dateTo.ToString("yyyy-MM-dd")}', '{Settings.Default.Class}')");
        }

        public static void Delete(DateTime dateFrom, DateTime dateTo)
        {
            SQL.Insert($"DELETE FROM Holidays WHERE DateFrom = '{dateFrom.ToString("yyyy-MM-dd")}' AND " +
                $"DateTo = '{dateTo.ToString("yyyy-MM-dd")}' AND Class = '{Settings.Default.Class}'");
        }

        public static bool AlreadyHasBeenAdded(DateTime dateFrom, DateTime dateTo)
        {
            return SQL.Select($"SELECT Class FROM Holidays WHERE DateFrom = '{dateFrom.ToString("yyyy-MM-dd")}' AND " +
                $"DateTo = '{dateTo.ToString("yyyy-MM-dd")}' AND Class = '{Settings.Default.Class}'").Count == 1;
        }

        public static void ReloadDBHolidays()
        {
            Days.RemoveRange(firstDBindex, Days.Count - firstDBindex);
            
            List<string> dbHolidays = SQL.Select($"SELECT DateFrom, DateTo FROM Holidays WHERE Class = '{Settings.Default.Class}'");

            for (int i = 0; i < dbHolidays.Count; i += 2)
            {
                DateTime dateFrom = DateTime.Parse(dbHolidays[i]);
                DateTime dateTo = DateTime.Parse(dbHolidays[i + 1]);

                for (DateTime date = dateFrom; date <= dateTo; date = date.AddDays(1))
                    Days.Add(date);
            }
        }
    }
}
