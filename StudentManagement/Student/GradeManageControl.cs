using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StudentManagement.Student
{
    public partial class GradeManageControl : UserControl
    {
        User t = null;
        /// <summary>
        /// 课程ID
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
            SQLHelper helper = new SQLHelper();//创建SQLHelp对象
            string sqlstr = "select tb_Course.Name as 课程名,tb_Grade.Grade as 课程分数 from tb_Grade ,tb_Course where SId='" + t.UserID + "' and tb_Grade.CId=tb_Course.Id";//SQL执行字符串
            DataTable dataTable = helper.reDt(sqlstr);//储存Datatable
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
