﻿using Bll;
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
        /// 教师获取学生成绩
        /// </summary>
        /// <returns>全部学生成绩数据表</returns>
        //GET: api/ApiGrade/GetCourseGradeArray/{Id}
        [HttpGet("{id}", Name = "GetCourseGradeArray")]
        public IActionResult GetCourseGradeArray(string Id)
        {
            try
            {
                return Ok(gradeBll.GetCourseGradeArray(Id));
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
        //PUT: api/ApiGrade/ChangeCourseGrade?score={score}&studenid={studenid}&courseid={courseid}
        [HttpPut("ChangeCourseGrade")]
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