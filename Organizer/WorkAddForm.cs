using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Organizer
{
    public partial class WorkAddForm : Form
    {
        public Dictionary<string, List<string>> WorkList = new Dictionary<string, List<string>>();

        private Label selectedLabel = new Label();

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

            RefreshResult();

            ForeColor = Head.Color;
        }

        private void SetDefaultResult()
        {
            resultPanel.Controls.Clear();

            resultPanel.Controls.Add(ResultLabelSample(WorkList["Default"][0]));
        }

        private void RefreshResult()
        {
            resultPanel.Controls.Clear();

            if (WorkList.Count > 1)
            {
                foreach (var works in WorkList)
                    if (works.Key != "Default")
                        resultPanel.Controls.AddRange(ResultLabelSampleList(works.Value.ToArray()).ToArray());

                int previousX = 0;

                foreach (Label label in resultPanel.Controls)
                {
                    bool needComma = true;

                    if (WorkList.Last().Value.Last() == label.Text)
                        needComma = false;

                    if (needComma)
                        label.Text += ',';

                    label.Location = new Point(previousX, 0);
                    previousX = label.Location.X + label.Size.Width;
                }
            }

            else
                SetDefaultResult();

            SortLabelIndexes();
        }

        private void SetRemoveMode(bool _removeMode)
        {
            removeMode = _removeMode;

            if (removeMode)
            {
                removeAddButton.Text = "-";

                rightButton.Visible = true;
                leftButton.Visible = true;

                addTextBox.Location = new Point(112, 128);
                addTextBox.Size = new Size(301, 23);
            }

            else
            {
                removeAddButton.Text = "+";

                rightButton.Visible = false;
                leftButton.Visible = false;

                addTextBox.Location = new Point(19, 128);
                addTextBox.Size = new Size(394, 23);

                addTextBox.Text = "";
            }
        }

        private void SortLabelIndexes()
        {
            for(int i = 1; i < resultPanel.Controls.Count; i++)
            {
                for(int j = i;
                    j > 0 && resultPanel.Controls[j - 1].Location.X > resultPanel.Controls[j].Location.X;
                    j--)
                {
                    int tabIndex = resultPanel.Controls[i].TabIndex;

                    resultPanel.Controls[i].TabIndex = resultPanel.Controls[j].TabIndex;
                    resultPanel.Controls[j].TabIndex = tabIndex;
                }
            }
        }

        private Label ResultLabelSample(string text)
        {
            Label resultLabelSample = new Label
            {
                AutoSize = true,
                AllowDrop = true,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular, GraphicsUnit.Point, 204),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = text
            };

            resultLabelSample.Click += ResultLabel_Click;

            return resultLabelSample;
        }

        private List<Label> ResultLabelSampleList(string[] workList)
        {
            List<Label> resultLabelSampleList = new List<Label>();

            for (int i = 0; i < workList.Length; i++)
                resultLabelSampleList.Add(ResultLabelSample(workList[i]));

            return resultLabelSampleList;
        }

        private void TypeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!removeMode)
                return;

            switch (selectedLabel.Text[0])
            {
                case 'C':
                    WorkList["На страницах"].Remove(selectedLabel.Text);

                    if (WorkList["На страницах"].Count == 0)
                        WorkList.Remove("На страницах");
                    break;

                case '§':
                    WorkList["Параграфы"].Remove(selectedLabel.Text);

                    if (WorkList["Параграфы"].Count == 0)
                        WorkList.Remove("Параграфы");
                    break;

                case '№':
                    WorkList["Номера"].Remove(selectedLabel.Text);

                    if (WorkList["Номера"].Count == 0)
                        WorkList.Remove("Номера");
                    break;

                default:
                    WorkList["Другое"].Remove(selectedLabel.Text);

                    if (WorkList["Другое"].Count == 0)
                        WorkList.Remove("Другое");
                    break;
            }

            if (selectedLabel.Text[0] == 'C' ||
                selectedLabel.Text[0] == '§' ||
                selectedLabel.Text[0] == '№')
                selectedLabel.Text = selectedLabel.Text.Remove(0, 2);

            switch (typeSelector.Text)
            {
                case "На страницах":
                    selectedLabel.Text = selectedLabel.Text.Insert(0, "C ");
                    break;

                case "Параграфы":
                    selectedLabel.Text = selectedLabel.Text.Insert(0, "§ ");
                    break;

                case "Номера":
                    selectedLabel.Text = selectedLabel.Text.Insert(0, "№ ");
                    break;
            }

            if (WorkList.Keys.Contains(typeSelector.Text))
                WorkList[typeSelector.Text].Add(selectedLabel.Text);

            else
                WorkList.Add(typeSelector.Text, new List<string>(new string[1] { selectedLabel.Text }));

        }

        private void ResultLabel_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;

            if (label.Text == WorkList["Default"][0])
                return;

            SetSelectedLabel(label);
        }

        private void SetSelectedLabel(Label label)
        {
            selectedLabel.ForeColor = Color.White;

            if (selectedLabel != label)
            {
                selectedLabel = label;

                selectedLabel.ForeColor = Head.Color;

                switch (label.Text[0])
                {
                    case 'C':
                        typeSelector.Text = "На страницах";
                        break;

                    case '§':
                        typeSelector.Text = "Параграфы";
                        break;

                    case '№':
                        typeSelector.Text = "Номера";
                        break;

                    default:
                        typeSelector.Text = "Другое";
                        break;
                }

                addTextBox.Text = label.Text;

                if (addTextBox.Text.Last() == ',')
                    addTextBox.Text = addTextBox.Text.Remove(addTextBox.Text.Length - 1, 1);

                if (typeSelector.Text != "Другое")
                    addTextBox.Text = addTextBox.Text.Remove(0, 2);

                SetRemoveMode(true);
            }

            else
            {
                selectedLabel = new Label();

                SetRemoveMode(false);

                addTextBox.Text = "";
            }
        }

        private void RemoveAddButton_Click(object sender, EventArgs e)
        {
            if (!removeMode)
            {
                if (string.IsNullOrWhiteSpace(addTextBox.Text))
                {
                    MessageBox.Show("Вы не ввели текст", "Введите задание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string textToAdd = "";

                if (WorkList.ContainsKey(typeSelector.Text))
                {
                    switch (typeSelector.Text)
                    {
                        case "На страницах":
                            textToAdd += "C ";
                            break;

                        case "Параграфы":
                            textToAdd += "§ ";
                            break;

                        case "Номера":
                            textToAdd += "№ ";
                            break;
                    }

                    textToAdd += addTextBox.Text;

                    RefreshResult();
                    WorkList[typeSelector.Text].Add(textToAdd);
                }

                else
                {
                    switch (typeSelector.Text)
                    {
                        case "На страницах":
                            textToAdd += "C ";
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

                addTextBox.Text = "";
                RefreshResult();
            }

            else
            {
                string textToRemove = addTextBox.Text;

                switch (typeSelector.Text)
                {
                    case "На страницах":
                        textToRemove = textToRemove.Insert(0, "C ");
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
                    WorkList.Remove(typeSelector.Text);

                if (resultPanel.Controls.Count <= 1)
                {
                    SetRemoveMode(false);

                    RefreshResult();
                }

                else
                {
                    RefreshResult();

                    try { SetSelectedLabel(resultPanel.Controls[selectedLabel.TabIndex - 1] as Label); }
                    catch { SetSelectedLabel(resultPanel.Controls[0] as Label); }
                }
            }
        }

        private void AddTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!removeMode || addTextBox.Text == WorkList["Default"][0])
                return;

            if (string.IsNullOrWhiteSpace(addTextBox.Text))
            {
                Label label = selectedLabel;

                SetSelectedLabel(selectedLabel);
                SetSelectedLabel(label);

                RemoveAddButton_Click(sender, e);

                return;
            }

            bool haveComma = selectedLabel.Text != WorkList[typeSelector.Text].Last();

            for (int i = 0; i < WorkList[typeSelector.Text].Count; i++)
            {
                if (WorkList[typeSelector.Text][i] == selectedLabel.Text.Remove(selectedLabel.Text.Length - 1, haveComma ? 1 : 0))
                {
                    switch (typeSelector.Text)
                    {
                        case "На страницах":
                            WorkList[typeSelector.Text][i] = addTextBox.Text.Insert(0, "C ");
                            break;

                        case "Параграфы":
                            WorkList[typeSelector.Text][i] = addTextBox.Text.Insert(0, "§ ");
                            break;

                        case "Номера":
                            WorkList[typeSelector.Text][i] = addTextBox.Text.Insert(0, "№ ");
                            break;

                        default:
                            WorkList[typeSelector.Text][i] = addTextBox.Text;
                            break;
                    }

                    RefreshResult();

                    foreach (Label label in resultPanel.Controls)
                    {
                        if (WorkList[typeSelector.Text][i] == label.Text.Remove(label.Text.Length - 1, haveComma ? 1 : 0))
                        {
                            selectedLabel = label;

                            selectedLabel.ForeColor = Head.Color;
                        }
                    }
                }
            }
        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            if (!removeMode || resultPanel.Controls.Count == 1)
                return;

            SortLabelIndexes();

            try { SetSelectedLabel(resultPanel.Controls[selectedLabel.TabIndex - 1] as Label); }
            catch { SetSelectedLabel(resultPanel.Controls[resultPanel.Controls.Count - 1] as Label); }
        }   

        private void RightButton_Click(object sender, EventArgs e)
        {
            if (!removeMode || resultPanel.Controls.Count == 1)
                return;

            SortLabelIndexes();

            try { SetSelectedLabel(resultPanel.Controls[selectedLabel.TabIndex + 1] as Label); }
            catch { SetSelectedLabel(resultPanel.Controls[0] as Label); }
        }
    }
}
