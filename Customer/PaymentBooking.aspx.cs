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

namespace Man.Customer
{
    public partial class PaymentBooking : PageBase
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

        private string updateSuccess = "Cập Nhật Thông Tin Đã Thành Công";
        private string updateUnSuccess = "Cập Nhật Thông Tin Không Thành Công";
        private string addSuccess = "Thêm Mới Thành Công";
        private string addUnSuccess = "Thêm Mới Không Thành Công";
        private string title = "Nhân Viên";
        private string postback = "window.opener.__doPostBack('PopupBillInfo','');";
        private string key = "PaymentBooking";

        /// <summary>
        /// List data
        /// </summary>
        private void ShowData(string YearMonth)
        {

        }

        /// <summary>
        /// Init values
        /// </summary>
        protected override void DoInit()
        {
            hidId.Value = Func.ParseString(Request["id"]);
            hidYearMonth.Value = Func.ParseString(Request["yearmonth"]);
        }

        protected override void DoPost()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            hidId.Value = Func.ParseString(Request["id"]);
            hidYearMonth.Value = Func.ParseString(Request["yearmonth"]);
            hidPaymentType.Value = Func.ParseString(Request["paymenttype"]);
            hidExchangeType.Value = Func.ParseString(Request["exchangetype"]);
            hidBookingId.Value = Func.ParseString(Request["bookingid"]);
            txtMoney.Text = Func.ParseString(Request["money"]);

            if (!IsPostBack)
            {
                ShowData(hidYearMonth.Value);

                CustomerData data = new CustomerData();
                ITransaction tran = factory.GetLoadObject(data, hidId.Value);
                Execute(tran);
                if (!HasError)
                {
                    //Get Data
                    data = (CustomerData)tran.Result;
                    txtCustomerId.Text = data.CustomerId;
                    txtName.Text = data.Name;
                    //txtComment.Text = data.Comment;
                    txtContactName.Text = data.ContactName;
                }

                lblMoney.Text = "USD";
                switch (hidExchangeType.Value)
                {
                    case "1":
                        lblMoney.Text = "VND"; // Where Fieldname is the name of fields from your database that you want to get
                        break;
                    default:
                        break;
                }
                switch (hidPaymentType.Value)
                {
                    case "1":
                        lblHeader.Text = "Thu tiền thuê"; // Where Fieldname is the name of fields from your database that you want to get
                        break;
                    case "2":
                        lblHeader.Text = "Thu tiền quản lý"; // Where Fieldname is the name of fields from your database that you want to get
                        break;
                    case "3":
                        lblHeader.Text = "Thu tiền gửi xe"; // Where Fieldname is the name of fields from your database that you want to get
                        break;
                    case "4":
                        lblHeader.Text = "Thu tiền giờ làm thêm"; // Where Fieldname is the name of fields from your database that you want to get
                        break;
                    case "5":
                        lblHeader.Text = "Thu tiền Điện"; // Where Fieldname is the name of fields from your database that you want to get
                        break;
                    case "6":
                        lblHeader.Text = "Thu tiền Nước"; // Where Fieldname is the name of fields from your database that you want to get
                        break;
                    case "7":
                        lblHeader.Text = "Thu tiền Phí khác"; // Where Fieldname is the name of fields from your database that you want to get
                        break;
                    case "8":
                        lblHeader.Text = "Thu tiền đặt phòng"; // Where Fieldname is the name of fields from your database that you want to get
                        break;
                    default:
                        break;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Get and Insert Data
            PaymentData data = new PaymentData();
            ITransaction tran = factory.GetInsertObject(data);
            data.ModifiedBy = Page.User.Identity.Name;
            data.CreatedBy = Page.User.Identity.Name;
            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.DelFlag = "0";

            data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);
            data.CustomerId = txtCustomerId.Text.Trim();
            data.YearMonth = hidYearMonth.Value;
            data.PaymentDate = Func.FormatYYYYmmdd(txtPaymentDate.Text.Trim().Substring(0,10));
            data.PaymentType = hidPaymentType.Value;
            data.PaidType = "1";
            data.Paymenter = txtPaymenter.Text.Trim();
            data.Receiver = txtReceiver.Text.Trim();
            data.MoneyUSD = (hidExchangeType.Value == "0") ? txtMoney.Text.Replace(",",".") : "0";
            data.MoneyVND = (hidExchangeType.Value == "1") ? txtMoney.Text.Replace(".", "") : "0";
            data.Comment = txtComment.Text.Trim();
            data.BookingId = hidBookingId.Value;

            Execute(tran);

            if (!HasError)
            {
                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                mvMessage.SetCompleteMessage(addSuccess);
                ScriptManager.RegisterClientScriptBlock(this.btnSave, this.GetType(), key, postback, true);
            }
            else
            {
                OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                mvMessage.AddError(addUnSuccess);
            }
        }
    }
}
