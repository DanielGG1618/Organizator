namespace Organizer
{
    partial class TimerForm
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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timeLabel = new System.Windows.Forms.Label();
            this.skipButton = new System.Windows.Forms.Button();
            this.resetTimer = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cycleLabel = new System.Windows.Forms.Label();
            this.timerPicture = new System.Windows.Forms.PictureBox();
            this.startPause = new System.Windows.Forms.PictureBox();
            this.workLabel = new System.Windows.Forms.Label();
            this.breakLabel = new System.Windows.Forms.Label();
            this.workTextBox = new System.Windows.Forms.TextBox();
            this.breakTextBox = new System.Windows.Forms.TextBox();
            this.pauseCheckBox = new System.Windows.Forms.CheckBox();
            this.couterCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startPause)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // timeLabel
            // 
            this.timeLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.timeLabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.timeLabel.ForeColor = System.Drawing.Color.Black;
            this.timeLabel.Location = new System.Drawing.Point(0, 28);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(194, 40);
            this.timeLabel.TabIndex = 1;
            this.timeLabel.Text = "00:00";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skipButton
            // 
            this.skipButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.skipButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skipButton.FlatAppearance.BorderSize = 0;
            this.skipButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.skipButton.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.skipButton.ForeColor = System.Drawing.Color.OliveDrab;
            this.skipButton.Location = new System.Drawing.Point(0, 76);
            this.skipButton.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.skipButton.Name = "skipButton";
            this.skipButton.Size = new System.Drawing.Size(200, 70);
            this.skipButton.TabIndex = 2;
            this.skipButton.Text = "Пропустить работу";
            this.skipButton.UseVisualStyleBackColor = false;
            this.skipButton.Click += new System.EventHandler(this.SkipButton_Click);
            // 
            // resetTimer
            // 
            this.resetTimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.resetTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resetTimer.FlatAppearance.BorderSize = 0;
            this.resetTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetTimer.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resetTimer.ForeColor = System.Drawing.Color.OliveDrab;
            this.resetTimer.Location = new System.Drawing.Point(0, 150);
            this.resetTimer.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.resetTimer.Name = "resetTimer";
            this.resetTimer.Size = new System.Drawing.Size(200, 70);
            this.resetTimer.TabIndex = 2;
            this.resetTimer.Text = "Сбросить таймер";
            this.resetTimer.UseVisualStyleBackColor = false;
            this.resetTimer.Click += new System.EventHandler(this.ResetTimer_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.settingsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settingsButton.ForeColor = System.Drawing.Color.OliveDrab;
            this.settingsButton.Location = new System.Drawing.Point(0, 224);
            this.settingsButton.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(200, 73);
            this.settingsButton.TabIndex = 2;
            this.settingsButton.Text = "Настройки";
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.settingsButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.skipButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.resetTimer, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(282, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 299);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cycleLabel);
            this.panel1.Controls.Add(this.timeLabel);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 68);
            this.panel1.TabIndex = 10;
            // 
            // cycleLabel
            // 
            this.cycleLabel.BackColor = System.Drawing.Color.Transparent;
            this.cycleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.cycleLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cycleLabel.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold);
            this.cycleLabel.ForeColor = System.Drawing.Color.Black;
            this.cycleLabel.Location = new System.Drawing.Point(0, 0);
            this.cycleLabel.Name = "cycleLabel";
            this.cycleLabel.Size = new System.Drawing.Size(194, 35);
            this.cycleLabel.TabIndex = 9;
            this.cycleLabel.Text = "цикл №0";
            this.cycleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerPicture
            // 
            this.timerPicture.BackColor = System.Drawing.Color.Transparent;
            this.timerPicture.Image = global::Organizer.Properties.Resources._0;
            this.timerPicture.Location = new System.Drawing.Point(9, 9);
            this.timerPicture.Margin = new System.Windows.Forms.Padding(0);
            this.timerPicture.Name = "timerPicture";
            this.timerPicture.Padding = new System.Windows.Forms.Padding(25, 20, 0, 0);
            this.timerPicture.Size = new System.Drawing.Size(270, 300);
            this.timerPicture.TabIndex = 0;
            this.timerPicture.TabStop = false;
            // 
            // startPause
            // 
            this.startPause.BackColor = System.Drawing.Color.Transparent;
            this.startPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startPause.Image = global::Organizer.Properties.Resources.start;
            this.startPause.Location = new System.Drawing.Point(181, 314);
            this.startPause.Name = "startPause";
            this.startPause.Size = new System.Drawing.Size(150, 128);
            this.startPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.startPause.TabIndex = 5;
            this.startPause.TabStop = false;
            this.startPause.Click += new System.EventHandler(this.StartPause_Click);
            // 
            // workLabel
            // 
            this.workLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.workLabel.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.workLabel.ForeColor = System.Drawing.Color.Black;
            this.workLabel.Location = new System.Drawing.Point(12, 337);
            this.workLabel.Name = "workLabel";
            this.workLabel.Size = new System.Drawing.Size(216, 33);
            this.workLabel.TabIndex = 6;
            this.workLabel.Text = "Время работы";
            this.workLabel.Visible = false;
            // 
            // breakLabel
            // 
            this.breakLabel.AutoSize = true;
            this.breakLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.breakLabel.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.breakLabel.ForeColor = System.Drawing.Color.Black;
            this.breakLabel.Location = new System.Drawing.Point(12, 392);
            this.breakLabel.Name = "breakLabel";
            this.breakLabel.Size = new System.Drawing.Size(216, 33);
            this.breakLabel.TabIndex = 6;
            this.breakLabel.Text = "Время отдыха";
            this.breakLabel.Visible = false;
            // 
            // workTextBox
            // 
            this.workTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.workTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.workTextBox.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.workTextBox.ForeColor = System.Drawing.Color.White;
            this.workTextBox.Location = new System.Drawing.Point(225, 343);
            this.workTextBox.Name = "workTextBox";
            this.workTextBox.Size = new System.Drawing.Size(54, 27);
            this.workTextBox.TabIndex = 7;
            this.workTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.workTextBox.Visible = false;
            this.workTextBox.TextChanged += new System.EventHandler(this.WorkTextBox_TextChanged);
            // 
            // breakTextBox
            // 
            this.breakTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.breakTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.breakTextBox.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.breakTextBox.ForeColor = System.Drawing.Color.White;
            this.breakTextBox.Location = new System.Drawing.Point(225, 398);
            this.breakTextBox.Name = "breakTextBox";
            this.breakTextBox.Size = new System.Drawing.Size(54, 27);
            this.breakTextBox.TabIndex = 7;
            this.breakTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.breakTextBox.Visible = false;
            this.breakTextBox.TextChanged += new System.EventHandler(this.BreakTextBox_TextChanged);
            // 
            // pauseCheckBox
            // 
            this.pauseCheckBox.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.pauseCheckBox.ForeColor = System.Drawing.Color.Black;
            this.pauseCheckBox.Location = new System.Drawing.Point(286, 334);
            this.pauseCheckBox.Name = "pauseCheckBox";
            this.pauseCheckBox.Size = new System.Drawing.Size(204, 40);
            this.pauseCheckBox.TabIndex = 8;
            this.pauseCheckBox.Text = "Пауза в конце";
            this.pauseCheckBox.UseVisualStyleBackColor = true;
            this.pauseCheckBox.Visible = false;
            // 
            // couterCheckBox
            // 
            this.couterCheckBox.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.couterCheckBox.ForeColor = System.Drawing.Color.Black;
            this.couterCheckBox.Location = new System.Drawing.Point(286, 389);
            this.couterCheckBox.Name = "couterCheckBox";
            this.couterCheckBox.Size = new System.Drawing.Size(204, 40);
            this.couterCheckBox.TabIndex = 8;
            this.couterCheckBox.Text = "Счетчик";
            this.couterCheckBox.UseVisualStyleBackColor = true;
            this.couterCheckBox.Visible = false;
            // 
            // TimerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.OliveDrab;
            this.ClientSize = new System.Drawing.Size(494, 448);
            this.Controls.Add(this.couterCheckBox);
            this.Controls.Add(this.pauseCheckBox);
            this.Controls.Add(this.breakTextBox);
            this.Controls.Add(this.workTextBox);
            this.Controls.Add(this.breakLabel);
            this.Controls.Add(this.workLabel);
            this.Controls.Add(this.startPause);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.timerPicture);
            this.ForeColor = System.Drawing.Color.Red;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(512, 490);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(512, 490);
            this.Name = "TimerForm";
            this.Text = "Таймер";
            this.Load += new System.EventHandler(this.TimerForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timerPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startPause)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox timerPicture;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button skipButton;
        private System.Windows.Forms.Button resetTimer;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox startPause;
        private System.Windows.Forms.Label breakLabel;
        private System.Windows.Forms.TextBox workTextBox;
        private System.Windows.Forms.TextBox breakTextBox;
        private System.Windows.Forms.CheckBox pauseCheckBox;
        private System.Windows.Forms.CheckBox couterCheckBox;
        private System.Windows.Forms.Label workLabel;
        private System.Windows.Forms.Label cycleLabel;
        private System.Windows.Forms.Panel panel1;
    }
}