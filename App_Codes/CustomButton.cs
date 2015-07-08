using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace Man
{
    public class CustomButton : System.Web.UI.WebControls.Button
    {
        private bool _isSecure = true;

        public bool IsSecure
        {
            get { return this._isSecure; }
            set { this._isSecure = value; }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (_isSecure)
            {
                //if (Page.User.IsInRole(Constants.Visitors))
                //{
                //    this.Enabled = false;
                //    this.ToolTip = "実行権限がありません。";
                //    this.OnClientClick = "";
                //}
                //else if (Page.User.IsInRole(Constants.AgencyUsers) && Page.Request.Path.IndexOf("Agency") == -1)
                //{
                //    this.Enabled = false;
                //    this.ToolTip = "実行権限がありません。";
                //    this.OnClientClick = "";
                //}
            }
            base.Render(writer);
        }
    }
}
