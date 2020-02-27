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
            ((System.ComponentModel.ISupportInitialize)(this.languagePict)).BeginInit();
            this.SuspendLayout();
            // 
            // languageSelector
            // 
            this.languageSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.languageSelector.BackColor = System.Drawing.SystemColors.Window;
            this.languageSelector.Cursor = System.Windows.Forms.Cursors.Default;
            this.languageSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageSelector.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.languageSelector.FormattingEnabled = true;
            this.languageSelector.Items.AddRange(new object[] {
            "Russian",
            "Англиский"});
            this.languageSelector.Location = new System.Drawing.Point(110, 39);
            this.languageSelector.Margin = new System.Windows.Forms.Padding(6, 30, 30, 30);
            this.languageSelector.Name = "languageSelector";
            this.languageSelector.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.languageSelector.Size = new System.Drawing.Size(200, 24);
            this.languageSelector.TabIndex = 0;
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
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(798, 453);
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

        }

        #endregion

        private System.Windows.Forms.ComboBox languageSelector;
        private System.Windows.Forms.PictureBox languagePict;
    }
}