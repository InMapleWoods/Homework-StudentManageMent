namespace StudentsManagement_winForm
{
    partial class StudentForm
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
            this.courseChooseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.courseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradeViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SuspendLayout();
            // 
            // courseChooseToolStripMenuItem
            // 
            this.courseChooseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.courseToolStripMenuItem});
            this.courseChooseToolStripMenuItem.Name = "courseChooseToolStripMenuItem";
            this.courseChooseToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.courseChooseToolStripMenuItem.Text = "选课(&C)";
            // 
            // courseToolStripMenuItem
            // 
            this.courseToolStripMenuItem.Name = "courseToolStripMenuItem";
            this.courseToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.courseToolStripMenuItem.Text = "课程选择(&K)";
            this.courseToolStripMenuItem.Click += new System.EventHandler(this.courseToolStripMenuItem_Click);
            // 
            // gradeToolStripMenuItem
            // 
            this.gradeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gradeViewToolStripMenuItem});
            this.gradeToolStripMenuItem.Name = "gradeToolStripMenuItem";
            this.gradeToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.gradeToolStripMenuItem.Text = "查看成绩(&G)";
            // 
            // gradeViewToolStripMenuItem
            // 
            this.gradeViewToolStripMenuItem.Name = "gradeViewToolStripMenuItem";
            this.gradeViewToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.gradeViewToolStripMenuItem.Text = "成绩查看(&V)";
            this.gradeViewToolStripMenuItem.Click += new System.EventHandler(this.gradeViewToolStripMenuItem_Click);
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "StudentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem courseChooseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem courseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradeViewToolStripMenuItem;
    }
}
