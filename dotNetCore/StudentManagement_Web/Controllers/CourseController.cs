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
        /// 获取分页后的课程
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <returns>分页后课程</returns>
        //GET: api/ApiCourse/GetPaperCourseArray?index={index}&size={size}
        [HttpGet("GetPaperCourseArray")]
        public IActionResult GetPaperCourseArray(int index, int size)
        {
            try
            {
                var users = courseBll.GetPaperCourseArray(index, size);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// 获取分页后的课程列表总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        //GET: api/ApiCourse/GetAllPageNum?size={size}
        [HttpGet("GetAllPageNum")]
        public IActionResult GetAllPageNum(int size)
        {
            try
            {
                return Ok(courseBll.GetAllPageNum(size));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// 获取学生未选课程总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        //GET: api/ApiCourse/GetStudentNoChooseCoursePageNum/{id}?size={size}
        [HttpGet("GetStudentNoChooseCoursePageNum/{id}")]
        public IActionResult GetStudentNoChooseCoursePageNum(int size, string id)
        {
            try
            {
                return Ok(courseBll.GetStudentNoChooseCoursePageNum(size, id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// 获取学生已选课程总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        //GET: api/ApiCourse/GetStudentAllCoursePageNum/{id}?size={size}
        [HttpGet("GetStudentAllCoursePageNum/{id}")]
        public IActionResult GetStudentAllCoursePageNum(int size, string id)
        {
            try
            {
                return Ok(courseBll.GetStudentAllCoursePageNum(size, id));
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
        //GET: api/ApiCourse/GetStudentAllCourseArray/{Id}?index={index}&size={size}
        [HttpGet("GetStudentAllCourseArray/{Id}")]
        public IActionResult GetStudentAllCourseArray(string Id, int index, int size)
        {
            try
            {
                return Ok(courseBll.GetStudentAllCourseArray(Id, index, size));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// 获取学生未选课程
        /// </summary>
        /// <returns>全部课程数据表</returns>
        //GET: api/ApiCourse/GetStudentNoChooseCourseArray/{Id}?index={index}&size={size}
        [HttpGet("GetStudentNoChooseCourseArray/{Id}")]
        public IActionResult GetStudentNoChooseCourseArray(string Id, int index, int size)
        {
            try
            {
                return Ok(courseBll.GetStudentNoChooseCourseArray(Id, index, size));
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
