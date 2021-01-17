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
            foreach (var control in LocalizationControls)
                try
                {
                    control.Text = Head.Translations[language][control.AccessibleName];
                }
                catch { }
        }
    }
}
