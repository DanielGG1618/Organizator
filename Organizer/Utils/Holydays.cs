using System;
using System.IO;
using System.Net;
using System.Windows;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer
{
    static class Holidays
    {
        public static List<DateTime> Days = new List<DateTime>();

        public static void Load()
        {
            int month = DateTime.Today.Month;
            int year = DateTime.Today.Year;

            Days.AddRange(GetHolidays(year));

            if (12 >= month && month >= 9)
                Days.AddRange(GetHolidays(year + 1));

            else
                Days.AddRange(GetHolidays(year - 1));
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
    }
}
