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
    /// 学生成绩管理
    /// </summary>
    public partial class StudentgrademangeForm : Form
    {
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
        public StudentgrademangeForm()
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
            string sqlstr = "select dbo.PadLeft(tb_Grade.SId,8,'0') as 学生学号,tb_Users.Name as 学生姓名,tb_Grade.Grade as 课程分数 from tb_Grade ,tb_Users where CId='" + courseid+ "' and tb_Grade.SId=tb_Users.Id";//SQL执行字符串
            DataTable dataTable = helper.reDt(sqlstr);//储存Datatable
            dataGridView1.DataSource = dataTable;//设置数据源，用于填充控件
            sqlstr = "select Id,Name from tb_Course";//SQL执行字符串
            dataTable = helper.reDt(sqlstr);//储存Datatable
            string[] accounts = new string[dataTable.Rows.Count];
            comboBoxId = new string[accounts.Length];
            for (int i = 0; i < accounts.Length; i++)
            {
                accounts[i] = dataTable.Rows[i]["Name"].ToString();
                comboBoxId[i] = dataTable.Rows[i]["Id"].ToString();
            }
            courseComboBox.DataSource = accounts;//设置数据源，用于填充控件
        }

        /// <summary>
        /// 关闭窗体事件
        /// </summary>
        private void StudentgrademangeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TeacherForm.isshow = false;
        }

        /// <summary>
        /// 改变按钮点击事件
        /// </summary>
        private void ChangeButton_Click(object sender, EventArgs e)
        {
            courseid = comboBoxId[comboBoxIndex];
            string grade = "";
            grade = gradeTextBox.Text;
            if (grade == "")
            {
                return;
            }
            SQLHelper sqlHelper = new SQLHelper();
            string sqlstr = "UPDATE tb_Grade SET Grade=@grade where SId=@studenid and CId=@courseid";
            //储存Datatable
            SqlParameter[] para1 = new SqlParameter[]//存储相应参数的容器
            {
                new SqlParameter("@grade",grade),
                new SqlParameter("@studenid",studenid),
                new SqlParameter("@courseid",courseid),
            };
            sqlHelper.ExecuteNonQuery(sqlstr, para1, CommandType.Text);
            DataListBind();
        }

        /// <summary>
        /// 下拉框选中项改变事件
        /// </summary>
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxIndex = courseComboBox.SelectedIndex;
        }

        /// <summary>
        /// datagridview选中项改变事件
        /// </summary>
        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                studenid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                studentIdLabel.Text = "学生ID： "+studenid;
            }
        }
    }
}
