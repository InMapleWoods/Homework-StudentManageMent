using Bll;
using Microsoft.AspNetCore.Mvc;
using System;

namespace StudentManagement_Web.Controllers
{
    /// <summary>
    /// 课程控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCourseController : ControllerBase
    {  /// <summary>
       /// 课程操作对象
       /// </summary>
        readonly CourseBll courseBll = new CourseBll();
        /// <summary>
        /// 获取全部课程
        /// </summary>
        /// <returns>全部课程数据表</returns>
        //GET: api/ApiCourse/GetAllCourseArray
        [HttpGet("GetAllCourseArray")]
        public IActionResult GetAllCourseArray()
        {
            try
            {
                return Ok(courseBll.GetAllCourseArray());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// 获取学生已选课程
        /// </summary>
        /// <returns>全部课程数据表</returns>
        //GET: api/ApiCourse/GetStudentAllCourseArray/{Id}
        [HttpGet("GetStudentAllCourseArray/{Id}")]
        public IActionResult GetStudentAllCourseArray(string Id)
        {
            try
            {
                return Ok(courseBll.GetStudentAllCourseArray(Id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// 增加课程
        /// </summary>
        /// <param name="name">课程名称</param>
        /// <param name="teacherId">教师Id</param>
        /// <returns>增加成功与否</returns>
        //PUT: api/ApiCourse/AddCourse?name={name}&teacherId={teacherId}
        [HttpPut("AddCourse")]
        public IActionResult AddCourse(string name, string teacherId)
        {
            try
            {
                return Ok(courseBll.AddCourse(name, teacherId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// 学生选课
        /// </summary>
        /// <param name="UserId">学生Id</param>
        /// <param name="CourseId">课程Id</param>
        /// <returns>选课成功与否</returns>
        //PUT: api/ApiCourse/ChooseCourse?UserId={UserId}&CourseId={CourseId}
        [HttpPut("ChooseCourse")]
        public IActionResult ChooseCourse(string UserId, string CourseId)
        {
            try
            {
                return Ok(courseBll.ChooseCourse(UserId, CourseId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// 删除选择课程
        /// </summary>
        /// <param name="UserId">学生Id</param>
        /// <param name="CourseId">课程Id</param>
        /// <returns>删除成功与否</returns>
        //DELETE: api/ApiCourse/DeleteStudentCourse?UserId={UserId}&CourseId={CourseId}
        [HttpDelete("DeleteStudentCourse")]
        public IActionResult DeleteStudentCourse(string UserId, string CourseId)
        {
            try
            {
                return Ok(courseBll.DeleteStudentCourse(UserId, CourseId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// 删除课程
        /// </summary>
        /// <param name="CourseId">课程Id</param>
        /// <returns>删除成功与否</returns>
        //DELETE: api/ApiCourse/DeleteCourse?CourseId={CourseId}
        [HttpDelete("DeleteCourse")]
        public IActionResult DeleteCourse(string CourseId)
        {
            try
            {
                return Ok(courseBll.DeleteCourse(CourseId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
