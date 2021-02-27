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
            this.colorPanel = new System.Windows.Forms.Panel();
            this.colorLabel = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.languagePict = new System.Windows.Forms.PictureBox();
            this.themeCheckBox = new System.Windows.Forms.CheckBox();
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
            // colorPanel
            // 
            this.colorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.colorPanel.BackColor = System.Drawing.Color.White;
            this.colorPanel.Location = new System.Drawing.Point(15, 162);
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
            this.colorLabel.Location = new System.Drawing.Point(105, 188);
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
            this.themeCheckBox.Location = new System.Drawing.Point(33, 102);
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
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.languagePict);
            this.Controls.Add(this.languageSelector);
            this.Name = "Options";
            this.Size = new System.Drawing.Size(400, 256);
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.languagePict)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox languageSelector;
        private System.Windows.Forms.PictureBox languagePict;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.CheckBox themeCheckBox;
    }
}