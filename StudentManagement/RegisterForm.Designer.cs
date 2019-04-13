namespace StudentManagement
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.accountTextBox = new System.Windows.Forms.TextBox();
            this.PassWordtextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.Account = new System.Windows.Forms.Label();
            this.LoginTitle = new System.Windows.Forms.Panel();
            this.Repeatlabel = new System.Windows.Forms.Label();
            this.RepeatTextBox = new System.Windows.Forms.TextBox();
            this.Registerbutton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.RoleComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // accountTextBox
            // 
            this.accountTextBox.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.accountTextBox.Location = new System.Drawing.Point(192, 112);
            this.accountTextBox.Name = "accountTextBox";
            this.accountTextBox.Size = new System.Drawing.Size(263, 36);
            this.accountTextBox.TabIndex = 1;
            // 
            // PassWordtextBox
            // 
            this.PassWordtextBox.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PassWordtextBox.Location = new System.Drawing.Point(192, 162);
            this.PassWordtextBox.Name = "PassWordtextBox";
            this.PassWordtextBox.Size = new System.Drawing.Size(263, 36);
            this.PassWordtextBox.TabIndex = 2;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PasswordLabel.Location = new System.Drawing.Point(110, 166);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(93, 25);
            this.PasswordLabel.TabIndex = 13;
            this.PasswordLabel.Text = "密码：";
            // 
            // Account
            // 
            this.Account.AutoSize = true;
            this.Account.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Account.Location = new System.Drawing.Point(110, 115);
            this.Account.Name = "Account";
            this.Account.Size = new System.Drawing.Size(93, 25);
            this.Account.TabIndex = 12;
            this.Account.Text = "昵称：";
            // 
            // LoginTitle
            // 
            this.LoginTitle.BackgroundImage = global::StudentManagement.Properties.Resources.LoginTitle;
            this.LoginTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoginTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.LoginTitle.Location = new System.Drawing.Point(0, 0);
            this.LoginTitle.Name = "LoginTitle";
            this.LoginTitle.Size = new System.Drawing.Size(562, 76);
            this.LoginTitle.TabIndex = 10;
            // 
            // Repeatlabel
            // 
            this.Repeatlabel.AutoSize = true;
            this.Repeatlabel.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.Repeatlabel.Location = new System.Drawing.Point(56, 215);
            this.Repeatlabel.Name = "Repeatlabel";
            this.Repeatlabel.Size = new System.Drawing.Size(147, 25);
            this.Repeatlabel.TabIndex = 13;
            this.Repeatlabel.Text = "重复密码：";
            // 
            // RepeatTextBox
            // 
            this.RepeatTextBox.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RepeatTextBox.Location = new System.Drawing.Point(192, 212);
            this.RepeatTextBox.Name = "RepeatTextBox";
            this.RepeatTextBox.Size = new System.Drawing.Size(263, 36);
            this.RepeatTextBox.TabIndex = 3;
            this.RepeatTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RepeatTextBox_KeyDown);
            // 
            // Registerbutton
            // 
            this.Registerbutton.Font = new System.Drawing.Font("华文楷体", 17F, System.Drawing.FontStyle.Bold);
            this.Registerbutton.Location = new System.Drawing.Point(192, 267);
            this.Registerbutton.Name = "Registerbutton";
            this.Registerbutton.Size = new System.Drawing.Size(100, 42);
            this.Registerbutton.TabIndex = 5;
            this.Registerbutton.Text = "注册";
            this.Registerbutton.UseVisualStyleBackColor = true;
            this.Registerbutton.Click += new System.EventHandler(this.Registerbutton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("华文楷体", 17F, System.Drawing.FontStyle.Bold);
            this.cancelButton.Location = new System.Drawing.Point(355, 267);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 42);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // RoleComboBox
            // 
            this.RoleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RoleComboBox.Font = new System.Drawing.Font("华文楷体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RoleComboBox.Items.AddRange(new object[] {
            "学生",
            "教师"});
            this.RoleComboBox.Location = new System.Drawing.Point(81, 267);
            this.RoleComboBox.Name = "RoleComboBox";
            this.RoleComboBox.Size = new System.Drawing.Size(88, 28);
            this.RoleComboBox.TabIndex = 4;
            this.RoleComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegisterForm_KeyDown);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(562, 353);
            this.ControlBox = false;
            this.Controls.Add(this.RoleComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.Registerbutton);
            this.Controls.Add(this.accountTextBox);
            this.Controls.Add(this.RepeatTextBox);
            this.Controls.Add(this.PassWordtextBox);
            this.Controls.Add(this.Repeatlabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.Account);
            this.Controls.Add(this.LoginTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegisterForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox accountTextBox;
        private System.Windows.Forms.TextBox PassWordtextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label Account;
        private System.Windows.Forms.Panel LoginTitle;
        private System.Windows.Forms.Label Repeatlabel;
        private System.Windows.Forms.TextBox RepeatTextBox;
        private System.Windows.Forms.Button Registerbutton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox RoleComboBox;
    }
}