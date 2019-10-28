﻿using Bll;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        readonly GradeBll gradeBll = new GradeBll();
        /// <summary>
        /// 获取学生成绩
        /// </summary>
        /// <returns>全部学生成绩数据表</returns>
        //GET: api/Grade/GetStudentGradeArray/{Id}
        [HttpGet("{id}",Name = "GetStudentGradeArray")]
        public IActionResult GetStudentGradeArray(string Id)
        {
            try
            {
                return Ok(GetStudentGradeArray(Id));
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
        //GET: api/Grade/GetCourseGradeArray/{Id}
        [HttpGet("{id}",Name = "GetCourseGradeArray")]
        public IActionResult GetCourseGradeArray(string Id)
        {
            try
            {
                return Ok(GetCourseGradeArray(Id));
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
        //PUT: api/Grade/ChangeCourseGrade?score={score}&studenid={studenid}&courseid={courseid}
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
    }
}
