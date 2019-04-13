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
            //未审核注册统一将其角色赋值为0（未审核）
            int Role = 0;
            if (!password.Equals(repeatpwd))
            {
                MessageBox.Show("两次密码不一致");
                return false;
            }
            object o = RoleComboBox.SelectedItem;
            if (o == null)//获取不到身份选择结果或未选择身份
            {
                MessageBox.Show("未选择身份");
                RoleComboBox.Focus();//身份选择控件获得焦点
                return false;
            }
            SQLHelper sqlHelper = new SQLHelper();
            int numid = 0;
            numid = sqlHelper.sqlNum("tb_Users");//获取表中数据条数
            string id = numid.ToString().PadLeft(8, '0');//将ID补全为8位
            if (numid == 0)//如果是第一个注册默认成为管理员
            {
                Role = 3;
            }
            else//否则将其希望成为的角色发送到Log表等待审核
            {
                string sqlStr1 = "INSERT INTO tb_Log(Time,UserId,WantToBe,Name) VALUES(@time,@id,@role,@name)";
                //储存Datatable
                SqlParameter[] para1 = new SqlParameter[]//存储相应参数的容器
                {
                new SqlParameter("@time",DateTime.Now),
                new SqlParameter("@id",id),
                new SqlParameter("@name",name),
                new SqlParameter("@role",RoleComboBox.SelectedIndex+1),
                };
                sqlHelper.ExecuteNonQuery(sqlStr1, para1, CommandType.Text);
            }
            //向User表中插入数据
            string sqlStr = "INSERT INTO tb_Users(Id,Name,Password,Role) VALUES(@id,@name,@password,@role)";
            //储存Datatable
            SqlParameter[] para = new SqlParameter[]//存储相应参数的容器
            {
                new SqlParameter("@id",id),
                new SqlParameter("@name",name),
                new SqlParameter("@passWord",sqlHelper.GetMD5(password)),
                new SqlParameter("@role",Role),
            };
            int count = 0;
            try
            {
                count = sqlHelper.ExecuteNonQuery(sqlStr, para, CommandType.Text);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            if (count > 0)
            {
                login.DataListBind();
                MessageBox.Show("注册成功");
                MessageBox.Show(id + "为你的登录唯一标识请牢记");
                return true;
            }
            return false;
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