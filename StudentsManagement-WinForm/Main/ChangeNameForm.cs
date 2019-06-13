using System;
using Model;
using System.Windows.Forms;
using Bll;

namespace StudentsManagement_winForm
{
    /// <summary>
    /// 昵称修改窗体
    /// </summary>
    public partial class ChangeNameForm : Form
    {
        /// <summary>
        /// 用户操作对象
        /// </summary>
        UserBll userBll = new UserBll();
        /// <summary>
        /// 储存登录角色
        /// </summary>
        User Login_user = null;
        public ChangeNameForm(User user)
        {
            Login_user = user;
            userBll.SetUser(Login_user);
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
        /// 修改昵称
        /// </summary>
        private bool CheckName()
        {
            if(userBll.ChangedName(Login_user.UserID.ToString(), NewNametextBox.Text))
            {
                Login_user.UserName = NewNametextBox.Text;
                userBll.SetUser(Login_user);
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
