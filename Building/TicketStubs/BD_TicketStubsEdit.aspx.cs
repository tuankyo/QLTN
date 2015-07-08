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

namespace Man.Building.TicketStubs
{
    public partial class BD_TicketStubsEdit : Man.PageBase
    {
        private string action = String.Empty;
        private string id = String.Empty;

        private string updateSuccess = "Cập Nhật Thông Tin Đã Thành Công";
        private string updateUnSuccess = "Cập Nhật Thông Tin Không Thành Công";
        private string addSuccess = "Thêm Mới Thành Công";
        private string addUnSuccess = "Thêm Mới Không Thành Công";
        private string title = "Nhân Viên";
        private string postback = "window.opener.__doPostBack('PopupBD_TicketStubsEdit','');";
        private string key = "openBD_TicketStubsEdit";

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
            BD_TicketStubsData data = new BD_TicketStubsData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_TicketStubsData)tran.Result;
                txtSeriNumber.Text = data.SeriNumber;
                txtReceiveDate.Text = !"".Equals(data.ReceiveDate) ? Func.FormatDMY(data.ReceiveDate) : "";

                txtReceiveFrom.Text = data.ReceiveFrom;
                txtReceiver.Text = data.Receiver;
                txtMount.Text = data.Mount;
                txtPrice.Text = data.Price;
                chkDelFlag.Checked =  "1".Equals(data.DelFlag) ? false : true;
                txtComment.Text = data.Comment;

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
            BD_TicketStubsData data = new BD_TicketStubsData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_TicketStubsData)tran.Result;
                data.SeriNumber = txtSeriNumber.Text.Trim();
                data.ReceiveDate = !"".Equals(txtReceiveDate.Text.Trim()) ? Func.FormatYYYYmmdd(txtReceiveDate.Text.Trim()) : "";

                data.ReceiveFrom = txtReceiveFrom.Text.Trim();
                data.Receiver = txtReceiver.Text.Trim();
                data.Mount = txtMount.Text.Trim();
                data.Price = txtPrice.Text.Trim();
                data.Sum = "" + Func.ParseInt(txtMount.Text.Trim()) * Func.ParseInt(txtPrice.Text.Trim());
                data.Comment = txtComment.Text.Trim();
                data.DelFlag = true.Equals(chkDelFlag.Checked) ? "0" : "1";
                
                data.ModifiedBy = Page.User.Identity.Name;
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");

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
            BD_TicketStubsData data = new BD_TicketStubsData();
            ITransaction tran = factory.GetInsertObject(data);
            data.SeriNumber = txtSeriNumber.Text.Trim();
            data.ReceiveDate = !"".Equals(txtReceiveDate.Text.Trim()) ? Func.FormatYYYYmmdd(txtReceiveDate.Text.Trim()) : "";

            data.ReceiveFrom = txtReceiveFrom.Text.Trim();
            data.Receiver = txtReceiver.Text.Trim();
            data.Mount = txtMount.Text.Trim();
            data.Price = txtPrice.Text.Trim();
            data.Sum = "" + Func.ParseInt(txtMount.Text.Trim()) * Func.ParseInt(txtPrice.Text.Trim());

            data.ModifiedBy = Page.User.Identity.Name;
            data.CreatedBy = Page.User.Identity.Name;
            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.DelFlag = true.Equals(chkDelFlag.Checked) ? "0" : "1";

            data.Comment = txtComment.Text.Trim();
            data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);

            Execute(tran);

            if (!HasError)
            {
                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                mvMessage.SetCompleteMessage(addSuccess);
                ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);


                btnRegister.CommandName = "Register";
                hidAction.Value = "Edit";
                hidId.Value = data.id;
                txtSeriNumber.Enabled = false;

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

            hidId.Value = id;
            hidAction.Value = action;

            //DbHelper.FillList(drpJobTypeId, "Select * from MST_JobType where delFlag <> 1 ", "Name", "id");
            SqlDatabase db = new SqlDatabase();
            if (action == "Edit")
            {
                //lblHeader.Text = "Thông Tin Chi Tiết " + title;
                btnRegister.Text = "Cập Nhật";
                btnCancel.Text = "Đóng";
                btnRegister.CommandName = "Edit";
                txtSeriNumber.Enabled = false;
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
