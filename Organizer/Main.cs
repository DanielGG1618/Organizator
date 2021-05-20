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

        public static int MaxLessonsCount;

        public static Dictionary<string, string> LessonsDefaultWork = new Dictionary<string, string>();

        public List<Control> LocalizationControls = new List<Control>();

        private UserControlGG activeUserControl;
        private Schelude schelude;
        private Options options;
        private AdminPanel adminPanel;
        private ModerPanel moderPanel;
        private UndoneHomework undoneHomework;

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

            FormClosing += options.SaveSettings;

            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LocalizationControls.AddRange(new Control[] { this, scheludeButton, optionsButton, undoneButton, loginButton, signinButton });
            Theme.GrayControls[2].AddRange(new Control[] { backButton, forwardButton });
            Theme.GrayControls[3].Add(this);

            ApplyColor();
            ApplyLocalization();

            mainPanel.Controls.Clear();
            if (Settings.Default.Role != Roles.Guest)
            {
                tableLayoutPanel1.Visible = true;
                backButton.Visible = true;
                forwardButton.Visible = true;
                loginButton.Visible = false;
                signinButton.Visible = false;

                mainPanel.Controls.Add(schelude);

                activeUserControl = schelude;

                navigation.Add(schelude);
            }
            else
            {
                tableLayoutPanel1.Visible = false;
                backButton.Visible = false;
                forwardButton.Visible = false;
                loginButton.Visible = true;
                signinButton.Visible = true;
            }

            Theme.Apply();
        }

        private void LoadFiles()
        {
            Holidays.Load();
            Theme.InitializeGray();

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

        public void UpdateRole(Roles role)
        {
            switch (role)
            {
                case Roles.Admin:
                    moderButton.Visible = true;
                    adminButton.Visible = true;
                    break;

                case Roles.Moderator:
                    moderButton.Visible = true;
                    adminButton.Visible = false;
                    break;

                case Roles.Regular:
                    moderButton.Visible = false;
                    adminButton.Visible = false;
                    break;
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

            if (activeUserControl == moderPanel)
            {
                schelude.DateMinusPlus();
            }

            schelude.LessonsRefresh();
            SetPanel(schelude);
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            if (schelude.EditMode)
            {
                Utils.NoEditMode();
                return;
            }

            SetPanel(options);
        }

        private void AdminButton_Click(object sender, EventArgs e)
        {
            if (schelude.EditMode)
            {
                Utils.NoEditMode();
                return;
            }

            SetPanel(adminPanel);
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
            SetPanel(undoneHomework);
        }

        private void ModerButton_Click(object sender, EventArgs e)
        {
            if (schelude.EditMode)
            {
                Utils.NoEditMode();
                return;
            }

            SetPanel(moderPanel);
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

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Autorization autorization = new Autorization(false);

            if(autorization.ShowDialog() == DialogResult.Yes)
            {
                tableLayoutPanel1.Visible = true;
                backButton.Visible = true;
                forwardButton.Visible = true;
                loginButton.Visible = false;
                signinButton.Visible = false;

                mainPanel.Controls.Add(schelude);

                activeUserControl = schelude;

                navigation.Add(schelude);

                Theme.Apply();
            }
        }

        private void SigninButton_Click(object sender, EventArgs e)
        {
            Autorization autorization = new Autorization(true);

            if (autorization.ShowDialog() == DialogResult.Yes)
            {
                tableLayoutPanel1.Visible = true;
                backButton.Visible = true;
                forwardButton.Visible = true;
                loginButton.Visible = false;
                signinButton.Visible = false;

                mainPanel.Controls.Add(schelude);

                activeUserControl = schelude;

                navigation.Add(schelude);

                Theme.Apply();
            }
        }
    }
}