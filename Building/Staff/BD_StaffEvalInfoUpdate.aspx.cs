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
    public partial class BD_StaffEvalInfoUpdate : Man.PageBase
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

        private string updateUnSuccess = "Cập Nhật Thông Tin Không Thành Công";
        private string updateSuccess = "Cập Nhật Thành Công";
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
            id = Request["id"];
            hidID.Value = id;

            BD_StaffEvalInfoData data = new BD_StaffEvalInfoData();
            ITransaction tran = factory.GetLoadObject(data, id);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_StaffEvalInfoData)tran.Result;
                txtContentEval.Text = data.ContentEval;
                txtEvalDate.Text = Func.FormatDMY(data.EvalDate);
                txtComment.Text = data.Comment;

                BD_StaffData dataS = new BD_StaffData();
                ITransaction tranS = factory.GetLoadObject(dataS, data.StaffId);
                Execute(tranS);
                if (!HasError)
                {
                    //Get Data
                    dataS = (BD_StaffData)tranS.Result;
                    lblStaffId.Text = dataS.StaffId;
                    lblName.Text = dataS.Name;
                }
            }
        }

        private void UpdateData()
        {
            BD_StaffEvalInfoData data = new BD_StaffEvalInfoData();
            ITransaction tran = factory.GetLoadObject(data, hidID.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_StaffEvalInfoData)tran.Result;

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
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, updateSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(updateSuccess);
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, updateUnSuccess, Page.User.Identity.Name);
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
            id = Request["id"];
            hidID.Value = id;

            if (!IsPostBack)
            {
                LoadData();
            }
            btnRegister.Text = "Cập nhật";
            btnRegister.CommandName = "Hủy";
            btnCancel.Text = "Đóng";
        }

        protected override void DoPost()
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            mvMessage.CheckRequired(txtEvalDate, "Ngày Đánh Giá: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtContentEval, "Nội Dung Đánh Giá: Danh mục bắt bắt buộc nhập");
            if (!mvMessage.IsValid) return;
            UpdateData();
        }
    }
}
