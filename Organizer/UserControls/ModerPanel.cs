using System;
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
    public partial class ModerPanel : UserControlGG
    {
        public ModerPanel()
        {
            InitializeComponent();

            Theme.GrayControls[2].Add(addHoliday);
            Theme.GrayControls[3].Add(this);
            Theme.BlackWhiteForeControls.AddRange(new Control[] { fromLabel, toLabel });
        }

        private void ModerPanel_Load(object sender, EventArgs e)
        {
            LocalizationControls.AddRange(new Control[] { addHoliday, fromLabel, toLabel, holiLabel });

            holidayFromPicker.Value = DateTime.Today;
            holidayToPicker.Value = DateTime.Today;
        }

        private void AddHoliday_Click(object sender, EventArgs e)
        {
            if (Holidays.AlreadyHasBeenAdded(GetHolidayFrom(), GetHolidayTo()))
                Holidays.Delete(GetHolidayFrom(), GetHolidayTo());

            else
                Holidays.Add(GetHolidayFrom(), GetHolidayTo());

            UpdateAddHolidayButtonStatus();
            Holidays.ReloadDBHolidays();
        }

        private void HolidayStartPicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateAddHolidayButtonStatus();

            holidayToPicker.MinDate = GetHolidayFrom();
        }

        private void HolidayFinishPicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateAddHolidayButtonStatus();

            holidayFromPicker.MaxDate = GetHolidayTo();
        }

        private void UpdateAddHolidayButtonStatus()
        {
            if (Holidays.AlreadyHasBeenAdded(GetHolidayFrom(), GetHolidayTo()))
                addHoliday.AccessibleName = "Remove";

            else
                addHoliday.AccessibleName = "Add";

            addHoliday.Text = Localization.Translate(addHoliday.AccessibleName);
        }

        private DateTime GetHolidayFrom()
        {
            return DateTime.Parse(holidayFromPicker.Text);
        }

        private DateTime GetHolidayTo()
        {
            return DateTime.Parse(holidayToPicker.Text);
        }
    }
}
