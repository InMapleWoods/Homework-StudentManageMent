namespace StudentManagement
{
    partial class TeacherForm
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
            this.SuspendLayout();
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TeacherForm";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.courseManageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.courseAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentManageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradeAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SuspendLayout();
            // 
            // courseManageToolStripMenuItem
            // 
            this.courseManageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.courseAddToolStripMenuItem});
            this.courseManageToolStripMenuItem.Name = "courseManageToolStripMenuItem";
            this.courseManageToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.courseManageToolStripMenuItem.Text = "课程管理(&C)";
            // 
            // courseAddToolStripMenuItem
            // 
            this.courseAddToolStripMenuItem.Name = "courseAddToolStripMenuItem";
            this.courseAddToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.courseAddToolStripMenuItem.Text = "新增课程(&A)";
            this.courseAddToolStripMenuItem.Click += new System.EventHandler(this.增添ToolStripMenuItem_Click);
            // 
            // studentManageToolStripMenuItem
            // 
            this.studentManageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gradeAddToolStripMenuItem});
            this.studentManageToolStripMenuItem.Name = "studentManageToolStripMenuItem";
            this.studentManageToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.studentManageToolStripMenuItem.Text = "学生信息管理(&S)";
            // 
            // gradeAddToolStripMenuItem
            // 
            this.gradeAddToolStripMenuItem.Name = "gradeAddToolStripMenuItem";
            this.gradeAddToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.gradeAddToolStripMenuItem.Text = "成绩录入(&G)";
            this.gradeAddToolStripMenuItem.Click += new System.EventHandler(this.成绩录入ToolStripMenuItem_Click);
            // 
            // Opartionform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(613, 464);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsMdiContainer = true;
            this.Name = "Opartionform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "教师信息管理";
            this.ResumeLayout(false);
            this.PerformLayout();


        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem courseManageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem courseAddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentManageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradeAddToolStripMenuItem;
    }
}
