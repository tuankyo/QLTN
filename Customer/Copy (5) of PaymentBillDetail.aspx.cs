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
using C1.C1Excel;
using System.Drawing;
using System.IO;

namespace Man.Customer
{
    public partial class PaymentBillDetail : PageBase
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

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(addSuccess);
                    hidBillId.Value = data.id;

                    using (SqlConnection con = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand cm = new SqlCommand("sp_PaymentDetailOneCustomer", con))
                        {
                            try
                            {
                                cm.CommandType = CommandType.StoredProcedure;
                                cm.Parameters.AddWithValue("@BuildingId", data.BuildingId);
                                cm.Parameters.AddWithValue("@CustomerId", data.CustomerId);
                                cm.Parameters.AddWithValue("@YearMonth", data.YearMonth);
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

                    tran = factory.GetUpdateObject(data);

                    Execute(tran);

                    if (!HasError)
                    {
                        OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, addSuccess, Page.User.Identity.Name);
                        mvMessage.SetCompleteMessage(addSuccess);

                        using (SqlConnection con = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                        {
                            con.Open();
                            using (SqlCommand cm = new SqlCommand("sp_PaymentDetailOneCustomer", con))
                            {
                                try
                                {
                                    cm.CommandType = CommandType.StoredProcedure;
                                    cm.Parameters.AddWithValue("@BuildingId", data.BuildingId);
                                    cm.Parameters.AddWithValue("@CustomerId", data.CustomerId);
                                    cm.Parameters.AddWithValue("@YearMonth", data.YearMonth);
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
                    else
                    {
                        OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, addUnSuccess, Page.User.Identity.Name);
                        mvMessage.AddError(addUnSuccess);
                    }
                }
            }
            ShowData(drpYear.SelectedValue + drpMonth.SelectedValue);
        }
        /// <summary>
        /// List data
        /// </summary>
        private void ShowData(string YearMonth)
        {
            divRent.Visible = true;
            divManager.Visible = true;
            divParking.Visible = true;
            divService.Visible = true;
            divWater.Visible = true;
            divExtraTime.Visible = true;
            divElec.Visible = true;

            hidBillId.Value = DbHelper.GetScalar("Select id from PaymentBillInfo where customerid = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "' and BuildingId= '" + Func.ParseString(Session["__BUILDINGID__"]) + "'");

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

                btnCreate.Text = "Tính lại tiền";
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
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'";

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
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'";
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
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'";

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
                sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfWaterId = 0  and A.YearMonth = '" + YearMonth + "'";
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
                sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfElecId = 0 and A.YearMonth = '" + YearMonth + "'";
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
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'";

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
                sql = "Select  *";
                sql += " From    PaymentBillDetail";
                sql += " Where   BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'";
                DataTable dt = DbHelper.GetDataTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string PaymentType = Func.ParseString(dt.Rows[i]["PaymentType"]);
                    string MoneyUSD = Func.ParseString(dt.Rows[i]["MoneyUSD"]);
                    string MoneyVND = Func.ParseString(dt.Rows[i]["MoneyVND"]);
                    string PaidUSD = Func.ParseString(dt.Rows[i]["PaidUSD"]);
                    string PaidVND = Func.ParseString(dt.Rows[i]["PaidVND"]);
                    string ExchangeType = Func.ParseString(dt.Rows[i]["ExchangeType"]);
                    //string UsdExchange = Func.ParseString(dt.Rows[i]["UsdExchange"]);

                    float tmpUSD = Func.ParseFloat(MoneyUSD) - Func.ParseFloat(PaidUSD);
                    double tmpVND = Func.ParseDouble(MoneyVND) - Func.ParseFloat(PaidVND);

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
        private void ShowData()
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

            divRent.Visible = false;
            divManager.Visible = false;
            divParking.Visible = false;
            divService.Visible = false;
            divWater.Visible = false;
            divExtraTime.Visible = false;
            divElec.Visible = false;

            lsYearmonth = lsYearmonth.Substring(1);
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

                btnCreate.Text = "Tính lại tiền";
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
                sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfWaterId = 0  and A.YearMonth in (" + lsYearmonth + ")";
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
                sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfElecId = 0 and A.YearMonth in (" + lsYearmonth + ")";
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

                    float tmpUSD = Func.ParseFloat(MoneyUSD) - Func.ParseFloat(PaidUSD);
                    double tmpVND = Func.ParseDouble(MoneyVND) - Func.ParseFloat(PaidVND);

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
                    ShowData(drpYear.SelectedValue + drpMonth.SelectedValue);
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

                ShowData(drpYear.SelectedValue + drpMonth.SelectedValue);

                //String[] chkText = new String[12] { "", "", "", "", "", "", "", "", "", "", "", ""};
                //DateTime monthYear = DateTime.Now.AddMonths(-6);
                //for (int i = 0; i < 12; i++)
                //{
                //    monthYear = monthYear.AddMonths(1);
                //    chkText[i] = monthYear.ToString("MM") + "/" + monthYear.ToString("yyyy");
                //}
                //chkMonth01.Text = chkText[0];
                //chkMonth02.Text = chkText[1];
                //chkMonth03.Text = chkText[2];
                //chkMonth04.Text = chkText[3];
                //chkMonth05.Text = chkText[4];
                //chkMonth06.Text = chkText[5];
                //chkMonth07.Text = chkText[6];
                //chkMonth08.Text = chkText[7];
                //chkMonth09.Text = chkText[8];
                //chkMonth10.Text = chkText[9];
                //chkMonth11.Text = chkText[10];
                //chkMonth12.Text = chkText[11];
                for (int i = -6; i < 6; i++)
                {
                    lstYearMonth.Items.Add(new ListItem(DateTime.Now.AddMonths(i).ToString("MM/yyyy"), DateTime.Now.AddMonths(i).ToString("yyyyMM")));
                }
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
        protected void btnAllSelect_Click(object sender, EventArgs e)
        {
            ArrayList rmList = new ArrayList();
            foreach (ListItem lstItem in lstYearMonth.Items)
            {
                lstSelectedYearMonth.Items.Add(lstItem);
                rmList.Add(lstItem);
            }
            for (int i = 0; i < rmList.Count; i++)
            {
                lstYearMonth.Items.Remove((ListItem)rmList[i]);
            }
        }
        protected void btnUnAllSelect_Click(object sender, EventArgs e)
        {
            ArrayList rmList = new ArrayList();
            foreach (ListItem lstItem in lstSelectedYearMonth.Items)
            {
                lstYearMonth.Items.Add(lstItem);
                rmList.Add(lstItem);
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
            ShowData(drpYear.SelectedValue + drpMonth.SelectedValue);
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
                    Func.SetGridTextValue(item, "ltrUsed", Func.FormatNumber_New(Func.ParseInt(ToIndex) - Func.ParseInt(FromIndex)));

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
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnSelect_Click(object sender, EventArgs e)
        //{
        //    ShowData(drpYear.SelectedValue + drpMonth.SelectedValue);
        //}
        protected void btnViewSum_Click(object sender, EventArgs e)
        {
            ShowData();
        }
        protected void btnSelectYM_Click(object sender, EventArgs e)
        {
            ShowData(drpYear.SelectedValue + drpMonth.SelectedValue);
        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            ViewMultiBoth("'" + drpYear.SelectedValue + drpMonth.SelectedValue + "'");
            //int rBillNo = 0;
            //int cBillNo = 1;

            //int rBillDate = 0;
            //int cBillDate = 10;

            //int rBillMonth = 2;
            //int cBillMonth = 0;

            //int rContact = 5;
            //int cContact = 3;

            //int rCustomer = 5;
            //int cCustomer = 7;

            //int rContract = 7;
            //int cContract = 1;

            //int rRate = 11;
            //int cRate = 9;

            //int rRateDate = 11;
            //int cRateDate = 12;

            //int rRent = 15;

            //int rManager = 23;

            //int rParking = 31;

            //int rExtra = 39;

            //int rElec = 47;

            //int rWater = 55;

            //int rService = 63;

            //int rPaid = 70;

            //int rDept = 77;

            //int rOffice = 88;
            //int cOffice = 3;

            //int rPhone = 89;
            //int cPhone = 3;

            //int rBank = 88;
            //int cBank = 7;

            //int rAccountName = 89;
            //int cAccountName = 7;

            //int rAccount = 90;
            //int cAccount = 7;

            //int rSum = 81;
            //int cSum = 12;

            //int rSumVND = 80;
            //int cSumVND = 12;


            //int rSumRead = 82;
            //int cSumRead = 13;

            //int check = DbHelper.GetCount("Select count(*) from PaymentBillInfo Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + lblCustomerId.Text + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'");
            //if (check == 0)
            //{
            //    mvMessage.AddError("Xin vui lòng tạo hóa đơn trước khi xem");
            //    return;
            //}
            //mvMessage.CheckRequired(txtBillDate, "Ngày xuất Hóa đơn là danh mục bắt buộc");
            //mvMessage.CheckRequired(txtBillNo, "Số Hóa đơn là danh mục bắt buộc");
            //mvMessage.CheckRequired(txtUsdExchange, "Tỉ giá USD-VN là danh mục bắt buộc");
            //mvMessage.CheckRequired(txtUsdExchangeDate, "Ngày tỉ giá là danh mục bắt buộc");
            ////ShowData(drpYear.SelectedValue + drpMonth.SelectedValue);
            //C1XLBook xlbBook = new C1XLBook();
            //string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\BillTongQuat.xlsx");
            //if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])))
            //{
            //    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])));
            //}

            //XLStyle xlstStyle = new XLStyle(xlbBook);
            //xlstStyle.AlignHorz = XLAlignHorzEnum.Center;
            //xlstStyle.AlignVert = XLAlignVertEnum.Center;
            //xlstStyle.WordWrap = true;
            //xlstStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            //xlstStyle.SetBorderColor(Color.Black);
            //xlstStyle.BorderBottom = XLLineStyleEnum.Thin;
            //xlstStyle.BorderTop = XLLineStyleEnum.Thin;
            //xlstStyle.BorderLeft = XLLineStyleEnum.Thin;
            //xlstStyle.BorderRight = XLLineStyleEnum.Thin;
            //xlstStyle.Format = "#,##0.00_);(#,##0.00)";

            //XLStyle xlstStyleH = new XLStyle(xlbBook);
            //xlstStyleH.AlignHorz = XLAlignHorzEnum.Center;
            //xlstStyleH.AlignVert = XLAlignVertEnum.Center;
            //xlstStyleH.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            //xlstStyleH.SetBorderColor(Color.Black);
            //xlstStyleH.BorderBottom = XLLineStyleEnum.Thin;
            //xlstStyleH.BorderTop = XLLineStyleEnum.Thin;
            //xlstStyleH.BorderLeft = XLLineStyleEnum.Thin;
            //xlstStyleH.BorderRight = XLLineStyleEnum.Thin;
            //xlstStyleH.WordWrap = true;

            //XLStyle xlstStyleSum = new XLStyle(xlbBook);
            //xlstStyleSum.AlignHorz = XLAlignHorzEnum.Right;
            //xlstStyleSum.AlignVert = XLAlignVertEnum.Center;
            //xlstStyleSum.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            //xlstStyleSum.SetBorderColor(Color.Black);
            //xlstStyleSum.BorderBottom = XLLineStyleEnum.Thin;
            //xlstStyleSum.BorderTop = XLLineStyleEnum.Thin;
            //xlstStyleSum.BorderLeft = XLLineStyleEnum.Thin;
            //xlstStyleSum.BorderRight = XLLineStyleEnum.Thin;
            //xlstStyleSum.WordWrap = true;
            //xlstStyleSum.Format = "#,##0.00_);(#,##0.00)";

            //string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
            //string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BillTongQuat" + strDT + ".xlsx";
            //string strFilePathExport = @"../../Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + @"/BillTongQuat" + strDT + ".xlsx";

            //string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

            ////string fileNameDes = HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\TongHopDienTich" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
            //File.Copy(fileName, fileNameDes);

            //xlbBook.Load(fileNameDes);
            //XLSheet xlsSheet = xlbBook.Sheets["TongHop"];

            ////Bill No
            //xlsSheet[rBillNo, cBillNo].Value = xlsSheet[rBillNo, cBillNo].Value.ToString().Replace("{%BILL_NO%}", txtBillNo.Text);

            ////Ngay Thang Nam
            //DateTime dtime = DateTime.Today;

            //string strTmp = xlsSheet[rBillDate, cBillDate].Value.ToString().Replace("{%NGAY%}", dtime.ToString("dd"));
            //strTmp = strTmp.Replace("{%THANG%}", dtime.ToString("MM"));
            //xlsSheet[rBillDate, cBillDate].Value = strTmp.Replace("{%NAM%}", dtime.ToString("yyyy"));

            ////Nam
            //xlsSheet[rBillMonth, cBillMonth].Value = xlsSheet[rBillMonth, cBillMonth].Value.ToString().Replace("{%NAM_THANG%}", drpMonth.SelectedValue + "/" + drpYear.SelectedValue);

            //using (SqlDatabase db = new SqlDatabase())
            //{
            //    DataSet ds = new DataSet();
            //    string sql = string.Empty;

            //    sql = " SELECT Name, ContactName";
            //    sql += " FROM Customer";
            //    sql += " WHERE CustomerId = '" + lblCustomerId.Text + "' ";

            //    using (SqlCommand cm = db.CreateCommand(sql))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(cm);
            //        da.Fill(ds);

            //        if (ds != null)
            //        {
            //            DataTable dt = ds.Tables[0];
            //            foreach (DataRow rowType in dt.Rows)
            //            {
            //                string Name = rowType[0].ToString();
            //                string ContactName = rowType[1].ToString();

            //                //Customer
            //                xlsSheet[rCustomer, cCustomer].Value = xlsSheet[rCustomer, cCustomer].Value.ToString().Replace("{%TEN_CONG_TY%}", Name);
            //                //Contact
            //                xlsSheet[rContact, cContact].Value = xlsSheet[rContact, cContact].Value.ToString().Replace("{%NGUOI_DAI_DIEN%}", ContactName);
            //            }
            //        }
            //    }
            //    Hashtable contractIdLst = new Hashtable();
            //    string contract = "";
            //    ds = new DataSet();
            //    sql = " SELECT Bank,Account,AccountName,Office,OfficeAddress,OfficePhone";
            //    sql += " FROM Mst_Building";
            //    sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' ";
            //    using (SqlCommand cm = db.CreateCommand(sql))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(cm);
            //        da.Fill(ds);

            //        if (ds != null)
            //        {
            //            DataTable dt = ds.Tables[0];
            //            foreach (DataRow rowType in dt.Rows)
            //            {
            //                string Bank = rowType["Bank"].ToString();
            //                string Account = rowType["Account"].ToString();
            //                string AccountName = rowType["AccountName"].ToString();
            //                string Office = rowType["Office"].ToString();
            //                string OfficeAddress = rowType["OfficeAddress"].ToString();
            //                string OfficePhone = rowType["OfficePhone"].ToString();

            //                xlsSheet[rOffice, cOffice].Value = xlsSheet[rOffice, cOffice].Value.ToString().Replace("{%VAN_PHONG%}", Office);
            //                xlsSheet[rPhone, cPhone].Value = xlsSheet[rPhone, cPhone].Value.ToString().Replace("{%DIEN_THOAI%}", OfficePhone);

            //                xlsSheet[rBank, cBank].Value = xlsSheet[rBank, cBank].Value.ToString().Replace("{%NGAN_HANG%}", Bank);
            //                xlsSheet[rAccountName, cAccountName].Value = xlsSheet[rAccountName, cAccountName].Value.ToString().Replace("{%TEN_TAI_KHOAN%}", AccountName);
            //                xlsSheet[rAccount, cAccount].Value = xlsSheet[rAccount, cAccount].Value.ToString().Replace("{%SO_TAI_KHOAN%}", Account);
            //            }
            //        }
            //    }

            //    xlsSheet[rRate, cRate].Value = xlsSheet[rRate, cRate].Value.ToString().Replace("{%TI_GIA%}", txtUsdExchange.Text);
            //    xlsSheet[rRateDate, cRateDate].Value = xlsSheet[rRateDate, cRateDate].Value.ToString().Replace("{%NGAY_AP_DUNG%}", txtUsdExchangeDate.Text);

            //    //Thue phong
            //    ds = new DataSet();
            //    sql = " Select *";
            //    sql += " FROM PaymentRoom";
            //    sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";

            //    int sumRow = 0;
            //    int j = 0;
            //    decimal[] LastSumPriceVND = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };
            //    decimal[] LastSumPriceUSD = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };

            //    decimal PaidPriceVND = 0;
            //    decimal PaidPriceUSD = 0;

            //    int line = 0;
            //    using (SqlCommand cm = db.CreateCommand(sql))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(cm);
            //        da.Fill(ds);

            //        line = rRent - 3 + j;

            //        XLCellRange mCell = new XLCellRange(line, line + 2, 1, 3);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 4, 5);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 4, 5);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 2, line + 2, 4, 5);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 6, 7);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 6, 7);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 8, 9);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 8, 9);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 10, 11);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 10, 11);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        //for (int m = 1; m < 14; m++)
            //        //{
            //        //    xlsSheet[line, m].Style = xlstStyleSum;
            //        //    xlsSheet[line+1, m].Style = xlstStyleSum;
            //        //    xlsSheet[line+1, m].Style = xlstStyleSum;
            //        //}

            //        if (ds != null)
            //        {
            //            int count = 0;
            //            DataTable dt = ds.Tables[0];
            //            foreach (DataRow rowType in dt.Rows)
            //            {
            //                if (count >= 1)
            //                {
            //                    xlsSheet.Rows.Insert(rRent + j);
            //                    j++;

            //                }
            //                count++;

            //                int tmp = rRent + j;

            //                string ContractId = Func.ParseString(rowType["ContractId"]);
            //                string ContractNo = Func.ParseString(rowType["ContractNo"]);
            //                string YearMonth = Func.ParseString(rowType["YearMonth"]);
            //                string Area = Func.ParseString(rowType["Area"]);
            //                string Name = Func.ParseString(rowType["Name"]);
            //                string Regional = Func.ParseString(rowType["Regional"]);
            //                string Floor = Func.ParseString(rowType["Floor"]);

            //                string BeginContract = Func.ParseString(rowType["BeginContract"]);


            //                if (!contractIdLst.ContainsKey(ContractId + "(" + BeginContract.Substring(0, 10) + ")"))
            //                {
            //                    contractIdLst.Add(ContractId + "(" + BeginContract.Substring(0, 10) + ")", ContractNo + "(" + BeginContract.Substring(0, 10) + ")");
            //                    contract += ";" + ContractNo + "(" + BeginContract.Substring(0, 10) + ")";
            //                }

            //                xlsSheet[tmp, 1].Value = Name;
            //                xlsSheet[tmp, 4].Value = rowType["Area"];
            //                xlsSheet[tmp, 6].Value = rowType["MonthRentPriceUSD"];
            //                xlsSheet[tmp, 7].Value = rowType["MonthRentPriceVND"];

            //                xlsSheet[tmp, 8].Value = rowType["MonthRentSumUSD"];
            //                xlsSheet[tmp, 9].Value = rowType["MonthRentSumVND"];

            //                xlsSheet[tmp, 10].Value = rowType["VatRentPriceUSD"];
            //                xlsSheet[tmp, 11].Value = rowType["VatRentPriceVND"];

            //                xlsSheet[tmp, 12].Value = rowType["LastRentSumUSD"];
            //                xlsSheet[tmp, 13].Value = rowType["LastRentSumVND"];

            //                XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
            //                xlsSheet.MergedCells.Add(mrCell);

            //                mrCell = new XLCellRange(tmp, tmp, 4, 5);
            //                xlsSheet.MergedCells.Add(mrCell);

            //                LastSumPriceVND[0] += Convert.ToDecimal(rowType["LastRentSumVND"]);
            //                LastSumPriceUSD[0] += Convert.ToDecimal(rowType["LastRentSumUSD"]);

            //            }
            //            mCell = new XLCellRange(rRent + 1 + j, rRent + 1 + j, 1, 11);
            //            xlsSheet.MergedCells.Add(mCell);

            //            xlsSheet[rRent + 1 + j, 12].Value = LastSumPriceUSD[0];
            //            xlsSheet[rRent + 1 + j, 13].Value = LastSumPriceVND[0];

            //            for (int row = rRent + sumRow; row <= rRent + dt.Rows.Count; row++)
            //            {
            //                for (int col = 1; col <= 13; col++)
            //                {
            //                    xlsSheet[row, col].Style = xlstStyle;
            //                }
            //            }
            //            sumRow += dt.Rows.Count - 1;

            //            ////////////////////////
            //            for (int col = 1; col <= 13; col++)
            //            {
            //                xlsSheet[rRent + 1 + j, col].Style = xlstStyleSum;
            //            }
            //            line = rManager - 3 + j;

            //            mCell = new XLCellRange(line, line + 2, 1, 3);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line, line, 4, 5);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line + 1, line + 1, 4, 5);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line + 2, line + 2, 4, 5);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line, line, 6, 7);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line + 1, line + 1, 6, 7);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line, line, 8, 9);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line + 1, line + 1, 8, 9);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line, line, 10, 11);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line + 1, line + 1, 10, 11);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line, line, 12, 13);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line + 1, line + 1, 12, 13);
            //            xlsSheet.MergedCells.Add(mCell);

            //            count = 0;
            //            foreach (DataRow row in dt.Rows)
            //            {
            //                if (count >= 1)
            //                {
            //                    xlsSheet.Rows.Insert(rManager + j);
            //                    j++;

            //                }
            //                count++;
            //                int tmp = rManager;

            //                string YearMonth = Func.ParseString(row["YearMonth"]);
            //                string Area = Func.ParseString(row["Area"]);
            //                string Name = Func.ParseString(row["Name"]);

            //                xlsSheet[tmp, 1].Value = Name;
            //                xlsSheet[tmp, 4].Value = row["Area"];
            //                xlsSheet[tmp, 6].Value = row["MonthManagerPriceUSD"];
            //                xlsSheet[tmp, 7].Value = row["MonthManagerPriceVND"];

            //                xlsSheet[tmp, 8].Value = row["MonthManagerSumUSD"];
            //                xlsSheet[tmp, 9].Value = row["MonthManagerSumVND"];

            //                xlsSheet[tmp, 19].Value = row["VatManagerPriceUSD"];
            //                xlsSheet[tmp, 11].Value = row["VatManagerPriceVND"];

            //                xlsSheet[tmp, 12].Value = row["LastManagerSumUSD"];
            //                xlsSheet[tmp, 13].Value = row["LastManagerSumVND"];

            //                XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
            //                xlsSheet.MergedCells.Add(mrCell);

            //                mrCell = new XLCellRange(tmp, tmp, 4, 5);
            //                xlsSheet.MergedCells.Add(mrCell);

            //                LastSumPriceVND[1] += Convert.ToDecimal(row["LastManagerSumVND"]);
            //                LastSumPriceUSD[1] += Convert.ToDecimal(row["LastManagerSumUSD"]);
            //            }
            //            mCell = new XLCellRange(rManager + 1 + j, rManager + 1 + j, 1, 11);
            //            xlsSheet.MergedCells.Add(mCell);

            //            xlsSheet[rManager + 1 + j, 12].Value = LastSumPriceUSD[1];
            //            xlsSheet[rManager + 1 + j, 13].Value = LastSumPriceVND[1];

            //            for (int row = rManager + sumRow; row <= rManager + sumRow + dt.Rows.Count; row++)
            //            {
            //                for (int col = 1; col <= 13; col++)
            //                {
            //                    xlsSheet[row, col].Style = xlstStyle;
            //                }
            //            }

            //            for (int col = 1; col <= 13; col++)
            //            {
            //                xlsSheet[rManager + 1 + j, col].Style = xlstStyleSum;
            //            }
            //            sumRow += dt.Rows.Count - 1;

            //        }
            //    }

            //    ds = new DataSet();
            //    //Xuất ra toàn bộ nội dung theo Trang
            //    sql = " SELECT COUNT(*) AS Num, YearMonth, TariffsParkingName, PriceVND, PriceUSD, SUM(VatVND) AS VatVND,SUM(VatUSD) AS VatUSD, SUM(SumVND) AS SumVND, SUM(SumUSD) AS SumUSD, SUM(LastPriceVND) AS LastPriceVND";
            //    sql += "        , SUM(LastPriceUSD) AS LastPriceUSD";
            //    sql += " FROM         dbo.PaymentParking";
            //    sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";
            //    sql += " GROUP BY YearMonth, TariffsParkingName, PriceVND, PriceUSD, Vat, daysParking";

            //    using (SqlCommand cm = db.CreateCommand(sql))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(cm);
            //        da.Fill(ds);

            //        line = rParking - 3 + j;
            //        XLCellRange mCell = new XLCellRange(line, line + 2, 1, 3);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 4, 5);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 4, 5);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 2, line + 2, 4, 5);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 6, 7);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 6, 7);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 8, 9);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 8, 9);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 10, 11);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 10, 11);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);
            //        if (ds != null)
            //        {
            //            int count = 0;
            //            DataTable dt = ds.Tables[0];

            //            foreach (DataRow row in dt.Rows)
            //            {
            //                if (count >= 1)
            //                {
            //                    xlsSheet.Rows.Insert(rParking + 1 + j);
            //                    j++;
            //                }
            //                count++;
            //                int tmp = rParking + j;

            //                string Num = Func.ParseString(row["Num"]);
            //                string TariffsParkingName = Func.ParseString(row["TariffsParkingName"]);

            //                xlsSheet[tmp, 1].Value = TariffsParkingName;
            //                xlsSheet[tmp, 4].Value = Num;
            //                xlsSheet[tmp, 6].Value = row["PriceUSD"];
            //                xlsSheet[tmp, 7].Value = row["PriceVND"];

            //                xlsSheet[tmp, 8].Value = row["SumUSD"];
            //                xlsSheet[tmp, 9].Value = row["SumVND"];

            //                xlsSheet[tmp, 10].Value = row["VatUSD"];
            //                xlsSheet[tmp, 11].Value = row["VatVND"];

            //                xlsSheet[tmp, 12].Value = row["LastPriceUSD"];
            //                xlsSheet[tmp, 13].Value = row["LastPriceVND"];

            //                XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
            //                xlsSheet.MergedCells.Add(mrCell);

            //                mrCell = new XLCellRange(tmp, tmp, 4, 5);
            //                xlsSheet.MergedCells.Add(mrCell);

            //                LastSumPriceVND[2] += Convert.ToDecimal(row["LastPriceVND"]);
            //                LastSumPriceUSD[2] += Convert.ToDecimal(row["LastPriceUSD"]);
            //            }
            //            xlsSheet[rParking + 1 + j, 12].Value = LastSumPriceUSD[2];
            //            xlsSheet[rParking + 1 + j, 13].Value = LastSumPriceVND[2];

            //            mCell = new XLCellRange(rParking + 1 + j, rParking + 1 + j, 1, 11);
            //            xlsSheet.MergedCells.Add(mCell);

            //            for (int row = rParking + sumRow; row <= rParking + sumRow + dt.Rows.Count; row++)
            //            {
            //                for (int col = 1; col <= 13; col++)
            //                {
            //                    xlsSheet[row, col].Style = xlstStyle;
            //                }
            //            }

            //            for (int col = 1; col <= 13; col++)
            //            {
            //                xlsSheet[rParking + 1 + j, col].Style = xlstStyleSum;
            //            }
            //            sumRow += dt.Rows.Count - 1;
            //        }
            //    }

            //    //Lam ngoai gio
            //    ds = new DataSet();
            //    //sql = " SELECT ExtraHour, dbo.fnDateTime(WorkingDate) WorkingDate, PriceVND,PriceUSD,VatUSD,VatVND,SumVND,SumUSD,LastPriceVND,LastPriceUSD  ";
            //    //sql += " FROM   PaymentExtraTime";
            //    //sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";

            //    sql = "SELECT id";
            //    sql += " ,YearMonth,BuildingId,CustomerId,RoomId,ExtraHour,VAT,OtherFee01,OtherFee02";
            //    sql += " ,PriceUSD,PriceVND,VatUSD,VatVND,SumUSD,SumVND,LastPriceUSD,LastPriceVND";
            //    sql += " ,RentArea,ExtratimeType,dbo.fnDateTime(FromWD) BeginDate,dbo.fnDateTime(EndWD) EndDate";
            //    sql += " FROM PaymentExtraTimeMonth";
            //    sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";

            //    using (SqlCommand cm = db.CreateCommand(sql))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(cm);
            //        da.Fill(ds);
            //        line = rExtra - 3 + j;
            //        //Phi dien
            //        XLCellRange mCell = new XLCellRange(line, line + 2, 1, 3);
            //        xlsSheet.MergedCells.Add(mCell);

            //        //mCell = new XLCellRange(line, line, 4, 5);
            //        //xlsSheet.MergedCells.Add(mCell);
            //        mCell = new XLCellRange(line, line + 2, 4, 4);
            //        xlsSheet.MergedCells.Add(mCell);

            //        //mCell = new XLCellRange(line + 1, line + 1, 4, 5);
            //        //xlsSheet.MergedCells.Add(mCell);

            //        //mCell = new XLCellRange(line + 2, line + 2, 4, 5);
            //        //xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 6, 7);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 6, 7);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 8, 9);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 8, 9);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 10, 11);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 10, 11);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        if (ds != null)
            //        {
            //            int count = 0;
            //            DataTable dt = ds.Tables[0];

            //            foreach (DataRow row in dt.Rows)
            //            {
            //                if (count >= 1)
            //                {
            //                    xlsSheet.Rows.Insert(rExtra + 1 + j);
            //                    j++;
            //                }
            //                count++;
            //                int tmp = rExtra + j;

            //                //string id = Func.ParseString(row["id"]);
            //                string ExtraHour = Func.ParseString(row["ExtraHour"]);
            //                //string WorkingDate = Func.ParseString(row["WorkingDate"]);
            //                string BeginDate = Func.ParseString(row["BeginDate"]);
            //                string EndDate = Func.ParseString(row["EndDate"]);

            //                string ExtratimeType = Func.ParseString(row["ExtratimeType"]);

            //                xlsSheet[tmp, 1].Value = BeginDate + "~" + EndDate;
            //                xlsSheet[tmp, 5].Value = ExtraHour;

            //                xlsSheet[tmp, 4].Value = "m2*h";
            //                if ("1".Equals(ExtratimeType))
            //                {
            //                    xlsSheet[tmp, 4].Value = "Diện tích";
            //                }
            //                xlsSheet[tmp, 6].Value = row["PriceUSD"];
            //                xlsSheet[tmp, 7].Value = row["PriceVND"];

            //                xlsSheet[tmp, 8].Value = row["SumUSD"];
            //                xlsSheet[tmp, 9].Value = row["SumVND"];

            //                xlsSheet[tmp, 10].Value = row["VatUSD"];
            //                xlsSheet[tmp, 11].Value = row["VatVND"];

            //                xlsSheet[tmp, 12].Value = row["LastPriceUSD"];
            //                xlsSheet[tmp, 13].Value = row["LastPriceVND"];

            //                LastSumPriceVND[3] += Convert.ToDecimal(row["LastPriceVND"]);
            //                LastSumPriceUSD[3] += Convert.ToDecimal(row["LastPriceUSD"]);
            //                //}
            //                XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
            //                xlsSheet.MergedCells.Add(mrCell);

            //                for (int col = 1; col <= 13; col++)
            //                {
            //                    xlsSheet[tmp, col].Style = xlstStyle;
            //                }

            //            }
            //            mCell = new XLCellRange(rExtra + 1 + j, rExtra + 1 + j, 1, 11);
            //            xlsSheet.MergedCells.Add(mCell);

            //            xlsSheet[rExtra + 1 + j, 12].Value = LastSumPriceUSD[3];
            //            xlsSheet[rExtra + 1 + j, 13].Value = LastSumPriceVND[3];

            //            for (int row = rExtra + sumRow; row <= rExtra + sumRow + dt.Rows.Count; row++)
            //            {
            //                for (int col = 1; col <= 13; col++)
            //                {
            //                    xlsSheet[row, col].Style = xlstStyle;
            //                }
            //            }

            //            for (int col = 1; col <= 13; col++)
            //            {
            //                xlsSheet[rExtra + 1 + j, col].Style = xlstStyleSum;
            //            }
            //            sumRow += dt.Rows.Count - 1;
            //        }
            //    }

            //    ds = new DataSet();
            //    //Dien
            //    //Xuất ra toàn bộ nội dung theo Trang
            //    sql = " SELECT dbo.fnDateTime(A.DateFrom) DateFrom, dbo.fnDateTime(A.DateTo) DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVND, B.PriceUSD, B.SumVND, B.SumUSD, ";
            //    sql += "        B.VatVND, B.VatUSD, B.LastPriceVND, B.LastPriceUSD, B.Name, B.WaterPricePercent,B.ElecPricePercent ";
            //    sql += " FROM   PaymentElecWater AS A INNER JOIN ";
            //    sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId";
            //    sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfWaterId = 0  and A.YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";
            //    sql += " Order by A.DateFrom, B.FromIndex";

            //    using (SqlCommand cm = db.CreateCommand(sql))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(cm);
            //        da.Fill(ds);

            //        line = rElec - 3 + j;
            //        //Phi dien
            //        XLCellRange mCell = new XLCellRange(line, line + 2, 1, 1);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line + 2, 2, 2);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 3, 3);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 4, 4);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 5, 5);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 7, 7);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 8, 8);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 9, 9);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 10, 10);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 11, 11);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        for (int col = 1; col < 13; col++)
            //        {
            //            xlsSheet[line, col].Style = xlstStyleH;
            //            xlsSheet[line + 1, col].Style = xlstStyleH;
            //            xlsSheet[line + 2, col].Style = xlstStyleH;
            //        }

            //        if (ds != null)
            //        {
            //            int count = 0;
            //            DataTable dt = ds.Tables[0];
            //            if (dt.Rows.Count > 0)
            //            {
            //                foreach (DataRow row in dt.Rows)
            //                {
            //                    if (count >= 1)
            //                    {
            //                        xlsSheet.Rows.Insert(rElec + 1 + j);
            //                        j++;

            //                    }
            //                    count++;
            //                    int tmp = rElec + j;

            //                    string DateFrom = Func.ParseString(row["DateFrom"]);
            //                    string DateTo = Func.ParseString(row["DateTo"]);

            //                    string FromIndex = Func.ParseString(row["FromIndex"]);
            //                    string ToIndex = Func.ParseString(row["ToIndex"]);
            //                    string OtherFee01 = Func.ParseString(row["OtherFee01"]);
            //                    string OtherFee02 = Func.ParseString(row["OtherFee02"]);
            //                    string Mount = Func.ParseString(row["Mount"]);
            //                    string ElecPricePercent = Func.ParseString(row["ElecPricePercent"]);

            //                    xlsSheet[tmp, 1].Value = DateFrom;
            //                    xlsSheet[tmp, 2].Value = DateTo;
            //                    xlsSheet[tmp, 3].Value = FromIndex;
            //                    xlsSheet[tmp, 4].Value = ToIndex;
            //                    xlsSheet[tmp, 5].Value = OtherFee01;
            //                    xlsSheet[tmp, 6].Value = Mount;
            //                    xlsSheet[tmp, 7].Value = row["PriceVND"];
            //                    xlsSheet[tmp, 8].Value = row["VatVND"];

            //                    xlsSheet[tmp, 9].Value = row["SumVND"];
            //                    xlsSheet[tmp, 10].Value = row["OtherFee02"];
            //                    xlsSheet[tmp, 11].Value = row["ElecPricePercent"];
            //                    xlsSheet[tmp, 12].Value = row["LastPriceVND"];

            //                    mCell = new XLCellRange(tmp, tmp, 12, 13);
            //                    xlsSheet.MergedCells.Add(mCell);

            //                    for (int col = 1; col <= 12; col++)
            //                    {
            //                        xlsSheet[tmp, col].Style = xlstStyle;
            //                    }
            //                    LastSumPriceVND[4] += Convert.ToDecimal(row["LastPriceVND"]);
            //                    LastSumPriceUSD[4] += Convert.ToDecimal(row["LastPriceUSD"]);
            //                }
            //                xlsSheet[rElec + 1 + j, 12].Value = LastSumPriceVND[4];
            //                mCell = new XLCellRange(rElec + 1 + j, rElec + 1 + j, 1, 11);
            //                xlsSheet.MergedCells.Add(mCell);

            //                mCell = new XLCellRange(rElec + 1 + j, rElec + 1 + j, 12, 13);
            //                xlsSheet.MergedCells.Add(mCell);

            //                for (int col = 1; col <= 13; col++)
            //                {
            //                    xlsSheet[rElec + 1 + j, col].Style = xlstStyleSum;
            //                }
            //                sumRow += dt.Rows.Count - 1;
            //            }
            //        }
            //    }

            //    ds = new DataSet();
            //    //Nuoc
            //    //Xuất ra toàn bộ nội dung theo Trang
            //    sql = " SELECT dbo.fnDateTime(A.DateFrom) DateFrom, dbo.fnDateTime(A.DateTo) DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVND, B.PriceUSD, B.SumVND, B.SumUSD, ";
            //    sql += "        B.VatVND, B.VatUSD, B.LastPriceVND, B.LastPriceUSD, B.Name, B.WaterPricePercent,B.ElecPricePercent ";
            //    sql += " FROM   PaymentElecWater AS A INNER JOIN ";
            //    sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId";
            //    sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfElecId = 0 and A.YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";
            //    sql += " Order by A.DateFrom, B.FromIndex";

            //    using (SqlCommand cm = db.CreateCommand(sql))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(cm);
            //        da.Fill(ds);
            //        line = rWater - 3 + j;
            //        //Phi dien
            //        XLCellRange mCell = new XLCellRange(line, line + 2, 1, 1);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line + 2, 2, 2);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 3, 3);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 4, 4);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 6, 6);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 7, 7);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 8, 8);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 9, 9);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 10, 10);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 11, 11);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        for (int col = 1; col < 13; col++)
            //        {
            //            xlsSheet[line, col].Style = xlstStyleH;
            //            xlsSheet[line + 1, col].Style = xlstStyleH;
            //            xlsSheet[line + 2, col].Style = xlstStyleH;
            //        }

            //        if (ds != null)
            //        {
            //            int count = 0;
            //            DataTable dt = ds.Tables[0];
            //            if (dt.Rows.Count > 0)
            //            {
            //                foreach (DataRow row in dt.Rows)
            //                {
            //                    if (count >= 1)
            //                    {
            //                        xlsSheet.Rows.Insert(rWater + 1 + j);
            //                        j++;
            //                    }
            //                    count++;
            //                    int tmp = rWater + j;

            //                    string DateFrom = Func.ParseString(row["DateFrom"]);
            //                    string DateTo = Func.ParseString(row["DateTo"]);

            //                    string FromIndex = Func.ParseString(row["FromIndex"]);
            //                    string ToIndex = Func.ParseString(row["ToIndex"]);
            //                    string OtherFee01 = Func.ParseString(row["OtherFee01"]);
            //                    string OtherFee02 = Func.ParseString(row["OtherFee02"]);
            //                    string Mount = Func.ParseString(row["Mount"]);

            //                    xlsSheet[tmp, 1].Value = DateFrom;
            //                    xlsSheet[tmp, 2].Value = DateTo;
            //                    xlsSheet[tmp, 3].Value = FromIndex;
            //                    xlsSheet[tmp, 4].Value = ToIndex;
            //                    xlsSheet[tmp, 5].Value = Mount;
            //                    xlsSheet[tmp, 6].Value = row["PriceVND"];
            //                    xlsSheet[tmp, 7].Value = row["OtherFee01"];
            //                    xlsSheet[tmp, 8].Value = row["VatVND"];

            //                    xlsSheet[tmp, 9].Value = row["SumVND"];
            //                    xlsSheet[tmp, 10].Value = row["OtherFee02"];
            //                    xlsSheet[tmp, 11].Value = row["WaterPricePercent"];
            //                    xlsSheet[tmp, 12].Value = row["LastPriceVND"];

            //                    for (int col = 1; col <= 12; col++)
            //                    {
            //                        xlsSheet[tmp, col].Style = xlstStyle;
            //                    }
            //                    LastSumPriceVND[5] += Convert.ToDecimal(row["LastPriceVND"]);
            //                    LastSumPriceUSD[5] += Convert.ToDecimal(row["LastPriceUSD"]);

            //                    mCell = new XLCellRange(tmp, tmp, 12, 13);
            //                    xlsSheet.MergedCells.Add(mCell);
            //                }
            //                xlsSheet[rWater + 1 + j, 12].Value = LastSumPriceVND[5];
            //                mCell = new XLCellRange(rWater + 1 + j, rWater + 1 + j, 1, 11);
            //                xlsSheet.MergedCells.Add(mCell);

            //                mCell = new XLCellRange(rWater + 1 + j, rWater + 1 + j, 12, 13);
            //                xlsSheet.MergedCells.Add(mCell);

            //                for (int col = 1; col <= 13; col++)
            //                {
            //                    xlsSheet[rWater + 1 + j, col].Style = xlstStyleSum;
            //                }
            //                sumRow += dt.Rows.Count - 1;
            //            }
            //        }
            //    }

            //    //Service
            //    ds = new DataSet();

            //    sql = string.Empty;
            //    sql = " SELECT Service,dbo.fnDateTime(ServiceDateFrom) ServiceDateFrom,dbo.fnDateTime(ServiceDateTo) ServiceDateTo,PriceVND,PriceUSD,VatUSD,VatVND,Mount,Unit,SumVND,SumUSD,LastPriceVND,LastPriceUSD ";
            //    sql += " FROM   PaymentService";
            //    sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";
            //    sql += " Order By ServiceDate ";

            //    using (SqlCommand cm = db.CreateCommand(sql))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(cm);
            //        da.Fill(ds);
            //        line = rService - 3 + j;
            //        //Phi khác
            //        //XLCellRange mCell = new XLCellRange(line, line + 2, 1, 2);
            //        //xlsSheet.MergedCells.Add(mCell);

            //        XLCellRange mCell = new XLCellRange(line, line + 2, 1, 1);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line + 2, 2, 2);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line + 2, 3, 3);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line + 2, 4, 4);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 5, 5);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 6, 7);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 6, 7);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 8, 9);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 8, 9);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 10, 11);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 10, 11);
            //        xlsSheet.MergedCells.Add(mCell);

            //        for (int col = 1; col < 13; col++)
            //        {
            //            xlsSheet[line, col].Style = xlstStyleH;
            //            xlsSheet[line + 1, col].Style = xlstStyleH;
            //            xlsSheet[line + 2, col].Style = xlstStyleH;
            //        }
            //        mCell = new XLCellRange(line, line, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        if (ds != null)
            //        {
            //            int count = 0;
            //            DataTable dt = ds.Tables[0];

            //            if (dt.Rows.Count > 0)
            //            {

            //                foreach (DataRow row in dt.Rows)
            //                {
            //                    if (count >= 1)
            //                    {
            //                        xlsSheet.Rows.Insert(rService + 1 + j);
            //                        j++;
            //                    }
            //                    count++;
            //                    int tmp = rService + j;



            //                    string Service = Func.ParseString(row["Service"]);
            //                    string ServiceDateFrom = Func.ParseString(row["ServiceDateFrom"]);
            //                    string ServiceDateTo = Func.ParseString(row["ServiceDateTo"]);

            //                    string Mount = Func.ParseString(row["Mount"]);

            //                    xlsSheet[tmp, 1].Value = Service;
            //                    xlsSheet[tmp, 2].Value = Func.ParseString(row["Unit"]);
            //                    xlsSheet[tmp, 3].Value = ServiceDateFrom;
            //                    xlsSheet[tmp, 4].Value = ServiceDateTo;
            //                    xlsSheet[tmp, 5].Value = Mount;

            //                    xlsSheet[tmp, 6].Value = row["PriceUSD"];
            //                    xlsSheet[tmp, 7].Value = row["PriceVND"];

            //                    xlsSheet[tmp, 8].Value = row["SumUSD"];
            //                    xlsSheet[tmp, 9].Value = row["SumVND"];

            //                    xlsSheet[tmp, 10].Value = row["VatUSD"];
            //                    xlsSheet[tmp, 11].Value = row["VatVND"];

            //                    xlsSheet[tmp, 12].Value = row["LastPriceUSD"];
            //                    xlsSheet[tmp, 13].Value = row["LastPriceVND"];

            //                    //mCell = new XLCellRange(tmp, tmp, 1, 2);
            //                    //xlsSheet.MergedCells.Add(mCell);

            //                    for (int col = 1; col <= 13; col++)
            //                    {
            //                        xlsSheet[tmp, col].Style = xlstStyle;
            //                    }
            //                    LastSumPriceVND[6] += Convert.ToDecimal(row["LastPriceVND"]);
            //                    LastSumPriceUSD[6] += Convert.ToDecimal(row["LastPriceUSD"]);
            //                }
            //                xlsSheet[rService + 1 + j, 12].Value = LastSumPriceUSD[6];
            //                xlsSheet[rService + 1 + j, 13].Value = LastSumPriceVND[6];

            //                mCell = new XLCellRange(rService + 1 + j, rService + 1 + j, 1, 11);
            //                xlsSheet.MergedCells.Add(mCell);

            //                for (int col = 1; col <= 13; col++)
            //                {
            //                    xlsSheet[rService + 1 + j, col].Style = xlstStyleSum;
            //                }
            //                sumRow += dt.Rows.Count - 1;
            //            }
            //        }
            //    }

            //    //Paid
            //    sql = "Select  *";
            //    sql += " From    PaymentBillDetail";
            //    sql += " Where   BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";
            //    string strYearMonth = "";
            //    int lineTmp = rPaid - 2 + j;

            //    XLCellRange mCellTmp = new XLCellRange(lineTmp, lineTmp + 1, 1, 1);
            //    xlsSheet.MergedCells.Add(mCellTmp);

            //    mCellTmp = new XLCellRange(lineTmp, lineTmp, 2, 3);
            //    xlsSheet.MergedCells.Add(mCellTmp);

            //    mCellTmp = new XLCellRange(lineTmp, lineTmp, 4, 5);
            //    xlsSheet.MergedCells.Add(mCellTmp);

            //    mCellTmp = new XLCellRange(lineTmp, lineTmp, 6, 7);
            //    xlsSheet.MergedCells.Add(mCellTmp);

            //    mCellTmp = new XLCellRange(lineTmp, lineTmp, 8, 9);
            //    xlsSheet.MergedCells.Add(mCellTmp);

            //    mCellTmp = new XLCellRange(lineTmp, lineTmp, 12, 13);
            //    xlsSheet.MergedCells.Add(mCellTmp);


            //    Hashtable rowNo = new Hashtable();
            //    decimal[] PaidSumVND = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };
            //    decimal[] PaidSumUSD = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };

            //    DataTable dtPaid = DbHelper.GetDataTable(sql);
            //    for (int i = 0; i < dtPaid.Rows.Count; i++)
            //    {
            //        string PaymentType = Func.ParseString(dtPaid.Rows[i]["PaymentType"]);
            //        string MoneyUSD = Func.ParseString(dtPaid.Rows[i]["MoneyUSD"]);
            //        string MoneyVND = Func.ParseString(dtPaid.Rows[i]["MoneyVND"]);
            //        string PaidUSD = Func.ParseString(dtPaid.Rows[i]["PaidUSD"]);
            //        string PaidVND = Func.ParseString(dtPaid.Rows[i]["PaidVND"]);
            //        string ExchangeType = Func.ParseString(dtPaid.Rows[i]["ExchangeType"]);
            //        string UsdExchange = Func.ParseString(dtPaid.Rows[i]["UsdExchange"]);
            //        string YearMonth = Func.ParseString(dtPaid.Rows[i]["YearMonth"]);

            //        if (!rowNo.Contains(YearMonth))
            //        {
            //            if (rowNo.Count != 0)
            //            {
            //                xlsSheet.Rows.Insert(rPaid + j + 1);
            //                j++;
            //            }
            //            rowNo.Add(YearMonth, j);
            //        }
            //        int m = Func.ParseInt(rowNo[YearMonth]);
            //        strYearMonth = YearMonth;
            //        decimal tmpUSD = Convert.ToDecimal(MoneyUSD) - Convert.ToDecimal(PaidUSD);
            //        decimal tmpVND = Convert.ToDecimal(MoneyVND) - Convert.ToDecimal(PaidVND);

            //        PaidPriceUSD += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
            //        PaidPriceVND += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);

            //        xlsSheet[rPaid + m, 1].Value = YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4);
            //        switch (PaymentType)
            //        {
            //            case "1":
            //                //Rent
            //                xlsSheet[rPaid + m, 2].Value = dtPaid.Rows[i]["PaidUSD"];
            //                xlsSheet[rPaid + m, 3].Value = dtPaid.Rows[i]["PaidVND"];

            //                PaidSumUSD[0] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
            //                PaidSumVND[0] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);

            //                break;
            //            case "2":
            //                //Manager
            //                xlsSheet[rPaid + m, 4].Value = dtPaid.Rows[i]["PaidUSD"];
            //                xlsSheet[rPaid + m, 5].Value = dtPaid.Rows[i]["PaidVND"];

            //                PaidSumUSD[1] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
            //                PaidSumVND[1] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);

            //                break;
            //            case "3":
            //                //Parking
            //                xlsSheet[rPaid + m, 6].Value = dtPaid.Rows[i]["PaidUSD"];
            //                xlsSheet[rPaid + m, 7].Value = dtPaid.Rows[i]["PaidVND"];

            //                PaidSumUSD[2] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
            //                PaidSumVND[2] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
            //                break;
            //            case "4":
            //                //Extra
            //                xlsSheet[rPaid + m, 8].Value = dtPaid.Rows[i]["PaidUSD"];
            //                xlsSheet[rPaid + m, 9].Value = dtPaid.Rows[i]["PaidVND"];

            //                PaidSumUSD[3] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
            //                PaidSumVND[3] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
            //                break;
            //            case "5":
            //                xlsSheet[rPaid + m, 10].Value = dtPaid.Rows[i]["PaidVND"];

            //                PaidSumUSD[4] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
            //                PaidSumVND[4] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
            //                break;
            //            case "6":
            //                xlsSheet[rPaid + m, 11].Value = dtPaid.Rows[i]["PaidVND"];

            //                PaidSumUSD[5] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
            //                PaidSumVND[5] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
            //                break;
            //            case "7":
            //                xlsSheet[rPaid + m, 12].Value = dtPaid.Rows[i]["PaidUSD"];
            //                xlsSheet[rPaid + m, 13].Value = dtPaid.Rows[i]["PaidVND"];
            //                break;
            //            default:
            //                break;
            //        }
            //        for (int row = rPaid + m; row <= rPaid + 1 + j; row++)
            //        {
            //            for (int col = 1; col <= 13; col++)
            //            {
            //                xlsSheet[row, col].Style = xlstStyle;
            //            }
            //        }
            //    }
            //    lineTmp = rPaid - 2 + j;

            //    xlsSheet[lineTmp + 3, 2].Value = PaidSumUSD[0];
            //    xlsSheet[lineTmp + 3, 3].Value = PaidSumVND[0];
            //    xlsSheet[lineTmp + 3, 4].Value = PaidSumUSD[1];
            //    xlsSheet[lineTmp + 3, 5].Value = PaidSumVND[1];
            //    xlsSheet[lineTmp + 3, 6].Value = PaidSumUSD[2];
            //    xlsSheet[lineTmp + 3, 7].Value = PaidSumVND[2];
            //    xlsSheet[lineTmp + 3, 8].Value = PaidSumUSD[3];
            //    xlsSheet[lineTmp + 3, 9].Value = PaidSumVND[3];
            //    xlsSheet[lineTmp + 3, 10].Value = PaidSumVND[4];
            //    xlsSheet[lineTmp + 3, 11].Value = PaidSumVND[5];
            //    xlsSheet[lineTmp + 3, 12].Value = PaidSumUSD[6];
            //    xlsSheet[lineTmp + 3, 13].Value = PaidSumVND[6];

            //    for (int col = 1; col <= 13; col++)
            //    {
            //        xlsSheet[lineTmp + 3, col].Style = xlstStyleSum;
            //    }

            //    ///////////////DEPT
            //    sql = "  Select *";
            //    sql += " From   v_DeptBill";
            //    sql += " Where  BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth <= '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";
            //    sql += " And    (DeptUsd <> 0 or DeptVnd <> 0)";
            //    lineTmp = rDept - 2 + j;

            //    //Paid
            //    mCellTmp = new XLCellRange(lineTmp, lineTmp + 1, 1, 1);
            //    xlsSheet.MergedCells.Add(mCellTmp);

            //    mCellTmp = new XLCellRange(lineTmp, lineTmp, 2, 3);
            //    xlsSheet.MergedCells.Add(mCellTmp);

            //    mCellTmp = new XLCellRange(lineTmp, lineTmp, 4, 5);
            //    xlsSheet.MergedCells.Add(mCellTmp);

            //    mCellTmp = new XLCellRange(lineTmp, lineTmp, 6, 7);
            //    xlsSheet.MergedCells.Add(mCellTmp);

            //    mCellTmp = new XLCellRange(lineTmp, lineTmp, 8, 9);
            //    xlsSheet.MergedCells.Add(mCellTmp);

            //    mCellTmp = new XLCellRange(lineTmp, lineTmp, 12, 13);
            //    xlsSheet.MergedCells.Add(mCellTmp);


            //    rowNo = new Hashtable();
            //    decimal DeptPriceVND = 0;
            //    decimal DeptPriceUSD = 0;

            //    decimal[] DeptSumVND = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };
            //    decimal[] DeptSumUSD = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };


            //    DataTable dtDept = DbHelper.GetDataTable(sql);
            //    for (int i = 0; i < dtDept.Rows.Count; i++)
            //    {
            //        string PaymentType = Func.ParseString(dtDept.Rows[i]["PaymentType"]);
            //        string DeptUSD = Func.ParseString(dtDept.Rows[i]["DeptUSD"]);
            //        string DeptVND = Func.ParseString(dtDept.Rows[i]["DeptVND"]);
            //        string YearMonth = Func.ParseString(dtDept.Rows[i]["YearMonth"]);

            //        if (!rowNo.Contains(YearMonth))
            //        {
            //            if (rowNo.Count != 0)
            //            {
            //                xlsSheet.Rows.Insert(rDept + j + 1);
            //                j++;
            //            }
            //            rowNo.Add(YearMonth, j);
            //        }
            //        int m = Func.ParseInt(rowNo[YearMonth]);
            //        strYearMonth = YearMonth;

            //        DeptPriceUSD += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
            //        DeptPriceVND += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);

            //        xlsSheet[rDept + m, 1].Value = YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4);
            //        switch (PaymentType)
            //        {
            //            case "1":
            //                //Rent
            //                xlsSheet[rDept + m, 2].Value = dtDept.Rows[i]["DeptUSD"];
            //                xlsSheet[rDept + m, 3].Value = dtDept.Rows[i]["DeptVND"];

            //                DeptSumUSD[0] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
            //                DeptSumVND[0] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);

            //                break;
            //            case "2":
            //                //Manager
            //                xlsSheet[rDept + m, 4].Value = dtDept.Rows[i]["DeptUSD"];
            //                xlsSheet[rDept + m, 5].Value = dtDept.Rows[i]["DeptVND"];

            //                DeptSumUSD[1] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
            //                DeptSumVND[1] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);

            //                break;
            //            case "3":
            //                //Parking
            //                xlsSheet[rDept + m, 6].Value = dtDept.Rows[i]["DeptUSD"];
            //                xlsSheet[rDept + m, 7].Value = dtDept.Rows[i]["DeptVND"];

            //                DeptSumUSD[2] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
            //                DeptSumVND[2] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
            //                break;
            //            case "4":
            //                //Extra
            //                xlsSheet[rDept + m, 8].Value = dtDept.Rows[i]["DeptUSD"];
            //                xlsSheet[rDept + m, 9].Value = dtDept.Rows[i]["DeptVND"];

            //                DeptSumUSD[3] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
            //                DeptSumVND[3] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
            //                break;
            //            case "5":
            //                xlsSheet[rDept + m, 10].Value = dtDept.Rows[i]["DeptVND"];

            //                DeptSumUSD[4] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
            //                DeptSumVND[4] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
            //                break;
            //            case "6":
            //                xlsSheet[rDept + m, 11].Value = dtDept.Rows[i]["DeptVND"];

            //                DeptSumUSD[5] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
            //                DeptSumVND[5] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
            //                break;
            //            case "7":
            //                xlsSheet[rDept + m, 12].Value = dtDept.Rows[i]["DeptUSD"];
            //                xlsSheet[rDept + m, 13].Value = dtDept.Rows[i]["DeptVND"];

            //                DeptSumUSD[6] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
            //                DeptSumVND[6] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
            //                break;
            //            default:
            //                break;
            //        }
            //        for (int row = rDept + m; row <= rDept + 1 + j; row++)
            //        {
            //            for (int col = 1; col <= 13; col++)
            //            {
            //                xlsSheet[row, col].Style = xlstStyle;
            //            }
            //        }
            //    }
            //    lineTmp = rDept - 2 + j;

            //    xlsSheet[lineTmp + 3, 2].Value = DeptSumUSD[0];
            //    xlsSheet[lineTmp + 3, 3].Value = DeptSumVND[0];
            //    xlsSheet[lineTmp + 3, 4].Value = DeptSumUSD[1];
            //    xlsSheet[lineTmp + 3, 5].Value = DeptSumVND[1];
            //    xlsSheet[lineTmp + 3, 6].Value = DeptSumUSD[2];
            //    xlsSheet[lineTmp + 3, 7].Value = DeptSumVND[2];
            //    xlsSheet[lineTmp + 3, 8].Value = DeptSumUSD[3];
            //    xlsSheet[lineTmp + 3, 9].Value = DeptSumVND[3];
            //    xlsSheet[lineTmp + 3, 10].Value = DeptSumVND[4];
            //    xlsSheet[lineTmp + 3, 11].Value = DeptSumVND[5];
            //    xlsSheet[lineTmp + 3, 12].Value = DeptSumUSD[6];
            //    xlsSheet[lineTmp + 3, 13].Value = DeptSumVND[6];

            //    for (int col = 1; col <= 13; col++)
            //    {
            //        xlsSheet[lineTmp + 3, col].Style = xlstStyleSum;
            //    }

            //    /////////////////DEPT
            //    ////Dept
            //    //mCellTmp = new XLCellRange(lineTmp, lineTmp + 1, 1, 1);
            //    //xlsSheet.MergedCells.Add(mCellTmp);

            //    //mCellTmp = new XLCellRange(lineTmp, lineTmp, 2, 3);
            //    //xlsSheet.MergedCells.Add(mCellTmp);

            //    //mCellTmp = new XLCellRange(lineTmp, lineTmp, 4, 5);
            //    //xlsSheet.MergedCells.Add(mCellTmp);

            //    //mCellTmp = new XLCellRange(lineTmp, lineTmp, 6, 7);
            //    //xlsSheet.MergedCells.Add(mCellTmp);

            //    //mCellTmp = new XLCellRange(lineTmp, lineTmp, 8, 9);
            //    //xlsSheet.MergedCells.Add(mCellTmp);

            //    //mCellTmp = new XLCellRange(lineTmp, lineTmp, 12, 13);
            //    //xlsSheet.MergedCells.Add(mCellTmp);

            //    //for (int row = lineTmp; row <= rDept + 1 + j; row++)
            //    //{
            //    //    for (int col = 1; col <= 13; col++)
            //    //    {
            //    //        xlsSheet[row, col].Style = xlstStyle;
            //    //    }
            //    //}
            //    //xlsSheet[lineTmp + 3, 1].Style = xlstStyleSum;

            //    decimal AllSumVND = 0;
            //    decimal AllSumUSD = 0;
            //    for (int i = 0; i < 7; i++)
            //    {
            //        AllSumVND += LastSumPriceVND[i];
            //        AllSumUSD += LastSumPriceUSD[i];
            //    }

            //    AllSumVND -= PaidPriceVND;
            //    AllSumUSD -= PaidPriceUSD;

            //    xlsSheet[rSumVND + j, cSumVND].Value = Func.FormatNumber_New(AllSumUSD);
            //    xlsSheet[rSumVND + j, cSumVND].Value += "(USD)";
            //    xlsSheet[rSumVND + j, cSumVND + 1].Value = Func.FormatNumber_New(AllSumVND);
            //    xlsSheet[rSumVND + j, cSumVND + 1].Value += "(VND)";

            //    AllSumVND += Convert.ToDecimal(AllSumUSD * Convert.ToDecimal(txtUsdExchange.Text));

            //    string strMoney = Func.docso(Convert.ToInt32(AllSumVND));

            //    xlsSheet[rContract, cContract].Value = xlsSheet[rContract, cContract].Value.ToString().Replace("{%HOP_DONG%}", contract.Substring(1));
            //    xlsSheet[rSum + j, cSum].Value = Convert.ToInt32(AllSumVND);

            //    mCellTmp = new XLCellRange(rSum + j, rSum + j, cSum, cSum + 1);
            //    xlsSheet.MergedCells.Add(mCellTmp);
            //    //xlsSheet[rSum + j, cSum].Style = xlstStyleSum;
            //    //xlsSheet[rSum + j, cSum + 1].Style = xlstStyleSum;

            //    xlsSheet[rSumRead + j, cSumRead].Value = xlsSheet[rSumRead + j, cSumRead].Value.ToString().Replace("{%TONG_CHU%}", strMoney.ToUpper());

            //    xlbBook.Save(fileNameDes);
            //    ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);
            //}
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
            //int rBillNo = 0;
            //int cBillNo = 1;

            //int rBillDate = 0;
            //int cBillDate = 10;

            //int rBillMonth = 2;
            //int cBillMonth = 0;

            //int rContact = 5;
            //int cContact = 3;

            //int rCustomer = 5;
            //int cCustomer = 7;

            //int rContract = 7;
            //int cContract = 1;

            //int rRate = 11;
            //int cRate = 9;

            //int rRateDate = 11;
            //int cRateDate = 12;

            //int rRent = 15;

            //int rManager = 23;

            //int rParking = 31;

            //int rExtra = 39;

            //int rElec = 47;

            //int rWater = 55;

            //int rService = 63;

            //int rPaid = 70;

            //int rDept = 77;

            //int rOffice = 88;
            //int cOffice = 3;

            //int rPhone = 89;
            //int cPhone = 3;

            //int rBank = 88;
            //int cBank = 7;

            //int rAccountName = 89;
            //int cAccountName = 7;

            //int rAccount = 90;
            //int cAccount = 7;

            //int rSum = 81;
            //int cSum = 12;

            //int rSumVND = 80;
            //int cSumVND = 12;

            //int rSumRead = 82;
            //int cSumRead = 13;

            //int check = DbHelper.GetCount("Select count(*) from PaymentBillInfo Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + lblCustomerId.Text + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'");
            //if (check == 0)
            //{
            //    mvMessage.AddError("Xin vui lòng tạo hóa đơn trước khi xem");
            //    return;
            //}
            //mvMessage.CheckRequired(txtBillDate, "Ngày xuất Hóa đơn là danh mục bắt buộc");
            //mvMessage.CheckRequired(txtBillNo, "Số Hóa đơn là danh mục bắt buộc");
            //mvMessage.CheckRequired(txtUsdExchange, "Tỉ giá USD-VN là danh mục bắt buộc");
            //mvMessage.CheckRequired(txtUsdExchangeDate, "Ngày tỉ giá là danh mục bắt buộc");
            ////ShowData(drpYear.SelectedValue + drpMonth.SelectedValue);
            //C1XLBook xlbBook = new C1XLBook();
            //string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\BillTongQuat.xlsx");
            //if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])))
            //{
            //    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])));
            //}

            //XLStyle xlstStyle = new XLStyle(xlbBook);
            //xlstStyle.AlignHorz = XLAlignHorzEnum.Center;
            //xlstStyle.AlignVert = XLAlignVertEnum.Center;
            //xlstStyle.WordWrap = true;
            //xlstStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            //xlstStyle.SetBorderColor(Color.Black);
            //xlstStyle.BorderBottom = XLLineStyleEnum.Thin;
            //xlstStyle.BorderTop = XLLineStyleEnum.Thin;
            //xlstStyle.BorderLeft = XLLineStyleEnum.Thin;
            //xlstStyle.BorderRight = XLLineStyleEnum.Thin;
            //xlstStyle.Format = "#,##0.00_);(#,##0.00)";

            //XLStyle xlstStyleH = new XLStyle(xlbBook);
            //xlstStyleH.AlignHorz = XLAlignHorzEnum.Center;
            //xlstStyleH.AlignVert = XLAlignVertEnum.Center;
            //xlstStyleH.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            //xlstStyleH.SetBorderColor(Color.Black);
            //xlstStyleH.BorderBottom = XLLineStyleEnum.Thin;
            //xlstStyleH.BorderTop = XLLineStyleEnum.Thin;
            //xlstStyleH.BorderLeft = XLLineStyleEnum.Thin;
            //xlstStyleH.BorderRight = XLLineStyleEnum.Thin;
            //xlstStyleH.WordWrap = true;

            //XLStyle xlstStyleSum = new XLStyle(xlbBook);
            //xlstStyleSum.AlignHorz = XLAlignHorzEnum.Right;
            //xlstStyleSum.AlignVert = XLAlignVertEnum.Center;
            //xlstStyleSum.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            //xlstStyleSum.SetBorderColor(Color.Black);
            //xlstStyleSum.BorderBottom = XLLineStyleEnum.Thin;
            //xlstStyleSum.BorderTop = XLLineStyleEnum.Thin;
            //xlstStyleSum.BorderLeft = XLLineStyleEnum.Thin;
            //xlstStyleSum.BorderRight = XLLineStyleEnum.Thin;
            //xlstStyleSum.WordWrap = true;
            //xlstStyleSum.Format = "#,##0.00_);(#,##0.00)";

            //string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
            //string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BillTongQuat" + strDT + ".xlsx";
            //string strFilePathExport = @"../../Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + @"/BillTongQuat" + strDT + ".xlsx";

            //string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

            ////string fileNameDes = HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\TongHopDienTich" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
            //File.Copy(fileName, fileNameDes);

            //xlbBook.Load(fileNameDes);
            //XLSheet xlsSheet = xlbBook.Sheets["TongHop"];

            ////Bill No
            //xlsSheet[rBillNo, cBillNo].Value = xlsSheet[rBillNo, cBillNo].Value.ToString().Replace("{%BILL_NO%}", txtBillNo.Text);

            ////Ngay Thang Nam
            //DateTime dtime = DateTime.Today;

            //string strTmp = xlsSheet[rBillDate, cBillDate].Value.ToString().Replace("{%NGAY%}", dtime.ToString("dd"));
            //strTmp = strTmp.Replace("{%THANG%}", dtime.ToString("MM"));
            //xlsSheet[rBillDate, cBillDate].Value = strTmp.Replace("{%NAM%}", dtime.ToString("yyyy"));

            ////Nam
            //xlsSheet[rBillMonth, cBillMonth].Value = xlsSheet[rBillMonth, cBillMonth].Value.ToString().Replace("{%NAM_THANG%}", drpMonth.SelectedValue + "/" + drpYear.SelectedValue);

            //using (SqlDatabase db = new SqlDatabase())
            //{
            //    DataSet ds = new DataSet();
            //    string sql = string.Empty;

            //    sql = " SELECT Name, ContactName";
            //    sql += " FROM Customer";
            //    sql += " WHERE CustomerId = '" + lblCustomerId.Text + "' ";

            //    using (SqlCommand cm = db.CreateCommand(sql))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(cm);
            //        da.Fill(ds);

            //        if (ds != null)
            //        {
            //            DataTable dt = ds.Tables[0];
            //            foreach (DataRow rowType in dt.Rows)
            //            {
            //                string Name = rowType[0].ToString();
            //                string ContactName = rowType[1].ToString();

            //                //Customer
            //                xlsSheet[rCustomer, cCustomer].Value = xlsSheet[rCustomer, cCustomer].Value.ToString().Replace("{%TEN_CONG_TY%}", Name);
            //                //Contact
            //                xlsSheet[rContact, cContact].Value = xlsSheet[rContact, cContact].Value.ToString().Replace("{%NGUOI_DAI_DIEN%}", ContactName);
            //            }
            //        }
            //    }
            //    Hashtable contractIdLst = new Hashtable();
            //    string contract = "";
            //    ds = new DataSet();
            //    sql = " SELECT Bank,Account,AccountName,Office,OfficeAddress,OfficePhone";
            //    sql += " FROM Mst_Building";
            //    sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' ";
            //    using (SqlCommand cm = db.CreateCommand(sql))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(cm);
            //        da.Fill(ds);

            //        if (ds != null)
            //        {
            //            DataTable dt = ds.Tables[0];
            //            foreach (DataRow rowType in dt.Rows)
            //            {
            //                string Bank = rowType["Bank"].ToString();
            //                string Account = rowType["Account"].ToString();
            //                string AccountName = rowType["AccountName"].ToString();
            //                string Office = rowType["Office"].ToString();
            //                string OfficeAddress = rowType["OfficeAddress"].ToString();
            //                string OfficePhone = rowType["OfficePhone"].ToString();

            //                xlsSheet[rOffice, cOffice].Value = xlsSheet[rOffice, cOffice].Value.ToString().Replace("{%VAN_PHONG%}", Office);
            //                xlsSheet[rPhone, cPhone].Value = xlsSheet[rPhone, cPhone].Value.ToString().Replace("{%DIEN_THOAI%}", OfficePhone);

            //                xlsSheet[rBank, cBank].Value = xlsSheet[rBank, cBank].Value.ToString().Replace("{%NGAN_HANG%}", Bank);
            //                xlsSheet[rAccountName, cAccountName].Value = xlsSheet[rAccountName, cAccountName].Value.ToString().Replace("{%TEN_TAI_KHOAN%}", AccountName);
            //                xlsSheet[rAccount, cAccount].Value = xlsSheet[rAccount, cAccount].Value.ToString().Replace("{%SO_TAI_KHOAN%}", Account);
            //            }
            //        }
            //    }

            //    xlsSheet[rRate, cRate].Value = xlsSheet[rRate, cRate].Value.ToString().Replace("{%TI_GIA%}", txtUsdExchange.Text);
            //    xlsSheet[rRateDate, cRateDate].Value = xlsSheet[rRateDate, cRateDate].Value.ToString().Replace("{%NGAY_AP_DUNG%}", txtUsdExchangeDate.Text);

            //    //Thue phong
            //    ds = new DataSet();
            //    sql = " Select *";
            //    sql += " FROM PaymentRoom";
            //    sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth in (" + lsYearmonth + ")";

            //    int sumRow = 0;
            //    int j = 0;
            //    decimal[] LastSumPriceVND = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };
            //    decimal[] LastSumPriceUSD = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };

            //    decimal PaidPriceVND = 0;
            //    decimal PaidPriceUSD = 0;

            //    int line = 0;
            //    using (SqlCommand cm = db.CreateCommand(sql))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(cm);
            //        da.Fill(ds);

            //        line = rRent - 3 + j;

            //        XLCellRange mCell = new XLCellRange(line, line + 2, 1, 3);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 4, 5);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 4, 5);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 2, line + 2, 4, 5);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 6, 7);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 6, 7);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 8, 9);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 8, 9);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 10, 11);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 10, 11);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        if (ds != null)
            //        {
            //            int count = 0;
            //            DataTable dt = ds.Tables[0];
            //            foreach (DataRow rowType in dt.Rows)
            //            {
            //                if (count >= 1)
            //                {
            //                    xlsSheet.Rows.Insert(rRent + 1 + j);
            //                    j++;
            //                }
            //                count++;
            //                int tmp = rRent + j;

            //                string ContractId = Func.ParseString(rowType["ContractId"]);
            //                string ContractNo = Func.ParseString(rowType["ContractNo"]);
            //                string YearMonth = Func.ParseString(rowType["YearMonth"]);
            //                string Area = Func.ParseString(rowType["Area"]);
            //                string Name = Func.ParseString(rowType["Name"]);
            //                string Regional = Func.ParseString(rowType["Regional"]);
            //                string Floor = Func.ParseString(rowType["Floor"]);

            //                string BeginContract = Func.ParseString(rowType["BeginContract"]);


            //                if (!contractIdLst.ContainsKey(ContractId + "(" + BeginContract.Substring(0, 10) + ")"))
            //                {
            //                    contractIdLst.Add(ContractId + "(" + BeginContract.Substring(0, 10) + ")", ContractNo + "(" + BeginContract.Substring(0, 10) + ")");
            //                    contract += ";" + ContractNo + "(" + BeginContract.Substring(0, 10) + ")";
            //                }

            //                xlsSheet[tmp, 1].Value = Name;
            //                xlsSheet[tmp, 4].Value = rowType["Area"];
            //                xlsSheet[tmp, 6].Value = rowType["MonthRentPriceUSD"];
            //                xlsSheet[tmp, 7].Value = rowType["MonthRentPriceVND"];

            //                xlsSheet[tmp, 8].Value = rowType["MonthRentSumUSD"];
            //                xlsSheet[tmp, 9].Value = rowType["MonthRentSumVND"];

            //                xlsSheet[tmp, 10].Value = rowType["VatRentPriceUSD"];
            //                xlsSheet[tmp, 11].Value = rowType["VatRentPriceVND"];

            //                xlsSheet[tmp, 12].Value = rowType["LastRentSumUSD"];
            //                xlsSheet[tmp, 13].Value = rowType["LastRentSumVND"];

            //                XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
            //                xlsSheet.MergedCells.Add(mrCell);

            //                mrCell = new XLCellRange(tmp, tmp, 4, 5);
            //                xlsSheet.MergedCells.Add(mrCell);

            //                LastSumPriceVND[0] += Convert.ToDecimal(rowType["LastRentSumVND"]);
            //                LastSumPriceUSD[0] += Convert.ToDecimal(rowType["LastRentSumUSD"]);

            //            }
            //            mCell = new XLCellRange(rRent + 1 + j, rRent + 1 + j, 1, 11);
            //            xlsSheet.MergedCells.Add(mCell);

            //            xlsSheet[rRent + 1 + j, 12].Value = LastSumPriceUSD[0];
            //            xlsSheet[rRent + 1 + j, 13].Value = LastSumPriceVND[0];

            //            for (int row = rRent + sumRow; row <= rRent + dt.Rows.Count; row++)
            //            {
            //                for (int col = 1; col <= 13; col++)
            //                {
            //                    xlsSheet[row, col].Style = xlstStyle;
            //                }
            //            }
            //            sumRow += dt.Rows.Count - 1;

            //            ////////////////////////
            //            for (int col = 1; col <= 13; col++)
            //            {
            //                xlsSheet[rRent + 1 + j, col].Style = xlstStyleSum;
            //            }
            //            line = rManager - 3 + j;
            //            mCell = new XLCellRange(line, line + 2, 1, 3);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line, line, 4, 5);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line + 1, line + 1, 4, 5);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line + 2, line + 2, 4, 5);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line, line, 6, 7);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line + 1, line + 1, 6, 7);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line, line, 8, 9);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line + 1, line + 1, 8, 9);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line, line, 10, 11);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line + 1, line + 1, 10, 11);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line, line, 12, 13);
            //            xlsSheet.MergedCells.Add(mCell);

            //            mCell = new XLCellRange(line + 1, line + 1, 12, 13);
            //            xlsSheet.MergedCells.Add(mCell);


            //            count = 0;
            //            foreach (DataRow row in dt.Rows)
            //            {
            //                if (count >= 1)
            //                {
            //                    xlsSheet.Rows.Insert(rManager + 1 + j);
            //                    j++;
            //                }
            //                count++;
            //                int tmp = rManager + j;

            //                string YearMonth = Func.ParseString(row["YearMonth"]);
            //                string Area = Func.ParseString(row["Area"]);
            //                string Name = Func.ParseString(row["Name"]);

            //                xlsSheet[tmp, 1].Value = Name;
            //                xlsSheet[tmp, 4].Value = row["Area"];
            //                xlsSheet[tmp, 6].Value = row["MonthManagerPriceUSD"];
            //                xlsSheet[tmp, 7].Value = row["MonthManagerPriceVND"];

            //                xlsSheet[tmp, 8].Value = row["MonthManagerSumUSD"];
            //                xlsSheet[tmp, 9].Value = row["MonthManagerSumVND"];

            //                xlsSheet[tmp, 19].Value = row["VatManagerPriceUSD"];
            //                xlsSheet[tmp, 11].Value = row["VatManagerPriceVND"];

            //                xlsSheet[tmp, 12].Value = row["LastManagerSumUSD"];
            //                xlsSheet[tmp, 13].Value = row["LastManagerSumVND"];

            //                XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
            //                xlsSheet.MergedCells.Add(mrCell);

            //                mrCell = new XLCellRange(tmp, tmp, 4, 5);
            //                xlsSheet.MergedCells.Add(mrCell);

            //                LastSumPriceVND[1] += Convert.ToDecimal(row["LastManagerSumVND"]);
            //                LastSumPriceUSD[1] += Convert.ToDecimal(row["LastManagerSumUSD"]);
            //            }
            //            mCell = new XLCellRange(rManager + 1 + j, rManager + 1 + j, 1, 11);
            //            xlsSheet.MergedCells.Add(mCell);

            //            xlsSheet[rManager + 1 + j, 12].Value = LastSumPriceUSD[1];
            //            xlsSheet[rManager + 1 + j, 13].Value = LastSumPriceVND[1];

            //            for (int row = rManager + sumRow; row <= rManager + sumRow + dt.Rows.Count; row++)
            //            {
            //                for (int col = 1; col <= 13; col++)
            //                {
            //                    xlsSheet[row, col].Style = xlstStyle;
            //                }
            //            }

            //            for (int col = 1; col <= 13; col++)
            //            {
            //                xlsSheet[rManager + 1 + j, col].Style = xlstStyleSum;
            //            }
            //            sumRow += dt.Rows.Count - 1;

            //        }
            //    }

            //    ds = new DataSet();
            //    //Xuất ra toàn bộ nội dung theo Trang
            //    sql = " SELECT COUNT(*) AS Num, YearMonth, TariffsParkingName, PriceVND, PriceUSD, SUM(VatVND) AS VatVND,SUM(VatUSD) AS VatUSD, SUM(SumVND) AS SumVND, SUM(SumUSD) AS SumUSD, SUM(LastPriceVND) AS LastPriceVND";
            //    sql += "        , SUM(LastPriceUSD) AS LastPriceUSD";
            //    sql += " FROM         dbo.PaymentParking";
            //    sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth in (" + lsYearmonth + ")";
            //    sql += " GROUP BY YearMonth, TariffsParkingName, PriceVND, PriceUSD, Vat, daysParking";

            //    using (SqlCommand cm = db.CreateCommand(sql))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(cm);
            //        da.Fill(ds);

            //        line = rParking - 3 + j;
            //        XLCellRange mCell = new XLCellRange(line, line + 2, 1, 3);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 4, 5);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 4, 5);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 2, line + 2, 4, 5);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 6, 7);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 6, 7);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 8, 9);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 8, 9);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 10, 11);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 10, 11);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);
            //        if (ds != null)
            //        {
            //            int count = 0;
            //            DataTable dt = ds.Tables[0];

            //            foreach (DataRow row in dt.Rows)
            //            {
            //                if (count >= 1)
            //                {
            //                    xlsSheet.Rows.Insert(rParking + 1 + j);
            //                    j++;
            //                }
            //                count++;
            //                int tmp = rParking + j;

            //                string Num = Func.ParseString(row["Num"]);
            //                string TariffsParkingName = Func.ParseString(row["TariffsParkingName"]);

            //                xlsSheet[tmp, 1].Value = TariffsParkingName;
            //                xlsSheet[tmp, 4].Value = Num;
            //                xlsSheet[tmp, 6].Value = row["PriceUSD"];
            //                xlsSheet[tmp, 7].Value = row["PriceVND"];

            //                xlsSheet[tmp, 8].Value = row["SumUSD"];
            //                xlsSheet[tmp, 9].Value = row["SumVND"];

            //                xlsSheet[tmp, 10].Value = row["VatUSD"];
            //                xlsSheet[tmp, 11].Value = row["VatVND"];

            //                xlsSheet[tmp, 12].Value = row["LastPriceUSD"];
            //                xlsSheet[tmp, 13].Value = row["LastPriceVND"];

            //                XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
            //                xlsSheet.MergedCells.Add(mrCell);

            //                mrCell = new XLCellRange(tmp, tmp, 4, 5);
            //                xlsSheet.MergedCells.Add(mrCell);

            //                LastSumPriceVND[2] += Convert.ToDecimal(row["LastPriceVND"]);
            //                LastSumPriceUSD[2] += Convert.ToDecimal(row["LastPriceUSD"]);
            //            }
            //            xlsSheet[rParking + 1 + j, 12].Value = LastSumPriceUSD[2];
            //            xlsSheet[rParking + 1 + j, 13].Value = LastSumPriceVND[2];

            //            mCell = new XLCellRange(rParking + 1 + j, rParking + 1 + j, 1, 11);
            //            xlsSheet.MergedCells.Add(mCell);

            //            for (int row = rParking + sumRow; row <= rParking + sumRow + dt.Rows.Count; row++)
            //            {
            //                for (int col = 1; col <= 13; col++)
            //                {
            //                    xlsSheet[row, col].Style = xlstStyle;
            //                }
            //            }

            //            for (int col = 1; col <= 13; col++)
            //            {
            //                xlsSheet[rParking + 1 + j, col].Style = xlstStyleSum;
            //            }
            //            sumRow += dt.Rows.Count - 1;
            //        }
            //    }

            //    ds = new DataSet();
            //    sql = "SELECT id";
            //    sql += " ,YearMonth,BuildingId,CustomerId,RoomId,ExtraHour,VAT,OtherFee01,OtherFee02";
            //    sql += " ,PriceUSD,PriceVND,VatUSD,VatVND,SumUSD,SumVND,LastPriceUSD,LastPriceVND";
            //    sql += " ,RentArea,dbo.fnDateTime(FromWD) BeginDate,dbo.fnDateTime(EndWD) EndDate,ExtratimeType";
            //    sql += " FROM PaymentExtraTimeMonth";
            //    sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth in (" + lsYearmonth + ")";

            //    using (SqlCommand cm = db.CreateCommand(sql))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(cm);
            //        da.Fill(ds);
            //        line = rExtra - 3 + j;
            //        //Phi dien
            //        XLCellRange mCell = new XLCellRange(line, line + 2, 1, 3);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line + 2, 4, 4);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 6, 7);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 6, 7);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 8, 9);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 8, 9);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 10, 11);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 10, 11);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        if (ds != null)
            //        {
            //            int count = 0;
            //            DataTable dt = ds.Tables[0];

            //            foreach (DataRow row in dt.Rows)
            //            {
            //                if (count >= 1)
            //                {
            //                    xlsSheet.Rows.Insert(rExtra + 1 + j);
            //                    j++;
            //                }
            //                count++;
            //                int tmp = rExtra + j;

            //                string ExtraHour = Func.ParseString(row["ExtraHour"]);
            //                string BeginDate = Func.ParseString(row["BeginDate"]);
            //                string EndDate = Func.ParseString(row["EndDate"]);

            //                string ExtratimeType = Func.ParseString(row["ExtratimeType"]);

            //                xlsSheet[tmp, 1].Value = BeginDate + "~" + EndDate;
            //                xlsSheet[tmp, 5].Value = ExtraHour;

            //                xlsSheet[tmp, 4].Value = "Diện tích";
            //                if ("0".Equals(ExtratimeType))
            //                {
            //                    xlsSheet[tmp, 4].Value = "m2*h";
            //                }
            //                xlsSheet[tmp, 6].Value = row["PriceUSD"];
            //                xlsSheet[tmp, 7].Value = row["PriceVND"];

            //                xlsSheet[tmp, 8].Value = row["SumUSD"];
            //                xlsSheet[tmp, 9].Value = row["SumVND"];

            //                xlsSheet[tmp, 10].Value = row["VatUSD"];
            //                xlsSheet[tmp, 11].Value = row["VatVND"];

            //                xlsSheet[tmp, 12].Value = row["LastPriceUSD"];
            //                xlsSheet[tmp, 13].Value = row["LastPriceVND"];

            //                LastSumPriceVND[3] += Convert.ToDecimal(row["LastPriceVND"]);
            //                LastSumPriceUSD[3] += Convert.ToDecimal(row["LastPriceUSD"]);
            //                //}
            //                XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
            //                xlsSheet.MergedCells.Add(mrCell);

            //                for (int col = 1; col <= 13; col++)
            //                {
            //                    xlsSheet[tmp, col].Style = xlstStyle;
            //                }

            //            }
            //            mCell = new XLCellRange(rExtra + 1 + j, rExtra + 1 + j, 1, 11);
            //            xlsSheet.MergedCells.Add(mCell);

            //            xlsSheet[rExtra + 1 + j, 12].Value = LastSumPriceUSD[3];
            //            xlsSheet[rExtra + 1 + j, 13].Value = LastSumPriceVND[3];

            //            for (int row = rExtra + sumRow; row <= rExtra + sumRow + dt.Rows.Count; row++)
            //            {
            //                for (int col = 1; col <= 13; col++)
            //                {
            //                    xlsSheet[row, col].Style = xlstStyle;
            //                }
            //            }

            //            for (int col = 1; col <= 12; col++)
            //            {
            //                xlsSheet[rExtra + 1 + j, col].Style = xlstStyleSum;
            //            }
            //            sumRow += dt.Rows.Count - 1;
            //        }
            //    }

            //    ds = new DataSet();
            //    //Dien
            //    //Xuất ra toàn bộ nội dung theo Trang
            //    sql = " SELECT dbo.fnDateTime(A.DateFrom) DateFrom, dbo.fnDateTime(A.DateTo) DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVND, B.PriceUSD, B.SumVND, B.SumUSD, ";
            //    sql += "        B.VatVND, B.VatUSD, B.LastPriceVND, B.LastPriceUSD, B.Name, B.WaterPricePercent,B.ElecPricePercent ";
            //    sql += " FROM   PaymentElecWater AS A INNER JOIN ";
            //    sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId";
            //    sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfWaterId = 0  and A.YearMonth in (" + lsYearmonth + ")";
            //    sql += " Order by A.DateFrom, B.FromIndex";

            //    using (SqlCommand cm = db.CreateCommand(sql))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(cm);
            //        da.Fill(ds);

            //        line = rElec - 3 + j;
            //        //Phi dien
            //        XLCellRange mCell = new XLCellRange(line, line + 2, 1, 1);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line + 2, 2, 2);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 3, 3);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 4, 4);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 5, 5);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 7, 7);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 8, 8);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 9, 9);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 10, 10);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 11, 11);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        for (int col = 1; col < 13; col++)
            //        {
            //            xlsSheet[line, col].Style = xlstStyleH;
            //            xlsSheet[line + 1, col].Style = xlstStyleH;
            //            xlsSheet[line + 2, col].Style = xlstStyleH;
            //        }

            //        if (ds != null)
            //        {
            //            int count = 0;
            //            DataTable dt = ds.Tables[0];
            //            if (dt.Rows.Count > 0)
            //            {
            //                foreach (DataRow row in dt.Rows)
            //                {
            //                    if (count >= 1)
            //                    {
            //                        xlsSheet.Rows.Insert(rElec + 1 + j);
            //                        j++;

            //                    }
            //                    count++;
            //                    int tmp = rElec + j;

            //                    string DateFrom = Func.ParseString(row["DateFrom"]);
            //                    string DateTo = Func.ParseString(row["DateTo"]);

            //                    string FromIndex = Func.ParseString(row["FromIndex"]);
            //                    string ToIndex = Func.ParseString(row["ToIndex"]);
            //                    string OtherFee01 = Func.ParseString(row["OtherFee01"]);
            //                    string OtherFee02 = Func.ParseString(row["OtherFee02"]);
            //                    string Mount = Func.ParseString(row["Mount"]);
            //                    string ElecPricePercent = Func.ParseString(row["ElecPricePercent"]);

            //                    xlsSheet[tmp, 1].Value = DateFrom;
            //                    xlsSheet[tmp, 2].Value = DateTo;
            //                    xlsSheet[tmp, 3].Value = FromIndex;
            //                    xlsSheet[tmp, 4].Value = ToIndex;
            //                    xlsSheet[tmp, 5].Value = OtherFee01;
            //                    xlsSheet[tmp, 6].Value = Mount;
            //                    xlsSheet[tmp, 7].Value = row["PriceVND"];
            //                    xlsSheet[tmp, 8].Value = row["VatVND"];

            //                    xlsSheet[tmp, 9].Value = row["SumVND"];
            //                    xlsSheet[tmp, 10].Value = row["OtherFee02"];
            //                    xlsSheet[tmp, 11].Value = row["ElecPricePercent"];
            //                    xlsSheet[tmp, 12].Value = row["LastPriceVND"];

            //                    mCell = new XLCellRange(tmp, tmp, 12, 13);
            //                    xlsSheet.MergedCells.Add(mCell);

            //                    for (int col = 1; col <= 12; col++)
            //                    {
            //                        xlsSheet[tmp, col].Style = xlstStyle;
            //                    }
            //                    LastSumPriceVND[4] += Convert.ToDecimal(row["LastPriceVND"]);
            //                    LastSumPriceUSD[4] += Convert.ToDecimal(row["LastPriceUSD"]);
            //                }
            //                xlsSheet[rElec + 1 + j, 12].Value = LastSumPriceVND[4];
            //                mCell = new XLCellRange(rElec + 1 + j, rElec + 1 + j, 1, 11);
            //                xlsSheet.MergedCells.Add(mCell);

            //                mCell = new XLCellRange(rElec + 1 + j, rElec + 1 + j, 12, 13);
            //                xlsSheet.MergedCells.Add(mCell);

            //                for (int col = 1; col <= 13; col++)
            //                {
            //                    xlsSheet[rElec + 1 + j, col].Style = xlstStyleSum;
            //                }
            //                sumRow += dt.Rows.Count - 1;
            //            }
            //        }
            //    }

            //    ds = new DataSet();
            //    //Nuoc
            //    //Xuất ra toàn bộ nội dung theo Trang
            //    sql = " SELECT dbo.fnDateTime(A.DateFrom) DateFrom, dbo.fnDateTime(A.DateTo) DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVND, B.PriceUSD, B.SumVND, B.SumUSD, ";
            //    sql += "        B.VatVND, B.VatUSD, B.LastPriceVND, B.LastPriceUSD, B.Name, B.WaterPricePercent,B.ElecPricePercent  ";
            //    sql += " FROM   PaymentElecWater AS A INNER JOIN ";
            //    sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId";
            //    sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfElecId = 0 and A.YearMonth in (" + lsYearmonth + ")";
            //    sql += " Order by A.DateFrom, B.FromIndex";

            //    using (SqlCommand cm = db.CreateCommand(sql))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(cm);
            //        da.Fill(ds);
            //        line = rWater - 3 + j;
            //        //Phi dien
            //        XLCellRange mCell = new XLCellRange(line, line + 2, 1, 1);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line + 2, 2, 2);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 3, 3);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 4, 4);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 6, 6);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 7, 7);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 8, 8);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 9, 9);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 10, 10);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 11, 11);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        for (int col = 1; col < 13; col++)
            //        {
            //            xlsSheet[line, col].Style = xlstStyleH;
            //            xlsSheet[line + 1, col].Style = xlstStyleH;
            //            xlsSheet[line + 2, col].Style = xlstStyleH;
            //        }

            //        if (ds != null)
            //        {
            //            int count = 0;
            //            DataTable dt = ds.Tables[0];
            //            if (dt.Rows.Count > 0)
            //            {
            //                foreach (DataRow row in dt.Rows)
            //                {
            //                    if (count >= 1)
            //                    {
            //                        xlsSheet.Rows.Insert(rWater + 1 + j);
            //                        j++;
            //                    }
            //                    count++;
            //                    int tmp = rWater + j;

            //                    string DateFrom = Func.ParseString(row["DateFrom"]);
            //                    string DateTo = Func.ParseString(row["DateTo"]);

            //                    string FromIndex = Func.ParseString(row["FromIndex"]);
            //                    string ToIndex = Func.ParseString(row["ToIndex"]);
            //                    string OtherFee01 = Func.ParseString(row["OtherFee01"]);
            //                    string OtherFee02 = Func.ParseString(row["OtherFee02"]);
            //                    string Mount = Func.ParseString(row["Mount"]);

            //                    xlsSheet[tmp, 1].Value = DateFrom;
            //                    xlsSheet[tmp, 2].Value = DateTo;
            //                    xlsSheet[tmp, 3].Value = FromIndex;
            //                    xlsSheet[tmp, 4].Value = ToIndex;
            //                    xlsSheet[tmp, 5].Value = Mount;
            //                    xlsSheet[tmp, 6].Value = row["PriceVND"];
            //                    xlsSheet[tmp, 7].Value = row["OtherFee01"];
            //                    xlsSheet[tmp, 8].Value = row["VatVND"];

            //                    xlsSheet[tmp, 9].Value = row["SumVND"];
            //                    xlsSheet[tmp, 10].Value = row["OtherFee02"];
            //                    xlsSheet[tmp, 11].Value = row["WaterPricePercent"];
            //                    xlsSheet[tmp, 12].Value = row["LastPriceVND"];

            //                    for (int col = 1; col <= 12; col++)
            //                    {
            //                        xlsSheet[tmp, col].Style = xlstStyle;
            //                    }
            //                    LastSumPriceVND[5] += Convert.ToDecimal(row["LastPriceVND"]);
            //                    LastSumPriceUSD[5] += Convert.ToDecimal(row["LastPriceUSD"]);

            //                    mCell = new XLCellRange(tmp, tmp, 12, 13);
            //                    xlsSheet.MergedCells.Add(mCell);
            //                }
            //                xlsSheet[rWater + 1 + j, 12].Value = LastSumPriceVND[5];
            //                mCell = new XLCellRange(rWater + 1 + j, rWater + 1 + j, 1, 11);
            //                xlsSheet.MergedCells.Add(mCell);

            //                mCell = new XLCellRange(rWater + 1 + j, rWater + 1 + j, 12, 13);
            //                xlsSheet.MergedCells.Add(mCell);

            //                for (int col = 1; col <= 13; col++)
            //                {
            //                    xlsSheet[rWater + 1 + j, col].Style = xlstStyleSum;
            //                }
            //                sumRow += dt.Rows.Count - 1;
            //            }
            //        }
            //    }

            //    //Service
            //    ds = new DataSet();

            //    sql = string.Empty;
            //    sql = " SELECT Service,dbo.fnDateTime(ServiceDateFrom) ServiceDateFrom,dbo.fnDateTime(ServiceDateTo) ServiceDateTo,PriceVND,PriceUSD,VatUSD,VatVND,Mount,Unit,SumVND,SumUSD,LastPriceVND,LastPriceUSD ";
            //    sql += " FROM   PaymentService";
            //    sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth in (" + lsYearmonth + ")";
            //    sql += " Order By ServiceDate ";

            //    using (SqlCommand cm = db.CreateCommand(sql))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(cm);
            //        da.Fill(ds);
            //        line = rService - 3 + j;
            //        //Phi khác
            //        XLCellRange mCell = new XLCellRange(line, line + 2, 1, 1);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line + 2, 2, 2);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line + 2, 3, 3);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line + 2, 4, 4);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 2, 5, 5);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 6, 7);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 6, 7);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 8, 9);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 8, 9);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line, line, 10, 11);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 10, 11);
            //        xlsSheet.MergedCells.Add(mCell);

            //        for (int col = 1; col < 13; col++)
            //        {
            //            xlsSheet[line, col].Style = xlstStyleH;
            //            xlsSheet[line + 1, col].Style = xlstStyleH;
            //            xlsSheet[line + 2, col].Style = xlstStyleH;
            //        }
            //        mCell = new XLCellRange(line, line, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        mCell = new XLCellRange(line + 1, line + 1, 12, 13);
            //        xlsSheet.MergedCells.Add(mCell);

            //        if (ds != null)
            //        {
            //            int count = 0;
            //            DataTable dt = ds.Tables[0];

            //            if (dt.Rows.Count > 0)
            //            {

            //                foreach (DataRow row in dt.Rows)
            //                {
            //                    if (count >= 1)
            //                    {
            //                        xlsSheet.Rows.Insert(rService + 1 + j);
            //                        j++;
            //                    }
            //                    count++;
            //                    int tmp = rService + j;

            //                    string Service = Func.ParseString(row["Service"]);
            //                    string ServiceDateFrom = Func.ParseString(row["ServiceDateFrom"]);
            //                    string ServiceDateTo = Func.ParseString(row["ServiceDateTo"]);

            //                    string Mount = Func.ParseString(row["Mount"]);

            //                    xlsSheet[tmp, 1].Value = Service;
            //                    xlsSheet[tmp, 2].Value = Func.ParseString(row["Unit"]);
            //                    xlsSheet[tmp, 3].Value = ServiceDateFrom;
            //                    xlsSheet[tmp, 4].Value = ServiceDateTo;
            //                    xlsSheet[tmp, 5].Value = Mount;

            //                    xlsSheet[tmp, 6].Value = row["PriceUSD"];
            //                    xlsSheet[tmp, 7].Value = row["PriceVND"];

            //                    xlsSheet[tmp, 8].Value = row["SumUSD"];
            //                    xlsSheet[tmp, 9].Value = row["SumVND"];

            //                    xlsSheet[tmp, 10].Value = row["VatUSD"];
            //                    xlsSheet[tmp, 11].Value = row["VatVND"];

            //                    xlsSheet[tmp, 12].Value = row["LastPriceUSD"];
            //                    xlsSheet[tmp, 13].Value = row["LastPriceVND"];

            //                    for (int col = 1; col <= 13; col++)
            //                    {
            //                        xlsSheet[tmp, col].Style = xlstStyle;
            //                    }
            //                    LastSumPriceVND[6] += Convert.ToDecimal(row["LastPriceVND"]);
            //                    LastSumPriceUSD[6] += Convert.ToDecimal(row["LastPriceUSD"]);
            //                }
            //                xlsSheet[rService + 1 + j, 12].Value = LastSumPriceUSD[6];
            //                xlsSheet[rService + 1 + j, 13].Value = LastSumPriceVND[6];

            //                mCell = new XLCellRange(rService + 1 + j, rService + 1 + j, 1, 11);
            //                xlsSheet.MergedCells.Add(mCell);

            //                for (int col = 1; col <= 13; col++)
            //                {
            //                    xlsSheet[rService + 1 + j, col].Style = xlstStyleSum;
            //                }
            //                sumRow += dt.Rows.Count - 1;
            //            }
            //        }
            //    }

            //    //Paid
            //    sql = "Select  *";
            //    sql += " From    PaymentBillDetail";
            //    sql += " Where   BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth in (" + lsYearmonth + ")";
            //    string strYearMonth = "";
            //    int lineTmp = rPaid - 2 + j;

            //    //Paid
            //    XLCellRange mCellTmp = new XLCellRange(lineTmp, lineTmp + 1, 1, 1);
            //    xlsSheet.MergedCells.Add(mCellTmp);

            //    mCellTmp = new XLCellRange(lineTmp, lineTmp, 2, 3);
            //    xlsSheet.MergedCells.Add(mCellTmp);

            //    mCellTmp = new XLCellRange(lineTmp, lineTmp, 4, 5);
            //    xlsSheet.MergedCells.Add(mCellTmp);

            //    mCellTmp = new XLCellRange(lineTmp, lineTmp, 6, 7);
            //    xlsSheet.MergedCells.Add(mCellTmp);

            //    mCellTmp = new XLCellRange(lineTmp, lineTmp, 8, 9);
            //    xlsSheet.MergedCells.Add(mCellTmp);

            //    mCellTmp = new XLCellRange(lineTmp, lineTmp, 12, 13);
            //    xlsSheet.MergedCells.Add(mCellTmp);


            //    Hashtable rowNo = new Hashtable();
            //    decimal[] PaidSumVND = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };
            //    decimal[] PaidSumUSD = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };

            //    DataTable dtPaid = DbHelper.GetDataTable(sql);
            //    for (int i = 0; i < dtPaid.Rows.Count; i++)
            //    {
            //        string PaymentType = Func.ParseString(dtPaid.Rows[i]["PaymentType"]);
            //        string MoneyUSD = Func.ParseString(dtPaid.Rows[i]["MoneyUSD"]);
            //        string MoneyVND = Func.ParseString(dtPaid.Rows[i]["MoneyVND"]);
            //        string PaidUSD = Func.ParseString(dtPaid.Rows[i]["PaidUSD"]);
            //        string PaidVND = Func.ParseString(dtPaid.Rows[i]["PaidVND"]);
            //        string ExchangeType = Func.ParseString(dtPaid.Rows[i]["ExchangeType"]);
            //        string UsdExchange = Func.ParseString(dtPaid.Rows[i]["UsdExchange"]);
            //        string YearMonth = Func.ParseString(dtPaid.Rows[i]["YearMonth"]);

            //        if (!rowNo.Contains(YearMonth))
            //        {
            //            if (rowNo.Count != 0)
            //            {
            //                xlsSheet.Rows.Insert(rPaid + j + 1);
            //                j++;
            //            }
            //            rowNo.Add(YearMonth, j);
            //        }
            //        int m = Func.ParseInt(rowNo[YearMonth]);
            //        strYearMonth = YearMonth;
            //        decimal tmpUSD = Convert.ToDecimal(MoneyUSD) - Convert.ToDecimal(PaidUSD);
            //        decimal tmpVND = Convert.ToDecimal(MoneyVND) - Convert.ToDecimal(PaidVND);

            //        PaidPriceUSD += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
            //        PaidPriceVND += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);

            //        xlsSheet[rPaid + m, 1].Value = YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4);
            //        switch (PaymentType)
            //        {
            //            case "1":
            //                //Rent
            //                xlsSheet[rPaid + m, 2].Value = dtPaid.Rows[i]["PaidUSD"];
            //                xlsSheet[rPaid + m, 3].Value = dtPaid.Rows[i]["PaidVND"];

            //                PaidSumUSD[0] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
            //                PaidSumVND[0] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);

            //                break;
            //            case "2":
            //                //Manager
            //                xlsSheet[rPaid + m, 4].Value = dtPaid.Rows[i]["PaidUSD"];
            //                xlsSheet[rPaid + m, 5].Value = dtPaid.Rows[i]["PaidVND"];

            //                PaidSumUSD[1] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
            //                PaidSumVND[1] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);

            //                break;
            //            case "3":
            //                //Parking
            //                xlsSheet[rPaid + m, 6].Value = dtPaid.Rows[i]["PaidUSD"];
            //                xlsSheet[rPaid + m, 7].Value = dtPaid.Rows[i]["PaidVND"];

            //                PaidSumUSD[2] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
            //                PaidSumVND[2] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
            //                break;
            //            case "4":
            //                //Extra
            //                xlsSheet[rPaid + m, 8].Value = dtPaid.Rows[i]["PaidUSD"];
            //                xlsSheet[rPaid + m, 9].Value = dtPaid.Rows[i]["PaidVND"];

            //                PaidSumUSD[3] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
            //                PaidSumVND[3] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
            //                break;
            //            case "5":
            //                xlsSheet[rPaid + m, 10].Value = dtPaid.Rows[i]["PaidVND"];

            //                PaidSumUSD[4] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
            //                PaidSumVND[4] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
            //                break;
            //            case "6":
            //                xlsSheet[rPaid + m, 11].Value = dtPaid.Rows[i]["PaidVND"];

            //                PaidSumUSD[5] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
            //                PaidSumVND[5] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
            //                break;
            //            case "7":
            //                xlsSheet[rPaid + m, 12].Value = dtPaid.Rows[i]["PaidUSD"];
            //                xlsSheet[rPaid + m, 13].Value = dtPaid.Rows[i]["PaidVND"];
            //                break;
            //            default:
            //                break;
            //        }
            //        for (int row = rPaid + m; row <= rPaid + 1 + j; row++)
            //        {
            //            for (int col = 1; col <= 13; col++)
            //            {
            //                xlsSheet[row, col].Style = xlstStyle;
            //            }
            //        }
            //    }
            //    lineTmp = rPaid - 2 + j;

            //    xlsSheet[lineTmp + 3, 2].Value = PaidSumUSD[0];
            //    xlsSheet[lineTmp + 3, 3].Value = PaidSumVND[0];
            //    xlsSheet[lineTmp + 3, 4].Value = PaidSumUSD[1];
            //    xlsSheet[lineTmp + 3, 5].Value = PaidSumVND[1];
            //    xlsSheet[lineTmp + 3, 6].Value = PaidSumUSD[2];
            //    xlsSheet[lineTmp + 3, 7].Value = PaidSumVND[2];
            //    xlsSheet[lineTmp + 3, 8].Value = PaidSumUSD[3];
            //    xlsSheet[lineTmp + 3, 9].Value = PaidSumVND[3];
            //    xlsSheet[lineTmp + 3, 10].Value = PaidSumVND[4];
            //    xlsSheet[lineTmp + 3, 11].Value = PaidSumVND[5];
            //    xlsSheet[lineTmp + 3, 12].Value = PaidSumUSD[6];
            //    xlsSheet[lineTmp + 3, 13].Value = PaidSumVND[6];

            //    for (int col = 1; col <= 13; col++)
            //    {
            //        xlsSheet[lineTmp + 3, col].Style = xlstStyleSum;
            //    }

            //    ///////////////DEPT
            //    sql = "  Select *";
            //    sql += " From   v_DeptBill";
            //    sql += " Where  BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth not in (" + lsYearmonth + ")";
            //    sql += " And    (DeptUsd <> 0 or DeptVnd <> 0)";
            //    strYearMonth = "";
            //    lineTmp = rDept - 2 + j;

            //    //Paid
            //    mCellTmp = new XLCellRange(lineTmp, lineTmp + 1, 1, 1);
            //    xlsSheet.MergedCells.Add(mCellTmp);

            //    mCellTmp = new XLCellRange(lineTmp, lineTmp, 2, 3);
            //    xlsSheet.MergedCells.Add(mCellTmp);

            //    mCellTmp = new XLCellRange(lineTmp, lineTmp, 4, 5);
            //    xlsSheet.MergedCells.Add(mCellTmp);

            //    mCellTmp = new XLCellRange(lineTmp, lineTmp, 6, 7);
            //    xlsSheet.MergedCells.Add(mCellTmp);

            //    mCellTmp = new XLCellRange(lineTmp, lineTmp, 8, 9);
            //    xlsSheet.MergedCells.Add(mCellTmp);

            //    mCellTmp = new XLCellRange(lineTmp, lineTmp, 12, 13);
            //    xlsSheet.MergedCells.Add(mCellTmp);


            //    rowNo = new Hashtable();
            //    decimal DeptPriceVND = 0;
            //    decimal DeptPriceUSD = 0;

            //    decimal[] DeptSumVND = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };
            //    decimal[] DeptSumUSD = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };


            //    DataTable dtDept = DbHelper.GetDataTable(sql);
            //    for (int i = 0; i < dtDept.Rows.Count; i++)
            //    {
            //        string PaymentType = Func.ParseString(dtDept.Rows[i]["PaymentType"]);
            //        string DeptUSD = Func.ParseString(dtDept.Rows[i]["DeptUSD"]);
            //        string DeptVND = Func.ParseString(dtDept.Rows[i]["DeptVND"]);
            //        string YearMonth = Func.ParseString(dtDept.Rows[i]["YearMonth"]);

            //        if (!rowNo.Contains(YearMonth))
            //        {
            //            if (rowNo.Count != 0)
            //            {
            //                xlsSheet.Rows.Insert(rDept + j + 1);
            //                j++;
            //            }
            //            rowNo.Add(YearMonth, j);
            //        }
            //        int m = Func.ParseInt(rowNo[YearMonth]);
            //        strYearMonth = YearMonth;

            //        DeptPriceUSD += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
            //        DeptPriceVND += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);

            //        xlsSheet[rDept + m, 1].Value = YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4);
            //        switch (PaymentType)
            //        {
            //            case "1":
            //                //Rent
            //                xlsSheet[rDept + m, 2].Value = dtDept.Rows[i]["DeptUSD"];
            //                xlsSheet[rDept + m, 3].Value = dtDept.Rows[i]["DeptVND"];

            //                DeptSumUSD[0] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
            //                DeptSumVND[0] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);

            //                break;
            //            case "2":
            //                //Manager
            //                xlsSheet[rDept + m, 4].Value = dtDept.Rows[i]["DeptUSD"];
            //                xlsSheet[rDept + m, 5].Value = dtDept.Rows[i]["DeptVND"];

            //                DeptSumUSD[1] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
            //                DeptSumVND[1] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);

            //                break;
            //            case "3":
            //                //Parking
            //                xlsSheet[rDept + m, 6].Value = dtDept.Rows[i]["DeptUSD"];
            //                xlsSheet[rDept + m, 7].Value = dtDept.Rows[i]["DeptVND"];

            //                DeptSumUSD[2] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
            //                DeptSumVND[2] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
            //                break;
            //            case "4":
            //                //Extra
            //                xlsSheet[rDept + m, 8].Value = dtDept.Rows[i]["DeptUSD"];
            //                xlsSheet[rDept + m, 9].Value = dtDept.Rows[i]["DeptVND"];

            //                DeptSumUSD[3] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
            //                DeptSumVND[3] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
            //                break;
            //            case "5":
            //                xlsSheet[rDept + m, 10].Value = dtDept.Rows[i]["DeptVND"];

            //                DeptSumUSD[4] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
            //                DeptSumVND[4] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
            //                break;
            //            case "6":
            //                xlsSheet[rDept + m, 11].Value = dtDept.Rows[i]["DeptVND"];

            //                DeptSumUSD[5] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
            //                DeptSumVND[5] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
            //                break;
            //            case "7":
            //                xlsSheet[rDept + m, 12].Value = dtDept.Rows[i]["DeptUSD"];
            //                xlsSheet[rDept + m, 13].Value = dtDept.Rows[i]["DeptVND"];

            //                DeptSumUSD[6] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
            //                DeptSumVND[6] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
            //                break;
            //            default:
            //                break;
            //        }
            //        for (int row = rDept + m; row <= rDept + 1 + j; row++)
            //        {
            //            for (int col = 1; col <= 13; col++)
            //            {
            //                xlsSheet[row, col].Style = xlstStyle;
            //            }
            //        }
            //    }
            //    lineTmp = rDept - 2 + j;

            //    xlsSheet[lineTmp + 3, 2].Value = DeptSumUSD[0];
            //    xlsSheet[lineTmp + 3, 3].Value = DeptSumVND[0];
            //    xlsSheet[lineTmp + 3, 4].Value = DeptSumUSD[1];
            //    xlsSheet[lineTmp + 3, 5].Value = DeptSumVND[1];
            //    xlsSheet[lineTmp + 3, 6].Value = DeptSumUSD[2];
            //    xlsSheet[lineTmp + 3, 7].Value = DeptSumVND[2];
            //    xlsSheet[lineTmp + 3, 8].Value = DeptSumUSD[3];
            //    xlsSheet[lineTmp + 3, 9].Value = DeptSumVND[3];
            //    xlsSheet[lineTmp + 3, 10].Value = DeptSumVND[4];
            //    xlsSheet[lineTmp + 3, 11].Value = DeptSumVND[5];
            //    xlsSheet[lineTmp + 3, 12].Value = DeptSumUSD[6];
            //    xlsSheet[lineTmp + 3, 13].Value = DeptSumVND[6];

            //    for (int col = 1; col <= 13; col++)
            //    {
            //        xlsSheet[lineTmp + 3, col].Style = xlstStyleSum;
            //    }

            //    xlsSheet[lineTmp + 3, 1].Style = xlstStyleSum;

            //    decimal AllSumVND = 0;
            //    decimal AllSumUSD = 0;
            //    for (int i = 0; i < 7; i++)
            //    {
            //        AllSumVND += LastSumPriceVND[i];
            //        AllSumUSD += LastSumPriceUSD[i];
            //    }

            //    AllSumVND -= PaidPriceVND;
            //    AllSumUSD -= PaidPriceUSD;

            //    AllSumVND += DeptPriceVND;
            //    AllSumUSD += DeptPriceUSD;

            //    xlsSheet[rSumVND + j, cSumVND].Value = Func.FormatNumber_New(AllSumUSD);
            //    xlsSheet[rSumVND + j, cSumVND].Value += "(USD)";
            //    xlsSheet[rSumVND + j, cSumVND + 1].Value = Func.FormatNumber_New(AllSumVND);
            //    xlsSheet[rSumVND + j, cSumVND + 1].Value += "(VND)";

            //    AllSumVND += Convert.ToDecimal(AllSumUSD * Convert.ToDecimal(txtUsdExchange.Text));

            //    string strMoney = Func.docso(Convert.ToInt32(AllSumVND));

            //    xlsSheet[rContract, cContract].Value = xlsSheet[rContract, cContract].Value.ToString().Replace("{%HOP_DONG%}", contract.Substring(1));
            //    xlsSheet[rSum + j, cSum].Value = Convert.ToInt32(AllSumVND);

            //    mCellTmp = new XLCellRange(rSum + j, rSum + j, cSum, cSum + 1);
            //    xlsSheet.MergedCells.Add(mCellTmp);
            //    xlsSheet[rSum + j, cSum].Style = xlstStyleSum;
            //    xlsSheet[rSum + j, cSum + 1].Style = xlstStyleSum;
            //    xlsSheet[rSumRead + j, cSumRead].Value = xlsSheet[rSumRead + j, cSumRead].Value.ToString().Replace("{%TONG_CHU%}", strMoney.ToUpper());

            //    xlbBook.Save(fileNameDes);
            //    ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);
            //}
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            ShowData(drpYear.SelectedValue + drpMonth.SelectedValue);
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
        public void ViewMultiBoth(string lsYearmonth)
        {
            //string lsYearmonth = "";
            //foreach (ListItem lstItem in lstSelectedYearMonth.Items)
            //{
            //    lsYearmonth += ",'" + lstItem.Value + "'";

            //    if (String.Compare(DateTime.Now.ToString("yyyyMMdd"), lstItem.Value) < 0)
            //    {
            //        using (SqlConnection con = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
            //        {
            //            con.Open();
            //            using (SqlCommand cm = new SqlCommand("sp_PaymentDetailOneCustomerRentManager", con))
            //            {
            //                try
            //                {
            //                    cm.CommandType = CommandType.StoredProcedure;
            //                    cm.Parameters.AddWithValue("@BuildingId", Func.ParseString(Session["__BUILDINGID__"]));
            //                    cm.Parameters.AddWithValue("@CustomerId", lblCustomerId.Text);
            //                    cm.Parameters.AddWithValue("@YearMonth", lstItem.Value);
            //                    cm.Parameters.AddWithValue("@Created", DateTime.Now.ToString("yyyyMMddHHmmss"));
            //                    cm.Parameters.AddWithValue("@CreatedBy", Page.User.Identity.Name);
            //                    cm.Parameters.AddWithValue("@Modified", DateTime.Now.ToString("yyyyMMddHHmmss"));
            //                    cm.Parameters.AddWithValue("@ModifiedBy", Page.User.Identity.Name);

            //                    cm.CommandTimeout = 9999;

            //                    int ret = cm.ExecuteNonQuery();
            //                }
            //                catch (Exception ex)
            //                {
            //                    ApplicationLog.WriteError(ex);
            //                }
            //                finally
            //                {
            //                    con.Close();
            //                }
            //            }
            //        }
            //    }
            //}
            if (String.IsNullOrEmpty(lsYearmonth))
            {
                mvMessage.AddError("Phải chọn ít nhất 1 tháng");
                return;
            }
            //lsYearmonth = lsYearmonth.Substring(1);

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

            int rRate = 11;
            int cRate = 9;

            int rRateDate = 11;
            int cRateDate = 12;

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
            int cOffice = 3;

            int rPhone = 89;
            int cPhone = 3;

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
            int cSumRead = 13;

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
            //ShowData(drpYear.SelectedValue + drpMonth.SelectedValue);
            C1XLBook xlbBook = new C1XLBook();
            string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\BillTongQuat.xlsx");
            if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])));
            }

            XLStyle xlstStyle = new XLStyle(xlbBook);
            xlstStyle.AlignHorz = XLAlignHorzEnum.Center;
            xlstStyle.AlignVert = XLAlignVertEnum.Center;
            xlstStyle.WordWrap = true;
            xlstStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            xlstStyle.SetBorderColor(Color.Black);
            xlstStyle.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyle.BorderTop = XLLineStyleEnum.Thin;
            xlstStyle.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyle.BorderRight = XLLineStyleEnum.Thin;
            xlstStyle.Format = "#,##0.00_);(#,##0.00)";

            XLStyle xlstStyleH = new XLStyle(xlbBook);
            xlstStyleH.AlignHorz = XLAlignHorzEnum.Center;
            xlstStyleH.AlignVert = XLAlignVertEnum.Center;
            xlstStyleH.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            xlstStyleH.SetBorderColor(Color.Black);
            xlstStyleH.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleH.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleH.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleH.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleH.WordWrap = true;

            XLStyle xlstStyleSum = new XLStyle(xlbBook);
            xlstStyleSum.AlignHorz = XLAlignHorzEnum.Right;
            xlstStyleSum.AlignVert = XLAlignVertEnum.Center;
            xlstStyleSum.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            xlstStyleSum.SetBorderColor(Color.Black);
            xlstStyleSum.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleSum.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleSum.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleSum.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleSum.WordWrap = true;
            xlstStyleSum.Format = "#,##0.00_);(#,##0.00)";

            string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\Bill_" + lblCustomerId.Text + "_" + strDT + ".xlsx";
            string strFilePathExport = @"../../Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + @"/Bill_" + lblCustomerId.Text + "_" + strDT + ".xlsx";

            string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

            //string fileNameDes = HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\TongHopDienTich" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
            File.Copy(fileName, fileNameDes);

            xlbBook.Load(fileNameDes);
            XLSheet xlsSheet = xlbBook.Sheets["TongHop"];
            XLSheet xlsSheetEn = xlbBook.Sheets["TongHop_En"];

            //Bill No
            xlsSheet[rBillNo, cBillNo].Value = xlsSheet[rBillNo, cBillNo].Value.ToString().Replace("{%BILL_NO%}", txtBillNo.Text);
            xlsSheetEn[rBillNo, cBillNo].Value = xlsSheetEn[rBillNo, cBillNo].Value.ToString().Replace("{%BILL_NO%}", txtBillNo.Text);

            //Ngay Thang Nam
            DateTime dtime = DateTime.Today;

            string strTmp = xlsSheet[rBillDate, cBillDate].Value.ToString().Replace("{%NGAY%}", dtime.ToString("dd"));
            strTmp = strTmp.Replace("{%THANG%}", dtime.ToString("MM"));
            xlsSheet[rBillDate, cBillDate].Value = strTmp.Replace("{%NAM%}", dtime.ToString("yyyy"));

            strTmp = xlsSheetEn[rBillDate, cBillDate].Value.ToString().Replace("{%NGAY%}", dtime.ToString("dd"));
            strTmp = strTmp.Replace("{%THANG%}", dtime.ToString("MM"));
            xlsSheetEn[rBillDate, cBillDate].Value = strTmp.Replace("{%NAM%}", dtime.ToString("yyyy"));


            //Nam
            xlsSheet[rBillMonth, cBillMonth].Value = xlsSheet[rBillMonth, cBillMonth].Value.ToString().Replace("{%NAM_THANG%}", drpMonth.SelectedValue + "/" + drpYear.SelectedValue);
            xlsSheetEn[rBillMonth, cBillMonth].Value = xlsSheetEn[rBillMonth, cBillMonth].Value.ToString().Replace("{%NAM_THANG%}", drpMonth.SelectedValue + "/" + drpYear.SelectedValue);

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
                            xlsSheet[rCustomer, cCustomer].Value = xlsSheet[rCustomer, cCustomer].Value.ToString().Replace("{%TEN_CONG_TY%}", Name);
                            xlsSheetEn[rCustomer, cCustomer].Value = xlsSheetEn[rCustomer, cCustomer].Value.ToString().Replace("{%TEN_CONG_TY%}", Name);
                            //Contact
                            xlsSheet[rContact, cContact].Value = xlsSheet[rContact, cContact].Value.ToString().Replace("{%NGUOI_DAI_DIEN%}", ContactName);
                            xlsSheetEn[rContact, cContact].Value = xlsSheetEn[rContact, cContact].Value.ToString().Replace("{%NGUOI_DAI_DIEN%}", ContactName);
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

                            xlsSheet[rOffice, cOffice].Value = xlsSheet[rOffice, cOffice].Value.ToString().Replace("{%VAN_PHONG%}", Office);
                            xlsSheet[rPhone, cPhone].Value = xlsSheet[rPhone, cPhone].Value.ToString().Replace("{%DIEN_THOAI%}", OfficePhone);

                            xlsSheet[rBank, cBank].Value = xlsSheet[rBank, cBank].Value.ToString().Replace("{%NGAN_HANG%}", Bank);
                            xlsSheet[rAccountName, cAccountName].Value = xlsSheet[rAccountName, cAccountName].Value.ToString().Replace("{%TEN_TAI_KHOAN%}", AccountName);
                            xlsSheet[rAccount, cAccount].Value = xlsSheet[rAccount, cAccount].Value.ToString().Replace("{%SO_TAI_KHOAN%}", Account);

                            xlsSheetEn[rOffice, cOffice].Value = xlsSheetEn[rOffice, cOffice].Value.ToString().Replace("{%VAN_PHONG%}", Office);
                            xlsSheetEn[rPhone, cPhone].Value = xlsSheetEn[rPhone, cPhone].Value.ToString().Replace("{%DIEN_THOAI%}", OfficePhone);

                            xlsSheetEn[rBank, cBank].Value = xlsSheetEn[rBank, cBank].Value.ToString().Replace("{%NGAN_HANG%}", Bank);
                            xlsSheetEn[rAccountName, cAccountName].Value = xlsSheetEn[rAccountName, cAccountName].Value.ToString().Replace("{%TEN_TAI_KHOAN%}", AccountName);
                            xlsSheetEn[rAccount, cAccount].Value = xlsSheetEn[rAccount, cAccount].Value.ToString().Replace("{%SO_TAI_KHOAN%}", Account);
                        }
                    }
                }

