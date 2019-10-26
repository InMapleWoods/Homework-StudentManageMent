using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace Bll
{
    /// <summary>
    /// 用户访问类
    /// </summary>
    public class UserBll
    {
        /// <summary>
        /// 数据操作对象
        /// </summary>
        readonly UserDal userDal = new UserDal();
        /// <summary>
        /// 登录用户
        /// </summary>
        public User t = null;
        /// <summary>
        /// 登录角色
        /// </summary>
        public string Role = null;


        /// <summary>
        /// 登录操作
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns>登录成功与否</returns>
        public bool Login(string account, string password)
        {
            account = account == null ? "" : account;
            password = password == null ? "" : password;
            bool result;
            try
            {
                result = userDal.Login(account, password, out t);
                t = userDal.t;
                Role = userDal.Role;
            }
            catch (Exception e) { throw e; }
            return result;
        }


        /// <summary>
        /// 获取账号对应的用户
        /// </summary>
        /// <param name="account">账号</param>
        /// <returns>用户</returns>
        public User GetUserLogin(string account)
        {
            account = account == null ? "" : account;
            User result;
            try
            {
                result = userDal.GetUserLogin(account, out t);
                t = userDal.t;
                Role = userDal.Role;
            }
            catch (Exception e) { throw e; }
            return result;
        }

        /// <summary>
        /// 用户名是否存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>是否存在</returns>
        public bool UserNameCheck(string userName)
        {
            bool result;
            try
            {
                result = userDal.UserNameCheck(userName);
            }
            catch (Exception e) { throw e; }
            return result;
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
        public bool Register(string name, string password, string repeatpwd, out string accountResult, int role = -1)
        {
            name = name == null ? "" : name;
            password = password == null ? "" : password;
            repeatpwd = repeatpwd == null ? "" : repeatpwd;
            bool result;
            try
            {
                result = userDal.Register(name, password, repeatpwd, out accountResult, out t, role);
                t = userDal.t;
                Role = userDal.Role;
            }
            catch (Exception e) { throw e; }
            return result;
        }
        /// <summary>
        /// 获取注册者Id
        /// </summary>
        /// <returns>注册者ID</returns>
        public int GetRegisterId()
        {
            int result;
            try
            {
                result = userDal.GetRegisterId();
            }
            catch (Exception e) { throw e; }
            return result;
        }


        /// <summary>
        /// 获取注册者账号
        /// </summary>
        /// <returns>注册者账号</returns>
        public string GetRegisterAccount()
        {
            string result;
            try
            {
                result = userDal.GetRegisterAccount();
            }
            catch (Exception e) { throw e; }
            return result;
        }


        /// <summary>
        /// 获取全部用户
        /// </summary>
        /// <returns>用户表</returns>
        public DataTable GetAllUser()
        {
            try
            {
                return userDal.GetAllUser();
            }
            catch
            {
                throw new Exception("获取全部用户失败");
            }
        }
        /// <summary>
        /// 获取全部用户
        /// </summary>
        /// <returns>用户表</returns>
        public List<User> GetAllUserArray()
        {
            List<User> temp = null;
            try
            {
                DataTable dataTable = userDal.GetAllUser();
                temp = new List<User>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    int Id = (int)dr["Id"];
                    string Name = dr["Name"].ToString();
                    string Password = dr["Password"].ToString();
                    int Role = (int)dr["Role"];
                    string Number = dr["Number"].ToString();
                    User t = new User(Id, Name, Password, Role, Number);
                    temp.Add(t);
                }
                return temp;
            }
            catch
            {
                throw new Exception("获取全部用户失败");
            }
        }

        /// <summary>
        /// 修改昵称
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="changedName">要修改的昵称</param>
        /// <returns>成功与否</returns>
        public bool ChangedName(string id, string changedName)
        {
            bool result;
            try
            {
                result = userDal.ChangedName(id, changedName);
            }
            catch (Exception e) { throw e; }
            return result;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="opwd">旧密码</param>
        /// <param name="npwd">新密码</param>
        /// <returns>成功与否</returns>
        public bool ChangePassword(string opwd, string npwd)
        {
            bool result;
            try
            {
                result = userDal.ChangePassword(opwd, npwd);
            }
            catch (Exception e) { throw e; }
            return result;
        }

    }
}