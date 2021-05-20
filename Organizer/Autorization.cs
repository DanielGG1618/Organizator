using Organizer.Properties;
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
    public partial class Autorization : Form
    {
        public List<Control> LocalizationControls = new List<Control>();

        private bool sign;

        public Autorization(bool _sign)
        {
            sign = _sign;

            InitializeComponent();

            if (!sign)
            {
                confirmLabel.Visible = false;
                confirmText.Visible = false;
                classLabel.Visible = false;
                classText.Visible = false;

                MaximumSize = new Size(400, 270);

                inLabel.AccessibleName = "LogIn";
                button1.AccessibleName = "LogInVerb";
            }

            DialogResult = DialogResult.No;
        }

        public void ApplyLocalization()
        {
            foreach (var control in LocalizationControls)
                if (!string.IsNullOrEmpty(control.Text) && !string.IsNullOrEmpty(control.AccessibleName))
                    control.Text = Localization.Translate(control.AccessibleName);
        }

        private void Autorization_Load(object sender, EventArgs e)
        {
            ForeColor = Settings.Default.Color;

            LocalizationControls.AddRange(new Control[] { inLabel, loginLabel, passwordLabel, confirmLabel, classLabel, button1 });

            ApplyLocalization();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(passwordText.Text) || string.IsNullOrEmpty(loginText.Text))
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(sign)
            {
                if(passwordText.Text != confirmText.Text)
                {
                    MessageBox.Show(Localization.Translate("Passwords don*t match"));
                    return;
                }

                else
                {
                    SignIn(loginText.Text, passwordText.Text, classText.Text);
                }
            }

            else
                TryLogIn(loginText.Text, passwordText.Text);
        }

        private void TryLogIn(string login, string password)
        {
            List<string> user = SQL.Select($"SELECT Class, Role FROM Users WHERE `Login` = '{login}' AND `Password` = '{password}'");

            if (user.Count == 0)
                MessageBox.Show(Localization.Translate("Login or password is wrong"));

            else
            {
                Settings.Default.Login = login;
                Settings.Default.Class = user[0];
                Settings.Default.Role = (Roles)Enum.Parse(typeof(Roles), user[1]);

                Main.Instance.UpdateRole(Settings.Default.Role);
                
                MessageBox.Show(Localization.Translate("Succesful login"));

                DialogResult = DialogResult.Yes;
            }
        }

        private void SignIn(string login, string password, string _class)
        {
            SQL.Insert("INSERT INTO Users (Login, Password, Class) VALUES " +
                $"('{login}', '{password}', '{_class}')");

            TryLogIn(login, password);
        }
    }
}
