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
    /// 审核表控价
    /// </summary>
    public partial class CheckTableControl : UserControl
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
        public CheckTableControl()
        {
            SQLHelper helper = new SQLHelper();//创建SQLHelp对象
            num = helper.sqlNum("tb_Log where IsChecked=0");
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
            string sqlstr = "select dbo.PadLeft(UserId,8,'0') 账号,Name 昵称,WantToBe 申请角色 from tb_Log where IsChecked=0 order by Id offset ((" + (index - 1) + ")*" + size + ") rows fetch next " + size + " rows only";//SQL执行字符串
            DataTable dataTable = helper.reDt(sqlstr);//储存Datatable
            CheckTableView.DataSource = dataTable;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "btnPass";
            btn.HeaderText = "通过";
            btn.DefaultCellStyle.NullValue = "通过";
            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            btn2.Name = "btnReject";
            btn2.HeaderText = "拒绝";
            btn2.DefaultCellStyle.NullValue = "拒绝";
            if (!CheckTableView.Columns.Contains("btnPass"))
            {
                CheckTableView.Columns.Add(btn);
            }
            if (!CheckTableView.Columns.Contains("btnReject"))
            {
                CheckTableView.Columns.Add(btn2);
            }
            if (IndexLabel != null)
                IndexLabel.Text = index.ToString();
            if (SplitLabel != null)
                CountLabel.Text = num.ToString();
        }

        /// <summary>
        /// 接收申请
        /// </summary>
        /// <param name="id">申请用户ID</param>
        private void AcceptLog(string id, string tobe)
        {
            SQLHelper sqlHelper = new SQLHelper();
            string sqlStr = "update tb_Log set IsChecked=@isChecked where UserId=@userId;  " +
                "update tb_Users set Role=@tobe where Id=@userId;";
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@isChecked",true),
                new SqlParameter("@tobe",tobe),
                new SqlParameter("@userId",id)
             };
            int count = sqlHelper.ExecuteNonQuery(sqlStr, para, CommandType.Text);
            TableShow();
        }

        /// <summary>
        /// 拒绝申请
        /// </summary>
        /// <param name="id">申请用户ID</param>
        private void RejectionLog(string id)
        {
            SQLHelper sqlHelper = new SQLHelper();
            string sqlStr = "update tb_Log set IsChecked=@isChecked where UserId=@userId  " +
                "update tb_Users set Role=0 where Id=@userId;";
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@isChecked",true),
                new SqlParameter("@userId",id)
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
        private void CheckTableView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //点击button按钮事件
            if (CheckTableView.Columns[e.ColumnIndex].Name == "btnPass" && e.RowIndex >= 0)
            {
                //说明点击的列是DataGridViewButtonColumn列
                DataGridViewColumn column = CheckTableView.Columns[e.ColumnIndex];
                string id = CheckTableView.CurrentRow.Cells[2].Value.ToString();
                string WantToBe = CheckTableView.CurrentRow.Cells[4].Value.ToString();
                AcceptLog(id, WantToBe);
            }
            else if (CheckTableView.Columns[e.ColumnIndex].Name == "btnReject" && e.RowIndex >= 0)
            {
                //说明点击的列是DataGridViewButtonColumn列
                DataGridViewColumn column = CheckTableView.Columns[e.ColumnIndex];
                string id = CheckTableView.CurrentRow.Cells[2].Value.ToString();
                RejectionLog(id);
            }
        }
    }
}