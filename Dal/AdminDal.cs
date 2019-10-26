using System.Data;
using System.Data.SqlClient;

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
        readonly SQLHelper helper = new SQLHelper(sqlConnect);

        /// <summary>
        /// 接收申请
        /// </summary>
        /// <param name="id">申请用户ID</param>
        /// <param name="tobe">申请角色</param>
        /// <returns>成功与否</returns>
        public bool AcceptLog(string id)
        {
            string sqlStr = "AccpetLog";
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@userId",id)
             };
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.StoredProcedure);
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
            string sqlStr = "RejectionLog";
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@userId",id)
             };
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.StoredProcedure);
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
            string str = "GetPageByOption";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@index",index),
                new SqlParameter("@size",size),
                new SqlParameter("@option","GetPaperUsersWaitingToCheck"),
            };
            DataTable dataTable = helper.ExcuteQuery(str, paras, CommandType.StoredProcedure);//储存Datatable
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
            string str = "GetPageByOption";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@index",index),
                new SqlParameter("@size",size),
                new SqlParameter("@option","GetPaperUsersStudent"),
            };
            DataTable dataTable = helper.ExcuteQuery(str, paras, CommandType.StoredProcedure);//储存Datatable
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
            string str = "GetPageByOption";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@index",index),
                new SqlParameter("@size",size),
                new SqlParameter("@option","GetPaperUsersTeacher"),
            };
            DataTable dataTable = helper.ExcuteQuery(str, paras, CommandType.StoredProcedure);//储存Datatable
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

        /// <summary>
        /// 更改是否开启注册功能
        /// </summary>
        /// <returns>更改结果</returns>
        public string ReverseRegisterOpenState()
        {
            string str = "ReverseRegisterOpenState";
            SqlParameter[] para = new SqlParameter[] {
                new SqlParameter("result",SqlDbType.VarChar,10)
            };
            para[0].Direction = ParameterDirection.ReturnValue;
            using (DataTable dataTable = helper.ExcuteQuery(str, para, CommandType.StoredProcedure))
            {
                string result = para[0].Value.ToString();
                if (result == "OpenStateBecomeFalse")
                {
                    return "注册功能关闭";
                }
                else if (result == "OpenStateBecomeTrue")
                {
                    return "注册功能开启";
                }
                else
                {
                    return "状态更改失败";
                }
            }
        }
    }
}