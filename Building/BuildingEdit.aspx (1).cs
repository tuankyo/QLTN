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

namespace Man.Building
{
    public partial class BuildingEdit : Man.PageBase
    {
        private string action = String.Empty;
        private string id = String.Empty;

        private string updateSuccess = "Cập Nhật Thông Tin Đã Thành Công";
        private string updateUnSuccess = "Cập Nhật Thông Tin Không Thành Công";
        private string addSuccess = "Thêm Mới Thành Công";
        private string addUnSuccess = "Thêm Mới Không Thành Công";
        private string title = "Tòa Nhà Cho Thuê";
        private string postback = "window.opener.__doPostBack('PopupBuildingEdit','');";
        private string key = "openBuildingEdit";

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
            Mst_BuildingData data = new Mst_BuildingData();
            ITransaction tran = factory.GetLoadObject(data, txtBuildingId.Text.Trim());
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (Mst_BuildingData)tran.Result;
                txtName.Text = data.Name;
                txtComment.Text = data.Comment;
                chkDelFlag.Checked = "1".Equals(data.DelFlag) ? false : true;

                txtBuildingId.Text = data.BuildingId;
                txtName.Text = data.Name;
                txtInvestor.Text = data.Investor;
                txtAddress.Text = data.Address;
                txtPhone.Text = data.Phone;
                txtOwner.Text = data.Owner;
                txtManagerCompany.Text = data.ManagerCompany;
                txtManagerCompanyAgent.Text = data.ManagerCompanyAgent;
                txtManagerCompanyPhone.Text = data.ManagerCompanyPhone;

                txtBank.Text = data.Bank;
                txtAccount.Text = data.Account;
                txtAccountName.Text = data.AccountName;
                txtOffice.Text = data.Office;
                txtOfficePhone.Text = data.OfficePhone;

                lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void UpdateData()
        {
            Mst_BuildingData data = new Mst_BuildingData();
            ITransaction tran = factory.GetLoadObject(data, txtBuildingId.Text.Trim());
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (Mst_BuildingData)tran.Result;

                data.BuildingId = txtBuildingId.Text.Trim();
                data.Name = txtName.Text.Trim();
                data.Investor = txtInvestor.Text.Trim();
                data.Address = txtAddress.Text.Trim();
                data.Phone = txtPhone.Text.Trim();
                data.Owner = txtOwner.Text.Trim();
                data.ManagerCompany = txtManagerCompany.Text.Trim();
                data.ManagerCompanyAgent = txtManagerCompanyAgent.Text.Trim();
                data.ManagerCompanyPhone = txtManagerCompanyPhone.Text.Trim();

                data.Comment = txtComment.Text.Trim();

                data.Bank = txtBank.Text.Trim();
                data.Account = txtAccount.Text.Trim();
                data.AccountName = txtAccountName.Text.Trim();
                data.Office = txtOffice.Text.Trim();
                data.OfficePhone = txtOfficePhone.Text.Trim();

                data.ModifiedBy = Page.User.Identity.Name;
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag = true.Equals(chkDelFlag.Checked) ? "0" : "1";

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
            Mst_BuildingData data = new Mst_BuildingData();
            ITransaction tran = factory.GetInsertObject(data);

            data.BuildingId = txtBuildingId.Text.Trim();
            data.Name = txtName.Text.Trim();
            data.Investor = txtInvestor.Text.Trim();
            data.Address = txtAddress.Text.Trim();
            data.Phone = txtPhone.Text.Trim();
            data.Owner = txtOwner.Text.Trim();
            data.ManagerCompany = txtManagerCompany.Text.Trim();
            data.ManagerCompanyAgent = txtManagerCompanyAgent.Text.Trim();
            data.ManagerCompanyPhone = txtManagerCompanyPhone.Text.Trim();

            data.Comment = txtComment.Text.Trim();

            data.Bank = txtBank.Text.Trim();
            data.Account = txtAccount.Text.Trim();
            data.AccountName = txtAccountName.Text.Trim();
            data.Office = txtOffice.Text.Trim();
            data.OfficePhone = txtOfficePhone.Text.Trim();

            data.DelFlag = "0";

            data.ModifiedBy = Page.User.Identity.Name;
            data.CreatedBy = Page.User.Identity.Name;
            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.DelFlag = true.Equals(chkDelFlag.Checked) ? "0" : "1";

            Execute(tran);

            if (!HasError)
            {
                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                mvMessage.SetCompleteMessage(addSuccess);
                ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);


                btnRegister.CommandName = "Register";
                hidAction.Value = "Edit";

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
            txtBuildingId.Text = Request["Id"];

            hidAction.Value = action;

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
                //chkDelFlag.Checked = true;
                //lblHeader.Text = "Thêm Mới " + title;
                //btnRegister.Text = "Thêm Mới";
                //btnRegister.CommandName = "Register";
                //btnCancel.Text = "Đóng";
            }
        }

        protected override void DoPost()
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            mvMessage.CheckRequired(txtName, "Tòa nhà cho thuê: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtInvestor, "Tên chủ đầu tư: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtAddress, "Địa chỉ: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtPhone, "Số điện thoại: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtOwner, "Người đại diện: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtManagerCompany, "Công ty quả lý: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtManagerCompanyAgent, "Người đại diện công ty: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtManagerCompanyPhone, "Số điện thoại công ty: là Danh mục bắt bắt buộc nhập");

            if (!mvMessage.IsValid) return;

            if (hidAction.Value == "Edit")
            {
                UpdateData();
            }
            else // Add new case
            {
                //InsertData();
            }

        }
    }
}
