using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Model;

namespace DAO
{
    public class databaseContorl
    {
        //数据库连接
        private static SqlConnection connection;
        public static SqlConnection Connection
        {
            get
            {
                //从web.config读取连接字符串
                string sqlString = ConfigurationManager.ConnectionStrings["sqlConnection"].ConnectionString;
                if (connection == null || connection.State == ConnectionState.Closed)
                {
                    connection = new SqlConnection(sqlString);
                    connection.Open();
                }
                return connection;
            }
        }

        /// <summary>
        /// 执行命令返回datatable数据集
        /// </summary>
        /// <param name="sql">sql执行语句</param>
        /// <returns>返回DataTable数据集</returns>
        public DataTable GetDataAdapter(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, Connection);
            comm.CommandTimeout = 180;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(ds);
            //关闭连接
            Connection.Close();
            return ds.Tables[0];
        }


        /// <summary>
        /// 有参数执行返回DataTable数据集
        /// </summary>
        /// <param name="sql">z字符串</param>
        /// <param name="sqlParameter">变量</param>
        /// <returns></returns>
        public static DataTable GetDataSet(string sql,SqlParameter[] sqlParameter)
        {
            SqlCommand command = new SqlCommand(sql, Connection);
            foreach(SqlParameter parameter in sqlParameter)
            {
                command.Parameters.Add(parameter);
            }
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
            //关闭连接
            Connection.Close();
            return ds.Tables[0];
        }

        /// <summary>
        /// 无参数执行返回受影响行数
        /// </summary>
        /// <param name="sql"></param >
        /// <returns></returns>
        public static int ExecuteSql(string sql)
        {
            SqlCommand command = new SqlCommand(sql, Connection);
            int ret = command.ExecuteNonQuery();
            //关闭连接
            Connection.Close();
            return ret;
        }

        /// <summary>
        /// 有参数执行返回受影响函数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParameter"></param>
        /// <returns></returns>
        public static int ExecuteSql(string sql,SqlParameter[] sqlParameter)
        {
            SqlCommand command = new SqlCommand(sql, Connection);
            foreach (SqlParameter parameter in sqlParameter)
            {
                command.Parameters.Add(parameter);
            }
            int ret = command.ExecuteNonQuery();
            //关闭连接
            Connection.Close();
            return ret;
        }
        

    }
}
