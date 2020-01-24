using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Dal
{
    /// <summary>
    /// 课程数据访问层
    /// </summary>
    public class CourseDal
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
        /// 获取全部课程
        /// </summary>
        /// <returns>全部课程数据表</returns>
        public DataTable GetAllCourse()
        {
            string sqlstr = "select tb_Course.Id as 课程ID,tb_Course.Name as 课程名, tb_Teachers.Name as 教师名 from tb_Course LEFT OUTER JOIN tb_Teachers on tb_Teachers.Id=tb_Course.TeacherId;";//SQL执行字符串
            DataTable dataTable = helper.reDt(sqlstr);
            return dataTable;
        }

        /// <summary>
        /// 获取学生未选课程
        /// </summary>
        /// <returns>全部课程数据表</returns>
        public DataTable GetStudentNoChooseCourse(string Id, int index, int size)
        {
            int startPos = (index - 1) * size;
            int endPos = index * size;
            string sqlstr = "select tb_Course.Id 课程ID, tb_Course.Name 课程名称, tb_Teachers.Name 教师名称 from tb_Course, tb_Teachers where tb_Course.TeacherId = tb_Teachers.Id and tb_Course.Id Not in (select tb_CourseGrade.CId from tb_CourseGrade where tb_CourseGrade.SId = @Id) order by tb_Course.Id limit @startPos,@endPos;";//SQL执行字符串
            MySqlParameter[] para = new MySqlParameter[] {
                new MySqlParameter("@id",Id),
                new MySqlParameter("@startPos",startPos),
                new MySqlParameter("@endPos",endPos),
            };
            DataTable dataTable = helper.ExecuteQuery(sqlstr, para, CommandType.Text);
            return dataTable;
        }

        /// <summary>
        /// 获取学生已选课程
        /// </summary>
        /// <returns>全部课程数据表</returns>
        public DataTable GetStudentAllCourse(string Id, int index, int size)
        {
            int startPos = (index - 1) * size;
            int endPos = index * size;
            string sqlstr = "select tb_Course.Id,tb_Course.Name from tb_Course inner join tb_CourseGrade on tb_CourseGrade.SId=@id and tb_CourseGrade.CId=tb_Course.Id order by tb_Course.Id limit @startPos,@endPos;";
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("@id",Id),
                new MySqlParameter("@startPos",startPos),
                new MySqlParameter("@endPos",endPos),
            };
            DataTable dataTable = helper.ExecuteQuery(sqlstr, paras, CommandType.Text);
            return dataTable;
        }
        /// <summary>
        /// 获取教师课程
        /// </summary>
        /// <returns>全部课程数据表</returns>
        public DataTable GetTeacherAllCourse(string Id, int index, int size)
        {
            int startPos = (index - 1) * size;
            int endPos = index * size;
            string sqlstr = "select tb_Course.Id,tb_Course.Name from tb_Course where TeacherId=@id order by tb_Course.Id limit @startPos,@endPos;";
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("@id",Id),
                new MySqlParameter("@startPos",startPos),
                new MySqlParameter("@endPos",endPos),
            };
            DataTable dataTable = helper.ExecuteQuery(sqlstr, paras, CommandType.Text);
            return dataTable;
        }
        /// <summary>
        /// 增加课程
        /// </summary>
        /// <param name="name">课程名称</param>
        /// <param name="teacherId">教师Id</param>
        /// <returns>增加成功与否</returns>
        public bool AddCourse(string name, string teacherId)
        {
            string sqlstr = "INSERT INTO tb_Course (Name,TeacherId) VALUES(@name,@teacherId)";
            //储存Datatable
            MySqlParameter[] para = new MySqlParameter[]//存储相应参数的容器
            {
                new MySqlParameter("@name",name),
                new MySqlParameter("@teacherId",teacherId),
            };
            int count = helper.ExecuteNonQuery(sqlstr, para, CommandType.Text);
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
        /// 学生选课
        /// </summary>
        /// <param name="UserId">学生Id</param>
        /// <param name="CourseId">课程Id</param>
        /// <returns>选课成功与否</returns>
        public bool ChooseCourse(string UserId, string CourseId)
        {
            string sqlstr = "StudentChooseCourse";
            //储存Datatable
            MySqlParameter[] para = new MySqlParameter[]//存储相应参数的容器
            {
                new MySqlParameter("@courseId",int.Parse(CourseId)),
                new MySqlParameter("@userId",int.Parse(UserId)),
                new MySqlParameter("@result",MySqlDbType.VarChar,30),
                new MySqlParameter("@returnValue",MySqlDbType.Int32,4),
            };
            para[2].Direction = ParameterDirection.Output;
            para[3].Direction = ParameterDirection.Output;
            int count = helper.ExecuteNonQuery(sqlstr, para, CommandType.StoredProcedure);
            string result = para[2].Value.ToString();
            int resultcount = (int)para[3].Value;
            if (resultcount == -2)
                throw new Exception("选课功能被关闭");
            if (result != "")
                throw new Exception(result);
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
        /// 删除选择课程
        /// <param name="UserId">学生Id</param>
        /// <param name="CourseId">课程Id</param>
        /// <returns>删除成功与否</returns>
        public bool DeleteStudentCourse(string UserId, string CourseId)
        {
            string sqlStr = "StudentDeleteChosenCourse";
            MySqlParameter[] para = new MySqlParameter[]//存储相应参数的容器
            {
                new MySqlParameter("@cid",CourseId),
                new MySqlParameter("@sid",UserId),
                new MySqlParameter("@returnValue",MySqlDbType.Int32)
            };
            para[2].Direction = ParameterDirection.ReturnValue;
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.StoredProcedure);
            int result = (int)para[2].Value;
            if (result == -2)
                throw new Exception("选课功能被关闭");
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
        /// 删除课程
        /// <param name="CourseId">课程Id</param>
        /// <returns>删除成功与否</returns>
        public bool DeleteCourse(string CourseId)
        {
            string sqlStr = "Delete from tb_Course where Id=@id";
            MySqlParameter[] para = new MySqlParameter[]//存储相应参数的容器
            {
                new MySqlParameter("@id",CourseId),
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
        /// 获取分页后的课程列表
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <returns>分页后名单</returns>
        public DataTable GetPaperCourse(int index, int size)
        {
            int startPos = (index - 1) * size;
            int endPos = index * size;
            string str = "GetPageByOption";
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("@startPos",startPos),
                new MySqlParameter("@endPos",endPos),
                new MySqlParameter("@option","GetPaperCourse"),
            };
            DataTable dataTable = helper.ExecuteQuery(str, paras, CommandType.StoredProcedure);//储存Datatable
            return dataTable;
        }

        /// <summary>
        /// 获取分页后的课程列表总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        public int GetAllPageNum(int size)
        {
            int num = helper.sqlNum("tb_Course");
            num = num / size + (num % size == 0 ? 0 : 1);
            return num;
        }
        /// <summary>
        /// 获取学生未选课程总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <param name="Id">学生Id</param>
        /// <returns>分页数</returns>
        public int GetStudentNoChooseCoursePageNum(int size, string Id)
        {
            string str = "select count(*) as Count from tb_Course, tb_Teachers where tb_Course.TeacherId = tb_Teachers.Id and tb_Course.Id Not in (select tb_CourseGrade.CId from tb_CourseGrade where tb_CourseGrade.SId = @Id)";
            DataTable dataTable = helper.ExecuteQuery(str, new MySqlParameter[] { new MySqlParameter("@id", Id) }, CommandType.Text);
            DataRow dr = dataTable.Rows[0];
            int num = (int)dr["Count"];
            num = num / size + (num % size == 0 ? 0 : 1);
            return num;
        }
        /// <summary>
        /// 获取学生已选课程总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <param name="Id">学生Id</param>
        /// <returns>分页数</returns>
        public int GetStudentAllCoursePageNum(int size, string Id)
        {
            string str = "select count(*) as Count from tb_Course inner join tb_CourseGrade on tb_CourseGrade.SId=@id and tb_CourseGrade.CId=tb_Course.Id";
            DataTable dataTable = helper.ExecuteQuery(str, new MySqlParameter[] { new MySqlParameter("@id", Id) }, CommandType.Text);
            DataRow dr = dataTable.Rows[0];
            int num = (int)dr["Count"];
            num = num / size + (num % size == 0 ? 0 : 1);
            return num;
        }


    }
}
