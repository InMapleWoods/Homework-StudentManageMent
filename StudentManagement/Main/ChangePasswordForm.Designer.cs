namespace StudentManagement
{
    partial class ChangePasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.NewPassWordtextBox = new System.Windows.Forms.TextBox();
            this.OldPassWordtextBox = new System.Windows.Forms.TextBox();
            this.NewPasswordLabel = new System.Windows.Forms.Label();
            this.OldPasswordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("华文楷体", 17F, System.Drawing.FontStyle.Bold);
            this.cancelButton.Location = new System.Drawing.Point(318, 208);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 42);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("华文楷体", 17F, System.Drawing.FontStyle.Bold);
            this.OKButton.Location = new System.Drawing.Point(180, 208);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(100, 42);
            this.OKButton.TabIndex = 6;
            this.OKButton.Text = "确定";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // NewPassWordtextBox
            // 
            this.NewPassWordtextBox.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NewPassWordtextBox.Location = new System.Drawing.Point(168, 145);
            this.NewPassWordtextBox.Name = "NewPassWordtextBox";
            this.NewPassWordtextBox.Size = new System.Drawing.Size(263, 36);
            this.NewPassWordtextBox.TabIndex = 15;
            // 
            // OldPassWordtextBox
            // 
            this.OldPassWordtextBox.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OldPassWordtextBox.Location = new System.Drawing.Point(168, 70);
            this.OldPassWordtextBox.Name = "OldPassWordtextBox";
            this.OldPassWordtextBox.Size = new System.Drawing.Size(263, 36);
            this.OldPassWordtextBox.TabIndex = 14;
            // 
            // NewPasswordLabel
            // 
            this.NewPasswordLabel.AutoSize = true;
            this.NewPasswordLabel.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.NewPasswordLabel.Location = new System.Drawing.Point(59, 148);
            this.NewPasswordLabel.Name = "NewPasswordLabel";
            this.NewPasswordLabel.Size = new System.Drawing.Size(120, 25);
            this.NewPasswordLabel.TabIndex = 16;
            this.NewPasswordLabel.Text = "新密码：";
            // 
            // OldPasswordLabel
            // 
            this.OldPasswordLabel.AutoSize = true;
            this.OldPasswordLabel.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OldPasswordLabel.Location = new System.Drawing.Point(59, 73);
            this.OldPasswordLabel.Name = "OldPasswordLabel";
            this.OldPasswordLabel.Size = new System.Drawing.Size(120, 25);
            this.OldPasswordLabel.TabIndex = 17;
            this.OldPasswordLabel.Text = "旧密码：";
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 300);
            this.Controls.Add(this.NewPassWordtextBox);
            this.Controls.Add(this.OldPassWordtextBox);
            this.Controls.Add(this.NewPasswordLabel);
            this.Controls.Add(this.OldPasswordLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangePasswordForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChangePasswordForm_FormClosing);
            this.Load += new System.EventHandler(this.ChangePasswordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TextBox NewPassWordtextBox;
        private System.Windows.Forms.TextBox OldPassWordtextBox;
        private System.Windows.Forms.Label NewPasswordLabel;
        private System.Windows.Forms.Label OldPasswordLabel;
    }
}