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
    public partial class CourseAddControl : UserControl
    {
        string id = "";
        User t = null;
        /// <summary>
        /// 构造函数
        /// </summary>
        public CourseAddControl(User user)
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
            string sqlstr = "select Id as 课程ID,Name as 课程名 from tb_Course";//SQL执行字符串
            DataTable dataTable = helper.reDt(sqlstr);//储存Datatable
            courseDataGridView.DataSource = dataTable;//设置数据源，用于填充控件
            sqlstr = "select tb_Course.Id as 课程ID,tb_Course.Name as 课程名  from tb_Course,tb_Grade where tb_Grade.SId='"+t.UserID+ "'  and tb_Grade.CId=tb_Course.Id";
            dataTable = helper.reDt(sqlstr);//储存Datatable
            myCourseDataGridView.DataSource = dataTable;
        }


        /// <summary>
        /// 增加课程按钮点击事件
        /// </summary>
        private void courseAddButton_Click(object sender, EventArgs e)
        {
            id = courseTextBox.Text;
            if (id == "")
            {
                return;
            }
            SQLHelper sqlHelper = new SQLHelper();
            int num = sqlHelper.sqlNum("tb_Course Where Id='"+id+"'");
            if (num == 0)
            {
                MessageBox.Show("该课程不存在");
                return;
            }
            num = sqlHelper.sqlNum("tb_Grade Where CId='" + courseTextBox.Text + "' and SId='"+t.UserID+"'");
            if (num != 0)
            {
                MessageBox.Show("重复选课");
                return;
            }
            string sqlstr = "INSERT INTO tb_Grade(CId,SId) VALUES(@cid,@sid)";
            //储存Datatable
            SqlParameter[] para1 = new SqlParameter[]//存储相应参数的容器
            {
                new SqlParameter("@cid",id),
                new SqlParameter("@sid",t.UserID),
            };
            sqlHelper.ExecuteNonQuery(sqlstr, para1, CommandType.Text);
            DataListBind();
        }

        private void CourseDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (courseDataGridView.CurrentRow != null)
            {
                id = courseDataGridView.CurrentRow.Cells[0].Value.ToString();
                courseTextBox.Text = id;
            }
        }

        private void CourseDeleteButton_Click(object sender, EventArgs e)
        {
            id = courseTextBox.Text;
            if (id == "")
            {
                return;
            }
            int sumcount = 0;
            SQLHelper sqlHelper = new SQLHelper();
            string sqlstr = "select tb_Course.Id as 课程ID,tb_Course.Name as 课程名  from tb_Course,tb_Grade where tb_Grade.SId='" + t.UserID + "'  and tb_Grade.CId=tb_Course.Id";
            DataTable dataTable = sqlHelper.reDt(sqlstr);//储存Datatable
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i]["课程ID"].ToString() == id)
                    sumcount++;
            }
            if(sumcount!=1)
            {
                MessageBox.Show("你未选择该课程");
                return;
            }
            sqlstr = "Delete from tb_Grade where CId=@cid and SId=@sid";
            SqlParameter[] para1 = new SqlParameter[]//存储相应参数的容器
            {
                new SqlParameter("@cid",id),
                new SqlParameter("@sid",t.UserID),
            };
            sqlHelper.ExecuteNonQuery(sqlstr, para1, CommandType.Text);
            DataListBind();

        }

        private void MyCourseDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (myCourseDataGridView.CurrentRow != null)
            {
                id = myCourseDataGridView.CurrentRow.Cells[0].Value.ToString();
                courseTextBox.Text = id;
            }
        }
    }
}
