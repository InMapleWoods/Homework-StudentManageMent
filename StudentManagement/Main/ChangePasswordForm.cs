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
    /// 密码修改窗体
    /// </summary>
    public partial class ChangePasswordForm : Form
    {
        /// <summary>
        /// 储存登录角色
        /// </summary>
        User Login_user = null;
        public ChangePasswordForm(User user)
        {
            Login_user = user;
            InitializeComponent();
        }

        /// <summary>
        /// 确定
        /// </summary>
        private void OKButton_Click(object sender, EventArgs e)
        {
            if(CheckPassword())
            {
                Close();
            }
            else
            {
                NewPassWordtextBox.Text = String.Empty;
                OldPassWordtextBox.Text = String.Empty;
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
        /// 密码修改窗体加载
        /// </summary>
        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            MainForm.IsShowed = true;
        }

        /// <summary>
        /// 密码修改窗体关闭
        /// </summary>
        private void ChangePasswordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.IsShowed = false;
        }

        /// <summary>
        /// 检查密码
        /// </summary>
        private bool CheckPassword()
        {
            SQLHelper helper = new SQLHelper();
            string opwd = OldPassWordtextBox.Text;
            if(!Login_user.PassWord.Equals(helper.GetMD5(opwd)))
            {
                MessageBox.Show("旧密码不正确");
                return false;
            }
            string sqlStr = "update tb_Users set Password=@password where Id=@Id";
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@password",helper.GetMD5(NewPassWordtextBox.Text)),
                new SqlParameter("@Id",Login_user.UserID),
             };
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.Text);
            if (count > 0)
            {
                Login_user.PassWord = helper.GetMD5(NewPassWordtextBox.Text);
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
