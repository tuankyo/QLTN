using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Gnt.Data;
using Man.Utils;
using Gnt.Data.DBCommand;
using System.Data.SqlClient;
using BusinessObjects;
using Gnt.Transaction;
using System.Text;
using Gnt.Utils.FastCsv;
using C1.C1Excel;
using System.IO;
using System.Drawing;
using System.Net;
using System.Collections;
using System.Collections.Specialized;
using Gnt.Configuration;

namespace Man
{
    /// <summary>
    /// Summary description for AutoCompleteExtender
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AutoCompleteExtender : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string[] getAutoList(string prefixText, int count, string contextKey)
        {
            List<string> autoList = new List<string>(count);
            if (!prefixText.StartsWith("%"))
            {
                SqlConnection sqlConn = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString);

                sqlConn.Open();

                SqlCommand sqlSelect = new SqlCommand("select top " + count + " UserName + '(' + FullName + ')' username from vw_aspnet_MembershipUsers where BuildingId = '"+ contextKey +"' and (UserName like @prefixText or FullName like @prefixText)", sqlConn);

                sqlSelect.CommandType = System.Data.CommandType.Text;

                sqlSelect.Parameters.Add("@prefixText", System.Data.SqlDbType.NVarChar).Value = "%" + prefixText + "%";

                SqlDataReader sqlRead = sqlSelect.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (sqlRead.Read())
                {
                    autoList.Add(sqlRead["username"].ToString());
                }

                return autoList.ToArray();
            }
            else
            {
                return new string[0];
            }
        }
    }

}
