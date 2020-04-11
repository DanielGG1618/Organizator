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
        public static Color[] GRAY = new Color[2] { Color.FromArgb(56, 56, 56), Color.FromArgb(48, 48, 48) };

        public static List<DateTime> PrimaryHolydays = new List<DateTime>();
        public static List<DateTime> SecondaryHolydays = new List<DateTime>();
        public static List<DateTime> ThisYearHolydays = new List<DateTime>();

        public static int MaxLessonsCount;

        public static int CellSize = 70;

        public static string[][] Schedule;
        public static Dictionary<string, string> LessonsDefaultWork = new Dictionary<string, string>();

        private static short daysInYear = 273;
        private static int year = 19;

        private DateTime date, firstDay, lastDay;
        private int lessonsCount;

        public static Lesson[] Lessons;
        private Lesson[] editModeLessonsBackup;
        private Dictionary<DateTime, Day> days = new Dictionary<DateTime, Day>();

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

            for (int i = 0; i < daysInYear; i++)
                days.Add(firstDay.AddDays(i), new Day(i, 2000 + year));
            
            foreach (var lessons in Schedule)
            {
                if (lessons.Length > MaxLessonsCount)
                    MaxLessonsCount = lessons.Length;
            }

            CellSize = 490 / MaxLessonsCount;

            date = DateTime.Today;

            do
                date = date.AddDays(1);
            while (!days[date].IsWorking);

            if (DateTime.IsLeapYear(2001 + year))
                daysInYear++;

            editModeLessonsBackup = new Lesson[MaxLessonsCount];
            for(int i = 0; i < MaxLessonsCount;  i++)
                editModeLessonsBackup[i] = new Lesson(i + 1, CellSize, ProjectColor);

            InitializeComponent();
        }

        private void Head_Load(object sender, EventArgs e)
        {
            lessonsPanel.Controls.Clear();

            Lessons = new Lesson[MaxLessonsCount];

            for (int i = 0; i < MaxLessonsCount; i++)
            {
                Lessons[i] = new Lesson(i + 1, CellSize, ProjectColor);

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
            }

            string[] holydays = File.ReadAllLines("Holydays.txt");

            foreach (var day in holydays)
            {
                string[] holyday = day.Split(new string[1] { " type: " }, StringSplitOptions.RemoveEmptyEntries);

                if (holyday[1] == "primary")
                {
                    string[] dayMonth = holyday[0].Split('.');

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

                    for (DateTime dayToAdd = new DateTime(2000 + Convert.ToInt32(startDayMonthYear[2]), Convert.ToInt32(startDayMonthYear[1]), Convert.ToInt32(startDayMonthYear[0]));
                        dayToAdd <= new DateTime(2000 + Convert.ToInt32(finishDayMonthYear[2]), Convert.ToInt32(finishDayMonthYear[1]), Convert.ToInt32(finishDayMonthYear[0]));
                        dayToAdd = dayToAdd.AddDays(1))
                    {
                        ThisYearHolydays.Add(dayToAdd);
                    }
                }
            }

            string[] lessonsDefaultWorks = File.ReadAllLines("Lessons default work.txt", Encoding.Default);

            LessonsDefaultWork.Clear();

            foreach (var lessonsDefaultWork in lessonsDefaultWorks)
            {
                string[] keyValue = lessonsDefaultWork.Split(new string[] { ": " }, StringSplitOptions.None);

                LessonsDefaultWork.Add(keyValue[0], keyValue[1]);
            }
        }

        private void LessonsRefresh()
        {
            for (int i = 0; i < days[date].Lessons.Length; i++)
                Lessons[i].CopyFrom(days[date].Lessons[i]);

            lessonsCount = Schedule[(int)date.DayOfWeek].Length;

            for (int i = 0; i < lessonsCount; i++)
            {
                Lessons[i].LoadWithSamples(CellSize, ProjectColor);
                Lessons[i].UpdateLocation(CellSize);

                WorkRefresh(i);
            }

            for (int i = MaxLessonsCount - 1; i >= lessonsCount; i--)
                Lessons[i].TurnOff();

            DateText.Text = date.Day.ToString("00") + "." + date.Month.ToString("00") + "." + date.Year;
        }

        public static void WorkRefresh(int num)
        {
            if (Lessons[num].WorkList.Count > 1)
            {
                Lessons[num].WorkLabel.Text = "";

                foreach (var work in Lessons[num].WorkList)
                {
                    if (work.Key != "Default")
                    {
                        Lessons[num].WorkLabel.Text += work.Value;

                        if (!work.Equals(Lessons[num].WorkList.Last()))
                            Lessons[num].WorkLabel.Text += " | ";
                    }
                }
            }
        }

        private void EditModeButton_Click(object sender, EventArgs e)
        {
            editMode = !editMode;

            if (editMode)
            {
                for (int i = 0; i < lessonsCount; i++)
                {
                    editModeLessonsBackup[i].CopyFrom(Lessons[i]);
                }
            }

            else
            {
                DialogResult result = MessageBox.Show("Сохранить изменения?", "Режим редактирования", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.No)
                {
                    for (int i = 0; i < lessonsCount; i++)
                    {
                        Lessons[i].CopyFrom(editModeLessonsBackup[i]);
                    }
                }

                else if (result == DialogResult.Cancel)
                    editMode = true;

                else
                {
                    for(int i = 0; i < days[date].Lessons.Length; i++)
                        days[date].Lessons[i].CopyFrom(Lessons[i]);
                }
            }

            EditModeButton.ForeColor = editMode ? Color.LimeGreen : ProjectColor;

            for (int i = 0; i < lessonsCount; i++)
            {
                Lessons[i].AddWorkButton.Visible = editMode;
                Lessons[i].UpdateSizes(CellSize, editMode);
            }
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

                    if (date <= firstDay)
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

                    if (date >= lastDay)
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
            settings.ShowDialog();

            UpdateLanguage(Settings.ActiveLanguage);
            LoadFiles();
        }

        private void UpdateLanguage(string language)
        {
            
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
                int num = Convert.ToInt32(((Label)sender).Tag);
                LessonSelectForm form = new LessonSelectForm(num);

                if (form.ShowDialog() == DialogResult.OK)
                    Lessons[num - 1].SetTitle(form.lesson);
            }
        }

        private void AddWorkButtonClick(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(((Button)sender).Tag);

            WorkAddForm form = new WorkAddForm(num);

            if (form.ShowDialog() == DialogResult.OK)
            {
                Lessons[num - 1].WorkList.Clear();

                foreach (var work in form.Works)
                    Lessons[num - 1].WorkList.Add(work.Key, work.Value);
            }

            WorkRefresh(num - 1);
        }
    }

    public struct Day
    {
        public DateTime Date;
        private DateTime generalViewDate;

        public bool IsWorking;
        public int Num;

        public Lesson[] Lessons;

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

            Lessons = new Lesson[Head.Schedule[(int)Date.DayOfWeek].Length];

            for (int i = 0; i < Lessons.Length; i++)
            {
                Lessons[i] = new Lesson(i + 1, Head.CellSize, Head.ProjectColor);
                Lessons[i].SetTitle(Head.Schedule[(int)Date.DayOfWeek][i]);
            }
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

        public Dictionary<string, string> WorkList;

        public int Num;
        public string Title;

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
            TitleLabel.Text = Title;

            WorkLabel.Text = lesson.WorkLabel.Text;

            WorkList.Clear();

            foreach (var workList in lesson.WorkList)
                WorkList.Add(workList.Key, workList.Value);
        }

        public void TurnOff()
        {
            NumLabel.ForeColor = Head.GRAY[(Num + 1) % 2];

            TitleLabel.Text = "";
            WorkLabel.Text = "";
        }

        public void SetTitle(string title)
        {
            Title = title;
            TitleLabel.Text = Title;

            WorkList["Default"] = Head.LessonsDefaultWork[Title];
            if (WorkList.Count == 1) WorkLabel.Text = WorkList["Default"];
        }
    }
}