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

using Gnt.Data;
using Man.Utils;
using Gnt.Data.DBCommand;
using System.Data.SqlClient;
using BusinessObjects;
using Gnt.Transaction;
using System.Text;

namespace Man.Building.Payment
{
    public partial class BD_PaymentType : PageBase
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

        private string updateSuccess = "Cập Nhật Thông Tin Đã Thành Công";
        private string updateUnSuccess = "Cập Nhật Thông Tin Không Thành Công";
        private string addSuccess = "Thêm Mới Thành Công";
        private string addUnSuccess = "Thêm Mới Không Thành Công";

        /// <summary>
        /// List data
        /// </summary>
        private void ShowData()
        {
            try
            {
                DbHelper.FillList(drpPaymentType, "Select Name,Id from BD_PaymentType Where delflag = 0 and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' Union Select Name, id From Mst_PaymentType", "Name", "id");
                DbHelper.FillList(drpUpdatePayment, "Select Name,Id from BD_PaymentType Where delflag = 0 and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' Union Select Name, id From Mst_PaymentType", "Name", "id");
                DbHelper.FillList(drpParentPaymentType, "Select Name,Id from BD_PaymentType Where delflag = 0 and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' Union Select Name, id From Mst_PaymentType", "Name", "id");

                string index = DbHelper.GetScalar("Select ParentId from BD_PaymentType where Delflag = 0 and id = '" + drpPaymentType.SelectedValue + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'");
                if (!String.IsNullOrEmpty(index))
                    drpParentPaymentType.SelectedValue = index;

                lstPaymentType.Items.Clear();
                bindToDropDown(lstPaymentType);
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }
        public void bindToDropDown(ListBox ddl)
        {
            //            DbHelper.FillList(drpPaymentType, "Select * from BD_PaymentType", "Name", "id");

            DataTable dt = DbHelper.GetDataTable("Select Name,Id,ParentId from BD_PaymentType Where Delflag = '0'  and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' union Select Name,Id,ParentId from Mst_PaymentType");

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["ParentId"].ToString() == "")
                {
                    ListItem item = new ListItem();
                    item.Text = dr["Name"].ToString();
                    item.Value = dr["Id"].ToString();
                    ddl.Items.Add(item);

                    GetChildItems(dr["Id"].ToString(), dt, ddl, "");
                }
            }
        }

        private void GetChildItems(string parentID, DataTable dtTemp, ListBox ddl, string str)
        {
            foreach (DataRow drr in dtTemp.Rows)
            {
                string child = "---";
                if (drr["ParentId"].ToString() == parentID.ToString())
                {
                    //child = child + "---";
                    ListItem chilitem = new ListItem();
                    chilitem.Text = str + child + drr["Name"].ToString();
                    chilitem.Value = drr["ID"].ToString();

                    ddl.Items.Add(chilitem);
                    GetChildItems(drr["ID"].ToString(), dtTemp, ddl, str + child);
                }
            }
        }
        /// <summary>
        /// Init values
        /// </summary>
        protected override void DoInit()
        {
        }
        protected void drpPaymentType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string index = DbHelper.GetScalar("Select ParentId from BD_PaymentType where Delflag = 0 and id = '" + drpPaymentType.SelectedValue + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'");
            if (!String.IsNullOrEmpty(index))
                drpParentPaymentType.SelectedValue = index;
        }

