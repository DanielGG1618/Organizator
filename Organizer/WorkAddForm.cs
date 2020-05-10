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
        public List<Control> LocalizationControls = new List<Control>();

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

            LocalizationControls.AddRange(new Control[2] { cancel, done });

            RefreshResult();

            ForeColor = Head.Color;

            SetLanguage(Head.ActiveLanguage);
        }

        private void SetLanguage(string language)
        {
            typeSelector.Items.Clear();
            typeSelector.Items.AddRange(new string[4] { Head.Translations[Head.ActiveLanguage]["Other"], Head.Translations[Head.ActiveLanguage]["On pages"], Head.Translations[Head.ActiveLanguage]["Numbers"], Head.Translations[Head.ActiveLanguage]["Paragraphs"] });
            typeSelector.SelectedIndex = 0;

            foreach (var control in LocalizationControls)
                control.Text = Head.Translations[language][control.AccessibleName];
        }

        private void SetDefaultResult()
        {
            resultPanel.Controls.Clear();

            resultPanel.Controls.Add(ResultLabelSample(Head.Translations[Head.ActiveLanguage][WorkList["Default"][0]]));
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
            if (typeSelector.Text == Head.Translations[Head.ActiveLanguage]["On pages"])
                typeSelector.AccessibleName = "On pages";

            else if (typeSelector.Text == Head.Translations[Head.ActiveLanguage]["Paragraphs"])
                typeSelector.AccessibleName = "Paragraphs";

            else if (typeSelector.Text == Head.Translations[Head.ActiveLanguage]["Numbers"])
                typeSelector.AccessibleName = "Numbers";

            else
                typeSelector.AccessibleName = "Other";

            if (!removeMode)
                return;

            switch (selectedLabel.Text[0])
            {
                case 'C':
                    WorkList["On pages"].Remove(selectedLabel.Text);

                    if (WorkList["On pages"].Count == 0)
                        WorkList.Remove("On pages");
                    break;

                case '§':
                    WorkList["Paragraphs"].Remove(selectedLabel.Text);

                    if (WorkList["Paragraphs"].Count == 0)
                        WorkList.Remove("Paragraphs");
                    break;

                case '№':
                    WorkList["Numbers"].Remove(selectedLabel.Text);

                    if (WorkList["Numbers"].Count == 0)
                        WorkList.Remove("Numbers");
                    break;

                default:
                    WorkList["Other"].Remove(selectedLabel.Text);

                    if (WorkList["Other"].Count == 0)
                        WorkList.Remove("Other");
                    break;
            }

            if (selectedLabel.Text[0] == 'C' ||
                selectedLabel.Text[0] == '§' ||
                selectedLabel.Text[0] == '№')
                selectedLabel.Text = selectedLabel.Text.Remove(0, 2);

            switch (typeSelector.AccessibleName)
            {
                case "On pages":
                    selectedLabel.Text = selectedLabel.Text.Insert(0, "C ");
                    break;

                case "Paragraphs":
                    selectedLabel.Text = selectedLabel.Text.Insert(0, "§ ");
                    break;

                case "Numbers":
                    selectedLabel.Text = selectedLabel.Text.Insert(0, "№ ");
                    break;
            }

            if (WorkList.Keys.Contains(typeSelector.AccessibleName))
                WorkList[typeSelector.AccessibleName].Add(selectedLabel.Text);

            else
                WorkList.Add(typeSelector.AccessibleName, new List<string>(new string[1] { selectedLabel.Text }));

        }

        private void ResultLabel_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;

            if (label.Text == Head.Translations[Head.ActiveLanguage][WorkList["Default"][0]])
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
                        typeSelector.AccessibleName = "On pages";
                        break;

                    case '§':
                        typeSelector.AccessibleName = "Paragraphs";
                        break;

                    case '№':
                        typeSelector.AccessibleName = "Numbers";
                        break;

                    default:
                        typeSelector.AccessibleName = "Other";
                        break;
                }

                addTextBox.Text = label.Text;

                if (addTextBox.Text.Last() == ',')
                    addTextBox.Text = addTextBox.Text.Remove(addTextBox.Text.Length - 1, 1);

                if (typeSelector.AccessibleName != "Other")
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

                if (WorkList.ContainsKey(typeSelector.AccessibleName))
                {
                    switch (typeSelector.AccessibleName)
                    {
                        case "On pages":
                            textToAdd += "C ";
                            break;

                        case "Paragraphs":
                            textToAdd += "§ ";
                            break;

                        case "Numbers":
                            textToAdd += "№ ";
                            break;
                    }

                    textToAdd += addTextBox.Text;

                    RefreshResult();
                    WorkList[typeSelector.AccessibleName].Add(textToAdd);
                }

                else
                {
                    switch (typeSelector.AccessibleName)
                    {
                        case "On pages":
                            textToAdd += "C ";
                            break;

                        case "Paragraphs":
                            textToAdd += "§ ";
                            break;

                        case "Numbers":
                            textToAdd += "№ ";
                            break;
                    }

                    textToAdd += addTextBox.Text;

                    WorkList.Add(typeSelector.AccessibleName, new List<string>(new string[1] { textToAdd }));
                }

                addTextBox.Text = "";
                RefreshResult();
            }

            else
            {
                string textToRemove = addTextBox.Text;

                switch (typeSelector.AccessibleName)
                {
                    case "On pages":
                        textToRemove = textToRemove.Insert(0, "C ");
                        break;

                    case "Paragraphs":
                        textToRemove = textToRemove.Insert(0, "§ ");
                        break;

                    case "Numbers":
                        textToRemove = textToRemove.Insert(0, "№ ");
                        break;
                }

                WorkList[typeSelector.AccessibleName].Remove(textToRemove);

                if (WorkList[typeSelector.AccessibleName].Count == 0)
                    WorkList.Remove(typeSelector.AccessibleName);

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
            if (!removeMode || addTextBox.Text == Head.Translations[Head.ActiveLanguage][WorkList["Default"][0]])
                return;

            if (string.IsNullOrWhiteSpace(addTextBox.Text))
            {
                Label label = selectedLabel;

                SetSelectedLabel(selectedLabel);
                SetSelectedLabel(label);

                RemoveAddButton_Click(sender, e);

                return;
            }

            bool haveComma = selectedLabel.Text != WorkList[typeSelector.AccessibleName].Last();

            for (int i = 0; i < WorkList[typeSelector.AccessibleName].Count; i++)
            {
                if (WorkList[typeSelector.AccessibleName][i] == selectedLabel.Text.Remove(selectedLabel.Text.Length - 1, haveComma ? 1 : 0))
                {
                    switch (typeSelector.AccessibleName)
                    {
                        case "On pages":
                            WorkList[typeSelector.AccessibleName][i] = addTextBox.Text.Insert(0, "C ");
                            break;

                        case "Paragraphs":
                            WorkList[typeSelector.AccessibleName][i] = addTextBox.Text.Insert(0, "§ ");
                            break;

                        case "Numbers":
                            WorkList[typeSelector.AccessibleName][i] = addTextBox.Text.Insert(0, "№ ");
                            break;

                        default:
                            WorkList[typeSelector.AccessibleName][i] = addTextBox.Text;
                            break;
                    }

                    RefreshResult();

                    foreach (Label label in resultPanel.Controls)
                    {
                        if (WorkList[typeSelector.AccessibleName][i] == label.Text.Remove(label.Text.Length - 1, haveComma ? 1 : 0))
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
