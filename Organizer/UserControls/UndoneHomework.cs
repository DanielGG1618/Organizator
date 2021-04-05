using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Organizer.Properties;

namespace Organizer
{
    public partial class UndoneHomework : UserControlGG
    {
        public static UndoneHomework Instance;

        public static int MaxLessonsCount = 8; 

        public static Lesson[] Lessons;
        public static Dictionary<DateTime, Day> Days = new Dictionary<DateTime, Day>();

        public int LessonsCount;
        public bool EditMode;

        private Lesson[] editModeLessonsBackup;
        private string[] attachments;
        private DateTime date, firstDay, lastDay;

        public UndoneHomework()
        {
            Instance = this;

            LoadDays();

            firstDay = new DateTime(Program.Year, 9, 1).ToLocalTime().Date;

            lastDay = new DateTime(Program.Year + 1, 5, 31).ToLocalTime().Date;

            date = DateTime.Today;

            do
            {
                date = date.AddDays(1);

                if (date >= lastDay)
                    date = firstDay;
            }
            while (!Days[date].IsWorking());

            attachments = new string[Main.MaxLessonsCount];
            editModeLessonsBackup = new Lesson[Main.MaxLessonsCount];
            for (int i = 0; i < Main.MaxLessonsCount; i++)
            {
                attachments[i] = "";
                editModeLessonsBackup[i] = new Lesson(i + 1);
            }

            InitializeComponent();
        }

        private void UndoneHomework_Load(object sender, EventArgs e)
        {
            lessonsPanel.Controls.Clear();

            Lessons = new Lesson[Main.MaxLessonsCount];

            for (int i = 0; i < Main.MaxLessonsCount; i++)
            {
                Lessons[i] = new Lesson(i + 1);
                Lesson lesson = Lessons[i];

                lesson.DoneCheckBox.CheckStateChanged += DoneCheckedChanged;

                lesson.Location = new Point(0, 70 * i);
                lessonsPanel.Controls.Add(lesson);

                LocalizationControls.Add(lesson);
                LocalizationControls.Add(lesson);
            }

            LessonsRefresh();

            ApplyColor();
            ApplyTheme();
        }

        private void DoneCheckedChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(((CheckBox)sender).Tag);

            Days[date].Lessons[num - 1].SetDone(((CheckBox)sender).Checked);
        }

        public void WorkRefresh(int num)
        {
            if (Lessons[num].Homework == "Default")
            {
                Lessons[num].SetTitle(Lessons[num].Title);
                Lessons[num].HomeworkTextBox.Text = "";
            }

            else
            {
                Lessons[num].WorkLabel.Text = Lessons[num].Homework;
                Lessons[num].HomeworkTextBox.Text = Lessons[num].Homework;
            }
        }

        private void LessonsRefresh()
        {
            LessonsCount = int.Parse(SQL.Select("SELECT COUNT(Title) FROM Lessons " +
                $"WHERE Date = '{date.ToString("yyyy-MM-dd")}' AND Class = '{Settings.Default.Class}'")[0]);

            if (LessonsCount == 0)
            {
                LessonsCount = int.Parse(SQL.Select("SELECT COUNT(Lesson) FROM UndoneHomework " +
                        $"WHERE DayOfWeek = '{(int)date.DayOfWeek}' AND Class = '{Settings.Default.Class}'")[0]);
            }

            for (int i = 0; i < LessonsCount; i++)
            {
                Lessons[i].NumLabel.ForeColor = Settings.Default.Color;
                Lessons[i].DoneCheckBox.Visible = true;
                
                try
                {
                    List<string> titleHomework = SQL.Select("SELECT Title, Homework FROM Lessons " +
                        $"WHERE Num = '{i + 1}' AND Date = '{date.ToString("yyyy-MM-dd")}' AND Class = '{Settings.Default.Class}'");

                    Lessons[i].SetTitle(titleHomework[0]);
                    Lessons[i].Homework = titleHomework[1];

                    Lessons[i].Attachment = SQL.SelectImage("SELECT Attachments FROM Lessons " +
                        $"WHERE Num = '{i + 1}' AND Date = '{date.ToString("yyyy-MM-dd")}' AND Class = '{Settings.Default.Class}'");
                }
                catch
                {
                    string title = SQL.Select("SELECT Lesson FROM UndoneHomework " +
                        $"WHERE DayOfWeek = '{(int)date.DayOfWeek}' AND Num = '{i + 1}' AND Class = '{Settings.Default.Class}'")[0];

                    SQL.Insert("INSERT INTO Lessons (Title, Homework, Num, Date, Class) " + 
                        $"VALUES ('{title}', 'Default', '{i + 1}', '{date.ToString("yyyy-MM-dd")}', '{Settings.Default.Class}')");

                    Lessons[i].SetTitle(title);
                    Lessons[i].Homework = "Default";
                }

                Lessons[i].Done = Days[date].Lessons[i].Done;

                Lessons[i].UpdateAttachmentLink();
                WorkRefresh(i);
            }

            for (int i = Main.MaxLessonsCount - 1; i >= LessonsCount; i--)
                Lessons[i].TurnOff();
        }

        private void CopyScreen_Click(object sender, EventArgs e)
        {
            copyScreen.Visible = false;
            titleText.Font = new Font(titleText.Font.FontFamily, 20);

            Clipboard.SetImage(Utils.GetControlScreenshot(this));

            copyScreen.Visible = true;
            titleText.Font = new Font(titleText.Font.FontFamily, 12);
        }

        public override void ApplyColor()
        {
            base.ApplyColor();

            foreach (var lesson in Lessons)
                if (lesson.Enabled)
                    lesson.NumLabel.ForeColor = Settings.Default.Color;
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
                    Days.Add(firstDay.AddDays(i), new Day(i));

                if (DateTime.IsLeapYear(Program.Year + 1))
                    Days.Add(firstDay.AddDays(273), new Day(273));
            }
        }
    }
}
