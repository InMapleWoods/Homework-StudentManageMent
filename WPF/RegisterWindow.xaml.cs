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
                if (Register())
                {
                    string account = "sss";
                    ParentLoginWindow.AccountText.Text = account;
                    ParentLoginWindow.PasswordText.Password = Register_Password_PasswordBox.Password;
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
        /// <returns>注册成功与否</returns>
        private bool Register()
        {
            try
            {
                string name = Register_Name_Text.Text;
                string password = Register_Password_PasswordBox.Password;
                string repassword = Register_Repassword_PasswordBox.Password;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
