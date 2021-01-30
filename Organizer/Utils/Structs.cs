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
            return Date.DayOfWeek != DayOfWeek.Sunday && Date.DayOfWeek != DayOfWeek.Saturday &&
                    !(Main.PrimaryHolydays.Contains<DateTime>(generalViewDate) ||

                    (!Main.PrimaryHolydays.Contains<DateTime>(generalViewDate) &&
                    (Main.PrimaryHolydays.Contains<DateTime>(generalViewDate) ||
                    Main.PrimaryHolydays.Contains<DateTime>(generalViewDate.AddDays(-1)))) ||

                    Main.SecondaryHolydays.Contains<DateTime>(generalViewDate) ||

                    Main.ThisYearHolydays.Contains<DateTime>(Date));
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

    /*public struct Lesson
    {
        public Label NumLabel, TitleLabel, WorkLabel;
        public Button AddWorkButton;
        public CheckBox DoneCheckBox;

        public int Num;
        public string Title;
        public string Homework;

        public bool Enabled;
        public bool Done { get => DoneCheckBox.Checked; }

        private string defaultHomework;

        public void LoadWithSamples(int cellSize, Color color)
        {
            NumLabel.Size = new Size(50, cellSize);
            NumLabel.TextAlign = ContentAlignment.MiddleCenter;
            NumLabel.Font = new Font("Microsoft Sans Serif", 36, FontStyle.Bold);
            NumLabel.ForeColor = color;

            TitleLabel.Size = new Size(700, (int)(cellSize * 2 / 7f));//
            TitleLabel.TextAlign = ContentAlignment.MiddleLeft;
            TitleLabel.Font = new Font("Microsoft Sans Serif", 12);
            TitleLabel.ForeColor = Color.White;

            WorkLabel.Size = new Size(700, (int)(cellSize * 5 / 7f));//
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
            Homework = "Default";
            Enabled = true;
            Title = "";
            defaultHomework = "";

            LoadWithSamples(cellSize, color);

            NumLabel.Text = Num.ToString();
            NumLabel.BackColor = Main.GRAY[Num % 2];

            TitleLabel.Tag = Num.ToString();
            TitleLabel.BackColor = Main.GRAY[(Num + 1) % 2];

            WorkLabel.Tag = Num.ToString();
            WorkLabel.BackColor = Main.GRAY[(Num + 1) % 2];

            AddWorkButton.Tag = Num.ToString();
            AddWorkButton.BackColor = Main.GRAY[(Num + 1) % 2];

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

        public Lesson(int num, int cellSize, Color color, string title, bool done, string homework)
        {
            this = new Lesson(num, cellSize, color, title, done);

            Homework = homework;
        }

        public void UpdateLocation(int cellSize)
        {
            int positionCoef = Num - 1;

            NumLabel.Location = new Point(0, cellSize * positionCoef);
            TitleLabel.Location = new Point(50, cellSize * positionCoef);
            WorkLabel.Location = new Point(50, cellSize * positionCoef + (int)(cellSize * 2 / 7f));
            AddWorkButton.Location = new Point(750 - cellSize + 10, cellSize * positionCoef + 10);
            DoneCheckBox.Location = new Point(0, cellSize * positionCoef);
        }

        public void UpdateSizes(int cellSize, bool editMode)
        {
            TitleLabel.Size = new Size(700 - (editMode ? cellSize : 0), (int)(cellSize * 2 / 7f));

            WorkLabel.Size = new Size(700 - (editMode ? cellSize : 0), (int)(cellSize * 5 / 7f));
        }

        public void CopyFrom(Lesson lesson)
        {
            Title = lesson.Title;
            Homework = lesson.Homework;

            if (TitleLabel == null) TitleLabel = new Label();
            TitleLabel.AccessibleName = Title;
            TitleLabel.Text = Program.Translate(TitleLabel.AccessibleName);

            if (WorkLabel == null) WorkLabel = new Label();
            WorkLabel.Text = lesson.WorkLabel.Text;

            if (DoneCheckBox == null) DoneCheckBox = new CheckBox();
            DoneCheckBox.Checked = lesson.Done;   
        }

        public void TurnOff()
        {
            NumLabel.ForeColor = Main.GRAY[(Num + 1) % 2];

            TitleLabel.Text = "";
            WorkLabel.Text = "";
            DoneCheckBox.Visible = false;
            Enabled = false;
        }

        public void SetTitle(string title)
        {
            Title = title;
            
            TitleLabel.AccessibleName = Title;
            TitleLabel.Text = Program.Translate(TitleLabel.AccessibleName);

            try { defaultHomework = Main.LessonsDefaultWork[Title]; }
            catch { defaultHomework = "Isn*t set"; }

            if (Homework == "Default")
            {
                WorkLabel.AccessibleName = defaultHomework;

                WorkLabel.Text = Program.Translate(WorkLabel.AccessibleName);
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
            string txt = lesson.Num + "╫ " + lesson.Title + "╫ " + lesson.Done + "╫ " + lesson.Homework;

            return txt;
        }

        public static Lesson Fromtxt(string txt)
        {
            string[] splited = txt.Split(new string[1] { "╫ " }, StringSplitOptions.None);

            return new Lesson(int.Parse(splited[0]), Schelude.CellSize, Program.Color, splited[1], bool.Parse(splited[2]), splited[3]);
        }
    }*/
}
