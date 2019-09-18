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
using Bll;

namespace StudentsManagement_winForm.Teacher
{
    public partial class GradeManageControl : UserControl
    {
        /// <summary>
        /// 课程用户操作对象
        /// </summary>
        CourseBll courseBll = new CourseBll();
        /// <summary>
        /// 成绩操作对象
        /// </summary>
        GradeBll gradeBll = new GradeBll();
        /// <summary>
        /// 学生ID
        /// </summary>
        private string studenid = "1";
        /// <summary>
        /// 课程ID
        /// </summary>
        private string courseid = "1";
        /// <summary>
        /// 下拉框Index
        /// </summary>
        private int comboBoxIndex = 0;
        /// <summary>
        /// Id存储
        /// </summary>
        private string[] comboBoxId;

        /// <summary>
        /// 构造函数
        /// </summary>
        public GradeManageControl()
        {
            InitializeComponent();
            DataListBind();
            CourseListBind();
        }

        /// <summary>
        /// 绑定数据源
        /// </summary>
        public void DataListBind()
        {
            DataTable dataTable = gradeBll.GetCourseGrade(courseid);//储存Datatable
            dataGridView1.DataSource = dataTable;//设置数据源，用于填充控件
        }

        private void CourseListBind()
        {
            DataTable dataTable = courseBll.GetAllCourse();//储存Datatable
            string[] accounts = new string[dataTable.Rows.Count];
            comboBoxId = new string[accounts.Length];
            for (int i = 0; i < accounts.Length; i++)
            {
                accounts[i] = dataTable.Rows[i]["课程名"].ToString();
                comboBoxId[i] = dataTable.Rows[i]["课程ID"].ToString();
            }
            courseComboBox.DataSource = accounts;//设置数据源，用于填充控件
        }

        /// <summary>
        /// 改变按钮点击事件
        /// </summary>
        private void ChangeButton_Click(object sender, EventArgs e)
        {
            courseid = comboBoxId[comboBoxIndex];
            string score= gradeTextBox.Text;
            if (score == "")
            {
                return;
            }
            if(gradeBll.ChangeCourseGrade(score,studenid,courseid))
            {
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("修改失败");
            }
            DataListBind();
        }

        /// <summary>
        /// 下拉框选中项改变事件
        /// </summary>
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxIndex = courseComboBox.SelectedIndex;
            courseid = comboBoxId[comboBoxIndex];
            DataListBind();
        }

        /// <summary>
        /// datagridview选中项改变事件
        /// </summary>
        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                studenid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                studentIdLabel.Text = "学生ID： " + studenid;
            }
        }
    }
}
