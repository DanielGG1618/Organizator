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
    public partial class UndoneLesson : UserControlGG
    {
        public int Num = 1;
        public string Title = "";
        public string Homework = "Default";
        public Image Attachment;

        public bool Done { get => DoneCheckBox.Checked; set => DoneCheckBox.Checked = value; }

        public UndoneLesson(int num, string title, bool done, string homework)
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
            DoneCheckBox.Tag = Num;
            DoneCheckBox.Checked = done;

            UpdateTheme();
        }

        private void UpdateTheme()
        {
            NumLabel.BackColor = Main.GRAY[Num % 2];
            TitleLabel.BackColor = Main.GRAY[(Num + 1) % 2];
            AttachmentLink.BackColor = Main.GRAY[(Num + 1) % 2];
            WorkLabel.BackColor = Main.GRAY[(Num + 1) % 2];
        }

        public void SetTitle(string title)
        {
            Title = title;

            TitleLabel.AccessibleName = Title;
            TitleLabel.Text = Localization.Translate(Title);
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

        private void AttachmentLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new PictureForm(this).Show();
        }
    }
}
