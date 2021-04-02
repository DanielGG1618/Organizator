using System;
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

        public static int MaxLessonsCount = 8; 

        public static Lesson[] Lessons;
        public static Dictionary<DateTime, Day> Days = new Dictionary<DateTime, Day>();

        public int LessonsCount;
        public bool EditMode;

        private Lesson[] editModeLessonsBackup;
        private string[] attachments;
        private DateTime date, firstDay, lastDay;

        public Schelude()
        {
            Instance = this;

            LoadDays();

            firstDay = new DateTime(Program.Year, 9, 1).ToLocalTime().Date;

            lastDay = new DateTime(Program.Year + 1, 5, 31).ToLocalTime().Date;

            date = DateTime.Today;

            do
            {
                date = date.AddDays(1);

                if (date >= lastDay)
                    date = firstDay;
            }
            while (!Days[date].IsWorking());

            attachments = new string[Main.MaxLessonsCount];
            editModeLessonsBackup = new Lesson[Main.MaxLessonsCount];
            for (int i = 0; i < Main.MaxLessonsCount; i++)
            {
                attachments[i] = "";
                editModeLessonsBackup[i] = new Lesson(i + 1);
            }

            InitializeComponent();
        }

        private void Schelude_Load(object sender, EventArgs e)
        {
            lessonsPanel.Controls.Clear();
            lessonsPanel.MouseWheel += LessonsPanelMouseWheel;

            Lessons = new Lesson[Main.MaxLessonsCount];

            for (int i = 0; i < Main.MaxLessonsCount; i++)
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
            ApplyTheme();
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

            int step = ModifierKeys == Keys.Shift ? 7 : 1;

            do
            {
                date = date.AddDays(step);

                if (date >= lastDay)
                    date = firstDay;
            }
            while (!Days[date].IsWorking());

            LessonsRefresh();
        }

        private void DateMinusButton_Click(object sender, EventArgs e)
        {
            if (EditMode)
            {
                NoEditMode();
                return;
            }

            int step = ModifierKeys == Keys.Shift ? 7 : 1;

            do
            {
                date = date.AddDays(-step);

                if (date <= firstDay)
                    date = lastDay;
            }
            while (!Days[date].IsWorking());

            LessonsRefresh();
        }

        private void EditModeButton_Click(object sender, EventArgs e)
        {
            EditMode = !EditMode;

            if (EditMode)
                for (int i = 0; i < LessonsCount; i++)
                    editModeLessonsBackup[i].CopyFrom(Lessons[i]);

            else
            {
                YesNoCancelDialog dialog = new YesNoCancelDialog(Localization.Translate("Edit mode"));

                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.No)
                {
                    for (int i = 0; i < LessonsCount; i++)
                        Lessons[i].CopyFrom(editModeLessonsBackup[i]);

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
                                $"'{lesson.Title}', '{(i + 1).ToString()}', " +
                                $"'{date.ToString("yyyy-MM-dd")}', '{Settings.Default.Class}')");
                        }
                        
                        catch
                        {
                            SQL.Insert($"UPDATE Lessons SET " +
                                $"Homework = '{lesson.Homework.Replace("'"[0], '"').Replace('`', '"')}', " +
                                $"Title = '{lesson.Title}' " +
                                $"WHERE Num = '{lesson.Num}' AND Date = '{date.ToString("yyyy-MM-dd")}' AND " +
                                $"Class = '{Settings.Default.Class}'");
                        }

                        if (attachments[i] == "remove")
                        {
                            try
                            {
                                SQL.Insert($"UPDATE Lessons SET Attachments = '' " +
                                    $"WHERE Num = '{lesson.Num}' AND Date = '{date.ToString("yyyy-MM-dd")}' AND " +
                                    $"Class = '{Settings.Default.Class}'");
                            }
                            catch (Exception exeption)
                            {
                                MessageBox.Show(exeption.Message, Localization.Translate("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        else if (attachments[i] != "")
                        {
                            try
                            {
                                SQL.UpdateFile($"UPDATE Lessons SET Attachments = @File " +
                                    $"WHERE Num = '{lesson.Num}' AND Date = '{date.ToString("yyyy-MM-dd")}' AND " +
                                    $"Class = '{Settings.Default.Class}'", attachments[i]);
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
            {
                Lessons[i].AddAttachmentButton.Visible = EditMode;
                Lessons[i].HomeworkTextBox.Visible = EditMode;
            }
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

            DialogResult result = openAttacmentDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                attachments[num - 1] = openAttacmentDialog.FileName;
                Lessons[num - 1].Attachment = Image.FromFile(attachments[num - 1]);
                Lessons[num - 1].UpdateAttachmentLink();
            }
        }

        public void RemoveAttachment(int i)
        {
            attachments[i] = "remove";
        }

        private void DoneCheckedChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(((CheckBox)sender).Tag);

            Days[date].Lessons[num - 1].SetDone(((CheckBox)sender).Checked);
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

        private void LessonsRefresh()
        {
            LessonsCount = int.Parse(SQL.Select("SELECT COUNT(Title) FROM Lessons " +
                $"WHERE Date = '{date.ToString("yyyy-MM-dd")}' AND Class = '{Settings.Default.Class}'")[0]);

            if (LessonsCount == 0)
            {
                LessonsCount = int.Parse(SQL.Select("SELECT COUNT(Lesson) FROM Schelude " +
                        $"WHERE DayOfWeek = '{(int)date.DayOfWeek}' AND Class = '{Settings.Default.Class}'")[0]);
            }

            for (int i = 0; i < LessonsCount; i++)
            {
                Lessons[i].NumLabel.ForeColor = Settings.Default.Color;
                Lessons[i].DoneCheckBox.Visible = true;
                
                try
                {
                    List<string> titleHomework = SQL.Select("SELECT Title, Homework FROM Lessons " +
                        $"WHERE Num = '{i + 1}' AND Date = '{date.ToString("yyyy-MM-dd")}' AND Class = '{Settings.Default.Class}'");

                    Lessons[i].SetTitle(titleHomework[0]);
                    Lessons[i].Homework = titleHomework[1];

                    Lessons[i].Attachment = SQL.SelectImage("SELECT Attachments FROM Lessons " +
                        $"WHERE Num = '{i + 1}' AND Date = '{date.ToString("yyyy-MM-dd")}' AND Class = '{Settings.Default.Class}'");
                }
                catch
                {
                    string title = SQL.Select("SELECT Lesson FROM Schelude " +
                        $"WHERE DayOfWeek = '{(int)date.DayOfWeek}' AND Num = '{i + 1}' AND Class = '{Settings.Default.Class}'")[0];

                    SQL.Insert("INSERT INTO Lessons (Title, Homework, Num, Date, Class) " + 
                        $"VALUES ('{title}', 'Default', '{i + 1}', '{date.ToString("yyyy-MM-dd")}', '{Settings.Default.Class}')");

                    Lessons[i].SetTitle(title);
                    Lessons[i].Homework = "Default";
                }

                Lessons[i].Done = Days[date].Lessons[i].Done;

                Lessons[i].UpdateAttachmentLink();
                WorkRefresh(i);
            }

            for (int i = Main.MaxLessonsCount - 1; i >= LessonsCount; i--)
                Lessons[i].TurnOff();

            dateText.Text = $"{date.ToString("dd.MM.yyyy")} - {Localization.Translate(date.DayOfWeek.ToString())}";
        }

        private void CopyScreen_Click(object sender, EventArgs e)
        {
            dateMinusButton.Visible = false;
            datePlusButton.Visible = false;
            copyScreen.Visible = false;
            editModeButton.Visible = false;
            dateText.Font = new Font(dateText.Font.FontFamily, 20);

            Clipboard.SetImage(Utils.GetControlScreenshot(this));

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

        private void LoadDays()
        {
            if (File.Exists("Days.txt") && !string.IsNullOrEmpty(File.ReadAllText("Days.txt")))
            {
                string[] days = File.ReadAllLines("Days.txt");

                Days.Clear();

                for (int i = 0; i < days.Length; i++)
                {
                    Day day = Day.Fromtxt(days[i]);
                    Days.Add(day.Date, day);
                }
            }

            else
            {
                for (int i = 0; i < 273; i++)
                    Days.Add(firstDay.AddDays(i), new Day(i));

                if (DateTime.IsLeapYear(Program.Year + 1))
                    Days.Add(firstDay.AddDays(273), new Day(273));
            }
        }

        private static void NoEditMode()
        {
            MessageBox.Show(Localization.Translate("Doesn*t work in edit mode"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