                xlsSheet[rRate, cRate].Value = xlsSheet[rRate, cRate].Value.ToString().Replace("{%TI_GIA%}", txtUsdExchange.Text);
                xlsSheet[rRateDate, cRateDate].Value = xlsSheet[rRateDate, cRateDate].Value.ToString().Replace("{%NGAY_AP_DUNG%}", txtUsdExchangeDate.Text);

                xlsSheetEn[rRate, cRate].Value = xlsSheetEn[rRate, cRate].Value.ToString().Replace("{%TI_GIA%}", txtUsdExchange.Text);
                xlsSheetEn[rRateDate, cRateDate].Value = xlsSheetEn[rRateDate, cRateDate].Value.ToString().Replace("{%NGAY_AP_DUNG%}", txtUsdExchangeDate.Text);

                //Thue phong
                ds = new DataSet();
                sql = " Select *";
                sql += " FROM PaymentRoom";
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth in (" + lsYearmonth + ")";

                int sumRow = 0;
                int j = 0;
                decimal[] LastSumPriceVND = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };
                decimal[] LastSumPriceUSD = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };

                decimal PaidPriceVND = 0;
                decimal PaidPriceUSD = 0;

                int line = 0;
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);

                    line = rRent - 3 + j;

                    XLCellRange mCell = new XLCellRange(line, line + 2, 1, 3);
                    xlsSheet.MergedCells.Add(mCell);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 4, 5);
                    xlsSheet.MergedCells.Add(mCell);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 4, 5);
                    xlsSheet.MergedCells.Add(mCell);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 2, line + 2, 4, 5);
                    xlsSheet.MergedCells.Add(mCell);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 6, 7);
                    xlsSheet.MergedCells.Add(mCell);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                    xlsSheet.MergedCells.Add(mCell);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 8, 9);
                    xlsSheet.MergedCells.Add(mCell);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                    xlsSheet.MergedCells.Add(mCell);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 10, 11);
                    xlsSheet.MergedCells.Add(mCell);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                    xlsSheet.MergedCells.Add(mCell);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 12, 13);
                    xlsSheet.MergedCells.Add(mCell);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                    xlsSheet.MergedCells.Add(mCell);
                    xlsSheetEn.MergedCells.Add(mCell);

                    if (ds != null)
                    {
                        int count = 0;
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            if (count >= 1)
                            {
                                xlsSheet.Rows.Insert(rRent + 1 + j);
                                xlsSheetEn.Rows.Insert(rRent + 1 + j);
                                j++;
                            }
                            count++;
                            int tmp = rRent + j;

                            string ContractId = Func.ParseString(rowType["ContractId"]);
                            string ContractNo = Func.ParseString(rowType["ContractNo"]);
                            string YearMonth = Func.ParseString(rowType["YearMonth"]);
                            string Area = Func.ParseString(rowType["Area"]);
                            string Name = Func.ParseString(rowType["Name"]);
                            string Regional = Func.ParseString(rowType["Regional"]);
                            string Floor = Func.ParseString(rowType["Floor"]);

                            string BeginContract = Func.ParseString(rowType["BeginContract"]);


                            if (!contractIdLst.ContainsKey(ContractId + "(" + BeginContract.Substring(0, 10) + ")"))
                            {
                                contractIdLst.Add(ContractId + "(" + BeginContract.Substring(0, 10) + ")", ContractNo + "(" + BeginContract.Substring(0, 10) + ")");
                                contract += ";" + ContractNo + "(" + BeginContract.Substring(0, 10) + ")";
                            }

                            xlsSheet[tmp, 1].Value = Name;
                            xlsSheet[tmp, 4].Value = rowType["Area"];
                            xlsSheet[tmp, 6].Value = rowType["MonthRentPriceUSD"];
                            xlsSheet[tmp, 7].Value = rowType["MonthRentPriceVND"];

                            xlsSheet[tmp, 8].Value = rowType["MonthRentSumUSD"];
                            xlsSheet[tmp, 9].Value = rowType["MonthRentSumVND"];

                            xlsSheet[tmp, 10].Value = rowType["VatRentPriceUSD"];
                            xlsSheet[tmp, 11].Value = rowType["VatRentPriceVND"];

                            xlsSheet[tmp, 12].Value = rowType["LastRentSumUSD"];
                            xlsSheet[tmp, 13].Value = rowType["LastRentSumVND"];

                            XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
                            xlsSheet.MergedCells.Add(mrCell);

                            mrCell = new XLCellRange(tmp, tmp, 4, 5);
                            xlsSheet.MergedCells.Add(mrCell);


                            ////EN
                            xlsSheetEn[tmp, 1].Value = Name;
                            xlsSheetEn[tmp, 4].Value = rowType["Area"];
                            xlsSheetEn[tmp, 6].Value = rowType["MonthRentPriceUSD"];
                            xlsSheetEn[tmp, 7].Value = rowType["MonthRentPriceVND"];

                            xlsSheetEn[tmp, 8].Value = rowType["MonthRentSumUSD"];
                            xlsSheetEn[tmp, 9].Value = rowType["MonthRentSumVND"];

                            xlsSheetEn[tmp, 10].Value = rowType["VatRentPriceUSD"];
                            xlsSheetEn[tmp, 11].Value = rowType["VatRentPriceVND"];

                            xlsSheetEn[tmp, 12].Value = rowType["LastRentSumUSD"];
                            xlsSheetEn[tmp, 13].Value = rowType["LastRentSumVND"];

                            mrCell = new XLCellRange(tmp, tmp, 1, 3);
                            xlsSheetEn.MergedCells.Add(mrCell);

                            mrCell = new XLCellRange(tmp, tmp, 4, 5);
                            xlsSheetEn.MergedCells.Add(mrCell);
                            ////EN


                            LastSumPriceVND[0] += Convert.ToDecimal(rowType["LastRentSumVND"]);
                            LastSumPriceUSD[0] += Convert.ToDecimal(rowType["LastRentSumUSD"]);

                        }
                        mCell = new XLCellRange(rRent + 1 + j, rRent + 1 + j, 1, 11);
                        xlsSheet.MergedCells.Add(mCell);
                        xlsSheetEn.MergedCells.Add(mCell);

                        xlsSheet[rRent + 1 + j, 12].Value = LastSumPriceUSD[0];
                        xlsSheet[rRent + 1 + j, 13].Value = LastSumPriceVND[0];

                        xlsSheetEn[rRent + 1 + j, 12].Value = LastSumPriceUSD[0];
                        xlsSheetEn[rRent + 1 + j, 13].Value = LastSumPriceVND[0];

                        for (int row = rRent + sumRow; row <= rRent + dt.Rows.Count; row++)
                        {
                            for (int col = 1; col <= 13; col++)
                            {
                                xlsSheet[row, col].Style = xlstStyle;
                                xlsSheetEn[row, col].Style = xlstStyle;
                            }
                        }
                        sumRow += dt.Rows.Count - 1;

                        ////////////////////////
                        for (int col = 1; col <= 13; col++)
                        {
                            xlsSheet[rRent + 1 + j, col].Style = xlstStyleSum;
                            xlsSheetEn[rRent + 1 + j, col].Style = xlstStyleSum;
                        }
                        line = rManager - 3 + j;
                        mCell = new XLCellRange(line, line + 2, 1, 3);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 4, 5);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line + 1, line + 1, 4, 5);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line + 2, line + 2, 4, 5);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 6, 7);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 8, 9);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 10, 11);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 12, 13);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                        xlsSheet.MergedCells.Add(mCell);

                        ////En
                        mCell = new XLCellRange(line, line + 2, 1, 3);
                        xlsSheetEn.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 4, 5);
                        xlsSheetEn.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line + 1, line + 1, 4, 5);
                        xlsSheetEn.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line + 2, line + 2, 4, 5);
                        xlsSheetEn.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 6, 7);
                        xlsSheetEn.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                        xlsSheetEn.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 8, 9);
                        xlsSheetEn.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                        xlsSheetEn.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 10, 11);
                        xlsSheetEn.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                        xlsSheetEn.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 12, 13);
                        xlsSheetEn.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                        xlsSheetEn.MergedCells.Add(mCell);
                        ////En
                        count = 0;
                        foreach (DataRow row in dt.Rows)
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

                            xlsSheet[tmp, 1].Value = Name;
                            xlsSheet[tmp, 4].Value = row["Area"];
                            xlsSheet[tmp, 6].Value = row["MonthManagerPriceUSD"];
                            xlsSheet[tmp, 7].Value = row["MonthManagerPriceVND"];

                            xlsSheet[tmp, 8].Value = row["MonthManagerSumUSD"];
                            xlsSheet[tmp, 9].Value = row["MonthManagerSumVND"];

                            xlsSheet[tmp, 19].Value = row["VatManagerPriceUSD"];
                            xlsSheet[tmp, 11].Value = row["VatManagerPriceVND"];

                            xlsSheet[tmp, 12].Value = row["LastManagerSumUSD"];
                            xlsSheet[tmp, 13].Value = row["LastManagerSumVND"];

                            XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
                            xlsSheet.MergedCells.Add(mrCell);

                            mrCell = new XLCellRange(tmp, tmp, 4, 5);
                            xlsSheet.MergedCells.Add(mrCell);

                            ////En
                            xlsSheetEn[tmp, 1].Value = Name;
                            xlsSheetEn[tmp, 4].Value = row["Area"];
                            xlsSheetEn[tmp, 6].Value = row["MonthManagerPriceUSD"];
                            xlsSheetEn[tmp, 7].Value = row["MonthManagerPriceVND"];

                            xlsSheetEn[tmp, 8].Value = row["MonthManagerSumUSD"];
                            xlsSheetEn[tmp, 9].Value = row["MonthManagerSumVND"];

                            xlsSheetEn[tmp, 19].Value = row["VatManagerPriceUSD"];
                            xlsSheetEn[tmp, 11].Value = row["VatManagerPriceVND"];

                            xlsSheetEn[tmp, 12].Value = row["LastManagerSumUSD"];
                            xlsSheetEn[tmp, 13].Value = row["LastManagerSumVND"];

                            mrCell = new XLCellRange(tmp, tmp, 1, 3);
                            xlsSheetEn.MergedCells.Add(mrCell);

                            mrCell = new XLCellRange(tmp, tmp, 4, 5);
                            xlsSheetEn.MergedCells.Add(mrCell);
                            ////En
                            LastSumPriceVND[1] += Convert.ToDecimal(row["LastManagerSumVND"]);
                            LastSumPriceUSD[1] += Convert.ToDecimal(row["LastManagerSumUSD"]);
                        }
                        mCell = new XLCellRange(rManager + 1 + j, rManager + 1 + j, 1, 11);
                        xlsSheet.MergedCells.Add(mCell);
                        xlsSheetEn.MergedCells.Add(mCell);

                        xlsSheet[rManager + 1 + j, 12].Value = LastSumPriceUSD[1];
                        xlsSheet[rManager + 1 + j, 13].Value = LastSumPriceVND[1];

                        xlsSheetEn[rManager + 1 + j, 12].Value = LastSumPriceUSD[1];
                        xlsSheetEn[rManager + 1 + j, 13].Value = LastSumPriceVND[1];

                        for (int row = rManager + sumRow; row <= rManager + sumRow + dt.Rows.Count; row++)
                        {
                            for (int col = 1; col <= 13; col++)
                            {
                                xlsSheet[row, col].Style = xlstStyle;
                                xlsSheetEn[row, col].Style = xlstStyle;
                            }
                        }

                        for (int col = 1; col <= 13; col++)
                        {
                            xlsSheet[rManager + 1 + j, col].Style = xlstStyleSum;
                            xlsSheetEn[rManager + 1 + j, col].Style = xlstStyleSum;
                        }
                        sumRow += dt.Rows.Count - 1;
                    }
                }

                ds = new DataSet();
                //Xuất ra toàn bộ nội dung theo Trang
                sql = " SELECT COUNT(*) AS Num, YearMonth, TariffsParkingName, PriceVND, PriceUSD, SUM(VatVND) AS VatVND,SUM(VatUSD) AS VatUSD, SUM(SumVND) AS SumVND, SUM(SumUSD) AS SumUSD, SUM(LastPriceVND) AS LastPriceVND";
                sql += "        , SUM(LastPriceUSD) AS LastPriceUSD";
                sql += " FROM         dbo.PaymentParking";
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth in (" + lsYearmonth + ")";
                sql += " GROUP BY YearMonth, TariffsParkingName, PriceVND, PriceUSD, Vat, daysParking";

                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);

                    line = rParking - 3 + j;
                    XLCellRange mCell = new XLCellRange(line, line + 2, 1, 3);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 4, 5);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 4, 5);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 2, line + 2, 4, 5);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 6, 7);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 8, 9);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 10, 11);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 12, 13);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                    xlsSheet.MergedCells.Add(mCell);

                    ////En
                    mCell = new XLCellRange(line, line + 2, 1, 3);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 4, 5);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 4, 5);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 2, line + 2, 4, 5);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 6, 7);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 8, 9);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 10, 11);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 12, 13);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                    xlsSheetEn.MergedCells.Add(mCell);
                    ////En
                    if (ds != null)
                    {
                        int count = 0;
                        DataTable dt = ds.Tables[0];

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

                            xlsSheet[tmp, 1].Value = TariffsParkingName;
                            xlsSheet[tmp, 4].Value = Num;
                            xlsSheet[tmp, 6].Value = row["PriceUSD"];
                            xlsSheet[tmp, 7].Value = row["PriceVND"];

                            xlsSheet[tmp, 8].Value = row["SumUSD"];
                            xlsSheet[tmp, 9].Value = row["SumVND"];

                            xlsSheet[tmp, 10].Value = row["VatUSD"];
                            xlsSheet[tmp, 11].Value = row["VatVND"];

                            xlsSheet[tmp, 12].Value = row["LastPriceUSD"];
                            xlsSheet[tmp, 13].Value = row["LastPriceVND"];

                            XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
                            xlsSheet.MergedCells.Add(mrCell);

                            mrCell = new XLCellRange(tmp, tmp, 4, 5);
                            xlsSheet.MergedCells.Add(mrCell);

                            /////En
                            xlsSheetEn[tmp, 1].Value = TariffsParkingName;
                            xlsSheetEn[tmp, 4].Value = Num;
                            xlsSheetEn[tmp, 6].Value = row["PriceUSD"];
                            xlsSheetEn[tmp, 7].Value = row["PriceVND"];

                            xlsSheetEn[tmp, 8].Value = row["SumUSD"];
                            xlsSheetEn[tmp, 9].Value = row["SumVND"];

                            xlsSheetEn[tmp, 10].Value = row["VatUSD"];
                            xlsSheetEn[tmp, 11].Value = row["VatVND"];

                            xlsSheetEn[tmp, 12].Value = row["LastPriceUSD"];
                            xlsSheetEn[tmp, 13].Value = row["LastPriceVND"];

                            mrCell = new XLCellRange(tmp, tmp, 1, 3);
                            xlsSheetEn.MergedCells.Add(mrCell);

                            mrCell = new XLCellRange(tmp, tmp, 4, 5);
                            xlsSheetEn.MergedCells.Add(mrCell);
                            /////En
                            LastSumPriceVND[2] += Convert.ToDecimal(row["LastPriceVND"]);
                            LastSumPriceUSD[2] += Convert.ToDecimal(row["LastPriceUSD"]);
                        }
                        xlsSheet[rParking + 1 + j, 12].Value = LastSumPriceUSD[2];
                        xlsSheet[rParking + 1 + j, 13].Value = LastSumPriceVND[2];

                        mCell = new XLCellRange(rParking + 1 + j, rParking + 1 + j, 1, 11);
                        xlsSheet.MergedCells.Add(mCell);


                        /////En
                        xlsSheetEn[rParking + 1 + j, 12].Value = LastSumPriceUSD[2];
                        xlsSheetEn[rParking + 1 + j, 13].Value = LastSumPriceVND[2];

                        mCell = new XLCellRange(rParking + 1 + j, rParking + 1 + j, 1, 11);
                        xlsSheetEn.MergedCells.Add(mCell);
                        /////En

                        for (int row = rParking + sumRow; row <= rParking + sumRow + dt.Rows.Count; row++)
                        {
                            for (int col = 1; col <= 13; col++)
                            {
                                xlsSheet[row, col].Style = xlstStyle;
                                xlsSheetEn[row, col].Style = xlstStyle;
                            }
                        }

                        for (int col = 1; col <= 13; col++)
                        {
                            xlsSheet[rParking + 1 + j, col].Style = xlstStyleSum;
                            xlsSheetEn[rParking + 1 + j, col].Style = xlstStyleSum;
                        }
                        sumRow += dt.Rows.Count - 1;
                    }
                }

                ds = new DataSet();
                sql = "SELECT id";
                sql += " ,YearMonth,BuildingId,CustomerId,RoomId,ExtraHour,VAT,OtherFee01,OtherFee02";
                sql += " ,PriceUSD,PriceVND,VatUSD,VatVND,SumUSD,SumVND,LastPriceUSD,LastPriceVND";
                sql += " ,RentArea,dbo.fnDateTime(FromWD) BeginDate,dbo.fnDateTime(EndWD) EndDate,ExtratimeType";
                sql += " FROM PaymentExtraTimeMonth";
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth in (" + lsYearmonth + ")";

                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    line = rExtra - 3 + j;
                    //Phi dien
                    XLCellRange mCell = new XLCellRange(line, line + 2, 1, 3);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line + 2, 4, 4);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 6, 7);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 8, 9);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 10, 11);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 12, 13);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                    xlsSheet.MergedCells.Add(mCell);


                    /////En
                    mCell = new XLCellRange(line, line + 2, 1, 3);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line + 2, 4, 4);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 6, 7);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 8, 9);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 10, 11);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 12, 13);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                    xlsSheetEn.MergedCells.Add(mCell);
                    /////En
                    if (ds != null)
                    {
                        int count = 0;
                        DataTable dt = ds.Tables[0];

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

                            xlsSheet[tmp, 1].Value = BeginDate + "~" + EndDate;
                            xlsSheet[tmp, 5].Value = ExtraHour;

                            xlsSheet[tmp, 4].Value = "Diện tích";
                            if ("0".Equals(ExtratimeType))
                            {
                                xlsSheet[tmp, 4].Value = "m2*h";
                            }
                            xlsSheet[tmp, 6].Value = row["PriceUSD"];
                            xlsSheet[tmp, 7].Value = row["PriceVND"];

                            xlsSheet[tmp, 8].Value = row["SumUSD"];
                            xlsSheet[tmp, 9].Value = row["SumVND"];

                            xlsSheet[tmp, 10].Value = row["VatUSD"];
                            xlsSheet[tmp, 11].Value = row["VatVND"];

                            xlsSheet[tmp, 12].Value = row["LastPriceUSD"];
                            xlsSheet[tmp, 13].Value = row["LastPriceVND"];

                            LastSumPriceVND[3] += Convert.ToDecimal(row["LastPriceVND"]);
                            LastSumPriceUSD[3] += Convert.ToDecimal(row["LastPriceUSD"]);

                            XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
                            xlsSheet.MergedCells.Add(mrCell);
                            //////En
                            xlsSheetEn[tmp, 1].Value = BeginDate + "~" + EndDate;
                            xlsSheetEn[tmp, 5].Value = ExtraHour;

                            xlsSheetEn[tmp, 4].Value = "Di?n tích";
                            if ("0".Equals(ExtratimeType))
                            {
                                xlsSheetEn[tmp, 4].Value = "m2*h";
                            }
                            xlsSheetEn[tmp, 6].Value = row["PriceUSD"];
                            xlsSheetEn[tmp, 7].Value = row["PriceVND"];

                            xlsSheetEn[tmp, 8].Value = row["SumUSD"];
                            xlsSheetEn[tmp, 9].Value = row["SumVND"];

                            xlsSheetEn[tmp, 10].Value = row["VatUSD"];
                            xlsSheetEn[tmp, 11].Value = row["VatVND"];

                            xlsSheetEn[tmp, 12].Value = row["LastPriceUSD"];
                            xlsSheetEn[tmp, 13].Value = row["LastPriceVND"];

                            LastSumPriceVND[3] += Convert.ToDecimal(row["LastPriceVND"]);
                            LastSumPriceUSD[3] += Convert.ToDecimal(row["LastPriceUSD"]);

                            mrCell = new XLCellRange(tmp, tmp, 1, 3);
                            xlsSheetEn.MergedCells.Add(mrCell);
                            //////En

                            for (int col = 1; col <= 13; col++)
                            {
                                xlsSheet[tmp, col].Style = xlstStyle;
                                xlsSheetEn[tmp, col].Style = xlstStyle;
                            }

                        }
                        mCell = new XLCellRange(rExtra + 1 + j, rExtra + 1 + j, 1, 11);
                        xlsSheet.MergedCells.Add(mCell);
                        xlsSheetEn.MergedCells.Add(mCell);

                        xlsSheet[rExtra + 1 + j, 12].Value = LastSumPriceUSD[3];
                        xlsSheet[rExtra + 1 + j, 13].Value = LastSumPriceVND[3];

                        xlsSheetEn[rExtra + 1 + j, 12].Value = LastSumPriceUSD[3];
                        xlsSheetEn[rExtra + 1 + j, 13].Value = LastSumPriceVND[3];

                        for (int row = rExtra + sumRow; row <= rExtra + sumRow + dt.Rows.Count; row++)
                        {
                            for (int col = 1; col <= 13; col++)
                            {
                                xlsSheet[row, col].Style = xlstStyle;
                                xlsSheetEn[row, col].Style = xlstStyle;
                            }
                        }

                        for (int col = 1; col <= 12; col++)
                        {
                            xlsSheet[rExtra + 1 + j, col].Style = xlstStyleSum;
                            xlsSheetEn[rExtra + 1 + j, col].Style = xlstStyleSum;
                        }
                        sumRow += dt.Rows.Count - 1;
                    }
                }

                ds = new DataSet();
                //Dien
                //Xuất ra toàn bộ nội dung theo Trang
                sql = " SELECT dbo.fnDateTime(A.DateFrom) DateFrom, dbo.fnDateTime(A.DateTo) DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVND, B.PriceUSD, B.SumVND, B.SumUSD, ";
                sql += "        B.VatVND, B.VatUSD, B.LastPriceVND, B.LastPriceUSD, B.Name, B.WaterPricePercent,B.ElecPricePercent ";
                sql += " FROM   PaymentElecWater AS A INNER JOIN ";
                sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId";
                sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfWaterId = 0  and A.YearMonth in (" + lsYearmonth + ")";
                sql += " Order by A.DateFrom, B.FromIndex";

                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);

                    line = rElec - 3 + j;
                    //Phi dien
                    XLCellRange mCell = new XLCellRange(line, line + 2, 1, 1);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line + 2, 2, 2);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 3, 3);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 4, 4);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 5, 5);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 7, 7);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 8, 8);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 9, 9);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 10, 10);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 11, 11);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 12, 13);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 12, 13);
                    xlsSheet.MergedCells.Add(mCell);
                    /////En
                    mCell = new XLCellRange(line, line + 2, 1, 1);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line + 2, 2, 2);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 3, 3);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 4, 4);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 5, 5);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 7, 7);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 8, 8);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 9, 9);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 10, 10);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 11, 11);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 12, 13);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 12, 13);
                    xlsSheetEn.MergedCells.Add(mCell);
                    /////En

                    for (int col = 1; col < 13; col++)
                    {
                        xlsSheet[line, col].Style = xlstStyleH;
                        xlsSheet[line + 1, col].Style = xlstStyleH;
                        xlsSheet[line + 2, col].Style = xlstStyleH;

                        xlsSheetEn[line, col].Style = xlstStyleH;
                        xlsSheetEn[line + 1, col].Style = xlstStyleH;
                        xlsSheetEn[line + 2, col].Style = xlstStyleH;
                    }

                    if (ds != null)
                    {
                        int count = 0;
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
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

                                xlsSheet[tmp, 1].Value = DateFrom;
                                xlsSheet[tmp, 2].Value = DateTo;
                                xlsSheet[tmp, 3].Value = FromIndex;
                                xlsSheet[tmp, 4].Value = ToIndex;
                                xlsSheet[tmp, 5].Value = OtherFee01;
                                xlsSheet[tmp, 6].Value = Mount;
                                xlsSheet[tmp, 7].Value = row["PriceVND"];
                                xlsSheet[tmp, 8].Value = row["VatVND"];

                                xlsSheet[tmp, 9].Value = row["SumVND"];
                                xlsSheet[tmp, 10].Value = row["OtherFee02"];
                                xlsSheet[tmp, 11].Value = row["ElecPricePercent"];
                                xlsSheet[tmp, 12].Value = row["LastPriceVND"];

                                mCell = new XLCellRange(tmp, tmp, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);


                                /////En
                                xlsSheetEn[tmp, 1].Value = DateFrom;
                                xlsSheetEn[tmp, 2].Value = DateTo;
                                xlsSheetEn[tmp, 3].Value = FromIndex;
                                xlsSheetEn[tmp, 4].Value = ToIndex;
                                xlsSheetEn[tmp, 5].Value = OtherFee01;
                                xlsSheetEn[tmp, 6].Value = Mount;
                                xlsSheetEn[tmp, 7].Value = row["PriceVND"];
                                xlsSheetEn[tmp, 8].Value = row["VatVND"];

                                xlsSheetEn[tmp, 9].Value = row["SumVND"];
                                xlsSheetEn[tmp, 10].Value = row["OtherFee02"];
                                xlsSheetEn[tmp, 11].Value = row["ElecPricePercent"];
                                xlsSheetEn[tmp, 12].Value = row["LastPriceVND"];

                                mCell = new XLCellRange(tmp, tmp, 12, 13);
                                xlsSheetEn.MergedCells.Add(mCell);
                                /////En
                                for (int col = 1; col <= 12; col++)
                                {
                                    xlsSheet[tmp, col].Style = xlstStyle;
                                    xlsSheetEn[tmp, col].Style = xlstStyle;
                                }
                                LastSumPriceVND[4] += Convert.ToDecimal(row["LastPriceVND"]);
                                LastSumPriceUSD[4] += Convert.ToDecimal(row["LastPriceUSD"]);
                            }
                            xlsSheet[rElec + 1 + j, 12].Value = LastSumPriceVND[4];
                            mCell = new XLCellRange(rElec + 1 + j, rElec + 1 + j, 1, 11);
                            xlsSheet.MergedCells.Add(mCell);

                            mCell = new XLCellRange(rElec + 1 + j, rElec + 1 + j, 12, 13);
                            xlsSheet.MergedCells.Add(mCell);


                            xlsSheetEn[rElec + 1 + j, 12].Value = LastSumPriceVND[4];
                            mCell = new XLCellRange(rElec + 1 + j, rElec + 1 + j, 1, 11);
                            xlsSheetEn.MergedCells.Add(mCell);

                            mCell = new XLCellRange(rElec + 1 + j, rElec + 1 + j, 12, 13);
                            xlsSheetEn.MergedCells.Add(mCell);

                            for (int col = 1; col <= 13; col++)
                            {
                                xlsSheet[rElec + 1 + j, col].Style = xlstStyleSum;
                                xlsSheetEn[rElec + 1 + j, col].Style = xlstStyleSum;
                            }
                            sumRow += dt.Rows.Count - 1;
                        }
                    }
                }

                ds = new DataSet();
                //Nuoc
                //Xuất ra toàn bộ nội dung theo Trang
                sql = " SELECT dbo.fnDateTime(A.DateFrom) DateFrom, dbo.fnDateTime(A.DateTo) DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVND, B.PriceUSD, B.SumVND, B.SumUSD, ";
                sql += "        B.VatVND, B.VatUSD, B.LastPriceVND, B.LastPriceUSD, B.Name, B.WaterPricePercent,B.ElecPricePercent  ";
                sql += " FROM   PaymentElecWater AS A INNER JOIN ";
                sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId";
                sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfElecId = 0 and A.YearMonth in (" + lsYearmonth + ")";
                sql += " Order by A.DateFrom, B.FromIndex";

                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    line = rWater - 3 + j;
                    //Phi dien
                    XLCellRange mCell = new XLCellRange(line, line + 2, 1, 1);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line + 2, 2, 2);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 3, 3);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 4, 4);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 6, 6);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 7, 7);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 8, 8);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 9, 9);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 10, 10);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 11, 11);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 12, 13);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 12, 13);
                    xlsSheet.MergedCells.Add(mCell);


                    /////En
                    mCell = new XLCellRange(line, line + 2, 1, 1);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line + 2, 2, 2);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 3, 3);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 4, 4);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 6, 6);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 7, 7);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 8, 8);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 9, 9);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 10, 10);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 11, 11);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 12, 13);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 12, 13);
                    xlsSheetEn.MergedCells.Add(mCell);
                    /////En

                    for (int col = 1; col < 13; col++)
                    {
                        xlsSheet[line, col].Style = xlstStyleH;
                        xlsSheet[line + 1, col].Style = xlstStyleH;
                        xlsSheet[line + 2, col].Style = xlstStyleH;

                        xlsSheetEn[line, col].Style = xlstStyleH;
                        xlsSheetEn[line + 1, col].Style = xlstStyleH;
                        xlsSheetEn[line + 2, col].Style = xlstStyleH;
                    }

                    if (ds != null)
                    {
                        int count = 0;
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
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

                                xlsSheet[tmp, 1].Value = DateFrom;
                                xlsSheet[tmp, 2].Value = DateTo;
                                xlsSheet[tmp, 3].Value = FromIndex;
                                xlsSheet[tmp, 4].Value = ToIndex;
                                xlsSheet[tmp, 5].Value = Mount;
                                xlsSheet[tmp, 6].Value = row["PriceVND"];
                                xlsSheet[tmp, 7].Value = row["OtherFee01"];
                                xlsSheet[tmp, 8].Value = row["VatVND"];

                                xlsSheet[tmp, 9].Value = row["SumVND"];
                                xlsSheet[tmp, 10].Value = row["OtherFee02"];
                                xlsSheet[tmp, 11].Value = row["WaterPricePercent"];
                                xlsSheet[tmp, 12].Value = row["LastPriceVND"];


                                /////En
                                xlsSheetEn[tmp, 1].Value = DateFrom;
                                xlsSheetEn[tmp, 2].Value = DateTo;
                                xlsSheetEn[tmp, 3].Value = FromIndex;
                                xlsSheetEn[tmp, 4].Value = ToIndex;
                                xlsSheetEn[tmp, 5].Value = Mount;
                                xlsSheetEn[tmp, 6].Value = row["PriceVND"];
                                xlsSheetEn[tmp, 7].Value = row["OtherFee01"];
                                xlsSheetEn[tmp, 8].Value = row["VatVND"];

                                xlsSheetEn[tmp, 9].Value = row["SumVND"];
                                xlsSheetEn[tmp, 10].Value = row["OtherFee02"];
                                xlsSheetEn[tmp, 11].Value = row["WaterPricePercent"];
                                xlsSheetEn[tmp, 12].Value = row["LastPriceVND"];

                                /////En
                                for (int col = 1; col <= 12; col++)
                                {
                                    xlsSheet[tmp, col].Style = xlstStyle;
                                    xlsSheetEn[tmp, col].Style = xlstStyle;
                                }
                                LastSumPriceVND[5] += Convert.ToDecimal(row["LastPriceVND"]);
                                LastSumPriceUSD[5] += Convert.ToDecimal(row["LastPriceUSD"]);

                                mCell = new XLCellRange(tmp, tmp, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);
                            }
                            xlsSheet[rWater + 1 + j, 12].Value = LastSumPriceVND[5];
                            xlsSheetEn[rWater + 1 + j, 12].Value = LastSumPriceVND[5];
                            mCell = new XLCellRange(rWater + 1 + j, rWater + 1 + j, 1, 11);
                            xlsSheet.MergedCells.Add(mCell);
                            xlsSheetEn.MergedCells.Add(mCell);

                            mCell = new XLCellRange(rWater + 1 + j, rWater + 1 + j, 12, 13);
                            xlsSheet.MergedCells.Add(mCell);
                            xlsSheetEn.MergedCells.Add(mCell);

                            for (int col = 1; col <= 13; col++)
                            {
                                xlsSheet[rWater + 1 + j, col].Style = xlstStyleSum;
                                xlsSheetEn[rWater + 1 + j, col].Style = xlstStyleSum;
                            }
                            sumRow += dt.Rows.Count - 1;
                        }
                    }
                }

                //Service
                ds = new DataSet();

                sql = string.Empty;
                sql = " SELECT Service,dbo.fnDateTime(ServiceDateFrom) ServiceDateFrom,dbo.fnDateTime(ServiceDateTo) ServiceDateTo,PriceVND,PriceUSD,VatUSD,VatVND,Mount,Unit,SumVND,SumUSD,LastPriceVND,LastPriceUSD ";
                sql += " FROM   PaymentService";
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth in (" + lsYearmonth + ")";
                sql += " Order By ServiceDate ";

                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    line = rService - 3 + j;
                    //Phi khác
                    XLCellRange mCell = new XLCellRange(line, line + 2, 1, 1);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line + 2, 2, 2);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line + 2, 3, 3);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line + 2, 4, 4);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 5, 5);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 6, 7);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 8, 9);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 10, 11);
                    xlsSheet.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                    xlsSheet.MergedCells.Add(mCell);

                    /////En
                    mCell = new XLCellRange(line, line + 2, 1, 1);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line + 2, 2, 2);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line + 2, 3, 3);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line + 2, 4, 4);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 2, 5, 5);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 6, 7);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 8, 9);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line, line, 10, 11);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                    xlsSheetEn.MergedCells.Add(mCell);
                    /////En
                    for (int col = 1; col < 13; col++)
                    {
                        xlsSheet[line, col].Style = xlstStyleH;
                        xlsSheet[line + 1, col].Style = xlstStyleH;
                        xlsSheet[line + 2, col].Style = xlstStyleH;

                        xlsSheetEn[line, col].Style = xlstStyleH;
                        xlsSheetEn[line + 1, col].Style = xlstStyleH;
                        xlsSheetEn[line + 2, col].Style = xlstStyleH;
                    }
                    mCell = new XLCellRange(line, line, 12, 13);
                    xlsSheet.MergedCells.Add(mCell);
                    xlsSheetEn.MergedCells.Add(mCell);

                    mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                    xlsSheet.MergedCells.Add(mCell);
                    xlsSheetEn.MergedCells.Add(mCell);

                    if (ds != null)
                    {
                        int count = 0;
                        DataTable dt = ds.Tables[0];

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow row in dt.Rows)
                            {
                                if (count >= 1)
                                {
                                    xlsSheet.Rows.Insert(rService + 1 + j);
                                    xlsSheetEn.Rows.Insert(rService + 1 + j);
                                    j++;
                                }
                                count++;
                                int tmp = rService + j;



                                string Service = Func.ParseString(row["Service"]);
                                string ServiceDateFrom = Func.ParseString(row["ServiceDateFrom"]);
                                string ServiceDateTo = Func.ParseString(row["ServiceDateTo"]);

                                string Mount = Func.ParseString(row["Mount"]);

                                xlsSheet[tmp, 1].Value = Service;
                                xlsSheet[tmp, 2].Value = Func.ParseString(row["Unit"]);
                                xlsSheet[tmp, 3].Value = ServiceDateFrom;
                                xlsSheet[tmp, 4].Value = ServiceDateTo;
                                xlsSheet[tmp, 5].Value = Mount;

                                xlsSheet[tmp, 6].Value = row["PriceUSD"];
                                xlsSheet[tmp, 7].Value = row["PriceVND"];

                                xlsSheet[tmp, 8].Value = row["SumUSD"];
                                xlsSheet[tmp, 9].Value = row["SumVND"];

                                xlsSheet[tmp, 10].Value = row["VatUSD"];
                                xlsSheet[tmp, 11].Value = row["VatVND"];

                                xlsSheet[tmp, 12].Value = row["LastPriceUSD"];
                                xlsSheet[tmp, 13].Value = row["LastPriceVND"];

                                /////En
                                xlsSheetEn[tmp, 1].Value = Service;
                                xlsSheetEn[tmp, 2].Value = Func.ParseString(row["Unit"]);
                                xlsSheetEn[tmp, 3].Value = ServiceDateFrom;
                                xlsSheetEn[tmp, 4].Value = ServiceDateTo;
                                xlsSheetEn[tmp, 5].Value = Mount;

                                xlsSheetEn[tmp, 6].Value = row["PriceUSD"];
                                xlsSheetEn[tmp, 7].Value = row["PriceVND"];

                                xlsSheetEn[tmp, 8].Value = row["SumUSD"];
                                xlsSheetEn[tmp, 9].Value = row["SumVND"];

                                xlsSheetEn[tmp, 10].Value = row["VatUSD"];
                                xlsSheetEn[tmp, 11].Value = row["VatVND"];

                                xlsSheetEn[tmp, 12].Value = row["LastPriceUSD"];
                                xlsSheetEn[tmp, 13].Value = row["LastPriceVND"];
                                /////En

                                for (int col = 1; col <= 13; col++)
                                {
                                    xlsSheet[tmp, col].Style = xlstStyle;
                                    xlsSheetEn[tmp, col].Style = xlstStyle;
                                }
                                LastSumPriceVND[6] += Convert.ToDecimal(row["LastPriceVND"]);
                                LastSumPriceUSD[6] += Convert.ToDecimal(row["LastPriceUSD"]);
                            }
                            xlsSheet[rService + 1 + j, 12].Value = LastSumPriceUSD[6];
                            xlsSheet[rService + 1 + j, 13].Value = LastSumPriceVND[6];

                            xlsSheetEn[rService + 1 + j, 12].Value = LastSumPriceUSD[6];
                            xlsSheetEn[rService + 1 + j, 13].Value = LastSumPriceVND[6];

                            mCell = new XLCellRange(rService + 1 + j, rService + 1 + j, 1, 11);
                            xlsSheet.MergedCells.Add(mCell);
                            xlsSheetEn.MergedCells.Add(mCell);

                            for (int col = 1; col <= 13; col++)
                            {
                                xlsSheet[rService + 1 + j, col].Style = xlstStyleSum;
                                xlsSheetEn[rService + 1 + j, col].Style = xlstStyleSum;
                            }
                            sumRow += dt.Rows.Count - 1;
                        }
                    }
                }

                //Paid
                sql = "Select  *";
                sql += " From    PaymentBillDetail";
                sql += " Where   BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth in (" + lsYearmonth + ")";
                string strYearMonth = "";
                int lineTmp = rPaid - 2 + j;

                //Paid
                XLCellRange mCellTmp = new XLCellRange(lineTmp, lineTmp + 1, 1, 1);
                xlsSheet.MergedCells.Add(mCellTmp);

                mCellTmp = new XLCellRange(lineTmp, lineTmp, 2, 3);
                xlsSheet.MergedCells.Add(mCellTmp);

                mCellTmp = new XLCellRange(lineTmp, lineTmp, 4, 5);
                xlsSheet.MergedCells.Add(mCellTmp);

                mCellTmp = new XLCellRange(lineTmp, lineTmp, 6, 7);
                xlsSheet.MergedCells.Add(mCellTmp);

                mCellTmp = new XLCellRange(lineTmp, lineTmp, 8, 9);
                xlsSheet.MergedCells.Add(mCellTmp);

                mCellTmp = new XLCellRange(lineTmp, lineTmp, 12, 13);
                xlsSheet.MergedCells.Add(mCellTmp);

                /////En
                mCellTmp = new XLCellRange(lineTmp, lineTmp + 1, 1, 1);
                xlsSheetEn.MergedCells.Add(mCellTmp);

                mCellTmp = new XLCellRange(lineTmp, lineTmp, 2, 3);
                xlsSheetEn.MergedCells.Add(mCellTmp);

                mCellTmp = new XLCellRange(lineTmp, lineTmp, 4, 5);
                xlsSheetEn.MergedCells.Add(mCellTmp);

                mCellTmp = new XLCellRange(lineTmp, lineTmp, 6, 7);
                xlsSheetEn.MergedCells.Add(mCellTmp);

                mCellTmp = new XLCellRange(lineTmp, lineTmp, 8, 9);
                xlsSheetEn.MergedCells.Add(mCellTmp);

                mCellTmp = new XLCellRange(lineTmp, lineTmp, 12, 13);
                xlsSheetEn.MergedCells.Add(mCellTmp);
                /////En
                Hashtable rowNo = new Hashtable();
                decimal[] PaidSumVND = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };
                decimal[] PaidSumUSD = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };

                DataTable dtPaid = DbHelper.GetDataTable(sql);
                for (int i = 0; i < dtPaid.Rows.Count; i++)
                {
                    string PaymentType = Func.ParseString(dtPaid.Rows[i]["PaymentType"]);
                    string MoneyUSD = Func.ParseString(dtPaid.Rows[i]["MoneyUSD"]);
                    string MoneyVND = Func.ParseString(dtPaid.Rows[i]["MoneyVND"]);
                    string PaidUSD = Func.ParseString(dtPaid.Rows[i]["PaidUSD"]);
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
                    decimal tmpUSD = Convert.ToDecimal(MoneyUSD) - Convert.ToDecimal(PaidUSD);
                    decimal tmpVND = Convert.ToDecimal(MoneyVND) - Convert.ToDecimal(PaidVND);

                    PaidPriceUSD += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                    PaidPriceVND += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);

                    xlsSheet[rPaid + m, 1].Value = YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4);
                    xlsSheetEn[rPaid + m, 1].Value = YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4);
                    switch (PaymentType)
                    {
                        case "1":
                            //Rent
                            xlsSheet[rPaid + m, 2].Value = dtPaid.Rows[i]["PaidUSD"];
                            xlsSheet[rPaid + m, 3].Value = dtPaid.Rows[i]["PaidVND"];

                            xlsSheetEn[rPaid + m, 2].Value = dtPaid.Rows[i]["PaidUSD"];
                            xlsSheetEn[rPaid + m, 3].Value = dtPaid.Rows[i]["PaidVND"];

                            PaidSumUSD[0] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                            PaidSumVND[0] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);

                            break;
                        case "2":
                            //Manager
                            xlsSheet[rPaid + m, 4].Value = dtPaid.Rows[i]["PaidUSD"];
                            xlsSheet[rPaid + m, 5].Value = dtPaid.Rows[i]["PaidVND"];

                            xlsSheetEn[rPaid + m, 4].Value = dtPaid.Rows[i]["PaidUSD"];
                            xlsSheetEn[rPaid + m, 5].Value = dtPaid.Rows[i]["PaidVND"];

                            PaidSumUSD[1] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                            PaidSumVND[1] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);

                            break;
                        case "3":
                            //Parking
                            xlsSheet[rPaid + m, 6].Value = dtPaid.Rows[i]["PaidUSD"];
                            xlsSheet[rPaid + m, 7].Value = dtPaid.Rows[i]["PaidVND"];

                            xlsSheetEn[rPaid + m, 6].Value = dtPaid.Rows[i]["PaidUSD"];
                            xlsSheetEn[rPaid + m, 7].Value = dtPaid.Rows[i]["PaidVND"];

                            PaidSumUSD[2] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                            PaidSumVND[2] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
                            break;
                        case "4":
                            //Extra
                            xlsSheet[rPaid + m, 8].Value = dtPaid.Rows[i]["PaidUSD"];
                            xlsSheet[rPaid + m, 9].Value = dtPaid.Rows[i]["PaidVND"];

                            xlsSheetEn[rPaid + m, 8].Value = dtPaid.Rows[i]["PaidUSD"];
                            xlsSheetEn[rPaid + m, 9].Value = dtPaid.Rows[i]["PaidVND"];

                            PaidSumUSD[3] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                            PaidSumVND[3] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
                            break;
                        case "5":
                            xlsSheet[rPaid + m, 10].Value = dtPaid.Rows[i]["PaidVND"];
                            xlsSheetEn[rPaid + m, 10].Value = dtPaid.Rows[i]["PaidVND"];

                            PaidSumUSD[4] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                            PaidSumVND[4] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
                            break;
                        case "6":
                            xlsSheet[rPaid + m, 11].Value = dtPaid.Rows[i]["PaidVND"];
                            xlsSheetEn[rPaid + m, 11].Value = dtPaid.Rows[i]["PaidVND"];

                            PaidSumUSD[5] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                            PaidSumVND[5] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
                            break;
                        case "7":
                            xlsSheet[rPaid + m, 12].Value = dtPaid.Rows[i]["PaidUSD"];
                            xlsSheet[rPaid + m, 13].Value = dtPaid.Rows[i]["PaidVND"];

                            xlsSheetEn[rPaid + m, 12].Value = dtPaid.Rows[i]["PaidUSD"];
                            xlsSheetEn[rPaid + m, 13].Value = dtPaid.Rows[i]["PaidVND"];
                            break;
                        default:
                            break;
                    }
                    for (int row = rPaid + m; row <= rPaid + 1 + j; row++)
                    {
                        for (int col = 1; col <= 13; col++)
                        {
                            xlsSheet[row, col].Style = xlstStyle;
                        }
                    }
                }
                lineTmp = rPaid - 2 + j;

                xlsSheet[lineTmp + 3, 2].Value = PaidSumUSD[0];
                xlsSheet[lineTmp + 3, 3].Value = PaidSumVND[0];
                xlsSheet[lineTmp + 3, 4].Value = PaidSumUSD[1];
                xlsSheet[lineTmp + 3, 5].Value = PaidSumVND[1];
                xlsSheet[lineTmp + 3, 6].Value = PaidSumUSD[2];
                xlsSheet[lineTmp + 3, 7].Value = PaidSumVND[2];
                xlsSheet[lineTmp + 3, 8].Value = PaidSumUSD[3];
                xlsSheet[lineTmp + 3, 9].Value = PaidSumVND[3];
                xlsSheet[lineTmp + 3, 10].Value = PaidSumVND[4];
                xlsSheet[lineTmp + 3, 11].Value = PaidSumVND[5];
                xlsSheet[lineTmp + 3, 12].Value = PaidSumUSD[6];
                xlsSheet[lineTmp + 3, 13].Value = PaidSumVND[6];

                /////En
                xlsSheetEn[lineTmp + 3, 2].Value = PaidSumUSD[0];
                xlsSheetEn[lineTmp + 3, 3].Value = PaidSumVND[0];
                xlsSheetEn[lineTmp + 3, 4].Value = PaidSumUSD[1];
                xlsSheetEn[lineTmp + 3, 5].Value = PaidSumVND[1];
                xlsSheetEn[lineTmp + 3, 6].Value = PaidSumUSD[2];
                xlsSheetEn[lineTmp + 3, 7].Value = PaidSumVND[2];
                xlsSheetEn[lineTmp + 3, 8].Value = PaidSumUSD[3];
                xlsSheetEn[lineTmp + 3, 9].Value = PaidSumVND[3];
                xlsSheetEn[lineTmp + 3, 10].Value = PaidSumVND[4];
                xlsSheetEn[lineTmp + 3, 11].Value = PaidSumVND[5];
                xlsSheetEn[lineTmp + 3, 12].Value = PaidSumUSD[6];
                xlsSheetEn[lineTmp + 3, 13].Value = PaidSumVND[6];
                /////En

                for (int col = 1; col <= 13; col++)
                {
                    xlsSheet[lineTmp + 3, col].Style = xlstStyleSum;
                    xlsSheetEn[lineTmp + 3, col].Style = xlstStyleSum;
                }

                ///////////////DEPT
                sql = "  Select *";
                sql += " From   v_DeptBill";
                sql += " Where  BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth not in (" + lsYearmonth + ")";
                sql += " And    (DeptUsd <> 0 or DeptVnd <> 0)";
                strYearMonth = "";
                lineTmp = rDept - 2 + j;

                //Paid
                mCellTmp = new XLCellRange(lineTmp, lineTmp + 1, 1, 1);
                xlsSheet.MergedCells.Add(mCellTmp);

                mCellTmp = new XLCellRange(lineTmp, lineTmp, 2, 3);
                xlsSheet.MergedCells.Add(mCellTmp);

                mCellTmp = new XLCellRange(lineTmp, lineTmp, 4, 5);
                xlsSheet.MergedCells.Add(mCellTmp);

                mCellTmp = new XLCellRange(lineTmp, lineTmp, 6, 7);
                xlsSheet.MergedCells.Add(mCellTmp);

                mCellTmp = new XLCellRange(lineTmp, lineTmp, 8, 9);
                xlsSheet.MergedCells.Add(mCellTmp);

                mCellTmp = new XLCellRange(lineTmp, lineTmp, 12, 13);
                xlsSheet.MergedCells.Add(mCellTmp);

                //////En
                mCellTmp = new XLCellRange(lineTmp, lineTmp + 1, 1, 1);
                xlsSheetEn.MergedCells.Add(mCellTmp);

                mCellTmp = new XLCellRange(lineTmp, lineTmp, 2, 3);
                xlsSheetEn.MergedCells.Add(mCellTmp);

                mCellTmp = new XLCellRange(lineTmp, lineTmp, 4, 5);
                xlsSheetEn.MergedCells.Add(mCellTmp);

                mCellTmp = new XLCellRange(lineTmp, lineTmp, 6, 7);
                xlsSheetEn.MergedCells.Add(mCellTmp);

                mCellTmp = new XLCellRange(lineTmp, lineTmp, 8, 9);
                xlsSheetEn.MergedCells.Add(mCellTmp);

                mCellTmp = new XLCellRange(lineTmp, lineTmp, 12, 13);
                xlsSheetEn.MergedCells.Add(mCellTmp);
                //////En
                rowNo = new Hashtable();
                decimal DeptPriceVND = 0;
                decimal DeptPriceUSD = 0;

                decimal[] DeptSumVND = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };
                decimal[] DeptSumUSD = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };


                DataTable dtDept = DbHelper.GetDataTable(sql);
                for (int i = 0; i < dtDept.Rows.Count; i++)
                {
                    string PaymentType = Func.ParseString(dtDept.Rows[i]["PaymentType"]);
                    string DeptUSD = Func.ParseString(dtDept.Rows[i]["DeptUSD"]);
                    string DeptVND = Func.ParseString(dtDept.Rows[i]["DeptVND"]);
                    string YearMonth = Func.ParseString(dtDept.Rows[i]["YearMonth"]);

                    if (!rowNo.Contains(YearMonth))
                    {
                        if (rowNo.Count != 0)
                        {
                            xlsSheet.Rows.Insert(rDept + j + 1);
                            xlsSheetEn.Rows.Insert(rDept + j + 1);
                            j++;
                        }
                        rowNo.Add(YearMonth, j);
                    }
                    int m = Func.ParseInt(rowNo[YearMonth]);
                    strYearMonth = YearMonth;

                    DeptPriceUSD += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                    DeptPriceVND += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);

                    xlsSheet[rDept + m, 1].Value = YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4);
                    xlsSheetEn[rDept + m, 1].Value = YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4);

                    xlsSheetEn[rDept + m, 2].Value = 0;
                    xlsSheetEn[rDept + m, 3].Value = 0;
                    xlsSheetEn[rDept + m, 4].Value = 0;
                    xlsSheetEn[rDept + m, 5].Value = 0;
                    xlsSheetEn[rDept + m, 6].Value = 0;
                    xlsSheetEn[rDept + m, 7].Value = 0;
                    xlsSheetEn[rDept + m, 8].Value = 0;
                    xlsSheetEn[rDept + m, 9].Value = 0;
                    xlsSheetEn[rDept + m, 10].Value = 0;
                    xlsSheetEn[rDept + m, 11].Value = 0;
                    xlsSheetEn[rDept + m, 12].Value = 0;
                    xlsSheetEn[rDept + m, 13].Value = 0;

                    xlsSheet[rDept + m, 2].Value = 0;
                    xlsSheet[rDept + m, 3].Value = 0;
                    xlsSheet[rDept + m, 4].Value = 0;
                    xlsSheet[rDept + m, 5].Value = 0;
                    xlsSheet[rDept + m, 6].Value = 0;
                    xlsSheet[rDept + m, 7].Value = 0;
                    xlsSheet[rDept + m, 8].Value = 0;
                    xlsSheet[rDept + m, 9].Value = 0;
                    xlsSheet[rDept + m, 10].Value = 0;
                    xlsSheet[rDept + m, 11].Value = 0;
                    xlsSheet[rDept + m, 12].Value = 0;
                    xlsSheet[rDept + m, 13].Value = 0;

                    switch (PaymentType)
                    {
                        case "1":
                            //Rent
                            xlsSheet[rDept + m, 2].Value = dtDept.Rows[i]["DeptUSD"];
                            xlsSheet[rDept + m, 3].Value = dtDept.Rows[i]["DeptVND"];

                            xlsSheetEn[rDept + m, 2].Value = dtDept.Rows[i]["DeptUSD"];
                            xlsSheetEn[rDept + m, 3].Value = dtDept.Rows[i]["DeptVND"];

                            DeptSumUSD[0] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                            DeptSumVND[0] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);

                            break;
                        case "2":
                            //Manager
                            xlsSheet[rDept + m, 4].Value = dtDept.Rows[i]["DeptUSD"];
                            xlsSheet[rDept + m, 5].Value = dtDept.Rows[i]["DeptVND"];

                            xlsSheetEn[rDept + m, 4].Value = dtDept.Rows[i]["DeptUSD"];
                            xlsSheetEn[rDept + m, 5].Value = dtDept.Rows[i]["DeptVND"];

                            DeptSumUSD[1] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                            DeptSumVND[1] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);

                            break;
                        case "3":
                            //Parking
                            xlsSheet[rDept + m, 6].Value = dtDept.Rows[i]["DeptUSD"];
                            xlsSheet[rDept + m, 7].Value = dtDept.Rows[i]["DeptVND"];

                            xlsSheetEn[rDept + m, 6].Value = dtDept.Rows[i]["DeptUSD"];
                            xlsSheetEn[rDept + m, 7].Value = dtDept.Rows[i]["DeptVND"];

                            DeptSumUSD[2] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                            DeptSumVND[2] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
                            break;
                        case "4":
                            //Extra
                            xlsSheet[rDept + m, 8].Value = dtDept.Rows[i]["DeptUSD"];
                            xlsSheet[rDept + m, 9].Value = dtDept.Rows[i]["DeptVND"];

                            xlsSheetEn[rDept + m, 8].Value = dtDept.Rows[i]["DeptUSD"];
                            xlsSheetEn[rDept + m, 9].Value = dtDept.Rows[i]["DeptVND"];

                            DeptSumUSD[3] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                            DeptSumVND[3] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
                            break;
                        case "5":
                            xlsSheet[rDept + m, 10].Value = dtDept.Rows[i]["DeptVND"];
                            xlsSheetEn[rDept + m, 10].Value = dtDept.Rows[i]["DeptVND"];

                            DeptSumUSD[4] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                            DeptSumVND[4] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
                            break;
                        case "6":
                            xlsSheet[rDept + m, 11].Value = dtDept.Rows[i]["DeptVND"];
                            xlsSheetEn[rDept + m, 11].Value = dtDept.Rows[i]["DeptVND"];

                            DeptSumUSD[5] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                            DeptSumVND[5] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
                            break;
                        case "7":
                            xlsSheet[rDept + m, 12].Value = dtDept.Rows[i]["DeptUSD"];
                            xlsSheet[rDept + m, 13].Value = dtDept.Rows[i]["DeptVND"];

                            xlsSheetEn[rDept + m, 12].Value = dtDept.Rows[i]["DeptUSD"];
                            xlsSheetEn[rDept + m, 13].Value = dtDept.Rows[i]["DeptVND"];

                            DeptSumUSD[6] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                            DeptSumVND[6] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
                            break;
                        default:
                            break;
                    }
                    for (int row = rDept + m; row <= rDept + 1 + j; row++)
                    {
                        for (int col = 1; col <= 13; col++)
                        {
                            xlsSheet[row, col].Style = xlstStyle;
                            xlsSheetEn[row, col].Style = xlstStyle;
                        }
                    }
                }
                lineTmp = rDept - 2 + j;

                xlsSheet[lineTmp + 3, 2].Value = DeptSumUSD[0];
                xlsSheet[lineTmp + 3, 3].Value = DeptSumVND[0];
                xlsSheet[lineTmp + 3, 4].Value = DeptSumUSD[1];
                xlsSheet[lineTmp + 3, 5].Value = DeptSumVND[1];
                xlsSheet[lineTmp + 3, 6].Value = DeptSumUSD[2];
                xlsSheet[lineTmp + 3, 7].Value = DeptSumVND[2];
                xlsSheet[lineTmp + 3, 8].Value = DeptSumUSD[3];
                xlsSheet[lineTmp + 3, 9].Value = DeptSumVND[3];
                xlsSheet[lineTmp + 3, 10].Value = DeptSumVND[4];
                xlsSheet[lineTmp + 3, 11].Value = DeptSumVND[5];
                xlsSheet[lineTmp + 3, 12].Value = DeptSumUSD[6];
                xlsSheet[lineTmp + 3, 13].Value = DeptSumVND[6];


                //////En
                xlsSheetEn[lineTmp + 3, 2].Value = DeptSumUSD[0];
                xlsSheetEn[lineTmp + 3, 3].Value = DeptSumVND[0];
                xlsSheetEn[lineTmp + 3, 4].Value = DeptSumUSD[1];
                xlsSheetEn[lineTmp + 3, 5].Value = DeptSumVND[1];
                xlsSheetEn[lineTmp + 3, 6].Value = DeptSumUSD[2];
                xlsSheetEn[lineTmp + 3, 7].Value = DeptSumVND[2];
                xlsSheetEn[lineTmp + 3, 8].Value = DeptSumUSD[3];
                xlsSheetEn[lineTmp + 3, 9].Value = DeptSumVND[3];
                xlsSheetEn[lineTmp + 3, 10].Value = DeptSumVND[4];
                xlsSheetEn[lineTmp + 3, 11].Value = DeptSumVND[5];
                xlsSheetEn[lineTmp + 3, 12].Value = DeptSumUSD[6];
                xlsSheetEn[lineTmp + 3, 13].Value = DeptSumVND[6];
                //////En
                for (int col = 1; col <= 13; col++)
                {
                    xlsSheet[lineTmp + 3, col].Style = xlstStyleSum;
                    xlsSheetEn[lineTmp + 3, col].Style = xlstStyleSum;
                }

                xlsSheet[lineTmp + 3, 1].Style = xlstStyleSum;
                xlsSheetEn[lineTmp + 3, 1].Style = xlstStyleSum;

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

                xlsSheet[rSumVND + j, cSumVND].Value = Func.FormatNumber_New(AllSumUSD);
                xlsSheet[rSumVND + j, cSumVND].Value += "(USD)";
                xlsSheet[rSumVND + j, cSumVND + 1].Value = Func.FormatNumber_New(AllSumVND);
                xlsSheet[rSumVND + j, cSumVND + 1].Value += "(VND)";

                xlsSheetEn[rSumVND + j, cSumVND].Value = Func.FormatNumber_New(AllSumUSD);
                xlsSheetEn[rSumVND + j, cSumVND].Value += "(USD)";
                xlsSheetEn[rSumVND + j, cSumVND + 1].Value = Func.FormatNumber_New(AllSumVND);
                xlsSheetEn[rSumVND + j, cSumVND + 1].Value += "(VND)";

                AllSumVND += Convert.ToDecimal(AllSumUSD * Convert.ToDecimal(txtUsdExchange.Text));

                string strMoney = Func.docso(Convert.ToInt32(AllSumVND));
                string strMoneyEn = Func.DocSo_En(Convert.ToInt32(AllSumVND));

                xlsSheet[rContract, cContract].Value = xlsSheet[rContract, cContract].Value.ToString().Replace("{%HOP_DONG%}", contract.Substring(1));
                xlsSheet[rSum + j, cSum].Value = Convert.ToInt32(AllSumVND);

                mCellTmp = new XLCellRange(rSum + j, rSum + j, cSum, cSum + 1);
                xlsSheet.MergedCells.Add(mCellTmp);
                xlsSheet[rSum + j, cSum].Style = xlstStyleSum;
                xlsSheet[rSum + j, cSum + 1].Style = xlstStyleSum;
                xlsSheet[rSumRead + j, cSumRead].Value = xlsSheet[rSumRead + j, cSumRead].Value.ToString().Replace("{%TONG_CHU%}", strMoney.ToUpper());


                xlsSheetEn[rContract, cContract].Value = xlsSheetEn[rContract, cContract].Value.ToString().Replace("{%HOP_DONG%}", contract.Substring(1));
                xlsSheetEn[rSum + j, cSum].Value = Convert.ToInt32(AllSumVND);

                mCellTmp = new XLCellRange(rSum + j, rSum + j, cSum, cSum + 1);
                xlsSheetEn.MergedCells.Add(mCellTmp);
                xlsSheetEn[rSum + j, cSum].Style = xlstStyleSum;
                xlsSheetEn[rSum + j, cSum + 1].Style = xlstStyleSum;
                xlsSheetEn[rSumRead + j, cSumRead].Value = xlsSheetEn[rSumRead + j, cSumRead].Value.ToString().Replace("{%TONG_CHU%}", strMoneyEn.ToUpper());

                xlbBook.Save(fileNameDes);
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);
            }
        }
    }
}