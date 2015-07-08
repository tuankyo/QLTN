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

namespace Man.Building.TarrifsElecWater
{
    public partial class BD_FeeGroup : Man.PageBase
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
        private string titleWater = "Nhóm Biểu Phí Tiền Nước";
        private string titleElec = "Nhóm Biểu Phí Tiền Điện";

        private string postback = "window.opener.__doPostBack('PopupTarrifsElecWaterEdit','');";
        private string key = "openTarrifsElecWaterEdit";

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
            BD_FeeGroupData data = new BD_FeeGroupData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_FeeGroupData)tran.Result;
                txtName.Text = data.Name;
                txtVAT.Text = data.VAT;
                txtOtherFee1.Text = data.OtherFee01;
                txtOtherFee2.Text = data.OtherFee02;

                txtComment.Text = data.Comment;

                lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";

                hidId.Value = id;
                ShowData();
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void UpdateData()
        {
            BD_FeeGroupData data = new BD_FeeGroupData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_FeeGroupData)tran.Result;
                data.Name = txtName.Text;
                data.VAT = txtVAT.Text;
                data.OtherFee01 = txtOtherFee1.Text;
                data.OtherFee02 = txtOtherFee2.Text;

                data.Comment = txtComment.Text.Trim();
                data.FeeGroup = hidFeeGroup.Value;

                data.ModifiedBy = Page.User.Identity.Name;
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);

                tran = factory.GetUpdateObject(data);

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(updateSuccess);
                    ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);

                    lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                    lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";

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
            BD_FeeGroupData data = new BD_FeeGroupData();
            ITransaction tran = factory.GetInsertObject(data);

            data.Name = txtName.Text;
            data.VAT = txtVAT.Text;
            data.OtherFee01 = txtOtherFee1.Text;
            data.OtherFee02 = txtOtherFee2.Text;

            data.Comment = txtComment.Text.Trim();
            data.FeeGroup = hidFeeGroup.Value;

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
            hidFeeGroup.Value = Request["FeeGroup"];

            hidId.Value = id;
            hidAction.Value = action;

            if (!String.IsNullOrEmpty(hidAction.Value))
            {
                ShowData();
            }

            lblOtherFee1.Text = "Hệ số(>=1)";
            lblOtherFee2.Text = "Phụ Thu(%)";
            string tmp = titleElec;
            if ("2".Equals(hidFeeGroup.Value))
            {
                tmp = titleWater;
                lblOtherFee1.Text = "BVMT(%)";
                lblOtherFee2.Text = "Phụ Thu(%)";
            }
            SqlDatabase db = new SqlDatabase();
            if (action == "Edit")
            {
                lblHeader.Text = "Thông Tin Chi Tiết " + tmp;
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
                lblHeader.Text = "Thêm Mới " + tmp;
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
            mvMessage.CheckRequired(txtName, "Biểu Phí: Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtOtherFee1, "Phí Khác(1): Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtOtherFee1, "Phí Khác(2): Danh mục bắt bắt buộc nhập");
            mvMessage.CheckRequired(txtVAT, "VAT: Danh mục bắt bắt buộc nhập");

            if (!mvMessage.IsValid) return;
            //InsertData();
            if (hidAction.Value == "Edit")
            {
                UpdateData();
            }
            else // Add new case
            {
                InsertData();
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
                ListSortExpression = "A.FeeGroup, IndexFrom";
                ListSortDirection = SortDirection.Ascending;
            }
            try
            {
                //Đếm số lượng record
                sql += " SELECT COUNT(ID) ";
                sql += " FROM BD_FeeGroup ";
                sql += " WHERE DelFlag <> '1' and FeeGroup = '" + hidFeeGroup.Value + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " SELECT *,ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM BD_FeeGroup";
                sql += " WHERE DelFlag <> '1' and FeeGroup = '" + hidFeeGroup.Value + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";

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
                    string ID = Func.ParseString(row["id"]);
                    string Name = Func.ParseString(row["Name"]);
                    string IndexFrom = Func.ParseString(row["IndexFrom"]);
                    string Comment = Func.ParseString(row["Comment"]);
                    string PriceVND = Func.ParseString(row["PriceVND"]);
                    string PriceUSD = Func.ParseString(row["PriceUSD"]);

                    string VAT = Func.ParseString(row["VAT"]);
                    string OtherFee01 = Func.ParseString(row["OtherFee01"]);
                    string OtherFee02 = Func.ParseString(row["OtherFee02"]);

                    string FeeGroupName = Func.ParseString(row["FeeGroupName"]);

                    Func.SetGridLinkValue(item, "btnEdit", ID);
                    Func.SetGridTextValue(item, "ltrName", Name);
                    Func.SetGridTextValue(item, "ltrIndexFrom", IndexFrom);
                    Func.SetGridTextValue(item, "ltrComment", Func.ToolTipByteLen(Comment, 20));
                    Func.SetGridTextValue(item, "ltrPriceVND", Func.FormatCurrency(PriceVND));
                    Func.SetGridTextValue(item, "ltrPriceUSD", Func.FormatCurrency(PriceUSD));

                    Func.SetGridTextValue(item, "ltrOtherFee01", OtherFee01);
                    Func.SetGridTextValue(item, "ltrOtherFee02", OtherFee02);
                    Func.SetGridTextValue(item, "ltrVAT", VAT);

                    Func.SetGridTextValue(item, "ltrGroup", FeeGroupName);

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
