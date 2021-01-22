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
        private bool b = false;
        private int lastSelectedType = 0;

        public static Dictionary<string, string> Types = new Dictionary<string, string>
        {
            { "Default", "" },
            { "Other", "" },
            { "On pages", "C " },
            { "Paragraphs", "§ " },
            { "Numbers", "№ " }
        };

        public WorkAddForm(int num)
        {
            foreach (var workList in Schelude.Lessons[num - 1].WorkList)
                WorkList.Add(workList.Key, new List<string>(workList.Value));

            InitializeComponent();
        }

        private void WorkAddForm_Load(object sender, EventArgs e)
        {
            typeSelector.SelectedIndex = 0;
            typeSelector.AccessibleName = "Other";

            LocalizationControls.AddRange(new Control[2] { cancel, done });

            RefreshResult();

            ForeColor = Program.Color;

            SetLanguage(Program.Language);
        }

        private void SetLanguage(string language)
        {
            typeSelector.Items.Clear();

            foreach (var type in Types)
                if (type.Key != "Default")
                    typeSelector.Items.Add(Program.Translate(type.Key));

            typeSelector.SelectedIndex = 0;

            foreach (var control in LocalizationControls)
                control.Text = Program.Translate(control.AccessibleName);
        }

        private void SetDefaultResult()
        {
            resultPanel.Controls.Clear();

            resultPanel.Controls.Add(ResultLabelSample(Program.Translate(WorkList["Default"][0]), "Default"));
        }

        private void RefreshResult()
        {
            resultPanel.Controls.Clear();

            if (WorkList.Count > 1)
            {
                foreach (var works in WorkList)
                    if (works.Key != "Default")
                        resultPanel.Controls.AddRange(ResultLabelSampleList(works.Value.ToArray(), works.Key).ToArray());

                int previousX = 0;

                foreach (Label label in resultPanel.Controls)
                {
                    label.Text += ',';

                    label.Location = new Point(previousX, 0);
                    previousX = label.Location.X + label.Size.Width;
                }
                 
                Label lastLabel = resultPanel.Controls[resultPanel.Controls.Count - 1] as Label;

                lastLabel.Text = lastLabel.Text.Remove(lastLabel.Text.Length - 1);
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

        private Label ResultLabelSample(string text, string type)
        {
            Label resultLabelSample = new Label
            {
                AutoSize = true,
                AllowDrop = true,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular, GraphicsUnit.Point, 204),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = Types[type] + text,
                AccessibleName = type
            };

            resultLabelSample.Click += ResultLabelClick;
            resultLabelSample.MouseMove += ResultLabelMouseMove;

            return resultLabelSample;
        }

        private List<Label> ResultLabelSampleList(string[] workList, string type)
        {
            List<Label> resultLabelSampleList = new List<Label>();

            for (int i = 0; i < workList.Length; i++)
                resultLabelSampleList.Add(ResultLabelSample(workList[i], type));

            return resultLabelSampleList;
        }

        private void TypeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lastSelectedType == typeSelector.SelectedIndex)
                return;

            foreach (var type in Types)
                if (type.Key != "Default")
                    if (typeSelector.Text == Program.Translate(type.Key))
                        typeSelector.AccessibleName = type.Key;

            if (!removeMode || b)
            {
                lastSelectedType = typeSelector.SelectedIndex;
                return;
            }

            b = true;

            string labelType = selectedLabel.AccessibleName;
            string currentType = typeSelector.AccessibleName;
            string textToRemoveAdd = selectedLabel.TabIndex == resultPanel.Controls.Count - 1 ? selectedLabel.Text : selectedLabel.Text.Remove(selectedLabel.Text.Length - 1);

            if (labelType != "Other")
                textToRemoveAdd = textToRemoveAdd.Remove(0, 2);

            if (WorkList.Keys.Contains(currentType) && WorkList[currentType].Contains(textToRemoveAdd))
            {
                typeSelector.SelectedIndex = lastSelectedType;

                MessageBox.Show(Program.Translate("This task has already been added"),
                                "",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                b = false;

                lastSelectedType = typeSelector.SelectedIndex;
                return;
            }

            WorkList[labelType].Remove(textToRemoveAdd);
            if (WorkList[labelType].Count == 0)
                WorkList.Remove(labelType);

            if (WorkList.Keys.Contains(currentType))
                WorkList[currentType].Add(textToRemoveAdd);

            else
                WorkList.Add(currentType, new List<string>(new string[] { textToRemoveAdd }));

            RefreshResult();
            
            foreach (Label label in resultPanel.Controls)
            {
                string str = label.Text.Last() == ',' ? label.Text.Remove(label.Text.Length - 1) : label.Text;
                
                if (label.AccessibleName != "Other")
                    str = str.Remove(0, 2);

                if (str == textToRemoveAdd)
                    SetSelectedLabel(label);
            }

            lastSelectedType = typeSelector.SelectedIndex;
        }

        private void ResultLabelClick(object sender, EventArgs e)
        {
            Label label = (Label)sender;

            if (label.Text == Program.Translate(WorkList["Default"][0]))
                return;

            SetSelectedLabel(label);
        }

        private void ResultLabelMouseMove(object sender, EventArgs e)
        {
            Label label = (Label)sender;

            if (label.Text == Program.Translate(WorkList["Default"][0]))
                return;

            Cursor.Current = Cursors.Hand;
        }

        private void SetSelectedLabel(Label label)
        {
            selectedLabel.ForeColor = Color.White;
            selectedLabel.Location = new Point(selectedLabel.Location.X, 0);

            if (selectedLabel != label)
            {
                b = true;

                selectedLabel = label;

                typeSelector.Text = Program.Translate(label.AccessibleName);

                addTextBox.Text = selectedLabel.Text;

                if (addTextBox.Text.Last() == ',')
                    addTextBox.Text = addTextBox.Text.Remove(addTextBox.Text.Length - 1, 1);

                if (typeSelector.AccessibleName != "Other")
                    addTextBox.Text = addTextBox.Text.Remove(0, 2);

                selectedLabel.ForeColor = Program.Color;
                selectedLabel.Location = new Point(selectedLabel.Location.X, 3);

                SetRemoveMode(true);

                b = false;
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
                    MessageBox.Show(Program.Translate("Enter the task"),
                                    Program.Translate("Empty task"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                foreach (var strList in WorkList)
                {
                    foreach(string str in strList.Value)
                    {
                        if (addTextBox.Text == str && typeSelector.AccessibleName == strList.Key)
                        {
                            MessageBox.Show(Program.Translate("This task has already been added"),
                                            "",
                                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }

                if (WorkList.ContainsKey(typeSelector.AccessibleName))
                    WorkList[typeSelector.AccessibleName].Add(addTextBox.Text);

                else
                    WorkList.Add(typeSelector.AccessibleName, new List<string>(new string[1] { addTextBox.Text }));

                RefreshResult();
                addTextBox.Text = "";
            }

            else
            {
                WorkList[typeSelector.AccessibleName].Remove(addTextBox.Text);

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
            if (!removeMode || b)
                return;

            bool haveComma = selectedLabel.TabIndex != resultPanel.Controls.Count - 1;

            if (string.IsNullOrWhiteSpace(addTextBox.Text))
            {
                addTextBox.Text = selectedLabel.Text.Remove(selectedLabel.Text.Length - 1, haveComma ? 1 : 0).Remove(0, Types[selectedLabel.AccessibleName].Length);
                RemoveAddButton_Click(sender, e);

                return;
            }

            for (int i = 0; i < WorkList[typeSelector.AccessibleName].Count; i++)
            {
                if (WorkList[typeSelector.AccessibleName][i] == selectedLabel.Text.Remove(selectedLabel.Text.Length - 1, haveComma ? 1 : 0).Remove(0, Types[selectedLabel.AccessibleName].Length))
                {
                    WorkList[typeSelector.AccessibleName][i] = addTextBox.Text;

                    RefreshResult();

                    foreach (Label label in resultPanel.Controls)
                    {
                        if (addTextBox.Text == label.Text.Remove(label.Text.Length - 1, haveComma ? 1 : 0).Remove(0, Types[label.AccessibleName].Length))
                        {
                            selectedLabel = label;

                            selectedLabel.ForeColor = Program.Color;
                            selectedLabel.Location = new Point(selectedLabel.Location.X, 3);
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
