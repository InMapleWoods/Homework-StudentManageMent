using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class TeacherForm : MainForm
    {
        public static bool isshow = false;
        public TeacherForm() : base()
        {
            InitializeComponent();
        }

        public TeacherForm(User user) : base(user)
        {
            InitializeComponent();
            AddExtend();
        }


        private void 增添ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CoursemanageForm form2 = new CoursemanageForm();
            form2.MdiParent = this;
            if (isshow == false)
            {
                form2.Show();
                isshow = true;
            }
        }

        private void 成绩录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentgrademangeForm form3 = new StudentgrademangeForm();
            form3.MdiParent = this;
            if (isshow == false)
            {
                form3.Show();
                isshow = true;
            }

        }

        /// <summary>
        /// 继承后子窗体增加内容
        /// </summary>
        private void AddExtend()
        {
            #region 增加菜单栏
            this.MainFormMenuStrip.Items.Insert(0, this.studentManageToolStripMenuItem);
            this.MainFormMenuStrip.Items.Insert(0, this.courseManageToolStripMenuItem);
            this.MainFormMenuStrip.SuspendLayout();
            this.MainFormMenuStrip.ResumeLayout(false);
            this.MainFormMenuStrip.PerformLayout();
            #endregion
        }
    }
}
