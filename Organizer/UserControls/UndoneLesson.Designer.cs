namespace Organizer
{
    partial class UndoneLesson
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
            this.attachmentLink = new System.Windows.Forms.LinkLabel();
            this.DoneCheckBox = new System.Windows.Forms.CheckBox();
            this.workLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // attachmentLink
            // 
            this.attachmentLink.ActiveLinkColor = System.Drawing.Color.White;
            this.attachmentLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.attachmentLink.BackColor = System.Drawing.Color.Transparent;
            this.attachmentLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.attachmentLink.DisabledLinkColor = System.Drawing.Color.White;
            this.attachmentLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.attachmentLink.LinkColor = System.Drawing.Color.White;
            this.attachmentLink.Location = new System.Drawing.Point(677, -22);
            this.attachmentLink.Name = "attachmentLink";
            this.attachmentLink.Size = new System.Drawing.Size(53, 40);
            this.attachmentLink.TabIndex = 6;
            this.attachmentLink.TabStop = true;
            this.attachmentLink.Text = "...";
            this.attachmentLink.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.attachmentLink.VisitedLinkColor = System.Drawing.Color.White;
            this.attachmentLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AttachmentLink_LinkClicked);
            // 
            // DoneCheckBox
            // 
            this.DoneCheckBox.AutoSize = true;
            this.DoneCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.DoneCheckBox.Location = new System.Drawing.Point(0, 0);
            this.DoneCheckBox.Name = "DoneCheckBox";
            this.DoneCheckBox.Size = new System.Drawing.Size(18, 17);
            this.DoneCheckBox.TabIndex = 4;
            this.DoneCheckBox.UseVisualStyleBackColor = false;
            // 
            // workLabel
            // 
            this.workLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.workLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.workLabel.Location = new System.Drawing.Point(0, 20);
            this.workLabel.Margin = new System.Windows.Forms.Padding(0);
            this.workLabel.Name = "workLabel";
            this.workLabel.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.workLabel.Size = new System.Drawing.Size(730, 50);
            this.workLabel.TabIndex = 2;
            this.workLabel.Text = "workworkworkworkworkworkworkworkworkworkwork";
            this.workLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.titleLabel.Size = new System.Drawing.Size(380, 20);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateLabel
            // 
            this.dateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.dateLabel.Location = new System.Drawing.Point(299, -2);
            this.dateLabel.Margin = new System.Windows.Forms.Padding(0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Padding = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.dateLabel.Size = new System.Drawing.Size(431, 72);
            this.dateLabel.TabIndex = 7;
            this.dateLabel.Text = "dd-mm-yy-weekday";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UndoneLesson
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.attachmentLink);
            this.Controls.Add(this.DoneCheckBox);
            this.Controls.Add(this.workLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.dateLabel);
            this.Name = "UndoneLesson";
            this.Size = new System.Drawing.Size(730, 70);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.CheckBox DoneCheckBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label workLabel;
        private System.Windows.Forms.LinkLabel attachmentLink;
        private System.Windows.Forms.Label dateLabel;
    }
}
