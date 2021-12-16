using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using MySqlConnector;

namespace shootDAL
{
    public static class DBHelper
    {

        private static MySqlConnection connection;
        /// <summary>
        /// 创建连接
        /// </summary>
        public static MySqlConnection Connection
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
                if (connection == null)
                {
                    connection = new MySqlConnection(connectionString);
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }

        /// <summary>
        /// 执行sql命令
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public static int ExecuteCommand(string safeSql)
        {
            MySqlCommand cmd = new MySqlCommand(safeSql, Connection);
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        /// <summary>
        /// 执行带参数sql
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int ExecuteCommand(string sql, params MySqlParameter[] values)
        {
            MySqlCommand cmd = new MySqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 获取单个对象
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public static int GetScalar(string safeSql)
        {
            MySqlCommand cmd = new MySqlCommand(safeSql, Connection);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }

        public static int GetScalar(params MySqlParameter[] values)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Connection;
            cmd.CommandText = "Pro_InsertOrder";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(values);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }

        public static int GetScalar(string sql, params MySqlParameter[] values)
        {
            MySqlCommand cmd = new MySqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }

        public static MySqlDataReader GetReader(string safeSql)
        {
            MySqlCommand cmd = new MySqlCommand(safeSql, Connection);
            MySqlDataReader reader = (MySqlDataReader)cmd.ExecuteReader();
            return reader;
        }

        public static MySqlDataReader GetReader(string sql, params MySqlParameter[] values)
        {
            MySqlCommand cmd = new MySqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            MySqlDataReader reader = (MySqlDataReader)cmd.ExecuteReader();
            return reader;
        }

        public static DataTable GetDataSet(string safeSql)
        {
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(safeSql, Connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable GetDataSet(string sql, params MySqlParameter[] values)
        {
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}
