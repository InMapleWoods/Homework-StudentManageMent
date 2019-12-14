using Bll;
using Microsoft.AspNetCore.Mvc;
using System;

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
        private readonly ExaminationBll examinationBll = new ExaminationBll();

        /// <summary>
        /// 获取考试分页列表
        /// </summary>
        /// <param name="index">页索引</param>
        /// <param name="size">页容量</param>
        /// <returns>考试列表</returns>
        // GET: api/ApiExamination/GetExam?index={index}&size={size}
        [HttpGet("GetExam")]
        public IActionResult GetExam(int index, int size)
        {
            try
            {
                return Ok(examinationBll.GetPageExamArray(index, size));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// 获取考试分页列表
        /// </summary>
        /// <param name="index">页索引</param>
        /// <param name="size">页容量</param>
        /// <param name="id">课程Id</param>
        /// <returns>考试列表</returns>
        // GET: api/ApiExamination/GetExam/{id}?index={index}&size={size}
        [HttpGet("GetExam/{id}")]
        public IActionResult GetExam(int index, int size, int id)
        {
            try
            {
                return Ok(examinationBll.GetPageExamArray(index, size, id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// 获取分页后的考试列表总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        // GET: api/ApiExamination/GetAllPageNum?size={size}
        [HttpGet("GetAllPageNum")]
        public IActionResult GetAllPageNum(int size)
        {
            try
            {
                return Ok(examinationBll.GetAllPageNum(size));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// 获取分页后的考试列表总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <param name="id">学生Id</param>
        /// <returns>分页数</returns>
        // GET: api/ApiExamination/GetAllPageNum/{id}?size={size}
        [HttpGet("GetAllPageNum/{id}")]
        public IActionResult GetAllPageNum(int size, int id)
        {
            try
            {
                return Ok(examinationBll.GetAllPageNum(size, id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// 按Id获取考试
        /// </summary>
        /// <param name="id">考试Id</param>
        /// <returns>符合条件的考试</returns>
        // GET: api/ApiExamination/5
        [HttpGet("{id}", Name = "GetExaminationById")]
        public IActionResult GetExaminationById(int id)
        {
            try
            {
                return Ok(examinationBll.GetExaminationById(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// 按课程Id获取考试
        /// </summary>
        /// <param name="courseId">课程Id</param>
        /// <returns>符合条件的考试</returns>
        // GET: api/ApiExamination/GetExaminationByCourseId/5
        [HttpGet("GetExaminationByCourseId/{courseId}")]
        public IActionResult GetExaminationByCourseId(int courseId)
        {
            try
            {
                return Ok(examinationBll.GetExaminationByCourseIdArray(courseId));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// 按教师Id获取考试
        /// </summary>
        /// <param name="id">教师Id</param>
        /// <returns>符合条件的考试</returns>
        // GET: api/ApiExamination/GetExaminationByTeacherId/5
        [HttpGet("GetExaminationByTeacherId/{id}")]
        public IActionResult GetExaminationByTeacherId(int id)
        {
            try
            {
                return Ok(examinationBll.GetExaminationByTeacherIdArray(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// 修改考试时间
        /// </summary>
        /// <param name="time">考试时间</param>
        /// <param name="id">需要修改的考试id</param>
        /// <returns>修改成功与否</returns>
        // PUT: api/ApiExamination/UpdateExaminationTime/8?time={time}
        [HttpPut("UpdateExaminationTime/{id}")]
        public IActionResult UpdateExaminationTime(int id, DateTime time)
        {
            try
            {
                return Ok(examinationBll.UpdateExaminationTime(time, id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// 修改考试名称
        /// </summary>
        /// <param name="name">考试名称</param>
        /// <param name="id">需要修改的考试id</param>
        /// <returns>修改成功与否</returns>
        // PUT: api/ApiExamination/UpdateExaminationName/8?name={name}
        [HttpPut("UpdateExaminationName/{id}")]
        public IActionResult UpdateExaminationName(int id, string name)
        {
            try
            {
                return Ok(examinationBll.UpdateExaminationName(name, id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// 删除考试
        /// </summary>
        /// <param name="id">考试Id</param>
        /// <returns>删除成功与否</returns>
        // DELETE: api/ApiExamination/8
        [HttpDelete("{id}")]
        public IActionResult DeleteExamination(int id)
        {
            try
            {
                return Ok(examinationBll.DeleteExamination(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// 获取考试申请分页列表
        /// </summary>
        /// <param name="index">页索引</param>
        /// <param name="size">页容量</param>
        /// <returns>考试申请列表</returns>
        // GET: api/ApiExamination/GetExamApply?index={index}&size={size}
        [HttpGet("GetExamApply")]
        public IActionResult GetExamApply(int index, int size)
        {
            try
            {
                return Ok(examinationBll.GetPageExamApplyArray(index, size));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// 获取分页后的考试申请列表总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        // GET: api/ApiExamination/GetAllPageApplyNum?size={size}
        [HttpGet("GetAllPageApplyNum")]
        public IActionResult GetAllPageApplyNum(int size)
        {
            try
            {
                return Ok(examinationBll.GetAllPageApplyNum(size));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        /// <summary>
        /// 获取考试申请分页列表
        /// </summary>
        /// <param name="id">教师Id</param>
        /// <param name="index">页索引</param>
        /// <param name="size">页容量</param>
        /// <returns>考试申请列表</returns>
        // GET: api/ApiExamination/GetExamApply/{id}?index={index}&size={size}
        [HttpGet("GetExamApply/{id}")]
        public IActionResult GetExamApply(int id, int index, int size)
        {
            try
            {
                return Ok(examinationBll.GetPageExamApplyArray(index, size, id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// 获取分页后的考试申请列表总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <param name="id">教师Id</param>
        /// <returns>分页数</returns>
        // GET: api/ApiExamination/GetAllPageApplyNum/{id}?size={size}
        [HttpGet("GetAllPageApplyNum/{id}")]
        public IActionResult GetAllPageApplyNum(int id, int size)
        {
            try
            {
                return Ok(examinationBll.GetAllPageApplyNum(size, id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// 增加考试申请
        /// </summary>
        /// <param name="examApply">考试申请</param>
        /// <returns>增加成功与否</returns>
        // POST: api/ApiExamination/AddExamApply
        [HttpPost("AddExamApply")]
        public IActionResult AddExamApply([FromBody]dynamic examApply)
        {
            try
            {
                dynamic examApplyObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(examApply.ToString());
                int teacherId = examApplyObject.teacherId;
                int examId = examApplyObject.examination.Id;
                int courseId = examApplyObject.examination.CourseId;
                DateTime time = examApplyObject.examination.Time;
                int duration = examApplyObject.examination.Duration;
                string name = examApplyObject.examination.Name;
                Model.Examination examination = new Model.Examination(examId, courseId, time, name, duration);
                bool result = examinationBll.AddExamApply(examination, teacherId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// 接受考试申请
        /// </summary>
        /// <param name="id">考试申请Id</param>
        /// <returns>接受成功与否</returns>
        // PUT: api/ApiExamination/Accpet/5
        [HttpPut("Accpet/{id}")]
        public IActionResult AccpetExamApply(int id)
        {
            try
            {
                return Ok(examinationBll.AccpetExamApply(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// 拒绝考试申请
        /// </summary>
        /// <param name="id">考试申请Id</param>
        /// <returns>拒绝成功与否</returns>
        // PUT: api/ApiExamination/Reject/5
        [HttpPut("Reject/{id}")]
        public IActionResult RejectExamApply(int id)
        {
            try
            {
                return Ok(examinationBll.RejectExamApply(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
