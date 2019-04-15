namespace StudentManagement
{
    partial class AdminForm
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
        private new void InitializeComponent()
        {
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StudentTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TeacherTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SuspendLayout();
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StudentTableToolStripMenuItem,
            this.TeacherTableToolStripMenuItem,
            this.CheckTableToolStripMenuItem});
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.OpenToolStripMenuItem.Text = "打开(&O)";
            // 
            // StudentTableToolStripMenuItem
            // 
            this.StudentTableToolStripMenuItem.Name = "StudentTableToolStripMenuItem";
            this.StudentTableToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.StudentTableToolStripMenuItem.Text = "学生表(&S)";
            this.StudentTableToolStripMenuItem.Click += new System.EventHandler(this.StudentTableToolStripMenuItem_Click);
            // 
            // TeacherTableToolStripMenuItem
            // 
            this.TeacherTableToolStripMenuItem.Name = "TeacherTableToolStripMenuItem";
            this.TeacherTableToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.TeacherTableToolStripMenuItem.Text = "教师表(&T)";
            this.TeacherTableToolStripMenuItem.Click += new System.EventHandler(this.TeacherTableToolStripMenuItem_Click);
            // 
            // CheckTableToolStripMenuItem
            // 
            this.CheckTableToolStripMenuItem.Name = "CheckTableToolStripMenuItem";
            this.CheckTableToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.CheckTableToolStripMenuItem.Text = "审核表(&C)";
            this.CheckTableToolStripMenuItem.Click += new System.EventHandler(this.CheckTableToolStripMenuItem_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(1551, 742);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "AdminForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem StudentTableToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem TeacherTableToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem CheckTableToolStripMenuItem;
    }
}
