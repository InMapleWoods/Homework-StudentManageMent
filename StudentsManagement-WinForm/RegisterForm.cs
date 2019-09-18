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

namespace StudentsManagement_winForm
{
    /// <summary>
    /// 注册窗体
    /// </summary>
    public partial class RegisterForm : Form
    {
        /// <summary>
        /// 登录窗体
        /// </summary>
        LoginForm login = null;

        /// <summary>
        /// 注册窗体构造函数
        /// </summary>
        public RegisterForm(LoginForm login)
        {
            InitializeComponent();
            this.login = login;
        }

        /// <summary>
        /// 注册按钮点击事件
        /// </summary>
        private void Registerbutton_Click(object sender, EventArgs e)
        {
            string name = accountTextBox.Text;
            string password = PassWordtextBox.Text;
            string repeatpwd = RepeatTextBox.Text;
            if (IsSuccess(name, password, repeatpwd))
            {
                login.Show();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("注册失败");
            }
        }

        /// <summary>
        /// 取消按钮点击事件
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Dispose();
        }

        /// <summary>
        /// 注册函数
        /// </summary>
        /// <param name="name">昵称</param>
        /// <param name="password">密码</param>
        /// <param name="repeatpwd">重复密码</param>
        /// <returns>是否成功注册</returns>
        private bool IsSuccess(string name, string password, string repeatpwd)
        {
            string id;
            int role;
            if (RoleComboBox.SelectedItem == null)//获取不到身份选择结果或未选择身份
            {
                role = -1;
            }
            else
            {
                role = RoleComboBox.SelectedIndex + 1;
            }
            try
            {
                if (login.userBll.Register(name, password, repeatpwd, role))
                {
                    id = login.userBll.GetRegisterId().ToString().PadLeft(8, '0'); ;//将ID补全为8位
                    login.DataListBind();
                    MessageBox.Show("注册成功");
                    MessageBox.Show(id + "为你的登录唯一标识请牢记");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                if (e.Message == "两次密码不一致")
                {
                    MessageBox.Show("两次密码不一致");
                }
                else if (e.Message == "未选择身份")//获取不到身份选择结果或未选择身份
                {
                    MessageBox.Show("未选择身份");
                    RoleComboBox.Focus();//身份选择控件获得焦点
                }
                return false;
            }
        }

        /// <summary>
        /// 获取按键
        /// </summary>
        private void RegisterForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)//如果按下回车键
                Registerbutton.Focus();//登录按钮获取焦点
        }
        
        /// <summary>
        /// 获取按键
        /// </summary>
        private void RepeatTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)//如果按下回车键
                RoleComboBox.Focus();//角色选择下拉列表获取焦点
        }
    }
}