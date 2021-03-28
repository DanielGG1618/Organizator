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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.addTranslationKeyGridView = new System.Windows.Forms.DataGridView();
            this.KeyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Russian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KtoAmYa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.English = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.addHolydayPanel.SuspendLayout();
            this.pickersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addTranslationKeyGridView)).BeginInit();
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
            // addTranslationKeyGridView
            // 
            this.addTranslationKeyGridView.AllowUserToOrderColumns = true;
            this.addTranslationKeyGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.addTranslationKeyGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.addTranslationKeyGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.addTranslationKeyGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addTranslationKeyGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KeyColumn,
            this.Russian,
            this.KtoAmYa,
            this.English,
            this.AddButton});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.addTranslationKeyGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.addTranslationKeyGridView.EnableHeadersVisualStyles = false;
            this.addTranslationKeyGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.addTranslationKeyGridView.Location = new System.Drawing.Point(0, 212);
            this.addTranslationKeyGridView.Name = "addTranslationKeyGridView";
            this.addTranslationKeyGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.addTranslationKeyGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.addTranslationKeyGridView.RowHeadersWidth = 50;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.addTranslationKeyGridView.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.addTranslationKeyGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addTranslationKeyGridView.Size = new System.Drawing.Size(750, 188);
            this.addTranslationKeyGridView.TabIndex = 18;
            this.addTranslationKeyGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AddTranslationKeyGridView_CellClick);
            // 
            // KeyColumn
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.KeyColumn.HeaderText = "Key";
            this.KeyColumn.MaxInputLength = 100;
            this.KeyColumn.MinimumWidth = 6;
            this.KeyColumn.Name = "KeyColumn";
            this.KeyColumn.Width = 160;
            // 
            // Russian
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Russian.DefaultCellStyle = dataGridViewCellStyle3;
            this.Russian.HeaderText = "Русский";
            this.Russian.MaxInputLength = 100;
            this.Russian.MinimumWidth = 6;
            this.Russian.Name = "Russian";
            this.Russian.Width = 160;
            // 
            // KtoAmYa
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KtoAmYa.DefaultCellStyle = dataGridViewCellStyle4;
            this.KtoAmYa.HeaderText = "Кто am я";
            this.KtoAmYa.MaxInputLength = 100;
            this.KtoAmYa.MinimumWidth = 6;
            this.KtoAmYa.Name = "KtoAmYa";
            this.KtoAmYa.Width = 160;
            // 
            // English
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.English.DefaultCellStyle = dataGridViewCellStyle5;
            this.English.HeaderText = "English";
            this.English.MaxInputLength = 100;
            this.English.MinimumWidth = 6;
            this.English.Name = "English";
            this.English.Width = 160;
            // 
            // AddButton
            // 
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.HeaderText = "Add";
            this.AddButton.MinimumWidth = 6;
            this.AddButton.Name = "AddButton";
            this.AddButton.Text = "+";
            this.AddButton.ToolTipText = "+";
            this.AddButton.Width = 59;
            // 
            // AdminPanel
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.addTranslationKeyGridView);
            this.Controls.Add(this.reference);
            this.Controls.Add(this.holyLabel);
            this.Controls.Add(this.addHolydayPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "AdminPanel";
            this.Size = new System.Drawing.Size(750, 400);
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            this.addHolydayPanel.ResumeLayout(false);
            this.pickersPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.addTranslationKeyGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button reference;
        private System.Windows.Forms.DataGridView addTranslationKeyGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Russian;
        private System.Windows.Forms.DataGridViewTextBoxColumn KtoAmYa;
        private System.Windows.Forms.DataGridViewTextBoxColumn English;
        private System.Windows.Forms.DataGridViewButtonColumn AddButton;
    }
}
