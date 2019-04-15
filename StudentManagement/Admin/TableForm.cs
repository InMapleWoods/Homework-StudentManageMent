using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    /// <summary>
    /// 管理员显示的表
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
            AdminForm.TableIsShowed = false;
        }

        /// <summary>
        /// 表窗体打开
        /// </summary>
        private void TableForm_Load(object sender, EventArgs e)
        {
            AdminForm.TableIsShowed = true;
        }
    }
}
