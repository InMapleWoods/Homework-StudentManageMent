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
    /// 课程表
    /// </summary>
    public partial class CourseTableControl : UserControl
    {
        /// <summary>
        /// 课程用户操作对象
        /// </summary>
        public CourseBll courseBll = new CourseBll();
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
            num = courseBll.GetAllPageNum(size);
            DataTable dataTable = courseBll.GetPaperCourse(index,size);//储存Datatable
            CourseTableView.DataSource = dataTable;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                Name = "btnDelete",
                HeaderText = "删除"
            };
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
        private void DeleteCourse(string id)
        {
            if(courseBll.DeleteCourse(id))
            {
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("删除失败");
            }
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
                DeleteCourse(id);
            }
        }
    }
}
