using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using Model;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bll;

namespace StudentsManagement_winForm
{
    /// <summary>
    /// 登录窗体
    /// </summary>
    public partial class LoginForm : Form
    {
        /// <summary>
        /// 用户操作对象
        /// </summary>
        public UserBll userBll = new UserBll();
        /// <summary>
        /// 登录失败次数
        /// </summary>
        int falseCount = 0;
        /// <summary>
        /// 验证码字符串
        /// </summary>
        string validateNum = "";

        /// <summary>
        /// 登录窗体构造函数
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登录窗体加载时执行
        /// </summary>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (IsOnLine())//判断是否联网
                DataListBind();
            else
                MessageBox.Show("未联网");
        }

        /// <summary>
        /// 绑定数据源
        /// </summary>
        public void DataListBind()
        {
            DataTable dataTable = userBll.GetAllUser();
            string[] accounts = new string[dataTable.Rows.Count];
            for (int i = 0; i < accounts.Length; i++)
            {
                accounts[i] = dataTable.Rows[i]["Id"].ToString().PadLeft(8, '0');
            }
            accountComboBox.DataSource = accounts;//设置数据源，用于填充控件
        }

        /// <summary>
        /// 注册按钮点击事件
        /// </summary>
        private void RegisterLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(this);
            registerForm.Show();
            this.Hide();
        }

        /// <summary>
        /// 取消按钮点击事件
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// 登录按钮点击事件
        /// </summary>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (IsOnLine())
            {
                if (!IsSuccess())
                {
                    falseCount++;//登录错误次数增加
                }
                else
                {
                    this.Hide();//登陆成功后隐藏登录窗口
                }
                if (falseCount >= 5)
                {
                    ValidateNumShow();//5次登录失败后显示验证码
                }
            }
            else
                MessageBox.Show("未联网");
        }

        /// <summary>
        /// 登录尝试
        /// </summary>
        /// <returns>登录成功与否</returns>
        private bool IsSuccess()
        {
            string account = accountComboBox.Text;
            string password = PassWordtextBox.Text;
            string validate = ValidateTextBox.Text.ToUpper().Trim();
            try
            {
                if (userBll.Login(account, password))
                {
                    MessageBox.Show("登录成功，欢迎你：" + userBll.Role);
                    MainForm mainForm;
                    if (userBll.Role == "管理员")
                    {
                        mainForm = new AdminForm(userBll.t);
                    }
                    else if (userBll.Role == "老师")
                    {
                        mainForm = new TeacherForm(userBll.t);
                    }
                    else
                    {
                        mainForm = new StudentForm(userBll.t);
                    }
                    mainForm.Text += ":"+ userBll.Role;
                    mainForm.Show();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                return false;
            }
        }
        /// <summary>
        /// 验证码显示事件
        /// </summary>
        private void ValidateNumShow()
        {
            if (ValidatePanel.Visible == false)//如果验证码未显示
            {
                //调整登录按钮和取消按钮的位置
                LoginButton.Location = new Point(LoginButton.Location.X, LoginButton.Location.Y + 40);
                cancelButton.Location = new Point(cancelButton.Location.X, cancelButton.Location.Y + 40);
            }
            ValidatePanel.BackgroundImage = userBll.GetValidate(4);//获取验证码图片            
            validateNum = userBll.validateNum;//获取验证码字符串
            #region 显示验证码相关控件
            ValidatePanel.Visible = true;
            ValidateTextBox.Visible = true;
            ValidateLabel.Visible = true;
            #endregion
        }

        /// <summary>
        /// 获取按键
        /// </summary>
        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)//如果按下回车键
                LoginButton.Focus();//登录按钮获取焦点
        }

        /// <summary>
        /// 判断是否联网
        /// </summary>
        /// <returns>是否联网</returns>
        private bool IsOnLine()
        {
            try
            {
                Ping objPingSender = new Ping();
                PingOptions objPinOptions = new PingOptions
                {
                    DontFragment = true
                };
                string data = "";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int intTimeout = 1000;
                PingReply objPinReply = objPingSender.Send("152.136.73.240", intTimeout, buffer, objPinOptions);
                string strInfo = objPinReply.Status.ToString();
                if (strInfo == "Success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 显示下拉菜单时发生
        /// </summary>
        private void accountComboBox_DropDown(object sender, EventArgs e)
        {
            if (IsOnLine())
            {
                DataListBind();
            }
        }
    }
}