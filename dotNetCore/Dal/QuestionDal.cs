﻿using Model;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace Dal
{
    /// <summary>
    /// 考试题目数据操作层
    /// </summary>
    public class QuestionDal
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        const string sqlConnect = "server=152.136.73.240;database=db_StudentManage;uid=Lsa;pwd=llfllf";

        /// <summary>
        /// SQL帮助类
        /// </summary>
        readonly SQLHelper helper = new SQLHelper(sqlConnect);

        /// <summary>
        /// 获取指定考试的所有题目
        /// </summary>
        /// <param name="examid">考试Id</param>
        /// <returns>题目表</returns>
        public DataTable GetExamAllQuestions(int examid)
        {
            string str = "select * from tb_ExamQuestion where ExamId=@examid";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@examid",examid),
            };
            DataTable dataTable = helper.ExecuteQuery(str, sqlParameters, CommandType.Text);
            return dataTable;
        }

        /// <summary>
        /// 通过Id获取题目
        /// </summary>
        /// <param name="questionId">题目Id</param>
        /// <returns>符合条件的题目</returns>
        public ExamQuestion GetExaminationQuestionById(int questionId)
        {
            string str = "select * from tb_ExamQuestion where Id=@questionid";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@questionid",questionId),
            };
            using (DataTable dataTable = helper.ExecuteQuery(str, sqlParameters, CommandType.Text))
            {
                if (dataTable.Rows.Count == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    return new ExamQuestion((int)dr["Id"], (int)dr["ExamId"], dr["QuestionText"].ToString());
                }
                return null;
            }
        }

        /// <summary>
        /// 按id删除题目
        /// </summary>
        /// <param name="id">题目Id</param>
        /// <returns>删除成功与否</returns>
        public bool DeleteExaminationQuestion(int id)
        {
            string str = "delete from tb_ExamQuestion where Id=@id";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@id",id),
            };
            int result = helper.ExecuteNonQuery(str, sqlParameters, CommandType.Text);
            if (result > 0)
                return true;
            return false;
        }

        #region 增加题目
        /// <summary>
        /// 增加题目
        /// </summary>
        /// <param name="question">题目对象</param>
        /// <returns>增加成功与否</returns>
        private bool AddExaminationQuestion(ExamQuestion question)
        {
            if (question == null)
                return false;
            string str = "insert into tb_ExamQuestion(Id,ExamId,QuestionText) Values(@questionid,@examid,@questiontext)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@questionid",question.Id),
                new SqlParameter("@examid",question.ExamId),
                new SqlParameter("@questiontext",question.QuestionText),
            };
            int result = helper.ExecuteNonQuery(str, sqlParameters, CommandType.Text);
            if (result > 0)
                return true;
            return false;
        }

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
            if (parameters == null)
                return false;
            ExaminationQuestion question = null;
            switch (type)
            {
                case ExamQuestion.QuestionType.ChoiceQuestion:
                    if (parameters.Length == 2)
                    {
                        question = new ChoiceQuestion((int)parameters[0], (ArrayList)parameters[1]);
                    }
                    else
                        return false;
                    break;
                case ExamQuestion.QuestionType.GapFillingQuestion:
                    if (parameters.Length == 1)
                    {
                        question = new GapFillingQuestion(parameters[0].ToString());
                    }
                    else
                        return false;
                    break;
                case ExamQuestion.QuestionType.ShortAnswerQuestion:
                    if (parameters.Length == 1)
                    {
                        question = new ShortAnswerQuestion(parameters[0].ToString());
                    }
                    else
                        return false;
                    break;
                case ExamQuestion.QuestionType.TrueOrFalseQuestion:
                    if (parameters.Length == 1)
                    {
                        question = new TrueOrFalseQuestion((bool)parameters[0]);
                    }
                    else
                        return false;
                    break;
            }
            if (question == null)
                return false;
            question.Stem = stem;
            ExamQuestion examQuestion = new ExamQuestion(0, examid, question);
            return AddExaminationQuestion(examQuestion);

        }
        #endregion

        #region 更改题目
        /// <summary>
        /// 更新题目信息
        /// </summary>
        /// <param name="question">更新后的题目</param>
        /// <returns>更新成功与否</returns>
        private bool UpdateExaminationQuestion(ExamQuestion question)
        {
            string str = "Update tb_ExamQuestion set ExamId=@examid,QuestionText=@questiontext where Id=@id";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@examid",question.ExamId),
                new SqlParameter("@id",question.Id),
                new SqlParameter("@questiontext",question.QuestionText),
            };
            int result = helper.ExecuteNonQuery(str, sqlParameters, CommandType.Text);
            if (result > 0)
                return true;
            return false;
        }

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
            if (parameters == null)
                return false;
            ExaminationQuestion question = null;
            switch (type)
            {
                case ExamQuestion.QuestionType.ChoiceQuestion:
                    if (parameters.Length == 2)
                    {
                        question = new ChoiceQuestion((int)parameters[0], (ArrayList)parameters[1]);
                    }
                    else
                        return false;
                    break;
                case ExamQuestion.QuestionType.GapFillingQuestion:
                    if (parameters.Length == 1)
                    {
                        question = new GapFillingQuestion(parameters[0].ToString());
                    }
                    else
                        return false;
                    break;
                case ExamQuestion.QuestionType.ShortAnswerQuestion:
                    if (parameters.Length == 1)
                    {
                        question = new ShortAnswerQuestion(parameters[0].ToString());
                    }
                    else
                        return false;
                    break;
                case ExamQuestion.QuestionType.TrueOrFalseQuestion:
                    if (parameters.Length == 1)
                    {
                        question = new TrueOrFalseQuestion((bool)parameters[0]);
                    }
                    else
                        return false;
                    break;
            }
            if (question == null)
                return false;
            question.Stem = stem;
            ExamQuestion examQuestion = new ExamQuestion(id, examid, question);
            return UpdateExaminationQuestion(examQuestion);
        }
        #endregion
    }
}
