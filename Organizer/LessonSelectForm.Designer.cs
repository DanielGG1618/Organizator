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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.LessonLabel = new System.Windows.Forms.Label();
            this.Done = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Items.AddRange(new object[] {
            "Алгебра",
            "Английский язык",
            "Биология",
            "География",
            "Геометрия",
            "Информатика",
            "История",
            "Литература",
            "Немецкий язык",
            "ОБЖ",
            "Обществознание",
            "Родной язык",
            "Русский язык",
            "Технология",
            "Физика",
            "Физкультура",
            "Химия"});
            this.comboBox1.Location = new System.Drawing.Point(19, 53);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(194, 33);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // LessonLabel
            // 
            this.LessonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LessonLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.LessonLabel.Location = new System.Drawing.Point(19, 14);
            this.LessonLabel.Margin = new System.Windows.Forms.Padding(10);
            this.LessonLabel.Name = "LessonLabel";
            this.LessonLabel.Size = new System.Drawing.Size(194, 29);
            this.LessonLabel.TabIndex = 4;
            this.LessonLabel.Text = " Урок №n";
            // 
            // Done
            // 
            this.Done.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Done.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Done.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Done.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Done.Location = new System.Drawing.Point(123, 149);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(90, 33);
            this.Done.TabIndex = 5;
            this.Done.Text = "готово";
            this.Done.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cancel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Cancel.Location = new System.Drawing.Point(19, 149);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(90, 33);
            this.Cancel.TabIndex = 5;
            this.Cancel.Text = "отмена";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // LessonSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(232, 208);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.LessonLabel);
            this.Controls.Add(this.comboBox1);
            this.MaximumSize = new System.Drawing.Size(250, 250);
            this.MinimumSize = new System.Drawing.Size(250, 250);
            this.Name = "LessonSelectForm";
            this.Text = "    ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label LessonLabel;
        private System.Windows.Forms.Button Done;
        private System.Windows.Forms.Button Cancel;
    }
}