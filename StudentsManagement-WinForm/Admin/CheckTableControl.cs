using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Bll;
namespace StudentsManagement_winForm
{
    /// <summary>
    /// 审核表控件
    /// </summary>
    public partial class CheckTableControl : UserControl
    {
        /// <summary>
        /// 管理员操作对象
        /// </summary>
        AdminBll adminBll = new AdminBll();
        /// <summary>
        /// 用户操作对象
        /// </summary>
        UserBll userBll = new UserBll();
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
            InitializeComponent();
            TableShow();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void TableShow()
        {
            num = adminBll.GetAllPageNum(size, AdminBll.choose_Unchecked);
            DataTable dataTable = adminBll.GetPaperUsers(index, size, AdminBll.choose_Unchecked);//储存Datatable
            CheckTableView.DataSource = dataTable;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                Name = "btnPass",
                HeaderText = "通过"
            };
            btn.DefaultCellStyle.NullValue = "通过";
            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn
            {
                Name = "btnReject",
                HeaderText = "拒绝"
            };
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
            if(adminBll.AcceptLog(id, tobe))
            {
                TableShow();
            }
            else
            {
                MessageBox.Show("失败");
            }
        }

        /// <summary>
        /// 拒绝申请
        /// </summary>
        /// <param name="id">申请用户ID</param>
        private void RejectionLog(string id)
        {
            if (adminBll.RejectionLog(id))
            {
                TableShow();
            }
            else
            {
                MessageBox.Show("失败");
            }
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
                string id = CheckTableView.CurrentRow.Cells[2].Value.ToString();
                string WantToBe = CheckTableView.CurrentRow.Cells[4].Value.ToString();
                AcceptLog(id, WantToBe);
            }
            else if (CheckTableView.Columns[e.ColumnIndex].Name == "btnReject" && e.RowIndex >= 0)
            {
                //说明点击的列是DataGridViewButtonColumn列
                string id = CheckTableView.CurrentRow.Cells[2].Value.ToString();
                RejectionLog(id);
            }
        }
    }
}