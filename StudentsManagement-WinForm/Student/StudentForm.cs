using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model;

namespace StudentsManagement_winForm
{
    public partial class StudentForm : MainForm
    {
        /// <summary>
        /// 子窗体是否显示
        /// </summary>
        public static bool isshow = false;
        /// <summary>
        /// 子窗体
        /// </summary>
        Student.TableForm tableForm =null;
        public StudentForm() : base()
        {
            InitializeComponent();
        }

        public StudentForm(User user) : base(user)
        {
            InitializeComponent();
            AddExtend();
            tableForm = new Student.TableForm(user);
        }

        /// <summary>
        /// 表显示
        /// </summary>
        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
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
                tableForm = new Student.TableForm(Logined_user);
            }
            tableForm.MdiParent = this;
            tableForm.Controls.Add(tableForm.courseAddControl);
            tableForm.StartPosition = FormStartPosition.CenterParent;
            tableForm.Show();

        }

        /// <summary>
        /// 表显示
        /// </summary>
        private void gradeViewToolStripMenuItem_Click(object sender, EventArgs e)
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
                tableForm = new Student.TableForm(Logined_user);
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
            this.MainFormMenuStrip.Items.Insert(0, this.courseChooseToolStripMenuItem);
            this.MainFormMenuStrip.Items.Insert(0, this.gradeToolStripMenuItem);
            this.MainFormMenuStrip.SuspendLayout();
            this.MainFormMenuStrip.ResumeLayout(false);
            this.MainFormMenuStrip.PerformLayout();
            #endregion
        }

    }
}
