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

namespace Man.Building.Room
{
    public partial class BD_RoomEdit : Man.PageBase
    {
        private string action = String.Empty;
        private string id = String.Empty;

        private string updateSuccess = "Cập Nhật Thông Tin Đã Thành Công";
        private string updateUnSuccess = "Cập Nhật Thông Tin Không Thành Công";
        private string addSuccess = "Thêm Mới Thành Công";
        private string addUnSuccess = "Thêm Mới Không Thành Công";
        private string title = "Phòng Cho Thuê";
        private string postback = "window.opener.__doPostBack('PopupBD_RoomEdit','');";
        private string key = "openBD_RoomEdit";

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
            BD_RoomData data = new BD_RoomData();
            ITransaction tran = factory.GetLoadObject(data, id);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_RoomData)tran.Result;
                txtId.Text = data.id;
                txtName.Text = data.Name;
                txtComment.Text = data.Comment;

                chkMeetinRoom.Checked = (data.IsMeetingRoom == "1" ? true : false);
                txtRegional.Text = data.Regional;
                txtFloor.Text = data.Floor;
                txtArea.Text = data.Area;

                txtHourRentPriceVND.Text = data.HourRentPriceVND;
                txtHourRentPriceUSD.Text = data.HourRentPriceUSD;
                txtMonthRentPriceVND.Text = data.MonthRentPriceVND;
                txtMonthRentPriceUSD.Text = data.MonthRentPriceUSD;
                txtMonthManagerPriceVND.Text = data.MonthManagerPriceVND;
                txtMonthManagerPriceUSD.Text = data.MonthManagerPriceUSD;

                txtHourExtraTimePriceVND.Text = data.HourExtraTimePriceVND;
                txtHourExtraTimePriceUSD.Text = data.HourExtraTimePriceUsd;

                txtMonthExtraTimePriceVND.Text = data.MonthExtraTimePriceVND;
                txtMonthExtraTimePriceUSD.Text = data.MonthExtraTimePriceUsd;

                txtVat.Text = data.Vat;
                chkDelFlag.Checked = "1".Equals(data.DelFlag) ? false : true;

                lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";
                txtDescription.Text = data.Description;

                hidId.Value = id;
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void UpdateData()
        {
            if (!checkData()) return;

            BD_RoomData data = new BD_RoomData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_RoomData)tran.Result;
                data.Name = txtName.Text.Trim();
                data.Comment = txtComment.Text.Trim();

                data.ModifiedBy = Page.User.Identity.Name;
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag = true.Equals(chkDelFlag.Checked) ? "0" : "1";

                data.IsMeetingRoom = (chkMeetinRoom.Checked == true ? "1" : "0");
                data.Regional = txtRegional.Text;
                data.Floor = txtFloor.Text;
                data.Description = txtDescription.Text;

                data.Area = txtArea.Text.Replace(',', '.');

                data.HourRentPriceVND = txtHourRentPriceVND.Text.Trim().Replace(',', '.');
                data.HourRentPriceUSD = txtHourRentPriceUSD.Text.Trim().Replace(',', '.');

                data.HourManagerPriceVND = "0";
                data.HourManagerPriceUSD = "0";

                data.HourExtraTimePriceVND = txtHourExtraTimePriceVND.Text.Trim().Replace(',', '.');
                data.HourExtraTimePriceUsd = txtHourExtraTimePriceUSD.Text.Trim().Replace(',', '.');

                data.MonthRentPriceVND = txtMonthRentPriceVND.Text.Trim().Replace(',', '.');
                data.MonthRentPriceUSD = txtMonthRentPriceUSD.Text.Trim().Replace(',', '.');
                data.MonthManagerPriceVND = txtMonthManagerPriceVND.Text.Trim().Replace(',', '.');
                data.MonthManagerPriceUSD = txtMonthManagerPriceUSD.Text.Trim().Replace(',', '.');
                data.MonthExtraTimePriceVND = txtMonthExtraTimePriceVND.Text.Trim().Replace(',', '.');
                data.MonthExtraTimePriceUsd = txtMonthExtraTimePriceUSD.Text.Trim().Replace(',', '.');

