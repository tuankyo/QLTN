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
    public partial class BD_RoomBookingService : Man.PageBase
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

        private string addSuccess = "Thêm Mới Thành Công";
        private string addUnSuccess = "Thêm Mới Không Thành Công";
        private string deleteSuccess = "Xóa Thành Công";
        private string deleteUnSuccess = "Xóa Không Thành Công";
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
            //BD_StaffData data = new BD_StaffData();
            //ITransaction tran = factory.GetLoadObject(data, id);
            //Execute(tran);
            //if (!HasError)
            //{
            //    //Get Data
            //    data = (BD_StaffData)tran.Result;
            //    lblStaffId.Text = data.StaffId;
            //    lblName.Text = data.Name;
            //}

            ShowData();
        }

        /// <summary>
        /// Update
        /// </summary>
        private void DeleteData(string strId)
        {
            BD_RoomBookingServiceData data = new BD_RoomBookingServiceData();
            ITransaction tran = factory.GetLoadObject(data, strId);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_RoomBookingServiceData)tran.Result;
                data.DelFlag = "1";

                data.Mount = data.Mount.Replace(".", "").Replace(",", ".");
                data.PriceVND = data.PriceVND.Replace(".", "").Replace(",", ".");
                data.PriceUSD = data.PriceUSD.Replace(".", "").Replace(",", ".");
                data.VAT = data.VAT.Replace(".", "").Replace(",", ".");
                data.OtherFee01 = "0";
                data.OtherFee02 = "0";

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
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, deleteUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(deleteUnSuccess);
                }
            }
        }

        /// <summary>
        /// Insert data
        /// </summary>
        private void InsertData()
        {
            mvMessage.CheckRequired(txtService, "Dịch vụ: Danh mục phải nhập");
            mvMessage.CheckRequired(txtMount, "Số lượng: Danh mục phải nhập");
            mvMessage.CheckRequired(txtPriceVND, "Đơn giá(VND): Danh mục phải nhập");
            mvMessage.CheckRequired(txtPriceUSD, "Đơn giá(USD): Danh mục phải nhập");

            if (!mvMessage.IsValid) return;

            //Get and Insert Data
            BD_RoomBookingServiceData data = new BD_RoomBookingServiceData();
            ITransaction tran = factory.GetInsertObject(data);
            data.Service = txtService.Text.Trim();
            data.Mount = txtMount.Text.Trim().Replace(".", "").Replace(",", ".");
            data.PriceVND = txtPriceVND.Text.Trim().Replace(".", "").Replace(",", ".");
            data.PriceUSD = txtPriceUSD.Text.Trim().Replace(".", "").Replace(",", ".");
            data.VAT = txtVAT.Text.Trim().Replace(".", "").Replace(",", ".");
            data.OtherFee01 = "0";
            data.OtherFee02 = "0";

            data.Comment = txtComment.Text.Trim();
            data.ModifiedBy = Page.User.Identity.Name;
            data.CreatedBy = Page.User.Identity.Name;
            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.DelFlag = "0";
            data.Unit = txtUnit.Text;
            data.BookingId = hidId.Value;

            Execute(tran);

            if (!HasError)
            {
                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                mvMessage.SetCompleteMessage(addSuccess);
                ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);

                txtComment.Text = "";

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
            hidId.Value = Request["id"];

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

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //mvMessage.CheckRequired(txt, "* là Danh mục bắt bắt buộc nhập");
            InsertData();
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
                ListSortExpression = "Modified";
                ListSortDirection = SortDirection.Ascending;
            }
            try
            {
                //Đếm số lượng record
                sql += " SELECT COUNT(ID) ";
                sql += " FROM [BD_RoomBookingService]";
                sql += " WHERE (ID IS NOT NULL) and DelFlag <> 1 and BookingId = '" + hidId.Value + "'";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " SELECT * ,ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM [BD_RoomBookingService]";
                sql += " WHERE (ID IS NOT NULL) and DelFlag <> 1 and BookingId = '" + hidId.Value + "'";

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
                    string Service = Func.ParseString(row["Service"]);
                    string Mount = Func.ParseString(row["Mount"]);

                    string PriceVND = Func.ParseString(row["PriceVND"]);
                    string PriceUSD = Func.ParseString(row["PriceUSD"]);
                    string VAT = Func.ParseString(row["VAT"]);

                    string Comment = Func.ParseString(row["Comment"]);

                    Func.SetGridTextValue(item, "ltrService", Service);
                    Func.SetGridTextValue(item, "ltrMount", Func.FormatNumber_New(Mount));

                    Func.SetGridTextValue(item, "ltrPriceVND", Func.FormatNumber_New(PriceVND));
                    Func.SetGridTextValue(item, "ltrVAT", Func.FormatNumber_New(VAT));
                    Func.SetGridTextValue(item, "ltrPriceUSD", Func.FormatNumber_New(PriceUSD));

                    Func.SetGridTextValue(item, "ltrComment", Func.ToolTipByteLen(Comment, 20));

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
