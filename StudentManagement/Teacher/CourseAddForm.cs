using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    /// <summary>
    /// 增加课程
    /// </summary>
    public partial class CoursemanageForm : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CoursemanageForm()
        {
            InitializeComponent();
            DataListBind();
        }

        /// <summary>
        /// 绑定数据源
        /// </summary>
        public void DataListBind()
        {
            SQLHelper helper = new SQLHelper();//创建SQLHelp对象
            string sqlstr = "select Name as 课程名 from tb_Course";//SQL执行字符串
            DataTable dataTable = helper.reDt(sqlstr);//储存Datatable
            courseDataGridView.DataSource = dataTable;//设置数据源，用于填充控件
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        private void CoursemanageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TeacherForm.isshow = false;
        }

        /// <summary>
        /// 增加课程按钮点击事件
        /// </summary>
        private void courseAddButton_Click(object sender, EventArgs e)
        {
            string name = "";
            name = courseTextBox.Text;
            if (name == "")
            {
                return;
            }
            SQLHelper sqlHelper = new SQLHelper();
            string sqlstr = "INSERT INTO tb_Course (Name) VALUES(@name)";
            //储存Datatable
            SqlParameter[] para1 = new SqlParameter[]//存储相应参数的容器
            {
                new SqlParameter("@name",name),
            };
            sqlHelper.ExecuteNonQuery(sqlstr, para1, CommandType.Text);
            DataListBind();
        }
    }
}
