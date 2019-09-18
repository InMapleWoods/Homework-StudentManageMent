using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Score = 0;
        }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="id">成绩Id</param>
        /// <param name="cid">课程Id</param>
        /// <param name="sid">学生Id</param>
        /// <param name="score">成绩数值</param>
        public Grade(int id,int cid,int sid,int score)
        {
            Id = id;
            CourseId = cid;
            StudentId = sid;
            Score = score;
        }
    }
}
