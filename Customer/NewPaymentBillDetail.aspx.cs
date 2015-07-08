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
using C1.C1Excel;
using System.Drawing;
using System.IO;

namespace Man.Customer
{
    public partial class NewPaymentBillDetail : PageBase
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

        private string popup = "PopupBillInfo";
        private string addSuccess = "Đã lưu thông tin thành công";
        private string addUnSuccess = "Lưu thông tin không thành công";
        private C1XLBook xlbBook = new C1XLBook();
        private XLSheet xlsSheet = null;
        private XLSheet xlsSheetEn = null;

        protected void btnReCal_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
            {
                con.Open();
                using (SqlCommand cm = new SqlCommand("sp_PaymentDetailOneCustomer", con))
                {
                    try
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@BuildingId", Func.ParseString(Session["__BUILDINGID__"]));
                        cm.Parameters.AddWithValue("@CustomerId", lblCustomerId.Text);
                        cm.Parameters.AddWithValue("@YearMonth", drpYear.SelectedValue + drpMonth.SelectedValue);
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
            }

            foreach (ListItem lstItem in lstSelectedYearMonth.Items)
            {
                if (String.Compare(DateTime.Now.ToString("yyyyMMdd"), lstItem.Value) < 0)
                {
                    using (SqlConnection con = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand cm = new SqlCommand("sp_PaymentDetailOneCustomerRentManager", con))
                        {
                            try
                            {
                                cm.CommandType = CommandType.StoredProcedure;
                                cm.Parameters.AddWithValue("@BuildingId", Func.ParseString(Session["__BUILDINGID__"]));
                                cm.Parameters.AddWithValue("@CustomerId", lblCustomerId.Text);
                                cm.Parameters.AddWithValue("@YearMonth", lstItem.Value);
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
                    }
                }
            }
            ShowData();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string id = "";
            string yearmonth = drpYear.SelectedValue + drpMonth.SelectedValue;
            hidBillId.Value = DbHelper.GetScalar("Select id from PaymentBillInfo where customerid = '" + hidId.Value + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "' and BuildingId= '" + Func.ParseString(Session["__BUILDINGID__"]) + "'");

            if (!(yearmonth.Equals(DateTime.Now.ToString("yyyyMM")) || yearmonth.Equals((DateTime.Now.AddMonths(-1).ToString("yyyyMM")))))
            {
                mvMessage.AddError("Chỉ thực hiện được trong tháng hoặc tháng trước");
                return;
            }

            mvMessage.CheckRequired(txtBillDate, "Ngày xuất Hóa đơn là danh mục bắt buộc");
            mvMessage.CheckRequired(txtBillNo, "Số Hóa đơn là danh mục bắt buộc");
            mvMessage.CheckRequired(txtUsdExchange, "Tỉ giá USD-VN là danh mục bắt buộc");
            mvMessage.CheckRequired(txtUsdExchangeDate, "Ngày tỉ giá là danh mục bắt buộc");

            string lsYearmonth = "";
            foreach (ListItem lstItem in lstSelectedYearMonth.Items)
            {
                lsYearmonth += ",'" + lstItem.Value + "'";
            }
            if (String.IsNullOrEmpty(lsYearmonth))
            {
                mvMessage.AddError("Phải chọn ít nhất 1 tháng");
                return;
            }
            lsYearmonth = lsYearmonth.Substring(1) + ",'" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";

            if (!mvMessage.IsValid) return;

            if (String.IsNullOrEmpty(hidBillId.Value))
            {
                //Get and Insert Data
                PaymentBillInfoData data = new PaymentBillInfoData();
                ITransaction tran = factory.GetInsertObject(data);
                data.ModifiedBy = Page.User.Identity.Name;
                data.CreatedBy = Page.User.Identity.Name;
                data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag = "0";

                data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);
                data.CustomerId = lblCustomerId.Text.Trim();
                data.YearMonth = drpYear.SelectedValue + drpMonth.SelectedValue;
                data.BillDate = Func.FormatYYYYmmdd(txtBillDate.Text.Trim());
                data.BillNo = txtBillNo.Text.Trim();
                data.UsdExchangeDate = Func.FormatYYYYmmdd(txtUsdExchangeDate.Text.Trim());
                data.UsdExchange = txtUsdExchange.Text.Trim();
                data.YearMonths = lsYearmonth;

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(addSuccess);
                    hidBillId.Value = data.id;
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(addUnSuccess);
                }
            }
            else
            {
                PaymentBillInfoData data = new PaymentBillInfoData();
                ITransaction tran = factory.GetLoadObject(data, hidBillId.Value);
                Execute(tran);
                if (!HasError)
                {
                    //Get Data
                    data = (PaymentBillInfoData)tran.Result;
                    data.ModifiedBy = Page.User.Identity.Name;
                    data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                    data.DelFlag = "0";
                    id = data.id;

                    data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);
                    data.BillDate = Func.FormatYYYYmmdd(txtBillDate.Text.Trim());
                    data.BillNo = txtBillNo.Text.Trim();
                    data.UsdExchangeDate = Func.FormatYYYYmmdd(Func.FormatYYYYmmdd(txtUsdExchangeDate.Text.Substring(0, 10)));
                    data.UsdExchange = txtUsdExchange.Text.Trim();
                    data.YearMonths = lsYearmonth;
                    tran = factory.GetUpdateObject(data);

                    Execute(tran);

                    if (!HasError)
                    {
                        OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, addSuccess, Page.User.Identity.Name);
                        mvMessage.SetCompleteMessage(addSuccess);
                    }
                    else
                    {
                        OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, addUnSuccess, Page.User.Identity.Name);
                        mvMessage.AddError(addUnSuccess);
                    }
                }
            }
            ShowData();
        }
        ///// <summary>
        ///// List data
        ///// </summary>
        //private void ShowData(string YearMonth)
        //{
        //    //divRent.Visible = true;
        //    //divManager.Visible = true;
        //    //divParking.Visible = true;
        //    //divService.Visible = true;
        //    //divWater.Visible = true;
        //    //divExtraTime.Visible = true;
        //    //divElec.Visible = true;

        //    hidBillId.Value = DbHelper.GetScalar("Select id from PaymentBillInfo where customerid = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "' and BuildingId= '" + Func.ParseString(Session["__BUILDINGID__"]) + "'");

        //    if (!String.IsNullOrEmpty(hidBillId.Value))
        //    {
        //        PaymentBillInfoData data = new PaymentBillInfoData();
        //        ITransaction tran = factory.GetLoadObject(data, hidBillId.Value);
        //        Execute(tran);
        //        if (!HasError)
        //        {
        //            data = (PaymentBillInfoData)tran.Result;

        //            txtBillNo.Text = data.BillNo;
        //            txtBillDate.Text = data.BillDate;
        //            txtUsdExchangeDate.Text = Func.FormatDMY(data.UsdExchangeDate);
        //            txtUsdExchange.Text = Func.ParseString(Func.ParseFloat(data.UsdExchange));
        //        }

        //        btnCreate.Text = "Tính lại tiền";
        //        //divDetail.Visible = true;
        //    }
        //    else
        //    {
        //        txtBillNo.Text = "";
        //        txtBillDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //        txtUsdExchangeDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //        txtUsdExchange.Text = "";

        //        btnCreate.Text = "Tạo Hóa Đơn";
        //        //divDetail.Visible = false;
        //    }

        //    SqlDatabase db = new SqlDatabase();
        //    string sql = string.Empty;
        //    if (!Func.IsValid(ListSortExpression))
        //    {
        //        ListSortExpression = "Name";
        //        ListSortDirection = SortDirection.Descending;
        //    }
        //    try
        //    {
        //        //Rent And Manager Price
        //        sql = string.Empty;
        //        string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

        //        //Xuất ra toàn bộ nội dung theo Trang
        //        sql += " Select *";
        //        sql += " FROM PaymentRoom";
        //        sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'";

        //        SqlCommand cm = db.CreateCommand(sql);
        //        SqlDataAdapter da = new SqlDataAdapter(cm);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds);
        //        db.Close();
        //        rptRoomRent.DataSource = ds.Tables[0].DefaultView;
        //        rptRoomRent.DataBind();

        //        rptRoomManager.DataSource = ds.Tables[0].DefaultView;
        //        rptRoomManager.DataBind();


        //        //Parking
        //        sql = string.Empty;
        //        sort = "TariffsParkingName" + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

        //        //Xuất ra toàn bộ nội dung theo Trang
        //        sql += " SELECT COUNT(*) AS Num, YearMonth, TariffsParkingName, PriceVND, PriceUSD, SUM(VatVND) AS VatVND,SUM(VatUSD) AS VatUSD, SUM(SumVND) AS SumVND, SUM(SumUSD) AS SumUSD, SUM(LastPriceVND) AS LastPriceVND";
        //        sql += "        , SUM(LastPriceUSD) AS LastPriceUSD";
        //        sql += " FROM         dbo.PaymentParking";
        //        sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'";
        //        sql += " GROUP BY YearMonth, TariffsParkingName, PriceVND, PriceUSD, Vat, daysParking";

        //        cm = db.CreateCommand(sql);
        //        da = new SqlDataAdapter(cm);
        //        ds = new DataSet();
        //        da.Fill(ds);
        //        db.Close();
        //        rptParking.DataSource = ds.Tables[0].DefaultView;
        //        rptParking.DataBind();

        //        //Extra Time
        //        sql = string.Empty;
        //        sort = "WorkingDate" + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

        //        //Xuất ra toàn bộ nội dung theo Trang
        //        sql += " SELECT * ";
        //        sql += " FROM   PaymentExtraTime";
        //        sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'";

        //        cm = db.CreateCommand(sql);
        //        da = new SqlDataAdapter(cm);
        //        ds = new DataSet();
        //        da.Fill(ds);
        //        db.Close();
        //        rptExtraTime.DataSource = ds.Tables[0].DefaultView;
        //        rptExtraTime.DataBind();

        //        //Elec
        //        ListSortDirection = SortDirection.Ascending;
        //        sql = string.Empty;
        //        sort = "B.FromIndex" + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

        //        //Xuất ra toàn bộ nội dung theo Trang
        //        sql += " SELECT BD_Room.Name as RoomName, A.DateFrom, A.DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVND, B.PriceUSD, B.SumVND, B.SumUSD, ";
        //        sql += "        B.VatVND, B.VatUSD, B.LastPriceVND, B.LastPriceUSD, B.Name,B.WaterPricePercent,B.ElecPricePercent ";
        //        sql += " FROM   PaymentElecWater AS A INNER JOIN ";
        //        sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId INNER JOIN";
        //        sql += "        BD_Room ON A.RoomId = BD_Room.id";
        //        sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfWaterId = 0  and A.YearMonth = '" + YearMonth + "'";
        //        sql += " Order by " + sort;


        //        cm = db.CreateCommand(sql);
        //        da = new SqlDataAdapter(cm);
        //        ds = new DataSet();
        //        da.Fill(ds);
        //        db.Close();
        //        rptElec.DataSource = ds.Tables[0].DefaultView;
        //        rptElec.DataBind();

        //        //Water
        //        sql = string.Empty;

        //        //Xuất ra toàn bộ nội dung theo Trang
        //        sql += " SELECT BD_Room.Name as RoomName, A.DateFrom, A.DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVND, B.PriceUSD, B.SumVND, B.SumUSD, ";
        //        sql += "        B.VatVND, B.VatUSD, B.LastPriceVND, B.LastPriceUSD, B.Name,B.WaterPricePercent,B.ElecPricePercent ";
        //        sql += " FROM   PaymentElecWater AS A INNER JOIN ";
        //        sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId INNER JOIN";
        //        sql += "        BD_Room ON A.RoomId = BD_Room.id";
        //        sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfElecId = 0 and A.YearMonth = '" + YearMonth + "'";
        //        sql += " Order by " + sort;

        //        cm = db.CreateCommand(sql);
        //        da = new SqlDataAdapter(cm);
        //        ds = new DataSet();
        //        da.Fill(ds);
        //        db.Close();
        //        rptWater.DataSource = ds.Tables[0].DefaultView;
        //        rptWater.DataBind();

        //        //Service
        //        sql = string.Empty;
        //        sort = "ServiceDate" + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

        //        //Xuất ra toàn bộ nội dung theo Trang
        //        sql += " SELECT * ";
        //        sql += " FROM   PaymentService";
        //        sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'";

        //        cm = db.CreateCommand(sql);
        //        da = new SqlDataAdapter(cm);
        //        ds = new DataSet();
        //        da.Fill(ds);
        //        db.Close();
        //        rptService.DataSource = ds.Tables[0].DefaultView;
        //        rptService.DataBind();

        //        //Dept
        //        sql = string.Empty;
        //        sort = "YearMonth" + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

        //        ////Parking
        //        //sql = string.Empty;
        //        //sql += " SELECT SUM(LastPriceVND) AS LastPriceVND, SUM(LastPriceUSD) AS LastPriceUSD";
        //        //sql += " FROM  PaymentParking";
        //        //sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'";
        //        //sql += " GROUP BY YearMonth, TariffsParkingName, PriceVND, PriceUSD, Vat";
        //        //dt = DbHelper.GetDataTable(sql);
        //        //if (dt.Rows.Count > 0) // Check if the DataTable returns any data from database
        //        //{
        //        //    lblParkingUSD.Text = dt.Rows[0][0].ToString(); // Where Fieldname is the name of fields from your database that you want to get
        //        //    lblParkingVND.Text =  Func.FormatNumber_New(dt.Rows[0][1].ToString(); // Where Fieldname is the name of fields from your database that you want to get
        //        //}
        //        ////Extra Time
        //        //sql = string.Empty;
        //        //sql += " SELECT SUM(LastPriceVND) AS LastPriceVND, SUM(LastPriceUSD) AS LastPriceUSD";
        //        //sql += " FROM   PaymentExtraTime";
        //        //sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'";
        //        //dt = DbHelper.GetDataTable(sql);
        //        //if (dt.Rows.Count > 0) // Check if the DataTable returns any data from database
        //        //{
        //        //    lblExtraTimeUSD.Text = dt.Rows[0][0].ToString(); // Where Fieldname is the name of fields from your database that you want to get
        //        //    lblExtraTimeVND.Text =  Func.FormatNumber_New(dt.Rows[0][1].ToString(); // Where Fieldname is the name of fields from your database that you want to get
        //        //}
        //        ////Elec
        //        //sql = string.Empty;
        //        //sql += " SELECT SUM(LastPriceVND) AS LastPriceVND, SUM(LastPriceUSD) AS LastPriceUSD";
        //        //sql += " FROM   PaymentElecWater";
        //        //sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and TarrifsOfWaterId = 0 and YearMonth = '" + YearMonth + "'";
        //        //dt = DbHelper.GetDataTable(sql);
        //        //if (dt.Rows.Count > 0) // Check if the DataTable returns any data from database
        //        //{
        //        //    lblElecUSD.Text = dt.Rows[0][0].ToString(); // Where Fieldname is the name of fields from your database that you want to get
        //        //    lblElecVND.Text =  Func.FormatNumber_New(dt.Rows[0][1].ToString(); // Where Fieldname is the name of fields from your database that you want to get
        //        //}
        //        ////Water
        //        //sql = string.Empty;
        //        //sql += " SELECT SUM(LastPriceVND) AS LastPriceVND, SUM(LastPriceUSD) AS LastPriceUSD";
        //        //sql += " FROM   PaymentElecWater ";
        //        //sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and TarrifsOfElecId = 0 and YearMonth = '" + YearMonth + "'";
        //        //dt = DbHelper.GetDataTable(sql);
        //        //if (dt.Rows.Count > 0) // Check if the DataTable returns any data from database
        //        //{
        //        //    lblWaterUSD.Text = dt.Rows[0][0].ToString(); // Where Fieldname is the name of fields from your database that you want to get
        //        //    lblWaterVND.Text =  Func.FormatNumber_New(dt.Rows[0][1].ToString(); // Where Fieldname is the name of fields from your database that you want to get
        //        //}
        //        ////Service
        //        //sql = string.Empty;
        //        //sql += " SELECT SUM(LastPriceVND) AS LastPriceVND, SUM(LastPriceUSD) AS LastPriceUSD";
        //        //sql += " FROM   PaymentService";
        //        //sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'";
        //        //dt = DbHelper.GetDataTable(sql);
        //        //if (dt.Rows.Count > 0) // Check if the DataTable returns any data from database
        //        //{
        //        //    lblServiceUSD.Text = dt.Rows[0][0].ToString(); // Where Fieldname is the name of fields from your database that you want to get
        //        //    lblServiceVND.Text =  Func.FormatNumber_New(dt.Rows[0][1].ToString(); // Where Fieldname is the name of fields from your database that you want to get
        //        //}
        //        ////Dept
        //        //sql = string.Empty;
        //        //sql += " SELECT sum(RemainRentUSD+RemainManagerUSD+RemainElecUSD+RemainWaterUSD+RemainServiceUSD+RemainParkingUSD+RemainExtraTimePriceUSD) as SumUSD,sum(RemainRentVND+RemainManagerVND+RemainElecVND+RemainWaterVND+RemainServiceVND+RemainParkingVND+RemainExtraTimePriceVND) AS SumVND ";
        //        //sql += " FROM   v_PaymentYearMonthDept";
        //        //sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' And";
        //        //sql += " (RemainRentUSD+RemainManagerUSD+RemainElecUSD+RemainWaterUSD+RemainServiceUSD+RemainParkingUSD+RemainExtraTimePriceUSD)>0 and YearMonth <> '" + YearMonth + "'";
        //        //dt = DbHelper.GetDataTable(sql);
        //        sql = "Select  *";
        //        sql += " From    PaymentBillDetail";
        //        sql += " Where   BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'";
        //        DataTable dt = DbHelper.GetDataTable(sql);
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            string PaymentType = Func.ParseString(dt.Rows[i]["PaymentType"]);
        //            string MoneyUSD = Func.ParseString(dt.Rows[i]["MoneyUSD"]);
        //            string MoneyVND = Func.ParseString(dt.Rows[i]["MoneyVND"]);
        //            string PaidUSD = Func.ParseString(dt.Rows[i]["PaidUSD"]);
        //            string PaidVND = Func.ParseString(dt.Rows[i]["PaidVND"]);
        //            string ExchangeType = Func.ParseString(dt.Rows[i]["ExchangeType"]);
        //            //string UsdExchange = Func.ParseString(dt.Rows[i]["UsdExchange"]);

        //            decimal tmpUSD = Convert.ToDecimal(MoneyUSD) - Convert.ToDecimal(PaidUSD);
        //            decimal tmpVND = Convert.ToDecimal(MoneyVND) - Convert.ToDecimal(PaidVND);

        //            switch (PaymentType)
        //            {
        //                case "1":
        //                    //Rent
        //                    lblRentUSD.Text = Func.FormatNumber_New(MoneyUSD); // Where Fieldname is the name of fields from your database that you want to get
        //                    lblRentVND.Text = Func.FormatNumber_New(MoneyVND); // Where Fieldname is the name of fields from your database that you want to get

        //                    lblRentPaidUSD.Text = Func.FormatNumber_New(PaidUSD); // Where Fieldname is the name of fields from your database that you want to get
        //                    lblRentPaidVND.Text = Func.FormatNumber_New(PaidVND); // Where Fieldname is the name of fields from your database that you want to get

        //                    txtRentPaidUSD.Text = Func.FormatNumber_New(tmpUSD);
        //                    txtRentPaidVND.Text = Func.FormatNumber_New(tmpVND);

        //                    if (tmpUSD > 0)
        //                    {
        //                        txtRentPaidUSD.Text = Func.FormatNumber_New(tmpUSD);
        //                    }
        //                    if (tmpVND > 0)
        //                    {
        //                        txtRentPaidVND.Text = Func.FormatNumber_New(tmpVND);
        //                    }
        //                    break;
        //                case "2":
        //                    //Manager
        //                    lblMangagerUSD.Text = Func.FormatNumber_New(MoneyUSD); // Where Fieldname is the name of fields from your database that you want to get
        //                    lblMangagerVND.Text = Func.FormatNumber_New(MoneyVND); // Where Fieldname is the name of fields from your database that you want to get

        //                    lblMangagerPaidUSD.Text = Func.FormatNumber_New(PaidUSD); // Where Fieldname is the name of fields from your database that you want to get
        //                    lblMangagerPaidVND.Text = Func.FormatNumber_New(PaidVND); // Where Fieldname is the name of fields from your database that you want to get

        //                    txtManagerPaidUSD.Text = Func.FormatNumber_New(tmpUSD);
        //                    txtManagerPaidVND.Text = Func.FormatNumber_New(tmpVND);

        //                    if (tmpUSD > 0)
        //                    {
        //                        txtManagerPaidUSD.Text = Func.FormatNumber_New(tmpUSD);
        //                    }
        //                    if (tmpVND > 0)
        //                    {
        //                        txtManagerPaidVND.Text = Func.FormatNumber_New(tmpVND);
        //                    }

        //                    break;
        //                case "3":
        //                    //Parking
        //                    lblParkingUSD.Text = Func.FormatNumber_New(MoneyUSD); // Where Fieldname is the name of fields from your database that you want to get
        //                    lblParkingVND.Text = Func.FormatNumber_New(MoneyVND); // Where Fieldname is the name of fields from your database that you want to get

        //                    lblParkingPaidUSD.Text = Func.FormatNumber_New(PaidUSD); // Where Fieldname is the name of fields from your database that you want to get
        //                    lblParkingPaidVND.Text = Func.FormatNumber_New(PaidVND); // Where Fieldname is the name of fields from your database that you want to get

        //                    txtParkingPaidUSD.Text = Func.FormatNumber_New(Func.ParseFloat(MoneyUSD) - Func.ParseFloat(PaidUSD));
        //                    txtParkingPaidVND.Text = Func.FormatNumber_New(Func.ParseDouble(MoneyVND) - Func.ParseFloat(PaidVND));

        //                    txtParkingPaidUSD.Text = Func.FormatNumber_New(tmpUSD);
        //                    txtParkingPaidVND.Text = Func.FormatNumber_New(tmpVND);

        //                    if (tmpUSD > 0)
        //                    {
        //                        txtParkingPaidUSD.Text = Func.FormatNumber_New(tmpUSD);
        //                    }
        //                    if (tmpVND > 0)
        //                    {
        //                        txtParkingPaidVND.Text = Func.FormatNumber_New(tmpVND);
        //                    }
        //                    break;
        //                case "4":
        //                    lblExtraTimeUSD.Text = Func.FormatNumber_New(MoneyUSD); // Where Fieldname is the name of fields from your database that you want to get
        //                    lblExtraTimeVND.Text = Func.FormatNumber_New(MoneyVND); // Where Fieldname is the name of fields from your database that you want to get

        //                    lblExtraTimePaidUSD.Text = Func.FormatNumber_New(PaidUSD); // Where Fieldname is the name of fields from your database that you want to get
        //                    lblExtraTimePaidVND.Text = Func.FormatNumber_New(PaidVND); // Where Fieldname is the name of fields from your database that you want to get

        //                    txtExtraTimePaidUSD.Text = Func.FormatNumber_New(Func.ParseFloat(MoneyUSD) - Func.ParseFloat(PaidUSD));
        //                    txtExtraTimePaidVND.Text = Func.FormatNumber_New(Func.ParseDouble(MoneyVND) - Func.ParseFloat(PaidVND));

        //                    txtExtraTimePaidUSD.Text = Func.FormatNumber_New(tmpUSD);
        //                    txtExtraTimePaidVND.Text = Func.FormatNumber_New(tmpVND);

        //                    if (tmpUSD > 0)
        //                    {
        //                        txtExtraTimePaidUSD.Text = Func.FormatNumber_New(tmpUSD);
        //                    }
        //                    if (tmpVND > 0)
        //                    {
        //                        txtExtraTimePaidVND.Text = Func.FormatNumber_New(tmpVND);
        //                    }
        //                    break;
        //                case "5":
        //                    //lblElecUSD.Text = Func.FormatNumber_New(MoneyUSD); // Where Fieldname is the name of fields from your database that you want to get
        //                    lblElecVND.Text = Func.FormatNumber_New(MoneyVND); // Where Fieldname is the name of fields from your database that you want to get

        //                    //lblElecPaidUSD.Text = PaidUSD; // Where Fieldname is the name of fields from your database that you want to get
        //                    lblElecPaidVND.Text = Func.FormatNumber_New(PaidVND); // Where Fieldname is the name of fields from your database that you want to get

        //                    //txtElecPaidUSD.Text = Func.FormatNumber_New(Func.ParseFloat(MoneyUSD) - Func.ParseFloat(PaidUSD));
        //                    txtElecPaidVND.Text = Func.FormatNumber_New(Func.ParseDouble(MoneyVND) - Func.ParseFloat(PaidVND));

        //                    //txtElecPaidUSD.Text = Func.FormatNumber_New(tmpUSD);
        //                    txtElecPaidVND.Text = Func.FormatNumber_New(tmpVND);

        //                    //if (tmpUSD > 0)
        //                    //{
        //                    //    txtElecPaidUSD.Text = Func.FormatNumber_New(tmpUSD);
        //                    //}
        //                    if (tmpVND > 0)
        //                    {
        //                        txtElecPaidVND.Text = Func.FormatNumber_New(tmpVND);
        //                    }
        //                    break;
        //                case "6":
        //                    //lblWaterUSD.Text = Func.FormatNumber_New(MoneyUSD); // Where Fieldname is the name of fields from your database that you want to get
        //                    lblWaterVND.Text = Func.FormatNumber_New(MoneyVND); // Where Fieldname is the name of fields from your database that you want to get

        //                    //lblWaterPaidUSD.Text = PaidUSD; // Where Fieldname is the name of fields from your database that you want to get
        //                    lblWaterPaidVND.Text = Func.FormatNumber_New(PaidVND); // Where Fieldname is the name of fields from your database that you want to get

        //                    //txtWaterPaidUSD.Text = Func.FormatNumber_New(Func.ParseFloat(MoneyUSD) - Func.ParseFloat(PaidUSD));
        //                    txtWaterPaidVND.Text = Func.FormatNumber_New(Func.ParseFloat(MoneyVND) - Func.ParseFloat(PaidVND));

        //                    //txtWaterPaidUSD.Text = Func.FormatNumber_New(tmpUSD);
        //                    txtWaterPaidVND.Text = Func.FormatNumber_New(tmpVND);

        //                    //if (tmpUSD > 0)
        //                    //{
        //                    //    txtWaterPaidUSD.Text = Func.FormatNumber_New(tmpUSD);
        //                    //}
        //                    if (tmpVND > 0)
        //                    {
        //                        txtWaterPaidVND.Text = Func.FormatNumber_New(tmpVND);
        //                    }
        //                    break;
        //                case "7":
        //                    lblServiceUSD.Text = Func.FormatNumber_New(MoneyUSD); // Where Fieldname is the name of fields from your database that you want to get
        //                    lblServiceVND.Text = Func.FormatNumber_New(MoneyVND); // Where Fieldname is the name of fields from your database that you want to get

        //                    lblServicePaidUSD.Text = Func.FormatNumber_New(PaidUSD); // Where Fieldname is the name of fields from your database that you want to get
        //                    lblServicePaidVND.Text = Func.FormatNumber_New(PaidVND); // Where Fieldname is the name of fields from your database that you want to get

        //                    txtServicePaidUSD.Text = Func.ParseString(Func.ParseFloat(MoneyUSD) - Func.ParseFloat(PaidUSD));
        //                    txtServicePaidVND.Text = Func.FormatNumber_New(Func.ParseFloat(MoneyVND) - Func.ParseFloat(PaidVND));

        //                    txtServicePaidUSD.Text = Func.FormatNumber_New(tmpUSD);
        //                    txtServicePaidVND.Text = Func.FormatNumber_New(tmpVND);

        //                    if (tmpUSD > 0)
        //                    {
        //                        txtServicePaidUSD.Text = Func.FormatNumber_New(tmpUSD);
        //                    }
        //                    if (tmpVND > 0)
        //                    {
        //                        txtServicePaidVND.Text = Func.FormatNumber_New(tmpVND);
        //                    }
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ApplicationLog.WriteError(ex);
        //    }
        //}
        private void ShowData()
        {
            hidBillId.Value = DbHelper.GetScalar("Select id from PaymentBillInfo where customerid = '" + hidId.Value + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "' and BuildingId= '" + Func.ParseString(Session["__BUILDINGID__"]) + "'");

            if (!String.IsNullOrEmpty(hidBillId.Value))
            {
                PaymentBillInfoData data = new PaymentBillInfoData();
                ITransaction tran = factory.GetLoadObject(data, hidBillId.Value);
                Execute(tran);
                if (!HasError)
                {
                    data = (PaymentBillInfoData)tran.Result;

                    txtBillNo.Text = data.BillNo;
                    txtBillDate.Text = data.BillDate;
                    txtUsdExchangeDate.Text = Func.FormatDMY(data.UsdExchangeDate);
                    txtUsdExchange.Text = Func.ParseString(Func.ParseFloat(data.UsdExchange));
                }

                btnCreate.Text = "Lưu Hóa Đơn";
                //divDetail.Visible = true;
            }
            else
            {
                txtBillNo.Text = "";
                txtBillDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtUsdExchangeDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtUsdExchange.Text = "";

                btnCreate.Text = "Tạo Hóa Đơn";
                //divDetail.Visible = false;
            }

            if (String.IsNullOrEmpty(hidBillId.Value))
            {
                mvMessage.AddError("Tháng chưa tạo Hóa Đơn");
                //return;
            }
            string yearMonths = DbHelper.GetScalar("Select YearMonths from PaymentBillInfo where id = '" + hidBillId.Value + "'");
            if (String.IsNullOrEmpty(yearMonths))
            {
                yearMonths = DateTime.Now.AddMonths(-1).ToString("yyyyMM");
            }

            lstYearMonth.Items.Clear();
            lstSelectedYearMonth.Items.Clear();

            for (int i = -9; i < 9; i++)
            {
                if (yearMonths.IndexOf(DateTime.Now.AddMonths(i).ToString("yyyyMM")) < 0)
                {
                    lstYearMonth.Items.Add(new ListItem(DateTime.Now.AddMonths(i).ToString("MM/yyyy"), DateTime.Now.AddMonths(i).ToString("yyyyMM")));
                }
                else
                {
                    lstSelectedYearMonth.Items.Add(new ListItem(DateTime.Now.AddMonths(i).ToString("MM/yyyy"), DateTime.Now.AddMonths(i).ToString("yyyyMM")));
                }
            }

            string lsYearmonth = "";
            foreach (ListItem lstItem in lstSelectedYearMonth.Items)
            {
                lsYearmonth += ",'" + lstItem.Value + "'";
            }
            if (String.IsNullOrEmpty(lsYearmonth))
            {
                mvMessage.AddError("Phải chọn ít nhất 1 tháng");
                return;
            }

            //divRent.Visible = false;
            //divManager.Visible = false;
            //divParking.Visible = false;
            //divService.Visible = false;
            //divWater.Visible = false;
            //divExtraTime.Visible = false;
            //divElec.Visible = false;

            lsYearmonth = lsYearmonth.Substring(1);



            SqlDatabase db = new SqlDatabase();
            string sql = string.Empty;
            if (!Func.IsValid(ListSortExpression))
            {
                ListSortExpression = "Name";
                ListSortDirection = SortDirection.Descending;
            }
            try
            {
                //Rent And Manager Price
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " Select *";
                sql += " FROM PaymentRoom";
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth in (" + lsYearmonth + ")";

                SqlCommand cm = db.CreateCommand(sql);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataSet ds = new DataSet();
                da.Fill(ds);
                db.Close();
                rptRoomRent.DataSource = ds.Tables[0].DefaultView;
                rptRoomRent.DataBind();

                rptRoomManager.DataSource = ds.Tables[0].DefaultView;
                rptRoomManager.DataBind();


                //Parking
                sql = string.Empty;
                sort = "TariffsParkingName" + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " SELECT COUNT(*) AS Num, YearMonth, TariffsParkingName, PriceVND, PriceUSD, SUM(VatVND) AS VatVND,SUM(VatUSD) AS VatUSD, SUM(SumVND) AS SumVND, SUM(SumUSD) AS SumUSD, SUM(LastPriceVND) AS LastPriceVND";
                sql += "        , SUM(LastPriceUSD) AS LastPriceUSD";
                sql += " FROM         dbo.PaymentParking";
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth in (" + lsYearmonth + ")";
                sql += " GROUP BY YearMonth, TariffsParkingName, PriceVND, PriceUSD, Vat, daysParking";

                cm = db.CreateCommand(sql);
                da = new SqlDataAdapter(cm);
                ds = new DataSet();
                da.Fill(ds);
                db.Close();
                rptParking.DataSource = ds.Tables[0].DefaultView;
                rptParking.DataBind();

                //Extra Time
                sql = string.Empty;
                sort = "WorkingDate" + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " SELECT * ";
                sql += " FROM   PaymentExtraTime";
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth in (" + lsYearmonth + ")";

                cm = db.CreateCommand(sql);
                da = new SqlDataAdapter(cm);
                ds = new DataSet();
                da.Fill(ds);
                db.Close();
                rptExtraTime.DataSource = ds.Tables[0].DefaultView;
                rptExtraTime.DataBind();

                //Elec
                ListSortDirection = SortDirection.Ascending;
                sql = string.Empty;
                sort = "B.FromIndex" + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " SELECT BD_Room.Name as RoomName, A.DateFrom, A.DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVND, B.PriceUSD, B.SumVND, B.SumUSD, ";
                sql += "        B.VatVND, B.VatUSD, B.LastPriceVND, B.LastPriceUSD, B.Name,B.WaterPricePercent,B.ElecPricePercent ";
                sql += " FROM   PaymentElecWater AS A INNER JOIN ";
                sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId INNER JOIN";
                sql += "        BD_Room ON A.RoomId = BD_Room.id";
                sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfWaterId = 0  and A.YearMonth in (" + lsYearmonth + ") and B.DetailType = 1";
                sql += " Order by " + sort;


                cm = db.CreateCommand(sql);
                da = new SqlDataAdapter(cm);
                ds = new DataSet();
                da.Fill(ds);
                db.Close();
                rptElec.DataSource = ds.Tables[0].DefaultView;
                rptElec.DataBind();

                //Water
                sql = string.Empty;

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " SELECT BD_Room.Name as RoomName, A.DateFrom, A.DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVND, B.PriceUSD, B.SumVND, B.SumUSD, ";
                sql += "        B.VatVND, B.VatUSD, B.LastPriceVND, B.LastPriceUSD, B.Name,B.WaterPricePercent,B.ElecPricePercent ";
                sql += " FROM   PaymentElecWater AS A INNER JOIN ";
                sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId INNER JOIN";
                sql += "        BD_Room ON A.RoomId = BD_Room.id";
                sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfElecId = 0 and A.YearMonth in (" + lsYearmonth + ")  and B.DetailType = 2";
                sql += " Order by " + sort;

                cm = db.CreateCommand(sql);
                da = new SqlDataAdapter(cm);
                ds = new DataSet();
                da.Fill(ds);
                db.Close();
                rptWater.DataSource = ds.Tables[0].DefaultView;
                rptWater.DataBind();

                //Service
                sql = string.Empty;
                sort = "ServiceDate" + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " SELECT * ";
                sql += " FROM   PaymentService";
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth in (" + lsYearmonth + ")";

                cm = db.CreateCommand(sql);
                da = new SqlDataAdapter(cm);
                ds = new DataSet();
                da.Fill(ds);
                db.Close();
                rptService.DataSource = ds.Tables[0].DefaultView;
                rptService.DataBind();

                //Dept
                sql = string.Empty;
                sort = "YearMonth" + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                ////Parking
                //sql = string.Empty;
                //sql += " SELECT SUM(LastPriceVND) AS LastPriceVND, SUM(LastPriceUSD) AS LastPriceUSD";
                //sql += " FROM  PaymentParking";
                //sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'";
                //sql += " GROUP BY YearMonth, TariffsParkingName, PriceVND, PriceUSD, Vat";
                //dt = DbHelper.GetDataTable(sql);
                //if (dt.Rows.Count > 0) // Check if the DataTable returns any data from database
                //{
                //    lblParkingUSD.Text = dt.Rows[0][0].ToString(); // Where Fieldname is the name of fields from your database that you want to get
                //    lblParkingVND.Text =  Func.FormatNumber_New(dt.Rows[0][1].ToString(); // Where Fieldname is the name of fields from your database that you want to get
                //}
                ////Extra Time
                //sql = string.Empty;
                //sql += " SELECT SUM(LastPriceVND) AS LastPriceVND, SUM(LastPriceUSD) AS LastPriceUSD";
                //sql += " FROM   PaymentExtraTime";
                //sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'";
                //dt = DbHelper.GetDataTable(sql);
                //if (dt.Rows.Count > 0) // Check if the DataTable returns any data from database
                //{
                //    lblExtraTimeUSD.Text = dt.Rows[0][0].ToString(); // Where Fieldname is the name of fields from your database that you want to get
                //    lblExtraTimeVND.Text =  Func.FormatNumber_New(dt.Rows[0][1].ToString(); // Where Fieldname is the name of fields from your database that you want to get
                //}
                ////Elec
                //sql = string.Empty;
                //sql += " SELECT SUM(LastPriceVND) AS LastPriceVND, SUM(LastPriceUSD) AS LastPriceUSD";
                //sql += " FROM   PaymentElecWater";
                //sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and TarrifsOfWaterId = 0 and YearMonth = '" + YearMonth + "'";
                //dt = DbHelper.GetDataTable(sql);
                //if (dt.Rows.Count > 0) // Check if the DataTable returns any data from database
                //{
                //    lblElecUSD.Text = dt.Rows[0][0].ToString(); // Where Fieldname is the name of fields from your database that you want to get
                //    lblElecVND.Text =  Func.FormatNumber_New(dt.Rows[0][1].ToString(); // Where Fieldname is the name of fields from your database that you want to get
                //}
                ////Water
                //sql = string.Empty;
                //sql += " SELECT SUM(LastPriceVND) AS LastPriceVND, SUM(LastPriceUSD) AS LastPriceUSD";
                //sql += " FROM   PaymentElecWater ";
                //sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and TarrifsOfElecId = 0 and YearMonth = '" + YearMonth + "'";
                //dt = DbHelper.GetDataTable(sql);
                //if (dt.Rows.Count > 0) // Check if the DataTable returns any data from database
                //{
                //    lblWaterUSD.Text = dt.Rows[0][0].ToString(); // Where Fieldname is the name of fields from your database that you want to get
                //    lblWaterVND.Text =  Func.FormatNumber_New(dt.Rows[0][1].ToString(); // Where Fieldname is the name of fields from your database that you want to get
                //}
                ////Service
                //sql = string.Empty;
                //sql += " SELECT SUM(LastPriceVND) AS LastPriceVND, SUM(LastPriceUSD) AS LastPriceUSD";
                //sql += " FROM   PaymentService";
                //sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'";
                //dt = DbHelper.GetDataTable(sql);
                //if (dt.Rows.Count > 0) // Check if the DataTable returns any data from database
                //{
                //    lblServiceUSD.Text = dt.Rows[0][0].ToString(); // Where Fieldname is the name of fields from your database that you want to get
                //    lblServiceVND.Text =  Func.FormatNumber_New(dt.Rows[0][1].ToString(); // Where Fieldname is the name of fields from your database that you want to get
                //}
                ////Dept
                //sql = string.Empty;
                //sql += " SELECT sum(RemainRentUSD+RemainManagerUSD+RemainElecUSD+RemainWaterUSD+RemainServiceUSD+RemainParkingUSD+RemainExtraTimePriceUSD) as SumUSD,sum(RemainRentVND+RemainManagerVND+RemainElecVND+RemainWaterVND+RemainServiceVND+RemainParkingVND+RemainExtraTimePriceVND) AS SumVND ";
                //sql += " FROM   v_PaymentYearMonthDept";
                //sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' And";
                //sql += " (RemainRentUSD+RemainManagerUSD+RemainElecUSD+RemainWaterUSD+RemainServiceUSD+RemainParkingUSD+RemainExtraTimePriceUSD)>0 and YearMonth <> '" + YearMonth + "'";
                //dt = DbHelper.GetDataTable(sql);
                sql = "  Select  SUM(MoneyUSD) AS MoneyUSD, SUM(MoneyVND) AS MoneyVND, SUM(PaidUSD) AS PaidUSD, SUM(PaidVND) AS PaidVND, PaymentType";
                sql += " From    PaymentBillDetail";
                sql += " Where   BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth in (" + lsYearmonth + ")";
                sql += " GROUP BY PaymentType";

                DataTable dt = DbHelper.GetDataTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string PaymentType = Func.ParseString(dt.Rows[i]["PaymentType"]);
                    string MoneyUSD = Func.ParseString(dt.Rows[i]["MoneyUSD"]);
                    string MoneyVND = Func.ParseString(dt.Rows[i]["MoneyVND"]);
                    string PaidUSD = Func.ParseString(dt.Rows[i]["PaidUSD"]);
                    string PaidVND = Func.ParseString(dt.Rows[i]["PaidVND"]);
                    //string ExchangeType = Func.ParseString(dt.Rows[i]["ExchangeType"]);
                    //string UsdExchange = Func.ParseString(dt.Rows[i]["UsdExchange"]);

                    decimal tmpUSD = Convert.ToDecimal(MoneyUSD) - Convert.ToDecimal(PaidUSD);
                    decimal tmpVND = Convert.ToDecimal(MoneyVND) - Convert.ToDecimal(PaidVND);

                    switch (PaymentType)
                    {
                        case "1":
                            //Rent
                            lblRentUSD.Text = Func.FormatNumber_New(MoneyUSD); // Where Fieldname is the name of fields from your database that you want to get
                            lblRentVND.Text = Func.FormatNumber_New(MoneyVND); // Where Fieldname is the name of fields from your database that you want to get

                            lblRentPaidUSD.Text = Func.FormatNumber_New(PaidUSD); // Where Fieldname is the name of fields from your database that you want to get
                            lblRentPaidVND.Text = Func.FormatNumber_New(PaidVND); // Where Fieldname is the name of fields from your database that you want to get

                            txtRentPaidUSD.Text = Func.FormatNumber_New(tmpUSD);
                            txtRentPaidVND.Text = Func.FormatNumber_New(tmpVND);

                            if (tmpUSD > 0)
                            {
                                txtRentPaidUSD.Text = Func.FormatNumber_New(tmpUSD);
                            }
                            if (tmpVND > 0)
                            {
                                txtRentPaidVND.Text = Func.FormatNumber_New(tmpVND);
                            }
                            break;
                        case "2":
                            //Manager
                            lblMangagerUSD.Text = Func.FormatNumber_New(MoneyUSD); // Where Fieldname is the name of fields from your database that you want to get
                            lblMangagerVND.Text = Func.FormatNumber_New(MoneyVND); // Where Fieldname is the name of fields from your database that you want to get

                            lblMangagerPaidUSD.Text = Func.FormatNumber_New(PaidUSD); // Where Fieldname is the name of fields from your database that you want to get
                            lblMangagerPaidVND.Text = Func.FormatNumber_New(PaidVND); // Where Fieldname is the name of fields from your database that you want to get

                            txtManagerPaidUSD.Text = Func.FormatNumber_New(tmpUSD);
                            txtManagerPaidVND.Text = Func.FormatNumber_New(tmpVND);

                            if (tmpUSD > 0)
                            {
                                txtManagerPaidUSD.Text = Func.FormatNumber_New(tmpUSD);
                            }
                            if (tmpVND > 0)
                            {
                                txtManagerPaidVND.Text = Func.FormatNumber_New(tmpVND);
                            }

                            break;
                        case "3":
                            //Parking
                            lblParkingUSD.Text = Func.FormatNumber_New(MoneyUSD); // Where Fieldname is the name of fields from your database that you want to get
                            lblParkingVND.Text = Func.FormatNumber_New(MoneyVND); // Where Fieldname is the name of fields from your database that you want to get

                            lblParkingPaidUSD.Text = Func.FormatNumber_New(PaidUSD); // Where Fieldname is the name of fields from your database that you want to get
                            lblParkingPaidVND.Text = Func.FormatNumber_New(PaidVND); // Where Fieldname is the name of fields from your database that you want to get

                            txtParkingPaidUSD.Text = Func.FormatNumber_New(Func.ParseFloat(MoneyUSD) - Func.ParseFloat(PaidUSD));
                            txtParkingPaidVND.Text = Func.FormatNumber_New(Func.ParseDouble(MoneyVND) - Func.ParseFloat(PaidVND));

                            txtParkingPaidUSD.Text = Func.FormatNumber_New(tmpUSD);
                            txtParkingPaidVND.Text = Func.FormatNumber_New(tmpVND);

                            if (tmpUSD > 0)
                            {
                                txtParkingPaidUSD.Text = Func.FormatNumber_New(tmpUSD);
                            }
                            if (tmpVND > 0)
                            {
                                txtParkingPaidVND.Text = Func.FormatNumber_New(tmpVND);
                            }
                            break;
                        case "4":
                            lblExtraTimeUSD.Text = Func.FormatNumber_New(MoneyUSD); // Where Fieldname is the name of fields from your database that you want to get
                            lblExtraTimeVND.Text = Func.FormatNumber_New(MoneyVND); // Where Fieldname is the name of fields from your database that you want to get

                            lblExtraTimePaidUSD.Text = Func.FormatNumber_New(PaidUSD); // Where Fieldname is the name of fields from your database that you want to get
                            lblExtraTimePaidVND.Text = Func.FormatNumber_New(PaidVND); // Where Fieldname is the name of fields from your database that you want to get

                            txtExtraTimePaidUSD.Text = Func.FormatNumber_New(Func.ParseFloat(MoneyUSD) - Func.ParseFloat(PaidUSD));
                            txtExtraTimePaidVND.Text = Func.FormatNumber_New(Func.ParseDouble(MoneyVND) - Func.ParseFloat(PaidVND));

                            txtExtraTimePaidUSD.Text = Func.FormatNumber_New(tmpUSD);
                            txtExtraTimePaidVND.Text = Func.FormatNumber_New(tmpVND);

                            if (tmpUSD > 0)
                            {
                                txtExtraTimePaidUSD.Text = Func.FormatNumber_New(tmpUSD);
                            }
                            if (tmpVND > 0)
                            {
                                txtExtraTimePaidVND.Text = Func.FormatNumber_New(tmpVND);
                            }
                            break;
                        case "5":
                            //lblElecUSD.Text = Func.FormatNumber_New(MoneyUSD); // Where Fieldname is the name of fields from your database that you want to get
                            lblElecVND.Text = Func.FormatNumber_New(MoneyVND); // Where Fieldname is the name of fields from your database that you want to get

                            //lblElecPaidUSD.Text = PaidUSD; // Where Fieldname is the name of fields from your database that you want to get
                            lblElecPaidVND.Text = Func.FormatNumber_New(PaidVND); // Where Fieldname is the name of fields from your database that you want to get

                            //txtElecPaidUSD.Text = Func.FormatNumber_New(Func.ParseFloat(MoneyUSD) - Func.ParseFloat(PaidUSD));
                            txtElecPaidVND.Text = Func.FormatNumber_New(Func.ParseDouble(MoneyVND) - Func.ParseFloat(PaidVND));

                            //txtElecPaidUSD.Text = Func.FormatNumber_New(tmpUSD);
                            txtElecPaidVND.Text = Func.FormatNumber_New(tmpVND);

                            //if (tmpUSD > 0)
                            //{
                            //    txtElecPaidUSD.Text = Func.FormatNumber_New(tmpUSD);
                            //}
                            if (tmpVND > 0)
                            {
                                txtElecPaidVND.Text = Func.FormatNumber_New(tmpVND);
                            }
                            break;
                        case "6":
                            //lblWaterUSD.Text = Func.FormatNumber_New(MoneyUSD); // Where Fieldname is the name of fields from your database that you want to get
                            lblWaterVND.Text = Func.FormatNumber_New(MoneyVND); // Where Fieldname is the name of fields from your database that you want to get

                            //lblWaterPaidUSD.Text = PaidUSD; // Where Fieldname is the name of fields from your database that you want to get
                            lblWaterPaidVND.Text = Func.FormatNumber_New(PaidVND); // Where Fieldname is the name of fields from your database that you want to get

                            //txtWaterPaidUSD.Text = Func.FormatNumber_New(Func.ParseFloat(MoneyUSD) - Func.ParseFloat(PaidUSD));
                            txtWaterPaidVND.Text = Func.FormatNumber_New(Func.ParseFloat(MoneyVND) - Func.ParseFloat(PaidVND));

                            //txtWaterPaidUSD.Text = Func.FormatNumber_New(tmpUSD);
                            txtWaterPaidVND.Text = Func.FormatNumber_New(tmpVND);

                            //if (tmpUSD > 0)
                            //{
                            //    txtWaterPaidUSD.Text = Func.FormatNumber_New(tmpUSD);
                            //}
                            if (tmpVND > 0)
                            {
                                txtWaterPaidVND.Text = Func.FormatNumber_New(tmpVND);
                            }
                            break;
                        case "7":
                            lblServiceUSD.Text = Func.FormatNumber_New(MoneyUSD); // Where Fieldname is the name of fields from your database that you want to get
                            lblServiceVND.Text = Func.FormatNumber_New(MoneyVND); // Where Fieldname is the name of fields from your database that you want to get

                            lblServicePaidUSD.Text = Func.FormatNumber_New(PaidUSD); // Where Fieldname is the name of fields from your database that you want to get
                            lblServicePaidVND.Text = Func.FormatNumber_New(PaidVND); // Where Fieldname is the name of fields from your database that you want to get

                            txtServicePaidUSD.Text = Func.ParseString(Func.ParseFloat(MoneyUSD) - Func.ParseFloat(PaidUSD));
                            txtServicePaidVND.Text = Func.FormatNumber_New(Func.ParseFloat(MoneyVND) - Func.ParseFloat(PaidVND));

                            txtServicePaidUSD.Text = Func.FormatNumber_New(tmpUSD);
                            txtServicePaidVND.Text = Func.FormatNumber_New(tmpVND);

                            if (tmpUSD > 0)
                            {
                                txtServicePaidUSD.Text = Func.FormatNumber_New(tmpUSD);
                            }
                            if (tmpVND > 0)
                            {
                                txtServicePaidVND.Text = Func.FormatNumber_New(tmpVND);
                            }
                            break;
                        default:
                            break;
                    }
                }
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
            hidId.Value = Func.ParseString(Request["id"]);

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
            hidId.Value = Func.ParseString(Request["id"]);

            if (!IsPostBack)
            {
                PopupWidth = 600;
                PopupHeight = 450;

                CustomerData data = new CustomerData();
                ITransaction tran = factory.GetLoadObject(data, hidId.Value);
                Execute(tran);
                if (!HasError)
                {
                    //Get Data
                    data = (CustomerData)tran.Result;
                    lblCustomerId.Text = data.CustomerId;
                    lblName.Text = data.Name;
                }

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
                //string YearMonths = DbHelper.GetScalar("Select YearMonths from PaymentBillInfo where customerid = '" + hidId.Value + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "' and BuildingId= '" + Func.ParseString(Session["__BUILDINGID__"]) + "'");

                //for (int i = -6; i < 6; i++)
                //{
                //    if (YearMonths.IndexOf(DateTime.Now.AddMonths(i).ToString("MM/yyyy")) < 0)
                //    {
                //        lstYearMonth.Items.Add(new ListItem(DateTime.Now.AddMonths(i).ToString("MM/yyyy"), DateTime.Now.AddMonths(i).ToString("yyyyMM")));
                //    }
                //    else
                //    {
                //        lstSelectedYearMonth.Items.Add(new ListItem(DateTime.Now.AddMonths(i).ToString("MM/yyyy"), DateTime.Now.AddMonths(i).ToString("yyyyMM")));
                //    }
                //}
                ShowData();

            }
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            ArrayList rmList = new ArrayList();
            using (SqlConnection rConn = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
            {
                rConn.Open();
                foreach (ListItem lstItem in lstYearMonth.Items)
                {

                    if (lstItem.Selected)
                    {
                        lstSelectedYearMonth.Items.Add(lstItem);
                        rmList.Add(lstItem);
                    }
                }
                rConn.Close();
            }
            for (int i = 0; i < rmList.Count; i++)
            {
                lstYearMonth.Items.Remove((ListItem)rmList[i]);
            }
        }
        protected void btnUnSelect_Click(object sender, EventArgs e)
        {
            ArrayList rmList = new ArrayList();
            foreach (ListItem lstItem in lstSelectedYearMonth.Items)
            {
                if (lstItem.Selected)
                {
                    lstYearMonth.Items.Add(lstItem);
                    rmList.Add(lstItem);
                }
            }
            for (int i = 0; i < rmList.Count; i++)
            {
                lstSelectedYearMonth.Items.Remove((ListItem)rmList[i]);
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

                    string ContractId = Func.ParseString(row["ContractId"]);
                    //string CustomerId = Func.ParseString(row["CustomerId"]);
                    string ContractDate = Func.ParseString(row["ContractDate"]);
                    string ContractEndDate = Func.ParseString(row["ContractEndDate"]);
                    string ReceiveDate = Func.ParseString(row["ReceiveDate"]);
                    string StaffMount = Func.ParseString(row["StaffMount"]);
                    string Comment = Func.ParseString(row["Comment"]);

                    Func.SetGridLinkValue(item, "btnEdit", ContractId);
                    //Func.SetGridTextValue(item, "ltrCustomerId", CustomerId);
                    Func.SetGridTextValue(item, "ltrContractDate", Func.Formatdmyhms(ContractDate));
                    Func.SetGridTextValue(item, "ltrContractEndDate", Func.Formatdmyhms(ContractEndDate));
                    Func.SetGridTextValue(item, "ltrReceiveDate", Func.Formatdmyhms(ReceiveDate));
                    Func.SetGridTextValue(item, "ltrStaffMount", StaffMount);
                    Func.SetGridTextValue(item, "ltrComment", Func.ToolTipByteLen(Comment, 20));

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

        protected void rptRoomManagerList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            try
            {
                if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
                {
                    DataRowView row = (DataRowView)item.DataItem;

                    string id = Func.ParseString(row["id"]);
                    string BuildingId = Func.ParseString(row["BuildingId"]);
                    string CustomerId = Func.ParseString(row["CustomerId"]);
                    string ContractId = Func.ParseString(row["ContractId"]);
                    string RoomId = Func.ParseString(row["RoomId"]);
                    string ManagerPriceVND = Func.ParseString(row["MonthManagerPriceVND"]);
                    string ManagerPriceUSD = Func.ParseString(row["MonthManagerPriceUSD"]);
                    string VatVND = Func.ParseString(row["VatManagerPriceVND"]);
                    string VatUSD = Func.ParseString(row["VatManagerPriceUSD"]);

                    string OtherFee01 = Func.ParseString(row["OtherFee01"]);
                    string OtherFee02 = Func.ParseString(row["OtherFee02"]);
                    string SumVND = Func.ParseString(row["MonthManagerSumVND"]);
                    string SumUSD = Func.ParseString(row["MonthManagerSumUSD"]);

                    string LastPriceVND = Func.ParseString(row["LastManagerSumVND"]);
                    string LastPriceUSD = Func.ParseString(row["LastManagerSumUSD"]);

                    string YearMonth = Func.ParseString(row["YearMonth"]);
                    string Area = Func.ParseString(row["Area"]);
                    string Name = Func.ParseString(row["Name"]);
                    string Regional = Func.ParseString(row["Regional"]);
                    string Floor = Func.ParseString(row["Floor"]);


                    Func.SetGridTextValue(item, "ltrName", Name);

                    Func.SetGridTextValue(item, "ltrArea", Area);

                    Func.SetGridTextValue(item, "ltrPriceVND", Func.FormatNumber_New(ManagerPriceVND));
                    Func.SetGridTextValue(item, "ltrPriceUSD", Func.FormatNumber_New(ManagerPriceUSD));

                    Func.SetGridTextValue(item, "ltrSumVND", Func.FormatNumber_New(SumVND));
                    Func.SetGridTextValue(item, "ltrSumUSD", Func.FormatNumber_New(SumUSD));

                    Func.SetGridTextValue(item, "ltrVatVND", Func.FormatNumber_New(VatVND));
                    Func.SetGridTextValue(item, "ltrVatUSD", Func.FormatNumber_New(VatUSD));

                    Func.SetGridTextValue(item, "ltrLastPriceVND", Func.FormatNumber_New(LastPriceVND));
                    Func.SetGridTextValue(item, "ltrLastPriceUSD", Func.FormatNumber_New(LastPriceUSD));

                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }

        protected void rptRoomRentList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            try
            {
                if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
                {
                    DataRowView row = (DataRowView)item.DataItem;

                    string id = Func.ParseString(row["id"]);
                    string BuildingId = Func.ParseString(row["BuildingId"]);
                    string CustomerId = Func.ParseString(row["CustomerId"]);
                    string ContractId = Func.ParseString(row["ContractId"]);
                    string RoomId = Func.ParseString(row["RoomId"]);

                    string OtherFee01 = Func.ParseString(row["OtherFee01"]);
                    string OtherFee02 = Func.ParseString(row["OtherFee02"]);

                    string YearMonth = Func.ParseString(row["YearMonth"]);
                    string Area = Func.ParseString(row["Area"]);
                    string Name = Func.ParseString(row["Name"]);
                    string Regional = Func.ParseString(row["Regional"]);
                    string Floor = Func.ParseString(row["Floor"]);


                    string RentPriceVND = Func.ParseString(row["MonthRentPriceVND"]);
                    string RentPriceUSD = Func.ParseString(row["MonthRentPriceUSD"]);
                    string VatVND = Func.ParseString(row["VatRentPriceVND"]);
                    string VatUSD = Func.ParseString(row["VatRentPriceUSD"]);


                    string SumVND = Func.ParseString(row["MonthRentSumVND"]);
                    string SumUSD = Func.ParseString(row["MonthRentSumUSD"]);

                    string LastPriceVND = Func.ParseString(row["LastRentSumVND"]);
                    string LastPriceUSD = Func.ParseString(row["LastRentSumUSD"]);


                    Func.SetGridTextValue(item, "ltrName", Name);

                    Func.SetGridTextValue(item, "ltrArea", Area);

                    Func.SetGridTextValue(item, "ltrPriceVND", Func.FormatNumber_New(RentPriceVND));
                    Func.SetGridTextValue(item, "ltrPriceUSD", Func.FormatNumber_New(RentPriceUSD));

                    Func.SetGridTextValue(item, "ltrSumVND", Func.FormatNumber_New(SumVND));
                    Func.SetGridTextValue(item, "ltrSumUSD", Func.FormatNumber_New(SumUSD));

                    Func.SetGridTextValue(item, "ltrVatVND", Func.FormatNumber_New(VatVND));
                    Func.SetGridTextValue(item, "ltrVatUSD", Func.FormatNumber_New(VatUSD));

                    Func.SetGridTextValue(item, "ltrLastPriceVND", Func.FormatNumber_New(LastPriceVND));
                    Func.SetGridTextValue(item, "ltrLastPriceUSD", Func.FormatNumber_New(LastPriceUSD));

                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }
        protected void rptParking_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            try
            {
                if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
                {
                    DataRowView row = (DataRowView)item.DataItem;

                    string Num = Func.ParseString(row["Num"]);
                    string TariffsParkingName = Func.ParseString(row["TariffsParkingName"]);

                    string PriceVND = Func.ParseString(row["PriceVND"]);
                    string PriceUSD = Func.ParseString(row["PriceUSD"]);
                    string VatVND = Func.ParseString(row["VatVND"]);
                    string VatUSD = Func.ParseString(row["VatUSD"]);

                    string SumVND = Func.ParseString(row["SumVND"]);
                    string SumUSD = Func.ParseString(row["SumUSD"]);
                    string LastPriceVND = Func.ParseString(row["LastPriceVND"]);
                    string LastPriceUSD = Func.ParseString(row["LastPriceUSD"]);

                    Func.SetGridTextValue(item, "ltrName", TariffsParkingName);

                    Func.SetGridTextValue(item, "ltrNum", Func.FormatNumber_New(Num));

                    Func.SetGridTextValue(item, "ltrPriceVND", Func.FormatNumber_New(PriceVND));
                    Func.SetGridTextValue(item, "ltrPriceUSD", Func.FormatNumber_New(PriceUSD));

                    Func.SetGridTextValue(item, "ltrSumVND", Func.FormatNumber_New(SumVND));
                    Func.SetGridTextValue(item, "ltrSumUSD", Func.FormatNumber_New(SumUSD));

                    Func.SetGridTextValue(item, "ltrVatVND", Func.FormatNumber_New(VatVND));
                    Func.SetGridTextValue(item, "ltrVatUSD", Func.FormatNumber_New(VatUSD));

                    Func.SetGridTextValue(item, "ltrLastPriceVND", Func.FormatNumber_New(LastPriceVND));
                    Func.SetGridTextValue(item, "ltrLastPriceUSD", Func.FormatNumber_New(LastPriceUSD));

                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }

        protected void rptExtraTime_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            try
            {
                if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
                {
                    DataRowView row = (DataRowView)item.DataItem;

                    string ExtraHour = Func.ParseString(row["ExtraHour"]);
                    string WorkingDate = Func.ParseString(row["WorkingDate"]);

                    string PriceVND = Func.ParseString(row["PriceVND"]);
                    string PriceUSD = Func.ParseString(row["PriceUSD"]);
                    string VatUSD = Func.ParseString(row["VatUSD"]);
                    string VatVND = Func.ParseString(row["VatVND"]);

                    string SumVND = Func.ParseString(row["SumVND"]);
                    string SumUSD = Func.ParseString(row["SumUSD"]);
                    string LastPriceVND = Func.ParseString(row["LastPriceVND"]);
                    string LastPriceUSD = Func.ParseString(row["LastPriceUSD"]);

                    Func.SetGridTextValue(item, "ltrWorkingDate", Func.FormatDMY(WorkingDate));

                    Func.SetGridTextValue(item, "ltrExtraHour", Func.FormatNumber_New(ExtraHour));

                    Func.SetGridTextValue(item, "ltrPriceVND", Func.FormatNumber_New(PriceVND));
                    Func.SetGridTextValue(item, "ltrPriceUSD", Func.FormatNumber_New(PriceUSD));

                    Func.SetGridTextValue(item, "ltrSumVND", Func.FormatNumber_New(SumVND));
                    Func.SetGridTextValue(item, "ltrSumUSD", Func.FormatNumber_New(SumUSD));

                    Func.SetGridTextValue(item, "ltrVatVND", Func.FormatNumber_New(VatVND));
                    Func.SetGridTextValue(item, "ltrVatUSD", Func.FormatNumber_New(VatUSD));

                    Func.SetGridTextValue(item, "ltrLastPriceVND", Func.FormatNumber_New(LastPriceVND));
                    Func.SetGridTextValue(item, "ltrLastPriceUSD", Func.FormatNumber_New(LastPriceUSD));

                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }
        protected void rptService_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            try
            {
                if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
                {
                    DataRowView row = (DataRowView)item.DataItem;

                    //string id = Func.ParseString(row["id"]);
                    string Service = Func.ParseString(row["Service"]);
                    string ServiceDate = Func.ParseString(row["ServiceDate"]);

                    string PriceVND = Func.ParseString(row["PriceVND"]);
                    string PriceUSD = Func.ParseString(row["PriceUSD"]);
                    string VatUSD = Func.ParseString(row["VatUSD"]);
                    string VatVND = Func.ParseString(row["VatVND"]);

                    string Mount = Func.ParseString(row["Mount"]);
                    //string OtherFee02 = Func.ParseString(row["OtherFee02"]);
                    string SumVND = Func.ParseString(row["SumVND"]);
                    string SumUSD = Func.ParseString(row["SumUSD"]);
                    string LastPriceVND = Func.ParseString(row["LastPriceVND"]);
                    string LastPriceUSD = Func.ParseString(row["LastPriceUSD"]);

                    Func.SetGridTextValue(item, "ltrServiceDate", ServiceDate);
                    Func.SetGridTextValue(item, "ltrMount", Mount);

                    Func.SetGridTextValue(item, "ltrService", Service);

                    Func.SetGridTextValue(item, "ltrPriceVND", Func.FormatNumber_New(PriceVND));
                    Func.SetGridTextValue(item, "ltrPriceUSD", Func.FormatNumber_New(PriceUSD));

                    Func.SetGridTextValue(item, "ltrSumVND", Func.FormatNumber_New(SumVND));
                    Func.SetGridTextValue(item, "ltrSumUSD", Func.FormatNumber_New(SumUSD));

                    Func.SetGridTextValue(item, "ltrVatVND", Func.FormatNumber_New(VatVND));
                    Func.SetGridTextValue(item, "ltrVatUSD", Func.FormatNumber_New(VatUSD));

                    Func.SetGridTextValue(item, "ltrLastPriceVND", Func.FormatNumber_New(LastPriceVND));
                    Func.SetGridTextValue(item, "ltrLastPriceUSD", Func.FormatNumber_New(LastPriceUSD));

                    //PopupWidth = 600;
                    //PopupHeight = 450;
                    //LinkPopup((LinkButton)item.FindControl("btnEdit"), editPageName + ".aspx?Action=Edit&Id=" + ContractId);
                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }
        protected void rptElect_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            try
            {
                if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
                {
                    DataRowView row = (DataRowView)item.DataItem;

                    string Name = Func.ParseString(row["RoomName"]);
                    string DateFrom = Func.ParseString(row["DateFrom"]);
                    string DateTo = Func.ParseString(row["DateTo"]);

                    string FromIndex = Func.ParseString(row["FromIndex"]);
                    string ToIndex = Func.ParseString(row["ToIndex"]);
                    string OtherFee01 = Func.ParseString(row["OtherFee01"]);
                    string OtherFee02 = Func.ParseString(row["OtherFee02"]);
                    string Mount = Func.ParseString(row["Mount"]);


                    string PriceVND = Func.ParseString(row["PriceVND"]);
                    string PriceUSD = Func.ParseString(row["PriceUSD"]);
                    string VatUSD = Func.ParseString(row["VatUSD"]);
                    string VatVND = Func.ParseString(row["VatVND"]);

                    string SumVND = Func.ParseString(row["SumVND"]);
                    string SumUSD = Func.ParseString(row["SumUSD"]);
                    string LastPriceVND = Func.ParseString(row["LastPriceVND"]);
                    string LastPriceUSD = Func.ParseString(row["LastPriceUSD"]);
                    string ElecPricePercent = Func.ParseString(row["ElecPricePercent"]);

                    Func.SetGridTextValue(item, "ltrName", Name);

                    Func.SetGridTextValue(item, "ltrDateFrom", Func.FormatDMY(DateFrom));
                    Func.SetGridTextValue(item, "ltrDateTo", Func.FormatDMY(DateTo));

                    Func.SetGridTextValue(item, "ltrFromIndex", Func.FormatNumber_New(FromIndex));
                    Func.SetGridTextValue(item, "ltrToIndex", Func.FormatNumber_New(ToIndex));

                    Func.SetGridTextValue(item, "ltrOtherFee01", Func.FormatNumber_New(OtherFee01));
                    Func.SetGridTextValue(item, "ltrOtherFee02", Func.FormatNumber_New(OtherFee02));
                    Func.SetGridTextValue(item, "ltrElecPricePercent", Func.FormatNumber_New(ElecPricePercent));

                    Func.SetGridTextValue(item, "ltrUsed", "" + (Func.ParseFloat(ToIndex) - Func.ParseFloat(FromIndex)) * Func.ParseFloat(OtherFee01));


                    Func.SetGridTextValue(item, "ltrPriceVND", Func.FormatNumber_New(PriceVND));
                    //Func.SetGridTextValue(item, "ltrPriceUSD", Func.FormatNumber_New(PriceUSD));

                    Func.SetGridTextValue(item, "ltrSumVND", Func.FormatNumber_New(SumVND));
                    //Func.SetGridTextValue(item, "ltrSumUSD", Func.FormatNumber_New(SumUSD));

                    Func.SetGridTextValue(item, "ltrVatVND", Func.FormatNumber_New(VatVND));
                    //Func.SetGridTextValue(item, "ltrVatUSD", VatUSD);

                    Func.SetGridTextValue(item, "ltrLastPriceVND", Func.FormatNumber_New(LastPriceVND));
                    //Func.SetGridTextValue(item, "ltrLastPriceUSD", Func.FormatNumber_New(LastPriceUSD));

                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }
        protected void rptDept_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            try
            {
                if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
                {
                    DataRowView row = (DataRowView)item.DataItem;

                    string YearMonth = Func.ParseString(row["YearMonth"]);
                    Func.SetGridTextValue(item, "ltrYearMonth", Func.ParseString(row["YearMonth"]));
                    Func.SetGridTextValue(item, "ltrSumUSD", Func.ParseString(row["SumUSD"]));
                    Func.SetGridTextValue(item, "ltrSumVND", Func.ParseString(row["SumVND"]));

                    Func.SetGridTextValue(item, "ltrRemainRentUSD", Func.ParseString(row["RemainRentUSD"]));
                    Func.SetGridTextValue(item, "ltrRemainRentVND", Func.ParseString(row["RemainRentVND"]));
                    Func.SetGridTextValue(item, "ltrRemainManagerUSD", Func.ParseString(row["RemainManagerUSD"]));
                    Func.SetGridTextValue(item, "ltrRemainManagerVND", Func.ParseString(row["RemainManagerVND"]));
                    Func.SetGridTextValue(item, "ltrRemainParkingUSD", Func.ParseString(row["RemainParkingUSD"]));
                    Func.SetGridTextValue(item, "ltrRemainParkingVND", Func.ParseString(row["RemainParkingVND"]));
                    Func.SetGridTextValue(item, "ltrRemainExtraTimePriceUSD", Func.ParseString(row["RemainExtraTimePriceUSD"]));
                    Func.SetGridTextValue(item, "ltrRemainExtraTimePriceVND", Func.ParseString(row["RemainExtraTimePriceVND"]));
                    Func.SetGridTextValue(item, "ltrRemainElecUSD", Func.ParseString(row["RemainElecUSD"]));
                    Func.SetGridTextValue(item, "ltrRemainElecVND", Func.ParseString(row["RemainElecVND"]));
                    Func.SetGridTextValue(item, "ltrRemainWaterUSD", Func.ParseString(row["RemainWaterUSD"]));
                    Func.SetGridTextValue(item, "ltrRemainWaterVND", Func.ParseString(row["RemainWaterVND"]));
                    Func.SetGridTextValue(item, "ltrRemainServiceUSD", Func.ParseString(row["RemainServiceUSD"]));
                    Func.SetGridTextValue(item, "ltrRemainServiceVND", Func.ParseString(row["RemainServiceVND"]));
                    Func.SetGridTextValue(item, "ltrSumUSD", Func.ParseString(row["SumUSD"]));
                    Func.SetGridTextValue(item, "ltrSumVND", Func.ParseString(row["SumVND"]));

                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }
        protected void rptWater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            try
            {
                if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
                {
                    DataRowView row = (DataRowView)item.DataItem;

                    string Name = Func.ParseString(row["RoomName"]);
                    string DateFrom = Func.ParseString(row["DateFrom"]);
                    string DateTo = Func.ParseString(row["DateTo"]);

                    string FromIndex = Func.ParseString(row["FromIndex"]);
                    string ToIndex = Func.ParseString(row["ToIndex"]);
                    string OtherFee01 = Func.ParseString(row["OtherFee01"]);
                    string OtherFee02 = Func.ParseString(row["OtherFee02"]);
                    string Mount = Func.ParseString(row["Mount"]);


                    string PriceVND = Func.ParseString(row["PriceVND"]);
                    string PriceUSD = Func.ParseString(row["PriceUSD"]);
                    string VatUSD = Func.ParseString(row["VatUSD"]);
                    string VatVND = Func.ParseString(row["VatVND"]);

                    string SumVND = Func.ParseString(row["SumVND"]);
                    string SumUSD = Func.ParseString(row["SumUSD"]);
                    string LastPriceVND = Func.ParseString(row["LastPriceVND"]);
                    string LastPriceUSD = Func.ParseString(row["LastPriceUSD"]);
                    string WaterPricePercent = Func.ParseString(row["WaterPricePercent"]);

                    Func.SetGridTextValue(item, "ltrName", Name);

                    Func.SetGridTextValue(item, "ltrDateFrom", Func.FormatDMY(DateFrom));
                    Func.SetGridTextValue(item, "ltrDateTo", Func.FormatDMY(DateTo));

                    Func.SetGridTextValue(item, "ltrFromIndex", Func.FormatNumber_New(FromIndex));
                    Func.SetGridTextValue(item, "ltrToIndex", Func.FormatNumber_New(ToIndex));

                    Func.SetGridTextValue(item, "ltrOtherFee01", Func.FormatNumber_New(OtherFee01));
                    Func.SetGridTextValue(item, "ltrOtherFee02", Func.FormatNumber_New(OtherFee02));
                    Func.SetGridTextValue(item, "ltrWaterPricePercent", "" + WaterPricePercent);
                    Func.SetGridTextValue(item, "ltrUsed", Func.FormatNumber_New(Func.ParseFloat(ToIndex) - Func.ParseFloat(FromIndex)));

                    Func.SetGridTextValue(item, "ltrPriceVND", Func.FormatNumber_New(PriceVND));
                    //Func.SetGridTextValue(item, "ltrPriceUSD", Func.FormatNumber_New(PriceUSD));

                    Func.SetGridTextValue(item, "ltrSumVND", Func.FormatNumber_New(SumVND));
                    //Func.SetGridTextValue(item, "ltrSumUSD", Func.FormatNumber_New(SumUSD));

                    Func.SetGridTextValue(item, "ltrVatVND", Func.FormatNumber_New(VatVND));
                    //Func.SetGridTextValue(item, "ltrVatUSD", Func.FormatNumber_New(VatUSD));

                    Func.SetGridTextValue(item, "ltrLastPriceVND", Func.FormatNumber_New(LastPriceVND));
                    //Func.SetGridTextValue(item, "ltrLastPriceUSD", Func.FormatNumber_New(LastPriceUSD));

                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }
        protected void btnViewSum_Click(object sender, EventArgs e)
        {
            ShowData();
        }
        protected void btnSelectYM_Click(object sender, EventArgs e)
        {
            ShowData();
        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            ViewMultiBoth("'" + drpYear.SelectedValue + drpMonth.SelectedValue + "'");
        }
        protected void btnSumMulti_Click(object sender, EventArgs e)
        {
            string lsYearmonth = "";
            foreach (ListItem lstItem in lstSelectedYearMonth.Items)
            {
                lsYearmonth += ",'" + lstItem.Value + "'";

                if (String.Compare(DateTime.Now.ToString("yyyyMMdd"), lstItem.Value) < 0)
                {
                    using (SqlConnection con = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand cm = new SqlCommand("sp_PaymentDetailOneCustomerRentManager", con))
                        {
                            try
                            {
                                cm.CommandType = CommandType.StoredProcedure;
                                cm.Parameters.AddWithValue("@BuildingId", Func.ParseString(Session["__BUILDINGID__"]));
                                cm.Parameters.AddWithValue("@CustomerId", lblCustomerId.Text);
                                cm.Parameters.AddWithValue("@YearMonth", lstItem.Value);
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
                    }
                }
            }
        }

        protected void btnViewMulti_Click(object sender, EventArgs e)
        {
            string lsYearmonth = "";
            foreach (ListItem lstItem in lstSelectedYearMonth.Items)
            {
                lsYearmonth += ",'" + lstItem.Value + "'";
            }
            if (String.IsNullOrEmpty(lsYearmonth))
            {
                mvMessage.AddError("Phải chọn ít nhất 1 tháng");
                return;
            }
            lsYearmonth = lsYearmonth.Substring(1);
            ViewMultiBoth(lsYearmonth);
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        protected void btnRent_Click(object sender, EventArgs e)
        {
            string exchangetype = (txtRentPaidVND.Text.Equals("0")) ? "0" : "1";
            string money = (exchangetype.Equals("0")) ? txtRentPaidUSD.Text : txtRentPaidVND.Text;
            money = money.Replace(".", "");

            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('Payment.aspx?paymenttype=1&id=" + lblCustomerId.Text + "&yearmonth=" + drpYear.SelectedValue + drpMonth.SelectedValue + "&exchangetype=" + exchangetype + "&money=" + money + "',600,370,'Payment', true);", true);
        }
        protected void btnManager_Click(object sender, EventArgs e)
        {
            string exchangetype = (txtManagerPaidVND.Text.Equals("0")) ? "0" : "1";
            string money = (exchangetype.Equals("0")) ? txtManagerPaidUSD.Text : txtManagerPaidVND.Text;
            money = money.Replace(".", "");

            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('Payment.aspx?paymenttype=2&id=" + lblCustomerId.Text + "&yearmonth=" + drpYear.SelectedValue + drpMonth.SelectedValue + "&exchangetype=" + exchangetype + "&money=" + money + "',600,370,'Payment', true);", true);
        }
        protected void btnParking_Click(object sender, EventArgs e)
        {
            string exchangetype = (txtParkingPaidVND.Text.Equals("0")) ? "0" : "1";
            string money = (exchangetype.Equals("0")) ? txtParkingPaidUSD.Text : txtParkingPaidVND.Text;
            money = money.Replace(".", "");

            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('Payment.aspx?paymenttype=3&id=" + lblCustomerId.Text + "&yearmonth=" + drpYear.SelectedValue + drpMonth.SelectedValue + "&exchangetype=" + exchangetype + "&money=" + money + "',600,370,'Payment', true);", true);
        }
        protected void btnExtraTime_Click(object sender, EventArgs e)
        {
            string exchangetype = (txtExtraTimePaidVND.Text.Equals("0")) ? "0" : "1";
            string money = (exchangetype.Equals("0")) ? txtExtraTimePaidUSD.Text : txtExtraTimePaidVND.Text;
            money = money.Replace(".", "");

            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('Payment.aspx?paymenttype=4&id=" + lblCustomerId.Text + "&yearmonth=" + drpYear.SelectedValue + drpMonth.SelectedValue + "&exchangetype=" + exchangetype + "&money=" + money + "',600,370,'Payment', true);", true);
        }
        protected void btnElec_Click(object sender, EventArgs e)
        {
            //string exchangetype = (txtElecPaidVND.Text.Equals("0")) ? "0" : "1";
            string money = txtElecPaidVND.Text.Replace(".", "");
            money = money.Replace(".", "");

            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('Payment.aspx?paymenttype=5&id=" + lblCustomerId.Text + "&yearmonth=" + drpYear.SelectedValue + drpMonth.SelectedValue + "&exchangetype=1&money=" + money + "',600,370,'Payment', true);", true);
        }
        protected void btnWater_Click(object sender, EventArgs e)
        {
            //string exchangetype = (txtWaterPaidVND.Text.Equals("0")) ? "0" : "1";
            string money = txtWaterPaidVND.Text;
            money = money.Replace(".", "");
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('Payment.aspx?paymenttype=6&id=" + lblCustomerId.Text + "&yearmonth=" + drpYear.SelectedValue + drpMonth.SelectedValue + "&exchangetype=1&money=" + money + "',600,370,'Payment', true);", true);
        }
        protected void btnService_Click(object sender, EventArgs e)
        {
            string exchangetype = (txtServicePaidVND.Text.Equals("0")) ? "0" : "1";
            string money = (exchangetype.Equals("0")) ? txtServicePaidUSD.Text : txtServicePaidVND.Text;
            money = money.Replace(".", "");
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('Payment.aspx?paymenttype=7&id=" + lblCustomerId.Text + "&yearmonth=" + drpYear.SelectedValue + drpMonth.SelectedValue + "&exchangetype=" + exchangetype + "&money=" + money + "',600,370,'Payment', true);", true);
        }
        public void mergeCell(int rowFrom, int rowTo, int colFrom, int colTo)
        {
            XLCellRange mergeCell = new XLCellRange(rowFrom, rowTo, colFrom, colTo);
            xlsSheet.MergedCells.Add(mergeCell);
            xlsSheetEn.MergedCells.Add(mergeCell);
        }
        public void setVal(int row, int col, Object val)
        {
            xlsSheet[row, col].Value = val;
            xlsSheetEn[row, col].Value = val;
        }
        public void setStyle(int row, int col, XLStyle style)
        {
            xlsSheet[row, col].Style = style;
            xlsSheetEn[row, col].Style = style;
        }
        public void setHideRow(int row)
        {
            xlsSheet.Rows[row].Height = 0;
            xlsSheetEn.Rows[row].Height = 0;
        }

        public void ViewMultiBoth(string lsYearmonth)
        {
            string[] strTmpYearMonth = lsYearmonth.Split(',');
            string maxYearMonth = "";
            for (int l = 0; l < strTmpYearMonth.Length; l++)
            {
                string tmp = strTmpYearMonth[l];
                if (maxYearMonth == "")
                    maxYearMonth = tmp;
                if (maxYearMonth.CompareTo(tmp) < 0)
                    maxYearMonth = tmp;
            }

            if (String.IsNullOrEmpty(lsYearmonth))
            {
                mvMessage.AddError("Phải chọn ít nhất 1 tháng");
                return;
            }

            int rBillNo = 0;
            int cBillNo = 1;

            int rBillDate = 0;
            int cBillDate = 10;

            int rBillMonth = 2;
            int cBillMonth = 0;

            int rContact = 5;
            int cContact = 3;

            int rCustomer = 5;
            int cCustomer = 7;

            int rContract = 7;
            int cContract = 1;

            //int rRate = 11;
            //int cRate = 9;

            //int rRateDate = 11;
            //int cRateDate = 12;

            int rRent = 15;

            int rManager = 23;

            int rParking = 31;

            int rExtra = 39;

            int rElec = 47;

            int rWater = 55;

            int rService = 63;

            int rPaid = 70;

            int rDept = 77;

            int rOffice = 88;
            int cOffice = 1;

            int rPhone = 89;
            int cPhone = 1;

            int rBank = 88;
            int cBank = 7;

            int rAccountName = 89;
            int cAccountName = 7;

            int rAccount = 90;
            int cAccount = 7;

            int rSum = 81;
            int cSum = 12;

            int rSumVND = 80;
            int cSumVND = 12;

            int rSumRead = 82;

            ArrayList removeRow = new ArrayList();
            ArrayList hideRow = new ArrayList();

            int check = DbHelper.GetCount("Select count(*) from PaymentBillInfo Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + lblCustomerId.Text + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'");
            if (check == 0)
            {
                mvMessage.AddError("Xin vui lòng tạo hóa đơn trước khi xem");
                return;
            }
            mvMessage.CheckRequired(txtBillDate, "Ngày xuất Hóa đơn là danh mục bắt buộc");
            mvMessage.CheckRequired(txtBillNo, "Số Hóa đơn là danh mục bắt buộc");
            mvMessage.CheckRequired(txtUsdExchange, "Tỉ giá USD-VN là danh mục bắt buộc");
            mvMessage.CheckRequired(txtUsdExchangeDate, "Ngày tỉ giá là danh mục bắt buộc");

            xlbBook = new C1XLBook();

            string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\NewBillTongQuat.xlsx");
            if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])));
            }

            XLStyle xlstStyleLeftCH = new XLStyle(xlbBook);
            xlstStyleLeftCH.AlignHorz = XLAlignHorzEnum.Left;
            xlstStyleLeftCH.AlignVert = XLAlignVertEnum.Center;
            xlstStyleLeftCH.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            xlstStyleLeftCH.SetBorderColor(Color.Black);
            xlstStyleLeftCH.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleLeftCH.WordWrap = false;

            XLStyle xlstStyleC = new XLStyle(xlbBook);
            xlstStyleC.AlignHorz = XLAlignHorzEnum.Center;
            xlstStyleC.AlignVert = XLAlignVertEnum.Center;
            xlstStyleC.WordWrap = true;
            xlstStyleC.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            xlstStyleC.SetBorderColor(Color.Black);
            xlstStyleC.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleC.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleC.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleC.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleC.Format = "#,##0.00_);(#,##0.00)";

            XLStyle xlstStyleC2 = new XLStyle(xlbBook);
            xlstStyleC2.AlignHorz = XLAlignHorzEnum.Center;
            xlstStyleC2.AlignVert = XLAlignVertEnum.Center;
            xlstStyleC2.WordWrap = true;
            xlstStyleC2.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            xlstStyleC2.SetBorderColor(Color.Black);
            xlstStyleC2.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleC2.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleC2.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleC2.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleC2.Format = "#,##0.00_);(#,##0.00)";

            XLStyle xlstStyleC1 = new XLStyle(xlbBook);
            xlstStyleC1.AlignHorz = XLAlignHorzEnum.Center;
            xlstStyleC1.AlignVert = XLAlignVertEnum.Center;
            xlstStyleC1.WordWrap = true;
            xlstStyleC1.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            xlstStyleC1.SetBorderColor(Color.Black);
            xlstStyleC1.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleC1.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleC1.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleC1.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleC1.Format = "#,##0.0_);(#,##0.0)";

            XLStyle xlstStyleC0 = new XLStyle(xlbBook);
            xlstStyleC0.AlignHorz = XLAlignHorzEnum.Center;
            xlstStyleC0.AlignVert = XLAlignVertEnum.Center;
            xlstStyleC0.WordWrap = true;
            xlstStyleC0.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            xlstStyleC0.SetBorderColor(Color.Black);
            xlstStyleC0.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleC0.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleC0.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleC0.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleC0.Format = "#,##0_);(#,##0)";

            XLStyle xlstStyleCH = new XLStyle(xlbBook);
            xlstStyleCH.AlignHorz = XLAlignHorzEnum.Center;
            xlstStyleCH.AlignVert = XLAlignVertEnum.Center;
            xlstStyleCH.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            xlstStyleCH.SetBorderColor(Color.Black);
            xlstStyleCH.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleCH.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleCH.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleCH.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleCH.WordWrap = true;

            XLStyle xlstStyleCSum2 = new XLStyle(xlbBook);
            xlstStyleCSum2.AlignHorz = XLAlignHorzEnum.Center;
            xlstStyleCSum2.AlignVert = XLAlignVertEnum.Center;
            xlstStyleCSum2.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            xlstStyleCSum2.SetBorderColor(Color.Black);
            xlstStyleCSum2.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleCSum2.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleCSum2.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleCSum2.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleCSum2.WordWrap = true;
            xlstStyleCSum2.Format = "#,##0.00_);(#,##0.00)";

            XLStyle xlstStyleCSum1 = new XLStyle(xlbBook);
            xlstStyleCSum1.AlignHorz = XLAlignHorzEnum.Center;
            xlstStyleCSum1.AlignVert = XLAlignVertEnum.Center;
            xlstStyleCSum1.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            xlstStyleCSum1.SetBorderColor(Color.Black);
            xlstStyleCSum1.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleCSum1.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleCSum1.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleCSum1.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleCSum1.WordWrap = true;
            xlstStyleCSum1.Format = "#,##0_);(#,##0)";

            XLStyle xlstStyleCSum0 = new XLStyle(xlbBook);
            xlstStyleCSum0.AlignHorz = XLAlignHorzEnum.Center;
            xlstStyleCSum0.AlignVert = XLAlignVertEnum.Center;
            xlstStyleCSum0.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            xlstStyleCSum0.SetBorderColor(Color.Black);
            xlstStyleCSum0.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleCSum0.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleCSum0.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleCSum0.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleCSum0.WordWrap = true;
            xlstStyleCSum0.Format = "#,##0_);(#,##0)";

            XLStyle xlstStyle = new XLStyle(xlbBook);
            xlstStyle.AlignHorz = XLAlignHorzEnum.Center;
            xlstStyle.AlignVert = XLAlignVertEnum.Center;
            xlstStyle.WordWrap = true;
            xlstStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            xlstStyle.SetBorderColor(Color.Black);
            xlstStyle.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyle.BorderTop = XLLineStyleEnum.Thin;
            xlstStyle.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyle.BorderRight = XLLineStyleEnum.Thin;
            xlstStyle.Format = "#,##0.00_);(#,##0.00)";

            XLStyle xlstStyle2 = new XLStyle(xlbBook);
            xlstStyle2.AlignHorz = XLAlignHorzEnum.Right;
            xlstStyle2.AlignVert = XLAlignVertEnum.Center;
            xlstStyle2.WordWrap = true;
            xlstStyle2.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            xlstStyle2.SetBorderColor(Color.Black);
            xlstStyle2.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyle2.BorderTop = XLLineStyleEnum.Thin;
            xlstStyle2.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyle2.BorderRight = XLLineStyleEnum.Thin;
            xlstStyle2.Format = "#,##0.00_);(#,##0.00)";

            XLStyle xlstStyle1 = new XLStyle(xlbBook);
            xlstStyle1.AlignHorz = XLAlignHorzEnum.Right;
            xlstStyle1.AlignVert = XLAlignVertEnum.Center;
            xlstStyle1.WordWrap = true;
            xlstStyle1.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            xlstStyle1.SetBorderColor(Color.Black);
            xlstStyle1.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyle1.BorderTop = XLLineStyleEnum.Thin;
            xlstStyle1.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyle1.BorderRight = XLLineStyleEnum.Thin;
            xlstStyle1.Format = "#,##0.0_);(#,##0.0)";

            XLStyle xlstStyle0 = new XLStyle(xlbBook);
            xlstStyle0.AlignHorz = XLAlignHorzEnum.Right;
            xlstStyle0.AlignVert = XLAlignVertEnum.Center;
            xlstStyle0.WordWrap = true;
            xlstStyle0.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            xlstStyle0.SetBorderColor(Color.Black);
            xlstStyle0.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyle0.BorderTop = XLLineStyleEnum.Thin;
            xlstStyle0.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyle0.BorderRight = XLLineStyleEnum.Thin;
            xlstStyle0.Format = "#,##0_);(#,##0)";

            XLStyle xlstStyleH = new XLStyle(xlbBook);
            xlstStyleH.AlignHorz = XLAlignHorzEnum.Center;
            xlstStyleH.AlignVert = XLAlignVertEnum.Center;
            xlstStyleH.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            xlstStyleH.SetBorderColor(Color.Black);
            xlstStyleH.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleH.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleH.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleH.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleH.WordWrap = true;

            XLStyle xlstStyleSum2 = new XLStyle(xlbBook);
            xlstStyleSum2.AlignHorz = XLAlignHorzEnum.Right;
            xlstStyleSum2.AlignVert = XLAlignVertEnum.Center;
            xlstStyleSum2.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            xlstStyleSum2.SetBorderColor(Color.Black);
            xlstStyleSum2.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleSum2.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleSum2.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleSum2.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleSum2.WordWrap = true;
            xlstStyleSum2.Format = "#,##0.00_);(#,##0.00)";

            XLStyle xlstStyleSum1 = new XLStyle(xlbBook);
            xlstStyleSum1.AlignHorz = XLAlignHorzEnum.Right;
            xlstStyleSum1.AlignVert = XLAlignVertEnum.Center;
            xlstStyleSum1.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            xlstStyleSum1.SetBorderColor(Color.Black);
            xlstStyleSum1.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleSum1.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleSum1.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleSum1.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleSum1.WordWrap = true;
            xlstStyleSum1.Format = "#,##0_);(#,##0)";

            XLStyle xlstStyleSum0 = new XLStyle(xlbBook);
            xlstStyleSum0.AlignHorz = XLAlignHorzEnum.Right;
            xlstStyleSum0.AlignVert = XLAlignVertEnum.Center;
            xlstStyleSum0.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            xlstStyleSum0.SetBorderColor(Color.Black);
            xlstStyleSum0.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleSum0.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleSum0.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleSum0.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleSum0.WordWrap = true;
            xlstStyleSum0.Format = "#,##0_);(#,##0)";

            if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\Bill"))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\Bill"));
            }

            string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\Bill\Bill_" + lblCustomerId.Text + "_" + strDT + ".xlsx";
            string strFilePathExport = @"../../Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + @"/Bill/Bill_" + lblCustomerId.Text + "_" + strDT + ".xlsx";

            string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

            File.Copy(fileName, fileNameDes);

            xlbBook.Load(fileNameDes);
            xlsSheet = xlbBook.Sheets["TongHop"];
            xlsSheetEn = xlbBook.Sheets["TongHop_En"];

            //Bill No
            setVal(rBillNo, cBillNo, xlsSheet[rBillNo, cBillNo].Value.ToString().Replace("{%BILL_NO%}", txtBillNo.Text));

            //Ngay Thang Nam
            DateTime dtime = DateTime.Today;

            string strTmp = xlsSheet[rBillDate, cBillDate].Value.ToString().Replace("{%NGAY%}", dtime.ToString("dd"));
            strTmp = strTmp.Replace("{%THANG%}", dtime.ToString("MM"));
            setVal(rBillDate, cBillDate, strTmp.Replace("{%NAM%}", dtime.ToString("yyyy")));

            //Nam
            setVal(rBillMonth, cBillMonth, xlsSheet[rBillMonth, cBillMonth].Value.ToString().Replace("{%NAM_THANG%}", drpMonth.SelectedValue + "/" + drpYear.SelectedValue));

            using (SqlDatabase db = new SqlDatabase())
            {
                DataSet ds = new DataSet();
                string sql = string.Empty;

                sql = " SELECT Name, ContactName";
                sql += " FROM Customer";
                sql += " WHERE CustomerId = '" + lblCustomerId.Text + "' ";

                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);

                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            string Name = rowType[0].ToString();
                            string ContactName = rowType[1].ToString();

                            //Customer
                            setVal(rCustomer, cCustomer, xlsSheet[rCustomer, cCustomer].Value.ToString().Replace("{%TEN_CONG_TY%}", Name));
                            //Contact
                            setVal(rContact, cContact, xlsSheet[rContact, cContact].Value.ToString().Replace("{%NGUOI_DAI_DIEN%}", ContactName));
                        }
                    }
                }
                Hashtable contractIdLst = new Hashtable();
                string contract = "";
                ds = new DataSet();
                sql = " SELECT Bank,Account,AccountName,Office,OfficeAddress,OfficePhone";
                sql += " FROM Mst_Building";
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' ";
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);

                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            string Bank = rowType["Bank"].ToString();
                            string Account = rowType["Account"].ToString();
                            string AccountName = rowType["AccountName"].ToString();
                            string Office = rowType["Office"].ToString();
                            string OfficeAddress = rowType["OfficeAddress"].ToString();
                            string OfficePhone = rowType["OfficePhone"].ToString();

                            setVal(rOffice, 2, Office);
                            setVal(rPhone, 2,  OfficePhone);

                            setVal(rBank, 10,  Bank);
                            setVal(rAccountName, 10,  AccountName);
                            setVal(rAccount, 10,  Account);

                        }
                    }
                }

                //setVal(rRate, cRate,  xlsSheet[rRate, cRate].Value.ToString().Replace("{%TI_GIA%}", Func.FormatNumber_New(txtUsdExchange.Text)));
                //setVal(rRateDate, cRateDate,  xlsSheet[rRateDate, cRateDate].Value.ToString().Replace("{%NGAY_AP_DUNG%}", txtUsdExchangeDate.Text));


                //Thue phong
                ds = new DataSet();
                sql = " Select A.*, B.ContractDate";
                sql += " FROM PaymentRoom A, RentContract B";
                sql += " WHERE A.ContractId = B.ContractId and A.BuildingId = B.BuildingId and A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and A.YearMonth in (" + lsYearmonth + ")";
                sql += " and A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and A.YearMonth in (" + lsYearmonth + ")";

                int sumRow = 0;
                int j = 0;
                decimal[] LastSumPriceVND = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };
                decimal[] LastSumPriceUSD = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };

                decimal PaidPriceVND = 0;
                decimal PaidPriceUSD = 0;

                int viewNumber = 1;
                string strSum = "";

                int line = 0;
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);

                    line = rRent - 3 + j;

                    removeRow.Add(line + 2);

                    mergeCell(line, line + 1, 1, 3);
                    mergeCell(line, line, 4, 5);
                    mergeCell(line + 1, line + 1, 4, 5);
                    mergeCell(line + 2, line + 2, 4, 5);
                    mergeCell(line, line, 6, 7);
                    mergeCell(line + 1, line + 1, 6, 7);
                    mergeCell(line, line, 8, 9);
                    mergeCell(line + 1, line + 1, 8, 9);
                    mergeCell(line, line, 10, 11);
                    mergeCell(line + 1, line + 1, 10, 11);
                    mergeCell(line, line, 12, 13);
                    mergeCell(line + 1, line + 1, 12, 13);

                    if (ds != null)
                    {
                        int count = 0;
                        DataTable dt = ds.Tables[0];
                        int k = 0;
                        if (dt.Rows.Count <= 0)
                        {
                            for (int rHideLine = 0; rHideLine < 13; rHideLine++)
                            {
                                setHideRow(rHideLine + line - 1);
                            }
                        }
                        else
                        {
                            setVal(line - 1, 0, viewNumber + ".");
                            strSum += viewNumber + " + ";

                            viewNumber++;

                            foreach (DataRow rowType in dt.Rows)
                            {
                                decimal tmp02 = Convert.ToDecimal(rowType["LastRentSumVND"]);

                                string ContractId = Func.ParseString(rowType["ContractId"]);
                                string ContractNo = Func.ParseString(rowType["ContractNo"]);
                                string YearMonth = Func.ParseString(rowType["YearMonth"]);
                                string Area = Func.ParseString(rowType["Area"]);
                                string Name = Func.ParseString(rowType["Name"]);
                                string Regional = Func.ParseString(rowType["Regional"]);
                                string Floor = Func.ParseString(rowType["Floor"]);
                                string BeginContract = Func.ParseString(rowType["ContractDate"]);

                                if (!contractIdLst.ContainsKey(ContractId + "(" + Func.FormatDMY(BeginContract) + ")"))
                                {
                                    contractIdLst.Add(ContractId + "(" + Func.FormatDMY(BeginContract) + ")", ContractNo + "(" + Func.FormatDMY(BeginContract) + ")");
                                    contract += ";" + ContractNo + "(" + Func.FormatDMY(BeginContract) + ")";
                                }
                                if (tmp02 > 0)
                                {

                                    if (count >= 1)
                                    {
                                        xlsSheet.Rows.Insert(rRent + 1 + j);
                                        xlsSheetEn.Rows.Insert(rRent + 1 + j);
                                        j++;
                                    }
                                    count++;
                                    int tmp = rRent + j;
                                    setVal(tmp, 1, YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4));
                                    setVal(tmp, 4, rowType["Area"]);
                                    setVal(tmp, 6, rowType["MonthRentPriceVND"]);
                                    setVal(tmp, 8, rowType["MonthRentSumVND"]);
                                    setVal(tmp, 10, rowType["VatRentPriceVND"]);
                                    setVal(tmp, 12, rowType["LastRentSumVND"]);

                                    mergeCell(tmp, tmp, 1, 3);
                                    mergeCell(tmp, tmp, 4, 5);
                                    mergeCell(tmp, tmp, 6, 7);
                                    mergeCell(tmp, tmp, 8, 9);
                                    mergeCell(tmp, tmp, 10, 11);
                                    mergeCell(tmp, tmp, 12, 13);
                                    
                                    mergeCell(tmp, tmp, 1, 3);
                                    mergeCell(tmp, tmp, 4, 5);

                                    for (int col = 1; col <= 13; col++)
                                    {
                                        setStyle(tmp, col, xlstStyle);
                                        
                                    }

                                    setStyle(tmp, 4, xlstStyleC1);
                                    setStyle(tmp, 6, xlstStyle0);
                                    setStyle(tmp, 8, xlstStyle0);
                                    setStyle(tmp, 10, xlstStyle0);
                                    setStyle(tmp, 12, xlstStyle0);

                                    LastSumPriceVND[0] += Convert.ToDecimal(rowType["LastRentSumVND"]);
                                }
                                else
                                {
                                    k++;
                                }
                            }
                            mergeCell(rRent + 1 + j, rRent + 1 + j, 1, 11);

                            setVal(rRent + 1 + j, 12, LastSumPriceVND[0]);

                            mergeCell(rRent + 1 + j, rRent + 1 + j, 12, 13);

                            //Format
                            setStyle(rRent + 1 + j, 12, xlstStyleSum1);
                            setStyle(rRent + 1 + j, 13, xlstStyleSum0);

                            sumRow += dt.Rows.Count - 1 - k;

                            //Phi quan ly
                            line = rManager - 3 + j;
                            setVal(line - 1, 0, viewNumber + ".");
                            strSum += viewNumber + " + ";

                            viewNumber++;

                            removeRow.Add(line + 2);

                            mergeCell(line, line + 1, 1, 3);
                            mergeCell(line, line, 4, 5);
                            mergeCell(line + 1, line + 1, 4, 5);
                            mergeCell(line + 2, line + 2, 4, 5);
                            mergeCell(line, line, 6, 7);
                            mergeCell(line + 1, line + 1, 6, 7);
                            mergeCell(line, line, 8, 9);
                            mergeCell(line + 1, line + 1, 8, 9);

                            mergeCell(line, line, 10, 11);
                            mergeCell(line + 1, line + 1, 10, 11);
                            mergeCell(line, line, 12, 13);
                            mergeCell(line + 1, line + 1, 12, 13);

                            ////En
                            k = 0;
                            count = 0;
                            foreach (DataRow row in dt.Rows)
                            {
                                decimal tmp02 = Convert.ToDecimal(row["LastManagerSumVND"]);

                                if (tmp02 > 0)
                                {

                                    if (count >= 1)
                                    {
                                        xlsSheet.Rows.Insert(rManager + 1 + j);
                                        xlsSheetEn.Rows.Insert(rManager + 1 + j);
                                        j++;
                                    }
                                    count++;
                                    int tmp = rManager + j;

                                    string YearMonth = Func.ParseString(row["YearMonth"]);
                                    string Area = Func.ParseString(row["Area"]);
                                    string Name = Func.ParseString(row["Name"]);

                                    setVal(tmp, 1, YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4));
                                    setVal(tmp, 4, row["Area"]);
                                    setVal(tmp, 6, row["MonthManagerPriceVND"]);

                                    setVal(tmp, 8, row["MonthManagerSumVND"]);

                                    setVal(tmp, 10, row["VatManagerPriceVND"]);

                                    setVal(tmp, 12, row["LastManagerSumVND"]);

                                    mergeCell(tmp, tmp, 1, 3);
                                    mergeCell(tmp, tmp, 4, 5);

                                    

                                    for (int col = 1; col <= 13; col++)
                                    {
                                        setStyle(tmp, col, xlstStyle);
                                    }
                                    setStyle(tmp, 4, xlstStyleC1);
                                    setStyle(tmp, 6, xlstStyle0);
                                    setStyle(tmp, 8, xlstStyle0);
                                    setStyle(tmp, 10, xlstStyle0);
                                    setStyle(tmp, 12, xlstStyle0);

                                    mergeCell(tmp, tmp, 1, 3);
                                    mergeCell(tmp, tmp, 4, 5);
                                    mergeCell(tmp, tmp, 6, 7);
                                    mergeCell(tmp, tmp, 8, 9);
                                    mergeCell(tmp, tmp, 10, 11);
                                    mergeCell(tmp, tmp, 12, 13);
                                    
                                    LastSumPriceVND[1] += Convert.ToDecimal(row["LastManagerSumVND"]);
                                }
                                else { k++; }
                            }
                            mergeCell(rManager + 1 + j, rManager + 1 + j, 1, 11);

                            setVal(rManager + 1 + j, 12, LastSumPriceVND[1]);

                            mergeCell(rManager + 1 + j, rManager + 1 + j, 12, 13);

                            setStyle(rManager + 1 + j, 12, xlstStyleSum0);

                            sumRow += dt.Rows.Count - 1 - k;
                        }
                    }
                    else
                    {
                        for (int rRentLine = 0; rRentLine < 15; rRentLine++)
                        {
                            setHideRow(rRentLine + rRent - 4 + line);
                        }
                    }
                }


                ds = new DataSet();
                //Xuất ra toàn bộ nội dung theo Trang
                sql = " SELECT COUNT(*) AS Num, YearMonth, TariffsParkingName, PriceVND, PriceUSD, SUM(VatVND) AS VatVND,SUM(VatUSD) AS VatUSD, SUM(SumVND) AS SumVND, SUM(SumUSD) AS SumUSD, SUM(LastPriceVND) AS LastPriceVND";
                sql += "        , SUM(LastPriceUSD) AS LastPriceUSD";
                sql += " FROM         dbo.PaymentParking";
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth in (" + lsYearmonth + ")";

                sql += " GROUP BY YearMonth, TariffsParkingName, PriceVND, PriceUSD, Vat, daysParking";
                sql += " HAVING (SUM(LastPriceVND) >0 or SUM(LastPriceUSD) >0)";
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);

                    line = rParking - 3 + j;
                    removeRow.Add(line + 2);

                    mergeCell(line, line + 1, 1, 3);
                    mergeCell(line, line, 4, 5);
                    mergeCell(line + 1, line + 1, 4, 5);
                    mergeCell(line + 2, line + 2, 4, 5);
                    mergeCell(line, line, 6, 7);
                    mergeCell(line + 1, line + 1, 6, 7);
                    mergeCell(line, line, 8, 9);
                    mergeCell(line + 1, line + 1, 8, 9);
                    mergeCell(line, line, 10, 11);
                    mergeCell(line + 1, line + 1, 10, 11);
                    mergeCell(line, line, 12, 13);
                    mergeCell(line + 1, line + 1, 12, 13);
                    if (ds != null)
                    {
                        int count = 0;
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            setVal(line - 1, 0, viewNumber + ".");
                            strSum += viewNumber + " + ";

                            viewNumber++;

                            foreach (DataRow row in dt.Rows)
                            {
                                if (count >= 1)
                                {
                                    xlsSheet.Rows.Insert(rParking + 1 + j);
                                    xlsSheetEn.Rows.Insert(rParking + 1 + j);
                                    j++;
                                }
                                count++;
                                int tmp = rParking + j;

                                string Num = Func.ParseString(row["Num"]);
                                string TariffsParkingName = Func.ParseString(row["TariffsParkingName"]);
                                // Phi gui xe
                                setVal(tmp, 1, TariffsParkingName);
                                setVal(tmp, 4, Num);
                                setVal(tmp, 6, row["PriceVND"]);
                                setVal(tmp, 8, row["SumVND"]);
                                setVal(tmp, 10, row["VatVND"]);
                                setVal(tmp, 12, row["LastPriceVND"]);

                                mergeCell(tmp, tmp, 1, 3);
                                mergeCell(tmp, tmp, 4, 5);

                                for (int col = 1; col <= 13; col++)
                                {
                                    setStyle(tmp, col, xlstStyle);
                                }
                                setStyle(tmp, 4, xlstStyleC1);
                                setStyle(tmp, 5, xlstStyleC1);
                                setStyle(tmp, 6, xlstStyle0);
                                setStyle(tmp, 8, xlstStyle0);
                                setStyle(tmp, 10, xlstStyle0);
                                setStyle(tmp, 12, xlstStyle0);

                                mergeCell(tmp, tmp, 1, 3);
                                mergeCell(tmp, tmp, 4, 5);
                                mergeCell(tmp, tmp, 6, 7);
                                mergeCell(tmp, tmp, 8, 9);
                                mergeCell(tmp, tmp, 10, 11);
                                mergeCell(tmp, tmp, 12, 13);

                                LastSumPriceVND[2] += Convert.ToDecimal(row["LastPriceVND"]);
                            }
                            setVal(rParking + 1 + j, 12, LastSumPriceVND[2]);

                            mergeCell(rParking + 1 + j, rParking + 1 + j, 1, 11);
                            mergeCell(rParking + 1 + j, rParking + 1 + j, 12, 13);

                            setStyle(rParking + 1 + j, 12, xlstStyleSum0);
                            mergeCell(rParking + 1 + j, rParking + 1 + j, 1, 11);

                            sumRow += dt.Rows.Count - 1;
                        }
                        else
                        {
                            for (int rHideLine = 0; rHideLine < 6; rHideLine++)
                            {
                                setHideRow(rHideLine + line - 1);
                            }
                        }
                    }
                }

                ds = new DataSet();
                sql = "SELECT id";
                sql += " ,YearMonth,BuildingId,CustomerId,RoomId,ExtraHour,VAT,OtherFee01,OtherFee02";
                sql += " ,PriceUSD,PriceVND,VatUSD,VatVND,SumUSD,SumVND,IsNull(LastPriceUSD,0) LastPriceUSD      ,IsNull(LastPriceVND,0) LastPriceVND ";
                sql += " ,RentArea,dbo.fnDateTime(FromWD) BeginDate,dbo.fnDateTime(EndWD) EndDate,ExtratimeType";
                sql += " FROM PaymentExtraTimeMonth";
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth in (" + lsYearmonth + ")";

                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    line = rExtra - 3 + j;
                    removeRow.Add(line + 2);

                    //Phi dien
                    mergeCell(line, line + 1, 1, 2);
                    mergeCell(line, line + 1, 4, 4);
                    mergeCell(line, line, 6, 7);
                    mergeCell(line + 1, line + 1, 6, 7);
                    mergeCell(line, line, 8, 9);
                    mergeCell(line + 1, line + 1, 8, 9);
                    mergeCell(line, line, 10, 11);
                    mergeCell(line + 1, line + 1, 10, 11);
                    mergeCell(line, line, 12, 13);
                    mergeCell(line + 1, line + 1, 12, 13);
                    /////En
                    if (ds != null)
                    {
                        int count = 0;
                        DataTable dt = ds.Tables[0];

                        if (dt.Rows.Count > 0)
                        {
                            setVal(line - 1, 0, viewNumber + ".");
                            strSum += viewNumber + " + ";

                            viewNumber++;

                            foreach (DataRow row in dt.Rows)
                            {
                                if (count >= 1)
                                {
                                    xlsSheet.Rows.Insert(rExtra + 1 + j);
                                    xlsSheetEn.Rows.Insert(rExtra + 1 + j);
                                    j++;
                                }
                                count++;
                                int tmp = rExtra + j;

                                string ExtraHour = Func.ParseString(row["ExtraHour"]);
                                string BeginDate = Func.ParseString(row["BeginDate"]);
                                string EndDate = Func.ParseString(row["EndDate"]);

                                string ExtratimeType = Func.ParseString(row["ExtratimeType"]);

                                setVal(tmp, 1, BeginDate + "~" + EndDate);
                                setVal(tmp, 3, row["RentArea"]);
                                setVal(tmp, 5, ExtraHour);

                                setVal(tmp, 4, "Diện tích");
                                if ("0".Equals(ExtratimeType))
                                {
                                    setVal(tmp, 4, "m2*h");
                                }
                                setVal(tmp, 7, row["PriceVND"]);
                                setVal(tmp, 9, row["SumVND"]);
                                setVal(tmp, 11, row["VatVND"]);
                                setVal(tmp, 13, row["LastPriceVND"]);
                                LastSumPriceVND[3] += Convert.ToDecimal(row["LastPriceVND"]);

                                mergeCell(tmp, tmp, 1, 2);

                                for (int col = 1; col <= 13; col++)
                                {
                                    setStyle(tmp, col, xlstStyle);
                                }
                                
                                /////////////////////
                                setStyle(tmp, 4, xlstStyleC1);
                                setStyle(tmp, 5, xlstStyleC1);
                                setStyle(tmp, 6, xlstStyle1);
                                setStyle(tmp, 7, xlstStyle0);
                                setStyle(tmp, 8, xlstStyle1);
                                setStyle(tmp, 9, xlstStyle0);
                                setStyle(tmp, 10, xlstStyle1);
                                setStyle(tmp, 11, xlstStyle0);
                                setStyle(tmp, 12, xlstStyle1);
                                setStyle(tmp, 13, xlstStyle0);

                                mergeCell(tmp, tmp, 1, 3);
                                mergeCell(tmp, tmp, 6, 7);
                                mergeCell(tmp, tmp, 8, 9);
                                mergeCell(tmp, tmp, 10, 11);
                                mergeCell(tmp, tmp, 12, 13);
                            }
                        }
                        else
                        {
                            for (int rHideLine = 0; rHideLine < 6; rHideLine++)
                            {
                                setHideRow(rHideLine + line - 1);
                            }
                        }
                        mergeCell(rExtra + 1 + j, rExtra + 1 + j, 1, 11);

                        setVal(rExtra + 1 + j, 13, LastSumPriceVND[3]);
                        mergeCell(rExtra + 1 + j, rExtra + 1 + j, 12, 13);

                        setStyle(rExtra + 1 + j, 12, xlstStyleSum1);
                        setStyle(rExtra + 1 + j, 13, xlstStyleSum0);

                        sumRow += dt.Rows.Count - 1;
                    }
                }

                ds = new DataSet();
                //Dien
                //Xuất ra toàn bộ nội dung theo Trang
                sql = " SELECT dbo.fnDateTime(A.DateFrom) DateFrom, dbo.fnDateTime(A.DateTo) DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVND, B.PriceUSD, B.SumVND, B.SumUSD, ";
                sql += "        B.VatVND, B.VatUSD ,IsNull(B.LastPriceUSD,0) LastPriceUSD      ,IsNull(B.LastPriceVND,0) LastPriceVND , B.Name, B.WaterPricePercent,B.ElecPricePercent ";
                sql += " FROM   PaymentElecWater AS A INNER JOIN ";
                sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId";
                sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfWaterId = 0  and A.YearMonth in (" + lsYearmonth + ")  and B.DetailType = 1";
                sql += " Order by A.DateFrom, B.FromIndex";

                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);

                    line = rElec - 3 + j;
                    removeRow.Add(line + 2);

                    //Phi dien
                    mergeCell(line, line + 1, 1, 1);
                    mergeCell(line, line + 1, 2, 2);
                    mergeCell(line, line + 1, 12, 13);
                    /////En

                    for (int col = 1; col < 13; col++)
                    {
                        setStyle(line, col, xlstStyleH);
                        setStyle(line + 1, col, xlstStyleH);
                        setStyle(line + 2, col, xlstStyleH);
                    }

                    if (ds != null)
                    {
                        int count = 0;
                        DataTable dt = ds.Tables[0];

                        if (dt.Rows.Count > 0)
                        {
                            setVal(line - 1, 0, viewNumber + ".");
                            strSum += viewNumber + " + ";

                            viewNumber++;

                            foreach (DataRow row in dt.Rows)
                            {
                                if (count >= 1)
                                {
                                    xlsSheet.Rows.Insert(rElec + 1 + j);
                                    xlsSheetEn.Rows.Insert(rElec + 1 + j);
                                    j++;

                                }
                                count++;
                                int tmp = rElec + j;

                                string DateFrom = Func.ParseString(row["DateFrom"]);
                                string DateTo = Func.ParseString(row["DateTo"]);

                                string FromIndex = Func.ParseString(row["FromIndex"]);
                                string ToIndex = Func.ParseString(row["ToIndex"]);
                                string OtherFee01 = Func.ParseString(row["OtherFee01"]);
                                string OtherFee02 = Func.ParseString(row["OtherFee02"]);
                                string Mount = Func.ParseString(row["Mount"]);
                                string ElecPricePercent = Func.ParseString(row["ElecPricePercent"]);

                                setVal(tmp, 1, DateFrom);
                                setVal(tmp, 2, DateTo);
                                setVal(tmp, 3, FromIndex);
                                setVal(tmp, 4, ToIndex);
                                setVal(tmp, 5, row["OtherFee01"]);
                                setVal(tmp, 6, Mount);
                                setVal(tmp, 7, row["PriceVND"]);
                                setVal(tmp, 8, row["VatVND"]);

                                setVal(tmp, 9, row["SumVND"]);
                                setVal(tmp, 10, row["OtherFee02"]);
                                setVal(tmp, 11, row["ElecPricePercent"]);
                                setVal(tmp, 12, row["LastPriceVND"]);

                                mergeCell(tmp, tmp, 12, 13);
                                for (int col = 1; col <= 13; col++)
                                {
                                    setStyle(tmp, col, xlstStyle);
                                }

                                /////////////////
                                setStyle(tmp, 3, xlstStyleC2);
                                setStyle(tmp, 4, xlstStyleC2);
                                setStyle(tmp, 5, xlstStyleC0);
                                setStyle(tmp, 6, xlstStyle2);
                                setStyle(tmp, 7, xlstStyle0);
                                setStyle(tmp, 8, xlstStyle0);
                                setStyle(tmp, 9, xlstStyle0);
                                setStyle(tmp, 10, xlstStyle0);
                                setStyle(tmp, 11, xlstStyle2);
                                setStyle(tmp, 12, xlstStyle0);
                            }
                            DataSet dsSum = new DataSet();
                            //Dien
                            //Xuất ra toàn bộ nội dung theo Trang
                            string sqlSum = " SELECT IsNull(A.LastPriceUSD,0) LastPriceUSD      ,IsNull(A.LastPriceVND,0) LastPriceVND  ";
                            sqlSum += " FROM   PaymentElecWater AS A ";
                            sqlSum += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfElecId > 0  and A.YearMonth in (" + lsYearmonth + ")  and A.DetailType = 1";
                            using (SqlCommand cmSum = db.CreateCommand(sqlSum))
                            {
                                SqlDataAdapter daSum = new SqlDataAdapter(cmSum);
                                daSum.Fill(dsSum);


                                if (daSum != null)
                                {
                                    DataTable dtSum = dsSum.Tables[0];
                                    if (dtSum.Rows.Count > 0)
                                    {
                                        foreach (DataRow row in dtSum.Rows)
                                        {
                                            LastSumPriceUSD[4] += Convert.ToDecimal(row["LastPriceUSD"]);
                                            LastSumPriceVND[4] += Convert.ToDecimal(row["LastPriceVND"]);
                                        }
                                    }
                                }
                            }

                            ///////////////////////////
                            setVal(rElec + 1 + j, 12, Decimal.Round(LastSumPriceVND[4], 0));
                            mergeCell(rElec + 1 + j, rElec + 1 + j, 1, 11);
                            mergeCell(rElec + 1 + j, rElec + 1 + j, 12, 13);
                            ////
                            setStyle(rElec + 1 + j, 12, xlstStyleSum0);
                            mergeCell(rElec + 1 + j, rElec + 1 + j, 1, 11);
                            mergeCell(rElec + 1 + j, rElec + 1 + j, 12, 13);

                            sumRow += dt.Rows.Count - 1;
                        }
                        else
                        {
                            for (int rHideLine = 0; rHideLine < 6; rHideLine++)
                            {
                                setHideRow(rHideLine + line - 1);
                            }
                        }
                    }
                }

                ds = new DataSet();
                //Phi Nuoc
                //Xuất ra toàn bộ nội dung theo Trang
                sql = " SELECT dbo.fnDateTime(A.DateFrom) DateFrom, dbo.fnDateTime(A.DateTo) DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVND, B.PriceUSD, B.SumVND, B.SumUSD, ";
                sql += "        B.VatVND, B.VatUSD,IsNull(B.LastPriceUSD,0) LastPriceUSD,IsNull(B.LastPriceVND,0) LastPriceVND, B.Name, B.WaterPricePercent,B.ElecPricePercent  ";
                sql += " FROM   PaymentElecWater AS A INNER JOIN ";
                sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId";
                sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfElecId = 0 and A.YearMonth in (" + lsYearmonth + ")  and B.DetailType = 2";
                sql += " Order by A.DateFrom, B.FromIndex";

                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    line = rWater - 3 + j;
                    removeRow.Add(line + 2);

                    //Phi nuoc
                    mergeCell(line, line + 1, 1, 1);
                    mergeCell(line, line + 1, 2, 2);
                    mergeCell(line, line + 1, 12, 13);

                    for (int col = 1; col < 13; col++)
                    {
                        setStyle(line, col, xlstStyleH);
                        setStyle(line + 1, col, xlstStyleH);
                        setStyle(line + 2, col, xlstStyleH);

                    }

                    for (int col = 1; col < 13; col++)
                    {
                        setStyle(line, col, xlstStyleH);
                        setStyle(line + 1, col, xlstStyleH);
                        setStyle(line + 2, col, xlstStyleH);
                    }

                    if (ds != null)
                    {
                        int count = 0;
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            setVal(line - 1, 0, viewNumber + ".");
                            strSum += viewNumber + " + ";

                            viewNumber++;

                            foreach (DataRow row in dt.Rows)
                            {
                                if (count >= 1)
                                {
                                    xlsSheet.Rows.Insert(rWater + 1 + j);
                                    xlsSheetEn.Rows.Insert(rWater + 1 + j);
                                    j++;
                                }
                                count++;
                                int tmp = rWater + j;

                                string DateFrom = Func.ParseString(row["DateFrom"]);
                                string DateTo = Func.ParseString(row["DateTo"]);

                                string FromIndex = Func.ParseString(row["FromIndex"]);
                                string ToIndex = Func.ParseString(row["ToIndex"]);
                                string OtherFee01 = Func.ParseString(row["OtherFee01"]);
                                string OtherFee02 = Func.ParseString(row["OtherFee02"]);
                                string Mount = Func.ParseString(row["Mount"]);

                                setVal(tmp, 1, DateFrom);
                                setVal(tmp, 2, DateTo);
                                setVal(tmp, 3, FromIndex);
                                setVal(tmp, 4, ToIndex);
                                setVal(tmp, 5, Mount);
                                setVal(tmp, 6, row["PriceVND"]);
                                setVal(tmp, 7, row["OtherFee01"]);
                                setVal(tmp, 8, row["VatVND"]);

                                setVal(tmp, 9, row["SumVND"]);
                                setVal(tmp, 10, row["OtherFee02"]);
                                setVal(tmp, 11, row["WaterPricePercent"]);
                                setVal(tmp, 12, row["LastPriceVND"]);
                                for (int col = 1; col <= 13; col++)
                                {
                                    setStyle(tmp, col, xlstStyle);
                                }

                                setStyle(tmp, 3, xlstStyleC2);
                                setStyle(tmp, 4, xlstStyleC2);
                                setStyle(tmp, 5, xlstStyleC2);
                                setStyle(tmp, 6, xlstStyle0);
                                setStyle(tmp, 7, xlstStyle0);
                                setStyle(tmp, 8, xlstStyle0);
                                setStyle(tmp, 9, xlstStyle0);
                                setStyle(tmp, 10, xlstStyle2);
                                setStyle(tmp, 11, xlstStyle2);
                                setStyle(tmp, 12, xlstStyle0);

                                mergeCell(tmp, tmp, 12, 13);
                            }

                            DataSet dsSum = new DataSet();
                            //Nuoc
                            //Xuất ra toàn bộ nội dung theo Trang
                            string sqlSum = " SELECT IsNull(A.LastPriceUSD,0) LastPriceUSD      ,IsNull(A.LastPriceVND,0) LastPriceVND  ";
                            sqlSum += " FROM   PaymentElecWater AS A ";
                            sqlSum += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfWaterId > 0  and A.YearMonth in (" + lsYearmonth + ")  and A.DetailType = 2";
                            using (SqlCommand cmSum = db.CreateCommand(sqlSum))
                            {
                                SqlDataAdapter daSum = new SqlDataAdapter(cmSum);
                                daSum.Fill(dsSum);
                                if (daSum != null)
                                {
                                    DataTable dtSum = dsSum.Tables[0];
                                    if (dtSum.Rows.Count > 0)
                                    {
                                        foreach (DataRow row in dtSum.Rows)
                                        {
                                            LastSumPriceVND[5] += Convert.ToDecimal(row["LastPriceVND"]);
                                        }
                                    }
                                }
                            }
                            setVal(rWater + 1 + j, 12, Decimal.Round(LastSumPriceVND[5], 0));
                            mergeCell(rWater + 1 + j, rWater + 1 + j, 1, 11);
                            mergeCell(rWater + 1 + j, rWater + 1 + j, 12, 13);

                            setStyle(rWater + 1 + j, 12, xlstStyleSum0);
                            sumRow += dt.Rows.Count - 1;
                        }
                        else
                        {
                            for (int rHideLine = 0; rHideLine < 6; rHideLine++)
                            {
                                setHideRow(rHideLine + line - 1);
                            }
                        }
                    }
                }

                //Service
                ds = new DataSet();

                sql = string.Empty;
                sql = " SELECT Service,dbo.fnDateTime(ServiceDateFrom) ServiceDateFrom,dbo.fnDateTime(ServiceDateTo) ServiceDateTo,PriceVND,PriceUSD,VatUSD,VatVND,Mount,Unit,SumVND,SumUSD,isnull(LastPriceVND,0) LastPriceVND,isnull(LastPriceUSD,0) LastPriceUSD";
                sql += " FROM   PaymentService";
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth in (" + lsYearmonth + ")";
                sql += " Order By ServiceDate ";

                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    line = rService - 3 + j;
                    removeRow.Add(line + 2);

                    //Phi khác
                    mergeCell(line, line + 1, 1, 1);
                    mergeCell(line, line + 1, 2, 2);
                    mergeCell(line, line + 1, 3, 3);
                    mergeCell(line, line + 1, 4, 4);

                    for (int col = 1; col < 13; col++)
                    {
                        setStyle(line, col, xlstStyleH);
                        setStyle(line + 1, col, xlstStyleH);
                        setStyle(line + 2, col, xlstStyleH);
                    }
                    mergeCell(line, line, 12, 13);
                    mergeCell(line + 1, line + 1, 12, 13);

                    if (ds != null)
                    {
                        int count = 0;
                        DataTable dt = ds.Tables[0];

                        if (dt.Rows.Count > 0)
                        {
                            setVal(line - 1, 0, viewNumber + ".");
                            strSum += viewNumber + " + ";

                            viewNumber++;

                            foreach (DataRow row in dt.Rows)
                            {
                                if (count >= 1)
                                {
                                    xlsSheet.Rows.Insert(rService + 1 + j);
                                    j++;
                                }
                                count++;
                                int tmp = rService + j;

                                string Service = Func.ParseString(row["Service"]);
                                string ServiceDateFrom = Func.ParseString(row["ServiceDateFrom"]);
                                string ServiceDateTo = Func.ParseString(row["ServiceDateTo"]);

                                string Mount = Func.ParseString(row["Mount"]);

                                setVal(tmp, 1, Service);
                                setVal(tmp, 2, Func.ParseString(row["Unit"]));
                                setVal(tmp, 3, ServiceDateFrom);
                                setVal(tmp, 4, ServiceDateTo);
                                setVal(tmp, 5, Mount);

                                setVal(tmp, 6, row["PriceVND"]);
                                setVal(tmp, 8, row["SumVND"]);
                                setVal(tmp, 10, row["VatVND"]);
                                setVal(tmp, 12, row["LastPriceVND"]);

                                mergeCell(tmp, tmp, 6, 7);
                                mergeCell(tmp, tmp, 8, 9);
                                mergeCell(tmp, tmp, 10, 11);
                                mergeCell(tmp, tmp, 12, 13);

                                for (int col = 1; col <= 13; col++)
                                {
                                    setStyle(tmp, col, xlstStyle);
                                }
                                
                                setStyle(tmp, 5, xlstStyleC2);
                                setStyle(tmp, 6, xlstStyle0);
                                setStyle(tmp, 8, xlstStyle0);
                                setStyle(tmp, 10, xlstStyle0);
                                setStyle(tmp, 12, xlstStyle0);

                                LastSumPriceVND[6] += Convert.ToDecimal(row["LastPriceVND"]);
                            }
                            setVal(rService + 1 + j, 12, LastSumPriceVND[6]);

                            setStyle(rService + 1 + j, 12, xlstStyleSum0);
                            mergeCell(rService + 1 + j, rService + 1 + j, 1, 11);
                            mergeCell(rService + 1 + j, rService + 1 + j, 12, 13);

                            sumRow += dt.Rows.Count - 1;
                        }
                        else
                        {
                            for (int rHideLine = 0; rHideLine < 6; rHideLine++)
                            {
                                setHideRow(rHideLine + line - 1);
                            }
                        }
                    }
                }

                //Paid
                sql = "Select  PaymentType,isnull(MoneyUSD,0) MoneyUSD,isnull(MoneyVND,0) MoneyVND,isnull(PaidUSD,0) PaidUSD,isnull(PaidVND,0) PaidVND,isnull(ExchangeType,0) ExchangeType,isnull(UsdExchange,0) UsdExchange,isnull(YearMonth,0) YearMonth";
                sql += " From    PaymentBillDetail";
                sql += " Where   BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth in (" + lsYearmonth + ") and YearMonth <= " + maxYearMonth + "";
                sql += " and isnull(MoneyVND,0) <> isnull(PaidVND,0)";
                string strYearMonth = "";
                int lineTmp = rPaid - 2 + j;
                removeRow.Add(lineTmp + 1);


                /////En
                mergeCell(lineTmp, lineTmp + 1, 1, 1);
                mergeCell(lineTmp, lineTmp, 2, 3);
                mergeCell(lineTmp, lineTmp, 4, 5);
                mergeCell(lineTmp, lineTmp, 6, 7);
                mergeCell(lineTmp, lineTmp, 8, 9);
                mergeCell(lineTmp, lineTmp, 12, 13);
                /////En
                Hashtable rowNo = new Hashtable();
                decimal[] PaidSumVND = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };
                decimal[] PaidSumUSD = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };

                int iPaidNo = 0;
                DataTable dtPaid = DbHelper.GetDataTable(sql);
                if (dtPaid.Rows.Count > 0)
                {
                    setVal(lineTmp - 1, 0, viewNumber + ".");
                    iPaidNo = viewNumber;
                    viewNumber++;

                    for (int i = 0; i < dtPaid.Rows.Count; i++)
                    {
                        string PaymentType = Func.ParseString(dtPaid.Rows[i]["PaymentType"]);
                        string MoneyVND = Func.ParseString(dtPaid.Rows[i]["MoneyVND"]);
                        string PaidVND = Func.ParseString(dtPaid.Rows[i]["PaidVND"]);
                        string ExchangeType = Func.ParseString(dtPaid.Rows[i]["ExchangeType"]);
                        string UsdExchange = Func.ParseString(dtPaid.Rows[i]["UsdExchange"]);
                        string YearMonth = Func.ParseString(dtPaid.Rows[i]["YearMonth"]);

                        if (!rowNo.Contains(YearMonth))
                        {
                            if (rowNo.Count != 0)
                            {
                                xlsSheet.Rows.Insert(rPaid + j + 1);
                                xlsSheetEn.Rows.Insert(rPaid + j + 1);
                                j++;
                            }
                            rowNo.Add(YearMonth, j);
                        }
                        int m = Func.ParseInt(rowNo[YearMonth]);
                        strYearMonth = YearMonth;
                        decimal tmpVND = Convert.ToDecimal(MoneyVND) - Convert.ToDecimal(PaidVND);
                        PaidPriceVND += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);

                        setVal(rPaid + m, 1, YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4));
                        switch (PaymentType)
                        {
                            case "1":
                                //Rent
                                setVal(rPaid + m, 3, dtPaid.Rows[i]["PaidVND"]);
                                PaidSumVND[0] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);

                                break;
                            case "2":
                                //Manager
                                setVal(rPaid + m, 5, dtPaid.Rows[i]["PaidVND"]);
                                PaidSumVND[1] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);

                                break;
                            case "3":
                                //Parking
                                setVal(rPaid + m, 7, dtPaid.Rows[i]["PaidVND"]);
                                PaidSumVND[2] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
                                break;
                            case "4":
                                //Extra
                                setVal(rPaid + m, 9, dtPaid.Rows[i]["PaidVND"]);
                                PaidSumVND[3] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
                                break;
                            case "5":
                                setVal(rPaid + m, 10, dtPaid.Rows[i]["PaidVND"]);
                                PaidSumVND[4] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
                                break;
                            case "6":
                                setVal(rPaid + m, 11, dtPaid.Rows[i]["PaidVND"]);
                                PaidSumVND[5] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
                                break;
                            case "7":
                                setVal(rPaid + m, 13, dtPaid.Rows[i]["PaidVND"]);
                                setVal(rPaid + m, 13, dtPaid.Rows[i]["PaidVND"]);
                                break;
                            default:
                                break;
                        }
                        /////////////////////////////////////////////////
                        for (int col = 1; col <= 13; col++)
                        {
                            setStyle(rPaid + m, col, xlstStyle);
                        }

                        //Rent
                        setStyle(rPaid + m, 2, xlstStyle1);
                        setStyle(rPaid + m, 3, xlstStyle0);

                        //Manager
                        setStyle(rPaid + m, 4, xlstStyle1);
                        setStyle(rPaid + m, 5, xlstStyle0);

                        //Parking
                        setStyle(rPaid + m, 6, xlstStyle1);
                        setStyle(rPaid + m, 7, xlstStyle0);

                        
                        //Extra
                        setStyle(rPaid + m, 8, xlstStyle1);
                        setStyle(rPaid + m, 9, xlstStyle0);

                        setStyle(rPaid + m, 10, xlstStyle0);

                        setStyle(rPaid + m, 11, xlstStyle0);

                        setStyle(rPaid + m, 12, xlstStyle1);
                        setStyle(rPaid + m, 13, xlstStyle0);
                        mergeCell(rPaid + m, rPaid + m, 2, 3);
                        mergeCell(rPaid + m, rPaid + m, 4, 5);
                        mergeCell(rPaid + m, rPaid + m, 6, 7);
                        mergeCell(rPaid + m, rPaid + m, 8, 9);
                        mergeCell(rPaid + m, rPaid + m, 10, 11);
                        mergeCell(rPaid + m, rPaid + m, 12, 13);
                    }
                }
                else
                {
                    for (int rHideLine = 0; rHideLine < 6; rHideLine++)
                    {
                        setHideRow(rHideLine + lineTmp - 1);
                    }
                }

                lineTmp = rPaid - 2 + j;

                setVal(lineTmp + 3, 3, PaidSumVND[0]);
                setVal(lineTmp + 3, 5, PaidSumVND[1]);
                setVal(lineTmp + 3, 7, PaidSumVND[2]);
                setVal(lineTmp + 3, 9, PaidSumVND[3]);
                setVal(lineTmp + 3, 10, PaidSumVND[4]);
                setVal(lineTmp + 3, 11, PaidSumVND[5]);
                setVal(lineTmp + 3, 13, PaidSumVND[6]);

                ///////////////
                setStyle(lineTmp + 3, 2, xlstStyleSum1);
                setStyle(lineTmp + 3, 3, xlstStyleSum0);
                setStyle(lineTmp + 3, 4, xlstStyleSum1);
                setStyle(lineTmp + 3, 5, xlstStyleSum0);
                setStyle(lineTmp + 3, 6, xlstStyleSum1);
                setStyle(lineTmp + 3, 7, xlstStyleSum0);
                setStyle(lineTmp + 3, 8, xlstStyleSum1);
                setStyle(lineTmp + 3, 9, xlstStyleSum0);
                setStyle(lineTmp + 3, 10, xlstStyleSum0);
                setStyle(lineTmp + 3, 11, xlstStyleSum0);
                setStyle(lineTmp + 3, 12, xlstStyleSum1);
                setStyle(lineTmp + 3, 13, xlstStyleSum0);

                ///////////////DEPT
                sql = "  Select *";
                sql += " From   v_DeptBill";
                sql += " Where  BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth not in (" + lsYearmonth + ") and YearMonth < " + maxYearMonth + "";
                sql += " And    (DeptUsd <> 0 or DeptVnd <> 0)";
                strYearMonth = "";
                lineTmp = rDept - 2 + j;
                removeRow.Add(lineTmp + 1);

                //////En
                mergeCell(lineTmp, lineTmp + 1, 1, 1);
                mergeCell(lineTmp, lineTmp, 2, 3);
                mergeCell(lineTmp, lineTmp, 4, 5);
                mergeCell(lineTmp, lineTmp, 6, 7);
                mergeCell(lineTmp, lineTmp, 8, 9);
                mergeCell(lineTmp, lineTmp, 12, 13);
                //////En
                rowNo = new Hashtable();
                decimal DeptPriceVND = 0;
                decimal DeptPriceUSD = 0;

                decimal[] DeptSumVND = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };
                decimal[] DeptSumUSD = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };


                DataTable dtDept = DbHelper.GetDataTable(sql);
                if (dtDept.Rows.Count > 0)
                {
                    setVal(lineTmp - 1, 0, viewNumber + ".");
                    
                    strSum += viewNumber + " + ";

                    viewNumber++;

                    for (int i = 0; i < dtDept.Rows.Count; i++)
                    {
                        string PaymentType = Func.ParseString(dtDept.Rows[i]["PaymentType"]);
                        string DeptVND = Func.ParseString(dtDept.Rows[i]["DeptVND"]);
                        string YearMonth = Func.ParseString(dtDept.Rows[i]["YearMonth"]);

                        if (!rowNo.Contains(YearMonth))
                        {
                            if (rowNo.Count != 0)
                            {
                                xlsSheet.Rows.Insert(rDept + j + 1);
                                j++;
                            }
                            rowNo.Add(YearMonth, j);
                        }
                        int m = Func.ParseInt(rowNo[YearMonth]);
                        strYearMonth = YearMonth;

                        DeptPriceVND += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);

                        setVal(rDept + m, 1, YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4));
                        
                        switch (PaymentType)
                        {
                            case "1":
                                //Rent
                                setVal(rDept + m, 3, dtDept.Rows[i]["DeptVND"]);
                                DeptSumVND[0] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);

                                break;
                            case "2":
                                //Manager
                                setVal(rDept + m, 5, dtDept.Rows[i]["DeptVND"]);
                                DeptSumVND[1] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);

                                break;
                            case "3":
                                //Parking
                                setVal(rDept + m, 7, dtDept.Rows[i]["DeptVND"]);
                                DeptSumVND[2] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
                                break;
                            case "4":
                                //Extra
                                setVal(rDept + m, 9, dtDept.Rows[i]["DeptVND"]);
                                DeptSumVND[3] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
                                break;
                            case "5":
                                setVal(rDept + m, 10, dtDept.Rows[i]["DeptVND"]);
                                DeptSumVND[4] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
                                break;
                            case "6":
                                setVal(rDept + m, 11, dtDept.Rows[i]["DeptVND"]);
                                DeptSumVND[5] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
                                break;
                            case "7":
                                setVal(rDept + m, 13, dtDept.Rows[i]["DeptVND"]);

                                DeptSumVND[6] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
                                break;
                            default:
                                break;
                        }
                        for (int col = 1; col <= 13; col++)
                        {
                            setStyle(rDept + m, col, xlstStyle);
                        }
                        setStyle(rDept + m, 2, xlstStyle1);
                        setStyle(rDept + m, 3, xlstStyle0);

                        //Manager
                        setStyle(rDept + m, 4, xlstStyle1);
                        setStyle(rDept + m, 5, xlstStyle0);

                        //Parking
                        setStyle(rDept + m, 6, xlstStyle1);
                        setStyle(rDept + m, 7, xlstStyle0);

                        //Extra
                        setStyle(rDept + m, 8, xlstStyle1);
                        setStyle(rDept + m, 9, xlstStyle0);

                        setStyle(rDept + m, 10, xlstStyle0);
                        
                        setStyle(rDept + m, 11, xlstStyle0);
                        
                        setStyle(rDept + m, 12, xlstStyle1);
                        setStyle(rDept + m, 13, xlstStyle0);

                        mergeCell(rDept + m, rDept + m, 2, 3);
                        mergeCell(rDept + m, rDept + m, 4, 5);
                        mergeCell(rDept + m, rDept + m, 6, 7);
                        mergeCell(rDept + m, rDept + m, 8, 9);
                        mergeCell(rDept + m, rDept + m, 10, 11);
                        mergeCell(rDept + m, rDept + m, 12, 13);
                    }
                }
                else
                {
                    for (int rHideLine = 0; rHideLine < 5; rHideLine++)
                    {
                        setHideRow(rHideLine + lineTmp - 1);
                    }
                }
                lineTmp = rDept - 2 + j;

                setVal(lineTmp + 3, 3, DeptSumVND[0]);
                setVal(lineTmp + 3, 5, DeptSumVND[1]);
                setVal(lineTmp + 3, 7, DeptSumVND[2]);
                setVal(lineTmp + 3, 9, DeptSumVND[3]);
                setVal(lineTmp + 3, 10, DeptSumVND[4]);
                setVal(lineTmp + 3, 11, DeptSumVND[5]);
                setVal(lineTmp + 3, 13, DeptSumVND[6]);

                setStyle(lineTmp + 3, 2, xlstStyleSum1);
                setStyle(lineTmp + 3, 3, xlstStyleSum0);
                setStyle(lineTmp + 3, 4, xlstStyleSum1);
                setStyle(lineTmp + 3, 5, xlstStyleSum0);
                setStyle(lineTmp + 3, 6, xlstStyleSum1);
                setStyle(lineTmp + 3, 7, xlstStyleSum0);
                setStyle(lineTmp + 3, 8, xlstStyleSum1);
                setStyle(lineTmp + 3, 9, xlstStyleSum0);
                setStyle(lineTmp + 3, 10, xlstStyleSum0);
                setStyle(lineTmp + 3, 11, xlstStyleSum0);
                setStyle(lineTmp + 3, 12, xlstStyleSum1);
                setStyle(lineTmp + 3, 13, xlstStyleSum0);

                mergeCell(lineTmp + 3, lineTmp + 3, 2, 3);
                mergeCell(lineTmp + 3, lineTmp + 3, 4, 5);
                mergeCell(lineTmp + 3, lineTmp + 3, 6, 7);
                mergeCell(lineTmp + 3, lineTmp + 3, 8, 9);
                mergeCell(lineTmp + 3, lineTmp + 3, 10, 11);
                mergeCell(lineTmp + 3, lineTmp + 3, 12, 13);

                strSum = strSum.Substring(0, strSum.Length - 2) + (iPaidNo > 0 ? " - " + iPaidNo : "") + ":";


                decimal AllSumVND = 0;
                decimal AllSumUSD = 0;
                for (int i = 0; i < 7; i++)
                {
                    AllSumVND += LastSumPriceVND[i];
                    AllSumUSD += LastSumPriceUSD[i];
                }

                AllSumVND -= PaidPriceVND;
                AllSumUSD -= PaidPriceUSD;

                AllSumVND += DeptPriceVND;
                AllSumUSD += DeptPriceUSD;

                //setVal(rSumVND + j, cSumVND - 2, Func.FormatNumber_New(AllSumUSD));
                setVal(rSumVND + j, cSumVND, Func.FormatNumber_New(Convert.ToInt32(AllSumVND)).Replace(",00", ""));
               
                mergeCell(rSumVND + j, rSumVND + j, 10, 13);

                //format
                //setStyle(rSumVND + j, cSumVND - 2, xlstStyleCH);
                setStyle(rSumVND + j, cSumVND, xlstStyleCH);

                //AllSumVND += Convert.ToDecimal(AllSumUSD * Convert.ToDecimal(txtUsdExchange.Text));

                string strMoney = Func.docso(Convert.ToInt32(AllSumVND));
                string strMoneyEn = Func.DocSo_En(Convert.ToInt32(AllSumVND));
                //Hop Dong
                setVal(rContract, cContract, xlsSheet[rContract, cContract].Value.ToString().Replace("{%HOP_DONG%}", String.IsNullOrEmpty(contract) ? "" : contract.Substring(1)));

                //Sum 1 + 2...
                setVal(rSum + j - 1, 7, strSum);
                //Sum số tiền
                setVal(rSum + j - 1, 10, Func.FormatNumber_New(Convert.ToInt32(AllSumVND)).Replace(",00", ""));
                mergeCell(rSum + j - 1, rSum + j - 1, 10, 13);
                setStyle(rSum + j -1, 10, xlstStyleCSum0);
                
                //Chữ
                //mergeCell(rSumRead + j, rSumRead + j, 7, 13);
                setVal(rSum + j + 1, 7, strMoney.ToUpper());
                xlsSheetEn[rSum + j + 1, 7].Value = strMoneyEn.ToUpper();

                setStyle(rSum + j + 1, 7, xlstStyleLeftCH);
                
                setVal(rContract, cContract, xlsSheetEn[rContract, cContract].Value.ToString().Replace("{%HOP_DONG%}", String.IsNullOrEmpty(contract) ? "" : contract.Substring(1)));

                
                //for (int i = 6; i <= 13; i++)
                //{
                //    setStyle(rSumRead + j, i, xlstStyle0);
                //}

                //mergeCell(rSum + j, rSum + j, cSum, cSum + 1);

                //mergeCell(84 + j, 84 + j, 1, 13);
                //mergeCell(85 + j, 85 + j, 1, 13);
                //for (int i = 0; i < 4; i++)
                //{
                //    mergeCell(87 + j + i, 87 + j + i, 1, 6);
                //    mergeCell(87 + j + i, 87 + j + i, 7, 13);
                //}
                //mergeCell(92 + j, 92 + j, 9, 11);

                removeRow.Sort();
                removeRow.Reverse();
                for (int r = 0; r < removeRow.Count; r++)
                {
                    setHideRow(Func.ParseInt(removeRow[r]));
                }

                xlbBook.Save(fileNameDes);
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);
            }
        }
        protected void btnPaymentMonth_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('AllPay.aspx?id=" + lblCustomerId.Text + "',1000,600,'Payment', true);", true);
        }
        protected void btnPrePaid_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('Paymentterm.aspx?id=" + lblCustomerId.Text + "',600,500,'Payment', true);", true);
        }
    }
}
