using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Collections.Generic;

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
using System.IO;
using System.Drawing;
using C1.C1Excel;

namespace Man.Report
{
    public partial class ReportReview : PageBase
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

        private string popup = "PopupBD_WorkingSheduleInfoEdit";
        private string editPageName = "BD_WorkingSheduleInfoEdit";



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
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ID = Func.ParseString(Request["id"]);
                string YearMonth = Func.ParseString(Request["yearmonth"]);
                string reportType = Func.ParseString(Request["reporttype"]);
                string DateFrom = Func.ParseString(Request["from"]);
                string DateTo = Func.ParseString(Request["to"]);

                string reportName = "";
                switch (reportType)
                {
                    case "1":
                    //1.Thông Tin Tòa Nhà</text>
                        break;
                    //2.Thông Tin Khách Hàng</text>
                    //3.Tổng Hợp Các Khoản Phí</text>
                    //4.Bảng Theo Dõi Chi Phí Điện</text>
                    //5.Bảng Theo Dõi Chi Phí Nước</text>
                    //6.Bảng Tổng Hợp Làm Việc Ngoài Giờ</text>
                    //7.Bảng Tổng Hợp Thu Phí Giữ Xe(Lược)</text>
                    //8.Bảng Tổng Hợp Thu Phí Giữ Xe(Tháng)</text>
                    //9.Danh Sách Đăng Ký Phòng Họp</text>
                    //10.Quản Lý Kho Vật Tư Tiêu Hao</text>
                    //11.Quản Lý Kho Vật Tư Nhập Kho</text>
                    //12.Quản Lý Kho Vật Tư Xuất Kho</text>
                    //13.Tình Trạng Trang Thiết Bị</text>
                    //14.Tình Trạng Vật Tư</text>
                    case "aaa":
                        break;
                    default:
                        break;
                }

