using Model;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Dal
{
    /// <summary>
    /// 考试数据操作层
    /// </summary>
    public class ExaminationDal
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        private const string sqlConnect = "server=152.136.73.240;port=1733;database=db_StudentManage;user id=Lsa;password=llfllf;Charset=utf8;";

        /// <summary>
        /// SQL帮助类
        /// </summary>
        private readonly SQLHelper helper = new SQLHelper(sqlConnect);

        #region 考试相关
        /// <summary>
        /// 获取分页后的考试列表
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <returns>分页后名单</returns>
        public DataTable GetPaperExam(int index, int size)
        {
            int startPos = (index - 1) * size;
            int endPos = index * size;
            string str = "GetPageByOption";
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("@startPos",startPos),
                new MySqlParameter("@endPos",endPos),
                new MySqlParameter("@option","GetPaperExam"),
            };
            DataTable dataTable = helper.ExecuteQuery(str, paras, CommandType.StoredProcedure);//储存Datatable
            return dataTable;
        }

        /// <summary>
        /// 获取分页后的考试列表总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        public int GetAllPageNum(int size)
        {
            int num = helper.sqlNum("tb_Examination");
            num = num / size + (num % size == 0 ? 0 : 1);
            return num;
        }
        /// <summary>
        /// 获取分页后的考试列表总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <param name="studentId">学生Id</param>
        /// <returns>分页数</returns>
        public int GetAllPageNum(int size, int studentId)
        {
            string str = "select count(*) as ALLCOUNT from tb_Examination where tb_Examination.CourseId in (select tb_Course.Id from tb_Course inner join tb_CourseGrade on tb_CourseGrade.SId=@id and tb_CourseGrade.CId=tb_Course.Id)";
            MySqlParameter[] sqlParameters = new MySqlParameter[]
            {
                new MySqlParameter("@id",studentId),
            };
            DataTable dataTable = helper.ExecuteQuery(str, sqlParameters, CommandType.Text);
            int num = (int)dataTable.Rows[0]["ALLCOUNT"];
            num = num / size + (num % size == 0 ? 0 : 1);
            return num;
        }

        /// <summary>
        /// 获取全部考试
        /// </summary>
        /// <returns>返回的考试列表</returns>
        public DataTable GetAllExamination()
        {
            string sqlStr = "select * from tb_Examination";
            DataTable dataTable = helper.reDt(sqlStr);
            return dataTable;
        }

        /// <summary>
        /// 按Id获取考试
        /// </summary>
        /// <param name="id">考试Id</param>
        /// <returns>符合条件的考试</returns>
        public Examination GetExaminationById(int id)
        {
            string sqlStr = "select * from tb_Examination where id=@id";
            MySqlParameter[] sqlParameters = new MySqlParameter[]
            {
                new MySqlParameter("@id",id),
            };
            DataTable dataTable = helper.ExecuteQuery(sqlStr, sqlParameters, CommandType.Text);
            if (dataTable.Rows.Count == 1)
            {
                DataRow dataRow = dataTable.Rows[0];
                int examId = (int)dataRow["Id"];
                int courseId = (int)dataRow["CourseId"];
                DateTime time = (DateTime)dataRow["Time"];
                string examName = dataRow["Name"].ToString();
                int duration = (int)dataRow["Duration"];
                Examination examination = new Examination(examId, courseId, time, examName, duration);
                return examination;
            }
            return null;
        }

        /// <summary>
        /// 按课程Id获取考试
        /// </summary>
        /// <param name="id">课程Id</param>
        /// <returns>符合条件的所有考试</returns>
        public DataTable GetExaminationByCourseId(int id)
        {
            string sqlStr = "select * from tb_Examination where CourseId=@id";
            MySqlParameter[] sqlParameters = new MySqlParameter[]
            {
                new MySqlParameter("@id",id),
            };
            DataTable dataTable = helper.ExecuteQuery(sqlStr, sqlParameters, CommandType.Text);
            return dataTable;
        }

        /// <summary>
        /// 按教师Id获取考试
        /// </summary>
        /// <param name="id">教师Id</param>
        /// <returns>符合条件的所有考试</returns>
        public DataTable GetExaminationByTeacherId(int id)
        {
            string sqlStr = "GetTeacherAllExam";
            MySqlParameter[] sqlParameters = new MySqlParameter[]
            {
                new MySqlParameter("@id",id),
            };
            DataTable dataTable = helper.ExecuteQuery(sqlStr, sqlParameters, CommandType.StoredProcedure);
            return dataTable;
        }

        /// <summary>
        /// 增加考试
        /// </summary>
        /// <param name="examination">考试</param>
        /// <returns>增加成功与否</returns>
        public bool AddExamination(Examination examination)
        {
            if (examination == null)
                return false;
            string str = "insert into tb_Examination(CourseId,Time,Name,Duration) Values(@courseid,@time,@examname,@duration)";
            MySqlParameter[] sqlParameters = new MySqlParameter[]
            {
                new MySqlParameter("@courseid",examination.CourseId),
                new MySqlParameter("@time",examination.Time),
                new MySqlParameter("@examname",examination.Name),
                new MySqlParameter("@duration",examination.Duration),
            };
            int result = helper.ExecuteNonQuery(str, sqlParameters, CommandType.Text);
            if (result > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 删除考试
        /// </summary>
        /// <param name="id">考试Id</param>
        /// <returns>删除成功与否</returns>
        public bool DeleteExamination(int id)
        {
            string str = "delete from tb_Examination where Id=@id";
            MySqlParameter[] sqlParameters = new MySqlParameter[]
            {
                new MySqlParameter("@id",id),
            };
            int result = helper.ExecuteNonQuery(str, sqlParameters, CommandType.Text);
            if (result > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 修改考试时间
        /// </summary>
        /// <param name="dateTime">考试时间</param>
        /// <param name="id">需要修改的考试id</param>
        /// <returns>修改成功与否</returns>
        public bool UpdateExaminationTime(DateTime dateTime, int id)
        {
            string str = "update tb_Examination set Time=@time where Id=@id";
            MySqlParameter[] sqlParameters = new MySqlParameter[]
            {
                new MySqlParameter("@time",dateTime),
                new MySqlParameter("@id",id),
            };
            int result = helper.ExecuteNonQuery(str, sqlParameters, CommandType.Text);
            if (result > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 修改考试名称
        /// </summary>
        /// <param name="name">考试名称</param>
        /// <param name="id">需要修改的考试id</param>
        /// <returns>修改成功与否</returns>
        public bool UpdateExaminationName(string name, int id)
        {
            string str = "update tb_Examination set Name=@name where Id=@id";
            MySqlParameter[] sqlParameters = new MySqlParameter[]
            {
                new MySqlParameter("@name",name),
                new MySqlParameter("@id",id),
            };
            int result = helper.ExecuteNonQuery(str, sqlParameters, CommandType.Text);
            if (result > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 学生参加考试
        /// </summary>
        /// <param name="studentId">学生Id</param>
        /// <param name="id">考试Id</param>
        /// <returns>修改成功与否</returns>
        public bool StudentJoinExam(string studentId, int id)
        {
            string sqlstr = "StudentJoinExam";
            //储存Datatable
            MySqlParameter[] para = new MySqlParameter[]//存储相应参数的容器
            {
                new MySqlParameter("@examId",id),
                new MySqlParameter("@studentId",studentId),
                new MySqlParameter("@result",MySqlDbType.VarChar,5000),
            };
            para[2].Direction = ParameterDirection.Output;
            int count = helper.ExecuteNonQuery(sqlstr, para, CommandType.StoredProcedure);
            string result = para[2].Value.ToString();
            if (result != "")
                throw new Exception(result);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 考试申请相关
        /// <summary>
        /// 获取分页后的考试申请列表
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <returns>分页后名单</returns>
        public DataTable GetPaperExamApply(int index, int size)
        {
            int startPos = (index - 1) * size;
            int endPos = index * size;
            string str = "GetPageByOption";
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("@startPos",startPos),
                new MySqlParameter("@endPos",endPos),
                new MySqlParameter("@option","GetPaperExamApply"),
            };
            DataTable dataTable = helper.ExecuteQuery(str, paras, CommandType.StoredProcedure);//储存Datatable
            return dataTable;
        }

        /// <summary>
        /// 获取分页后的考试申请列表总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        public int GetAllPageApplyNum(int size)
        {
            int num = helper.sqlNum("tb_ExamApplyLog");
            num = num / size + (num % size == 0 ? 0 : 1);
            return num;
        }
        /// <summary>
        /// 获取分页后的教师考试申请列表
        /// </summary>
        /// <param name="id">教师Id</param>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <returns>分页后名单</returns>
        public DataTable GetPaperExamApply(int id, int index, int size)
        {
            int startPos = (index - 1) * size;
            int endPos = index * size;
            string str = "select tb_ExamApplyLog.Id 考试ID,tb_Course.Name 课程名称,tb_Teachers.Name 老师名称,tb_ExamApplyLog.ExamName 考试名称,tb_ExamApplyLog.Time 考试时间,tb_ExamApplyLog.Duration 考试时长 from tb_Course, tb_ExamApplyLog, tb_Teachers where tb_Course.Id = tb_ExamApplyLog.CourseId and tb_Teachers.Id = tb_Course.TeacherId and tb_ExamApplyLog.IsChecked = 0 and tb_Course.TeacherId=@id order by tb_ExamApplyLog.Id limit @startPos,@endPos;";
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("@id",id),
                new MySqlParameter("@startPos",startPos),
                new MySqlParameter("@endPos",endPos),
            };
            DataTable dataTable = helper.ExecuteQuery(str, paras, CommandType.Text);//储存Datatable
            return dataTable;
        }

        /// <summary>
        /// 获取分页后的教师考试申请列表总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        public int GetAllPageApplyNum(int id, int size)
        {
            string str = "select count(*) from tb_ExamApplyLog,tb_Course where tb_ExamApplyLog.CourseId=tb_Course.Id and tb_Course.TeacherId=@id";
            int num = (int)(long)helper.ExecuteQuery(str, new MySqlParameter[] { new MySqlParameter("@id", id) }, CommandType.Text).Rows[0][0];
            num = num / size + (num % size == 0 ? 0 : 1);
            return num;
        }

        /// <summary>
        /// 增加考试申请
        /// </summary>
        /// <param name="examination">考试</param>
        /// <param name="teacherId">教师Id</param>
        /// <returns>增加成功与否</returns>
        public bool AddExamApply(Examination examination, int teacherId)
        {
            if (examination == null)
                return false;
            string str = "AddExamApply";
            MySqlParameter[] sqlParameters = new MySqlParameter[]
            {
                new MySqlParameter("@courseid",examination.CourseId),
                new MySqlParameter("@time",examination.Time),
                new MySqlParameter("@examname",examination.Name),
                new MySqlParameter("@ischecked",false),
                new MySqlParameter("@duration",examination.Duration),
                new MySqlParameter("@output",MySqlDbType.VarChar,200),
            };
            sqlParameters[5].Direction = ParameterDirection.Output;
            int result = helper.ExecuteNonQuery(str, sqlParameters, CommandType.StoredProcedure);
            string output = sqlParameters[5].Value.ToString();
            if (output != "")
                throw new Exception(output);
            if (result > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 改变考试申请状态
        /// </summary>
        /// <param name="id">考试申请Id</param>
        /// <returns>改变成功与否</returns>
        public bool UpdateExamApplyCheckedState(int id)
        {
            string str = "Update tb_ExamApplyLog set IsChecked=@ischecked where Id=@id";
            MySqlParameter[] sqlParameters = new MySqlParameter[]
            {
                new MySqlParameter("@id",id),
                new MySqlParameter("@ischecked",true),
            };
            int result = helper.ExecuteNonQuery(str, sqlParameters, CommandType.Text);
            if (result > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 接受考试申请
        /// </summary>
        /// <param name="id">考试申请Id</param>
        /// <returns>接受成功与否</returns>
        public bool AccpetExamApply(int id)
        {
            Examination examination = null;
            string sqlStr = "select * from tb_ExamApplyLog where id=@id and IsChecked=@ischecked";
            MySqlParameter[] sqlParameters = new MySqlParameter[]
            {
                new MySqlParameter("@id",id),
                new MySqlParameter("@ischecked",false),
            };
            DataTable dataTable = helper.ExecuteQuery(sqlStr, sqlParameters, CommandType.Text);
            if (dataTable.Rows.Count == 1)
            {
                DataRow dataRow = dataTable.Rows[0];
                int examId = (int)dataRow["Id"];
                int courseId = (int)dataRow["CourseId"];
                DateTime time = (DateTime)dataRow["Time"];
                string examName = dataRow["ExamName"].ToString();
                int duration = (int)dataRow["Duration"];
                examination = new Examination(examId, courseId, time, examName, duration);
            }
            if (examination != null)
            {
                if (UpdateExamApplyCheckedState(id))
                {
                    if (AddExamination(examination))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 拒绝考试申请
        /// </summary>
        /// <param name="id">考试申请Id</param>
        /// <returns>拒绝成功与否</returns>
        public bool RejectExamApply(int id)
        {
            if (UpdateExamApplyCheckedState(id))
            {
                return true;
            }
            return false;
        }
        #endregion

    }
}