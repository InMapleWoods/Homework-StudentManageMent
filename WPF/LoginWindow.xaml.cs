using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Model;

namespace WPF
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        /// <summary>
        /// 登录失败次数
        /// </summary>
        private int countFailed = 0;

        /// <summary>
        /// 窗体构造函数
        /// </summary>
        public LoginWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            #region 自定义事件绑定
            MouseLeftButtonDown += new MouseButtonEventHandler((sender, e)=>{DragMove();});
            #endregion
        }

        #region 验证码
        /// <summary>
        /// 验证码对象
        /// </summary>
        private Captcha captcha = new Captcha();

        /// <summary>
        /// 验证码显示位置变化
        /// </summary>
        private void ShowValidate()
        {
            LoginBtn.Margin = new Thickness(135, 160, 0, 0);
            CancelBtn.Margin = new Thickness(280, 160, 0, 0);
            ValidateImg.Visibility = Visibility.Visible;
            ValidateLabel.Visibility = Visibility.Visible;
            ValidateText.Visibility = Visibility.Visible;
            GetCaptcha();
        }

        /// <summary>
        /// 获取新验证码
        /// </summary>
        private void GetCaptcha()
        {
            byte[] captchaBtyes = captcha.GetValidateBytes(4);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = new MemoryStream(captchaBtyes);
            image.EndInit();
            ValidateImg.Source = image;
        }

        /// <summary>
        /// 验证码点击后刷新
        /// </summary>
        private void ValidateImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GetCaptcha();
        }
        #endregion
        
        #region 登录
        /// <summary>
        /// 登录按钮点击事件
        /// </summary>
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!Login())
                {
                    countFailed++;
                }
                if (countFailed >= 5)
                {
                    ShowValidate();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("登录失败"+ex.Message);
            }
        }

        /// <summary>
        /// 登录事件
        /// </summary>
        /// <returns>登录成功与否</returns>
        private bool Login()
        {
            return false;
        }
        #endregion

        #region 注册
        /// <summary>
        /// 注册按钮点击事件
        /// </summary>
        private void RegisterLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Register();
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <returns>注册结果</returns>
        private void Register()
        {
            RegisterWindow registerWindow = new RegisterWindow(this);
            Hide();
            registerWindow.Show();
            registerWindow.Focus();
        }
        #endregion

        #region 注册标签鼠标事件
        /// <summary>
        /// 注册标签鼠标进入
        /// </summary>
        private void RegisterLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            RegisterLabel.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(110, 110, 110));
            RegisterLabel.FontSize = 12.3;
        }

        /// <summary>
        /// 注册标签鼠标移出
        /// </summary>
        private void RegisterLabel_MouseLeave(object sender, MouseEventArgs e)
        {
            RegisterLabel.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(153, 153, 153));
            RegisterLabel.FontSize = 12;
        }
        #endregion

        /// <summary>
        /// 取消按钮点击事件
        /// </summary>
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}