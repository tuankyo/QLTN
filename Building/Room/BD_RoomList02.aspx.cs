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

namespace Man.Building.Room
{
    public partial class BD_RoomList02 : PageBase
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

        private string popup = "PopupBD_RoomElecWaterEdit";
        private string editElecPageName = "BD_RoomExtraTime";
        private string GetWhere()
        {
            string whereClause = string.Empty;

            if (txtID.Text.Trim().Length != 0)
            {
                whereClause += " AND ID LIKE '%" + txtID.Text.Trim() + "%'";
            }
            if (txtName.Text.Trim().Length != 0)
            {
                whereClause += " AND Name LIKE '%" + txtName.Text.Trim() + "%'";
            }
            if (chkMeetingRoom.Checked)
            {
                whereClause += " AND IsMeetingRoom LIKE '1'";
            }
            else
            {
                whereClause += " AND IsMeetingRoom LIKE '0'";
            }

            if (txtRegional.Text.Trim().Length != 0)
            {
                whereClause += " AND Regional LIKE '%" + txtRegional.Text.Trim() + "%'";
            }
            if (txtFloor.Text.Trim().Length != 0)
            {
                whereClause += " AND Floor LIKE '%" + txtFloor.Text.Trim() + "%'";
            }
            if (txtAreaFrom.Text.Trim().Length != 0)
            {
                whereClause += " AND Area >= " + txtAreaFrom.Text.Trim() + "";
            }

            if (txtAreaTo.Text.Trim().Length != 0)
            {
                whereClause += " AND Area <= " + txtAreaTo.Text.Trim() + "";
            }
            if (rdoActive.Checked)
            {
                whereClause += " AND DelFlag <> 1";

            }
            else if (rdoInActive.Checked)
            {
                whereClause += " AND DelFlag = 1";
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
                ListSortExpression = "A.Modified";
                ListSortDirection = SortDirection.Descending;
            }
            try
            {
                //Đếm số lượng record
                sql += " Select COUNT(ID) ";
                sql += " FROM BD_Room A left outer join (SELECT count(*) num,[RoomId], CustomerId, BuildingId FROM [BD_RoomExtraTime]  where YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";
                sql += " group by RoomId, CustomerId, BuildingId) B  on A.id = B.RoomId and A.BuildingId = B.BuildingId";
                sql += " WHERE (ID IS NOT NULL) and A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";
                sql += GetWhere();

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " Select A.*, B.CustomerId, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM BD_Room A left outer join (SELECT count(*) num,[RoomId], CustomerId, BuildingId FROM [BD_RoomExtraTime]  where YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";
                sql += " group by RoomId, CustomerId, BuildingId) B  on A.id = B.RoomId and A.BuildingId = B.BuildingId";
                sql += " WHERE (ID IS NOT NULL) and A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";
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
            if (!IsPostBack)
            {
                PopupWidth = 600;
                PopupHeight = 450;

                for (int i = 2010; i < 2050; i++)
                {
                    drpYear.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i), Func.ParseString(i)));
                }
                drpYear.Items.FindByValue(DateTime.Now.ToString("yyyy")).Selected = true;

                for (int i = 1; i < 13; i++)
                {
                    drpMonth.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
                }
                drpMonth.Items.FindByValue(DateTime.Now.ToString("MM")).Selected = true;

                ShowData();

                //Mst_BuildingData data = new Mst_BuildingData();
                //ITransaction tran = factory.GetLoadObject(data, Func.ParseString(Session["__BUILDINGID__"]));
                //Execute(tran);
                //if (!HasError)
                //{
                //    //Get Data
                //    data = (Mst_BuildingData)tran.Result;
                //    lblName.Text = data.Name;
                //    lblComment.Text = data.Comment;
                //    lblBuildingId.Text = data.BuildingId;
                //    lblName.Text = data.Name;
                //    lblInvestor.Text = data.Investor;
                //    lblAddress.Text = data.Address;
                //    lblPhone.Text = data.Phone;
                //    lblOwner.Text = data.Owner;
                //    lblManagerCompany.Text = data.ManagerCompany;
                //    lblManagerCompanyAgent.Text = data.ManagerCompanyAgent;
                //    lblManagerCompanyPhone.Text = data.ManagerCompanyPhone;
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
                    string ID = Func.ParseString(row["id"]);
                    string Name = Func.ParseString(row["Name"]);
                    string Comment = Func.ParseString(row["Comment"]);
                    string CustomerId = Func.ParseString(row["CustomerId"]);

                    string IsMeetingRoom = Func.ParseString(row["IsMeetingRoom"]);
                    string Regional = Func.ParseString(row["Regional"]);
                    string Floor = Func.ParseString(row["Floor"]);
                    string Area = Func.ParseString(row["Area"]);

                    CheckBox chkMeetingRoom = (CheckBox)item.FindControl("chkMeetingRoom");
                    chkMeetingRoom.Checked = (IsMeetingRoom == "1" ? true : false);

                    Func.SetGridLinkValue(item, "btnEdit", ID);
                    Func.SetGridTextValue(item, "ltrName", Name);
                    Func.SetGridTextValue(item, "ltrComment", Func.ToolTipByteLen(Comment, 20));

                    Func.SetGridTextValue(item, "ltrRegional", Regional);
                    Func.SetGridTextValue(item, "ltrFloor", Floor);
                    Func.SetGridTextValue(item, "ltrArea", Area);
                    Func.SetGridTextValue(item, "ltrCustomerId", CustomerId);

                    Button btnExtraTime = (Button)item.FindControl("btnExtraTime");
                    Button btnExtraTime01 = (Button)item.FindControl("btnExtraTime01");

                    btnExtraTime.Visible = false;
                    btnExtraTime01.Visible = false;

                    if (!String.IsNullOrEmpty(CustomerId))
                    {
                        btnExtraTime.Visible = true;
                    }
                    else
                    {
                        btnExtraTime01.Visible = true;
                    }

                    PopupWidth = 600;
                    PopupHeight = 600;

                    ButtonPopup((Button)item.FindControl("btnExtraTime"), editElecPageName + ".aspx?Action=Edit&Id=" + ID);
                    ButtonPopup((Button)item.FindControl("btnExtraTime01"), editElecPageName + ".aspx?Action=Edit&Id=" + ID);

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
    }
}
