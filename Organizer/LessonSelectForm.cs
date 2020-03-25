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

        public LessonSelectForm(string num)
        {
            InitializeComponent();
            LessonLabel.Text = "Урок №" + num;

            Head.Lesson lesson = Head.Lessons[Convert.ToInt32(num) - 1];

            comboBox1.Text = lesson.TitleLabel.Text;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lesson = comboBox1.Text;
        }
    }
}
