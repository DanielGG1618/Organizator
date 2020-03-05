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

        public Head()
        {
            if (DateTime.IsLeapYear(2001 + year))
                daysInYear++;
            
            days = new Day[daysInYear];

            for (int i = 0; i < daysInYear; i++)
                days[i] = new Day(i, year);

            InitializeComponent();
        }

        private void Head_Load(object sender, EventArgs e)
        {
            dateTime = DateTime.Today;

            dayNum = DateToNum(DateSubtract(dateTime, new DateTime(2000 + year, 9, 1)));
            
            lessonsCount = days[dayNum].lessonsCount;
            lessonsPanel.Controls.Clear();

            int y = 0;
            for (int i = 0; i < lessonsCount; i++)
            {
                lessons[i] = new Lesson(i + 1);

                lessons[i].numLabel.Location = new Point(0, y);
                lessons[i].numLabel.Size = new Size(70, 70);
                lessons[i].numLabel.TextAlign = ContentAlignment.MiddleCenter;
                lessons[i].numLabel.Font = new Font("Microsoft Sans Serif", 30, FontStyle.Bold);
                lessons[i].numLabel.Text = (i + 1).ToString();
                
                lessons[i].titleLabel.Location = new Point(70, y);
                lessons[i].titleLabel.Tag = (i + 1).ToString();
                lessons[i].titleLabel.Click += TitleClick;
                lessons[i].titleLabel.TextAlign = ContentAlignment.MiddleLeft;
                lessons[i].titleLabel.Font = new Font("Microsoft Sans Serif", 12);
                lessons[i].titleLabel.ForeColor = Color.White;

                lessons[i].workLabel.Location = new Point(70, y + 20);
                lessons[i].workLabel.Tag = (i + 1).ToString();
                lessons[i].workLabel.Click += WorkClick;
                lessons[i].workLabel.TextAlign = ContentAlignment.MiddleLeft;
                lessons[i].workLabel.Font = new Font("Microsoft Sans Serif", 12);
                lessons[i].workLabel.ForeColor = Color.White;

                lessonsPanel.Controls.Add(lessons[i].numLabel);
                lessonsPanel.Controls.Add(lessons[i].titleLabel);
                lessonsPanel.Controls.Add(lessons[i].workLabel);

                y += 70;
            }
            lessons[0].workLabel.Text = "Скачай электричество";
            lessons[0].titleLabel.Text = "Физика";
            lessons[1].titleLabel.Text = "Математика";

            LessonsRefresh();
        }

        private struct Lesson
        {
            public Label numLabel, titleLabel, workLabel;

            public Lesson(Label _numLabel, Label _titleLabel, Label _workLabel, int _num)
            {
                numLabel = _numLabel;
                numLabel.Text = _num.ToString();
                numLabel.Size = new Size(70, 70);

                titleLabel = _titleLabel;
                titleLabel.Size = new Size(621, 20);

                workLabel = _workLabel;
                workLabel.Size = new Size(621, 50);
            }
            public Lesson(int _num)
            {
                numLabel = new Label();
                numLabel.Text = _num.ToString();
                numLabel.Size = new Size(70, 70);

                titleLabel = new Label();
                titleLabel.Size = new Size(621, 20);

                workLabel = new Label();
                workLabel.Size = new Size(621, 50);
            }
        }

        private struct Day
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

                lessonsCount = LESSONS_COUNT[(int)date.DayOfWeek];
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
                lessons[i].numLabel.Visible = true;
                lessons[i].titleLabel.Visible = true;
                lessons[i].workLabel.Visible = true;
            }

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

        private void WorkClick(object sender, EventArgs e)
        {
            
        }

        private void TitleClick(object sender, EventArgs e)
        {
            Label title = (Label)sender;
            LessonSelectForm form = new LessonSelectForm(title.Tag.ToString());
            form.ShowDialog();
            title.Text = form.lesson;
        }
    }
}
