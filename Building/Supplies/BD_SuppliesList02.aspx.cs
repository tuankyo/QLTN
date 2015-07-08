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

using Gnt.Data;
using Man.Utils;
using Gnt.Data.DBCommand;
using System.Data.SqlClient;
using BusinessObjects;
using Gnt.Transaction;
using System.Text;

namespace Man.Building.Supplies
{
    public partial class BD_SuppliesList02 : PageBase
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

        private string popup = "PopupBD_SuppliesEdit";
        private string editPageName = "BD_SuppliesEdit";
        private string editStatusPageName = "BD_SuppliesStatus";
        private string editImportPageName = "BD_SuppliesImport";
        private string editExportPageName = "BD_SuppliesExport";


        private string GetWhere()
        {
            string whereClause = string.Empty;

            if (txtID.Text.Trim().Length != 0)
            {
                whereClause += " AND CreatedId LIKE '%" + txtID.Text.Trim() + "%'";
            }
            if (txtName.Text.Trim().Length != 0)
            {
                whereClause += " AND Name LIKE N'%" + txtName.Text.Trim() + "%'";
            }

            if (txtDescription.Text.Trim().Length != 0)
            {
                whereClause += " AND Description LIKE N'%" + txtDescription.Text.Trim() + "%'";
            }
            if (txtProvider.Text.Trim().Length != 0)
            {
                whereClause += " AND ProductOf LIKE N'%" + txtProvider.Text.Trim() + "%'";
            }
            return whereClause;
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
                ListSortExpression = "isnull(B.Modified,A.Modified)";
                ListSortDirection = SortDirection.Descending;
            }
            try
            {
                //Đếm số lượng record
                sql += " Select COUNT(ID) ";
                sql += " FROM BD_Supplies";
                sql += " WHERE (Id IS NOT NULL) and DelFlag <> 1 and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and SuppliesType = '" + hidSuppliesType.Value + "'";
                sql += GetWhere();

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " Select id,CreatedId,BuildingId,JobType,SuppliesType,ItemId,Name,Description,ProductOf,Comment,Created,CreatedBy,isnull(B.Modified,A.Modified) as Modified,isnull(A.ModifiedBy,B.ModifiedBy) as ModifiedBy,DelFlag,Model,Label,Regional, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM BD_Supplies A left outer join (SELECT t.SuppliesId,Modified,ModifiedBy ";
                sql += " FROM ( SELECT SuppliesId , MAX(id) AS max_votes FROM BD_SuppliesExim GROUP BY SuppliesId) AS m ";
                sql += " INNER JOIN BD_SuppliesExim AS t ";
                sql += " ON t.SuppliesId = m.SuppliesId ";
                sql += " AND t.id = m.max_votes) B on A.id = B.SuppliesId";
                sql += " WHERE Id IS NOT NULL and DelFlag <> 1 and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and SuppliesType = '" + hidSuppliesType.Value + "'";
                sql += GetWhere();

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

        /// <summary>
        /// Init values
        /// </summary>
        protected override void DoInit()
        {
        }

        protected override void DoPost()
        {
            //Handle postback from popup
            string eventTarget = Func.ParseString(Request["__EVENTTARGET"]);
            string eventArgument = Func.ParseString(Request["__EVENTARGUMENT"]);
            if (eventTarget.StartsWith("Popup"))
            {
                if (eventTarget == popup)
                {
                    ShowData();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            hidSuppliesType.Value = Func.ParseString(Request["SuppliesType"]);
            switch (hidSuppliesType.Value)
            {
                case "1":
                    ltrPage.Text = "Quản lý hoạt động > Vật tư > Xuất nhập kho";
                    break;
                case "2":
                    ltrPage.Text = "Quản lý hoạt động > Thiết bị > Xuất nhập kho";
                    break;
                case "3":
                    ltrPage.Text = "Kế toán > Vật tư > Xuất nhập kho";
                    break;
                case "4":
                    ltrPage.Text = "Kế toán > Thiết bị > Xuất nhập kho";
                    break;
                case "5":
                    ltrPage.Text = "Kỹ thuật > Vật tư > Xuất nhập kho";
                    break;
                case "6":
                    ltrPage.Text = "Kỹ thuật > Thiết bị > Xuất nhập kho";
                    break;
            }
            if (!IsPostBack)
            {
                PopupWidth = 600;
                PopupHeight = 450;
                ShowData();

                //Mst_BuildingData data = new Mst_BuildingData();
                //ITransaction tran = factory.GetLoadObject(data, Func.ParseString(Session["__BUILDINGID__"]));
                //Execute(tran);
                //if (!HasError)
                //{
                //    //Get Data
                //    data = (Mst_BuildingData)tran.Result;
                //    //lblName.Text = data.Name;
                //    //lblComment.Text = data.Comment;
                //    //lblBuildingId.Text = data.BuildingId;
                //    //lblName.Text = data.Name;
                //    //lblInvestor.Text = data.Investor;
                //    //lblAddress.Text = data.Address;
                //    //lblPhone.Text = data.Phone;
                //    //lblOwner.Text = data.Owner;
                //    //lblManagerCompany.Text = data.ManagerCompany;
                //    //lblManagerCompanyAgent.Text = data.ManagerCompanyAgent;
                //    //lblManagerCompanyPhone.Text = data.ManagerCompanyPhone;
                //}
            }
        }

        /// </summary> Chọn trang
        /// <param name="source"></param>
        /// <param name="args"></param>
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
                    string ID = Func.ParseString(row["Id"]);
                    string CreatedId = Func.ParseString(row["CreatedId"]);
                    string Name = Func.ParseString(row["Name"]);
                    string Description = Func.ParseString(row["Description"]);
                    string ProductOf = Func.ParseString(row["ProductOf"]);
                    string Comment = Func.ParseString(row["Comment"]);


                    Func.SetGridTextValue(item, "ltrId", CreatedId);
                    Func.SetGridTextValue(item, "ltrDescription", Description);
                    Func.SetGridTextValue(item, "ltrProductOf", ProductOf);
                    Func.SetGridTextValue(item, "ltrName", Name);

                    Func.SetGridTextValue(item, "ltrComment", Func.ToolTipByteLen(Comment, 20));

                    PopupWidth = 600;
                    PopupHeight = 450;
                    //LinkPopup((LinkButton)item.FindControl("btnEdit"), editPageName + ".aspx?Action=Edit&Id=" + ID);
                    ButtonPopup((Button)item.FindControl("btnImport"), editImportPageName + ".aspx?Action=Edit&Id=" + ID);
                    ButtonPopup((Button)item.FindControl("btnExport"), editExportPageName + ".aspx?Action=Edit&Id=" + ID);
                    //ButtonPopup((Button)item.FindControl("btnStatus"), editStatusPageName + ".aspx?Action=Edit&Id=" + ID);
                    Func.SetGridTextValue(item, "ltrInventory", Func.FormatNumber(DbHelper.GetScalar("Select Sum(Mount*ProcessType) From BD_SuppliesExim Where SuppliesId = '" + ID + "' and DelFlag = '0'")));
                    string ModifiedBy = Func.ParseString(row["ModifiedBy"].ToString().Trim());
                    string Modified = Func.ParseString(row["Modified"].ToString().Trim());
                    Func.SetGridTextValue(item, "ltrModifiedBy", ModifiedBy);
                    Func.SetGridTextValue(item, "ltrModified", Func.Formatdmyhms(Modified));

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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PopupWidth = 600;
            PopupHeight = 450;
            ShowData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            PopupWidth = 600;
            PopupHeight = 600;
            mvMessage.CheckRequired(txtAutoId, "Hãy tạo ID trước khi Thêm mới, chọn nút Cấp Phát ID hoặc tự nhập vào ID (chiều dài 8 ký tự)");
            if (!mvMessage.IsValid)
            {
                return;
            }
            int count = DbHelper.GetCount("Select count(*) from BD_Supplies Where CreatedId = '" + txtAutoId.Text.Trim() + "'");
            if (count >= 1)
            {
                mvMessage.AddError("ID đã tồn tại, hãy cấp phát lại");
                return;
            }
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + editPageName + ".aspx?Action=Register&ID=" + txtAutoId.Text.Trim() + "&SuppliesType=" + hidSuppliesType.Value + "'," + PopupWidth + "," + PopupHeight + ",'" + editPageName + "', true);", true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAutoId_Click(object sender, EventArgs e)
        {
            BD_SuppliesData data = new BD_SuppliesData();

            string prefix = Func.ParseString(Session["__BUILDINGID__"]) + DbHelper.GetScalar("Select Comment From Mst_SuppliesType Where id = '" + hidSuppliesType.Value + "'");
            if (String.IsNullOrEmpty(prefix))
            {
                mvMessage.AddError("Lỗi xảy ra, hãy bấm F5 hoặc liên hệ Admin");
                return;
            }

            int length = 10;
            string tmp = String.Format("", length);

            string sql = "SELECT max(maxid) from (SELECT SUBSTRING(CreatedId, " + (prefix.Length + 1) + ", " + length + ") as maxid FROM BD_Supplies) as tmp WHERE maxid < '100'";


            int key = 0;
            try
            {
                key = Convert.ToInt32(DbHelper.GetScalar(sql));
                key++;
            }
            catch
            {
                key = 1;
            }

            bool keyFlg = true;
            while (keyFlg)
            {
                string tmpKey = prefix + key.ToString().PadLeft(length - prefix.Length, '0');
                sql = "SELECT count(*) from BD_Supplies WHERE CreatedId = '" + tmpKey + "'";
                if (Convert.ToInt32(DbHelper.GetScalar(sql)) != 1)
                {
                    keyFlg = false;
                }
                else
                {
                    key--;
                }
            }
            txtAutoId.Text = prefix + key.ToString().PadLeft(length - prefix.Length, '0');
        }
    }
}
