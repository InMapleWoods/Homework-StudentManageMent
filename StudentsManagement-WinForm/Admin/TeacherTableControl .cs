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

namespace StudentsManagement_winForm
{
    /// <summary>
    /// 老师表
    /// </summary>
    public partial class TeacherTableControl : UserControl
    {
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
        /// 老师表控件构造函数
        /// </summary>
        public TeacherTableControl()
        {
            InitializeComponent();
            TableShow();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void TableShow()
        {
            num = userBll.GetAllPageNum(size, UserBll.choose_Teacher);
            DataTable dataTable = userBll.GetPaperUsers(index, size, UserBll.choose_Teacher);//储存Datatable
            TeacherTableView.DataSource = dataTable;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                Name = "btnDelete",
                HeaderText = "删除"
            };
            btn.DefaultCellStyle.NullValue = "删除";           
            if (!TeacherTableView.Columns.Contains("btnDelete"))
            {
                TeacherTableView.Columns.Add(btn);
            }
            if (IndexLabel != null)
                IndexLabel.Text = index.ToString();
            if (SplitLabel != null)
                CountLabel.Text = num.ToString();
        }

        /// <summary>
        /// 删除老师
        /// </summary>
        /// <param name="id">用户ID</param>
        private void DeleteUser(string id)
        {
            if (userBll.DeleteUser(id))
            {
                MessageBox.Show("删除成功");
                TableShow();
            }
            else
            {
                MessageBox.Show("删除失败");
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
        private void TeacherTableView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //点击button按钮事件
            if (TeacherTableView.Columns[e.ColumnIndex].Name == "btnDelete" && e.RowIndex >= 0)
            {
                //说明点击的列是DataGridViewButtonColumn列
                //DataGridViewColumn column = TeacherTableView.Columns[e.ColumnIndex];
                string id = TeacherTableView.CurrentRow.Cells[1].Value.ToString();
                DeleteUser(id);
            }
        }
    }
}
