using Model;
using System;
using System.Data;
using System.Data.SqlClient;

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
        private const string sqlConnect = "server=152.136.73.240,1733;database=db_StudentManage;uid=Lsa;pwd=llfllf";

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
            string str = "GetPageByOption";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@index",index),
                new SqlParameter("@size",size),
                new SqlParameter("@option","GetPaperExam"),
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
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@id",studentId),
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
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@id",id),
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
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@id",id),
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
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@id",id),
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
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@courseid",examination.CourseId),
                new SqlParameter("@time",examination.Time),
                new SqlParameter("@examname",examination.Name),
                new SqlParameter("@duration",examination.Duration),
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
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@id",id),
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
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@time",dateTime),
                new SqlParameter("@id",id),
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
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@name",name),
                new SqlParameter("@id",id),
            };
            int result = helper.ExecuteNonQuery(str, sqlParameters, CommandType.Text);
            if (result > 0)
                return true;
            return false;
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
            string str = "GetPageByOption";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@index",index),
                new SqlParameter("@size",size),
                new SqlParameter("@option","GetPaperExamApply"),
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
            string str = "select tb_ExamApplyLog.Id 考试ID,tb_Course.Name 课程名称,tb_Teachers.Name 老师名称,tb_ExamApplyLog.ExamName 考试名称,tb_ExamApplyLog.Time 考试时间,tb_ExamApplyLog.Duration 考试时长 from tb_Course, tb_ExamApplyLog, tb_Teachers where tb_Course.Id = tb_ExamApplyLog.CourseId and tb_Teachers.Id = tb_ExamApplyLog.TeacherId and tb_ExamApplyLog.IsChecked = 0 and tb_ExamApplyLog.TeacherId=@id order by tb_ExamApplyLog.Id offset((@index -1)*@size ) rows fetch next @size rows only; ";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@id",id),
                new SqlParameter("@index",index),
                new SqlParameter("@size",size),
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
            int num = helper.sqlNum("tb_ExamApplyLog where TeacherId=" + id.ToString());
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
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@out",SqlDbType.VarChar,200),
                new SqlParameter("@teacherid",teacherId),
                new SqlParameter("@courseid",examination.CourseId),
                new SqlParameter("@time",examination.Time),
                new SqlParameter("@examname",examination.Name),
                new SqlParameter("@ischecked",false),
                new SqlParameter("@duration",examination.Duration),
            };
            sqlParameters[0].Direction = ParameterDirection.Output;
            int result = helper.ExecuteNonQuery(str, sqlParameters, CommandType.StoredProcedure);
            string output = sqlParameters[0].Value.ToString();
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
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@id",id),
                new SqlParameter("@ischecked",true),
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
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@id",id),
                new SqlParameter("@ischecked",false),
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