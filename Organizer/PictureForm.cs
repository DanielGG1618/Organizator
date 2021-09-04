using Organizer.Properties;
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
    public partial class PictureForm : Form
    {
        public List<Control> LocalizationControls = new List<Control>();

        private Lesson _lesson;

        public PictureForm(Lesson lesson)
        {
            _lesson = lesson;
            base.BackgroundImage = _lesson.Attachment;

            InitializeComponent();

            deleteButton.Visible = Schelude.Instance.EditMode;
        }

        public PictureForm(UndoneLesson _lesson)
        {
            BackgroundImage = _lesson.Attachment;

            InitializeComponent();

            deleteButton.Visible = false;
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(BackgroundImage);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Localization.Translate("Delete") + '?', "", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                _lesson.Attachment = null;
                _lesson.UpdateAttachmentLink();
                Close();
            }
        }

        public void ApplyLocalization()
        {
            foreach (var control in LocalizationControls)
                if (!string.IsNullOrEmpty(control.Text) && !string.IsNullOrEmpty(control.AccessibleName))
                    control.Text = Localization.Translate(control.AccessibleName);
        }

        public void ApplyColor()
        {
            ForeColor = Settings.Default.Color;
        }

        public void ApplyTheme()
        {
            BackColor = Settings.Default.DarkTheme ? Color.FromArgb(32, 32, 32) : Color.FromArgb(255, 255, 255);
        }

        private void PictureForm_Load(object sender, EventArgs e)
        {
            LocalizationControls.AddRange(new Control[] { deleteButton, copyButton });

            ApplyColor();
            ApplyTheme();
            ApplyLocalization();
        }
    }
}
