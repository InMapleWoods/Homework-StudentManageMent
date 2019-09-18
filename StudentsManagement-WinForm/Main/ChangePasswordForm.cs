using System;
using System.Data.SqlClient;
using Model;
using System.Windows.Forms;
using Bll;
using System.Security.Cryptography;

namespace StudentsManagement_winForm
{
    /// <summary>
    /// 密码修改窗体
    /// </summary>
    public partial class ChangePasswordForm : Form
    {
        /// <summary>
        /// 用户操作对象
        /// </summary>
        UserBll userBll = new UserBll();
        /// <summary>
        /// 储存登录角色
        /// </summary>
        User Login_user = null;
        public ChangePasswordForm(User user)
        {
            Login_user = user;
            userBll.t=user;
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
            string opwd = OldPassWordtextBox.Text;
            string npwd = NewPassWordtextBox.Text;
            if (userBll.ChangePassword(opwd,npwd))
            {
                Login_user.PassWord = GetMD5(NewPassWordtextBox.Text);
                userBll.t=Login_user;
                MessageBox.Show("修改成功");
                return true;
            }
            else
            {
                MessageBox.Show("修改失败");
                return false;
            }
        }

        public string GetMD5(string strPwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(strPwd);
            byte[] MD5data = md5.ComputeHash(data);
            md5.Clear();
            string str = "";
            for (int i = 0; i < MD5data.Length - 1; i++)
            {
                str += MD5data[i].ToString("X").PadLeft('1', '0');
            }
            return str;
        }

    }
}
