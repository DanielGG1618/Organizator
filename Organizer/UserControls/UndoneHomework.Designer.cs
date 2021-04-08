namespace Organizer
{
    partial class UndoneHomework
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
            this.deleteDone = new System.Windows.Forms.Button();
            this.copyScreen = new System.Windows.Forms.Button();
            this.titleText = new System.Windows.Forms.Label();
            this.lessonsPanel = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.topPanel.Controls.Add(this.deleteDone);
            this.topPanel.Controls.Add(this.copyScreen);
            this.topPanel.Controls.Add(this.titleText);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(750, 70);
            this.topPanel.TabIndex = 1;
            // 
            // deleteDone
            // 
            this.deleteDone.AccessibleName = "";
            this.deleteDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.deleteDone.Cursor = System.Windows.Forms.Cursors.Default;
            this.deleteDone.Dock = System.Windows.Forms.DockStyle.Right;
            this.deleteDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteDone.Location = new System.Drawing.Point(540, 0);
            this.deleteDone.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.deleteDone.Name = "deleteDone";
            this.deleteDone.Size = new System.Drawing.Size(70, 70);
            this.deleteDone.TabIndex = 5;
            this.deleteDone.Text = "☼";
            this.deleteDone.UseVisualStyleBackColor = false;
            this.deleteDone.Click += new System.EventHandler(this.DeleteDone_Click);
            // 
            // copyScreen
            // 
            this.copyScreen.AccessibleName = "Copy screen";
            this.copyScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.copyScreen.Cursor = System.Windows.Forms.Cursors.Default;
            this.copyScreen.Dock = System.Windows.Forms.DockStyle.Right;
            this.copyScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.copyScreen.Location = new System.Drawing.Point(610, 0);
            this.copyScreen.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.copyScreen.Name = "copyScreen";
            this.copyScreen.Size = new System.Drawing.Size(140, 70);
            this.copyScreen.TabIndex = 4;
            this.copyScreen.Text = "Скриншот";
            this.copyScreen.UseVisualStyleBackColor = false;
            this.copyScreen.Click += new System.EventHandler(this.CopyScreen_Click);
            // 
            // titleText
            // 
            this.titleText.AccessibleName = "Undone homework";
            this.titleText.Dock = System.Windows.Forms.DockStyle.Left;
            this.titleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleText.Location = new System.Drawing.Point(0, 0);
            this.titleText.Margin = new System.Windows.Forms.Padding(70, 0, 70, 0);
            this.titleText.Name = "titleText";
            this.titleText.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.titleText.Size = new System.Drawing.Size(611, 70);
            this.titleText.TabIndex = 4;
            this.titleText.Text = "Невыполненные задания";
            this.titleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lessonsPanel.TabIndex = 4;
            // 
            // UndoneHomework
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.lessonsPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "UndoneHomework";
            this.Size = new System.Drawing.Size(750, 580);
            this.Load += new System.EventHandler(this.UndoneHomework_Load);
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button copyScreen;
        private System.Windows.Forms.Label titleText;
        private System.Windows.Forms.Button deleteDone;
        private System.Windows.Forms.Panel lessonsPanel;
    }
}
