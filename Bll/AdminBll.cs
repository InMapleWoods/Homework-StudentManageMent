using Dal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
namespace Bll
{
    /// <summary>
    /// 管理员用户层
    /// </summary>
    public class AdminBll
    {
        /// <summary>
        /// 数据操作对象
        /// </summary>
        readonly AdminDal adminDal = new AdminDal();
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
        /// 接收申请
        /// </summary>
        /// <param name="number">申请用户账号</param>
        /// <returns>成功与否</returns>
        public bool AcceptLog(string number)
        {
            bool result;
            try
            {
                Model.User user = new UserBll().GetUserLogin(number);
                result = adminDal.AcceptLog(user.UserID.ToString());
            }
            catch (Exception e) { Console.WriteLine(e.Message); throw e; }
            return result;
        }

        /// <summary>
        /// 拒绝申请
        /// </summary>
        /// <param name="number">申请用户账号</param>
        /// <returns>成功与否</returns>
        public bool RejectionLog(string number)
        {
            bool result;
            try
            {
                Model.User user = new UserBll().GetUserLogin(number);
                result = adminDal.RejectionLog(user.UserID.ToString());
            }
            catch (Exception e) { Console.WriteLine(e.Message); throw e; }
            return result;
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
                result = adminDal.DeleteUser(id);
            }
            catch (Exception e) { Console.WriteLine(e.Message); throw e; }
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
                    result = adminDal.GetPaperUsersStudent(index, size);
                }
                else if (choose == choose_Teacher)
                {
                    result = adminDal.GetPaperUsersTeacher(index, size);
                }
                else if (choose == choose_Unchecked)
                {
                    result = adminDal.GetPaperUsersWaitingToCheck(index, size);
                }
                else
                {
                    throw new Exception("choose选项不正确");
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); throw e; }
            return result;
        }

        /// <summary>
        /// 获取分页后的用户名单
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <param name="choose">分页选项</param>
        /// <returns>分页后名单</returns>
        public IEnumerable GetPaperUsersArray(int index, int size, int choose)
        {
            try
            {
                DataTable dataTable = GetPaperUsers(index, size, choose);
                if ((choose == choose_Student) || (choose == choose_Teacher))
                {
                    List<UserTempObject> temp = new List<UserTempObject>();
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        string Name = dr["昵称"].ToString();
                        string Number = dr["账号"].ToString();
                        UserTempObject t = new UserTempObject(Number, Name);
                        temp.Add(t);
                    }
                    return temp;
                }
                else if (choose == choose_Unchecked)
                {
                    List<WaitingCheckUser> temp = new List<WaitingCheckUser>();
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        string Name = dr["昵称"].ToString();
                        string Number = dr["账号"].ToString();
                        int WantToBe = (int)dr["申请角色"];
                        WaitingCheckUser t = new WaitingCheckUser(Number, Name, WantToBe);
                        temp.Add(t);
                    }
                    return temp;
                }
                else
                {
                    throw new Exception("choose选项不正确");
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); throw e; }
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
                    result = adminDal.GetAllPageNum_Student(size);
                }
                else if (choose == choose_Teacher)
                {
                    result = adminDal.GetAllPageNum_Teacher(size);
                }
                else if (choose == choose_Unchecked)
                {
                    result = adminDal.GetAllPageNumUnChecked(size);
                }
                else
                {
                    throw new Exception("choose选项不正确");
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); throw e; }
            return result;
        }
        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <param name="name">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="role">用户角色</param>
        /// <returns>增加成功与否</returns>
        public bool AddUser(string account, string name, string password, int role)
        {
            bool result;
            try
            {
                result = adminDal.AddUser(account, name, password, role);
            }
            catch (Exception e) { Console.WriteLine(e.Message); throw e; }
            return result;
        }

        /// <summary>
        /// 更改是否开启注册功能
        /// </summary>
        /// <returns>更改结果</returns>
        public string ReverseRegisterOpenState()
        {
            string result;
            try
            {
                result = adminDal.ReverseRegisterOpenState();
            }
            catch (Exception e) { Console.WriteLine(e.Message); throw e; }
            return result;
        }

        public class WaitingCheckUser
        {
            public string Name { get; set; }
            public string Number { get; set; }
            public int Role { get; set; }
            public WaitingCheckUser(string id, string name, int role)
            {
                Name = name;
                Number = id;
                Role = role;
            }
        }

        public class UserTempObject
        {
            public string Name { get; set; }
            public string Number { get; set; }
            public UserTempObject(string id, string name)
            {
                Name = name;
                Number = id;
            }

        }
    }
}
