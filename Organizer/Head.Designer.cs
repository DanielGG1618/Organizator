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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.SaveToButton = new System.Windows.Forms.Button();
            this.LoadFromButton = new System.Windows.Forms.Button();
            this.SaveScreenButton = new System.Windows.Forms.Button();
            this.EditModeButton = new System.Windows.Forms.Button();
            this.lessonsPanel = new System.Windows.Forms.Panel();
            this.panel15.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.SettingsButton, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.SaveToButton, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.LoadFromButton, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.SaveScreenButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.EditModeButton, 0, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(743, 13);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(427, 599);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.SettingsButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.SettingsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SettingsButton.ForeColor = System.Drawing.Color.OliveDrab;
            this.SettingsButton.Location = new System.Drawing.Point(0, 486);
            this.SettingsButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(427, 103);
            this.SettingsButton.TabIndex = 6;
            this.SettingsButton.Text = "Настройки";
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // SaveToButton
            // 
            this.SaveToButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.SaveToButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.SaveToButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveToButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveToButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveToButton.ForeColor = System.Drawing.Color.OliveDrab;
            this.SaveToButton.Location = new System.Drawing.Point(0, 248);
            this.SaveToButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.SaveToButton.Name = "SaveToButton";
            this.SaveToButton.Size = new System.Drawing.Size(427, 99);
            this.SaveToButton.TabIndex = 2;
            this.SaveToButton.Text = "Сохранить а файл";
            this.SaveToButton.UseVisualStyleBackColor = false;
            this.SaveToButton.Click += new System.EventHandler(this.SaveToButton_Click);
            // 
            // LoadFromButton
            // 
            this.LoadFromButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.LoadFromButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.LoadFromButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadFromButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadFromButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadFromButton.ForeColor = System.Drawing.Color.OliveDrab;
            this.LoadFromButton.Location = new System.Drawing.Point(0, 129);
            this.LoadFromButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.LoadFromButton.Name = "LoadFromButton";
            this.LoadFromButton.Size = new System.Drawing.Size(427, 99);
            this.LoadFromButton.TabIndex = 1;
            this.LoadFromButton.Text = "Загрузить из файла";
            this.LoadFromButton.UseVisualStyleBackColor = false;
            this.LoadFromButton.Click += new System.EventHandler(this.LoadFromButton_Click);
            // 
            // SaveScreenButton
            // 
            this.SaveScreenButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.SaveScreenButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.SaveScreenButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveScreenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveScreenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveScreenButton.ForeColor = System.Drawing.Color.OliveDrab;
            this.SaveScreenButton.Location = new System.Drawing.Point(0, 10);
            this.SaveScreenButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.SaveScreenButton.Name = "SaveScreenButton";
            this.SaveScreenButton.Size = new System.Drawing.Size(427, 99);
            this.SaveScreenButton.TabIndex = 0;
            this.SaveScreenButton.Text = "Сохранить скриншот";
            this.SaveScreenButton.UseVisualStyleBackColor = false;
            this.SaveScreenButton.Click += new System.EventHandler(this.SaveScreenButton_Click);
            // 
            // EditModeButton
            // 
            this.EditModeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.EditModeButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.EditModeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditModeButton.ForeColor = System.Drawing.Color.OliveDrab;
            this.EditModeButton.Location = new System.Drawing.Point(0, 367);
            this.EditModeButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.EditModeButton.Name = "EditModeButton";
            this.EditModeButton.Size = new System.Drawing.Size(427, 99);
            this.EditModeButton.TabIndex = 4;
            this.EditModeButton.Text = "Режим редактирования";
            this.EditModeButton.UseVisualStyleBackColor = false;
            this.EditModeButton.Click += new System.EventHandler(this.EditModeButton_Click);
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
            // Head
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1182, 617);
            this.Controls.Add(this.lessonsPanel);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panel15);
            this.ForeColor = System.Drawing.Color.OliveDrab;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1200, 700);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1200, 618);
            this.Name = "Head";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Список ";
            this.Load += new System.EventHandler(this.Head_Load);
            this.panel15.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Button DatePlusButton;
        private System.Windows.Forms.Button DateMinusButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button EditModeButton;
        private System.Windows.Forms.Button SaveToButton;
        private System.Windows.Forms.Button LoadFromButton;
        private System.Windows.Forms.Button SaveScreenButton;
        private System.Windows.Forms.Label DateText;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Panel lessonsPanel;
    }
}

