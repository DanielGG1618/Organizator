using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Organizer.Properties;
using System.IO;

namespace Organizer
{
    public partial class Lesson : UserControlGG
    {
        public int Num = 1;
        public string Title = "";
        public string Homework = "Default";
        public Image Attachment;

        public new bool Enabled = true;
        public bool Done { get => DoneCheckBox.Checked; set => DoneCheckBox.Checked = value; }

        private string defaultHomework;

        public Lesson(int num, bool done = false)
        {
            InitializeComponent();

            Initialize(num, done);
        }

        private void Initialize(int num, bool done)
        {
            Num = num;

            NumLabel.Text = Num.ToString();
            TitleLabel.Tag = Num;
            AddAttachmentButton.Tag = Num;
            DoneCheckBox.Tag = Num;
            DoneCheckBox.Checked = done;

            UpdateTheme();
        }

        private void UpdateTheme()
        {
            NumLabel.BackColor = Main.GRAY[Num % 2];
            TitleLabel.BackColor = Main.GRAY[(Num + 1) % 2];
            AttachmentLink.BackColor = Main.GRAY[(Num + 1) % 2];
            HomeworkTextBox.BackColor = Main.GRAY[(Num + 1) % 2];
            WorkLabel.BackColor = Main.GRAY[(Num + 1) % 2];
            AddAttachmentButton.BackColor = Main.GRAY[Num % 2];
        }

        public void CopyFrom(Lesson lesson)
        {
            Title = lesson.Title;
            Homework = lesson.Homework;
            Attachment = lesson.Attachment;

            if (TitleLabel == null) TitleLabel = new Label();
            TitleLabel.AccessibleName = Title;
            TitleLabel.Text = Localization.Translate(TitleLabel.AccessibleName);

            if (WorkLabel == null) WorkLabel = new Label();
            WorkLabel.Text = lesson.Homework;

            if (DoneCheckBox == null) DoneCheckBox = new CheckBox();
            DoneCheckBox.Checked = lesson.Done;
        }

        public void TurnOff()
        {
            NumLabel.ForeColor = Main.GRAY[(Num + 1) % 2];

            TitleLabel.Text = "";
            WorkLabel.Text = "";
            DoneCheckBox.Visible = false;
            AttachmentLink.Visible = false;
            copyToNearest.Visible = false;
            Enabled = false;
        }

        public void SetTitle(string title)
        {
            Title = title;

            if (Title == "-")
                TurnOff();

            else
            {
                TitleLabel.AccessibleName = Title;
                TitleLabel.Text = Localization.Translate(Title);

                try { defaultHomework = Main.LessonsDefaultWork[Title]; }
                catch { defaultHomework = "Isn*t set"; }

                if (Homework == "Default")
                {
                    WorkLabel.AccessibleName = defaultHomework;

                    WorkLabel.Text = Localization.Translate(WorkLabel.AccessibleName);
                }

                else
                    WorkLabel.AccessibleName = "";
            }
        }

        public void SetDone(bool done)
        {
            DoneCheckBox.Checked = done;
        }

        public void UpdateAttachmentLink()
        {
            AttachmentLink.Visible = Attachment != null;

            if (Schelude.Instance.EditMode && Attachment == null)
                Schelude.Instance.RemoveAttachment(Num - 1);
        }

        public void SetMode(bool mode)
        {
            AddAttachmentButton.Visible = mode;
            HomeworkTextBox.Visible = mode;
            copyToNearest.Visible = mode;
        }

        private void AttachmentLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new PictureForm(this).Show();
        }

        private void CopyToNearest_Click(object sender, EventArgs e)
        {
            DateTime date = Schelude.Instance.Date;

            var dateNum = SQL.Select("SELECT Date, Num FROM Lessons WHERE Homework = 'Default' AND " +
                $"Date > '{date.ToString("yyyy-MM-dd")}' AND Title = '{Title}' AND Class = '{Settings.Default.Class}' ORDER BY Date");

            if (dateNum.Count == 0)
            {
                dateNum = SQL.Select("SELECT DayOfWeek, Num FROM Schelude " +
                    $"WHERE DayOfWeek > '{(int)date.DayOfWeek}' AND Class = '{Settings.Default.Class}' AND Lesson = '{Title}' ORDER BY DayOfWeek");

                if (dateNum.Count == 0)
                {
                    dateNum = SQL.Select("SELECT DayOfWeek, Num FROM Schelude " +
                        $"WHERE Class = '{Settings.Default.Class}' AND Lesson = '{Title}' ORDER BY DayOfWeek DESC");
                }

                do
                    date = date.AddDays(1);
                while ((int)date.DayOfWeek != int.Parse(dateNum[0]));

                dateNum[0] = date.ToString();
            }

            MessageBox.Show("Успешно скопировано в " + dateNum[0] + "   " + dateNum[1] + "(нет)");
        }
    }
}
