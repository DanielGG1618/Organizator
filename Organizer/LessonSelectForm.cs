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
    public partial class LessonSelectForm : Form
    {
        public List<Control> LocalizationControls = new List<Control>();

        public string Lesson;

        private string[] lessonsKeys;

        public LessonSelectForm(int num)
        {
            InitializeComponent();
            lessonLabel.Text = Localization.Translate("Lesson") + " №" + num;

            lessonsKeys = new string[comboBox.Items.Count];
            for (int i = 0; i < comboBox.Items.Count; i++)
                lessonsKeys[i] = comboBox.Items[i].ToString();
        }

        private void LessonSelectForm_Load(object sender, EventArgs e)
        {
            LocalizationControls.AddRange(new Control[] { done, cancel });

            ApplyAll();

            comboBox.Text = Schelude.Lessons[int.Parse(lessonLabel.Text.Last().ToString()) - 1].TitleLabel.Text;
        }

        private void ApplyColor()
        {
            ForeColor = Settings.Default.Color;
        }

        private void ApplyLocalization()
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
                comboBox.Items[i] = Localization.Translate(lessonsKeys[i]);

            foreach (var control in LocalizationControls)
                control.Text = Localization.Translate(control.AccessibleName);
        }

        private void ApplyTheme()
        {

        }

        private void ApplyAll()
        {
            ApplyColor();
            ApplyTheme();
            ApplyLocalization();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lesson = lessonsKeys[comboBox.SelectedIndex];
        }

        private void LessonLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
