namespace StudentsManagement_winForm
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainFormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.ActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitOrRelogintoolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.ReloginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangePassWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainFormMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormMenuStrip
            // 
            this.MainFormMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionToolStripMenuItem});
            this.MainFormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainFormMenuStrip.Name = "MainFormMenuStrip";
            this.MainFormMenuStrip.Size = new System.Drawing.Size(800, 28);
            this.MainFormMenuStrip.TabIndex = 1;
            this.MainFormMenuStrip.Text = "menuStrip1";
            // 
            // ActionToolStripMenuItem
            // 
            this.ActionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem,
            this.ExitOrRelogintoolStripSeparator,
            this.ReloginToolStripMenuItem,
            this.ChangePassWordToolStripMenuItem,
            this.ChangeNameToolStripMenuItem});
            this.ActionToolStripMenuItem.Name = "ActionToolStripMenuItem";
            this.ActionToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.ActionToolStripMenuItem.Text = "操作(&A)";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.ExitToolStripMenuItem.Text = "退出(&E)";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // ExitOrRelogintoolStripSeparator
            // 
            this.ExitOrRelogintoolStripSeparator.Name = "ExitOrRelogintoolStripSeparator";
            this.ExitOrRelogintoolStripSeparator.Size = new System.Drawing.Size(163, 6);
            // 
            // ReloginToolStripMenuItem
            // 
            this.ReloginToolStripMenuItem.Name = "ReloginToolStripMenuItem";
            this.ReloginToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.ReloginToolStripMenuItem.Text = "重新登录(&R)";
            this.ReloginToolStripMenuItem.Click += new System.EventHandler(this.ReloginToolStripMenuItem_Click);
            // 
            // ChangePassWordToolStripMenuItem
            // 
            this.ChangePassWordToolStripMenuItem.Name = "ChangePassWordToolStripMenuItem";
            this.ChangePassWordToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.ChangePassWordToolStripMenuItem.Text = "修改密码(&P)";
            this.ChangePassWordToolStripMenuItem.Click += new System.EventHandler(this.ChangePassWordToolStripMenuItem_Click);
            // 
            // ChangeNameToolStripMenuItem
            // 
            this.ChangeNameToolStripMenuItem.Name = "ChangeNameToolStripMenuItem";
            this.ChangeNameToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.ChangeNameToolStripMenuItem.Text = "修改昵称(&N)";
            this.ChangeNameToolStripMenuItem.Click += new System.EventHandler(this.ChangeNameToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainFormMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "学生信息管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MainFormMenuStrip.ResumeLayout(false);
            this.MainFormMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip MainFormMenuStrip;
        public System.Windows.Forms.ToolStripMenuItem ActionToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ExitOrRelogintoolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem ReloginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangePassWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangeNameToolStripMenuItem;
    }
}

