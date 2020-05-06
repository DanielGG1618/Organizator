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
        public static Dictionary<string, Dictionary<string, string>> Translations = new Dictionary<string, Dictionary<string, string>>();

        public static string ActiveLanguage; 

        public List<Control> LocalizationControls = new List<Control>();
        public Color Color;

        private static bool firstLoad = true;

        public Settings()
        {
            if (firstLoad)
            {
                firstLoad = false;

                LoadFiles();

                Dictionary<string, string> english = new Dictionary<string, string>
                {
                    { "Language", "English" },
                    { "Add", "Add" },
                    { "Remove", "Remove" },
                    { "From", "From" },
                    { "To", "To" },
                    { "Primary", "Primary" },
                    { "Secondary", "Secondary" },
                    { "This year", "This year" },
                    { "Select color", "Select color" },
                    { "Add holydays", "Add holydays"}
                };

                Dictionary<string, string> russian = new Dictionary<string, string>
                {
                    { "Language", "Русский" },
                    { "Add", "Добавить" },
                    { "Remove", "Удалить" },
                    { "From", "От" },
                    { "To", "До" },
                    { "Primary", "Первичные" },
                    { "Secondary", "Вторичные" },
                    { "This year", "Этого года" },
                    { "Select color", "Выберите цвет" },
                    { "Add holydays", "Добавить выходные"}
                };

                Translations.Add("English", english);
                Translations.Add("Русский", russian);
            }

            Color = Head.ProjectColor;

            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            FormClosing += SaveFiles;

            LocalizationControls.AddRange(new Control[5] { languageSelector, addHolyday, fromLabel, toLabel, colorLabel });

            languageSelector.Text = ActiveLanguage;

            fromLabel.Visible = false;
            toLabel.Visible = false;

            holydayFinishPicker.Visible = false;

            holydayStartPicker.Location = new Point(0, 13);

            SetColor(Head.ProjectColor);
            SetLanguage();

            holydayTypeComboBox.SelectedIndex = 0;
        }

        private void SetColor(Color color)
        {
            Color = color;

            holyLabel.ForeColor = color;
            addHolyday.ForeColor = color;
            colorPanel.BackColor = color;
        }

        private void LanguageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveLanguage = languageSelector.Text;
            languagePict.Image = Image.FromFile("Language images/" + ActiveLanguage + ".png");

            SetLanguage();
        }

        private void LoadFiles()
        {
            ActiveLanguage = File.ReadAllLines("Save.txt")[0];
        }

        private void SaveFiles(object sender, EventArgs e)
        {
            File.WriteAllLines("Save.txt", new string[2] { ActiveLanguage, Color.R + ";" + Color.G + ";" + Color.B });
        }

        private void SetLanguage()
        {
            int holydayTypeIndex = holydayTypeComboBox.SelectedIndex;

            holydayTypeComboBox.Items.Clear();
            holydayTypeComboBox.Items.AddRange(new string[3] { Translations[ActiveLanguage]["Primary"], Translations[ActiveLanguage]["Secondary"], Translations[ActiveLanguage]["This year"] });
            holydayTypeComboBox.SelectedIndex = holydayTypeIndex;

            foreach (var control in LocalizationControls)
            {
                control.Text = Translations[ActiveLanguage][control.AccessibleName.ToString()];
            }
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

            if (holydayTypeComboBox.Text == Translations[ActiveLanguage]["Primary"])
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

            addHolyday.Text = Translations[ActiveLanguage][addHolyday.AccessibleName.ToString()];
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
