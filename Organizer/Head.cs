using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private static int[] LESSONS_COUNT = new int[7];
        private static string[,] LESSONS = new string[7, 8] {{ null, null, null, null, null, null, null, null },
                                                             { "Физкультура", "какой-то урок", "какой-то урок", "какой-то урок", "какой-то урок", "какой-то урок", null, null },
                                                             { "История", "какой-то урок", "какой-то урок", "какой-то урок", "какой-то урок", "какой-то урок", "какой-то урок", null },
                                                             { "Технология", "какой-то урок", "какой-то урок", "какой-то урок", "какой-то урок", "какой-то урок", "какой-то урок", null },
                                                             { "Физкультура", "какой-то урок", "какой-то урок", "какой-то урок", "какой-то урок", "какой-то урок", null, null },
                                                             { "Англиский язык", "какой-то урок", "какой-то урок", "какой-то урок", "какой-то урок", "какой-то урок", "Информатика", null },
                                                             { null, null, null, null, null, null, null, null }};
        private static int daysInYear = 273, year = 19;

        private DateTime dateTime;
        private int lessonsCount, dayNum;

        public static Lesson[] Lessons;
        private Day[] days;

        public static List<Work>[] Works;

        private bool editMode;

        public Head()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 10; j++)
                    if (LESSONS[i, j] == null)
                    {
                        LESSONS_COUNT[i] = j;
                        break;
                    }
            }
            MAX_LESSONS_COUNT = LESSONS_COUNT.Max();

            Lessons = new Lesson[MAX_LESSONS_COUNT];
            Works = new List<Work>[MAX_LESSONS_COUNT];

            if (DateTime.IsLeapYear(2001 + year))
                daysInYear++;

            days = new Day[daysInYear];

            for (int i = 0; i < MAX_LESSONS_COUNT; i++)
                Works[i] = new List<Work>();

            for (int i = 0; i < daysInYear; i++)
                days[i] = new Day(i, year);

            Work work = new Work("qwerg", new string[2] { "fadsfa", "dasasd" });
            work.Values.Add("asdasf");
            work.Values.Add("12345");
            Works[0].Add(work);

            InitializeComponent();
        }

        private void Head_Load(object sender, EventArgs e)
        {
            Lesson.LoadSamples();

            dateTime = DateTime.Today;

            dayNum = DateToNum(DateSubtract(dateTime, new DateTime(2000 + year, 9, 1)));

            lessonsCount = days[dayNum].lessonsCount;
            lessonsPanel.Controls.Clear();

            for(int i = 0; i < MAX_LESSONS_COUNT; i++)
            {
                Lessons[i] = new Lesson(i + 1);

                Lessons[i].workLabel.Click += WorkClick;
                Lessons[i].titleLabel.Click += TitleClick;

                lessonsPanel.Controls.Add(Lessons[i].numLabel);
                lessonsPanel.Controls.Add(Lessons[i].titleLabel);
                lessonsPanel.Controls.Add(Lessons[i].workLabel);
            }

            Lessons[0].workLabel.Text = "Скачай электричество";
            Lessons[0].titleLabel.Text = "Физика";
            Lessons[1].titleLabel.Text = "Математика";

            LessonsRefresh();
        }

        public struct Lesson
        {
            private static Label NUM_SAMPLE;
            private static Label TITLE_SAMPLE;
            private static Label WORK_SAPMLE;
            public Label numLabel, titleLabel, workLabel;

            public static void LoadSamples()
            {
                NUM_SAMPLE = new Label();
                TITLE_SAMPLE = new Label();
                WORK_SAPMLE = new Label();

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
            }

            public Lesson(int num)
            {
                LoadSamples();
                numLabel = NUM_SAMPLE;
                numLabel.Text = num.ToString();
                numLabel.Location = new Point(0, CELL_SIZE * (num - 1));
                numLabel.BackColor = GRAY[num % 2];

                titleLabel = TITLE_SAMPLE;
                titleLabel.Tag = num.ToString();
                titleLabel.Location = new Point(CELL_SIZE, CELL_SIZE * (num - 1));
                titleLabel.BackColor = GRAY[(num + 1) % 2];

                workLabel = WORK_SAPMLE;
                workLabel.Tag = num.ToString();
                workLabel.Location = new Point(CELL_SIZE, CELL_SIZE * (num - 1) + (int)(CELL_SIZE * 2 / 7f));
                workLabel.BackColor = GRAY[(num + 1) % 2];
            }
        }

        public struct Work
        {
            public string Type;
            public List<string> Values;

            public Work(string type)
            {
                Type = type;

                Values = new List<string>();
            }

            public Work(string type, string[] values)
            {
                Type = type;

                Values = new List<string>();
                for(int i = 0; i < values.Length; i++)
                    Values.Add(values[i]);
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

                lessonsCount = isWorking ? LESSONS_COUNT[(int)date.DayOfWeek] : 0;
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
            lessonsCount = days[dayNum].lessonsCount;

            for (int i = 0; i < lessonsCount; i++)
            {
                ReloadWorkLabel(i);

                Lessons[i].titleLabel.Text = LESSONS[(int)days[dayNum].date.DayOfWeek, i];

                Lessons[i].numLabel.Visible = true;
                Lessons[i].titleLabel.Visible = true;
                Lessons[i].workLabel.Visible = true;
            }

            for (int i = 6; i >= lessonsCount; i--)
            {
                Lessons[i].numLabel.Visible = false;
                Lessons[i].titleLabel.Visible = false;
                Lessons[i].workLabel.Visible = false;
            }

            DateText.Text = dateTime.Day.ToString("00") + "." + dateTime.Month.ToString("00") + "." + dateTime.Year;
        }

        public void ReloadWorkLabel(int num)
        {
            Lessons[num].workLabel.Text = "";

            foreach (Work work in Works[num])
                foreach (string value in work.Values)
                    Lessons[num].workLabel.Text += value + " ";
        }

        private void DevelopModeButton_Click(object sender, EventArgs e)
        {
            editMode = !editMode;
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
            dateTime = dateTime.AddDays(-1);
            dayNum--;

            while (!days[dayNum].isWorking)
            {
                dateTime = dateTime.AddDays(-1);
                dayNum--;
            }

            LessonsRefresh();
        }

        private void DatePlusButton_Click(object sender, EventArgs e)
        {
            dateTime = dateTime.AddDays(1);
            dayNum++;

            while (!days[dayNum].isWorking)
            {
                dateTime = dateTime.AddDays(1);
                dayNum++;
            }

            LessonsRefresh();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        private void InDevelop()
        {
            MessageBox.Show("Кнопка в разработке", "Эrrоr");
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
                form.ShowDialog();
                if (form.lesson != null)
                    title.Text = form.lesson;
            }
        }
    }
}
