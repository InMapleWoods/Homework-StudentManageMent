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
        /// <summary>
        /// 子窗体是否显示
        /// </summary>
        public static bool isshow = false;
        /// <summary>
        /// 子窗体
        /// </summary>
        Teacher.TableForm tableForm = new Teacher.TableForm();
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
            if (isshow)
            {
                int t = tableForm.Controls.Count;
                while (t > 0)
                {
                    t--;
                    tableForm.Controls.RemoveAt(0);
                }
            }
            else
            {
                tableForm = new Teacher.TableForm();
            }
            tableForm.MdiParent = this;
            tableForm.Controls.Add(tableForm.courseAddControl);
            tableForm.StartPosition = FormStartPosition.CenterParent;
            tableForm.Show();
        }

        private void 成绩录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isshow)
            {
                int t = tableForm.Controls.Count;
                while (t > 0)
                {
                    t--;
                    tableForm.Controls.RemoveAt(0);
                }
            }
            else
            {
                tableForm = new Teacher.TableForm();
            }
            tableForm.MdiParent = this;
            tableForm.Controls.Add(tableForm.gradeManageControl);
            tableForm.StartPosition = FormStartPosition.CenterParent;
            tableForm.Show();
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
