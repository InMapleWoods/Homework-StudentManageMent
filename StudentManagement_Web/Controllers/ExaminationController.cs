using Bll;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace StudentManagement_Web.Controllers
{
    /// <summary>
    /// 考试控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ApiExaminationController : ControllerBase
    {
        /// <summary>
        /// 考试操作对象
        /// </summary>
        readonly ExaminationBll examinationBll = new ExaminationBll();

        /// <summary>
        /// 获取考试分页列表
        /// </summary>
        /// <param name="index">页索引</param>
        /// <param name="size">页容量</param>
        /// <returns>考试列表</returns>
        // GET: api/ApiExamination/GetExam?index={index}&&size={size}
        [HttpGet("GetExam")]
        public IActionResult GetExam(int index, int size)
        {
            try
            {
                return Ok(examinationBll.GetPageExamApplyArray(index, size));
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// 获取考试分页列表
        /// </summary>
        /// <param name="index">页索引</param>
        /// <param name="size">页容量</param>
        /// <returns>考试列表</returns>
        // GET: api/ApiExamination/GetExam?index={index}&&size={size}
        [HttpGet("GetExam")]
        public IActionResult GetExam(int index, int size)
        {
            try
            {
                return Ok(examinationBll.GetPageExamApplyArray(index, size));
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
        // GET: api/Examination
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Examination/5
        [HttpGet("{id}", Name = "GetExaminationById")]
        public string GetExaminationById(int id)
        {
            return "value";
        }

        // POST: api/Examination
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Examination/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
