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
        public List<Work> Works = new List<Work>();

        public WorkAddForm(string num)
        {
            Works.Add(new Work(""));
            InitializeComponent();
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
                if (work.Type == TypeSelector.Text)
                {
                    List<string> values = new List<string>(AddTextBox.Text.Split(new string[2] { ",", " " }, StringSplitOptions.RemoveEmptyEntries));

                    work.Values.AddRange(values);

                    work.LoadResult();
                    ResultLabel.Text += work.Result;

                    AddTextBox.Text = "";

                    wasAdded = true;
                }
            }

            if (!wasAdded)
            {
                List<string> values = new List<string>(AddTextBox.Text.Split(new string[2] { ",", " " }, StringSplitOptions.RemoveEmptyEntries));

                Work work = new Work(TypeSelector.Text, values);

                Works.Add(work);

                work.LoadResult();
                if (ResultLabel.Text.ToLower() == "не задано")
                    ResultLabel.Text = "";

                ResultLabel.Text += work.Result;

                AddTextBox.Text = "";
            }
        }
    }
}
