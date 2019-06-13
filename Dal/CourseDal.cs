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
    /// 课程数据访问层
    /// </summary>
    public class CourseDal
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
        /// 获取全部课程
        /// </summary>
        /// <returns>全部课程数据表</returns>
        public DataTable GetAllCourse()
        {
            string sqlstr = "select tb_Course.Id as 课程ID,tb_Course.Name as 课程名, tb_Users.Name as 教师名 from tb_Course,tb_Users where tb_Users.Id=tb_Course.TeacherId";//SQL执行字符串
            DataTable dataTable = helper.reDt(sqlstr);
            return dataTable;
        }

        /// <summary>
        /// 获取学生已选课程
        /// </summary>
        /// <returns>全部课程数据表</returns>
        public DataTable GetStudentAllCourse(string Id)
        {
            string sqlstr = "select tb_Course.Id as 课程ID,tb_Course.Name as 课程名  from tb_Course,tb_Grade where tb_Grade.SId='" + Id + "'  and tb_Grade.CId=tb_Course.Id";
            DataTable dataTable = helper.reDt(sqlstr);
            return dataTable;
        }
        /// <summary>
        /// 增加课程
        /// </summary>
        /// <param name="name">课程名称</param>
        /// <param name="teacherId">教师Id</param>
        /// <returns>增加成功与否</returns>
        public bool AddCourse(string name,string teacherId)
        {
            string sqlstr = "INSERT INTO tb_Course (Name,TeacherId) VALUES(@name,@teacherId)";
            //储存Datatable
            SqlParameter[] para = new SqlParameter[]//存储相应参数的容器
            {
                new SqlParameter("@name",name),
                new SqlParameter("@teacherId",teacherId),
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
        public bool ChooseCourse(string UserId,string CourseId)
        {
            int num = helper.sqlNum("tb_Course Where Id='" + CourseId + "'");
            if (num == 0)
            {
                throw new Exception("该课程不存在");
            }
            num = helper.sqlNum("tb_Grade Where CId='" + CourseId + "' and SId='" + UserId + "'");
            if (num != 0)
            {
                throw new Exception("重复选课");
            }
            string sqlstr = "INSERT INTO tb_Grade(CId,SId) VALUES(@cid,@sid)";
            //储存Datatable
            SqlParameter[] para1 = new SqlParameter[]//存储相应参数的容器
            {
                new SqlParameter("@cid",CourseId),
                new SqlParameter("@sid",UserId),
            };
            int count=helper.ExecuteNonQuery(sqlstr, para1, CommandType.Text);
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
            string sqlStr = "Delete from tb_Grade where CId=@cid and SId=@sid";
            SqlParameter[] para = new SqlParameter[]//存储相应参数的容器
            {
                new SqlParameter("@cid",CourseId),
                new SqlParameter("@sid",UserId),
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
        /// 删除课程
        /// <param name="CourseId">课程Id</param>
        /// <returns>删除成功与否</returns>
        public bool DeleteCourse(string CourseId)
        {
            string sqlStr = "Delete from tb_Course where Id=@id";
            SqlParameter[] para = new SqlParameter[]//存储相应参数的容器
            {
                new SqlParameter("@id",CourseId),
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
            string sqlstr = "select Id 课程ID,Name 课程名称 from tb_Course order by Id offset ((" + (index - 1) + ")*" + size + ") rows fetch next " + size + " rows only";//SQL执行字符串
            DataTable dataTable = helper.reDt(sqlstr);//储存Datatable
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


    }
}
