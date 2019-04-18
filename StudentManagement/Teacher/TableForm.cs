using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement.Teacher
{
    /// <summary>
    /// 显示的表
    /// </summary>
    public partial class TableForm : Form
    {
        /// <summary>
        /// 表窗体构造函数
        /// </summary>
        public TableForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 表窗体关闭
        /// </summary>
        private void TableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TeacherForm.isshow = false;
        }

        /// <summary>
        /// 表窗体打开
        /// </summary>
        private void TableForm_Load(object sender, EventArgs e)
        {
            TeacherForm.isshow = true;
        }
    }
}
