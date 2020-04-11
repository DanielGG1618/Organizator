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
            foreach (var workList in Head.Lessons[num - 1].WorkList)
                Works.Add(workList.Key, workList.Value);
    
            InitializeComponent();
        }

        private void WorkAddForm_Load(object sender, EventArgs e)
        {
            TypeSelector.SelectedIndex = 0;

            if (Works.Count > 1)
            {
                RefreshResult();
            }
            else
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
            if (Works.ContainsKey(TypeSelector.Text))
            {
                switch(TypeSelector.Text)
                {
                    case "На страницах":
                        Works[TypeSelector.Text] += ", с ";
                        break;

                    case "Параграфы":
                        Works[TypeSelector.Text] += ", §";
                        break;

                    case "Номера":
                        Works[TypeSelector.Text] += ", №";
                        break;
                }

                Works[TypeSelector.Text] += AddTextBox.Text;
            }

            else
            {
                string textToAdd = "";

                switch (TypeSelector.Text)
                {
                    case "На страницах":
                        textToAdd += "с ";
                        break;

                    case "Параграфы":
                        textToAdd += "§";
                        break;

                    case "Номера":
                        textToAdd += "№";
                        break;
                }

                textToAdd += AddTextBox.Text;

                Works.Add(TypeSelector.Text, textToAdd);
            }

            RefreshResult();

            AddTextBox.Text = "";
        }

        private void RefreshResult()
        {
            ResultLabel.Text = "";

            foreach (var work in Works)
            {
                if (work.Key != "Default")
                { 
                    ResultLabel.Text += work.Value;

                    if (!work.Equals(Works.Last()))
                        ResultLabel.Text += " | ";
                }
            }
        }
    }
}
