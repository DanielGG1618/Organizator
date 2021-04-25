namespace Organizer
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.buttonsTimer = new System.Windows.Forms.Timer(this.components);
            this.sqlUpdater = new System.Windows.Forms.Timer(this.components);
            this.scheludeButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.adminButton = new System.Windows.Forms.Button();
            this.undoneButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.moderButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.Location = new System.Drawing.Point(219, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(750, 580);
            this.mainPanel.TabIndex = 9;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.backButton.Enabled = false;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.Location = new System.Drawing.Point(12, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(100, 70);
            this.backButton.TabIndex = 11;
            this.backButton.Text = "<=";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // forwardButton
            // 
            this.forwardButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.forwardButton.Enabled = false;
            this.forwardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forwardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forwardButton.Location = new System.Drawing.Point(112, 12);
            this.forwardButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(100, 70);
            this.forwardButton.TabIndex = 11;
            this.forwardButton.Text = "=>";
            this.forwardButton.UseVisualStyleBackColor = false;
            this.forwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
            // 
            // buttonsTimer
            // 
            this.buttonsTimer.Enabled = true;
            this.buttonsTimer.Interval = 1000;
            this.buttonsTimer.Tick += new System.EventHandler(this.ButtonsTimer_Tick);
            // 
            // sqlUpdater
            // 
            this.sqlUpdater.Enabled = true;
            this.sqlUpdater.Interval = 60000;
            this.sqlUpdater.Tick += new System.EventHandler(this.SqlUpdater_Tick);
            // 
            // scheludeButton
            // 
            this.scheludeButton.AccessibleDescription = "";
            this.scheludeButton.AccessibleName = "Schelude";
            this.scheludeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheludeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scheludeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scheludeButton.Location = new System.Drawing.Point(0, 0);
            this.scheludeButton.Margin = new System.Windows.Forms.Padding(0);
            this.scheludeButton.Name = "scheludeButton";
            this.scheludeButton.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.scheludeButton.Size = new System.Drawing.Size(200, 100);
            this.scheludeButton.TabIndex = 12;
            this.scheludeButton.Text = "Расписание";
            this.scheludeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.scheludeButton.UseVisualStyleBackColor = true;
            this.scheludeButton.Click += new System.EventHandler(this.ScheludeButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.AccessibleDescription = "";
            this.optionsButton.AccessibleName = "Options";
            this.optionsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.optionsButton.Location = new System.Drawing.Point(0, 200);
            this.optionsButton.Margin = new System.Windows.Forms.Padding(0);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.optionsButton.Size = new System.Drawing.Size(200, 100);
            this.optionsButton.TabIndex = 12;
            this.optionsButton.Text = "Настройки";
            this.optionsButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // adminButton
            // 
            this.adminButton.AccessibleDescription = "";
            this.adminButton.AccessibleName = "";
            this.adminButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adminButton.Location = new System.Drawing.Point(0, 400);
            this.adminButton.Margin = new System.Windows.Forms.Padding(0);
            this.adminButton.Name = "adminButton";
            this.adminButton.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.adminButton.Size = new System.Drawing.Size(200, 103);
            this.adminButton.TabIndex = 12;
            this.adminButton.Text = "Админка";
            this.adminButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.adminButton.UseVisualStyleBackColor = true;
            this.adminButton.Click += new System.EventHandler(this.AdminButton_Click);
            // 
            // undoneButton
            // 
            this.undoneButton.AccessibleDescription = "";
            this.undoneButton.AccessibleName = "Homework";
            this.undoneButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.undoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.undoneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.undoneButton.Location = new System.Drawing.Point(0, 100);
            this.undoneButton.Margin = new System.Windows.Forms.Padding(0);
            this.undoneButton.Name = "undoneButton";
            this.undoneButton.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.undoneButton.Size = new System.Drawing.Size(200, 100);
            this.undoneButton.TabIndex = 12;
            this.undoneButton.Text = "Задания";
            this.undoneButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.undoneButton.UseVisualStyleBackColor = true;
            this.undoneButton.Click += new System.EventHandler(this.UndoneButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.moderButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.scheludeButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.undoneButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.optionsButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.adminButton, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 88);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 503);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // moderButton
            // 
            this.moderButton.AccessibleDescription = "";
            this.moderButton.AccessibleName = "";
            this.moderButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.moderButton.Location = new System.Drawing.Point(0, 300);
            this.moderButton.Margin = new System.Windows.Forms.Padding(0);
            this.moderButton.Name = "moderButton";
            this.moderButton.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.moderButton.Size = new System.Drawing.Size(200, 100);
            this.moderButton.TabIndex = 13;
            this.moderButton.Text = "Модерка";
            this.moderButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.moderButton.UseVisualStyleBackColor = true;
            this.moderButton.Click += new System.EventHandler(this.ModerButton_Click);
            // 
            // Main
            // 
            this.AccessibleName = "ToDoList";
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(981, 603);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.backButton);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(999, 1200);
            this.MinimumSize = new System.Drawing.Size(999, 650);
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Head_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Timer buttonsTimer;
        private System.Windows.Forms.Timer sqlUpdater;
        private System.Windows.Forms.Button scheludeButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Button adminButton;
        private System.Windows.Forms.Button undoneButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button moderButton;
    }
}

