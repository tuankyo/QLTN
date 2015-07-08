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

namespace Man.Building.TicketStubs
{
    public partial class BD_TicketStubsUsed : Man.PageBase
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
        private string title = "Nhân Viên";
        private string postback = "window.opener.__doPostBack('PopupBD_TicketStubsEdit','');";
        private string key = "openBD_TicketStubsEdit";
        private string deleteSuccess = "Xóa Thành Công";
        private string deleteUnSuccess = "Xóa Không Thành Công";

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
            BD_TicketStubsData data = new BD_TicketStubsData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_TicketStubsData)tran.Result;
                lblSeriNumber.Text = data.SeriNumber;
                //lblReceiveDate.Text = !"".Equals(data.ReceiveDate) ? Func.FormatDMY(data.ReceiveDate) : "";

                //lblReceiveFrom.Text = data.ReceiveFrom;
                //lblReceiver.Text = data.Receiver;
                //lblMount.Text = data.Mount;
                //lblPrice.Text = data.Price;

                //txtUsedMount.Text = data.UsedMount;
                //txtUsedReceiveFrom.Text = data.UsedReceiveFrom;
                //txtUsedDate.Text = !"".Equals(data.UsedDate) ? Func.FormatDMY(data.UsedDate) : "";
                //txtUsedReceiver.Text = data.UsedReceiver;
                //txtUsedComment.Text = data.UsedComment;

                //lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                //lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";

                hidId.Value = id;
            }
            ShowData();
        }
        /// <summary>
        /// Update
        /// </summary>
        private void DeleteData(string strId)
        {
            BD_TicketStubsPayData data = new BD_TicketStubsPayData();
            ITransaction tran = factory.GetLoadObject(data, strId);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_TicketStubsPayData)tran.Result;
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
                sql += " FROM [BD_TicketStubsPay]";
                sql += " WHERE (ID IS NOT NULL) and DelFlag <> 1 and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and SeriNumber = '" + lblSeriNumber.Text + "'";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " SELECT * ,ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM [BD_TicketStubsPay]";
                sql += " WHERE (ID IS NOT NULL) and DelFlag <> 1 and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and SeriNumber = '" + lblSeriNumber.Text + "'";

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
                    string UsedMount = Func.ParseString(row["UsedMount"]);
                    string UsedPrice = Func.ParseString(row["UsedPrice"]);
                    string UsedSum = Func.ParseString(row["UsedSum"]);
                    string UsedReceiveFrom = Func.ParseString(row["UsedReceiveFrom"]);
                    string UsedReceiver = Func.ParseString(row["UsedReceiver"]);
                    string UsedDate = Func.ParseString(row["UsedDate"]);

                    string Comment = Func.ParseString(row["UsedComment"]);
                    string PaidSeriNumber = Func.ParseString(row["PaidSeriNumber"]);

                    Func.SetGridTextValue(item, "ltrComment", Func.ToolTipByteLen(Comment, 20));
                    Func.SetGridTextValue(item, "ltrUsedMount",UsedMount);
                    Func.SetGridTextValue(item, "ltrUsedPrice",UsedPrice);
                    Func.SetGridTextValue(item, "ltrUsedSum",UsedSum);
                    Func.SetGridTextValue(item, "ltrUsedReceiveFrom",UsedReceiveFrom);
                    Func.SetGridTextValue(item, "ltrUsedReceiver",UsedReceiver);
                    Func.SetGridTextValue(item, "ltrUsedDate", Func.FormatDMY(UsedDate));
                    Func.SetGridTextValue(item, "ltrPaidSeriNumber", PaidSeriNumber);

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
        /// <summary>
        /// Update
        /// </summary>
        //private void UpdateData()
        //{
        //    BD_TicketStubsPayData data = new BD_TicketStubsPayData();
        //    ITransaction tran = factory.GetLoadObject(data, hidId.Value);
        //    Execute(tran);
        //    if (!HasError)
        //    {
        //        //Get Data
        //        data = (BD_TicketStubsPayData)tran.Result;
        //        data.Used = txtUsedMount.Text.Trim();
        //        data.UsedMount = txtUsedMount.Text.Trim();
        //        data.UsedReceiveFrom = txtUsedReceiveFrom.Text.Trim();
        //        data.UsedDate = !"".Equals(txtUsedDate.Text.Trim()) ? Func.FormatYYYYmmdd(txtUsedDate.Text.Trim()) : "";
        //        data.UsedReceiver = txtUsedReceiver.Text.Trim();
        //        data.UsedComment = txtUsedComment.Text.Trim();

        //        tran = factory.GetUpdateObject(data);

        //        Execute(tran);

        //        if (!HasError)
        //        {
        //            OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateSuccess, Page.User.Identity.Name);
        //            mvMessage.SetCompleteMessage(updateSuccess);
        //            ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);

        //            lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
        //            lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";
        //        }
        //        else
        //        {
        //            OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateUnSuccess, Page.User.Identity.Name);
        //            mvMessage.AddError(updateUnSuccess);
        //        }
        //    }
        //}

        /// <summary>
        /// Insert data
        /// </summary>
        private void InsertData()
        {
            //Get and Insert Data
            BD_TicketStubsPayData data = new BD_TicketStubsPayData();
            ITransaction tran = factory.GetInsertObject(data);
            data.SeriNumber = lblSeriNumber.Text.Trim();
            data.UsedDate = !"".Equals(txtUsedDate.Text.Trim()) ? Func.FormatYYYYmmdd(txtUsedDate.Text.Trim()) : "";

            data.UsedReceiveFrom = txtUsedReceiveFrom.Text.Trim();
            data.UsedReceiver = txtUsedReceiver.Text.Trim();
            data.UsedMount = txtUsedMount.Text.Trim();
            data.UsedPrice = txtUsedPrice.Text.Trim();
            data.UsedSum = "" + Func.ParseInt(txtUsedMount.Text.Trim()) * Func.ParseInt(txtUsedPrice.Text.Trim());

            data.ModifiedBy = Page.User.Identity.Name;
            data.CreatedBy = Page.User.Identity.Name;
            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.DelFlag = "0";
            data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);
            data.PaidSeriNumber = txtPaidSeriNumber.Text;

            data.UsedComment = txtUsedComment.Text;

            Execute(tran);

            if (!HasError)
            {
                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                mvMessage.SetCompleteMessage(addSuccess);
                ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);


                btnRegister.CommandName = "Register";
                hidAction.Value = "Edit";
                hidId.Value = data.id;
                lblSeriNumber.Enabled = false;

                lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";
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

            //DbHelper.FillList(drpJobTypeId, "Select * from MST_JobType where delFlag <> 1 ", "Name", "id");
            SqlDatabase db = new SqlDatabase();
            if (action == "Edit")
            {
                //lblHeader.Text = "Thông Tin Chi Tiết " + title;
                btnRegister.Text = "Cập Nhật";
                btnCancel.Text = "Đóng";
                btnRegister.CommandName = "Edit";
                lblSeriNumber.Enabled = false;
                if (!IsPostBack)
                {
                    LoadData();
                }
            }
            else // Add new case
            {
                //lblHeader.Text = "Thêm Mới " + title;
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
            //mvMessage.CheckRequired(lblName, "* là Danh mục bắt bắt buộc nhập");
            InsertData();
        }
    }
}
