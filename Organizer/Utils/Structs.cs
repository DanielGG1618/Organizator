using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Organizer
{
    /*public struct Day
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
                    !(Main.PrimaryHolidays.Contains<DateTime>(generalViewDate) ||

                    Main.SecondaryHolidays.Contains<DateTime>(generalViewDate) ||

                    Main.ThisYearHolidays.Contains<DateTime>(Date));

            if (isWorking)
                isWorking = (!Main.PrimaryHolidays.Contains<DateTime>(generalViewDate) &&
                     (Main.PrimaryHolidays.Contains<DateTime>(generalViewDate.AddDays(1)) ||
                     Main.PrimaryHolidays.Contains<DateTime>(generalViewDate.AddDays(-1)))) ||

                     Date.DayOfWeek != DayOfWeek.Sunday && Date.DayOfWeek != DayOfWeek.Saturday &&
                    !(Main.PrimaryHolidays.Contains<DateTime>(generalViewDate) ||

                    Main.SecondaryHolidays.Contains<DateTime>(generalViewDate) ||

                    Main.ThisYearHolidays.Contains<DateTime>(Date));

            return isWorking;
        }
    }*/

    public enum Roles { NotLogedIn, Regular, Moderator, Admin }
}
