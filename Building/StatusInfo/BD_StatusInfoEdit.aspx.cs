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

namespace Man.Building.StatusInfo
{
    public partial class BD_StatusInfoEdit : Man.PageBase
    {
        private string action = String.Empty;
        private string id = String.Empty;

        private string updateSuccess = "Cập Nhật Thông Tin Đã Thành Công";
        private string updateUnSuccess = "Cập Nhật Thông Tin Không Thành Công";
        private string addSuccess = "Thêm Mới Thành Công";
        private string addUnSuccess = "Thêm Mới Không Thành Công";
        private string title = "Tình Trạng Lịch Sử";
        private string postback = "window.opener.__doPostBack('PopupBD_StatusInfoEdit','');";
        private string key = "openBD_StatusInfoEdit";

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
            BD_StatusInfoData data = new BD_StatusInfoData();
            ITransaction tran = factory.GetLoadObject(data, id);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_StatusInfoData)tran.Result;
                txtId.Text = data.id;
                txtRegion.Text = data.Region;
                txtFloor.Text = data.Floor;
                txtRoom.Text = data.Room;
                drpStatus.SelectedValue = data.Status;
                txtStatusDate.Text = Func.Formatdmyhms(data.StatusDate);
                txtComment.Text = data.Comment;
                chkDelFlag.Checked = "1".Equals(data.DelFlag) ? false : true;
                txtSystem.Text = data.System;
                txtDescription.Text = data.Description;
                txtSolution.Text = data.Solution;
                txtSolutioner.Text = data.Solutioner;

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
            BD_StatusInfoData data = new BD_StatusInfoData();
            ITransaction tran = factory.GetLoadObject(data, txtId.Text.Trim());
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_StatusInfoData)tran.Result;
                data.Region = txtRegion.Text.Trim();
                data.Floor = txtFloor.Text;
                data.Room = txtRoom.Text;
                data.Status = drpStatus.SelectedValue;
                data.StatusDate = Func.FormatYYYYmmdd(txtStatusDate.Text.Substring(0, 10));
                data.Comment = txtComment.Text;
                data.DelFlag = "1";
                data.System = txtSystem.Text;

                data.Description = txtDescription.Text;
                data.Solution = txtSolution.Text;
                data.Solutioner = txtSolutioner.Text;

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
                    //mvMessage.AddError(updateUnSuccess);
                }
            }
        }

        /// <summary>
        /// Insert data
        /// </summary>
        private void InsertData()
        {
            mvMessage.CheckRequired(txtRegion, "Khu vực là dữ liệu bắt buộc");
            mvMessage.CheckRequired(txtFloor, "Lầu là dữ liệu bắt buộc");
            mvMessage.CheckRequired(txtRoom, "Phòng là dữ liệu bắt buộc");
            mvMessage.CheckRequired(txtSystem, "Hạng mục là dữ liệu bắt buộc");
            mvMessage.CheckRequired(txtStatusDate, "Ngày là dữ liệu bắt buộc");
            mvMessage.CheckRequired(txtDescription, "Mô tả là dữ liệu bắt buộc");
            mvMessage.CheckRequired(txtSolution, "Hướng xử lý là dữ liệu bắt buộc");
            mvMessage.CheckRequired(txtSolutioner, "Người xử lý là dữ liệu bắt buộc");

            if (!mvMessage.IsValid) return;

            //Get and Insert Data
            BD_StatusInfoData data = new BD_StatusInfoData();
            ITransaction tran = factory.GetInsertObject(data);
            data.Region = txtRegion.Text.Trim();
            data.Floor = txtFloor.Text;
            data.Room = txtRoom.Text;
            data.Status = drpStatus.SelectedValue;
            data.StatusDate=Func.FormatYYYYmmdd(txtStatusDate.Text);
            data.Comment = txtComment.Text;
            data.DelFlag = "1";
            data.System = txtSystem.Text;
            data.Type = hidType.Value;

            data.Description = txtDescription.Text;
            data.Solution = txtSolution.Text;
            data.Solutioner = txtSolutioner.Text;

            data.ModifiedBy = Page.User.Identity.Name;
            data.CreatedBy = Page.User.Identity.Name;
            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.DelFlag = true.Equals(chkDelFlag.Checked) ? "0" : "1";
            //data.StatusInfoId = txtId.Text.Trim();

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
            hidStatusInfoType.Value = Request["StatusInfoType"];
            hidId.Value = id;
            hidAction.Value = action;
            txtId.Text = id;
            hidType.Value = Request["type"];
            DbHelper.FillList(drpStatus, "Select Status from Mst_Status", "Status", "Status");

            SqlDatabase db = new SqlDatabase();
            if (action == "Edit")
            {
                //lblHeader.Text = "Thông Tin Chi Tiết " + title;
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
                //lblHeader.Text = "Thêm Mới " + title;
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
            //mvMessage.CheckRequired(txtName, "Tên: Danh mục bắt bắt buộc nhập");
            //mvMessage.CheckRequired(txtContact, "Liên Lạc: Danh mục bắt bắt buộc nhập");
            //mvMessage.CheckRequired(txtVisitDate, "Ngày Tham Quan: Danh mục bắt bắt buộc nhập");
            //mvMessage.CheckRequired(txtPhone, "Điện Thoại: Danh mục bắt bắt buộc nhập");
            //mvMessage.CheckRequired(txtAddress, "Địa Chỉ: Danh mục bắt bắt buộc nhập");

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
