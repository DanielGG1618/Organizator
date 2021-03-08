using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Organizer
{
    public struct Day
    {
        public DateTime Date;
        private readonly DateTime generalViewDate;

        public int Num;

        public List<Lesson> Lessons;

        public Day(int num)
        {
            Num = num;

            Date = new DateTime(Program.Year, 9, 1).AddDays(Num);
            generalViewDate = new DateTime(4, Date.Month, Date.Day);

            Lessons = new List<Lesson>();

            for (int i = 0; i < Main.Schelude[(int)Date.DayOfWeek].Length; i++)
                Lessons.Add(new Lesson(i + 1, Main.Schelude[(int)Date.DayOfWeek][i]));
        }

        public Day(int num, List<Lesson> lessons)
        {
            this = new Day(num);

            Lessons = new List<Lesson>();

            for (int i = 0; i < lessons.Count; i++)
                Lessons.Add(lessons[i]);
        }

        public bool IsWorking()
        {
            bool isWorking = Date.DayOfWeek != DayOfWeek.Sunday && Date.DayOfWeek != DayOfWeek.Saturday &&
                    !(Main.PrimaryHolydays.Contains<DateTime>(generalViewDate) ||

                    Main.SecondaryHolydays.Contains<DateTime>(generalViewDate) ||

                    Main.ThisYearHolydays.Contains<DateTime>(Date));

            if (isWorking)
                isWorking = (!Main.PrimaryHolydays.Contains<DateTime>(generalViewDate) &&
                     (Main.PrimaryHolydays.Contains<DateTime>(generalViewDate.AddDays(1)) ||
                     Main.PrimaryHolydays.Contains<DateTime>(generalViewDate.AddDays(-1)))) ||

                     Date.DayOfWeek != DayOfWeek.Sunday && Date.DayOfWeek != DayOfWeek.Saturday &&
                    !(Main.PrimaryHolydays.Contains<DateTime>(generalViewDate) ||

                    Main.SecondaryHolydays.Contains<DateTime>(generalViewDate) ||

                    Main.ThisYearHolydays.Contains<DateTime>(Date));

            return isWorking;
        }

        public static string Totxt(Day day)
        {
            string txt = day.Num.ToString();

            foreach (var lesson in day.Lessons)
                txt += "░ " + Lesson.Totxt(lesson);

            return txt;
        }

        public static Day Fromtxt(string txt)
        {
            Day day;

            string[] dayLessons = txt.Split(new string[1] { "░ " }, StringSplitOptions.None);
            string[] splited = dayLessons[0].Split(new string[1] { "╫ " }, StringSplitOptions.None);

            List<Lesson> lessons = new List<Lesson>();

            for (int i = 1; i < dayLessons.Length; i++)
                lessons.Add(Lesson.Fromtxt(dayLessons[i]));

            for (int i = 2; i < splited.Length - 1; i++)
                lessons.Add(Lesson.Fromtxt(splited[i]));

            day = new Day(int.Parse(splited[0]), lessons);

            return day;
        }
    }

    public enum Roles { NotLogedIn, Regular, Moderator, Admin }
}
