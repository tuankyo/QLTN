using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using BusinessObjects;
using Gnt.Transaction;
using Gnt.Data.DBCommand;
using Gnt.Data;
using System.Data.SqlClient;
using Man.Utils;

namespace Man.Report
{
    public partial class Report : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidId.Value = Func.ParseString(Request["type"]);
            }
        }

        protected override void DoPost()
        {
            //Handle postback from popup
            string eventTarget = Func.ParseString(Request["__EVENTTARGET"]);
            string eventArgument = Func.ParseString(Request["__EVENTARGUMENT"]);
            if (eventTarget.StartsWith("PopUp"))
            {
                if (eventTarget == "PopUpEditUser")
                {
                }
            }
        }
        protected void btnReport_Click(object sender, EventArgs e)
        {
            //Response.Redirect("ReportView.aspx?type="+hidId.Value+"from="+txtDateFrom.Text+"to="+txtDateTo.Text);
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + "ReportView.aspx?reporttype=" + hidId.Value + "from=" + txtDateFrom.Text + "to=" + txtDateTo.Text + "'," + 1200 + "," + 1000 + ",'ReportView.aspx', true);", true);

        }
    }
}
