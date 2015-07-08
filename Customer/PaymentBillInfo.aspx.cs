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

using Gnt.Data;using Man.Utils;
using Gnt.Data.DBCommand;
using System.Data.SqlClient;
using BusinessObjects;
using Gnt.Transaction;
using System.Text;

namespace Man.Customer
{
    public partial class PaymentBillInfo : PageBase
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
        private string key = "PaymentBillInfo";

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

            if (!IsPostBack)
            {
                txtCustomerId.Text = hidId.Value;
                hidBillId.Value = DbHelper.GetScalar("Select id from PaymentBillInfo where customerid = '" + hidId.Value + "' and YearMonth = '" + hidYearMonth.Value + "' and BuildingId= '" + Func.ParseString(Session["__BUILDINGID__"]) + "'");
                if (Func.ParseInt(hidBillId.Value) > 0)
                {
                    PaymentBillInfoData data = new PaymentBillInfoData();
                    ITransaction tran = factory.GetLoadObject(data, hidBillId.Value);
                    Execute(tran);
                    if (!HasError)
                    {
                        data = (PaymentBillInfoData)tran.Result;
                        txtName.Text = data.Name;
                        txtContactName.Text = data.ContactName;
                        txtBank.Text = data.Bank;
                        txtAccount.Text = data.Account;
                        txtAccountName.Text = data.AccountName;
                        txtOffice.Text = data.Office;
                        txtOfficePhone.Text = data.OfficePhone;
                        txtBillDate.Text = data.BillDate;
                        txtUsdExchangeDate.Text = Func.FormatDMY(data.UsdExchangeDate);
                        txtUsdExchange.Text = data.UsdExchange;
                    }
                }

                if (String.IsNullOrEmpty(hidBillId.Value))
                {
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

                    Mst_BuildingData dataB = new Mst_BuildingData();
                    ITransaction tranB = factory.GetLoadObject(dataB, Func.ParseString(Session["__BUILDINGID__"]));
                    Execute(tranB);
                    if (!HasError)
                    {
                        //Get Data
                        dataB = (Mst_BuildingData)tranB.Result;
                        txtBank.Text = dataB.Bank;
                        txtAccount.Text = dataB.Account;
                        txtAccountName.Text = dataB.AccountName;
                        txtOffice.Text = dataB.Office;
                        txtOfficePhone.Text = dataB.OfficePhone;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
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
                data.CustomerId = txtCustomerId.Text.Trim();
                data.YearMonth = hidYearMonth.Value;
                data.Name = txtName.Text.Trim();
                data.ContactName = txtContactName.Text.Trim();
                data.Bank = txtBank.Text.Trim();
                data.Account = txtAccount.Text.Trim();
                data.AccountName = txtAccountName.Text.Trim();
                data.Office = txtOffice.Text.Trim();
                data.OfficePhone = txtOfficePhone.Text.Trim();
                data.BillDate = txtBillDate.Text.Trim();
                data.UsdExchangeDate = Func.FormatYYYYmmdd(txtUsdExchangeDate.Text.Trim());
                data.UsdExchange = txtUsdExchange.Text.Trim();

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(addSuccess);

                    using (SqlConnection con = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand cm = new SqlCommand("sp_PaymentDetail", con))
                        {
                            try
                            {
                                cm.CommandType = CommandType.StoredProcedure;
                                cm.Parameters.AddWithValue("@BuildingId", data.BuildingId);
                                cm.Parameters.AddWithValue("@CustomerId", data.CustomerId);
                                cm.Parameters.AddWithValue("@YearMonth", data.YearMonth);
                                cm.Parameters.AddWithValue("@rent", rdoRentPaidUSD.Checked == true ? "0" : "1");
                                cm.Parameters.AddWithValue("@manager", rdoManagerPaidUSD.Checked == true ? "0" : "1");
                                cm.Parameters.AddWithValue("@parking", rdoParkingPaidUSD.Checked == true ? "0" : "1");
                                cm.Parameters.AddWithValue("@extratime", rdoExtraTimePaidUSD.Checked == true ? "0" : "1");
                                cm.Parameters.AddWithValue("@elec", rdoElecPaidUSD.Checked == true ? "0" : "1");
                                cm.Parameters.AddWithValue("@water", rdoWaterPaidUSD.Checked == true ? "0" : "1");
                                cm.Parameters.AddWithValue("@service", rdoServicePaidUSD.Checked == true ? "0" : "1");

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

                    ScriptManager.RegisterClientScriptBlock(this.btnSave, this.GetType(), key, postback, true);
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

                    data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);
                    data.CustomerId = txtCustomerId.Text.Trim();
                    data.YearMonth = hidYearMonth.Value;
                    data.Name = txtName.Text.Trim();
                    data.ContactName = txtContactName.Text.Trim();
                    data.Bank = txtBank.Text.Trim();
                    data.Account = txtAccount.Text.Trim();
                    data.AccountName = txtAccountName.Text.Trim();
                    data.Office = txtOffice.Text.Trim();
                    data.OfficePhone = txtOfficePhone.Text.Trim();
                    data.BillDate = txtBillDate.Text.Trim();
                    data.UsdExchangeDate = Func.FormatYYYYmmdd(Func.FormatYYYYmmdd(txtUsdExchangeDate.Text.Substring(0, 10)));
                    data.UsdExchange = txtUsdExchange.Text.Trim();

                    tran = factory.GetUpdateObject(data);

                    Execute(tran);

                    if (!HasError)
                    {
                        OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateSuccess, Page.User.Identity.Name);
                        mvMessage.SetCompleteMessage(updateSuccess);

                        using (SqlConnection con = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                        {
                            con.Open();
                            using (SqlCommand cm = new SqlCommand("sp_PaymentDetail", con))
                            {
                                try
                                {
                                    cm.CommandType = CommandType.StoredProcedure;
                                    cm.Parameters.AddWithValue("@BuildingId", data.BuildingId);
                                    cm.Parameters.AddWithValue("@CustomerId", data.CustomerId);
                                    cm.Parameters.AddWithValue("@YearMonth", data.YearMonth);
                                    cm.Parameters.AddWithValue("@rent", rdoRentPaidUSD.Checked == true ? "0" : "1");
                                    cm.Parameters.AddWithValue("@manager", rdoManagerPaidUSD.Checked == true ? "0" : "1");
                                    cm.Parameters.AddWithValue("@parking", rdoParkingPaidUSD.Checked == true ? "0" : "1");
                                    cm.Parameters.AddWithValue("@extratime", rdoExtraTimePaidUSD.Checked == true ? "0" : "1");
                                    cm.Parameters.AddWithValue("@elec", rdoElecPaidUSD.Checked == true ? "0" : "1");
                                    cm.Parameters.AddWithValue("@water", rdoWaterPaidUSD.Checked == true ? "0" : "1");
                                    cm.Parameters.AddWithValue("@service", rdoServicePaidUSD.Checked == true ? "0" : "1");

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
                        OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateUnSuccess, Page.User.Identity.Name);
                        mvMessage.AddError(updateUnSuccess);
                    }
                }
            }
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
        }

    }
}
