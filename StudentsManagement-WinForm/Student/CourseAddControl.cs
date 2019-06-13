using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using System.Data.SqlClient;
using Bll;

namespace StudentsManagement_winForm.Student
{
    public partial class CourseAddControl : UserControl
    {
        /// <summary>
        /// 课程用户操作对象
        /// </summary>
        public CourseBll courseBll = new CourseBll();
        string id = "";
        /// <summary>
        /// 创建user对象储存登录信息
        /// </summary>
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
            DataTable dataTable = courseBll.GetAllCourse();//储存Datatable
            courseDataGridView.DataSource = dataTable;//设置数据源，用于填充控件            
            dataTable = courseBll.GetStudentAllCourse(t.UserID.ToString());//储存Datatable
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
            try
            {
                if(courseBll.ChooseCourse(t.UserID.ToString(),id))
                {
                    MessageBox.Show("成功");
                }
                else
                {
                    MessageBox.Show("失败");
                }
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
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
            DataTable dataTable = courseBll.GetStudentAllCourse(t.UserID.ToString());//储存Datatable
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
            if(courseBll.DeleteStudentCourse(t.UserID.ToString(), id))
            {
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("删除失败");
            }
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
