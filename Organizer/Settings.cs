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
                                           russian = new Dictionary<string, string>();

                english.Add("label1", "label1");
                english.Add("label2", "label2");
                english.Add("Language", "English");
                english.Add("Add", "Add");

                russian.Add("label1", "лейбл1");
                russian.Add("label2", "лейбл2");
                russian.Add("Language", "Русский");
                russian.Add("Add", "Добавить");

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

            UpdateLanguage();
        }

        private void HolydayTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (holydayTypeComboBox.Text == "Первичные")
            {

            }
        }

        private void LanguageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveLanguage = languageSelector.Text;
            languagePict.Image = Image.FromFile("Language images/" + ActiveLanguage + ".png");
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
    }
}
