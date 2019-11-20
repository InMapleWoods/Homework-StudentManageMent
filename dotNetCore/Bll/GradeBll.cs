using Dal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

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
        private readonly GradeDal gradeDal = new GradeDal();

        /// <summary>
        /// 获取学生成绩
        /// </summary>
        /// <param name="Id">学生Id</param>
        /// <param name="courseId">课程Id</param>
        /// <param name="examId">考试Id</param>
        /// <returns>全部学生成绩数据表</returns>
        public IEnumerable GetStudentGradeArray(string Id, string courseId, string examId)
        {
            List<string[]> result = new List<string[]>();
            try
            {
                DataTable dataTable = gradeDal.GetStudentGrade(Id, courseId, examId);
                foreach (DataRow dr in dataTable.Rows)
                {
                    string CourseName = dr["课程名"].ToString();
                    string ExamName = dr["考试名"].ToString();
                    string Score = dr["成绩"].ToString();
                    string[] t = new string[] { CourseName, ExamName, Score };
                    result.Add(t);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;
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
        public IEnumerable GetCourseGradeArray(string Id)
        {
            List<GradeObject> temp = null;
            try
            {
                DataTable dataTable = gradeDal.GetCourseGrade(Id);
                temp = new List<GradeObject>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    string ExamName = dr["考试名"].ToString();
                    string CourseName = dr["课程名"].ToString();
                    int Score = (int)dr["成绩"];
                    GradeObject t = new GradeObject(CourseName, ExamName, Score);
                    temp.Add(t);
                }
                return temp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
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


        /// <summary>
        /// 更改学生某考试成绩
        /// </summary>
        /// <param name="score">成绩</param>
        /// <param name="studenid">学生Id</param>
        /// <param name="examid">考试Id</param>
        /// <returns>修改是否成功</returns>
        public bool ChangeExamGrade(string score, string studenid, string examid)
        {
            bool result = false;
            try
            {
                result = gradeDal.ChangeExamGrade(score, studenid, examid);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;
        }

        public class GradeObject
        {
            public string courseName { get; set; }
            public string examName { get; set; }
            public int score { get; set; }
            public GradeObject(string cN, string eN, int s)
            {
                courseName = cN;
                examName = eN;
                score = s;
            }
        }
    }
}
