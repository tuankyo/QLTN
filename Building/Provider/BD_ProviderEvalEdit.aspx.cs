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

namespace Man.Building.Provider
{
    public partial class BD_ProviderEvalEdit : Man.PageBase
    {
        private string action = String.Empty;
        private string id = String.Empty;

        private string updateSuccess = "Cập Nhật Thông Tin Đã Thành Công";
        private string updateUnSuccess = "Cập Nhật Thông Tin Không Thành Công";
        private string addSuccess = "Thêm Mới Thành Công";
        private string addUnSuccess = "Thêm Mới Không Thành Công";
        private string deleteSuccess = "Xóa Thành Công";
        private string deleteUnSuccess = "Xóa Không Thành Công";
        private string title = "Đánh Giá Nhà Cung Cấp";
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
            BD_ProviderEvalData data = new BD_ProviderEvalData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_ProviderEvalData)tran.Result;
                txtContentEval.Text = data.ContentEval;
                txtEvalDate.Text = Func.FormatDMY(data.EvalDate);
                txtComment.Text = data.Comment;
                lblProviderId.Text = data.ProviderId;


                BD_ProviderData dataP = new BD_ProviderData();
                ITransaction tranP = factory.GetLoadObject(dataP, lblProviderId.ID);
                Execute(tranP);
                if (!HasError)
                {
                    //Get Data
                    dataP = (BD_ProviderData)tranP.Result;
                    lblName.Text = dataP.Name;
                }
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void UpdateData()
        {
            BD_ProviderEvalData data = new BD_ProviderEvalData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_ProviderEvalData)tran.Result;
                data.ContentEval = txtContentEval.Text.Trim();
                data.EvalDate = Func.FormatYYYYmmdd(txtEvalDate.Text.Trim());
                data.Comment = txtComment.Text.Trim();
                data.ModifiedBy = Page.User.Identity.Name;
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag = "0";
                tran = factory.GetUpdateObject(data);

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, deleteSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(deleteSuccess);
                    ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);
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
            InitValues();
        }
        protected override void DoGet()
        {
            hidId.Value = Request["id"];
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected override void DoPost()
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            mvMessage.CheckRequired(txtContentEval, "Nội Dung Đánh Giá: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtEvalDate, "Ngày Đánh Giá: Danh mục bắt bắt buộc nhập");

            if (!mvMessage.IsValid) return;
            UpdateData();
        }
    }
}
