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

            Setheme();
        }

        private void Setheme()
        {
            Theme.GrayControls[Num % 2 + 1].AddRange(new Control[] { NumLabel, copyToNearest, AddAttachmentButton });
            Theme.GrayControls[(Num + 1) % 2 + 1].AddRange(new Control[] { TitleLabel, AttachmentLink, HomeworkTextBox, WorkLabel, DoneCheckBox });

            Theme.GrayControls[3].Add(this);

            Theme.BlackWhiteForeControls.AddRange(new Control[] { TitleLabel, AttachmentLink, HomeworkTextBox, WorkLabel, copyToNearest} );
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
            NumLabel.ForeColor = Theme.Gray[Settings.Default.DarkTheme][(Num + 1) % 2];

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

        public void UpdateAttachmentLink()
        {
            AttachmentLink.Visible = Attachment != null;

            if (Schelude.Instance.EditMode && Attachment == null)
                Schelude.Instance.RemoveAttachment(Num - 1);
        }

        public void SetMode(bool mode)
        {
            if (!Enabled)
                return;

            AddAttachmentButton.Visible = mode;
            HomeworkTextBox.Visible = mode;

            if (mode)
            {
                copyToNearest.Visible = Homework != "Default";
                HomeworkTextBox.Size = new Size(Homework != "Default" ? 585 : 630, 45);
            }

            else
                copyToNearest.Visible = false;
        }

        private void AttachmentLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new PictureForm(this).Show();
        }

        private void CopyToNearest_Click(object sender, EventArgs e)
        {
            DoneCheckBox.Checked = true;

            DateTime currentDate = Schelude.Instance.Date;
            DateTime nearestDate;

            var dateNum = SQL.Select("SELECT Date, Num FROM Lessons WHERE Homework = 'Default' AND " +
                $"Date > '{currentDate.ToString("yyyy-MM-dd")}' AND Title = '{Title}' AND Class = '{Settings.Default.Class}' ORDER BY Date");

            if (dateNum.Count == 0)
            {
                dateNum = SQL.Select("SELECT DayOfWeek, Num FROM Schelude " +
                    $"WHERE DayOfWeek > '{(int)currentDate.DayOfWeek}' AND Class = '{Settings.Default.Class}' AND Lesson = '{Title}' ORDER BY DayOfWeek");

                if (dateNum.Count == 0)
                {
                    dateNum = SQL.Select("SELECT DayOfWeek, Num FROM Schelude " +
                        $"WHERE Class = '{Settings.Default.Class}' AND Lesson = '{Title}' ORDER BY DayOfWeek DESC");
                }

                SQL.Insert($"INSERT INTO Lessons (Date, Num, Homework, Class) VALUES ('{dateNum[0]}', '{dateNum[1]}', " +
                    $"'{Homework}', '{Settings.Default.Class}')");

                nearestDate = currentDate.AddDays(1);

                int dayOfWeek = int.Parse(dateNum[0]);
                while ((int)currentDate.DayOfWeek != dayOfWeek)
                    currentDate = currentDate.AddDays(1);

                dateNum[0] = nearestDate.ToString("yyyy-MM-dd");
            }

            else
            {
                dateNum[0] = DateTime.Parse(dateNum[0]).ToString("yyyy-MM-dd");
                SQL.Insert($"UPDATE Lessons SET Homework = '{Homework}' WHERE Date = '{dateNum[0]}' AND Num = '{dateNum[1]}' AND Class = '{Settings.Default.Class}'");
                nearestDate = DateTime.Parse(dateNum[0]);
            }

            string isNext = currentDate.DayOfWeek > nearestDate.DayOfWeek ? " " + Localization.Translate("Next").ToLower() : "";

            MessageBox.Show($"{Localization.Translate("Successfully copied to")}{isNext} " +
                $"{Localization.Translate(DateTime.Parse(dateNum[0]).DayOfWeek.ToString()).ToLower()}");
        }
    }
}
