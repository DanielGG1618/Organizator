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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkAddForm));
            this.typeSelector = new System.Windows.Forms.ComboBox();
            this.done = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.addTextBox = new System.Windows.Forms.TextBox();
            this.removeAddButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.resultPanel = new System.Windows.Forms.Panel();
            this.attachmentsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // typeSelector
            // 
            this.typeSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            "Параграфы",
            "Прикрепить файл"});
            this.typeSelector.Location = new System.Drawing.Point(19, 73);
            this.typeSelector.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.typeSelector.Name = "typeSelector";
            this.typeSelector.Size = new System.Drawing.Size(444, 33);
            this.typeSelector.TabIndex = 3;
            this.typeSelector.SelectedIndexChanged += new System.EventHandler(this.TypeSelector_SelectedIndexChanged);
            // 
            // done
            // 
            this.done.AccessibleName = "Done";
            this.done.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.done.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.done.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.done.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.done.Location = new System.Drawing.Point(244, 169);
            this.done.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.done.Name = "done";
            this.done.Size = new System.Drawing.Size(219, 33);
            this.done.TabIndex = 5;
            this.done.Text = "Готово";
            this.done.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.AccessibleName = "Cancel";
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel.Location = new System.Drawing.Point(19, 169);
            this.cancel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(219, 33);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // addTextBox
            // 
            this.addTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.addTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.addTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addTextBox.ForeColor = System.Drawing.Color.White;
            this.addTextBox.Location = new System.Drawing.Point(19, 128);
            this.addTextBox.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.addTextBox.Name = "addTextBox";
            this.addTextBox.Size = new System.Drawing.Size(394, 23);
            this.addTextBox.TabIndex = 6;
            this.addTextBox.TextChanged += new System.EventHandler(this.AddTextBox_TextChanged);
            // 
            // removeAddButton
            // 
            this.removeAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.removeAddButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.removeAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeAddButton.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold);
            this.removeAddButton.Location = new System.Drawing.Point(426, 119);
            this.removeAddButton.Name = "removeAddButton";
            this.removeAddButton.Size = new System.Drawing.Size(37, 37);
            this.removeAddButton.TabIndex = 7;
            this.removeAddButton.Text = "+";
            this.removeAddButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.removeAddButton.UseVisualStyleBackColor = true;
            this.removeAddButton.Click += new System.EventHandler(this.RemoveAddButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.leftButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.leftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leftButton.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold);
            this.leftButton.Location = new System.Drawing.Point(19, 119);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(37, 37);
            this.leftButton.TabIndex = 9;
            this.leftButton.Text = "<";
            this.leftButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Visible = false;
            this.leftButton.Click += new System.EventHandler(this.LeftButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rightButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.rightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rightButton.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold);
            this.rightButton.Location = new System.Drawing.Point(62, 119);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(37, 37);
            this.rightButton.TabIndex = 9;
            this.rightButton.Text = ">";
            this.rightButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Visible = false;
            this.rightButton.Click += new System.EventHandler(this.RightButton_Click);
            // 
            // resultPanel
            // 
            this.resultPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultPanel.AutoScroll = true;
            this.resultPanel.Location = new System.Drawing.Point(19, 21);
            this.resultPanel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Size = new System.Drawing.Size(444, 50);
            this.resultPanel.TabIndex = 10;
            // 
            // attachmentsLabel
            // 
            this.attachmentsLabel.AccessibleName = "Attachments";
            this.attachmentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.attachmentsLabel.Location = new System.Drawing.Point(19, 169);
            this.attachmentsLabel.Name = "attachmentsLabel";
            this.attachmentsLabel.Size = new System.Drawing.Size(444, 33);
            this.attachmentsLabel.TabIndex = 11;
            this.attachmentsLabel.Text = "Attachments";
            this.attachmentsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.attachmentsLabel.Visible = false;
            // 
            // WorkAddForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(482, 228);
            this.Controls.Add(this.resultPanel);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.removeAddButton);
            this.Controls.Add(this.addTextBox);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.done);
            this.Controls.Add(this.typeSelector);
            this.Controls.Add(this.attachmentsLabel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimumSize = new System.Drawing.Size(500, 270);
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
        private System.Windows.Forms.Button removeAddButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Panel resultPanel;
        private System.Windows.Forms.Label attachmentsLabel;
    }
}