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
    /// 学生表
    /// </summary>
    public partial class StudentTableControl : UserControl
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
        public StudentTableControl()
        {
            SQLHelper helper = new SQLHelper();//创建SQLHelp对象
            num = helper.sqlNum("tb_Users where Role=1");
            num = num / size + (num % size == 0 ? 0 : 1);
            InitializeComponent();
            TableShow();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void TableShow()
        {
            SQLHelper helper = new SQLHelper();//创建SQLHelp对象
            string sqlstr = "select dbo.PadLeft(Id,8,'0') 账号,Name 昵称 from tb_Users where Role=1 order by Id offset ((" + (index - 1) + ")*" + size + ") rows fetch next " + size + " rows only";//SQL执行字符串
            DataTable dataTable = helper.reDt(sqlstr);//储存Datatable
            StudentTableView.DataSource = dataTable;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "btnDelete";
            btn.HeaderText = "删除";
            btn.DefaultCellStyle.NullValue = "删除";           
            if (!StudentTableView.Columns.Contains("btnDelete"))
            {
                StudentTableView.Columns.Add(btn);
            }
            if (IndexLabel != null)
                IndexLabel.Text = index.ToString();
            if (SplitLabel != null)
                CountLabel.Text = num.ToString();
        }

        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="id">用户ID</param>
        private void DeleteUser(string id)
        {
            SQLHelper sqlHelper = new SQLHelper();
            string sqlStr = "delete from tb_Users where Id=@Id";
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
        private void StudentTableView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //点击button按钮事件
            if (StudentTableView.Columns[e.ColumnIndex].Name == "btnDelete" && e.RowIndex >= 0)
            {
                //说明点击的列是DataGridViewButtonColumn列
                DataGridViewColumn column = StudentTableView.Columns[e.ColumnIndex];
                string id = StudentTableView.CurrentRow.Cells[1].Value.ToString();
                DeleteUser(id);
            }
        }
    }
}
