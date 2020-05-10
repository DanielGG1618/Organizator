namespace Organizer
{
    partial class LessonSelectForm
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
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.lessonLabel = new System.Windows.Forms.Label();
            this.done = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox
            // 
            this.comboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox.ForeColor = System.Drawing.Color.White;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.IntegralHeight = false;
            this.comboBox.Items.AddRange(new object[] {
            "Algebra",
            "Biology",
            "Chemistry",
            "English language",
            "Geography",
            "Geometry",
            "German language",
            "History",
            "Informatics",
            "Life safety",
            "Literature",
            "Music",
            "Native language",
            "Physical education",
            "Physics",
            "Russian language",
            "Social studies",
            "Technology"});
            this.comboBox.Location = new System.Drawing.Point(19, 53);
            this.comboBox.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(194, 33);
            this.comboBox.Sorted = true;
            this.comboBox.TabIndex = 3;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // lessonLabel
            // 
            this.lessonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lessonLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lessonLabel.Location = new System.Drawing.Point(19, 14);
            this.lessonLabel.Margin = new System.Windows.Forms.Padding(10);
            this.lessonLabel.Name = "lessonLabel";
            this.lessonLabel.Size = new System.Drawing.Size(194, 29);
            this.lessonLabel.TabIndex = 4;
            this.lessonLabel.Text = " Урок №n";
            this.lessonLabel.Click += new System.EventHandler(this.LessonLabel_Click);
            // 
            // done
            // 
            this.done.AccessibleName = "Done";
            this.done.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.done.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.done.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.done.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.done.Location = new System.Drawing.Point(123, 149);
            this.done.Name = "done";
            this.done.Size = new System.Drawing.Size(90, 33);
            this.done.TabIndex = 5;
            this.done.Text = "Готово";
            this.done.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.AccessibleName = "Cancel";
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel.Location = new System.Drawing.Point(19, 149);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(90, 33);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // LessonSelectForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(232, 208);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.done);
            this.Controls.Add(this.lessonLabel);
            this.Controls.Add(this.comboBox);
            this.ForeColor = System.Drawing.Color.OliveDrab;
            this.MaximumSize = new System.Drawing.Size(250, 250);
            this.MinimumSize = new System.Drawing.Size(250, 250);
            this.Name = "LessonSelectForm";
            this.Text = "    ";
            this.Load += new System.EventHandler(this.LessonSelectForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label lessonLabel;
        private System.Windows.Forms.Button done;
        private System.Windows.Forms.Button cancel;
    }
}