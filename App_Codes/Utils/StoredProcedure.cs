using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Data.SqlClient;
using Gnt.Configuration;

namespace Man.Utils
{
    public class StoredProcedure
    {
        private string storedProcedureName=string.Empty;
        SqlConnection connection = null;
        SqlCommand command = null;
               
        public StoredProcedure(string name)
        {
            string connectionString = ApplicationConfiguration.ConnectionString;
            connection = new SqlConnection(connectionString);
            command= connection.CreateCommand();
            storedProcedureName = name;
        }

        public void AddParameter(string parameterName ,object value, ParameterDirection direction,DbType type)
        {
            SqlParameter param = new SqlParameter(parameterName, value);
            param.DbType = type;
            param.Direction = direction;
            command.Parameters.Add(param);
        }
        public void AddParameter(string parameterName, ParameterDirection direction, DbType type)
        {
            SqlParameter param = new SqlParameter(parameterName, type);
            param.Direction = direction;
            command.Parameters.Add(param);
        }
        public SqlParameter GetParameter(string parameterName)
        {
            if (command.Parameters.IndexOf(parameterName) > 0)
            {
                return command.Parameters[parameterName];
            }
            else
            {
                return null;
            }
        }
        public int ExecuteNonQuery()
        {
            int ret = 0;

            if ((command.Parameters == null) || (command.Parameters.Count == 0))
            {
                return ret;
            }

            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }                
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("StoredProcedureTransaction");
                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    command.CommandText = storedProcedureName;
                    command.CommandType = CommandType.StoredProcedure;                    
                    ret = command.ExecuteNonQuery();                    
                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    ret = -1;
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        command.Dispose();
                    }
                }
            }
            return ret;
        }
    }
}
