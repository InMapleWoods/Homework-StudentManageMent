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
    /// 昵称修改窗体
    /// </summary>
    public partial class ChangeNameForm : Form
    {
        /// <summary>
        /// 储存登录角色
        /// </summary>
        User Login_user = null;
        public ChangeNameForm(User user)
        {
            Login_user = user;
            InitializeComponent();
            OldNameLabel.Text = user.UserName + ":";
        }

        /// <summary>
        /// 确定
        /// </summary>
        private void OKButton_Click(object sender, EventArgs e)
        {
            if(CheckName())
            {
                Close();
            }
            else
            {
                NewNametextBox.Text = String.Empty;
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 昵称修改窗体加载
        /// </summary>
        private void ChangeNameForm_Load(object sender, EventArgs e)
        {
            MainForm.IsShowed = true;
        }

        /// <summary>
        /// 昵称修改窗体关闭
        /// </summary>
        private void ChangeNameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.IsShowed = false;
        }

        /// <summary>
        /// 检查昵称
        /// </summary>
        private bool CheckName()
        {
            SQLHelper helper = new SQLHelper();
            string sqlStr = "update tb_Users set Name=@name where Id=@Id";
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@name",NewNametextBox.Text),
                new SqlParameter("@Id",Login_user.UserID),
             };
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.Text);
            if (count > 0)
            {
                Login_user.UserName = NewNametextBox.Text;
                MessageBox.Show("修改成功");
                return true;
            }
            else
            {
                MessageBox.Show("修改失败");
                return false;
            }
        }
    }
}
