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

namespace Man.Building.StatusInfo
{
    public partial class BD_StatusInfoList : PageBase
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

        private string popup = "PopupBD_StatusInfoEdit";
        private string editPageName = "BD_StatusInfoEdit";

        /// <summary>
        /// List data
        /// </summary>
        private void ShowData()
        {
            SqlDatabase db = new SqlDatabase();
            string sql = string.Empty;
            if (!Func.IsValid(ListSortExpression))
            {
                ListSortExpression = "Modified";
                ListSortDirection = SortDirection.Descending;
            }
            try
            {
                //Đếm số lượng record
                sql += " Select COUNT(ID) ";
                sql += " FROM BD_StatusInfo";
                sql += " WHERE (Id IS NOT NULL) and DelFlag = '0' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and Type = '" + hidType.Value + "'";
                sql += GetWhere();

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " Select *, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM BD_StatusInfo";
                sql += " WHERE (Id IS NOT NULL) and DelFlag = '0' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and Type = '" + hidType.Value + "'";
                sql += GetWhere();

                //Phân trang
                sql = " Select * FROM (" + sql + ") AS TMP ";
                sql += " WHERE RowNum BETWEEN @PageIndex*@PageSize + 1  AND (@PageIndex+1)*@PageSize ORDER BY RowNum ";

                //Thực hiện câu SQL

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
        }

        protected override void DoPost()
        {
            //Handle postback from popup
            string eventTarget = Func.ParseString(Request["__EVENTTARGET"]);
            string eventArgument = Func.ParseString(Request["__EVENTARGUMENT"]);
            if (eventTarget.StartsWith("Popup"))
            {
                if (eventTarget == popup)
                {
                    ShowData();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            hidType.Value = Func.ParseString(Request["Type"]);
            if (hidType.Value == "1")
            {
                ltrPage.Text = "Quản lý kỹ thuật -> Quản lý thi công nội thất";
            }

            else
            {
                ltrPage.Text = "Quản lý kỹ thuật -> Quản lý thi công sửa chửa";
            }

            if (!IsPostBack)
            {
                PopupWidth = 600;
                PopupHeight = 450;
                ShowData();

                //Mst_BuildingData data = new Mst_BuildingData();
                //ITransaction tran = factory.GetLoadObject(data, Func.ParseString(Session["__BUILDINGID__"]));
                //Execute(tran);
                //if (!HasError)
                //{
                //    //Get Data
                //    data = (Mst_BuildingData)tran.Result;
                //    //lblName.Text = data.Name;
                //    //lblComment.Text = data.Comment;
                //    //lblBuildingId.Text = data.BuildingId;
                //    //lblName.Text = data.Name;
                //    //lblInvestor.Text = data.Investor;
                //    //lblAddress.Text = data.Address;
                //    //lblPhone.Text = data.Phone;
                //    //lblOwner.Text = data.Owner;
                //    //lblManagerCompany.Text = data.ManagerCompany;
                //    //lblManagerCompanyAgent.Text = data.ManagerCompanyAgent;
                //    //lblManagerCompanyPhone.Text = data.ManagerCompanyPhone;
                //}
            }
        }

        /// </summary> Chọn trang
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void pager_PageIndexChanged(object source, PagerPageChangedEventArgs args)
        {
            ShowData();
        }

        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string command = e.CommandName;
            string colName = string.Empty;
            if (command.StartsWith("Sort"))
            {
                if (string.Compare(command, "SortID") == 0)
                {
                    colName = "ID";
                }
                else if (string.Compare(command, "SortName") == 0)
                {
                    colName = "Name";
                }
                else if (string.Compare(command, "SortModifiedBy") == 0)
                {
                    colName = "ModifiedBy";
                }
                else if (string.Compare(command, "SortModified") == 0)
                {
                    colName = "Modified";
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

        }

        /// </summary>Hiển thị nội dung trên datagrid
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
                    string ID = Func.ParseString(row["Id"]);
                    string Region = Func.ParseString(row["Region"]);
                    string Floor = Func.ParseString(row["Floor"]);
                    string Room = Func.ParseString(row["Room"]);
                    string Status = Func.ParseString(row["Status"]);
                    string StatusDate = Func.FormatDMY(row["StatusDate"]);
                    string Description = Func.ParseString(row["Description"]);

                    string Comment = Func.ParseString(row["Comment"]);


                    Func.SetGridLinkValue(item, "btnEdit", StatusDate);
                    Func.SetGridTextValue(item, "ltrRegion", Region);
                    Func.SetGridTextValue(item, "ltrFloor", Floor);
                    Func.SetGridTextValue(item, "ltrRoom", Room);
                    Func.SetGridTextValue(item, "ltrStatus", Status);
                    //Func.SetGridTextValue(item, "ltrStatusDate", StatusDate);
                    Func.SetGridTextValue(item, "ltrDescription", Func.ToolTipByteLen(Description, 20));

                    Func.SetGridTextValue(item, "ltrComment", Func.ToolTipByteLen(Comment, 20));

                    PopupWidth = 600;
                    PopupHeight = 450;
                    LinkPopup((LinkButton)item.FindControl("btnEdit"), editPageName + ".aspx?Action=Edit&Id=" + ID);

                    string ModifiedBy = Func.ParseString(row["ModifiedBy"].ToString().Trim());
                    string Modified = Func.ParseString(row["Modified"].ToString().Trim());
                    Func.SetGridTextValue(item, "ltrModifiedBy", ModifiedBy);
                    Func.SetGridTextValue(item, "ltrModified", Func.Formatdmyhms(Modified));

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
                        else if (colName.EndsWith("ModifiedBy"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkModifiedBy");
                            link.Text = "Cập Nhật" + img;
                        }
                        else if (colName.EndsWith("Modified"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkModified");
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
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PopupWidth = 600;
            PopupHeight = 450;
            ShowData();
        }
        private string GetWhere()
        {
            string whereClause = string.Empty;

            if (txtStatusDateFrom.Text.Trim().Length != 0)
            {
                whereClause += " AND StatusDate >= '" + Func.FormatYYYYmmdd(txtStatusDateFrom.Text.Trim()) + "'";
            }

            if (txtStatusDateTo.Text.Trim().Length != 0)
            {
                whereClause += " AND StatusDate <= '" + Func.FormatYYYYmmdd(txtStatusDateTo.Text.Trim()) + "'";
            }

            if (txtStatus.Text.Trim().Length != 0)
            {
                whereClause += " AND Status LIKE N'%" + txtStatus.Text.Trim() + "%'";
            }
            if (txtRegion.Text.Trim().Length != 0)
            {
                whereClause += " AND Region LIKE N'%" + txtRegion.Text.Trim() + "%'";
            }
            if (txtFloor.Text.Trim().Length != 0)
            {
                whereClause += " AND Floor LIKE N'%" + txtFloor.Text.Trim() + "%'";
            }
            if (txtRoom.Text.Trim().Length != 0)
            {
                whereClause += " AND Room LIKE N'%" + txtRoom.Text.Trim() + "%'";
            }
            if (txtDescription.Text.Trim().Length != 0)
            {
                whereClause += " AND Description LIKE N'%" + txtDescription.Text.Trim() + "%'";
            }
            if (txtComment.Text.Trim().Length != 0)
            {
                whereClause += " AND Comment LIKE N'%" + txtComment.Text.Trim() + "%'";
            }
            return whereClause;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            PopupWidth = 600;
            PopupHeight = 600;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + editPageName + ".aspx?Action=Register&type=" + hidType.Value + "'," + PopupWidth + "," + PopupHeight + ",'" + editPageName + "', true);", true);
        }
    }
}
