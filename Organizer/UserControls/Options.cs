﻿using System;
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

            Theme.GrayControls[3].Add(this);
            Theme.BlackWhiteForeControls.AddRange(new Control[] { themeCheckBox, colorLabel });
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            languageSelector.Items.Clear();
            languageSelector.Items.AddRange(SQL.Select("SELECT Name FROM Languages").ToArray());

            languageSelector.Text = Settings.Default.Language;

            LocalizationControls.AddRange(new Control[] { themeCheckBox, colorLabel, schoolLabel, classLabel, changeClassButton });

            changeClassPanel.Visible = Settings.Default.Role != Roles.Guest;
            
            ApplyAll();

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
        }

        public override void ApplyColor()
        {
            base.ApplyColor();
            colorPanel.BackColor = Settings.Default.Color;
        }

        public override void ApplyLocalization()
        {
            base.ApplyLocalization();

            ((Main)Form.ActiveForm).ApplyLocalization();
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
            Theme.Apply();
        }

        private void ChangeClassButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(schoolTextBox.Text) || string.IsNullOrWhiteSpace(classTextBox.Text))
            {
                MessageBox.Show(Localization.Translate("Empty field"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string calssString = $"{schoolTextBox.Text};{classTextBox.Text}";

            Settings.Default.Class = calssString;

            SQL.Insert($"UPDATE Users SET Class = '{calssString}' WHERE Login = '{Settings.Default.Login}'");

            MessageBox.Show(Localization.Translate("Class was successfully changed"));
        }
    }
}
