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

using Gnt.Data.DBCommand;
using Gnt.Data;
using System.Data.SqlClient;
using BusinessObjects;
using Gnt.Transaction;
using Man.Utils;

namespace Man.Customer
{
    public partial class CustomerServiceEdit : Man.PageBase
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

        private string action = String.Empty;
        private string id = String.Empty;

        private string updateSuccess = "Cập Nhật Thông Tin Đã Thành Công";
        private string updateUnSuccess = "Cập Nhật Thông Tin Không Thành Công";
        private string addSuccess = "Thêm Mới Thành Công";
        private string addUnSuccess = "Thêm Mới Không Thành Công";
        private string deleteSuccess = "Xóa Thành Công";
        private string deleteUnSuccess = "Xóa Không Thành Công";
        private string title = "Dịch Vụ Cộng Thêm";
        private string postback = "window.opener.__doPostBack('PopupBD_StaffEdit','');";
        private string key = "openBD_StaffEdit";

        /// <summary>
        /// Init values
        /// </summary>
        private void InitValues()
        {
        }

        /// <summary>
        /// Load data
        /// </summary>
        private void LoadData()
        {
            CustomerServiceData data = new CustomerServiceData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (CustomerServiceData)tran.Result;

                txtService.Text = data.Service;
                txtServiceDateFrom.Text = Func.FormatDMY(data.ServiceDateFrom);
                txtServiceDateTo.Text = Func.FormatDMY(data.ServiceDateTo);
                txtUnit.Text = data.Unit;
                txtPriceUSD.Text = data.PriceUSD;
                txtPriceVND.Text = data.PriceVND;
                txtMount.Text = data.Mount;
                txtVAT.Text = data.VAT;
                drpYear.SelectedValue = String.IsNullOrEmpty(data.YearMonth) ? "" : data.YearMonth.Substring(0, 4);
                drpMonth.SelectedValue = String.IsNullOrEmpty(data.YearMonth) ? "" : data.YearMonth.Substring(4, 2);
                txtComment.Text = data.Comment;
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void DeleteData(string strId)
        {
            CustomerServiceData data = new CustomerServiceData();
            ITransaction tran = factory.GetLoadObject(data, strId);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (CustomerServiceData)tran.Result;
                data.PriceUSD = data.PriceUSD.Replace(",", ".");
                data.PriceUSD = data.PriceUSD.Replace(",", ".");
                data.PriceVND = data.PriceVND.Replace(",", ".");
                data.Mount = data.Mount.Replace(",", ".");
                data.VAT = data.VAT.Replace(",", ".");

                data.DelFlag = "1";
                tran = factory.GetUpdateObject(data);

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, deleteSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(deleteSuccess);
                    ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(updateUnSuccess);
                }
            }
        }

        /// <summary>
        /// Insert data
        /// </summary>
        private void UpdateData()
        {
            double PriceVND = Func.ParseDouble(txtPriceVND.Text.Trim().Replace(",", "."));
            double PriceUSD = Func.ParseFloat(txtPriceUSD.Text.Trim().Replace(",", "."));

            if (PriceVND != 0 && PriceUSD != 0)
            {
                mvMessage.AddError("Đơn giá không được phép nhập cả 2 USD và VND lớn hơn 0. \n Một trong 2 loại phải = 0");
                return;
            }

            //Get and Insert Data
            CustomerServiceData data = new CustomerServiceData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                data = (CustomerServiceData)tran.Result;
                data.Service = txtService.Text.Trim();
                data.ServiceDateFrom = Func.FormatYYYYmmdd(txtServiceDateFrom.Text.Trim());
                data.ServiceDateTo = Func.FormatYYYYmmdd(txtServiceDateTo.Text.Trim());
                data.PriceUSD = txtPriceUSD.Text.Trim().Replace(",", ".");
                data.PriceVND = txtPriceVND.Text.Trim().Replace(",", ".");
                data.Mount = txtMount.Text.Trim().Replace(",", ".");
                data.Unit = txtUnit.Text.Trim();
                data.VAT = txtVAT.Text.Trim().Replace(",", ".");
                data.OtherFee01 = "0";
                data.OtherFee02 = "0";
                data.YearMonth = drpYear.SelectedValue + drpMonth.SelectedValue;
                data.Comment = txtComment.Text.Trim();
                data.ModifiedBy = Page.User.Identity.Name;
                data.CreatedBy = Page.User.Identity.Name;
                data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");

                tran = factory.GetUpdateObject(data);
                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(addSuccess);
                    ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(addUnSuccess);
                }
            }

        }

        /// <summary>
        /// Init values
        /// </summary>
        protected override void DoInit()
        {
            for (int i = 2000; i < 2050; i++)
            {
                drpYear.Items.Add(new ListItem(Func.ParseString(i), Func.ParseString(i)));
            }
            drpYear.Items.FindByValue(DateTime.Now.AddMonths(-1).ToString("yyyy")).Selected = true;

            for (int i = 1; i < 13; i++)
            {
                drpMonth.Items.Add(new ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
            }
            drpMonth.Items.FindByValue(DateTime.Now.AddMonths(-1).ToString("MM")).Selected = true;

            InitValues();
        }
        protected override void DoGet()
        {
            id = Request["id"];
            hidId.Value = id;

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected override void DoPost()
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //mvMessage.CheckRequired(txtComplainDate, "Ngày: Danh mục bắt bắt buộc nhập");
            //mvMessage.CheckRequired(txtDescription, "Nội Dung: Danh mục bắt bắt buộc nhập");

            if (!mvMessage.IsValid) return;

            UpdateData();
        }
    }
}
