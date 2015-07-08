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
    public partial class PaymentBillDetailReview : PageBase
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

        private void ShowData()
        {
            string yearmonth = "";
            if (!String.IsNullOrEmpty(hidId.Value))
            {
                PaymentBillInfoData data = new PaymentBillInfoData();
                ITransaction tran = factory.GetLoadObject(data, hidId.Value);
                Execute(tran);
                if (!HasError)
                {
                    data = (PaymentBillInfoData)tran.Result;

                    lblBillNo.Text = data.BillNo;
                    lblBillDate.Text = Func.FormatDMY(data.BillDate);
                    lblUsdExchangeDate.Text = Func.FormatDMY(data.UsdExchangeDate);
                    lblUsdExchange.Text = Func.FormatNumber_New(data.UsdExchange) + "VND";
                    yearmonth = data.YearMonths;
                    
                    string[] tmp = yearmonth.Replace("'", "").Split(',');
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        lblYearMonth.Text += Func.parseYYYYMM(tmp[i]);
                    }
                    lblCustomerId.Text = data.CustomerId;
                    lblName.Text = DbHelper.GetScalar("Select Name from Customer where customerid = '" + data.CustomerId + "' and BuildingId= '" + Func.ParseString(Session["__BUILDINGID__"]) + "'");
                }
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
                sql += " WHERE CustomerId = '" + lblCustomerId.Text + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and YearMonth in (" + yearmonth + ")";

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
                sql += " SELECT COUNT(*) AS Num, YearMonth, TariffsParkingName, PriceVnd, PriceUsd, SUM(VatVnd) AS VatVnd,SUM(VatUsd) AS VatUsd, SUM(SumVnd) AS SumVnd, SUM(SumUsd) AS SumUsd, SUM(LastPriceVnd) AS LastPriceVnd";
                sql += "        , SUM(LastPriceUsd) AS LastPriceUsd";
                sql += " FROM         dbo.PaymentParking";
                sql += " WHERE CustomerId = '" + lblCustomerId.Text + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and YearMonth in (" + yearmonth + ")";
                sql += " GROUP BY YearMonth, TariffsParkingName, PriceVnd, PriceUsd, Vat, daysParking";

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
                sql += " WHERE CustomerId = '" + lblCustomerId.Text + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and YearMonth in (" + yearmonth + ")";

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
                sql += " SELECT BD_Room.Name as RoomName, A.DateFrom, A.DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVnd, B.PriceUsd, B.SumVnd, B.SumUsd, ";
                sql += "        B.VatVnd, B.VatUsd, B.LastPriceVnd, B.LastPriceUsd, B.Name,B.WaterPricePercent,B.ElecPricePercent ";
                sql += " FROM   PaymentElecWater AS A INNER JOIN ";
                sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId INNER JOIN";
                sql += "        BD_Room ON A.RoomId = BD_Room.id";
                sql += " WHERE A.CustomerId = '" + lblCustomerId.Text + "' and A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and TarrifsOfWaterId = 0  and A.YearMonth in (" + yearmonth + ")";
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
                sql += " SELECT BD_Room.Name as RoomName, A.DateFrom, A.DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVnd, B.PriceUsd, B.SumVnd, B.SumUsd, ";
                sql += "        B.VatVnd, B.VatUsd, B.LastPriceVnd, B.LastPriceUsd, B.Name,B.WaterPricePercent,B.ElecPricePercent ";
                sql += " FROM   PaymentElecWater AS A INNER JOIN ";
                sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId INNER JOIN";
                sql += "        BD_Room ON A.RoomId = BD_Room.id";
                sql += " WHERE A.CustomerId = '" + lblCustomerId.Text + "' and A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and TarrifsOfElecId = 0 and A.YearMonth in (" + yearmonth + ")";
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
                sql += " WHERE CustomerId = '" + lblCustomerId.Text + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and YearMonth in (" + yearmonth + ")";

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

                sql = "  Select  SUM(MoneyUsd) AS MoneyUsd, SUM(MoneyVnd) AS MoneyVnd, SUM(PaidUsd) AS PaidUsd, SUM(PaidVnd) AS PaidVnd, PaymentType";
                sql += " From    PaymentBillDetail";
                sql += " Where   CustomerId = '" + lblCustomerId.Text + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and YearMonth in (" + yearmonth + ")";
                sql += " GROUP BY PaymentType";

                DataTable dt = DbHelper.GetDataTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string PaymentType = Func.ParseString(dt.Rows[i]["PaymentType"]);
                    string MoneyUsd = Func.ParseString(dt.Rows[i]["MoneyUsd"]);
                    string MoneyVnd = Func.ParseString(dt.Rows[i]["MoneyVnd"]);
                    string PaidUsd = Func.ParseString(dt.Rows[i]["PaidUsd"]);
                    string PaidVnd = Func.ParseString(dt.Rows[i]["PaidVnd"]);
                    //string ExchangeType = Func.ParseString(dt.Rows[i]["ExchangeType"]);
                    //string UsdExchange = Func.ParseString(dt.Rows[i]["UsdExchange"]);

                    decimal tmpUsd = Convert.ToDecimal(MoneyUsd) - Convert.ToDecimal(PaidUsd);
                    decimal tmpVnd = Convert.ToDecimal(MoneyVnd) - Convert.ToDecimal(PaidVnd);

                    switch (PaymentType)
                    {
                        case "1":
                            //Rent
                            lblRentUsd.Text = Func.FormatNumber_New(MoneyUsd); // Where Fieldname is the name of fields from your database that you want to get
                            lblRentVnd.Text = Func.FormatNumber_New(MoneyVnd); // Where Fieldname is the name of fields from your database that you want to get

                            lblRentPaidUsd.Text = Func.FormatNumber_New(PaidUsd); // Where Fieldname is the name of fields from your database that you want to get
                            lblRentPaidVnd.Text = Func.FormatNumber_New(PaidVnd); // Where Fieldname is the name of fields from your database that you want to get

                            lblRentPaidUsdRemain.Text = Func.FormatNumber_New(tmpUsd);
                            lblRentPaidVndRemain.Text = Func.FormatNumber_New(tmpVnd);

                            //if (tmpUsd > 0)
                            //{
                            //    lblRentPaidUsd.Text = Func.FormatNumber_New(tmpUsd);
                            //}
                            //if (tmpVnd > 0)
                            //{
                            //    lblRentPaidVnd.Text = Func.FormatNumber_New(tmpVnd);
                            //}
                            break;
                        case "2":
                            //Manager
                            lblManagerUsd.Text = Func.FormatNumber_New(MoneyUsd); // Where Fieldname is the name of fields from your database that you want to get
                            lblManagerVnd.Text = Func.FormatNumber_New(MoneyVnd); // Where Fieldname is the name of fields from your database that you want to get

                            lblManagerPaidUsd.Text = Func.FormatNumber_New(PaidUsd); // Where Fieldname is the name of fields from your database that you want to get
                            lblManagerPaidVnd.Text = Func.FormatNumber_New(PaidVnd); // Where Fieldname is the name of fields from your database that you want to get

                            lblManagerPaidUsdRemain.Text = Func.FormatNumber_New(tmpUsd);
                            lblManagerPaidVndRemain.Text = Func.FormatNumber_New(tmpVnd);

                            //if (tmpUsd > 0)
                            //{
                            //    lblManagerPaidUsd.Text = Func.FormatNumber_New(tmpUsd);
                            //}
                            //if (tmpVnd > 0)
                            //{
                            //    lblManagerPaidVnd.Text = Func.FormatNumber_New(tmpVnd);
                            //}

                            break;
                        case "3":
                            //Parking
                            lblParkingUsd.Text = Func.FormatNumber_New(MoneyUsd); // Where Fieldname is the name of fields from your database that you want to get
                            lblParkingVnd.Text = Func.FormatNumber_New(MoneyVnd); // Where Fieldname is the name of fields from your database that you want to get

                            lblParkingPaidUsd.Text = Func.FormatNumber_New(PaidUsd); // Where Fieldname is the name of fields from your database that you want to get
                            lblParkingPaidVnd.Text = Func.FormatNumber_New(PaidVnd); // Where Fieldname is the name of fields from your database that you want to get

                            //lblParkingPaidUsd.Text = Func.FormatNumber_New(Func.ParseFloat(MoneyUsd) - Func.ParseFloat(PaidUsd));
                            //lblParkingPaidVnd.Text = Func.FormatNumber_New(Func.ParseDouble(MoneyVnd) - Func.ParseFloat(PaidVnd));

                            lblParkingPaidUsdRemain.Text = Func.FormatNumber_New(tmpUsd);
                            lblParkingPaidVndRemain.Text = Func.FormatNumber_New(tmpVnd);

                            //if (tmpUsd > 0)
                            //{
                            //    lblParkingPaidUsd.Text = Func.FormatNumber_New(tmpUsd);
                            //}
                            //if (tmpVnd > 0)
                            //{
                            //    lblParkingPaidVnd.Text = Func.FormatNumber_New(tmpVnd);
                            //}
                            break;
                        case "4":
                            lblExtraTimeUsd.Text = Func.FormatNumber_New(MoneyUsd); // Where Fieldname is the name of fields from your database that you want to get
                            lblExtraTimeVnd.Text = Func.FormatNumber_New(MoneyVnd); // Where Fieldname is the name of fields from your database that you want to get

                            lblExtraTimePaidUsd.Text = Func.FormatNumber_New(PaidUsd); // Where Fieldname is the name of fields from your database that you want to get
                            lblExtraTimePaidVnd.Text = Func.FormatNumber_New(PaidVnd); // Where Fieldname is the name of fields from your database that you want to get

                            //lblExtraTimePaidUsd.Text = Func.FormatNumber_New(Func.ParseFloat(MoneyUsd) - Func.ParseFloat(PaidUsd));
                            //lblExtraTimePaidVnd.Text = Func.FormatNumber_New(Func.ParseDouble(MoneyVnd) - Func.ParseFloat(PaidVnd));

                            lblExtraTimePaidUsdRemain.Text = Func.FormatNumber_New(tmpUsd);
                            lblExtraTimePaidVndRemain.Text = Func.FormatNumber_New(tmpVnd);

                            //if (tmpUsd > 0)
                            //{
                            //    lblExtraTimePaidUsd.Text = Func.FormatNumber_New(tmpUsd);
                            //}
                            //if (tmpVnd > 0)
                            //{
                            //    lblExtraTimePaidVnd.Text = Func.FormatNumber_New(tmpVnd);
                            //}
                            break;
                        case "5":
                            lblElecVnd.Text = Func.FormatNumber_New(MoneyVnd); // Where Fieldname is the name of fields from your database that you want to get
                            lblElecPaidVnd.Text = Func.FormatNumber_New(PaidVnd); // Where Fieldname is the name of fields from your database that you want to get

                            //lblElecPaidVnd.Text = Func.FormatNumber_New(Func.ParseDouble(MoneyVnd) - Func.ParseFloat(PaidVnd));
                            lblElecPaidVndRemain.Text = Func.FormatNumber_New(tmpVnd);
                            //if (tmpVnd > 0)
                            //{
                            //    lblElecPaidVnd.Text = Func.FormatNumber_New(tmpVnd);
                            //}
                            break;
                        case "6":
                            lblWaterVnd.Text = Func.FormatNumber_New(MoneyVnd); // Where Fieldname is the name of fields from your database that you want to get
                            lblWaterPaidVnd.Text = Func.FormatNumber_New(PaidVnd); // Where Fieldname is the name of fields from your database that you want to get
                            //lblWaterPaidVnd.Text = Func.FormatNumber_New(Func.ParseFloat(MoneyVnd) - Func.ParseFloat(PaidVnd));
                            lblWaterPaidVndRemain.Text = Func.FormatNumber_New(tmpVnd);

                            //if (tmpVnd > 0)
                            //{
                            //    lblWaterPaidVnd.Text = Func.FormatNumber_New(tmpVnd);
                            //}
                            break;
                        case "7":
                            lblServiceUsd.Text = Func.FormatNumber_New(MoneyUsd); // Where Fieldname is the name of fields from your database that you want to get
                            lblServiceVnd.Text = Func.FormatNumber_New(MoneyVnd); // Where Fieldname is the name of fields from your database that you want to get

                            lblServicePaidUsd.Text = Func.FormatNumber_New(PaidUsd); // Where Fieldname is the name of fields from your database that you want to get
                            lblServicePaidVnd.Text = Func.FormatNumber_New(PaidVnd); // Where Fieldname is the name of fields from your database that you want to get

                            //lblServicePaidUsd.Text = Func.ParseString(Func.ParseFloat(MoneyUsd) - Func.ParseFloat(PaidUsd));
                            //lblServicePaidVnd.Text = Func.FormatNumber_New(Func.ParseFloat(MoneyVnd) - Func.ParseFloat(PaidVnd));

                            lblServicePaidUsdRemain.Text = Func.FormatNumber_New(tmpUsd);
                            lblServicePaidVndRemain.Text = Func.FormatNumber_New(tmpVnd);

                            //if (tmpUsd > 0)
                            //{
                            //    lblServicePaidUsd.Text = Func.FormatNumber_New(tmpUsd);
                            //}
                            //if (tmpVnd > 0)
                            //{
                            //    lblServicePaidVnd.Text = Func.FormatNumber_New(tmpVnd);
                            //}
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
        /// List data
        /// </summary>
        private void ShowData(string YearMonth)
        {

            if (!String.IsNullOrEmpty(hidId.Value))
            {
                PaymentBillInfoData data = new PaymentBillInfoData();
                ITransaction tran = factory.GetLoadObject(data, hidId.Value);
                Execute(tran);
                if (!HasError)
                {
                    data = (PaymentBillInfoData)tran.Result;

                    lblBillNo.Text = data.BillNo;
                    lblBillDate.Text = data.BillDate;
                    lblUsdExchangeDate.Text = Func.FormatDMY(data.UsdExchangeDate);
                    lblUsdExchange.Text = Func.ParseString(Func.ParseFloat(data.UsdExchange));
                }
            }
            else
            {
                lblBillNo.Text = "";
                lblBillDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                lblUsdExchangeDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                lblUsdExchange.Text = "";
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
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and YearMonth in (" + YearMonth + ")";

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
                sql += " SELECT COUNT(*) AS Num, YearMonth, TariffsParkingName, PriceVnd, PriceUsd, SUM(VatVnd) AS VatVnd,SUM(VatUsd) AS VatUsd, SUM(SumVnd) AS SumVnd, SUM(SumUsd) AS SumUsd, SUM(LastPriceVnd) AS LastPriceVnd";
                sql += "        , SUM(LastPriceUsd) AS LastPriceUsd";
                sql += " FROM         dbo.PaymentParking";
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and YearMonth in (" + YearMonth + ")";
                sql += " GROUP BY YearMonth, TariffsParkingName, PriceVnd, PriceUsd, Vat, daysParking";

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
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and YearMonth in (" + YearMonth + ")";

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
                sql += " SELECT BD_Room.Name as RoomName, A.DateFrom, A.DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVnd, B.PriceUsd, B.SumVnd, B.SumUsd, ";
                sql += "        B.VatVnd, B.VatUsd, B.LastPriceVnd, B.LastPriceUsd, B.Name,B.WaterPricePercent,B.ElecPricePercent ";
                sql += " FROM   PaymentElecWater AS A INNER JOIN ";
                sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId INNER JOIN";
                sql += "        BD_Room ON A.RoomId = BD_Room.id";
                sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfWaterId = 0  and A.YearMonth = '" + YearMonth + "' and B.DetailType = 1";
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
                sql += " SELECT BD_Room.Name as RoomName, A.DateFrom, A.DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVnd, B.PriceUsd, B.SumVnd, B.SumUsd, ";
                sql += "        B.VatVnd, B.VatUsd, B.LastPriceVnd, B.LastPriceUsd, B.Name,B.WaterPricePercent,B.ElecPricePercent ";
                sql += " FROM   PaymentElecWater AS A INNER JOIN ";
                sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId INNER JOIN";
                sql += "        BD_Room ON A.RoomId = BD_Room.id";
                sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfElecId = 0 and A.YearMonth = '" + YearMonth + "' and B.DetailType = 2";
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
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and YearMonth in (" + YearMonth + ")";

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

                //sql = "Select  *";
                //sql += " From    PaymentBillDetail";
                //sql += " Where   BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and YearMonth in (" + YearMonth + ")";

                sql = "  Select  SUM(MoneyUSD) AS MoneyUSD, SUM(MoneyVND) AS MoneyVND, SUM(PaidUSD) AS PaidUSD, SUM(PaidVND) AS PaidVND, PaymentType";
                sql += " From    PaymentBillDetail";
                sql += " Where   BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth in (" + YearMonth + ")";
                sql += " GROUP BY PaymentType";

                DataTable dt = DbHelper.GetDataTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string PaymentType = Func.ParseString(dt.Rows[i]["PaymentType"]);
                    string MoneyUsd = Func.ParseString(dt.Rows[i]["MoneyUsd"]);
                    string MoneyVnd = Func.ParseString(dt.Rows[i]["MoneyVnd"]);
                    string PaidUsd = Func.ParseString(dt.Rows[i]["PaidUsd"]);
                    string PaidVnd = Func.ParseString(dt.Rows[i]["PaidVnd"]);
                    string ExchangeType = Func.ParseString(dt.Rows[i]["ExchangeType"]);
                    //string UsdExchange = Func.ParseString(dt.Rows[i]["UsdExchange"]);

                    decimal tmpUsd = Convert.ToDecimal(MoneyUsd) - Convert.ToDecimal(PaidUsd);
                    decimal tmpVnd = Convert.ToDecimal(MoneyVnd) - Convert.ToDecimal(PaidVnd);

                    switch (PaymentType)
                    {
                        case "1":
                            //Rent
                            lblRentUsd.Text = Func.FormatNumber_New(MoneyUsd); // Where Fieldname is the name of fields from your database that you want to get
                            lblRentVnd.Text = Func.FormatNumber_New(MoneyVnd); // Where Fieldname is the name of fields from your database that you want to get

                            lblRentPaidUsd.Text = Func.FormatNumber_New(PaidUsd); // Where Fieldname is the name of fields from your database that you want to get
                            lblRentPaidVnd.Text = Func.FormatNumber_New(PaidVnd); // Where Fieldname is the name of fields from your database that you want to get

                            lblRentPaidUsdRemain.Text = Func.FormatNumber_New(tmpUsd);
                            lblRentPaidVndRemain.Text = Func.FormatNumber_New(tmpVnd);

                            if (tmpUsd > 0)
                            {
                                lblRentPaidUsd.Text = Func.FormatNumber_New(tmpUsd);
                            }
                            if (tmpVnd > 0)
                            {
                                lblRentPaidVnd.Text = Func.FormatNumber_New(tmpVnd);
                            }
                            break;
                        case "2":
                            //Manager
                            lblManagerUsd.Text = Func.FormatNumber_New(MoneyUsd); // Where Fieldname is the name of fields from your database that you want to get
                            lblManagerVnd.Text = Func.FormatNumber_New(MoneyVnd); // Where Fieldname is the name of fields from your database that you want to get

                            lblManagerPaidUsd.Text = Func.FormatNumber_New(PaidUsd); // Where Fieldname is the name of fields from your database that you want to get
                            lblManagerPaidVnd.Text = Func.FormatNumber_New(PaidVnd); // Where Fieldname is the name of fields from your database that you want to get

                            lblManagerPaidUsdRemain.Text = Func.FormatNumber_New(tmpUsd);
                            lblManagerPaidVndRemain.Text = Func.FormatNumber_New(tmpVnd);

                            if (tmpUsd > 0)
                            {
                                lblManagerPaidUsd.Text = Func.FormatNumber_New(tmpUsd);
                            }
                            if (tmpVnd > 0)
                            {
                                lblManagerPaidVnd.Text = Func.FormatNumber_New(tmpVnd);
                            }

                            break;
                        case "3":
                            //Parking
                            lblParkingUsd.Text = Func.FormatNumber_New(MoneyUsd); // Where Fieldname is the name of fields from your database that you want to get
                            lblParkingVnd.Text = Func.FormatNumber_New(MoneyVnd); // Where Fieldname is the name of fields from your database that you want to get

                            lblParkingPaidUsd.Text = Func.FormatNumber_New(PaidUsd); // Where Fieldname is the name of fields from your database that you want to get
                            lblParkingPaidVnd.Text = Func.FormatNumber_New(PaidVnd); // Where Fieldname is the name of fields from your database that you want to get

                            lblParkingPaidUsd.Text = Func.FormatNumber_New(Func.ParseFloat(MoneyUsd) - Func.ParseFloat(PaidUsd));
                            lblParkingPaidVnd.Text = Func.FormatNumber_New(Func.ParseDouble(MoneyVnd) - Func.ParseFloat(PaidVnd));

                            lblParkingPaidUsdRemain.Text = Func.FormatNumber_New(tmpUsd);
                            lblParkingPaidVndRemain.Text = Func.FormatNumber_New(tmpVnd);

                            if (tmpUsd > 0)
                            {
                                lblParkingPaidUsd.Text = Func.FormatNumber_New(tmpUsd);
                            }
                            if (tmpVnd > 0)
                            {
                                lblParkingPaidVnd.Text = Func.FormatNumber_New(tmpVnd);
                            }
                            break;
                        case "4":
                            lblExtraTimeUsd.Text = Func.FormatNumber_New(MoneyUsd); // Where Fieldname is the name of fields from your database that you want to get
                            lblExtraTimeVnd.Text = Func.FormatNumber_New(MoneyVnd); // Where Fieldname is the name of fields from your database that you want to get

                            lblExtraTimePaidUsd.Text = Func.FormatNumber_New(PaidUsd); // Where Fieldname is the name of fields from your database that you want to get
                            lblExtraTimePaidVnd.Text = Func.FormatNumber_New(PaidVnd); // Where Fieldname is the name of fields from your database that you want to get

                            lblExtraTimePaidUsd.Text = Func.FormatNumber_New(Func.ParseFloat(MoneyUsd) - Func.ParseFloat(PaidUsd));
                            lblExtraTimePaidVnd.Text = Func.FormatNumber_New(Func.ParseDouble(MoneyVnd) - Func.ParseFloat(PaidVnd));

                            lblExtraTimePaidUsdRemain.Text = Func.FormatNumber_New(tmpUsd);
                            lblExtraTimePaidVndRemain.Text = Func.FormatNumber_New(tmpVnd);

                            if (tmpUsd > 0)
                            {
                                lblExtraTimePaidUsd.Text = Func.FormatNumber_New(tmpUsd);
                            }
                            if (tmpVnd > 0)
                            {
                                lblExtraTimePaidVnd.Text = Func.FormatNumber_New(tmpVnd);
                            }
                            break;
                        case "5":
                            lblElecVnd.Text = Func.FormatNumber_New(MoneyVnd); // Where Fieldname is the name of fields from your database that you want to get
                            lblElecPaidVnd.Text = Func.FormatNumber_New(PaidVnd); // Where Fieldname is the name of fields from your database that you want to get
                            lblElecPaidVnd.Text = Func.FormatNumber_New(Func.ParseDouble(MoneyVnd) - Func.ParseFloat(PaidVnd));
                            lblElecPaidVndRemain.Text = Func.FormatNumber_New(tmpVnd);
                            if (tmpVnd > 0)
                            {
                                lblElecPaidVnd.Text = Func.FormatNumber_New(tmpVnd);
                            }
                            break;
                        case "6":
                            lblWaterVnd.Text = Func.FormatNumber_New(MoneyVnd); // Where Fieldname is the name of fields from your database that you want to get
                            lblWaterPaidVnd.Text = Func.FormatNumber_New(PaidVnd); // Where Fieldname is the name of fields from your database that you want to get

                            //lblWaterPaidUsd.Text = Func.FormatNumber_New(Func.ParseFloat(MoneyUsd) - Func.ParseFloat(PaidUsd));
                            lblWaterPaidVnd.Text = Func.FormatNumber_New(Func.ParseFloat(MoneyVnd) - Func.ParseFloat(PaidVnd));

                            //lblWaterPaidUsd.Text = Func.FormatNumber_New(tmpUsd);
                            lblWaterPaidVndRemain.Text = Func.FormatNumber_New(tmpVnd);

                            //if (tmpUsd > 0)
                            //{
                            //    lblWaterPaidUsd.Text = Func.FormatNumber_New(tmpUsd);
                            //}
                            if (tmpVnd > 0)
                            {
                                lblWaterPaidVnd.Text = Func.FormatNumber_New(tmpVnd);
                            }
                            break;
                        case "7":
                            lblServiceUsd.Text = Func.FormatNumber_New(MoneyUsd); // Where Fieldname is the name of fields from your database that you want to get
                            lblServiceVnd.Text = Func.FormatNumber_New(MoneyVnd); // Where Fieldname is the name of fields from your database that you want to get

                            lblServicePaidUsd.Text = Func.FormatNumber_New(PaidUsd); // Where Fieldname is the name of fields from your database that you want to get
                            lblServicePaidVnd.Text = Func.FormatNumber_New(PaidVnd); // Where Fieldname is the name of fields from your database that you want to get

                            lblServicePaidUsd.Text = Func.ParseString(Func.ParseFloat(MoneyUsd) - Func.ParseFloat(PaidUsd));
                            lblServicePaidVnd.Text = Func.FormatNumber_New(Func.ParseFloat(MoneyVnd) - Func.ParseFloat(PaidVnd));

                            lblServicePaidUsdRemain.Text = Func.FormatNumber_New(tmpUsd);
                            lblServicePaidVndRemain.Text = Func.FormatNumber_New(tmpVnd);

                            if (tmpUsd > 0)
                            {
                                lblServicePaidUsd.Text = Func.FormatNumber_New(tmpUsd);
                            }
                            if (tmpVnd > 0)
                            {
                                lblServicePaidVnd.Text = Func.FormatNumber_New(tmpVnd);
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
                    hidId.Value = Func.ParseString(Request["id"]);
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

                //CustomerData data = new CustomerData();
                //ITransaction tran = factory.GetLoadObject(data, hidId.Value);
                //Execute(tran);
                //if (!HasError)
                //{
                //    //Get Data
                //    data = (CustomerData)tran.Result;
                //    lblCustomerId.Text = data.CustomerId;
                //    lblName.Text = data.Name;
                //}
                hidId.Value = Func.ParseString(Request["id"]);
                ShowData();

            }
        }

        /// </summary> Chọn trang
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void pager_PageIndexChanged(object source, PagerPageChangedEventArgs args)
        {
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
                    string ManagerPriceVnd = Func.ParseString(row["MonthManagerPriceVnd"]);
                    string ManagerPriceUsd = Func.ParseString(row["MonthManagerPriceUsd"]);
                    string VatVnd = Func.ParseString(row["VatManagerPriceVnd"]);
                    string VatUsd = Func.ParseString(row["VatManagerPriceUsd"]);

                    string OtherFee01 = Func.ParseString(row["OtherFee01"]);
                    string OtherFee02 = Func.ParseString(row["OtherFee02"]);
                    string SumVnd = Func.ParseString(row["MonthManagerSumVnd"]);
                    string SumUsd = Func.ParseString(row["MonthManagerSumUsd"]);

                    string LastPriceVnd = Func.ParseString(row["LastManagerSumVnd"]);
                    string LastPriceUsd = Func.ParseString(row["LastManagerSumUsd"]);

                    string YearMonth = Func.ParseString(row["YearMonth"]);
                    string Area = Func.ParseString(row["Area"]);
                    string Name = Func.ParseString(row["Name"]);
                    string Regional = Func.ParseString(row["Regional"]);
                    string Floor = Func.ParseString(row["Floor"]);


                    Func.SetGridTextValue(item, "ltrName", Name);

                    Func.SetGridTextValue(item, "ltrArea", Area);

                    Func.SetGridTextValue(item, "ltrPriceVnd", Func.FormatNumber_New(ManagerPriceVnd));
                    Func.SetGridTextValue(item, "ltrPriceUsd", Func.FormatNumber_New(ManagerPriceUsd));

                    Func.SetGridTextValue(item, "ltrSumVnd", Func.FormatNumber_New(SumVnd));
                    Func.SetGridTextValue(item, "ltrSumUsd", Func.FormatNumber_New(SumUsd));

                    Func.SetGridTextValue(item, "ltrVatVnd", Func.FormatNumber_New(VatVnd));
                    Func.SetGridTextValue(item, "ltrVatUsd", Func.FormatNumber_New(VatUsd));

                    Func.SetGridTextValue(item, "ltrLastPriceVnd", Func.FormatNumber_New(LastPriceVnd));
                    Func.SetGridTextValue(item, "ltrLastPriceUsd", Func.FormatNumber_New(LastPriceUsd));

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


                    string RentPriceVnd = Func.ParseString(row["MonthRentPriceVnd"]);
                    string RentPriceUsd = Func.ParseString(row["MonthRentPriceUsd"]);
                    string VatVnd = Func.ParseString(row["VatRentPriceVnd"]);
                    string VatUsd = Func.ParseString(row["VatRentPriceUsd"]);


                    string SumVnd = Func.ParseString(row["MonthRentSumVnd"]);
                    string SumUsd = Func.ParseString(row["MonthRentSumUsd"]);

                    string LastPriceVnd = Func.ParseString(row["LastRentSumVnd"]);
                    string LastPriceUsd = Func.ParseString(row["LastRentSumUsd"]);


                    Func.SetGridTextValue(item, "ltrName", Name);

                    Func.SetGridTextValue(item, "ltrArea", Area);

                    Func.SetGridTextValue(item, "ltrPriceVnd", Func.FormatNumber_New(RentPriceVnd));
                    Func.SetGridTextValue(item, "ltrPriceUsd", Func.FormatNumber_New(RentPriceUsd));

                    Func.SetGridTextValue(item, "ltrSumVnd", Func.FormatNumber_New(SumVnd));
                    Func.SetGridTextValue(item, "ltrSumUsd", Func.FormatNumber_New(SumUsd));

                    Func.SetGridTextValue(item, "ltrVatVnd", Func.FormatNumber_New(VatVnd));
                    Func.SetGridTextValue(item, "ltrVatUsd", Func.FormatNumber_New(VatUsd));

                    Func.SetGridTextValue(item, "ltrLastPriceVnd", Func.FormatNumber_New(LastPriceVnd));
                    Func.SetGridTextValue(item, "ltrLastPriceUsd", Func.FormatNumber_New(LastPriceUsd));

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

                    string PriceVnd = Func.ParseString(row["PriceVnd"]);
                    string PriceUsd = Func.ParseString(row["PriceUsd"]);
                    string VatVnd = Func.ParseString(row["VatVnd"]);
                    string VatUsd = Func.ParseString(row["VatUsd"]);

                    string SumVnd = Func.ParseString(row["SumVnd"]);
                    string SumUsd = Func.ParseString(row["SumUsd"]);
                    string LastPriceVnd = Func.ParseString(row["LastPriceVnd"]);
                    string LastPriceUsd = Func.ParseString(row["LastPriceUsd"]);

                    Func.SetGridTextValue(item, "ltrName", TariffsParkingName);

                    Func.SetGridTextValue(item, "ltrNum", Func.FormatNumber_New(Num));

                    Func.SetGridTextValue(item, "ltrPriceVnd", Func.FormatNumber_New(PriceVnd));
                    Func.SetGridTextValue(item, "ltrPriceUsd", Func.FormatNumber_New(PriceUsd));

                    Func.SetGridTextValue(item, "ltrSumVnd", Func.FormatNumber_New(SumVnd));
                    Func.SetGridTextValue(item, "ltrSumUsd", Func.FormatNumber_New(SumUsd));

                    Func.SetGridTextValue(item, "ltrVatVnd", Func.FormatNumber_New(VatVnd));
                    Func.SetGridTextValue(item, "ltrVatUsd", Func.FormatNumber_New(VatUsd));

                    Func.SetGridTextValue(item, "ltrLastPriceVnd", Func.FormatNumber_New(LastPriceVnd));
                    Func.SetGridTextValue(item, "ltrLastPriceUsd", Func.FormatNumber_New(LastPriceUsd));

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

                    string PriceVnd = Func.ParseString(row["PriceVnd"]);
                    string PriceUsd = Func.ParseString(row["PriceUsd"]);
                    string VatUsd = Func.ParseString(row["VatUsd"]);
                    string VatVnd = Func.ParseString(row["VatVnd"]);

                    string SumVnd = Func.ParseString(row["SumVnd"]);
                    string SumUsd = Func.ParseString(row["SumUsd"]);
                    string LastPriceVnd = Func.ParseString(row["LastPriceVnd"]);
                    string LastPriceUsd = Func.ParseString(row["LastPriceUsd"]);

                    Func.SetGridTextValue(item, "ltrWorkingDate", Func.FormatDMY(WorkingDate));

                    Func.SetGridTextValue(item, "ltrExtraHour", Func.FormatNumber_New(ExtraHour));

                    Func.SetGridTextValue(item, "ltrPriceVnd", Func.FormatNumber_New(PriceVnd));
                    Func.SetGridTextValue(item, "ltrPriceUsd", Func.FormatNumber_New(PriceUsd));

                    Func.SetGridTextValue(item, "ltrSumVnd", Func.FormatNumber_New(SumVnd));
                    Func.SetGridTextValue(item, "ltrSumUsd", Func.FormatNumber_New(SumUsd));

                    Func.SetGridTextValue(item, "ltrVatVnd", Func.FormatNumber_New(VatVnd));
                    Func.SetGridTextValue(item, "ltrVatUsd", Func.FormatNumber_New(VatUsd));

                    Func.SetGridTextValue(item, "ltrLastPriceVnd", Func.FormatNumber_New(LastPriceVnd));
                    Func.SetGridTextValue(item, "ltrLastPriceUsd", Func.FormatNumber_New(LastPriceUsd));

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

                    string PriceVnd = Func.ParseString(row["PriceVnd"]);
                    string PriceUsd = Func.ParseString(row["PriceUsd"]);
                    string VatUsd = Func.ParseString(row["VatUsd"]);
                    string VatVnd = Func.ParseString(row["VatVnd"]);

                    string Mount = Func.ParseString(row["Mount"]);
                    //string OtherFee02 = Func.ParseString(row["OtherFee02"]);
                    string SumVnd = Func.ParseString(row["SumVnd"]);
                    string SumUsd = Func.ParseString(row["SumUsd"]);
                    string LastPriceVnd = Func.ParseString(row["LastPriceVnd"]);
                    string LastPriceUsd = Func.ParseString(row["LastPriceUsd"]);

                    Func.SetGridTextValue(item, "ltrServiceDate", ServiceDate);
                    Func.SetGridTextValue(item, "ltrMount", Mount);

                    Func.SetGridTextValue(item, "ltrService", Service);

                    Func.SetGridTextValue(item, "ltrPriceVnd", Func.FormatNumber_New(PriceVnd));
                    Func.SetGridTextValue(item, "ltrPriceUsd", Func.FormatNumber_New(PriceUsd));

                    Func.SetGridTextValue(item, "ltrSumVnd", Func.FormatNumber_New(SumVnd));
                    Func.SetGridTextValue(item, "ltrSumUsd", Func.FormatNumber_New(SumUsd));

                    Func.SetGridTextValue(item, "ltrVatVnd", Func.FormatNumber_New(VatVnd));
                    Func.SetGridTextValue(item, "ltrVatUsd", Func.FormatNumber_New(VatUsd));

                    Func.SetGridTextValue(item, "ltrLastPriceVnd", Func.FormatNumber_New(LastPriceVnd));
                    Func.SetGridTextValue(item, "ltrLastPriceUsd", Func.FormatNumber_New(LastPriceUsd));

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


                    string PriceVnd = Func.ParseString(row["PriceVnd"]);
                    string PriceUsd = Func.ParseString(row["PriceUsd"]);
                    string VatUsd = Func.ParseString(row["VatUsd"]);
                    string VatVnd = Func.ParseString(row["VatVnd"]);

                    string SumVnd = Func.ParseString(row["SumVnd"]);
                    string SumUsd = Func.ParseString(row["SumUsd"]);
                    string LastPriceVnd = Func.ParseString(row["LastPriceVnd"]);
                    string LastPriceUsd = Func.ParseString(row["LastPriceUsd"]);
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


                    Func.SetGridTextValue(item, "ltrPriceVnd", Func.FormatNumber_New(PriceVnd));
                    //Func.SetGridTextValue(item, "ltrPriceUsd", Func.FormatNumber_New(PriceUsd));

                    Func.SetGridTextValue(item, "ltrSumVnd", Func.FormatNumber_New(SumVnd));
                    //Func.SetGridTextValue(item, "ltrSumUsd", Func.FormatNumber_New(SumUsd));

                    Func.SetGridTextValue(item, "ltrVatVnd", Func.FormatNumber_New(VatVnd));
                    //Func.SetGridTextValue(item, "ltrVatUsd", VatUsd);

                    Func.SetGridTextValue(item, "ltrLastPriceVnd", Func.FormatNumber_New(LastPriceVnd));
                    //Func.SetGridTextValue(item, "ltrLastPriceUsd", Func.FormatNumber_New(LastPriceUsd));

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
                    Func.SetGridTextValue(item, "ltrSumUsd", Func.ParseString(row["SumUsd"]));
                    Func.SetGridTextValue(item, "ltrSumVnd", Func.ParseString(row["SumVnd"]));

                    Func.SetGridTextValue(item, "ltrRemainRentUsd", Func.ParseString(row["RemainRentUsd"]));
                    Func.SetGridTextValue(item, "ltrRemainRentVnd", Func.ParseString(row["RemainRentVnd"]));
                    Func.SetGridTextValue(item, "ltrRemainManagerUsd", Func.ParseString(row["RemainManagerUsd"]));
                    Func.SetGridTextValue(item, "ltrRemainManagerVnd", Func.ParseString(row["RemainManagerVnd"]));
                    Func.SetGridTextValue(item, "ltrRemainParkingUsd", Func.ParseString(row["RemainParkingUsd"]));
                    Func.SetGridTextValue(item, "ltrRemainParkingVnd", Func.ParseString(row["RemainParkingVnd"]));
                    Func.SetGridTextValue(item, "ltrRemainExtraTimePriceUsd", Func.ParseString(row["RemainExtraTimePriceUsd"]));
                    Func.SetGridTextValue(item, "ltrRemainExtraTimePriceVnd", Func.ParseString(row["RemainExtraTimePriceVnd"]));
                    Func.SetGridTextValue(item, "ltrRemainElecUsd", Func.ParseString(row["RemainElecUsd"]));
                    Func.SetGridTextValue(item, "ltrRemainElecVnd", Func.ParseString(row["RemainElecVnd"]));
                    Func.SetGridTextValue(item, "ltrRemainWaterUsd", Func.ParseString(row["RemainWaterUsd"]));
                    Func.SetGridTextValue(item, "ltrRemainWaterVnd", Func.ParseString(row["RemainWaterVnd"]));
                    Func.SetGridTextValue(item, "ltrRemainServiceUsd", Func.ParseString(row["RemainServiceUsd"]));
                    Func.SetGridTextValue(item, "ltrRemainServiceVnd", Func.ParseString(row["RemainServiceVnd"]));
                    Func.SetGridTextValue(item, "ltrSumUsd", Func.ParseString(row["SumUsd"]));
                    Func.SetGridTextValue(item, "ltrSumVnd", Func.ParseString(row["SumVnd"]));

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


                    string PriceVnd = Func.ParseString(row["PriceVnd"]);
                    string PriceUsd = Func.ParseString(row["PriceUsd"]);
                    string VatUsd = Func.ParseString(row["VatUsd"]);
                    string VatVnd = Func.ParseString(row["VatVnd"]);

                    string SumVnd = Func.ParseString(row["SumVnd"]);
                    string SumUsd = Func.ParseString(row["SumUsd"]);
                    string LastPriceVnd = Func.ParseString(row["LastPriceVnd"]);
                    string LastPriceUsd = Func.ParseString(row["LastPriceUsd"]);
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

                    Func.SetGridTextValue(item, "ltrPriceVnd", Func.FormatNumber_New(PriceVnd));
                    //Func.SetGridTextValue(item, "ltrPriceUsd", Func.FormatNumber_New(PriceUsd));

                    Func.SetGridTextValue(item, "ltrSumVnd", Func.FormatNumber_New(SumVnd));
                    //Func.SetGridTextValue(item, "ltrSumUsd", Func.FormatNumber_New(SumUsd));

                    Func.SetGridTextValue(item, "ltrVatVnd", Func.FormatNumber_New(VatVnd));
                    //Func.SetGridTextValue(item, "ltrVatUsd", Func.FormatNumber_New(VatUsd));

                    Func.SetGridTextValue(item, "ltrLastPriceVnd", Func.FormatNumber_New(LastPriceVnd));
                    //Func.SetGridTextValue(item, "ltrLastPriceUsd", Func.FormatNumber_New(LastPriceUsd));

                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }
    }
}
