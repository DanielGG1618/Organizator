using System;
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
    public partial class YesNoCancelDialog : Form
    {
        public List<Control> LocalizationControls = new List<Control>();

        public YesNoCancelDialog(string title)
        {
            Text = title;

            InitializeComponent();
        }

        private void YesNoCancelDialog_Load(object sender, EventArgs e)
        {
            LocalizationControls.AddRange(new Control[] { yes, no, cancel, saveChanges });

            SetColor(Head.Color);
            SetLanguage(Head.ActiveLanguage);
        }

        private void SetColor(Color color)
        {
            ForeColor = color;
        }

        private void SetLanguage(string language)
        {
            foreach (var control in LocalizationControls)
                control.Text = Head.Translations[language][control.AccessibleName];
        }
    }
}
