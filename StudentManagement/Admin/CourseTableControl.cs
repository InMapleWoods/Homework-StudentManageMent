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

namespace StudentManagement
{
    /// <summary>
    /// 课程表
    /// </summary>
    public partial class CourseTableControl : UserControl
    {
        /// <summary>
        /// 分页宽度
        /// </summary>
        int size = 5;
        /// <summary>
        /// 当前页索引
        /// </summary>
        int index = 1;
        /// <summary>
        /// 总页数
        /// </summary>
        int num = 1;
        /// <summary>
        /// 审核表控价构造函数
        /// </summary>
        public CourseTableControl()
        {
            InitializeComponent();
            TableShow();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void TableShow()
        {
            SQLHelper helper = new SQLHelper();//创建SQLHelp对象
            num = helper.sqlNum("tb_Course");
            num = num / size + (num % size == 0 ? 0 : 1);
            string sqlstr = "select Id 课程ID,Name 课程名称 from tb_Course order by Id offset ((" + (index - 1) + ")*" + size + ") rows fetch next " + size + " rows only";//SQL执行字符串
            DataTable dataTable = helper.reDt(sqlstr);//储存Datatable
            CourseTableView.DataSource = dataTable;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "btnDelete";
            btn.HeaderText = "删除";
            btn.DefaultCellStyle.NullValue = "删除";           
            if (!CourseTableView.Columns.Contains("btnDelete"))
            {
                CourseTableView.Columns.Add(btn);
            }
            if (IndexLabel != null)
                IndexLabel.Text = index.ToString();
            if (SplitLabel != null)
                CountLabel.Text = num.ToString();
        }

        /// <summary>
        /// 删除课程
        /// </summary>
        /// <param name="id">课程ID</param>
        private void DeleteUser(string id)
        {
            SQLHelper sqlHelper = new SQLHelper();
            string sqlStr = "delete from tb_Course where Id=@Id";
            SqlParameter[] para = new SqlParameter[]
             {                
                new SqlParameter("@Id",id)
             };
            int count = sqlHelper.ExecuteNonQuery(sqlStr, para, CommandType.Text);
            TableShow();
        }

        /// <summary>
        /// 页码减小
        /// </summary>
        private void LeftButton_Click(object sender, EventArgs e)
        {
            index = index >= 2 ? index - 1 : 1;
            TableShow();
        }

        /// <summary>
        /// 页码增加
        /// </summary>
        private void RightButton_Click(object sender, EventArgs e)
        {
            index = index < num ? index + 1 : num;
            TableShow();
        }

        /// <summary>
        /// button按钮事件
        /// </summary>
        private void CourseTableView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //点击button按钮事件
            if (CourseTableView.Columns[e.ColumnIndex].Name == "btnDelete" && e.RowIndex >= 0)
            {
                //说明点击的列是DataGridViewButtonColumn列
                DataGridViewColumn column = CourseTableView.Columns[e.ColumnIndex];
                string id = CourseTableView.CurrentRow.Cells[1].Value.ToString();
                DeleteUser(id);
            }
        }
    }
}
