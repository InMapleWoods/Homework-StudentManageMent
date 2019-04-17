using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StudentManagement
{
    /// <summary>
    /// 管理员窗体
    /// </summary>
    public partial class AdminForm : MainForm
    {
        /// <summary>
        /// 子窗体是否显示
        /// </summary>
        public static bool TableIsShowed = false;
        /// <summary>
        /// 子窗体
        /// </summary>
        TableForm tableForm = new TableForm();
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public AdminForm() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="user">用户</param>
        public AdminForm(User user) : base(user)
        {
            InitializeComponent();
            AddExtend();
        }

        /// <summary>
        /// 表显示
        /// </summary>
        private void TableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TableIsShowed)
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
                tableForm = new TableForm();
            }
            tableForm.MdiParent = this;
            if(((ToolStripMenuItem)sender).Text== "学生表(&S)")
            {
                tableForm.Controls.Add(tableForm.studentTableControl1);
            }
            else if (((ToolStripMenuItem)sender).Text == "教师表(&T)")
            {
                tableForm.Controls.Add(tableForm.teacherTableControl1);
            }
            else if (((ToolStripMenuItem)sender).Text == "审核表(&C)")
            {
                tableForm.Controls.Add(tableForm.CheckTableControl1);
            }
            else if (((ToolStripMenuItem)sender).Text == "课程表(&K)")
            {
                tableForm.Controls.Add(tableForm.courseTableControl1);
            }
            tableForm.StartPosition = FormStartPosition.CenterParent;
            tableForm.Show();            
        } 

        /// <summary>
        /// 继承后子窗体增加内容
        /// </summary>
        private void AddExtend()
        {
            #region 增加菜单栏
            this.MainFormMenuStrip.Items.Insert(0, this.OpenToolStripMenuItem);
            this.MainFormMenuStrip.SuspendLayout();
            this.MainFormMenuStrip.ResumeLayout(false);
            this.MainFormMenuStrip.PerformLayout();
            #endregion
        }


    }
}
