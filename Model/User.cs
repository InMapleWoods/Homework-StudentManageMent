using System.ComponentModel.DataAnnotations;

namespace Model
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Key]
        public int UserID { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        [StringLength(50)]
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [StringLength(500)]
        public string PassWord { get; set; }
        /// <summary>
        /// 用户角色
        /// </summary>
        public int Role { get; set; }
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public User()
        {
            UserID = 0;
            UserName = "";
            PassWord = "";
            Role = 0;
        }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="userName">用户姓名</param>
        /// <param name="passWord">用户密码</param>
        /// <param name="role">用户角色</param>
        public User(int userID, string userName, string passWord,  int role)
        {
            UserID = userID;
            UserName = userName;
            PassWord = passWord;
            Role = role;
        }
    }
}
