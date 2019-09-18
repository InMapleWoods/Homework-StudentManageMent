using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Windows.Forms;

namespace StudentsManagement_winForm.Student
{
    /// <summary>
    /// 显示的表
    /// </summary>
    public partial class TableForm : Form
    {
        User t = null;
        /// <summary>
        /// 表窗体构造函数
        /// </summary>
        public TableForm(User user)
        {
            t = user;
            InitializeComponent();
        }

        /// <summary>
        /// 表窗体关闭
        /// </summary>
        private void TableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StudentForm.isshow = false;
        }

        /// <summary>
        /// 表窗体打开
        /// </summary>
        private void TableForm_Load(object sender, EventArgs e)
        {
            StudentForm.isshow = true;
        }
    }
}
