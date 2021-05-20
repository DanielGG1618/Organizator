
namespace Organizer
{
    partial class Autorization
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.confirmText = new System.Windows.Forms.TextBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.loginText = new System.Windows.Forms.TextBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.confirmLabel = new System.Windows.Forms.Label();
            this.inLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.classText = new System.Windows.Forms.TextBox();
            this.classLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // confirmText
            // 
            this.confirmText.Location = new System.Drawing.Point(124, 137);
            this.confirmText.Name = "confirmText";
            this.confirmText.Size = new System.Drawing.Size(246, 38);
            this.confirmText.TabIndex = 0;
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(124, 93);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(246, 38);
            this.passwordText.TabIndex = 1;
            // 
            // loginText
            // 
            this.loginText.Location = new System.Drawing.Point(124, 49);
            this.loginText.Name = "loginText";
            this.loginText.Size = new System.Drawing.Size(246, 38);
            this.loginText.TabIndex = 2;
            // 
            // loginLabel
            // 
            this.loginLabel.AccessibleName = "LoginNoun";
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(12, 52);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(88, 31);
            this.loginLabel.TabIndex = 3;
            this.loginLabel.Text = "Логин";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AccessibleName = "Password";
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(12, 96);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(108, 31);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "Пароль";
            // 
            // confirmLabel
            // 
            this.confirmLabel.AccessibleName = "Confirm";
            this.confirmLabel.AutoSize = true;
            this.confirmLabel.Location = new System.Drawing.Point(12, 140);
            this.confirmLabel.Name = "confirmLabel";
            this.confirmLabel.Size = new System.Drawing.Size(105, 31);
            this.confirmLabel.TabIndex = 3;
            this.confirmLabel.Text = "Повтор";
            // 
            // inLabel
            // 
            this.inLabel.AccessibleName = "SignIn";
            this.inLabel.Location = new System.Drawing.Point(12, 9);
            this.inLabel.Name = "inLabel";
            this.inLabel.Size = new System.Drawing.Size(358, 33);
            this.inLabel.TabIndex = 4;
            this.inLabel.Text = "Регистрация";
            this.inLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.AccessibleName = "SignInVerb";
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(402, 50);
            this.button1.TabIndex = 5;
            this.button1.Text = "Зарегистрироваться";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // classText
            // 
            this.classText.Location = new System.Drawing.Point(124, 181);
            this.classText.Name = "classText";
            this.classText.Size = new System.Drawing.Size(246, 38);
            this.classText.TabIndex = 0;
            // 
            // classLabel
            // 
            this.classLabel.AccessibleName = "Class";
            this.classLabel.AutoSize = true;
            this.classLabel.Location = new System.Drawing.Point(12, 184);
            this.classLabel.Name = "classLabel";
            this.classLabel.Size = new System.Drawing.Size(90, 31);
            this.classLabel.TabIndex = 3;
            this.classLabel.Text = "Класс";
            // 
            // Autorization
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(402, 276);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.inLabel);
            this.Controls.Add(this.classLabel);
            this.Controls.Add(this.confirmLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.loginText);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.classText);
            this.Controls.Add(this.confirmText);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(420, 323);
            this.MinimumSize = new System.Drawing.Size(400, 323);
            this.Name = "Autorization";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Autorization_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox confirmText;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.TextBox loginText;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label confirmLabel;
        private System.Windows.Forms.Label inLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox classText;
        private System.Windows.Forms.Label classLabel;
    }
}