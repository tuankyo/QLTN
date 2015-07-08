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
    public partial class BD_SuppliesStatusUpdate : Man.PageBase
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
        private string deleteSuccess = "Xóa Thành Công";
        private string deleteUnSuccess = "Xóa Không Thành Công";
        private string title = "Biểu Phí Tiền Nước";
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
            DbHelper.FillList(drpSuppliesStatus, "SELECT C.SuppliesStatus, C.id FROM dbo.BD_Supplies AS A INNER JOIN BD_SuppliesStatus AS B ON A.id = B.SuppliesId INNER JOIN Mst_SuppliesStatus AS C ON A.SuppliesType = C.SuppliesType WHERE B.id = '" + id + "'", "SuppliesStatus", "id");

            BD_SuppliesStatusData data = new BD_SuppliesStatusData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_SuppliesStatusData)tran.Result;

                txtDescription.Text = data.Description;
                txtProcessDate.Text = data.ProcessDate;
                txtComment.Text = data.Comment;
                drpSuppliesStatus.SelectedValue = DbHelper.GetScalar("SELECT C.id FROM dbo.BD_Supplies AS A INNER JOIN BD_SuppliesStatus AS B ON A.id = B.SuppliesId INNER JOIN Mst_SuppliesStatus AS C ON A.SuppliesType = C.SuppliesType WHERE B.id = '" + id + "' and C.SuppliesStatus = N'"+ data.SuppliesStatus +"'");
                txtSolution.Text = data.Solution;
                txtSolutioner.Text = data.Solutioner;

                txtRegion.Text = data.Region;
                txtFloor.Text = data.Floor;
                txtRoom.Text= data.Room;
                txtSystem.Text = data.System;
                BD_SuppliesData dataS = new BD_SuppliesData();
                ITransaction tranS = factory.GetLoadObject(dataS, data.SuppliesId);
                Execute(tranS);
                if (!HasError)
                {
                    //Get Data
                    dataS = (BD_SuppliesData)tranS.Result;
                    lblCreatedId.Text = dataS.CreatedId;
                    lblName.Text = dataS.Name;
                }
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void DeleteData(string strId)
        {
            BD_SuppliesStatusData data = new BD_SuppliesStatusData();
            ITransaction tran = factory.GetLoadObject(data, strId);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_SuppliesStatusData)tran.Result;
                data.DelFlag = "1";
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
        /// Insert data
        /// </summary>
        private void UpdateData()
        {
            mvMessage.CheckRequired(txtDescription, "Mô tả: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtProcessDate, "Ngày: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(drpSuppliesStatus, "Tình Trạng: Danh mục bắt bắt buộc nhập");

            if (!mvMessage.IsValid) return;

            //Get and Insert Data
            BD_SuppliesStatusData data = new BD_SuppliesStatusData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                data = (BD_SuppliesStatusData)tran.Result;

                data.Description = txtDescription.Text.Trim();
                data.ProcessDate = Func.FormatYYYYmmdd(txtProcessDate.Text.Trim());
                data.Comment = txtComment.Text.Trim();
                data.SuppliesStatus = drpSuppliesStatus.SelectedItem.Text;
                data.ModifiedBy = Page.User.Identity.Name;
                data.CreatedBy = Page.User.Identity.Name;
                data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag = "0";
                data.Solution = txtSolution.Text.Trim();
                data.Solutioner = txtSolutioner.Text.Trim();

                data.Region = txtRegion.Text.Trim();
                data.Floor = txtFloor.Text;
                data.Room = txtRoom.Text;
                data.System = txtSystem.Text;

                tran = factory.GetUpdateObject(data);
                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(updateSuccess);
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, updateUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(addUnSuccess);
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
            hidId.Value = id;

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
            //mvMessage.CheckRequired(txt, "* là Danh mục bắt bắt buộc nhập");
            UpdateData();
        }

    }
}
