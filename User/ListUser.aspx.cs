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

namespace Man.User
{
    public partial class ListUser : PageBase
    {
        protected SortDirection ListSortDirection
        {
            get
            {
                object o = ViewState["SortDirection"];
                if (o == null)
                {
                    return SortDirection.Descending;
                }
                return (SortDirection)o;
            }
            set
            {
                ViewState["SortDirection"] = value;
            }
        }

        protected string ListSortExpression
        {
            get
            {
                object o = ViewState["SortExpression"];
                if (o == null)
                {
                    return "";
                }
                return o.ToString();
            }
            set
            {
                ViewState["SortExpression"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                drpUserType.DataSource = Roles.GetAllRoles();
                drpUserType.DataBind();
                drpUserType.Items.Insert(0, "");
                txtUserName.Focus();
                ShowData();
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
                    ShowData();
                }
            }
        }

        private string GetWhere()
        {
            string sql = string.Empty;
            if (txtUserName.Text.Trim() != string.Empty)
            {
                sql += "AND (FullName LIKE '%" + txtUserName.Text.Trim().Replace("'", "''") + "%' "
                    + " OR U.UserName LIKE '%" + txtUserName.Text.Trim().Replace("'", "''") + "%') ";
            }

            //if (chkAuthority.Items[0].Selected)
            //{
            //    sql += "AND M.SaleUserFlag='1' ";
            //}

            //if (chkAuthority.Items[1].Selected)
            //{
            //    sql += "AND M.InChargeUserFlag='1' ";
            //}

            if (drpUserType.SelectedValue != string.Empty)
            {
                sql += " AND R.RoleName ='" + drpUserType.SelectedValue + "'";
            }
            return sql;
        }
        protected void ShowData()
        {
            SqlDatabase db = new SqlDatabase();
            string sql = string.Empty;
            try
            {
                aspnet_MembershipData member = new aspnet_MembershipData();
                aspnet_UsersData user = new aspnet_UsersData();
                aspnet_UsersInRolesData roles = new aspnet_UsersInRolesData();

                sql = "SELECT count(distinct U.UserName)"
                 + " FROM aspnet_Membership AS M Inner JOIN aspnet_Users AS U ON M.UserId=U.UserId Inner Join Mst_Building AS A on M.BuildingId = A.BuildingId"
                 + " WHERE M.UserId=U.UserId and M.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'" + GetWhere();
                int total = db.ExecuteCount(sql);

                if (!Func.IsValid(ListSortExpression))
                {
                    ListSortExpression = "M.FullName";
                    ListSortDirection = SortDirection.Ascending;
                }
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                sql = "SELECT distinct M.FullName, U.UserName, A.Name as BuildingName, M.Email, M.IsApproved, M.LastLoginDate, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum "
                 + " FROM aspnet_Membership AS M Inner JOIN aspnet_Users AS U ON M.UserId=U.UserId Inner Join Mst_Building AS A on M.BuildingId = A.BuildingId"
                 + " WHERE M.UserId=U.UserId and M.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'" + GetWhere();

                sql = "Select FullName, UserName, BuildingName, Email, IsApproved, LastLoginDate FROM (" + sql + ") as tmp WHERE RowNum BetWeen @PageIndex*@PageSize + 1  and (@PageIndex+1)*@PageSize Order by RowNum";
                SqlCommand cm = db.CreateCommand(sql);
                cm.Parameters.AddWithValue("@PageIndex", pager.CurrentPageIndex);
                cm.Parameters.AddWithValue("@PageSize", pager.PageSize);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataSet ds = new DataSet();
                da.Fill(ds);
                db.Close();
                rptList.DataSource = ds.Tables[0].DefaultView;
                rptList.DataBind();
                pager.Count = total;
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string command = e.CommandName;

            //if (command.StartsWith("Sort"))
            //{
            //    string col = string.Empty;
            //    if (command == "SortUserName")
            //    {
            //        col = "U.UserName";
            //    }
            //    else if (command == "SortFullName")
            //    {
            //        col = "M.FullName";
            //    }
            //    else if (command == "SortRoleName")
            //    {
            //        col = "R.RoleName";
            //    }
            //    else if (command == "SortLastLoginDate")
            //    {
            //        col = "M.LastLoginDate";
            //    }
            //    else if (command == "SortIsApproved")
            //    {
            //        col = "M.IsApproved";
            //    }
            //    if (col == ListSortExpression)
            //    {
            //        ListSortDirection = (ListSortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending);
            //    }
            //    else
            //    {
            //        ListSortDirection = SortDirection.Descending;
            //    }
            //    ListSortExpression = col;
            //    pager.CurrentPageIndex = 0;
            //    ShowData();
            //}
            //else
            if (command == "Delete")
            {
                SqlDatabase db = new SqlDatabase();
                string id = Func.ParseString(e.CommandArgument);
                try
                {
                    if (Membership.DeleteUser(Func.ParseString(e.CommandArgument)))
                    {
                        OperationLogger.WriteInfo(Constants.LogOperationUserId, Constants.LogActionDeleteId, "Xóa Thành Công", Page.User.Identity.Name);
                        mvMessage.SetCompleteMessage("Xóa Thành Công");
                    }
                    else
                    {
                        OperationLogger.WriteError(Constants.LogOperationUserId, Constants.LogActionDeleteId, "Xóa Phát Sinh Lỗi", Page.User.Identity.Name);
                        mvMessage.SetCompleteMessage("Xóa Phát Sinh Lỗi");
                    }
                }
                catch (Exception ex)
                {
                    ApplicationLog.WriteError(ex);
                    OperationLogger.WriteError(Constants.LogOperationUserId, Constants.LogActionDeleteId, "Xóa Phát Sinh Lỗi", Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage("Xóa Phát Sinh Lỗi");
                }
                ShowData();
            }
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
            {
                DataRowView row = (DataRowView)item.DataItem;
                string index = item.ItemIndex.ToString();
                string userName = Func.ParseString(row["UserName"]);
                string isApproved = Func.ParseString(row["IsApproved"]);

                MembershipUser user = Membership.GetUser(userName);
                Literal tmp = (Literal)item.FindControl("ltrUserName");
                tmp.Text = userName;

                tmp = (Literal)item.FindControl("ltrFullName");
                tmp.Text = Func.ParseString(row["FullName"]);

                //tmp = (Literal)item.FindControl("ltrRoleName");
                tmp.Text = Func.ParseString(row["BuildingName"]);

                tmp = (Literal)item.FindControl("ltrEmail");
                tmp.Text = Func.ParseString(row["Email"]);

                CheckBox chk = (CheckBox)item.FindControl("chkOnline");
                chk.Checked = user.IsOnline;

                //chk = (CheckBox)item.FindControl("chkIsApproved");
                //chk.Checked = isApproved == "1";

                tmp = (Literal)item.FindControl("ltrLastLoginDate");
                tmp.Text = DateTime.Parse(Func.ParseString(row["LastLoginDate"])).ToString("dd/MM/yyyy hh:mm:ss");

                LinkButton btnEdit = (LinkButton)item.FindControl("btnEdit");
                btnEdit.OnClientClick = "PopUp('EditUser.aspx?Action=Edit&UserName=" + userName + "', 600,500,'EditUser', true); return false;";

                LinkButton btnDelete = (LinkButton)item.FindControl("btnDelete");
                btnDelete.CommandArgument = userName;
                btnDelete.OnClientClick = "return confirm('Xóa người dùng?');";


            }
            else if (item.ItemType == ListItemType.Header)
            {
                Button btnAdd = (Button)item.FindControl("btnAdd");
                btnAdd.OnClientClick = "PopUp('EditUser.aspx', 600,500,'EditUser', true); return false;";

                //string col = ListSortExpression;
                //if (Func.IsValid(col))
                //{
                //    string img = string.Empty;
                //    if (ListSortDirection == SortDirection.Ascending)
                //    {
                //        img = "<img src=\"../App_Themes/Default/Images/ASCSymbol.gif\" border=\"0\">";
                //    }
                //    else
                //    {
                //        img = "<img src=\"../App_Themes/Default/Images/DSCSymbol.gif\" border=\"0\">";
                //    }

                //    if (col.EndsWith("UserName"))
                //    {
                //        LinkButton link = (LinkButton)item.FindControl("lnkUserName");
                //        link.Text = "Tên Truy Cập" + img;
                //    }
                //    if (col.EndsWith("FullName"))
                //    {
                //        LinkButton link = (LinkButton)item.FindControl("lnkFullName");
                //        link.Text = "Họ Tên" + img;
                //    }
                //    else if (col.EndsWith("RoleName"))
                //    {
                //        LinkButton link = (LinkButton)item.FindControl("lnkRoleName");
                //        link.Text = "Quyền Hạn" + img;
                //    }
                //    else if (col.EndsWith("LastLoginDate"))
                //    {
                //        LinkButton link = (LinkButton)item.FindControl("lnkLastLoginDate");
                //        link.Text = "Sử Dụng Lần Cuối" + img;
                //    }
                //    else if (col.EndsWith("IsApproved"))
                //    {
                //        LinkButton link = (LinkButton)item.FindControl("lnkIsApproved");
                //        link.Text = "Trạng Thái" + img;
                //    }
                //}
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            pager.CurrentPageIndex = 0;
            ShowData();
        }

        protected void pager_PageIndexChanged(object source, PagerPageChangedEventArgs args)
        {
            ShowData();
        }

    }
}
