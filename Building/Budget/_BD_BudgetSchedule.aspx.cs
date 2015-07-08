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

namespace Man.Building.Budget
{
    public partial class BD_BudgetSchedule : PageBase
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

        private string updateSuccess = "Cập Nhật Thông Tin Đã Thành Công";
        private string updateUnSuccess = "Cập Nhật Thông Tin Không Thành Công";
        private string addSuccess = "Thêm Mới Thành Công";
        private string addUnSuccess = "Thêm Mới Không Thành Công";

        private void GetChildItems(string id, string parentID, DataTable dtTemp, DataTable ddl, int colNo)
        {
            foreach (DataRow drr in dtTemp.Rows)
            {
                int child = 1;
                if (drr["ParentId"].ToString() == parentID.ToString())
                {
                    ListItem chilitem = new ListItem();
                    chilitem.Text = drr["Name"].ToString();
                    chilitem.Value = drr["ID"].ToString();
                    ddl.Rows.Add(id, chilitem.Text, chilitem.Value, child + colNo, "0", Func.ParseInt(drr["ParentId"]));
                    GetChildItems(id, drr["ID"].ToString(), dtTemp, ddl, child + colNo);
                }
            }
        }
        /// <summary>
        /// Init values
        /// </summary>
        protected override void DoInit()
        {
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopupWidth = 600;
                PopupHeight = 450;

                for (int i = 2010; i < 2050; i++)
                {
                    drpYear.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i), Func.ParseString(i)));
                }
                drpYear.Items.FindByValue(DateTime.Now.AddMonths(-1).ToString("yyyy")).Selected = true;

                //for (int i = 1; i < 13; i++)
                //{
                //    drpMonth.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
                //}
                //drpMonth.Items.FindByValue(DateTime.Now.AddMonths(-1).ToString("MM")).Selected = true;

                DbHelper.FillList(drpBudget, "Select * from BD_BudgetSchedule Where delflag = 0 and YearMonth = '" + drpYear.SelectedValue + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "Budget", "id");
                DbHelper.FillListSearch(drpBudgetExport, "Select * from BD_BudgetSchedule Where delflag = 0 and YearMonth = '" + drpYear.SelectedValue + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "Budget", "id");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            mvMessage.CheckRequired(txtBudget, "Ngân sách kỳ: là Danh mục bắt bắt buộc nhập");
            if (!mvMessage.IsValid) return;

            //Get and Insert Data
            BD_BudgetScheduleData data = new BD_BudgetScheduleData();
            ITransaction tran = factory.GetLoadObject(data, drpBudget.SelectedValue);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_BudgetScheduleData)tran.Result;
                data.Budget = txtBudget.Text.Trim();

                data.ModifiedBy = Page.User.Identity.Name;
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");

                tran = factory.GetUpdateObject(data);

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(updateSuccess);
                    DbHelper.FillList(drpBudget, "Select * from BD_BudgetSchedule Where YearMonth = '" + drpYear.SelectedValue + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "Budget", "id");
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(updateUnSuccess);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            mvMessage.CheckRequired(txtBudget, "Ngân sách kỳ: là Danh mục bắt bắt buộc nhập");
            if (!mvMessage.IsValid) return;

            //Get and Insert Data
            BD_BudgetScheduleData data = new BD_BudgetScheduleData();
            ITransaction tran = factory.GetInsertObject(data);
            data.Budget = txtBudget.Text.Trim();
            data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);
            data.YearMonth = drpYear.SelectedValue;
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
                DbHelper.FillList(drpBudget, "Select * from BD_BudgetSchedule Where DelFlag = 0 and YearMonth = '" + drpYear.SelectedValue + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "Budget", "id");
                DbHelper.FillList(drpBudgetExport, "Select * from BD_BudgetSchedule Where DelFlag = 0 and YearMonth = '" + drpYear.SelectedValue + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "Budget", "id");

                //// Them vao de xuat ngan sach
                string yearmonth = drpYear.SelectedValue;
                string building = Func.ParseString(Session["__BUILDINGID__"]);

                DataTable dtTable = new DataTable();
                dtTable.Columns.Add("BuggetScheduleId", Type.GetType("System.String"));
                dtTable.Columns.Add("PaymentType", Type.GetType("System.String"));
                dtTable.Columns.Add("PaymentId", Type.GetType("System.String"));
                dtTable.Columns.Add("colNo", Type.GetType("System.String"));
                dtTable.Columns.Add("delFlag", Type.GetType("System.String"));
                dtTable.Columns.Add("ParentId", Type.GetType("System.Int32"));

                string buildingId = Func.ParseString(Session["__BUILDINGID__"]);
                string sqlTmp = "Select Name,id,ParentId from BD_PaymentType Where delflag = '0' and BuildingId = '" + buildingId + "' ";
                sqlTmp += "Union ";
                sqlTmp += "Select Name,id,ParentId from Mst_PaymentType";

                DataTable dt = DbHelper.GetDataTable("Select * from (" + sqlTmp + ") A order by id");
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["ParentId"].ToString() == "")
                    {
                        int j = 1;
                        ListItem item = new ListItem();
                        item.Text = dr["Name"].ToString();
                        item.Value = dr["Id"].ToString();
                        dtTable.Rows.Add(data.id, item.Text, item.Value, j, "0", Func.ParseInt(dr["ParentId"]));
                        GetChildItems(data.id, dr["Id"].ToString(), dt, dtTable, j);
                    }
                }
                using (SqlBulkCopy copy = new SqlBulkCopy(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                {
                    copy.DestinationTableName = "BD_BudgetScheduleDetail";
                    copy.BatchSize = 3000;
                    copy.BulkCopyTimeout = 99999;
                    copy.ColumnMappings.Add(0, "BuggetScheduleId");
                    copy.ColumnMappings.Add(1, "PaymentType");
                    copy.ColumnMappings.Add(2, "PaymentId");
                    copy.ColumnMappings.Add(3, "colNo");
                    copy.ColumnMappings.Add(4, "DelFlag");
                    copy.ColumnMappings.Add(5, "ParentId");

                    copy.WriteToServer(dtTable);
                }
            }
            else
            {
                OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                mvMessage.AddError(addUnSuccess);
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DbHelper.ExecuteNonQuery("Update BD_BudgetScheduleDetail Set DelFlag = 1 Where BuggetScheduleId = '" + drpBudget.SelectedValue + "'");
            DbHelper.ExecuteNonQuery("Update BD_BudgetSchedule Set DelFlag = 1 Where id = '" + drpBudget.SelectedValue + "'");
            DbHelper.FillList(drpBudget, "Select * from BD_BudgetSchedule Where DelFlag = 0 and YearMonth = '" + drpYear.SelectedValue + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "Budget", "id");
            DbHelper.FillListSearch(drpBudgetExport, "Select * from BD_BudgetSchedule Where DelFlag = 0 and YearMonth = '" + drpYear.SelectedValue + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "Budget", "id");
        }

        private void GetChildItems(string parentID, DataTable dtTemp, DataTable ddl, int colNo)
        {
            string building = Func.ParseString(Session["__BUILDINGID__"]);
            string sessionId = Session.SessionID;

            foreach (DataRow drr in dtTemp.Rows)
            {
                int child = 1;
                if (Func.ParseString(drr["ParentId"]).Equals(parentID))
                {
                    int BuggetScheduleId = Func.ParseInt(drr["BuggetScheduleId"]);
                    int PaymentId = Func.ParseInt(drr["PaymentId"]);
                    string ParentId = Func.ParseString(drr["ParentId"]);

                    ddl.Rows.Add(sessionId, BuggetScheduleId, PaymentId, ParentId);

                    GetChildItems(drr["PaymentId"].ToString(), dtTemp, ddl, child + colNo);
                }
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string yearmonth = drpYear.SelectedValue;
            string building = Func.ParseString(Session["__BUILDINGID__"]);

            DataSet ds = new DataSet();
            string sql = string.Empty;

            sql = " SELECT *";
            sql += " FROM BD_BudgetSchedule ";
            sql += " WHERE BuildingId = '" + building + "' ";
            sql += " and YearMonth = '" + yearmonth + "' ";
            sql += " and id ='" + drpBudgetExport.SelectedValue + "' and DelFlag = 0 Order by id";

            using (SqlDatabase db = new SqlDatabase())
            {
                C1XLBook xlbBook = new C1XLBook();

                string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\NganSach.xlsx");
                if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])));
                }

                string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
                string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\NganSach" + strDT + ".xlsx";
                string strFilePathExport = @"../../Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + @"/NganSach" + strDT + ".xlsx";

                string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

                //string fileNameDes = HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\TongHopDienTich" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx");
                File.Copy(fileName, fileNameDes);

                xlbBook.Load(fileNameDes);

                string sheet = "NganSach";

                XLSheet xlsSheet = xlbBook.Sheets[sheet];

                string IDs = "";
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    if (ds != null)
                    {
                        xlsSheet[0, 1].Value = xlsSheet[0, 1].Value.ToString().Replace("{%TOA_NHA%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + building + "'"));
                        xlsSheet[0, 1].Value = xlsSheet[0, 1].Value.ToString().Replace("{%NAM_THANG%}", "NĂM " + yearmonth);

                        int j = 2;
                        DataTable dtReport = ds.Tables[0];

                        foreach (DataRow rowType in dtReport.Rows)
                        {
                            string Budget = rowType["Budget"].ToString();
                            string id = rowType["id"].ToString();

                            IDs += ",'" + id + "'";
                            xlsSheet[2, j].Value = id;
                            xlsSheet[3, j].Value = Budget;
                            j += 2;
                        }
                        for (int i = j; i < j * 12; i++)
                        {
                            XLColumn col = new XLColumn();
                            col = xlsSheet.Columns[j];
                            xlsSheet.Columns.Remove(col);
                        }

                    }
                }
                if (String.IsNullOrEmpty(IDs))
                {
                    mvMessage.AddError("Hiện tại chưa có Kỳ ngân sách nào được tạo");
                    return;
                }

                DataTable dtTable = new DataTable();
                dtTable.Columns.Add("SessionId", Type.GetType("System.String"));
                dtTable.Columns.Add("BuggetScheduleId", Type.GetType("System.Int32"));
                dtTable.Columns.Add("PaymentId", Type.GetType("System.Int32"));
                dtTable.Columns.Add("ParentId", Type.GetType("System.String"));

                string buildingId = Func.ParseString(Session["__BUILDINGID__"]);
                string sessionId = Session.SessionID;
                string sqlTmp = "Select * from BD_BudgetScheduleDetail where BuggetScheduleId in (" + IDs.Substring(1) + ") and delFlag = 0 Order by ParentId";

                DbHelper.ExecuteNonQuery("Delete From BD_BudgetScheduleDetailReport where SessionId = '" + sessionId + "'");
                DataTable dt = DbHelper.GetDataTable(sqlTmp);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["ParentId"].ToString() == "0")
                    {
                        int j = 1;
                        int BuggetScheduleId = Func.ParseInt(dr["BuggetScheduleId"]);
                        int PaymentId = Func.ParseInt(dr["PaymentId"]);
                        string ParentId = dr["ParentId"].ToString();

                        dtTable.Rows.Add(sessionId, BuggetScheduleId, PaymentId, ParentId);

                        GetChildItems(dr["PaymentId"].ToString(), dt, dtTable, j);
                    }
                }
                using (SqlBulkCopy copy = new SqlBulkCopy(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                {
                    copy.DestinationTableName = "BD_BudgetScheduleDetailReport";
                    copy.BatchSize = 3000;
                    copy.BulkCopyTimeout = 99999;

                    copy.ColumnMappings.Add(0, "SessionId");
                    copy.ColumnMappings.Add(1, "BuggetScheduleId");
                    copy.ColumnMappings.Add(2, "PaymentId");
                    copy.ColumnMappings.Add(3, "ParentId");

                    copy.WriteToServer(dtTable);
                }

                ds = new DataSet();
                sql = "Select * from BD_BudgetScheduleDetailReport where SessionId = '" + sessionId + "' Order by Id";
                int k = 5;
                int colData = -1;
                string bsId = "";

                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    if (ds != null)
                    {
                        DataTable dtReport = ds.Tables[0];
                        foreach (DataRow rowType in dtReport.Rows)
                        {
                            string PaymentType = rowType["PaymentType"].ToString();
                            string InVND = rowType["InVND"].ToString();
                            string InUSD = rowType["InUSD"].ToString();
                            string OutVND = rowType["OutVND"].ToString();
                            string OutUSD = rowType["OutUSD"].ToString();
                            string PaymentId = rowType["PaymentId"].ToString();
                            int colNo = Func.ParseInt(rowType["colNo"].ToString());
                            string id = rowType["BuggetScheduleId"].ToString();
                            string ParentId = rowType["ParentId"].ToString();
                            //string PaymentId = rowType["PaymentId"].ToString();
                            //xlsSheet[2, j].Value = id;
                            //xlsSheet[3, j].Value = Budget;
                            //j += 2;
                            if (!bsId.Equals(id))
                            {
                                k = 5;
                                colData += 2;
                                bsId = id;
                            }

                            xlsSheet[k, 1].Value = PaymentType;
                            xlsSheet[k, colData + 1].Value = Func.ParseDouble(InUSD);
                            xlsSheet[k, colData + 2].Value = Func.ParseDouble(InVND);
                            //xlsSheet[k, colData + 3].Value = Func.ParseDouble(OutUSD);
                            //xlsSheet[k, colData + 4].Value = Func.ParseDouble(OutVND);
                            xlsSheet[k, 0].Value = PaymentId;


                            XLStyle xlstStyle = new XLStyle(xlbBook);
                            xlstStyle.AlignHorz = XLAlignHorzEnum.Left;
                            xlstStyle.WordWrap = false;
                            xlstStyle.Font = new Font("", 8, FontStyle.Regular);
                            xlstStyle.SetBorderColor(Color.Black);
                            xlstStyle.BorderBottom = XLLineStyleEnum.Thin;
                            xlstStyle.BorderTop = XLLineStyleEnum.Thin;
                            xlstStyle.BorderLeft = XLLineStyleEnum.Thin;
                            xlstStyle.BorderRight = XLLineStyleEnum.Thin;
                            if ("0".Equals(ParentId))
                            {
                                xlstStyle.BackColor = Color.Orange;
                            }
                            xlsSheet[k, 1].Style = xlstStyle;

                            xlstStyle = new XLStyle(xlbBook);
                            if (String.IsNullOrEmpty(ParentId))
                            {
                                xlstStyle.BackColor = Color.Orange;
                            }
                            xlstStyle.WordWrap = false;
                            xlstStyle.Font = new Font("", 8, FontStyle.Regular);
                            xlstStyle.SetBorderColor(Color.Black);
                            xlstStyle.BorderBottom = XLLineStyleEnum.Thin;
                            xlstStyle.BorderTop = XLLineStyleEnum.Thin;
                            xlstStyle.BorderLeft = XLLineStyleEnum.Thin;
                            xlstStyle.BorderRight = XLLineStyleEnum.Thin;
                            xlstStyle.AlignHorz = XLAlignHorzEnum.Center;
                            xlsSheet[k, colData + 1].Style = xlstStyle;
                            xlsSheet[k, colData + 2].Style = xlstStyle;
                            //xlsSheet[k, colData+3].Style = xlstStyle;
                            //xlsSheet[k, colData+4].Style = xlstStyle;

                            k++;
                        }
                    }
                }

                //ds = new DataSet();
                //sql = string.Empty;

                //sql = " SELECT *";
                //sql += " FROM BD_PaymentReportMonth ";
                //sql += " WHERE BuildingId = '" + building + "' ";
                //sql += " and YearMonth = '" + yearmonth + "' order by id";

                //using (db = new SqlDatabase())
                //{
                //    using (SqlCommand cm = db.CreateCommand(sql))
                //    {
                //        SqlDataAdapter da = new SqlDataAdapter(cm);
                //        da.Fill(ds);
                //        if (ds != null)
                //        {
                //            xlbBook = new C1XLBook();

                //            fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\BaoCaoThuChiThang.xlsx");
                //            if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])))
                //            {
                //                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])));
                //            }

                //            strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
                //            strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BaoCaoThuChiThang" + strDT + ".xlsx";
                //            strFilePathExport = "Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + "/BaoCaoThuChiThang" + strDT + ".xlsx";

                //            fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

                //            //string fileNameDes = HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\TongHopDienTich" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx");
                //            File.Copy(fileName, fileNameDes);

                //            xlbBook.Load(fileNameDes);

                //            sheet = "BaoCao";

                //            xlsSheet = xlbBook.Sheets[sheet];
                //            int i = 5;

                //            xlsSheet[0, 0].Value = xlsSheet[0, 0].Value.ToString().Replace("{%TOA_NHA%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + building + "'"));
                //            xlsSheet[0, 0].Value = xlsSheet[0, 0].Value.ToString().Replace("{%NAM_THANG%}", "THÁNG" + yearmonth.Substring(4, 2) + "/" + yearmonth.Substring(0, 4));

                //            DataTable dtReport = ds.Tables[0];
                //            foreach (DataRow rowType in dtReport.Rows)
                //            {
                //                int colNo = Func.ParseInt(rowType["colNo"]);
                //                string PaymentType = rowType["PaymentType"].ToString();
                //                string InVND = rowType["InVND"].ToString();
                //                string InUSD = rowType["InUSD"].ToString();
                //                string OutVND = rowType["OutVND"].ToString();
                //                string OutUSD = rowType["OutUSD"].ToString();
                //                bool bold = rowType["bold"].ToString().Equals("1") ? true : false;

                //                XLCellRange mrCell = new XLCellRange(i, i, 0, 3);
                //                xlsSheet.MergedCells.Add(mrCell);

                //                xlsSheet[i, 0].Value = "." + " ".PadLeft(colNo * 3, ' ') + PaymentType;
                //                xlsSheet[i, 4].Value = Func.ParseDouble(InUSD);
                //                xlsSheet[i, 5].Value = Func.ParseDouble(InVND);
                //                xlsSheet[i, 6].Value = Func.ParseDouble(OutUSD);
                //                xlsSheet[i, 7].Value = Func.ParseDouble(OutVND);


                //                XLStyle xlstStyle = new XLStyle(xlbBook);
                //                xlstStyle.AlignHorz = XLAlignHorzEnum.Left;
                //                xlstStyle.WordWrap = false;
                //                xlstStyle.Font = new Font("", 8, FontStyle.Regular);
                //                xlstStyle.SetBorderColor(Color.Black);
                //                xlstStyle.BorderBottom = XLLineStyleEnum.Thin;
                //                xlstStyle.BorderTop = XLLineStyleEnum.Thin;
                //                xlstStyle.BorderLeft = XLLineStyleEnum.Thin;
                //                xlstStyle.BorderRight = XLLineStyleEnum.Thin;

                //                xlsSheet[i, 0].Style = xlstStyle;
                //                xlsSheet[i, 1].Style = xlstStyle;
                //                xlsSheet[i, 2].Style = xlstStyle;
                //                xlsSheet[i, 3].Style = xlstStyle;

                //                xlstStyle = new XLStyle(xlbBook);
                //                xlstStyle.WordWrap = false;
                //                xlstStyle.Font = new Font("", 8, FontStyle.Regular);
                //                xlstStyle.SetBorderColor(Color.Black);
                //                xlstStyle.BorderBottom = XLLineStyleEnum.Thin;
                //                xlstStyle.BorderTop = XLLineStyleEnum.Thin;
                //                xlstStyle.BorderLeft = XLLineStyleEnum.Thin;
                //                xlstStyle.BorderRight = XLLineStyleEnum.Thin;
                //                xlstStyle.AlignHorz = XLAlignHorzEnum.Center;
                //                xlsSheet[i, 4].Style = xlstStyle;
                //                xlsSheet[i, 5].Style = xlstStyle;
                //                xlsSheet[i, 6].Style = xlstStyle;
                //                xlsSheet[i, 7].Style = xlstStyle;

                //                i++;
                //            }

                //            xlbBook.Save(fileNameDes);
                //            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('../" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);
                //        }
                //    }
                //}



                xlbBook.Save(fileNameDes);
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);

            }
        }
        protected void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Server.MapPath("./") + File1.PostedFile.FileName))
                {
                    File.Delete(Server.MapPath("./") + File1.PostedFile.FileName);
                }
                C1XLBook xlbBook = new C1XLBook();

                string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
                string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Import\NganSach" + strDT + ".xlsx");
                File1.PostedFile.SaveAs(fileName);

                if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])));
                }

                string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\NganSach" + strDT + ".xlsx";
                string strFilePathExport = @"../../Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + @"/NganSach" + strDT + ".xlsx";
                xlbBook.Load(fileName);

                string sheet = "NganSach";

                XLSheet xlsSheet = xlbBook.Sheets[sheet];

                for (int i = 2; i < 24; i++)
                {
                    if (String.IsNullOrEmpty(Func.ParseString(xlsSheet[2, i].Value)))
                    {
                        break;
                    }
                    string BuggetScheduleId = Func.ParseString(xlsSheet[2, i].Value);
                    for (int j = 5; j < 250; j++)
                    {
                        if (String.IsNullOrEmpty(Func.ParseString(xlsSheet[j, 0].Value)))
                        {
                            break;
                        }

                        string PaymentId = Func.ParseString(xlsSheet[j, 0].Value);
                        string inUSD = Func.ParseString(xlsSheet[j, i].Value);
                        string inVND = Func.ParseString(xlsSheet[j, i + 1].Value);

                        DbHelper.ExecuteNonQuery("Update BD_BudgetScheduleDetail Set inVND = '" + inVND.Replace(",", ".") + "', inUSD = '" + inUSD.Replace(",", ".") + "' Where BuggetScheduleId ='" + BuggetScheduleId + "' and PaymentId = '" + PaymentId + "'");
                    }
                    i++;
                }
                mvMessage.SetCompleteMessage("Đã import thành công");
            }
            catch (Exception ex)
            {

            }
        }
    }
}


