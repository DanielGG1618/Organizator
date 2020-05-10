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
        public List<Control> LocalizationControls = new List<Control>();

        public string Lesson;

        public LessonSelectForm(int num)
        {
            InitializeComponent();
            lessonLabel.Text = Head.Translations[Head.ActiveLanguage]["Lesson"] + " №" + num;
        }

        private void LessonSelectForm_Load(object sender, EventArgs e)
        {
            LocalizationControls.AddRange(new Control[] { done, cancel });

            SetColor(Head.Color);
            SetLanguage(Head.ActiveLanguage);

            comboBox.Text = Head.Lessons[int.Parse(lessonLabel.Text.Last().ToString()) - 1].TitleLabel.Text;
        }

        private void SetColor(Color color)
        {
            ForeColor = color;
        }

        private void SetLanguage(string language)
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
                comboBox.Items[i] = Head.Translations[language][comboBox.Items[i].ToString()];

            foreach (var control in LocalizationControls)
                control.Text = Head.Translations[language][control.AccessibleName];
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lesson = comboBox.Text;
        }  
    }
}
