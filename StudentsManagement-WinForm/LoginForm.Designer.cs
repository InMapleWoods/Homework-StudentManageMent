namespace StudentsManagement_winForm
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.Account = new System.Windows.Forms.Label();
            this.PassWordtextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.accountComboBox = new System.Windows.Forms.ComboBox();
            this.RegisterLinkLabel = new System.Windows.Forms.LinkLabel();
            this.LoginTitle = new System.Windows.Forms.Panel();
            this.ValidateTextBox = new System.Windows.Forms.TextBox();
            this.ValidateLabel = new System.Windows.Forms.Label();
            this.ValidatePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Account
            // 
            this.Account.AutoSize = true;
            this.Account.Font = new System.Drawing.Font("楷体", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Account.Location = new System.Drawing.Point(87, 120);
            this.Account.Name = "Account";
            this.Account.Size = new System.Drawing.Size(117, 34);
            this.Account.TabIndex = 1;
            this.Account.Text = "账号：";
            // 
            // PassWordtextBox
            // 
            this.PassWordtextBox.Font = new System.Drawing.Font("宋体", 15F);
            this.PassWordtextBox.Location = new System.Drawing.Point(190, 170);
            this.PassWordtextBox.Name = "PassWordtextBox";
            this.PassWordtextBox.PasswordChar = '☆';
            this.PassWordtextBox.Size = new System.Drawing.Size(263, 36);
            this.PassWordtextBox.TabIndex = 2;
            this.PassWordtextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("楷体", 20F);
            this.PasswordLabel.Location = new System.Drawing.Point(87, 170);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(119, 39);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "密码：";
            // 
            // LoginButton
            // 
            this.LoginButton.Font = new System.Drawing.Font("楷体", 17F, System.Drawing.FontStyle.Bold);
            this.LoginButton.Location = new System.Drawing.Point(204, 220);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(100, 42);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "登录";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("楷体", 17F, System.Drawing.FontStyle.Bold);
            this.cancelButton.Location = new System.Drawing.Point(342, 220);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 42);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // accountComboBox
            // 
            this.accountComboBox.Font = new System.Drawing.Font("宋体", 15F);
            this.accountComboBox.FormattingEnabled = true;
            this.accountComboBox.Location = new System.Drawing.Point(190, 120);
            this.accountComboBox.Name = "accountComboBox";
            this.accountComboBox.Size = new System.Drawing.Size(263, 33);
            this.accountComboBox.TabIndex = 1;
            this.accountComboBox.DropDown += new System.EventHandler(this.accountComboBox_DropDown);
            // 
            // RegisterLinkLabel
            // 
            this.RegisterLinkLabel.AutoSize = true;
            this.RegisterLinkLabel.Location = new System.Drawing.Point(457, 130);
            this.RegisterLinkLabel.Name = "RegisterLinkLabel";
            this.RegisterLinkLabel.Size = new System.Drawing.Size(67, 15);
            this.RegisterLinkLabel.TabIndex = 9;
            this.RegisterLinkLabel.TabStop = true;
            this.RegisterLinkLabel.Text = "注册账号";
            this.RegisterLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RegisterLinkLabel_LinkClicked);
            // 
            // LoginTitle
            // 
            this.LoginTitle.BackgroundImage = global::StudentsManagement_winForm.Properties.Resources.LoginTitle;
            this.LoginTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoginTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.LoginTitle.Location = new System.Drawing.Point(0, 0);
            this.LoginTitle.Name = "LoginTitle";
            this.LoginTitle.Size = new System.Drawing.Size(562, 76);
            this.LoginTitle.TabIndex = 0;
            // 
            // ValidateTextBox
            // 
            this.ValidateTextBox.Font = new System.Drawing.Font("宋体", 12F);
            this.ValidateTextBox.Location = new System.Drawing.Point(190, 220);
            this.ValidateTextBox.Name = "ValidateTextBox";
            this.ValidateTextBox.Size = new System.Drawing.Size(114, 30);
            this.ValidateTextBox.TabIndex = 3;
            this.ValidateTextBox.Visible = false;
            this.ValidateTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            // 
            // ValidateLabel
            // 
            this.ValidateLabel.AutoSize = true;
            this.ValidateLabel.Font = new System.Drawing.Font("楷体", 20F);
            this.ValidateLabel.Location = new System.Drawing.Point(53, 220);
            this.ValidateLabel.Name = "ValidateLabel";
            this.ValidateLabel.Size = new System.Drawing.Size(153, 39);
            this.ValidateLabel.TabIndex = 10;
            this.ValidateLabel.Text = "验证码：";
            this.ValidateLabel.Visible = false;
            // 
            // ValidatePanel
            // 
            this.ValidatePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ValidatePanel.Location = new System.Drawing.Point(342, 220);
            this.ValidatePanel.Name = "ValidatePanel";
            this.ValidatePanel.Size = new System.Drawing.Size(100, 40);
            this.ValidatePanel.TabIndex = 12;
            this.ValidatePanel.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(562, 363);
            this.ControlBox = false;
            this.Controls.Add(this.ValidatePanel);
            this.Controls.Add(this.ValidateTextBox);
            this.Controls.Add(this.ValidateLabel);
            this.Controls.Add(this.RegisterLinkLabel);
            this.Controls.Add(this.accountComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PassWordtextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.Account);
            this.Controls.Add(this.LoginTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel LoginTitle;
        private System.Windows.Forms.Label Account;
        private System.Windows.Forms.TextBox PassWordtextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox accountComboBox;
        private System.Windows.Forms.LinkLabel RegisterLinkLabel;
        private System.Windows.Forms.TextBox ValidateTextBox;
        private System.Windows.Forms.Label ValidateLabel;
        private System.Windows.Forms.Panel ValidatePanel;
    }
}