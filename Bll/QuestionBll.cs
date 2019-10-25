using Dal;
using Model;
using System;
using System.Data;

namespace Bll
{
    /// <summary>
    /// 题目用户层
    /// </summary>
    public class QuestionBll
    {
        /// <summary>
        /// 题目数据操作对象
        /// </summary>
        private QuestionDal questionDal = new QuestionDal();

        /// <summary>
        /// 获取指定考试的所有题目
        /// </summary>
        /// <param name="examid">考试Id</param>
        /// <returns>题目表</returns>
        public DataTable GetExamAllQuestions(int examid)
        {
            DataTable result = null;
            try
            {
                result = questionDal.GetExamAllQuestions(examid);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;
        }

        /// <summary>
        /// 通过Id获取题目
        /// </summary>
        /// <param name="questionId">题目Id</param>
        /// <returns>符合条件的题目</returns>
        public ExamQuestion GetExaminationQuestionById(int questionId)
        {
            ExamQuestion result = null;
            try
            {
                result = questionDal.GetExaminationQuestionById(questionId);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;
        }

        /// <summary>
        /// 按id删除题目
        /// </summary>
        /// <param name="id">题目Id</param>
        /// <returns>删除成功与否</returns>
        public bool DeleteExaminationQuestion(int id)
        {
            bool result = false;
            try
            {
                result = questionDal.DeleteExaminationQuestion(id);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;
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
        public bool AddExamQuestion(ExamQuestion.QuestionType type, int examid, string stem, object[] parameters)
        {
            bool result = false;
            try
            {
                result = questionDal.AddExamQuestion(type, examid, stem, parameters);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;
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
        public bool UpdateExamQuestion(ExamQuestion.QuestionType type, int id, int examid, string stem, object[] parameters)
        {
            bool result = false;
            try
            {
                result = questionDal.UpdateExamQuestion(type, id, examid, stem, parameters);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;
        }
        #endregion
    }
}