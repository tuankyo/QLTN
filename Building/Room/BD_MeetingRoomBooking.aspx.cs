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

namespace Man.Building.Room
{
    public partial class BD_MeetingRoomBooking : PageBase
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

        private string popup = "PopupBD_RoomEdit";
        private string editPageName = "../Customer/CustomerEdit";
        private string editServicePageName = "BD_RoomBookingService";
        private string editConfirmPageName = "BD_MeetingRoomBookingConfirm";

        private string addSuccess = "Đã Đặt Phòng Thành Công";
        private string addUnSuccess = "Đặt Phòng Không Thành Công";

        private string deleteSuccess = "Hủy Thành Công";
        private string deleteUnSuccess = "Hủy Không Thành Công";

        private string title = "Biểu Phí Tiền Nước";
        private string postback = "window.opener.__doPostBack('PopupBD_RoomEdit','');";
        private string key = "openBD_RoomEdit";

        /// <summary>
        /// List data
        /// </summary>
        private void ShowData()
        {
            SqlDatabase db = new SqlDatabase();
            string sql = string.Empty;
            if (!Func.IsValid(ListSortExpression))
            {
                ListSortExpression = "A.BookingHourFrom";
                ListSortDirection = SortDirection.Descending;
            }
            try
            {
                string sqlWhere = "";
                if (!String.IsNullOrEmpty(txtBookingDate.Text.Trim()))
                {
                    sqlWhere = "and BookingDate = '" + Func.FormatYYYYmmdd(txtBookingDate.Text.Trim()) + "'";
                }

                //Đếm số lượng record
                sql += " Select COUNT(ID) ";
                sql += " FROM BD_RoomBooking A";
                sql += " Where Status in ('0','1') and DelFlag = 0 and RoomId = '" + drpMeetingRoom.SelectedValue + "'" + sqlWhere;

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " Select A.*, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM BD_RoomBooking A";
                sql += " Where Status in ('0','1') and DelFlag = 0 and RoomId = '" + drpMeetingRoom.SelectedValue + "'" + sqlWhere;

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

        private bool checkData()
        {
            mvMessage.CheckRequired(drpCustomerId, "Khách hàng: là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtBookingDate, "Ngày đặt: là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtPriceUSD, "Phí thuê (USD): là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtPriceVND, "Phí thuê (VND): là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtVAT, "VAT: là Danh mục bắt bắt buộc nhập");

            if (!mvMessage.IsValid) return false;

            double priceVND = Func.ParseDouble(txtPriceVND.Text);
            float priceUSD = Func.ParseFloat(txtPriceUSD.Text);

            if (priceUSD != 0 && priceVND != 0)
            {
                mvMessage.AddError("Phí thuê không được nhập USD và VND đồng thời > 0, một trong 2 giá trị phải bằng không");
                return false;
            }
            return true;
        }


        /// <summary>
        /// Init values
        /// </summary>
        private void ViewBookingTime()
        {
            try
            {
                Hashtable tmp = new Hashtable();
                for (int i = 0; i < 24; i++)
                {
                    drpHourFrom.Items.Add(new ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
                    drpHourTo.Items.Add(new ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
                }
                drpHourFrom.Items.FindByValue(DateTime.Now.AddHours(-1).ToString("HH")).Selected = true;
                drpHourTo.Items.FindByValue(DateTime.Now.AddHours(1).ToString("HH")).Selected = true;

                if (!String.IsNullOrEmpty(txtBookingDate.Text.Trim()))
                {

                    DataSet ds = new DataSet();
                    string sql = string.Empty;

                    sql = " SELECT *";
                    sql += " FROM BD_RoomBooking ";
                    sql += " Where Status in ('0','1') and DelFlag <> 1 and RoomId = '" + drpMeetingRoom.SelectedValue + "' and BookingDate = '" + Func.FormatYYYYmmdd(txtBookingDate.Text.Trim()) + "' Order By BookingHourFrom";

                    using (SqlDatabase db = new SqlDatabase())
                    {
                        using (SqlCommand cm = db.CreateCommand(sql))
                        {
                            SqlDataAdapter da = new SqlDataAdapter(cm);
                            da.Fill(ds);
                            db.Close();

                            if (ds != null)
                            {
                                DataTable dt = ds.Tables[0];
                                foreach (DataRow rowType in dt.Rows)
                                {
                                    int id = Func.ParseInt(rowType["Id"].ToString());
                                    float BookingHourFrom = Func.ParseFloat(rowType["BookingHourFrom"].ToString() + "00");
                                    float BookingMinuteFrom = Func.ParseFloat(rowType["BookingMinuteFrom"].ToString());
                                    float BookingHourTo = Func.ParseFloat(rowType["BookingHourTo"].ToString() + "00");
                                    float BookingMinuteTo = Func.ParseFloat(rowType["BookingMinuteTo"].ToString());
                                    BookingRoomInfo bkf = new BookingRoomInfo(BookingHourFrom, BookingMinuteFrom, BookingHourTo, BookingMinuteTo);
                                    tmp.Add(id, bkf);
                                }
                            }
                        }
                    }

                    int tblRows = 3;
                    int tblCols = 16;
                    // Create a Table and set its properties 
                    Table tbl = new Table();
                    // Add the table to the placeholder control
                    PlaceHolder1.Controls.Add(tbl);
                    // Now iterate through the table and add your controls 
                    for (int i = 0; i < tblRows; i++)
                    {
                        TableRow tr = new TableRow();
                        for (int j = 0; j < tblCols; j++)
                        {
                            TableCell tc = new TableCell();
                            TextBox txtBox = new TextBox();
                            txtBox.Width = 50;
                            string minute = j % 2 == 0 ? "00" : "30";
                            txtBox.BackColor = System.Drawing.Color.LightBlue;
                            string hour = (i * 8 + j / 2) + "00";
                            int hourOdd = Func.ParseInt(hour) + Func.ParseInt(minute);
                            foreach (int key in tmp.Keys)
                            {
                                BookingRoomInfo bkf = (BookingRoomInfo)tmp[key];
                                if (bkf.checkBooked(hourOdd))
                                {
                                    txtBox.BackColor = System.Drawing.Color.Red;
                                    break;
                                }
                            }
                            txtBox.Text = (minute == "00" ? (i * 8 + j / 2) + ":00" : (i * 8 + j / 2) + ":" + minute);
                            tc.Controls.Add(txtBox);
                            tr.Cells.Add(tc);
                        }
                        // Add the TableRow to the Table
                        tbl.Rows.Add(tr);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            //return tmp;
        }
        protected override void DoInit()
        {
            //try
            //{
            //    Hashtable tmp = new Hashtable();
            //    for (int i = 0; i < 24; i++)
            //    {
            //        drpHourFrom.Items.Add(new ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
            //        drpHourTo.Items.Add(new ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
            //    }
            //    drpHourFrom.Items.FindByValue(DateTime.Now.AddHours(-1).ToString("hh")).Selected = true;
            //    drpHourTo.Items.FindByValue(DateTime.Now.AddHours(1).ToString("hh")).Selected = true;

            //    if (!String.IsNullOrEmpty(txtBookingDate.Text.Trim()))
            //    {

            //        DataSet ds = new DataSet();
            //        string sql = string.Empty;

            //        sql = " SELECT *";
            //        sql += " FROM BD_RoomBooking ";
            //        sql += " Where Status in ('0','1') and DelFlag <> 1 and RoomId = '" + drpMeetingRoom.SelectedValue + "' and BookingDate = '" + Func.FormatYYYYmmdd(txtBookingDate.Text.Trim()) + "' Order By BookingHourFrom";

            //        using (SqlDatabase db = new SqlDatabase())
            //        {
            //            using (SqlCommand cm = db.CreateCommand(sql))
            //            {
            //                SqlDataAdapter da = new SqlDataAdapter(cm);
            //                da.Fill(ds);
            //                db.Close();

            //                if (ds != null)
            //                {
            //                    DataTable dt = ds.Tables[0];
            //                    foreach (DataRow rowType in dt.Rows)
            //                    {
            //                        int id = Func.ParseInt(rowType["Id"].ToString());
            //                        float BookingHourFrom = Func.ParseFloat(rowType["BookingHourFrom"].ToString() + "00");
            //                        float BookingMinuteFrom = Func.ParseFloat(rowType["BookingMinuteFrom"].ToString());
            //                        float BookingHourTo = Func.ParseFloat(rowType["BookingHourTo"].ToString() + "00");
            //                        float BookingMinuteTo = Func.ParseFloat(rowType["BookingMinuteTo"].ToString());
            //                        BookingRoomInfo bkf = new BookingRoomInfo(BookingHourFrom, BookingMinuteFrom, BookingHourTo, BookingMinuteTo);
            //                        tmp.Add(id, bkf);
            //                    }
            //                }
            //            }
            //        }

            //        int tblRows = 3;
            //        int tblCols = 16;
            //        // Create a Table and set its properties 
            //        Table tbl = new Table();
            //        // Add the table to the placeholder control
            //        PlaceHolder1.Controls.Add(tbl);
            //        // Now iterate through the table and add your controls 
            //        for (int i = 0; i < tblRows; i++)
            //        {
            //            TableRow tr = new TableRow();
            //            for (int j = 0; j < tblCols; j++)
            //            {
            //                TableCell tc = new TableCell();
            //                TextBox txtBox = new TextBox();
            //                txtBox.Width = 50;
            //                string minute = j % 2 == 0 ? "00" : "30";
            //                txtBox.BackColor = System.Drawing.Color.LightBlue;
            //                string hour = (i * 8 + j / 2) + "00";
            //                int hourOdd = Func.ParseInt(hour) + Func.ParseInt(minute);
            //                foreach (int key in tmp.Keys)
            //                {
            //                    BookingRoomInfo bkf = (BookingRoomInfo)tmp[key];
            //                    if (bkf.checkBooked(hourOdd))
            //                    {
            //                        txtBox.BackColor = System.Drawing.Color.Red;
            //                        break;
            //                    }
            //                }
            //                txtBox.Text = (minute == "00" ? (i * 8 + j / 2) + ":00" : (i * 8 + j / 2) + ":" + minute);
            //                tc.Controls.Add(txtBox);
            //                tr.Cells.Add(tc);
            //            }
            //            // Add the TableRow to the Table
            //            tbl.Rows.Add(tr);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.Write(ex);
            //}
            ////return tmp;
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
                hidId.Value = Func.ParseString(Request["id"]);
                txtBookingDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                DbHelper.FillListSearch(drpCustomerId, "SELECT CustomerId,CustomerId + '-' + Name as Name  FROM Customer Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "Name", "CustomerId");
                drpCustomerId.SelectedValue = hidId.Value;

                DbHelper.FillList(drpMeetingRoom, "SELECT Id,Name FROM BD_Room Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and IsMeetingRoom = '1'", "Name", "Id");

                ViewBookingTime();
                ShowData();

                BD_RoomData data = new BD_RoomData();
                ITransaction tran = factory.GetLoadObject(data, drpMeetingRoom.SelectedValue);
                Execute(tran);
                if (!HasError)
                {
                    //Get Data
                    data = (BD_RoomData)tran.Result;
                    //lblName.Text = data.Name;
                    lblComment.Text = data.Comment;

                    lblRegional.Text = data.Regional;
                    lblFloor.Text = data.Floor;
                    lblArea.Text = data.Area;

                    lblHourRentPriceVND.Text = data.HourRentPriceVND;
                    lblHourRentPriceUSD.Text = data.HourRentPriceUSD;

                    txtPriceVND.Text = data.HourRentPriceVND;
                    txtPriceUSD.Text = data.HourRentPriceUSD;
                    txtVAT.Text = data.Vat;
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
            else if (command.Equals("Delete"))
            {
                BD_RoomBookingData data = new BD_RoomBookingData();
                ITransaction tran = factory.GetLoadObject(data, Func.ParseString(e.CommandArgument));
                Execute(tran);
                if (!HasError)
                {
                    //Get Data
                    data = (BD_RoomBookingData)tran.Result;
                    data.DelFlag = "1";
                    data.PriceUSD = data.PriceUSD.Replace(",", ".");
                    data.PriceVND = data.PriceVND.Replace(",", ".");

                    data.VAT = data.VAT.Replace(",", ".");
                    data.OtherFee01 = data.OtherFee01.Replace(",", ".");
                    data.OtherFee02 = data.OtherFee02.Replace(",", ".");
                    data.Hour = data.Hour.Replace(",", ".");
                    data.HourExtraPriceUSD = data.HourExtraPriceUSD.Replace(",", ".");
                    data.HourExtraPriceVND = data.HourExtraPriceVND.Replace(",", ".");
                    tran = factory.GetUpdateObject(data);

                    Execute(tran);

                    if (!HasError)
                    {
                        OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, deleteSuccess, Page.User.Identity.Name);
                        mvMessage.SetCompleteMessage(deleteSuccess);

                        ViewBookingTime();
                        ShowData();
                    }
                    else
                    {
                        OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, deleteUnSuccess, Page.User.Identity.Name);
                        mvMessage.AddError(deleteUnSuccess);
                    }
                }
            }
            else if (command.Equals("Confirm"))
            {
                Response.Redirect(editConfirmPageName + ".aspx?id=" + e.CommandArgument);
            }
            else if (command.Equals("Delete"))
            {
                DeleteData("" + e.CommandArgument);
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void DeleteData(string id)
        {
            BD_RoomBookingData data = new BD_RoomBookingData();
            ITransaction tran = factory.GetLoadObject(data, id);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_RoomBookingData)tran.Result;
                data.PriceUSD = data.PriceUSD.Replace(",", ".");
                data.PriceVND = data.PriceVND.Replace(",", ".");

                data.VAT = data.VAT.Replace(",", ".");
                data.OtherFee01 = data.OtherFee01.Replace(",", ".");
                data.OtherFee02 = data.OtherFee02.Replace(",", ".");
                data.Hour = data.Hour.Replace(",", ".");
                data.HourExtraPriceUSD = data.HourExtraPriceUSD.Replace(",", ".");
                data.HourExtraPriceVND = data.HourExtraPriceVND.Replace(",", ".");
                tran = factory.GetUpdateObject(data);

                data.ModifiedBy = Page.User.Identity.Name;
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag = "1";

                tran = factory.GetUpdateObject(data);

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, deleteSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(deleteSuccess);
                    ViewBookingTime();
                    ShowData();
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, deleteUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(deleteUnSuccess);
                }
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
                    string CustomerId = Func.ParseString(row["CustomerId"]);
                    string Comment = Func.ParseString(row["Comment"]);

                    string BookingDate = Func.ParseString(row["BookingDate"]);
                    string BookingHourFrom = Func.ParseString(row["BookingHourFrom"]);
                    string BookingHourTo = Func.ParseString(row["BookingHourTo"]);
                    string BookingMinuteFrom = Func.ParseString(row["BookingMinuteFrom"]);
                    string BookingMinuteTo = Func.ParseString(row["BookingMinuteTo"]);
                    string PriceVND = Func.ParseString(row["PriceVND"]);
                    string PriceUSD = Func.ParseString(row["PriceUSD"]);
                    string VAT = Func.ParseString(row["VAT"]);


                    float hour = Func.ParseInt(BookingHourTo) - Func.ParseInt(BookingHourFrom);
                    int hourOdd = Func.ParseInt(BookingMinuteTo) - Func.ParseInt(BookingMinuteFrom);
                    if (hourOdd < 0)
                    {
                        hour--;
                    }
                    else
                    {
                        hour += Func.ParseFloat(hourOdd) / 60;
                    }

                    Func.SetGridLinkValue(item, "btnCustomer", CustomerId);
                    Func.SetGridTextValue(item, "ltrBookingDate", Func.FormatDMY(BookingDate));
                    Func.SetGridTextValue(item, "ltrBookingHourFrom", BookingHourFrom + ":" + ("".Equals(BookingMinuteFrom) ? "00" : BookingMinuteFrom));
                    Func.SetGridTextValue(item, "ltrBookingHourTo", BookingHourTo + ":" + ("".Equals(BookingMinuteTo) ? "00" : BookingMinuteTo));
                    Func.SetGridTextValue(item, "ltrPriceVND", Func.FormatNumber(Func.ParseDouble(PriceVND)));
                    Func.SetGridTextValue(item, "ltrPriceUSD", PriceUSD);
                    Func.SetGridTextValue(item, "ltrSumVND", Func.ParseString(Func.ParseFloat(PriceVND) * hour + Func.ParseFloat(PriceVND) * hour * Func.ParseFloat(VAT) / 100));
                    Func.SetGridTextValue(item, "ltrSumUSD", Func.ParseString(Func.ParseFloat(PriceUSD) * hour + Func.ParseFloat(PriceUSD) * hour * Func.ParseFloat(VAT) / 100));

                    Func.SetGridTextValue(item, "ltrComment", Comment);

                    PopupWidth = 600;
                    PopupHeight = 450;
                    LinkPopup((LinkButton)item.FindControl("btnCustomer"), editPageName + ".aspx?Action=Edit&Id=" + CustomerId);
                    ButtonPopup((Button)item.FindControl("btnService"), editServicePageName + ".aspx?Action=Edit&Id=" + ID);
                    Button btnConfirm = (Button)item.FindControl("btnConfirm");
                    btnConfirm.CommandArgument = ID;

                    Button btnDelete = (Button)item.FindControl("btnDelete");
                    btnDelete.CommandArgument = ID;

                    string ModifiedBy = Func.ParseString(row["ModifiedBy"].ToString().Trim());
                    string Modified = Func.ParseString(row["Modified"].ToString().Trim());
                    Func.SetGridTextValue(item, "ltrModifiedBy", ModifiedBy);
                    Func.SetGridTextValue(item, "ltrModified", Func.Formatdmyhms(Modified));

                    string Status = Func.ParseString(row["Status"]);
                    if ("0".Equals(Status))
                    {
                        //0 la dat
                        ((Button)item.FindControl("btnService")).Visible = true;
                        ((Button)item.FindControl("btnDelete")).Visible = true;
                    }
                    if ("1".Equals(Status))
                    {
                        ((Button)item.FindControl("btnService")).Visible = false;
                        ((Button)item.FindControl("btnDelete")).Visible = false;
                        //1 la dat hoàn thành
                        btnConfirm.Text = "Xem chi tiết";
                    }
                    //else if ("2".Equals(Status))
                    //{
                    //    //2 la huy
                    //    btnConfirm.Text = "Xem chi tiết";
                    //}
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

        protected void txtBookingDate_TextChanged(object sender, EventArgs e)
        {
            ViewBookingTime();
            ShowData();
        }
        protected void drpMeetingRoom_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ViewBookingTime();
            BD_RoomData data = new BD_RoomData();
            ITransaction tran = factory.GetLoadObject(data, drpMeetingRoom.SelectedValue);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_RoomData)tran.Result;
                //lblName.Text = data.Name;
                lblComment.Text = data.Comment;

                lblRegional.Text = data.Regional;
                lblFloor.Text = data.Floor;
                lblArea.Text = data.Area;

                lblHourRentPriceVND.Text = data.HourRentPriceVND;
                lblHourRentPriceUSD.Text = data.HourRentPriceUSD;

                txtPriceVND.Text = data.HourRentPriceVND;
                txtPriceUSD.Text = data.HourRentPriceUSD;
                txtVAT.Text = data.Vat;
            }
            ShowData();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!checkData()) return;

            int from = Func.ParseInt(drpHourFrom.SelectedValue + drpMinuteFrom.Value);
            int to = Func.ParseInt(drpHourTo.SelectedValue + drpMinuteTo.Value);

            //if (Func.ParseDate(txtBookingDate.Text).CompareTo(DateTime.Now) < 0)
            //{
            //    mvMessage.AddError("Ngày đặt phòng không hợp lệ");
            //    return;
            //}

            //if (from >= to)
            //{
            //    mvMessage.AddError("Thời gian đặt phòng không hợp lệ");
            //    return;
            //}

            //if (!mvMessage.IsValid) return;

            decimal hour = Func.ParseInt(drpHourTo.SelectedValue) - Func.ParseInt(drpHourFrom.SelectedValue);
            decimal hourOdd = Func.ParseInt(drpMinuteTo.Value) - Func.ParseInt(drpMinuteFrom.Value);
            if (hourOdd < 0)
            {
                hour--;
            }
            else
            {
                hour += Convert.ToDecimal(hourOdd) / 60;
            }
            if (hour <= 0)
            {
                mvMessage.AddError("Thời gian đặt phòng không hợp lệ");
            }
            if (!mvMessage.IsValid) return;

            //Get and Insert Data
            BD_RoomBookingData data = new BD_RoomBookingData();
            ITransaction tran = factory.GetInsertObject(data);

            data.Hour = Func.FormatNumber_New(hour).Replace(".", "").Replace(",", ".");

            data.CustomerId = drpCustomerId.SelectedValue;
            data.BookingDate = Func.FormatYYYYmmdd(txtBookingDate.Text.Trim());
            data.BookingHourFrom = drpHourFrom.SelectedValue;
            data.BookingHourTo = drpHourTo.SelectedValue;

            data.BookingMinuteFrom = drpMinuteFrom.Value;
            data.BookingMinuteTo = drpMinuteTo.Value;

            data.PriceVND = txtPriceVND.Text.Trim().Replace(',', '.');
            data.PriceUSD = txtPriceUSD.Text.Trim().Replace(',', '.');
            data.Comment = txtComment.Text.Trim();
            data.RoomId = drpMeetingRoom.SelectedValue;
            data.VAT = txtVAT.Text.Trim().Replace(',', '.');

            data.ModifiedBy = Page.User.Identity.Name;
            data.CreatedBy = Page.User.Identity.Name;
            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.DelFlag = "0";
            data.Status = "0";
            data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);

            data.BookingType = (chkBookingType.Checked == true ? "1" : "0");
            Execute(tran);

            if (!HasError)
            {
                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                mvMessage.SetCompleteMessage(addSuccess);
                ShowData();
            }
            else
            {
                OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                mvMessage.AddError(addUnSuccess);
            }
        }
    }
    class BookingRoomInfo
    {
        private float BookingHourFrom;
        private float BookingMinuteFrom;
        private float BookingHourTo;
        private float BookingMinuteTo;
        public BookingRoomInfo(float a, float b, float c, float d)
        {
            this.BookingHourFrom = a;
            this.BookingMinuteFrom = b;
            this.BookingHourTo = c;
            this.BookingMinuteTo = d;
        }
        public bool checkBooked(int a)
        {
            bool tmp = false;
            float from = BookingHourFrom + BookingMinuteFrom;
            float to = BookingHourTo + BookingMinuteTo;
            if (a >= from && a <= to)
            {
                return true;
            }
            return tmp;
        }
    }
}
