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
        /// <param name="studentid">学生Id</param>
        /// <param name="examid">考试Id</param>
        /// <returns>全部学生成绩数据表</returns>
        public DataTable GetStudentGrade(string studentid, string examid = "0")
        {
            DataTable dataTable = null;
            try
            {
                dataTable = gradeDal.GetStudentGrade(studentid, examid);
            }
            catch (Exception e)
            {

            }
            return dataTable;
        }
        /// <summary>
        /// 获取学生成绩
        /// </summary>
        /// <param name="studentid">学生Id</param>
        /// <param name="examid">考试Id</param>
        /// <returns>全部学生成绩数据表</returns>
        public List<Grade> GetStudentGradeArray(string studentid, string examid = "0")
        {
            List<Grade> temp = null;
            try
            {
                DataTable dataTable = gradeDal.GetStudentGrade(studentid, examid);
                temp = new List<Grade>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    int GradeId = (int)dr["Id"];
                    int CId = (int)dr["CId"];
                    int SId = (int)dr["SId"];
                    int EId = (int)dr["EId"];
                    int Score = (int)dr["Score"];
                    Grade t = new Grade(GradeId, CId, SId,EId, Score);
                    temp.Add(t);
                }
                return temp;
            }
            catch (Exception e)
            {

            }
            return temp;
        }
        /// <summary>
        /// 教师获取学生成绩
        /// </summary>
        /// <param name="courseid">课程Id</param>
        /// <param name="examid">考试Id</param>
        /// <returns>全部学生成绩数据表</returns>
        public DataTable GetCourseGrade(string courseid, string examid = "0")
        {
            DataTable dataTable = null;
            try
            {
                dataTable = gradeDal.GetCourseGrade(courseid, examid);
            }
            catch (Exception e)
            {

            }
            return dataTable;
        }
        /// <summary>
        /// 教师获取学生成绩
        /// </summary>
        /// <param name="courseid">课程Id</param>
        /// <param name="examid">考试Id</param>
        /// <returns>全部学生成绩数据表</returns>
        public List<Grade> GetCourseGradeArray(string courseid, string examid = "0")
        {
            List<Grade> temp = null;
            try
            {
                DataTable dataTable = gradeDal.GetCourseGrade(courseid, examid);
                temp = new List<Grade>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    int GradeId = (int)dr["Id"];
                    int CId = (int)dr["CId"];
                    int SId = (int)dr["SId"];
                    int EId = (int)dr["EId"];
                    int Score = (int)dr["Score"];
                    Grade t = new Grade(GradeId, CId, SId, EId, Score);
                    temp.Add(t);
                }
                return temp;
            }
            catch (Exception e)
            {

            }
            return temp;
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
            bool result = false;
            try
            {
                result = gradeDal.ChangeCourseGrade(score, studenid, courseid, examid);
            }
            catch (Exception e)
            {

            }
            return result;
        }
    }
}
