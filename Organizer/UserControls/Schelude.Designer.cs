namespace Organizer
{
    partial class Schelude
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.topPanel = new System.Windows.Forms.Panel();
            this.copyScreen = new System.Windows.Forms.Button();
            this.editModeButton = new System.Windows.Forms.Button();
            this.dateText = new System.Windows.Forms.Label();
            this.datePlusButton = new System.Windows.Forms.Button();
            this.dateMinusButton = new System.Windows.Forms.Button();
            this.lessonsPanel = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.topPanel.Controls.Add(this.copyScreen);
            this.topPanel.Controls.Add(this.editModeButton);
            this.topPanel.Controls.Add(this.dateText);
            this.topPanel.Controls.Add(this.datePlusButton);
            this.topPanel.Controls.Add(this.dateMinusButton);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(750, 70);
            this.topPanel.TabIndex = 1;
            // 
            // copyScreen
            // 
            this.copyScreen.AccessibleName = "Copy screen";
            this.copyScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.copyScreen.Cursor = System.Windows.Forms.Cursors.Default;
            this.copyScreen.Dock = System.Windows.Forms.DockStyle.Right;
            this.copyScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.copyScreen.Location = new System.Drawing.Point(540, 0);
            this.copyScreen.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.copyScreen.Name = "copyScreen";
            this.copyScreen.Size = new System.Drawing.Size(140, 70);
            this.copyScreen.TabIndex = 9;
            this.copyScreen.Text = "Скриншот";
            this.copyScreen.UseVisualStyleBackColor = false;
            this.copyScreen.Click += new System.EventHandler(this.CopyScreen_Click);
            // 
            // editModeButton
            // 
            this.editModeButton.AccessibleName = "Edit mode";
            this.editModeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.editModeButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.editModeButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.editModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editModeButton.Location = new System.Drawing.Point(70, 0);
            this.editModeButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.editModeButton.Name = "editModeButton";
            this.editModeButton.Size = new System.Drawing.Size(140, 70);
            this.editModeButton.TabIndex = 8;
            this.editModeButton.Text = "Редакт.";
            this.editModeButton.UseVisualStyleBackColor = false;
            this.editModeButton.Click += new System.EventHandler(this.EditModeButton_Click);
            // 
            // dateText
            // 
            this.dateText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateText.Location = new System.Drawing.Point(70, 0);
            this.dateText.Margin = new System.Windows.Forms.Padding(70, 0, 70, 0);
            this.dateText.Name = "dateText";
            this.dateText.Size = new System.Drawing.Size(610, 70);
            this.dateText.TabIndex = 4;
            this.dateText.Text = "dd.mm.yyyy - weekday";
            this.dateText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // datePlusButton
            // 
            this.datePlusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.datePlusButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.datePlusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.datePlusButton.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.datePlusButton.Location = new System.Drawing.Point(680, 0);
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
            this.dateMinusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateMinusButton.Dock = System.Windows.Forms.DockStyle.Left;
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
            // lessonsPanel
            // 
            this.lessonsPanel.AutoScroll = true;
            this.lessonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lessonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lessonsPanel.Location = new System.Drawing.Point(0, 90);
            this.lessonsPanel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.lessonsPanel.Name = "lessonsPanel";
            this.lessonsPanel.Size = new System.Drawing.Size(750, 490);
            this.lessonsPanel.TabIndex = 3;
            // 
            // Schelude
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.lessonsPanel);
            this.Name = "Schelude";
            this.Size = new System.Drawing.Size(750, 580);
            this.Load += new System.EventHandler(this.Schelude_Load);
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button copyScreen;
        private System.Windows.Forms.Button editModeButton;
        private System.Windows.Forms.Label dateText;
        public System.Windows.Forms.Button datePlusButton;
        public System.Windows.Forms.Button dateMinusButton;
        private System.Windows.Forms.Panel lessonsPanel;
    }
}
