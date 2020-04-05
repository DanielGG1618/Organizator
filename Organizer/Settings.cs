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
    public partial class Settings : Form
    {
        private Dictionary<string, string> ru_RU = new Dictionary<string, string>(), en_US = new Dictionary<string, string>();

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            en_US.Add("label1", "label1");
            en_US.Add("label2", "label2");
            en_US.Add("language", "Английский");

            ru_RU.Add("label1", "лейбл1");
            ru_RU.Add("label2", "лейбл2");
            ru_RU.Add("language", "Russian");

            languageSelector.SelectedIndex = 0;
        }

        private void LanguageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (languageSelector.Text == "Английский")
            {
                label1.Text = en_US["label1"];
                label2.Text = en_US["label2"];
            }
            else
            {
                label1.Text = ru_RU["label1"];
                label2.Text = ru_RU["label2"];
            }
        }
    }
}
