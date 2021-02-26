namespace Organizer
{
    partial class Options
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
            this.languageSelector = new System.Windows.Forms.ComboBox();
            this.addHolyday = new System.Windows.Forms.Button();
            this.holydayStartPicker = new System.Windows.Forms.DateTimePicker();
            this.holydayFinishPicker = new System.Windows.Forms.DateTimePicker();
            this.fromLabel = new System.Windows.Forms.Label();
            this.toLabel = new System.Windows.Forms.Label();
            this.holydayTypeComboBox = new System.Windows.Forms.ComboBox();
            this.addHolydayPanel = new System.Windows.Forms.Panel();
            this.pickersPanel = new System.Windows.Forms.Panel();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.colorLabel = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.holyLabel = new System.Windows.Forms.Label();
            this.languagePict = new System.Windows.Forms.PictureBox();
            this.themeCheckBox = new System.Windows.Forms.CheckBox();
            this.addHolydayPanel.SuspendLayout();
            this.pickersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.languagePict)).BeginInit();
            this.SuspendLayout();
            // 
            // languageSelector
            // 
            this.languageSelector.AccessibleName = "Language";
            this.languageSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.languageSelector.Cursor = System.Windows.Forms.Cursors.Default;
            this.languageSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.languageSelector.ForeColor = System.Drawing.Color.White;
            this.languageSelector.FormattingEnabled = true;
            this.languageSelector.Items.AddRange(new object[] {
            "Русский",
            "English",
            "Кто я am"});
            this.languageSelector.Location = new System.Drawing.Point(110, 39);
            this.languageSelector.Margin = new System.Windows.Forms.Padding(6, 30, 30, 30);
            this.languageSelector.Name = "languageSelector";
            this.languageSelector.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.languageSelector.Size = new System.Drawing.Size(263, 30);
            this.languageSelector.TabIndex = 0;
            this.languageSelector.SelectedIndexChanged += new System.EventHandler(this.LanguageSelector_SelectedIndexChanged);
            // 
            // addHolyday
            // 
            this.addHolyday.AccessibleDescription = "";
            this.addHolyday.AccessibleName = "Add";
            this.addHolyday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addHolyday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.addHolyday.Cursor = System.Windows.Forms.Cursors.Default;
            this.addHolyday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addHolyday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addHolyday.Location = new System.Drawing.Point(0, 36);
            this.addHolyday.Margin = new System.Windows.Forms.Padding(10);
            this.addHolyday.Name = "addHolyday";
            this.addHolyday.Size = new System.Drawing.Size(147, 55);
            this.addHolyday.TabIndex = 4;
            this.addHolyday.Text = "Добавить";
            this.addHolyday.UseVisualStyleBackColor = false;
            this.addHolyday.Click += new System.EventHandler(this.AddHolyday_Click);
            // 
            // holydayStartPicker
            // 
            this.holydayStartPicker.AllowDrop = true;
            this.holydayStartPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.holydayStartPicker.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.holydayStartPicker.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.holydayStartPicker.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.holydayStartPicker.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.holydayStartPicker.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.holydayStartPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.holydayStartPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.holydayStartPicker.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.holydayStartPicker.Location = new System.Drawing.Point(0, 0);
            this.holydayStartPicker.Name = "holydayStartPicker";
            this.holydayStartPicker.Size = new System.Drawing.Size(138, 28);
            this.holydayStartPicker.TabIndex = 7;
            this.holydayStartPicker.Value = new System.DateTime(2019, 9, 1, 0, 0, 0, 0);
            this.holydayStartPicker.ValueChanged += new System.EventHandler(this.HolydayStartPicker_ValueChanged);
            // 
            // holydayFinishPicker
            // 
            this.holydayFinishPicker.AllowDrop = true;
            this.holydayFinishPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.holydayFinishPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.holydayFinishPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.holydayFinishPicker.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.holydayFinishPicker.Location = new System.Drawing.Point(0, 27);
            this.holydayFinishPicker.Name = "holydayFinishPicker";
            this.holydayFinishPicker.Size = new System.Drawing.Size(138, 28);
            this.holydayFinishPicker.TabIndex = 7;
            this.holydayFinishPicker.Value = new System.DateTime(2019, 9, 1, 0, 0, 0, 0);
            this.holydayFinishPicker.ValueChanged += new System.EventHandler(this.HolydayFinishPicker_ValueChanged);
            // 
            // fromLabel
            // 
            this.fromLabel.AccessibleName = "From";
            this.fromLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fromLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fromLabel.ForeColor = System.Drawing.Color.White;
            this.fromLabel.Location = new System.Drawing.Point(147, 38);
            this.fromLabel.Margin = new System.Windows.Forms.Padding(0);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fromLabel.Size = new System.Drawing.Size(72, 25);
            this.fromLabel.TabIndex = 8;
            this.fromLabel.Text = "От";
            this.fromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toLabel
            // 
            this.toLabel.AccessibleName = "To";
            this.toLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.toLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toLabel.ForeColor = System.Drawing.Color.White;
            this.toLabel.Location = new System.Drawing.Point(147, 66);
            this.toLabel.Margin = new System.Windows.Forms.Padding(0);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(72, 25);
            this.toLabel.TabIndex = 8;
            this.toLabel.Text = "До";
            this.toLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // holydayTypeComboBox
            // 
            this.holydayTypeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.holydayTypeComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.holydayTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.holydayTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.holydayTypeComboBox.ForeColor = System.Drawing.Color.White;
            this.holydayTypeComboBox.FormattingEnabled = true;
            this.holydayTypeComboBox.Location = new System.Drawing.Point(0, 0);
            this.holydayTypeComboBox.Name = "holydayTypeComboBox";
            this.holydayTypeComboBox.Size = new System.Drawing.Size(358, 30);
            this.holydayTypeComboBox.TabIndex = 9;
            this.holydayTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.HolydayTypeComboBox_SelectedIndexChanged);
            // 
            // addHolydayPanel
            // 
            this.addHolydayPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addHolydayPanel.Controls.Add(this.pickersPanel);
            this.addHolydayPanel.Controls.Add(this.fromLabel);
            this.addHolydayPanel.Controls.Add(this.holydayTypeComboBox);
            this.addHolydayPanel.Controls.Add(this.addHolyday);
            this.addHolydayPanel.Controls.Add(this.toLabel);
            this.addHolydayPanel.Location = new System.Drawing.Point(15, 405);
            this.addHolydayPanel.Name = "addHolydayPanel";
            this.addHolydayPanel.Size = new System.Drawing.Size(358, 91);
            this.addHolydayPanel.TabIndex = 11;
            // 
            // pickersPanel
            // 
            this.pickersPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pickersPanel.Controls.Add(this.holydayStartPicker);
            this.pickersPanel.Controls.Add(this.holydayFinishPicker);
            this.pickersPanel.Location = new System.Drawing.Point(219, 38);
            this.pickersPanel.Name = "pickersPanel";
            this.pickersPanel.Size = new System.Drawing.Size(138, 53);
            this.pickersPanel.TabIndex = 12;
            // 
            // colorPanel
            // 
            this.colorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.colorPanel.BackColor = System.Drawing.Color.White;
            this.colorPanel.Location = new System.Drawing.Point(15, 268);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(83, 83);
            this.colorPanel.TabIndex = 12;
            this.colorPanel.Click += new System.EventHandler(this.ColorPanel_Click);
            // 
            // colorLabel
            // 
            this.colorLabel.AccessibleName = "Select color";
            this.colorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.colorLabel.AutoSize = true;
            this.colorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colorLabel.ForeColor = System.Drawing.Color.White;
            this.colorLabel.Location = new System.Drawing.Point(105, 294);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(189, 29);
            this.colorLabel.TabIndex = 13;
            this.colorLabel.Text = "Выберите цвет";
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.Color = System.Drawing.Color.OliveDrab;
            // 
            // holyLabel
            // 
            this.holyLabel.AccessibleName = "Add holydays";
            this.holyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.holyLabel.AutoSize = true;
            this.holyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.holyLabel.Location = new System.Drawing.Point(12, 367);
            this.holyLabel.Name = "holyLabel";
            this.holyLabel.Size = new System.Drawing.Size(268, 31);
            this.holyLabel.TabIndex = 14;
            this.holyLabel.Text = "Добавить выходные";
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
            // themeCheckBox
            // 
            this.themeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.themeCheckBox.ForeColor = System.Drawing.Color.White;
            this.themeCheckBox.Location = new System.Drawing.Point(32, 210);
            this.themeCheckBox.Name = "themeCheckBox";
            this.themeCheckBox.Size = new System.Drawing.Size(340, 52);
            this.themeCheckBox.TabIndex = 17;
            this.themeCheckBox.Text = "Тёмная тема";
            this.themeCheckBox.UseVisualStyleBackColor = true;
            this.themeCheckBox.CheckedChanged += new System.EventHandler(this.ThemeCheckBox_CheckedChanged);
            // 
            // Options
            // 
            this.AccessibleName = "Options";
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.themeCheckBox);
            this.Controls.Add(this.holyLabel);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.addHolydayPanel);
            this.Controls.Add(this.languagePict);
            this.Controls.Add(this.languageSelector);
            this.MaximumSize = new System.Drawing.Size(400, 550);
            this.MinimumSize = new System.Drawing.Size(400, 550);
            this.Name = "Options";
            this.Size = new System.Drawing.Size(400, 550);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.addHolydayPanel.ResumeLayout(false);
            this.pickersPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.languagePict)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox languageSelector;
        private System.Windows.Forms.PictureBox languagePict;
        private System.Windows.Forms.Button addHolyday;
        private System.Windows.Forms.DateTimePicker holydayStartPicker;
        private System.Windows.Forms.DateTimePicker holydayFinishPicker;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.ComboBox holydayTypeComboBox;
        private System.Windows.Forms.Panel addHolydayPanel;
        private System.Windows.Forms.Panel pickersPanel;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label holyLabel;
        private System.Windows.Forms.CheckBox themeCheckBox;
    }
}