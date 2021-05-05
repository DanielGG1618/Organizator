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
        public Image Attachment;

        public UndoneLesson(string title, string homework, DateTime date, int num, Image attachment, int i)
        {
            InitializeComponent();

            SetTheme(i);
            SetTitle(title);

            DoneCheckBox.Tag = num;
            DoneCheckBox.AccessibleDescription = date.ToString("yyyy-MM-dd");

            workLabel.Text = homework;
            dateLabel.Text = $"{date:dd.MM.yyyy} - {Localization.Translate(date.DayOfWeek.ToString())}";
            Attachment = attachment;
            UpdateAttachmentLink();

            Theme.BlackWhiteForeControls.AddRange(new Control[] { titleLabel, dateLabel, attachmentLink, workLabel, DoneCheckBox });
        }

        private void SetTheme(int i)
        {
            Theme.GrayControls[(i + 1) % 2 + 1].AddRange(new Control[] { titleLabel, dateLabel, attachmentLink, workLabel, DoneCheckBox });
        }

        public void UpdateTheme(int i)
        {
            Theme.Apply(new Control[] { titleLabel, dateLabel, attachmentLink, workLabel, DoneCheckBox }, (i + 1) % 2 + 1);
            Theme.ApplyBlackWhiteFore(new Control[] { titleLabel, dateLabel, attachmentLink, workLabel, DoneCheckBox });
        }
        
        public void SetTitle(string title)
        {
            Title = title;

            titleLabel.AccessibleName = Title;
            titleLabel.Text = Localization.Translate(Title);
        }

        public void UpdateAttachmentLink()
        {
            attachmentLink.Visible = Attachment != null;
        }

        private void AttachmentLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new PictureForm(this).Show();
        }
    }
}
