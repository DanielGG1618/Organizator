﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Organizer.Properties;

namespace Organizer
{
    public partial class Schelude : UserControlGG
    {
        public static Schelude Instance;
        public static Bitmap Screenshot;

        public static Lesson[] Lessons;

        public int LessonsCount;
        public bool EditMode;

        public DateTime Date;

        private Lesson[] _editModeLessonsBackup;
        private string[] _attachments;
        private bool[] _doneStatuses;
        private DateTime _firstDay, _lastDay;

        public Schelude()
        {
            Instance = this;

            _firstDay = new DateTime(Program.Year, 9, 1).ToLocalTime().Date;
            _lastDay = new DateTime(Program.Year + 1, 5, 31).ToLocalTime().Date;

            Date = DateTime.Today;

            do
            {
                Date = Date.AddDays(1);

                if (Date >= _lastDay)
                    Date = _firstDay;
            }
            while (!Utils.IsWorking(Date));

            _attachments = new string[Main.MAX_LESSONS_COUNT];
            _doneStatuses = new bool[Main.MAX_LESSONS_COUNT];
            _editModeLessonsBackup = new Lesson[Main.MAX_LESSONS_COUNT];
            for (int i = 0; i < Main.MAX_LESSONS_COUNT; i++)
            {
                _attachments[i] = "";
                _editModeLessonsBackup[i] = new Lesson(i + 1);
            }

            InitializeComponent();

            Theme.GrayControls[0].AddRange(new Control[] { dateMinusButton, datePlusButton });
            Theme.GrayControls[2].AddRange(new Control[] { editModeButton, copyScreen, dateText });
            Theme.GrayControls[3].Add(this);
        }

        private void Schelude_Load(object sender, EventArgs e)
        {
            lessonsPanel.Controls.Clear();
            lessonsPanel.MouseWheel += LessonsPanelMouseWheel;

            Lessons = new Lesson[Main.MAX_LESSONS_COUNT];

            for (int i = 0; i < Main.MAX_LESSONS_COUNT; i++)
            {
                Lessons[i] = new Lesson(i + 1);
                Lesson lesson = Lessons[i];

                lesson.TitleLabel.Click += TitleClick;
                lesson.TitleLabel.MouseMove += TitleMouseMove;

                lesson.AddAttachmentButton.Click += AddAttachmentClick;

                lesson.DoneCheckBox.CheckStateChanged += DoneCheckedChanged;

                lesson.Location = new Point(0, 70 * i);
                lessonsPanel.Controls.Add(lesson);

                LocalizationControls.Add(lesson);
                LocalizationControls.Add(lesson);
            }

            LessonsRefresh();

            ApplyColor();

            UpdateRole(Settings.Default.Role);
        }

        public void DateMinusPlus()
        {
            DateMinusButton_Click(0, new EventArgs());
            DatePlusButton_Click(0, new EventArgs());
        }

        private void DatePlusButton_Click(object sender, EventArgs e)
        {
            if (EditMode)
            {
                NoEditMode();
                return;
            }

            SaveDoneStatuses();

            int step = ModifierKeys == Keys.Shift ? 7 : 1;

            do
            {
                Date = Date.AddDays(step);

                if (Date >= _lastDay)
                    Date = _firstDay;
            }
            while (!Utils.IsWorking(Date));

            LessonsRefresh();
        }

        private void DateMinusButton_Click(object sender, EventArgs e)
        {
            if (EditMode)
            {
                NoEditMode();
                return;
            }

            SaveDoneStatuses();

            int step = ModifierKeys == Keys.Shift ? 7 : 1;

            do
            {
                Date = Date.AddDays(-step);

                if (Date <= _firstDay)
                    Date = _lastDay;
            }
            while (!Utils.IsWorking(Date));

            LessonsRefresh();
        }

