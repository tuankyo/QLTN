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


namespace Man
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Session["__USERFULLNAME__"] = null;
            Session["__BUILDINGID__"] = null;
        }
        protected void OnAuthenticate(object sender, AuthenticateEventArgs e)
        {
        }

        protected void OnLoggedIn(object sender, EventArgs e)
        {
            Session["__USERFULLNAME__"] = null;
            Session["__BUILDINGID__"] = null;
        }
    }
}
