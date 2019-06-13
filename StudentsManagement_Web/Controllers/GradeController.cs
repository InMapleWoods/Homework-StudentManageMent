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
    /// 成绩控制器
    /// </summary>
    public class GradeController : ApiController
    {
        /// <summary>
        /// 成绩操作对象
        /// </summary>
        GradeBll gradeBll = new GradeBll();
        /// <summary>
        /// 获取学生成绩
        /// </summary>
        /// <returns>全部学生成绩数据表</returns>
        //GET: api/Grade/GetStudentGradeArray/{Id}
        public IEnumerable<Grade> GetStudentGradeArray(string Id)
        {
            try
            {
                return GetStudentGradeArray(Id);
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
        /// 教师获取学生成绩
        /// </summary>
        /// <returns>全部学生成绩数据表</returns>
        //GET: api/Grade/GetCourseGradeArray/{Id}
        public IEnumerable<Grade> GetCourseGradeArray(string Id)
        {
            try
            {
                return GetCourseGradeArray(Id);
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
        /// 更改学生成绩
        /// </summary>
        /// <param name="score">成绩</param>
        /// <param name="studenid">学生Id</param>
        /// <param name="courseid">课程Id</param>
        /// <returns>修改是否成功</returns>
        //PUT: api/Grade?score={score}&studenid={studenid}&courseid={courseid}
        //PUT: api/Grade/ChangeCourseGrade?score={score}&studenid={studenid}&courseid={courseid}
        [HttpPut]
        public bool ChangeCourseGrade(string score, string studenid, string courseid)
        {
            try
            {
                return gradeBll.ChangeCourseGrade(score, studenid, courseid);
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
