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
    class Holydays
    {
        public static HtmlNodeCollection Method()
        {
            HtmlWeb webGet = new HtmlWeb();

            HtmlDocument document = webGet.Load("http://www.consultant.ru/law/ref/calendar/proizvodstvennye/"
                + DateTime.Today.Year.ToString() + "/");

            return document.DocumentNode.SelectNodes("//div[contains(@class, 'newspost__content')]");
        }
    }
}
