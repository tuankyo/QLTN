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

namespace Man.Building.Supplies
{
    public partial class BD_SuppliesEdit : Man.PageBase
    {
        private string action = String.Empty;
        private string id = String.Empty;

        private string updateSuccess = "Cập Nhật Thông Tin Đã Thành Công";
        private string updateUnSuccess = "Cập Nhật Thông Tin Không Thành Công";
        private string addSuccess = "Thêm Mới Thành Công";
        private string addUnSuccess = "Thêm Mới Không Thành Công";
        private string title = "Vật Tư";
        private string postback = "window.opener.__doPostBack('PopupBD_SuppliesEdit','');";
        private string key = "openBD_SuppliesEdit";

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
            BD_SuppliesData data = new BD_SuppliesData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_SuppliesData)tran.Result;
                txtId.Text = data.CreatedId;
                txtName.Text = data.Name;
                txtDescription.Text = data.Description;
                txtProductOf.Text = data.ProductOf;
                txtComment.Text = data.Comment;
                txtModel.Text = data.Model;
                txtLabel.Text = data.Label;
                txtRegional.Text = data.Regional;

                chkDelFlag.Checked = "1".Equals(data.DelFlag) ? false : true;

                lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";

                hidId.Value = id;

                switch (data.SuppliesType)
                {
                    case "1":
                        lblHeader.Text = "Quản lý vật tư – Thiết bị VP";
                        lblDescription.Text = "Mô Tả";
                        lblRegional.Text = "Khu vực sử dụng";
                        lblModel.Text = "Mã hàng";

                        break;
                    case "2":
                        lblHeader.Text = "Quản lý hoạt động > Thiết bị > Danh sách";
                        break;
                    case "3":
                        lblHeader.Text = "Quản lý tài chính > Vật tư tiêu hao";
                        lblDescription.Text = "Mô Tả";
                        lblRegional.Text = "Khu vực sử dụng";
                        lblModel.Text = "Mã hàng";
                        break;
                    case "4":
                        lblHeader.Text = "Kế toán > Quản lý vật tư - dụng cụ KT";
                        break;
                    case "5":
                        lblHeader.Text = "Quản lý kỹ thuật > Quản lý vật tư - dụng cụ KT";
                        break;
                    case "6":
                        lblHeader.Text = "Quản lý kỹ thuật > Hệ thống kỹ thuật tòa nhà";
                        break;
                }
            }

            
        }

        /// <summary>
        /// Update
        /// </summary>
        private void UpdateData()
        {
            BD_SuppliesData data = new BD_SuppliesData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_SuppliesData)tran.Result;
                data.Name = txtName.Text.Trim();
                data.Description = txtDescription.Text.Trim();
                data.Comment = txtComment.Text.Trim();
                //data.Type = txtType.Text.Trim();
                data.ProductOf = txtProductOf.Text.Trim();
                data.ModifiedBy = Page.User.Identity.Name;
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag = true.Equals(chkDelFlag.Checked) ? "0" : "1";
                data.Model = txtModel.Text;
                data.Label = txtLabel.Text;
                data.Regional = txtRegional.Text;

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
            BD_SuppliesData data = new BD_SuppliesData();
            ITransaction tran = factory.GetInsertObject(data);
            data.CreatedId = txtId.Text.Trim();
            data.JobType = null;
            data.SuppliesType = hidSuppliesType.Value;
            data.ItemId = null;
            data.Name = txtName.Text.Trim();
            data.Description = txtDescription.Text.Trim();

            data.ProductOf = txtProductOf.Text.Trim();
            data.ModifiedBy = Page.User.Identity.Name;
            data.CreatedBy = Page.User.Identity.Name;
            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.DelFlag = true.Equals(chkDelFlag.Checked) ? "0" : "1";
            data.Model = txtModel.Text;
            data.Label = txtLabel.Text;
            data.Regional = txtRegional.Text;
            //data.SuppliesId = txtId.Text.Trim();

            data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);

            Execute(tran);

            if (!HasError)
            {
                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                mvMessage.SetCompleteMessage(addSuccess);
                ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);


                btnRegister.CommandName = "Register";
                hidId.Value = data.id;
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
            hidSuppliesType.Value = Request["SuppliesType"];
            hidId.Value = id;
            hidAction.Value = action;
            txtId.Text = id;

            //string tmp = "";
            //if ("1".Equals(hidSuppliesType.Value))
            //{
            //    tmp = "Vật tư";
            //}
            //else
            //{
            //    tmp = "Thiết bị";
            //}
            hidSuppliesType.Value = Func.ParseString(Request["SuppliesType"]);

            switch (hidSuppliesType.Value)
            {
                case "1":
                    lblHeader.Text = "Quản lý vật tư – Thiết bị VP";
                    lblDescription.Text = "Mô Tả";
                    lblRegional.Text = "Khu vực sử dụng";
                    lblModel.Text = "Mã hàng";

                    break;
                case "2":
                    lblHeader.Text = "Quản lý hoạt động > Thiết bị > Danh sách";
                    break;
                case "3":
                    lblHeader.Text = "Quản lý tài chính > Vật tư tiêu hao";
                    lblDescription.Text = "Mô Tả";
                    lblRegional.Text = "Khu vực sử dụng";
                    lblModel.Text = "Mã hàng";
                    break;
                case "4":
                    lblHeader.Text = "Kế toán > Quản lý vật tư - dụng cụ KT";
                    break;
                case "5":
                    lblHeader.Text = "Quản lý kỹ thuật > Quản lý vật tư - dụng cụ KT";
                    break;
                case "6":
                    lblHeader.Text = "Quản lý kỹ thuật > Hệ thống kỹ thuật tòa nhà";
                    break;
            }
            SqlDatabase db = new SqlDatabase();
            if (action == "Edit")
            {
                //lblHeader.Text = "Thông Tin Chi Tiết " + tmp;
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
                //lblHeader.Text = "Thêm Mới " + tmp;
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
            mvMessage.CheckRequired(txtDescription, "Mô tả: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtProductOf, "Nhà cung cấp: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtName, "Tên: Danh mục bắt bắt buộc nhập");
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
