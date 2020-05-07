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
        public string lesson;  

        public LessonSelectForm(int num)
        {
            InitializeComponent();
            LessonLabel.Text = "Урок №" + num;

            comboBox1.Text = Head.Lessons[num - 1].TitleLabel.Text;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lesson = comboBox1.Text;
        }

        private void LessonSelectForm_Load(object sender, EventArgs e)
        {
            ForeColor = Head.Color;
        }
    }
}
