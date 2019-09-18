﻿using Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Dal
{
    /// <summary>
    /// 用户访问类
    /// </summary>
    public class UserDal
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        static readonly string sqlConnect = "server=152.136.73.240;database=db_StudentManage;uid=Lsa;pwd=llfllf";

        /// <summary>
        /// 登录用户
        /// </summary>
        public User t = null;
        
        /// <summary>
        /// 登录角色
        /// </summary>
        public string Role = null;

        /// <summary>
        /// SQL帮助类
        /// </summary>
        readonly SQLHelper helper = new SQLHelper(sqlConnect);

        /// <summary>
        /// 登录操作
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <param name="validate">验证码</param>
        /// <returns>登录成功与否</returns>
        public bool Login(string account, string password)
        {
            return LoginSystem(account, password);
        }

        public bool LoginSystem(string id, string password)
        {
            try
            {
                int _id = Int32.Parse(id);
            }
            catch
            {
                throw new Exception("账号格式不正确");
            }
            //MD5加密密码
            string pwd = helper.GetMD5(password);
            //编写SQL语句
            string sqlstr = "SELECT * FROM tb_Users where Id='" + id + "' AND Password='" + pwd + "'";
            //将返回的结果保存在datatable中
            System.Data.DataTable dataTable = helper.reDt(sqlstr);
            if (dataTable.Rows.Count == 1)//如果返回一个结果
            {
                DataRow dr = dataTable.Rows[0];
                int userId = (int)dr["Id"];
                string name = dr["Name"].ToString();
                string psw = dr["Password"].ToString();
                int Role = (int)dr["Role"];
                if (Role == 0)//未审核人员无法访问
                {
                    throw new Exception("注册未审核，请联系管理员");
                }
                else
                {
                    t = new User(userId, name, psw, Role);//将用户信息保存到变量t中
                    if (Role == 3)
                    {
                        this.Role = "管理员";
                    }
                    else if (Role == 2)
                    {
                        this.Role = "老师";
                    }
                    else
                    {
                        this.Role = "学生";
                    }
                    return true;
                }
            }
            else if (dataTable.Rows.Count > 1)//返回结果不止一个
            {
                throw new Exception("未知用户重复错误，请联系管理员");
            }
            else//返回结果为0个
            {
                throw new Exception("用户名或密码不正确，请重新输入");
            }
        }

        /// <summary>
        /// 获取账号对应的用户
        /// </summary>
        /// <param name="account">账号</param>
        /// <returns>用户</returns>
        public User GetUserLogin(string account)
        {
            try
            {
                int _id = Int32.Parse(account);
            }
            catch
            {
                throw new Exception("账号格式不正确");
            }
            //编写SQL语句
            string sqlstr = "SELECT * FROM tb_Users where Id='" + account + "'";
            //将返回的结果保存在datatable中
            System.Data.DataTable dataTable = helper.reDt(sqlstr);
            if (dataTable.Rows.Count == 1)//如果返回一个结果
            {
                DataRow dr = dataTable.Rows[0];
                int userId = (int)dr["Id"];
                string name = dr["Name"].ToString();
                string psw = dr["Password"].ToString();
                int Role = (int)dr["Role"];
                t = new User(userId, name, psw, Role);//将用户信息保存到变量t中
                return t;
            }
            else if (dataTable.Rows.Count > 1)//返回结果不止一个
            {
                throw new Exception("未知用户重复错误，请联系管理员");
            }
            else//返回结果为0个
            {
                return null;
            }
        }

        /// <summary>
        /// 用户名是否存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>是否存在</returns>
        public bool UserNameCheck(string userName)
        {
            //编写SQL语句
            string sqlstr = "SELECT * FROM tb_Users where Name='" + userName + "'";
            //将返回的结果保存在datatable中
            System.Data.DataTable dataTable = helper.reDt(sqlstr);
            if (dataTable.Rows.Count >= 1)//返回结果不止一个
            {
                return false;
            }
            else//返回结果为0个
            {
                return true;
            }
        }


        /// <summary>
        /// 注册操作
        /// </summary>
        /// <param name="name">昵称</param>
        /// <param name="password">密码</param>
        /// <param name="repeatpwd">重复密码</param>
        /// <returns>是否成功注册</returns>
        public bool Register(string name, string password, string repeatpwd, int role = -1)
        {
            //未审核注册统一将其角色赋值为0（未审核）
            int Role = 0;
            if (!password.Equals(repeatpwd))
            {
                throw new Exception("两次密码不一致");
            }
            if (role == -1)//获取不到身份选择结果或未选择身份
            {
                throw new Exception("未选择身份");
            }
            int numid = helper.sqlNum("tb_Users");//获取表中数据条数
            string id = helper.sqlMaxID("Id", "tb_Users").ToString().PadLeft(8, '0');//将ID补全为8位
            t = new User(helper.sqlMaxID("Id", "tb_Users"), name, password, Role);//将用户信息保存到变量t中
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
                new SqlParameter("@role",role),
                };
                helper.ExecuteNonQuery(sqlStr1, para1, CommandType.Text);
            }
            //向User表中插入数据
            string sqlStr = "INSERT INTO tb_Users(Id,Name,Password,Role) VALUES(@id,@name,@password,@role)";
            //储存Datatable
            SqlParameter[] para = new SqlParameter[]//存储相应参数的容器
            {
                new SqlParameter("@id",id),
                new SqlParameter("@name",name),
                new SqlParameter("@passWord",helper.GetMD5(password)),
                new SqlParameter("@role",Role),
            };
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.Text);
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取注册者Id
        /// </summary>
        /// <returns>注册者ID</returns>
        public int GetRegisterId()
        {
            return helper.sqlMaxID("Id", "tb_Users") - 1;
        }

        /// <summary>
        /// 获取全部用户
        /// </summary>
        /// <returns>用户表</returns>
        public DataTable GetAllUser()
        {            
            string sqlstr = "select * from tb_Users";//SQL执行字符串
            DataTable dataTable = helper.reDt(sqlstr);//储存Datatable
            return dataTable;
        }

        /// <summary>
        /// 修改昵称
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="changedName">要修改的昵称</param>
        /// <returns>成功与否</returns>
        public bool ChangedName(string id, string changedName)
        {
            string sqlStr = "update tb_Users set Name=@name where Id=@Id";
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@name",changedName),
                new SqlParameter("@Id",id),
             };
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.Text);
            if (count > 0)
            {
                t.UserName = changedName;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="opwd">旧密码</param>
        /// <param name="npwd">新密码</param>
        /// <returns>成功与否</returns>
        public bool ChangePassword(string opwd, string npwd)
        {
            if (!t.PassWord.Equals(helper.GetMD5(opwd)))
            {
                throw new Exception("旧密码不正确");
            }
            string sqlStr = "update tb_Users set Password=@password where Id=@Id";
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@password",helper.GetMD5(npwd)),
                new SqlParameter("@Id",t.UserID),
             };
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.Text);
            if (count > 0)
            {
                t.PassWord = helper.GetMD5(npwd);
                return true;
            }
            else
            {
                throw new Exception("修改失败");
            }
        }

    }
}