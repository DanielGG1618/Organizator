using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer
{
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
        }

        private void Feedback_Load(object sender, EventArgs e)
        {
            ForeColor = Head.Color;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            MailAddress fromMailAddress = new MailAddress("DanielGGdebug@gmail.com", "Организатор");
            MailAddress toAddress = new MailAddress("daniel.gevorgyan25@gmail.com");

            MailMessage mailMessage = new MailMessage(fromMailAddress, toAddress);
            SmtpClient smtpClient = new SmtpClient();

            mailMessage.Subject = comboBox.Text;

            mailMessage.Body = "Средство связи: " + textBox1.Text + Environment.NewLine + 
                               "Сообщение: " + textBox2.Text;

            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(fromMailAddress.Address,                                                                "debugпароль");

            smtpClient.Send(mailMessage);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
