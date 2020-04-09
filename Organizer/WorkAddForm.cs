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
    public partial class WorkAddForm : Form
    {
        public Dictionary<string, string> Works = new Dictionary<string, string>();

        public WorkAddForm(int num)
        {
            foreach(var workList in Head.Lessons[num - 1].WorkList)
                Works.Add(workList.Key, workList.Value);

            InitializeComponent();
        }

        private void WorkAddForm_Load(object sender, EventArgs e)
        {
            ResultLabel.Text = Works["Default"];
        }

        private void DoneClick(object sender, EventArgs e)
        {
            
        }

        private void CancelClick(object sender, EventArgs e)
        {
            
        }

        private void ResultLabel_Click(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            bool wasAdded = false;

            foreach (var work in Works)
            {
                if (work.Key == TypeSelector.Text)
                {
                    List<string> values = new List<string>(AddTextBox.Text.Split(new string[2] { ",", " " }, StringSplitOptions.RemoveEmptyEntries));

                    foreach (var value in values)
                        Works[work.Key] += value + " | ";

                    ResultLabel.Text += work.Value;

                    AddTextBox.Text = "";

                    wasAdded = true;
                }
            }

            if (!wasAdded)
            {
                string value = "";
                foreach (var splitet in AddTextBox.Text.Split(new string[2] { ",", " " }, StringSplitOptions.RemoveEmptyEntries))
                    value += splitet + " | ";

                value.Remove(value.Length - 4, 3);

                MessageBox.Show(value);

                Works.Add(TypeSelector.Text, value);

                ResultLabel.Text += value;

                AddTextBox.Text = "";
            }
        }
    }
}
