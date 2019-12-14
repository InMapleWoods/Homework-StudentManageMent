using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Dal
{
    public class SQLHelper
    {
        private readonly SqlConnection conn = null;
        private SqlCommand cmd = null;
        private readonly SqlDataReader sdr = null;

        public SQLHelper(string sqlConnect)
        {
            conn = new SqlConnection(sqlConnect);
        }

        private string protectsql(string text)
        {/*
            text = text.Replace(";", "");
            text = text.Replace("-", "");*/
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
            catch (Exception) { throw; }
            return conn;
        }


        /// <summary>
        /// 查询表中数据条数
        /// </summary>
        /// <param name="cmdtext">要查询的表</param>
        /// <returns>表中数据条数</returns>
        public int sqlNum(string cmdtext)
        {
            cmdtext = protectsql(cmdtext);
            string sqltext = "SELECT COUNT(*) from " + cmdtext;
            getconn();
            int res = 0;
            try
            {
                using (cmd = new SqlCommand(sqltext, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    res = (int)cmd.ExecuteScalar();
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
        /// 查询表中数据最大值
        /// </summary>
        /// <param name="cmdCol">要查询的列名称</param>
        /// <param name="cmdtext">要查询的表</param>
        /// <returns>表中数据最大值</returns>
        public int sqlMaxColValue(string cmdCol, string cmdtext)
        {
            cmdtext = protectsql(cmdtext);
            string sqltext = "SELECT Max(" + cmdCol + ") from " + cmdtext;
            getconn();
            int res = 0;
            try
            {
                using (cmd = new SqlCommand(sqltext, conn))
                {

                    cmd.CommandType = CommandType.Text;
                    res = (int)cmd.ExecuteScalar();
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
        public int sqlMaxID(string cmdID, string cmdtext)
        {
            cmdtext = protectsql(cmdtext);
            string sqltext = "SELECT Max(" + cmdID + ")+1 from " + cmdtext;
            getconn();
            int res = 0;
            try
            {
                using (cmd = new SqlCommand(sqltext, conn))
                {

                    cmd.CommandType = CommandType.Text;
                    res = (int)cmd.ExecuteScalar();
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
                using (da = new SqlDataAdapter(cmdtext, conn))
                {
                    using (ds = new DataSet())
                    {
                        da.Fill(ds);
                        return (ds.Tables[0]);
                    }
                }
            }
            catch
            {
                throw;
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
        public DataTable ExecuteQuery(string cmdtext, SqlParameter[] paras, CommandType ct)
        {//执行查询
            cmdtext = protectsql(cmdtext);
            DataTable dt = new DataTable();
            try
            {
                using (cmd = new SqlCommand(cmdtext, getconn()))
                {
                    cmd.CommandType = ct;
                    cmd.Parameters.AddRange(paras);
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        dt.Load(sdr);
                    }
                }
            }
            catch
            {
                throw;
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
            for (int i = 0; i < MD5data.Length - 1; i++)
            {
                str += MD5data[i].ToString("X").PadLeft('1', '0');
            }
            md5.Dispose();
            return str;
        }

        /// <summary>
        /// 获取账号对应的用户表
        /// </summary>
        /// <param name="number">用户账号</param>
        /// <returns>表名称</returns>
        public string GetUserRole(string number)
        {
            string sqlStr = "select Role from tb_Users where Number=@number";
            getconn();
            int res = 0;
            try
            {
                using (cmd = new SqlCommand(sqlStr, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@number", number));
                    res = (int)cmd.ExecuteScalar();
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
            string result = GetTableNameByRole(res);
            return result;
        }

        /// <summary>
        /// 获取角色对应的表
        /// </summary>
        /// <param name="res">角色</param>
        /// <returns>表名</returns>
        public string GetTableNameByRole(int res)
        {
            string result = "";
            switch (res)
            {
                case 0:
                    result = "tb_UnCheckedUsers";
                    break;
                case 1:
                    result = "tb_Students";
                    break;
                case 2:
                    result = "tb_Teachers";
                    break;
                case 3:
                    result = "tb_Administrators";
                    break;
                default:
                    result = "Error";
                    break;
            }

            return result;
        }
    }
}




