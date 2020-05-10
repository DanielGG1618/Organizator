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
        public static Color Color;
        public static Color[] GRAY = new Color[2] { Color.FromArgb(56, 56, 56), Color.FromArgb(48, 48, 48) };

        public static List<DateTime> PrimaryHolydays = new List<DateTime>();
        public static List<DateTime> SecondaryHolydays = new List<DateTime>();
        public static List<DateTime> ThisYearHolydays = new List<DateTime>();

        public static int MaxLessonsCount;

        public static int CellSize = 70;

        public static string[][] Schedule;
        public static Dictionary<string, string> LessonsDefaultWork = new Dictionary<string, string>();

        public static Dictionary<string, Dictionary<string, string>> Translations = new Dictionary<string, Dictionary<string, string>>();

        public static string ActiveLanguage;
        public static List<string> Languages;

        private static int year = 19;

        private DateTime date, firstDay, lastDay;
        private int lessonsCount;

        public static Lesson[] Lessons;
        private Lesson[] editModeLessonsBackup;
        public List<Control> LocalizationControls = new List<Control>();
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
            {
                date = date.AddDays(1);

                if (date >= lastDay)
                    date = firstDay;
            }
            while (!Days[date].IsWorking);

            editModeLessonsBackup = new Lesson[MaxLessonsCount];
            for(int i = 0; i < MaxLessonsCount;  i++)
                editModeLessonsBackup[i] = new Lesson(i + 1, CellSize, Color);

            InitializeComponent();
        }

        private void Head_Load(object sender, EventArgs e)
        {
            lessonsPanel.Controls.Clear();
            lessonsPanel.MouseWheel += LessonsPanelMouseWheel;

            Lessons = new Lesson[MaxLessonsCount];

            for (int i = 0; i < MaxLessonsCount; i++)
            {
                Lessons[i] = new Lesson(i + 1, CellSize, Color);

                Lessons[i].TitleLabel.Click += TitleClick;
                Lessons[i].AddWorkButton.Click += AddWorkButtonClick;

                lessonsPanel.Controls.Add(Lessons[i].AddWorkButton);
                lessonsPanel.Controls.Add(Lessons[i].NumLabel);
                lessonsPanel.Controls.Add(Lessons[i].TitleLabel);
                lessonsPanel.Controls.Add(Lessons[i].WorkLabel);

                LocalizationControls.Add(Lessons[i].TitleLabel);
                LocalizationControls.Add(Lessons[i].WorkLabel);
            }

            foreach (Button button in tableLayoutPanel1.Controls)
                LocalizationControls.Add(button);

            SetColor(Color);
            SetLanguage(ActiveLanguage);

            LessonsRefresh();
        }

        private void LoadFiles()
        {
            LoadSave();

            LoadTranslations();

            LoadSchedule();

            LoadHolydays();

            LoadDefaultWorks();

            LoadDays();
        }

        private void LoadTranslations()
        {
            Languages = new List<string>(File.ReadAllLines("Translations\\Languages.txt", Encoding.UTF8));

            foreach (var language in Languages)
            {
                if (Translations.ContainsKey(language))
                    continue;

                Dictionary<string, string> langDict = new Dictionary<string, string>();

                string[] langStr = File.ReadAllLines("Translations\\" + language + ".txt", Encoding.UTF8);

                for (int i = 0; i < langStr.Length; i++)
                {
                    string[] langWord = langStr[i].Split(';');
                    langDict.Add(langWord[0], langWord[1]);
                }

                Translations.Add(language, langDict);
            }
        }

        private void LoadSave()
        {
            string[] save = File.ReadAllLines("Save.txt", Encoding.UTF8);

            ActiveLanguage = save[0];

            string[] color = save[1].Split(';');
            Color = Color.FromArgb(int.Parse(color[0]), int.Parse(color[1]), int.Parse(color[2]));
        }

        private void LoadDays()
        {
            if (File.Exists("Days.txt") && !string.IsNullOrEmpty(File.ReadAllText("Days.txt")))
            {
                string[] days = File.ReadAllLines("Days.txt");

                Days.Clear();

                for (int i = 0; i < days.Length; i++)
                {
                    Day day = Day.Fromtxt(days[i]);
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

        private void LoadDefaultWorks()
        {
            string[] lessonsDefaultWorks = File.ReadAllLines("Lessons default work.txt", Encoding.UTF8);

            LessonsDefaultWork.Clear();

            foreach (var lessonsDefaultWork in lessonsDefaultWorks)
            {
                string[] keyValue = lessonsDefaultWork.Split(new string[] { ": " }, StringSplitOptions.None);

                LessonsDefaultWork.Add(keyValue[0], keyValue[1]);
            }
        }

        private void LoadHolydays()
        {
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
        }

        private void LoadSchedule()
        {
            string[] schedule = File.ReadAllLines("Lessons.txt", Encoding.UTF8);

            Schedule = new string[schedule.Length][];

            for (int i = 0; i < schedule.Length; i++)
            {
                List<string> array = new List<string>(schedule[i].Split(new string[2] { ", ", ": " }, StringSplitOptions.RemoveEmptyEntries));
                array.RemoveAt(0);

                Schedule[i] = array.ToArray();
            }
        }

        public void SaveFiles(object sender, FormClosingEventArgs e)
        {
            List<string> days = new List<string>();

            foreach(var day in Days)
                days.Add(Day.Totxt(day.Value));

            File.WriteAllLines("Days.txt", days);
        }

        private void LessonsRefresh()
        {
            for (int i = 0; i < Days[date].Lessons.Count; i++)//////////////////////////
            {
                Lessons[i].NumLabel.ForeColor = Color;
                Lessons[i].CopyFrom(Days[date].Lessons[i]);////////////////////////////
                WorkRefresh(i);
            }

            lessonsCount = Days[date].Lessons.Count;

            for (int i = MaxLessonsCount - 1; i >= lessonsCount; i--)
                Lessons[i].TurnOff();

            DateText.Text = date.Day.ToString("00") + "." + date.Month.ToString("00") + "." + date.Year;
        }

        public void WorkRefresh(int num)
        {
            if (Lessons[num].WorkList.Count > 1)
            {
                Lessons[num].WorkLabel.Text = "";

                foreach (var work in Lessons[num].WorkList)
                    if (work.Key != "Default")
                        Lessons[num].WorkLabel.Text += work.Value.Replace("☼", ", ") + ", ";

                Lessons[num].WorkLabel.Text = Lessons[num].WorkLabel.Text.Remove(Lessons[num].WorkLabel.Text.Length - 2, 2);
            }

            else
                Lessons[num].SetTitle(Lessons[num].Title);
        }

        private void EditModeButton_Click(object sender, EventArgs e)
        { 
            editMode = !editMode;

            if (editMode)
                for (int i = 0; i < lessonsCount; i++)
                    editModeLessonsBackup[i].CopyFrom(Lessons[i]);

            else
            {
                YesNoCancelDialog dialog = new YesNoCancelDialog(Translations[ActiveLanguage]["Edit mode"]);

                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.No)
                    for (int i = 0; i < lessonsCount; i++)
                        Lessons[i].CopyFrom(editModeLessonsBackup[i]);

                else if (result == DialogResult.Cancel)
                    editMode = true;

                else
                    for(int i = 0; i < Days[date].Lessons.Count; i++)
                        Days[date].Lessons[i].CopyFrom(Lessons[i]);
            }

            editModeButton.ForeColor = editMode ? Color.LimeGreen : new Color();

            LessonsRefresh();

            for (int i = 0; i < lessonsCount; i++)
                Lessons[i].AddWorkButton.Visible = editMode;

            for (int i = 0; i < MaxLessonsCount; i++)
                Lessons[i].UpdateSizes(CellSize, editMode);
        }

        private void SaveScreenButton_Click(object sender, EventArgs e)
        {
            InDevelop();
        }

        private void DateMinusButton_Click(object sender, EventArgs e)
        {
            if (editMode)
            {
                NoEditMode();
                return;
            }

            do
            {
                date = date.AddDays(-1);

                if (date <= firstDay)
                    date = lastDay;
            }
            while (!Days[date].IsWorking);

            LessonsRefresh();
        }

        private void DatePlusButton_Click(object sender, EventArgs e)
        {
            if (editMode)
            {
                NoEditMode();
                return;
            }

            do
            {
                date = date.AddDays(1);

                if (date >= lastDay)
                    date = firstDay;
            }
            while (!Days[date].IsWorking);

            LessonsRefresh();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            if(editMode)
            {
                NoEditMode();
                return;
            }

            Settings settings = new Settings();
            settings.ShowDialog();

            SetColor(settings.Color);
            SetLanguage(ActiveLanguage);
            LoadHolydays();
            LoadTranslations();
        }

        private void SetLanguage(string language)
        {
            foreach (var control in LocalizationControls)
                if (!string.IsNullOrEmpty(control.Text) && !string.IsNullOrEmpty(control.AccessibleName))
                    control.Text = Translations[language][control.AccessibleName];

            for(int i = 0; i < lessonsCount; i++)
                WorkRefresh(i);
        }

        private void SetColor(Color color)
        {
            Color = color;

            ForeColor = Color;

            foreach (var lesson in Lessons)
                if(lesson.Enabled)
                    lesson.NumLabel.ForeColor = Color;
        }

        private void InDevelop()
        {
            MessageBox.Show(Translations[ActiveLanguage]["In the develop"], "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private static void NoEditMode()
        {
            MessageBox.Show(Translations[ActiveLanguage]["Doesn't work in edit mode"], "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void LessonsPanelMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                DatePlusButton_Click(sender, e);

            else
                DateMinusButton_Click(sender, e);
        }

        private void TimerButton_Click(object sender, EventArgs e)
        {
            TimerForm form = new TimerForm();

            form.Show();
        }

        private void FeedbackButton_Click(object sender, EventArgs e)
        {
            Feedback form = new Feedback();

            form.Show();
        }

        private void TitleClick(object sender, EventArgs e)
        {
            if (editMode)
            {
                int num = Convert.ToInt32(((Label)sender).Tag);
                LessonSelectForm form = new LessonSelectForm(num);

                if (form.ShowDialog() == DialogResult.OK)
                    Lessons[num - 1].SetTitle(form.Lesson);
            }
        }

        private void AddWorkButtonClick(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(((Button)sender).Tag);

            WorkAddForm form = new WorkAddForm(num);

            if (form.ShowDialog() == DialogResult.OK)
            {
                Lessons[num - 1].WorkList.Clear();

                foreach (var work in form.WorkList)
                {
                    Lessons[num - 1].WorkList.Add(work.Key, "");

                    foreach (var text in work.Value)
                        Lessons[num - 1].WorkList[work.Key] += text + '☼';

                    Lessons[num - 1].WorkList[work.Key] = Lessons[num - 1].WorkList[work.Key].Remove(Lessons[num - 1].WorkList[work.Key].Length - 1, 1);
                }

                WorkRefresh(num - 1);
            }
        }
    }
}