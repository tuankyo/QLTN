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

namespace Man.Customer
{
    public partial class CustomerParking : Man.PageBase
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
        private string postback = "window.opener.__doPostBack('PopupCustomerParking','');";
        private string key = "openCustomerParking";

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
            //RentContractData data = new RentContractData();
            //ITransaction tran = factory.GetLoadObject(data, id);
            //Execute(tran);
            //if (!HasError)
            //{
            //    //Get Data
            //    data = (RentContractData)tran.Result;
            //    lblMotorParkingMount.Text = data.MotorParkingMount;
            //    lblCarParkingMount.Text = data.CarParkingMount;
            //}
            DataTable dt = DbHelper.GetDataTable("SELECT      SUM(CarParkingMount) AS CarParkingMount, SUM(MotorParkingMount) AS MotorParkingMount, SUM(BycParkingMount) AS BycParkingMount"
                            + " FROM    RentContract"
                            + " WHERE   ((ContractDate <= CONVERT(varchar(10), GETDATE(), 112)) AND (ContractEndDate >= CONVERT(varchar(10), GETDATE(), 112)) OR"
                            + "         (ContractDate > CONVERT(varchar(10), GETDATE(), 112)) AND (ContractDate <= CONVERT(varchar(10), DATEADD(s, - 1, DATEADD(mm, DATEDIFF(m, 0, GETDATE()) + 2, 0)), 112)))"
                            + "         And CustomerId = '" + hidId.Value + "' and DelFlag = '0' GROUP BY CustomerId");
            foreach (DataRow rowType in dt.Rows)
            {
                lblCarParkingMount.Text = rowType[0].ToString();
                lblMotorParkingMount.Text = rowType[1].ToString();
                lblBycParkingMount.Text = rowType[2].ToString();
            }
            ShowData();

            DbHelper.FillListSearch(drpVehicleType, "Select Name + '('+ CONVERT(nvarchar,PriceVND) +')' as PriceName, id from BD_TariffsPacking Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "PriceName", "id");
        }

