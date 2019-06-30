using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using Dal;
using Model;

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
        UserDal userDal = new UserDal();
        /// <summary>
        /// 登录用户
        /// </summary>
        public User t = null;
        /// <summary>
        /// 验证码图片
        /// </summary>
        public Bitmap validatePicture = null;
        /// <summary>
        /// 验证码
        /// </summary>
        public string validateNum = "";
        /// <summary>
        /// 登录角色
        /// </summary>
        public string Role = null;
        /// <summary>
        /// 表单选择教师
        /// </summary>
        static public int choose_Teacher = 0x001;
        /// <summary>
        /// 表单选择学生
        /// </summary>
        static public int choose_Student = 0x002;
        /// <summary>
        /// 表单选择未审核
        /// </summary>
        static public int choose_Unchecked = 0x003;
        /// <summary>
        /// 获取User
        /// </summary>
        /// <returns>用户对象</returns>
        public User GetUser()
        {
            return (User)userDal.GetUser();
        }
        /// <summary>
        /// 设置User
        /// </summary>
        /// <param name="user">用户对象</param>
        public void SetUser(User user)
        {
            try
            {
                userDal.SetUser(user);
            }
            catch { }
        }
        /// <summary>
        /// 获得n位验证码
        /// </summary>
        /// <param name="num">验证码位数</param>
        /// <returns>返回num位的验证码图片</returns>
        public Bitmap GetValidate(int num)
        {
            Bitmap result;
            try
            {
                result = userDal.GetValidate(num);
                validateNum = userDal.validateNum;
                validatePicture = userDal.validatePicture;
            }
            catch (Exception e) { throw e; }
            return result;
        }
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns>验证码</returns>
        public string GetValidateNum()
        {
            string result;
            try
            {
                result = userDal.GetValidateNum();
                validateNum = userDal.validateNum;
                validatePicture = userDal.validatePicture;
            }
            catch (Exception e) { throw e; }
            return result;
        }
        /// <summary>
        /// 获取验证码图片
        /// </summary>
        /// <param name="validate">验证码</param>
        /// <returns>验证码图片</returns>
        public Bitmap GetValidatePicture(string validate)
        {
            Bitmap result;
            try
            {
                result = userDal.CreateImage(validate);
                validateNum = userDal.validateNum;
                validatePicture = userDal.validatePicture;
            }
            catch (Exception e) { throw e; }
            return result;
        }
        /// <summary>
        /// 获取验证码图片
        /// </summary>
        /// <returns>验证码图片</returns>
        public Bitmap GetValidatePicture()
        {
            Bitmap result;
            try
            {
                result = userDal.GetValidatePicture();
                validateNum = userDal.validateNum;
                validatePicture = userDal.validatePicture;
            }
            catch (Exception e) { throw e; }
            return result;
        }
        /// <summary>
        /// 更换验证码
        /// </summary>
        /// <returns>更换验证码成功与否</returns>
        public bool ChangeValidate()
        {
            bool result;
            try
            {
                result = userDal.ChangeValidate();
                validateNum = userDal.validateNum;
                validatePicture = userDal.validatePicture;
            }
            catch (Exception e) { throw e; }
            return result;
        }
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
                result = userDal.Login(account, password);
                t = userDal.t;
                Role = userDal.Role;
                validateNum = userDal.GetValidateNum();
            }
            catch (Exception e) { throw e; }
            return result;
        }


        /// <summary>
        /// 获取账号密码对应的用户
        /// </summary>
        /// <param name="account">账号</param>
        /// <returns>用户</returns>
        public User GetUserLogin(string account)
        {
            account = account == null ? "" : account;
            User result;
            try
            {
                result = userDal.GetUserLogin(account);
                t = userDal.t;
                Role = userDal.Role;
                validateNum = userDal.validateNum;
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
        /// <returns>是否成功注册</returns>
        public bool Register(string name, string password, string repeatpwd, int role = -1)
        {
            name = name == null ? "" : name;
            password = password == null ? "" : password;
            repeatpwd = repeatpwd == null ? "" : repeatpwd;
            bool result;
            try
            {
                result = userDal.Register(name, password, repeatpwd, role);
                t = userDal.t;
                Role = userDal.Role;
                validateNum = userDal.validateNum;
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
        /// 接收申请
        /// </summary>
        /// <param name="id">申请用户ID</param>
        /// <param name="tobe">申请角色</param>
        /// <returns>成功与否</returns>
        public bool AcceptLog(string id, string tobe)
        {
            bool result;
            try
            {
                result = userDal.AcceptLog(id, tobe);
            }
            catch (Exception e) { throw e; }
            return result;
        }

        /// <summary>
        /// 拒绝申请
        /// </summary>
        /// <param name="id">申请用户ID</param>
        /// <returns>成功与否</returns>
        public bool RejectionLog(string id)
        {
            bool result;
            try
            {
                result = userDal.RejectionLog(id);
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
                    User t = new User(Id, Name, Password, Role);
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
        /// 删除用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>成功与否</returns>
        public bool DeleteUser(string id)
        {
            bool result;
            try
            {
                result = userDal.DeleteUser(id);
            }
            catch (Exception e) { throw e; }
            return result;
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
        /// <summary>
        /// 获取分页后的用户名单
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <param name="choose">分页选项</param>
        /// <returns>分页后名单</returns>
        public DataTable GetPaperUsers(int index, int size, int choose)
        {
            DataTable result;
            try
            {
                if (choose == choose_Student)
                {
                    result = userDal.GetPaperUsers_Student(index, size);
                }
                else if (choose == choose_Teacher)
                {
                    result = userDal.GetPaperUsers_Teacher(index, size);
                }
                else if (choose == choose_Unchecked)
                {
                    result = userDal.GetPaperUsers_Check(index, size);
                }
                else
                {
                    throw new Exception("choose选项不正确");
                }
            }
            catch (Exception e) { throw e; }
            return result;
        }

        /// <summary>
        /// 获取分页后的用户名单
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <param name="choose">分页选项</param>
        /// <returns>分页后名单</returns>
        public List<User> GetPaperUsersArray(int index, int size, int choose)
        {
            List<User> temp = null;
            try
            {
                DataTable dataTable = GetPaperUsers(index, size, choose);
                temp = new List<User>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    int Id = (int)dr["Id"];
                    string Name = dr["Name"].ToString();
                    string Password = dr["Password"].ToString();
                    int Role = (int)dr["Role"];
                    User t = new User(Id, Name, Password, Role);
                    temp.Add(t);
                }
                return temp;
            }
            catch (Exception e) { throw e; }
        }
        /// <summary>
        /// 获取未审核用户分页总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <param name="choose">分页选项</param>
        /// <returns>分页数</returns>
        public int GetAllPageNum(int size, int choose)
        {
            int result;
            try
            {
                if (choose == choose_Student)
                {
                    result = userDal.GetAllPageNum_Student(size);
                }
                else if (choose == choose_Teacher)
                {
                    result = userDal.GetAllPageNum_Teacher(size);
                }
                else if (choose == choose_Unchecked)
                {
                    result = userDal.GetAllPageNum_UnChecked(size);
                }
                else
                {
                    throw new Exception("choose选项不正确");
                }
            }
            catch (Exception e) { throw e; }
            return result;
        }
    }
}