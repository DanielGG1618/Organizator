namespace Organizer
{
    partial class ModerPanel
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
            this.holiLabel = new System.Windows.Forms.Label();
            this.addHolidayPanel = new System.Windows.Forms.Panel();
            this.pickersPanel = new System.Windows.Forms.Panel();
            this.holidayFromPicker = new System.Windows.Forms.DateTimePicker();
            this.holidayToPicker = new System.Windows.Forms.DateTimePicker();
            this.fromLabel = new System.Windows.Forms.Label();
            this.addHoliday = new System.Windows.Forms.Button();
            this.toLabel = new System.Windows.Forms.Label();
            this.addHolidayPanel.SuspendLayout();
            this.pickersPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // holiLabel
            // 
            this.holiLabel.AccessibleName = "Add holidays";
            this.holiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.holiLabel.Location = new System.Drawing.Point(3, 0);
            this.holiLabel.Name = "holiLabel";
            this.holiLabel.Size = new System.Drawing.Size(360, 31);
            this.holiLabel.TabIndex = 18;
            this.holiLabel.Text = "Добавить выходные";
            this.holiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addHolidayPanel
            // 
            this.addHolidayPanel.Controls.Add(this.pickersPanel);
            this.addHolidayPanel.Controls.Add(this.fromLabel);
            this.addHolidayPanel.Controls.Add(this.addHoliday);
            this.addHolidayPanel.Controls.Add(this.toLabel);
            this.addHolidayPanel.Location = new System.Drawing.Point(3, 34);
            this.addHolidayPanel.Name = "addHolidayPanel";
            this.addHolidayPanel.Size = new System.Drawing.Size(360, 55);
            this.addHolidayPanel.TabIndex = 17;
            // 
            // pickersPanel
            // 
            this.pickersPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pickersPanel.Controls.Add(this.holidayFromPicker);
            this.pickersPanel.Controls.Add(this.holidayToPicker);
            this.pickersPanel.Location = new System.Drawing.Point(219, 2);
            this.pickersPanel.Name = "pickersPanel";
            this.pickersPanel.Size = new System.Drawing.Size(138, 53);
            this.pickersPanel.TabIndex = 12;
            // 
            // holidayStartPicker
            // 
            this.holidayFromPicker.AllowDrop = true;
            this.holidayFromPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.holidayFromPicker.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.holidayFromPicker.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.holidayFromPicker.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.holidayFromPicker.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.holidayFromPicker.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.holidayFromPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.holidayFromPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.holidayFromPicker.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.holidayFromPicker.Location = new System.Drawing.Point(0, 0);
            this.holidayFromPicker.Name = "holidayStartPicker";
            this.holidayFromPicker.Size = new System.Drawing.Size(138, 28);
            this.holidayFromPicker.TabIndex = 7;
            this.holidayFromPicker.Value = new System.DateTime(2019, 9, 1, 0, 0, 0, 0);
            this.holidayFromPicker.ValueChanged += new System.EventHandler(this.HolidayStartPicker_ValueChanged);
            // 
            // holidayFinishPicker
            // 
            this.holidayToPicker.AllowDrop = true;
            this.holidayToPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.holidayToPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.holidayToPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.holidayToPicker.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.holidayToPicker.Location = new System.Drawing.Point(0, 27);
            this.holidayToPicker.Name = "holidayFinishPicker";
            this.holidayToPicker.Size = new System.Drawing.Size(138, 28);
            this.holidayToPicker.TabIndex = 7;
            this.holidayToPicker.Value = new System.DateTime(2019, 9, 1, 0, 0, 0, 0);
            this.holidayToPicker.ValueChanged += new System.EventHandler(this.HolidayFinishPicker_ValueChanged);
            // 
            // fromLabel
            // 
            this.fromLabel.AccessibleName = "From";
            this.fromLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fromLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fromLabel.ForeColor = System.Drawing.Color.White;
            this.fromLabel.Location = new System.Drawing.Point(149, 2);
            this.fromLabel.Margin = new System.Windows.Forms.Padding(0);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fromLabel.Size = new System.Drawing.Size(72, 25);
            this.fromLabel.TabIndex = 8;
            this.fromLabel.Text = "От";
            this.fromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addHoliday
            // 
            this.addHoliday.AccessibleDescription = "";
            this.addHoliday.AccessibleName = "Add";
            this.addHoliday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addHoliday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.addHoliday.Cursor = System.Windows.Forms.Cursors.Default;
            this.addHoliday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addHoliday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addHoliday.Location = new System.Drawing.Point(0, 0);
            this.addHoliday.Margin = new System.Windows.Forms.Padding(10);
            this.addHoliday.Name = "addHoliday";
            this.addHoliday.Size = new System.Drawing.Size(147, 55);
            this.addHoliday.TabIndex = 4;
            this.addHoliday.Text = "Добавить";
            this.addHoliday.UseVisualStyleBackColor = false;
            this.addHoliday.Click += new System.EventHandler(this.AddHoliday_Click);
            // 
            // toLabel
            // 
            this.toLabel.AccessibleName = "To";
            this.toLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.toLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toLabel.ForeColor = System.Drawing.Color.White;
            this.toLabel.Location = new System.Drawing.Point(149, 30);
            this.toLabel.Margin = new System.Windows.Forms.Padding(0);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(72, 25);
            this.toLabel.TabIndex = 8;
            this.toLabel.Text = "До";
            this.toLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ModerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.holiLabel);
            this.Controls.Add(this.addHolidayPanel);
            this.Name = "ModerPanel";
            this.Size = new System.Drawing.Size(750, 400);
            this.Load += new System.EventHandler(this.ModerPanel_Load);
            this.addHolidayPanel.ResumeLayout(false);
            this.pickersPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label holiLabel;
        private System.Windows.Forms.Panel addHolidayPanel;
        private System.Windows.Forms.Panel pickersPanel;
        private System.Windows.Forms.DateTimePicker holidayFromPicker;
        private System.Windows.Forms.DateTimePicker holidayToPicker;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Button addHoliday;
        private System.Windows.Forms.Label toLabel;
    }
}
