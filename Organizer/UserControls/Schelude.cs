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

namespace Organizer
{
    public partial class Schelude : UserControlGG
    {
        public static int CellSize = 70;
        public static int MaxLessonsCount = 8; 

        public static Lesson[] Lessons;
        public static Dictionary<DateTime, Day> Days = new Dictionary<DateTime, Day>();

        public int LessonsCount;
        public bool EditMode;

        private Lesson[] editModeLessonsBackup;
        private DateTime date, firstDay, lastDay;

        public Schelude()
        {
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

            editModeLessonsBackup = new Lesson[Main.MaxLessonsCount];
            for (int i = 0; i < Main.MaxLessonsCount; i++)
                editModeLessonsBackup[i] = new Lesson(i + 1, CellSize, Program.Color);

            InitializeComponent();
        }

        private void Schelude_Load(object sender, EventArgs e)
        {
            lessonsPanel.Controls.Clear();
            lessonsPanel.MouseWheel += LessonsPanelMouseWheel;

            Lessons = new Lesson[Main.MaxLessonsCount];

            for (int i = 0; i < Main.MaxLessonsCount; i++)
            {
                Lessons[i] = new Lesson(i + 1, CellSize, Program.Color);

                Lessons[i].TitleLabel.Click += TitleClick;
                Lessons[i].TitleLabel.MouseMove += TitleMouseMove;

                Lessons[i].AddWorkButton.Click += AddWorkButtonClick;

                Lessons[i].DoneCheckBox.CheckStateChanged += DoneCheckedChanged;

                lessonsPanel.Controls.Add(Lessons[i].DoneCheckBox);
                lessonsPanel.Controls.Add(Lessons[i].AddWorkButton);
                lessonsPanel.Controls.Add(Lessons[i].NumLabel);
                lessonsPanel.Controls.Add(Lessons[i].TitleLabel);
                lessonsPanel.Controls.Add(Lessons[i].WorkLabel);

                LocalizationControls.Add(Lessons[i].TitleLabel);
                LocalizationControls.Add(Lessons[i].WorkLabel);
            }

            LessonsRefresh();

            SetColor(Program.Color);
            SetTheme(Program.DarkTheme);
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

            do
            {
                date = date.AddDays(1);

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

            do
            {
                date = date.AddDays(-1);

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
                YesNoCancelDialog dialog = new YesNoCancelDialog(Program.Translate("Edit mode"));

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
                    for (int i = 0; i < Days[date].Lessons.Count; i++)
                        Days[date].Lessons[i].CopyFrom(Lessons[i]);

                    LessonsRefresh();
                }
            }

            editModeButton.ForeColor = EditMode ? Color.LimeGreen : new Color();

            for (int i = 0; i < LessonsCount; i++)
                Lessons[i].AddWorkButton.Visible = EditMode;

            for (int i = 0; i < LessonsCount; i++)
                Lessons[i].UpdateSizes(CellSize, EditMode);
        }

        private void LessonsPanelMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                DatePlusButton_Click(sender, e);

            else
                DateMinusButton_Click(sender, e);
        }

        private void AddWorkButtonClick(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(((Button)sender).Tag);

            WorkAddForm form = new WorkAddForm(num);

            if (form.ShowDialog() == DialogResult.OK)
            {
                Lessons[num - 1].WorkList = form.WorkList;

                WorkRefresh(num - 1);
            }
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
            if (Lessons[num].WorkList.Count > 1)
            {
                Lessons[num].WorkLabel.Text = "";

                foreach (var work in Lessons[num].WorkList)
                    if (work.Key != "Default")
                        foreach (var text in work.Value)
                            Lessons[num].WorkLabel.Text += WorkAddForm.Types[work.Key] + text + ", ";

                Lessons[num].WorkLabel.Text = Lessons[num].WorkLabel.Text.Remove(Lessons[num].WorkLabel.Text.Length - 2, 2);
            }

            else
                Lessons[num].SetTitle(Lessons[num].Title);
        }

        private void LessonsRefresh()
        {
            for (int i = 0; i < Days[date].Lessons.Count; i++)
            {
                Lessons[i].NumLabel.ForeColor = Program.Color;
                Lessons[i].DoneCheckBox.Visible = true;
                Lessons[i].CopyFrom(Days[date].Lessons[i]);
                WorkRefresh(i);
            }

            LessonsCount = Days[date].Lessons.Count;

            for (int i = Main.MaxLessonsCount - 1; i >= LessonsCount; i--)
                Lessons[i].TurnOff();

            dateText.Text = $"{date.Day.ToString("00")}.{date.Month.ToString("00")}.{date.Year} - {Program.Translate(date.DayOfWeek.ToString())}";
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

        public override void SetColor(Color color)
        {
            ForeColor = color;

            foreach (var lesson in Lessons)
                if (lesson.Enabled)
                    lesson.NumLabel.ForeColor = color;
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
            MessageBox.Show(Program.Translate("Doesn*t work in edit mode"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void SaveFiles(object sender, FormClosingEventArgs e)
        {
            List<string> days = new List<string>();

            foreach (var day in Days)
                days.Add(Day.Totxt(day.Value));

            File.WriteAllLines("Days.txt", days);
        }
    }
}
