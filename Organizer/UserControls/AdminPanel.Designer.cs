namespace Organizer
{
    partial class AdminPanel : UserControlGG
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

        private System.Windows.Forms.Label holyLabel;
        private System.Windows.Forms.Panel addHolydayPanel;
        private System.Windows.Forms.Panel pickersPanel;
        private System.Windows.Forms.DateTimePicker holydayStartPicker;
        private System.Windows.Forms.DateTimePicker holydayFinishPicker;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.ComboBox holydayTypeComboBox;
        private System.Windows.Forms.Button addHolyday;
        private System.Windows.Forms.Label toLabel;

        private void InitializeComponent()
        {
            this.holyLabel = new System.Windows.Forms.Label();
            this.addHolydayPanel = new System.Windows.Forms.Panel();
            this.pickersPanel = new System.Windows.Forms.Panel();
            this.holydayStartPicker = new System.Windows.Forms.DateTimePicker();
            this.holydayFinishPicker = new System.Windows.Forms.DateTimePicker();
            this.fromLabel = new System.Windows.Forms.Label();
            this.holydayTypeComboBox = new System.Windows.Forms.ComboBox();
            this.addHolyday = new System.Windows.Forms.Button();
            this.toLabel = new System.Windows.Forms.Label();
            this.reference = new System.Windows.Forms.Button();
            this.addHolydayPanel.SuspendLayout();
            this.pickersPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // holyLabel
            // 
            this.holyLabel.AccessibleName = "Add holydays";
            this.holyLabel.AutoSize = true;
            this.holyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.holyLabel.Location = new System.Drawing.Point(3, 0);
            this.holyLabel.Name = "holyLabel";
            this.holyLabel.Size = new System.Drawing.Size(268, 31);
            this.holyLabel.TabIndex = 16;
            this.holyLabel.Text = "Добавить выходные";
            // 
            // addHolydayPanel
            // 
            this.addHolydayPanel.Controls.Add(this.pickersPanel);
            this.addHolydayPanel.Controls.Add(this.fromLabel);
            this.addHolydayPanel.Controls.Add(this.holydayTypeComboBox);
            this.addHolydayPanel.Controls.Add(this.addHolyday);
            this.addHolydayPanel.Controls.Add(this.toLabel);
            this.addHolydayPanel.Location = new System.Drawing.Point(6, 38);
            this.addHolydayPanel.Name = "addHolydayPanel";
            this.addHolydayPanel.Size = new System.Drawing.Size(358, 91);
            this.addHolydayPanel.TabIndex = 15;
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
            // reference
            // 
            this.reference.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.reference.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reference.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.reference.Location = new System.Drawing.Point(9, 142);
            this.reference.Name = "reference";
            this.reference.Size = new System.Drawing.Size(354, 64);
            this.reference.TabIndex = 17;
            this.reference.Text = "Справка";
            this.reference.UseVisualStyleBackColor = false;
            this.reference.Click += new System.EventHandler(this.Reference_Click);
            // 
            // AdminPanel
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.reference);
            this.Controls.Add(this.holyLabel);
            this.Controls.Add(this.addHolydayPanel);
            this.Name = "AdminPanel";
            this.Size = new System.Drawing.Size(371, 220);
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            this.addHolydayPanel.ResumeLayout(false);
            this.pickersPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button reference;
    }
}
