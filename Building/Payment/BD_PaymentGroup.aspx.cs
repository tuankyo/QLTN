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
    public partial class BD_PaymentGroup : PageBase
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
                DbHelper.FillList(lstPayment, "Select * from BD_PaymentType Where id not in (Select PaymentTypeId from BD_SetPaymentGroup) and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and Delflag <> '1' ", "PaymentType", "id");
                DbHelper.FillList(lstAddedPayment, "SELECT B.id, A.PaymentType FROM BD_PaymentType AS A INNER JOIN BD_SetPaymentGroup AS B ON A.id = B.PaymentTypeId and B.PaymentGroupId = '" + drpPaymentGroup.SelectedValue + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "PaymentType", "id");
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }

        /// <summary>
        /// Init values
        /// </summary>
        protected override void DoInit()
        {
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopupWidth = 600;
                PopupHeight = 450;
                DbHelper.FillList(drpPaymentGroup, "Select * from BD_PaymentGroup Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "PaymentGroupName", "id");
                DbHelper.FillList(drpPaymentType, "Select * from BD_PaymentType Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "PaymentType", "id");
                ShowData();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdateGroup_Click(object sender, EventArgs e)
        {
            //Get and Insert Data
            BD_PaymentGroupData data = new BD_PaymentGroupData();
            ITransaction tran = factory.GetLoadObject(data, drpPaymentGroup.SelectedValue);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_PaymentGroupData)tran.Result;
                data.PaymentGroupName = txtPaymentGroup.Text.Trim();

                tran = factory.GetUpdateObject(data);

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(updateSuccess);
                    DbHelper.FillList(drpPaymentGroup, "Select * from BD_PaymentGroup Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "PaymentGroupName", "id");
                    ShowData();
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(updateUnSuccess);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddGroup_Click(object sender, EventArgs e)
        {
            //Get and Insert Data
            BD_PaymentGroupData data = new BD_PaymentGroupData();
            ITransaction tran = factory.GetInsertObject(data);
            data.PaymentGroupName = txtPaymentGroup.Text.Trim();
            data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);

            Execute(tran);

            if (!HasError)
            {
                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                mvMessage.SetCompleteMessage(addSuccess);
                DbHelper.FillList(drpPaymentGroup, "Select * from BD_PaymentGroup Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "PaymentGroupName", "id");

                ShowData();
            }
            else
            {
                OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                mvMessage.AddError(addUnSuccess);
            }
        }
        protected void btnSetGroup_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in lstPayment.Items)
            {
                if (li.Selected == true)
                {
                    //Get and Insert Data
                    BD_SetPaymentGroupData data = new BD_SetPaymentGroupData();
                    ITransaction tran = factory.GetInsertObject(data);
                    data.PaymentTypeId = li.Value;
                    data.PaymentGroupId = drpPaymentGroup.SelectedValue;

                    Execute(tran);

                    if (!HasError)
                    {
                        OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                        mvMessage.SetCompleteMessage(addSuccess);
                    }
                    else
                    {
                        OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                        mvMessage.AddError(addUnSuccess);
                    }
                }
            }
            ShowData();

        }
        protected void btnRemoveGroup_Click(object sender, EventArgs e)
        {
            string lstId = "";
            foreach (ListItem li in lstAddedPayment.Items)
            {
                if (li.Selected == true)
                {

                    lstId += ",'" + li.Value + "'";
                }
            }
            DbHelper.ExecuteNonQuery("Delete From BD_SetPaymentGroup Where id in (" + lstId.Substring(1) + ")");

            ShowData();
        }
        protected void btnGroupChange_Click(object sender, EventArgs e)
        {
            ShowData();
        }
        protected void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            DbHelper.ExecuteNonQuery("Delete From BD_PaymentGroup Where id = '"+ drpPaymentGroup.SelectedValue +"'");
            DbHelper.ExecuteNonQuery("Delete From BD_SetPaymentGroup Where PaymentGroupId = '" + drpPaymentGroup.SelectedValue + "'");
            DbHelper.FillList(drpPaymentGroup, "Select * from BD_PaymentGroup Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "PaymentGroupName", "id");
            ShowData();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddPaymentType_Click(object sender, EventArgs e)
        {
            //Get and Insert Data
            BD_PaymentTypeData data = new BD_PaymentTypeData();
            ITransaction tran = factory.GetInsertObject(data);
            data.Name = txtPaymentType.Text.Trim();
            data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);
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
                DbHelper.FillList(drpPaymentType, "Select * from BD_PaymentType Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "PaymentType", "id");

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
            DbHelper.ExecuteNonQuery("Delete From BD_PaymentType Where id = '" + drpPaymentType.SelectedValue + "'");
            DbHelper.FillList(drpPaymentType, "Select * from BD_PaymentType Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "PaymentType", "id");
            ShowData();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdatePaymentType_Click(object sender, EventArgs e)
        {
            //Get and Insert Data
            BD_PaymentTypeData data = new BD_PaymentTypeData();
            ITransaction tran = factory.GetLoadObject(data, drpPaymentType.SelectedValue);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_PaymentTypeData)tran.Result;
                data.Name = txtPaymentType.Text.Trim();

                tran = factory.GetUpdateObject(data);

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(updateSuccess);
                    DbHelper.FillList(drpPaymentType, "Select * from BD_PaymentType Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "PaymentType", "id");
                    ShowData();
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(updateUnSuccess);
                }
            }
        }
    }
}
