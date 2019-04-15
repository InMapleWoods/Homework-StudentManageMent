namespace StudentManagement
{
    partial class ChangeNameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeNameForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.NewNametextBox = new System.Windows.Forms.TextBox();
            this.NewNameLabel = new System.Windows.Forms.Label();
            this.OldNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("华文楷体", 17F, System.Drawing.FontStyle.Bold);
            this.cancelButton.Location = new System.Drawing.Point(319, 162);
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
            this.OKButton.Location = new System.Drawing.Point(181, 162);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(100, 42);
            this.OKButton.TabIndex = 6;
            this.OKButton.Text = "确定";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // NewNametextBox
            // 
            this.NewNametextBox.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NewNametextBox.Location = new System.Drawing.Point(169, 99);
            this.NewNametextBox.Name = "NewNametextBox";
            this.NewNametextBox.Size = new System.Drawing.Size(263, 36);
            this.NewNametextBox.TabIndex = 15;
            // 
            // NewNameLabel
            // 
            this.NewNameLabel.AutoSize = true;
            this.NewNameLabel.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.NewNameLabel.Location = new System.Drawing.Point(60, 102);
            this.NewNameLabel.Name = "NewNameLabel";
            this.NewNameLabel.Size = new System.Drawing.Size(120, 25);
            this.NewNameLabel.TabIndex = 16;
            this.NewNameLabel.Text = "新昵称：";
            // 
            // OldNameLabel
            // 
            this.OldNameLabel.AutoSize = true;
            this.OldNameLabel.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.OldNameLabel.Location = new System.Drawing.Point(60, 53);
            this.OldNameLabel.Name = "OldNameLabel";
            this.OldNameLabel.Size = new System.Drawing.Size(0, 25);
            this.OldNameLabel.TabIndex = 17;
            // 
            // ChangeNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 300);
            this.Controls.Add(this.OldNameLabel);
            this.Controls.Add(this.NewNametextBox);
            this.Controls.Add(this.NewNameLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangeNameForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChangeNameForm_FormClosing);
            this.Load += new System.EventHandler(this.ChangeNameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TextBox NewNametextBox;
        private System.Windows.Forms.Label NewNameLabel;
        private System.Windows.Forms.Label OldNameLabel;
    }
}