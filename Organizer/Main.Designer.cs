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
            this.frontButton = new System.Windows.Forms.Button();
            this.buttonsTimer = new System.Windows.Forms.Timer(this.components);
            this.sqlUpdater = new System.Windows.Forms.Timer(this.components);
            this.scheludeButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.adminButton = new System.Windows.Forms.Button();
            this.undoneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.Location = new System.Drawing.Point(215, 12);
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
            this.backButton.Size = new System.Drawing.Size(90, 70);
            this.backButton.TabIndex = 11;
            this.backButton.Text = "<=";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // frontButton
            // 
            this.frontButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.frontButton.Enabled = false;
            this.frontButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.frontButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.frontButton.Location = new System.Drawing.Point(108, 12);
            this.frontButton.Name = "frontButton";
            this.frontButton.Size = new System.Drawing.Size(90, 70);
            this.frontButton.TabIndex = 11;
            this.frontButton.Text = "=>";
            this.frontButton.UseVisualStyleBackColor = false;
            this.frontButton.Click += new System.EventHandler(this.FrontButton_Click);
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
            this.scheludeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scheludeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scheludeButton.Location = new System.Drawing.Point(12, 99);
            this.scheludeButton.Name = "scheludeButton";
            this.scheludeButton.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.scheludeButton.Size = new System.Drawing.Size(186, 109);
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
            this.optionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.optionsButton.Location = new System.Drawing.Point(12, 329);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.optionsButton.Size = new System.Drawing.Size(186, 109);
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
            this.adminButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adminButton.Location = new System.Drawing.Point(12, 444);
            this.adminButton.Name = "adminButton";
            this.adminButton.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.adminButton.Size = new System.Drawing.Size(186, 109);
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
            this.undoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.undoneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.undoneButton.Location = new System.Drawing.Point(12, 214);
            this.undoneButton.Name = "undoneButton";
            this.undoneButton.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.undoneButton.Size = new System.Drawing.Size(186, 109);
            this.undoneButton.TabIndex = 12;
            this.undoneButton.Text = "Задания";
            this.undoneButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.undoneButton.UseVisualStyleBackColor = true;
            this.undoneButton.Click += new System.EventHandler(this.UndoneButton_Click);
            // 
            // Main
            // 
            this.AccessibleName = "ToDoList";
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(978, 603);
            this.Controls.Add(this.undoneButton);
            this.Controls.Add(this.adminButton);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.scheludeButton);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.frontButton);
            this.Controls.Add(this.backButton);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(996, 1200);
            this.MinimumSize = new System.Drawing.Size(996, 650);
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список ";
            this.Load += new System.EventHandler(this.Head_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button frontButton;
        private System.Windows.Forms.Timer buttonsTimer;
        private System.Windows.Forms.Timer sqlUpdater;
        private System.Windows.Forms.Button scheludeButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Button adminButton;
        private System.Windows.Forms.Button undoneButton;
    }
}

