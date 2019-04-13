using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    /// <summary>
    /// 登录窗体
    /// </summary>
    public partial class LoginForm : Form
    {
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
            SQLHelper helper = new SQLHelper();//创建SQLHelp对象
            string sqlstr = "select Id from tb_Users";//SQL执行字符串
            DataTable dataTable = helper.reDt(sqlstr);//储存Datatable
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
            if (!validateNum.ToUpper().Equals(ValidateTextBox.Text.Trim()))
            {
                MessageBox.Show("验证码不正确");
                return false;
            }
            SQLHelper sqlHelper = new SQLHelper();
            //MD5加密密码
            string pwd = sqlHelper.GetMD5(PassWordtextBox.Text);
            //编写SQL语句
            string sqlstr = "SELECT * FROM tb_Users where Id='" + accountComboBox.Text + "' AND Password='" + pwd + "'";
            //将返回的结果保存在datatable中
            DataTable dataTable = sqlHelper.reDt(sqlstr);
            User t;//创建user对象
            if (dataTable.Rows.Count == 1)//如果返回一个结果
            {
                DataRow dr = dataTable.Rows[0];
                int userId = (int)dr["Id"];
                string name = dr["Name"].ToString();
                string password = dr["Password"].ToString();
                int Role = (int)dr["Role"];
                if (Role == 0)//未审核人员无法访问
                {
                    MessageBox.Show("注册未审核，请联系管理员");
                    return false;
                }
                else
                {
                    MainForm mainForm = null;
                    t = new User(userId, name, password, Role);//将用户信息保存到变量t中
                    if (Role == 3)
                    {
                        MessageBox.Show("欢迎你，管理员");
                        mainForm = new AdminForm(t);
                        mainForm.Text = mainForm.Text + ":管理员";
                    }
                    else if (Role == 2)
                    {
                        MessageBox.Show("老师你好，登陆成功");
                        mainForm = new TeacherForm(t);
                        mainForm.Text = mainForm.Text + ":老师";
                    }
                    else
                    {
                        MessageBox.Show("同学你好，登陆成功");
                        mainForm = new StudentForm(t);
                        mainForm.Text = mainForm.Text + ":学生";
                    }
                    mainForm.Show();
                    return true;
                }
            }
            else if (dataTable.Rows.Count > 1)//返回结果不止一个
            {
                MessageBox.Show("未知用户重复错误，请联系管理员");
                return false;
            }
            else//返回结果为0个
            {
                MessageBox.Show("用户名或密码不正确，请重新输入");
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
            //创建验证码实体类
            ValidateNum validateNum = new ValidateNum();
            this.validateNum = validateNum.CreateRandomNum(4);//获取验证码字符串
            ValidatePanel.BackgroundImage = validateNum.CreateImage(this.validateNum);//获取验证码图片
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
                PingOptions objPinOptions = new PingOptions();
                objPinOptions.DontFragment = true;
                string data = "";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int intTimeout = 300;
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
            if(IsOnLine())
            {
                DataListBind();
            }
        }
    }
}