                data.Vat = txtVat.Text.Trim().Replace(',', '.');
                data.OtherFee01 = "0";
                data.OtherFee02 = "0";

                data.ExtraTimeMinPriceVND = txtMonthExtraTimePriceVND.Text.Trim().Replace(',', '.');
                data.ExtraTimeMinPriceUSD = txtMonthExtraTimePriceUSD.Text.Trim().Replace(',', '.');

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
            mvMessage.CheckRequired(txtId, "Mã: là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtName, "Phòng: là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtRegional, "Khu vực: là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtFloor, "Lầu: là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtArea, "Diện tích: là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtVat, "VAT: là Danh mục bắt bắt buộc nhập");

            mvMessage.CheckRequired(txtHourRentPriceVND, "Phí thuê (giờ) VND: là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtHourRentPriceUSD, "Phí thuê (giờ) USD: là Danh mục bắt bắt buộc nhập");

            mvMessage.CheckRequired(txtMonthRentPriceVND, "Phí thuê (VND): là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtMonthRentPriceUSD, "Phí thuê (USD): là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtMonthManagerPriceVND, "Phí quản lý (VND): là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtMonthManagerPriceUSD, "Phí quản lý (USD): là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtMonthExtraTimePriceVND, "Sử dụng ngoài giờ theo diện tích (VND): là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtMonthExtraTimePriceUSD, "Sử dụng ngoài giờ theo diện tích (USD): là Danh mục bắt bắt buộc nhập");

            mvMessage.CheckRequired(txtHourExtraTimePriceVND, "Sử dụng ngoài giờ theo thời gian (VND) : là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtHourExtraTimePriceUSD, "Sử dụng ngoài giờ theo thời gian (USD) : là Danh mục bắt bắt buộc nhập");

            if (!mvMessage.IsValid) return false;
            return true;
        }
        /// <summary>
        /// Insert data
        /// </summary>
        private void InsertData()
        {
            if (!checkData()) return;

            //Get and Insert Data
            BD_RoomData data = new BD_RoomData();
            ITransaction tran = factory.GetInsertObject(data);
            data.id = txtId.Text.Trim();
            data.Name = txtName.Text.Trim();
            data.Comment = txtComment.Text.Trim();
            data.ModifiedBy = Page.User.Identity.Name;
            data.CreatedBy = Page.User.Identity.Name;
            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.DelFlag = true.Equals(chkDelFlag.Checked) ? "0" : "1";

            data.IsMeetingRoom = (chkMeetinRoom.Checked == true ? "1" : "0");

            data.Regional = txtRegional.Text;
            data.Floor = txtFloor.Text;
            data.Area = txtArea.Text.Replace(',', '.');

            data.HourRentPriceVND = txtHourRentPriceVND.Text.Trim().Replace(',', '.');
            data.HourRentPriceUSD = txtHourRentPriceUSD.Text.Trim().Replace(',', '.');
            
            data.HourManagerPriceVND = "0";
            data.HourManagerPriceUSD = "0";

            data.HourExtraTimePriceVND = txtHourExtraTimePriceVND.Text.Trim().Replace(',', '.');
            data.HourExtraTimePriceUsd = txtHourExtraTimePriceUSD.Text.Trim().Replace(',', '.');

            data.MonthRentPriceVND = txtMonthRentPriceVND.Text.Trim().Replace(',', '.');
            data.MonthRentPriceUSD = txtMonthRentPriceUSD.Text.Trim().Replace(',', '.');
            data.MonthManagerPriceVND = txtMonthManagerPriceVND.Text.Trim().Replace(',', '.');
            data.MonthManagerPriceUSD = txtMonthManagerPriceUSD.Text.Trim().Replace(',', '.');
            data.MonthExtraTimePriceVND = txtMonthExtraTimePriceVND.Text.Trim().Replace(',', '.');
            data.MonthExtraTimePriceUsd = txtMonthExtraTimePriceUSD.Text.Trim().Replace(',', '.');

            data.Vat = txtVat.Text.Trim().Replace(',', '.');
            data.OtherFee01 = "0";
            data.OtherFee02 = "0";

            data.ExtraTimeMinPriceVND = txtMonthExtraTimePriceVND.Text.Trim().Replace(',', '.');
            data.ExtraTimeMinPriceUSD = txtMonthExtraTimePriceUSD.Text.Trim().Replace(',', '.');

            data.Description = txtDescription.Text;

            data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);

            Execute(tran);

            if (!HasError)
            {
                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                mvMessage.SetCompleteMessage(addSuccess);
                ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);


                btnRegister.CommandName = "Register";
                hidId.Value = data.id;
                txtId.Text = data.id;
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
            chkDelFlag.Enabled = DbHelper.isAdmin(Page.User.Identity.Name);

            action = Request["Action"];
            id = Request["id"];

            hidId.Value = id;
            hidAction.Value = action;

            SqlDatabase db = new SqlDatabase();
            if (action == "Edit")
            {
                lblHeader.Text = "Thông Tin Chi Tiết " + title;
                btnRegister.Text = "Cập Nhật";
                btnCancel.Text = "Đóng";
                btnRegister.CommandName = "Edit";
                if (!IsPostBack)
                {
                    LoadData();
                }
            }
            else // Add new case
            {
                txtId.Text = id;
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
            mvMessage.CheckRequired(txtName, "Phòng: Danh mục phải nhập");
            mvMessage.CheckRequired(txtRegional, "Khu vực: Danh mục phải nhập");
            mvMessage.CheckRequired(txtFloor, "Lầu: Danh mục phải nhập");
            mvMessage.CheckRequired(txtArea, "Diện tích: Danh mục phải nhập");

            mvMessage.CheckRequired(txtMonthRentPriceVND, "Phí thuê giờ(VND): Danh mục phải nhập");
            mvMessage.CheckRequired(txtMonthRentPriceUSD, "Phí thuê giờ(USD): Danh mục phải nhập");

            mvMessage.CheckRequired(txtMonthManagerPriceVND, "Phí quản lý giờ(VND): Danh mục phải nhập");
            mvMessage.CheckRequired(txtMonthManagerPriceUSD, "Phí quản lý giờ(USD): Danh mục phải nhập");

            mvMessage.CheckRequired(txtMonthExtraTimePriceVND, "Phí sử dụng ngoài giờ(VND): Danh mục phải nhập");
            mvMessage.CheckRequired(txtMonthExtraTimePriceUSD, "Phí sử dụng ngoài giờ(USD): Danh mục phải nhập");

            mvMessage.CheckRequired(txtHourRentPriceVND, "Phí thuê tháng(VND): Danh mục phải nhập");
            mvMessage.CheckRequired(txtHourRentPriceUSD, "Phí thuê tháng (USD): Danh mục phải nhập");

            //mvMessage.CheckRequired(txtHourManagerPriceVND, "Phí Quản lý tháng (VND):Danh mục phải nhập");
            //mvMessage.CheckRequired(txtHourManagerPriceUSD, "Phí Quản lý tháng (USD):Danh mục phải nhập");

            //mvMessage.CheckRequired(txtHourExtraTimePriceVND, "Phí cộng thêm giờ (tháng)(VND): Danh mục phải nhập");
            //mvMessage.CheckRequired(txtHourExtraTimePriceUSD, "Phí cộng thêm giờ (tháng)(USD): Danh mục phải nhập");


            if (!mvMessage.IsValid) return;

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
