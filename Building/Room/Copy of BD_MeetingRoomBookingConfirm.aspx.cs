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

        private string addSuccess = "Thêm Mới Thành Công";
        private string addUnSuccess = "Thêm Mới Không Thành Công";

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

                    txtContractNo.Text = data.ContractNo;
                    txtRate.Text = Func.ParseString(Func.ParseDouble(data.Rate));
                    txtRateDate.Text = data.RateDate;

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

                    //lblSumVND.Text = Func.ParseString((long)(Func.ParseFloat(data.PriceVND) * hour) + (long)(Func.ParseFloat(data.PriceVND) * hour * Func.ParseFloat(data.VAT) / 100));
                    //lblSumUSD.Text = Func.ParseString(Func.ParseFloat(data.PriceUSD) * hour) + Func.ParseString(Func.ParseFloat(data.PriceUSD) * hour * Func.ParseFloat(data.VAT) / 100);
                    txtComment.Text = data.Comment;

                    if ("1".Equals(data.Status))
                    {
                        btnConfirm.Visible = false;
                        divPaid.Visible = true;
                    }
                    else
                    {
                        divPaid.Visible = false;
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

                string sql = " SELECT LastPriceVND VND,LastPriceUSD USD";
                sql += " FROM [PaymentBooking]";
                sql += " WHERE BookingId = '" + hidId.Value + "'";

                DataTable dt = DbHelper.GetDataTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lblSumVND.Text = Func.ParseString(Func.ParseDouble(dt.Rows[i]["VND"]));
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
                    lblPaidUSD.Text = Func.ParseString(Func.ParseFloat(dt.Rows[i]["USD"]));
                    lblPaidVND.Text = Func.ParseString(Func.ParseDouble(dt.Rows[i]["VND"]));
                }
                txtPaidUSD.Text = "" + (Func.ParseFloat(lblSumPriceUSD.Text) - Func.ParseFloat(lblPaidUSD.Text));
                txtPaidVND.Text = "" + (Func.ParseDouble(lblSumPriceVND.Text) - Func.ParseDouble(lblPaidVND.Text));
                ShowData();

                string tmpPaid = DbHelper.GetScalar("Select count(*) from Payment Where BookingId = '" + hidId.Value + "' and DelFlag = '0' and PaymentType = '8'");
                if ("1".Equals(tmpPaid))
                {
                    btnPaid.Visible = false;
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

                PopupWidth = 600;
                PopupHeight = 450;
            }
        }

        protected void btnPaid_Click(object sender, EventArgs e)
        {

            //string exchangetype = (rdoUSD.Checked == true) ? "0" : "1";
            //string money = (rdoUSD.Checked == true) ? txtPaidUSD.Text : txtPaidVND.Text;
            //ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('../../Customer/PaymentBooking.aspx?paymenttype=8&id=" + lnbCustomerId.Text + "&yearmonth=" + Func.FormatYYYYmmdd(lblBookingDate.Text).Substring(0, 6) + "&exchangetype=" + exchangetype + "&money=" + money + "&bookingid=" + hidId.Value + "',600,600,'PaymentBooking', true);", true);
            try
            {
                BD_RoomBookingData data = new BD_RoomBookingData();
                ITransaction tran = factory.GetLoadObject(data, hidId.Value);
                Execute(tran);
                if (!HasError)
                {
                    //Get Data
                    data = (BD_RoomBookingData)tran.Result;

                    data.ContractNo = txtContractNo.Text.Trim();
                    data.Rate = txtRate.Text.Trim();
                    data.RateDate = Func.Formatymdhms(txtRateDate.Text);
                    data.PaidMoneyType = rdoUSD.Checked == true ? "0" : "1";

                    data.ModifiedBy = Page.User.Identity.Name;
                    data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");

                    tran = factory.GetUpdateObject(data);
                    Execute(tran);

                    if (!HasError)
                    {
                        OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                        mvMessage.SetCompleteMessage(addSuccess);
                    }
                    else
                    {
                        OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                        mvMessage.AddError(addUnSuccess);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            try
            {
                PaymentData data = new PaymentData();
                ITransaction tran = factory.GetInsertObject(data);
                data.ModifiedBy = Page.User.Identity.Name;
                data.CreatedBy = Page.User.Identity.Name;
                data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag = "0";

                data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);
                data.CustomerId = lnbCustomerId.Text;
                data.PaymentDate = Func.FormatYYYYmmdd(txtContractDate.Text.Trim().Substring(0, 10));
                data.YearMonth = data.PaymentDate.Substring(0, 6);
                data.PaymentType = "8";
                data.PaidType = rdoUSD.Checked == true ? "0" : "1";
                data.Paymenter = txtPaymenter.Text.Trim();
                data.Receiver = txtReceiver.Text.Trim();
                data.MoneyUSD = (rdoUSD.Checked == true) ? txtPriceUSD.Text.Replace(",", ".") : "0";
                data.MoneyVND = (rdoVND.Checked == true) ? txtPriceVND.Text.Replace(".", "") : "0";
                data.Comment = txtComment.Text.Trim();
                data.BookingId = hidId.Value;

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(addSuccess);
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(addUnSuccess);
                }
            }
            catch (Exception ex)
            { }
        }
        //protected void btnView_Click(object sender, EventArgs e)
        //{

        //    string exchangetype = (rdoUSD.Checked == true) ? "0" : "1";
        //    string money = (rdoUSD.Checked == true) ? txtPaidUSD.Text : txtPaidVND.Text;
        //    ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('../../Customer/PaymentBooking.aspx?paymenttype=8&id=" + lnbCustomerId.Text + "&yearmonth=" + Func.FormatYYYYmmdd(lblBookingDate.Text).Substring(0, 6) + "&exchangetype=" + exchangetype + "&money=" + money + "&bookingid=" + hidId.Value + "',600,600,'PaymentBooking', true);", true);
        //}
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
            txtContractNo.Text = prefix + key.ToString().PadLeft(length - prefix.Length, '0');
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            mvMessage.CheckRequired(txtPriceVND, "Phí thuê(giờ)(VND): Danh mục phải nhập");
            mvMessage.CheckRequired(txtPriceUSD, "Phí thuê(giờ)(USD): Danh mục phải nhập");

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

                data.PriceVND = txtPriceVND.Text.Trim().Replace(',', '.');
                data.PriceUSD = txtPriceUSD.Text.Trim().Replace(',', '.');

                data.Status = "1";//2 la Huy; 0 la dat.

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

                data.Hour = Func.ParseString(hour);
                data.Comment = txtComment.Text.Trim();
                data.VAT = txtVat.Text.Trim();

                data.ModifiedBy = Page.User.Identity.Name;
                data.CreatedBy = Page.User.Identity.Name;
                data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag = "0";

                tran = factory.GetUpdateObject(data);
                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(addSuccess);
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

                    string sumVND = Func.ParseString(row["sumVND"]);
                    string sumUSD = Func.ParseString(row["sumUSD"]);

                    Func.SetGridTextValue(item, "ltrService", Service);
                    Func.SetGridTextValue(item, "ltrMount", Mount);

                    Func.SetGridTextValue(item, "ltrPriceVND", Func.FormatNumber(PriceVND));
                    Func.SetGridTextValue(item, "ltrPriceUSD", PriceUSD);

                    //string SumVND = Func.ParseString((long)(Func.ParseInt(Mount) * Func.ParseInt(PriceVND) + Func.ParseInt(Mount) * Func.ParseInt(PriceVND) * Func.ParseInt(VAT) / 100));
                    //string SumUSD = Func.ParseString((float)(Func.ParseInt(Mount) * Func.ParseFloat(PriceUSD) + Func.ParseInt(Mount) * Func.ParseFloat(PriceVND) * Func.ParseInt(VAT) / 100));

                    Func.SetGridTextValue(item, "ltrSumVND", Func.FormatNumber(sumVND));
                    Func.SetGridTextValue(item, "ltrSumUSD", sumUSD);

                    Func.SetGridTextValue(item, "ltrComment", Func.ToolTipByteLen(Comment, 20));

                    string ModifiedBy = Func.ParseString(row["ModifiedBy"].ToString().Trim());
                    string Modified = Func.ParseString(row["Modified"].ToString().Trim());
                    Func.SetGridTextValue(item, "ltrModifiedBy", ModifiedBy);
                    Func.SetGridTextValue(item, "ltrModified", Func.Formatdmyhms(Modified));

                    //Button btnDelete = (Button)item.FindControl("btnDelete");
                    //btnDelete.CommandArgument = ID;
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
                sql += " FROM [BD_RoomBookingService]";
                sql += " WHERE (ID IS NOT NULL) and DelFlag <> 1 and BookingId = '" + hidId.Value + "'";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " SELECT (PriceVND*Mount+PriceVND*Mount*VAT/100) sumVND,(PriceUSD*Mount+PriceUSD*Mount*VAT/100) sumUSD, *,ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM [BD_RoomBookingService]";
                sql += " WHERE (ID IS NOT NULL) and DelFlag <> 1 and BookingId = '" + hidId.Value + "'";

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
            C1XLBook xlbBook = new C1XLBook();
            string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\BillPhongHop.xlsx");
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

            string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BillPhongHop" + strDT + ".xlsx";
            string strFilePathExport = @"../../Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + @"/BillPhongHop" + strDT + ".xlsx";

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

                            xlsSheet[9, 0].Value = xlsSheet[9, 0].Value.ToString().Replace("{%NGAY_HOP_DONG%}", lblBookingDate.Text);

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
                        int tmp = 2;
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            string Bank = rowType["Bank"].ToString();
                            string Account = rowType["Account"].ToString();
                            string AccountName = rowType["AccountName"].ToString();
                            string Office = rowType["Office"].ToString();
                            string OfficeAddress = rowType["OfficeAddress"].ToString();
                            string OfficePhone = rowType["OfficePhone"].ToString();

                            xlsSheet[30 + tmp, 0].Value = xlsSheet[30 + tmp, 0].Value.ToString().Replace("{%VAN_PHONG%}", Office);
                            xlsSheet[31 + tmp, 0].Value = xlsSheet[31 + tmp, 0].Value.ToString().Replace("{%DIEN_THOAI%}", OfficePhone);

                            xlsSheet[33 + tmp, 0].Value = xlsSheet[33 + tmp, 0].Value.ToString().Replace("{%NGAN_HANG%}", Bank);
                            xlsSheet[34 + tmp, 0].Value = xlsSheet[34 + tmp, 0].Value.ToString().Replace("{%TEN_TAI_KHOAN%}", AccountName);
                            xlsSheet[35 + tmp, 0].Value = xlsSheet[35 + tmp, 0].Value.ToString().Replace("{%SO_TAI_KHOAN%}", Account);
                        }
                    }
                }

                ds = new DataSet();
                sql = " SELECT *";
                sql += " FROM v_BookingRoomInfo";
                sql += " WHERE BookingId = '" + hidId.Value + "' ";

                int j = 0;

                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);

                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            if (j >= 1)
                            {
                                xlsSheet.Rows.Insert(18);
                            }

                            int tmp = 18 + j++;
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
                            xlsSheet[tmp, 4].Value = Func.ParseFloat(Area);
                            xlsSheet[tmp, 5].Value = Func.ParseFloat(PriceUSD);
                            xlsSheet[tmp, 6].Value = Func.ParseDouble(PriceVND);
                            xlsSheet[tmp, 7].Value = Func.ParseFloat(SumUSD);
                            xlsSheet[tmp, 8].Value = Func.ParseDouble(SumVND);
                            xlsSheet[tmp, 9].Value = Func.ParseFloat(VatUSD);
                            xlsSheet[tmp, 10].Value = Func.ParseDouble(VatVND);
                            xlsSheet[tmp, 11].Value = Func.ParseFloat(LastPriceUSD);
                            xlsSheet[tmp, 12].Value = Func.ParseDouble(LastPriceVND);

                            for (int col = 1; col <= 12; col++)
                            {
                                xlsSheet[tmp, col].Style = xlstStyle;
                            }
                        }

                    }
                }
                j--;
                XLSheet source = xlbBook.Sheets["tpl"];

                for (int row = 22; row <= 26; row++)
                {
                    for (int col = 1; col <= 12; col++)
                    {
                        xlsSheet[row + j, col].Style = source[row, col].Style;
                        xlsSheet[row + j, col].Value = source[row, col].Value;
                    }
                }

                XLCellRange mrCell = new XLCellRange(22 + j, 23 + j, 1, 1);
                xlsSheet.MergedCells.Add(mrCell);

                mrCell = new XLCellRange(22 + j, 23 + j, 2, 2);
                xlsSheet.MergedCells.Add(mrCell);

                mrCell = new XLCellRange(22 + j, 23 + j, 3, 4);
                xlsSheet.MergedCells.Add(mrCell);

                mrCell = new XLCellRange(22 + j, 22 + j, 5, 6);
                xlsSheet.MergedCells.Add(mrCell);

                mrCell = new XLCellRange(22 + j, 22 + j, 7, 8);
                xlsSheet.MergedCells.Add(mrCell);

                mrCell = new XLCellRange(22 + j, 22 + j, 9, 10);
                xlsSheet.MergedCells.Add(mrCell);

                mrCell = new XLCellRange(22 + j, 22 + j, 11, 12);
                xlsSheet.MergedCells.Add(mrCell);


                ds = new DataSet();
                sql = " SELECT  Service, Mount, PriceUSD, PriceVND, SumUSD, SumVND, VatUSD, VatVND, LastPriceUSD, LastPriceVND, Unit";
                sql += " FROM    PaymentBookingService";
                sql += " WHERE BookingId = '" + hidId.Value + "' ";

                j = 0;
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);

                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            if (j >= 1)
                            {
                                xlsSheet.Rows.Insert(19);
                            }
                            int tmp = 24 + j++;

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
                            xlsSheet[tmp, 2].Value = Func.ParseFloat(Mount);
                            xlsSheet[tmp, 3].Value = Unit;

                            xlsSheet[tmp, 5].Value = Func.ParseFloat(PriceUSD);
                            xlsSheet[tmp, 6].Value = Func.ParseDouble(PriceVND);
                            xlsSheet[tmp, 7].Value = Func.ParseFloat(SumUSD);
                            xlsSheet[tmp, 8].Value = Func.ParseDouble(SumVND);
                            xlsSheet[tmp, 9].Value = Func.ParseFloat(VatUSD);
                            xlsSheet[tmp, 10].Value = Func.ParseDouble(VatVND);
                            xlsSheet[tmp, 11].Value = Func.ParseFloat(LastPriceUSD);
                            xlsSheet[tmp, 12].Value = Func.ParseDouble(LastPriceVND);

                            for (int col = 1; col <= 12; col++)
                            {
                                xlsSheet[tmp, col].Style = xlstStyle;
                            }
                        }

                    }
                }

                xlbBook.Save(fileNameDes);
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);
            }
        }
    }
}

