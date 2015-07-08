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


namespace Man
{
    public partial class WebForm1 : PageBase
    {
        
        protected override void DoGet()
        {
            
        }

        protected override void DoPost()
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "Hello";
        }
    }
}
