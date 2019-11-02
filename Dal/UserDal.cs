using Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

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
        public string Role = "";

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
        public bool Login(string account, string password, out User user)
        {
            try
            {
                string matchPattern = @"(^\d{8,40}$)";
                Match resultGet = Regex.Match(account, matchPattern);
                if (resultGet.Groups.Count == 0)
                    throw new Exception("账号格式不正确");
            }
            catch
            {
                throw;
            }
            //MD5加密密码
            string pwd = helper.GetMD5(password);
            //编写SQL语句
            string sqlstr = "SELECT * FROM tb_Users where Number=@number AND Password=@password";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@number",account),
                new SqlParameter("@password",pwd)
            };
            //将返回的结果保存在datatable中
            using (DataTable dataTable = helper.ExcuteQuery(sqlstr, paras, CommandType.Text))
            {
                if (dataTable.Rows.Count == 1)//如果返回一个结果
                {
                    DataRow dr = dataTable.Rows[0];
                    int userId = (int)dr["Id"];
                    string name = dr["Name"].ToString();
                    string psw = dr["Password"].ToString();
                    int Role = (int)dr["Role"];
                    string Number = dr["Number"].ToString();
                    if (Role == 0)//未审核人员无法访问
                    {
                        throw new Exception("注册未审核，请联系管理员");
                    }
                    else
                    {
                        t = new User(userId, name, psw, Role, Number);//将用户信息保存到变量t中
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
                        user = t;
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
        }

        /// <summary>
        /// 获取账号对应的用户
        /// </summary>
        /// <param name="account">账号</param>
        /// <returns>用户</returns>
        public User GetUserLogin(string account, out User user)
        {
            try
            {
                string matchPattern = @"(^\d{8,40}$)";
                Match resultGet = Regex.Match(account, matchPattern);
                if (resultGet.Groups.Count == 0)
                    throw new Exception("账号格式不正确");
            }
            catch
            {
                throw;
            }
            //编写SQL语句
            string sqlstr = "SELECT * FROM tb_Users where Number=@number";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@number",account),
            };
            //将返回的结果保存在datatable中
            using (DataTable dataTable = helper.ExcuteQuery(sqlstr, paras, CommandType.Text))
            {
                if (dataTable.Rows.Count == 1)//如果返回一个结果
                {
                    DataRow dr = dataTable.Rows[0];
                    int userId = (int)dr["Id"];
                    string name = dr["Name"].ToString();
                    string psw = dr["Password"].ToString();
                    int Role = (int)dr["Role"];
                    string Number = dr["Number"].ToString();
                    t = new User(userId, name, psw, Role, Number);//将用户信息保存到变量t中
                    user = t;
                    return t;
                }
                else if (dataTable.Rows.Count > 1)//返回结果不止一个
                {
                    throw new Exception("未知用户重复错误，请联系管理员");
                }
                else//返回结果为0个
                {
                    user = t;
                    return null;
                }
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
            string sqlstr = "SELECT * FROM tb_Users where Name=@userName";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@userName",userName),
            };
            //将返回的结果保存在datatable中
            using (DataTable dataTable = helper.ExcuteQuery(sqlstr, paras, CommandType.Text))
            {
                if (dataTable.Rows.Count >= 1)//返回结果不止一个
                {
                    return false;
                }
                else//返回结果为0个
                {
                    return true;
                }
            }
        }


        /// <summary>
        /// 注册操作
        /// </summary>
        /// <param name="name">昵称</param>
        /// <param name="password">密码</param>
        /// <param name="repeatpwd">重复密码</param>
        /// <param name="accountResult">注册账号结果</param>
        /// <param name="role">角色</param>
        /// <returns>是否成功注册</returns>
        public bool Register(string name, string password, string repeatpwd, out string accountResult, out User user, int role = -1)
        {
            if (password == null)
            {
                accountResult = "";
                user = new User();
                return false;
            }
            //未审核注册统一将其角色赋值为0（未审核）
            int Role = 0;
            if (!password.Equals(repeatpwd, StringComparison.CurrentCulture))
            {
                throw new Exception("两次密码不一致");
            }
            if (role == -1)//获取不到身份选择结果或未选择身份
            {
                throw new Exception("未选择身份");
            }
            int numid = helper.sqlNum("tb_Users");//获取表中数据条数
            string account = helper.sqlMaxID("Number", "tb_Users").ToString().PadLeft(8, '0');//获取用户编号
            accountResult = account;
            if (numid == 0)//如果是第一个注册默认成为管理员
            {
                Role = 3;
            }
            //向User表中插入数据
            string sqlStr = "Register";
            //储存Datatable
            SqlParameter[] para = new SqlParameter[]//存储相应参数的容器
            {
                new SqlParameter("returnValue",SqlDbType.Int,4),
                new SqlParameter("@name",name),
                new SqlParameter("@passWord",helper.GetMD5(password)),
                new SqlParameter("@repeatpwd",helper.GetMD5(repeatpwd)),
                new SqlParameter("@role",role),
            };
            para[0].Direction = ParameterDirection.ReturnValue;
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.StoredProcedure);
            int result = (int)para[0].Value;
            switch (result)
            {
                case -3:
                    {
                        throw new Exception("两次密码不一致");
                    }
                case -2:
                    {
                        throw new Exception("注册功能被关闭");
                    }
            }
            t = new User(helper.sqlMaxID("Id", "tb_Users"), name, password, Role, account);//将用户信息保存到变量t中
            user = t;
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
        /// 获取注册者账号
        /// </summary>
        /// <returns>注册者账号</returns>
        public string GetRegisterAccount(out User user)
        {
            user = t;
            t = t == null ? new User() : t;
            return t.Number;
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
        public bool ChangedName(string id, string changedName, out User user)
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
                user = t;
                t = t == null ? new User() : t;
                t.UserName = changedName;
                return true;
            }
            else
            {
                user = t;
                return false;
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="opwd">旧密码</param>
        /// <param name="npwd">新密码</param>
        /// <param name="id">用户Id</param>
        /// <returns>成功与否</returns>
        public bool ChangePassword(string opwd, string npwd,string id, out User user)
        {
            string sqlStr = "update tb_Users set Password=@password where Id=@Id";
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@password",helper.GetMD5(npwd)),
                new SqlParameter("@Id",id),
             };
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.Text);
            if (count > 0)
            {
                user = t;
                t = t == null ? new User() : t;
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