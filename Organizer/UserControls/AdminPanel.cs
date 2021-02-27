﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer
{
    public partial class AdminPanel : UserControlGG
    {
        public AdminPanel()
        {
            InitializeComponent();
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

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            fromLabel.Visible = false;
            toLabel.Visible = false;

            holydayFinishPicker.Visible = false;

            holydayStartPicker.Location = new Point(0, 13);

            LocalizationControls.AddRange(new Control[] { addHolyday, fromLabel, toLabel, holyLabel });

            holydayTypeComboBox.SelectedIndex = 0;

            ApplyAll();
        }

        public override void ApplyLocalization()
        {
            int holydayTypeIndex = holydayTypeComboBox.SelectedIndex;

            holydayTypeComboBox.Items.Clear();
            holydayTypeComboBox.Items.AddRange(new string[3] { Localization.Translate("Primary"), Localization.Translate("Secondary"), Localization.Translate("This year") });
            holydayTypeComboBox.SelectedIndex = holydayTypeIndex;

            base.ApplyLocalization();
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

                addHolydayPanel.Size = new Size(358, 91);

                holydayFinishPicker.MinDate = DateTime.Parse(holydayStartPicker.Text);
                holydayStartPicker.MaxDate = DateTime.Parse(holydayFinishPicker.Text);
            }
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

        private bool CanAdd()
        {
            return !File.ReadAllLines("Holydays.txt").Contains(HolydayToAdd());
        }

        private void Reference_Click(object sender, EventArgs e)
        {
            Utils.InDevelop();
        }
    }
}
