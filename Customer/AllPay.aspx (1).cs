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

namespace Man.Customer
{
    public partial class AllPay : Man.PageBase
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
            ITransaction tran = factory.GetLoadObject(data, id);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (CustomerData)tran.Result;
                lblCustomerId.Text = data.CustomerId;
                txtName.Text = data.Name;
                txtContactName.Text = data.ContactName;

                ShowData();

                for (int i = 2010; i < 2050; i++)
                {
                    drpYear.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i), Func.ParseString(i)));
                }
                drpYear.Items.Add(new ListItem("", ""));
                drpYear.Text = "";
                //drpYear.Items.FindByValue(DateTime.Now.AddMonths(-1).ToString("yyyy")).Selected = true;

                for (int i = 1; i < 13; i++)
                {
                    drpMonth.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
                }
                drpMonth.Items.Add(new ListItem("", ""));
                drpMonth.Text = "";
                //drpMonth.Items.FindByValue(DateTime.Now.AddMonths(-1).ToString("MM")).Selected = true;
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
                using (SqlCommand cm = new SqlCommand("sp_PaymentDetailPaidMoney", con))
                {
                    try
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@BuildingId", Func.ParseString(Session["__BUILDINGID__"]));
                        cm.Parameters.AddWithValue("@CustomerId", lblCustomerId.Text);
                        cm.Parameters.AddWithValue("@YearMonth", yearmonth);

                        cm.Parameters.AddWithValue("@Type", type);
                        cm.Parameters.AddWithValue("@PaymentType", paymenttype);
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
            try
            {
                string buildingId = Func.ParseString(Session["__BUILDINGID__"]);
                Hashtable PaymentList = new Hashtable();
                string sqlWhere = "";
                if (!String.IsNullOrEmpty(drpMonth.SelectedValue) && String.IsNullOrEmpty(drpYear.SelectedValue))
                {
                    sqlWhere = " and YearMonth like '%" + drpMonth.SelectedValue + "'";
                }
                else if (String.IsNullOrEmpty(drpMonth.SelectedValue) && !String.IsNullOrEmpty(drpYear.SelectedValue))
                {
                    sqlWhere = " and YearMonth like '" + drpYear.SelectedValue + "%'";
                }
                if (!String.IsNullOrEmpty(drpMonth.SelectedValue) && !String.IsNullOrEmpty(drpYear.SelectedValue))
                {
                    sqlWhere = " and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";
                }
                string sql = "Select * from v_PaymentBillDetail Where BuildingId = '" + buildingId + "' " + sqlWhere + " and CustomerId = '" + lblCustomerId.Text + "' order by YearMonth";

                DataTable dt = DbHelper.GetDataTable(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    string CustomerId = dr["CustomerId"].ToString();
                    string YearMonth = dr["YearMonth"].ToString();
                    string key = CustomerId + "_" + YearMonth;
                    DeptInfo tmp;

                    if (!PaymentList.Contains(key))
                    {
                        tmp = new DeptInfo();
                        tmp.CustomerId = CustomerId;
                        //tmp.Customer = Func.ParseString(CusList[CustomerId]);
                        tmp.YearMonth = YearMonth;
                        PaymentList.Add(key, tmp);
                    }
                    string PaymentType = dr["PaymentType"].ToString();

                    double MoneyUSD = Func.ParseDouble(dr["MoneyUSD"]);
                    double MoneyVND = Func.ParseDouble(dr["MoneyVND"]);
                    double PaidUSD = Func.ParseDouble(dr["PaidUSD"]);
                    double PaidVND = Func.ParseDouble(dr["PaidVND"]);

                    tmp = (DeptInfo)PaymentList[key];
                    switch (PaymentType)
                    {
                        case "1":
                            tmp.RentUSD = MoneyUSD;
                            tmp.RentVND = MoneyVND;
                            tmp.RentPaidUSD = PaidUSD;
                            tmp.RentPaidVND = PaidVND;
                            break;
                        case "2":
                            tmp.ManagerUSD = MoneyUSD;
                            tmp.ManagerVND = MoneyVND;
                            tmp.ManagerPaidUSD = PaidUSD;
                            tmp.ManagerPaidVND = PaidVND;
                            break;
                        case "3":
                            tmp.ParkingUSD = MoneyUSD;
                            tmp.ParkingVND = MoneyVND;
                            tmp.ParkingPaidUSD = PaidUSD;
                            tmp.ParkingPaidVND = PaidVND;
                            break;
                        case "4":
                            tmp.ExtraUSD = MoneyUSD;
                            tmp.ExtraVND = MoneyVND;
                            tmp.ExtraPaidUSD = PaidUSD;
                            tmp.ExtraPaidVND = PaidVND;
                            break;
                        case "5":
                            tmp.ElecUSD = MoneyUSD;
                            tmp.ElecVND = MoneyVND;
                            tmp.ElecPaidUSD = PaidUSD;
                            tmp.ElecPaidVND = PaidVND;
                            break;
                        case "6":
                            tmp.WaterUSD = MoneyUSD;
                            tmp.WaterVND = MoneyVND;
                            tmp.WaterPaidUSD = PaidUSD;
                            tmp.WaterPaidVND = PaidVND;
                            break;
                        case "7":
                            tmp.ServiceUSD = MoneyUSD;
                            tmp.ServiceVND = MoneyVND;
                            tmp.ServicePaidUSD = PaidUSD;
                            tmp.ServicePaidVND = PaidVND;
                            break;
                        case "8":
                            tmp.BookingUSD = MoneyUSD;
                            tmp.BookingVND = MoneyVND;
                            tmp.BookingPaidUSD = PaidUSD;
                            tmp.BookingPaidVND = PaidVND;
                            break;
                        default:
                            break;
                    }
                }
                DataTable cusDeptInfo = new DataTable();
                cusDeptInfo.Columns.Add("YearMonth", Type.GetType("System.String"));
                cusDeptInfo.Columns.Add("RentUsd", Type.GetType("System.String"));
                cusDeptInfo.Columns.Add("RentVnd", Type.GetType("System.String"));
                cusDeptInfo.Columns.Add("ManagerUsd", Type.GetType("System.String"));
                cusDeptInfo.Columns.Add("ManagerVnd", Type.GetType("System.String"));
                cusDeptInfo.Columns.Add("ParkingUsd", Type.GetType("System.String"));
                cusDeptInfo.Columns.Add("ParkingVnd", Type.GetType("System.String"));
                cusDeptInfo.Columns.Add("ExtraTimeUsd", Type.GetType("System.String"));
                cusDeptInfo.Columns.Add("ExtraTimeVnd", Type.GetType("System.String"));
                cusDeptInfo.Columns.Add("ElecVnd", Type.GetType("System.String"));
                cusDeptInfo.Columns.Add("WaterVnd", Type.GetType("System.String"));
                cusDeptInfo.Columns.Add("ServiceUsd", Type.GetType("System.String"));
                cusDeptInfo.Columns.Add("ServiceVnd", Type.GetType("System.String"));


                foreach (DictionaryEntry tmp in PaymentList)
                {
                    string key = (string)tmp.Key;
                    DeptInfo dept = (DeptInfo)tmp.Value;

                    DataRow newRow = cusDeptInfo.NewRow();
                    newRow["YearMonth"] = dept.YearMonth;
                    newRow["RentUsd"] = dept.RentDeptUSD();
                    newRow["RentVnd"] = dept.RentDeptVND();
                    newRow["ManagerUsd"] = dept.ManagerDeptUSD();
                    newRow["ManagerVnd"] = dept.ManagerDeptVND();
                    newRow["ParkingUsd"] = dept.ParkingDeptUSD();
                    newRow["ParkingVnd"] = dept.ParkingDeptVND();
                    newRow["ExtraTimeUsd"] = dept.ExtraDeptUSD();
                    newRow["ExtraTimeVnd"] = dept.ExtraDeptVND();
                    newRow["ElecVnd"] = dept.ElecDeptVND();
                    newRow["WaterVnd"] = dept.WaterDeptVND();
                    newRow["ServiceUsd"] = dept.ServiceDeptUSD();
                    newRow["ServiceVnd"] = dept.ServiceDeptVND();

                    cusDeptInfo.Rows.Add(newRow);
                }
                rptList.DataSource = cusDeptInfo.DefaultView;
                rptList.DataBind();
                pager.Count = cusDeptInfo.Rows.Count;
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
            else if (command.Equals("RentUsdPaid"))
            {
                UpdateData("1", "usd", Func.ParseString(e.CommandArgument));
            }
            else if (command.Equals("RentVndPaid"))
            {
                UpdateData("1", "vnd", Func.ParseString(e.CommandArgument));
            }
            else if (command.Equals("ManagerUsdPaid"))
            {
                UpdateData("2", "usd", Func.ParseString(e.CommandArgument));
            }
            else if (command.Equals("ManagerVndPaid"))
            {
                UpdateData("2", "vnd", Func.ParseString(e.CommandArgument));
            }
            else if (command.Equals("ParkingUsdPaid"))
            {
                UpdateData("3", "usd", Func.ParseString(e.CommandArgument));
            }
            else if (command.Equals("ParkingVndPaid"))
            {
                UpdateData("3", "vnd", Func.ParseString(e.CommandArgument));
            }
            else if (command.Equals("ExtraTimeUsdPaid"))
            {
                UpdateData("4", "usd", Func.ParseString(e.CommandArgument));
            }
            else if (command.Equals("ExtraTimeVndPaid"))
            {
                UpdateData("4", "vnd", Func.ParseString(e.CommandArgument));
            }
            else if (command.Equals("ElecVndPaid"))
            {
                UpdateData("5", "vnd", Func.ParseString(e.CommandArgument));
            }
            else if (command.Equals("WaterVndPaid"))
            {
                UpdateData("6", "vnd", Func.ParseString(e.CommandArgument));
            }
            else if (command.Equals("ServiceUsdPaid"))
            {
                UpdateData("7", "usd", Func.ParseString(e.CommandArgument));
            }
            else if (command.Equals("ServiceVndPaid"))
            {
                UpdateData("7", "vnd", Func.ParseString(e.CommandArgument));
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

                    string YearMonth = Func.ParseString(row["YearMonth"]);
                    string RentUsd = Func.ParseString(row["RentUsd"]);
                    string RentVnd = Func.ParseString(row["RentVnd"]);
                    string ManagerUsd = Func.ParseString(row["ManagerUsd"]);
                    string ManagerVnd = Func.ParseString(row["ManagerVnd"]);
                    string ParkingUsd = Func.ParseString(row["ParkingUsd"]);
                    string ParkingVnd = Func.ParseString(row["ParkingVnd"]);
                    string ExtraTimeUsd = Func.ParseString(row["ExtraTimeUsd"]);
                    string ExtraTimeVnd = Func.ParseString(row["ExtraTimeVnd"]);
                    string ElecVnd = Func.ParseString(row["ElecVnd"]);
                    string WaterVnd = Func.ParseString(row["WaterVnd"]);
                    string ServiceUsd = Func.ParseString(row["ServiceUsd"]);
                    string ServiceVnd = Func.ParseString(row["ServiceVnd"]);

                    Func.SetGridTextValue(item, "ltrYearMonth", YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4));
                    Func.SetGridTextValue(item, "ltrRentUsd", Func.FormatNumber_New(RentUsd));
                    Func.SetGridTextValue(item, "ltrRentVnd", Func.FormatNumber_New(RentVnd));
                    Func.SetGridTextValue(item, "ltrManagerUsd", Func.FormatNumber_New(ManagerUsd));
                    Func.SetGridTextValue(item, "ltrManagerVnd", Func.FormatNumber_New(ManagerVnd));
                    Func.SetGridTextValue(item, "ltrParkingUsd", Func.FormatNumber_New(ParkingUsd));
                    Func.SetGridTextValue(item, "ltrParkingVnd", Func.FormatNumber_New(ParkingVnd));
                    Func.SetGridTextValue(item, "ltrExtraTimeUsd", Func.FormatNumber_New(ExtraTimeUsd));
                    Func.SetGridTextValue(item, "ltrExtraTimeVnd", Func.FormatNumber_New(ExtraTimeVnd));
                    Func.SetGridTextValue(item, "ltrElecVnd", Func.FormatNumber_New(ElecVnd));
                    Func.SetGridTextValue(item, "ltrWaterVnd", Func.FormatNumber_New(WaterVnd));
                    Func.SetGridTextValue(item, "ltrServiceUsd", Func.FormatNumber_New(ServiceUsd));
                    Func.SetGridTextValue(item, "ltrServiceVnd", Func.FormatNumber_New(ServiceVnd));

                    Button btnRentUsd = (Button)item.FindControl("btnRentUsd");
                    Button btnRentVnd = (Button)item.FindControl("btnRentVnd");
                    Button btnManagerUsd = (Button)item.FindControl("btnManagerUsd");
                    Button btnManagerVnd = (Button)item.FindControl("btnManagerVnd");
                    Button btnParkingUsd = (Button)item.FindControl("btnParkingUsd");
                    Button btnParkingVnd = (Button)item.FindControl("btnParkingVnd");
                    Button btnExtraTimeUsd = (Button)item.FindControl("btnExtraTimeUsd");
                    Button btnExtraTimeVnd = (Button)item.FindControl("btnExtraTimeVnd");
                    Button btnElecVnd = (Button)item.FindControl("btnElecVnd");
                    Button btnWaterVnd = (Button)item.FindControl("btnWaterVnd");
                    Button btnServiceUsd = (Button)item.FindControl("btnServiceUsd");
                    Button btnServiceVnd = (Button)item.FindControl("btnServiceVnd");

                    btnRentUsd.CommandArgument = YearMonth;
                    btnRentVnd.CommandArgument = YearMonth;
                    btnManagerUsd.CommandArgument = YearMonth;
                    btnManagerVnd.CommandArgument = YearMonth;
                    btnParkingUsd.CommandArgument = YearMonth;
                    btnParkingVnd.CommandArgument = YearMonth;
                    btnExtraTimeUsd.CommandArgument = YearMonth;
                    btnExtraTimeVnd.CommandArgument = YearMonth;
                    btnElecVnd.CommandArgument = YearMonth;
                    btnWaterVnd.CommandArgument = YearMonth;
                    btnServiceUsd.CommandArgument = YearMonth;
                    btnServiceVnd.CommandArgument = YearMonth;

                    if ("0".Equals(RentUsd)) { btnRentUsd.Visible = false; }
                    if ("0".Equals(RentVnd)) { btnRentVnd.Visible = false; }
                    if ("0".Equals(ManagerUsd)) { btnManagerUsd.Visible = false; }
                    if ("0".Equals(ManagerVnd)) { btnManagerVnd.Visible = false; }
                    if ("0".Equals(ParkingUsd)) { btnParkingUsd.Visible = false; }
                    if ("0".Equals(ParkingVnd)) { btnParkingVnd.Visible = false; }
                    if ("0".Equals(ExtraTimeUsd)) { btnExtraTimeUsd.Visible = false; }
                    if ("0".Equals(ExtraTimeVnd)) { btnExtraTimeVnd.Visible = false; }
                    if ("0".Equals(ElecVnd)) { btnElecVnd.Visible = false; }
                    if ("0".Equals(WaterVnd)) { btnWaterVnd.Visible = false; }
                    if ("0".Equals(ServiceUsd)) { btnServiceUsd.Visible = false; }
                    if ("0".Equals(ServiceVnd)) { btnServiceVnd.Visible = false; }
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
        public class DeptInfo
        {
            public string CustomerId
            {
                get;
                set;
            }

            public string Customer
            {
                get;
                set;
            }

            public double RentUSD
            {
                get;
                set;
            }
            public double RentVND
            {
                get;
                set;

            }

            public double ManagerUSD
            {
                get;
                set;

            }
            public double ManagerVND
            {
                get;
                set;

            }

            public double ElecUSD
            {
                get;
                set;

            }
            public double ElecVND
            {
                get;
                set;

            }

            public double WaterUSD
            {
                get;
                set;

            }
            public double WaterVND
            {
                get;
                set;

            }

            public double ParkingUSD
            {
                get;
                set;

            }
            public double ParkingVND
            {
                get;
                set;

            }

            public double ExtraUSD
            {
                get;
                set;

            }
            public double ExtraVND
            {
                get;
                set;

            }

            public double ServiceUSD
            {
                get;
                set;

            }
            public double ServiceVND
            {
                get;
                set;

            }
            public double RentPaidUSD
            {
                get;
                set;

            }
            public double RentPaidVND
            {
                get;
                set;
            }

            public double ManagerPaidUSD
            {
                get;
                set;
            }
            public double ManagerPaidVND
            {
                get;
                set;
            }

            public double ElecPaidUSD
            {
                get;
                set;
            }
            public double ElecPaidVND
            {
                get;
                set;
            }

            public double WaterPaidUSD
            {
                get;
                set;
            }
            public double WaterPaidVND
            {
                get;
                set;
            }

            public double ParkingPaidUSD
            {
                get;
                set;
            }
            public double ParkingPaidVND
            {
                get;
                set;
            }

            public double ExtraPaidUSD
            {
                get;
                set;
            }
            public double ExtraPaidVND
            {
                get;
                set;
            }

            public double ServicePaidUSD
            {
                get;
                set;
            }
            public double ServicePaidVND
            {
                get;
                set;
            }


            public double BookingPaidUSD
            {
                get;
                set;

            }
            public double BookingUSD
            {
                get;
                set;

            }
            public double BookingVND
            {
                get;
                set;

            }
            public double BookingPaidVND
            {
                get;
                set;
            }
            public string YearMonth
            {
                get;
                set;
            }
            // Default constructor:
            public DeptInfo()
            {
            }

            public double RentDeptUSD()
            {
                return this.RentUSD - this.RentPaidUSD;
            }
            public double RentDeptVND()
            {
                return this.RentVND - this.RentPaidVND;
            }

            public double ManagerDeptUSD()
            {
                return this.ManagerUSD - this.ManagerPaidUSD;
            }
            public double ManagerDeptVND()
            {
                return this.ManagerVND - this.ManagerPaidVND;
            }

            public double ElecDeptUSD()
            {
                return this.ElecUSD - this.ElecPaidUSD;
            }
            public double ElecDeptVND()
            {
                return this.ElecVND - this.ElecPaidVND;
            }

            public double WaterDeptUSD()
            {
                return this.WaterUSD - this.WaterPaidUSD;
            }
            public double WaterDeptVND()
            {
                return this.WaterVND - this.WaterPaidVND;
            }

            public double ParkingDeptUSD()
            {
                return this.ParkingUSD - this.ParkingPaidUSD;
            }
            public double ParkingDeptVND()
            {
                return this.ParkingVND - this.ParkingPaidVND;
            }

            public double ExtraDeptUSD()
            {
                return this.ExtraUSD - this.ExtraPaidUSD;
            }
            public double ExtraDeptVND()
            {
                return this.ExtraVND - this.ExtraPaidVND;
            }

            public double ServiceDeptUSD()
            {
                return this.ServiceUSD - this.ServicePaidUSD;
            }
            public double ServiceDeptVND()
            {
                return this.ServiceVND - this.ServicePaidVND;
            }


            public double BookingDeptUSD()
            {
                return this.BookingUSD - this.BookingPaidUSD;
            }
            public double BookingDeptVND()
            {
                return this.BookingVND - this.BookingPaidVND;
            }

            public double SumUSD()
            {
                return this.RentUSD + this.ManagerUSD + this.ParkingUSD + this.ElecUSD + this.WaterUSD + this.ExtraUSD + this.ServiceUSD + this.BookingUSD;
            }
            public double SumVND()
            {
                return this.RentVND + this.ManagerVND + this.ParkingVND + this.ElecVND + this.WaterVND + this.ExtraVND + this.ServiceVND + this.BookingVND;
            }

            public double SumPaidUSD()
            {
                return this.RentPaidUSD + this.ManagerPaidUSD + this.ParkingPaidUSD + this.ElecPaidUSD + this.WaterPaidUSD + this.ExtraPaidUSD + this.ServicePaidUSD + this.BookingPaidUSD;
            }
            public double SumPaidVND()
            {
                return this.RentPaidVND + this.ManagerPaidVND + this.ParkingPaidVND + this.ElecPaidVND + this.WaterPaidVND + this.ExtraPaidVND + this.ServicePaidVND + this.BookingPaidVND;
            }
        }
    }
}
