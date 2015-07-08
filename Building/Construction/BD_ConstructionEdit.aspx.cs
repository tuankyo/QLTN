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

namespace Man.Building.Construction
{
    public partial class BD_ConstructionEdit : Man.PageBase
    {
        private string action = String.Empty;
        private string id = String.Empty;

        private string updateSuccess = "Cập Nhật Thông Tin Đã Thành Công";
        private string updateUnSuccess = "Cập Nhật Thông Tin Không Thành Công";
        private string addSuccess = "Thêm Mới Thành Công";
        private string addUnSuccess = "Thêm Mới Không Thành Công";
        private string title = "Bảo Trì Sửa Chữa Tòa Nhà";
        private string postback = "window.opener.__doPostBack('PopupBD_ConstructionEdit','');";
        private string key = "openBD_ConstructionEdit";

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
            BD_ConstructionData data = new BD_ConstructionData();
            ITransaction tran = factory.GetLoadObject(data, id);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_ConstructionData)tran.Result;
                txtConstructDate.Text = !"".Equals(data.ConstructDate) ? Func.Formatdmyhms(data.ConstructDate) : "";
                txtDuration.Text = data.Duration;
                txtConstructContent.Text = data.ConstructContent;

                txtRegional.Text = data.Regional;
                txtConstructCompany.Text = data.ConstructCompany;
                txtConstructDate.Text = data.ConstructDate;

                chkDelFlag.Checked = "1".Equals(data.DelFlag) ? false : true;

                lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";
                txtId.Text = id;
                hidId.Value = id;
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void UpdateData()
        {
            BD_ConstructionData data = new BD_ConstructionData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_ConstructionData)tran.Result;
                data.ConstructDate = !"".Equals(txtConstructDate.Text.Trim()) ? Func.Formatdmyhms(txtConstructDate.Text.Trim()) : "";
                data.Duration = txtDuration.Text.Trim();

                data.Regional = txtRegional.Text.Trim();
                data.ConstructCompany = txtConstructCompany.Text.Trim();
                data.ConstructContent = txtConstructContent.Text.Trim();
                data.Comment = txtComment.Text;
                data.ConstructDate = txtConstructDate.Text.Trim();

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
            BD_ConstructionData data = new BD_ConstructionData();
            ITransaction tran = factory.GetInsertObject(data);
            data.ConstructDate = !"".Equals(txtConstructDate.Text.Trim()) ? Func.Formatdmyhms(txtConstructDate.Text.Trim()) : "";
            data.Duration = txtDuration.Text.Trim();

            data.Regional = txtRegional.Text.Trim();
            data.ConstructCompany = txtConstructCompany.Text.Trim();
            data.ConstructContent = txtConstructContent.Text.Trim();
            data.Comment = txtComment.Text;

            data.ConstructDate = Func.FormatYYYYmmdd(txtConstructDate.Text.Trim());

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

            //DbHelper.FillList(drpJobTypeId, "Select * from MST_JobType where delFlag <> 1 ", "Name", "id");
            SqlDatabase db = new SqlDatabase();
            if (action == "Edit")
            {
                lblHeader.Text = "Thông Tin Chi Tiết " + title;
                btnRegister.Text = "Cập Nhật";
                btnCancel.Text = "Đóng";
                btnRegister.CommandName = "Edit";
                txtId.Enabled = false;
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
            mvMessage.CheckRequired(txtConstructCompany, "Công Ty Thực Hiện: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtConstructContent, "Nội Dung Thực Hiện: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtConstructDate, "Ngày: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtDuration, "Thời Gian: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtRegional, "Khu Vực: Danh mục bắt bắt buộc nhập");

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
