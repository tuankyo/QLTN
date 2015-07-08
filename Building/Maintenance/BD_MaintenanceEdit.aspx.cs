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

namespace Man.Building.Maintenance
{
    public partial class BD_MaintenanceEdit : Man.PageBase
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
        private string title = "Thông Tin Làm Thêm Của Nhân Viên";
        private string postback = "window.opener.__doPostBack('PopupBD_StaffEdit','');";
        private string key = "openBD_StaffEdit";
        private string deleteSuccess = "Xóa Thành Công";
        private string deleteUnSuccess = "Xóa Không Thành Công";

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

        }

        /// <summary>
        /// Update
        /// </summary>
        private void UpdateData()
        {
            BD_MaintenanceData data = new BD_MaintenanceData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_MaintenanceData)tran.Result;
                data.ModifiedBy = Page.User.Identity.Name;
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag = true.Equals(chkDelFlag.Checked) ? "0" : "1";

                data.ExecDate = Func.FormatYYYYmmdd(txtExecDate.Text);
                data.ExecDescription = txtExecDescription.Text;
                data.ExecComment = txtExecComment.Text;
                data.ExecCompany = txtExecCompany.Text;
                data.ExecConfirmer = txtExecConfirmer.Text;

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
        /// Init values
        /// </summary>
        protected override void DoInit()
        {
            id = Request["id"];

            hidId.Value = id;
            chkDelFlag.Enabled = DbHelper.isAdmin(Page.User.Identity.Name);

            BD_MaintenanceData data = new BD_MaintenanceData();
            ITransaction tran = factory.GetLoadObject(data, id);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_MaintenanceData)tran.Result;
                txtYear.Text = data.Year;
                txtMonth.Text = data.Month;
                txtWeek.Text = data.Week;
                txtMainName.Text = data.MainName;
                txtSubName.Text = data.SubName;
                txtExecDate.Text = Func.FormatDMY(data.ExecDate);
                txtExecDescription.Text = data.ExecDescription;
                txtExecComment.Text = data.ExecComment;
                txtExecCompany.Text = data.ExecCompany;
                txtExecConfirmer.Text = data.ExecConfirmer;

                lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";

                hidId.Value = id;
            }

        }
        protected override void DoGet()
        {
            id = Request["id"];
            chkDelFlag.Enabled = DbHelper.isAdmin(Page.User.Identity.Name);

            hidId.Value = id;

            lblHeader.Text = "Thông Tin Chi Tiết " + title;
            btnRegister.Text = "Cập Nhật";
            btnCancel.Text = "Đóng";
            btnRegister.CommandName = "Edit";
        }

        protected override void DoPost()
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //mvMessage.CheckRequired(txtName, "* là Danh mục bắt bắt buộc nhập");
            UpdateData();
        }
    }
}
