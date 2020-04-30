using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
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

        private static int year = 19;

        private DateTime date, firstDay, lastDay;
        private int lessonsCount;

        public static Lesson[] Lessons;
        private Lesson[] editModeLessonsBackup;
        public static Dictionary<DateTime, Day> Days = new Dictionary<DateTime, Day>();

        private bool editMode;

        public Head()
        {
            firstDay = new DateTime(2000 + year, 9, 1);
            firstDay = firstDay.ToLocalTime();
            firstDay = firstDay.Date;

            lastDay = new DateTime(2001 + year, 5, 31);
            lastDay = lastDay.ToLocalTime();
            lastDay = lastDay.Date;

            LoadFiles();

            foreach (var lessons in Schedule)
                if (lessons.Length > MaxLessonsCount)
                    MaxLessonsCount = lessons.Length;

            CellSize = 490 / MaxLessonsCount;

            date = DateTime.Today;
            
            do
                date = date.AddDays(1);
            while (!Days[date].IsWorking);

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


            if (File.Exists("Days.txt") && !string.IsNullOrEmpty(File.ReadAllText("Days.txt")))
            {
                string[] days = File.ReadAllLines("Days.txt");

                Days.Clear();

                for (int i = 0; i < days.Length; i ++)
                {
                    Day day = Day.FromCSV(days[i]);
                    Days.Add(day.Date, day);
                }
            }

            else
            {
                for (int i = 0; i < 273; i++)
                    Days.Add(firstDay.AddDays(i), new Day(i, 2000 + year));

                if (DateTime.IsLeapYear(2001 + year))
                    Days.Add(firstDay.AddDays(273), new Day(273, 2000 + year));
            }
        }

        public void SaveFiles(object sender, FormClosingEventArgs e)
        {
            List<string> days = new List<string>();

            foreach(var day in Days)
                days.Add(Day.ToCSV(day.Value));

            File.WriteAllLines("Days.txt", days);
        }

        private void LessonsRefresh()
        {
            for (int i = 0; i < Days[date].Lessons.Count; i++)//////////////////////////
            {
                Lessons[i].NumLabel.ForeColor = ProjectColor;
                Lessons[i].CopyFrom(Days[date].Lessons[i]);////////////////////////////
            }

            lessonsCount = Days[date].Lessons.Count;

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
                    for (int i = 0; i < lessonsCount; i++)
                        Lessons[i].CopyFrom(editModeLessonsBackup[i]);

                else if (result == DialogResult.Cancel)
                    editMode = true;

                else
                    for(int i = 0; i < Days[date].Lessons.Count; i++)
                        Days[date].Lessons[i].CopyFrom(Lessons[i]);
            }

            EditModeButton.ForeColor = editMode ? Color.LimeGreen : ProjectColor;

            LessonsRefresh();

            for (int i = 0; i < lessonsCount; i++)
                Lessons[i].AddWorkButton.Visible = editMode;

            for (int i = 0; i < MaxLessonsCount; i++)
                Lessons[i].UpdateSizes(CellSize, editMode);
        }

        private void SaveScreenButton_Click(object sender, EventArgs e)
        {
            InDevelop();

            /*MailAddress fromMailAddress = new MailAddress("DanielGGdebug@gmail.com", "Твое имя");
            MailAddress toAddress = new MailAddress("daniel.gevorgyan25@gmail.com");

            using (MailMessage mailMessage = new MailMessage(fromMailAddress, toAddress))
            using (SmtpClient smtpClient = new SmtpClient())
            {
                mailMessage.Subject = "Привет";

                mailMessage.IsBodyHtml = true;

                mailMessage.Body += File.ReadAllText("gigigi.txt", Encoding.UTF8);

                /*foreach (var day in Days)
                {
                    foreach (var lesson in day.Value.Lessons)
                    {
                        mailMessage.Body += Environment.NewLine + lesson.Num + " " +  lesson.Title;
                    }

                    mailMessage.Body += Environment.NewLine;
                }/*

                File.WriteAllText("File.csv", mailMessage.Body, Encoding.UTF8);
                mailMessage.Attachments.Add(new Attachment("File.csv"));

                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromMailAddress.Address,                                                                "debugпароль");

                smtpClient.Send(mailMessage);
            }*/
        }

        private void LoadFromButton_Click(object sender, EventArgs e)
        {
            InDevelop();

            //System.Net.WebClient wc = new System.Net.WebClient();
            //wc.DownloadFileAsync(new Uri("https://www.xeroxscanners.com/downloads/Manuals/XMS/PDF_Converter_Pro_Quick_Reference_Guide.RU.pdf"), "file.pdf");
        }

        private void SaveToButton_Click(object sender, EventArgs e)
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
                while (!Days[date].IsWorking);

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
                while (!Days[date].IsWorking);

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

        private void TimerButton_Click(object sender, EventArgs e)
        {
            TimerForm form = new TimerForm();
            form.Show();
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
            {
                Lessons.Add(new Lesson(i + 1, Head.CellSize, Head.ProjectColor, Head.Schedule[(int)Date.DayOfWeek][i]));
            }
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
            string CSV = day.Num + ", " + day.Year;

            foreach (var lesson in day.Lessons)
                CSV += "; " + Lesson.ToCSV(lesson);

            return CSV;
        }

        public static Day FromCSV(string CSV)
        {
            Day day;

            string[] dayLessons = CSV.Split(new string[1] { "; " }, StringSplitOptions.None);
            string[] splited = dayLessons[0].Split(new string[1] { ", " }, StringSplitOptions.None);

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

            if(TitleLabel == null) TitleLabel = new Label();
            TitleLabel.Text = Title;

            if (WorkLabel == null) WorkLabel = new Label();
            WorkLabel.Text = lesson.WorkLabel.Text;

            WorkList = new Dictionary<string, string>();
            
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

        public static Lesson CopyFromStatic(Lesson lesson)
        {
            Lesson result = new Lesson();

            result.Title = lesson.Title;

            result.TitleLabel = new Label();
            result.TitleLabel.Text = result.Title;

            result.WorkLabel = new Label();
            result.WorkLabel.Text = lesson.WorkLabel.Text;

            result.WorkList = new Dictionary<string, string>();

            foreach (var workList in lesson.WorkList)
                result.WorkList.Add(workList.Key, workList.Value);

            return result;
        }

        public static string ToCSV(Lesson lesson)
        {
            string CSV = lesson.Num + ", " + lesson.Title;

            foreach(var work in lesson.WorkList)
                CSV += ", " + work.Key + ", " + work.Value;

            return CSV;
        }

        public static Lesson FromCSV(string CSV)
        {
            Lesson lesson;

            string[] splited = CSV.Split(new string[1] { ", " }, StringSplitOptions.None);

            Dictionary<string, string> workList = new Dictionary<string, string>();

            for (int i = 2; i < splited.Length - 1; i += 2)
                workList.Add(splited[i], splited[i + 1]);

            lesson = new Lesson(int.Parse(splited[0]), Head.CellSize, Head.ProjectColor, splited[1], workList);

            return lesson;
        }
    }
}