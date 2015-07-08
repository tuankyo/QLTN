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
    public partial class PaymentOfBD : PageBase
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
        private string postback = "window.opener.__doPostBack('PopupPaymentEdit','');";
        private string key = "PaymentBillInfo";

        /// <summary>
        /// Init values
        /// </summary>
        protected override void DoInit()
        {
        }

        protected override void DoPost()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //CustomerData data = new CustomerData();
                //ITransaction tran = factory.GetLoadObject(data, hidId.Value);
                //Execute(tran);
                //if (!HasError)
                //{
                //    //Get Data
                //    data = (CustomerData)tran.Result;
                //    txtCustomerId.Text = data.CustomerId;
                //    txtName.Text = data.Name;
                //    //txtComment.Text = data.Comment;
                //    txtContactName.Text = data.ContactName;
                //}
                string buildingId = Func.ParseString(Session["__BUILDINGID__"]);
                string sql = "Select Name,id from BD_PaymentType Where Id not in (Select ParentId from ";
                sql += "BD_PaymentType  ";
                sql += "Where delflag = '0' and ParentId is not null and BuildingId = '" + buildingId + "') and delflag = '0' and BuildingId = '" + buildingId + "' ";
                sql += "Union ";
                sql += "Select Name,id from Mst_PaymentType where ParentId is not null";
                DbHelper.FillList(drpPaymentType, sql, "Name", "id");
            }
        }
        protected void drpPaymentType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string buildingId = Func.ParseString(Session["__BUILDINGID__"]);
            string sql = "Select PaidType, id from BD_PaymentType Where Id not in (Select ParentId from ";
                sql += "BD_PaymentType  ";
                sql += "Where delflag = '0' and ParentId is not null and BuildingId = '" + buildingId + "') and delflag = '0' and BuildingId = '" + buildingId + "' ";
                sql += "Union ";
                sql += "Select PaidType, id from Mst_PaymentType where ParentId is not null";

                drpPaidType.Value = DbHelper.GetScalar("Select PaidType from (" + sql + ") A where id = '" + drpPaymentType.SelectedValue + "'");
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
            data.YearMonth = Func.FormatYYYYmmdd(txtPaymentDate.Text.Trim().Substring(0, 10)).Substring(0, 6);
            data.PaymentDate = Func.FormatYYYYmmdd(txtPaymentDate.Text.Trim().Substring(0, 10));
            data.PaymentType = drpPaymentType.SelectedValue;
            data.PaidType = drpPaidType.Value;
            data.Paymenter = txtPaymenter.Text.Trim();
            data.Receiver = txtReceiver.Text.Trim();
            data.MoneyUSD = (drpExchangeType.Value == "0") ? txtMoney.Text.Replace(",", ".") : "0";
            data.MoneyVND = (drpExchangeType.Value == "1") ? txtMoney.Text.Replace(",", ".") : "0";
            data.Comment = txtComment.Text.Trim();

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

        protected void CustomerId_OnTextChanged(object sender, EventArgs e)
        {
            txtName.Text = DbHelper.GetScalar("Select Name from Customer Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + txtCustomerId.Text + "'");
            txtContactName.Text = DbHelper.GetScalar("Select ContactName from Customer Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + txtCustomerId.Text + "'");

        }
    }
}
