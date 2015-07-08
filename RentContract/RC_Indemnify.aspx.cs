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
    public partial class RC_Indemnify : Man.PageBase
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
        private string title = "Bàn Giao";
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
                //lblContractDate.Text = Func.Formatdmyhms(data.ContractDate);
                //lblContractEndDate.Text = Func.Formatdmyhms(data.ContractEndDate);
                //lblReceiveDate.Text = Func.Formatdmyhms(data.ReceiveDate);
                //lblStaffMount.Text = data.StaffMount;
                //lblComment.Text = data.Comment;
                //chkDelFlag.Checked = "1".Equals(data.DelFlag) ? false : true;
                //lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                //lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";

                //txtContractDate.Text = Func.Formatdmyhms(data.ContractDate);
                //txtContractEndDate.Text = Func.Formatdmyhms(data.ContractEndDate);

                ShowData();

                //string sqlElec = " SELECT distinct ID, Name";
                //sqlElec += " FROM BD_FeeGroup B ";
                //sqlElec += " WHERE B.DelFlag <> '1' and FeeGroup = 1 and B.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";

                //string sqlWater = " SELECT distinct ID, Name";
                //sqlWater += " FROM BD_FeeGroup B ";
                //sqlWater += " WHERE B.DelFlag <> '1' and FeeGroup = 2 and B.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";

                //DbHelper.FillList(drpTariffsOfElec, sqlElec, "Name", "ID");
                //DbHelper.FillList(drpTariffsOfWater, sqlWater, "Name", "ID");
                //DbHelper.FillList(drpRoom, "Select ID, Name + '(' + Regional + '-' + [FLOOR] + '-' + convert(nvarchar(10),Area) + 'm2)' as RoomName from BD_Room Where DelFlag <> '1' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "RoomName", "ID");

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
                //data.Comment = lblComment.Text.Trim();
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

        /// <summary>
        /// Insert data
        /// </summary>
        private void InsertData()
        {
            //Get and Insert Data
            RC_IndemnifyData data = new RC_IndemnifyData();
            ITransaction tran = factory.GetInsertObject(data);
            data.ContractId = lblId.Text.Trim();
            data.Item = txtItem.Text.Trim();
            data.ReceiveDate = Func.FormatYYYYmmdd(txtReceiveDate.Text.Substring(0, 10));
            data.Mount = txtMount.Text.Trim();
            data.PriceVND = txtPriceVND.Text.Trim();
            data.PriceUSD = txtPriceUSD.Text.Trim().Replace(",",".");

            data.Indemnifier = txtIndemnifier.Text.Trim();
            data.Receiver = txtReceiver.Text.Trim();
            data.Description = txtDescription.Text.Trim();

            data.Comment = txtComment.Text.Trim();
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
                ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);

                btnRegister.CommandName = "Register";
                hidAction.Value = "Edit";
                lblId.Enabled = false;
                hidId.Value = data.id;
                //lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                //lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";

                ShowData();
                txtItem.Text = "";
                txtReceiveDate.Text = "";
                txtMount.Text = "";
                txtPriceVND.Text = "";
                txtPriceUSD.Text = "";

                txtIndemnifier.Text = "";
                txtReceiver.Text = "";
                txtDescription.Text = "";

                txtComment.Text.Trim();
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
                sql += " FROM [RC_Indemnify]";
                sql += " WHERE (ID IS NOT NULL) and DelFlag <> 1 and ContractId = '" + lblId.Text + "'";


                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " SELECT A.*, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM [RC_Indemnify] A";
                sql += " WHERE (ID IS NOT NULL) and DelFlag <> 1 and ContractId = '" + lblId.Text + "'";

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
            else if (command.Equals("Delete"))
            {
                DbHelper.ExecuteDB("Update RC_Indemnify Set DelFlag = 1 Where ID = '" + Func.ParseString(e.CommandArgument) + "'");
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

                    string ID = Func.ParseString(row["ID"]);
                    string Item = Func.ParseString(row["Item"]);

                    string Mount = Func.ParseString(row["Mount"]);
                    string PriceVND = Func.ParseString(row["PriceVND"]);
                    string PriceUSD = Func.ParseString(row["PriceUSD"]);
                    string Indemnifier = Func.ParseString(row["Indemnifier"]);
                    string Receiver = Func.ParseString(row["Receiver"]);
                    string ReceiveDate = Func.ParseString(row["ReceiveDate"]);
                    string Description = Func.ParseString(row["Description"]);

                    string Comment = Func.ParseString(row["Comment"]);

                    Func.SetGridTextValue(item, "ltrItem", Item);
                    Func.SetGridTextValue(item, "ltrReceiveDate", Func.Formatdmyhms(ReceiveDate).Substring(0, 10));
                    Func.SetGridTextValue(item, "ltrMount", Mount);
                    Func.SetGridTextValue(item, "ltrPriceVND", PriceVND);
                    Func.SetGridTextValue(item, "ltrPriceUSD", PriceUSD);
                    Func.SetGridTextValue(item, "ltrIndemnifier", Indemnifier);
                    Func.SetGridTextValue(item, "ltrReceiver", Receiver);
                    Func.SetGridTextValue(item, "ltrReceiveDate", ReceiveDate);
                    Func.SetGridTextValue(item, "ltrDescription", Func.ToolTipByteLen(Description,20));

                    Func.SetGridTextValue(item, "ltrComment", Func.ToolTipByteLen(Comment,20));
                    string ModifiedBy = Func.ParseString(row["ModifiedBy"].ToString().Trim());
                    string Modified = Func.ParseString(row["Modified"].ToString().Trim());
                    Func.SetGridTextValue(item, "ltrModifiedBy", ModifiedBy);
                    Func.SetGridTextValue(item, "ltrModified", Func.Formatdmyhms(Modified));

                    Button btnDelete = (Button)item.FindControl("btnDelete");
                    btnDelete.CommandArgument = Func.ParseString(row["id"]);

                    //Button btnDelete = (Button)item.FindControl("btnDelete");
                    //btnDelete.CommandArgument = Func.ParseString(row["id"]);
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
