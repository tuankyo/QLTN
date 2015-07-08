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
    public partial class BD_StaffSchedule : PageBase
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
            BD_WorkingSheduleInfoData data = new BD_WorkingSheduleInfoData();
            ITransaction tran = factory.GetLoadObject(data, Func.ParseString(id));
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_WorkingSheduleInfoData)tran.Result;
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
        private void UpdateWorkingPlace(string id, string workingPlaceID)
        {
            BD_WorkingSheduleInfoData data = new BD_WorkingSheduleInfoData();
            ITransaction tran = factory.GetLoadObject(data, Func.ParseString(id));
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_WorkingSheduleInfoData)tran.Result;
                data.WorkingPlaceId = workingPlaceID;

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
                sql += " FROM BD_WorkingSheduleInfo A";
                sql += " WHERE (Id IS NOT NULL) and DelFlag <> 1 and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and JobTypeId = '" + hidJobType.Value + "'";
                sql += sqlWhere;
                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " Select A.*, B.Name StaffName, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM BD_WorkingSheduleInfo A, BD_Staff B";
                sql += " WHERE A.StaffID IS NOT NULL and A.DelFlag <> 1 and A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.StaffId = B.StaffId and A.JobTypeId = '" + hidJobType.Value + "' and B.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";
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
                        ltrPage.Text = "Quản lý hoạt động > Lịch làm việc Nhân viên bảo vệ";
                        break;
                    case "2":
                        ltrPage.Text = "Quản lý hoạt động > Lịch làm việc Nhân viên vệ sinh";
                        break;
                    case "3":
                        ltrPage.Text = "Quản lý hoạt động > Lịch làm việc Nhân viên kỹ thuật";
                        break;
                    case "4":
                        ltrPage.Text = "Quản lý hoạt động > Lịch làm việc Nhân viên BQL";
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
                DbHelper.FillListSearch(drpStaff, "Select (StaffId + ':' + Name) as Name, StaffId from BD_Staff Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and JobTypeId = '" + hidJobType.Value + "'", "Name", "StaffId");
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
                UpdateWorkingPlace(Func.ParseString(e.CommandArgument), drpWorkingPlace.SelectedValue);
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

                    Func.SetGridLinkValue(item, "btnView", StaffId);
                    Func.SetGridTextValue(item, "ltrName", StaffName);
                    Func.SetGridTextValue(item, "ltrWorkingDate", Func.Formatdmyhms(WorkingDate));
                    Func.SetGridTextValue(item, "ltrComment", Func.ToolTipByteLen(Comment, 20));
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

                    string sqlWorkingPlace = " SELECT distinct WorkingPlaceId, WorkingPlaceId ID";
                    sqlWorkingPlace += " FROM BD_WorkingPlace";
                    sqlWorkingPlace += " WHERE DelFlag <> '1' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";

                    //DropDownList drpWorkingHour = (DropDownList)item.FindControl("drpWorkingHour");
                    DropDownList drpWorkingPlace = (DropDownList)item.FindControl("drpWorkingPlace");

                    //DbHelper.FillListSearch(drpWorkingHour, sqlWorkingHour, "WorkingHourId", "ID");
                    DbHelper.FillListSearch(drpWorkingPlace, sqlWorkingPlace, "WorkingPlaceId", "ID");

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
            sql += " FROM BD_Staff";
            sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and DelFlag <> 1 and jobtypeid = '"+ hidJobType.Value +"'";
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
                        XLSheet xlsSheet = xlbBook.Sheets[0];
                        xlsSheet.Name = drpMonth.SelectedValue + "_" + drpYear.SelectedValue;

                        int i = 0;
                        XLCellRange mrCell = new XLCellRange(0, 0, 0, 2);
                        xlsSheet.MergedCells.Add(mrCell);

                        XLStyle xlstStyle = new XLStyle(xlbBook);
                        xlstStyle.AlignHorz = XLAlignHorzEnum.Center;
                        xlstStyle.Font = new Font("", 12, FontStyle.Bold);
                        xlstStyle.SetBorderColor(Color.Black);

                        xlsSheet[i, 0].Value = "Tháng " + drpMonth.SelectedValue + "/" + drpYear.SelectedValue;
                        xlsSheet[i, 0].Style = xlstStyle;

                        xlsSheet[i + 1, 0].Value = "STT";
                        xlsSheet[i + 1, 1].Value = "Mã Nhân Viên";
                        xlsSheet[i + 1, 2].Value = "Họ và Tên";

                        XLStyle xlstStyle01 = new XLStyle(xlbBook);
                        xlstStyle01.AlignHorz = XLAlignHorzEnum.Center;
                        xlstStyle01.Font = new Font("", 10, FontStyle.Bold);
                        xlstStyle.SetBorderColor(Color.Black);

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
                            string StaffId = rowType["StaffId"].ToString();
                            string Name = rowType["Name"].ToString();

                            xlsSheet[i, 0].Value = No;
                            xlsSheet[i, 1].Value = StaffId;
                            xlsSheet[i, 2].Value = Name;

                            xlsSheet[i, 0].Style = xlstStyle01;
                            xlsSheet[i, 1].Style = xlstStyle01;
                            xlsSheet[i, 2].Style = xlstStyle01;

                        }

                        //ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('/CSV/DownloadZipFile.aspx'," + PopupWidth + "," + PopupHeight + ",'EditFlat', true);", true);

                        //xlsSheet[i++, 0].Value = "Ghi chú:";
                        DataSet ds1 = new DataSet();
                        sql = string.Empty;

                        sql = " SELECT *";
                        sql += " FROM BD_WorkingHour";
                        sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and DelFlag <> 1 and jobtypeid = '"+ hidJobType.Value +"'";
                        sql += " Order By Name";

                        using (SqlCommand cm1 = db.CreateCommand(sql))
                        {
                            SqlDataAdapter da1 = new SqlDataAdapter(cm1);
                            da1.Fill(ds1);
                            db.Close();

                            if (ds != null)
                            {

                                xlsSheet[i++ + 1, 0].Value = "Ghi chú:";
                                DataTable dt1 = ds1.Tables[0];
                                foreach (DataRow rowType in dt1.Rows)
                                {
                                    i++;
                                    string Ma = rowType["WorkingHourId"].ToString();
                                    string Name = rowType["Name"].ToString();
                                    xlsSheet[i, 0].Value = Ma + ":";
                                    xlsSheet[i, 1].Value = Name;
                                }
                                xlsSheet[i + 1, 0].Value = "OF:";
                                xlsSheet[i + 1, 1].Value = "OF: nghỉ";
                            }
                        }
                        string dataPath = HttpContext.Current.Server.MapPath(@"\Building\Staff\DataTmp");
                        string tmpFolder = dataPath;
                        if (!Directory.Exists(tmpFolder))
                        {
                            Directory.CreateDirectory(tmpFolder);
                        }
                        string name ="KhaiBaoLichLamViec_"+ DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                        string fileName = Path.Combine(tmpFolder, name);
                        xlbBook.Save(fileName);
                        //Session["ZipFilePath"] = null;
                        //Session["ZipFilePath"] = fileName;

                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('../Staff/DataTmp/" + name + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);

                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnImport_Click(object sender, EventArgs e)
        {
            if (!(drpYear.SelectedValue + drpMonth.SelectedValue).Equals(DateTime.Now.AddMonths(-1).ToString("yyyyMM")))
            {
                //mvMessage.AddError("Chỉ lưu Phí khác cho " + DateTime.Now.AddMonths(-1).ToString("MM/yyyy"));
                //return;
            }

            CsvReader csvRead = null;

            try
            {
                string[] array = File1.PostedFile.FileName.Split('.');
                string ext = string.Empty;
                if (array.Length > 0)
                {
                    ext = array[array.Length - 1];
                }
                if (ext.Length == 0) return;

                ext = ext.ToUpper();

                if (!"csv".Equals(ext.ToLower()))
                {
                    mvMessage.AddError("Hãy chọn file CSV.");
                    return;
                }
                if (File.Exists(Server.MapPath("./") + File1.PostedFile.FileName))
                {
                    File.Delete(Server.MapPath("./") + File1.PostedFile.FileName);
                }
                File1.PostedFile.SaveAs(Server.MapPath("./") + File1.PostedFile.FileName);

                csvRead = new CsvReader(Server.MapPath("./") + File1.PostedFile.FileName, true, ',');
                csvRead.IsCheckQuote = true;

                DataTable dt = new DataTable();
                dt.Load(csvRead);

                DataTable staffSchedule = new DataTable();
                staffSchedule.Columns.Add("BuildingId", Type.GetType("System.String"));
                staffSchedule.Columns.Add("StaffId", Type.GetType("System.String"));
                staffSchedule.Columns.Add("WorkingPlaceId", Type.GetType("System.String"));
                staffSchedule.Columns.Add("WorkingHourId", Type.GetType("System.String"));
                staffSchedule.Columns.Add("JobTypeId", Type.GetType("System.String"));
                staffSchedule.Columns.Add("WorkingDate", Type.GetType("System.String"));
                staffSchedule.Columns.Add("MonthYear", Type.GetType("System.String"));
                staffSchedule.Columns.Add("Comment", Type.GetType("System.String"));
                staffSchedule.Columns.Add("Created", Type.GetType("System.String"));
                staffSchedule.Columns.Add("CreatedBy", Type.GetType("System.String"));
                staffSchedule.Columns.Add("Modified", Type.GetType("System.String"));
                staffSchedule.Columns.Add("ModifiedBy", Type.GetType("System.String"));
                staffSchedule.Columns.Add("DelFlag", Type.GetType("System.String"));

                if (dt.Rows.Count > 0)
                {

                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        string staffId = Func.ParseString(dt.Rows[i][1]);
                        string[] dayOfMonth = new string[31];
                        for (int j = 0; j < 31; j++)
                        {
                            dayOfMonth[j] = Func.ParseString(dt.Rows[i][j + 3]);

                            if (!String.IsNullOrEmpty(staffId) && !String.IsNullOrEmpty(dayOfMonth[j]))
                            {
                                DataRow newRow = staffSchedule.NewRow();
                                newRow["BuildingId"] = Func.ParseString(Session["__BUILDINGID__"]);
                                newRow["StaffId"] = staffId;
                                newRow["WorkingPlaceId"] = "";
                                newRow["WorkingHourId"] = dayOfMonth[j];
                                newRow["JobTypeId"] = hidJobType.Value;
                                newRow["WorkingDate"] = "" + drpYear.SelectedValue + drpMonth.SelectedValue + Func.ParseString((j + 1)).PadLeft(2, '0');
                                newRow["MonthYear"] = drpYear.SelectedValue + drpMonth.SelectedValue;
                                newRow["Comment"] = "";
                                newRow["Created"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                                newRow["CreatedBy"] = Page.User.Identity.Name;
                                newRow["Modified"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                                newRow["ModifiedBy"] = Page.User.Identity.Name;
                                newRow["DelFlag"] = "0";

                                staffSchedule.Rows.Add(newRow);
                            }
                        }
                        Console.Write("");
                    }
                }
                using (SqlBulkCopy copy = new SqlBulkCopy(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                {
                    copy.DestinationTableName = "dbo.BD_WorkingSheduleInfo";
                    copy.BatchSize = 3000;
                    copy.BulkCopyTimeout = 99999;

                    copy.ColumnMappings.Add(0, "BuildingId");
                    copy.ColumnMappings.Add(1, "StaffId");
                    copy.ColumnMappings.Add(2, "WorkingPlaceId");
                    copy.ColumnMappings.Add(3, "WorkingHourId");
                    copy.ColumnMappings.Add(4, "JobTypeId");
                    copy.ColumnMappings.Add(5, "WorkingDate");
                    copy.ColumnMappings.Add(6, "MonthYear");
                    copy.ColumnMappings.Add(7, "Comment");
                    copy.ColumnMappings.Add(8, "Created");
                    copy.ColumnMappings.Add(9, "CreatedBy");
                    copy.ColumnMappings.Add(10, "Modified");
                    copy.ColumnMappings.Add(11, "ModifiedBy");
                    copy.ColumnMappings.Add(12, "DelFlag");

                    copy.WriteToServer(staffSchedule);
                }
                //Response.Redirect("ListOtherFeeImport.aspx", false);
                ShowData();
            }
            catch (Exception ex)
            {
                mvMessage.AddError("Lỗi phát sinh: " + ex.Message);
            }
            finally
            {
                if (csvRead != null)
                {
                    csvRead.Dispose();
                }
            }
        }
    }
}
