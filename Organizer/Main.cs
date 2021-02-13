using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Organizer
{
    public partial class Main : Form
    {
        public static Color[] GRAY = new Color[2] { Color.FromArgb(56, 56, 56), Color.FromArgb(48, 48, 48) };

        public static List<DateTime> PrimaryHolydays = new List<DateTime>();
        public static List<DateTime> SecondaryHolydays = new List<DateTime>();
        public static List<DateTime> ThisYearHolydays = new List<DateTime>();

        public static int MaxLessonsCount;

        public static string[][] Schelude;
        public static Dictionary<string, string> LessonsDefaultWork = new Dictionary<string, string>();

        public List<Control> LocalizationControls = new List<Control>();

        private UserControlGG activeUserControl;
        private Schelude schelude;
        private Options options;
        private UnknownUserControl unknown;
        private Dictionary<string, UserControlGG> userControls = new Dictionary<string, UserControlGG>();

        private List<UserControlGG> navigation = new List<UserControlGG>();
        private int navigationPos = 0;

        public Main()
        {
            LoadFiles();

            foreach (var lessons in Schelude)
                if (lessons.Length > MaxLessonsCount)
                    MaxLessonsCount = lessons.Length;

            schelude = new Schelude();
            options = new Options
            {
                Location = new Point(175, 24)
            };
            unknown = new UnknownUserControl();

            userControls.Add("schelude", schelude);
            userControls.Add("options", options);
            userControls.Add("unknown", unknown);

            FormClosing += schelude.SaveFiles;
            FormClosing += options.SaveOptions;

            InitializeComponent();
        }

        private void Head_Load(object sender, EventArgs e)
        {
            LocalizationControls.Add(this);

            SetColor();
            SetTheme(Program.DarkTheme);
            SetLanguage();

            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(schelude);

            activeUserControl = schelude;

            navigation.Add(schelude);
        }

        private void LoadFiles()
        {
            LoadSchedule();

            LoadHolydays();

            LoadDefaultWorks();
        }

        private void LoadDefaultWorks()
        {
            string[] lessonsDefaultWorks = File.ReadAllLines("Lessons default work.txt", Encoding.UTF8);

            LessonsDefaultWork.Clear();

            foreach (var lessonsDefaultWork in lessonsDefaultWorks)
            {
                string[] keyValue = lessonsDefaultWork.Split(new string[] { ": " }, StringSplitOptions.None);

                LessonsDefaultWork.Add(keyValue[0], keyValue[1]);
            }
        }

        private void LoadHolydays()
        {
            PrimaryHolydays.Clear();
            SecondaryHolydays.Clear();
            ThisYearHolydays.Clear();

            string[] holydays = File.ReadAllLines("Holydays.txt");

            foreach (var day in holydays)
            {
                string[] holyday = day.Split(new string[1] { " type: " }, StringSplitOptions.RemoveEmptyEntries);

                if (holyday[1] == "primary")
                {
                    string[] dayMonth = holyday[0].Split('.');

                    PrimaryHolydays.Add(new DateTime(4, Convert.ToInt32(dayMonth[1]), Convert.ToInt32(dayMonth[0])));
                }

                else if (holyday[1] == "secondary")
                {
                    string[] startFinish = holyday[0].Split('-');

                    string[] startDayMonth = startFinish[0].Split('.');
                    string[] finishDayMonth = startFinish.Length > 1 ? startFinish[1].Split('.') : startDayMonth;

                    for (DateTime dayToAdd = new DateTime(4, Convert.ToInt32(startDayMonth[1]), Convert.ToInt32(startDayMonth[0]));
                        dayToAdd <= new DateTime(4, Convert.ToInt32(finishDayMonth[1]), Convert.ToInt32(finishDayMonth[0]));
                        dayToAdd = dayToAdd.AddDays(1))
                    {
                        SecondaryHolydays.Add(dayToAdd);
                    }
                }

                else if (holyday[1] == "this year")
                {
                    string[] startFinish = holyday[0].Split('-');

                    string[] startDayMonthYear = startFinish[0].Split('.');
                    string[] finishDayMonthYear = startFinish.Length > 1 ? startFinish[1].Split('.') : startDayMonthYear;

                    for (DateTime dayToAdd = new DateTime(2000 + Convert.ToInt32(startDayMonthYear[2]), Convert.ToInt32(startDayMonthYear[1]), Convert.ToInt32(startDayMonthYear[0]));
                        dayToAdd <= new DateTime(2000 + Convert.ToInt32(finishDayMonthYear[2]), Convert.ToInt32(finishDayMonthYear[1]), Convert.ToInt32(finishDayMonthYear[0]));
                        dayToAdd = dayToAdd.AddDays(1))
                    {
                        ThisYearHolydays.Add(dayToAdd);
                    }
                }
            }
        }

        private void LoadSchedule()
        {
            string[] schedule = File.ReadAllLines("Lessons.txt", Encoding.UTF8);

            Schelude = new string[schedule.Length][];

            for (int i = 0; i < schedule.Length; i++)
            {
                List<string> list = new List<string>(schedule[i].Split(new string[2] { ", ", ": " }, StringSplitOptions.RemoveEmptyEntries));
                list.RemoveAt(0);

                Schelude[i] = list.ToArray();

                /*for(int j = 0; j < list.Count; j++)
                    Program.Insert("INSERT INTO Schelude (`DayOfWeek`, `Num`, `Lesson`, `Class`) " +
                        $"VALUES ('{i}', '{j + 1}', '{list[j]}', '{"25;9В"}')");*/
            }
        }

        public void SetLanguage()
        {
            foreach (var control in LocalizationControls)
                if (!string.IsNullOrEmpty(control.Text) && !string.IsNullOrEmpty(control.AccessibleName))
                    control.Text = Program.Translate(control.AccessibleName);

            for (int i = 0; i < schelude.LessonsCount; i++)
                schelude.WorkRefresh(i);
        }

        public void SetColor()
        {
            ForeColor = Program.Color;
        }

        public void SetTheme(bool darkTheme)
        {
            BackColor = darkTheme ? Color.FromArgb(32, 32, 32) : Color.FromArgb(255, 255, 255);
        }

        private void InDevelop()
        {
            MessageBox.Show(Program.Translate("In the develop"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private static void NoEditMode()
        {
            MessageBox.Show(Program.Translate("Doesn*t work in edit mode"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (schelude.EditMode)
            {
                NoEditMode();
                return;
            }

            if (activeUserControl == options)
            {
                LoadHolydays();

                schelude.DateMinusPlus();
            }

            UserControlGG userControl = userControls[e.Node.Tag.ToString()];

            userControl.SetColor(Program.Color);
            userControl.SetTheme(Program.DarkTheme);
            userControl.SetLanguage(Program.Language);

            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(userControl);
            activeUserControl = userControl;

            if (navigation[navigationPos] != userControl)
            {
                if(navigationPos < navigation.Count - 2)
                    navigation.RemoveRange(navigationPos, navigation.Count - navigationPos);

                navigation.Add(userControl);
                navigationPos++;
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (navigationPos < 1)
                return;

            navigationPos--;

            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(navigation[navigationPos]);
        }

        private void FrontButton_Click(object sender, EventArgs e)
        {
            if (navigationPos > navigation.Count - 2)
                return;

            navigationPos++;

            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(navigation[navigationPos]);
        }

        private void ButtonsTimer_Tick(object sender, EventArgs e)
        {
            backButton.Enabled = navigationPos > 0;
            frontButton.Enabled = navigationPos < navigation.Count - 1;
        }

        private void SqlUpdater_Tick(object sender, EventArgs e)
        {
            _ = Program.Select("SELECT IsAdmin FROM Users Where Login = 'Admin'");
        }
    }
}