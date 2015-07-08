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

using Gnt.Data;
using Man.Utils;
using Gnt.Data.DBCommand;
using System.Data.SqlClient;
using BusinessObjects;
using Gnt.Transaction;
using System.Text;

namespace Man.Admin
{
    public partial class ListBuilding : PageBase
    {
        
        

        public string[,] resultSync = new string[20, 3];
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
        /// <summary>
        
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string whereClause = string.Empty;
            //ID
            if (txtId.Text.Trim().Length != 0)
            {
                whereClause += " AND BuildingID LIKE '%" + txtId.Text.Trim() + "%'";
            }

            //Name

            if (txtName.Text.Trim().Length != 0)
            {
                whereClause += " AND Name LIKE N'%" + txtName.Text.Trim() + "%'";
            }

            //Address

            if (txtAddress.Text.Trim().Length != 0)
            {
                whereClause += " AND Address LIKE N'%" + txtAddress.Text.Trim() + "%'";
            }
            //Comment

            if (txtComment.Text.Trim().Length != 0)
            {
                whereClause += " AND Comment LIKE N'%" + txtComment.Text.Trim() + "%'";
            }

            //if (!"".Equals(drpUpdator.SelectedValue)){
            //    whereClause += " AND Updator = '"+ drpUpdator.SelectedValue +"'";
            //}
            //if (!"".Equals(txtUpdatedFrom.Text.Trim()))
            //{
            //    whereClause += " AND Convert(varchar(8), Updated) >= '" + Func.FormatYmd(txtUpdatedFrom.Text.Trim()).Replace("/", "") + "'";
            //}
            //if (!"".Equals(txtUpdatedTo.Text.Trim()))
            //{
            //    whereClause += " AND Convert(varchar(8), Updated) <= '" + Func.FormatYmd(txtUpdatedTo.Text.Trim()).Replace("/", "") + "'";
            //}

            whereClause += " AND BuildingID = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";

            return whereClause;
        }
        /// <summary>
        /// List data
        /// </summary>
        private void ShowData()
        {
            SqlDatabase db = new SqlDatabase();
            string sql = string.Empty;
            if (!Func.IsValid(ListSortExpression))
            {
                    ListSortExpression = "BuildingId";
                    ListSortDirection = SortDirection.Descending;
            }
            try
            {
                
                sql += " SELECT COUNT(*) ";
                sql += " FROM MST_Building";
                sql += " WHERE DelFlag=0 ";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                
                sql += " SELECT *,ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM MST_Building ";
                sql += " WHERE DelFlag=0 ";

                sql = " SELECT * FROM (" + sql + ") AS TMP ";
                sql += " WHERE RowNum BETWEEN @PageIndex*@PageSize + 1  AND (@PageIndex+1)*@PageSize ORDER BY RowNum ";

                SqlCommand cm = db.CreateCommand(sql);
                cm.Parameters.AddWithValue("@PageIndex", pager.CurrentPageIndex);
                cm.Parameters.AddWithValue("@PageSize", pager.PageSize);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataSet ds = new DataSet();
                da.Fill(ds);
                db.Close();
                rptList.DataSource = ds.Tables[0].DefaultView;
                rptList.DataBind();
                pager.Count = count;                
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }

        /// <summary>
        /// Init values
        /// </summary>
        protected override void DoInit()
        {
            DbHelper.FillListSearch(drpUpdator, "Select distinct Updator from MST_Building", "Updator", "Updator");
        }

        protected override void DoPost()
        {
            
            string eventTarget = Func.ParseString(Request["__EVENTTARGET"]);
            string eventArgument = Func.ParseString(Request["__EVENTARGUMENT"]);
            if (eventTarget.StartsWith("PopUp"))
            {
                if (eventTarget == "PopUpEditBuilding")
                {
                    ShowData();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopupWidth = 850;
                PopupHeight = 450;
                PopupName = "EditBuilding";

                ShowData();
            }
        }
        /// <summary>
        /// 

        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void pager_PageIndexChanged(object source, PagerPageChangedEventArgs args)
        {
            ShowData();
        }
        /// <summary>
        /// 

        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string command = e.CommandName;
            string colName = string.Empty;
            if (command.StartsWith("Sort"))
            {
                if (string.Compare(command, "SortBuildingID") == 0)
                {
                    colName = "BuildingID";
                }
                else if (string.Compare(command, "SortName") == 0)
                {
                    colName = "Name";
                }
                else if (string.Compare(command, "SortUpdator") == 0)
                {
                    colName = "Updator";
                }
                else if (string.Compare(command, "SortUpdated") == 0)
                {
                    colName = "Updated";
                }
               

                if (colName == ListSortExpression)
                {
                    ListSortDirection = (ListSortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending);
                }
                else
                {
                    ListSortDirection = SortDirection.Descending;
                }
                ListSortExpression = colName;
                pager.CurrentPageIndex = 0;
                ShowData();
            }
            else if (command.Equals("Edit"))
            {
                string BuildingId = (string)e.CommandArgument;
                Response.Redirect("ListUser.aspx?BuildingId=" + BuildingId);
            }
        }
        /// <summary>
        /// 

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            try
            {
                if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
                {
                    DataRowView row = (DataRowView)item.DataItem;
                    string BuildingID = Func.ParseString(row["BuildingID"]);
                    string Name = Func.ParseString(row["Name"]);
                    string Address = Func.ParseString(row["Address"]);
                    string Comment = Func.ParseString(row["Comment"]);

                    Func.SetGridLinkValue(item, "btnEdit", BuildingID);
                    Func.SetGridTextValue(item, "ltrName", Name);
                    Func.SetGridTextValue(item, "ltrAddress", Address);
                    Func.SetGridTextValue(item, "ltrComment", Func.ToolTipByteLen(Comment, 20));

                    PopupHeight = 600;
                    LinkButton btn = (LinkButton)item.FindControl("btnEdit");
                    btn.CommandArgument = BuildingID;
                }
                else if (item.ItemType == ListItemType.Header)
                {
                    string colName = ListSortExpression;
                    if (Func.IsValid(colName))
                    {
                        string img = string.Empty;
                        if (ListSortDirection == SortDirection.Ascending)
                        {
                            img = "<img src=\"../App_Themes/Default/Images/ASCSymbol.gif\" border=\"0\">";
                        }
                        else
                        {
                            img = "<img src=\"../App_Themes/Default/Images/DSCSymbol.gif\" border=\"0\">";
                        }

                        if (colName.EndsWith("Id"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkTypeId");
                            link.Text = "ID" + img;
                        }
                        else if (colName.EndsWith("Address"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkName");
                            link.Text = "Địa Chỉ" + img;
                        }
                        else if (colName.EndsWith("Name"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkName");
                            link.Text = "Loại Phí" + img;
                        }                      
                        else if (colName.EndsWith("Updator"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkUpdator");
                            link.Text = "Người Cập Nhật" + img;
                        }
                        else if (colName.EndsWith("Updated"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkUpdated");
                            link.Text = "Ngày Cập Nhật" + img;
                        }  
                    }
                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }
        /// <summary>
        

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PopupWidth = 850;
            PopupHeight = 450;
            ShowData();
        }
    }
}
