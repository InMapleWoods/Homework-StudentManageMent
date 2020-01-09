using Bll;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;

namespace StudentManagement_Web.Controllers
{
    /// <summary>
    /// 考试题目控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ApiQuestionController : ControllerBase
    {
        /// <summary>
        /// 题目数据操作对象
        /// </summary>
        private readonly QuestionBll questionBll = new QuestionBll();

        /// <summary>
        /// 获取指定考试的所有题目
        /// </summary>
        /// <param name="examid">考试Id</param>
        /// <returns>题目表</returns>
        // GET: api/ApiQuestion/GetExamAllQuestions?examid={examid}
        [HttpGet("GetExamAllQuestions")]
        public IActionResult GetExamAllQuestions(int examid)
        {
            try
            {
                return Ok(questionBll.GetExamAllQuestions(examid));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// 通过Id获取题目
        /// </summary>
        /// <param name="questionId">题目Id</param>
        /// <returns>符合条件的题目</returns>
        // GET: api/ApiQuestion/GetExaminationQuestionById?questionId={questionId}
        [HttpGet("GetExaminationQuestionById")]
        public IActionResult GetExaminationQuestionById(int questionId)
        {
            try
            {
                return Ok(questionBll.GetExaminationQuestionById(questionId));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// 按id删除题目
        /// </summary>
        /// <param name="id">题目Id</param>
        /// <returns>删除成功与否</returns>
        // DELETE: api/ApiQuestion/DeleteExaminationQuestion/{id}
        [HttpDelete("DeleteExaminationQuestion/{id}")]
        public IActionResult DeleteExaminationQuestion(int id)
        {
            try
            {
                return Ok(questionBll.DeleteExaminationQuestion(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        #region 增加题目

        /// <summary>
        /// 通过题目类型增加题目
        /// </summary>
        /// <param name="type">题目类型</param>
        /// <param name="examid">考试Id</param>
        /// <param name="stem">题目题干</param>
        /// <param name="parameters">题目参数</param>
        /// <returns>增加成功与否</returns>
        // POST: api/ApiQuestion/AddExamQuestion?type={type}&examid={examid}&stem={stem}
        [HttpPost("AddExamQuestion")]
        public IActionResult AddExamQuestion(int type, int examid, string stem, [FromBody]object[] parameters)
        {
            try
            {
                ExamQuestion.QuestionType questionType = (ExamQuestion.QuestionType)type;
                return Ok(questionBll.AddExamQuestion(questionType, examid, stem, parameters));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        #endregion

        #region 更改题目

        /// <summary>
        /// 通过题目类型更改题目
        /// </summary>
        /// <param name="type">题目类型</param>
        /// <param name="id">题目Id</param>
        /// <param name="examid">考试Id</param>
        /// <param name="stem">题目题干</param>
        /// <param name="parameters">题目参数</param>
        /// <returns>更改成功与否</returns>
        // PUT: api/ApiQuestion/UpdateExamQuestion/{id}?type={type}&examid={examid}&stem={stem}
        [HttpPut("UpdateExamQuestion/{id}")]
        public IActionResult UpdateExamQuestion(ExamQuestion.QuestionType type, int id, int examid, string stem, [FromBody]object[] parameters)
        {
            try
            {
                return Ok(questionBll.UpdateExamQuestion(type, id, examid, stem, parameters));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        #endregion
    }
}