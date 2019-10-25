﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dal
{
    /// <summary>
    /// 成绩数据访问类
    /// </summary>
    public class GradeDal
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        const string sqlConnect = "server=152.136.73.240;database=db_StudentManage;uid=Lsa;pwd=llfllf";

        /// <summary>
        /// SQL帮助类
        /// </summary>
        SQLHelper helper = new SQLHelper(sqlConnect);

        /// <summary>
        /// 获取学生成绩
        /// </summary>
        /// <returns>全部学生成绩数据表</returns>
        public DataTable GetStudentGrade(string Id)
        {
            string sqlstr = "select tb_Course.Id as 课程ID,tb_Course.Name as 课程名  from tb_Course inner join tb_Grade on tb_Grade.SId='" + Id + "'  and tb_Grade.CId=tb_Course.Id";//SQL执行字符串
            DataTable dataTable = helper.reDt(sqlstr);//储存Datatable
            return dataTable;
        }

        /// <summary>
        /// 教师获取学生成绩
        /// </summary>
        /// <returns>全部学生成绩数据表</returns>
        public DataTable GetCourseGrade(string Id)
        {
            string sqlstr = "select dbo.PadLeft(tb_Grade.SId,8,'0') as 学生学号,tb_Users.Name as 学生姓名,tb_Grade.Score as 课程分数 from tb_Grade inner join tb_Users on CId='" + Id + "' and tb_Grade.SId=tb_Users.Id";//SQL执行字符串
            DataTable dataTable = helper.reDt(sqlstr);//储存Datatable
            return dataTable;
        }

        /// <summary>
        /// 更改学生成绩
        /// </summary>
        /// <param name="score">成绩</param>
        /// <param name="studenid">学生Id</param>
        /// <param name="courseid">课程Id</param>
        /// <returns>修改是否成功</returns>
        public bool ChangeCourseGrade(string score, string studenid, string courseid)
        {
            string sqlstr = "UPDATE tb_Grade SET Score=@score where SId=@studenid and CId=@courseid";
            //储存Datatable
            SqlParameter[] para = new SqlParameter[]//存储相应参数的容器
            {
                new SqlParameter("@score",score),
                new SqlParameter("@studenid",studenid),
                new SqlParameter("@courseid",courseid),
            };
            int count = helper.ExecuteNonQuery(sqlstr, para, CommandType.Text);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
