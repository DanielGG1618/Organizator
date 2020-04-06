using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Organizer
{
    public partial class Head : Form
    {
        public static Color ProjectColor = Color.OliveDrab;
        public static Color[] GRAY = new Color[2] { Color.FromArgb(56, 56, 56), Color.FromArgb(48, 48, 48)};

        public static List<DateTime> PrimaryHolydays = new List<DateTime>();
        public static List<DateTime> SecondaryHolydays = new List<DateTime>();
        public static List<DateTime> ThisYearHolydays = new List<DateTime>();

        private static int MAX_LESSONS_COUNT = 0;

        private const int CELL_SIZE = 70;

        public static int[] LessonsCount = new int[7];
        public static string[][] Schedule;

        private static short daysInYear = 273;
        private static int year = 19;

        private DateTime date, firstDay, lastDay;
        private int lessonsCount;

        public static Lesson[] Lessons;
        private Lesson[] editModeLessonsBackup;
        private Dictionary<DateTime, Day> days = new Dictionary<DateTime, Day>();

        public static List<Work>[] Works;

        private bool editMode;

        public Head()
        {
            LoadFiles();

            firstDay = new DateTime(2000 + year, 9, 1);
            firstDay = firstDay.ToLocalTime();
            firstDay = firstDay.Date;

            lastDay = new DateTime(2001 + year, 5, 31);
            lastDay = lastDay.ToLocalTime();
            lastDay = lastDay.Date;

            for (int i = 0; i < Schedule.Length; i++)
            {
                LessonsCount[i] = Schedule[i].Length;
            }

            MAX_LESSONS_COUNT = LessonsCount.Max();

            Lessons = new Lesson[MAX_LESSONS_COUNT];
            Works = new List<Work>[MAX_LESSONS_COUNT];

            if (DateTime.IsLeapYear(2001 + year))
                daysInYear++;

            for (int i = 0; i < MAX_LESSONS_COUNT; i++)
                Works[i] = new List<Work>();

            for (int i = 0; i < daysInYear; i++)
                days.Add(firstDay.AddDays(i), new Day(i, 2000 + year));

            Work work = new Work("qwerg");
            work.Values.Add("asdasf");
            work.Values.Add("12345");
            Works[0].Add(work);

            InitializeComponent();
        }

        private void Head_Load(object sender, EventArgs e)
        {
            date = DateTime.Today;

            do
                date = date.AddDays(1);
            while (!days[date].IsWorking);

            lessonsCount = days[date].LessonsCount;
            lessonsPanel.Controls.Clear();

            for(int i = 0; i < MAX_LESSONS_COUNT; i++)
            {
                Lessons[i] = new Lesson(i + 1, CELL_SIZE, ProjectColor);

                Lessons[i].WorkLabel.Click += WorkClick;
                Lessons[i].TitleLabel.Click += TitleClick;
                Lessons[i].AddWorkButton.Click += AddWorkButtonClick;

                lessonsPanel.Controls.Add(Lessons[i].AddWorkButton);
                lessonsPanel.Controls.Add(Lessons[i].NumLabel);
                lessonsPanel.Controls.Add(Lessons[i].TitleLabel);
                lessonsPanel.Controls.Add(Lessons[i].WorkLabel);
            }

            LessonsRefresh();
        }

        private void LoadFiles()
        {
            string[] schedule = File.ReadAllLines("Lessons.txt", Encoding.Default);

            Schedule = new string[schedule.Length][];

            for (int i = 0; i < schedule.Length; i++)
            {
                List<string> array = new List<string>(schedule[i].Split(new string[2] { ", ", ": " }, StringSplitOptions.RemoveEmptyEntries));
                array.RemoveAt(0);

                Schedule[i] = array.ToArray();

                if (array.Count > MAX_LESSONS_COUNT)
                    MAX_LESSONS_COUNT = array.Count;
            }

            string[] holydays = File.ReadAllLines("Holydays.txt");

            foreach (var day in holydays)
            {
                string[] holyday = day.Split(new string[1] { " type: " }, StringSplitOptions.None);

                if (holyday[1] == "primary")
                {
                    string[] dayMonth = holyday[0].Split('.');

                    DateTime date = new DateTime(4, Convert.ToInt32(dayMonth[1]), Convert.ToInt32(dayMonth[0]));

                    PrimaryHolydays.Add(new DateTime(4, Convert.ToInt32(dayMonth[1]), Convert.ToInt32(dayMonth[0])));
                }

                else if (holyday[1] == "secondary")
                {
                    string[] startFinish = holyday[0].Split('-');

                    string[] startDayMonth = startFinish[0].Split('.');
                    string[] finishDayMonth = startFinish.Length > 1 ? startFinish[1].Split('.') : startDayMonth;

                    for (DateTime dayToAdd = new DateTime(4, Convert.ToInt32(startDayMonth[1]), Convert.ToInt32(startDayMonth[0]));
                        dayToAdd <= new DateTime(4, Convert.ToInt32(finishDayMonth[1]), Convert.ToInt32(finishDayMonth[0]));
                        dayToAdd = dayToAdd.AddDays(1))
                    {
                        SecondaryHolydays.Add(dayToAdd);
                    }
                }

                else if (holyday[1] == "this year")
                {
                    string[] startFinish = holyday[0].Split('-');

                    string[] startDayMonthYear = startFinish[0].Split('.');
                    string[] finishDayMonthYear = startFinish.Length > 1 ? startFinish[1].Split('.') : startDayMonthYear;

                    for (DateTime dayToAdd = new DateTime(Convert.ToInt32(startDayMonthYear[2]), Convert.ToInt32(startDayMonthYear[1]), Convert.ToInt32(startDayMonthYear[0]));
                        dayToAdd <= new DateTime(Convert.ToInt32(finishDayMonthYear[2]), Convert.ToInt32(finishDayMonthYear[1]), Convert.ToInt32(finishDayMonthYear[0]));
                        dayToAdd = dayToAdd.AddDays(1))
                    {
                        ThisYearHolydays.Add(dayToAdd);
                    }
                }
            }
        }

        private void LessonsRefresh()
        {
            lessonsCount = days[date].LessonsCount;

            for (int i = 0; i < lessonsCount; i++)
            {
                ReloadWorkLabel(i);

                Lessons[i].TitleLabel.Text = Schedule[(int)days[date].Date.DayOfWeek][i];

                Lessons[i].NumLabel.Visible = true;
                Lessons[i].TitleLabel.Visible = true;
                Lessons[i].WorkLabel.Visible = true;
            }

            for (int i = 6; i >= lessonsCount; i--)
            {
                Lessons[i].NumLabel.Visible = false;
                Lessons[i].TitleLabel.Visible = false;
                Lessons[i].WorkLabel.Visible = false;
            }

            DateText.Text = date.Day.ToString("00") + "." + date.Month.ToString("00") + "." + date.Year;
        }

        public void ReloadWorkLabel(int num)
        {
            Lessons[num].WorkLabel.Text = "";

            foreach (Work work in Works[num])
                foreach (string value in work.Values)
                    Lessons[num].WorkLabel.Text += value + " ";
        }

        private void EditModeButton_Click(object sender, EventArgs e)
        {
            editMode = !editMode;
            
            if (editMode)
            {
                editModeLessonsBackup = new Lesson[7];

                for (int i = 0; i < lessonsCount; i++)
                {
                    editModeLessonsBackup[i].TitleLabel = new Label();
                    editModeLessonsBackup[i].TitleLabel.Text = Lessons[i].TitleLabel.Text;

                    editModeLessonsBackup[i].WorkLabel = new Label();
                    editModeLessonsBackup[i].WorkLabel.Text = Lessons[i].WorkLabel.Text;
                }
            }

            else
            {
                DialogResult result = MessageBox.Show("Сохранить изменения?", "Режим редактирования", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.No)
                {
                    for (int i = 0; i < lessonsCount; i++)
                    {
                        Lessons[i].TitleLabel.Text = editModeLessonsBackup[i].TitleLabel.Text;

                        Lessons[i].WorkLabel.Text = editModeLessonsBackup[i].WorkLabel.Text;
                    }
                }

                else if (result == DialogResult.Cancel)
                    editMode = true;
            }

            EditModeButton.ForeColor = editMode ? Color.LimeGreen : ProjectColor;

            for (int i = 0; i < lessonsCount; i++)
                Lessons[i].AddWorkButton.Visible = editMode;
        }

        private void SaveScreenButton_Click(object sender, EventArgs e)
        {
            InDevelop();
        }

        private void LoadFromButton_Click(object sender, EventArgs e)
        {
            InDevelop();
        }

        private void SaveToButton_Click(object sender, EventArgs e)
        {
            InDevelop();
        }

        private void ChangesButton_Click(object sender, EventArgs e)
        {
            InDevelop();
        } 

        private void DateMinusButton_Click(object sender, EventArgs e)
        {
            if (!editMode)
            {
                do
                {
                    date = date.AddDays(-1);

                    if (date < firstDay)
                        date = lastDay;
                }
                while (!days[date].IsWorking);

                LessonsRefresh();
            }

            else
                MessageBox.Show("Не работает в режиме редактирования");
        }

        private void DatePlusButton_Click(object sender, EventArgs e)
        {
            if (!editMode)
            {
                do
                {
                    date = date.AddDays(1);

                    if (date > lastDay)
                        date = firstDay;
                }
                while (!days[date].IsWorking);

                LessonsRefresh();
            }

            else
                MessageBox.Show("Не работает в режиме редактирования");
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        private void InDevelop()
        {
            MessageBox.Show("Кнопка в разработке", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void WorkClick(object sender, EventArgs e)
        {
            
        }

        private void TitleClick(object sender, EventArgs e)
        {
            if (editMode)
            {
                Label title = (Label)sender;
                LessonSelectForm form = new LessonSelectForm(title.Tag.ToString());

                if (form.ShowDialog() == DialogResult.OK)
                    title.Text = form.lesson;
            }
        }

        private void AddWorkButtonClick(object sender, EventArgs e)
        {
            Button addWorkButton = (Button)sender;
            WorkAddForm form = new WorkAddForm(addWorkButton.Tag.ToString());

            int num = Convert.ToInt32(addWorkButton.Tag) - 1;

            if (form.ShowDialog() == DialogResult.OK)
                foreach(var work in form.Works)
                    Works[num].Add(work);

            ReloadWorkLabel(num);
        }
    }

    public struct Lesson
    {
        public Label NumLabel, TitleLabel, WorkLabel;
        public Button AddWorkButton;

        public void LoadWithSamples(int cellSize, Color color)
        {
            NumLabel.Size = new Size(cellSize, cellSize);
            NumLabel.TextAlign = ContentAlignment.MiddleCenter;
            NumLabel.Font = new Font("Microsoft Sans Serif", 36, FontStyle.Bold);
            NumLabel.ForeColor = color;

            TitleLabel.Size = new Size(630, (int)(cellSize * 2 / 7f));//
            TitleLabel.TextAlign = ContentAlignment.MiddleLeft;
            TitleLabel.Font = new Font("Microsoft Sans Serif", 12);
            TitleLabel.ForeColor = Color.White;

            WorkLabel.Size = new Size(630, (int)(cellSize * 5 / 7f));//
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
            NumLabel = new Label();
            TitleLabel = new Label();
            WorkLabel = new Label();
            AddWorkButton = new Button();

            LoadWithSamples(cellSize, color);

            NumLabel.Text = num.ToString();
            NumLabel.Location = new Point(0, cellSize * (num - 1));
            NumLabel.BackColor = Head.GRAY[num % 2];

            TitleLabel.Tag = num.ToString();
            TitleLabel.Location = new Point(cellSize, cellSize * (num - 1));
            TitleLabel.BackColor = Head.GRAY[(num + 1) % 2];

            WorkLabel.Tag = num.ToString();
            WorkLabel.Location = new Point(cellSize, cellSize * (num - 1) + (int)(cellSize * 2 / 7f));
            WorkLabel.BackColor = Head.GRAY[(num + 1) % 2];

            AddWorkButton.Tag = num.ToString();
            AddWorkButton.Location = new Point(570 + cellSize, cellSize * (num - 1) + 10);
            AddWorkButton.BackColor = Head.GRAY[(num + 1) % 2];
        }
    }

    public struct Work
    {
        public string Type;
        public List<string> Values;

        public string Result;

        public Work(string type)
        {
            Type = type;

            Values = new List<string>();

            Result = "";
        }

        public Work(string type, List<string> values)
        {
            Type = type;

            Values = values;

            Result = "";
        }

        public void LoadResult()
        {
            foreach (string value in Values)
                Result += value + " ";
        }
    }

    public struct Day
    {
        public DateTime Date;
        private DateTime generalViewDate;

        public bool IsWorking;
        public int LessonsCount, Num;

        public Day(int num, int year)
        {
            Num = num;
            Date = new DateTime(year, 9, 1).AddDays(Num);
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

            LessonsCount = IsWorking ? Head.LessonsCount[(int)Date.DayOfWeek] : 0;
        }

        public static DateTime DateSubtract(DateTime a, DateTime b)
        {
            return DateTime.FromBinary(a.ToBinary() - b.ToBinary());
        }
    }
}