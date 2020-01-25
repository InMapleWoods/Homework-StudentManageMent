using MySql.Data.MySqlClient;
using System.Data;

namespace Dal
{
    /// <summary>
    /// 成绩数据访问类
    /// </summary>
    public class GradeDal
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
        /// 获取学生成绩
        /// </summary>
        /// <param name="Id">学生Id</param>
        /// <param name="courseId">课程Id</param>
        /// <param name="examId">考试Id</param>
        /// <returns>全部学生成绩数据表</returns>
        public DataTable GetStudentGrade(string Id, string courseId, string examId)
        {
            string sqlstr = "GetStudentGrade";//SQL执行字符串
            MySqlParameter[] para = new MySqlParameter[]
            {
                new MySqlParameter("@studentId",int.Parse(Id)),
                new MySqlParameter("@courseId",int.Parse(courseId)),
                new MySqlParameter("@examId",int.Parse(examId)),
            };
            DataTable dataTable = helper.ExecuteQuery(sqlstr, para, CommandType.StoredProcedure);//储存Datatable
            return dataTable;
        }

        /// <summary>
        /// 教师获取学生成绩
        /// </summary>
        /// <param name="Id">课程Id</param>
        /// <returns>全部学生成绩数据表</returns>
        public DataTable GetCourseGrade(string Id, int index, int size)
        {
            int startPos = (index - 1) * size;
            int endPos = index * size;
            string sqlstr = "select tb_Students.Number as 学生学号,tb_Students.Name as 学生姓名,tb_CourseGrade.Score as 课程分数 from tb_CourseGrade,tb_Students where tb_CourseGrade.CId=@id and tb_CourseGrade.SId=tb_Students.Id order by tb_Students.Number limit @startPos,@endPos;";//SQL执行字符串
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("@id",Id),
                new MySqlParameter("@startPos",startPos),
                new MySqlParameter("@endPos",endPos),
            };
            DataTable dataTable = helper.ExecuteQuery(sqlstr, paras, CommandType.Text);//储存Datatable
            return dataTable;
        }
        /// <summary>
        /// 获取全部学生全部成绩
        /// </summary>
        /// <param name="Id">教师Id</param>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <returns>全部学生成绩数据表</returns>
        public DataTable GetAllStudentAllGrade(string Id, int index, int size)
        {
            int startPos = (index - 1) * size;
            int endPos = index * size;
            string str = "GetAllStudentAllGrade";
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("@teacherid",Id),
                new MySqlParameter("@startPos",startPos),
                new MySqlParameter("@endPos",endPos),
            };
            DataTable dataTable = helper.ExecuteQuery(str, paras, CommandType.StoredProcedure);//储存Datatable
            return dataTable;
        }
        /// <summary>
        /// 教师获取学生某考试成绩
        /// </summary>
        /// <param name="Id">考试Id</param>
        /// <returns>全部学生成绩数据表</returns>
        public DataTable GetExamGrade(string Id, int index, int size)
        {
            int startPos = (index - 1) * size;
            int endPos = index * size;
            string sqlstr = "select tb_Students.Number as 学生学号,tb_Students.Name as 学生姓名,tb_ExamGrade.Score as 课程分数 from tb_ExamGrade,tb_Students where tb_ExamGrade.EId=@id and tb_ExamGrade.SId=tb_Students.Id order by tb_Students.Number limit @startPos,@endPos;";//SQL执行字符串
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("@id",Id),
                new MySqlParameter("@startPos",startPos),
                new MySqlParameter("@endPos",endPos),
            };
            DataTable dataTable = helper.ExecuteQuery(sqlstr, paras, CommandType.Text);//储存Datatable
            return dataTable;
        }
        /// <summary>
        /// 获取教师获取学生成绩列表总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        public int GetAllCoursePageNum(string id, int size)
        {
            string sqlstr = "select count(*) from tb_CourseGrade,tb_Students where tb_CourseGrade.CId=@id and tb_CourseGrade.SId=tb_Students.Id ";//SQL执行字符串
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("@id",id),
            };
            DataTable dataTable = helper.ExecuteQuery(sqlstr, paras, CommandType.Text);//储存Datatable
            DataRow dataRow = dataTable.Rows[0];
            int num = (int)(long)dataRow[0];
            num = num / size + (num % size == 0 ? 0 : 1);
            return num;
        }
        /// <summary>
        /// 获取学生某考试成绩列表总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        public int GetAllExamPageNum(string id, int size)
        {
            string sqlstr = "select count(*) from tb_ExamGrade,tb_Students where tb_ExamGrade.EId=@id and tb_ExamGrade.SId=tb_Students.Id";//SQL执行字符串
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("@id",id),
            };
            DataTable dataTable = helper.ExecuteQuery(sqlstr, paras, CommandType.Text);//储存Datatable
            DataRow dataRow = dataTable.Rows[0];
            int num = (int)(long)dataRow[0];
            num = num / size + (num % size == 0 ? 0 : 1);
            return num;
        }

        /// <summary>
        /// 更改学生某课程总成绩
        /// </summary>
        /// <param name="score">成绩</param>
        /// <param name="studenid">学生Id</param>
        /// <param name="courseid">课程Id</param>
        /// <returns>修改是否成功</returns>
        public bool ChangeCourseGrade(string score, string studenid, string courseid)
        {
            string sqlstr = "UPDATE tb_CourseGrade SET Score=@score where SId=GetUserIdByNumber(@studenid) and CId=@courseid";
            //储存Datatable
            MySqlParameter[] para = new MySqlParameter[]//存储相应参数的容器
            {
                new MySqlParameter("@score",score),
                new MySqlParameter("@studenid",studenid),
                new MySqlParameter("@courseid",courseid),
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
        /// 更改学生某考试成绩
        /// </summary>
        /// <param name="score">成绩</param>
        /// <param name="studenid">学生Id</param>
        /// <param name="examid">考试Id</param>
        /// <returns>修改是否成功</returns>
        public bool ChangeExamGrade(string score, string studenid, string examid)
        {
            string sqlstr = "UPDATE tb_ExamGrade SET Score=@score where SId=GetUserIdByNumber(@studenid) and Eid=@examid";
            //储存Datatable
            MySqlParameter[] para = new MySqlParameter[]//存储相应参数的容器
            {
                new MySqlParameter("@score",score),
                new MySqlParameter("@studenid",studenid),
                new MySqlParameter("@examid",examid),
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

    }
}
