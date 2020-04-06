namespace Organizer
{
partial class WorkAddForm
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
            this.TypeSelector = new System.Windows.Forms.ComboBox();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.Done = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.AddTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.TypeSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((int)(32)))), ((int)(((int)(32)))), ((int)(((int)(32)))));
            this.TypeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TypeSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((int)(204)));
            this.TypeSelector.ForeColor = System.Drawing.Color.White;
            this.TypeSelector.FormattingEnabled = true;
            this.TypeSelector.IntegralHeight = false;
            this.TypeSelector.Items.AddRange(new object[] {
            "Другое",
            "На страницах",
            "Номера",
            "Параграфы",
            "Темы"});
            this.TypeSelector.Location = new System.Drawing.Point(19, 53);
            this.TypeSelector.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.TypeSelector.Name = "comboBox1";
            this.TypeSelector.Size = new System.Drawing.Size(444, 33);
            this.TypeSelector.TabIndex = 3;
            // 
            // ResultLabel
            // 
            this.ResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((int)(204)));
            this.ResultLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ResultLabel.Location = new System.Drawing.Point(19, 14);
            this.ResultLabel.Margin = new System.Windows.Forms.Padding(10);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(444, 29);
            this.ResultLabel.TabIndex = 4;
            this.ResultLabel.Text = "Не задано";
            this.ResultLabel.Click += new System.EventHandler(this.ResultLabel_Click);
            // 
            // Done
            // 
            this.Done.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Done.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Done.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Done.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((int)(204)));
            this.Done.ForeColor = System.Drawing.Color.OliveDrab;
            this.Done.Location = new System.Drawing.Point(244, 149);
            this.Done.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(219, 33);
            this.Done.TabIndex = 5;
            this.Done.Text = "готово";
            this.Done.UseVisualStyleBackColor = true;
            this.Done.Click += new System.EventHandler(this.DoneClick);
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((int)(204)));
            this.Cancel.ForeColor = System.Drawing.Color.OliveDrab;
            this.Cancel.Location = new System.Drawing.Point(19, 149);
            this.Cancel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(219, 33);
            this.Cancel.TabIndex = 5;
            this.Cancel.Text = "отмена";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.CancelClick);
            // 
            // AddTextBox
            // 
            this.AddTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((int)(48)))), ((int)(((int)(48)))), ((int)(((int)(48)))));
            this.AddTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AddTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((int)(204)));
            this.AddTextBox.ForeColor = System.Drawing.Color.White;
            this.AddTextBox.Location = new System.Drawing.Point(115, 105);
            this.AddTextBox.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.AddTextBox.Name = "AddTextBox";
            this.AddTextBox.Size = new System.Drawing.Size(255, 23);
            this.AddTextBox.TabIndex = 6;
            // 
            // AddButton
            // 
            this.AddButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold);
            this.AddButton.ForeColor = System.Drawing.Color.OliveDrab;
            this.AddButton.Location = new System.Drawing.Point(426, 99);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(37, 37);
            this.AddButton.TabIndex = 7;
            this.AddButton.Text = "+";
            this.AddButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Default;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.OliveDrab;
            this.button2.Location = new System.Drawing.Point(65, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 37);
            this.button2.TabIndex = 9;
            this.button2.Text = "<";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.OliveDrab;
            this.button1.Location = new System.Drawing.Point(383, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 37);
            this.button1.TabIndex = 9;
            this.button1.Text = ">";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Default;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.OliveDrab;
            this.button3.Location = new System.Drawing.Point(19, 99);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(37, 37);
            this.button3.TabIndex = 9;
            this.button3.Text = "-";
            this.button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // WorkAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((int)(32)))), ((int)(((int)(32)))), ((int)(((int)(32)))));
            this.ClientSize = new System.Drawing.Size(482, 208);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.AddTextBox);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.TypeSelector);
            this.MaximumSize = new System.Drawing.Size(500, 250);
            this.MinimumSize = new System.Drawing.Size(500, 250);
            this.Name = "WorkAddForm";
            this.Text = "    ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TypeSelector;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.Button Done;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.TextBox AddTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}