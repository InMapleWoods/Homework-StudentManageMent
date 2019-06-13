using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Windows.Forms;
using System.Data.SqlClient;
using Bll;

namespace StudentsManagement_winForm.Student
{
    public partial class GradeManageControl : UserControl
    {
        /// <summary>
        /// 成绩操作对象
        /// </summary>
        GradeBll gradeBll = new GradeBll();
        /// <summary>
        /// 用户对象
        /// </summary>
        User t = null;
        /// <summary>
        /// 课程名
        /// </summary>
        private string coursename = "";
        /// <summary>
        /// 构造函数
        /// </summary>
        public GradeManageControl(User user)
        {
            t = user;
            InitializeComponent();
            DataListBind();
        }

        /// <summary>
        /// 绑定数据源
        /// </summary>
        public void DataListBind()
        {
            DataTable dataTable = gradeBll.GetStudentGrade(t.UserID.ToString());
            myGradeDataGridView.DataSource = dataTable;//设置数据源，用于填充控件
        }

        private void MyGradeDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (myGradeDataGridView.CurrentRow != null)
            {
                coursename = myGradeDataGridView.CurrentRow.Cells[0].Value.ToString();
                courseIdLabel.Text = "课程名： " + coursename;
                gradeLabel.Text = "成绩: " + myGradeDataGridView.CurrentRow.Cells[1].Value.ToString();
            }
        }
    }
}
