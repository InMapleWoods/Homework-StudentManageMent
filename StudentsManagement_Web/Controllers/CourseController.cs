using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsManagement_Web.Controllers
{
    /// <summary>
    /// 课程控制器
    /// </summary>
    public class CourseController : ApiController
    {
        /// <summary>
        /// 课程操作对象
        /// </summary>
        CourseBll courseBll = new CourseBll();
        /// <summary>
        /// 获取全部课程
        /// </summary>
        /// <returns>全部课程数据表</returns>
        //GET: api/Course
        //GET: api/Course/GetAllCourseArray
        [HttpGet]
        public IEnumerable<Course> GetAllCourseArray()
        {
            try
            {
                return courseBll.GetAllCourseArray();
            }
            catch (Exception ex)
            {
                //在webapi中抛出异常
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "error"
                };
                throw new HttpResponseException(response);
            }
        }

        /// <summary>
        /// 获取学生已选课程
        /// </summary>
        /// <returns>全部课程数据表</returns>
        //GET: api/Course/{Id}
        //GET: api/Course/GetStudentAllCourseArray/{Id}
        public IEnumerable<Course> GetStudentAllCourseArray(string Id)
        {
            try
            {
                return courseBll.GetStudentAllCourseArray(Id);
            }
            catch (Exception ex)
            {
                //在webapi中抛出异常
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "error"
                };
                throw new HttpResponseException(response);
            }
        }

        /// <summary>
        /// 增加课程
        /// </summary>
        /// <param name="name">课程名称</param>
        /// <param name="teacherId">教师Id</param>
        /// <returns>增加成功与否</returns>
        //PUT: api/Course?name={name}&teacherId={teacherId}
        //PUT: api/Course/AddCourse?name={name}&teacherId={teacherId}
        [HttpPut]
        public bool AddCourse(string name, string teacherId)
        {
            try
            {
                return courseBll.AddCourse(name, teacherId);
            }
            catch (Exception ex)
            {
                //在webapi中抛出异常
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "error"
                };
                throw new HttpResponseException(response);
            }
        }
        /// <summary>
        /// 学生选课
        /// </summary>
        /// <param name="UserId">学生Id</param>
        /// <param name="CourseId">课程Id</param>
        /// <returns>选课成功与否</returns>
        //PUT: api/Course?UserId={UserId}&CourseId={CourseId}
        //PUT: api/Course/ChooseCourse?UserId={UserId}&CourseId={CourseId}
        [HttpPut]
        public bool ChooseCourse(string UserId, string CourseId)
        {
            try
            {
                return courseBll.ChooseCourse(UserId, CourseId);
            }
            catch (Exception ex)
            {
                //在webapi中抛出异常
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "error"
                };
                throw new HttpResponseException(response);
            }
        }

        /// <summary>
        /// 删除选择课程
        /// <param name="UserId">学生Id</param>
        /// <param name="CourseId">课程Id</param>
        /// <returns>删除成功与否</returns>
        //DELETE: api/Course?UserId={UserId}&CourseId={CourseId}
        //DELETE: api/Course/DeleteStudentCourse?UserId={UserId}&CourseId={CourseId}
        [HttpDelete]
        public bool DeleteStudentCourse(string UserId, string CourseId)
        {
            try
            {
                return courseBll.DeleteStudentCourse(UserId, CourseId);
            }
            catch (Exception ex)
            {
                //在webapi中抛出异常
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "error"
                };
                throw new HttpResponseException(response);
            }
        }

        /// <summary>
        /// 删除课程
        /// <param name="CourseId">课程Id</param>
        /// <returns>删除成功与否</returns>
        //DELETE: api/Course?CourseId={CourseId}
        //DELETE: api/Course/DeleteCourse?CourseId={CourseId}
        [HttpDelete]
        public bool DeleteCourse(string CourseId)
        {
            try
            {
                return courseBll.DeleteCourse(CourseId);
            }
            catch (Exception ex)
            {
                //在webapi中抛出异常
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "error"
                };
                throw new HttpResponseException(response);
            }
        }

    }
}
