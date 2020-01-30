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
    public partial class Head : Form
    {
        bool developmentMode;
        DateTime dateTime;
        
        public Head()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTime = DateTime.Today;
            DateText.Text = dateTime.Day + "." + dateTime.Month.ToString("00") + "." + dateTime.Year;
        }

        private void DevelopModeButton_Click(object sender, EventArgs e)
        {
            InDevelop();
        }

        private void SaveScreenButton_Click(object sender, EventArgs e)
        {
            InDevelop();
        }

        private void LoadFromButton_Click(object sender, EventArgs e)
        {
            InDevelop();
        }

        private void SaveToButton_Click(object sender, EventArgs e)
        {
            InDevelop();
        }

        private void ChangesButton_Click(object sender, EventArgs e)
        {
            InDevelop();
        } 

        private void DateMinusButton_Click(object sender, EventArgs e)
        {
            dateTime = dateTime.AddDays(-1);
            DateText.Text = dateTime.Day + "." + dateTime.Month.ToString("00") + "." + dateTime.Year;
        }
        
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        private void InDevelop()
        {
            MessageBox.Show("Кнопка в разработке", "Эrrоr");
        }

        private void Title2_Click(object sender, EventArgs e)
        {
            TaskForm f = new TaskForm("Физика", "Проводники");
            f.Show();
        }

        private void DatePlusButton_Click(object sender, EventArgs e)
        {
            dateTime = dateTime.AddDays(1);
            DateText.Text = dateTime.Day + "." + dateTime.Month.ToString("00") + "." + dateTime.Year;
        }
    }
}