                SqlDatabase db = new SqlDatabase();
                if (!Func.IsValid(ListSortExpression))
                {
                    ListSortExpression = "Name";
                    ListSortDirection = SortDirection.Descending;
                }
                try
                {
                    //Rent And Manager Price
                    string sqlPaymentRoom = string.Empty;
                    string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                    ////Xuất ra toàn bộ nội dung theo Trang
                    sqlPaymentRoom += " Select *";
                    sqlPaymentRoom += " FROM PaymentRoom";
                    sqlPaymentRoom += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'";

                    ////Parking
                    string sqlParking = string.Empty;
                    sort = "TariffsParkingName" + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                    ////Xuất ra toàn bộ nội dung theo Trang
                    sqlParking += " SELECT COUNT(*) AS Num, CustomerId, YearMonth, TariffsParkingName, PriceVND, PriceUSD, SUM(VatVND) AS VatVND,SUM(VatUSD) AS VatUSD, SUM(SumVND) AS SumVND, SUM(SumUSD) AS SumUSD, SUM(LastPriceVND) AS LastPriceVND";
                    sqlParking += "        , SUM(LastPriceUSD) AS LastPriceUSD";
                    sqlParking += " FROM         dbo.PaymentParking";
                    sqlParking += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'";
                    sqlParking += " GROUP BY CustomerId,YearMonth, TariffsParkingName, PriceVND, PriceUSD, Vat";

                    ////Extra Time
                    string sqlExtraTime = string.Empty;
                    sort = "WorkingDate" + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                    ////Xuất ra toàn bộ nội dung theo Trang
                    sqlExtraTime += " SELECT id,YearMonth,BuildingId,CustomerId,RoomId,RoomExtraTimeId,convert(datetime,WorkingDate) WorkingDate";
                    sqlExtraTime += "       ,ExtraHour,VAT,OtherFee01,OtherFee02,PriceUSD,PriceVND,VatUSD,VatVND ";
                    sqlExtraTime += "       ,SumUSD,SumVND,LastPriceUSD,LastPriceVND ";
                    sqlExtraTime += " FROM   PaymentExtraTime";
                    sqlExtraTime += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'";

                    ////Elec
                    ListSortDirection = SortDirection.Ascending;
                    string sqlElec = string.Empty;
                    sort = "B.FromIndex" + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                    //Xuất ra toàn bộ nội dung theo Trang
                    sqlElec += " SELECT convert(datetime, A.DateFrom) AS DateFrom, convert(datetime, A.DateTo) AS DateTo, A.Vat, B.* ";
                    sqlElec += " FROM   PaymentElecWater AS A INNER JOIN ";
                    sqlElec += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId";
                    sqlElec += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + "BD002KH001" + "' and TarrifsOfWaterId = 0  and A.YearMonth = '" + "201202" + "'";
                    sqlElec += " Order by " + sort;

                    //Water
                    string sqlWater = string.Empty;

                    //Xuất ra toàn bộ nội dung theo Trang
                    sqlWater += " SELECT convert(datetime, A.DateFrom) AS DateFrom, convert(datetime, A.DateTo) AS DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.Mount, B.PriceVND, B.PriceUSD, B.SumVND, B.SumUSD, ";
                    sqlWater += "        B.VatVND, B.VatUSD, B.LastPriceVND, B.LastPriceUSD, B.Name ";
                    sqlWater += " FROM   PaymentElecWater AS A INNER JOIN ";
                    sqlWater += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId";
                    sqlWater += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfElecId = 0 and A.YearMonth = '" + YearMonth + "'";
                    sqlWater += " Order by " + sort;

                    //Service
                    string sqlService = string.Empty;
                    sort = "ServiceDate" + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                    //Xuất ra toàn bộ nội dung theo Trang
                    sqlService += " SELECT id,YearMonth,BuildingId,CustomerId,[Service],ServiceId,convert(datetime, ServiceDate) AS ServiceDate ";
                    sqlService += " ,Mount,VAT,OtherFee01,OtherFee02,PriceUSD,PriceVND,VatUSD ";
                    sqlService += " ,VatVND,SumUSD,SumVND,LastPriceUSD,LastPriceVND ";
                    sqlService += " FROM   PaymentService";
                    sqlService += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'";

                    //    //Dept
                    //    sql = string.Empty;
                    //    sort = "YearMonth" + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                    //    //Xuất ra toàn bộ nội dung theo Trang
                    //    sql += " SELECT *,(RemainRentUSD+RemainManagerUSD+RemainElecUSD+RemainWaterUSD+RemainServiceUSD+RemainParkingUSD+RemainExtraTimePriceUSD) as SumUSD,(RemainRentVND+RemainManagerVND+RemainElecVND+RemainWaterVND+RemainServiceVND+RemainParkingVND+RemainExtraTimePriceVND) AS SumVND ";
                    //    sql += " FROM   v_PaymentYearMonthDept";
                    //    sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' And";
                    //    sql += " (RemainRentUSD+RemainManagerUSD+RemainElecUSD+RemainWaterUSD+RemainServiceUSD+RemainParkingUSD+RemainExtraTimePriceUSD)>0 and YearMonth <> '" + YearMonth + "'";


                    //    string yearMonthID = DbHelper.GetScalar("Select Id from PaymentYearMonth Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'");
                    //    if (!String.IsNullOrEmpty(yearMonthID))
                    //    {
                    //        PaymentYearMonthData data = new PaymentYearMonthData();
                    //        ITransaction tran = factory.GetLoadObject(data, yearMonthID);
                    //        Execute(tran);
                    //        if (!HasError)
                    //        {
                    //            //Get Data
                    //            data = (PaymentYearMonthData)tran.Result;
                    //            //Rent
                    //            //lblRentUSD.Text = data.RentUSD; // Where Fieldname is the name of fields from your database that you want to get
                    //            //lblRentVND.Text = Func.FormatNumber(Func.ParseDouble(data.RentVND)); // Where Fieldname is the name of fields from your database that you want to get
                    //            ////Manager
                    //            //lblMangagerUSD.Text = data.ManagerUSD; // Where Fieldname is the name of fields from your database that you want to get
                    //            //lblMangagerVND.Text = Func.FormatNumber(Func.ParseDouble(data.ManagerVND)); // Where Fieldname is the name of fields from your database that you want to get

                    //            ////Parking
                    //            //lblParkingUSD.Text = data.ParkingUSD; // Where Fieldname is the name of fields from your database that you want to get
                    //            //lblParkingVND.Text = Func.FormatNumber(Func.ParseDouble(data.ParkingVND)); // Where Fieldname is the name of fields from your database that you want to get
                    //            ////Extra Time
                    //            //lblExtraTimeUSD.Text = data.ExtraTimePriceUSD; // Where Fieldname is the name of fields from your database that you want to get
                    //            //lblExtraTimeVND.Text = Func.FormatNumber(Func.ParseDouble(data.ExtraTimePriceVND)); // Where Fieldname is the name of fields from your database that you want to get
                    //            ////Elec
                    //            //lblElecUSD.Text = data.ElectUSD; // Where Fieldname is the name of fields from your database that you want to get
                    //            //lblElecVND.Text = Func.FormatNumber(Func.ParseDouble(data.ElecVND)); // Where Fieldname is the name of fields from your database that you want to get
                    //            ////Water
                    //            //lblWaterUSD.Text = data.WaterUSD; // Where Fieldname is the name of fields from your database that you want to get
                    //            //lblWaterVND.Text = Func.FormatNumber(Func.ParseDouble(data.WaterVND)); // Where Fieldname is the name of fields from your database that you want to get
                    //            ////Service
                    //            //lblServiceUSD.Text = data.ServiceUSD; // Where Fieldname is the name of fields from your database that you want to get
                    //            //lblServiceVND.Text = Func.FormatNumber(Func.ParseDouble(data.ServiceVND)); // Where Fieldname is the name of fields from your database that you want to get
                    //            ///////////
                    //            ////Rent
                    //            //lblRentPaidUSD.Text = data.PaidRentUSD; // Where Fieldname is the name of fields from your database that you want to get
                    //            //lblRentPaidVND.Text = Func.FormatNumber(Func.ParseDouble(data.PaidRentVND)); // Where Fieldname is the name of fields from your database that you want to get
                    //            ////Manager
                    //            //lblMangagerPaidUSD.Text = data.PaidManagerUSD; // Where Fieldname is the name of fields from your database that you want to get
                    //            //lblMangagerPaidVND.Text = Func.FormatNumber(Func.ParseDouble(data.PaidManagerVND)); // Where Fieldname is the name of fields from your database that you want to get

                    //            ////Parking
                    //            //lblParkingPaidUSD.Text = data.PaidParkingUSD; // Where Fieldname is the name of fields from your database that you want to get
                    //            //lblParkingPaidVND.Text = Func.FormatNumber(data.PaidParkingVND); // Where Fieldname is the name of fields from your database that you want to get
                    //            ////Extra Time
                    //            //lblExtraTimePaidUSD.Text = data.PaidExtraTimePriceUSD; // Where Fieldname is the name of fields from your database that you want to get
                    //            //lblExtraTimePaidVND.Text = Func.FormatNumber(Func.ParseDouble(data.PaidExtraTimePriceVND)); // Where Fieldname is the name of fields from your database that you want to get
                    //            ////Elec
                    //            //lblElecPaidUSD.Text = data.PaidElectUSD; // Where Fieldname is the name of fields from your database that you want to get
                    //            //lblElecPaidVND.Text = Func.FormatNumber(Func.ParseDouble(data.PaidElecVND)); // Where Fieldname is the name of fields from your database that you want to get
                    //            ////Water
                    //            //lblWaterPaidUSD.Text = data.PaidWaterUSD; // Where Fieldname is the name of fields from your database that you want to get
                    //            //lblWaterPaidVND.Text = Func.FormatNumber(Func.ParseDouble(data.PaidWaterVND));// Where Fieldname is the name of fields from your database that you want to get
                    //            ////Service
                    //            //lblServicePaidUSD.Text = data.PaidServiceUSD; // Where Fieldname is the name of fields from your database that you want to get
                    //            //lblServicePaidVND.Text = Func.FormatNumber(Func.ParseDouble(data.PaidServiceVND)); // Where Fieldname is the name of fields from your database that you want to get


                    //            //txtRentPaidUSD.Text = Func.ParseString(Func.ParseFloat(data.RentUSD) - Func.ParseFloat(data.PaidRentUSD));
                    //            //txtRentPaidVND.Text = Func.FormatNumber(Func.ParseDouble(data.RentVND) - Func.ParseDouble(data.PaidRentVND));
                    //            ////Manager	=		//Manager	)-			//Manager
                    //            //txtManagerPaidUSD.Text = Func.ParseString(Func.ParseFloat(data.ManagerUSD) - Func.ParseFloat(data.PaidManagerUSD));
                    //            //txtManagerPaidVND.Text = Func.FormatNumber(Func.ParseDouble(data.ManagerVND) - Func.ParseDouble(data.PaidManagerVND));
                    //            ////Parking	=		//Parking	)-			//Parking
                    //            //txtParkingPaidUSD.Text = Func.ParseString(Func.ParseFloat(data.ParkingUSD) - Func.ParseFloat(data.PaidParkingUSD));
                    //            //txtParkingPaidVND.Text = Func.FormatNumber(Func.ParseDouble(data.ParkingVND) - Func.ParseDouble(data.PaidParkingVND));
                    //            ////ExtraTime	=		//ExtraTime	)-			//ExtraTime
                    //            //txtExtraTimePaidUSD.Text = Func.ParseString(Func.ParseFloat(data.ExtraTimePriceUSD) - Func.ParseFloat(data.PaidExtraTimePriceUSD));
                    //            //txtExtraTimePaidVND.Text = Func.FormatNumber(Func.ParseDouble(data.ExtraTimePriceVND) - Func.ParseDouble(data.PaidExtraTimePriceVND));
                    //            ////Elec	=		//Elec	)-			//Elec
                    //            //txtElecPaidUSD.Text = Func.ParseString(Func.ParseFloat(data.ElectUSD) - Func.ParseFloat(data.PaidElectUSD));
                    //            //txtElecPaidVND.Text = Func.FormatNumber(Func.ParseDouble(data.ElecVND) - Func.ParseDouble(data.PaidElecVND));
                    //            ////Water	=		//Water	)-			//Water
                    //            //txtWaterPaidUSD.Text = Func.ParseString(Func.ParseFloat(data.WaterUSD) - Func.ParseFloat(data.PaidWaterUSD));
                    //            //txtWaterPaidVND.Text = Func.FormatNumber(Func.ParseDouble(data.WaterVND) - Func.ParseDouble(data.PaidWaterVND));
                    //            ////Service	=		//Service	)-			//Service
                    //            //txtServicePaidUSD.Text = Func.ParseString(Func.ParseFloat(data.ServiceUSD) - Func.ParseFloat(data.PaidServiceUSD));
                    //            //txtServicePaidVND.Text = Func.FormatNumber(Func.ParseDouble(data.ServiceVND) - Func.ParseDouble(data.PaidServiceVND));
                    //        }
                    //    }



                    CrystalReportSource1.Report.FileName = "../Report/Bill.rpt";

                    DataTable Customer = DbHelper.GetDataTable("Select * from Customer Where CustomerId = '" + hidId.Value + "'");

                    DataTable RoomRent = DbHelper.GetDataTable(sqlPaymentRoom);
                    DataTable RoomManager = DbHelper.GetDataTable(sqlPaymentRoom);
                    DataTable Parking = DbHelper.GetDataTable(sqlParking);
                    DataTable ExtraTime = DbHelper.GetDataTable(sqlExtraTime);
                    DataTable Elec = DbHelper.GetDataTable(sqlElec);
                    DataTable Water = DbHelper.GetDataTable(sqlWater);
                    DataTable Service = DbHelper.GetDataTable(sqlService);

                    CrystalReportViewer1.Visible = true;
                    CrystalReportSource1.ReportDocument.SetDataSource(Customer);
                    //CrystalReportSource1.ReportDocument.Subreports[0].SetDataSource(RoomRent);
                    //CrystalReportSource1.ReportDocument.Subreports[0].SetParameterValue(0,"1");

                    //CrystalReportSource1.ReportDocument.Subreports[1].SetDataSource(RoomManager);
                    ////CrystalReportSource1.ReportDocument.Subreports[1].SetParameterValue(0, "2");
                    CrystalReportSource1.ReportDocument.SetParameterValue("RentTitle", "1. Tiền Thuê");
                    CrystalReportSource1.ReportDocument.SetParameterValue("ManagerTitle", "2. Tiền Quản Lý");
                    CrystalReportSource1.ReportDocument.SetParameterValue("ParkingTitle", "3. Phí Gửi Xe");
                    CrystalReportSource1.ReportDocument.SetParameterValue("ExtraTimeTitle", "4. Phí Ngoài Giờ");
                    CrystalReportSource1.ReportDocument.SetParameterValue("ElecTitle", "5. Tiền Điện");
                    CrystalReportSource1.ReportDocument.SetParameterValue("WaterTitle", "6. Tiền Nước");
                    CrystalReportSource1.ReportDocument.SetParameterValue("ServiceTitle", "7. Phí khác");

                    CrystalReportSource1.ReportDocument.Subreports["rptPaymentParking.rpt"].SetDataSource(Parking);
                    CrystalReportSource1.ReportDocument.Subreports["rptPaymentRoomElec.rpt"].SetDataSource(Elec);
                    CrystalReportSource1.ReportDocument.Subreports["rptPaymentRoomExtraTime.rpt"].SetDataSource(ExtraTime);
                    CrystalReportSource1.ReportDocument.Subreports["rptPaymentRoomManager.rpt"].SetDataSource(RoomManager);
                    CrystalReportSource1.ReportDocument.Subreports["rptPaymentRoomRent.rpt"].SetDataSource(RoomRent);
                    CrystalReportSource1.ReportDocument.Subreports["rptPaymentRoomWater.rpt"].SetDataSource(Water);
                    CrystalReportSource1.ReportDocument.Subreports["rptPaymentService.rpt"].SetDataSource(Service);

                    ////CrystalReportSource1.ReportDocument.Subreports[2].SetParameterValue(0, "1");

                    //CrystalReportSource1.ReportDocument.Subreports[1].SetDataSource(ExtraTime);
                    //CrystalReportSource1.ReportDocument.Subreports[3].SetParameterValue(0, "1");

                    //CrystalReportSource1.ReportDocument.Subreports[2].SetDataSource(Elec);
                    ////CrystalReportSource1.ReportDocument.Subreports[4].SetParameterValue(0, "1");

                    //CrystalReportSource1.ReportDocument.Subreports[5].SetDataSource(Water);
                    ////CrystalReportSource1.ReportDocument.Subreports[5].SetParameterValue(0, "1");

                    //CrystalReportSource1.ReportDocument.Subreports[6].SetDataSource(Service);
                    ////CrystalReportSource1.ReportDocument.Subreports[6].SetParameterValue(0, "1");

                    CrystalReportViewer1.ReportSourceID = CrystalReportSource1.ID;
                    CrystalReportViewer1.DataBind();
                    //CrystalReportViewer1.EnableDatabaseLogonPrompt = false;
                    //PopupWidth = 600;
                    //PopupHeight = 450;

                    //for (int i = 2000; i < 2050; i++)
                    //{
                    //    drpYear.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i), Func.ParseString(i)));
                    //}
                    //drpYear.Items.FindByValue(DateTime.Now.AddMonths(-1).ToString("yyyy")).Selected = true;

                    //for (int i = 1; i < 13; i++)
                    //{
                    //    drpMonth.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
                    //}
                    //drpMonth.Items.FindByValue(DateTime.Now.AddMonths(-1).ToString("MM")).Selected = true;

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
                catch (Exception ex)
                {
                    ApplicationLog.WriteError(ex);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //string[] dateOfWeekVN = { "T2", "T3", "T4", "T5", "T6", "T7", "CN" };
            //string[] dateOfWeekEN = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Sartuday", "Sunday" };

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            //dictionary.Add("monday", "T2");
            //dictionary.Add("tuesday", "T3");
            //dictionary.Add("wednesday", "T4");
            //dictionary.Add("thursday", "T5");
            //dictionary.Add("friday", "T6");
            //dictionary.Add("saturday", "T7");
            //dictionary.Add("sunday", "CN");


            //DataSet ds = new DataSet();
            //string sql = string.Empty;

            //sql = " SELECT *";
            //sql += " FROM BD_Staff";
            //sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and DelFlag <> 1";
            //sql += " Order By Name";

            //using (SqlDatabase db = new SqlDatabase())
            //{
            //    using (SqlCommand cm = db.CreateCommand(sql))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(cm);
            //        da.Fill(ds);
            //        db.Close();

            //        if (ds != null)
            //        {
            //            mvMessage.SetCompleteMessage("File CSV đã xuất thành công.");

            //            C1XLBook xlbBook = new C1XLBook();
            //            XLSheet xlsSheet = xlbBook.Sheets[0];
            //            xlsSheet.Name = drpMonth.SelectedValue + "_" + drpYear.SelectedValue;

            //            int i = 0;
            //            XLCellRange mrCell = new XLCellRange(0, 0, 0, 2);
            //            xlsSheet.MergedCells.Add(mrCell);

            //            XLStyle xlstStyle = new XLStyle(xlbBook);
            //            xlstStyle.AlignHorz = XLAlignHorzEnum.Center;
            //            xlstStyle.Font = new Font("", 12, FontStyle.Bold);
            //            xlstStyle.SetBorderColor(Color.Black);

            //            xlsSheet[i, 0].Value = "Tháng " + drpMonth.SelectedValue + "/" + drpYear.SelectedValue;
            //            xlsSheet[i, 0].Style = xlstStyle;

            //            xlsSheet[i + 1, 0].Value = "STT";
            //            xlsSheet[i + 1, 1].Value = "Mã Nhân Viên";
            //            xlsSheet[i + 1, 2].Value = "Họ và Tên";

            //            XLStyle xlstStyle01 = new XLStyle(xlbBook);
            //            xlstStyle01.AlignHorz = XLAlignHorzEnum.Center;
            //            xlstStyle01.Font = new Font("", 10, FontStyle.Bold);
            //            xlstStyle.SetBorderColor(Color.Black);

            //            for (int j = 1; j <= 31; j++)
            //            {
            //                xlsSheet[i, 2 + j].Value = j;
            //                DateTime date = new DateTime(Func.ParseInt(drpYear.SelectedValue), Func.ParseInt(drpMonth.SelectedValue), j);
            //                xlsSheet[i + 1, 2 + j].Value = dictionary[date.DayOfWeek.ToString().ToLower()];

            //                xlsSheet[i, 2 + j].Style = xlstStyle01;
            //                xlsSheet[i + 1, 2 + j].Style = xlstStyle01;
            //                if (j == DateTime.DaysInMonth(Func.ParseInt(drpYear.SelectedValue), Func.ParseInt(drpMonth.SelectedValue)))
            //                {
            //                    break;
            //                }
            //            }

            //            i++;
            //            DataTable dt = ds.Tables[0];
            //            foreach (DataRow rowType in dt.Rows)
            //            {
            //                int No = i;
            //                i++;
            //                string StaffId = rowType["StaffId"].ToString();
            //                string Name = rowType["Name"].ToString();

            //                xlsSheet[i, 0].Value = No;
            //                xlsSheet[i, 1].Value = StaffId;
            //                xlsSheet[i, 2].Value = Name;

            //                xlsSheet[i, 0].Style = xlstStyle01;
            //                xlsSheet[i, 1].Style = xlstStyle01;
            //                xlsSheet[i, 2].Style = xlstStyle01;

            //            }



            //            //ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('/CSV/DownloadZipFile.aspx'," + PopupWidth + "," + PopupHeight + ",'EditFlat', true);", true);

            //            xlsSheet[i++, 0].Value = "Ghi chú:";
            //            DataSet ds1 = new DataSet();
            //            sql = string.Empty;

            //            sql = " SELECT *";
            //            sql += " FROM BD_WorkingHour";
            //            sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and DelFlag <> 1";
            //            sql += " Order By Name";

            //            using (SqlCommand cm1 = db.CreateCommand(sql))
            //            {
            //                SqlDataAdapter da1 = new SqlDataAdapter(cm1);
            //                da1.Fill(ds1);
            //                db.Close();

            //                if (ds != null)
            //                {

            //                    xlsSheet[i++, 0].Value = "Ghi chú:";
            //                    DataTable dt1 = ds1.Tables[0];
            //                    foreach (DataRow rowType in dt1.Rows)
            //                    {
            //                        i++;
            //                        string Ma = rowType["WorkingHourId"].ToString();
            //                        string Name = rowType["Name"].ToString();
            //                        xlsSheet[i, 0].Value = Ma + ":";
            //                        xlsSheet[i, 1].Value = Name;
            //                    }
            //                    xlsSheet[i+1, 1].Value = "OF: nghỉ";
            //                }
            //            }
            //            string dataPath = HttpContext.Current.Server.MapPath(@"\Staff\DataTmp");
            //            string tmpFolder = dataPath;
            //            if (!Directory.Exists(tmpFolder))
            //            {
            //                Directory.CreateDirectory(tmpFolder);
            //            }
            //            string fileName = Path.Combine(tmpFolder, "KhaiBaoLichLamViec_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls");
            //            xlbBook.Save(fileName);
            //            Session["ZipFilePath"] = null;
            //            Session["ZipFilePath"] = fileName;
            //        }
            //    }
            //}
        }
    }
}
