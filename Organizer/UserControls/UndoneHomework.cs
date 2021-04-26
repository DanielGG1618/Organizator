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
        public static List<UndoneLesson> Lessons = new List<UndoneLesson>();

        public int LessonsCount;

        public UndoneHomework()
        {
            InitializeComponent();

            LocalizationControls.AddRange(new Control[] { titleText, copyScreen });
            Theme.GrayControls[3].Add(this);
            Theme.GrayControls[2].AddRange(new Control[] { copyScreen, deleteDone, titleText });
        }

        private void UndoneHomework_Load(object sender, EventArgs e)
        {
            UpdatePanel();

            ApplyColor();

            Theme.Apply();
        }

        public void UpdatePanel()
        {
            lessonsPanel.Controls.Clear();

            List<string> undoneLessons = SQL.Select($"SELECT Title, Homework, Lessons.Date, Lessons.Num FROM DoneStatus, Lessons WHERE " +
                $"Class = '{Settings.Default.Class}' AND User = '{Settings.Default.Login}' AND Lessons.Num = DoneStatus.Num AND " +
                $"DoneStatus.Date = Lessons.Date AND Done = '0' AND Homework != 'Default' ORDER BY Lessons.Date ASC, Lessons.Num ASC");

            List<Image> attachments = SQL.SelectImages($"SELECT Attachments FROM DoneStatus, Lessons WHERE " +
                $"Class = '{Settings.Default.Class}' AND User = '{Settings.Default.Login}' AND Lessons.Num = DoneStatus.Num AND " +
                $"DoneStatus.Date = Lessons.Date AND Done = '0' AND Homework != 'Default' ORDER BY Lessons.Date ASC, Lessons.Num ASC");

            for (int i = 0; i < undoneLessons.Count; i += 4)
            {
                UndoneLesson lesson = new UndoneLesson(undoneLessons[i], undoneLessons[i + 1],
                    DateTime.Parse(undoneLessons[i + 2]), int.Parse(undoneLessons[i + 3]), attachments[i/4], i/4);
                Lessons.Add(lesson);

                lesson.DoneCheckBox.CheckStateChanged += DoneCheckedChanged;

                lesson.Location = new Point(0, 70*i/4);
                lessonsPanel.Controls.Add(lesson);
                LocalizationControls.Add(lesson);
            }
        }

        private void DoneCheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            int num = Convert.ToInt32(checkBox.Tag);
            bool done = checkBox.Checked;

            SQL.Insert($"UPDATE DoneStatus SET Done = '{(done ? 1 : 0)}' " +
                    $"WHERE Date = '{checkBox.AccessibleDescription}' AND Num = '{num}' AND User = '{Settings.Default.Login}'");
        }

        private void CopyScreen_Click(object sender, EventArgs e)
        {
            copyScreen.Visible = false;
            deleteDone.Visible = false;
            titleText.Font = new Font(titleText.Font.FontFamily, 20);

            Clipboard.SetImage(Utils.GetControlScreenshot(this));

            copyScreen.Visible = true;
            deleteDone.Visible = true;
            titleText.Font = new Font(titleText.Font.FontFamily, 12);
        }

        private void DeleteDone_Click(object sender, EventArgs e)
        {
            UpdatePanel();
        }
    }
}
