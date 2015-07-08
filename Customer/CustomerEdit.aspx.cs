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
    public partial class CustomerEdit : Man.PageBase
    {
        private string action = String.Empty;
        private string id = String.Empty;

        private string updateSuccess = "Cập Nhật Thông Tin Đã Thành Công";
        private string updateUnSuccess = "Cập Nhật Thông Tin Không Thành Công";
        private string addSuccess = "Thêm Mới Thành Công";
        private string addUnSuccess = "Thêm Mới Không Thành Công";
        private string title = "Khách Hàng";
        private string postback = "window.opener.__doPostBack('PopupCustomerEdit','');";
        private string key = "openCustomerEdit";

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
            CustomerData data = new CustomerData();
            ITransaction tran = factory.GetLoadObject(data, id);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (CustomerData)tran.Result;
                txtId.Text = data.CustomerId;
                txtName.Text = data.Name;
                txtPhone.Text = data.Phone;
                txtEmail.Text = data.Email;
                txtContactName.Text = data.ContactName;
                txtComment.Text = data.Comment;
                chkDelFlag.Checked =  "1".Equals(data.DelFlag) ? false : true;
                lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";
                rdoMonthPaymentTypeFirst.Checked = data.MonthPaymentType.Equals("1") ? true : false;
                rdoMonthPaymentTypeLast.Checked = data.MonthPaymentType.Equals("2") ? true : false;
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void UpdateData()
        {
            CustomerData data = new CustomerData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (CustomerData)tran.Result;
                data.Name = txtName.Text.Trim();
                data.Phone = txtPhone.Text.Trim();
                data.Email = txtEmail.Text.Trim();
                data.ContactName = txtContactName.Text.Trim();
                data.Comment = txtComment.Text.Trim();
                data.ModifiedBy = Page.User.Identity.Name;
                data.CreatedBy = Page.User.Identity.Name;
                data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag = true.Equals(chkDelFlag.Checked) ? "0" : "1";
                data.MonthPaymentType = rdoMonthPaymentTypeFirst.Checked ? "1" : "2";

                tran = factory.GetUpdateObject(data);

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(updateSuccess);
                    ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);

                    lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                    lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";
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
        private void InsertData()
        {
            //Get and Insert Data
            CustomerData data = new CustomerData();
            ITransaction tran = factory.GetInsertObject(data);
            data.CustomerId = txtId.Text.Trim();
            data.Name = txtName.Text.Trim();
            data.Phone = txtPhone.Text.Trim();
            data.Email = txtEmail.Text.Trim();
            data.ContactName = txtContactName.Text.Trim();
            data.Comment = txtComment.Text.Trim();
            data.ModifiedBy = Page.User.Identity.Name;
            data.CreatedBy = Page.User.Identity.Name;
            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.DelFlag = true.Equals(chkDelFlag.Checked) ? "0" : "1";
            data.CustomerId = txtId.Text;
            data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);
            data.MonthPaymentType = rdoMonthPaymentTypeFirst.Checked ? "1" : "2";

            Execute(tran);

            if (!HasError)
            {
                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                mvMessage.SetCompleteMessage(addSuccess);
                ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);

                btnRegister.CommandName = "Register";
                hidAction.Value = "Edit";
                txtId.Enabled = false;
                lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";
            }
            else
            {
                OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                mvMessage.AddError(addUnSuccess);
            }

        }

        /// <summary>
        /// Init values
        /// </summary>
        protected override void DoInit()
        {
            InitValues();
        }
        protected override void DoGet()
        {
            chkDelFlag.Enabled = DbHelper.isAdmin(Page.User.Identity.Name);

            action = Request["Action"];
            id = Request["id"];

            hidId.Value = id;
            hidAction.Value = action;
            txtId.Text = id;

            SqlDatabase db = new SqlDatabase();
            if (action == "Edit")
            {
                lblHeader.Text = "Thông Tin Chi Tiết " + title;
                btnRegister.Text = "Cập Nhật";
                btnCancel.Text = "Đóng";
                btnRegister.CommandName = "Edit";
                if (!IsPostBack)
                {
                    LoadData();
                }
            }
            else // Add new case
            {
                lblHeader.Text = "Thêm Mới " + title;
                btnRegister.Text = "Thêm Mới";
                btnRegister.CommandName = "Register";
                btnCancel.Text = "Đóng";
            }
        }

        protected override void DoPost()
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            mvMessage.CheckRequired(txtName, "Khách Hàng: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtEmail, "Email: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtContactName, "Người Liên Lạc: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtPhone, "Phone: Danh mục bắt bắt buộc nhập");

            if (!mvMessage.IsValid) return;

            if (hidAction.Value == "Edit")
            {
                UpdateData();
            }
            else // Add new case
            {
                InsertData();
            }
            
        }
    }
}
