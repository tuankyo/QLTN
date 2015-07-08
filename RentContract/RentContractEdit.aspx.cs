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

namespace Man.RentContract
{
    public partial class RentContractEdit : Man.PageBase
    {
        private string action = String.Empty;
        private string id = String.Empty;

        private string updateSuccess = "Cập Nhật Thông Tin Đã Thành Công";
        private string updateUnSuccess = "Cập Nhật Thông Tin Không Thành Công";
        private string addSuccess = "Thêm Mới Thành Công";
        private string addUnSuccess = "Thêm Mới Không Thành Công";
        private string title = "Hợp Đồng Thuê";
        private string postback = "window.opener.__doPostBack('PopupRentContractEdit','');";
        private string key = "openRentContractEdit";

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
            RentContractData data = new RentContractData();
            ITransaction tran = factory.GetLoadObject(data, id);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (RentContractData)tran.Result;
                txtId.Text = data.ContractId;
                txtCustomerId.Text = data.CustomerId;
                txtContractDate.Text = Func.FormatDMY(data.ContractDate);
                txtContractEndDate.Text = Func.FormatDMY(data.ContractEndDate);
                txtReceiveDate.Text = Func.FormatDMY(data.ReceiveDate);
                txtStaffMount.Text = data.StaffMount;
                txtComment.Text = data.Comment;
                txtContractNo.Text = data.ContractNo;
                chkDelFlag.Checked = "1".Equals(data.DelFlag) ? false : true;
                lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";

                txtCarParkingMount.Text = data.CarParkingMount;
                txtMotorParkingMount.Text = data.MotorParkingMount;
                txtBycParkingMount.Text = data.BycParkingMount;
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void UpdateData()
        {
            int count = DbHelper.GetCount("select Count(*) From RentContract Where ContractNo = '" + txtContractNo.Text + "' and ContractId <> '" + hidId.Value + "'");
            if (count > 0)
            {
                mvMessage.AddError("Lỗi xảy ra: Số Hợp Đồng đã tồn tại");
                return;
            }

            RentContractData data = new RentContractData();
            ITransaction tran = factory.GetLoadObject(data, txtId.Text);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (RentContractData)tran.Result;
                data.CustomerId = txtCustomerId.Text.Trim();
                data.ContractDate = Func.FormatYYYYmmdd(txtContractDate.Text.Trim());
                data.ContractEndDate = Func.FormatYYYYmmdd(txtContractEndDate.Text.Trim());
                data.ReceiveDate = Func.FormatYYYYmmdd(txtReceiveDate.Text.Trim());
                data.Comment = txtComment.Text.Trim();
                data.StaffMount = txtStaffMount.Text.Trim();
                data.ModifiedBy = Page.User.Identity.Name;
                data.CreatedBy = Page.User.Identity.Name;
                data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag = true.Equals(chkDelFlag.Checked) ? "0" : "1";
                data.CarParkingMount = txtCarParkingMount.Text.Trim();
                data.MotorParkingMount = txtMotorParkingMount.Text.Trim();
                data.BycParkingMount = txtBycParkingMount.Text.Trim();

                data.ContractNo = txtContractNo.Text;

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
        private bool checkData()
        {
            mvMessage.CheckRequired(txtContractDate, "Ngày hợp đồng: là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtContractEndDate, "Ngày kết thúc hợp đồng: là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtContractNo, "Số hợp đồng: là Danh mục bắt bắt buộc nhập");

            if (!mvMessage.IsValid) return false;
            return true;
        }
        /// <summary>
        /// Insert data
        /// </summary>
        private void InsertData()
        {
            int count = DbHelper.GetCount("select Count(*) From RentContract Where ContractNo = '" + txtContractNo.Text + "'");
            if (count > 0)
            {
                mvMessage.AddError("Lỗi xảy ra: Số Hợp Đồng đã tồn tại");
                return;
            }
            //Get and Insert Data
            RentContractData data = new RentContractData();
            ITransaction tran = factory.GetInsertObject(data);
            data.ContractId = txtId.Text.Trim();
            data.CustomerId = txtCustomerId.Text.Trim();
            data.ContractDate = Func.FormatYYYYmmdd(txtContractDate.Text.Trim());
            data.ContractEndDate = Func.FormatYYYYmmdd(txtContractEndDate.Text.Trim());
            data.ReceiveDate = Func.FormatYYYYmmdd(txtReceiveDate.Text.Trim());
            data.StaffMount = txtStaffMount.Text.Trim();
            data.Comment = txtComment.Text.Trim();
            data.ModifiedBy = Page.User.Identity.Name;
            data.CreatedBy = Page.User.Identity.Name;
            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.DelFlag = true.Equals(chkDelFlag.Checked) ? "0" : "1";
            data.CarParkingMount = txtCarParkingMount.Text.Trim();
            data.MotorParkingMount = txtMotorParkingMount.Text.Trim();
            data.BycParkingMount = txtBycParkingMount.Text.Trim();
            data.ContractNo = txtContractNo.Text;

            data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);

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
            action = Request["Action"];
            id = Request["id"];
            chkDelFlag.Enabled = DbHelper.isAdmin(Page.User.Identity.Name);

            txtCustomerId.Text = Request["CustomerId"];
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
            if (!checkData())
                return;

            //mvMessage.CheckRequired(txtName, "* là Danh mục bắt bắt buộc nhập");
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