        protected void lstPaymentType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string index = DbHelper.GetScalar("Select ParentId from BD_PaymentType where  Delflag = 0 and id = '" + lstPaymentType.SelectedValue + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'");
            drpPaymentType.SelectedValue = lstPaymentType.SelectedValue;
            if (!String.IsNullOrEmpty(index))
                drpParentPaymentType.SelectedValue = index;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSetting_Click(object sender, EventArgs e)
        {
            int level = Func.ParseInt(DbHelper.GetScalar("Select isnull(itemlevel,0) + 1 from BD_PaymentType where id = '" + drpParentPaymentType.SelectedValue + "'"));
            string paidType = DbHelper.GetScalar("Select PaidType from BD_PaymentType where id = '" + drpParentPaymentType.SelectedValue + "'");

            if (drpParentPaymentType.SelectedValue.Equals("9"))
            {
                level = 1;
                paidType = "1";
            }
            if (drpParentPaymentType.SelectedValue.Equals("10"))
            {
                level = 1;
                paidType = "0";
            }

            if (level >= 4)
            {
                mvMessage.AddError("Không thể thiết lập vì Tối đa chỉ có 4 cấp Thu/Chi");
                return;
            }
            //Get and Insert Data
            BD_PaymentTypeData data = new BD_PaymentTypeData();
            ITransaction tran = factory.GetLoadObject(data, drpPaymentType.SelectedValue);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_PaymentTypeData)tran.Result;
                data.ParentId = drpParentPaymentType.SelectedValue;
                data.ItemLevel = Func.ParseString(level);
                data.PaidType = paidType;
                tran = factory.GetUpdateObject(data);

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(updateSuccess);
                    ShowData();
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(updateUnSuccess);
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopupWidth = 600;
                PopupHeight = 450;
                ShowData();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddPaymentType_Click(object sender, EventArgs e)
        {
            mvMessage.CheckRequired(txtPaymentType, "Danh mục Thu/Chi là yêu cầu bắt buộc");
            if (!mvMessage.IsValid) return;

            //Get and Insert Data
            BD_PaymentTypeData data = new BD_PaymentTypeData();
            ITransaction tran = factory.GetInsertObject(data);
            data.Name = txtPaymentType.Text.Trim();
            data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);
            data.ItemLevel = "0";
            data.ModifiedBy = Page.User.Identity.Name;
            data.CreatedBy = Page.User.Identity.Name;
            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.DelFlag = "0";

            Execute(tran);

            if (!HasError)
            {
                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                mvMessage.SetCompleteMessage(addSuccess);
                //DbHelper.FillList(drpPaymentType, "Select * from BD_PaymentType Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and Delflag = '0'", "Name", "id");
                DbHelper.FillList(drpPaymentType, "Select Name,Id from BD_PaymentType Where delflag = 0 and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' Union Select Name, id From Mst_PaymentType", "Name", "id");
                ShowData();
            }
            else
            {
                OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                mvMessage.AddError(addUnSuccess);
            }
        }
        protected void btnDeletePaymentType_Click(object sender, EventArgs e)
        {
            //Get and Insert Data
            BD_PaymentTypeData data = new BD_PaymentTypeData();
            ITransaction tran = factory.GetLoadObject(data, drpUpdatePayment.SelectedValue);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_PaymentTypeData)tran.Result;
                data.DelFlag = "1";

                tran = factory.GetUpdateObject(data);

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(updateSuccess);
                    //DbHelper.FillList(drpPaymentType, "Select * from BD_PaymentType Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and Delflag = '0'", "Name", "id");
                    DbHelper.FillList(drpPaymentType, "Select Name,Id from BD_PaymentType Where delflag = 0 and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' Union Select Name, id From Mst_PaymentType", "Name", "id");
                    ShowData();
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(updateUnSuccess);
                }
            }
        }
        protected void btnUpdatePaymentType_Click(object sender, EventArgs e)
        {
            //Get and Insert Data
            BD_PaymentTypeData data = new BD_PaymentTypeData();
            ITransaction tran = factory.GetLoadObject(data, drpUpdatePayment.SelectedValue);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_PaymentTypeData)tran.Result;
                data.Name = txtPaymentType.Text;

                tran = factory.GetUpdateObject(data);

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(updateSuccess);
                    //DbHelper.FillList(drpPaymentType, "Select * from BD_PaymentType Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and Delflag = '0'", "Name", "id");
                    DbHelper.FillList(drpPaymentType, "Select Name,Id from BD_PaymentType Where delflag = 0 and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' Union Select Name, id From Mst_PaymentType", "Name", "id");
                    ShowData();
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(updateUnSuccess);
                }
            }
        }
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PopupWidth = 600;
            PopupHeight = 450;
            ShowData();
        }
    }
}
