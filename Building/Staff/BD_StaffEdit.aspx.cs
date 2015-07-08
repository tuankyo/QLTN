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

namespace Man.Building.Staff
{
    public partial class BD_StaffEdit : Man.PageBase
    {
        private string action = String.Empty;
        private string id = String.Empty;

        private string updateSuccess = "Cập Nhật Thông Tin Đã Thành Công";
        private string updateUnSuccess = "Cập Nhật Thông Tin Không Thành Công";
        private string addSuccess = "Thêm Mới Thành Công";
        private string addUnSuccess = "Thêm Mới Không Thành Công";
        private string title = "Nhân Viên";
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
            BD_StaffData data = new BD_StaffData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_StaffData)tran.Result;
                txtStaffId.Text = data.StaffId;
                txtName.Text = data.Name;
                txtComment.Text = data.Comment;

                txtPhone.Text = data.Phone;
                txtAddress.Text = data.Address;
                txtMail.Text = data.Mail;
                txtJobBegin.Text = data.JobBegin;
                txtJobEnd.Text = !"".Equals(data.JobEnd) ? Func.Formatdmyhms(data.JobEnd) : "";

                txtJobBegin.Text = Func.FormatDMY(data.JobBegin);
                txtJobEnd.Text = Func.FormatDMY(data.JobEnd);

                DbHelper.FillList(drpPosition, "Select * from Mst_Position Where Jobtype = '" + data.JobTypeId + "'", "Position", "id");
                DbHelper.FillListSearch(drpWorkingPlace, "Select WorkingPlaceId + '('+ Name +')' As Name, ID from BD_WorkingPlace Where JobTypeId = '" + data.JobTypeId + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and DelFlag = 0", "Name", "id");

                drpWorkingPlace.SelectedValue = data.WorkingPlaceId;
                drpPosition.SelectedValue = data.Position;
                txtJobContent.Text = data.JobContent;
                chkDelFlag.Checked =  "1".Equals(data.DelFlag) ? false : true;

                lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void UpdateData()
        {
            BD_StaffData data = new BD_StaffData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_StaffData)tran.Result;
                data.Name = txtName.Text.Trim();
                data.Comment = txtComment.Text.Trim();

                data.ModifiedBy = Page.User.Identity.Name;
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag =  true.Equals(chkDelFlag.Checked) ? "0" : "1";

                data.Phone = txtPhone.Text;
                data.Address = txtAddress.Text;
                data.Mail = txtMail.Text;
                data.JobBegin = !"".Equals(txtJobBegin.Text) ? Func.FormatYYYYmmdd(txtJobBegin.Text) : "";
                data.JobEnd = !"".Equals(txtJobEnd.Text) ? Func.FormatYYYYmmdd(txtJobEnd.Text) : "";
                data.Position = drpPosition.SelectedValue;
                data.WorkingPlaceId = drpWorkingPlace.SelectedValue;

                data.JobContent = txtJobContent.Text;

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
            BD_StaffData data = new BD_StaffData();
            ITransaction tran = factory.GetInsertObject(data);
            data.Name = txtName.Text.Trim();
            data.Comment = txtComment.Text.Trim();
            data.ModifiedBy = Page.User.Identity.Name;
            data.CreatedBy = Page.User.Identity.Name;
            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.DelFlag = true.Equals(chkDelFlag.Checked) ? "0" : "1";
            data.JobContent = txtJobContent.Text;

            data.Phone = txtPhone.Text;
            data.Address = txtAddress.Text;
            data.Mail = txtMail.Text;
            data.JobBegin = !"".Equals(txtJobBegin.Text) ? Func.FormatYYYYmmdd(txtJobBegin.Text) : "";
            data.JobEnd = !"".Equals(txtJobEnd.Text) ? Func.FormatYYYYmmdd(txtJobEnd.Text) : "";

            data.JobTypeId = hidJobType.Value;
            data.Position = drpPosition.SelectedValue;
            data.WorkingPlaceId = drpWorkingPlace.SelectedValue;

            data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);
            data.StaffId = txtStaffId.Text;

            Execute(tran);

            if (!HasError)
            {
                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                mvMessage.SetCompleteMessage(addSuccess);
                ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);


                btnRegister.CommandName = "Register";
                hidAction.Value = "Edit";
                txtStaffId.Enabled = false;
                hidId.Value = data.id;

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
            hidJobType.Value = Func.ParseString(Request["JobType"]);

            DbHelper.FillList(drpPosition, "Select * from Mst_Position Where Jobtype = '"+ hidJobType.Value +"'", "Position", "id");
            DbHelper.FillListSearch(drpWorkingPlace, "Select WorkingPlaceId + '('+ Name +')' As Name, ID from BD_WorkingPlace Where JobTypeId = '" + hidJobType.Value + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and DelFlag = 0", "Name", "id");

            SqlDatabase db = new SqlDatabase();
            if (action == "Edit")
            {
                lblHeader.Text = "Thông Tin Chi Tiết " + title;
                btnRegister.Text = "Cập Nhật";
                btnCancel.Text = "Đóng";
                btnRegister.CommandName = "Edit";
                txtStaffId.Enabled = false;
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
            mvMessage.CheckRequired(txtStaffId, "Mã Nhân Viên: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtName, "Tên Nhân Viên: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtAddress, "Địa Chỉ: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtPhone, "Số Điện Thoại: Danh mục bắt bắt buộc nhập");
            //mvMessage.CheckRequired(txtMail, "Địa Chỉ Mail: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtJobBegin, "Thời gian vào làm từ: Danh mục bắt bắt buộc nhập");
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