        /// <summary>
        /// Update
        /// </summary>
        private void UpdateData()
        {
            CustomerParkingData data = new CustomerParkingData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (CustomerParkingData)tran.Result;
                data.CustomerId = hidId.Value;
                data.TariffsParkingId = drpVehicleType.SelectedValue;
                data.VehicleName = txtVehicleName.Text.Trim();
                data.VehicleCode = txtVehicleCode.Text.Trim();
                data.Comment = txtComment.Text.Trim();
                data.OwnerName = txtOwnerName.Text.Trim();
                data.OwnerPhone = txtOwnerPhone.Text.Trim();
                data.ParkingBegin = Func.FormatYYYYmmdd(txtParkingBegin.Text.Trim().Substring(0, 10));
                data.ParkingEnd = Func.FormatYYYYmmdd(txtParkingEnd.Text.Trim().Substring(0, 10));

                data.ModifiedBy = Page.User.Identity.Name;
                data.CreatedBy = Page.User.Identity.Name;
                data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag = "0";

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

        /// <summary>
        /// Insert data
        /// </summary>
        private void InsertData()
        {
            //Get and Insert Data
            CustomerParkingData data = new CustomerParkingData();
            ITransaction tran = factory.GetInsertObject(data);
            data.CustomerId = hidId.Value;
            data.TariffsParkingId = drpVehicleType.SelectedValue;
            data.VehicleName = txtVehicleName.Text.Trim();
            data.VehicleCode = txtVehicleCode.Text.Trim();
            data.Comment = txtComment.Text.Trim();
            data.OwnerName = txtOwnerName.Text.Trim();
            data.OwnerPhone = txtOwnerPhone.Text.Trim();
            data.ParkingBegin = Func.FormatYYYYmmdd(txtParkingBegin.Text.Trim().Substring(0, 10));
            data.ParkingEnd = String.IsNullOrEmpty(txtParkingEnd.Text.Trim()) ? "" : Func.FormatYYYYmmdd(txtParkingEnd.Text.Trim().Substring(0, 10));

            data.ModifiedBy = Page.User.Identity.Name;
            data.CreatedBy = Page.User.Identity.Name;
            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.DelFlag = "0";
            data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);

            Execute(tran);

            if (!HasError)
            {
                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                mvMessage.SetCompleteMessage(addSuccess);
                ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);

                btnRegister.CommandName = "Register";
                hidAction.Value = "Edit";

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
            mvMessage.CheckRequired(drpVehicleType, "Loại xe: là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtVehicleCode, "Biển số: là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtVehicleName, "Hiệu xe: là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtOwnerName, "Chủ sở hữu: là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtOwnerPhone, "Số ĐT: là Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtParkingBegin, "Ngày bắt đầu gửi: là Danh mục bắt bắt buộc nhập");

            if (!mvMessage.IsValid)
                return;

            InsertData();
        }
        /// <summary>
        /// List data
        /// </summary>
        private void ShowData()
        {
            DataTable dtCount = DbHelper.GetDataTable("SELECT     COUNT(*) AS VehicleCount, A.VehicleType, C.CustomerId" +
                    " FROM         Mst_VehicleType AS A INNER JOIN" +
                    "              BD_TariffsPacking AS B ON A.Id = B.VehicleTypeId INNER JOIN" +
                    "              CustomerParking AS C ON B.id = C.TariffsParkingId" +
                    " WHERE     (C.DelFlag = 0) and (SUBSTRING(C.ParkingBegin ,1,6) <= '" + DateTime.Now.ToString("yyyyMM") + "'" +
                    " and ((C.ParkingEnd is null or C.ParkingEnd = '') or (C.ParkingEnd >=  '" + DateTime.Now.ToString("yyyyMMdd") + "'"+ "))) And C.CustomerId = '" + hidId.Value + "' and C.DelFlag = '0'" +
                    " GROUP BY A.VehicleType, C.CustomerId ");
            string tmp = "";
            foreach (DataRow rowType in dtCount.Rows)
            {
                tmp += rowType[1].ToString() + ":" + rowType[0].ToString() + " Chiếc </br>";
            }
            lblVehicleCount.Text = tmp;


            SqlDatabase db = new SqlDatabase();
            string sql = string.Empty;
            if (!Func.IsValid(ListSortExpression))
            {
                ListSortExpression = "Modified";
                ListSortDirection = SortDirection.Ascending;
            }
            try
            {
                //Đếm số lượng record
                sql += " SELECT COUNT(ID) ";
                sql += " FROM [CustomerParking]";
                sql += " WHERE (ID IS NOT NULL) and DelFlag <> 1 and CustomerId = '" + hidId.Value + "'";


                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " SELECT *, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM CustomerParking";
                sql += " WHERE (ID IS NOT NULL) and DelFlag <> 1 and CustomerId = '" + hidId.Value + "'";

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

                //sql = "SELECT   A.Name, COUNT(*) AS Mount";
                //sql += " FROM   BD_TariffsPacking AS A INNER JOIN";
                //sql += "        CustomerParking AS B ON A.id = B.TariffsParkingId";
                //sql += " WHERE  CustomerId = '" + hidId.Value + "' and B.DelFlag = '0' and  (B.ParkingBegin <= CONVERT(varchar(10), GETDATE(), 112)) AND (B.ParkingEnd >= CONVERT(varchar(10), GETDATE(), 112)) OR";
                //sql += "        (B.ParkingBegin > CONVERT(varchar(10), GETDATE(), 112)) AND (B.ParkingBegin <= CONVERT(varchar(10), DATEADD(s, - 1, DATEADD(mm, DATEDIFF(m, 0, GETDATE()+ 2), 0)), 112))";
                //sql += " GROUP BY A.Name";
                //cm = db.CreateCommand(sql);
                //da = new SqlDataAdapter(cm);
                //ds = new DataSet();
                //da.Fill(ds);
                //db.Close();
                //rptParking.DataSource = ds.Tables[0].DefaultView;
                //rptParking.DataBind();
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
                TextBox VehicleCode = (TextBox)e.Item.FindControl("txtVehicleCode");
                TextBox VehicleName = (TextBox)e.Item.FindControl("txtVehicleName");
                TextBox OwnerName = (TextBox)e.Item.FindControl("txtOwnerName");
                TextBox OwnerPhone = (TextBox)e.Item.FindControl("txtOwnerPhone");
                TextBox ParkingBegin = (TextBox)e.Item.FindControl("txtParkingBegin");
                TextBox ParkingEnd = (TextBox)e.Item.FindControl("txtParkingEnd");
                TextBox Comment = (TextBox)e.Item.FindControl("txtComment");

                DropDownList drpPriceName = (DropDownList)e.Item.FindControl("drpPriceName");

                mvMessage.CheckRequired(drpPriceName, "Loại xe: là Danh mục bắt bắt buộc nhập");
                mvMessage.CheckRequired(VehicleCode, "Biển số: là Danh mục bắt bắt buộc nhập");
                mvMessage.CheckRequired(VehicleName, "Hiệu xe: là Danh mục bắt bắt buộc nhập");
                mvMessage.CheckRequired(OwnerName, "Chủ sở hữu: là Danh mục bắt bắt buộc nhập");
                mvMessage.CheckRequired(OwnerPhone, "Số ĐT: là Danh mục bắt bắt buộc nhập");
                mvMessage.CheckRequired(ParkingBegin, "Ngày bắt đầu gửi: là Danh mục bắt bắt buộc nhập");

                if (!mvMessage.IsValid)
                    return;

                string sqlNew = " Update CustomerParking " +
                                " Set " +
                                "		TariffsParkingId	=@TariffsParkingId" +
                                "	,	VehicleCode	=@VehicleCode" +
                                "	,	VehicleName	=@VehicleName" +
                                "	,	OwnerName	=@OwnerName" +
                                "	,	OwnerPhone	=@OwnerPhone" +
                                "	,	ParkingBegin=@ParkingBegin" +
                                "	,	ParkingEnd	=@ParkingEnd" +
                                "	,	Comment	=@Comment		" +
                                "       ,Modified=@Modified" +
                                "       ,ModifiedBy=@ModifiedBy" +
                                " Where id=@id";

                using (SqlConnection rConn = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                {
                    rConn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlNew, rConn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@id", Func.ParseString(e.CommandArgument)));
                        cmd.Parameters.Add(new SqlParameter("@VehicleCode", VehicleCode.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@VehicleName", VehicleName.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@OwnerName", OwnerName.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@OwnerPhone", OwnerPhone.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@ParkingBegin", Func.FormatYYYYmmdd(ParkingBegin.Text.Trim().Substring(0, 10))));
                        cmd.Parameters.Add(new SqlParameter("@ParkingEnd", (String.IsNullOrEmpty(ParkingEnd.Text) ? "" : Func.FormatYYYYmmdd(ParkingEnd.Text.Trim().Substring(0, 10)))));
                        cmd.Parameters.Add(new SqlParameter("@Comment", Comment.Text.Trim()));

                        cmd.Parameters.Add(new SqlParameter("@TariffsParkingId", drpPriceName.SelectedValue));

                        cmd.Parameters.Add(new SqlParameter("@Modified", DateTime.Now.ToString("yyyyMMddHHmmss")));
                        cmd.Parameters.Add(new SqlParameter("@ModifiedBy", Page.User.Identity.Name));

                        cmd.ExecuteNonQuery();
                    }
                    rConn.Close();
                    mvMessage.SetCompleteMessage("Đã cập nhật thành công");
                    ShowData();
                }
            }
            else if (command.Equals("Delete"))
            {
                DbHelper.ExecuteDB("Update CustomerParking Set DelFlag = 1 Where ID = '" + Func.ParseString(e.CommandArgument) + "'");
                ShowData();
            }
        }
        //protected void rptParking_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    RepeaterItem item = e.Item;
        //    try
        //    {
        //        if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
        //        {
        //            DataRowView row = (DataRowView)item.DataItem;

        //            string Name = Func.ParseString(row["Name"]);
        //            string Mount = Func.ParseString(row["Mount"]);

        //            Func.SetGridTextValue(item, "lblName", Name);
        //            Func.SetGridTextValue(item, "lblMount", Mount);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ApplicationLog.WriteError(ex);
        //    }
        //}
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

                    string TariffsPackingId = Func.ParseString(row["TariffsParkingId"]);
                    string VehicleCode = Func.ParseString(row["VehicleCode"]);
                    string VehicleName = Func.ParseString(row["VehicleName"]);
                    string OwnerName = Func.ParseString(row["OwnerName"]);
                    string OwnerPhone = Func.ParseString(row["OwnerPhone"]);
                    string ParkingBegin = Func.ParseString(row["ParkingBegin"]);
                    string ParkingEnd = Func.ParseString(row["ParkingEnd"]);
                    string Comment = Func.ParseString(row["Comment"]);

                    Func.SetGridTextboxValue(item, "txtVehicleCode", VehicleCode);
                    Func.SetGridTextboxValue(item, "txtVehicleName", VehicleName);
                    Func.SetGridTextboxValue(item, "txtOwnerName", OwnerName);
                    Func.SetGridTextboxValue(item, "txtOwnerPhone", OwnerPhone);
                    Func.SetGridTextboxValue(item, "txtParkingBegin", Func.FormatDMY(ParkingBegin));
                    Func.SetGridTextboxValue(item, "txtParkingEnd", Func.FormatDMY(ParkingEnd));
                    Func.SetGridTextboxValue(item, "txtComment", Comment);

                    string ModifiedBy = Func.ParseString(row["ModifiedBy"].ToString().Trim());
                    string Modified = Func.ParseString(row["Modified"].ToString().Trim());
                    Func.SetGridTextValue(item, "ltrModifiedBy", ModifiedBy);
                    Func.SetGridTextValue(item, "ltrModified", Func.Formatdmyhms(Modified));

                    Button btnUpdate = (Button)item.FindControl("btnUpdate");
                    btnUpdate.CommandArgument = Func.ParseString(row["id"]);

                    Button btnDelete = (Button)item.FindControl("btnDelete");
                    btnDelete.CommandArgument = Func.ParseString(row["id"]);

                    DropDownList drpPriceName = (DropDownList)item.FindControl("drpPriceName");

                    DbHelper.FillListSearch(drpPriceName, "Select Name + '('+ CONVERT(nvarchar,PriceVND) +')' as PriceName, id from BD_TariffsPacking Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "PriceName", "id");
                    drpPriceName.SelectedValue = TariffsPackingId;
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
    }
}
