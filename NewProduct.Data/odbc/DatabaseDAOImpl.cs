using System;
using System.Collections;
using System.Data;
using System.Text;

using System.Data.SqlClient;
using SCOTCH.DBManager.dao;
using System.Configuration;

namespace SCOTCH.DBManager.odbc
{
    public class DatabaseDAOImpl : DatabaseDAO
    {
        public DatabaseDAOImpl()
        {
           
        }

        private static string connectionStringCommon = ConfigurationManager.ConnectionStrings["SQLConnectionCommon"].ConnectionString;

        public DataSet ExcecuteDataSet(DataSet ds, String tableName, String commandText , 
            SqlParameter[] pm, string connectionString)
        {
            SqlDataAdapter da = null;
            SqlConnection conn = null;
            SqlCommand comm = null;
            try
            {
                conn = new SqlConnection(connectionString);
                if (conn != null)
                {
                    conn.Close();
                    conn.Open();
                    comm = new SqlCommand();
                    comm = PrepareCommand(comm, conn, CommandType.StoredProcedure, commandText, pm);
                    comm.CommandTimeout = 120;
                    da = new SqlDataAdapter(comm);
                    ds.EnforceConstraints = false;
                    da.Fill(ds, tableName);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                da.Dispose();
                if (conn != null)
                    conn.Close();
            }
            return ds;
        }

        public int NonExcecute(String commandText, SqlParameter[] pm, string connectionString)
        {
            int row = 0;
            SqlConnection conn = null;
            SqlCommand comm = null;
            try
            {
                conn = new SqlConnection(connectionString);
                if (conn != null)
                {
                    conn.Close();
                    conn.Open();
                    comm = new SqlCommand();
                    comm = PrepareCommand(comm, conn, CommandType.StoredProcedure, commandText, pm);
                    row = comm.ExecuteNonQuery();
                    
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (comm != null)
                    comm.Dispose();
                if (conn != null)
                    conn.Close();
            }

            return row;
        }

        private static SqlCommand PrepareCommand(SqlCommand command, SqlConnection connection, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            //associate the connection with the command
            command.Connection = connection;

            //set the command text (stored procedure name or Oracle statement)
            command.CommandText = commandText;

            //set the command type
            command.CommandType = commandType;

            //attach the command parameters if they are provided
            if (commandParameters != null)
            {
                command = AttachParameters(command, commandParameters);
            }

            return command;
        }

        private static SqlCommand AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            foreach (SqlParameter p in commandParameters)
            {
                if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                {
                    p.Value = DBNull.Value;
                }
                command.Parameters.Add(p);
            }
            return command;
        }

    }


}
