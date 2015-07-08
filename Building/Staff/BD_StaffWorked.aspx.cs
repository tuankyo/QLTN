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

namespace Man.Building.Staff
{
    public partial class BD_StaffWorked : PageBase
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

        private string popup = "PopupBD_StaffEdit";
        private string editPageName = "BD_StaffEdit";

        private string editStaffEvalInfo = "BD_StaffEvalInfoEdit";
        private string editWorkingExtraTimeInfo = "BD_WorkingExtraTimeInfoEdit";
        private string updateSuccess = "Cập nhật thành công";
        private string updateUnSuccess = "Cập nhật không thành công";
        private string deleteSuccess = "Xóa thành công";
        private string deleteUnSuccess = "Xóa không thành công";


        private void Delete(string id)
        {
            BD_WorkingWorkedInfoData data = new BD_WorkingWorkedInfoData();
            ITransaction tran = factory.GetLoadObject(data, Func.ParseString(id));
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_WorkingWorkedInfoData)tran.Result;
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
            BD_WorkingWorkedInfoData data = new BD_WorkingWorkedInfoData();
            ITransaction tran = factory.GetLoadObject(data, Func.ParseString(id));
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_WorkingWorkedInfoData)tran.Result;
                data.WorkingPlaceId = workingPlaceID;
                data.JobContent = JobContent;
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
            string sqlWhere = String.IsNullOrEmpty(txtWorkingDate.Text) ? "" : ("and A.WorkingDate = '" + Func.FormatYYYYmmdd(txtWorkingDate.Text.Trim().Substring(0, 10)) + "'");
            sqlWhere += String.IsNullOrEmpty(drpStaff.SelectedValue) ? "" : ("and A.StaffId = '" + drpStaff.SelectedValue + "'");

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
                sql += " FROM BD_WorkingWorkedInfo A";
                sql += " WHERE (Id IS NOT NULL) and DelFlag = 0 and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and JobTypeId = '" + hidJobType.Value + "'";
                sql += sqlWhere;
                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " Select A.*, B.Name StaffName, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM BD_WorkingWorkedInfo A, BD_Staff B";
                sql += " WHERE A.StaffID IS NOT NULL and A.DelFlag = 0 and A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.StaffId = B.ID and A.JobTypeId = '" + hidJobType.Value + "' and B.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";
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

            hidJobType.Value = Func.ParseString(Request["JobType"]);
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
                hidJobType.Value = Func.ParseString(Request["JobType"]);

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
                //    lblName.Text = data.Name;
                //    lblComment.Text = data.Comment;
                //    lblBuildingId.Text = data.BuildingId;
                //    lblName.Text = data.Name;
                //    lblInvestor.Text = data.Investor;
                //    lblAddress.Text = data.Address;
                //    lblPhone.Text = data.Phone;
                //    lblOwner.Text = data.Owner;
                //    lblManagerCompany.Text = data.ManagerCompany;
                //    lblManagerCompanyAgent.Text = data.ManagerCompanyAgent;
                //    lblManagerCompanyPhone.Text = data.ManagerCompanyPhone;
                //}

                switch (hidJobType.Value)
                {
                    case "1":
                        ltrPage.Text = "Quản lý hoạt động > Làm việc thực tế Nhân viên bảo vệ";
                        break;
                    case "2":
                        ltrPage.Text = "Quản lý hoạt động > Làm việc thực tế Nhân viên vệ sinh";
                        break;
                    case "3":
                        ltrPage.Text = "Quản lý hoạt động > Làm việc thực tế Nhân viên kỹ thuật";
                        break;
                    case "4":
                        ltrPage.Text = "Quản lý hoạt động > Làm việc thực tế Nhân viên BQL";
                        break;
                    case "5":
                        ltrPage.Text = "Quản lý hoạt động > Làm việc thực tế Nhân viên an ninh";
                        break;
                    case "6":
                        ltrPage.Text = "Quản lý hoạt động > Làm việc thực tế Nhân viên lẽ tân";
                        break;

                    default:
                        break;
                }

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
                DbHelper.FillListSearch(drpStaff, "Select Name, Id from BD_Staff Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and JobTypeId = '" + hidJobType.Value + "' and delFlag = 0 order by Name", "Name", "ID");
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
            else if (command.Equals("Update"))
            {
                DropDownList drpWorkingPlace = (DropDownList)e.Item.FindControl("drpWorkingPlace");
                TextBox JobContent = (TextBox)e.Item.FindControl("txtJobContent");
                TextBox Comment = (TextBox)e.Item.FindControl("txtComment");
                UpdateWorkingPlace(Func.ParseString(e.CommandArgument), drpWorkingPlace.SelectedValue, JobContent.Text, Comment.Text);
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
                    string StaffName = Func.ParseString(row["StaffName"]);
                    string StaffId = Func.ParseString(row["StaffId"]);
                    string Comment = Func.ParseString(row["Comment"]);

                    string WorkingPlaceId = Func.ParseString(row["WorkingPlaceId"]);
                    string WorkingHourId = Func.ParseString(row["WorkingHourId"]);
                    string WorkingDate = Func.ParseString(row["WorkingDate"]);
                    string JobContent = Func.ParseString(row["JobContent"]);

                    Func.SetGridLinkValue(item, "btnView", StaffId);
                    Func.SetGridTextValue(item, "ltrName", StaffName);
                    Func.SetGridTextValue(item, "ltrWorkingDate", Func.Formatdmyhms(WorkingDate));
                    Func.SetGridTextboxValue(item, "txtComment", Comment);
                    Func.SetGridTextboxValue(item, "txtJobContent", JobContent);
                    Func.SetGridTextValue(item, "ltrWorkingHour", WorkingHourId);


                    PopupWidth = 600;
                    PopupHeight = 500;
                    LinkPopup((LinkButton)item.FindControl("btnView"), editPageName + ".aspx?Action=Edit&Id=" + ID);

                    string ModifiedBy = Func.ParseString(row["ModifiedBy"].ToString().Trim());
                    string Modified = Func.ParseString(row["Modified"].ToString().Trim());
                    Func.SetGridTextValue(item, "ltrModifiedBy", ModifiedBy);
                    Func.SetGridTextValue(item, "ltrModified", Func.Formatdmyhms(Modified));

                    //string sqlWorkingHour = " SELECT distinct WorkingHourId, WorkingHourId ID";
                    //sqlWorkingHour += " FROM BD_WorkingHour";
                    //sqlWorkingHour += " WHERE DelFlag <> '1' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";

                    string sqlWorkingPlace = " SELECT distinct WorkingPlaceId + ':' + Name WorkingPlace, WorkingPlaceId ID";
                    sqlWorkingPlace += " FROM BD_WorkingPlace";
                    sqlWorkingPlace += " WHERE DelFlag = 0 and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and JobTypeId = '" + hidJobType.Value + "'";

                    //DropDownList drpWorkingHour = (DropDownList)item.FindControl("drpWorkingHour");
                    DropDownList drpWorkingPlace = (DropDownList)item.FindControl("drpWorkingPlace");

                    //DbHelper.FillListSearch(drpWorkingHour, sqlWorkingHour, "WorkingHourId", "ID");
                    DbHelper.FillListSearch(drpWorkingPlace, sqlWorkingPlace, "WorkingPlace", "ID");

                    //drpWorkingHour.SelectedValue = WorkingHourId;
                    drpWorkingPlace.SelectedValue = WorkingPlaceId;

                    Button btnUpdate = (Button)item.FindControl("btnUpdate");
                    btnUpdate.CommandArgument = ID;

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
        protected void btnExport_Click(object sender, EventArgs e)
        {
            string job = "";
            switch (hidJobType.Value)
            {
                case "1":
                    job = "BV";
                    break;
                case "2":
                    job = "VS";
                    break;
                case "3":
                    job = "KT";
                    break;
                case "4":
                    job = "QL";
                    break;

                default:
                    break;
            }
            string buildingId = Func.ParseString(Session["__BUILDINGID__"]);

            Hashtable staffIdRow = new Hashtable();
            string[] dateOfWeekVN = { "T2", "T3", "T4", "T5", "T6", "T7", "CN" };
            string[] dateOfWeekEN = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Sartuday", "Sunday" };

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("monday", "T2");
            dictionary.Add("tuesday", "T3");
            dictionary.Add("wednesday", "T4");
            dictionary.Add("thursday", "T5");
            dictionary.Add("friday", "T6");
            dictionary.Add("saturday", "T7");
            dictionary.Add("sunday", "CN");


            DataSet ds = new DataSet();
            string sql = string.Empty;

            sql = " SELECT *";
            sql += " FROM BD_WorkingWorkedInfo";
            sql += " WHERE BuildingId = '" + buildingId + "' and DelFlag = 0 and jobtypeid = '" + hidJobType.Value + "'";
            sql += " and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";

            Hashtable scheduleLst = new Hashtable();

            using (SqlDatabase db = new SqlDatabase())
            {
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    db.Close();

                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            string StaffId = rowType["StaffId"].ToString();
                            string WorkingHourId = rowType["WorkingHourId"].ToString();
                            string WorkingDate = rowType["WorkingDate"].ToString().Substring(6, 2);
                            if (!String.IsNullOrEmpty(WorkingHourId) && scheduleLst.ContainsKey(StaffId + WorkingDate))
                            {
                                scheduleLst.Add(StaffId + WorkingDate, WorkingHourId);
                            }
                        }
                    }
                }
            }

            ds = new DataSet();
            sql = " SELECT *";
            sql += " FROM BD_Staff";
            sql += " WHERE BuildingId = '" + buildingId + "' and DelFlag = 0 and jobtypeid = '" + hidJobType.Value + "' and SUBSTRING(JobBegin,0,7) <= '" + drpYear.SelectedValue + drpMonth.SelectedValue + "' and (JobEnd = '' or JobEnd is Null or SUBSTRING(JobEnd,0,7) >= '" + drpYear.SelectedValue + drpMonth.SelectedValue + "')";
            sql += " Order By Name";

            using (SqlDatabase db = new SqlDatabase())
            {
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    db.Close();

                    if (ds != null)
                    {
                        mvMessage.SetCompleteMessage("File CSV đã xuất thành công.");

                        C1XLBook xlbBook = new C1XLBook();

                        string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\LichLamViec.xls");
                        if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + buildingId));
                        }

                        string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
                        string strFilePath = @"~\Report\Building\" + buildingId + @"\" + buildingId + "_LichLamViec_" + job + "_" + strDT + "export.xls";
                        string strFilePathExport = @"../../Report/Building/" + buildingId + @"/" + buildingId + "_LichLamViec_" + job + "_" + strDT + "export.xls";

                        string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

                        File.Copy(fileName, fileNameDes);

                        xlbBook.Load(fileNameDes);

                        string sheet = "LichLamViec";

                        XLSheet xlsSheet = xlbBook.Sheets[sheet];

                        int i = 0;
                        XLCellRange mrCell = new XLCellRange(0, 0, 1, 2);
                        xlsSheet.MergedCells.Add(mrCell);

                        XLStyle xlstStyle = new XLStyle(xlbBook);
                        xlstStyle.AlignHorz = XLAlignHorzEnum.Center;
                        xlstStyle.Font = new Font("", 12, FontStyle.Bold);
                        xlstStyle.SetBorderColor(Color.Black);
                        xlstStyle.BorderBottom = XLLineStyleEnum.Thin;
                        xlstStyle.BorderTop = XLLineStyleEnum.Thin;
                        xlstStyle.BorderLeft = XLLineStyleEnum.Thin;
                        xlstStyle.BorderRight = XLLineStyleEnum.Thin;

                        xlsSheet[i, 1].Value = "Tháng " + drpMonth.SelectedValue + "/" + drpYear.SelectedValue;
                        xlsSheet[i, 1].Style = xlstStyle;

                        xlsSheet[i + 1, 1].Value = "STT";
                        //xlsSheet[i + 1, 1].Value = "Mã Nhân Viên";
                        xlsSheet[i + 1, 2].Value = "Họ và Tên";

                        XLStyle xlstStyle01 = new XLStyle(xlbBook);
                        xlstStyle01.AlignHorz = XLAlignHorzEnum.Left;
                        xlstStyle01.Font = new Font("", 10, FontStyle.Bold);
                        xlstStyle01.SetBorderColor(Color.Black);
                        xlstStyle01.BorderBottom = XLLineStyleEnum.Thin;
                        xlstStyle01.BorderTop = XLLineStyleEnum.Thin;
                        xlstStyle01.BorderLeft = XLLineStyleEnum.Thin;
                        xlstStyle01.BorderRight = XLLineStyleEnum.Thin;

                        for (int j = 1; j <= 31; j++)
                        {
                            xlsSheet[i, 2 + j].Value = j;
                            DateTime date = new DateTime(Func.ParseInt(drpYear.SelectedValue), Func.ParseInt(drpMonth.SelectedValue), j);
                            xlsSheet[i + 1, 2 + j].Value = dictionary[date.DayOfWeek.ToString().ToLower()];

                            xlsSheet[i, 2 + j].Style = xlstStyle01;
                            xlsSheet[i + 1, 2 + j].Style = xlstStyle01;
                            if (j == DateTime.DaysInMonth(Func.ParseInt(drpYear.SelectedValue), Func.ParseInt(drpMonth.SelectedValue)))
                            {
                                break;
                            }
                        }

                        i++;
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            int No = i;
                            i++;
                            string StaffId = rowType["ID"].ToString();
                            string Name = rowType["Name"].ToString();

                            staffIdRow.Add(StaffId, i);

                            xlsSheet[i, 1].Value = No;
                            xlsSheet[i, 0].Value = StaffId;
                            xlsSheet[i, 2].Value = Name;

                            xlsSheet[i, 0].Style = xlstStyle01;
                            xlsSheet[i, 1].Style = xlstStyle01;
                            xlsSheet[i, 2].Style = xlstStyle01;

                            for (int j = 1; j <= 31; j++)
                            {
                                if (scheduleLst.ContainsKey(StaffId + "" + j.ToString().PadLeft(2, '0')))
                                {
                                    xlsSheet[i, 2 + j].Value = scheduleLst[StaffId + "" + j.ToString().PadLeft(2, '0')];
                                    xlsSheet[i, 2 + j].Style = xlstStyle01;
                                }
                                else
                                {
                                    xlsSheet[i, 2 + j].Style = xlstStyle01;
                                }
                                if (j == DateTime.DaysInMonth(Func.ParseInt(drpYear.SelectedValue), Func.ParseInt(drpMonth.SelectedValue)))
                                {
                                    break;
                                }
                            }
                        }

                        ds = new DataSet();
                        sql = string.Empty;

                        //sql = " SELECT *";
                        //sql += " FROM BD_WorkingWorkedInfo";
                        //sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and DelFlag <> 1 and jobtypeid = '" + hidJobType.Value + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";
                        //sql += " Order By StaffId";

                        //using (SqlCommand cm1 = db.CreateCommand(sql))
                        //{
                        //    SqlDataAdapter da1 = new SqlDataAdapter(cm1);
                        //    da1.Fill(ds);
                        //    db.Close();

                        //    if (ds != null)
                        //    {
                        //        xlsSheet[i++ + 1, 2].Value = "Ghi chú:";
                        //        DataTable dt1 = ds.Tables[0];
                        //        foreach (DataRow rowType in dt1.Rows)
                        //        {
                        //            i++;
                        //            string StaffId = rowType["StaffId"].ToString();
                        //            string WorkingHourId = rowType["WorkingHourId"].ToString();
                        //            string WorkingDate = rowType["WorkingDate"].ToString().Substring(6, 2);

                        //            int col = Func.ParseInt(WorkingDate) + 2;
                        //            int row = Func.ParseInt(staffIdRow[StaffId]);
                        //            xlsSheet[row, col].Value = WorkingHourId;
                        //        }
                        //    }
                        //}

                        DataSet ds1 = new DataSet();
                        sql = string.Empty;

                        sql = " SELECT *";
                        sql += " FROM BD_WorkingHour";
                        sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and DelFlag <> 1 and jobtypeid = '" + hidJobType.Value + "'";
                        sql += " Order By Name";

                        using (SqlCommand cm1 = db.CreateCommand(sql))
                        {
                            SqlDataAdapter da1 = new SqlDataAdapter(cm1);
                            da1.Fill(ds1);
                            db.Close();

                            if (ds != null)
                            {
                                xlsSheet[i++ + 1, 2].Value = "Ghi chú:";
                                DataTable dt1 = ds1.Tables[0];
                                foreach (DataRow rowType in dt1.Rows)
                                {
                                    i++;
                                    string Ma = rowType["WorkingHourId"].ToString();
                                    string Name = rowType["Name"].ToString();
                                    xlsSheet[i, 2].Value = Ma + ":" + Name;
                                }
                                xlsSheet[i + 1, 2].Value = "OFF:nghỉ";
                            }
                        }
                        xlbBook.Save(fileNameDes);
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);
                    }
                }
            }
        }
        protected void btnImport_Click(object sender, EventArgs e)
        {
            if (!(drpYear.SelectedValue + drpMonth.SelectedValue).Equals(DateTime.Now.AddMonths(-1).ToString("yyyyMM")))
            {
                //mvMessage.AddError("Chỉ lưu Phí khác cho " + DateTime.Now.AddMonths(-1).ToString("MM/yyyy"));
                //return;
            }

            //CsvReader csvRead = null;

            try
            {
                DbHelper.ExecuteNonQuery("Update [BD_WorkingWorkedInfo] Set DelFlag = 1 Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "' and JobTypeId = '" + hidJobType.Value + "'");
                if (File.Exists(Server.MapPath("./") + File1.PostedFile.FileName))
                {
                    File.Delete(Server.MapPath("./") + File1.PostedFile.FileName);
                }
                C1XLBook xlbBook = new C1XLBook();

                string buildingId = Func.ParseString(Session["__BUILDINGID__"]);
                string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
                string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Import\"+buildingId+"LichLamViec" + strDT + "import.xls");
                File1.PostedFile.SaveAs(fileName);

                if (!Directory.Exists(@"~\Report\Building\" + buildingId))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])));
                }

                //string strFilePath = @"~\Report\Building\" + buildingId + @"\" + buildingId + "LichLamViec" + strDT + ".xls";
                //string strFilePathExport = @"../../Report/Building/" + buildingId + @"/" + buildingId + "LichLamViec" + strDT + ".xls";
                xlbBook.Load(fileName);

                string sheet = "LichLamViec";

                XLSheet xlsSheet = xlbBook.Sheets[sheet];

                DataTable staffSchedule = new DataTable();
                staffSchedule.Columns.Add("BuildingId", Type.GetType("System.String"));
                staffSchedule.Columns.Add("StaffId", Type.GetType("System.String"));
                //staffSchedule.Columns.Add("WorkingPlaceId", Type.GetType("System.String"));
                staffSchedule.Columns.Add("WorkingHourId", Type.GetType("System.String"));
                staffSchedule.Columns.Add("JobTypeId", Type.GetType("System.String"));
                staffSchedule.Columns.Add("WorkingDate", Type.GetType("System.String"));
                staffSchedule.Columns.Add("YearMonth", Type.GetType("System.String"));
                //staffSchedule.Columns.Add("Comment", Type.GetType("System.String"));
                staffSchedule.Columns.Add("Created", Type.GetType("System.String"));
                staffSchedule.Columns.Add("CreatedBy", Type.GetType("System.String"));
                staffSchedule.Columns.Add("Modified", Type.GetType("System.String"));
                staffSchedule.Columns.Add("ModifiedBy", Type.GetType("System.String"));
                staffSchedule.Columns.Add("DelFlag", Type.GetType("System.String"));

                for (int i = 2; i < 200; i++)
                {
                    if (String.IsNullOrEmpty(Func.ParseString(xlsSheet[i, 0].Value)))
                    {
                        break;
                    }
                    string StaffId = Func.ParseString(xlsSheet[i, 0].Value);
                    for (int j = 3; j < 34; j++)
                    {
                        if (String.IsNullOrEmpty(Func.ParseString(xlsSheet[0, j].Value)))
                        {
                            break;
                        }
                        string WorkingDate = drpYear.SelectedValue + drpMonth.SelectedValue + (j - 2).ToString().PadLeft(2, '0');
                        string WorkingHourId = Func.ParseString(xlsSheet[i, j].Value);
                        if (WorkingHourId.ToLower().Equals("off"))
                        {
                            WorkingHourId = "OFF";
                        }
                        DataRow newRow = staffSchedule.NewRow();
                        newRow["BuildingId"] = Func.ParseString(Session["__BUILDINGID__"]);
                        newRow["StaffId"] = StaffId;
                        newRow["WorkingHourId"] = WorkingHourId;
                        newRow["WorkingDate"] = WorkingDate;
                        newRow["JobTypeId"] = hidJobType.Value;
                        newRow["YearMonth"] = drpYear.SelectedValue + drpMonth.SelectedValue;
                        newRow["Created"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                        newRow["CreatedBy"] = Page.User.Identity.Name;
                        newRow["Modified"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                        newRow["ModifiedBy"] = Page.User.Identity.Name;
                        newRow["DelFlag"] = "0";

                        staffSchedule.Rows.Add(newRow);
                    }
                }

                using (SqlBulkCopy copy = new SqlBulkCopy(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                {
                    copy.DestinationTableName = "dbo.BD_WorkingWorkedInfo";
                    copy.BatchSize = 3000;
                    copy.BulkCopyTimeout = 99999;

                    copy.ColumnMappings.Add(0, "BuildingId");
                    copy.ColumnMappings.Add(1, "StaffId");
                    copy.ColumnMappings.Add(2, "WorkingHourId");
                    copy.ColumnMappings.Add(3, "JobTypeId");
                    copy.ColumnMappings.Add(4, "WorkingDate");
                    copy.ColumnMappings.Add(5, "YearMonth");
                    copy.ColumnMappings.Add(6, "Created");
                    copy.ColumnMappings.Add(7, "CreatedBy");
                    copy.ColumnMappings.Add(8, "Modified");
                    copy.ColumnMappings.Add(9, "ModifiedBy");
                    copy.ColumnMappings.Add(10, "DelFlag");

                    copy.WriteToServer(staffSchedule);
                }
                string sql = "update ";
                sql += " BD_WorkingWorkedInfo ";
                sql += " Set ";
                sql += " WorkingPlaceId = B.WorkingPlaceId , ";
                sql += " JobContent = B.JobContent ";
                sql += " FROM  ";
                sql += " BD_WorkingWorkedInfo A, ";
                sql += " BD_Staff B ";
                sql += " Where A.StaffId = B.id and A.YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "' ";

                DbHelper.ExecuteNonQuery(sql);
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
