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
        private static DateTime[] HOLYDAYS = new DateTime[6] { new DateTime(1, 2, 22), new DateTime(1, 2, 23), new DateTime(1, 2, 24),
                                                               new DateTime(1, 3, 7),  new DateTime(1, 3, 8),  new DateTime(1, 3, 9) };

        private static int[] LESSONS_COUNT = new int[7] { 6, 7, 7, 6, 7, 0, 0 };
        private static int daysInYear = 273, year = 19;

        private bool developmentMode;
        private DateTime dateTime;
        private int lessonsCount, dayNum;

        private Lesson[] lessons = new Lesson[7];
        private Day[] days;

        private Label numLabel, titleLabel, workLabel;

        public Head()
        {
            if (DateTime.IsLeapYear(2001 + year))
                daysInYear++;
            
            days = new Day[daysInYear];

            for (int i = 0; i < daysInYear; i++)
                days[i] = new Day(i, year);

            numLabel = new Label();
            titleLabel = new Label();
            workLabel = new Label();

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTime = DateTime.Today;

            dayNum = 100;//dateTime - new DateTime(2000 + year, 9, 1);
            
            lessonsCount = days[dayNum].lessonsCount;

            for (int i = 0; i < lessonsCount; i++)
            {
                lessons[i] = new Lesson(numLabel, titleLabel, workLabel, i + 1);
                
                Controls.Add(lessons[i].numLabel);
                Controls.Add(lessons[i].titleLabel);
                Controls.Add(lessons[i].workLabel);
            }

            /*lessons[1] = new Lesson(Num1, Title1, Work1);
            lessons[2] = new Lesson(Num2, Title2, Work2);
            lessons[3] = new Lesson(Num3, Title3, Work3);
            lessons[4] = new Lesson(Num4, Title4, Work4);
            lessons[5] = new Lesson(Num5, Title5, Work5);
            lessons[6] = new Lesson(Num6, Title6, Work6);
            lessons[7] = new Lesson(Num7, Title7, Work7);*/

            LessonsRefresh();
        }

        private struct Lesson
        {
            public Label numLabel, titleLabel, workLabel;

            public Lesson(Label _numLabel, Label _titleLabel, Label _workLabel, int _num)
            {
                numLabel = _numLabel;
                numLabel.Text = _num.ToString();
                numLabel.Location = new Point(24, 117);
                numLabel.Size = new Size(70, 70);

                titleLabel = _titleLabel;

                workLabel = _workLabel;
            }
        }

        private struct Day
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
                    if (date == HOLYDAYS[i] ||
                       (HOLYDAYS[i].Year == 1 && date.Day == HOLYDAYS[i].Day && date.Month == HOLYDAYS[i].Month))
                        isWorking = false;
                }

                lessonsCount = LESSONS_COUNT[(int)date.DayOfWeek];
            }
        }

        private void LessonsRefresh()
        {
            lessonsCount = days[dayNum].lessonsCount;

            for (int i = 6; i >= lessonsCount; i--)
            {
                lessons[i].numLabel.Visible = false;
                lessons[i].titleLabel.Visible = false;
                lessons[i].workLabel.Visible = false;
            }

            DateText.Text = dateTime.Day.ToString("00") + "." + dateTime.Month.ToString("00") + "." + dateTime.Year;
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

        private void Title2_Click(object sender, EventArgs e)
        {
            TaskForm f = new TaskForm("Физика", "Проводники");
            f.Show();
        }

        private void DatePlusButton_Click(object sender, EventArgs e)
        {
            dateTime = dateTime.AddDays(1);
            dayNum++;
            LessonsRefresh();
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
