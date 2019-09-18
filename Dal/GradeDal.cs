using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

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
        static readonly string sqlConnect = "server=152.136.73.240;database=db_StudentManage;uid=Lsa;pwd=llfllf";

        /// <summary>
        /// SQL帮助类
        /// </summary>
        readonly SQLHelper helper = new SQLHelper(sqlConnect);

        /// <summary>
        /// 获取学生成绩
        /// </summary>
        /// <param name="studentid">学生Id</param>
        /// <param name="courseid">课程Id</param>
        /// <returns>学生每次成绩数据表</returns>
        public DataTable GetStudentCourseGrade(string studentid,string courseid)
        {
            string sqlstr = "select tb_Examination.Name as 考试名,tb_Grade.Score as 课程分数 from tb_Grade inner join tb_Examination on SId=@studentid and tb_Grade.CId=tb_Examination.CourseId and tb_Grade.CId=@courseid and tb_Grade.EId<>0";//SQL执行字符串
            SqlParameter[] para = new SqlParameter[]//存储相应参数的容器
            {
                new SqlParameter("@studentid",studentid),
                new SqlParameter("@courseid",courseid),
            };

            DataTable dataTable = helper.ExcuteQuery(sqlstr, para, CommandType.Text);//储存Datatable
            return dataTable;
        }
        /// <summary>
        /// 获取学生成绩
        /// </summary>
        /// <param name="studentid">学生Id</param>
        /// <param name="examid">考试Id</param>
        /// <returns>全部学生成绩数据表</returns>
        public DataTable GetStudentGrade(string studentid, string examid = "0")
        {
            string sqlstr = "select tb_Course.Name as 课程名,tb_Grade.Score as 课程分数 from tb_Grade inner join tb_Course on SId=@studentid and tb_Grade.CId=tb_Course.Id and tb_Grade.EId=@examid";//SQL执行字符串
            SqlParameter[] para = new SqlParameter[]//存储相应参数的容器
            {
                new SqlParameter("@studentid",studentid),
                new SqlParameter("@examid",examid),
            };

            DataTable dataTable = helper.ExcuteQuery(sqlstr, para, CommandType.Text);//储存Datatable
            return dataTable;
        }

        /// <summary>
        /// 教师获取学生成绩
        /// </summary>
        /// <param name="courseid">课程Id</param>
        /// <param name="examid">考试Id</param>
        /// <returns>全部学生成绩数据表</returns
        public DataTable GetCourseGrade(string courseid, string examid = "0")
        {
            string sqlstr = "select dbo.PadLeft(tb_Grade.SId,8,'0') as 学生学号,tb_Users.Name as 学生姓名,tb_Grade.Score as 课程分数 from tb_Grade inner join tb_Users on CId=@courseid and EId=@examid and tb_Grade.SId=tb_Users.courseid";//SQL执行字符串
            SqlParameter[] para = new SqlParameter[]//存储相应参数的容器
            {
                new SqlParameter("@courseid",courseid),
                new SqlParameter("@examid",examid),
            };

            DataTable dataTable = helper.ExcuteQuery(sqlstr,para,CommandType.Text);//储存Datatable
            return dataTable;
        }

        /// <summary>
        /// 更改学生成绩
        /// </summary>
        /// <param name="score">成绩</param>
        /// <param name="studenid">学生Id</param>
        /// <param name="courseid">课程Id</param>
        /// <param name="examid">考试Id</param>
        /// <returns>修改是否成功</returns>
        public bool ChangeCourseGrade(string score, string studenid, string courseid, string examid = "0")
        {
            string sqlstr = "UPDATE tb_Grade SET Score=@score where SId=@studenid and CId=@courseid and EId=@examid";
            //储存Datatable
            SqlParameter[] para = new SqlParameter[]//存储相应参数的容器
            {
                new SqlParameter("@score",score),
                new SqlParameter("@studenid",studenid),
                new SqlParameter("@courseid",courseid),
                new SqlParameter("@examid",examid),
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