using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organizer.Properties;
using System.Windows.Forms;

namespace Organizer
{
    static class Theme
    {
        public static Dictionary<bool, Color[]> Gray = new Dictionary<bool, Color[]>();

        public static List<Control>[] GrayControls = new List<Control>[4] { new List<Control>(), new List<Control>(), new List<Control>(), new List<Control>() };
        public static List<Control> BlackWhiteForeControls = new List<Control>();

        public static void InitializeGray()
        {
            Color[] darkThemeGray = new Color[4] { Color.FromArgb(64, 64, 64), Color.FromArgb(56, 56, 56), Color.FromArgb(48, 48, 48), Color.FromArgb(32, 32, 32) };
            Color[] lightThemeGray = new Color[4] { Color.FromArgb(208, 208, 208), Color.FromArgb(220, 220, 220), Color.FromArgb(232, 232, 232), Color.FromArgb(255, 255, 255) };
            Gray.Add(true, darkThemeGray);
            Gray.Add(false, lightThemeGray);
        }

        public static void Apply()
        {
            for (int i = 0; i < GrayControls.Length; i++)
                for (int j = 0; j < GrayControls[i].Count; j++)
                    GrayControls[i][j].BackColor = Gray[Settings.Default.DarkTheme][i];

            foreach (var control in BlackWhiteForeControls)
            {
                Color blackWhite = Settings.Default.DarkTheme ? Color.White : Color.FromArgb(64, 64, 64);

                control.ForeColor = blackWhite;

                if (control is LinkLabel link)
                {
                    link.LinkColor = blackWhite;
                    link.VisitedLinkColor = blackWhite;
                }
            }
        }

        public static void ApplyBlackWhiteFore(Control[] controls)
        {
            foreach (Control control in controls)
                control.ForeColor = Settings.Default.DarkTheme ? Color.White : Color.FromArgb(64, 64, 64);
        }

        public static void Apply(Control[] controls, int i)
        {
            foreach (Control control in controls)
                control.BackColor = Gray[Settings.Default.DarkTheme][i];
        }
    }
}
