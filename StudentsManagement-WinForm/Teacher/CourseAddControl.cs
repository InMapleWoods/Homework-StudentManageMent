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
using Model;
using Bll;

namespace StudentsManagement_winForm.Teacher
{
    public partial class CourseAddControl : UserControl
    {
        /// <summary>
        /// 课程用户操作对象
        /// </summary>
        public CourseBll courseBll = new CourseBll();
        /// <summary>
        /// 创建user对象储存登录信息
        /// </summary>
        public User user;
        /// <summary>
        /// 构造函数
        /// </summary>
        public CourseAddControl(User user)
        {
            InitializeComponent();
            this.user = user;
            DataListBind();
        }

        /// <summary>
        /// 绑定数据源
        /// </summary>
        public void DataListBind()
        {
            DataTable dataTable = courseBll.GetAllCourse();//储存Datatable
            courseDataGridView.DataSource = dataTable;//设置数据源，用于填充控件
        }


        /// <summary>
        /// 增加课程按钮点击事件
        /// </summary>
        private void courseAddButton_Click(object sender, EventArgs e)
        {
            string name = courseTextBox.Text;
            if (name == "")
            {
                return;
            }
            if(courseBll.AddCourse(name,user.UserID.ToString()))
            {
                MessageBox.Show("操作成功");
            }
            else
            {
                MessageBox.Show("失败");
            }
            DataListBind();
        }
    }
}
