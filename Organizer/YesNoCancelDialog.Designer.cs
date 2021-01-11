namespace Organizer
{
    partial class YesNoCancelDialog
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
            this.yes = new System.Windows.Forms.Button();
            this.no = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.saveChanges = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // yes
            // 
            this.yes.AccessibleName = "Yes";
            this.yes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.yes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yes.Location = new System.Drawing.Point(12, 90);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(100, 36);
            this.yes.TabIndex = 0;
            this.yes.Text = "Да";
            this.yes.UseVisualStyleBackColor = true;
            // 
            // no
            // 
            this.no.AccessibleName = "No";
            this.no.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.no.DialogResult = System.Windows.Forms.DialogResult.No;
            this.no.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.no.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.no.Location = new System.Drawing.Point(118, 91);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(100, 36);
            this.no.TabIndex = 0;
            this.no.Text = "Нет";
            this.no.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.AccessibleName = "Cancel";
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel.Location = new System.Drawing.Point(224, 91);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(100, 36);
            this.cancel.TabIndex = 0;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // saveChanges
            // 
            this.saveChanges.AccessibleName = "Save changes";
            this.saveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveChanges.Location = new System.Drawing.Point(7, 7);
            this.saveChanges.Name = "saveChanges";
            this.saveChanges.Size = new System.Drawing.Size(317, 78);
            this.saveChanges.TabIndex = 1;
            this.saveChanges.Text = "Сохранить изменения?";
            this.saveChanges.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // YesNoCancelDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(336, 139);
            this.Controls.Add(this.saveChanges);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.no);
            this.Controls.Add(this.yes);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "YesNoCancelDialog";
            this.Load += new System.EventHandler(this.YesNoCancelDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button yes;
        private System.Windows.Forms.Button no;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label saveChanges;
    }
}