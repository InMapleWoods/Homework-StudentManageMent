using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace StudentsManagement_winForm
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// 创建user对象储存登录信息
        /// </summary>
        public User Logined_user;
        /// <summary>
        /// 是否已经显示修改窗体
        /// </summary>
        static public bool IsShowed = false;
        /// <summary>
        /// 主窗体构造函数
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 有参主窗体构造函数
        /// </summary>
        /// <param name="user">登录的user对象</param>
        public MainForm(User user)
        {
            Logined_user = user;//将传递过来的参数保存在user对象中
            InitializeComponent();
        }

        /// <summary>
        /// 主窗体关闭事件
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);//关闭进程
        }

        /// <summary>
        /// 菜单栏退出
        /// </summary>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);//关闭进程
        }
        
        /// <summary>
        /// 菜单栏重新登录
        /// </summary>
        private void ReloginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        private void ChangePassWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!IsShowed)
            {
                ChangePasswordForm changePasswordForm = new ChangePasswordForm(Logined_user);
                changePasswordForm.MdiParent = this;
                changePasswordForm.StartPosition = FormStartPosition.CenterParent;
                changePasswordForm.Show();                
            }
        }

        /// <summary>
        /// 修改昵称
        /// </summary>
        private void ChangeNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsShowed)
            {
                ChangeNameForm changeNameForm = new ChangeNameForm(Logined_user);
                changeNameForm.MdiParent = this;
                changeNameForm.StartPosition = FormStartPosition.CenterParent;
                changeNameForm.Show();
            }
        }
    }
}
