namespace Organizer
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.languageSelector = new System.Windows.Forms.ComboBox();
            this.languagePict = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddHolyday = new System.Windows.Forms.Button();
            this.holydayStartPicker = new System.Windows.Forms.DateTimePicker();
            this.holyday = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.holydayTypeComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.languagePict)).BeginInit();
            this.SuspendLayout();
            // 
            // languageSelector
            // 
            this.languageSelector.AccessibleName = "Language";
            this.languageSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.languageSelector.BackColor = System.Drawing.SystemColors.Window;
            this.languageSelector.Cursor = System.Windows.Forms.Cursors.Default;
            this.languageSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.languageSelector.ForeColor = System.Drawing.Color.Black;
            this.languageSelector.FormattingEnabled = true;
            this.languageSelector.Items.AddRange(new object[] {
            "Русский",
            "English"});
            this.languageSelector.Location = new System.Drawing.Point(110, 39);
            this.languageSelector.Margin = new System.Windows.Forms.Padding(6, 30, 30, 30);
            this.languageSelector.Name = "languageSelector";
            this.languageSelector.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.languageSelector.Size = new System.Drawing.Size(200, 30);
            this.languageSelector.TabIndex = 0;
            this.languageSelector.SelectedIndexChanged += new System.EventHandler(this.LanguageSelector_SelectedIndexChanged);
            // 
            // languagePict
            // 
            this.languagePict.Image = global::Organizer.Properties.Resources.rus;
            this.languagePict.Location = new System.Drawing.Point(15, 12);
            this.languagePict.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.languagePict.Name = "languagePict";
            this.languagePict.Size = new System.Drawing.Size(83, 83);
            this.languagePict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.languagePict.TabIndex = 1;
            this.languagePict.TabStop = false;
            // 
            // label1
            // 
            this.label1.AccessibleName = "label1";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AccessibleName = "label2";
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // AddHolyday
            // 
            this.AddHolyday.AccessibleDescription = "";
            this.AddHolyday.AccessibleName = "Add";
            this.AddHolyday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.AddHolyday.Cursor = System.Windows.Forms.Cursors.Default;
            this.AddHolyday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddHolyday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddHolyday.ForeColor = System.Drawing.Color.OliveDrab;
            this.AddHolyday.Location = new System.Drawing.Point(19, 377);
            this.AddHolyday.Margin = new System.Windows.Forms.Padding(10);
            this.AddHolyday.Name = "AddHolyday";
            this.AddHolyday.Size = new System.Drawing.Size(147, 62);
            this.AddHolyday.TabIndex = 4;
            this.AddHolyday.Text = "Добавить";
            this.AddHolyday.UseVisualStyleBackColor = false;
            // 
            // holydayStartPicker
            // 
            this.holydayStartPicker.AllowDrop = true;
            this.holydayStartPicker.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.holydayStartPicker.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.holydayStartPicker.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.holydayStartPicker.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.holydayStartPicker.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.holydayStartPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.holydayStartPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.holydayStartPicker.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.holydayStartPicker.Location = new System.Drawing.Point(207, 377);
            this.holydayStartPicker.Name = "holydayStartPicker";
            this.holydayStartPicker.Size = new System.Drawing.Size(138, 28);
            this.holydayStartPicker.TabIndex = 7;
            this.holydayStartPicker.Value = new System.DateTime(2019, 9, 1, 0, 0, 0, 0);
            // 
            // holyday
            // 
            this.holyday.AllowDrop = true;
            this.holyday.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.holyday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.holyday.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.holyday.Location = new System.Drawing.Point(207, 412);
            this.holyday.Name = "holyday";
            this.holyday.Size = new System.Drawing.Size(138, 28);
            this.holyday.TabIndex = 7;
            this.holyday.Value = new System.DateTime(2019, 9, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(168, 377);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "От";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(168, 412);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "До";
            // 
            // holydayTypeComboBox
            // 
            this.holydayTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.holydayTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.holydayTypeComboBox.ForeColor = System.Drawing.Color.Black;
            this.holydayTypeComboBox.FormattingEnabled = true;
            this.holydayTypeComboBox.Items.AddRange(new object[] {
            "Первичные",
            "Вторичные",
            "Этого года"});
            this.holydayTypeComboBox.Location = new System.Drawing.Point(19, 341);
            this.holydayTypeComboBox.Name = "holydayTypeComboBox";
            this.holydayTypeComboBox.Size = new System.Drawing.Size(326, 30);
            this.holydayTypeComboBox.TabIndex = 9;
            this.holydayTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.HolydayTypeComboBox_SelectedIndexChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(798, 458);
            this.Controls.Add(this.holydayTypeComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.holyday);
            this.Controls.Add(this.holydayStartPicker);
            this.Controls.Add(this.AddHolyday);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.languagePict);
            this.Controls.Add(this.languageSelector);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(816, 500);
            this.MinimumSize = new System.Drawing.Size(816, 500);
            this.Name = "Settings";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.languagePict)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox languageSelector;
        private System.Windows.Forms.PictureBox languagePict;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddHolyday;
        private System.Windows.Forms.DateTimePicker holydayStartPicker;
        private System.Windows.Forms.DateTimePicker holyday;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox holydayTypeComboBox;
    }
}