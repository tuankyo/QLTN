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
using C1.C1Excel;
using System.IO;
using System.Drawing;

namespace Man.Building.Supplies
{
    public partial class BD_SuppliesGroupList : PageBase
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

        /// <summary>
        /// List data
        /// </summary>
        private void ShowData()
        {
            SqlDatabase db = new SqlDatabase();
            string sql = string.Empty;
            if (!Func.IsValid(ListSortExpression))
            {
                ListSortExpression = "GroupName";
                ListSortDirection = SortDirection.Descending;
            }
            try
            {
                //Đếm số lượng record
                sql += " Select COUNT(ID) ";
                sql += " FROM BD_SuppliesGroup";
                sql += " WHERE (Id IS NOT NULL) and SuppliesType = '" + hidSuppliesType.Value + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " Select *, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM BD_SuppliesGroup";
                sql += " WHERE (Id IS NOT NULL) and SuppliesType = '" + hidSuppliesType.Value + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";

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

            //switch (hidSuppliesType.Value)
            //{
            //    case "1":
            //        ltrPage.Text = "Quản lý hoạt động > Quản lý vật tư – Thiết bị VP > Danh sách";
            //        break;
            //    case "2":
            //        ltrPage.Text = "Quản lý hoạt động > Thiết bị > Danh sách";
            //        break;
            //    case "3":
            //        ltrPage.Text = "Kế toán > Vật tư > Danh sách";
            //        break;
            //    case "4":
            //        ltrPage.Text = "Kế toán > Thiết bị > Danh sách";
            //        break;
            //    case "5":
            //        ltrPage.Text = "Kỹ thuật > Vật tư > Danh sách";
            //        break;
            //    case "6":
            //        ltrPage.Text = "Kỹ thuật > Thiết bị > Danh sách";
            //        break;
            //}
            //if ("1".Equals(hidSuppliesType.Value))
            //{
            //    ltrPage.Text = "Quản lý hoạt động > Vật tư";
            //}
            //else
            //{
            //    ltrPage.Text = "Quản lý hoạt động > Thiết bị";
            //}
            if (!IsPostBack)
            {
                for (int i = 2010; i < 2050; i++)
                {
                    drpYear.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i), Func.ParseString(i)));
                }
                drpYear.Items.FindByValue(DateTime.Now.AddMonths(-1).ToString("yyyy")).Selected = true;

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
            else if (command.Equals("Schedule"))
            {
                Response.Redirect("BD_SuppliesGroupMaintenance.aspx?id=" + Func.ParseString(e.CommandArgument));
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
                    string GroupName = Func.ParseString(row["GroupName"]);

                    Func.SetGridTextValue(item, "ltrGroupName", GroupName);

                    Button btnUpdate = (Button)item.FindControl("btnSchedule");
                    btnUpdate.CommandArgument = Func.ParseString(row["id"]);
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
        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string sql = string.Empty;

            sql = " SELECT  A.GroupName, B.MaintenanceItem, B.ScheduleDate";
            sql += " FROM    BD_SuppliesGroup AS A Left outer JOIN";
            sql += "         BD_SuppliesGroupMaintenance AS B ON A.id = B.SuppliesGroupId";
            sql += "         and substring(ScheduleDate,1,4) = '" + drpYear.SelectedValue + "'";
            sql += " and B.DelFlag = 0 Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.SuppliesType = '" + hidSuppliesType.Value + "'";
            sql += " Order by GroupName, MaintenanceItem";

            using (SqlDatabase db = new SqlDatabase())
            {
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    if (ds != null)
                    {
                        C1XLBook xlbBook = new C1XLBook();
                        XLStyle xlstStyle = new XLStyle(xlbBook);
                        xlstStyle.AlignHorz = XLAlignHorzEnum.Left;
                        xlstStyle.AlignVert = XLAlignVertEnum.Center;
                        xlstStyle.WordWrap = true;
                        xlstStyle.Font = new Font("", 8, FontStyle.Regular);
                        xlstStyle.SetBorderColor(Color.Black);
                        xlstStyle.BorderBottom = XLLineStyleEnum.Thin;
                        xlstStyle.BorderTop = XLLineStyleEnum.Thin;
                        xlstStyle.BorderLeft = XLLineStyleEnum.Thin;
                        xlstStyle.BorderRight = XLLineStyleEnum.Thin;

                        XLStyle xlstStyleS = new XLStyle(xlbBook);
                        xlstStyleS.AlignHorz = XLAlignHorzEnum.Left;
                        xlstStyleS.AlignVert = XLAlignVertEnum.Center;
                        xlstStyleS.WordWrap = true;
                        xlstStyleS.Font = new Font("", 8, FontStyle.Regular);
                        xlstStyleS.SetBorderColor(Color.Black);
                        xlstStyleS.BorderBottom = XLLineStyleEnum.Thin;
                        xlstStyleS.BorderTop = XLLineStyleEnum.Thin;
                        xlstStyleS.BorderLeft = XLLineStyleEnum.Thin;
                        xlstStyleS.BorderRight = XLLineStyleEnum.Thin;
                        xlstStyleS.BackColor = Color.Red;


                        string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\BaoTriDinhKy.xls");
                        if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BaoTriDinhKy"))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BaoTriDinhKy"));
                        }

