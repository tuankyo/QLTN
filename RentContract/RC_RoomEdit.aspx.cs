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
    public partial class RC_RoomEdit : Man.PageBase
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
        private string title = "Biểu Phí Tiền Nước";
        private string postback = "window.opener.__doPostBack('PopupRC_Room','');";
        private string key = "openRC_Room";

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
            for (int i = 2010; i < 2050; i++)
            {
                drpBeginYear.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i), Func.ParseString(i)));
                drpEndYear.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i), Func.ParseString(i)));
            }
            drpBeginYear.Items.FindByValue(DateTime.Now.AddMonths(0).ToString("yyyy")).Selected = true;
            drpEndYear.Items.FindByValue(DateTime.Now.AddMonths(0).ToString("yyyy")).Selected = true;

            for (int i = 1; i < 13; i++)
            {
                drpBeginMonth.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
                drpEndMonth.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
            }
            drpBeginMonth.Items.FindByValue(DateTime.Now.AddMonths(0).ToString("MM")).Selected = true;
            drpEndMonth.Items.FindByValue(DateTime.Now.AddMonths(0).ToString("MM")).Selected = true;

            string sqlElec = " SELECT distinct ID, Name";
            sqlElec += " FROM BD_FeeGroup B ";
            sqlElec += " WHERE B.DelFlag <> '1' and FeeGroup = 1 and B.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";

            string sqlWater = " SELECT distinct ID, Name";
            sqlWater += " FROM BD_FeeGroup B ";
            sqlWater += " WHERE B.DelFlag <> '1' and FeeGroup = 2 and B.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";

            DbHelper.FillList(drpTariffsOfElec, sqlElec, "Name", "ID");
            DbHelper.FillList(drpTariffsOfWater, sqlWater, "Name", "ID");
            DbHelper.FillList(drpRoom, "Select ID, '(' + ID + ')   ' + Name + '(' + Regional + '-' + [FLOOR] + '-' + convert(nvarchar(10),Area) + 'm2)' as RoomName from BD_Room Where DelFlag <> '1' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' Order by Floor", "RoomName", "ID");

            string contractID = "";
            RC_RoomData dataRoom = new RC_RoomData();
            ITransaction tranRoom = factory.GetLoadObject(dataRoom, id);
            Execute(tranRoom);
            if (!HasError)
            {
                //Get Data
                dataRoom = (RC_RoomData)tranRoom.Result;

                drpRoom.SelectedValue = dataRoom.RoomId;

                txtVAT.Text = dataRoom.VAT;
                txtManagerPriceVND.Text = Func.ParseString(Func.ParseDouble(dataRoom.MonthManagerPriceVND));
                txtManagerPriceUSD.Text = Func.ParseString(Func.ParseDouble(dataRoom.MonthManagerPriceUSD));

                txtRentPriceVND.Text = Func.ParseString(Func.ParseDouble(dataRoom.MonthRentPriceVND));
                txtRentPriceUSD.Text = Func.ParseString(Func.ParseDouble(dataRoom.MonthRentPriceUSD));

                lblComment.Text = dataRoom.Comment;
                drpTariffsOfElec.SelectedValue = dataRoom.TariffsOfElecId;
                drpTariffsOfWater.SelectedValue = dataRoom.TariffsOfWaterId;
                txtContractDate.Text = Func.Formatdmyhms(dataRoom.BeginContract);
                txtContractEndDate.Text = Func.Formatdmyhms(dataRoom.EndContract);

                txtHourExtraTimePriceUsd.Text = Func.ParseString(Func.ParseDouble(dataRoom.HourExtraTimePriceUsd));
                txtHourExtraTimePriceVND.Text = Func.ParseString(Func.ParseDouble(dataRoom.HourExtraTimePriceVND));
                txtMonthExtraTimePriceUSD.Text = Func.ParseString(Func.ParseDouble(dataRoom.MonthExtraTimePriceUsd));
                txtMonthExtraTimePriceVND.Text = Func.ParseString(Func.ParseDouble(dataRoom.MonthExtraTimePriceVND));

                chkRentType.Checked = dataRoom.RentType == "1" ? true : false;
                chkManagerType.Checked = dataRoom.ManagerType == "1" ? true : false;

                txtElecPricePercent.Text = dataRoom.ElecPricePercent;
                txtWaterPricePercent.Text = dataRoom.WaterPricePercent;
                txtRentArea.Text = dataRoom.RentArea;
                contractID = dataRoom.ContractId;

                if (!dataRoom.FitoutBegin.Equals(""))
                {
                    drpBeginYear.SelectedValue = dataRoom.FitoutBegin.Substring(0, 4);
                    drpBeginMonth.SelectedValue = dataRoom.FitoutBegin.Substring(4, 2);
                }
                if (!dataRoom.FitoutEnd.Equals(""))
                {
                    drpEndYear.SelectedValue = dataRoom.FitoutEnd.Substring(0, 4);
                    drpEndMonth.SelectedValue = dataRoom.FitoutEnd.Substring(4, 2);
                }

                chkFitoutManager.Checked = (dataRoom.FitoutManager.Equals("1") ? true : false);
                chkFitoutParking.Checked = (dataRoom.FitoutParking.Equals("1") ? true : false);
                chkFitoutService.Checked = (dataRoom.FitoutService.Equals("1") ? true : false);
                chkFitoutWater.Checked = (dataRoom.FitoutWater.Equals("1") ? true : false);
                chkFitoutElec.Checked = (dataRoom.FitoutElec.Equals("1") ? true : false);
                chkFitoutExtraTime.Checked = (dataRoom.FitoutExtraTime.Equals("1") ? true : false);

                RentContractData data = new RentContractData();
                ITransaction tran = factory.GetLoadObject(data, contractID);
                Execute(tran);
                if (!HasError)
                {
                    //Get Data
                    data = (RentContractData)tran.Result;
                    lblId.Text = data.ContractId;
                    lblCustomerId.Text = data.CustomerId;
                    lblContractDate.Text = Func.Formatdmyhms(data.ContractDate);
                    lblContractEndDate.Text = Func.Formatdmyhms(data.ContractEndDate);
                    lblReceiveDate.Text = Func.Formatdmyhms(data.ReceiveDate);
                    lblStaffMount.Text = data.StaffMount;
                    lblComment.Text = data.Comment;
                }
            }
        }

        /// <summary>
        /// Insert data
        /// </summary>
        private void UpdateData()
        {
            double BeginContract = Func.ParseDouble(Func.FormatYYYYmmdd(txtContractDate.Text.Substring(0, 10)));
            double EndContract = Func.ParseDouble(Func.FormatYYYYmmdd(txtContractEndDate.Text.Substring(0, 10)));

            //string exit = DbHelper.GetScalar("Select Count(*) from RC_Room Where id <> '"+ hidId.Value +"' and delflag = 0 and (BeginContract <= '" + BeginContract + "' and '" + BeginContract + "' <= EndContract) or (BeginContract <= '" + EndContract + "' and '" + EndContract + "' <= EndContract) or ('" + EndContract + "' <= BeginContract and '" + EndContract + "' >= EndContract)");
            //if (!exit.Equals("0"))
            //{
            //    mvMessage.AddError("Phòng này đang được cho thuê");
            //    return;
            //}

            //Get and Insert Data
            RC_RoomData data = new RC_RoomData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (RC_RoomData)tran.Result;
                data.RoomId = drpRoom.SelectedValue;

                data.VAT = txtVAT.Text.Replace(",", ".");
                data.MonthManagerPriceVND = txtManagerPriceVND.Text.Trim().Replace(",", ".");
                data.MonthManagerPriceUSD = txtManagerPriceUSD.Text.Trim().Replace(",", ".");

                data.MonthRentPriceVND = txtRentPriceVND.Text.Trim().Replace(",", ".");
                data.MonthRentPriceUSD = txtRentPriceUSD.Text.Trim().Replace(",", ".");

                data.Comment = txtComment.Text.Trim();
                data.ModifiedBy = Page.User.Identity.Name;
                data.CreatedBy = Page.User.Identity.Name;
                data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag = "0";

                data.TariffsOfElecId = drpTariffsOfElec.SelectedValue;
                data.TariffsOfWaterId = drpTariffsOfWater.SelectedValue;

                data.BeginContract = Func.FormatYYYYmmdd(txtContractDate.Text.Substring(0, 10));
                data.EndContract = Func.FormatYYYYmmdd(txtContractEndDate.Text.Substring(0, 10));

                data.HourExtraTimePriceUsd = txtHourExtraTimePriceUsd.Text.Replace(",", ".");
                data.HourExtraTimePriceVND = txtHourExtraTimePriceVND.Text.Replace(",", ".");

                data.MonthExtraTimePriceUsd = txtMonthExtraTimePriceUSD.Text.Replace(",", ".");
                data.MonthExtraTimePriceVND = txtMonthExtraTimePriceVND.Text.Replace(",", ".");

                data.RentType = chkRentType.Checked == true ? "1" : "0";
                data.ManagerType = chkManagerType.Checked == true ? "1" : "0";

                data.ElecPricePercent = txtElecPricePercent.Text.Replace(",", ".");
                data.WaterPricePercent = txtWaterPricePercent.Text.Replace(",", ".");
                data.RentArea = txtRentArea.Text.Replace(",", ".");

                data.HourExtraTimePriceUsd = txtHourExtraTimePriceUsd.Text.Replace(",", ".");
                data.HourExtraTimePriceVND = txtHourExtraTimePriceVND.Text.Replace(",", ".");
                data.MonthExtraTimePriceUsd = txtMonthExtraTimePriceUSD.Text.Replace(",", ".");
                data.MonthExtraTimePriceVND = txtMonthExtraTimePriceVND.Text.Replace(",", ".");

                data.FitoutBegin = drpBeginYear.SelectedValue + drpBeginMonth.SelectedValue;
                data.FitoutEnd = drpEndYear.SelectedValue + drpEndMonth.SelectedValue;
                data.FitoutManager = chkFitoutManager.Checked == true ? "1" : "0";
                data.FitoutParking = chkFitoutParking.Checked == true ? "1" : "0";
                data.FitoutService = chkFitoutService.Checked == true ? "1" : "0";
                data.FitoutWater = chkFitoutWater.Checked == true ? "1" : "0";
                data.FitoutElec = chkFitoutElec.Checked == true ? "1" : "0";
                data.FitoutExtraTime = chkFitoutExtraTime.Checked == true ? "1" : "0";

                //if (rdoExtraTimeM.Checked == true)
                //{
                //    data.ExtratimeType = "0";
                //    data.HourExtraTimePriceUsd = txtHourExtraTimePriceUsd.Text.Replace(",", ".");
                //    data.HourExtraTimePriceVND = txtHourExtraTimePriceVND.Text.Replace(",", ".");

                //    data.MonthExtraTimePriceUsd = "0";
                //    data.MonthExtraTimePriceVND = "0";

                //}
                //else
                //{
                //    data.ExtratimeType = "1";

                //    data.HourExtraTimePriceUsd = "0";
                //    data.HourExtraTimePriceVND = "0";

                //    data.MonthExtraTimePriceUsd = txtMonthExtraTimePriceUSD.Text.Replace(",", ".");
                //    data.MonthExtraTimePriceVND = txtMonthExtraTimePriceVND.Text.Replace(",", ".");

                //}

                tran = factory.GetUpdateObject(data);
                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(addSuccess);
                    ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);

                    btnRegister.CommandName = "Register";
                    hidAction.Value = "Edit";
                    lblId.Enabled = false;
                    hidId.Value = data.id;
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
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
            action = Request["Action"];
            id = Request["id"];
            hidId.Value = id;
            hidAction.Value = action;
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
            //mvMessage.CheckRequired(lblName, "* là Danh mục bắt bắt buộc nhập");
            UpdateData();
        }
        protected void chkRentTypeChange(object sender, EventArgs e)
        {
            //mvMessage.CheckRequired(lblName, "* là Danh mục bắt bắt buộc nhập");
            lblRentPrice.Text = "Phí Thuê (/m2)";
            lblManagerPrice.Text = "Phí Quản lý (/m2)";
            if (chkRentType.Checked == true)
            {
                lblRentPrice.Text = "Phí Thuê";
                lblManagerPrice.Text = "Phí Quản lý";
            }
        }

        protected void drpRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            BD_RoomData data = new BD_RoomData();
            ITransaction tran = factory.GetLoadObject(data, drpRoom.SelectedValue);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_RoomData)tran.Result;

                txtRentPriceVND.Text = data.MonthRentPriceVND;
                txtRentPriceUSD.Text = data.MonthRentPriceUSD;
                txtManagerPriceVND.Text = data.MonthManagerPriceVND;
                txtManagerPriceUSD.Text = data.MonthManagerPriceUSD;

                txtHourExtraTimePriceUsd.Text = data.HourExtraTimePriceUsd;
                txtHourExtraTimePriceVND.Text = data.HourExtraTimePriceVND;

                txtMonthExtraTimePriceUSD.Text = data.MonthExtraTimePriceUsd;
                txtMonthExtraTimePriceVND.Text = data.MonthExtraTimePriceVND;

                txtVAT.Text = data.Vat;
                txtRentArea.Text = data.Area;
            }
        }
        protected void rdoCheckedChanged(object sender, System.EventArgs e)
        {
            //if (rdoExtraTimeA.Checked == true)
            //{
            //    txtMonthExtraTimePriceUSD.Enabled = true;
            //    txtMonthExtraTimePriceVND.Enabled = true;

            //    txtHourExtraTimePriceUsd.Enabled = false;
            //    txtHourExtraTimePriceVND.Enabled = false;
            //}
            //else
            //{
            //    txtMonthExtraTimePriceUSD.Enabled = false;
            //    txtMonthExtraTimePriceVND.Enabled = false;

            //    txtHourExtraTimePriceUsd.Enabled = true;
            //    txtHourExtraTimePriceVND.Enabled = true;
            //}
        }
    }
}
