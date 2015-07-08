using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using Gnt.Data;
using Man.Utils;

namespace Man
{
    public class OperationLogger
    {
        private static void Write(int operationId,int actionId, string information, string creator,int status)
        {
            string sql = string.Empty;
            StringBuilder sb = new StringBuilder();
            SqlDatabase db = new SqlDatabase(ICJSystem.Instance.ConnectionString1);
            try
            {
                Func.AddSqlString(sb, "INSERT INTO OperationLog");
                Func.AddSqlString(sb, "(");
                Func.AddSqlString(sb, "  [Date],");                
                Func.AddSqlString(sb, "  OperationId,");
                Func.AddSqlString(sb, "  ActionId,");
                Func.AddSqlString(sb, "  Information,");
                Func.AddSqlString(sb, "  [Status],");                
                Func.AddSqlString(sb, "  Creator");
                Func.AddSqlString(sb, ")VALUES");
                Func.AddSqlString(sb, "(");
                Func.AddSqlString(sb, "	'" + DateTime.Now.ToString("yyyyMMddHHmmss") + "',");                
                Func.AddSqlString(sb, "	" + operationId + ",");
                Func.AddSqlString(sb, "	" + actionId + ",");
                Func.AddSqlString(sb, "	'" + information + "',");
                Func.AddSqlString(sb, "	" + status + ",");                
                Func.AddSqlString(sb, "	'" + creator + "'");
                Func.AddSqlString(sb, ")");
                sql = sb.ToString();
                db.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }            
        }

        public static void WriteInfo(int operationId,int actionId,string information,string creator)
        {
            Write(operationId, actionId, information, creator, 1);
        }

        public static void WriteError(int operationId,int actionId, string information, string creator)
        {
            Write(operationId, actionId, information, creator, 0);
        }
    }
}
