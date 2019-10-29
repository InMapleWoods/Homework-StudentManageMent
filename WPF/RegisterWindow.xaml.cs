using Bll;
using System;
using System.Windows;

namespace WPF
{
    /// <summary>
    /// RegisterWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterWindow : Window
    {
        /// <summary>
        /// 用户操作对象
        /// </summary>
        readonly UserBll userBll = new UserBll();
        /// <summary>
        /// 父登录窗体
        /// </summary>
        private readonly LoginWindow ParentLoginWindow = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public RegisterWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 有父窗体的构造函数
        /// </summary>
        public RegisterWindow(LoginWindow loginWindow)
        {
            ParentLoginWindow = loginWindow;
            InitializeComponent();
        }

        #region 注册
        /// <summary>
        /// 注册按钮点击事件
        /// </summary>
        private void Register_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Register_RoleChoose.SelectedIndex == -1)
                    throw new Exception("未选择角色");
                string account;
                string name = Register_Name_Text.Text;
                string pwd = Register_Password_PasswordBox.Password;
                string repeatpwd = Register_Repassword_PasswordBox.Password;
                int role = Register_RoleChoose.SelectedIndex + 1;
                if (Register(name, pwd, repeatpwd, role, out account))
                {
                    ParentLoginWindow.AccountText.Text = account;
                    ParentLoginWindow.PasswordText.Password = Register_Password_PasswordBox.Password;
                    ParentLoginWindow.Show();
                    Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="repeatPassword">重复密码</param>
        /// <param name="role">用户角色</param>
        /// <param name="account">用户账号</param>
        /// <returns>注册成功与否</returns>
        private bool Register(string name, string password, string repeatPassword, int role, out string account)
        {
            try
            {
                string accountNum;
                bool result = userBll.Register(name, password, repeatPassword, out accountNum, role);
                account = accountNum;
                MessageBox.Show("请牢记您的登录账号为：" + accountNum);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            account = "";
            return false;
        }

        #endregion

        /// <summary>
        /// 取消按钮点击事件
        /// </summary>
        private void Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            ParentLoginWindow.Show();
            Hide();
            Close();
        }

    }
}
