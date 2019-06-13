using Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Dal
{
    /// <summary>
    /// 用户访问类
    /// </summary>
    public class UserDal
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        static readonly string sqlConnect = "server=152.136.73.240;database=db_StudentManage;uid=Lsa;pwd=llfllf";

        /// <summary>
        /// 登录用户
        /// </summary>
        public User t = null;
        /// <summary>
        /// 验证码图片
        /// </summary>
        public Bitmap validatePicture = null;
        /// <summary>
        /// 验证码
        /// </summary>
        public string validateNum = "";
        /// <summary>
        /// 登录角色
        /// </summary>
        public string Role = null;

        public bool LoginSystem(string id, string password)
        {
            //MD5加密密码
            string pwd = helper.GetMD5(password);
            //编写SQL语句
            string sqlstr = "SELECT * FROM tb_Users where Id='" + id + "' AND Password='" + pwd + "'";
            //将返回的结果保存在datatable中
            System.Data.DataTable dataTable = helper.reDt(sqlstr);
            if (dataTable.Rows.Count == 1)//如果返回一个结果
            {
                DataRow dr = dataTable.Rows[0];
                int userId = (int)dr["Id"];
                string name = dr["Name"].ToString();
                string psw = dr["Password"].ToString();
                int Role = (int)dr["Role"];
                if (Role == 0)//未审核人员无法访问
                {
                    throw new Exception("注册未审核，请联系管理员");
                }
                else
                {
                    t = new User(userId, name, psw, Role);//将用户信息保存到变量t中
                    if (Role == 3)
                    {
                        this.Role = "管理员";
                    }
                    else if (Role == 2)
                    {
                        this.Role = "老师";
                    }
                    else
                    {
                        this.Role = "学生";
                    }
                    return true;
                }
            }
            else if (dataTable.Rows.Count > 1)//返回结果不止一个
            {
                throw new Exception("未知用户重复错误，请联系管理员");
            }
            else//返回结果为0个
            {
                throw new Exception("用户名或密码不正确，请重新输入");
            }
        }

        /// <summary>
        /// 获得n位验证码
        /// </summary>
        /// <param name="num">验证码位数</param>
        /// <returns>返回num位的验证码图片</returns>
        public Bitmap GetValidate(int num)
        {
            return CreateImage(CreateRandomNum(num));
        }

        /// <summary>
        /// 获得n位验证码
        /// </summary>
        /// <param name="NumCount">位数</param>
        /// <returns>验证码字符串</returns>
        public string CreateRandomNum(int NumCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string RandomNum = "";
            int temp = -1;//避免重复随机数
            Random random = new Random();
            for (int i = 0; i < NumCount; i++)
            {
                if (temp != -1)
                {
                    random = new Random(i * temp * ((int)DateTime.Now.Millisecond));
                }
                int t = random.Next(35);
                if (t == temp)
                {
                    return CreateRandomNum(NumCount);
                }
                temp = t;
                RandomNum += allCharArray[t];
            }
            validateNum = RandomNum;
            return RandomNum;
        }

        /// <summary>
        /// 获得验证码图片
        /// </summary>
        /// <param name="validateNum">验证码字符串</param>
        /// <returns>返回验证码图片</returns>
        public Bitmap CreateImage(string validateNum)
        {
            if (validateNum == null || validateNum.Trim() == string.Empty)
            {
                return null;
            }
            Color[] colors = new Color[] { Color.Silver, Color.SlateGray, Color.Wheat, Color.YellowGreen, Color.Pink };
            Bitmap image = new Bitmap(100, 40);
            Graphics graphics = Graphics.FromImage(image);
            try
            {
                Random random = new Random();
                graphics.Clear(Color.White);//清空背景色
                //绘制背景
                for (int i = 0; i < 15; i++)
                {
                    int RandomColor = random.Next(colors.Length - 1);
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    graphics.DrawLine(new Pen(colors[RandomColor]), x1, y1, x2, y2);
                }
                //绘制文字
                Font font = new Font("Arial", 20, FontStyle.Bold | FontStyle.Strikeout | FontStyle.Italic);
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.DarkBlue, Color.Red, 1.2f, true);
                graphics.DrawString(validateNum, font, brush, 2, 2);
                //绘制前景
                for (int i = 0; i < 25; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //绘制边框
                graphics.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                graphics.Dispose();
            }
            validatePicture = image;
            return image;
        }

        /// <summary>
        /// SQL帮助类
        /// </summary>
        readonly SQLHelper helper = new SQLHelper(sqlConnect);

        /// <summary>
        /// 获取User
        /// </summary>
        /// <returns>用户对象</returns>
        public User GetUser()
        {
            return t;
        }
        /// <summary>
        /// 设置User
        /// </summary>
        /// <param name="user">用户对象</param>
        public void SetUser(User user)
        {
            t=user;
        }
        /// <summary>
        /// 登录操作
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <param name="validate">验证码</param>
        /// <returns>登录成功与否</returns>
        public bool Login(string account, string password)
        {
            return LoginSystem(account, password);
        }

        /// <summary>
        /// 获取账号密码对应的用户
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns>用户</returns>
        public User GetUserLogin(string account)
        {
            //编写SQL语句
            string sqlstr = "SELECT * FROM tb_Users where Id='" + account + "'";
            //将返回的结果保存在datatable中
            System.Data.DataTable dataTable = helper.reDt(sqlstr);
            if (dataTable.Rows.Count == 1)//如果返回一个结果
            {
                DataRow dr = dataTable.Rows[0];
                int userId = (int)dr["Id"];
                string name = dr["Name"].ToString();
                string psw = dr["Password"].ToString();
                int Role = (int)dr["Role"];
                if (Role == 0)//未审核人员无法访问
                {
                    throw new Exception("注册未审核，请联系管理员");
                }
                else
                {
                    t = new User(userId, name, psw, Role);//将用户信息保存到变量t中
                    if (Role == 3)
                    {
                        this.Role = "管理员";
                    }
                    else if (Role == 2)
                    {
                        this.Role = "老师";
                    }
                    else
                    {
                        this.Role = "学生";
                    }
                    return t;
                }
            }
            else if (dataTable.Rows.Count > 1)//返回结果不止一个
            {
                throw new Exception("未知用户重复错误，请联系管理员");
            }
            else//返回结果为0个
            {
                throw new Exception("用户名或密码不正确，请重新输入");
            }
        }
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns>验证码</returns>
        public string GetValidateNum()
        {
            return validateNum;
        }
        /// <summary>
        /// 获取验证码图片
        /// </summary>
        /// <returns>验证码图片</returns>
        public Bitmap GetValidatePicture()
        {
            return validatePicture;
        }

        /// <summary>
        /// 更换验证码
        /// </summary>
        /// <returns>更换验证码成功与否</returns>
        public bool ChangeValidate()
        {
            Bitmap bitmap = validatePicture;
            if (GetValidate(4) != bitmap)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 注册操作
        /// </summary>
        /// <param name="name">昵称</param>
        /// <param name="password">密码</param>
        /// <param name="repeatpwd">重复密码</param>
        /// <returns>是否成功注册</returns>
        public bool Register(string name, string password, string repeatpwd, int role = -1)
        {
            //未审核注册统一将其角色赋值为0（未审核）
            int Role = 0;
            if (!password.Equals(repeatpwd))
            {
                throw new Exception("两次密码不一致");
            }
            if (role == -1)//获取不到身份选择结果或未选择身份
            {
                throw new Exception("未选择身份");
            }
            int numid = helper.sqlNum("tb_Users");//获取表中数据条数
            string id = helper.sqlMaxID("Id", "tb_Users").ToString().PadLeft(8, '0');//将ID补全为8位
            t = new User(helper.sqlMaxID("Id", "tb_Users"), name, password, Role);//将用户信息保存到变量t中
            if (numid == 0)//如果是第一个注册默认成为管理员
            {
                Role = 3;
            }
            else//否则将其希望成为的角色发送到Log表等待审核
            {
                string sqlStr1 = "INSERT INTO tb_Log(Time,UserId,WantToBe,Name) VALUES(@time,@id,@role,@name)";
                //储存Datatable
                SqlParameter[] para1 = new SqlParameter[]//存储相应参数的容器
                {
                new SqlParameter("@time",DateTime.Now),
                new SqlParameter("@id",id),
                new SqlParameter("@name",name),
                new SqlParameter("@role",role),
                };
                helper.ExecuteNonQuery(sqlStr1, para1, CommandType.Text);
            }
            //向User表中插入数据
            string sqlStr = "INSERT INTO tb_Users(Id,Name,Password,Role) VALUES(@id,@name,@password,@role)";
            //储存Datatable
            SqlParameter[] para = new SqlParameter[]//存储相应参数的容器
            {
                new SqlParameter("@id",id),
                new SqlParameter("@name",name),
                new SqlParameter("@passWord",helper.GetMD5(password)),
                new SqlParameter("@role",Role),
            };
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.Text);
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取注册者Id
        /// </summary>
        /// <returns>注册者ID</returns>
        public int GetRegisterId()
        {
            return helper.sqlMaxID("Id", "tb_Users") - 1;
        }

        /// <summary>
        /// 接收申请
        /// </summary>
        /// <param name="id">申请用户ID</param>
        /// <param name="tobe">申请角色</param>
        /// <returns>成功与否</returns>
        public bool AcceptLog(string id, string tobe)
        {
            string sqlStr = "update tb_Log set IsChecked=@isChecked where UserId=@userId;  " +
                "update tb_Users set Role=@tobe where Id=@userId;";
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@isChecked",true),
                new SqlParameter("@tobe",tobe),
                new SqlParameter("@userId",id)
             };
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.Text);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 拒绝申请
        /// </summary>
        /// <param name="id">申请用户ID</param>
        /// <returns>成功与否</returns>
        public bool RejectionLog(string id)
        {
            string sqlStr = "update tb_Log set IsChecked=@isChecked where UserId=@userId  " +
                "update tb_Users set Role=0 where Id=@userId;";
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@isChecked",true),
                new SqlParameter("@userId",id)
             };
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.Text);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取全部用户
        /// </summary>
        /// <returns>用户表</returns>
        public DataTable GetAllUser()
        {            
            string sqlstr = "select * from tb_Users";//SQL执行字符串
            DataTable dataTable = helper.reDt(sqlstr);//储存Datatable
            return dataTable;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>成功与否</returns>
        public bool DeleteUser(string id)
        {
            string sqlStr = "delete from tb_Users where Id=@Id";
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@Id",id)
             };
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.Text);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 修改昵称
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="changedName">要修改的昵称</param>
        /// <returns>成功与否</returns>
        public bool ChangedName(string id, string changedName)
        {
            string sqlStr = "update tb_Users set Name=@name where Id=@Id";
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@name",changedName),
                new SqlParameter("@Id",id),
             };
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.Text);
            if (count > 0)
            {
                t.UserName = changedName;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="opwd">旧密码</param>
        /// <param name="npwd">新密码</param>
        /// <returns>成功与否</returns>
        public bool ChangePassword(string opwd, string npwd)
        {
            if (!t.PassWord.Equals(helper.GetMD5(opwd)))
            {
                throw new Exception("旧密码不正确");
            }
            string sqlStr = "update tb_Users set Password=@password where Id=@Id";
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@password",helper.GetMD5(npwd)),
                new SqlParameter("@Id",t.UserID),
             };
            int count = helper.ExecuteNonQuery(sqlStr, para, CommandType.Text);
            if (count > 0)
            {
                t.PassWord = helper.GetMD5(npwd);
                return true;
            }
            else
            {
                throw new Exception("修改失败");
            }
        }

        /// <summary>
        /// 获取分页后的未审核用户名单
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <returns>分页后名单</returns>
        public DataTable GetPaperUsers_Check(int index, int size)
        {
            string sqlstr = "select dbo.PadLeft(UserId,8,'0') 账号,Name 昵称,WantToBe 申请角色 from tb_Log where IsChecked=0 order by Id offset ((" + (index - 1) + ")*" + size + ") rows fetch next " + size + " rows only";//SQL执行字符串
            DataTable dataTable = helper.reDt(sqlstr);//储存Datatable
            return dataTable;
        }


        /// <summary>
        /// 获取分页后的学生名单
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <returns>分页后名单</returns>
        public DataTable GetPaperUsers_Student(int index, int size)
        {
            string sqlstr = "select dbo.PadLeft(Id,8,'0') 账号,Name 昵称 from tb_Users where Role=1 order by Id offset ((" + (index - 1) + ")*" + size + ") rows fetch next " + size + " rows only";//SQL执行字符串
            DataTable dataTable = helper.reDt(sqlstr);//储存Datatable
            return dataTable;
        }

        /// <summary>
        /// 获取分页后的教师名单
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <returns>分页后名单</returns>
        public DataTable GetPaperUsers_Teacher(int index, int size)
        {
            string sqlstr = "select dbo.PadLeft(Id,8,'0') 账号,Name 昵称 from tb_Users where Role=2 order by Id offset ((" + (index - 1) + ")*" + size + ") rows fetch next " + size + " rows only";//SQL执行字符串
            DataTable dataTable = helper.reDt(sqlstr);//储存Datatable
            return dataTable;
        }

        /// <summary>
        /// 获取未审核用户分页总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        public int GetAllPageNum_UnChecked(int size)
        {
            int num = helper.sqlNum("tb_Log where IsChecked=0");
            num = num / size + (num % size == 0 ? 0 : 1);
            return num;
        }

        /// <summary>
        /// 获取老师分页总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        public int GetAllPageNum_Teacher(int size)
        {
            int num = helper.sqlNum("tb_Users where Role=2");
            num = num / size + (num % size == 0 ? 0 : 1);
            return num;
        }

        /// <summary>
        /// 获取学生分页总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        public int GetAllPageNum_Student(int size)
        {
            int num = helper.sqlNum("tb_Users where Role=1");
            num = num / size + (num % size == 0 ? 0 : 1);
            return num;
        }
    }
}