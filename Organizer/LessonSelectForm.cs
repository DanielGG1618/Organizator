﻿using System;
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void DoneClick(object sender, EventArgs e)
        {
            lesson = comboBox1.Text;
            Close();
        }

        private void CancelClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}