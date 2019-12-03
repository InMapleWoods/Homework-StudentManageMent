using Dal;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
namespace Bll
{
    /// <summary>
    /// 课程用户操作类
    /// </summary>
    public class CourseBll
    {
        /// <summary>
        /// 课程数据操作对象
        /// </summary>
        private readonly CourseDal courseDal = new CourseDal();

        /// <summary>
        /// 获取全部课程
        /// </summary>
        /// <returns>全部课程数据表</returns>
        public DataTable GetAllCourse()
        {
            DataTable dataTable = null;
            try
            {
                dataTable = courseDal.GetAllCourse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return dataTable;
        }

        /// <summary>
        /// 获取全部课程
        /// </summary>
        /// <returns>全部课程数据表</returns>
        public List<Course> GetAllCourseArray()
        {
            List<Course> temp = null;
            try
            {
                DataTable dataTable = courseDal.GetAllCourse();
                temp = new List<Course>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    int Id = (int)dr["Id"];
                    string Name = dr["Name"].ToString();
                    int TeacherId = (int)dr["TeacherId"];
                    Course t = new Course(Id, Name, TeacherId);
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
        /// 获取学生已选课程
        /// </summary>
        /// <returns>全部课程数据表</returns>
        public IEnumerable GetStudentAllCourseArray(string Id, int index, int size)
        {
            List<string[]> temp = null;
            try
            {
                DataTable dataTable = courseDal.GetStudentAllCourse(Id, index, size);
                temp = new List<string[]>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    int CourseId = (int)dr["Id"];
                    string Name = dr["Name"].ToString();
                    string[] t = new string[] { CourseId.ToString(), Name };
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
        /// 获取教师课程
        /// </summary>
        /// <returns>全部课程数据表</returns>
        public IEnumerable GetTeacherAllCourseArray(string Id, int index, int size)
        {
            List<string[]> temp = null;
            try
            {
                DataTable dataTable = courseDal.GetTeacherAllCourse(Id, index, size);
                temp = new List<string[]>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    int CourseId = (int)dr["Id"];
                    string Name = dr["Name"].ToString();
                    string[] t = new string[] { CourseId.ToString(), Name };
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
        /// 获取学生未选课程
        /// </summary>
        /// <returns>全部课程数据表</returns>
        public IEnumerable GetStudentNoChooseCourseArray(string Id, int index, int size)
        {
            List<string[]> temp = null;
            try
            {
                DataTable dataTable = courseDal.GetStudentNoChooseCourse(Id, index, size);
                temp = new List<string[]>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    int CourseId = (int)dr["课程ID"];
                    string Name = dr["课程名称"].ToString();
                    string TeacherName = dr["教师名称"].ToString();
                    string[] t = new string[] { CourseId.ToString(), Name, TeacherName };
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
        /// 增加课程
        /// </summary>
        /// <param name="name">课程名称</param>
        /// <param name="teacherId">教师Id</param>
        /// <returns>增加成功与否</returns>
        public bool AddCourse(string name, string teacherId)
        {
            bool result = false;
            try
            {
                result = courseDal.AddCourse(name, teacherId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;
        }
        /// <summary>
        /// 学生选课
        /// </summary>
        /// <param name="UserId">学生Id</param>
        /// <param name="CourseId">课程Id</param>
        /// <returns>选课成功与否</returns>
        public bool ChooseCourse(string UserId, string CourseId)
        {
            bool result = false;
            try
            {
                result = courseDal.ChooseCourse(UserId, CourseId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;
        }

        /// <summary>
        /// 删除选择课程
        /// <param name="UserId">学生Id</param>
        /// <param name="CourseId">课程Id</param>
        /// <returns>删除成功与否</returns>
        public bool DeleteStudentCourse(string UserId, string CourseId)
        {
            bool result;
            try
            {
                result = courseDal.DeleteStudentCourse(UserId, CourseId);
            }
            catch (Exception e) { Console.WriteLine(e.Message); throw e; }
            return result;
        }

        /// <summary>
        /// 删除课程
        /// <param name="CourseId">课程Id</param>
        /// <returns>删除成功与否</returns>
        public bool DeleteCourse(string CourseId)
        {
            bool result;
            try
            {
                result = courseDal.DeleteCourse(CourseId);
            }
            catch (Exception e) { Console.WriteLine(e.Message); throw e; }
            return result;
        }

        /// <summary>
        /// 获取分页后的用户名单
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <param name="choose">分页选项</param>
        /// <returns>分页后名单</returns>
        public DataTable GetPaperCourse(int index, int size)
        {
            DataTable result;
            try
            {
                result = courseDal.GetPaperCourse(index, size);
            }
            catch (Exception e) { Console.WriteLine(e.Message); throw e; }
            return result;
        }

        /// <summary>
        /// 获取全部课程
        /// </summary>
        /// <returns>全部课程数据表</returns>
        public List<CourseTempObject> GetPaperCourseArray(int index, int size)
        {
            List<CourseTempObject> temp = null;
            try
            {
                DataTable dataTable = GetPaperCourse(index, size);
                temp = new List<CourseTempObject>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    int Id = (int)dr["课程ID"];
                    string Name = dr["课程名称"].ToString();
                    string TeacherName = dr["教师名称"].ToString();
                    CourseTempObject t = new CourseTempObject(Id, Name, TeacherName);
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
        /// 获取分页后的课程列表总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <param name="choose">分页选项</param>
        /// <returns>分页数</returns>
        public int GetAllPageNum(int size)
        {
            int result;
            try
            {
                result = courseDal.GetAllPageNum(size);
            }
            catch (Exception e) { Console.WriteLine(e.Message); throw e; }
            return result;
        }
        /// <summary>
        /// 获取学生未选课程总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <param name="Id">学生Id</param>
        /// <returns>分页数</returns>
        public int GetStudentNoChooseCoursePageNum(int size, string Id)
        {
            int result;
            try
            {
                result = courseDal.GetStudentNoChooseCoursePageNum(size, Id);
            }
            catch (Exception e) { Console.WriteLine(e.Message); throw e; }
            return result;
        }
        /// <summary>
        /// 获取学生已选课程总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <param name="Id">学生Id</param>
        /// <returns>分页数</returns>
        public int GetStudentAllCoursePageNum(int size, string Id)
        {
            int result;
            try
            {
                result = courseDal.GetStudentAllCoursePageNum(size, Id);
            }
            catch (Exception e) { Console.WriteLine(e.Message); throw e; }
            return result;
        }
        public class CourseTempObject
        {
            public int Id { get; set; }
            public string CourseName { get; set; }
            public string TeacherName { get; set; }
            public CourseTempObject(int id, string cname, string tname)
            {
                Id = id;
                CourseName = cname;
                TeacherName = tname;
            }

        }
    }
}