                        string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
                        string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BaoTriDinhKy\BaoTriDinhKy" + strDT + ".xls";
                        string strFilePathExport = "../../Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + "/BaoTriDinhKy/BaoTriDinhKy" + strDT + ".xls";

                        string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

                        File.Copy(fileName, fileNameDes);

                        xlbBook.Load(fileNameDes);

                        XLSheet xlsSheet = xlbBook.Sheets["BaoTri"];
                        xlsSheet[1, 0].Value = xlsSheet[1, 0].Value.ToString().Replace("{%NAM%}", drpYear.SelectedValue);

                        int stt = 0;
                        XLCellRange mCell = new XLCellRange(0, 0, 0, 0);

                        int i = 4;
                        DataTable dt = ds.Tables[0];
                        string tmpMaintenanceItem = "";
                        foreach (DataRow rowType in dt.Rows)
                        {
                            string GroupName = rowType["GroupName"].ToString();
                            string MaintenanceItem = rowType["MaintenanceItem"].ToString();
                            string ScheduleDate = rowType["ScheduleDate"].ToString();
                            if (String.IsNullOrEmpty(tmpMaintenanceItem))
                            {
                                tmpMaintenanceItem = GroupName + MaintenanceItem;
                                i++;
                            }

                            if (!tmpMaintenanceItem.Equals(GroupName + MaintenanceItem))
                            {
                                i++;
                                tmpMaintenanceItem = GroupName + MaintenanceItem;
                            }

                            xlsSheet[i, 1].Value = GroupName;
                            xlsSheet[i, 2].Value = MaintenanceItem;

                            mCell = new XLCellRange(i, i, 2, 3);
                            xlsSheet.MergedCells.Add(mCell);

                            xlsSheet[i, 1].Style = xlstStyle;
                            xlsSheet[i, 2].Style = xlstStyle;

                            for (int m = 0; m <= 51; m++)
                            {
                                xlsSheet[i, m].Style = xlstStyle;
                                if ("X".Equals(xlsSheet[i, m].Value))
                                {
                                    xlsSheet[i, m].Style = xlstStyleS;
                                }
                            }

                            if (!String.IsNullOrEmpty(ScheduleDate))
                            {
                                int month = Func.ParseInt(ScheduleDate.Substring(4, 2));
                                int date = Func.ParseInt(ScheduleDate.Substring(6, 2));
                                int x = month * 4;
                                if (date >= 1 && date <= 7)
                                    x += 0;
                                if (date >= 8 && date <= 14)
                                    x += 1;
                                if (date >= 15 && date <= 21)
                                    x += 2;
                                if (date >= 22 && date <= 31)
                                    x += 3;
                                xlsSheet[i, x].Value = "X";
                                xlsSheet[i, x].Style = xlstStyleS;
                            }
                            
                        }

                        i = 5;
                        int k = 1;
                        string tmp = xlsSheet[i, 1].Value.ToString();
                        xlsSheet[i, 0].Value = k;
                        int y = i;
                        i++;
                        mCell = new XLCellRange(0, 0, 0, 0); ;
                        while (!String.IsNullOrEmpty(Func.ParseString(xlsSheet[i, 1].Value)))
                        {
                            if (xlsSheet[i, 1].Value.ToString() != tmp)
                            {
                                tmp = xlsSheet[i, 1].Value.ToString();
                                mCell = new XLCellRange(y, i - 1, 1, 1);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(y, i - 1, 0, 0);
                                xlsSheet.MergedCells.Add(mCell);

                                y = i;
                                xlsSheet[i, 0].Value = ++k;
                            }
                            i++;
                        }
                        mCell = new XLCellRange(y, i - 1, 1, 1);
                        xlsSheet.MergedCells.Add(mCell);

                        mCell = new XLCellRange(y, i - 1, 0, 0);
                        xlsSheet.MergedCells.Add(mCell);

                        xlbBook.Save(fileNameDes);
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('../" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);

                    }
                }
            }
        }
    }
}
