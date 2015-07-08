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
using Gnt.Utils.FastCsv;
using C1.C1Excel;
using System.IO;
using System.Drawing;

namespace Man.Customer
{
    public partial class CustomerList03 : PageBase
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

        private string popup = "PopupCustomerEdit";
        private string editPageName = "CustomerEdit";
        private string PaymentTermPage = "Paymentterm";
        private string BookingPage = "/Building/Room/BD_MeetingRoomBooking";
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
                string buildingId = Func.ParseString(Session["__BUILDINGID__"]);
                //Đếm số lượng record
                sql += " Select COUNT(*) ";
                sql += " FROM Customer A Left outer Join (SELECT COUNT(*) num,BuildingId,CustomerId ";
                sql += " FROM BD_RoomBooking ";
                sql += " where substring(BookingDate,0,7) = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "' and BuildingId = '" + buildingId + "'  and Status in ('0','1') and Delflag = 0 ";
                sql += " Group by CustomerId,BuildingId) B on A.CustomerId = B.CustomerId and A.BuildingId = B.BuildingId ";
                sql += " WHERE A.BuildingId = '" + buildingId + "'";
                sql += GetWhere();

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " Select A.*,B.num, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM Customer A Left outer Join (SELECT COUNT(*) num,BuildingId,CustomerId ";
                sql += " FROM BD_RoomBooking ";
                sql += " where substring(BookingDate,0,7) = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "' and BuildingId = '" + buildingId + "'  and Status in ('0','1') and Delflag = 0 ";
                sql += " Group by CustomerId,BuildingId) B on A.CustomerId = B.CustomerId and A.BuildingId = B.BuildingId ";
                sql += " WHERE A.BuildingId = '" + buildingId + "'";
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
                if (!IsPostBack)
                {
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
                }
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
            else if ("Booking".Equals(Func.ParseString(e.CommandName)))
            {
                Response.Redirect(BookingPage + ".aspx?id=" + e.CommandArgument);
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
                    string ID = Func.ParseString(row["CustomerId"]);
                    string Name = Func.ParseString(row["Name"]);
                    string Phone = Func.ParseString(row["Phone"]);
                    string Email = Func.ParseString(row["Email"]);
                    string ContactName = Func.ParseString(row["ContactName"]);
                    string Comment = Func.ParseString(row["Comment"]);
                    int num = Func.ParseInt(row["num"]);

                    Func.SetGridLinkValue(item, "btnEdit", ID);
                    Func.SetGridTextValue(item, "ltrName", Func.ToolTipByteLen(Name, 30));
                    Func.SetGridTextValue(item, "ltrPhone", Phone);
                    Func.SetGridTextValue(item, "ltrEmail", Email);
                    Func.SetGridTextValue(item, "ltrContactName", Func.ToolTipByteLen(ContactName, 20));
                    Func.SetGridTextValue(item, "ltrComment", Func.ToolTipByteLen(Comment, 20));

                    PopupWidth = 600;
                    PopupHeight = 450;
                    LinkPopup((LinkButton)item.FindControl("btnEdit"), editPageName + ".aspx?Action=Edit&Id=" + ID);

                    ((Button)item.FindControl("btnBooking")).CommandArgument = ID;
                    ((Button)item.FindControl("btnBooking01")).CommandArgument = ID;

                    string ModifiedBy = Func.ParseString(row["ModifiedBy"].ToString().Trim());
                    string Modified = Func.ParseString(row["Modified"].ToString().Trim());
                    Func.SetGridTextValue(item, "ltrModifiedBy", ModifiedBy);
                    Func.SetGridTextValue(item, "ltrModified", Func.Formatdmyhms(Modified));


                    Button btnBooking = (Button)item.FindControl("btnBooking");
                    Button btnBooking01 = (Button)item.FindControl("btnBooking01");

                    btnBooking.Visible = false;
                    btnBooking01.Visible = false;

                    if (num > 0)
                    {
                        btnBooking.Visible = true;
                    }
                    else 
                    {
                        btnBooking01.Visible = true;
                    }
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

            if (txtID.Text.Trim().Length != 0)
            {
                whereClause += " AND A.CustomerId LIKE '%" + txtID.Text.Trim() + "%'";
            }
            if (txtName.Text.Trim().Length != 0)
            {
                whereClause += " AND Name LIKE N'%" + txtName.Text.Trim() + "%'";
            }
            if (txtPhone.Text.Trim().Length != 0)
            {
                whereClause += " AND Phone LIKE '%" + txtPhone.Text.Trim() + "%'";
            }
            if (txtEmail.Text.Trim().Length != 0)
            {
                whereClause += " AND Email LIKE '%" + txtEmail.Text.Trim() + "%'";
            }
            if (txtContactName.Text.Trim().Length != 0)
            {
                whereClause += " AND ContactName LIKE N'%" + txtContactName.Text.Trim() + "%'";
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

    }
}
