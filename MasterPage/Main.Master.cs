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
using Gnt.Transaction;
using Gnt.Data.DBCommand;
using Gnt.Data;
using Man.Utils;

namespace Man.MasterPage
{
    public partial class Main : System.Web.UI.MasterPage
    {
        private int PopUpChangePassWidth = 500;
        private int PubUpChangePassHeigh = 250;

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "Select * from UsersMessagesMapped Where UserName = '" + Page.User.Identity.Name + "' and Delflag = 0";
            DataTable dtable = new DataTable();

            dtable = DbHelper.GetDataTable(sql);
            int cntInbox = 0;
            int cntInboxReadNotYet = 0;
            foreach (DataRow dr in dtable.Rows)
            {
                string strPlaceHolderID = dr["PlaceHolderID"].ToString();
                string IsRead = dr["IsRead"].ToString();
                string IsReply = dr["IsReply"].ToString();

                switch (strPlaceHolderID)
                {
                    case "1":
                        cntInbox++;
                        if ("0".Equals(IsRead))
                            cntInboxReadNotYet++;
                        break;
                }
            }
            cntInboxReadNotYet += DbHelper.GetCount("Select count(*) from MessageCommentReadFlg Where UserName = '" + Page.User.Identity.Name + "' and Delflag = 0 and ReadFlag = 0");
            lnkInbox.Text = "Tin nhắn(" + cntInboxReadNotYet + ")";

            //ltrScript.Text = " <script  language=\"javascript\" type=\"text/javascript\" src=\"" + ResolveClientUrl("~/js/common.js") + "\"></script>" +
            //                "<script  language=\"javascript\" type=\"text/javascript\" src=\"" + ResolveClientUrl("~/js/tooltip.js") + "\"></script>";

            if (!IsPostBack)
            {
                DataTable dtR = DbHelper.GetDataTable("Select RoleId from Mst_UserInRoles Where Username = '" + Page.User.Identity.Name + "'");
                if (dtR != null)
                {
                    foreach (DataRow row in dtR.Rows)
                    {
                        string functionName = row["roleId"].ToString();
                        if (!mnuMain.UserRoles.Contains(functionName))
                            mnuMain.UserRoles.Add(functionName);
                    }
                    if (Page.User.IsInRole("Administrators"))
                    {
                        mnuMain.UserRoles.Add("Administrators");
                    }
                }

                mnuMain.DataSource = Server.MapPath("~/MasterPage/MenuData.xml");
                mnuMain.DataBind();

                //Check latest version
                System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
                string appVer = asm.GetName().Version.ToString();
                //get the location of our executing assembly
                System.IO.FileInfo inf = new System.IO.FileInfo(asm.Location);
                DateTime dt = inf.LastWriteTime;
                //ltrLastVersion.Text = "<font size=\"1pt\" color=\"gray\"> 最終メンテナンス: " + dt.ToString("MM/dd HH:mm:ss") + " | バージョン: " + appVer + "</font>";

                //if (Page.User.IsInRole(ICJSystem.Instance.RoleLevel1))
                //{
                //    smSource.SiteMapProvider = ICJSystem.Instance.RoleLevel1;
                //}
                //else if (Page.User.IsInRole(ICJSystem.Instance.RoleLevel2))
                //{
                //    smSource.SiteMapProvider = ICJSystem.Instance.RoleLevel2;
                //}
                //else if (Page.User.IsInRole(ICJSystem.Instance.RoleLevel3))
                //{
                //    smSource.SiteMapProvider = ICJSystem.Instance.RoleLevel3;
                //}
                MembershipUser a = Membership.GetUser(Page.User.Identity.Name);
                if (a.IsLockedOut)
                {
                    Response.Redirect("Login.aspx");
                }
                if (Page.User.Identity.Name != null && Page.User.Identity.Name != string.Empty)
                {
                    SqlDatabase db = null;
                    sql = string.Empty;
                    string FullName = string.Empty;
                    string buildingId = string.Empty;
                    lnkChangePass.OnClientClick = "PopUp('" + ResolveClientUrl("~/ChangePassword.aspx?uid=") + Page.User.Identity.Name + "', " + PopUpChangePassWidth + " , " + PubUpChangePassHeigh + ", 'ChangePassord'); return false;";
                    try
                    {
                        if (Session["__USERFULLNAME__"] != null)
                        {
                            FullName = Func.ParseString(Session["__USERFULLNAME__"]);
                        }
                        else
                        {
                            db = new SqlDatabase();
                            sql = "SELECT FullName FROM aspnet_Membership "
                            + " WHERE UserId=(SELECT UserId FROM aspnet_Users WHERE UserName='" + Page.User.Identity.Name + "')";
                            FullName = Func.ParseString(db.ExecuteScalar(sql));
                            Session["__USERFULLNAME__"] = (FullName.Length != 0 ? FullName : Page.User.Identity.Name);
                        }
                        ltrFullName.Text = FullName;

                        //if (Session["__BUILDINGID__"] != null)
                        //{
                        //    db = new SqlDatabase();
                        //    buildingId = Func.ParseString(Session["__BUILDINGID__"]);
                        //    lblCompanyName.Text = Func.ParseString(db.ExecuteScalar("Select Name From Mst_Building Where BuildingId = '" + buildingId + "'"));
                        //}
                        //else
                        //{
                        //    db = new SqlDatabase();
                        //    sql = "SELECT BuildingId FROM aspnet_Membership "
                        //    + " WHERE UserId=(SELECT UserId FROM aspnet_Users WHERE UserName='" + Page.User.Identity.Name + "')";
                        //    buildingId = Func.ParseString(db.ExecuteScalar(sql));
                        //    Session["__BUILDINGID__"] = (buildingId.Length != 0 ? buildingId : null);
                        //    lblCompanyName.Text = Func.ParseString(db.ExecuteScalar("Select Name From Mst_Building Where BuildingId = '" + buildingId + "'"));
                        //}

                        db = new SqlDatabase();
                        sql = "SELECT BuildingId FROM aspnet_Membership "
                        + " WHERE UserId=(SELECT UserId FROM aspnet_Users WHERE UserName='" + Page.User.Identity.Name + "')";
                        buildingId = Func.ParseString(db.ExecuteScalar(sql));
                        Session["__BUILDINGID__"] = (buildingId.Length != 0 ? buildingId : null);
                        lblCompanyName.Text = Func.ParseString(db.ExecuteScalar("Select Name From Mst_Building Where BuildingId = '" + buildingId + "'"));
                    }
                    catch
                    {
                        ltrFullName.Text = Page.User.Identity.Name;
                        Session["__USERFULLNAME__"] = Page.User.Identity.Name;
                        Response.Redirect("Login.aspx");
                    }
                    if (String.IsNullOrEmpty(Func.ParseString(Session["__BUILDINGID__"])))
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
                else
                {
                    Session["__USERFULLNAME__"] = null;
                    Response.Redirect("Login.aspx");
                }
            }
        }

    }
}

