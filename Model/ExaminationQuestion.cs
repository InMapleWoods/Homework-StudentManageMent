using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 题目类
    /// </summary>
    public class ExaminationQuestion
    {
        /// <summary>
        /// 题干
        /// </summary>
        public string Stem { get; set; }
    }

    /// <summary>
    /// 选择题
    /// </summary>
    public class ChoiceQuestion : ExaminationQuestion
    {
        /// <summary>
        /// 正确答案
        /// </summary>
        private int rightAnswer;

        /// <summary>
        /// 选项
        /// </summary>
        private ArrayList options = new ArrayList();

        /// <summary>
        /// 增加选项
        /// </summary>
        /// <param name="strOp">选项内容</param>
        public void AddOption(string strOp)
        {
            options.Add(strOp);
        }

        /// <summary>
        /// 更改选项
        /// </summary>
        /// <param name="index">选项索引</param>
        /// <param name="strOp">更改后内容</param>
        public void ChangeOption(int index,string strOp)
        {
            options.RemoveAt(index);
            options.Insert(index, strOp);
        }

        /// <summary>
        /// 删除选项
        /// </summary>
        /// <param name="index">选项索引</param>
        public void RemoveOption(int index)
        {
            options.RemoveAt(index);
        }

        /// <summary>
        /// 获取选项列表
        /// </summary>
        /// <returns></returns>
        public ArrayList GetOption()
        {
            return options;
        }

        /// <summary>
        /// 获取正确答案
        /// </summary>
        /// <returns></returns>
        public int GetRightAnswer()
        {
            return rightAnswer;
        }

        /// <summary>
        /// 设置正确答案
        /// </summary>
        /// <param name="index">选项索引</param>
        public void SetRightAnswer(int index)
        {
            rightAnswer = index;
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
        private bool rightAnswer { get; set; }
    }
    /// <summary>
    /// 简答题
    /// </summary>
    public class ShortAnswerQuestion : ExaminationQuestion
    {
        /// <summary>
        /// 参考答案
        /// </summary>
        private bool rightAnswer { get; set; }
    }
    /// <summary>
    /// 填空题
    /// </summary>
    public class GapFillingQuestion : ExaminationQuestion
    {
        /// <summary>
        /// 参考答案
        /// </summary>
        private bool rightAnswer { get; set; }
    }
}
