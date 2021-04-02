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

        private Lesson lesson;

        public PictureForm(Lesson _lesson)
        {
            lesson = _lesson;
            BackgroundImage = lesson.Attachment;

            InitializeComponent();

            deleteButton.Visible = Schelude.Instance.EditMode;
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
                lesson.Attachment = null;
                lesson.UpdateAttachmentLink();
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
