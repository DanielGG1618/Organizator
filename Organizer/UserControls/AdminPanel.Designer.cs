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

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.reference = new System.Windows.Forms.Button();
            this.addTranslationKeyGridView = new System.Windows.Forms.DataGridView();
            this.KeyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Russian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KtoAmYa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.English = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.updateDictionary = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.addTranslationKeyGridView)).BeginInit();
            this.SuspendLayout();
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.addTranslationKeyGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.addTranslationKeyGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addTranslationKeyGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KeyColumn,
            this.Russian,
            this.KtoAmYa,
            this.English,
            this.AddButton});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.addTranslationKeyGridView.DefaultCellStyle = dataGridViewCellStyle14;
            this.addTranslationKeyGridView.EnableHeadersVisualStyles = false;
            this.addTranslationKeyGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.addTranslationKeyGridView.Location = new System.Drawing.Point(0, 212);
            this.addTranslationKeyGridView.Name = "addTranslationKeyGridView";
            this.addTranslationKeyGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.addTranslationKeyGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.addTranslationKeyGridView.RowHeadersWidth = 50;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.addTranslationKeyGridView.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.addTranslationKeyGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addTranslationKeyGridView.Size = new System.Drawing.Size(750, 188);
            this.addTranslationKeyGridView.TabIndex = 18;
            this.addTranslationKeyGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AddTranslationKeyGridView_CellClick);
            // 
            // KeyColumn
            // 
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.KeyColumn.HeaderText = "Key";
            this.KeyColumn.MaxInputLength = 100;
            this.KeyColumn.MinimumWidth = 6;
            this.KeyColumn.Name = "KeyColumn";
            this.KeyColumn.Width = 160;
            // 
            // Russian
            // 
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Russian.DefaultCellStyle = dataGridViewCellStyle11;
            this.Russian.HeaderText = "Русский";
            this.Russian.MaxInputLength = 100;
            this.Russian.MinimumWidth = 6;
            this.Russian.Name = "Russian";
            this.Russian.Width = 160;
            // 
            // KtoAmYa
            // 
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KtoAmYa.DefaultCellStyle = dataGridViewCellStyle12;
            this.KtoAmYa.HeaderText = "Кто am я";
            this.KtoAmYa.MaxInputLength = 100;
            this.KtoAmYa.MinimumWidth = 6;
            this.KtoAmYa.Name = "KtoAmYa";
            this.KtoAmYa.Width = 160;
            // 
            // English
            // 
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.English.DefaultCellStyle = dataGridViewCellStyle13;
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
            // updateDictionary
            // 
            this.updateDictionary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.updateDictionary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateDictionary.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.updateDictionary.Location = new System.Drawing.Point(369, 142);
            this.updateDictionary.Name = "updateDictionary";
            this.updateDictionary.Size = new System.Drawing.Size(378, 64);
            this.updateDictionary.TabIndex = 17;
            this.updateDictionary.Text = "Обновить словарь";
            this.updateDictionary.UseVisualStyleBackColor = false;
            this.updateDictionary.Click += new System.EventHandler(this.UpdateDictionary_Click);
            // 
            // AdminPanel
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.addTranslationKeyGridView);
            this.Controls.Add(this.updateDictionary);
            this.Controls.Add(this.reference);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "AdminPanel";
            this.Size = new System.Drawing.Size(750, 400);
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.addTranslationKeyGridView)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button reference;
        private System.Windows.Forms.DataGridView addTranslationKeyGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Russian;
        private System.Windows.Forms.DataGridViewTextBoxColumn KtoAmYa;
        private System.Windows.Forms.DataGridViewTextBoxColumn English;
        private System.Windows.Forms.DataGridViewButtonColumn AddButton;
        private System.Windows.Forms.Button updateDictionary;
    }
}
