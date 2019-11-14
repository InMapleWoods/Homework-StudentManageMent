using System.ComponentModel.DataAnnotations;

namespace Model
{
    /// <summary>
    /// 成绩类
    /// </summary>
    public class Grade
    {
        /// <summary>
        /// 成绩Id
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 课程Id
        /// </summary>
        public int CourseId { get; set; }
        /// <summary>
        /// 学生Id
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// 考试Id
        /// </summary>
        public int ExamId { get; set; }
        /// <summary>
        /// 学生成绩
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public Grade()
        {
            Id = 0;
            CourseId = 0;
            StudentId = 0;
            ExamId = 0;
            Score = 0;
        }
        /// <summary>
        /// 有参构造函数（学生总成绩）
        /// </summary>
        /// <param name="id">成绩Id</param>
        /// <param name="cid">课程Id</param>
        /// <param name="sid">学生Id</param>
        /// <param name="score">成绩数值</param>
        public Grade(int id, int cid, int sid, int score)
        {
            Id = id;
            CourseId = cid;
            StudentId = sid;
            Score = score;
        }
        /// <summary>
        /// 有参构造函数（某次考试成绩）
        /// </summary>
        /// <param name="id">成绩Id</param>
        /// <param name="cid">课程Id</param>
        /// <param name="sid">学生Id</param>
        /// <param name="eid">考试Id</param>
        /// <param name="score">成绩数值</param>
        public Grade(int id, int cid, int sid, int eid, int score)
        {
            Id = id;
            CourseId = cid;
            StudentId = sid;
            ExamId = eid;
            Score = score;
        }
    }
}
