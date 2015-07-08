using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

//using BusinessObjects;
using Gnt.Transaction;
using Gnt.Data.DBCommand;
using Gnt.Data;
using Man.Utils;

namespace Man.UserControls.Common
{
    public partial class ShowEditInfomation : System.Web.UI.UserControl
    {

        public string KeyColumnName
        {
            get
            {
                if (ViewState["KeyColumnName"] != null)
                    return ViewState["KeyColumnName"].ToString();
                else
                    return "";
            }
            set
            {
                        if (value != null)
                        {
                            ViewState["KeyColumnName"] = value;
                        }
                }
        }

        public string KeyValue
        {
            get
            {
                if (ViewState["KeyValue"] != null)
                    return ViewState["KeyValue"].ToString();
                else
                    return "";
            }
            set
            {
                if (value != null)
                {
                    ViewState["KeyValue"] = value;
                }
            }
        }

        public string TableName
        {
            get 
            {
                if (ViewState["TableName"] != null)
                    return ViewState["TableName"].ToString();
                else
                    return "";            
            }
            set
            {
                if (value != null)
                {
                    ViewState["TableName"] = value;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)        
        {            
                Render();
        }

        /// <summary>
        ///  Access database to recive and render content to control
        /// </summary>
        public void Render()
        {
            string sql = string.Format("SELECT [Creator], [Created], [ModifiedBy], [Modified] FROM [{0}] WHERE [{1}] = '{2}'; ", TableName, KeyColumnName, KeyValue);
            SqlDatabase db = new SqlDatabase();
            try
            {
                DataSet ds = db.ExecuteDataSet(sql);
                if (ds.Tables.Count >= 1)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count >= 1)
                    {
                        DataRow dr = dt.Rows[0];
                        lblEditDate.Text = Func.Formatdmyhms(dr[3].ToString());
                        lblEditer.Text = Func.GetFullNameByUserName(dr[2].ToString());
                        lblRegister.Text = Func.GetFullNameByUserName(dr[0].ToString());
                        lblRegisterDate.Text = Func.Formatdmyhms(dr[1].ToString());
                    }
                }

            }
            catch
            {
                lblEditDate.Text = " ";
                lblEditer.Text = " ";
                lblRegister.Text = " ";
                lblRegisterDate.Text = " ";
            }

            db.Close();
        }
    }
}