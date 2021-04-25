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
using Organizer.Properties;
using Newtonsoft.Json;

namespace Organizer
{
    public partial class Main : Form
    {
        public static Main Instance;

        public static Color[] GRAY = new Color[2] { Color.FromArgb(56, 56, 56), Color.FromArgb(48, 48, 48) };

        //public static List<DateTime> PrimaryHolidays = new List<DateTime>();
        //public static List<DateTime> SecondaryHolidays = new List<DateTime>();
        //public static List<DateTime> ThisYearHolidays = new List<DateTime>();

        public static int MaxLessonsCount;

        public static Dictionary<string, string> LessonsDefaultWork = new Dictionary<string, string>();

        public List<Control> LocalizationControls = new List<Control>();

        private UserControlGG activeUserControl;
        private Schelude schelude;
        private Options options;
        private AdminPanel adminPanel;
        private ModerPanel moderPanel;
        private UndoneHomework undoneHomework;
        private Dictionary<string, UserControlGG> userControls = new Dictionary<string, UserControlGG>();

        private List<UserControlGG> navigation = new List<UserControlGG>();
        private int navigationPos = 0;

        public Main()
        {
            Instance = this;

            LoadFiles();

            MaxLessonsCount = 7;////////////

            schelude = new Schelude();
            options = new Options
            {
                Location = new Point(175, 100)
            };
            adminPanel = new AdminPanel
            {
                Location = new Point(0, 100)
            };
            moderPanel = new ModerPanel
            {
                Location = new Point(0, 100)
            };
            undoneHomework = new UndoneHomework();

            userControls.Add("schelude", schelude);
            userControls.Add("undoneHomework", undoneHomework);
            userControls.Add("options", options);
            userControls.Add("moderPanel", moderPanel);
            userControls.Add("adminPanel", adminPanel);

            FormClosing += options.SaveSettings;

            InitializeComponent();
        }

        private void Head_Load(object sender, EventArgs e)
        {
            LocalizationControls.AddRange(new Control[] { this, scheludeButton, optionsButton, undoneButton });

            ApplyColor();
            ApplyTheme();
            ApplyLocalization();

            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(schelude);

            activeUserControl = schelude;

            navigation.Add(schelude);

            TryLogIn("Admin", "Admin");///////////////////
        }

