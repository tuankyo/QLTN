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
    public partial class BD_SuppliesMaintenance : PageBase
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
                    string Name = drr["Name"].ToString();
                    string idd = drr["Id"].ToString();
                    string itemLevel = drr["ItemLevel"].ToString();

                    ddl.Rows.Add(id, Name, idd, child + colNo, "0", Func.ParseInt(drr["ParentId"]), itemLevel);
                    GetChildItems(id, idd, dtTemp, ddl, child + colNo);
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
                DbHelper.FillListSearch(drpBudgetExport, "Select * from BD_BudgetSchedule Where DelFlag = 0 and YearMonth = '" + drpYear.SelectedValue + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "Budget", "id");

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
                dtTable.Columns.Add("ItemLevel", Type.GetType("System.String"));

                string buildingId = Func.ParseString(Session["__BUILDINGID__"]);
                string sqlTmp = "Select Name,id,ParentId,ItemLevel from BD_PaymentType Where delflag = '0' and BuildingId = '" + buildingId + "' ";
                sqlTmp += "Union ";
                sqlTmp += "Select Name,id,ParentId,ItemLevel from Mst_PaymentType";

                DataTable dt = DbHelper.GetDataTable("Select * from (" + sqlTmp + ") A order by id");
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["ParentId"].ToString() == "")
                    {
                        int j = 1;
                        string Name = dr["Name"].ToString();
                        string id = dr["Id"].ToString();
                        string itemLevel = dr["ItemLevel"].ToString();
                        dtTable.Rows.Add(data.id, Name, id, j, "0", Func.ParseInt(dr["ParentId"]), itemLevel);
                        GetChildItems(data.id, id, dt, dtTable, j);
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
                    copy.ColumnMappings.Add(6, "ItemLevel");

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
                    string PaymentType = drr["PaymentType"].ToString();
                    int PaymentId = Func.ParseInt(drr["PaymentId"]);
                    int ParentId = Func.ParseInt(drr["ParentId"]);
                    double InVND = Func.ParseDouble(drr["InVND"]);
                    decimal InUSD = Func.ParseInt(drr["InUSD"]);
                    double OutVND = Func.ParseDouble(drr["OutVND"]);
                    decimal OutUSD = Func.ParseInt(drr["OutUSD"]);
                    string itemLevel = Func.ParseString(drr["itemLevel"]);

                    ddl.Rows.Add(sessionId, BuggetScheduleId, PaymentType, PaymentId, ParentId, InVND, InUSD, OutVND, OutUSD, itemLevel);

                    GetChildItems(Func.ParseString(PaymentId), dtTemp, ddl, child + colNo);
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
            sql += drpBudgetExport.SelectedValue.Equals("") ? "" : " and id ='" + drpBudgetExport.SelectedValue + "'";
            sql += " and DelFlag = 0 Order by id";

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
                        xlsSheet[0, 2].Value = xlsSheet[0, 2].Value.ToString().Replace("{%TOA_NHA%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + building + "'"));
                        xlsSheet[0, 2].Value = xlsSheet[0, 2].Value.ToString().Replace("{%NAM_THANG%}", "NĂM " + yearmonth);

                        int j = 7;
                        DataTable dtReport = ds.Tables[0];

                        foreach (DataRow rowType in dtReport.Rows)
                        {
                            string Budget = rowType["Budget"].ToString();
                            string id = rowType["id"].ToString();

                            IDs += ",'" + id + "'";
                            xlsSheet[2, j].Value = id;
                            xlsSheet[3, j].Value = Budget;
                            j++;
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


                string buildingId = Func.ParseString(Session["__BUILDINGID__"]);
                string sessionId = Session.SessionID;
                DbHelper.ExecuteNonQuery("Delete From BD_BudgetScheduleDetailReport where SessionId = '" + sessionId + "'");

                string[] idList = IDs.Substring(1).Split(',');
                for (int m = 0; m < idList.Length; m++)
                {
                    string sqlTmp = "Select * from BD_BudgetScheduleDetail where BuggetScheduleId in (" + idList[m] + ") and delFlag = 0 Order by Id";
                    DataTable dtTable = new DataTable();
                    dtTable.Columns.Add("SessionId", Type.GetType("System.String"));
                    dtTable.Columns.Add("BuggetScheduleId", Type.GetType("System.Int32"));
                    dtTable.Columns.Add("PaymentType", Type.GetType("System.String"));
                    dtTable.Columns.Add("PaymentId", Type.GetType("System.Int32"));
                    dtTable.Columns.Add("ParentId", Type.GetType("System.Int32"));
                    dtTable.Columns.Add("InVND", Type.GetType("System.Double"));
                    dtTable.Columns.Add("InUSD", Type.GetType("System.Decimal"));
                    dtTable.Columns.Add("OutVND", Type.GetType("System.Double"));
                    dtTable.Columns.Add("OutUSD", Type.GetType("System.Decimal"));
                    dtTable.Columns.Add("ItemLevel", Type.GetType("System.String"));

                    DataTable dt = DbHelper.GetDataTable(sqlTmp);
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ParentId"].ToString() == "0")
                        {
                            int j = 1;
                            int BuggetScheduleId = Func.ParseInt(dr["BuggetScheduleId"]);
                            string PaymentType = dr["PaymentType"].ToString();
                            int PaymentId = Func.ParseInt(dr["PaymentId"]);
                            int ParentId = Func.ParseInt(dr["ParentId"]);
                            double InVND = Func.ParseDouble(dr["InVND"]);
                            decimal InUSD = Func.ParseInt(dr["InUSD"]);
                            double OutVND = Func.ParseDouble(dr["OutVND"]);
                            decimal OutUSD = Func.ParseInt(dr["OutUSD"]);
                            string itemLevel = Func.ParseString(dr["itemLevel"]);

                            dtTable.Rows.Add(sessionId, BuggetScheduleId, PaymentType, PaymentId, ParentId, InVND, InUSD, OutVND, OutUSD, itemLevel);

                            GetChildItems(Func.ParseString(PaymentId), dt, dtTable, j);
                        }
                    }
                    using (SqlBulkCopy copy = new SqlBulkCopy(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                    {
                        copy.DestinationTableName = "BD_BudgetScheduleDetailReport";
                        copy.BatchSize = 3000;
                        copy.BulkCopyTimeout = 99999;

                        copy.ColumnMappings.Add(0, "SessionId");
                        copy.ColumnMappings.Add(1, "BuggetScheduleId");
                        copy.ColumnMappings.Add(2, "PaymentType");
                        copy.ColumnMappings.Add(3, "PaymentId");
                        copy.ColumnMappings.Add(4, "ParentId");
                        copy.ColumnMappings.Add(5, "InVND");
                        copy.ColumnMappings.Add(6, "InUSD");
                        copy.ColumnMappings.Add(7, "OutVND");
                        copy.ColumnMappings.Add(8, "OutUSD");
                        copy.ColumnMappings.Add(9, "ItemLevel");

                        copy.WriteToServer(dtTable);
                    }
                }
                ds = new DataSet();
                sql = "Select * from BD_BudgetScheduleDetailReport where SessionId = '" + sessionId + "' Order by BuggetScheduleId,Id";
                int k = 5;
                int colData = 6;
                string bsId = "";
                string[] alpha = "A. B. C. D. E. F. G. H. I. J. K. L. M. N. O. P. Q. R. S. T. U. V. W. X. Y. Z.".Split(' ');
                string[] alphaLevel2 = "I. II. III. IV. V. VI. VII. VIII. IX. X. XI. XII. XII. XIV.".Split(' ');
                string[] alphaLevel3 = "1. 2. 3. 4. 5. 6. 7. 8. 9. 10. 11. 12. 13. 14. 15. 16. 17. 18. 19. 20.".Split(' ');
                string[] alphaLevel4 = "a. b. c. d. e. f. g. h. i. j. k. l. m. n. o. p. q. r. s. t. u. v. w.".Split(' ');
                int level1 = -1;
                int level2 = -1;
                int level3 = -1;
                int level4 = -1;
                xlsSheet.Columns[1].Width = 300;
                xlsSheet.Columns[2].Width = 300;
                xlsSheet.Columns[3].Width = 300;
                xlsSheet.Columns[4].Width = 300;
                xlsSheet.Columns[5].Width = 300;
                int lastrow = 0;
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    if (ds != null)
                    {
                        double inSumVND = 0;
                        double outSumVND = 0;
                        DataTable dtReport = ds.Tables[0];
                        foreach (DataRow rowType in dtReport.Rows)
                        {
                            XLStyle xlstStyleAll = new XLStyle(xlbBook);
                            //xlstStyleAll.AlignHorz = XLAlignHorzEnum.Left;
                            xlstStyleAll.WordWrap = false;
                            xlstStyleAll.Font = new Font("", 8, FontStyle.Regular);
                            xlstStyleAll.SetBorderColor(Color.Black);
                            xlstStyleAll.BorderBottom = XLLineStyleEnum.Thin;
                            xlstStyleAll.BorderTop = XLLineStyleEnum.Thin;
                            xlstStyleAll.BorderLeft = XLLineStyleEnum.Thin;
                            xlstStyleAll.BorderRight = XLLineStyleEnum.Thin;

                            XLStyle xlstStyleLeft = new XLStyle(xlbBook);
                            //xlstStyleLeft.AlignHorz = XLAlignHorzEnum.Left;
                            xlstStyleLeft.WordWrap = false;
                            xlstStyleLeft.Font = new Font("", 8, FontStyle.Regular);
                            xlstStyleLeft.SetBorderColor(Color.Black);
                            xlstStyleLeft.BorderBottom = XLLineStyleEnum.Thin;
                            xlstStyleLeft.BorderTop = XLLineStyleEnum.Thin;
                            xlstStyleLeft.BorderLeft = XLLineStyleEnum.Thin;

                            XLStyle xlstStyleRight = new XLStyle(xlbBook);
                            //xlstStyleRight.AlignHorz = XLAlignHorzEnum.Left;
                            xlstStyleRight.WordWrap = false;
                            xlstStyleRight.Font = new Font("", 8, FontStyle.Regular);
                            xlstStyleRight.SetBorderColor(Color.Black);
                            xlstStyleRight.BorderBottom = XLLineStyleEnum.Thin;
                            xlstStyleRight.BorderTop = XLLineStyleEnum.Thin;
                            xlstStyleRight.BorderRight = XLLineStyleEnum.Thin;

                            XLStyle xlstStyleMiddle = new XLStyle(xlbBook);
                            //xlstStyleMiddle.AlignHorz = XLAlignHorzEnum.Left;
                            xlstStyleMiddle.WordWrap = false;
                            xlstStyleMiddle.Font = new Font("", 8, FontStyle.Regular);
                            xlstStyleMiddle.SetBorderColor(Color.Black);
                            xlstStyleMiddle.BorderBottom = XLLineStyleEnum.Thin;
                            xlstStyleMiddle.BorderTop = XLLineStyleEnum.Thin;

                            xlsSheet[k, 2].Style = xlstStyleLeft;
                            xlsSheet[k, 3].Style = xlstStyleMiddle;
                            xlsSheet[k, 4].Style = xlstStyleMiddle;
                            xlsSheet[k, 5].Style = xlstStyleMiddle;
                            xlsSheet[k, 6].Style = xlstStyleRight;



                            string PaymentType = rowType["PaymentType"].ToString();
                            string InVND = rowType["InVND"].ToString();
                            string InUSD = rowType["InUSD"].ToString();
                            string OutVND = rowType["OutVND"].ToString();
                            string OutUSD = rowType["OutUSD"].ToString();
                            string PaymentId = rowType["PaymentId"].ToString();
                            int colNo = Func.ParseInt(rowType["colNo"].ToString());
                            string id = rowType["BuggetScheduleId"].ToString();
                            string ParentId = rowType["ParentId"].ToString();
                            string itemLevel = rowType["ItemLevel"].ToString();

                            if (itemLevel.Equals("0"))
                            {
                                xlstStyleAll.BackColor = Color.Orange;
                                xlstStyleLeft.BackColor = Color.Orange;
                                xlstStyleRight.BackColor = Color.Orange;
                                xlstStyleMiddle.BackColor = Color.Orange;
                            }
                            else
                            {
                                xlstStyleAll.BackColor = Color.White;
                                xlstStyleLeft.BackColor = Color.White;
                                xlstStyleRight.BackColor = Color.White;
                                xlstStyleMiddle.BackColor = Color.White;
                            }

                            if (itemLevel.Equals("0") || itemLevel.Equals("1") || itemLevel.Equals("2"))
                            {
                                xlstStyleAll.Font = new Font("", 8, FontStyle.Bold);
                                xlstStyleLeft.Font = new Font("", 8, FontStyle.Bold);
                                xlstStyleRight.Font = new Font("", 8, FontStyle.Bold);
                                xlstStyleMiddle.Font = new Font("", 8, FontStyle.Bold);
                            }
                            xlsSheet[k, colData].Style = xlstStyleAll;

                            //j += 2;
                            if (!bsId.Equals(id))
                            {
                                if (k > 5)
                                {
                                    lastrow = k;
                                    xlsSheet[k, 2].Value = alpha[level1+1];
                                    xlsSheet[k, 3].Value = "CÂN ĐỐI THU - CHI (Phần Lãi)";
                                    //xlsSheet[k, colData + 1].Value = Func.ParseDouble(InUSD);
                                    xlsSheet[k, colData].Value = Func.ParseDouble(inSumVND - outSumVND);
                                }
                                k = 5;
                                colData++;
                                bsId = id;
                                level1 = -1;
                            }
                            int col = Func.ParseInt(itemLevel) + 3;

                            if (itemLevel.Equals("0"))
                            {
                                level1++;
                                xlsSheet[k, col - 1].Value = alpha[level1];

                                level2 = -1;
                            }
                            else if (itemLevel.Equals("1"))
                            {
                                level2++;
                                xlsSheet[k, col - 1].Value = alphaLevel2[level2];

                                level3 = -1;
                            }
                            else if (itemLevel.Equals("2"))
                            {
                                level3++;
                                xlsSheet[k, col - 1].Value = alphaLevel3[level3];

                                level4 = -1;
                            }
                            else if (itemLevel.Equals("3"))
                            {
                                level4++;
                                xlsSheet[k, col - 1].Value = alphaLevel4[level4];
                            }
                            xlsSheet[k, col].Value = PaymentType;
                            //xlsSheet[k, colData + 1].Value = Func.ParseDouble(InUSD);
                            xlsSheet[k, colData].Value = Func.ParseDouble(InVND);
                            ////xlsSheet[k, colData + 3].Value = Func.ParseDouble(OutUSD);
                            ////xlsSheet[k, colData + 4].Value = Func.ParseDouble(OutVND);
                            xlsSheet[k, 0].Value = PaymentId;

                            if (PaymentId.Equals("9"))
                            {
                                inSumVND = Func.ParseDouble(InVND);
                            }
                            else if (PaymentId.Equals("10"))
                            {
                                outSumVND = Func.ParseDouble(InVND);
                            }


                            //XLStyle xlstStyleAll = new XLStyle(xlbBook);
                            //xlstStyleAll.AlignHorz = XLAlignHorzEnum.Left;
                            //xlstStyleAll.WordWrap = false;
                            //xlstStyleAll.Font = new Font("", 8, FontStyle.Regular);
                            //xlstStyleAll.SetBorderColor(Color.Black);
                            //xlstStyleAll.BorderBottom = XLLineStyleEnum.Thin;
                            //xlstStyleAll.BorderTop = XLLineStyleEnum.Thin;
                            //xlstStyleAll.BorderLeft = XLLineStyleEnum.Thin;
                            //xlstStyleAll.BorderRight = XLLineStyleEnum.Thin;

                            //XLStyle xlstStyleLeft = new XLStyle(xlbBook);
                            //xlstStyleLeft.AlignHorz = XLAlignHorzEnum.Left;
                            //xlstStyleLeft.WordWrap = false;
                            //xlstStyleLeft.Font = new Font("", 8, FontStyle.Regular);
                            //xlstStyleLeft.SetBorderColor(Color.Black);
                            //xlstStyleLeft.BorderBottom = XLLineStyleEnum.Thin;
                            //xlstStyleLeft.BorderTop = XLLineStyleEnum.Thin;
                            //xlstStyleLeft.BorderLeft = XLLineStyleEnum.Thin;

                            //XLStyle xlstStyleRight = new XLStyle(xlbBook);
                            //xlstStyleRight.AlignHorz = XLAlignHorzEnum.Left;
                            //xlstStyleRight.WordWrap = false;
                            //xlstStyleRight.Font = new Font("", 8, FontStyle.Regular);
                            //xlstStyleRight.SetBorderColor(Color.Black);
                            //xlstStyleRight.BorderBottom = XLLineStyleEnum.Thin;
                            //xlstStyleRight.BorderTop = XLLineStyleEnum.Thin;
                            //xlstStyleRight.BorderRight = XLLineStyleEnum.Thin;

                            //XLStyle xlstStyleMiddle = new XLStyle(xlbBook);
                            //xlstStyleMiddle.AlignHorz = XLAlignHorzEnum.Left;
                            //xlstStyleMiddle.WordWrap = false;
                            //xlstStyleMiddle.Font = new Font("", 8, FontStyle.Regular);
                            //xlstStyleMiddle.SetBorderColor(Color.Black);
                            //xlstStyleMiddle.BorderBottom = XLLineStyleEnum.Thin;
                            //xlstStyleMiddle.BorderTop = XLLineStyleEnum.Thin;

                            //xlsSheet[k, 2].Style = xlstStyleLeft;
                            //xlsSheet[k, 3].Style = xlstStyleMiddle;
                            //xlsSheet[k, 4].Style = xlstStyleMiddle;
                            //xlsSheet[k, 5].Style = xlstStyleMiddle;
                            //xlsSheet[k, 6].Style = xlstStyleRight;

                            //if (itemLevel.Equals("0"))
                            //{
                            //    xlstStyleAll.BackColor = Color.Orange;
                            //    xlstStyleLeft.BackColor = Color.Orange;
                            //    xlstStyleRight.BackColor = Color.Orange;
                            //    xlstStyleMiddle.BackColor = Color.Orange;
                            //}
                            //else
                            //{
                            //    xlstStyleAll.BackColor = Color.White;
                            //    xlstStyleLeft.BackColor = Color.White;
                            //    xlstStyleRight.BackColor = Color.White;
                            //    xlstStyleMiddle.BackColor = Color.White;
                            //}

                            //if (itemLevel.Equals("0") || itemLevel.Equals("1") || itemLevel.Equals("2"))
                            //{
                            //    xlstStyleAll.Font = new Font("", 8, FontStyle.Bold);
                            //    xlstStyleLeft.Font = new Font("", 8, FontStyle.Bold);
                            //    xlstStyleRight.Font = new Font("", 8, FontStyle.Bold);
                            //    xlstStyleMiddle.Font = new Font("", 8, FontStyle.Bold);
                            //}
                            xlsSheet[k, colData].Style = xlstStyleAll;
                            k++;

                            if (k == lastrow)
                            {
                                XLStyle xlstStyleLast = new XLStyle(xlbBook);
                                xlstStyleLast.WordWrap = false;
                                xlstStyleLast.Font = new Font("", 8, FontStyle.Regular);
                                xlstStyleLast.SetBorderColor(Color.Black);
                                xlstStyleLast.BorderBottom = XLLineStyleEnum.Thin;
                                xlstStyleLast.BorderTop = XLLineStyleEnum.Thin;
                                xlstStyleLast.BorderLeft = XLLineStyleEnum.Thin;
                                xlstStyleLast.BorderRight = XLLineStyleEnum.Thin;
                                xlstStyleLast.Font = new Font("", 8, FontStyle.Bold);
                                xlstStyleLast.BackColor = Color.Orange;

                                xlsSheet[k, colData].Value = Func.ParseDouble(inSumVND - outSumVND);
                                xlsSheet[k, colData].Style = xlstStyleLast;
                            }

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

                for (int i = 7; i < 31; i++)
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
                        string inVND = Func.ParseString(xlsSheet[j, i].Value);

                        DbHelper.ExecuteNonQuery("Update BD_BudgetScheduleDetail Set inVND = '" + inVND.Replace(",", ".") + "' Where BuggetScheduleId ='" + BuggetScheduleId + "' and PaymentId = '" + PaymentId + "'");
                    }
                }
                mvMessage.SetCompleteMessage("Đã import thành công");
            }
            catch (Exception ex)
            {

            }
        }
    }
}


