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
        static DateTime[] HOLYDAYS = new DateTime[0];
        static int[] LESSONS_COUNT = new int[7] { 6, 7, 7, 6, 7, 0, 0 };
        static int daysInYear = 273, year = 19;

        bool developmentMode;
        DateTime dateTime;
        int lessonsCount, dayNum;

        Lesson[] lessons = new Lesson[8];
        Day[] days;

        public Head()
        {
            if (DateTime.IsLeapYear(2000 + year + 1))
                daysInYear++;
            
            days = new Day[daysInYear];

            for (int i = 0; i < daysInYear; i++)
                days[i] = new Day(i, year);

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTime = DateTime.Today;

            dayNum = 1;//dateTime - new DateTime(2000 + year1, 9, 1);
            

            lessonsCount = days[dayNum].lessonsCount;

            lessons[1] = new Lesson(Num1, Title1, Work1);
            lessons[2] = new Lesson(Num2, Title2, Work2);
            lessons[3] = new Lesson(Num3, Title3, Work3);
            lessons[4] = new Lesson(Num4, Title4, Work4);
            lessons[5] = new Lesson(Num5, Title5, Work5);
            lessons[6] = new Lesson(Num6, Title6, Work6);
            lessons[7] = new Lesson(Num7, Title7, Work7);

            Refresh();
        }

        struct Lesson
        {
            public Label numText, titleText, workText;

            public Lesson(Label _numText, Label _titleText, Label _workText)
            {
                numText = _numText;
                titleText = _titleText;
                workText = _workText;
                numText.Text = workText.Tag.ToString();
            }
        }

        public struct Day
        {
            public DateTime date;

            public bool isWorking;
            public int lessonsCount, num;

            public Day(int _num, int year)
            {
                num = _num;
                date = new DateTime(2000 + year, 9, 1).AddDays(num);

                isWorking = date.DayOfWeek != DayOfWeek.Sunday && date.DayOfWeek != DayOfWeek.Saturday;

                for (int i = 0; i < HOLYDAYS.Length; i++)
                {
                    if (date == HOLYDAYS[i])
                        isWorking = false;
                }

                lessonsCount = LESSONS_COUNT[(int)date.DayOfWeek];
            }
        }

        private void Refresh()
        {
            lessonsCount = days[dayNum].lessonsCount;

            for (int i = 7; i > lessonsCount; i--)
            {
                lessons[i].numText.Visible = false;
                lessons[i].titleText.Visible = false;
                lessons[i].workText.Visible = false;
            }

            DateText.Text = dateTime.Day.ToString("00") + "." + dateTime.Month.ToString("00") + "." + dateTime.Year;
        }

        private void DateTimeMinus(DateTime a, DateTime b)
        {
            //тут разность 2 DateTime a-b
        }

        private void DevelopModeButton_Click(object sender, EventArgs e)
        {
            InDevelop();
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
            Refresh();
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

        private void Title2_Click(object sender, EventArgs e)
        {
            TaskForm f = new TaskForm("Физика", "Проводники");
            f.Show();
        }

        private void DatePlusButton_Click(object sender, EventArgs e)
        {
            dateTime = dateTime.AddDays(1);
            dayNum++;
            Refresh();
        }

        private void Work_Click(object sender, EventArgs e)
        {
            Label work = (Label)sender;
            LessonSelectForm form = new LessonSelectForm(work.Tag.ToString());
            form.Show();
        }

        private void Title_Click(object sender, EventArgs e)
        {
            Work_Click(sender, e);
        }
    }
}
