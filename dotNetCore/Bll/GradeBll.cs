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
        /// 获取全部学生全部成绩
        /// </summary>
        /// <param name="Id">教师Id</param>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <returns>全部学生成绩数据表</returns>
        public IEnumerable GetAllStudentAllGrade(string Id, int index, int size)
        {
            List<string[]> temp = null;
            try
            {
                DataTable dataTable = gradeDal.GetAllStudentAllGrade(Id, index, size);
                temp = new List<string[]>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    List<string> t = new List<string>();
                    foreach(var obj in dr.ItemArray)
                    {
                        t.Add(obj.ToString());
                    }
                    temp.Add(t.ToArray());
                }
                return temp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
        }
        /// <summary>
        /// 教师获取学生成绩
        /// </summary>
        /// <returns>全部学生成绩数据表</returns>
        public DataTable GetCourseGrade(string Id, int index, int size)
        {
            DataTable dataTable = null;
            try
            {
                dataTable = gradeDal.GetCourseGrade(Id, index, size);
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
        public IEnumerable GetCourseGradeArray(string Id, int index, int size)
        {
            List<string[]> temp = null;
            try
            {
                DataTable dataTable = gradeDal.GetCourseGrade(Id, index, size);
                temp = new List<string[]>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    string Number = dr["学生学号"].ToString();
                    string Name = dr["学生姓名"].ToString();
                    string Score = dr["课程分数"].ToString();
                    string[] t = new string[] { Number, Name, Score };
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
        /// 教师获取学生某考试成绩
        /// </summary>
        /// <param name="Id">考试Id</param>
        /// <returns>全部学生成绩数据表</returns>
        public IEnumerable GetExamGradeArray(string Id, int index, int size)
        {
            List<string[]> temp = null;
            try
            {
                DataTable dataTable = gradeDal.GetExamGrade(Id, index, size);
                temp = new List<string[]>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    string Number = dr["学生学号"].ToString();
                    string Name = dr["学生姓名"].ToString();
                    string Score = dr["课程分数"].ToString();
                    string[] t = new string[] { Number, Name, Score };
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
        /// 获取教师获取学生成绩列表总页数
        /// </summary>
        /// <param name="id">课程Id</param>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        public int GetAllCoursePageNum(string id, int size)
        {
            int result;
            try
            {
                result = gradeDal.GetAllCoursePageNum(id, size);
            }
            catch (Exception e) { Console.WriteLine(e.Message); throw e; }
            return result;
        }
        /// <summary>
        /// 获取学生某考试成绩列表总页数
        /// </summary>
        /// <param name="id">考试Id</param>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        public int GetAllExamPageNum(string id, int size)
        {
            int result;
            try
            {
                result = gradeDal.GetAllExamPageNum(id, size);
            }
            catch (Exception e) { Console.WriteLine(e.Message); throw e; }
            return result;
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
            try
            {
                int _score = Int32.Parse(score);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("成绩格式不正确");
            }
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
            try
            {
                int _score = Int32.Parse(score);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message); 
                throw new Exception("成绩格式不正确");
            }
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
