using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Services.Protocols;

using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using Gnt.Data;
using Gnt.Transaction;
using Man.Utils;
using System.Runtime.InteropServices;

namespace Man
{
    public partial class Test : PageBase
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Request["type"];

            DataTable dt = GetCopyrightFeeUnique(type);
            StringBuilder strSQL = new StringBuilder();

            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    string CopyrightContractId = row["CopyrightContractId"].ToString();    
                    string PriceNoTax = row["PriceNoTax"].ToString();
                    string SongMediaId = row["SongMediaId"].ToString();

                    string CopyrightFeeUnique = Func.GetCopyrightFeeUnique(CopyrightContractId, PriceNoTax, type);
                    strSQL.AppendLine("Update SongMedia Set CopyrightFeeUnique = '"+ CopyrightFeeUnique +"' Where SongMediaId = '"+ SongMediaId +"' and TypeId = '"+ type +"'");
                }
                catch (Exception exc)
                {

                }
                finally
                {
                }
            }
            Console.Write("");
            
            
        }
        

        
        private DataTable GetCopyrightFeeUnique(string type)
        {
            DataTable retTable = null;
            string sql = string.Empty;
            StringBuilder sb = new StringBuilder();
            try
            {
                Func.AddSqlString(sb, "select S.CopyrightOrg,S.CopyrightContractId, SM.SongMediaId,SM.PriceNoTax from Song S, SongMedia SM");
                Func.AddSqlString(sb, "where S.SongId = SM.songid and (SM.CopyrightFeeUnique is null or SM.CopyrightFeeUnique = 0)");
                Func.AddSqlString(sb, "and TypeId = '"+ type +"' and SM.HaishinDate is not null");
                Func.AddSqlString(sb, "and S.CopyrightOrg is not null ");

                sql = sb.ToString();

                retTable = DbHelper.GetDataTable(sql);
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
            return retTable;
        }
    }
}