        private void EditModeButton_Click(object sender, EventArgs e)
        {
            SaveDoneStatuses();

            EditMode = !EditMode;

            if (EditMode)
                for (int i = 0; i < LessonsCount; i++)
                    _editModeLessonsBackup[i].CopyFrom(Lessons[i]);

            else
            {
                YesNoCancelDialog dialog = new YesNoCancelDialog(Localization.Translate("Edit mode"));

                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.No)
                {
                    for (int i = 0; i < LessonsCount; i++)
                        Lessons[i].CopyFrom(_editModeLessonsBackup[i]);

                    LessonsRefresh();
                }

                else if (result == DialogResult.Cancel)
                    EditMode = true;

                else
                {
                    for (int i = 0; i < LessonsCount; i++)
                    {
                        Lesson lesson = Lessons[i];

                        lesson.Homework = lesson.HomeworkTextBox.Text == "" ? "Default" : lesson.HomeworkTextBox.Text;

                        try
                        {
                            SQL.Insert($"INSERT INTO Lessons (Homework, Title, Num, Date, Class) VALUES " +
                                $"('{lesson.Homework.ToString().Replace("'"[0], '"').Replace('`', '"')}', " +
                                $"'{lesson.Title}', '{(i + 1)}', " +
                                $"'{Date.ToString("yyyy-MM-dd")}', '{Settings.Default.Class}')");
                        }
                        
                        catch
                        {
                            SQL.Insert($"UPDATE Lessons SET " +
                                $"Homework = '{lesson.Homework.Replace("'"[0], '"').Replace('`', '"')}', " +
                                $"Title = '{lesson.Title}' " +
                                $"WHERE Num = '{lesson.Num}' AND Date = '{Date.ToString("yyyy-MM-dd")}' AND " +
                                $"Class = '{Settings.Default.Class}'");
                        }

                        if (_attachments[i] == "remove")
                        {
                            try
                            {
                                SQL.Insert($"UPDATE Lessons SET Attachments = '' " +
                                    $"WHERE Num = '{lesson.Num}' AND Date = '{Date.ToString("yyyy-MM-dd")}' AND " +
                                    $"Class = '{Settings.Default.Class}'");
                            }
                            catch (Exception exeption)
                            {
                                MessageBox.Show(exeption.Message, Localization.Translate("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        else if (_attachments[i] != "")
                        {
                            try
                            {
                                SQL.UpdateFile($"UPDATE Lessons SET Attachments = @File " +
                                    $"WHERE Num = '{lesson.Num}' AND Date = '{Date.ToString("yyyy-MM-dd")}' AND " +
                                    $"Class = '{Settings.Default.Class}'", _attachments[i]);
                            }
                            catch (Exception exeption)
                            {
                                MessageBox.Show(exeption.Message, Localization.Translate("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                        
                    LessonsRefresh();
                }
            }

            editModeButton.ForeColor = EditMode ? Color.LimeGreen : new Color();

            for (int i = 0; i < LessonsCount; i++)            
                Lessons[i].SetMode(EditMode);
        }

        private void LessonsPanelMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                DatePlusButton_Click(sender, e);

            else
                DateMinusButton_Click(sender, e);
        }

        private void AddAttachmentClick(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(((Button)sender).Tag);

            DialogResult result;

            if (Clipboard.ContainsImage())
            {
                result = MessageBox.Show(Localization.Translate("There is image in clipboard. Use it?"), "", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                    AddAttachmentViaClipboard(num);

                else
                    AddAttachmentViaFileDialog(num);
            }
            else

            {
                AddAttachmentViaFileDialog(num);
            }
        }

        private void AddAttachmentViaFileDialog(int num)
        {
            DialogResult result = openAttacmentDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                _attachments[num - 1] = openAttacmentDialog.FileName;
                AddAttachment(num, Image.FromFile(_attachments[num - 1]));
            }
        }

        private void AddAttachmentViaClipboard(int num)
        {
            Image attachment = Clipboard.GetImage();
            string path = $"Temp/From clipboard{num}.bmp";

            attachment.Save(path);
            _attachments[num - 1] = path;
            AddAttachment(num, attachment);
        }

        private void AddAttachment(int num, Image image)
        {
            Lessons[num - 1].Attachment = image;
            Lessons[num - 1].UpdateAttachmentLink();
        }

        public void RemoveAttachment(int i)
        {
            _attachments[i] = "remove";
        }

        private void DoneCheckedChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(((CheckBox)sender).Tag);
            bool done = ((CheckBox)sender).Checked;

            _doneStatuses[num - 1] = done;
        }

        public void SaveDoneStatuses()
        {
            for (int i = 0; i < LessonsCount; i++)
            {
                SQL.Insert($"UPDATE DoneStatus SET Done = '{(_doneStatuses[i] ? 1 : 0)}' " +
                    $"WHERE Date = '{Date.ToString("yyyy-MM-dd")}' AND Num = '{i + 1}' AND User = '{Settings.Default.Login}'");
            }
        }

        private void TitleClick(object sender, EventArgs e)
        {
            if (!EditMode)
                return;

            int num = Convert.ToInt32(((Label)sender).Tag);
            LessonSelectForm form = new LessonSelectForm(num);

            if (form.ShowDialog() == DialogResult.OK)
                Lessons[num - 1].SetTitle(form.Lesson);
        }

        private void TitleMouseMove(object sender, EventArgs e)
        {
            if (!EditMode)
                return;

            Cursor.Current = Cursors.Hand;
        }

        public void WorkRefresh(int num)
        {
            if (!Lessons[num].Enabled)
                return;

            if (Lessons[num].Homework == "Default")
            {
                Lessons[num].SetTitle(Lessons[num].Title);
                Lessons[num].HomeworkTextBox.Text = "";
            }

            else
            {
                Lessons[num].WorkLabel.Text = Lessons[num].Homework;
                Lessons[num].HomeworkTextBox.Text = Lessons[num].Homework;
            }
        }

        public void UpdateRole(Roles role)
        {
            switch (role)
            {
                case Roles.Admin:
                    editModeButton.Visible = true;
                    break;

                case Roles.Moderator:
                    editModeButton.Visible = true;
                    break;

                case Roles.Regular:
                    editModeButton.Visible = false;
                    break;
            }
        }

        public void LessonsRefresh()
        {
            LessonsCount = int.Parse(SQL.Select("SELECT COUNT(*) FROM Lessons " +
                $"WHERE Date = '{Date.ToString("yyyy-MM-dd")}' AND Class = '{Settings.Default.Class}'")[0]);

            List<string> titleHomework = new List<string>();
            List<Image> attachments = SQL.SelectImages($"SELECT Attachments FROM Lessons " +
                    $"WHERE Date = '{Date.ToString("yyyy-MM-dd")}' AND Class = '{Settings.Default.Class}' ORDER BY Num");
            List<bool> doneStatuses = SQL.SelectBools($"SELECT Done FROM `DoneStatus` " +
                $"WHERE Date = '{Date.ToString("yyyy-MM-dd")}' AND User = '{Settings.Default.Login}' ORDER BY Num");

            if (LessonsCount == 0)
            {
                LessonsCount = int.Parse(SQL.Select("SELECT COUNT(Lesson) FROM Schelude " +
                        $"WHERE DayOfWeek = '{(int)Date.DayOfWeek}' AND Class = '{Settings.Default.Class}'")[0]);

                if (LessonsCount == 0)
                {
                    DialogResult result = MessageBox.Show(Localization.Translate("Schelude is not found. Load default?"), "", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        LessonsCount = Main.MAX_LESSONS_COUNT;
                        for (int i = 1; i <= Main.MAX_LESSONS_COUNT; i++)
                        {
                            titleHomework.AddRange(new string[] { "Default", "Default" });
                        }
                    }
                    else
                    {
                        Main.Instance.Close();
                        return;
                    }
                }

                else
                {
                    titleHomework = SQL.Select("SELECT Lesson, 'Default' FROM Schelude " +
                                $"WHERE DayOfWeek = '{(int)Date.DayOfWeek}' AND Class = '{Settings.Default.Class}' ORDER BY Num");
                }

                string values = "";
                string doneValues = "";

                for (int i = 0; i < LessonsCount; i++)
                {
                    values += $", ('{titleHomework[2 * i]}', 'Default', '{i + 1}', '{Date.ToString("yyyy-MM-dd")}', '{Settings.Default.Class}', '')";
                    doneValues += $", ('0', '{i + 1}', '{Date.ToString("yyyy-MM-dd")}', '{Settings.Default.Login}')";
                }

                values = values.Remove(0, 1);
                doneValues = doneValues.Remove(0, 1);

                SQL.Insert("INSERT INTO Lessons (Title, Homework, Num, Date, Class, Attachments) VALUES" + values);
                SQL.Insert("INSERT INTO DoneStatus (Done, Num, Date, User) VALUES" + doneValues);
            }

            else
            {
                titleHomework = SQL.Select("SELECT Title, Homework FROM Lessons " +
                $"WHERE Date = '{Date.ToString("yyyy-MM-dd")}' AND Class = '{Settings.Default.Class}' ORDER BY Num");

                for (int i = 0; i < LessonsCount; i++)
                {
                    Lessons[i].Attachment = attachments[i];
                    Lessons[i].Done = doneStatuses[i];
                    Lessons[i].UpdateAttachmentLink();
                }
            }

            for (int i = 0; i < LessonsCount; i++)
            {
                Lessons[i].Enabled = true;
                Lessons[i].NumLabel.ForeColor = Settings.Default.Color;
                Lessons[i].DoneCheckBox.Visible = true;

                Lessons[i].SetTitle(titleHomework[2 * i]);
                Lessons[i].Homework = titleHomework[2 * i + 1];
                
                WorkRefresh(i);
            }

            for (int i = Main.MAX_LESSONS_COUNT - 1; i >= LessonsCount; i--)
                Lessons[i].TurnOff();

            dateText.Text = $"{Date.ToString("dd.MM.yyyy")} - {Localization.Translate(Date.DayOfWeek.ToString())}";
        }

        private void CopyScreen_Click(object sender, EventArgs e)
        {
            dateMinusButton.Visible = false;
            datePlusButton.Visible = false;
            copyScreen.Visible = false;
            editModeButton.Visible = false;
            dateText.Font = new Font(dateText.Font.FontFamily, 20);

            Screenshot = Utils.GetControlScreenshot(this);
            Clipboard.SetImage(Screenshot);

            dateMinusButton.Visible = true;
            datePlusButton.Visible = true;
            copyScreen.Visible = true;
            editModeButton.Visible = true;
            dateText.Font = new Font(dateText.Font.FontFamily, 12);
        }

        public override void ApplyColor()
        {
            base.ApplyColor();

            foreach (var lesson in Lessons)
                if (lesson.Enabled)
                    lesson.NumLabel.ForeColor = Settings.Default.Color;
        }

        private static void NoEditMode()
        {
            MessageBox.Show(Localization.Translate("Doesn*t work in edit mode"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
