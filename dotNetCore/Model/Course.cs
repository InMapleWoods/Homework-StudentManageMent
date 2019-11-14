using System.ComponentModel.DataAnnotations;

namespace Model
{
    /// <summary>
    /// 课程类
    /// </summary>
    public class Course
    {
        /// <summary>
        /// 课程Id
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 开课教师Id
        /// </summary>
        public int TeacherId { get; set; }
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public Course()
        {
            Id = 0;
            Name = "";
            TeacherId = 0;
        }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="id">课程Id</param>
        /// <param name="name">课程名称</param>
        /// <param name="teacherId">开课教师Id</param>
        public Course(int id, string name, int teacherId)
        {
            Id = id;
            Name = name;
            TeacherId = teacherId;
        }
    }
}
