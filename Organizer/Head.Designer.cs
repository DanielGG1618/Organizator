namespace Organizer
{
    partial class Head
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Head));
            this.panel15 = new System.Windows.Forms.Panel();
            this.DateText = new System.Windows.Forms.Label();
            this.DatePlusButton = new System.Windows.Forms.Button();
            this.DateMinusButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.saveScreenButton = new System.Windows.Forms.Button();
            this.editModeButton = new System.Windows.Forms.Button();
            this.lessonsPanel = new System.Windows.Forms.Panel();
            this.timerButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.feedbackButton = new System.Windows.Forms.Button();
            this.panel15.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panel15.Controls.Add(this.DateText);
            this.panel15.Controls.Add(this.DatePlusButton);
            this.panel15.Controls.Add(this.DateMinusButton);
            this.panel15.Location = new System.Drawing.Point(24, 23);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(700, 70);
            this.panel15.TabIndex = 1;
            // 
            // DateText
            // 
            this.DateText.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DateText.ForeColor = System.Drawing.Color.OliveDrab;
            this.DateText.Location = new System.Drawing.Point(70, 0);
            this.DateText.Margin = new System.Windows.Forms.Padding(70, 0, 70, 0);
            this.DateText.Name = "DateText";
            this.DateText.Size = new System.Drawing.Size(560, 70);
            this.DateText.TabIndex = 4;
            this.DateText.Text = "dd.mm.yyyy";
            this.DateText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DatePlusButton
            // 
            this.DatePlusButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DatePlusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DatePlusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DatePlusButton.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DatePlusButton.ForeColor = System.Drawing.Color.OliveDrab;
            this.DatePlusButton.Location = new System.Drawing.Point(630, 0);
            this.DatePlusButton.Margin = new System.Windows.Forms.Padding(0);
            this.DatePlusButton.Name = "DatePlusButton";
            this.DatePlusButton.Size = new System.Drawing.Size(70, 70);
            this.DatePlusButton.TabIndex = 3;
            this.DatePlusButton.Text = ">";
            this.DatePlusButton.UseVisualStyleBackColor = false;
            this.DatePlusButton.Click += new System.EventHandler(this.DatePlusButton_Click);
            // 
            // DateMinusButton
            // 
            this.DateMinusButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DateMinusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DateMinusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DateMinusButton.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DateMinusButton.ForeColor = System.Drawing.Color.OliveDrab;
            this.DateMinusButton.Location = new System.Drawing.Point(0, 0);
            this.DateMinusButton.Margin = new System.Windows.Forms.Padding(0);
            this.DateMinusButton.Name = "DateMinusButton";
            this.DateMinusButton.Size = new System.Drawing.Size(70, 70);
            this.DateMinusButton.TabIndex = 2;
            this.DateMinusButton.Text = "<";
            this.DateMinusButton.UseVisualStyleBackColor = false;
            this.DateMinusButton.Click += new System.EventHandler(this.DateMinusButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.settingsButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.settingsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settingsButton.ForeColor = System.Drawing.Color.OliveDrab;
            this.settingsButton.Location = new System.Drawing.Point(0, 370);
            this.settingsButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(422, 100);
            this.settingsButton.TabIndex = 6;
            this.settingsButton.Text = "Настройки";
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // saveScreenButton
            // 
            this.saveScreenButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.saveScreenButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.saveScreenButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveScreenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveScreenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveScreenButton.ForeColor = System.Drawing.Color.OliveDrab;
            this.saveScreenButton.Location = new System.Drawing.Point(0, 10);
            this.saveScreenButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.saveScreenButton.Name = "saveScreenButton";
            this.saveScreenButton.Size = new System.Drawing.Size(422, 100);
            this.saveScreenButton.TabIndex = 0;
            this.saveScreenButton.Text = "Сохранить скриншот";
            this.saveScreenButton.UseVisualStyleBackColor = false;
            this.saveScreenButton.Click += new System.EventHandler(this.SaveScreenButton_Click);
            // 
            // editModeButton
            // 
            this.editModeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.editModeButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.editModeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editModeButton.ForeColor = System.Drawing.Color.OliveDrab;
            this.editModeButton.Location = new System.Drawing.Point(0, 250);
            this.editModeButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.editModeButton.Name = "editModeButton";
            this.editModeButton.Size = new System.Drawing.Size(422, 100);
            this.editModeButton.TabIndex = 4;
            this.editModeButton.Text = "Режим редактирования";
            this.editModeButton.UseVisualStyleBackColor = false;
            this.editModeButton.Click += new System.EventHandler(this.EditModeButton_Click);
            // 
            // lessonsPanel
            // 
            this.lessonsPanel.AutoScroll = true;
            this.lessonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lessonsPanel.Location = new System.Drawing.Point(24, 112);
            this.lessonsPanel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.lessonsPanel.Name = "lessonsPanel";
            this.lessonsPanel.Size = new System.Drawing.Size(700, 490);
            this.lessonsPanel.TabIndex = 3;
            // 
            // timerButton
            // 
            this.timerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.timerButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.timerButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timerButton.ForeColor = System.Drawing.Color.OliveDrab;
            this.timerButton.Location = new System.Drawing.Point(0, 130);
            this.timerButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.timerButton.Name = "timerButton";
            this.timerButton.Size = new System.Drawing.Size(422, 100);
            this.timerButton.TabIndex = 7;
            this.timerButton.Text = "Таймер";
            this.timerButton.UseVisualStyleBackColor = false;
            this.timerButton.Click += new System.EventHandler(this.TimerButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.feedbackButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.settingsButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.editModeButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.timerButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.saveScreenButton, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(739, 12);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(12, 3, 12, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(422, 600);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // feedbackButton
            // 
            this.feedbackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.feedbackButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.feedbackButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feedbackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.feedbackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.feedbackButton.ForeColor = System.Drawing.Color.OliveDrab;
            this.feedbackButton.Location = new System.Drawing.Point(0, 490);
            this.feedbackButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.feedbackButton.Name = "feedbackButton";
            this.feedbackButton.Size = new System.Drawing.Size(422, 100);
            this.feedbackButton.TabIndex = 8;
            this.feedbackButton.Text = "Обратная связь";
            this.feedbackButton.UseVisualStyleBackColor = false;
            this.feedbackButton.Click += new System.EventHandler(this.FeedbackButton_Click);
            // 
            // Head
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1182, 624);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lessonsPanel);
            this.Controls.Add(this.panel15);
            this.ForeColor = System.Drawing.Color.OliveDrab;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1200, 666);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1200, 666);
            this.Name = "Head";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Список ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SaveFiles);
            this.Load += new System.EventHandler(this.Head_Load);
            this.panel15.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Button DatePlusButton;
        private System.Windows.Forms.Button DateMinusButton;
        private System.Windows.Forms.Button editModeButton;
        private System.Windows.Forms.Button saveScreenButton;
        private System.Windows.Forms.Label DateText;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Panel lessonsPanel;
        private System.Windows.Forms.Button timerButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button feedbackButton;
    }
}

