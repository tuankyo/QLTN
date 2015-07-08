using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Collections.Generic;

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
using C1.C1Excel;
using System.IO;
using System.Drawing;
using Gnt.Utils.FastCsv;

namespace Man.Building.Maintenance
{
    public partial class BD_Maintenance : PageBase
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

        private string popup = "PopupBD_MaintenanceEdit";
        private string editPageName = "BD_MaintenanceEdit";

        private string editStaffEvalInfo = "BD_MaintenanceEvalInfoEdit";
        private string editWorkingExtraTimeInfo = "BD_WorkingExtraTimeInfoEdit";
        private string updateSuccess = "Cập nhật thành công";
        private string updateUnSuccess = "Cập nhật không thành công";
        private string deleteSuccess = "Xóa thành công";
        private string deleteUnSuccess = "Xóa không thành công";


        private void Delete(string id)
        {
            BD_MaintenanceData data = new BD_MaintenanceData();
            ITransaction tran = factory.GetLoadObject(data, Func.ParseString(id));
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_MaintenanceData)tran.Result;
                data.DelFlag = "1";

                tran = factory.GetUpdateObject(data);

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, deleteSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(deleteSuccess);
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, deleteUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(deleteUnSuccess);
                }
                ShowData();
            }
        }
        private void UpdateWorkingPlace(string id, string workingPlaceID, string JobContent, string Comment)
        {
            BD_MaintenanceData data = new BD_MaintenanceData();
            ITransaction tran = factory.GetLoadObject(data, Func.ParseString(id));
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_MaintenanceData)tran.Result;
                data.Comment = Comment;

                tran = factory.GetUpdateObject(data);

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(updateSuccess);
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(updateUnSuccess);
                }
                ShowData();
            }
        }
        /// <summary>
        /// List data
        /// </summary>
        private void ShowData()
        {
            string sqlWhere = String.IsNullOrEmpty(txtExecDateFrom.Text) ? "" : (" and A.ExecDate >= '" + Func.FormatYYYYmmdd(txtExecDateFrom.Text.Trim().Substring(0, 10)) + "'");
            sqlWhere += String.IsNullOrEmpty(txtExecDateTo.Text) ? "" : (" and A.ExecDate <= '" + Func.FormatYYYYmmdd(txtExecDateTo.Text.Trim().Substring(0, 10)) + "'");
            sqlWhere += " and A.Year = '" + drpYear.SelectedValue + "'";
            sqlWhere += " and A.Month = '" + Func.ParseInt(drpMonth.SelectedValue) + "'";
            sqlWhere += String.IsNullOrEmpty(drpMainName.SelectedValue) ? "" : (" and A.MainName = N'" + drpMainName.SelectedValue + "'");
            sqlWhere += String.IsNullOrEmpty(drpSubName.SelectedValue) ? "" : (" and A.SubName = N'" + drpSubName.SelectedValue + "'");

            SqlDatabase db = new SqlDatabase();
            string sql = string.Empty;
            if (!Func.IsValid(ListSortExpression))
            {
                ListSortExpression = "A.Modified";
                ListSortDirection = SortDirection.Descending;
            }
            try
            {
                //Đếm số lượng record
                sql += " Select COUNT(*) ";
                sql += " FROM BD_Maintenance A";
                sql += " WHERE (Id IS NOT NULL) and DelFlag = 0 and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";
                sql += sqlWhere;
                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " Select *, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM BD_Maintenance A";
                sql += " WHERE DelFlag = 0 and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' ";
                sql += sqlWhere;

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
            if (!IsPostBack)
            {
                PopupWidth = 600;
                PopupHeight = 450;
                ShowData();

                for (int i = 2010; i < 2050; i++)
                {
                    drpYear.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i), Func.ParseString(i)));
                }
                drpYear.Items.FindByValue(DateTime.Now.AddMonths(-1).ToString("yyyy")).Selected = true;

                for (int i = 1; i < 13; i++)
                {
                    drpMonth.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
                }
                drpMonth.Items.FindByValue(DateTime.Now.AddMonths(-1).ToString("MM")).Selected = true;
                DbHelper.FillListSearch(drpMainName, "Select distinct MainName From BD_Maintenance Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and delFlag = 0 and Year = '" + drpYear.SelectedValue + "'", "MainName", "MainName");
                DbHelper.FillListSearch(drpSubName, "Select distinct SubName From BD_Maintenance Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and delFlag = 0 and Year = '" + drpYear.SelectedValue + "' and MainName = '" + drpMainName.SelectedValue + "'", "SubName", "SubName");
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
            else if (command.Equals("Delete"))
            {
                Delete(Func.ParseString(e.CommandArgument));
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
                    string Week = Func.ParseString(row["Week"]);
                    string IsMaintenance = Func.ParseString(row["IsMaintenance"]);
                    string MainName = Func.ParseString(row["MainName"]);
                    string SubName = Func.ParseString(row["SubName"]);

                    string ExecDate = Func.ParseString(row["ExecDate"]);
                    string ExecDescription = Func.ParseString(row["ExecDescription"]);
                    string ExecComment = Func.ParseString(row["ExecComment"]);
                    string ExecCompany = Func.ParseString(row["ExecCompany"]);
                    string ExecConfirmer = Func.ParseString(row["ExecConfirmer"]);

                    Func.SetGridTextValue(item, "ltrWeek", Week);
                    Func.SetGridTextValue(item, "ltrIsMaintenance", IsMaintenance);
                    Func.SetGridTextValue(item, "ltrMainName", MainName);
                    Func.SetGridTextValue(item, "ltrSubName", SubName);
                    Func.SetGridTextValue(item, "ltrExecDate", Func.Formatdmyhms(ExecDate));
                    Func.SetGridTextValue(item, "ltrExecComment", ExecComment);
                    Func.SetGridTextValue(item, "ltrExecCompany", ExecCompany);
                    Func.SetGridTextValue(item, "ltrExecConfirmer", ExecConfirmer);
                    Func.SetGridTextValue(item, "ltrExecDescription", ExecDescription);


                    PopupWidth = 600;
                    PopupHeight = 500;

                    string ModifiedBy = Func.ParseString(row["ModifiedBy"].ToString().Trim());
                    string Modified = Func.ParseString(row["Modified"].ToString().Trim());
                    Func.SetGridTextValue(item, "ltrModifiedBy", ModifiedBy);
                    Func.SetGridTextValue(item, "ltrModified", Func.Formatdmyhms(Modified));

                    ButtonPopup((Button)item.FindControl("btnUpdate"), "BD_MaintenanceEdit.aspx?Action=Edit&Id=" + ID);

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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnView_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void drpYM_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DbHelper.FillListSearch(drpMainName, "Select distinct MainName From BD_Maintenance Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and delFlag = 0 and Year = '" + drpYear.SelectedValue + "'", "MainName", "MainName");
            DbHelper.FillListSearch(drpSubName, "Select distinct SubName From BD_Maintenance Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and delFlag = 0 and Year = '" + drpYear.SelectedValue + "' and MainName = '" + drpMainName.SelectedValue + "'", "SubName", "SubName");
        }
        protected void drpMainName_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DbHelper.FillListSearch(drpSubName, "Select distinct SubName From BD_Maintenance Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and delFlag = 0 and Year = '" + drpYear.SelectedValue + "' and MainName = '" + drpMainName.SelectedValue + "'", "SubName", "SubName");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                DbHelper.ExecuteNonQuery("Update BD_Maintenance Set DelFlag = 1 Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and Year = '" + drpYear.SelectedValue + "'");
                if (File.Exists(Server.MapPath("./") + File1.PostedFile.FileName))
                {
                    File.Delete(Server.MapPath("./") + File1.PostedFile.FileName);
                }
                C1XLBook xlbBook = new C1XLBook();

                string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
                string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Import\BaoTri" + strDT + ".xls");
                File1.PostedFile.SaveAs(fileName);

                if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])));
                }

                string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BaoTri" + strDT + ".xls";
                string strFilePathExport = @"../../Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + @"/BaoTri" + strDT + ".xls";
                xlbBook.Load(fileName);

                string sheet = "BaoTri";

                XLSheet xlsSheet = xlbBook.Sheets[sheet];

                DataTable dtMain = new DataTable();
                dtMain.Columns.Add("BuildingId", Type.GetType("System.String"));
                dtMain.Columns.Add("Year", Type.GetType("System.String"));
                dtMain.Columns.Add("Month", Type.GetType("System.String"));
                dtMain.Columns.Add("MainName", Type.GetType("System.String"));
                dtMain.Columns.Add("SubName", Type.GetType("System.String"));
                dtMain.Columns.Add("Week", Type.GetType("System.String"));
                dtMain.Columns.Add("IsMaintenance", Type.GetType("System.String"));
                dtMain.Columns.Add("Created", Type.GetType("System.String"));
                dtMain.Columns.Add("CreatedBy", Type.GetType("System.String"));
                dtMain.Columns.Add("Modified", Type.GetType("System.String"));
                dtMain.Columns.Add("ModifiedBy", Type.GetType("System.String"));
                dtMain.Columns.Add("DelFlag", Type.GetType("System.String"));

                string MainName = "";
                for (int i = 5; i < 200; i++)
                {
                    string MN = Func.ParseString(xlsSheet[i, 1].Value);
                    if (MN == "END")
                        break;

                    if (!MainName.Equals(MN) && !String.IsNullOrEmpty(MN))
                    {
                        MainName = MN;
                    }
                    string SN = Func.ParseString(xlsSheet[i, 2].Value);


                    for (int j = 4; j <= 51; j++)
                    {
                        DataRow newRow = dtMain.NewRow();
                        newRow["BuildingId"] = Func.ParseString(Session["__BUILDINGID__"]);
                        newRow["Year"] = drpYear.SelectedValue;
                        newRow["Month"] = (j / 4).ToString().PadLeft(2, '0');
                        newRow["MainName"] = MainName;
                        newRow["SubName"] = SN;
                        newRow["Week"] = j % 4;

                        if ("X".Equals(Func.ParseString(xlsSheet[i, j].Value).ToUpper()))
                        {
                            newRow["IsMaintenance"] = "X";
                        }
                        newRow["Created"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                        newRow["CreatedBy"] = Page.User.Identity.Name;
                        newRow["Modified"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                        newRow["ModifiedBy"] = Page.User.Identity.Name;
                        newRow["DelFlag"] = "0";
                        dtMain.Rows.Add(newRow);
                    }
                }

                using (SqlBulkCopy copy = new SqlBulkCopy(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                {
                    copy.DestinationTableName = "BD_Maintenance";
                    copy.BatchSize = 3000;
                    copy.BulkCopyTimeout = 99999;

                    copy.ColumnMappings.Add(0, "BuildingId");
                    copy.ColumnMappings.Add(1, "Year");
                    copy.ColumnMappings.Add(2, "Month");
                    copy.ColumnMappings.Add(3, "MainName");
                    copy.ColumnMappings.Add(4, "SubName");
                    copy.ColumnMappings.Add(5, "Week");
                    copy.ColumnMappings.Add(6, "IsMaintenance");
                    copy.ColumnMappings.Add(7, "Created");
                    copy.ColumnMappings.Add(8, "CreatedBy");
                    copy.ColumnMappings.Add(9, "Modified");
                    copy.ColumnMappings.Add(10, "ModifiedBy");
                    copy.ColumnMappings.Add(11, "DelFlag");

                    copy.WriteToServer(dtMain);
                }
                DbHelper.FillListSearch(drpMainName, "Select distinct MainName From BD_Maintenance Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and delFlag = 0 and Year = '" + drpYear.SelectedValue + "'", "MainName", "MainName");
                DbHelper.FillListSearch(drpSubName, "Select distinct SubName From BD_Maintenance Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and delFlag = 0 and Year = '" + drpYear.SelectedValue + "' and MainName = '" + drpMainName.SelectedValue + "'", "SubName", "SubName");

                ShowData();
            }
            catch (Exception ex)
            {
                mvMessage.AddError("Lỗi phát sinh: " + ex.Message);
            }
            finally
            {
            }
        }
    }
}
