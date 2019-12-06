using Bll;
using Microsoft.AspNetCore.Mvc;
using System;

namespace StudentManagement_Web.Controllers
{
    /// <summary>
    /// 成绩控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ApiGradeController : ControllerBase
    {
        /// <summary>
        /// 成绩操作对象
        /// </summary>
        private readonly GradeBll gradeBll = new GradeBll();
        /// <summary>
        /// 获取学生成绩
        /// </summary>
        /// <param name="id">学生Id</param>
        /// <param name="courseId">课程Id</param>
        /// <param name="examId">考试Id</param>
        /// <returns>全部学生成绩数据表</returns>
        //GET: api/ApiGrade/GetStudentGradeArray/{id}?courseId={courseId}&examId={examId}
        [HttpGet("GetStudentGradeArray/{id}")]
        public IActionResult GetStudentGradeArray(string id, string courseId, string examId)
        {
            try
            {
                return Ok(gradeBll.GetStudentGradeArray(id, courseId, examId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// 教师获取学生某考试成绩
        /// </summary>
        /// <param name="id">考试Id</param>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <returns>全部学生成绩数据表</returns>
        //GET: api/ApiGrade/GetExamGradeArray/{id}?index={index}&size={size}
        [HttpGet("GetExamGradeArray/{id}")]
        public IActionResult GetExamGradeArray(string id, int index, int size)
        {
            try
            {
                return Ok(gradeBll.GetExamGradeArray(id, index, size));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// 教师获取学生成绩
        /// </summary>
        /// <returns>全部学生成绩数据表</returns>
        //GET: api/ApiGrade/GetCourseGradeArray/{id}?index={index}&size={size}
        [HttpGet("GetCourseGradeArray/{id}")]
        public IActionResult GetCourseGradeArray(string id, int index, int size)
        {
            try
            {
                return Ok(gradeBll.GetCourseGradeArray(id, index, size));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// 获取全部学生全部成绩
        /// </summary>
        /// <param name="id">教师Id</param>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <returns>全部学生成绩数据表</returns>
        //GET: api/ApiGrade/GetAllStudentAllGrade/{id}?index={index}&size={size}
        [HttpGet("GetAllStudentAllGrade/{id}")]
        public IActionResult GetAllStudentAllGrade(string id, int index, int size)
        {
            try
            {
                return Ok(gradeBll.GetAllStudentAllGrade(id, index, size));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// 获取教师获取学生成绩列表总页数
        /// </summary>
        /// <param name="id">课程Id</param>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        //GET: api/ApiGrade/GetAllCoursePageNum/{id}?size={size}
        [HttpGet("GetAllCoursePageNum/{id}")]
        public IActionResult GetAllCoursePageNum(string id, int size)
        {
            try
            {
                return Ok(gradeBll.GetAllCoursePageNum(id, size));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// 获取学生某考试成绩列表总页数
        /// </summary>
        /// <param name="id">考试Id</param>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        //GET: api/ApiGrade/GetAllExamPageNum/{id}?size={size}
        [HttpGet("GetAllExamPageNum/{id}")]
        public IActionResult GetAllExamPageNum(string id, int size)
        {
            try
            {
                return Ok(gradeBll.GetAllExamPageNum(id, size));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// 更改学生成绩
        /// </summary>
        /// <param name="score">成绩</param>
        /// <param name="studenid">学生Id</param>
        /// <param name="courseid">课程Id</param>
        /// <returns>修改是否成功</returns>
        //PUT: api/ApiGrade/ChangeCourseGrade?score={score}&studenid={studenid}&courseid={courseid}
        [HttpPut("ChangeCourseGrade")]
        public IActionResult ChangeCourseGrade(string score, string studenid, string courseid)
        {
            try
            {
                return Ok(gradeBll.ChangeCourseGrade(score, studenid, courseid));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// 更改学生某考试成绩
        /// </summary>
        /// <param name="score">成绩</param>
        /// <param name="studenid">学生Id</param>
        /// <param name="examid">考试Id</param>
        /// <returns>修改是否成功</returns>
        //PUT: api/ApiGrade/ChangeExamGrade?score={score}&studenid={studenid}&examid={examid}
        [HttpPut("ChangeExamGrade")]
        public IActionResult ChangeExamGrade(string score, string studenid, string examid)
        {
            try
            {
                return Ok(gradeBll.ChangeExamGrade(score, studenid, examid));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