        private void LoadFiles()
        {
            Holidays.Load();

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

        /*private void LoadHolidays()
        {
            PrimaryHolidays.Clear();
            SecondaryHolidays.Clear();
            ThisYearHolidays.Clear();

            string[] holydays = File.ReadAllLines("Holidays.txt");

            foreach (var day in holydays)
            {
                string[] holyday = day.Split(new string[1] { " type: " }, StringSplitOptions.RemoveEmptyEntries);

                if (holyday[1] == "primary")
                {
                    string[] dayMonth = holyday[0].Split('.');

                    PrimaryHolidays.Add(new DateTime(4, Convert.ToInt32(dayMonth[1]), Convert.ToInt32(dayMonth[0])));
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
                        SecondaryHolidays.Add(dayToAdd);
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
                        ThisYearHolidays.Add(dayToAdd);
                    }
                }
            }
        }*/

        public void ApplyLocalization()
        {
            foreach (var control in LocalizationControls)
                if (!string.IsNullOrEmpty(control.Text) && !string.IsNullOrEmpty(control.AccessibleName))
                    control.Text = Localization.Translate(control.AccessibleName);

            for (int i = 0; i < schelude.LessonsCount; i++)
                schelude.WorkRefresh(i);
        }

        public void ApplyColor()
        {
            ForeColor = Settings.Default.Color;
        }

        public void ApplyTheme()
        {
            BackColor = Settings.Default.DarkTheme ? Color.FromArgb(32, 32, 32) : Color.FromArgb(255, 255, 255);
        }

        private void TryLogIn(string login, string password)
        {
            List<string> user = SQL.Select($"SELECT Class, Role FROM Users WHERE `Login` = '{login}' AND `Password` = '{password}'");

            if (user.Count == 0)
                MessageBox.Show(Localization.Translate("Login or password is wrong"));

            else
            {
                Settings.Default.Login = login;
                Settings.Default.Role = (Roles)Enum.Parse(typeof(Roles), user[1]);

                switch (Settings.Default.Role)
                {
                    case Roles.Admin:
                        adminButton.Visible = true;
                        break;

                    case Roles.Moderator:
                        adminButton.Visible = false;
                        break;

                    case Roles.Regular:
                        adminButton.Visible = false;
                        break;
                }

                MessageBox.Show(Localization.Translate("Succesful login"));
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (navigationPos < 1)
                return;

            navigationPos--;

            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(navigation[navigationPos]);

            backButton.Enabled = navigationPos > 0;
            forwardButton.Enabled = navigationPos < navigation.Count - 1;
        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            if (navigationPos > navigation.Count - 2)
                return;

            navigationPos++;

            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(navigation[navigationPos]);

            backButton.Enabled = navigationPos > 0;
            forwardButton.Enabled = navigationPos < navigation.Count - 1;
        }

        private void ButtonsTimer_Tick(object sender, EventArgs e)
        {
            backButton.Enabled = navigationPos > 0;
            forwardButton.Enabled = navigationPos < navigation.Count - 1;
        }

        private void SqlUpdater_Tick(object sender, EventArgs e)
        {
            _ = SQL.Select("SELECT Role FROM Users Where Login = 'Admin'");
        }

        private void ScheludeButton_Click(object sender, EventArgs e)
        {
            if (schelude.EditMode)
            {
                Utils.NoEditMode();
                return;
            }

            if (activeUserControl == options)
            {
                //LoadHolidays();
                schelude.DateMinusPlus();
            }

            schelude.LessonsRefresh();
            SetPanel(userControls["schelude"]);
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            if (schelude.EditMode)
            {
                Utils.NoEditMode();
                return;
            }

            SetPanel(userControls["options"]);
        }

        private void AdminButton_Click(object sender, EventArgs e)
        {
            if (schelude.EditMode)
            {
                Utils.NoEditMode();
                return;
            }

            SetPanel(userControls["adminPanel"]);
        }

        private void UndoneButton_Click(object sender, EventArgs e)
        {
            if (schelude.EditMode)
            {
                Utils.NoEditMode();
                return;
            }

            schelude.SaveDoneStatuses();
            undoneHomework.UpdatePanel();
            SetPanel(userControls["undoneHomework"]);
        }

        private void ModerButton_Click(object sender, EventArgs e)
        {
            if (schelude.EditMode)
            {
                Utils.NoEditMode();
                return;
            }

            SetPanel(userControls["moderPanel"]);
        }

        private void SetPanel(UserControlGG userControl)
        {
            userControl.ApplyAll();

            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(userControl);
            activeUserControl = userControl;

            if (navigation[navigationPos] != userControl)
            {
                if (navigationPos < navigation.Count - 2)
                    navigation.RemoveRange(navigationPos, navigation.Count - navigationPos);

                navigation.Add(userControl);
                navigationPos++;
            }
        }

        private void WeatherWithIP(object sender, FormClosingEventArgs e)
        {
            WebRequest wr = WebRequest.Create("https://ipwhois.app/json/" + Dns.GetHostByName(Dns.GetHostName()).AddressList.First());

            wr.Method = "GET";
            WebResponse response = wr.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);

            string sReadData = sr.ReadToEnd();
            dynamic ip = JsonConvert.DeserializeObject(sReadData);
            response.Close();

            wr = WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?q=" + ip.city + "," + ip.country_code + "&appid=711c2fd34e54038de950712b8fe02a75");
            wr.Method = "GET";
            response = wr.GetResponse();

            stream = response.GetResponseStream();
            sr = new StreamReader(stream);

            sReadData = sr.ReadToEnd();
            dynamic text = JsonConvert.DeserializeObject(sReadData);
            MessageBox.Show(Math.Round(float.Parse(text.main.temp.ToString()) - 273.15f).ToString(), "градусов Цельсия");
            response.Close();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            schelude.SaveDoneStatuses();
        }
    }
}