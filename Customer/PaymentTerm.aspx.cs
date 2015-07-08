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
    public partial class PaymentTerm : PageBase
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
                CustomerData data = new CustomerData();
                ITransaction tran = factory.GetLoadObject(data, Func.ParseString(Request["id"]));
                Execute(tran);
                if (!HasError)
                {
                    //Get Data
                    data = (CustomerData)tran.Result;
                    txtName.Text = data.Name;
                    txtContactName.Text = data.ContactName;
                    txtCustomerId.Text = data.CustomerId;
                }
                

                //txtName.Text = DbHelper.GetScalar("Select Name from Customer Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + txtCustomerId.Text + "'");
                //txtContactName.Text = DbHelper.GetScalar("Select ContactName from Customer Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + txtCustomerId.Text + "'");


                for (int i = -6; i < 12; i++)
                {
                    lstYearMonth.Items.Add(new ListItem(DateTime.Now.AddMonths(i).ToString("MM/yyyy"), DateTime.Now.AddMonths(i).ToString("yyyyMM")));
                }

                //DbHelper.FillList(drpPaymentType, "Select * from Mst_PaymentType Where specialPay = 1 and delflag = '0'", "Name", "id");
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (lstSelectedYearMonth.Items.Count == 0)
            {
                mvMessage.AddError("Hãy chọn ít nhất 1 tháng.");
                return;
            }
            foreach (ListItem lstItem in lstSelectedYearMonth.Items)
            {
                if (lstItem.Selected)
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
                    data.YearMonth = lstItem.Value;
                    data.PaymentDate = Func.FormatYYYYmmdd(txtPaymentDate.Text.Trim().Substring(0, 10));
                    data.PaymentType = drpSelect.Value;
                    data.PaidType = "1";
                    data.Paymenter = txtPaymenter.Text.Trim();
                    data.Receiver = txtReceiver.Text.Trim();
                    data.MoneyUSD = (drpExchangeType.Value == "0") ? txtMoney.Text.Replace(",", ".") : "0";
                    data.MoneyVND = (drpExchangeType.Value == "1") ? txtMoney.Text.Replace(".", "") : "0";
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
            }
        }

        protected void CustomerId_OnTextChanged(object sender, EventArgs e)
        {
            txtName.Text = DbHelper.GetScalar("Select Name from Customer Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '"+ txtCustomerId.Text +"'");
            txtContactName.Text = DbHelper.GetScalar("Select ContactName from Customer Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + txtCustomerId.Text + "'");
        }
    }
}
