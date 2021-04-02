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

        public Lesson()
        {
            InitializeComponent();
        }

        public Lesson(int num, bool done = false)
        {
            InitializeComponent();

            Initialize(num, done);
        }

        public Lesson(int num, string title, bool done = false)
        {
            InitializeComponent();

            Initialize(num, done);

            SetTitle(title);
        }

        public Lesson(int num, string title, bool done, string homework)
        {
            Homework = homework;

            InitializeComponent();

            Initialize(num, done);

            SetTitle(title);
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

        public static string Totxt(Lesson lesson)
        {
            string txt = lesson.Num + "╫ " + lesson.Title + "╫ " + lesson.Done + "╫ " + lesson.Homework;

            return txt;
        }

        public static Lesson Fromtxt(string txt)
        {
            string[] splited = txt.Split(new string[1] { "╫ " }, StringSplitOptions.None);

            return new Lesson(int.Parse(splited[0]), splited[1], bool.Parse(splited[2]), splited[3]);
        }

        public void UpdateAttachmentLink()
        {
            AttachmentLink.Visible = Attachment != null;

            if (Schelude.Instance.EditMode && Attachment == null)
                Schelude.Instance.RemoveAttachment(Num - 1);
        }

        private void AttachmentLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new PictureForm(this).Show();
        }
    }
}
