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
            "adsasd",
            "dasda",
            "qsd "});
            this.comboBox1.Location = new System.Drawing.Point(19, 53);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(194, 33);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // LessonLabel
            // 
            this.LessonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LessonLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.LessonLabel.Location = new System.Drawing.Point(19, 14);
            this.LessonLabel.Margin = new System.Windows.Forms.Padding(10);
            this.LessonLabel.Name = "LessonLabel";
            this.LessonLabel.Size = new System.Drawing.Size(194, 29);
            this.LessonLabel.TabIndex = 4;
            this.LessonLabel.Text = " Урок №n";
            // 
            // LessonSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(232, 203);
            this.Controls.Add(this.LessonLabel);
            this.Controls.Add(this.comboBox1);
            this.MaximumSize = new System.Drawing.Size(250, 250);
            this.MinimumSize = new System.Drawing.Size(250, 250);
            this.Name = "LessonSelectForm";
            this.Text = "    ";
            this.Load += new System.EventHandler(this.LessonSelectForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label LessonLabel;
    }
}