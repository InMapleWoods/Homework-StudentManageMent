using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    /// <summary>
    /// 考试类
    /// </summary>
    public class Examination
    {
        /// <summary>
        /// 考试Id
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 课程Id
        /// </summary>
        [Key]
        public int CourseId { get; set; }
        /// <summary>
        /// 考试时间
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 考试名称
        /// </summary>
        [StringLength(500)]
        public string Name { get; set; }
        
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public Examination()
        {
            Id = 0;
            CourseId = 0;
            Time = DateTime.Now;
            Name = "";
        }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="id">考试Id</param>
        /// <param name="courseId">课程Id</param>
        /// <param name="time">考试时间</param>
        /// <param name="name">考试名称</param>
        public Examination(int id, int courseId, DateTime time,  string name)
        {
            Id = id;
            CourseId = courseId;
            Time = time;
            Name = name;
        }
    }
}
