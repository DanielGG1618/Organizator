using System;
using System.IO;
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
    public partial class Settings : Form
    {
        public List<Control> LocalizationControls = new List<Control>();
        public Color Color;

        public Settings()
        {
            Color = Head.Color;

            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            FormClosing += SaveFiles;

            LocalizationControls.AddRange(new Control[6] { languageSelector, addHolyday, fromLabel, toLabel, colorLabel, holyLabel });

            languageSelector.Text = Head.ActiveLanguage;

            fromLabel.Visible = false;
            toLabel.Visible = false;

            holydayFinishPicker.Visible = false;

            holydayStartPicker.Location = new Point(0, 13);

            SetColor(Head.Color);
            SetLanguage();

            holydayTypeComboBox.SelectedIndex = 0;
        }

        private void SetColor(Color color)
        {
            Color = color;

            ForeColor = color;
            colorPanel.BackColor = color;
        }

        private void LanguageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            Head.ActiveLanguage = languageSelector.Text;
            languagePict.Image = Image.FromFile("Language images/" + Head.ActiveLanguage + ".png");

            SetLanguage();
        }

        private void SaveFiles(object sender, EventArgs e)
        {
            File.WriteAllLines("Save.txt", new string[2] { Head.ActiveLanguage, Color.R + ";" + Color.G + ";" + Color.B });
        }

        private void SetLanguage()
        {
            int holydayTypeIndex = holydayTypeComboBox.SelectedIndex;

            holydayTypeComboBox.Items.Clear();
            holydayTypeComboBox.Items.AddRange(new string[3] { Head.Translations[Head.ActiveLanguage]["Primary"], Head.Translations[Head.ActiveLanguage]["Secondary"], Head.Translations[Head.ActiveLanguage]["This year"] });
            holydayTypeComboBox.SelectedIndex = holydayTypeIndex;

            foreach (var control in LocalizationControls)
                control.Text = Head.Translations[Head.ActiveLanguage][control.AccessibleName];
        }

        private void AddHolyday_Click(object sender, EventArgs e)
        {
            if (CanAdd())
            {
                File.AppendAllText("Holydays.txt", HolydayToAdd() + "\r\n");
            }

            else
            {
                List<string> holydays = new List<string>(File.ReadAllLines("Holydays.txt"));

                holydays.Remove(HolydayToAdd());

                File.WriteAllLines("Holydays.txt", holydays);
            }

            UpdateAddHolydayButtonStatus();
        }

        private void HolydayStartPicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateAddHolydayButtonStatus();

            holydayFinishPicker.MinDate = DateTime.Parse(holydayStartPicker.Text);
        }

        private void HolydayFinishPicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateAddHolydayButtonStatus();

            holydayStartPicker.MaxDate = DateTime.Parse(holydayFinishPicker.Text);
        }

        private void HolydayTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAddHolydayButtonStatus();

            if (holydayTypeComboBox.Text == Head.Translations[Head.ActiveLanguage]["Primary"])
            {
                fromLabel.Visible = false;
                toLabel.Visible = false;

                holydayFinishPicker.Visible = false;

                holydayStartPicker.Location = new Point(0, 13);

                addHolydayPanel.Size = new Size(295, 91);
            }

            else
            {
                fromLabel.Visible = true;
                toLabel.Visible = true;

                holydayFinishPicker.Visible = true;

                holydayStartPicker.Location = Point.Empty;

                addHolydayPanel.Size = new Size(358,91);
            }
        }
        
        private bool CanAdd()
        {
            return !File.ReadAllLines("Holydays.txt").Contains(HolydayToAdd());
        }

        private void UpdateAddHolydayButtonStatus()
        {
            if (CanAdd())
                addHolyday.AccessibleName = "Add";

            else
                addHolyday.AccessibleName = "Remove";

            addHolyday.Text = Head.Translations[Head.ActiveLanguage][addHolyday.AccessibleName];
        }

        private string HolydayToAdd()
        {
            string holydayToAdd = "";
            string[] splitedDate;

            switch (holydayTypeComboBox.SelectedIndex)
            {
                case 0:
                    splitedDate = holydayStartPicker.Text.Split('.');

                    holydayToAdd += splitedDate[0] + "." + splitedDate[1] + ".04 type: primary";
                    break;

                case 1:
                    splitedDate = holydayStartPicker.Text.Split('.');

                    holydayToAdd += splitedDate[0] + "." + splitedDate[1] + ".04-";

                    splitedDate = holydayFinishPicker.Text.Split('.');

                    holydayToAdd += splitedDate[0] + "." + splitedDate[1] + ".04 type: secondary";
                    break;

                case 2:
                    holydayToAdd += holydayStartPicker.Text + "-" + holydayFinishPicker.Text + " type: this year";
                    break;
            }

            return holydayToAdd;
        }

        private void ColorPanel_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();

            SetColor(colorDialog.Color);
        }
    }
}
