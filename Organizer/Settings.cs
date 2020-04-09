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
        public static Dictionary<string, Dictionary<string, string>> Languages = new Dictionary<string, Dictionary<string, string>>();

        public static string ActiveLanguage; 

        public List<Control> LocalizationControls = new List<Control>();

        private static bool firstLoad = true;

        public Settings()
        {
            if (firstLoad)
            {
                firstLoad = false;

                LoadLanguage();

                Dictionary<string, string> english = new Dictionary<string, string>(),
                                           russian = new Dictionary<string, string>();//добавить от и до лейблы

                english.Add("label1", "label1");
                english.Add("label2", "label2");
                english.Add("Language", "English");
                english.Add("Add", "Add");
                english.Add("Added", "Added");

                russian.Add("label1", "лейбл1");
                russian.Add("label2", "лейбл2");
                russian.Add("Language", "Русский");
                russian.Add("Add", "Добавить");
                russian.Add("Added", "Добавлено");

                Languages.Add("English", english);
                Languages.Add("Русский", russian);
            }

            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            FormClosing += SaveLanguage;

            LocalizationControls.AddRange(new Control[4] { label1, label2, languageSelector, AddHolyday });

            languageSelector.Text = ActiveLanguage;
            holydayTypeComboBox.SelectedIndex = 0;

            fromLabel.Visible = false;
            toLabel.Visible = false;

            holydayFinishPicker.Visible = false;

            holydayStartPicker.Location = new Point(0, 18);

            UpdateLanguage();
        }

        private void LanguageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveLanguage = languageSelector.Text;
            languagePict.Image = Image.FromFile("Language images/" + ActiveLanguage + ".png");

            UpdateLanguage();
        }

        private void LoadLanguage()
        {
            ActiveLanguage = File.ReadAllText("Save.txt");
        }

        private void SaveLanguage(object sender, EventArgs e)
        {
            File.WriteAllText("Save.txt", ActiveLanguage);
        }

        private void UpdateLanguage()
        {
            foreach (var control in LocalizationControls)
            {
                control.Text = Languages[ActiveLanguage][control.AccessibleName.ToString()];
            }
        }

        private void AddHolyday_Click(object sender, EventArgs e)
        {
            if (CanAdd())
            {
                File.AppendAllText("Holydays.txt", HolydayToAdd() + "\r\n");

                AddHolyday.AccessibleName = "Added";
                AddHolyday.Text = Languages[ActiveLanguage][AddHolyday.AccessibleName.ToString()];
            }
        }

        private void HolydayStartPicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateAddHolydayButtonStatus();
        }

        private void HolydayFinishPicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateAddHolydayButtonStatus();
        }

        private void HolydayTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAddHolydayButtonStatus();

            if (holydayTypeComboBox.Text == "Первичные")
            {
                fromLabel.Visible = false;
                toLabel.Visible = false;

                holydayFinishPicker.Visible = false;

                holydayStartPicker.Location = new Point(0, 18);
            }

            else
            {
                fromLabel.Visible = true;
                toLabel.Visible = true;

                holydayFinishPicker.Visible = true;

                holydayStartPicker.Location = new Point(0, 0);
            }
        }

        private bool CanAdd()
        {
            string[] holydays = File.ReadAllLines("Holydays.txt");

            return !holydays.Contains(HolydayToAdd());
        }

        private void UpdateAddHolydayButtonStatus()
        {
            if (CanAdd())
                AddHolyday.AccessibleName = "Add";

            else
                AddHolyday.AccessibleName = "Added";

            AddHolyday.Text = Languages[ActiveLanguage][AddHolyday.AccessibleName.ToString()];
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
    }
}
