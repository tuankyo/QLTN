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
    public partial class AllPayRoomBooking : Man.PageBase
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
            CustomerData data = new CustomerData();
            ITransaction tran = factory.GetLoadObject(data, hidCustomerId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (CustomerData)tran.Result;
                lblCustomerId.Text = data.CustomerId;
                txtName.Text = data.Name;
                txtContactName.Text = data.ContactName;

                ShowData();
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void UpdateData(string paymenttype, string type, string yearmonth)
        {
            mvMessage.CheckRequired(txtPaymenter, "Thu tiền từ: trường bắt buộc");
            mvMessage.CheckRequired(txtReceiver, "Người/Công ty nhận: trường bắt buộc");
            mvMessage.CheckRequired(txtPaymentDate, "Ngày thu: trường bắt buộc");
            mvMessage.CheckRequired(txtRateChange, "Tỉ giá: trường bắt buộc");

            if (!mvMessage.IsValid) return;

            using (SqlConnection con = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
            {
                con.Open();
                using (SqlCommand cm = new SqlCommand("sp_PaymentRoomBookingPaidMoney", con))
                {
                    try
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@BuildingId", Func.ParseString(Session["__BUILDINGID__"]));
                        cm.Parameters.AddWithValue("@CustomerId", lblCustomerId.Text);
                        cm.Parameters.AddWithValue("@YearMonth", yearmonth);

                        cm.Parameters.AddWithValue("@Type", type);
                        cm.Parameters.AddWithValue("@BookingId", hidId.Value);
                        cm.Parameters.AddWithValue("@Paymenter", txtPaymenter.Text);
                        cm.Parameters.AddWithValue("@Receiver", txtReceiver.Text);
                        cm.Parameters.AddWithValue("@RateChange", txtRateChange.Text);
                        cm.Parameters.AddWithValue("@PaymentDate", Func.FormatYYYYmmdd(txtPaymentDate.Text));

                        cm.Parameters.AddWithValue("@Created", DateTime.Now.ToString("yyyyMMddHHmmss"));
                        cm.Parameters.AddWithValue("@CreatedBy", Page.User.Identity.Name);
                        cm.Parameters.AddWithValue("@Modified", DateTime.Now.ToString("yyyyMMddHHmmss"));
                        cm.Parameters.AddWithValue("@ModifiedBy", Page.User.Identity.Name);

                        cm.CommandTimeout = 9999;

                        int ret = cm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        ApplicationLog.WriteError(ex);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                ShowData();
            }
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
            id = Request["id"];
            hidId.Value = id;
            hidCustomerId.Value = Request["CustomerId"];
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected override void DoPost()
        {

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            //mvMessage.CheckRequired(lblName, "* là Danh mục bắt bắt buộc nhập");
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
                //if (optDept.Checked)
                //{
                //    sqlWhere = " and (DeptUSD <> 0 or DeptVND <> 0)";
                //}
                //else if (optNoDept.Checked)
                //{
                //    sqlWhere = " and DeptUSD = 0 and DeptVND = 0";
                //}

                //string sql = " SELECT BookingId ,ContractNo ,ContractDate ,Name";
                //sql += " ,RentHourFrom ,RentMinuteFrom ,RentHourTo ,RentMinuteTo";
                //sql += " ,Rate ,LastPriceUSD ,LastPriceVND ,ServiceLastPriceUSD";
                //sql += " ,ServiceLastPriceVND ,PaidUSD ,PaidVND ,DeptUSD ,DeptVND";
                //sql += " FROM v_PaymentRoomBooking Where BuildingId = '" + buildingId + "' " + sqlWhere + " and CustomerId = '" + lblCustomerId.Text + "' and BookingId ='"+ hidId.Value +"'order by YearMonth";

                sql = " SELECT Count(*)";
                sql += " FROM v_PaymentRoomBooking Where BuildingId = '" + buildingId + "' " + sqlWhere + " and CustomerId = '" + lblCustomerId.Text + "' and BookingId ='" + hidId.Value + "'";
                sql += sqlWhere;

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " Select *, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM v_PaymentRoomBooking Where BuildingId = '" + buildingId + "' " + sqlWhere + " and CustomerId = '" + lblCustomerId.Text + "' and BookingId ='" + hidId.Value + "'";
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


                //DataTable dt = DbHelper.GetDataTable(sql);
                //foreach (DataRow dr in dt.Rows)
                //{
                //    string CustomerId = dr["CustomerId"].ToString();
                //    string YearMonth = dr["YearMonth"].ToString();
                //    string key = CustomerId + "_" + YearMonth;
                //    DeptInfo tmp;

                //    if (!PaymentList.Contains(key))
                //    {
                //        tmp = new DeptInfo();
                //        tmp.CustomerId = CustomerId;
                //        //tmp.Customer = Func.ParseString(CusList[CustomerId]);
                //        tmp.YearMonth = YearMonth;
                //        PaymentList.Add(key, tmp);
                //    }
                //    string PaymentType = dr["PaymentType"].ToString();

                //    double MoneyUSD = Func.ParseDouble(dr["MoneyUSD"]);
                //    double MoneyVND = Func.ParseDouble(dr["MoneyVND"]);
                //    double PaidUSD = Func.ParseDouble(dr["PaidUSD"]);
                //    double PaidVND = Func.ParseDouble(dr["PaidVND"]);

                //    tmp = (DeptInfo)PaymentList[key];
                //    switch (PaymentType)
                //    {
                //        case "1":
                //            tmp.RentUSD = MoneyUSD;
                //            tmp.RentVND = MoneyVND;
                //            tmp.RentPaidUSD = PaidUSD;
                //            tmp.RentPaidVND = PaidVND;
                //            break;
                //        case "2":
                //            tmp.ManagerUSD = MoneyUSD;
                //            tmp.ManagerVND = MoneyVND;
                //            tmp.ManagerPaidUSD = PaidUSD;
                //            tmp.ManagerPaidVND = PaidVND;
                //            break;
                //        case "3":
                //            tmp.ParkingUSD = MoneyUSD;
                //            tmp.ParkingVND = MoneyVND;
                //            tmp.ParkingPaidUSD = PaidUSD;
                //            tmp.ParkingPaidVND = PaidVND;
                //            break;
                //        case "4":
                //            tmp.ExtraUSD = MoneyUSD;
                //            tmp.ExtraVND = MoneyVND;
                //            tmp.ExtraPaidUSD = PaidUSD;
                //            tmp.ExtraPaidVND = PaidVND;
                //            break;
                //        case "5":
                //            tmp.ElecUSD = MoneyUSD;
                //            tmp.ElecVND = MoneyVND;
                //            tmp.ElecPaidUSD = PaidUSD;
                //            tmp.ElecPaidVND = PaidVND;
                //            break;
                //        case "6":
                //            tmp.WaterUSD = MoneyUSD;
                //            tmp.WaterVND = MoneyVND;
                //            tmp.WaterPaidUSD = PaidUSD;
                //            tmp.WaterPaidVND = PaidVND;
                //            break;
                //        case "7":
                //            tmp.ServiceUSD = MoneyUSD;
                //            tmp.ServiceVND = MoneyVND;
                //            tmp.ServicePaidUSD = PaidUSD;
                //            tmp.ServicePaidVND = PaidVND;
                //            break;
                //        case "8":
                //            tmp.BookingUSD = MoneyUSD;
                //            tmp.BookingVND = MoneyVND;
                //            tmp.BookingPaidUSD = PaidUSD;
                //            tmp.BookingPaidVND = PaidVND;
                //            break;
                //        default:
                //            break;
                //    }
                //}
                //DataTable cusDeptInfo = new DataTable();
                //cusDeptInfo.Columns.Add("YearMonth", Type.GetType("System.String"));
                //cusDeptInfo.Columns.Add("RentUsd", Type.GetType("System.String"));
                //cusDeptInfo.Columns.Add("RentVnd", Type.GetType("System.String"));
                //cusDeptInfo.Columns.Add("ManagerUsd", Type.GetType("System.String"));
                //cusDeptInfo.Columns.Add("ManagerVnd", Type.GetType("System.String"));
                //cusDeptInfo.Columns.Add("ParkingUsd", Type.GetType("System.String"));
                //cusDeptInfo.Columns.Add("ParkingVnd", Type.GetType("System.String"));
                //cusDeptInfo.Columns.Add("ExtraTimeUsd", Type.GetType("System.String"));
                //cusDeptInfo.Columns.Add("ExtraTimeVnd", Type.GetType("System.String"));
                //cusDeptInfo.Columns.Add("ElecVnd", Type.GetType("System.String"));
                //cusDeptInfo.Columns.Add("WaterVnd", Type.GetType("System.String"));
                //cusDeptInfo.Columns.Add("ServiceUsd", Type.GetType("System.String"));
                //cusDeptInfo.Columns.Add("ServiceVnd", Type.GetType("System.String"));


                //foreach (DictionaryEntry tmp in PaymentList)
                //{
                //    string key = (string)tmp.Key;
                //    DeptInfo dept = (DeptInfo)tmp.Value;

                //    DataRow newRow = cusDeptInfo.NewRow();
                //    newRow["YearMonth"] = dept.YearMonth;
                //    newRow["RentUsd"] = dept.RentDeptUSD();
                //    newRow["RentVnd"] = dept.RentDeptVND();
                //    newRow["ManagerUsd"] = dept.ManagerDeptUSD();
                //    newRow["ManagerVnd"] = dept.ManagerDeptVND();
                //    newRow["ParkingUsd"] = dept.ParkingDeptUSD();
                //    newRow["ParkingVnd"] = dept.ParkingDeptVND();
                //    newRow["ExtraTimeUsd"] = dept.ExtraDeptUSD();
                //    newRow["ExtraTimeVnd"] = dept.ExtraDeptVND();
                //    newRow["ElecVnd"] = dept.ElecDeptVND();
                //    newRow["WaterVnd"] = dept.WaterDeptVND();
                //    newRow["ServiceUsd"] = dept.ServiceDeptUSD();
                //    newRow["ServiceVnd"] = dept.ServiceDeptVND();

                //    cusDeptInfo.Rows.Add(newRow);
                //}
                //rptList.DataSource = cusDeptInfo.DefaultView;
                //rptList.DataBind();
                //pager.Count = cusDeptInfo.Rows.Count;
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
            else if (command.Equals("DeptUsdPaid"))
            {
                UpdateData("1", "usd", Func.ParseString(e.CommandArgument));
            }
            else if (command.Equals("DeptVndPaid"))
            {
                UpdateData("1", "vnd", Func.ParseString(e.CommandArgument));
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
                    string ContractNo = Func.ParseString(row["ContractNo"]);
                    string ContractDate = Func.ParseString(row["ContractDate"]);
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

                    Button btnDeptUsd = (Button)item.FindControl("btnServiceUsd");
                    Button btnDeptVnd = (Button)item.FindControl("btnServiceVnd");

                    btnDeptUsd.CommandArgument = BookingId;
                    btnDeptVnd.CommandArgument = BookingId;

                    if ("0".Equals(DeptUSD)) { btnDeptUsd.Visible = false; }
                    if ("0".Equals(DeptVND)) { btnDeptUsd.Visible = false; }
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
