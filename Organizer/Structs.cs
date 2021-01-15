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

            Date = new DateTime(2000 + Head.YEAR, 9, 1).AddDays(Num);
            generalViewDate = new DateTime(4, Date.Month, Date.Day);

            Lessons = new List<Lesson>();

            for (int i = 0; i < Head.Schelude[(int)Date.DayOfWeek].Length; i++)
                Lessons.Add(new Lesson(i + 1, Schelude.CellSize, Head.Color, Head.Schelude[(int)Date.DayOfWeek][i]));
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
            return Date.DayOfWeek != DayOfWeek.Sunday && Date.DayOfWeek != DayOfWeek.Saturday &&
                    !(Head.PrimaryHolydays.Contains<DateTime>(generalViewDate) ||

                    (!Head.PrimaryHolydays.Contains<DateTime>(generalViewDate) &&
                    (Head.PrimaryHolydays.Contains<DateTime>(generalViewDate) ||
                    Head.PrimaryHolydays.Contains<DateTime>(generalViewDate.AddDays(-1)))) ||

                    Head.SecondaryHolydays.Contains<DateTime>(generalViewDate) ||

                    Head.ThisYearHolydays.Contains<DateTime>(Date));
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

    public struct Lesson
    {
        public Label NumLabel, TitleLabel, WorkLabel;
        public Button AddWorkButton;
        public CheckBox DoneCheckBox;

        public int Num;
        public string Title;
        public Dictionary<string, List<string>> WorkList;

        public bool Enabled;
        public bool Done { get => DoneCheckBox.Checked; }

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

        public Lesson(int num, int cellSize, Color color, bool done = false)
        {
            Num = num;

            NumLabel = new Label();
            TitleLabel = new Label();
            WorkLabel = new Label();
            AddWorkButton = new Button();
            DoneCheckBox = new CheckBox();
            WorkList = new Dictionary<string, List<string>> { { "Default", new List<string>(new string[1] { "" }) } };
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

            DoneCheckBox.Text = "";
            DoneCheckBox.AutoSize = true;
            DoneCheckBox.BackColor = Color.Transparent;
            DoneCheckBox.Checked = done;
            DoneCheckBox.Tag = Num.ToString();

            UpdateLocation(cellSize);
        }

        public Lesson(int num, int cellSize, Color color, string title, bool done = false)
        {
            this = new Lesson(num, cellSize, color, done);

            SetTitle(title);
        }

        public Lesson(int num, int cellSize, Color color, string title, bool done, Dictionary<string, List<string>> workList)
        {
            this = new Lesson(num, cellSize, color, title, done);

            WorkList = workList;
        }

        public void UpdateLocation(int cellSize)
        {
            int positionCoef = Num - 1;

            NumLabel.Location = new Point(0, cellSize * positionCoef);
            TitleLabel.Location = new Point(50, cellSize * positionCoef);
            WorkLabel.Location = new Point(50, cellSize * positionCoef + (int)(cellSize * 2 / 7f));
            AddWorkButton.Location = new Point(700 - cellSize + 10, cellSize * positionCoef + 10);
            DoneCheckBox.Location = new Point(0, cellSize * positionCoef);
        }

        public void UpdateSizes(int cellSize, bool editMode)
        {
            TitleLabel.Size = new Size(650 - (editMode ? cellSize : 0), (int)(cellSize * 2 / 7f));

            WorkLabel.Size = new Size(650 - (editMode ? cellSize : 0), (int)(cellSize * 5 / 7f));
        }

        public void CopyFrom(Lesson lesson)
        {
            Title = lesson.Title;

            if (TitleLabel == null) TitleLabel = new Label();
            TitleLabel.AccessibleName = Title;
            TitleLabel.Text = Head.Translations[Head.ActiveLanguage][TitleLabel.AccessibleName];

            if (WorkLabel == null) WorkLabel = new Label();
            WorkLabel.Text = lesson.WorkLabel.Text;

            if (WorkList == null) WorkList = new Dictionary<string, List<string>>();
            WorkList.Clear();

            if (DoneCheckBox == null) DoneCheckBox = new CheckBox();
            DoneCheckBox.Checked = lesson.Done;

            foreach (var workList in lesson.WorkList)
                WorkList.Add(workList.Key, new List<string>(workList.Value.ToArray()));
        }

        public void TurnOff()
        {
            NumLabel.ForeColor = Head.GRAY[(Num + 1) % 2];

            TitleLabel.Text = "";
            WorkLabel.Text = "";
            DoneCheckBox.Visible = false;
            Enabled = false;
        }

        public void SetTitle(string title)
        {
            Title = title;
            
            TitleLabel.AccessibleName = Title;
            TitleLabel.Text = Head.Translations[Head.ActiveLanguage][TitleLabel.AccessibleName];

            try { WorkList["Default"][0] = Head.LessonsDefaultWork[Title]; }
            catch { WorkList["Default"][0] = "Isn't set"; }

            if (WorkList.Count == 1)
            {
                WorkLabel.AccessibleName = WorkList["Default"][0];

                WorkLabel.Text = Head.Translations[Head.ActiveLanguage][WorkLabel.AccessibleName];
            }

            else
                WorkLabel.AccessibleName = "";
        }

        public void SetDone(bool done)
        {
            DoneCheckBox.Checked = done;
        }

        public static string Totxt(Lesson lesson)
        {
            string txt = lesson.Num + "╫ " + lesson.Title + "╫ " + lesson.Done;

            foreach (var work in lesson.WorkList)
            {
                txt += "╫ " + work.Key + "╫ ";

                foreach (var str in work.Value)
                    txt += str + '◘';

                txt = txt.Remove(txt.Length - 1);
            }

            return txt;
        }

        public static Lesson Fromtxt(string txt)
        {
            string[] splited = txt.Split(new string[1] { "╫ " }, StringSplitOptions.None);

            Dictionary<string, List<string>> workList = new Dictionary<string, List<string>>();

            for (int i = 3; i < splited.Length - 1; i += 2)
                workList.Add(splited[i], new List<string>(splited[i + 1].Split('◘')));

            return new Lesson(int.Parse(splited[0]), Schelude.CellSize, Head.Color, splited[1], bool.Parse(splited[2]), workList);
        }
    }
}
