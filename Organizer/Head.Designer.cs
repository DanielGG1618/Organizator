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
            this.datePlusButton = new System.Windows.Forms.Button();
            this.dateMinusButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.saveScreenButton = new System.Windows.Forms.Button();
            this.editModeButton = new System.Windows.Forms.Button();
            this.lessonsPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.screenShotPanel = new System.Windows.Forms.Panel();
            this.copyScreen = new System.Windows.Forms.Button();
            this.screen = new System.Windows.Forms.Panel();
            this.panel15.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.screenShotPanel.SuspendLayout();
            this.screen.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panel15.Controls.Add(this.DateText);
            this.panel15.Controls.Add(this.datePlusButton);
            this.panel15.Controls.Add(this.dateMinusButton);
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(700, 70);
            this.panel15.TabIndex = 1;
            // 
            // DateText
            // 
            this.DateText.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DateText.Location = new System.Drawing.Point(70, 0);
            this.DateText.Margin = new System.Windows.Forms.Padding(70, 0, 70, 0);
            this.DateText.Name = "DateText";
            this.DateText.Size = new System.Drawing.Size(560, 70);
            this.DateText.TabIndex = 4;
            this.DateText.Text = "dd.mm.yyyy";
            this.DateText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // datePlusButton
            // 
            this.datePlusButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datePlusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.datePlusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.datePlusButton.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.datePlusButton.Location = new System.Drawing.Point(630, 0);
            this.datePlusButton.Margin = new System.Windows.Forms.Padding(0);
            this.datePlusButton.Name = "datePlusButton";
            this.datePlusButton.Size = new System.Drawing.Size(70, 70);
            this.datePlusButton.TabIndex = 7;
            this.datePlusButton.Text = ">";
            this.datePlusButton.UseVisualStyleBackColor = false;
            this.datePlusButton.Click += new System.EventHandler(this.DatePlusButton_Click);
            // 
            // dateMinusButton
            // 
            this.dateMinusButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dateMinusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateMinusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dateMinusButton.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateMinusButton.Location = new System.Drawing.Point(0, 0);
            this.dateMinusButton.Margin = new System.Windows.Forms.Padding(0);
            this.dateMinusButton.Name = "dateMinusButton";
            this.dateMinusButton.Size = new System.Drawing.Size(70, 70);
            this.dateMinusButton.TabIndex = 6;
            this.dateMinusButton.Text = "<";
            this.dateMinusButton.UseVisualStyleBackColor = false;
            this.dateMinusButton.Click += new System.EventHandler(this.DateMinusButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.AccessibleName = "Settings";
            this.settingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.settingsButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.settingsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settingsButton.Location = new System.Drawing.Point(0, 460);
            this.settingsButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(422, 130);
            this.settingsButton.TabIndex = 4;
            this.settingsButton.Text = "Настройки";
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // saveScreenButton
            // 
            this.saveScreenButton.AccessibleName = "Save screen";
            this.saveScreenButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.saveScreenButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.saveScreenButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveScreenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveScreenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveScreenButton.Location = new System.Drawing.Point(0, 0);
            this.saveScreenButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.saveScreenButton.Name = "saveScreenButton";
            this.saveScreenButton.Size = new System.Drawing.Size(422, 130);
            this.saveScreenButton.TabIndex = 0;
            this.saveScreenButton.Text = "Сохранить скриншот";
            this.saveScreenButton.UseVisualStyleBackColor = false;
            this.saveScreenButton.Click += new System.EventHandler(this.SaveScreenButton_Click);
            // 
            // editModeButton
            // 
            this.editModeButton.AccessibleName = "Edit mode";
            this.editModeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.editModeButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.editModeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editModeButton.Location = new System.Drawing.Point(0, 310);
            this.editModeButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.editModeButton.Name = "editModeButton";
            this.editModeButton.Size = new System.Drawing.Size(422, 130);
            this.editModeButton.TabIndex = 3;
            this.editModeButton.Text = "Режим редактирования";
            this.editModeButton.UseVisualStyleBackColor = false;
            this.editModeButton.Click += new System.EventHandler(this.EditModeButton_Click);
            // 
            // lessonsPanel
            // 
            this.lessonsPanel.AutoScroll = true;
            this.lessonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lessonsPanel.Location = new System.Drawing.Point(0, 90);
            this.lessonsPanel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.lessonsPanel.Name = "lessonsPanel";
            this.lessonsPanel.Size = new System.Drawing.Size(700, 490);
            this.lessonsPanel.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.copyScreen, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.screenShotPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.settingsButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.editModeButton, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(739, 12);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(12, 3, 12, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(422, 600);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // screenShotPanel
            // 
            this.screenShotPanel.Controls.Add(this.saveScreenButton);
            this.screenShotPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenShotPanel.Location = new System.Drawing.Point(0, 10);
            this.screenShotPanel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.screenShotPanel.Name = "screenShotPanel";
            this.screenShotPanel.Size = new System.Drawing.Size(422, 130);
            this.screenShotPanel.TabIndex = 11;
            // 
            // copyScreen
            // 
            this.copyScreen.AccessibleName = "Copy screen";
            this.copyScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.copyScreen.Cursor = System.Windows.Forms.Cursors.Default;
            this.copyScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copyScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.copyScreen.Location = new System.Drawing.Point(0, 160);
            this.copyScreen.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.copyScreen.Name = "copyScreen";
            this.copyScreen.Size = new System.Drawing.Size(422, 130);
            this.copyScreen.TabIndex = 1;
            this.copyScreen.Text = "Скопировать скриншот";
            this.copyScreen.UseVisualStyleBackColor = false;
            this.copyScreen.Click += new System.EventHandler(this.CopyScreen_Click);
            // 
            // screen
            // 
            this.screen.Controls.Add(this.lessonsPanel);
            this.screen.Controls.Add(this.panel15);
            this.screen.Location = new System.Drawing.Point(24, 22);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(700, 580);
            this.screen.TabIndex = 9;
            // 
            // Head
            // 
            this.AccessibleName = "ToDoList";
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1182, 619);
            this.Controls.Add(this.screen);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1200, 666);
            this.MinimumSize = new System.Drawing.Size(1200, 666);
            this.Name = "Head";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SaveFiles);
            this.Load += new System.EventHandler(this.Head_Load);
            this.panel15.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.screenShotPanel.ResumeLayout(false);
            this.screen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Button datePlusButton;
        private System.Windows.Forms.Button dateMinusButton;
        private System.Windows.Forms.Button editModeButton;
        private System.Windows.Forms.Button saveScreenButton;
        private System.Windows.Forms.Label DateText;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Panel lessonsPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel screen;
        private System.Windows.Forms.Panel screenShotPanel;
        private System.Windows.Forms.Button copyScreen;
    }
}

