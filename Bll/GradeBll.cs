using Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Bll
{
    /// <summary>
    /// 成绩用户操作类
    /// </summary>
    public class GradeBll
    {
        /// <summary>
        /// 课程数据操作对象
        /// </summary>
        GradeDal gradeDal = new GradeDal();

        /// <summary>
        /// 获取学生成绩
        /// </summary>
        /// <returns>全部学生成绩数据表</returns>
        public DataTable GetStudentGrade(string Id)
        {
            DataTable dataTable = null;
            try
            {
                dataTable = gradeDal.GetStudentGrade(Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return dataTable;
        }
        /// <summary>
        /// 获取学生成绩
        /// </summary>
        /// <returns>全部学生成绩数据表</returns>
        public List<Grade> GetStudentGradeArray(string Id)
        {
            List<Grade> temp = null;
            try
            {
                DataTable dataTable = gradeDal.GetStudentGrade(Id);
                temp = new List<Grade>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    int GradeId = (int)dr["Id"];
                    int CId = (int)dr["CId"];
                    int SId = (int)dr["SId"];
                    int Score = (int)dr["Score"];
                    Grade t = new Grade(GradeId, CId, SId, Score);
                    temp.Add(t);
                }
                return temp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return temp;
        }
        /// <summary>
        /// 教师获取学生成绩
        /// </summary>
        /// <returns>全部学生成绩数据表</returns>
        public DataTable GetCourseGrade(string Id)
        {
            DataTable dataTable = null;
            try
            {
                dataTable = gradeDal.GetCourseGrade(Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return dataTable;
        }
        /// <summary>
        /// 教师获取学生成绩
        /// </summary>
        /// <returns>全部学生成绩数据表</returns>
        public List<Grade> GetCourseGradeArray(string Id)
        {
            List<Grade> temp = null;
            try
            {
                DataTable dataTable = gradeDal.GetCourseGrade(Id);
                temp = new List<Grade>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    int GradeId = (int)dr["Id"];
                    int CId = (int)dr["CId"];
                    int SId = (int)dr["SId"];
                    int Score = (int)dr["Score"];
                    Grade t = new Grade(GradeId, CId, SId, Score);
                    temp.Add(t);
                }
                return temp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return temp;
        }

        /// <summary>
        /// 更改学生成绩
        /// </summary>
        /// <param name="score">成绩</param>
        /// <param name="studenid">学生Id</param>
        /// <param name="courseid">课程Id</param>
        /// <returns>修改是否成功</returns>
        public bool ChangeCourseGrade(string score, string studenid, string courseid)
        {
            bool result = false;
            try
            {
                result = gradeDal.ChangeCourseGrade(score, studenid, courseid);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;
        }
    }
}
