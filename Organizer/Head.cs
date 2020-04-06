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

        private static DateTime[] HOLYDAYS = new DateTime[6] { new DateTime(1, 2, 22), new DateTime(1, 2, 23), new DateTime(1, 2, 24),
                                                               new DateTime(1, 3, 7),  new DateTime(1, 3, 8),  new DateTime(1, 3, 9) };

        private static int MAX_LESSONS_COUNT = 0;

        private const int CELL_SIZE = 70;

        private static int[] LessonsCount = new int[7];
        private static string[][] Schedule;

        private static short daysInYear = 273;
        private static int year = 19;

        private DateTime date, startPoint;
        private int lessonsCount;

        public static Lesson[] Lessons;
        private Lesson[] editModeLessonsBackup;
        private Dictionary<DateTime, Day> days = new Dictionary<DateTime, Day>();

        public static List<Work>[] Works;

        private bool editMode;

        public Head()
        {
            LoadFiles();

            startPoint = new DateTime(2000 + year, 9, 1);
            startPoint = startPoint.ToLocalTime();
            startPoint = startPoint.Date;

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
                days.Add(startPoint.AddDays(i), new Day(i, 2000 + year));

            Work work = new Work("qwerg");
            work.Values.Add("asdasf");
            work.Values.Add("12345");
            Works[0].Add(work);

            InitializeComponent();
        }

        private void Head_Load(object sender, EventArgs e)
        {
            Lesson.LoadSamples();

            date = DateTime.Today;

            do
                date = date.AddDays(1);
            while (!days[date].isWorking);

            lessonsCount = days[date].lessonsCount;
            lessonsPanel.Controls.Clear();

            for(int i = 0; i < MAX_LESSONS_COUNT; i++)
            {
                Lessons[i] = new Lesson(i + 1);

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
        }

        public struct Lesson
        {
            private static Label NUM_SAMPLE;
            private static Label TITLE_SAMPLE;
            private static Label WORK_SAPMLE;
            private static Button ADD_WORK_BUTTON;

            public Label NumLabel, TitleLabel, WorkLabel;
            public Button AddWorkButton;

            public static void LoadSamples()
            {
                NUM_SAMPLE = new Label();
                TITLE_SAMPLE = new Label();
                WORK_SAPMLE = new Label();
                ADD_WORK_BUTTON = new Button();

                NUM_SAMPLE.Size = new Size(CELL_SIZE, CELL_SIZE);
                NUM_SAMPLE.TextAlign = ContentAlignment.MiddleCenter;
                NUM_SAMPLE.Font = new Font("Microsoft Sans Serif", 36, FontStyle.Bold);
                NUM_SAMPLE.ForeColor = ProjectColor;

                TITLE_SAMPLE.Size = new Size(630, (int)(CELL_SIZE * 2 / 7f));//
                TITLE_SAMPLE.TextAlign = ContentAlignment.MiddleLeft;
                TITLE_SAMPLE.Font = new Font("Microsoft Sans Serif", 12);
                TITLE_SAMPLE.ForeColor = Color.White;

                WORK_SAPMLE.Size = new Size(630, (int)(CELL_SIZE * 5 / 7f));//
                WORK_SAPMLE.TextAlign = ContentAlignment.MiddleLeft;
                WORK_SAPMLE.Font = new Font("Microsoft Sans Serif", 12);
                WORK_SAPMLE.ForeColor = Color.White;

                ADD_WORK_BUTTON.Size = new Size(CELL_SIZE - 20, CELL_SIZE - 20);//
                ADD_WORK_BUTTON.FlatStyle = FlatStyle.Flat;
                ADD_WORK_BUTTON.TextAlign = ContentAlignment.MiddleCenter;
                ADD_WORK_BUTTON.Font = new Font("Microsoft Sans Serif", 30, FontStyle.Bold);
                ADD_WORK_BUTTON.ForeColor = Color.LimeGreen;
                ADD_WORK_BUTTON.Text = "+";
                ADD_WORK_BUTTON.Visible = false;
            }

            public Lesson(int num)
            {
                LoadSamples();
                NumLabel = NUM_SAMPLE;
                NumLabel.Text = num.ToString();
                NumLabel.Location = new Point(0, CELL_SIZE * (num - 1));
                NumLabel.BackColor = GRAY[num % 2];

                TitleLabel = TITLE_SAMPLE;
                TitleLabel.Tag = num.ToString();
                TitleLabel.Location = new Point(CELL_SIZE, CELL_SIZE * (num - 1));
                TitleLabel.BackColor = GRAY[(num + 1) % 2];

                WorkLabel = WORK_SAPMLE;
                WorkLabel.Tag = num.ToString();
                WorkLabel.Location = new Point(CELL_SIZE, CELL_SIZE * (num - 1) + (int)(CELL_SIZE * 2 / 7f));
                WorkLabel.BackColor = GRAY[(num + 1) % 2];

                AddWorkButton = ADD_WORK_BUTTON;
                AddWorkButton.Tag = num.ToString();
                AddWorkButton.Location = new Point(570 + CELL_SIZE, CELL_SIZE * (num - 1) + 10);
                AddWorkButton.BackColor = GRAY[(num + 1) % 2];
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
            public DateTime date;

            public bool isWorking;
            public int lessonsCount, num;

            public Day(int _num, int _year)
            {
                num = _num;
                date = new DateTime(2000 + _year, 9, 1).AddDays(num);

                isWorking = date.DayOfWeek != DayOfWeek.Sunday && date.DayOfWeek != DayOfWeek.Saturday;

                for (int i = 0; i < HOLYDAYS.Length; i++)
                {
                    if (date == HOLYDAYS[i] ||
                       (HOLYDAYS[i].Year == 1 && date.Day == HOLYDAYS[i].Day && date.Month == HOLYDAYS[i].Month))
                        isWorking = false;
                }

                lessonsCount = isWorking ? LessonsCount[(int)date.DayOfWeek] : 0;
            }
        }

        private DateTime DateSubtract(DateTime a, DateTime b)
        {
            return DateTime.FromBinary(a.ToBinary() - b.ToBinary());
        }

        private int DateToNum(DateTime a)
        {
            int num = 0;

            for (int i = 1; i < a.Month; i++)
                num += DateTime.DaysInMonth(1, i);

            num += a.Day;

            num--; //так нада

            return num;
        }

        private void LessonsRefresh()
        {
            lessonsCount = days[date].lessonsCount;

            for (int i = 0; i < lessonsCount; i++)
            {
                ReloadWorkLabel(i);

                Lessons[i].TitleLabel.Text = Schedule[(int)days[date].date.DayOfWeek][i];

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
                    date = date.AddDays(-1);
                while (!days[date].isWorking);

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
                    date = date.AddDays(1);
                while (!days[date].isWorking);

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
}
