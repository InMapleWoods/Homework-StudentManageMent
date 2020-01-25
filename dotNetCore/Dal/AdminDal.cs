using MySql.Data.MySqlClient;
using System.Data;

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
        private const string sqlConnect = "server=152.136.73.240;port=1733;database=db_StudentManage;user id=Lsa;password=llfllf;Charset=utf8;";

        /// <summary>
        /// SQL帮助类
        /// </summary>
        private readonly SQLHelper helper = new SQLHelper(sqlConnect);

        /// <summary>
        /// 接收申请
        /// </summary>
        /// <param name="id">申请用户ID</param>
        /// <param name="tobe">申请角色</param>
        /// <returns>成功与否</returns>
        public bool AcceptLog(string id)
        {
            string sqlStr = "AcceptLog";
            MySqlParameter[] para = new MySqlParameter[]
             {
                new MySqlParameter("@id",id),
                new MySqlParameter("@returnValue",MySqlDbType.Int32,4),
             };
            para[1].Direction = ParameterDirection.Output;
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.StoredProcedure);
            int resultcount = (int)para[1].Value;
            if (resultcount > 0)
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
            MySqlParameter[] para = new MySqlParameter[]
             {
                new MySqlParameter("@id",id),
                new MySqlParameter("@returnValue",MySqlDbType.Int32,4),
             };
            para[1].Direction = ParameterDirection.Output;
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.StoredProcedure);
            int resultcount = (int)para[1].Value;
            if (resultcount > 0)
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
        /// <param name="number">用户账号</param>
        /// <returns>成功与否</returns>
        public bool DeleteUser(string number)
        {
            string sqlStr = "delete from " + helper.GetUserRole(number) + " where Number=@number";
            MySqlParameter[] para = new MySqlParameter[]
             {
                new MySqlParameter("@number",number)
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
            int startPos = (index - 1) * size;
            int endPos = index * size;
            string str = "GetPageByOption";
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("@startPos",startPos),
                new MySqlParameter("@endPos",endPos),
                new MySqlParameter("@option","GetPaperUsersWaitingToCheck"),
            };
            DataTable dataTable = helper.ExecuteQuery(str, paras, CommandType.StoredProcedure);//储存Datatable
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
            int startPos = (index - 1) * size;
            int endPos = index * size;
            string str = "GetPageByOption";
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("@startPos",startPos),
                new MySqlParameter("@endPos",endPos),
                new MySqlParameter("@option","GetPaperUsersStudent"),
            };
            DataTable dataTable = helper.ExecuteQuery(str, paras, CommandType.StoredProcedure);//储存Datatable
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
            int startPos = (index - 1) * size;
            int endPos = index * size;
            string str = "GetPageByOption";
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("@startPos",startPos),
                new MySqlParameter("@endPos",endPos),
                new MySqlParameter("@option","GetPaperUsersTeacher"),
            };
            DataTable dataTable = helper.ExecuteQuery(str, paras, CommandType.StoredProcedure);//储存Datatable
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
            int num = helper.sqlNum("tb_Teachers");
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
            int num = helper.sqlNum("tb_Students");
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
            string sqlStr = "INSERT INTO " + helper.GetTableNameByRole(role) + "(Name,Password,Number) VALUES(@name,@password,@number)";
            //储存Datatable
            MySqlParameter[] para = new MySqlParameter[]//存储相应参数的容器
            {
                new MySqlParameter("@number",account),
                new MySqlParameter("@name",name),
                new MySqlParameter("@passWord",helper.GetMD5(password)),
            };
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.Text);
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取设置列表
        /// </summary>
        /// <returns>设置列表</returns>
        public DataTable GetSettings()
        {
            string str = "select * from tb_Settings";
            MySqlParameter[] para = new MySqlParameter[] {
            };
            using (DataTable dataTable = helper.ExecuteQuery(str, para, CommandType.Text))
            {
                return dataTable;
            }
        }

        /// <summary>
        /// 更改是否开启注册功能
        /// </summary>
        /// <returns>更改结果</returns>
        public string ReverseRegisterOpenState()
        {
            string str = "ReverseRegisterOpenState";
            MySqlParameter[] para = new MySqlParameter[] {
                new MySqlParameter("@result",MySqlDbType.VarChar,5000)
            };
            para[0].Direction = ParameterDirection.Output;
            using (DataTable dataTable = helper.ExecuteQuery(str, para, CommandType.StoredProcedure))
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
        /// <summary>
        /// 更改是否开启选课功能
        /// </summary>
        /// <returns>更改结果</returns>
        public string ReverseCourseChooseOpenState()
        {
            string str = "ReverseCourseChooseOpenState";
            MySqlParameter[] para = new MySqlParameter[] {
                new MySqlParameter("@result",MySqlDbType.VarChar,5000)
            };
            para[0].Direction = ParameterDirection.Output;
            using (DataTable dataTable = helper.ExecuteQuery(str, para, CommandType.StoredProcedure))
            {
                string result = para[0].Value.ToString();
                if (result == "OpenStateBecomeFalse")
                {
                    return "选课功能关闭";
                }
                else if (result == "OpenStateBecomeTrue")
                {
                    return "选课功能开启";
                }
                else
                {
                    return "状态更改失败";
                }
            }
        }
    }
}