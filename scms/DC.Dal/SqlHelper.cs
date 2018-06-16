using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.Dal
{
    public class SqlHelper
    {
        //获取连接字符
        private static string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //创建连接对象
        public static SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// 有连接对象查询
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(SqlConnection conn, string sql, params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }

        }
        /// <summary>
        /// 无连接对象查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>

        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = CreateConnection())
            {
                return ExecuteNonQuery(conn, sql, parameters);
            }
        }
        /// <summary>
        /// 有连接对象获取首行首列
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="paramater"></param>
        /// <returns></returns>
        public static object ExecuteScalar(SqlConnection conn, string sql, params SqlParameter[] paramater)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(paramater);
                return cmd.ExecuteScalar();
            }
        }
        /// <summary>
        /// 无连接对象获取首行首列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramater"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] paramater)
        {
            using (SqlConnection conn = CreateConnection())
            {
                return ExecuteScalar(conn, sql, paramater);
            }
        }
        /// <summary>
        /// 有连接获取符合条件数据
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="paramaters"></param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(SqlConnection conn, string sql, params SqlParameter[] paramaters)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(paramaters);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
                return dt;
            }
        }
        /// <summary>
        /// 无连接对象获取符合条件数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramaters"></param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(string sql, params SqlParameter[] paramaters)
        {
            using (SqlConnection conn = CreateConnection())
            {
                return ExecuteQuery(conn, sql, paramaters);
            }
        }
    }
}
