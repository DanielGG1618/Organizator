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
using Organizer.Properties;

namespace Organizer
{
    public partial class Options : UserControlGG
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            languageSelector.Items.Clear();
            languageSelector.Items.AddRange(SQL.Select("SELECT Name FROM Languages").ToArray());

            languageSelector.Text = Settings.Default.Language;

            fromLabel.Visible = false;
            toLabel.Visible = false;

            holydayFinishPicker.Visible = false;

            holydayStartPicker.Location = new Point(0, 13);

            LocalizationControls.AddRange(new Control[] { addHolyday, fromLabel, toLabel, colorLabel, holyLabel, this });

            ApplyColor();
            ApplyTheme();
            ApplyLocalization();

            holydayTypeComboBox.SelectedIndex = 0;
            themeCheckBox.Checked = Settings.Default.DarkTheme;
        }

        private void LanguageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.Language = languageSelector.Text;

            languagePict.Image = SQL.SelectImage($"SELECT Image FROM Languages WHERE Name = '{Settings.Default.Language}'");

            ApplyLocalization();
        }

        public void SaveSettings(object sender, EventArgs e)
        {
            Settings.Default.Save();
            //SQL.Insert($"UPDATE `Users` SET `Language` = '{Settings.Default.Language}', `Color` = '{Settings.Default.Color.ToArgb()}', `DarkTheme` = '{(Settings.Default.DarkTheme ? 1 : 0)}' WHERE `Login` = '{Settings.Default.Login}'");
        }

        public override void ApplyColor()
        {
            base.ApplyColor();
            colorPanel.BackColor = Settings.Default.Color;
        }

        public override void ApplyLocalization()
        {
            int holydayTypeIndex = holydayTypeComboBox.SelectedIndex;

            holydayTypeComboBox.Items.Clear();
            holydayTypeComboBox.Items.AddRange(new string[3] { Localization.Translate("Primary"), Localization.Translate("Secondary"), Localization.Translate("This year") });
            holydayTypeComboBox.SelectedIndex = holydayTypeIndex;

            base.ApplyLocalization();

            ((Main)Form.ActiveForm).SetLanguage();
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

            if (holydayTypeComboBox.Text != Localization.Translate("Primary"))
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

            if (holydayTypeComboBox.Text == Localization.Translate("Primary"))
            {
                holydayStartPicker.MaxDate = new DateTime(2090, 12, 31);

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

                holydayFinishPicker.MinDate = DateTime.Parse(holydayStartPicker.Text);
                holydayStartPicker.MaxDate = DateTime.Parse(holydayFinishPicker.Text);
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

            addHolyday.Text = Localization.Translate(addHolyday.AccessibleName);
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

            Settings.Default.Color = colorDialog.Color;
            ApplyColor();
            ((Main)Form.ActiveForm).ApplyColor();
        }

        private void ThemeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.DarkTheme = ((CheckBox)sender).Checked;
            ApplyTheme();
        }
    }
}
