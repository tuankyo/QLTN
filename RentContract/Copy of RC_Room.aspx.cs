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
    public partial class RC_Room : Man.PageBase
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
            RentContractData data = new RentContractData();
            ITransaction tran = factory.GetLoadObject(data, id);
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
                //chkDelFlag.Checked = "1".Equals(data.DelFlag) ? false : true;
                //lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                //lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";

                txtContractDate.Text = Func.Formatdmyhms(data.ContractDate);
                txtContractEndDate.Text = Func.Formatdmyhms(data.ContractEndDate);
                ShowData();

                string sqlElec = " SELECT distinct ID, Name";
                sqlElec += " FROM BD_FeeGroup B ";
                sqlElec += " WHERE B.DelFlag = '0' and FeeGroup = 1 and B.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";

                string sqlWater = " SELECT distinct ID, Name";
                sqlWater += " FROM BD_FeeGroup B ";
                sqlWater += " WHERE B.DelFlag = '0' and FeeGroup = 2 and B.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";

                DbHelper.FillList(drpTariffsOfElec, sqlElec, "Name", "ID");
                DbHelper.FillList(drpTariffsOfWater, sqlWater, "Name", "ID");
                DbHelper.FillList(drpRoom, "Select ID, Name + '(' + Regional + '-' + [FLOOR] + '-' + convert(nvarchar(10),Area) + 'm2)' as RoomName from BD_Room Where DelFlag <> '1' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "RoomName", "ID");

            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void UpdateData()
        {
            RC_RoomData data = new RC_RoomData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (RC_RoomData)tran.Result;
                data.ContractId = lblId.Text.Trim();
                //data.CustomerId = lblCustomerId.Text.Trim();
                //data.ContractDate = Func.FormatYYYYmmdd(lblContractDate.Text.Trim());
                //data.ContractEndDate = Func.FormatYYYYmmdd(lblContractEndDate.Text.Trim());
                //data.ReceiveDate = Func.FormatYYYYmmdd(lblReceiveDate.Text.Trim());
                data.Comment = lblComment.Text.Trim();
                //data.StaffMount = lblStaffMount.Text.Trim();
                data.ModifiedBy = Page.User.Identity.Name;
                data.CreatedBy = Page.User.Identity.Name;
                data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag = "1";

                tran = factory.GetUpdateObject(data);

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(updateSuccess);
                    ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);

                    //lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                    //lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";

                    ShowData();
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
            mvMessage.CheckRequired(txtContractDate, "Từ ngày: là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtContractEndDate, "Đến ngày: là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtRentArea, "Diện tích thuê: là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtRentPriceUSD, "Phí thuê/m2 USD: là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtRentPriceVND, "Phí thuê/m2 VND: là Danh mục bắt bắt buộc nhập");

            mvMessage.CheckRequired(txtVAT, "VAT: là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtManagerPriceUSD, "Phí quản lý/m2 USD: là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtManagerPriceVND, "Phí quản lý/m2 VND: là Danh mục bắt bắt buộc nhập");

            mvMessage.CheckRequired(txtHourExtraTimePriceUsd, "Phí ngoài giờ/h (USD): là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtHourExtraTimePriceVND, "Phí ngoài giờ/h (VND): là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtMonthExtraTimePriceVND, "Phí ngoài giờ/diện tích (VND): là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtMonthExtraTimePriceUSD, "Phí ngoài giờ/diện tích (USD): là Danh mục bắt bắt buộc nhập");

            mvMessage.CheckRequired(txtElecPricePercent, "Tỉ lệ sử dụng điện : là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtWaterPricePercent, "Tỉ lệ sử dụng nước : là Danh mục bắt bắt buộc nhập");

            if (!mvMessage.IsValid) return false;
            return true;
        }
        /// <summary>
        /// Insert data
        /// </summary>
        private void InsertData()
        {
            double BeginContract = Func.ParseDouble(Func.FormatYYYYmmdd(txtContractDate.Text.Substring(0, 10)));
            double EndContract = Func.ParseDouble(Func.FormatYYYYmmdd(txtContractEndDate.Text.Substring(0, 10)));

            string exit = DbHelper.GetScalar("Select Count(*) from RC_Room Where delflag = 0 and RoomId = '"+ drpRoom.SelectedValue +"' and ((BeginContract <= '" + BeginContract + "' and '" + BeginContract + "' <= EndContract) or (BeginContract <= '" + EndContract + "' and '" + EndContract + "' <= EndContract) or ('" + EndContract + "' <= BeginContract and '" + EndContract + "' >= EndContract))");
            if (!exit.Equals("0"))
            {
                mvMessage.AddError("Phòng này đang được cho thuê");
                return;
            }

            if (!checkData()) { return; }

            double managerVND = Func.ParseDouble(txtManagerPriceVND.Text.Trim());
            float managerUSD = Func.ParseFloat(txtManagerPriceUSD.Text.Trim().Replace(",", "."));

            if (managerVND != 0 && managerUSD != 0)
            {
                mvMessage.AddError("Phí quản lý không được phép nhập cả 2 USD và VND lớn hơn 0. \n Một trong 2 loại phải = 0");
                return;
            }

            double MonthRentPriceVND = Func.ParseDouble(txtRentPriceVND.Text.Trim());
            float MonthRentPriceUSD = Func.ParseFloat(txtRentPriceUSD.Text.Trim().Replace(",", "."));

            if (MonthRentPriceVND != 0 && MonthRentPriceUSD != 0)
            {
                mvMessage.AddError("Phí Thuê không được phép nhập cả 2 USD và VND lớn hơn 0. \n Một trong 2 loại phải = 0");
                return;
            }

            if (EndContract < BeginContract)
            {
                mvMessage.AddError("Ngày kết thúc hợp đồng phải lớn hơn ngày bắt đầu Hợp đồng");
                return;
            }

            double HourExtraTimePriceVND = Func.ParseDouble(txtHourExtraTimePriceVND.Text);
            float HourExtraTimePriceUsd = Func.ParseFloat(txtHourExtraTimePriceUsd.Text.Replace(",", "."));
            if (HourExtraTimePriceVND != 0 && HourExtraTimePriceUsd != 0)
            {
                mvMessage.AddError("Phí Ngoài Giờ không được phép nhập cả 2 USD và VND lớn hơn 0. \n Một trong 2 loại phải = 0");
                return;
            }

            double MonthExtraTimePriceVND = Func.ParseDouble(txtMonthExtraTimePriceVND.Text);
            float MonthExtraTimePriceUsd = Func.ParseFloat(txtMonthExtraTimePriceUSD.Text.Replace(",", "."));
            if (MonthExtraTimePriceVND != 0 && MonthExtraTimePriceUsd != 0)
            {
                mvMessage.AddError("Phí Ngoài giờ không được phép nhập cả 2 USD và VND lớn hơn 0. \n Một trong 2 loại phải = 0");
                return;
            }

            //Get and Insert Data
            RC_RoomData data = new RC_RoomData();
            ITransaction tran = factory.GetInsertObject(data);
            data.ContractId = lblId.Text.Trim();
            data.RoomId = drpRoom.SelectedValue;

            data.VAT = txtVAT.Text.Replace(",", ".");
            data.MonthManagerPriceVND = txtManagerPriceVND.Text.Trim().Replace(",", ".");
            data.MonthManagerPriceUSD = txtManagerPriceUSD.Text.Trim().Replace(",", ".");

            data.MonthRentPriceVND = txtRentPriceVND.Text.Trim().Replace(",", ".");
            data.MonthRentPriceUSD = txtRentPriceUSD.Text.Trim().Replace(",", ".");

            data.Comment = lblComment.Text.Trim();
            data.ModifiedBy = Page.User.Identity.Name;
            data.CreatedBy = Page.User.Identity.Name;
            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.DelFlag = "0";

            data.TariffsOfElecId = drpTariffsOfElec.SelectedValue;
            data.TariffsOfWaterId = drpTariffsOfWater.SelectedValue;

            data.BeginContract = Func.FormatYYYYmmdd(txtContractDate.Text.Substring(0, 10));
            data.EndContract = Func.FormatYYYYmmdd(txtContractEndDate.Text.Substring(0, 10));

            data.RentType = chkRentType.Checked == true ? "1" : "0";
            data.ElecPricePercent = txtElecPricePercent.Text.Replace(",", ".");
            data.WaterPricePercent = txtWaterPricePercent.Text.Replace(",", ".");
            data.RentArea = txtRentArea.Text.Replace(",", ".");

            if (rdoExtraTimeM.Checked == true)
            {
                data.ExtratimeType = "0";
                data.HourExtraTimePriceUsd = txtHourExtraTimePriceUsd.Text.Replace(",", ".");
                data.HourExtraTimePriceVND = txtHourExtraTimePriceVND.Text.Replace(",", ".");

                data.MonthExtraTimePriceUsd = "0";
                data.MonthExtraTimePriceVND = "0";

            }
            else
            {
                data.ExtratimeType = "1";

                data.HourExtraTimePriceUsd = "0";
                data.HourExtraTimePriceVND = "0";

                data.MonthExtraTimePriceUsd = txtMonthExtraTimePriceUSD.Text.Replace(",", ".");
                data.MonthExtraTimePriceVND = txtMonthExtraTimePriceVND.Text.Replace(",", ".");

            }

            data.ExtraTimeMinPriceUSD = txtMinPriceUSD.Text.Replace(",", ".");
            data.ExtraTimeMinPriceVND = txtMinPriceVND.Text.Replace(",", ".");

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
                //lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                //lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";

                ShowData();
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
            InsertData();
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
        /// <summary>
        /// List data
        /// </summary>
        private void ShowData()
        {
            SqlDatabase db = new SqlDatabase();
            string sql = string.Empty;
            if (!Func.IsValid(ListSortExpression))
            {
                ListSortExpression = "A.Modified";
                ListSortDirection = SortDirection.Ascending;
            }
            try
            {
                //Đếm số lượng record
                sql += " SELECT COUNT(ID) ";
                sql += " FROM [RC_Room]";
                sql += " WHERE (ID IS NOT NULL) and DelFlag <> 1 and ContractId = '" + lblId.Text + "'";


                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " SELECT A.*, B.Name as RoomName , B.Regional as RegionalRoom, B.Floor as FloorRoom,B.Area as AreaRoom, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM [RC_Room] A, BD_Room B ";
                sql += " WHERE A.ContractID IS NOT NULL and A.DelFlag <> 1 and A.RoomId = B.id and A.ContractId = '" + lblId.Text + "'";

                //Phân trang
                sql = " SELECT * FROM (" + sql + ") AS TMP ";
                sql += " WHERE RowNum BETWEEN @PageIndex*@PageSize + 1  AND (@PageIndex+1)*@PageSize ORDER BY RowNum ";

                //Thực hiện câu SQL

                SqlCommand cm = db.CreateCommand(sql);
                cm.Parameters.AddWithValue("@PageIndex", pager.CurrentPageIndex);
                cm.Parameters.AddWithValue("@PageSize", pager.PageSize);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataSet ds = new DataSet();
                da.Fill(ds);
                db.Close();
                rptList.DataSource = ds.Tables[0].DefaultView;
                rptList.DataBind();
                pager.Count = count;
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }

        protected void pager_PageIndexChanged(object source, PagerPageChangedEventArgs args)
        {
            ShowData();
        }

        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string command = e.CommandName;
            string colName = string.Empty;
            if (command.StartsWith("Sort"))
            {
                if (string.Compare(command, "SortID") == 0)
                {
                    colName = "ID";
                }
                else if (string.Compare(command, "SortName") == 0)
                {
                    colName = "Name";
                }
                else if (string.Compare(command, "SortModifiedBy") == 0)
                {
                    colName = "ModifiedBy";
                }
                else if (string.Compare(command, "SortModified") == 0)
                {
                    colName = "Modified";
                }


                if (colName == ListSortExpression)
                {
                    ListSortDirection = (ListSortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending);
                }
                else
                {
                    ListSortDirection = SortDirection.Descending;
                }
                ListSortExpression = colName;
                pager.CurrentPageIndex = 0;
                ShowData();
            }
            else if (command.Equals("Update"))
            {
                //TextBox txtManagerPriceUSD = (TextBox)e.Item.FindControl("txtManagerPriceUSD");
                //TextBox txtManagerPriceVND = (TextBox)e.Item.FindControl("txtManagerPriceVND");
                //TextBox txtRentPriceUSD = (TextBox)e.Item.FindControl("txtRentPriceUSD");
                //TextBox txtRentPriceVND = (TextBox)e.Item.FindControl("txtRentPriceVND");
                //TextBox txtVAT = (TextBox)e.Item.FindControl("txtVAT");
                //TextBox txtBeginContract = (TextBox)e.Item.FindControl("txtBeginContractDate");
                //TextBox txtEndContract = (TextBox)e.Item.FindControl("txtEndContractDate");

                //TextBox txtComment = (TextBox)e.Item.FindControl("txtComment");
                //DropDownList drpElec = (DropDownList)e.Item.FindControl("drpElec");
                //DropDownList drpWater = (DropDownList)e.Item.FindControl("drpWater");

                //string sqlNew = " Update RC_Room " +
                //                " Set " +
                //                "       MonthManagerPriceUSD=@ManagerPriceUSD" +
                //                "       ,MonthManagerPriceVND=@ManagerPriceVND" +
                //                "       ,MonthRentPriceUSD=@RentPriceUSD" +
                //                "       ,MonthRentPriceVND=@RentPriceVND" +
                //                "       ,BeginContract=@BeginContract" +
                //                "       ,EndContract=@EndContract" +
                //                "       ,VAT=@VAT" +

                //                "       ,TariffsOfElecId=@TariffsOfElecId" +
                //                "       ,TariffsOfWaterId=@TariffsOfWaterId" +
                //                "       ,Comment=@Comment" +
                //                "       ,Modified=@Modified" +
                //                "       ,ModifiedBy=@ModifiedBy" +
                //                " Where id=@id";

                //using (SqlConnection rConn = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                //{
                //    rConn.Open();
                //    using (SqlCommand cmd = new SqlCommand(sqlNew, rConn))
                //    {
                //        cmd.Parameters.Add(new SqlParameter("@id", Func.ParseString(e.CommandArgument)));

                //        cmd.Parameters.Add(new SqlParameter("@ManagerPriceUSD", txtManagerPriceUSD.Text.Trim().Replace(",", ".")));
                //        cmd.Parameters.Add(new SqlParameter("@ManagerPriceVND", txtManagerPriceVND.Text.Trim().Replace(",", ".")));
                //        cmd.Parameters.Add(new SqlParameter("@RentPriceUSD", txtRentPriceUSD.Text.Trim().Replace(",", ".")));
                //        cmd.Parameters.Add(new SqlParameter("@RentPriceVND", txtRentPriceVND.Text.Trim().Replace(",", ".")));
                //        cmd.Parameters.Add(new SqlParameter("@VAT", txtVAT.Text.Trim().Replace(",", ".")));
                //        cmd.Parameters.Add(new SqlParameter("@BeginContract", Func.FormatYYYYmmdd(txtBeginContract.Text.Trim().Substring(0, 10))));
                //        cmd.Parameters.Add(new SqlParameter("@EndContract", Func.FormatYYYYmmdd(txtEndContract.Text.Trim().Substring(0, 10))));

                //        cmd.Parameters.Add(new SqlParameter("@Comment", txtComment.Text.Trim()));
                //        cmd.Parameters.Add(new SqlParameter("@TariffsOfElecId", drpElec.SelectedValue));
                //        cmd.Parameters.Add(new SqlParameter("@TariffsOfWaterId", drpWater.SelectedValue));
                //        cmd.Parameters.Add(new SqlParameter("@Modified", DateTime.Now.ToString("yyyyMMddHHmmss")));
                //        cmd.Parameters.Add(new SqlParameter("@ModifiedBy", Page.User.Identity.Name));

                //        cmd.ExecuteNonQuery();
                //    }
                //    rConn.Close();
                //    mvMessage.SetCompleteMessage("Đã cập nhật thành công");
                //    ShowData();
                //}
                Response.Redirect("RC_RoomEdit.aspx?id=" + Func.ParseString(e.CommandArgument));
            }
            else if (command.Equals("Delete"))
            {
                DbHelper.ExecuteDB("Update RC_Room Set DelFlag = 1 Where ID = '" + Func.ParseString(e.CommandArgument) + "'");
                ShowData();
            }
        }

        /// </summary>Hiển thị nội dung trên datagrid
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            try
            {
                if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
                {
                    DataRowView row = (DataRowView)item.DataItem;

                    string RoomId = Func.ParseString(row["RoomId"]);
                    string RoomName = Func.ParseString(row["RoomName"]);

                    string BeginContractDate = Func.ParseString(row["BeginContract"]);
                    string EndContractDate = Func.ParseString(row["EndContract"]);


                    //string ManagerPriceRoomVND = Func.ParseString(row["MonthManagerPriceVND"]);
                    //string ManagerPriceRoomUSD = Func.ParseString(row["MonthManagerPriceUSD"]);
                    //string MonthRentPriceVND = Func.ParseString(row["MonthRentPriceVND"]);
                    //string MonthRentPriceUSD = Func.ParseString(row["MonthRentPriceUSD"]);
                    //string VAT = Func.ParseString(row["VAT"]);

                    string Comment = Func.ParseString(row["Comment"]);
                    //string ElecId = Func.ParseString(row["TariffsOfElecId"]);
                    //string WaterId = Func.ParseString(row["TariffsOfWaterId"]);

                    Func.SetGridTextValue(item, "ltrRoomName", RoomName);
                    //Func.SetGridTextboxValue(item, "txtVAT", VAT);

                    Func.SetGridTextValue(item, "ltrBeginContractDate", Func.Formatdmyhms(BeginContractDate).Substring(0, 10));
                    Func.SetGridTextValue(item, "ltrEndContractDate", Func.Formatdmyhms(EndContractDate).Substring(0, 10));
                    Func.SetGridTextValue(item, "ltrComment", Comment);
                    //Func.SetGridTextboxValue(item, "txtManagerPriceVND", ManagerPriceRoomVND);
                    //Func.SetGridTextboxValue(item, "txtManagerPriceUSD", ManagerPriceRoomUSD);
                    //Func.SetGridTextboxValue(item, "txtRentPriceVND", MonthRentPriceVND);
                    //Func.SetGridTextboxValue(item, "txtRentPriceUSD", MonthRentPriceUSD);

                    string ModifiedBy = Func.ParseString(row["ModifiedBy"].ToString().Trim());
                    string Modified = Func.ParseString(row["Modified"].ToString().Trim());
                    Func.SetGridTextValue(item, "ltrModifiedBy", ModifiedBy);
                    Func.SetGridTextValue(item, "ltrModified", Func.Formatdmyhms(Modified));

                    Button btnUpdate = (Button)item.FindControl("btnUpdate");
                    btnUpdate.CommandArgument = Func.ParseString(row["id"]);

                    Button btnDelete = (Button)item.FindControl("btnDelete");
                    btnDelete.CommandArgument = Func.ParseString(row["id"]);

                    //string sqlElec = " SELECT distinct ID, Name";
                    //sqlElec += " FROM BD_FeeGroup B ";
                    //sqlElec += " WHERE B.DelFlag <> '1' and FeeGroup = 1 and B.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";

                    //string sqlWater = " SELECT distinct ID, Name";
                    //sqlWater += " FROM BD_FeeGroup B ";
                    //sqlWater += " WHERE B.DelFlag <> '1' and FeeGroup = 2 and B.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";

                    //DropDownList drpElec = (DropDownList)item.FindControl("drpElec");
                    //DropDownList drpWater = (DropDownList)item.FindControl("drpWater");

                    //DbHelper.FillList(drpElec, sqlElec, "Name", "ID");
                    //DbHelper.FillList(drpWater, sqlWater, "Name", "ID");

                    //drpElec.SelectedValue = ElecId;
                    //drpWater.SelectedValue = WaterId;
                }
                else if (item.ItemType == ListItemType.Header)
                {
                    string colName = ListSortExpression;
                    if (Func.IsValid(colName))
                    {
                        string img = string.Empty;
                        if (ListSortDirection == SortDirection.Ascending)
                        {
                            img = "<img src=\"../App_Themes/Default/Images/ASCSymbol.gif\" border=\"0\">";
                        }
                        else
                        {
                            img = "<img src=\"../App_Themes/Default/Images/DSCSymbol.gif\" border=\"0\">";
                        }

                        if (colName.EndsWith("Id"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkTypeId");
                            link.Text = "ID" + img;
                        }
                        else if (colName.EndsWith("Address"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkName");
                            link.Text = "Địa Chỉ" + img;
                        }
                        else if (colName.EndsWith("Name"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkName");
                            link.Text = "Loại Phí" + img;
                        }
                        else if (colName.EndsWith("ModifiedBy"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkModifiedBy");
                            link.Text = "Cập Nhật" + img;
                        }
                        else if (colName.EndsWith("Modified"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkModified");
                            link.Text = "Ngày Cập Nhật" + img;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
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
            if (rdoExtraTimeA.Checked == true)
            {
                txtMonthExtraTimePriceUSD.Enabled = true;
                txtMonthExtraTimePriceVND.Enabled = true;

                txtHourExtraTimePriceUsd.Enabled = false;
                txtHourExtraTimePriceVND.Enabled = false;
            }
            else
            {
                txtMonthExtraTimePriceUSD.Enabled = false;
                txtMonthExtraTimePriceVND.Enabled = false;

                txtHourExtraTimePriceUsd.Enabled = true;
                txtHourExtraTimePriceVND.Enabled = true;
            }
        } 
    }
}
