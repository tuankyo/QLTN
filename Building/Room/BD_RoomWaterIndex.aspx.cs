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
    public partial class BD_RoomWaterIndex : Man.PageBase
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
            BD_RoomData data = new BD_RoomData();
            ITransaction tran = factory.GetLoadObject(data, id);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_RoomData)tran.Result;
                lblRoomId.Text = data.id;
                lblName.Text = data.Name;
                lblArea.Text = data.Area;
                lblFloor.Text = data.Floor;
            }
            DbHelper.FillListSearch(drpCustomerId, "SELECT CustomerId,CustomerId + '-' + Name as Name  FROM Customer Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and delflag = 0", "Name", "CustomerId");

            string CustomerId = DbHelper.GetScalar("SELECT CustomerId FROM BD_RoomUsedElecWater where id = (select MAX(id) from BD_RoomUsedElecWater where RoomId = '" + id + "' and DelFlag = 0 and TarrifsType = 2)");
            drpCustomerId.SelectedValue = CustomerId;

            DbHelper.FillListSearch(drpTariffsOfWater, "Select Id,Name from BD_FeeGroup where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'  and delflag = 0 and feeGroup = 2", "Name", "ID");

            ShowData();
        }

        /// <summary>
        /// Update
        /// </summary>
        private void DeleteData(string strId)
        {
            BD_RoomUsedElecWaterData data = new BD_RoomUsedElecWaterData();
            ITransaction tran = factory.GetLoadObject(data, strId);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_RoomUsedElecWaterData)tran.Result;
                data.DelFlag = "1";
                tran = factory.GetUpdateObject(data);
                data.ElecPricePercent = data.ElecPricePercent.Replace(",", ".");
                data.WaterPricePercent = data.WaterPricePercent.Replace(",", ".");

                data.OldIndex = data.OldIndex.Replace(",", ".");
                data.NewIndex = data.NewIndex.Replace(",", ".");

                data.ModifiedBy = Page.User.Identity.Name;
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");

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
        private void InsertData()
        {
            //Get and Insert Data
            BD_RoomUsedElecWaterData data = new BD_RoomUsedElecWaterData();
            ITransaction tran = factory.GetInsertObject(data);
            data.CustomerId = drpCustomerId.SelectedValue;
            data.DateFrom = Func.FormatYYYYmmdd(txtDateFrom.Text.Trim());
            data.DateTo = Func.FormatYYYYmmdd(txtDateTo.Text.Trim());
            data.OldIndex = txtOldIndex.Text.Trim();
            data.NewIndex = txtNewIndex.Text.Trim();
            data.OtherFee01 = txtOtherFee1.Text.Trim().Replace(',', '.');
            data.OtherFee02 = txtOtherFee2.Text.Trim().Replace(',', '.');

            data.ModifiedBy = Page.User.Identity.Name;
            data.CreatedBy = Page.User.Identity.Name;
            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.DelFlag = "0";
            data.YearMonth = drpYear.SelectedValue + drpMonth.SelectedValue;

            data.RoomId = lblRoomId.Text;
            data.TarrifsType = "2";
            data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);

            data.TariffsOfWaterId = drpTariffsOfWater.SelectedValue;

            data.ElecPricePercent = "0";
            data.WaterPricePercent = "0";

            Execute(tran);

            if (!HasError)
            {
                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                mvMessage.SetCompleteMessage(addSuccess);
                ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);

                txtOldIndex.Text = "";
                txtNewIndex.Text = "";

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
            for (int i = 2000; i < 2050; i++)
            {
                drpYear.Items.Add(new ListItem(Func.ParseString(i), Func.ParseString(i)));
            }
            drpYear.Items.FindByValue(DateTime.Now.AddMonths(-1).ToString("yyyy")).Selected = true;

            for (int i = 1; i < 13; i++)
            {
                drpMonth.Items.Add(new ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
            }
            drpMonth.Items.FindByValue(DateTime.Now.AddMonths(-1).ToString("MM")).Selected = true;
        }
        protected override void DoGet()
        {
            id = Request["id"];

            if (!IsPostBack)
            {
                LoadData();
            }
            btnRegister.Text = "Thêm Mới";
            btnRegister.CommandName = "Hủy";
            btnCancel.Text = "Đóng";
        }

        protected override void DoPost()
        {

        }

        protected void txtDateTo_OnTextChanged(object sender, EventArgs e)
        {
            string year = Func.FormatYYYYmmdd(txtDateTo.Text).Substring(0, 4);
            string month = Func.FormatYYYYmmdd(txtDateTo.Text).Substring(4, 2);
            drpMonth.SelectedValue = month;
            drpYear.SelectedValue = year;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //mvMessage.CheckRequired(txt, "* là Danh mục bắt bắt buộc nhập");
            InsertData();
        }

        //protected void txtCustomerIdChanged(object sender, EventArgs e)
        //{
        //    string begin = Func.FormatYYYYmmdd(txtDateFrom.Text);
        //    string end = Func.FormatYYYYmmdd(txtDateTo.Text);

        //    if (!String.IsNullOrEmpty(begin) && !String.IsNullOrEmpty(end))
        //    {
        //        //mvMessage.CheckRequired(txt, "* là Danh mục bắt bắt buộc nhập");
        //        txtCustomerId.Text = DbHelper.GetScalar("SELECT A.CustomerId FROM RentContract AS A INNER JOIN RC_Room AS B ON A.ContractId = B.ContractId Where B.BeginContract <= '" + begin + "' and B.BeginContract <= '" + end + "' and B.EndContract >= '" + begin + "' and B.EndContract >= '" + begin + "' and B.RoomId = '" + lblRoomId.Text + "'");
        //        lblCustomerName.Text = "Không tìm thấy có Khách Hàng nào đang sử dụng phòng này";
        //        if (!String.IsNullOrEmpty(txtCustomerId.Text))
        //        {
        //            lblCustomerName.Text = DbHelper.GetScalar("Select Name From Customer Where CustomerId = '" + txtCustomerId.Text + "'");
        //        }
        //    }
        //}

        /// <summary>
        /// List data
        /// </summary>
        private void ShowData()
        {
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
                sql += " Select COUNT(ID) ";
                sql += " FROM [BD_RoomUsedElecWater]";
                sql += " WHERE (ID IS NOT NULL) and DelFlag <> 1 and RoomId = '" + lblRoomId.Text + "' and TarrifsType = 2";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " Select * ,ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM [BD_RoomUsedElecWater]";
                sql += " WHERE (ID IS NOT NULL) and DelFlag <> 1 and RoomId = '" + lblRoomId.Text + "' and TarrifsType = 2";

                //Phân trang
                sql = " Select * FROM (" + sql + ") AS TMP ";
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
                    string ID = Func.ParseString(row["ID"]);
                    string DateFrom = Func.ParseString(row["DateFrom"]);
                    string DateTo = Func.ParseString(row["DateTo"]);
                    string CustomerId = Func.ParseString(row["CustomerId"]);
                    string OldIndex = Func.ParseString(row["OldIndex"]);
                    string NewIndex = Func.ParseString(row["NewIndex"]);

                    Func.SetGridTextValue(item, "ltrID", ID);
                    Func.SetGridTextValue(item, "ltrDateFrom", Func.FormatDMY(DateFrom));
                    Func.SetGridTextValue(item, "ltrDateTo", Func.FormatDMY(DateTo));
                    Func.SetGridTextValue(item, "ltrCustomerId", CustomerId);
                    Func.SetGridTextValue(item, "ltrOldIndex", Func.FormatNumber(OldIndex));
                    Func.SetGridTextValue(item, "ltrNewIndex", Func.FormatNumber(NewIndex));


                    string ModifiedBy = Func.ParseString(row["ModifiedBy"].ToString().Trim());
                    string Modified = Func.ParseString(row["Modified"].ToString().Trim());
                    Func.SetGridTextValue(item, "ltrModifiedBy", ModifiedBy);
                    Func.SetGridTextValue(item, "ltrModified", Func.Formatdmyhms(Modified));

                    Button btnDelete = (Button)item.FindControl("btnDelete");
                    btnDelete.CommandArgument = ID;
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
            }
            else if (command.Equals("Delete"))
            {
                DeleteData(Func.ParseString(e.CommandArgument));
            }
            ShowData();
        }
    }
}
