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
    public partial class UserControlGG : UserControl
    {
        public List<Control> LocalizationControls = new List<Control>();

        public UserControlGG()
        {
            InitializeComponent();
        }

        public virtual void SetColor(Color color)
        {
            ForeColor = color;
        }

        public virtual void SetTheme(bool darkTheme)
        {
            BackColor = darkTheme ? Color.FromArgb(32, 32, 32) : Color.FromArgb(255, 255, 255);
        }

        public virtual void SetLanguage(string language)
        {
            List<string> transList = Program.Select($"SELECT TransKey, TransValue FROM Translations WHERE Language = '{language}'");

            Dictionary<string, string> translations = new Dictionary<string, string>();

            for (int i = 0; i < transList.Count; i += 2)
                translations.Add(transList[i], transList[i + 1]);

            foreach (var control in LocalizationControls)
                if (!string.IsNullOrEmpty(control.Text) && !string.IsNullOrEmpty(control.AccessibleName))
                    control.Text = translations[control.AccessibleName];
        }
    }
}
