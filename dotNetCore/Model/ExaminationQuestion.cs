using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    /// <summary>
    /// 问题类
    /// </summary>
    public class ExamQuestion
    {
        /// <summary>
        /// 题目类型
        /// </summary>
        public enum QuestionType
        {
            ChoiceQuestion,
            TrueOrFalseQuestion,
            ShortAnswerQuestion,
            GapFillingQuestion
        };
        /// <summary>
        /// 题目Id
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 考试Id
        /// </summary>
        [StringLength(50)]
        public int ExamId { get; set; }
        /// <summary>
        /// 序列化题目
        /// </summary>
        [StringLength(5000)]
        public string QuestionText { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public ExamQuestion()
        {
            Id = 0;
            ExamId = 0;
            QuestionText = "";
        }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="id">题目Id</param>
        /// <param name="examId">考试Id</param>
        /// <param name="examinationQuestion">题目</param>

        public ExamQuestion(int id, int examId, ExaminationQuestion examinationQuestion)
        {
            Id = id;
            ExamId = examId;
            QuestionText = JsonConvert.SerializeObject(examinationQuestion);
        }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="id">题目Id</param>
        /// <param name="examId">考试Id</param>
        /// <param name="examinationQuestionToString">题目</param>

        public ExamQuestion(int id, int examId, string examinationQuestionToString)
        {
            Id = id;
            ExamId = examId;
            QuestionText = examinationQuestionToString;
        }

        /// <summary>
        /// 获取题目对象
        /// </summary>
        /// <returns>题目对象</returns>
        public ExaminationQuestion GetExaminationQuestion()
        {
            return (ExaminationQuestion)JsonConvert.DeserializeObject(QuestionText);
        }
    }

    /// <summary>
    /// 题目类
    /// </summary>
    public class ExaminationQuestion
    {
        /// <summary>
        /// 题干
        /// </summary>
        public string Stem { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public ExaminationQuestion()
        {
            Stem = "";
        }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="stem"></param>
        public ExaminationQuestion(string stem)
        {
            Stem = stem;
        }
    }

    /// <summary>
    /// 选择题
    /// </summary>
    public class ChoiceQuestion : ExaminationQuestion
    {
        /// <summary>
        /// 正确答案
        /// </summary>
        public int choiceRightAnswer;

        /// <summary>
        /// 选项
        /// </summary>
        public readonly IEnumerable options = new List<string>();

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="rightAnswer">正确答案</param>
        /// <param name="options">选项</param>
        public ChoiceQuestion(int rightAnswer, IEnumerable options)
        {
            choiceRightAnswer = rightAnswer;
            this.options = options;
        }

        /// <summary>
        /// 增加选项
        /// </summary>
        /// <param name="strOp">选项内容</param>
        public void AddOption(string strOp)
        {
            ((List<string>)options).Add(strOp);
        }

        /// <summary>
        /// 更改选项
        /// </summary>
        /// <param name="index">选项索引</param>
        /// <param name="strOp">更改后内容</param>
        public void ChangeOption(int index, string strOp)
        {
            ((List<string>)options).RemoveAt(index);
            ((List<string>)options).Insert(index, strOp);
        }

        /// <summary>
        /// 删除选项
        /// </summary>
        /// <param name="index">选项索引</param>
        public void RemoveOption(int index)
        {
            ((List<string>)options).RemoveAt(index);
        }

        /// <summary>
        /// 获取选项列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetOption()
        {
            return options;
        }

        /// <summary>
        /// 获取正确答案
        /// </summary>
        /// <returns></returns>
        public int GetRightAnswer()
        {
            return choiceRightAnswer;
        }

        /// <summary>
        /// 设置正确答案
        /// </summary>
        /// <param name="index">选项索引</param>
        public void SetRightAnswer(int index)
        {
            choiceRightAnswer = index;
        }
    }

    /// <summary>
    /// 判断题
    /// </summary>
    public class TrueOrFalseQuestion : ExaminationQuestion
    {
        /// <summary>
        /// 正确答案
        /// </summary>
        public bool TOFRightAnswer { get; set; }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="rightAnswer">正确答案</param>
        public TrueOrFalseQuestion(bool rightAnswer)
        {
            TOFRightAnswer = rightAnswer;
        }
    }

    /// <summary>
    /// 简答题
    /// </summary>
    public class ShortAnswerQuestion : ExaminationQuestion
    {
        /// <summary>
        /// 参考答案
        /// </summary>
        public string shortAnsRightAnswer { get; set; }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="rightAnswer">正确答案</param>
        public ShortAnswerQuestion(string rightAnswer)
        {
            shortAnsRightAnswer = rightAnswer;
        }
    }

    /// <summary>
    /// 填空题
    /// </summary>
    public class GapFillingQuestion : ExaminationQuestion
    {
        /// <summary>
        /// 参考答案
        /// </summary>
        public string gapFillRightAnswer { get; set; }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="rightAnswer">正确答案</param>
        public GapFillingQuestion(string rightAnswer)
        {
            gapFillRightAnswer = rightAnswer;
        }
    }

}
