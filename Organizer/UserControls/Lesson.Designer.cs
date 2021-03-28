﻿namespace Organizer
{
    partial class Lesson
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
            this.NumLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.WorkLabel = new System.Windows.Forms.Label();
            this.AddAttachmentButton = new System.Windows.Forms.Button();
            this.DoneCheckBox = new System.Windows.Forms.CheckBox();
            this.HomeworkTextBox = new System.Windows.Forms.TextBox();
            this.AttachmentLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // NumLabel
            // 
            this.NumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumLabel.Location = new System.Drawing.Point(0, 0);
            this.NumLabel.Margin = new System.Windows.Forms.Padding(0);
            this.NumLabel.Name = "NumLabel";
            this.NumLabel.Size = new System.Drawing.Size(50, 70);
            this.NumLabel.TabIndex = 0;
            this.NumLabel.Text = "0";
            this.NumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.TitleLabel.Location = new System.Drawing.Point(50, 0);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(700, 20);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Title";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WorkLabel
            // 
            this.WorkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WorkLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.WorkLabel.Location = new System.Drawing.Point(50, 20);
            this.WorkLabel.Margin = new System.Windows.Forms.Padding(0);
            this.WorkLabel.Name = "WorkLabel";
            this.WorkLabel.Size = new System.Drawing.Size(700, 50);
            this.WorkLabel.TabIndex = 2;
            this.WorkLabel.Text = "workworkworkworkworkworkworkworkworkworkwork";
            this.WorkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AddAttachmentButton
            // 
            this.AddAttachmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddAttachmentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddAttachmentButton.ForeColor = System.Drawing.Color.LimeGreen;
            this.AddAttachmentButton.Location = new System.Drawing.Point(690, 10);
            this.AddAttachmentButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddAttachmentButton.Name = "AddAttachmentButton";
            this.AddAttachmentButton.Size = new System.Drawing.Size(50, 50);
            this.AddAttachmentButton.TabIndex = 3;
            this.AddAttachmentButton.Text = "+";
            this.AddAttachmentButton.UseVisualStyleBackColor = true;
            this.AddAttachmentButton.Visible = false;
            // 
            // DoneCheckBox
            // 
            this.DoneCheckBox.AutoSize = true;
            this.DoneCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.DoneCheckBox.Location = new System.Drawing.Point(0, -2);
            this.DoneCheckBox.Name = "DoneCheckBox";
            this.DoneCheckBox.Size = new System.Drawing.Size(18, 17);
            this.DoneCheckBox.TabIndex = 4;
            this.DoneCheckBox.UseVisualStyleBackColor = false;
            // 
            // HomeworkTextBox
            // 
            this.HomeworkTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.HomeworkTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HomeworkTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HomeworkTextBox.ForeColor = System.Drawing.Color.White;
            this.HomeworkTextBox.Location = new System.Drawing.Point(50, 25);
            this.HomeworkTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.HomeworkTextBox.MaxLength = 200;
            this.HomeworkTextBox.Multiline = true;
            this.HomeworkTextBox.Name = "HomeworkTextBox";
            this.HomeworkTextBox.Size = new System.Drawing.Size(630, 45);
            this.HomeworkTextBox.TabIndex = 5;
            this.HomeworkTextBox.Visible = false;
            // 
            // AttachmentLink
            // 
            this.AttachmentLink.ActiveLinkColor = System.Drawing.Color.White;
            this.AttachmentLink.BackColor = System.Drawing.Color.Transparent;
            this.AttachmentLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AttachmentLink.DisabledLinkColor = System.Drawing.Color.White;
            this.AttachmentLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AttachmentLink.LinkColor = System.Drawing.Color.White;
            this.AttachmentLink.Location = new System.Drawing.Point(630, -20);
            this.AttachmentLink.Name = "AttachmentLink";
            this.AttachmentLink.Size = new System.Drawing.Size(50, 40);
            this.AttachmentLink.TabIndex = 6;
            this.AttachmentLink.TabStop = true;
            this.AttachmentLink.Text = "...";
            this.AttachmentLink.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.AttachmentLink.VisitedLinkColor = System.Drawing.Color.White;
            this.AttachmentLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AttachmentLink_LinkClicked);
            // 
            // Lesson
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.AttachmentLink);
            this.Controls.Add(this.HomeworkTextBox);
            this.Controls.Add(this.DoneCheckBox);
            this.Controls.Add(this.AddAttachmentButton);
            this.Controls.Add(this.WorkLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.NumLabel);
            this.Name = "Lesson";
            this.Size = new System.Drawing.Size(750, 70);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label NumLabel;
        public System.Windows.Forms.Label TitleLabel;
        public System.Windows.Forms.Label WorkLabel;
        public System.Windows.Forms.Button AddAttachmentButton;
        public System.Windows.Forms.CheckBox DoneCheckBox;
        public System.Windows.Forms.TextBox HomeworkTextBox;
        public System.Windows.Forms.LinkLabel AttachmentLink;
    }
}
