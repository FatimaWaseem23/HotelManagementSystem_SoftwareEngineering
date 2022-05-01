using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace VMS.SQLServerCore
{
    public class DBAccess
    {
        public short DBOption;
        /// <summary>
        /// By Default Constructor for DB Access
        /// </summary>
        public DBAccess()
        {
        }
        /// <summary>
        /// Enum used for DB
        /// </summary>
        public static string connectionString = ConfigurationManager.ConnectionStrings["Roomers_ConnectionString"].ToString();
        /// <summary>
        /// ExecuteCommandAsDataSet is used to Execute Command as Data Set
        /// </summary>
        /// <param name="Command"></param>
        /// <param name="isACO_EDW"></param>
        /// <param name="ConnectionStringName"></param>
        /// <returns>DataSet</returns>
        public DataSet ExecuteCommandAsDataSet(SqlCommand Command)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                Command.Connection = conn;
                Command.CommandTimeout = 10000;
                if (Command.CommandType == CommandType.StoredProcedure)
                    Command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Command);
                da.Fill(ds);
                //conn.Close();
                return ds;

            }
        }
        /// <summary>
        /// ExecuteCommandAsDataTable is used to Execute Command as Data Table
        /// </summary>
        /// <param name="Command"></param>
        /// <param name="isACO_EDW"></param>
        /// <param name="ConnectionStringName"></param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteCommandAsDataTable(SqlCommand Command)
        {
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                Command.Connection = conn;
                Command.CommandTimeout = 10000;
                if (Command.CommandType == CommandType.StoredProcedure)
                    Command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Command);
                da.Fill(ds);
               // conn.Close();
                return ds.Tables[0];
            }
        }
        /// <summary>
        /// ExecuteCommandAsNonQuery is used to Execute Command and check if query executes succesfully
        /// </summary>
        /// <param name="Command"></param>
        /// <param name="isACO_EDW"></param>
        /// <param name="ConnectionStringName"></param>
        /// <returns>integer</returns>
        public int ExecuteCommandAsNonQuery(SqlCommand Command)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                Command.Connection = conn;
                Command.CommandTimeout = 10000;
                if (Command.CommandType == CommandType.StoredProcedure)
                    Command.CommandType = CommandType.StoredProcedure;
                Command.Connection.Open();
                int r = Command.ExecuteNonQuery();
                //conn.Close();
                return r;
            }
        }
        /// <summary>
        /// ExecuteCommandAsNonQueryWithSelectedConnection is used to Execute Command and check if query executes succesfully with selected Connection
        /// </summary>
        /// <param name="Command"></param>
        /// <param name="ConnectionStringName"></param>
        /// <returns>integer</returns>
        public int ExecuteCommandAsNonQueryWithSelectedConnection(SqlCommand Command)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                Command.Connection = conn;
                Command.CommandTimeout = 10000;
                if (Command.CommandType == CommandType.StoredProcedure)
                    Command.CommandType = CommandType.StoredProcedure;
                Command.Connection.Open();
                int r = Command.ExecuteNonQuery();
                //conn.Close();
                return r;
            }
        }
    }
}