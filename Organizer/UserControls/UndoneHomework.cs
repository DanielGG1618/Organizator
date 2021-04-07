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

        public static List<UndoneLesson> Lessons;

        public int LessonsCount;

        public UndoneHomework()
        {
            Instance = this;

            InitializeComponent();
        }

        private void UndoneHomework_Load(object sender, EventArgs e)
        {
            lessonsPanel.Controls.Clear();

            Lessons = new List<UndoneLesson>();

            for (int i = 0; i < Main.MaxLessonsCount; i++)
            {
                //UndoneLesson lesson = new UndoneLesson(i + 1);
                /*Lessons.Add(lesson);

                lesson.DoneCheckBox.CheckStateChanged += DoneCheckedChanged;

                lesson.Location = new Point(0, 70 * i);
                lessonsPanel.Controls.Add(lesson);

                LocalizationControls.Add(lesson);
                LocalizationControls.Add(lesson);*/
            }

            //LessonsRefresh();

            ApplyColor();
            ApplyTheme();
        }

        private void DoneCheckedChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(((CheckBox)sender).Tag);

            //Days[date].Lessons[num - 1].SetDone(((CheckBox)sender).Checked);
        }

        public void WorkRefresh(int num)
        {
            Lessons[num].WorkLabel.Text = Lessons[num].Homework;
        }

        /*private void LessonsRefresh()
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
        }*/

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
    }
}
