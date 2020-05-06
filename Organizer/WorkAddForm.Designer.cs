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
            this.typeSelector = new System.Windows.Forms.ComboBox();
            this.done = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.addTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // typeSelector
            // 
            this.typeSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.typeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.typeSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typeSelector.ForeColor = System.Drawing.Color.White;
            this.typeSelector.FormattingEnabled = true;
            this.typeSelector.IntegralHeight = false;
            this.typeSelector.Items.AddRange(new object[] {
            "Другое",
            "На страницах",
            "Номера",
            "Параграфы"});
            this.typeSelector.Location = new System.Drawing.Point(19, 53);
            this.typeSelector.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.typeSelector.Name = "typeSelector";
            this.typeSelector.Size = new System.Drawing.Size(444, 33);
            this.typeSelector.TabIndex = 3;
            // 
            // done
            // 
            this.done.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.done.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.done.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.done.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.done.Location = new System.Drawing.Point(244, 149);
            this.done.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.done.Name = "done";
            this.done.Size = new System.Drawing.Size(219, 33);
            this.done.TabIndex = 5;
            this.done.Text = "готово";
            this.done.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel.Location = new System.Drawing.Point(19, 149);
            this.cancel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(219, 33);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "отмена";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // addTextBox
            // 
            this.addTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.addTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.addTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addTextBox.ForeColor = System.Drawing.Color.White;
            this.addTextBox.Location = new System.Drawing.Point(115, 105);
            this.addTextBox.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.addTextBox.Name = "addTextBox";
            this.addTextBox.Size = new System.Drawing.Size(255, 23);
            this.addTextBox.TabIndex = 6;
            // 
            // addButton
            // 
            this.addButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold);
            this.addButton.Location = new System.Drawing.Point(426, 99);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(37, 37);
            this.addButton.TabIndex = 7;
            this.addButton.Text = "+";
            this.addButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.leftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leftButton.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold);
            this.leftButton.Location = new System.Drawing.Point(65, 99);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(37, 37);
            this.leftButton.TabIndex = 9;
            this.leftButton.Text = "<";
            this.leftButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.leftButton.UseVisualStyleBackColor = true;
            // 
            // rightButton
            // 
            this.rightButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.rightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rightButton.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold);
            this.rightButton.Location = new System.Drawing.Point(383, 99);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(37, 37);
            this.rightButton.TabIndex = 9;
            this.rightButton.Text = ">";
            this.rightButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rightButton.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeButton.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold);
            this.removeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.removeButton.Location = new System.Drawing.Point(19, 99);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(37, 37);
            this.removeButton.TabIndex = 9;
            this.removeButton.Text = "-";
            this.removeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // WorkAddForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(482, 208);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.addTextBox);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.done);
            this.Controls.Add(this.typeSelector);
            this.ForeColor = System.Drawing.Color.OliveDrab;
            this.MaximumSize = new System.Drawing.Size(500, 250);
            this.MinimumSize = new System.Drawing.Size(500, 250);
            this.Name = "WorkAddForm";
            this.Text = "    ";
            this.Load += new System.EventHandler(this.WorkAddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox typeSelector;
        private System.Windows.Forms.Button done;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.TextBox addTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button removeButton;
    }
}