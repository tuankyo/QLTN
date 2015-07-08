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
                //data.Name = txtName.Text.Trim();
                //data.ContactName = txtContactName.Text.Trim();
                //data.Bank = txtBank.Text.Trim();
                //data.Account = txtAccount.Text.Trim();
                //data.AccountName = txtAccountName.Text.Trim();
                //data.Office = txtOffice.Text.Trim();
                //data.OfficePhone = txtOfficePhone.Text.Trim();
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
                                //cm.Parameters.AddWithValue("@rent", rdoRentUSD.Checked == true ? "0" : "1");
                                //cm.Parameters.AddWithValue("@manager", rdoManagerUSD.Checked == true ? "0" : "1");
                                //cm.Parameters.AddWithValue("@parking", rdoParkingUSD.Checked == true ? "0" : "1");
                                //cm.Parameters.AddWithValue("@extratime", rdoExtraTimeUSD.Checked == true ? "0" : "1");
                                //cm.Parameters.AddWithValue("@elec", rdoElecUSD.Checked == true ? "0" : "1");
                                //cm.Parameters.AddWithValue("@water", rdoWaterUSD.Checked == true ? "0" : "1");
                                //cm.Parameters.AddWithValue("@service", rdoServiceUSD.Checked == true ? "0" : "1");

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
                    //data.CustomerId = txtCustomerId.Text.Trim();
                    //data.YearMonth = hidYearMonth.Value;
                    //data.Name = txtName.Text.Trim();
                    //data.ContactName = txtContactName.Text.Trim();
                    //data.Bank = txtBank.Text.Trim();
                    //data.Account = txtAccount.Text.Trim();
                    //data.AccountName = txtAccountName.Text.Trim();
                    //data.Office = txtOffice.Text.Trim();
                    //data.OfficePhone = txtOfficePhone.Text.Trim();
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
                                    //cm.Parameters.AddWithValue("@rent", rdoRentUSD.Checked == true ? "0" : "1");
                                    //cm.Parameters.AddWithValue("@manager", rdoManagerUSD.Checked == true ? "0" : "1");
                                    //cm.Parameters.AddWithValue("@parking", rdoParkingUSD.Checked == true ? "0" : "1");
                                    //cm.Parameters.AddWithValue("@extratime", rdoExtraTimeUSD.Checked == true ? "0" : "1");
                                    //cm.Parameters.AddWithValue("@elec", rdoElecUSD.Checked == true ? "0" : "1");
                                    //cm.Parameters.AddWithValue("@water", rdoWaterUSD.Checked == true ? "0" : "1");
                                    //cm.Parameters.AddWithValue("@service", rdoServiceUSD.Checked == true ? "0" : "1");

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
                sql += " GROUP BY YearMonth, TariffsParkingName, PriceVND, PriceUSD, Vat";

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
                sql += "        B.VatVND, B.VatUSD, B.LastPriceVND, B.LastPriceUSD, B.Name ";
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
                sql += "        B.VatVND, B.VatUSD, B.LastPriceVND, B.LastPriceUSD, B.Name ";
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

                //Xuất ra toàn bộ nội dung theo Trang
                //////sql += " SELECT *,(RemainRentUSD+RemainManagerUSD+RemainElecUSD+RemainWaterUSD+RemainServiceUSD+RemainParkingUSD+RemainExtraTimePriceUSD) as SumUSD,(RemainRentVND+RemainManagerVND+RemainElecVND+RemainWaterVND+RemainServiceVND+RemainParkingVND+RemainExtraTimePriceVND) AS SumVND ";
                //////sql += " FROM   v_PaymentYearMonthDept";
                //////sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' And";
                //////sql += " (RemainRentUSD+RemainManagerUSD+RemainElecUSD+RemainWaterUSD+RemainServiceUSD+RemainParkingUSD+RemainExtraTimePriceUSD)>0 and YearMonth <> '" + YearMonth + "'";

                //////cm = db.CreateCommand(sql);
                //////da = new SqlDataAdapter(cm);
                //////ds = new DataSet();
                //////da.Fill(ds);
                //////db.Close();
                //////rptDept.DataSource = ds.Tables[0].DefaultView;
                //////rptDept.DataBind();

                //DataTable dt = new DataTable();
                /////Get Sum money
                /////
                ////Rent And Manager Price 
                //sql = string.Empty;
                //sql += " Select sum(LastRentSumVND),sum(LastRentSumUSD),sum(LastManagerSumVND),sum(LastManagerSumUSD)";
                //sql += " FROM PaymentRoom";
                //sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'";
                //dt = DbHelper.GetDataTable(sql);
                //if (dt.Rows.Count > 0) // Check if the DataTable returns any data from database
                //{
                //    lblRentUSD.Text = dt.Rows[0][0].ToString(); // Where Fieldname is the name of fields from your database that you want to get
                //    lblRentVND.Text =  Func.FormatNumber(dt.Rows[0][1].ToString(); // Where Fieldname is the name of fields from your database that you want to get

                //    lblMangagerUSD.Text = dt.Rows[0][2].ToString(); // Where Fieldname is the name of fields from your database that you want to get
                //    lblMangagerVND.Text =  Func.FormatNumber(dt.Rows[0][3].ToString(); // Where Fieldname is the name of fields from your database that you want to get

                //}

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
                //    lblParkingVND.Text =  Func.FormatNumber(dt.Rows[0][1].ToString(); // Where Fieldname is the name of fields from your database that you want to get
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
                //    lblExtraTimeVND.Text =  Func.FormatNumber(dt.Rows[0][1].ToString(); // Where Fieldname is the name of fields from your database that you want to get
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
                //    lblElecVND.Text =  Func.FormatNumber(dt.Rows[0][1].ToString(); // Where Fieldname is the name of fields from your database that you want to get
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
                //    lblWaterVND.Text =  Func.FormatNumber(dt.Rows[0][1].ToString(); // Where Fieldname is the name of fields from your database that you want to get
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
                //    lblServiceVND.Text =  Func.FormatNumber(dt.Rows[0][1].ToString(); // Where Fieldname is the name of fields from your database that you want to get
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
                    string UsdExchange = Func.ParseString(dt.Rows[i]["UsdExchange"]);

                    float tmpUSD = Func.ParseFloat(MoneyUSD) - Func.ParseFloat(PaidUSD);
                    float tmpVND = Func.ParseFloat(MoneyVND) - Func.ParseFloat(PaidVND);

                    switch (PaymentType)
                    {
                        case "1":
                            //Rent
                            lblRentUSD.Text = MoneyUSD; // Where Fieldname is the name of fields from your database that you want to get
                            lblRentVND.Text = Func.FormatNumber(Func.ParseFloat(MoneyVND)); // Where Fieldname is the name of fields from your database that you want to get

                            lblRentPaidUSD.Text = PaidUSD; // Where Fieldname is the name of fields from your database that you want to get
                            lblRentPaidVND.Text = Func.FormatNumber(Func.ParseFloat(PaidVND)); // Where Fieldname is the name of fields from your database that you want to get

                            txtRentPaidUSD.Text = Func.FormatNumber(tmpUSD);
                            txtRentPaidVND.Text = Func.FormatNumber(tmpVND);

                            if (tmpUSD > 0)
                            {
                                txtRentPaidUSD.Text = Func.FormatDecimal2(tmpUSD);
                            }
                            if (tmpVND > 0)
                            {
                                txtRentPaidVND.Text = Func.FormatDecimal2(tmpVND);
                            }
                            //if (!String.IsNullOrEmpty(ExchangeType))
                            //{
                            //    rdoRentPaidUSD.Checked = "0".Equals(ExchangeType) ? true : false;
                            //    rdoRentPaidVND.Checked = "1".Equals(ExchangeType) ? true : false;

                            //    rdoRentUSD.Checked = "0".Equals(ExchangeType) ? true : false;
                            //    rdoRentVND.Checked = "1".Equals(ExchangeType) ? true : false;
                            //}
                            break;
                        case "2":
                            //Manager
                            lblMangagerUSD.Text = MoneyUSD; // Where Fieldname is the name of fields from your database that you want to get
                            lblMangagerVND.Text = Func.FormatNumber(Func.ParseFloat(MoneyVND)); // Where Fieldname is the name of fields from your database that you want to get

                            lblMangagerPaidUSD.Text = PaidUSD; // Where Fieldname is the name of fields from your database that you want to get
                            lblMangagerPaidVND.Text = Func.FormatNumber(Func.ParseFloat(PaidVND)); // Where Fieldname is the name of fields from your database that you want to get

                            //txtManagerPaidUSD.Text = Func.ParseString(Func.ParseFloat(MoneyUSD) - Func.ParseFloat(PaidUSD));
                            //txtManagerPaidVND.Text = Func.FormatDecimal(Func.ParseFloat(MoneyVND) - Func.ParseFloat(PaidVND), 0);

                            txtManagerPaidUSD.Text = Func.FormatNumber(tmpUSD);
                            txtManagerPaidVND.Text = Func.FormatNumber(tmpVND);

                            if (tmpUSD > 0)
                            {
                                txtManagerPaidUSD.Text = Func.FormatDecimal2(tmpUSD);
                            }
                            if (tmpVND > 0)
                            {
                                txtManagerPaidVND.Text = Func.FormatDecimal2(tmpVND);
                            }

                            //if (!String.IsNullOrEmpty(ExchangeType))
                            //{
                            //    rdoManagerPaidUSD.Checked = "0".Equals(ExchangeType) ? true : false;
                            //    rdoManagerPaidVND.Checked = "1".Equals(ExchangeType) ? true : false;

                            //    rdoManagerUSD.Checked = "0".Equals(ExchangeType) ? true : false;
                            //    rdoManagerVND.Checked = "1".Equals(ExchangeType) ? true : false;
                            //}
                            break;
                        case "3":
                            //Parking
                            lblParkingUSD.Text = MoneyUSD; // Where Fieldname is the name of fields from your database that you want to get
                            lblParkingVND.Text = Func.FormatNumber(Func.ParseFloat(MoneyVND)); // Where Fieldname is the name of fields from your database that you want to get

                            lblParkingPaidUSD.Text = PaidUSD; // Where Fieldname is the name of fields from your database that you want to get
                            lblParkingPaidVND.Text = Func.FormatNumber(Func.ParseFloat(PaidVND)); // Where Fieldname is the name of fields from your database that you want to get

                            txtParkingPaidUSD.Text = Func.ParseString(Func.ParseFloat(MoneyUSD) - Func.ParseFloat(PaidUSD));
                            txtParkingPaidVND.Text = Func.FormatDecimal(Func.ParseFloat(MoneyVND) - Func.ParseFloat(PaidVND), 0);
                            //if (!String.IsNullOrEmpty(ExchangeType))
                            //{
                            //    //0:USD; 1:VND
                            //    rdoParkingPaidUSD.Checked = "0".Equals(ExchangeType) ? true : false;
                            //    rdoParkingPaidVND.Checked = "1".Equals(ExchangeType) ? true : false;

                            //    rdoParkingUSD.Checked = "0".Equals(ExchangeType) ? true : false;
                            //    rdoParkingVND.Checked = "1".Equals(ExchangeType) ? true : false;
                            //}
                            txtParkingPaidUSD.Text = Func.FormatNumber(tmpUSD);
                            txtParkingPaidVND.Text = Func.FormatNumber(tmpVND);

                            if (tmpUSD > 0)
                            {
                                txtParkingPaidUSD.Text = Func.FormatDecimal2(tmpUSD);
                            }
                            if (tmpVND > 0)
                            {
                                txtParkingPaidVND.Text = Func.FormatDecimal2(tmpVND);
                            }
                            break;
                        case "4":
                            lblExtraTimeUSD.Text = MoneyUSD; // Where Fieldname is the name of fields from your database that you want to get
                            lblExtraTimeVND.Text = Func.FormatNumber(Func.ParseFloat(MoneyVND)); // Where Fieldname is the name of fields from your database that you want to get

                            lblExtraTimePaidUSD.Text = PaidUSD; // Where Fieldname is the name of fields from your database that you want to get
                            lblExtraTimePaidVND.Text = Func.FormatNumber(Func.ParseFloat(PaidVND)); // Where Fieldname is the name of fields from your database that you want to get

                            txtExtraTimePaidUSD.Text = Func.ParseString(Func.ParseFloat(MoneyUSD) - Func.ParseFloat(PaidUSD));
                            txtExtraTimePaidVND.Text = Func.FormatDecimal(Func.ParseFloat(MoneyVND) - Func.ParseFloat(PaidVND), 0);
                            //if (!String.IsNullOrEmpty(ExchangeType))
                            //{
                            //    rdoExtraTimePaidUSD.Checked = "0".Equals(ExchangeType) ? true : false;
                            //    rdoExtraTimePaidVND.Checked = "1".Equals(ExchangeType) ? true : false;

                            //    rdoExtraTimeUSD.Checked = "0".Equals(ExchangeType) ? true : false;
                            //    rdoExtraTimeVND.Checked = "1".Equals(ExchangeType) ? true : false;
                            //}
                            txtExtraTimePaidUSD.Text = Func.FormatNumber(tmpUSD);
                            txtExtraTimePaidVND.Text = Func.FormatNumber(tmpVND);

                            if (tmpUSD > 0)
                            {
                                txtExtraTimePaidUSD.Text = Func.FormatDecimal2(tmpUSD);
                            }
                            if (tmpVND > 0)
                            {
                                txtExtraTimePaidVND.Text = Func.FormatDecimal2(tmpVND);
                            }
                            break;
                        case "5":
                            lblElecUSD.Text = MoneyUSD; // Where Fieldname is the name of fields from your database that you want to get
                            lblElecVND.Text = Func.FormatNumber(Func.ParseFloat(MoneyVND)); // Where Fieldname is the name of fields from your database that you want to get

                            lblElecPaidUSD.Text = PaidUSD; // Where Fieldname is the name of fields from your database that you want to get
                            lblElecPaidVND.Text = Func.FormatNumber(Func.ParseFloat(PaidVND)); // Where Fieldname is the name of fields from your database that you want to get

                            txtElecPaidUSD.Text = Func.ParseString(Func.ParseFloat(MoneyUSD) - Func.ParseFloat(PaidUSD));
                            txtElecPaidVND.Text = Func.FormatDecimal(Func.ParseFloat(MoneyVND) - Func.ParseFloat(PaidVND), 0);
                            //if (!String.IsNullOrEmpty(ExchangeType))
                            //{
                            //    rdoElecPaidUSD.Checked = "0".Equals(ExchangeType) ? true : false;
                            //    rdoElecPaidVND.Checked = "1".Equals(ExchangeType) ? true : false;

                            //    rdoElecUSD.Checked = "0".Equals(ExchangeType) ? true : false;
                            //    rdoElecVND.Checked = "1".Equals(ExchangeType) ? true : false;
                            //}
                            txtElecPaidUSD.Text = Func.FormatNumber(tmpUSD);
                            txtElecPaidVND.Text = Func.FormatNumber(tmpVND);

                            if (tmpUSD > 0)
                            {
                                txtElecPaidUSD.Text = Func.FormatDecimal2(tmpUSD);
                            }
                            if (tmpVND > 0)
                            {
                                txtElecPaidVND.Text = Func.FormatDecimal2(tmpVND);
                            }
                            break;
                        case "6":
                            lblWaterUSD.Text = MoneyUSD; // Where Fieldname is the name of fields from your database that you want to get
                            lblWaterVND.Text = Func.FormatNumber(Func.ParseFloat(MoneyVND)); // Where Fieldname is the name of fields from your database that you want to get

                            lblWaterPaidUSD.Text = PaidUSD; // Where Fieldname is the name of fields from your database that you want to get
                            lblWaterPaidVND.Text = Func.FormatNumber(Func.ParseFloat(PaidVND)); // Where Fieldname is the name of fields from your database that you want to get

                            txtWaterPaidUSD.Text = Func.ParseString(Func.ParseFloat(MoneyUSD) - Func.ParseFloat(PaidUSD));
                            txtWaterPaidVND.Text = Func.FormatNumber(Func.ParseFloat(MoneyVND) - Func.ParseFloat(PaidVND));
                            //if (!String.IsNullOrEmpty(ExchangeType))
                            //{
                            //    rdoWaterPaidUSD.Checked = "0".Equals(ExchangeType) ? true : false;
                            //    rdoWaterPaidVND.Checked = "1".Equals(ExchangeType) ? true : false;

                            //    rdoWaterUSD.Checked = "0".Equals(ExchangeType) ? true : false;
                            //    rdoWaterVND.Checked = "1".Equals(ExchangeType) ? true : false;
                            //}
                            txtWaterPaidUSD.Text = Func.FormatNumber(tmpUSD);
                            txtWaterPaidVND.Text = Func.FormatNumber(tmpVND);

                            if (tmpUSD > 0)
                            {
                                txtWaterPaidUSD.Text = Func.FormatDecimal2(tmpUSD);
                            }
                            if (tmpVND > 0)
                            {
                                txtWaterPaidVND.Text = Func.FormatDecimal2(tmpVND);
                            }
                            break;
                        case "7":
                            lblServiceUSD.Text = MoneyUSD; // Where Fieldname is the name of fields from your database that you want to get
                            lblServiceVND.Text = Func.FormatNumber(Func.ParseFloat(MoneyVND)); // Where Fieldname is the name of fields from your database that you want to get

                            lblServicePaidUSD.Text = PaidUSD; // Where Fieldname is the name of fields from your database that you want to get
                            lblServicePaidVND.Text = Func.FormatNumber(Func.ParseFloat(PaidVND)); // Where Fieldname is the name of fields from your database that you want to get

                            txtServicePaidUSD.Text = Func.ParseString(Func.ParseFloat(MoneyUSD) - Func.ParseFloat(PaidUSD));
                            txtServicePaidVND.Text = Func.FormatNumber(Func.ParseFloat(MoneyVND) - Func.ParseFloat(PaidVND));
                            //if (!String.IsNullOrEmpty(ExchangeType))
                            //{
                            //    rdoServicePaidUSD.Checked = "0".Equals(ExchangeType) ? true : false;
                            //    rdoServicePaidVND.Checked = "1".Equals(ExchangeType) ? true : false;

                            //    rdoServiceUSD.Checked = "0".Equals(ExchangeType) ? true : false;
                            //    rdoServiceVND.Checked = "1".Equals(ExchangeType) ? true : false;
                            //}
                            txtServicePaidUSD.Text = Func.FormatNumber(tmpUSD);
                            txtServicePaidVND.Text = Func.FormatNumber(tmpVND);

                            if (tmpUSD > 0)
                            {
                                txtServicePaidUSD.Text = Func.FormatDecimal2(tmpUSD);
                            }
                            if (tmpVND > 0)
                            {
                                txtServicePaidVND.Text = Func.FormatDecimal2(tmpVND);
                            }
                            break;
                        default:
                            break;
                    }
                }
                //string yearMonthID = DbHelper.GetScalar("Select Id from PaymentYearMonth Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + YearMonth + "'");
                //if (!String.IsNullOrEmpty(yearMonthID))
                //{

                //    PaymentYearMonthData data = new PaymentYearMonthData();
                //    ITransaction tran = factory.GetLoadObject(data, yearMonthID);
                //    Execute(tran);
                //    if (!HasError)
                //    {
                //        //Get Data
                //        data = (PaymentYearMonthData)tran.Result;
                //        //Rent
                //        lblRentUSD.Text = data.RentUSD; // Where Fieldname is the name of fields from your database that you want to get
                //        lblRentVND.Text = Func.FormatNumber(Func.ParseFloat(data.RentVND)); // Where Fieldname is the name of fields from your database that you want to get
                //        //Manager
                //        lblMangagerUSD.Text = data.ManagerUSD; // Where Fieldname is the name of fields from your database that you want to get
                //        lblMangagerVND.Text = Func.FormatNumber(Func.ParseFloat(data.ManagerVND)); // Where Fieldname is the name of fields from your database that you want to get

                //        //Parking
                //        lblParkingUSD.Text = data.ParkingUSD; // Where Fieldname is the name of fields from your database that you want to get
                //        lblParkingVND.Text = Func.FormatNumber(Func.ParseFloat(data.ParkingVND)); // Where Fieldname is the name of fields from your database that you want to get
                //        //Extra Time
                //        lblExtraTimeUSD.Text = data.ExtraTimePriceUSD; // Where Fieldname is the name of fields from your database that you want to get
                //        lblExtraTimeVND.Text = Func.FormatNumber(Func.ParseFloat(data.ExtraTimePriceVND)); // Where Fieldname is the name of fields from your database that you want to get
                //        //Elec
                //        lblElecUSD.Text = data.ElectUSD; // Where Fieldname is the name of fields from your database that you want to get
                //        lblElecVND.Text = Func.FormatNumber(Func.ParseFloat(data.ElecVND)); // Where Fieldname is the name of fields from your database that you want to get
                //        //Water
                //        lblWaterUSD.Text = data.WaterUSD; // Where Fieldname is the name of fields from your database that you want to get
                //        lblWaterVND.Text = Func.FormatNumber(Func.ParseFloat(data.WaterVND)); // Where Fieldname is the name of fields from your database that you want to get
                //        //Service
                //        lblServiceUSD.Text = data.ServiceUSD; // Where Fieldname is the name of fields from your database that you want to get
                //        lblServiceVND.Text = Func.FormatNumber(Func.ParseFloat(data.ServiceVND)); // Where Fieldname is the name of fields from your database that you want to get
                //        /////////
                //        //Rent
                //        lblRentPaidUSD.Text = data.PaidRentUSD; // Where Fieldname is the name of fields from your database that you want to get
                //        lblRentPaidVND.Text = Func.FormatNumber(Func.ParseFloat(data.PaidRentVND)); // Where Fieldname is the name of fields from your database that you want to get
                //        //Manager
                //        lblMangagerPaidUSD.Text = data.PaidManagerUSD; // Where Fieldname is the name of fields from your database that you want to get
                //        lblMangagerPaidVND.Text = Func.FormatNumber(Func.ParseFloat(data.PaidManagerVND)); // Where Fieldname is the name of fields from your database that you want to get

                //        //Parking
                //        lblParkingPaidUSD.Text = data.PaidParkingUSD; // Where Fieldname is the name of fields from your database that you want to get
                //        lblParkingPaidVND.Text = Func.FormatNumber(data.PaidParkingVND); // Where Fieldname is the name of fields from your database that you want to get
                //        //Extra Time
                //        lblExtraTimePaidUSD.Text = data.PaidExtraTimePriceUSD; // Where Fieldname is the name of fields from your database that you want to get
                //        lblExtraTimePaidVND.Text = Func.FormatNumber(Func.ParseFloat(data.PaidExtraTimePriceVND)); // Where Fieldname is the name of fields from your database that you want to get
                //        //Elec
                //        lblElecPaidUSD.Text = data.PaidElectUSD; // Where Fieldname is the name of fields from your database that you want to get
                //        lblElecPaidVND.Text = Func.FormatNumber(Func.ParseFloat(data.PaidElecVND)); // Where Fieldname is the name of fields from your database that you want to get
                //        //Water
                //        lblWaterPaidUSD.Text = data.PaidWaterUSD; // Where Fieldname is the name of fields from your database that you want to get
                //        lblWaterPaidVND.Text = Func.FormatNumber(Func.ParseFloat(data.PaidWaterVND));// Where Fieldname is the name of fields from your database that you want to get
                //        //Service
                //        lblServicePaidUSD.Text = data.PaidServiceUSD; // Where Fieldname is the name of fields from your database that you want to get
                //        lblServicePaidVND.Text = Func.FormatNumber(Func.ParseFloat(data.PaidServiceVND)); // Where Fieldname is the name of fields from your database that you want to get


                //        txtRentPaidUSD.Text = Func.ParseString(Func.ParseFloat(data.RentUSD) - Func.ParseFloat(data.PaidRentUSD));
                //        txtRentPaidVND.Text = Func.FormatNumber(Func.ParseFloat(data.RentVND) - Func.ParseFloat(data.PaidRentVND));
                //        //Manager	=		//Manager	)-			//Manager
                //        txtManagerPaidUSD.Text = Func.ParseString(Func.ParseFloat(data.ManagerUSD) - Func.ParseFloat(data.PaidManagerUSD));
                //        txtManagerPaidVND.Text = Func.FormatNumber(Func.ParseFloat(data.ManagerVND) - Func.ParseFloat(data.PaidManagerVND));
                //        //Parking	=		//Parking	)-			//Parking
                //        txtParkingPaidUSD.Text = Func.ParseString(Func.ParseFloat(data.ParkingUSD) - Func.ParseFloat(data.PaidParkingUSD));
                //        txtParkingPaidVND.Text = Func.FormatNumber(Func.ParseFloat(data.ParkingVND) - Func.ParseFloat(data.PaidParkingVND));
                //        //ExtraTime	=		//ExtraTime	)-			//ExtraTime
                //        txtExtraTimePaidUSD.Text = Func.ParseString(Func.ParseFloat(data.ExtraTimePriceUSD) - Func.ParseFloat(data.PaidExtraTimePriceUSD));
                //        txtExtraTimePaidVND.Text = Func.FormatNumber(Func.ParseFloat(data.ExtraTimePriceVND) - Func.ParseFloat(data.PaidExtraTimePriceVND));
                //        //Elec	=		//Elec	)-			//Elec
                //        txtElecPaidUSD.Text = Func.ParseString(Func.ParseFloat(data.ElectUSD) - Func.ParseFloat(data.PaidElectUSD));
                //        txtElecPaidVND.Text = Func.FormatNumber(Func.ParseFloat(data.ElecVND) - Func.ParseFloat(data.PaidElecVND));
                //        //Water	=		//Water	)-			//Water
                //        txtWaterPaidUSD.Text = Func.ParseString(Func.ParseFloat(data.WaterUSD) - Func.ParseFloat(data.PaidWaterUSD));
                //        txtWaterPaidVND.Text = Func.FormatNumber(Func.ParseFloat(data.WaterVND) - Func.ParseFloat(data.PaidWaterVND));
                //        //Service	=		//Service	)-			//Service
                //        txtServicePaidUSD.Text = Func.ParseString(Func.ParseFloat(data.ServiceUSD) - Func.ParseFloat(data.PaidServiceUSD));
                //        txtServicePaidVND.Text = Func.FormatNumber(Func.ParseFloat(data.ServiceVND) - Func.ParseFloat(data.PaidServiceVND));
                //    }
                //}
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
                ShowData(drpYear.SelectedValue + drpMonth.SelectedValue);

                CustomerData data = new CustomerData();
                ITransaction tran = factory.GetLoadObject(data, hidId.Value);
                Execute(tran);
                if (!HasError)
                {
                    //Get Data
                    data = (CustomerData)tran.Result;
                    lblCustomerId.Text = data.CustomerId;
                    lblName.Text = data.Name;
                    //lblComment.Text = data.Comment;
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
            //string command = e.CommandName;
            //string colName = string.Empty;
            //if (command.StartsWith("Sort"))
            //{
            //    if (string.Compare(command, "SortID") == 0)
            //    {
            //        colName = "ID";
            //    }
            //    else if (string.Compare(command, "SortName") == 0)
            //    {
            //        colName = "Name";
            //    }
            //    else if (string.Compare(command, "SortModifiedBy") == 0)
            //    {
            //        colName = "ModifiedBy";
            //    }
            //    else if (string.Compare(command, "SortModified") == 0)
            //    {
            //        colName = "Modified";
            //    }


            //    if (colName == ListSortExpression)
            //    {
            //        ListSortDirection = (ListSortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending);
            //    }
            //    else
            //    {
            //        ListSortDirection = SortDirection.Descending;
            //    }
            //    ListSortExpression = colName;
            //    pager.CurrentPageIndex = 0;
            //    ShowData();
            //}
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

                    //PopupWidth = 600;
                    //PopupHeight = 450;
                    //LinkPopup((LinkButton)item.FindControl("btnEdit"), editPageName + ".aspx?Action=Edit&Id=" + ContractId);
                    //ButtonPopup((Button)item.FindControl("btnRoom"), RoomPageName + ".aspx?Action=Edit&Id=" + ContractId);
                    ////ButtonPopup((Button)item.FindControl("btnParking"), ParkingPageName + ".aspx?Action=Edit&Id=" + ContractId);
                    //ButtonPopup((Button)item.FindControl("btnDoc"), DocumentPageName + ".aspx?Action=Edit&DocType=5&Id=" + ContractId);


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

                    Func.SetGridTextValue(item, "ltrPriceVND", Func.FormatNumber(Func.ParseFloat(ManagerPriceVND)));
                    Func.SetGridTextValue(item, "ltrPriceUSD", ManagerPriceUSD);

                    Func.SetGridTextValue(item, "ltrSumVND", Func.FormatDecimal2(Func.ParseFloat(SumVND)));
                    Func.SetGridTextValue(item, "ltrSumUSD", SumUSD);

                    Func.SetGridTextValue(item, "ltrVatVND", Func.FormatDecimal2(Func.ParseFloat(VatVND)));
                    Func.SetGridTextValue(item, "ltrVatUSD", VatUSD);

                    Func.SetGridTextValue(item, "ltrLastPriceVND", Func.FormatNumber(Func.ParseFloat(LastPriceVND)));
                    Func.SetGridTextValue(item, "ltrLastPriceUSD", LastPriceUSD);


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

                    Func.SetGridTextValue(item, "ltrPriceVND", Func.FormatNumber(Func.ParseFloat(RentPriceVND)));
                    Func.SetGridTextValue(item, "ltrPriceUSD", RentPriceUSD);

                    Func.SetGridTextValue(item, "ltrSumVND", Func.FormatDecimal2(Func.ParseFloat(SumVND)));
                    Func.SetGridTextValue(item, "ltrSumUSD", SumUSD);

                    Func.SetGridTextValue(item, "ltrVatVND", Func.FormatDecimal2(Func.ParseFloat(VatVND)));
                    Func.SetGridTextValue(item, "ltrVatUSD", VatUSD);

                    Func.SetGridTextValue(item, "ltrLastPriceVND", Func.FormatNumber(Func.ParseFloat(LastPriceVND)));
                    Func.SetGridTextValue(item, "ltrLastPriceUSD", LastPriceUSD);

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
        protected void rptParking_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            try
            {
                if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
                {
                    DataRowView row = (DataRowView)item.DataItem;

                    //string id = Func.ParseString(row["id"]);
                    string Num = Func.ParseString(row["Num"]);
                    string TariffsParkingName = Func.ParseString(row["TariffsParkingName"]);

                    string PriceVND = Func.ParseString(row["PriceVND"]);
                    string PriceUSD = Func.ParseString(row["PriceUSD"]);
                    string VatVND = Func.ParseString(row["VatVND"]);
                    string VatUSD = Func.ParseString(row["VatUSD"]);

                    //string OtherFee01 = Func.ParseString(row["OtherFee01"]);
                    //string OtherFee02 = Func.ParseString(row["OtherFee02"]);
                    string SumVND = Func.ParseString(row["SumVND"]);
                    string SumUSD = Func.ParseString(row["SumUSD"]);
                    string LastPriceVND = Func.ParseString(row["LastPriceVND"]);
                    string LastPriceUSD = Func.ParseString(row["LastPriceUSD"]);

                    Func.SetGridTextValue(item, "ltrName", TariffsParkingName);

                    Func.SetGridTextValue(item, "ltrNum", Func.FormatNumber(Num));

                    Func.SetGridTextValue(item, "ltrPriceVND", Func.FormatNumber(Func.ParseFloat(PriceVND)));
                    Func.SetGridTextValue(item, "ltrPriceUSD", PriceUSD);

                    Func.SetGridTextValue(item, "ltrSumVND", Func.FormatDecimal2(Func.ParseFloat(SumVND)));
                    Func.SetGridTextValue(item, "ltrSumUSD", SumUSD);

                    Func.SetGridTextValue(item, "ltrVatVND", Func.FormatDecimal2(Func.ParseFloat(VatVND)));
                    Func.SetGridTextValue(item, "ltrVatUSD", VatUSD);

                    Func.SetGridTextValue(item, "ltrLastPriceVND", Func.FormatNumber(Func.ParseFloat(LastPriceVND)));
                    Func.SetGridTextValue(item, "ltrLastPriceUSD", LastPriceUSD);


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

        protected void rptExtraTime_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            try
            {
                if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
                {
                    DataRowView row = (DataRowView)item.DataItem;

                    //string id = Func.ParseString(row["id"]);
                    string ExtraHour = Func.ParseString(row["ExtraHour"]);
                    string WorkingDate = Func.ParseString(row["WorkingDate"]);

                    string PriceVND = Func.ParseString(row["PriceVND"]);
                    string PriceUSD = Func.ParseString(row["PriceUSD"]);
                    string VatUSD = Func.ParseString(row["VatUSD"]);
                    string VatVND = Func.ParseString(row["VatVND"]);

                    //string OtherFee01 = Func.ParseString(row["OtherFee01"]);
                    //string OtherFee02 = Func.ParseString(row["OtherFee02"]);
                    string SumVND = Func.ParseString(row["SumVND"]);
                    string SumUSD = Func.ParseString(row["SumUSD"]);
                    string LastPriceVND = Func.ParseString(row["LastPriceVND"]);
                    string LastPriceUSD = Func.ParseString(row["LastPriceUSD"]);

                    Func.SetGridTextValue(item, "ltrWorkingDate", Func.FormatDMY(WorkingDate));

                    Func.SetGridTextValue(item, "ltrExtraHour", Func.FormatNumber(ExtraHour));

                    Func.SetGridTextValue(item, "ltrPriceVND", Func.FormatNumber(Func.ParseFloat(PriceVND)));
                    Func.SetGridTextValue(item, "ltrPriceUSD", PriceUSD);

                    Func.SetGridTextValue(item, "ltrSumVND", Func.FormatNumber(Func.ParseFloat(SumVND)));
                    Func.SetGridTextValue(item, "ltrSumUSD", SumUSD);

                    Func.SetGridTextValue(item, "ltrVatVND", Func.FormatNumber(Func.ParseFloat(VatVND)));
                    Func.SetGridTextValue(item, "ltrVatUSD", VatUSD);

                    Func.SetGridTextValue(item, "ltrLastPriceVND", Func.FormatNumber(Func.ParseFloat(LastPriceVND)));
                    Func.SetGridTextValue(item, "ltrLastPriceUSD", LastPriceUSD);


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

                    Func.SetGridTextValue(item, "ltrServiceDate", Func.FormatDMY(ServiceDate));
                    Func.SetGridTextValue(item, "ltrMount", Mount);

                    Func.SetGridTextValue(item, "ltrService", Service);

                    Func.SetGridTextValue(item, "ltrPriceVND", Func.FormatNumber(Func.ParseFloat(PriceVND)));
                    Func.SetGridTextValue(item, "ltrPriceUSD", PriceUSD);

                    Func.SetGridTextValue(item, "ltrSumVND", Func.FormatNumber(Func.ParseFloat(SumVND)));
                    Func.SetGridTextValue(item, "ltrSumUSD", SumUSD);

                    Func.SetGridTextValue(item, "ltrVatVND", Func.FormatNumber(Func.ParseFloat(VatVND)));
                    Func.SetGridTextValue(item, "ltrVatUSD", VatUSD);

                    Func.SetGridTextValue(item, "ltrLastPriceVND", Func.FormatNumber(Func.ParseFloat(LastPriceVND)));
                    Func.SetGridTextValue(item, "ltrLastPriceUSD", LastPriceUSD);

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

                    Func.SetGridTextValue(item, "ltrName", Name);

                    Func.SetGridTextValue(item, "ltrDateFrom", Func.FormatDMY(DateFrom));
                    Func.SetGridTextValue(item, "ltrDateTo", Func.FormatDMY(DateTo));

                    Func.SetGridTextValue(item, "ltrFromIndex", "" + Func.ParseFloat(FromIndex));
                    Func.SetGridTextValue(item, "ltrToIndex", "" + Func.ParseFloat(ToIndex));

                    Func.SetGridTextValue(item, "ltrOtherFee01", OtherFee01);
                    Func.SetGridTextValue(item, "ltrOtherFee02", OtherFee02);

                    Func.SetGridTextValue(item, "ltrUsed", "" + (Func.ParseFloat(ToIndex) - Func.ParseFloat(FromIndex)) * Func.ParseFloat(OtherFee01));


                    Func.SetGridTextValue(item, "ltrPriceVND", Func.FormatNumber(Func.ParseFloat(PriceVND)));
                    Func.SetGridTextValue(item, "ltrPriceUSD", PriceUSD);

                    Func.SetGridTextValue(item, "ltrSumVND", Func.FormatDecimal(Func.ParseFloat(SumVND)));
                    Func.SetGridTextValue(item, "ltrSumUSD", SumUSD);

                    Func.SetGridTextValue(item, "ltrVatVND", Func.FormatDecimal(Func.ParseFloat(VatVND), 2));
                    Func.SetGridTextValue(item, "ltrVatUSD", VatUSD);

                    Func.SetGridTextValue(item, "ltrLastPriceVND", Func.FormatDecimal(Func.ParseFloat(LastPriceVND), 0));
                    Func.SetGridTextValue(item, "ltrLastPriceUSD", LastPriceUSD);

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

                    Func.SetGridTextValue(item, "ltrName", Name);

                    Func.SetGridTextValue(item, "ltrDateFrom", Func.FormatDMY(DateFrom));
                    Func.SetGridTextValue(item, "ltrDateTo", Func.FormatDMY(DateTo));

                    Func.SetGridTextValue(item, "ltrFromIndex", Func.FormatNumber(FromIndex));
                    Func.SetGridTextValue(item, "ltrToIndex", Func.FormatNumber(ToIndex));

                    Func.SetGridTextValue(item, "ltrOtherFee01", "" + OtherFee01);
                    Func.SetGridTextValue(item, "ltrOtherFee02", "" + OtherFee02);
                    Func.SetGridTextValue(item, "ltrUsed", "" + (Func.ParseInt(ToIndex) - Func.ParseInt(FromIndex)));

                    Func.SetGridTextValue(item, "ltrPriceVND", Func.FormatNumber(Func.ParseFloat(PriceVND)));
                    Func.SetGridTextValue(item, "ltrPriceUSD", PriceUSD);

                    Func.SetGridTextValue(item, "ltrSumVND", Func.FormatNumber(Func.ParseFloat(SumVND)));
                    Func.SetGridTextValue(item, "ltrSumUSD", SumUSD);

                    Func.SetGridTextValue(item, "ltrVatVND", Func.FormatNumber(Func.ParseFloat(VatVND)));
                    Func.SetGridTextValue(item, "ltrVatUSD", VatUSD);

                    Func.SetGridTextValue(item, "ltrLastPriceVND", Func.FormatNumber(Func.ParseFloat(LastPriceVND)));
                    Func.SetGridTextValue(item, "ltrLastPriceUSD", LastPriceUSD);

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
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            ShowData(drpYear.SelectedValue + drpMonth.SelectedValue);
        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            int rBillNo = 0;
            int cBillNo = 1;

            int rBillDate = 0;
            int cBillDate = 10;

            int rBillMonth = 2;
            int cBillMonth = 0;

            int rContact = 5;
            int cContact = 3;

            int rCustomer = 5;
            int cCustomer = 9;

            int rContract = 7;
            int cContract = 1;

            int rRate = 11;
            int cRate = 9;

            int rRateDate = 11;
            int cRateDate = 12;

            int rRent = 15;
            int cRent = 1;

            int rManager = 23;
            int cManager = 1;

            int rParking = 31;
            int cParking = 1;

            int rExtra = 39;
            int cExtra = 1;

            int rElec = 47;
            int cElec = 1;

            int rWater = 55;
            int cWater = 1;

            int rService = 63;
            int cService = 1;

            int rPaid = 70;
            int cPaid = 1;

            int rDept = 77;
            int cDept = 1;

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
            xlstStyle.WordWrap = true;
            xlstStyle.Font = new Font("", 8, FontStyle.Regular);
            xlstStyle.SetBorderColor(Color.Black);
            xlstStyle.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyle.BorderTop = XLLineStyleEnum.Thin;
            xlstStyle.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyle.BorderRight = XLLineStyleEnum.Thin;
            xlstStyle.Format = "#,##0.00_);(#,##0.00)";

            XLStyle xlstStyleH = new XLStyle(xlbBook);
            xlstStyleH.AlignHorz = XLAlignHorzEnum.Center;
            xlstStyleH.AlignVert = XLAlignVertEnum.Center;
            xlstStyleH.Font = new Font("", 8, FontStyle.Bold);
            xlstStyleH.SetBorderColor(Color.Black);
            xlstStyleH.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleH.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleH.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleH.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleH.WordWrap = true;

            string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BillTongQuat" + strDT + ".xlsx";
            string strFilePathExport = @"../../Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + @"/BillTongQuat" + strDT + ".xlsx";

            string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

            //string fileNameDes = HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\TongHopDienTich" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
            File.Copy(fileName, fileNameDes);

            xlbBook.Load(fileNameDes);
            XLSheet xlsSheet = xlbBook.Sheets["TongHop"];

            xlsSheet[0, 0].Value = xlsSheet[0, 0].Value.ToString().Replace("{%BILL_NO%}", txtBillNo.Text);
            xlsSheet[1, 8].Value = xlsSheet[1, 8].Value.ToString().Replace("{%NGAY%}", DateTime.Today.ToString("dd"));
            xlsSheet[1, 8].Value = xlsSheet[1, 8].Value.ToString().Replace("{%THANG%}", DateTime.Today.ToString("MM"));
            xlsSheet[1, 8].Value = xlsSheet[1, 8].Value.ToString().Replace("{%NAM%}", DateTime.Today.ToString("yyyy"));

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

                            xlsSheet[6, 0].Value = xlsSheet[6, 0].Value.ToString().Replace("{%TEN_CONG_TY%}", Name);
                            xlsSheet[7, 0].Value = xlsSheet[7, 0].Value.ToString().Replace("{%NGUOI_DAI_DIEN%}", ContactName);
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

                            xlsSheet[62, 0].Value = xlsSheet[62, 0].Value.ToString().Replace("{%VAN_PHONG%}", Office);
                            xlsSheet[63, 0].Value = xlsSheet[63, 0].Value.ToString().Replace("{%DIEN_THOAI%}", OfficePhone);

                            xlsSheet[65, 0].Value = xlsSheet[65, 0].Value.ToString().Replace("{%NGAN_HANG%}", Bank);
                            xlsSheet[66, 0].Value = xlsSheet[66, 0].Value.ToString().Replace("{%TEN_TAI_KHOAN%}", AccountName);
                            xlsSheet[67, 0].Value = xlsSheet[67, 0].Value.ToString().Replace("{%SO_TAI_KHOAN%}", Account);
                        }
                    }
                }

                xlsSheet[56, 0].Value = xlsSheet[56, 0].Value.ToString().Replace("{%TI_GIA%}", txtUsdExchange.Text).Replace("{%NGAY_AP_DUNG%}", txtUsdExchangeDate.Text);

                //Thue phong
                ds = new DataSet();
                sql = " Select *";
                sql += " FROM PaymentRoom";
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";

                int j = 0;

                double[] LastSumPriceVND = new double[7] { 0, 0, 0, 0, 0, 0, 0 };
                float[] LastSumPriceUSD = new float[7] { 0, 0, 0, 0, 0, 0, 0 };

                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);

                    if (ds != null)
                    {
                        int count = 0;
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            if (count >= 1)
                            {
                                xlsSheet.Rows.Insert(17 + j);
                                j++;
                            }
                            count++;

                            int tmp = 16 + j;

                            string id = Func.ParseString(rowType["id"]);
                            string BuildingId = Func.ParseString(rowType["BuildingId"]);
                            string CustomerId = Func.ParseString(rowType["CustomerId"]);
                            string ContractId = Func.ParseString(rowType["ContractId"]);
                            string RoomId = Func.ParseString(rowType["RoomId"]);

                            string OtherFee01 = Func.ParseString(rowType["OtherFee01"]);
                            string OtherFee02 = Func.ParseString(rowType["OtherFee02"]);

                            string YearMonth = Func.ParseString(rowType["YearMonth"]);
                            string Area = Func.ParseString(rowType["Area"]);
                            string Name = Func.ParseString(rowType["Name"]);
                            string Regional = Func.ParseString(rowType["Regional"]);
                            string Floor = Func.ParseString(rowType["Floor"]);


                            string RentPriceVND = Func.ParseString(rowType["MonthRentPriceVND"]);
                            string RentPriceUSD = Func.ParseString(rowType["MonthRentPriceUSD"]);
                            string VatVND = Func.ParseString(rowType["VatRentPriceVND"]);
                            string VatUSD = Func.ParseString(rowType["VatRentPriceUSD"]);


                            string SumVND = Func.ParseString(rowType["MonthRentSumVND"]);
                            string SumUSD = Func.ParseString(rowType["MonthRentSumUSD"]);

                            string LastPriceVND = Func.ParseString(rowType["LastRentSumVND"]);
                            string LastPriceUSD = Func.ParseString(rowType["LastRentSumUSD"]);

                            string BeginContract = Func.ParseString(rowType["BeginContract"]);


                            if (!contractIdLst.ContainsKey(ContractId + "(" + BeginContract + ")"))
                            {
                                contractIdLst.Add(ContractId + "(" + BeginContract + ")", ContractId + "(" + BeginContract + ")");
                                contract += ";" + ContractId + "(" + BeginContract + ")";
                            }

                            xlsSheet[tmp, 1].Value = Name;
                            xlsSheet[tmp, 4].Value = Regional;
                            xlsSheet[tmp, 5].Value = Floor;
                            xlsSheet[tmp, 6].Value = Func.ParseFloat(Area);
                            xlsSheet[tmp, 7].Value = Func.ParseFloat(RentPriceUSD);
                            xlsSheet[tmp, 8].Value = Func.ParseFloat(RentPriceVND);
                            xlsSheet[tmp, 9].Value = Func.ParseFloat(SumUSD);
                            xlsSheet[tmp, 10].Value = Func.ParseFloat(SumVND);
                            xlsSheet[tmp, 11].Value = Func.ParseFloat(VatUSD);
                            xlsSheet[tmp, 12].Value = Func.ParseFloat(VatVND);
                            xlsSheet[tmp, 13].Value = Func.ParseFloat(LastPriceUSD);
                            xlsSheet[tmp, 14].Value = Func.ParseFloat(LastPriceVND);

                            XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
                            xlsSheet.MergedCells.Add(mrCell);

                            for (int col = 1; col <= 14; col++)
                            {
                                xlsSheet[tmp, col].Style = xlstStyle;
                            }

                            LastSumPriceVND[0] += Func.ParseFloat(LastPriceVND);
                            LastSumPriceUSD[0] += Func.ParseFloat(LastPriceUSD);

                        }
                        xlsSheet[17 + j, 13].Value = LastSumPriceUSD[0];
                        xlsSheet[17 + j, 14].Value = LastSumPriceVND[0];

                        int line = 20 + j;
                        //Quan ly
                        XLCellRange mCell = new XLCellRange(line, line + 1, 1, 3);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line + 1, 4, 4);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line + 1, 5, 5);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 7, 8);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 9, 10);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 11, 12);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 13, 14);
                        xlsSheet.MergedCells.Add(mCell);

                        for (int col = 1; col <= 14; col++)
                        {
                            xlsSheet[line, col].Style = xlstStyleH;
                        }

                        count = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            if (count >= 1)
                            {
                                xlsSheet.Rows.Insert(23 + j);
                                j++;
                            }
                            count++;
                            int tmp = 22;

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

                            xlsSheet[tmp, 1].Value = Name;
                            xlsSheet[tmp, 4].Value = Regional;
                            xlsSheet[tmp, 5].Value = Floor;
                            xlsSheet[tmp, 6].Value = Func.ParseFloat(Area);
                            xlsSheet[tmp, 7].Value = Func.ParseFloat(ManagerPriceUSD);
                            xlsSheet[tmp, 8].Value = Func.ParseFloat(ManagerPriceVND);
                            xlsSheet[tmp, 9].Value = Func.ParseFloat(SumUSD);
                            xlsSheet[tmp, 10].Value = Func.ParseFloat(SumVND);
                            xlsSheet[tmp, 11].Value = Func.ParseFloat(VatUSD);
                            xlsSheet[tmp, 12].Value = Func.ParseFloat(VatVND);
                            xlsSheet[tmp, 13].Value = Func.ParseFloat(LastPriceUSD);
                            xlsSheet[tmp, 14].Value = Func.ParseFloat(LastPriceVND);

                            XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
                            xlsSheet.MergedCells.Add(mrCell);

                            for (int col = 1; col <= 14; col++)
                            {
                                xlsSheet[tmp, col].Style = xlstStyle;
                            }
                            LastSumPriceVND[1] += Func.ParseFloat(LastPriceVND);
                            LastSumPriceUSD[1] += Func.ParseFloat(LastPriceUSD);
                        }
                        xlsSheet[23 + j, 13].Value = LastSumPriceUSD[1];
                        xlsSheet[23 + j, 14].Value = LastSumPriceVND[1];
                    }
                }
                ds = new DataSet();
                //Xuất ra toàn bộ nội dung theo Trang
                sql = " SELECT COUNT(*) AS Num, YearMonth, TariffsParkingName, PriceVND, PriceUSD, SUM(VatVND) AS VatVND,SUM(VatUSD) AS VatUSD, SUM(SumVND) AS SumVND, SUM(SumUSD) AS SumUSD, SUM(LastPriceVND) AS LastPriceVND";
                sql += "        , SUM(LastPriceUSD) AS LastPriceUSD";
                sql += " FROM         dbo.PaymentParking";
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";
                sql += " GROUP BY YearMonth, TariffsParkingName, PriceVND, PriceUSD, Vat";

                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);

                    if (ds != null)
                    {
                        int count = 0;
                        DataTable dt = ds.Tables[0];
                        int line = 26 + j;
                        //Phi gui xe
                        XLCellRange mCell = new XLCellRange(line, line + 1, 1, 5);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 7, 8);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 9, 10);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 11, 12);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 13, 14);
                        xlsSheet.MergedCells.Add(mCell);

                        for (int col = 1; col <= 14; col++)
                        {
                            xlsSheet[line, col].Style = xlstStyleH;
                        }

                        foreach (DataRow row in dt.Rows)
                        {
                            if (count >= 1)
                            {
                                xlsSheet.Rows.Insert(29 + j);
                                j++;
                            }
                            count++;
                            int tmp = 28 + j;

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

                            xlsSheet[tmp, 1].Value = TariffsParkingName;
                            xlsSheet[tmp, 6].Value = Num;
                            xlsSheet[tmp, 7].Value = Func.ParseFloat(PriceUSD);
                            xlsSheet[tmp, 8].Value = Func.ParseFloat(PriceVND);
                            xlsSheet[tmp, 9].Value = Func.ParseFloat(SumUSD);
                            xlsSheet[tmp, 10].Value = Func.ParseFloat(SumVND);
                            xlsSheet[tmp, 11].Value = Func.ParseFloat(VatUSD);
                            xlsSheet[tmp, 12].Value = Func.ParseFloat(VatVND);
                            xlsSheet[tmp, 13].Value = Func.ParseFloat(LastPriceUSD);
                            xlsSheet[tmp, 14].Value = Func.ParseFloat(LastPriceVND);

                            XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 5);
                            xlsSheet.MergedCells.Add(mrCell);

                            for (int col = 1; col <= 14; col++)
                            {
                                xlsSheet[tmp, col].Style = xlstStyle;
                            }
                            LastSumPriceVND[2] += Func.ParseFloat(LastPriceVND);
                            LastSumPriceUSD[2] += Func.ParseFloat(LastPriceUSD);
                        }
                        xlsSheet[29 + j, 13].Value = LastSumPriceUSD[2];
                        xlsSheet[29 + j, 14].Value = LastSumPriceVND[2];
                    }
                }

                //Lam ngoai gio
                ds = new DataSet();
                sql = " SELECT * ";
                sql += " FROM   PaymentExtraTime";
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";

                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);

                    if (ds != null)
                    {
                        int count = 0;
                        DataTable dt = ds.Tables[0];
                        int line = 32 + j;
                        //Phi ngoai gio
                        XLCellRange mCell = new XLCellRange(line, line + 1, 1, 5);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 7, 8);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 9, 10);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 11, 12);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 13, 14);
                        xlsSheet.MergedCells.Add(mCell);

                        for (int col = 1; col <= 14; col++)
                        {
                            xlsSheet[line, col].Style = xlstStyleH;
                        }

                        foreach (DataRow row in dt.Rows)
                        {
                            if (count >= 1)
                            {
                                xlsSheet.Rows.Insert(35 + j);
                                j++;
                            }
                            count++;
                            int tmp = 34 + j;

                            //string id = Func.ParseString(row["id"]);
                            string ExtraHour = Func.ParseString(row["ExtraHour"]);
                            string WorkingDate = Func.ParseString(row["WorkingDate"]);

                            string PriceVND = Func.ParseString(row["PriceVND"]);
                            string PriceUSD = Func.ParseString(row["PriceUSD"]);
                            string VatUSD = Func.ParseString(row["VatUSD"]);
                            string VatVND = Func.ParseString(row["VatVND"]);

                            //string OtherFee01 = Func.ParseString(row["OtherFee01"]);
                            //string OtherFee02 = Func.ParseString(row["OtherFee02"]);
                            string SumVND = Func.ParseString(row["SumVND"]);
                            string SumUSD = Func.ParseString(row["SumUSD"]);
                            string LastPriceVND = Func.ParseString(row["LastPriceVND"]);
                            string LastPriceUSD = Func.ParseString(row["LastPriceUSD"]);

                            xlsSheet[tmp, 1].Value = WorkingDate;
                            xlsSheet[tmp, 6].Value = ExtraHour;
                            xlsSheet[tmp, 7].Value = Func.ParseFloat(PriceUSD);
                            xlsSheet[tmp, 8].Value = Func.ParseFloat(PriceVND);
                            xlsSheet[tmp, 9].Value = Func.ParseFloat(SumUSD);
                            xlsSheet[tmp, 10].Value = Func.ParseFloat(SumVND);
                            xlsSheet[tmp, 11].Value = Func.ParseFloat(VatUSD);
                            xlsSheet[tmp, 12].Value = Func.ParseFloat(VatVND);
                            xlsSheet[tmp, 13].Value = Func.ParseFloat(LastPriceUSD);
                            xlsSheet[tmp, 14].Value = Func.ParseFloat(LastPriceVND);

                            XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 5);
                            xlsSheet.MergedCells.Add(mrCell);

                            for (int col = 1; col <= 14; col++)
                            {
                                xlsSheet[tmp, col].Style = xlstStyle;
                            }
                            LastSumPriceVND[3] += Func.ParseFloat(LastPriceVND);
                            LastSumPriceUSD[3] += Func.ParseFloat(LastPriceUSD);
                        }
                        xlsSheet[35 + j, 13].Value = LastSumPriceUSD[3];
                        xlsSheet[35 + j, 14].Value = LastSumPriceVND[3];
                    }
                }

                ds = new DataSet();
                //Dien
                //Xuất ra toàn bộ nội dung theo Trang
                sql = " SELECT A.DateFrom, A.DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.Mount, B.PriceVND, B.PriceUSD, B.SumVND, B.SumUSD, ";
                sql += "        B.VatVND, B.VatUSD, B.LastPriceVND, B.LastPriceUSD, B.Name ";
                sql += " FROM   PaymentElecWater AS A INNER JOIN ";
                sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId";
                sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfWaterId = 0  and A.YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";
                sql += " Order by A.DateFrom, B.FromIndex";

                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);

                    if (ds != null)
                    {
                        int count = 0;
                        DataTable dt = ds.Tables[0];
                        int line = 38 + j;
                        //Phi dien
                        XLCellRange mCell = new XLCellRange(line, line + 1, 1, 1);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line + 1, 2, 2);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line + 1, 3, 3);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line + 1, 4, 4);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line + 1, 5, 5);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 7, 8);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 9, 10);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 11, 12);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 13, 14);
                        xlsSheet.MergedCells.Add(mCell);

                        for (int col = 1; col <= 14; col++)
                        {
                            xlsSheet[line, col].Style = xlstStyleH;
                        }

                        foreach (DataRow row in dt.Rows)
                        {
                            if (count >= 1)
                            {
                                xlsSheet.Rows.Insert(41 + j);
                                j++;
                            }
                            count++;
                            int tmp = 40 + j;

                            string Name = Func.ParseString(row["Name"]);
                            string DateFrom = Func.ParseString(row["DateFrom"]);
                            string DateTo = Func.ParseString(row["DateTo"]);

                            string FromIndex = Func.ParseString(row["FromIndex"]);
                            string ToIndex = Func.ParseString(row["ToIndex"]);
                            string OtherFee01 = Func.ParseString(row["OtherFee01"]);
                            string Mount = Func.ParseString(row["Mount"]);


                            string PriceVND = Func.ParseString(row["PriceVND"]);
                            string PriceUSD = Func.ParseString(row["PriceUSD"]);
                            string VatUSD = Func.ParseString(row["VatUSD"]);
                            string VatVND = Func.ParseString(row["VatVND"]);

                            string SumVND = Func.ParseString(row["SumVND"]);
                            string SumUSD = Func.ParseString(row["SumUSD"]);
                            string LastPriceVND = Func.ParseString(row["LastPriceVND"]);
                            string LastPriceUSD = Func.ParseString(row["LastPriceUSD"]);

                            xlsSheet[tmp, 1].Value = DateFrom;
                            xlsSheet[tmp, 2].Value = DateTo;
                            xlsSheet[tmp, 3].Value = FromIndex;
                            xlsSheet[tmp, 4].Value = ToIndex;
                            xlsSheet[tmp, 5].Value = OtherFee01;
                            xlsSheet[tmp, 6].Value = Mount;
                            xlsSheet[tmp, 7].Value = Func.ParseFloat(PriceUSD);
                            xlsSheet[tmp, 8].Value = Func.ParseFloat(PriceVND);
                            xlsSheet[tmp, 9].Value = Func.ParseFloat(SumUSD);
                            xlsSheet[tmp, 10].Value = Func.ParseFloat(SumVND);
                            xlsSheet[tmp, 11].Value = Func.ParseFloat(VatUSD);
                            xlsSheet[tmp, 12].Value = Func.ParseFloat(VatVND);
                            xlsSheet[tmp, 13].Value = Func.ParseFloat(LastPriceUSD);
                            xlsSheet[tmp, 14].Value = Func.ParseFloat(LastPriceVND);

                            for (int col = 1; col <= 14; col++)
                            {
                                xlsSheet[tmp, col].Style = xlstStyle;
                            }
                            LastSumPriceVND[4] += Func.ParseFloat(LastPriceVND);
                            LastSumPriceUSD[4] += Func.ParseFloat(LastPriceUSD);
                        }
                        xlsSheet[41 + j, 13].Value = LastSumPriceUSD[4];
                        xlsSheet[41 + j, 14].Value = LastSumPriceVND[4];
                    }
                }

                ////Water
                //sql = string.Empty;

                ////Xuất ra toàn bộ nội dung theo Trang
                //sql += " SELECT A.DateFrom, A.DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.Mount, B.PriceVND, B.PriceUSD, B.SumVND, B.SumUSD, ";
                //sql += "        B.VatVND, B.VatUSD, B.LastPriceVND, B.LastPriceUSD, B.Name ";
                //sql += " FROM   PaymentElecWater AS A INNER JOIN ";
                //sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId";
                //sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + hidId.Value + "' and TarrifsOfElecId = 0 and A.YearMonth = '" + YearMonth + "'";
                //sql += " Order by A.DateFrom, B.FromIndex";
                ds = new DataSet();
                //Service
                sql = string.Empty;
                sql = " SELECT * ";
                sql += " FROM   PaymentService";
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidId.Value + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";
                sql += " Order By ServiceDate ";

                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);

                    if (ds != null)
                    {
                        int count = 0;
                        DataTable dt = ds.Tables[0];
                        int line = 44 + j;
                        //Phi khác
                        XLCellRange mCell = new XLCellRange(line, line + 1, 1, 3);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line + 1, 4, 4);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line + 1, 5, 5);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 7, 8);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 9, 10);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 11, 12);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(line, line, 13, 14);
                        xlsSheet.MergedCells.Add(mCell);

                        for (int col = 1; col <= 14; col++)
                        {
                            xlsSheet[line, col].Style = xlstStyleH;
                        }

                        foreach (DataRow row in dt.Rows)
                        {
                            if (count >= 1)
                            {
                                xlsSheet.Rows.Insert(41 + j);
                                j++;
                            }
                            count++;
                            int tmp = 46 + j++;

                            string Service = Func.ParseString(row["Service"]);
                            string ServiceDateFrom = Func.ParseString(row["ServiceDateFrom"]);
                            string ServiceDateTo = Func.ParseString(row["ServiceDateTo"]);

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

                            xlsSheet[tmp, 1].Value = Service;
                            xlsSheet[tmp, 4].Value = ServiceDateFrom;
                            xlsSheet[tmp, 5].Value = ServiceDateTo;
                            xlsSheet[tmp, 6].Value = Mount;
                            xlsSheet[tmp, 7].Value = Func.ParseFloat(PriceUSD);
                            xlsSheet[tmp, 8].Value = Func.ParseFloat(PriceVND);
                            xlsSheet[tmp, 9].Value = Func.ParseFloat(SumUSD);
                            xlsSheet[tmp, 10].Value = Func.ParseFloat(SumVND);
                            xlsSheet[tmp, 11].Value = Func.ParseFloat(VatUSD);
                            xlsSheet[tmp, 12].Value = Func.ParseFloat(VatVND);
                            xlsSheet[tmp, 13].Value = Func.ParseFloat(LastPriceUSD);
                            xlsSheet[tmp, 14].Value = Func.ParseFloat(LastPriceVND);

                            XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
                            xlsSheet.MergedCells.Add(mrCell);

                            for (int col = 1; col <= 14; col++)
                            {
                                xlsSheet[tmp, col].Style = xlstStyle;
                            }
                            LastSumPriceVND[5] += Func.ParseFloat(LastPriceVND);
                            LastSumPriceUSD[5] += Func.ParseFloat(LastPriceUSD);
                        }
                        xlsSheet[47 + j, 13].Value = LastSumPriceUSD[5];
                        xlsSheet[47 + j, 14].Value = LastSumPriceVND[5];
                    }
                }
                double AllSumVND = 0;
                float AllSumUSD = 0;
                for (int i = 0; i < 7; i++)
                {
                    AllSumVND += LastSumPriceVND[i];
                    AllSumUSD += LastSumPriceUSD[i];
                }
                string strMoney = Func.docso(Convert.ToInt32(AllSumVND));

                xlsSheet[8, 0].Value = xlsSheet[8, 0].Value.ToString().Replace("{%HOP_DONG%}", contract.Substring(1));
                xlsSheet[57 + j, 0].Value = xlsSheet[57 + j, 0].Value.ToString().Replace("{%TONG%}", Func.ParseString(AllSumVND));
                xlsSheet[58 + j, 0].Value = xlsSheet[58 + j, 0].Value.ToString().Replace("{%TONG_CHU%}", strMoney.ToUpper());

                //j--;
                //XLSheet source = xlbBook.Sheets["tpl"];

                //for (int row = 22; row <= 26; row++)
                //{
                //    for (int col = 1; col <= 12; col++)
                //    {
                //        xlsSheet[row + j, col].Style = source[row, col].Style;
                //        xlsSheet[row + j, col].Value = source[row, col].Value;
                //    }
                //}

                //XLCellRange mrCell = new XLCellRange(22 + j, 23 + j, 1, 1);
                //xlsSheet.MergedCells.Add(mrCell);

                //mrCell = new XLCellRange(22 + j, 23 + j, 2, 2);
                //xlsSheet.MergedCells.Add(mrCell);

                //mrCell = new XLCellRange(22 + j, 23 + j, 3, 4);
                //xlsSheet.MergedCells.Add(mrCell);

                //mrCell = new XLCellRange(22 + j, 22 + j, 5, 6);
                //xlsSheet.MergedCells.Add(mrCell);

                //mrCell = new XLCellRange(22 + j, 22 + j, 7, 8);
                //xlsSheet.MergedCells.Add(mrCell);

                //mrCell = new XLCellRange(22 + j, 22 + j, 9, 10);
                //xlsSheet.MergedCells.Add(mrCell);

                //mrCell = new XLCellRange(22 + j, 22 + j, 11, 12);
                //xlsSheet.MergedCells.Add(mrCell);


                //ds = new DataSet();
                //sql = " SELECT  Service, Mount, PriceUSD, PriceVND, SumUSD, SumVND, VatUSD, VatVND, LastPriceUSD, LastPriceVND, Unit";
                //sql += " FROM    PaymentBookingService";
                //sql += " WHERE BookingId = '" + hidId.Value + "' ";

                //j = 0;
                //using (SqlCommand cm = db.CreateCommand(sql))
                //{
                //    SqlDataAdapter da = new SqlDataAdapter(cm);
                //    da.Fill(ds);

                //    if (ds != null)
                //    {
                //        DataTable dt = ds.Tables[0];
                //        foreach (DataRow rowType in dt.Rows)
                //        {
                //            if (j >= 1)
                //            {
                //                xlsSheet.Rows.Insert(19);
                //            }
                //            int tmp = 24 + j++;

                //            string Service = rowType["Service"].ToString();
                //            string Mount = rowType["Mount"].ToString();
                //            string Unit = rowType["Unit"].ToString();
                //            string PriceUSD = rowType["PriceUSD"].ToString();
                //            string PriceVND = rowType["PriceVND"].ToString();
                //            string SumUSD = rowType["SumUSD"].ToString();
                //            string SumVND = rowType["SumVND"].ToString();
                //            string VatUSD = rowType["VatUSD"].ToString();
                //            string VatVND = rowType["VatVND"].ToString();
                //            string LastPriceUSD = rowType["LastPriceUSD"].ToString();
                //            string LastPriceVND = rowType["LastPriceVND"].ToString();

                //            xlsSheet[tmp, 1].Value = Service;
                //            xlsSheet[tmp, 2].Value = Func.ParseFloat(Mount);
                //            xlsSheet[tmp, 3].Value = Unit;

                //            xlsSheet[tmp, 5].Value = Func.ParseFloat(PriceUSD);
                //            xlsSheet[tmp, 6].Value = Func.ParseFloat(PriceVND);
                //            xlsSheet[tmp, 7].Value = Func.ParseFloat(SumUSD);
                //            xlsSheet[tmp, 8].Value = Func.ParseFloat(SumVND);
                //            xlsSheet[tmp, 9].Value = Func.ParseFloat(VatUSD);
                //            xlsSheet[tmp, 10].Value = Func.ParseFloat(VatVND);
                //            xlsSheet[tmp, 11].Value = Func.ParseFloat(LastPriceUSD);
                //            xlsSheet[tmp, 12].Value = Func.ParseFloat(LastPriceVND);

                //            for (int col = 1; col <= 12; col++)
                //            {
                //                xlsSheet[tmp, col].Style = xlstStyle;
                //            }
                //        }

                //    }
                //}

                xlbBook.Save(fileNameDes);
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);
            }
        }

        //protected void btnCreate_Click(object sender, EventArgs e)
        //{
        //    ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('PaymentBillInfo.aspx?id=" + lblCustomerId.Text + "&yearmonth=" + drpYear.SelectedValue + drpMonth.SelectedValue + "',600,370,'EditPaymentBillInfo', true);", true);
        //}
        protected void btnExport_Click(object sender, EventArgs e)
        {
            ShowData(drpYear.SelectedValue + drpMonth.SelectedValue);
        }

        protected void btnRent_Click(object sender, EventArgs e)
        {
            string exchangetype = (txtRentPaidVND.Text.Equals("0")) ? "0" : "1";
            string money = (!txtRentPaidUSD.Text.Equals("0")) ? txtRentPaidUSD.Text : txtRentPaidVND.Text;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('Payment.aspx?paymenttype=1&id=" + lblCustomerId.Text + "&yearmonth=" + drpYear.SelectedValue + drpMonth.SelectedValue + "&exchangetype=" + exchangetype + "&money=" + money + "',600,370,'Payment', true);", true);
        }
        protected void btnManager_Click(object sender, EventArgs e)
        {
            string exchangetype = (txtManagerPaidVND.Text.Equals("0")) ? "0" : "1";
            string money = (!txtManagerPaidUSD.Text.Equals("0")) ? txtManagerPaidUSD.Text : txtManagerPaidVND.Text;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('Payment.aspx?paymenttype=2&id=" + lblCustomerId.Text + "&yearmonth=" + drpYear.SelectedValue + drpMonth.SelectedValue + "&exchangetype=" + exchangetype + "&money=" + money + "',600,370,'Payment', true);", true);
        }
        protected void btnParking_Click(object sender, EventArgs e)
        {
            string exchangetype = (txtParkingPaidVND.Text.Equals("0")) ? "0" : "1";
            string money = (!txtParkingPaidUSD.Text.Equals("0")) ? txtParkingPaidUSD.Text : txtParkingPaidVND.Text;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('Payment.aspx?paymenttype=3&id=" + lblCustomerId.Text + "&yearmonth=" + drpYear.SelectedValue + drpMonth.SelectedValue + "&exchangetype=" + exchangetype + "&money=" + money + "',600,370,'Payment', true);", true);
        }
        protected void btnExtraTime_Click(object sender, EventArgs e)
        {
            string exchangetype = (txtExtraTimePaidVND.Text.Equals("0")) ? "0" : "1";
            string money = (!txtExtraTimePaidUSD.Text.Equals("0")) ? txtExtraTimePaidUSD.Text : txtExtraTimePaidVND.Text;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('Payment.aspx?paymenttype=4&id=" + lblCustomerId.Text + "&yearmonth=" + drpYear.SelectedValue + drpMonth.SelectedValue + "&exchangetype=" + exchangetype + "&money=" + money + "',600,370,'Payment', true);", true);
        }
        protected void btnElec_Click(object sender, EventArgs e)
        {
            string exchangetype = (txtElecPaidVND.Text.Equals("0")) ? "0" : "1";
            string money = (!txtElecPaidUSD.Text.Equals("0")) ? txtElecPaidUSD.Text : txtElecPaidVND.Text;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('Payment.aspx?paymenttype=5&id=" + lblCustomerId.Text + "&yearmonth=" + drpYear.SelectedValue + drpMonth.SelectedValue + "&exchangetype=" + exchangetype + "&money=" + money + "',600,370,'Payment', true);", true);
        }
        protected void btnWater_Click(object sender, EventArgs e)
        {
            string exchangetype = (txtWaterPaidVND.Text.Equals("0")) ? "0" : "1";
            string money = (!txtWaterPaidUSD.Text.Equals("0")) ? txtWaterPaidUSD.Text : txtWaterPaidVND.Text;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('Payment.aspx?paymenttype=6&id=" + lblCustomerId.Text + "&yearmonth=" + drpYear.SelectedValue + drpMonth.SelectedValue + "&exchangetype=" + exchangetype + "&money=" + money + "',600,370,'Payment', true);", true);
        }
        protected void btnService_Click(object sender, EventArgs e)
        {
            string exchangetype = (txtServicePaidVND.Text.Equals("0")) ? "0" : "1";
            string money = (!txtServicePaidUSD.Text.Equals("0")) ? txtServicePaidUSD.Text : txtServicePaidVND.Text;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('Payment.aspx?paymenttype=7&id=" + lblCustomerId.Text + "&yearmonth=" + drpYear.SelectedValue + drpMonth.SelectedValue + "&exchangetype=" + exchangetype + "&money=" + money + "',600,370,'Payment', true);", true);
        }
    }
}
