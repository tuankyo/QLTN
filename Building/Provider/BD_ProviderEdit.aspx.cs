﻿using System;
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

namespace Man.Building.Provider
{
    public partial class BD_ProviderEdit : Man.PageBase
    {
        private string action = String.Empty;
        private string id = String.Empty;

        private string updateSuccess = "Cập Nhật Thông Tin Đã Thành Công";
        private string updateUnSuccess = "Cập Nhật Thông Tin Không Thành Công";
        private string addSuccess = "Thêm Mới Thành Công";
        private string addUnSuccess = "Thêm Mới Không Thành Công";
        private string title = "Nhà Cung Cấp";
        private string postback = "window.opener.__doPostBack('PopupBD_ProviderEdit','');";
        private string key = "openBD_ProviderEdit";

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
            BD_ProviderData data = new BD_ProviderData();
            ITransaction tran = factory.GetLoadObject(data, id);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_ProviderData)tran.Result;
                txtId.Text = data.id;
                txtName.Text = data.Name;

                txtGoodsProvider.Text= data.GoodsProvider;
                txtName.Text = data.Name;
                txtAddress.Text = data.Address;
                txtPhone.Text = data.Phone;
                txtContact.Text = data.Contact;

                txtComment.Text = data.Comment;
                chkDelFlag.Checked = "1".Equals(data.DelFlag) ? false : true;

                lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";

                hidId.Value = id;
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void UpdateData()
        {
            BD_ProviderData data = new BD_ProviderData();
            ITransaction tran = factory.GetLoadObject(data, txtId.Text.Trim());
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_ProviderData)tran.Result;
                data.GoodsProvider = txtGoodsProvider.Text.Trim();
                data.Name = txtName.Text.Trim();
                data.Address = txtAddress.Text.Trim();
                data.Phone = txtPhone.Text.Trim();
                data.Contact = txtContact.Text.Trim();

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
            BD_ProviderData data = new BD_ProviderData();
            ITransaction tran = factory.GetInsertObject(data);
            data.id = txtId.Text.Trim();
            data.GoodsProvider = txtGoodsProvider.Text.Trim();
            data.Name = txtName.Text.Trim();
            data.Address = txtAddress.Text.Trim();
            data.Phone = txtPhone.Text.Trim();
            data.Contact = txtContact.Text.Trim();
            data.Dept = hidDept.Value;

            data.ModifiedBy = Page.User.Identity.Name;
            data.CreatedBy = Page.User.Identity.Name;
            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.DelFlag = true.Equals(chkDelFlag.Checked) ? "0" : "1";

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
            hidDept.Value = Request["Dept"];
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
            mvMessage.CheckRequired(txtName, "Tên Nhà Cung Cấp: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtId, "Mã: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtPhone, "Số Điện Thoại: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtGoodsProvider, "Mặt Hàng: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtContact, "Liên Hệ: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtAddress, "Địa Chỉ: Danh mục bắt bắt buộc nhập");

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
