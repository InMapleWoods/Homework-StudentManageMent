using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web;
using System.Security.Cryptography;

namespace StudentManagement
{
    public class SQLHelper
    {
        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        private SqlDataReader sdr = null;

        public SQLHelper()
        {
            // conn = new SqlConnection("server=LLF-COMPUTER\\MSSQLSERVER_A;database=db_Blog;uid=Lsa;pwd=llfllf");
            //conn = new SqlConnection("Data Source=LLF-COMPUTER\\MSSQLSERVER_A;Initial Catalog=db_StudentManage;Persist Security Info=True;User ID=Lsa;Password=llfllf");
            conn = new SqlConnection("Data Source=152.136.73.240;Initial Catalog=db_StudentManage;Persist Security Info=True;User ID=Lsa;Password=llfllf");
            //  conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());

        }

        public bool SqlFilter(string InText)
        {
            /*string word = "and|exec|insert|select|delete|update|chr|mid|master|or|truncate|char|declare|join|cmd";
            if (InText == null)
                return false;
            foreach (string i in word.Split('|'))
            {
                if ((InText.ToLower().IndexOf(i + " ") > -1) || (InText.ToLower().IndexOf(" " + i) > -1))
                {
                    return true;
                }
            }*/
            return false;
        }

        private string protectsql(string text)
        {
            //text = text.Replace(";", "");
            //text = text.Replace("-", "");
            return text;
        }

    /// <summary>
    /// 打开数据库
    /// </summary>
    /// <returns>返回SqlConnection</returns>
    private SqlConnection getconn()
        {
            try
            {
                //打开链接            
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch { }
            return conn;

        }

        /// <summary>
        /// 查询表中数据条数
        /// </summary>
        /// <param name="cmdtext">要查询的表</param>
        /// <returns>表中数据条数</returns>
        public int sqlNum(string cmdtext)
        {
            cmdtext=protectsql(cmdtext);
            string sqltext = "SELECT COUNT(*) from " + cmdtext; 
            getconn();
            int res = 0;
            try
            {
                using (cmd = new SqlCommand(sqltext, conn))
                {
                    
                    cmd.CommandType = CommandType.Text;
                    res=(int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                res = -1;
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return res;
        }
        
        /// <summary>
        /// 查询表中数据条数
        /// </summary>
        /// <param name="cmdID">要查询的ID列名称</param>
        /// <param name="cmdtext">要查询的表</param>
        /// <returns>表中数据最大值</returns>
        public int sqlMaxID(string cmdID,string cmdtext)
        {
            cmdtext=protectsql(cmdtext);
            string sqltext = "SELECT Max("+ cmdID + ")+1 from " + cmdtext; 
            getconn();
            int res = 0;
            try
            {
                using (cmd = new SqlCommand(sqltext, conn))
                {
                    
                    cmd.CommandType = CommandType.Text;
                    res=(int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                res = -1;
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return res;
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="cmdtext">SQL语句</param>
        /// <returns>成功为1，失败为0</returns>
        public int sqlEx(string cmdtext)
        {
            cmdtext = protectsql(cmdtext);
            getconn();
            int res = 0;
            try
            {
                using (cmd = new SqlCommand(cmdtext, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    res = 1;
                }
            }
            catch (Exception ex)
            {
                res = 0;
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return res;
        }

        /// <summary>
        /// 执行SQL查询语句
        /// </summary>
        /// <param name="cmdtext">SQL查询语句</param>
        /// <returns>返回DataTable数据表</returns>
        public DataTable reDt(string cmdtext)
        {
            cmdtext = protectsql(cmdtext);
            getconn();
            SqlDataAdapter da;
            DataSet ds;
            try
            {
                da = new SqlDataAdapter(cmdtext, conn);
                ds = new DataSet();
                da.Fill(ds);
                return (ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 执行SQL查询语句
        /// </summary>
        /// <param name="cmdtext">SQL查询语句</param>
        /// <returns>返回SqlDataReader</returns>
        public SqlDataReader reDr(string cmdtext)
        {
            cmdtext = protectsql(cmdtext);
            getconn();
            try
            {
                cmd = new SqlCommand(cmdtext, conn);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sdr;
        }

        /// <summary>
        /// 执行不带参数的增删改SQL语句或存储过程
        /// </summary>
        /// <param name="cmdtext">增删改SQL语句或存储过程</param>
        /// <param name="ct">命令类型（SQL语句或存储过程）</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string cmdtext, CommandType ct)
        {//该方法执行传入的SQL语句
            cmdtext = protectsql(cmdtext);
            int res = 0;
            try
            {
                using (cmd = new SqlCommand(cmdtext, getconn()))
                {
                    cmd.CommandType = ct;
                    res = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return res;
        }

        /// <summary>
        ///  执行带参数的增删改SQL语句或存储过程
        /// </summary>
        /// <param name="cmdtext">增删改SQL语句或存储过程</param>
        /// <param name="paras">参数集合</param>
        /// <param name="ct">命令类型（SQL语句或存储过程）</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string cmdtext, SqlParameter[] paras, CommandType ct)
        {//该方法执行传入的SQL语句
            cmdtext = protectsql(cmdtext);
            int res = 0;
            try
            {
                using (cmd = new SqlCommand(cmdtext, getconn()))
                {
                    cmd.CommandType = ct;
                    cmd.Parameters.AddRange(paras);
                    res = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return res;
        }

        /// <summary>
        /// 执行带参数查询SQL语句或存储过程
        /// </summary>
        /// <param name="cmdtext">查询SQL语句或存储过程</param>
        /// <param name="paras">参数集合</param>
        /// <param name="ct">命令类型（SQL语句或存储过程）</param>
        /// <returns></returns>
        public DataTable ExcuteQuery(string cmdtext, SqlParameter[] paras, CommandType ct)
        {//执行查询
            cmdtext = protectsql(cmdtext);
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand(cmdtext, getconn());
                cmd.CommandType = ct;
                cmd.Parameters.AddRange(paras);
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return dt;
        }

        /// <summary>
        /// 执行不带参数查询SQL语句或存储过程
        /// </summary>
        /// <param name="cmdtext">查询SQL语句或存储过程</param>
        /// <param name="ct">命令类型（SQL语句或存储过程）</param>
        /// <returns></returns>
        public DataTable ExcuteQuery(string cmdtext, CommandType ct)
        {
            cmdtext = protectsql(cmdtext);
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand(cmdtext, getconn());
                cmd.CommandType = ct;
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return dt;
        }

        /// <summary>
        /// 执行不带参数查询SQL语句或存储过程
        /// </summary>
        /// <param name="cmdtext">查询SQL语句或存储过程</param>
        /// <param name="ct">命令类型（SQL语句或存储过程）</param>
        /// <returns></returns>
        public SqlDataReader ExcuteQuery(string cmdtext)
        {
            cmdtext = protectsql(cmdtext);
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand(cmdtext, getconn());
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return sdr;
        }

        /// <summary>
        ///  MD5加密
        /// </summary>
        /// <param name="strPwd">要加密的字符串</param>
        /// <returns>返回加密后的字符串</returns>
        public string GetMD5(string strPwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(strPwd);
            byte[] MD5data = md5.ComputeHash(data);
            md5.Clear();
            string str = "";
            for(int i=0;i<MD5data.Length-1;i++)
            {
                str += MD5data[i].ToString("X").PadLeft('1','0');
            }
            return str;
        }

    }
}




