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

namespace Man.Building.Room
{
    public partial class BD_MeetingRoomBookingConfirm : PageBase
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

        private string addSuccess = "Thông Tin Đặt Phòng Đã Xác Nhận Thành Công";
        private string addUnSuccess = "Thông Tin Đặt Phòng Xác Nhận Bị Lỗi";

        /// <summary>
        /// Init values
        /// </summary>
        protected override void DoInit()
        {
            try
            {
                Hashtable tmp = new Hashtable();
                for (int i = 0; i < 24; i++)
                {
                    drpHourFrom.Items.Add(new ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
                    drpHourTo.Items.Add(new ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
                }
                drpHourFrom.Items.FindByValue(DateTime.Now.AddHours(-1).ToString("hh")).Selected = true;
                drpHourTo.Items.FindByValue(DateTime.Now.AddHours(1).ToString("hh")).Selected = true;

                BD_RoomBookingData data = new BD_RoomBookingData();
                ITransaction tran = factory.GetLoadObject(data, hidId.Value);
                Execute(tran);
                if (!HasError)
                {
                    //Get Data
                    data = (BD_RoomBookingData)tran.Result;
                    lnbCustomerId.Text = data.CustomerId;

                    lblBookingDate.Text = Func.FormatDMY(data.BookingDate);
                    drpHourFrom.SelectedValue = data.BookingHourFrom.PadLeft(2, '0');
                    drpHourTo.SelectedValue = data.BookingHourTo.PadLeft(2, '0');
                    drpMinuteFrom.Value = data.BookingMinuteFrom.PadLeft(2, '0');
                    drpMinuteTo.Value = data.BookingMinuteTo.PadLeft(2, '0');

                    txtPriceVND.Text = Func.ParseString(Func.ParseDouble(data.PriceVND));
                    txtPriceUSD.Text = data.PriceUSD;
                    txtVat.Text = data.VAT;
                    chkBookingType.Checked = (data.BookingType == "1" ? true : false);

                    //txtContractNo.Text = data.ContractNo;
                    //txtRate.Text = Func.ParseString(Func.ParseDouble(data.Rate));
                    //txtRateDate.Text = data.RateDate;

                    float hour = Func.ParseInt(data.BookingHourTo) - Func.ParseInt(data.BookingHourFrom);
                    int hourOdd = Func.ParseInt(data.BookingMinuteTo) - Func.ParseInt(data.BookingMinuteFrom);
                    if (hourOdd < 0)
                    {
                        hour--;
                    }
                    else
                    {
                        hour += Func.ParseFloat(hourOdd) / 60;
                    }

                    txtComment.Text = data.Comment;

                    if ("1".Equals(data.Status))
                    {
                        btnConfirm.Visible = false;
                        btnPaid.Visible = true;
                        btnView.Visible = true;
                        lblBill.Visible = true;
                    }
                    else if ("0".Equals(data.Status))
                    {
                        btnConfirm.Visible = true;
                        btnPaid.Visible = false;
                        btnView.Visible = false;
                        lblBill.Visible = false;
                    }
                    else if ("2".Equals(data.Status))
                    {
                        btnConfirm.Visible = false;
                        btnPaid.Visible = false;
                        btnView.Visible = false;
                        lblBill.Visible = false;
                    }
                }

                BD_RoomData dataR = new BD_RoomData();
                ITransaction tranR = factory.GetLoadObject(dataR, data.RoomId);
                Execute(tranR);
                if (!HasError)
                {
                    //Get Data
                    dataR = (BD_RoomData)tranR.Result;
                    lblName.Text = dataR.Name;
                    lblComment.Text = dataR.Comment;

                    lblRegional.Text = dataR.Regional;
                    lblFloor.Text = dataR.Floor;
                    lblArea.Text = dataR.Area;

                    lblHourManagerPriceVND.Text = dataR.HourRentPriceVND;
                    lblHourManagerPriceUSD.Text = dataR.HourRentPriceUSD;
                    lblVat.Text = data.VAT;

                }

                //string sql = " SELECT sum(PriceVND*Mount+PriceVND*Mount*VAT/100) VND,sum(PriceUSD*Mount+PriceUSD*Mount*VAT/100) USD";
                //sql += " FROM [BD_RoomBookingService]";
                //sql += " WHERE (ID IS NOT NULL) and DelFlag <> 1 and BookingId = '" + hidId.Value + "'";

                //DataTable dt = DbHelper.GetDataTable(sql);
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    lblSumServiceVND.Text = Func.ParseString(dt.Rows[i]["VND"]);
                //    lblSumServiceUSD.Text = Func.ParseString(dt.Rows[i]["USD"]);
                //}
                //lblSumPriceUSD.Text = "" + (Func.ParseFloat(lblSumUSD.Text) + Func.ParseFloat(lblSumServiceUSD.Text));
                //lblSumPriceVND.Text = "" + (Func.ParseDouble(lblSumVND.Text) + Func.ParseDouble(lblSumServiceVND.Text));

                //sql = " SELECT sum(MoneyUSD) USD,sum(MoneyVND) VND ";
                //sql += " FROM [Payment]";
                //sql += " WHERE (ID IS NOT NULL) and DelFlag <> 1 and BookingId = '" + hidId.Value + "'";

                //dt = DbHelper.GetDataTable(sql);
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    lblPaidUSD.Text = Func.ParseString(dt.Rows[i]["VND"]);
                //    lblPaidVND.Text = Func.ParseString(dt.Rows[i]["USD"]);
                //}
                //txtPaidUSD.Text = "" + (Func.ParseFloat(lblSumPriceUSD.Text) - Func.ParseFloat(lblPaidUSD.Text));
                //txtPaidVND.Text = "" + (Func.ParseDouble(lblSumPriceVND.Text) - Func.ParseDouble(lblPaidVND.Text));

                //string sql = " SELECT LastPriceVND VND,LastPriceUSD USD";
                //sql += " FROM [PaymentBooking]";
                //sql += " WHERE BookingId = '" + hidId.Value + "'";

                //DataTable dt = DbHelper.GetDataTable(sql);
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    lblSumVND.Text = Func.ParseString(Func.ParseDouble(dt.Rows[i]["VND"]));
                //    lblSumUSD.Text = Func.ParseString(dt.Rows[i]["USD"]);
                //}

                ////lblSumVND.Text = Func.ParseString((long)(Func.ParseFloat(data.PriceVND) * hour) + (long)(Func.ParseFloat(data.PriceVND) * hour * Func.ParseFloat(data.VAT) / 100));
                ////lblSumUSD.Text = Func.ParseString(Func.ParseFloat(data.PriceUSD) * hour) + Func.ParseString(Func.ParseFloat(data.PriceUSD) * hour * Func.ParseFloat(data.VAT) / 100);
                //sql = " SELECT sum(LastPriceVND) VND,sum(LastPriceUSD) USD";
                //sql += " FROM [PaymentBookingService]";
                //sql += " WHERE BookingId = '" + hidId.Value + "'";

                //dt = DbHelper.GetDataTable(sql);
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    lblSumServiceVND.Text = Func.ParseString(Func.ParseFloat(dt.Rows[i]["VND"]));
                //    lblSumServiceUSD.Text = Func.ParseString(dt.Rows[i]["USD"]);
                //}

                //lblSumPriceUSD.Text = "" + (Func.ParseFloat(lblSumUSD.Text) + Func.ParseFloat(lblSumServiceUSD.Text));
                //lblSumPriceVND.Text = "" + (Func.ParseDouble(lblSumVND.Text) + Func.ParseDouble(lblSumServiceVND.Text));

                //sql = " SELECT sum(MoneyUSD) USD,sum(MoneyVND) VND ";
                //sql += " FROM [Payment]";
                //sql += " WHERE (ID IS NOT NULL) and DelFlag <> 1 and BookingId = '" + hidId.Value + "'";

                //dt = DbHelper.GetDataTable(sql);
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    lblPaidUSD.Text = Func.ParseString(Func.ParseFloat(dt.Rows[i]["USD"]));
                //    lblPaidVND.Text = Func.ParseString(Func.ParseDouble(dt.Rows[i]["VND"]));
                //}
                //txtPaidUSD.Text = "" + (Func.ParseFloat(lblSumPriceUSD.Text) - Func.ParseFloat(lblPaidUSD.Text));
                //txtPaidVND.Text = "" + (Func.ParseDouble(lblSumPriceVND.Text) - Func.ParseDouble(lblPaidVND.Text));
                ShowData();

                string tmpPaid = DbHelper.GetScalar("Select count(*) from Payment Where BookingId = '" + hidId.Value + "' and DelFlag = '0' and PaymentType = '8'");
                if ("1".Equals(tmpPaid))
                {
                    //btnPaid.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            //return tmp;
        }
        /// <summary>
        /// Init values
        /// </summary>
        protected void btnCal_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection rConn = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                {
                    rConn.Open();
                    using (SqlCommand command = new SqlCommand("sp_PaymentBooking", rConn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@BookingId", hidId.Value));
                        command.ExecuteNonQuery();
                    }
                    rConn.Close();
                }

                string sql = " SELECT LastPriceVND VND,LastPriceUSD USD";
                sql += " FROM [PaymentBooking]";
                sql += " WHERE BookingId = '" + hidId.Value + "'";

                DataTable dt = DbHelper.GetDataTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lblSumVND.Text = Func.ParseString(Func.ParseFloat(dt.Rows[i]["VND"]));
                    lblSumUSD.Text = Func.ParseString(dt.Rows[i]["USD"]);
                }

                //lblSumVND.Text = Func.ParseString((long)(Func.ParseFloat(data.PriceVND) * hour) + (long)(Func.ParseFloat(data.PriceVND) * hour * Func.ParseFloat(data.VAT) / 100));
                //lblSumUSD.Text = Func.ParseString(Func.ParseFloat(data.PriceUSD) * hour) + Func.ParseString(Func.ParseFloat(data.PriceUSD) * hour * Func.ParseFloat(data.VAT) / 100);
                sql = " SELECT sum(LastPriceVND) VND,sum(LastPriceUSD) USD";
                sql += " FROM [PaymentBookingService]";
                sql += " WHERE BookingId = '" + hidId.Value + "'";

                dt = DbHelper.GetDataTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lblSumServiceVND.Text = Func.ParseString(Func.ParseFloat(dt.Rows[i]["VND"]));
                    lblSumServiceUSD.Text = Func.ParseString(dt.Rows[i]["USD"]);
                }

                lblSumPriceUSD.Text = "" + (Func.ParseFloat(lblSumUSD.Text) + Func.ParseFloat(lblSumServiceUSD.Text));
                lblSumPriceVND.Text = "" + (Func.ParseDouble(lblSumVND.Text) + Func.ParseDouble(lblSumServiceVND.Text));

                sql = " SELECT sum(MoneyUSD) USD,sum(MoneyVND) VND ";
                sql += " FROM [Payment]";
                sql += " WHERE (ID IS NOT NULL) and DelFlag <> 1 and BookingId = '" + hidId.Value + "'";

                dt = DbHelper.GetDataTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lblPaidUSD.Text = Func.ParseString(dt.Rows[i]["USD"]);
                    lblPaidVND.Text = Func.ParseString(dt.Rows[i]["VND"]);
                }
                txtPaidUSD.Text = "" + (Func.ParseFloat(lblSumPriceUSD.Text) - Func.ParseFloat(lblPaidUSD.Text));
                txtPaidVND.Text = "" + (Func.ParseDouble(lblSumPriceVND.Text) - Func.ParseDouble(lblPaidVND.Text));
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            //return tmp;
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
                hidId.Value = Func.ParseString(Request["id"]);

                string sql = " SELECT *,LastPriceVND VND,LastPriceUSD USD , ServiceLastPriceUSD A, ServiceLastPriceVND B";
                sql += " FROM [PaymentBooking]";
                sql += " WHERE BookingId = '" + hidId.Value + "'";

                DataTable dt = DbHelper.GetDataTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lblSumVND.Text = Func.ParseString(Func.ParseFloat(dt.Rows[i]["VND"]));
                    lblSumUSD.Text = Func.ParseString(dt.Rows[i]["USD"]);

                    lblSumServiceVND.Text = Func.ParseString(Func.ParseFloat(dt.Rows[i]["B"]));
                    lblSumServiceUSD.Text = Func.ParseString(dt.Rows[i]["A"]);

                    txtContractDate.Text = Func.FormatDMY(dt.Rows[i]["ContractDate"]);
                    txtContractNo.Text = Func.ParseString(dt.Rows[i]["ContractNo"]);
                    txtRate.Text = Func.FormatNumber_New(dt.Rows[i]["Rate"]);
                    txtRateDate.Text = Func.FormatDMY(dt.Rows[i]["RateDate"]);
                }

                lblSumPriceUSD.Text = "" + (Convert.ToDecimal(lblSumUSD.Text) + Convert.ToDecimal(lblSumServiceUSD.Text == "" ? "0" : lblSumServiceUSD.Text));
                lblSumPriceVND.Text = "" + (Convert.ToDecimal(lblSumVND.Text) + Convert.ToDecimal(lblSumServiceVND.Text == "" ? "0" : lblSumServiceVND.Text));

                sql = " SELECT sum(isnull(MoneyUSD,0)) USD,sum(isnull(MoneyVND,0)) VND ";
                sql += " FROM [Payment]";
                sql += " WHERE (ID IS NOT NULL) and DelFlag <> 1 and BookingId = '" + hidId.Value + "'";

                dt = DbHelper.GetDataTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lblPaidUSD.Text = Func.ParseString(dt.Rows[i]["USD"]);
                    lblPaidVND.Text = Func.ParseString(dt.Rows[i]["VND"]);
                }
                txtPaidUSD.Text = "" + (Convert.ToDecimal(lblSumPriceUSD.Text) - Convert.ToDecimal(lblPaidUSD.Text == "" ? "0" : lblPaidUSD.Text));
                txtPaidVND.Text = "" + (Convert.ToDecimal(lblSumPriceVND.Text) - Convert.ToDecimal(lblPaidVND.Text == "" ? "0" : lblPaidVND.Text));
            }

            lblSumVND.Text = Func.FormatNumber_New(lblSumVND.Text);
            lblSumUSD.Text = Func.FormatNumber_New(lblSumUSD.Text);

            lblSumServiceVND.Text = Func.FormatNumber_New(lblSumServiceVND.Text);
            lblSumServiceUSD.Text = Func.FormatNumber_New(lblSumServiceUSD.Text);

            lblSumPriceUSD.Text = Func.FormatNumber_New(lblSumPriceUSD.Text);
            lblSumPriceVND.Text = Func.FormatNumber_New(lblSumPriceVND.Text);


            lblPaidUSD.Text = Func.FormatNumber_New(lblPaidUSD.Text);
            lblPaidVND.Text = Func.FormatNumber_New(lblPaidVND.Text);
            txtPaidUSD.Text = Func.FormatNumber_New(txtPaidUSD.Text);
            txtPaidVND.Text = Func.FormatNumber_New(txtPaidVND.Text);

        }


        protected void btnPaid_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('AllPayRoomBooking.aspx?CustomerId=" + lnbCustomerId.Text + "&id=" + hidId.Value + "',1020,600,'PaymentBooking', true);", true);
        }

        protected void btnAutoContractNo_Click(object sender, EventArgs e)
        {
            BD_RoomBookingServiceData data = new BD_RoomBookingServiceData();

            string prefix = Func.ParseString(Session["__BUILDINGID__"]) + "M";
            int length = 10;
            string tmp = String.Format("", length);

            string sql = "SELECT max(maxid) from (SELECT SUBSTRING(ContractNo, " + (prefix.Length + 1) + ", " + length + ") as maxid FROM BD_RoomBookingService where SUBSTRING(ContractNo, 1, 7) = '" + prefix + "') as tmp WHERE maxid < '100'";


            int key = 0;
            try
            {
                key = Convert.ToInt32(DbHelper.GetScalar(sql));
                key++;
            }
            catch
            {
                key = 1;
            }

            bool keyFlg = true;
            while (keyFlg)
            {
                string tmpKey = prefix + key.ToString().PadLeft(length - prefix.Length, '0');
                sql = "SELECT count(*) from BD_RoomBooking WHERE ContractNo = '" + tmpKey + "'";
                if (Convert.ToInt32(DbHelper.GetScalar(sql)) != 1)
                {
                    keyFlg = false;
                }
                else
                {
                    key--;
                }
            }
            //txtContractNo.Text = prefix + key.ToString().PadLeft(length - prefix.Length, '0');
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            mvMessage.CheckRequired(txtContractDate, "Ngày xuất HĐ : Danh mục phải nhập");
            mvMessage.CheckRequired(txtContractNo, "Hợp đồng số : Danh mục phải nhập");
            mvMessage.CheckRequired(txtRate, "Tỉ giá quy đổi USD->VND : Danh mục phải nhập");
            mvMessage.CheckRequired(txtRateDate, "Thời gian quy đổi: Danh mục phải nhập");
            //mvMessage.CheckRequired(txtPaymenter, " Đại diện Khách Hàng : Danh mục phải nhập");
            //mvMessage.CheckRequired(txtReceiver, "Đại diện Tòa nhà : Danh mục phải nhập");

            int from = Func.ParseInt(drpHourFrom.SelectedValue + drpMinuteFrom.Value);
            int to = Func.ParseInt(drpHourTo.SelectedValue + drpMinuteTo.Value);

            if (from >= to)
            {
                mvMessage.AddError("Thời gian đặt phòng không hợp lệ");
                return;
            }

            if (!mvMessage.IsValid) return;
            //Get and Insert Data
            BD_RoomBookingData data = new BD_RoomBookingData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_RoomBookingData)tran.Result;

                data.BookingDate = Func.FormatYYYYmmdd(lblBookingDate.Text.Trim());
                data.BookingHourFrom = drpHourFrom.SelectedValue;
                data.BookingHourTo = drpHourTo.SelectedValue;

                data.BookingMinuteFrom = drpMinuteFrom.Value;
                data.BookingMinuteTo = drpMinuteTo.Value;

                data.RentHourFrom = drpHourFrom.SelectedValue;
                data.RentHourTo = drpHourTo.SelectedValue;

                data.RentMinuteFrom = drpMinuteFrom.Value;
                data.RentMinuteTo = drpMinuteTo.Value;

                data.PriceVND = txtPriceVND.Text.Trim().Replace(".", "").Replace(",", ".");
                data.PriceUSD = txtPriceUSD.Text.Trim().Replace(".", "").Replace(",", ".");

                data.Status = "1";//2 la Huy; 0 la dat; 1 là OK

                float hour = Func.ParseInt(data.BookingHourTo) - Func.ParseInt(data.BookingHourFrom);
                int hourOdd = Func.ParseInt(data.BookingMinuteTo) - Func.ParseInt(data.BookingMinuteFrom);
                if (hourOdd < 0)
                {
                    hour--;
                }
                else
                {
                    hour += Func.ParseFloat(hourOdd) / 60;
                }

                data.Hour = Func.ParseString(hour).Replace(".", "").Replace(",", ".");
                data.Comment = txtComment.Text.Trim();
                data.VAT = txtVat.Text.Trim().Replace(".", "").Replace(",", ".");
                data.HourExtraPriceUSD = "0";
                data.HourExtraPriceVND = "0";

                data.ModifiedBy = Page.User.Identity.Name;
                data.CreatedBy = Page.User.Identity.Name;
                data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag = "0";

                data.OtherFee01 = "0";
                data.OtherFee02 = "0";

                data.ContractDate = Func.FormatYYYYmmdd(txtContractDate.Text.Trim());
                data.ContractNo = txtContractNo.Text;
                data.Rate = txtRate.Text.Replace(".", "").Replace(",", ".");
                data.RateDate = Func.FormatYYYYmmdd(txtRateDate.Text.Trim());

                tran = factory.GetUpdateObject(data);
                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(addSuccess);

                    btnConfirm.Visible = false;
                    btnDelete.Visible = false;
                    btnView.Visible = true;
                    btnPaid.Visible = true;
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(addUnSuccess);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BD_RoomBookingData data = new BD_RoomBookingData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_RoomBookingData)tran.Result;

                data.PriceVND = txtPriceVND.Text.Trim().Replace(".", "").Replace(",", ".");
                data.PriceUSD = txtPriceUSD.Text.Trim().Replace(".", "").Replace(",", ".");

                data.Status = "2";//2 la Huy; 0 la dat; 1 là OK

                data.Hour = data.Hour.Replace(".", "").Replace(",", ".");
                data.Comment = txtComment.Text.Trim();
                data.VAT = txtVat.Text.Trim().Replace(".", "").Replace(",", ".");
                data.HourExtraPriceUSD = "0";
                data.HourExtraPriceVND = "0";

                data.ModifiedBy = Page.User.Identity.Name;
                data.CreatedBy = Page.User.Identity.Name;
                data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag = "1";

                data.OtherFee01 = "0";
                data.OtherFee02 = "0";

                data.Rate = data.Rate.Replace(".", "").Replace(",", ".");

                tran = factory.GetUpdateObject(data);
                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(addSuccess);

                    btnConfirm.Visible = false;
                    btnDelete.Visible = false;
                    btnView.Visible = false;
                    btnPaid.Visible = false;
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(addUnSuccess);
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
                    string ID = Func.ParseString(row["ID"]);
                    string Service = Func.ParseString(row["Service"]);
                    string Mount = Func.ParseString(row["Mount"]);

                    string PriceVND = Func.ParseString(row["PriceVND"]);
                    string PriceUSD = Func.ParseString(row["PriceUSD"]);
                    string VAT = Func.ParseString(row["VAT"]);

                    string Comment = Func.ParseString(row["Comment"]);

                    string sumVND = Func.ParseString(row["LastPriceVND"]);
                    string sumUSD = Func.ParseString(row["LastPriceUSD"]);

                    Func.SetGridTextValue(item, "ltrService", Service);
                    Func.SetGridTextValue(item, "ltrMount", Func.FormatNumber_New(Mount));
                    Func.SetGridTextValue(item, "ltrVAT", Func.FormatNumber_New(VAT));

                    Func.SetGridTextValue(item, "ltrPriceVND", Func.FormatNumber_New(PriceVND));
                    Func.SetGridTextValue(item, "ltrPriceUSD", Func.FormatNumber_New(PriceUSD));

                    Func.SetGridTextValue(item, "ltrSumVND", Func.FormatNumber_New(sumVND));
                    Func.SetGridTextValue(item, "ltrSumUSD", Func.FormatNumber_New(sumUSD));

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
                ListSortDirection = SortDirection.Ascending;
            }
            try
            {
                //Đếm số lượng record
                sql += " SELECT COUNT(ID) ";
                sql += " FROM [PaymentBookingService]";
                sql += " WHERE (ID IS NOT NULL) and (DelFlag = 0 or DelFlag is null) and BookingId = '" + hidId.Value + "'";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " SELECT *,ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM [PaymentBookingService]";
                sql += " WHERE (ID IS NOT NULL) and (DelFlag = 0 or DelFlag is null) and BookingId = '" + hidId.Value + "'";

                //Phân trang
                //sql = " SELECT * FROM (" + sql + ") AS TMP ";
                //sql += " WHERE RowNum BETWEEN @PageIndex*@PageSize + 1  AND (@PageIndex+1)*@PageSize ORDER BY RowNum ";

                //Thực hiện câu SQL

                SqlCommand cm = db.CreateCommand(sql);
                //cm.Parameters.AddWithValue("@PageIndex", pager.CurrentPageIndex);
                //cm.Parameters.AddWithValue("@PageSize", pager.PageSize);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataSet ds = new DataSet();
                da.Fill(ds);
                db.Close();
                rptList.DataSource = ds.Tables[0].DefaultView;
                rptList.DataBind();
                //pager.Count = count;
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
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
                //pager.CurrentPageIndex = 0;
            }
            else if (command.Equals("Delete"))
            {
                //DeleteData(Func.ParseString(e.CommandArgument));
            }
            ShowData();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            mvMessage.CheckRequired(txtContractDate, "Ngày xuất HĐ : Danh mục phải nhập");
            mvMessage.CheckRequired(txtContractNo, "Hợp đồng số : Danh mục phải nhập");
            mvMessage.CheckRequired(txtRate, "Tỉ giá quy đổi USD->VND : Danh mục phải nhập");
            mvMessage.CheckRequired(txtRateDate, "Thời gian quy đổi: Danh mục phải nhập");
            if (!mvMessage.IsValid) return;

            C1XLBook xlbBook = new C1XLBook();
            string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\BillPhongHop.xlsx");
            if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BillPhongHop"))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BillPhongHop"));
            }

            decimal[] LastSumPriceVND = { 0, 0, 0 };
            decimal[] LastSumPriceUSD = { 0, 0, 0 };

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

            XLStyle xlstStyleSum = new XLStyle(xlbBook);
            xlstStyleSum.AlignHorz = XLAlignHorzEnum.Right;
            xlstStyleSum.AlignVert = XLAlignVertEnum.Center;
            xlstStyleSum.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            xlstStyleSum.SetBorderColor(Color.Black);
            xlstStyleSum.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleSum.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleSum.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleSum.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleSum.WordWrap = true;
            xlstStyleSum.Format = "#,##0.00_);(#,##0.00)";

            string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"BillPhongHop\BillPhongHop" + "_" + lnbCustomerId.Text + "_" + strDT + ".xlsx";
            string strFilePathExport = @"../../Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + "/BillPhongHop/BillPhongHop" + "_" + lnbCustomerId.Text + "_" + strDT + ".xlsx";

            string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

            //string fileNameDes = HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\TongHopDienTich" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx");
            File.Copy(fileName, fileNameDes);

            xlbBook.Load(fileNameDes);
            XLSheet xlsSheet = xlbBook.Sheets["HoaDon"];

            int k = 2;
            xlsSheet[1, 6 + k].Value = xlsSheet[1, 6 + k].Value.ToString().Replace("{%NGAY%}", DateTime.Today.ToString("dd"));
            xlsSheet[1, 6 + k].Value = xlsSheet[1, 6 + k].Value.ToString().Replace("{%THANG%}", DateTime.Today.ToString("MM"));
            xlsSheet[1, 6 + k].Value = xlsSheet[1, 6 + k].Value.ToString().Replace("{%NAM%}", DateTime.Today.ToString("yyyy"));

            using (SqlDatabase db = new SqlDatabase())
            {
                DataSet ds = new DataSet();
                string sql = string.Empty;

                sql = " SELECT Name, ContactName";
                sql += " FROM Customer";
                sql += " WHERE CustomerId = '" + lnbCustomerId.Text + "' ";

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

                            xlsSheet[9, 0].Value = xlsSheet[9, 0].Value.ToString().Replace("{%NGAY_HOP_DONG%}", lblBookingDate.Text).Replace("{%HOP_DONG%}", txtContractNo.Text);

                            xlsSheet[11, 0].Value = xlsSheet[11, 0].Value.ToString().Replace("{%GIO_TU%}", drpHourFrom.SelectedValue);
                            xlsSheet[11, 0].Value = xlsSheet[11, 0].Value.ToString().Replace("{%PHUT_TU%}", drpMinuteFrom.Value);
                            xlsSheet[11, 0].Value = xlsSheet[11, 0].Value.ToString().Replace("{%GIO_DEN%}", drpHourTo.SelectedValue);
                            xlsSheet[11, 0].Value = xlsSheet[11, 0].Value.ToString().Replace("{%PHUT_DEN%}", drpMinuteTo.Value);
                            xlsSheet[11, 0].Value = xlsSheet[11, 0].Value.ToString().Replace("{%NGAY_THUE%}", lblBookingDate.Text);
                        }
                    }
                }

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

                            xlsSheet[35, 0].Value = xlsSheet[35, 0].Value.ToString().Replace("{%VAN_PHONG%}", Office);
                            xlsSheet[36, 0].Value = xlsSheet[36, 0].Value.ToString().Replace("{%DIEN_THOAI%}", OfficePhone);

                            xlsSheet[38, 0].Value = xlsSheet[38, 0].Value.ToString().Replace("{%NGAN_HANG%}", Bank);
                            xlsSheet[39, 0].Value = xlsSheet[39, 0].Value.ToString().Replace("{%TEN_TAI_KHOAN%}", AccountName);
                            xlsSheet[40, 0].Value = xlsSheet[40, 0].Value.ToString().Replace("{%SO_TAI_KHOAN%}", Account);
                        }
                    }
                }
                XLCellRange mrCell = new XLCellRange(0, 0, 0, 0);


                xlsSheet[27, 0].Value = xlsSheet[27, 0].Value.ToString().Replace("{%TI_GIA%}", Func.FormatNumber_New(txtRate.Text)).Replace("{%NGAY_AP_DUNG%}", txtRateDate.Text.Substring(0, 10));

                ds = new DataSet();
                sql = " SELECT *";
                sql += " FROM v_BookingRoomInfo";
                sql += " WHERE BookingId = '" + hidId.Value + "' ";

                int j = 0;
                int count = 0;
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);

                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            if (count >= 1)
                            {
                                xlsSheet.Rows.Insert(18 + 1 + j);
                                j++;
                            }
                            count++;
                            int tmp = 18 + j;

                            string Name = rowType["Name"].ToString();
                            string Regional = rowType["Regional"].ToString();
                            string Floor = rowType["Floor"].ToString();
                            string Area = rowType["Area"].ToString();
                            string PriceUSD = rowType["PriceUSD"].ToString();
                            string PriceVND = rowType["PriceVND"].ToString();
                            string SumUSD = rowType["SumUSD"].ToString();
                            string SumVND = rowType["SumVND"].ToString();
                            string VatUSD = rowType["VatUSD"].ToString();
                            string VatVND = rowType["VatVND"].ToString();
                            string LastPriceUSD = rowType["LastPriceUSD"].ToString();
                            string LastPriceVND = rowType["LastPriceVND"].ToString();
                            string BookingId = rowType["BookingId"].ToString();

                            xlsSheet[tmp, 1].Value = Name;
                            xlsSheet[tmp, 2].Value = Regional;
                            xlsSheet[tmp, 3].Value = Floor;
                            xlsSheet[tmp, 4].Value = rowType["Area"];
                            xlsSheet[tmp, 5].Value = rowType["PriceUSD"];
                            xlsSheet[tmp, 6].Value = rowType["PriceVND"];
                            xlsSheet[tmp, 7].Value = rowType["SumUSD"];
                            xlsSheet[tmp, 8].Value = rowType["SumVND"];
                            xlsSheet[tmp, 9].Value = rowType["VatUSD"];
                            xlsSheet[tmp, 10].Value = rowType["VatVND"];
                            xlsSheet[tmp, 11].Value = rowType["LastPriceUSD"];
                            xlsSheet[tmp, 12].Value = rowType["LastPriceVND"];

                            LastSumPriceVND[0] += Convert.ToDecimal(rowType["LastPriceVND"]);
                            LastSumPriceUSD[0] += Convert.ToDecimal(rowType["LastPriceUSD"]);

                            for (int col = 1; col <= 12; col++)
                            {
                                xlsSheet[tmp, col].Style = xlstStyle;
                            }
                        }
                        mrCell = new XLCellRange(18 + 1 + j, 18 + 1 + j, 1, 10);
                        xlsSheet.MergedCells.Add(mrCell);

                        xlsSheet[18 + 1 + j, 11].Value = LastSumPriceUSD[0];
                        xlsSheet[18 + 1 + j, 12].Value = LastSumPriceVND[0];

                        for (int col = 1; col <= 12; col++)
                        {
                            xlsSheet[18 + 1 + j, col].Style = xlstStyleSum;
                        }
                    }
                }
                XLSheet source = xlbBook.Sheets["tpl"];

                for (int row = 21; row <= 25; row++)
                {
                    for (int col = 0; col <= 12; col++)
                    {
                        xlsSheet[row + j, col].Style = source[row, col].Style;
                        xlsSheet[row + j, col].Value = source[row, col].Value;
                    }
                }

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


                ds = new DataSet();
                sql = " SELECT  Service, Mount, PriceUSD, PriceVND, SumUSD, SumVND, VatUSD, VatVND, LastPriceUSD, LastPriceVND, Unit";
                sql += " FROM    PaymentBookingService";
                sql += " WHERE BookingId = '" + hidId.Value + "' and (Delflag is null or Delflag = 0)";

                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);

                    if (ds != null)
                    {
                        count = 0;
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            if (count >= 1)
                            {
                                xlsSheet.Rows.Insert(24 + 1 + j);
                                j++;
                            }
                            count++;
                            int tmp = 24 + j;

                            string Service = rowType["Service"].ToString();
                            string Mount = rowType["Mount"].ToString();
                            string Unit = rowType["Unit"].ToString();
                            string PriceUSD = rowType["PriceUSD"].ToString();
                            string PriceVND = rowType["PriceVND"].ToString();
                            string SumUSD = rowType["SumUSD"].ToString();
                            string SumVND = rowType["SumVND"].ToString();
                            string VatUSD = rowType["VatUSD"].ToString();
                            string VatVND = rowType["VatVND"].ToString();
                            string LastPriceUSD = rowType["LastPriceUSD"].ToString();
                            string LastPriceVND = rowType["LastPriceVND"].ToString();

                            xlsSheet[tmp, 1].Value = Service;
                            xlsSheet[tmp, 2].Value = rowType["Mount"];
                            xlsSheet[tmp, 3].Value = Unit;

                            mrCell = new XLCellRange(tmp, tmp, 3, 4);
                            xlsSheet.MergedCells.Add(mrCell);

                            xlsSheet[tmp, 5].Value = rowType["PriceUSD"];
                            xlsSheet[tmp, 6].Value = rowType["PriceVND"];
                            xlsSheet[tmp, 7].Value = rowType["SumUSD"];
                            xlsSheet[tmp, 8].Value = rowType["SumVND"];
                            xlsSheet[tmp, 9].Value = rowType["VatUSD"];
                            xlsSheet[tmp, 10].Value = rowType["VatVND"];
                            xlsSheet[tmp, 11].Value = rowType["LastPriceUSD"];
                            xlsSheet[tmp, 12].Value = rowType["LastPriceVND"];

                            LastSumPriceVND[1] += Convert.ToDecimal(rowType["LastPriceVND"]);
                            LastSumPriceUSD[1] += Convert.ToDecimal(rowType["LastPriceUSD"]);

                            for (int col = 1; col <= 12; col++)
                            {
                                xlsSheet[tmp, col].Style = xlstStyle;
                            }
                        }
                        mrCell = new XLCellRange(24 + 1 + j, 24 + 1 + j, 1, 10);
                        xlsSheet.MergedCells.Add(mrCell);

                        xlsSheet[24 + 1 + j, 11].Value = LastSumPriceUSD[1];
                        xlsSheet[24 + 1 + j, 12].Value = LastSumPriceVND[1];

                        for (int col = 1; col <= 12; col++)
                        {
                            xlsSheet[24 + 1 + j, col].Style = xlstStyleSum;
                        }
                    }
                }


                //////////////////Da Tra
                ds = new DataSet();
                sql = " SELECT  Sum(isnull(MoneyUSD,0)) USD, Sum(isnull(MoneyVND,0)) VND";
                sql += " FROM    Payment";
                sql += " WHERE BookingId = '" + hidId.Value + "' and (Delflag is null or Delflag = 0)";

                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);

                    if (ds != null)
                    {
                        count = 0;
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            int tmp = 29 + j;

                            xlsSheet[tmp, 2].Value = (Func.ParseString(rowType["USD"]) == "" ? 0 : rowType["USD"]);
                            xlsSheet[tmp, 4].Value = (Func.ParseString(rowType["VND"]) == "" ? 0 : rowType["VND"]);

                            LastSumPriceVND[2] += Convert.ToDecimal(Func.ParseString(rowType["VND"]) == "" ? 0 : rowType["VND"]);
                            LastSumPriceUSD[2] += Convert.ToDecimal(Func.ParseString(rowType["USD"]) == "" ? 0 : rowType["USD"]);

                        }
                    }
                }
                //////////////////Da Tra

                xlsSheet[28 + j, 2].Value = Func.FormatNumber_New(LastSumPriceUSD[0] + LastSumPriceUSD[1]);
                xlsSheet[28 + j, 4].Value = Func.FormatNumber_New(LastSumPriceVND[0] + LastSumPriceVND[1]);

                xlsSheet[30 + j, 2].Value = Func.FormatNumber_New(Convert.ToDecimal(txtRate.Text) * (LastSumPriceUSD[0] + LastSumPriceUSD[1] - LastSumPriceUSD[2]));
                xlsSheet[30 + j, 4].Value = Func.FormatNumber_New(LastSumPriceVND[0] + LastSumPriceVND[1] - LastSumPriceVND[2]);

                xlsSheet[31 + j, 3].Value = Func.FormatNumber_New(Convert.ToDecimal(txtRate.Text) * (LastSumPriceUSD[0] + LastSumPriceUSD[1] - LastSumPriceUSD[2]) + (LastSumPriceVND[0] + LastSumPriceVND[1] - LastSumPriceVND[2]));
                xlsSheet[32 + j, 2].Value = Func.docso(Convert.ToInt32(Convert.ToDecimal(txtRate.Text) * (LastSumPriceUSD[0] + LastSumPriceUSD[1] - LastSumPriceUSD[2]) + (LastSumPriceVND[0] + LastSumPriceVND[1] - LastSumPriceVND[2]))).ToUpper();

                //xlsSheet[28 + j, 2].Style = xlstStyleSum;
                //xlsSheet[28 + j, 4].Style = xlstStyleSum;

                //xlsSheet[30 + j, 2].Style = xlstStyleSum;
                //xlsSheet[30 + j, 4].Style = xlstStyleSum;

                //xlsSheet[31 + j, 3].Style = xlstStyleSum;


                xlbBook.Save(fileNameDes);
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);
            }
        }
    }
}

