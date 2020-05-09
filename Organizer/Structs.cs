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

        public bool IsWorking;
        public int Num;
        public int Year;

        public List<Lesson> Lessons;

        public Day(int num, int year)
        {
            Num = num;
            Year = year;

            Date = new DateTime(Year, 9, 1).AddDays(Num);
            generalViewDate = new DateTime(4, Date.Month, Date.Day);

            IsWorking = Date.DayOfWeek != DayOfWeek.Sunday && Date.DayOfWeek != DayOfWeek.Saturday;

            if (IsWorking)
            {
                /*if (Head.PrimaryHolydays.Contains<DateTime>(generalViewDate))
                {
                    IsWorking = false;
                }

                else if (Head.PrimaryHolydays.Contains<DateTime>(generalViewDate.AddDays(1)) ||
                         Head.PrimaryHolydays.Contains<DateTime>(generalViewDate.AddDays(-1)))
                {
                    IsWorking = false;
                }

                if (Head.SecondaryHolydays.Contains<DateTime>(generalViewDate))
                {
                    IsWorking = false;
                }

                if (Head.ThisYearHolydays.Contains<DateTime>(Date))
                {
                    IsWorking = false;
                }*/

                IsWorking = !(Head.PrimaryHolydays.Contains<DateTime>(generalViewDate) ||

                              (!Head.PrimaryHolydays.Contains<DateTime>(generalViewDate) &&
                              (Head.PrimaryHolydays.Contains<DateTime>(generalViewDate) ||
                              Head.PrimaryHolydays.Contains<DateTime>(generalViewDate.AddDays(-1)))) ||

                              Head.SecondaryHolydays.Contains<DateTime>(generalViewDate) ||

                              Head.ThisYearHolydays.Contains<DateTime>(Date));
            }

            Lessons = new List<Lesson>();

            for (int i = 0; i < Head.Schedule[(int)Date.DayOfWeek].Length; i++)
                Lessons.Add(new Lesson(i + 1, Head.CellSize, Head.Color, Head.Schedule[(int)Date.DayOfWeek][i]));
        }

        public Day(int num, int year, List<Lesson> lessons)
        {
            this = new Day(num, year);

            Lessons = new List<Lesson>();

            for (int i = 0; i < lessons.Count; i++)
                Lessons.Add(lessons[i]);
        }

        public static string ToCSV(Day day)
        {
            string CSV = day.Num + "╫ " + day.Year;

            foreach (var lesson in day.Lessons)
                CSV += "░ " + Lesson.ToCSV(lesson);

            return CSV;
        }

        public static Day FromCSV(string CSV)
        {
            Day day;

            string[] dayLessons = CSV.Split(new string[1] { "░ " }, StringSplitOptions.None);
            string[] splited = dayLessons[0].Split(new string[1] { "╫ " }, StringSplitOptions.None);

            List<Lesson> lessons = new List<Lesson>();

            for (int i = 1; i < dayLessons.Length; i++)
                lessons.Add(Lesson.FromCSV(dayLessons[i]));

            for (int i = 2; i < splited.Length - 1; i++)
                lessons.Add(Lesson.FromCSV(splited[i]));

            day = new Day(int.Parse(splited[0]), int.Parse(splited[1]), lessons);

            return day;
        }

        public static DateTime DateSubtract(DateTime a, DateTime b)
        {
            return DateTime.FromBinary(a.ToBinary() - b.ToBinary());
        }
    }

    public struct Lesson
    {
        public Label NumLabel, TitleLabel, WorkLabel;
        public Button AddWorkButton;

        public int Num;
        public string Title;
        public Dictionary<string, string> WorkList;

        public bool Enabled;

        public void LoadWithSamples(int cellSize, Color color)
        {
            NumLabel.Size = new Size(50, cellSize);
            NumLabel.TextAlign = ContentAlignment.MiddleCenter;
            NumLabel.Font = new Font("Microsoft Sans Serif", 36, FontStyle.Bold);
            NumLabel.ForeColor = color;

            TitleLabel.Size = new Size(650, (int)(cellSize * 2 / 7f));//
            TitleLabel.TextAlign = ContentAlignment.MiddleLeft;
            TitleLabel.Font = new Font("Microsoft Sans Serif", 12);
            TitleLabel.ForeColor = Color.White;

            WorkLabel.Size = new Size(650, (int)(cellSize * 5 / 7f));//
            WorkLabel.TextAlign = ContentAlignment.MiddleLeft;
            WorkLabel.Font = new Font("Microsoft Sans Serif", 12);
            WorkLabel.ForeColor = Color.White;

            AddWorkButton.Size = new Size(cellSize - 20, cellSize - 20);//
            AddWorkButton.FlatStyle = FlatStyle.Flat;
            AddWorkButton.TextAlign = ContentAlignment.MiddleCenter;
            AddWorkButton.Font = new Font("Microsoft Sans Serif", 30, FontStyle.Bold);
            AddWorkButton.ForeColor = Color.LimeGreen;
            AddWorkButton.Text = "+";
            AddWorkButton.Visible = false;
        }

        public Lesson(int num, int cellSize, Color color)
        {
            Num = num;

            NumLabel = new Label();
            TitleLabel = new Label();
            WorkLabel = new Label();
            AddWorkButton = new Button();
            WorkList = new Dictionary<string, string> { { "Default", "" } };
            Enabled = true;
            Title = "";

            LoadWithSamples(cellSize, color);

            NumLabel.Text = Num.ToString();
            NumLabel.BackColor = Head.GRAY[Num % 2];

            TitleLabel.Tag = Num.ToString();
            TitleLabel.BackColor = Head.GRAY[(Num + 1) % 2];

            WorkLabel.Tag = Num.ToString();
            WorkLabel.BackColor = Head.GRAY[(Num + 1) % 2];

            AddWorkButton.Tag = Num.ToString();
            AddWorkButton.BackColor = Head.GRAY[(Num + 1) % 2];

            UpdateLocation(cellSize);
        }

        public Lesson(int num, int cellSize, Color color, string title)
        {
            this = new Lesson(num, cellSize, color);

            SetTitle(title);
        }

        public Lesson(int num, int cellSize, Color color, string title, Dictionary<string, string> workList)
        {
            this = new Lesson(num, cellSize, color, title);

            WorkList = workList;
        }

        public void UpdateLocation(int cellSize)
        {
            int positionCoef = Num - 1;

            NumLabel.Location = new Point(0, cellSize * positionCoef);
            TitleLabel.Location = new Point(50, cellSize * positionCoef);
            WorkLabel.Location = new Point(50, cellSize * positionCoef + (int)(cellSize * 2 / 7f));
            AddWorkButton.Location = new Point(700 - cellSize + 10, cellSize * positionCoef + 10);
        }

        public void UpdateSizes(int cellSize, bool editMode)
        {
            TitleLabel.Size = new Size(650 - (editMode ? cellSize : 0), (int)(cellSize * 2 / 7f));//

            WorkLabel.Size = new Size(650 - (editMode ? cellSize : 0), (int)(cellSize * 5 / 7f));//
        }

        public void CopyFrom(Lesson lesson)
        {
            Title = lesson.Title;

            if (TitleLabel == null) TitleLabel = new Label();
            TitleLabel.Text = Title;

            if (WorkLabel == null) WorkLabel = new Label();
            WorkLabel.Text = lesson.WorkLabel.Text;

            if (WorkList == null) WorkList = new Dictionary<string, string>();
            WorkList.Clear();

            foreach (var workList in lesson.WorkList)
                WorkList.Add(workList.Key, workList.Value);
        }

        public void TurnOff()
        {
            NumLabel.ForeColor = Head.GRAY[(Num + 1) % 2];

            TitleLabel.Text = "";
            WorkLabel.Text = "";
            Enabled = false;
        }

        public void SetTitle(string title)
        {
            Title = title;
            
            TitleLabel.AccessibleName = Title;
            TitleLabel.Text = Head.Translations[Head.ActiveLanguage][TitleLabel.AccessibleName];

            try { WorkList["Default"] = Head.LessonsDefaultWork[Title]; }
            catch { WorkList["Default"] = "Isn't set"; }

            if (WorkList.Count == 1)
            {
                WorkLabel.AccessibleName = WorkList["Default"];

                WorkLabel.Text = Head.Translations[Head.ActiveLanguage][WorkLabel.AccessibleName];
            }

            else
                WorkLabel.AccessibleName = "";
        }

        public static Lesson CopyFromStatic(Lesson lesson)
        {
            Lesson result = new Lesson
            {
                Title = lesson.Title,

                WorkLabel = new Label(),
                TitleLabel = new Label(),

                WorkList = new Dictionary<string, string>()
            };

            result.TitleLabel.Text = result.Title;

            result.WorkLabel.Text = lesson.WorkLabel.Text;

            foreach (var workList in lesson.WorkList)
                result.WorkList.Add(workList.Key, workList.Value);

            return result;
        }

        public static string ToCSV(Lesson lesson)
        {
            string CSV = lesson.Num + "╫ " + lesson.Title;

            foreach (var work in lesson.WorkList)
                CSV += "╫ " + work.Key + "╫ " + work.Value;

            return CSV;
        }

        public static Lesson FromCSV(string CSV)
        {
            string[] splited = CSV.Split(new string[1] { "╫ " }, StringSplitOptions.None);

            Dictionary<string, string> workList = new Dictionary<string, string>();

            for (int i = 2; i < splited.Length - 1; i += 2)
                workList.Add(splited[i], splited[i + 1]);

            return new Lesson(int.Parse(splited[0]), Head.CellSize, Head.Color, splited[1], workList);
        }
    }
}
