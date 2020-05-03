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
        public Dictionary<string, List<string>> WorkList = new Dictionary<string, List<string>>();
        private bool removeMode = false;

        public WorkAddForm(int num)
        {
            foreach (var workList in Head.Lessons[num - 1].WorkList)
                WorkList.Add(workList.Key, workList.Value.Split('☼').ToList());

            InitializeComponent();
        }

        private void WorkAddForm_Load(object sender, EventArgs e)
        {
            typeSelector.SelectedIndex = 0;

            if (WorkList.Count > 1)
            {
                RefreshResult();
                typeSelector.Text = WorkList.ToArray()[1].Key;
                addTextBox.Text = WorkList.ToArray()[1].Value[0];

                if (typeSelector.Text != "Другое") addTextBox.Text = addTextBox.Text.Remove(0, 2);

                SetRemoveMode(true);
            }

            else
            {
                SetDefaultResult();
                SetRemoveMode(false);
            }
        }

        private void SetDefaultResult()
        {
            Controls.Add(ResultLabelSample(WorkList["Default"][0], 0, out _));
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!removeMode)
            {
                string textToAdd = "";

                if (WorkList.ContainsKey(typeSelector.Text))
                {
                    switch (typeSelector.Text)
                    {
                        case "На страницах":
                            textToAdd += "☼ с ";
                            break;

                        case "Параграфы":
                            textToAdd += "☼ § ";
                            break;

                        case "Номера":
                            textToAdd += "☼ № ";
                            break;
                    }

                    textToAdd += addTextBox.Text;

                    WorkList[typeSelector.Text].Add(textToAdd);
                }

                else
                {
                    switch (typeSelector.Text)
                    {
                        case "На страницах":
                            textToAdd += "с ";
                            break;

                        case "Параграфы":
                            textToAdd += "§ ";
                            break;

                        case "Номера":
                            textToAdd += "№ ";
                            break;
                    }

                    textToAdd += addTextBox.Text;

                    WorkList.Add(typeSelector.Text, new List<string>(new string[1] { textToAdd }));
                }

                RefreshResult();

                addTextBox.Text = "";
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (removeMode)
            {
                string textToRemove = addTextBox.Text;

                switch (typeSelector.Text)
                {
                    case "На страницах":
                        textToRemove = textToRemove.Insert(0, "с ");
                        break;

                    case "Параграфы":
                        textToRemove = textToRemove.Insert(0, "§ ");
                        break;

                    case "Номера":
                        textToRemove = textToRemove.Insert(0, "№ ");
                        break;
                }

                WorkList[typeSelector.Text].Remove(textToRemove);

                if (WorkList[typeSelector.Text].Count == 0)
                {
                    WorkList.Remove(typeSelector.Text);
                    SetRemoveMode(false);
                }

                RefreshResult();
            }
        }

        private void RefreshResult()
        {
            foreach (Control control in Controls)
                if (control is Label)
                    Controls.Remove(control);

            if (WorkList.Count > 1)
            {
                int previousX = 0;

                foreach (var works in WorkList)
                    if (works.Key != "Default")
                        Controls.AddRange(ResultLabelSampleList(works.Value.ToArray(), previousX, out previousX).ToArray());
            }

            else
                SetDefaultResult();
        }

        private void SetRemoveMode(bool _removeMode)
        {
            removeMode = _removeMode;

            if (removeMode)
            {
                addButton.ForeColor = Head.GRAY[0];
                removeButton.ForeColor = Head.ProjectColor;
            }

            else
            {
                addButton.ForeColor = Head.ProjectColor;
                removeButton.ForeColor = Head.GRAY[0];
            }
        }

        private Label ResultLabelSample(string text, int previousX, out int thisX)
        {
            Label resultLabelSample = new Label
            {
                AllowDrop = true,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular, GraphicsUnit.Point, 204),
                ForeColor = Color.White,
                Location = new Point(previousX + 19, 14),
                Size = new Size(444, 29),
                TextAlign = ContentAlignment.MiddleLeft,
                Text = text
            };

            thisX = resultLabelSample.Location.X + resultLabelSample.Size.Width;

            return resultLabelSample;
        }

        private List<Label> ResultLabelSampleList(string[] workList, int previousX, out int thisX)
        {
            List<Label> resultLabelSampleList = new List<Label>();

            for (int i = 0; i < workList.Length; i++)
                resultLabelSampleList.Add(ResultLabelSample(workList[i], previousX, out previousX));

            thisX = previousX;
            return resultLabelSampleList;
        }

    }
}
