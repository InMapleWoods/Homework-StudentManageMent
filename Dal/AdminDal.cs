using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    /// <summary>
    /// 管理员数据层
    /// </summary>
    public class AdminDal
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        const string sqlConnect = "server=152.136.73.240;database=db_StudentManage;uid=Lsa;pwd=llfllf";

        /// <summary>
        /// SQL帮助类
        /// </summary>
        SQLHelper helper = new SQLHelper(sqlConnect);

        /// <summary>
        /// 接收申请
        /// </summary>
        /// <param name="id">申请用户ID</param>
        /// <param name="tobe">申请角色</param>
        /// <returns>成功与否</returns>
        public bool AcceptLog(string id, string tobe)
        {
            string sqlStr = "update tb_Log set IsChecked=@isChecked where UserId=@userId;  " +
                "update tb_Users set Role=@tobe where Id=@userId;";
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@isChecked",true),
                new SqlParameter("@tobe",tobe),
                new SqlParameter("@userId",id)
             };
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.Text);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 拒绝申请
        /// </summary>
        /// <param name="id">申请用户ID</param>
        /// <returns>成功与否</returns>
        public bool RejectionLog(string id)
        {
            string sqlStr = "update tb_Log set IsChecked=@isChecked where UserId=@userId  " +
                "update tb_Users set Role=0 where Id=@userId;";
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@isChecked",true),
                new SqlParameter("@userId",id)
             };
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.Text);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>成功与否</returns>
        public bool DeleteUser(string id)
        {
            string sqlStr = "delete from tb_Users where Id=@Id";
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@Id",id)
             };
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.Text);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取分页后的未审核用户名单
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <returns>分页后名单</returns>
        public DataTable GetPaperUsersWaitingToCheck(int index, int size)
        {
            string sqlstr = "select dbo.PadLeft(UserId,8,'0') 账号,Name 昵称,WantToBe 申请角色 from tb_Log where IsChecked=0 order by Id offset ((" + (index - 1) + ")*" + size + ") rows fetch next " + size + " rows only";//SQL执行字符串
            DataTable dataTable = helper.reDt(sqlstr);//储存Datatable
            return dataTable;
        }


        /// <summary>
        /// 获取分页后的学生名单
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <returns>分页后名单</returns>
        public DataTable GetPaperUsersStudent(int index, int size)
        {
            string sqlstr = "select dbo.PadLeft(Id,8,'0') 账号,Name 昵称 from tb_Users where Role=1 order by Id offset ((" + (index - 1) + ")*" + size + ") rows fetch next " + size + " rows only";//SQL执行字符串
            DataTable dataTable = helper.reDt(sqlstr);//储存Datatable
            return dataTable;
        }

        /// <summary>
        /// 获取分页后的教师名单
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <returns>分页后名单</returns>
        public DataTable GetPaperUsersTeacher(int index, int size)
        {
            string sqlstr = "select dbo.PadLeft(Id,8,'0') 账号,Name 昵称 from tb_Users where Role=2 order by Id offset ((" + (index - 1) + ")*" + size + ") rows fetch next " + size + " rows only";//SQL执行字符串
            DataTable dataTable = helper.reDt(sqlstr);//储存Datatable
            return dataTable;
        }

        /// <summary>
        /// 获取未审核用户分页总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        public int GetAllPageNumUnChecked(int size)
        {
            int num = helper.sqlNum("tb_Log where IsChecked=0");
            num = num / size + (num % size == 0 ? 0 : 1);
            return num;
        }

        /// <summary>
        /// 获取老师分页总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        public int GetAllPageNum_Teacher(int size)
        {
            int num = helper.sqlNum("tb_Users where Role=2");
            num = num / size + (num % size == 0 ? 0 : 1);
            return num;
        }

        /// <summary>
        /// 获取学生分页总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        public int GetAllPageNum_Student(int size)
        {
            int num = helper.sqlNum("tb_Users where Role=1");
            num = num / size + (num % size == 0 ? 0 : 1);
            return num;
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
            //向User表中插入数据
            string sqlStr = "INSERT INTO tb_Users(Name,Password,Role,Number) VALUES(@name,@password,@role,@number)";
            //储存Datatable
            SqlParameter[] para = new SqlParameter[]//存储相应参数的容器
            {
                new SqlParameter("@number",account),
                new SqlParameter("@name",name),
                new SqlParameter("@passWord",helper.GetMD5(password)),
                new SqlParameter("@role",role),
            };
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.Text);
            if (count > 0)
            {
                return true;
            }
            return false;
        }
    }
}