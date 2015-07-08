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
    public partial class CustomerService : Man.PageBase
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
        private string title = "Dịch Vụ Cộng Thêm";
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
            ShowData();
        }

        protected void txtDateTo_OnTextChanged(object sender, EventArgs e)
        {
            string year = Func.FormatYYYYmmdd(txtServiceDateTo.Text).Substring(0, 4);
            string month = Func.FormatYYYYmmdd(txtServiceDateTo.Text).Substring(4, 2);
            drpMonth.SelectedValue = month;
            drpYear.SelectedValue = year;
        }

        /// <summary>
        /// Update
        /// </summary>
        private void DeleteData(string strId)
        {
            CustomerServiceData data = new CustomerServiceData();
            ITransaction tran = factory.GetLoadObject(data, strId);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (CustomerServiceData)tran.Result;
                data.PriceUSD = data.PriceUSD.Replace(",", ".");
                data.PriceVND = data.PriceVND.Replace(",", ".");
                data.Mount = data.Mount.Replace(",", ".");
                data.VAT = data.VAT.Replace(",", ".");
                data.OtherFee01 = "0";
                data.OtherFee02 = "0";
                data.Unit = txtUnit.Text;

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
        /// Insert data
        /// </summary>
        private void InsertData()
        {
            double PriceVND = Func.ParseDouble(txtPriceVND.Text.Trim());
            float PriceUSD = Func.ParseFloat(txtPriceUSD.Text.Trim().Replace(",", "."));

            if (PriceVND != 0 && PriceUSD != 0)
            {
                mvMessage.AddError("Đơn giá không được phép nhập cả 2 USD và VND lớn hơn 0. \n Một trong 2 loại phải = 0");
                return;
            }

            //Get and Insert Data
            CustomerServiceData data = new CustomerServiceData();
            ITransaction tran = factory.GetInsertObject(data);
            data.CustomerId = hidId.Value;
            data.Service = txtService.Text.Trim();
            data.ServiceDateFrom = Func.FormatYYYYmmdd(txtServiceDateFrom.Text.Trim());
            data.ServiceDateTo = Func.FormatYYYYmmdd(txtServiceDateTo.Text.Trim());

            data.PriceUSD = txtPriceUSD.Text.Trim().Replace(",", ".");
            data.PriceVND = txtPriceVND.Text.Trim().Replace(",", ".");
            data.Mount = txtMount.Text.Trim().Replace(",", ".");
            data.VAT = txtVAT.Text.Trim().Replace(",", ".");
            data.OtherFee01 = "0";
            data.OtherFee02 = "0";
            data.YearMonth = drpYear.SelectedValue + drpMonth.SelectedValue;
            data.Unit = txtUnit.Text;

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

                //txtDescription.Text = "";
                //txtComplainDate.Text = "";
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

            InitValues();
        }
        protected override void DoGet()
        {
            id = Request["id"];
            hidId.Value = id;

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
            //mvMessage.CheckRequired(txtComplainDate, "Ngày: Danh mục bắt bắt buộc nhập");
            //mvMessage.CheckRequired(txtDescription, "Nội Dung: Danh mục bắt bắt buộc nhập");

            if (!mvMessage.IsValid) return;

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
                sql += " FROM [CustomerService]";
                sql += " WHERE (ID IS NOT NULL) and DelFlag = 0 and CustomerId = '" + hidId.Value + "'";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " SELECT * ,ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM [CustomerService]";
                sql += " WHERE (ID IS NOT NULL) and DelFlag = 0 and CustomerId = '" + hidId.Value + "'";

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
                    string ServiceDateFrom = Func.ParseString(row["ServiceDateFrom"]);
                    string ServiceDateTo = Func.ParseString(row["ServiceDateTo"]);
                    string Service = Func.ParseString(row["Service"]);
                    string Mount = Func.ParseString(row["Mount"]);
                    string Unit = Func.ParseString(row["Unit"]);
                    string VAT = Func.ParseString(row["VAT"]);
                    string PriceVND = Func.ParseString(row["PriceVND"]);
                    string PriceUSD = Func.ParseString(row["PriceUSD"]);

                    double SumVND = Func.ParseDouble(Mount) * Func.ParseDouble(PriceVND) + Func.ParseDouble(Mount) * Func.ParseDouble(PriceVND) * Func.ParseDouble(VAT) / 100;
                    double SumUSD = Func.ParseDouble(Mount) * Func.ParseDouble(PriceUSD) + Func.ParseDouble(Mount) * Func.ParseDouble(PriceUSD) * Func.ParseDouble(VAT) / 100;

                    string Comment = Func.ParseString(row["Comment"]);

                    Func.SetGridTextValue(item, "ltrServiceDateFrom", Func.Formatdmyhms(ServiceDateFrom));
                    Func.SetGridTextValue(item, "ltrServiceDateTo", Func.Formatdmyhms(ServiceDateTo));
                    Func.SetGridTextValue(item, "ltrService", Service);

                    Func.SetGridTextValue(item, "ltrMount", Func.FormatDecimal(Mount));
                    Func.SetGridTextValue(item, "ltrUnit", Unit);
                    Func.SetGridTextValue(item, "ltrPriceVND", Func.FormatDecimal(PriceVND));
                    Func.SetGridTextValue(item, "ltrPriceUSD", Func.FormatDecimal(PriceUSD));
                    Func.SetGridTextValue(item, "ltrSumVND", Func.FormatDecimal(SumVND));
                    Func.SetGridTextValue(item, "ltrSumUSD", Func.FormatDecimal(SumUSD));
                    Func.SetGridTextValue(item, "ltrVAT", Func.ParseString(VAT));

                    Func.SetGridTextValue(item, "ltrComment", Func.ToolTipByteLen(Comment, 20));

                    string ModifiedBy = Func.ParseString(row["ModifiedBy"].ToString().Trim());
                    string Modified = Func.ParseString(row["Modified"].ToString().Trim());
                    Func.SetGridTextValue(item, "ltrModifiedBy", ModifiedBy);
                    Func.SetGridTextValue(item, "ltrModified", Func.Formatdmyhms(Modified));

                    Button btnDelete = (Button)item.FindControl("btnDelete");
                    btnDelete.CommandArgument = ID;

                    Button btnUpdate = (Button)item.FindControl("btnUpdate");
                    btnUpdate.CommandArgument = ID;
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
            else if (command.Equals("Update"))
            {
                Response.Redirect("CustomerServiceEdit.aspx?id=" + Func.ParseString(e.CommandArgument));
            }
            ShowData();
        }
    }
}
