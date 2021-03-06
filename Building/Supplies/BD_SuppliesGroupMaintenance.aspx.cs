﻿using System;
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

namespace Man.Building.Supplies
{
    public partial class BD_SuppliesGroupMaintenance : PageBase
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

        private string popup = "PopupBD_SuppliesGroupEdit";
        private string editPageName = "BD_SuppliesGroupMaintenanceEdit";

        private string GetWhere()
        {
            string whereClause = string.Empty;

            if (txtMaintenanceItem.Text.Trim().Length != 0)
            {
                whereClause += " AND MaintenanceItem LIKE '%" + txtMaintenanceItem.Text.Trim() + "%'";
            }
            if (txtScheduleDate.Text.Trim().Length != 0)
            {
                whereClause += " AND ScheduleDate <= N'%" + txtScheduleDate.Text.Trim() + "%'";
            }

            if (txtDescriptionSearch.Text.Trim().Length != 0)
            {
                whereClause += " AND Description LIKE N'%" + txtDescriptionSearch.Text.Trim() + "%'";
            }
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
                ListSortExpression = "Modified";
                ListSortDirection = SortDirection.Descending;
            }
            try
            {
                //Đếm số lượng record
                sql += " Select COUNT(ID) ";
                sql += " FROM BD_SuppliesGroupMaintenance";
                sql += " WHERE (Id IS NOT NULL) and DelFlag = 0 and SuppliesGroupId = '" + hidId.Value + "'";
                sql += GetWhere();

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " Select *, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM BD_SuppliesGroupMaintenance";
                sql += " WHERE (Id IS NOT NULL) and DelFlag = 0 and SuppliesGroupId = '" + hidId.Value + "'";
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
            hidId.Value = Request["id"];
            hidSuppliesType.Value = Request["SuppliesType"];
        }

        protected override void DoPost()
        {
            hidId.Value = Request["id"];
            hidSuppliesType.Value = Request["SuppliesType"];

            //Handle postback from popup
            string eventTarget = Func.ParseString(Request["__EVENTTARGET"]);
            string eventArgument = Func.ParseString(Request["__EVENTARGUMENT"]);
            if (eventTarget.StartsWith("Popup"))
            {
                if (eventTarget == popup)
                {
                    //BD_SuppliesGroupData data = new BD_SuppliesGroupData();
                    //ITransaction tran = factory.GetLoadObject(data, hidId.Value);
                    //Execute(tran);
                    //if (!HasError)
                    //{
                    //    //Get Data
                    //    data = (BD_SuppliesGroupData)tran.Result;
                    //    txtGroupName.Text = data.GroupName;
                    //}
                    ShowData();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //hidSuppliesType.Value = Func.ParseString(Request["SuppliesType"]);
            hidId.Value = Func.ParseString(Request["id"]);
            //switch (hidSuppliesType.Value)
            //{
            //    case "1":
            //        ltrPage.Text = "Quản lý hoạt động > Vật tư > Bảo trì";
            //        break;
            //    case "2":
            //        ltrPage.Text = "Quản lý hoạt động > Thiết bị > Bảo trì";
            //        break;
            //    case "3":
            //        ltrPage.Text = "Kế toán > Vật tư > Bảo trì";
            //        break;
            //    case "4":
            //        ltrPage.Text = "Kế toán > Thiết bị > Bảo trì";
            //        break;
            //    case "5":
            //        ltrPage.Text = "Kỹ thuật > Vật tư > Bảo trì";
            //        break;
            //    case "6":
            //        ltrPage.Text = "Kỹ thuật > Thiết bị > Bảo trì";
            //        break;
            //}
            //if (!IsPostBack)
            //{
            //    PopupWidth = 600;
            //    PopupHeight = 450;
            //    ShowData();

            BD_SuppliesGroupData data = new BD_SuppliesGroupData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_SuppliesGroupData)tran.Result;
                txtGroupName.Text = data.GroupName;
                ShowData();
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
                    string MaintenanceItem = Func.ParseString(row["MaintenanceItem"]);
                    string ScheduleDate = Func.ParseString(row["ScheduleDate"]);
                    string Description = Func.ParseString(row["Description"]);
                    string Comment = Func.ParseString(row["Comment"]);

                    Func.SetGridTextValue(item, "ltrMaintenanceItem", MaintenanceItem);
                    Func.SetGridTextValue(item, "ltrDescription", Description);
                    Func.SetGridTextValue(item, "ltrScheduleDate", Func.FormatDMY(ScheduleDate));

                    Func.SetGridTextValue(item, "ltrComment", Func.ToolTipByteLen(Comment, 20));

                    PopupWidth = 600;
                    PopupHeight = 450;

                    Button btnScheduleExec = (Button)item.FindControl("btnScheduleExec");
                    btnScheduleExec.CommandArgument = Func.ParseString(row["id"]);

                    ButtonPopup((Button)item.FindControl("btnScheduleExec"), editPageName + ".aspx?Action=Edit&Id=" + ID);


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

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            PopupWidth = 600;
            PopupHeight = 450;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + editPageName + ".aspx?ID=" + hidId.Value + "&Action=Register'," + PopupWidth + "," + PopupHeight + ",'" + editPageName + "', true);", true);
        }
    }
}
