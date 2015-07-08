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

namespace Man.Building.Supplies
{
    public partial class BD_SuppliesGroup : PageBase
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
                DbHelper.FillList(lstSupplies, "Select * from BD_Supplies Where id not in (Select SuppliesId from BD_SetSuppliesGroup) and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and SuppliesType = '" + hidSuppliesType.Value + "' and Delflag = 0 ", "Name", "id");
                DbHelper.FillList(lstAddedSupplies, "SELECT B.id, A.Name FROM BD_Supplies AS A INNER JOIN BD_SetSuppliesGroup AS B ON A.id = B.SuppliesId and B.SuppliesGroupId = '" + drpSuppliesGroup.SelectedValue + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.SuppliesType = '" + hidSuppliesType.Value + "' and A.DelFlag = 0 ", "Name", "id");
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
            hidSuppliesType.Value = Func.ParseString(Request["SuppliesType"]);
            switch (hidSuppliesType.Value)
            {
                case "1":
                    ltrPage.Text = "Quản lý hoạt động > Vật tư > Danh sách";
                    break;
                case "2":
                    ltrPage.Text = "Quản lý hoạt động > Thiết bị > Danh sách";
                    break;
                case "3":
                    ltrPage.Text = "Kế toán > Vật tư > Danh sách";
                    break;
                case "4":
                    ltrPage.Text = "Kế toán > Thiết bị > Danh sách";
                    break;
                case "5":
                    ltrPage.Text = "Kỹ thuật > Vật tư > Danh sách";
                    break;
                case "6":
                    ltrPage.Text = "Kỹ thuật > Thiết bị > Danh sách";
                    break;
            }
            if (!IsPostBack)
            {
                PopupWidth = 600;
                PopupHeight = 450;
                DbHelper.FillList(drpSuppliesGroup, "Select * from BD_SuppliesGroup Where SuppliesType = '" + hidSuppliesType.Value + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "GroupName", "id");
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
            BD_SuppliesGroupData data = new BD_SuppliesGroupData();
            ITransaction tran = factory.GetLoadObject(data, drpSuppliesGroup.SelectedValue);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_SuppliesGroupData)tran.Result;
                data.GroupName = txtSuppliesGroup.Text.Trim();

                tran = factory.GetUpdateObject(data);

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(updateSuccess);
                    DbHelper.FillList(drpSuppliesGroup, "Select * from BD_SuppliesGroup Where SuppliesType = '" + hidSuppliesType.Value + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "GroupName", "id");
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
            BD_SuppliesGroupData data = new BD_SuppliesGroupData();
            ITransaction tran = factory.GetInsertObject(data);
            data.GroupName = txtSuppliesGroup.Text.Trim();
            data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);
            data.SuppliesType = hidSuppliesType.Value;

            Execute(tran);

            if (!HasError)
            {
                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                mvMessage.SetCompleteMessage(addSuccess);
                DbHelper.FillList(drpSuppliesGroup, "Select * from BD_SuppliesGroup Where SuppliesType = '" + hidSuppliesType.Value + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "GroupName", "id");

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
            foreach (ListItem li in lstSupplies.Items)
            {
                if (li.Selected == true)
                {
                    //Get and Insert Data
                    BD_SetSuppliesGroupData data = new BD_SetSuppliesGroupData();
                    ITransaction tran = factory.GetInsertObject(data);
                    data.SuppliesId = li.Value;
                    data.SuppliesGroupId = drpSuppliesGroup.SelectedValue;

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
            foreach (ListItem li in lstAddedSupplies.Items)
            {
                if (li.Selected == true)
                {

                    lstId += ",'" + li.Value + "'";
                }
            }
            DbHelper.ExecuteNonQuery("Delete From BD_SetSuppliesGroup Where id in (" + lstId.Substring(1) + ")");

            ShowData();
        }
        protected void btnGroupChange_Click(object sender, EventArgs e)
        {
            ShowData();
        }
        protected void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            DbHelper.ExecuteNonQuery("Delete From BD_SuppliesGroup Where id = '"+ drpSuppliesGroup.SelectedValue +"'");
            DbHelper.ExecuteNonQuery("Delete From BD_SetSuppliesGroup Where SuppliesGroupId = '" + drpSuppliesGroup.SelectedValue + "'");
            DbHelper.FillList(drpSuppliesGroup, "Select * from BD_SuppliesGroup Where SuppliesType = '" + hidSuppliesType.Value + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "GroupName", "id");
            ShowData();
        }
    }
}
