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

namespace Man.Customer
{
    public partial class PaymentList : PageBase
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

        private string popup = "PopupPaymentEdit";
        private string editPageName = "PaymentOfBD";
        private string editCustomerComplainPage = "CustomerComplain";
        private string editComplainCustomerPage = "ComplainCustomer";

        private string deleteSuccess = "Xóa Thành Công";
        private string deleteUnSuccess = "Xóa Không Thành Công";

        private string GetWhere()
        {
            string whereClause = string.Empty;

            if (txtCustomerId.Text.Trim().Length != 0)
            {
                whereClause += " AND A.CustomerId LIKE '%" + txtCustomerId.Text.Trim() + "%'";
            }
            if (!String.IsNullOrEmpty(drpPaymentType.SelectedValue))
            {
                whereClause += " AND B.id = N'" + drpPaymentType.SelectedValue + "'";
            }
            if (!String.IsNullOrEmpty(drpPaidType.Value))
            {
                whereClause += " AND PaidType = '" + drpPaidType.Value + "'";
            }
            if (txtDateFrom.Text.Trim().Length != 0)
            {
                whereClause += " AND PaymentDate >= '" + Func.FormatYYYYmmdd(txtDateFrom.Text.Trim()) + "'";
            }
            if (txtDateTo.Text.Trim().Length != 0)
            {
                whereClause += " AND PaymentDate <= '" + Func.FormatYYYYmmdd(txtDateTo.Text.Trim()) + "'";
            }
            whereClause += " AND YearMonth ='" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";

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
                string buildingId = Func.ParseString(Session["__BUILDINGID__"]);
                string tmpTable = "Select Name,id from BD_PaymentType Where Id not in (Select ParentId from ";
                tmpTable += "BD_PaymentType  ";
                tmpTable += "Where delflag = '0' and ParentId is not null and BuildingId = '" + buildingId + "') and delflag = '0' and BuildingId = '" + buildingId + "' ";
                tmpTable += "Union ";
                tmpTable += "Select Name,id from Mst_PaymentType";

                //Đếm số lượng record
                //sql = " Select COUNT(*) ";
                //sql += " FROM Payment A";
                //sql += " WHERE (ID IS NOT NULL) and DelFlag = 0 and BuildingId = '" + buildingId + "'";
                sql += " Select Count(*) ";
                sql += " FROM Payment A, (" + tmpTable + ") B";
                sql += " WHERE A.PaymentType = B.Id and A.DelFlag = 0 and BuildingId = '" + buildingId + "'";
                sql += GetWhere();

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " Select A.*,B.Name as PaymentName, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM Payment A, (" + tmpTable + ") B";
                sql += " WHERE A.PaymentType = B.Id and A.DelFlag = 0 and BuildingId = '" + buildingId + "'";
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
                drpYear.Items.FindByValue(DateTime.Now.AddMonths(-1).ToString("yyyy")).Selected = true;

                for (int i = 1; i < 13; i++)
                {
                    drpMonth.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
                }
                drpMonth.Items.FindByValue(DateTime.Now.AddMonths(-1).ToString("MM")).Selected = true;

                string buildingId = Func.ParseString(Session["__BUILDINGID__"]);
                string sql = "Select Name,id from BD_PaymentType Where Id not in (Select ParentId from ";
                sql += "BD_PaymentType  ";
                sql += "Where delflag = '0' and ParentId is not null and BuildingId = '" + buildingId + "') and delflag = '0' and BuildingId = '" + buildingId + "' ";
                sql += "Union ";
                sql += "Select Name,id from Mst_PaymentType where ParentId is not null";
                DbHelper.FillListSearch(drpPaymentType, sql, "Name", "id");

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
        /// <summary>
        /// Update
        /// </summary>
        private void DeleteData(string strId)
        {
            PaymentData data = new PaymentData();
            ITransaction tran = factory.GetLoadObject(data, strId);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (PaymentData)tran.Result;
                data.DelFlag = "1";
                data.MoneyUSD = data.MoneyUSD.Replace(",", ".");
                data.MoneyVND = data.MoneyVND.Replace(",", ".");
                data.RateChange = data.RateChange.Replace(",", ".");

                tran = factory.GetUpdateObject(data);

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, deleteSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(deleteSuccess);
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, deleteUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(deleteUnSuccess);
                }
            }
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
            }
            else if (command.Equals("Delete"))
            {
                DeleteData(Func.ParseString(e.CommandArgument));
            }
            ShowData();

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
                    string ID = Func.ParseString(row["ID"]);
                    string BuildingId = Func.ParseString(row["BuildingId"]);
                    string YearMonth = Func.ParseString(row["YearMonth"]);
                    string PaymentDate = Func.ParseString(row["PaymentDate"]);
                    string CustomerId = Func.ParseString(row["CustomerId"]);
                    string PaymentType = Func.ParseString(row["PaymentName"]);
                    string PaidType = Func.ParseString(row["PaidType"]);
                    string Paymenter = Func.ParseString(row["Paymenter"]);
                    string Receiver = Func.ParseString(row["Receiver"]);
                    string MoneyUSD = Func.ParseString(row["MoneyUSD"]);
                    string MoneyVND = Func.ParseString(row["MoneyVND"]);
                    string Comment = Func.ParseString(row["Comment"]);
                    string DelFlag = Func.ParseString(row["DelFlag"]);

                    Func.SetGridTextValue(item, "ltrBuildingId", BuildingId);
                    Func.SetGridTextValue(item, "ltrYearMonth", String.IsNullOrEmpty(YearMonth) ? "" : YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4));
                    //Func.SetGridTextValue(item, "ltrPaymentDate", Func.FormatDMY(PaymentDate));

                    PopupWidth = 600;
                    PopupHeight = 450;
                    LinkButton btnView = (LinkButton)item.FindControl("btnView");
                    btnView.Text = Func.FormatDMY(PaymentDate);
                    LinkPopup((LinkButton)item.FindControl("btnView"), editPageName + ".aspx?Action=Edit&Id=" + ID);

                    Func.SetGridTextValue(item, "ltrCustomerId", CustomerId);
                    Func.SetGridTextValue(item, "ltrPaymentType", Func.ToolTipByteLen(PaymentType, 15));
                    Func.SetGridTextValue(item, "ltrPaidType", "1".Equals(PaidType) ? "Thu" : "Chi");
                    //Func.SetGridTextValue(item, "ltrPaymenter", Paymenter);
                    //Func.SetGridTextValue(item, "ltrReceiver", Receiver);
                    Func.SetGridTextValue(item, "ltrMoneyUSD", Func.FormatNumber_New(MoneyUSD));
                    Func.SetGridTextValue(item, "ltrMoneyVND", Func.FormatNumber_New(MoneyVND));
                    Func.SetGridTextValue(item, "ltrComment", Func.ToolTipByteLen(Comment, 10));


                    //PopupWidth = 600;
                    //PopupHeight = 450;
                    //LinkPopup((LinkButton)item.FindControl("btnEdit"), editPageName + ".aspx?Action=Edit&Id=" + ID);
                    //ButtonPopup((Button)item.FindControl("btnCustomerComplain"), editCustomerComplainPage + ".aspx?Action=Edit&Id=" + ID);
                    //ButtonPopup((Button)item.FindControl("btnComplainCustomer"), editComplainCustomerPage + ".aspx?Action=Edit&Id=" + ID);

                    string ModifiedBy = Func.ParseString(row["ModifiedBy"].ToString().Trim());
                    string Modified = Func.ParseString(row["Modified"].ToString().Trim());
                    Func.SetGridTextValue(item, "ltrModifiedBy", ModifiedBy);
                    Func.SetGridTextValue(item, "ltrModified", Func.Formatdmyhms(Modified));

                    Button btnDelete = (Button)item.FindControl("btnDelete");
                    btnDelete.CommandArgument = ID;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            PopupWidth = 600;
            PopupHeight = 400;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + editPageName + ".aspx?Action=Register'," + PopupWidth + "," + PopupHeight + ",'" + editPageName + "', true);", true);
        }
    }
}
