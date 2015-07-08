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

using Gnt.Data.DBCommand;
using Gnt.Data;
using System.Data.SqlClient;
using BusinessObjects;
using Gnt.Transaction;
using Man.Utils;

namespace Man.Building.Room
{
    public partial class BD_RoomBookingList : Man.PageBase
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

        private string action = String.Empty;
        private string id = String.Empty;

        private string updateSuccess = "Cập Nhật Thông Tin Đã Thành Công";
        private string updateUnSuccess = "Cập Nhật Thông Tin Không Thành Công";
        private string addSuccess = "Thêm Mới Thành Công";
        private string addUnSuccess = "Thêm Mới Không Thành Công";
        private string title = "Biểu Phí Tiền Nước";
        private string postback = "window.opener.__doPostBack('PopupRC_Room','');";
        private string key = "openRC_Room";

        /// <summary>
        /// Init values
        /// </summary>
        private void InitValues()
        {
        }

        /// <summary>
        /// Load data
        /// </summary>
        private void LoadData()
        {

        }

        /// <summary>
        /// Init values
        /// </summary>
        protected override void DoInit()
        {
            InitValues();
        }
        protected override void DoGet()
        {
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        protected override void DoPost()
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
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
                ListSortExpression = "ContractDate";
                ListSortDirection = SortDirection.Descending;
            }
            try
            {
                string buildingId = Func.ParseString(Session["__BUILDINGID__"]);
                Hashtable PaymentList = new Hashtable();
                string sqlWhere = "";
                if (optDept.Checked)
                {
                    sqlWhere = " and (DeptUSD <> 0 or DeptVND <> 0) and Status = 1";
                }
                else if (optNoDept.Checked)
                {
                    sqlWhere = " and DeptUSD = 0 and DeptVND = 0 and Status = 1";
                }
                else if (optBook.Checked)
                {
                    sqlWhere = " and Status = 0";
                }
                if (!String.IsNullOrEmpty(txtCustomer.Text))
                {
                    sqlWhere += " and CustomerName like N'%" + txtCustomer.Text + "%'";
                }
                if (!String.IsNullOrEmpty(txtRoomName.Text))
                {
                    sqlWhere += " and Name like N'%" + txtRoomName.Text + "%'";
                }

                if (!String.IsNullOrEmpty(txtFromDate.Text))
                {
                    sqlWhere += " and BookingDate >= '" + Func.FormatYYYYmmdd(txtFromDate.Text) + "'";
                }
                if (!String.IsNullOrEmpty(txtToDate.Text))
                {
                    sqlWhere += " and BookingDate <= '" + Func.FormatYYYYmmdd(txtToDate.Text) + "'";
                }

                //string sql = " SELECT BookingId ,ContractNo ,ContractDate ,Name";
                //sql += " ,RentHourFrom ,RentMinuteFrom ,RentHourTo ,RentMinuteTo";
                //sql += " ,Rate ,LastPriceUSD ,LastPriceVND ,ServiceLastPriceUSD";
                //sql += " ,ServiceLastPriceVND ,PaidUSD ,PaidVND ,DeptUSD ,DeptVND";
                //sql += " FROM v_PaymentRoomBooking Where BuildingId = '" + buildingId + "' " + sqlWhere + " and CustomerId = '" + lblCustomerId.Text + "' and BookingId ='"+ hidId.Value +"'order by YearMonth";

                sql = " SELECT Count(*)";
                sql += " FROM v_PaymentRoomBooking Where BuildingId = '" + buildingId + "' " + sqlWhere;
                sql += sqlWhere;

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " Select BookingId,ContractNo,ContractDate,Name,RentHourFrom,RentMinuteFrom";
                sql += " ,RentHourTo,RentMinuteTo,Rate,LastPriceUSD,LastPriceVND,ServiceLastPriceUSD";
                sql += " ,ServiceLastPriceVND,PaidUSD,PaidVND,DeptUSD,DeptVND,BuildingId";
                sql += " ,CustomerId,CustomerName,[Status],dbo.fnDateTime(BookingDate) BookingDate, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM v_PaymentRoomBooking Where BuildingId = '" + buildingId + "' " + sqlWhere;
                sql += sqlWhere;

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
            else if (command.Equals("Detail"))
            {
                Response.Redirect("BD_MeetingRoomBookingConfirm.aspx?id=" + e.CommandArgument);
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
                    string BookingId = Func.ParseString(row["BookingId"]);
                    string CustomerName = Func.ParseString(row["CustomerName"]);
                    string ContractNo = Func.ParseString(row["ContractNo"]);
                    string ContractDate = Func.ParseString(row["BookingDate"]);
                    string Name = Func.ParseString(row["Name"]);
                    string RentHourFrom = Func.ParseString(row["RentHourFrom"]);
                    string RentMinuteFrom = Func.ParseString(row["RentMinuteFrom"]);
                    string RentHourTo = Func.ParseString(row["RentHourTo"]);
                    string RentMinuteTo = Func.ParseString(row["RentMinuteTo"]);
                    string Rate = Func.ParseString(row["Rate"]);
                    string LastPriceUSD = Func.ParseString(row["LastPriceUSD"]);
                    string LastPriceVND = Func.ParseString(row["LastPriceVND"]);
                    string ServiceLastPriceUSD = Func.ParseString(row["ServiceLastPriceUSD"]);
                    string ServiceLastPriceVND = Func.ParseString(row["ServiceLastPriceVND"]);
                    string PaidUSD = Func.ParseString(row["PaidUSD"]);
                    string PaidVND = Func.ParseString(row["PaidVND"]);
                    string DeptUSD = Func.ParseString(row["DeptUSD"]);
                    string DeptVND = Func.ParseString(row["DeptVND"]);

                    Func.SetGridTextValue(item, "ltrBookingId", BookingId);
                    Func.SetGridTextValue(item, "ltrCustomerName", CustomerName);
                    Func.SetGridTextValue(item, "ltrContractNo", ContractNo);
                    Func.SetGridTextValue(item, "ltrContractDate", ContractDate);
                    Func.SetGridTextValue(item, "ltrName", Name);
                    Func.SetGridTextValue(item, "ltrRentHourFrom", RentHourFrom);
                    Func.SetGridTextValue(item, "ltrRentMinuteFrom", RentMinuteFrom);
                    Func.SetGridTextValue(item, "ltrRentHourTo", RentHourTo);
                    Func.SetGridTextValue(item, "ltrRentMinuteTo", RentMinuteTo);
                    Func.SetGridTextValue(item, "ltrRate", Rate);
                    Func.SetGridTextValue(item, "ltrLastPriceUSD", LastPriceUSD);
                    Func.SetGridTextValue(item, "ltrLastPriceVND", LastPriceVND);
                    Func.SetGridTextValue(item, "ltrServiceLastPriceUSD", ServiceLastPriceUSD);
                    Func.SetGridTextValue(item, "ltrServiceLastPriceVND", ServiceLastPriceVND);
                    Func.SetGridTextValue(item, "ltrPaidUSD", PaidUSD);
                    Func.SetGridTextValue(item, "ltrPaidVND", PaidVND);
                    Func.SetGridTextValue(item, "ltrDeptUSD", DeptUSD);
                    Func.SetGridTextValue(item, "ltrDeptVND", DeptVND);

                    Button btnDetail = (Button)item.FindControl("btnDetail");
                    btnDetail.CommandArgument = BookingId;
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

    }
}
