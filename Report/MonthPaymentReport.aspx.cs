using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using BusinessObjects;
using Gnt.Transaction;
using Gnt.Data.DBCommand;
using Gnt.Data;
using System.Data.SqlClient;
using Man.Utils;
using C1.C1Excel;
using System.IO;
using System.Drawing;

namespace Man.Report
{
    public partial class MonthPaymentReport : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            }
        }

        protected override void DoPost()
        {
            //Handle postback from popup
            string eventTarget = Func.ParseString(Request["__EVENTTARGET"]);
            string eventArgument = Func.ParseString(Request["__EVENTARGUMENT"]);
            if (eventTarget.StartsWith("PopUp"))
            {
                if (eventTarget == "PopUpEditUser")
                {
                }
            }
        }
        private void GetChildItems(string parentID, DataTable dtTemp, DataTable ddl, int colNo)
        {
            //string yearmonth = drpYear.SelectedValue + drpMonth.SelectedValue;
            string building = Func.ParseString(Session["__BUILDINGID__"]);

            foreach (DataRow drr in dtTemp.Rows)
            {
                int child = 1;
                if (drr["ParentId"].ToString() == parentID.ToString())
                {
                    ListItem chilitem = new ListItem();
                    chilitem.Text = drr["Name"].ToString();
                    chilitem.Value = drr["ID"].ToString();

                    for (int k = 0; k < 13; k++)
                    {
                        string month = Func.ParseString(k).PadLeft(2, '0');
                        string yearmonthTmp = DateTime.Now.Year.ToString() + month;
                        ddl.Rows.Add(yearmonthTmp, building, chilitem.Text, chilitem.Value, child + colNo, drr["ItemLevel"].ToString(), drr["ParentId"].ToString());
                    }

                    GetChildItems(drr["ID"].ToString(), dtTemp, ddl, child + colNo);
                }
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string building = Func.ParseString(Session["__BUILDINGID__"]);

            DbHelper.ExecuteNonQuery("Delete from BD_PaymentReportMonth Where BuildingId = '" + building + "' and substring(yearmonth,1,4) = '" + DateTime.Now.Year.ToString() + "'");

            DataTable dtTable = new DataTable();
            dtTable.Columns.Add("YearMonth", Type.GetType("System.String"));
            dtTable.Columns.Add("BuildingId", Type.GetType("System.String"));
            dtTable.Columns.Add("PaymentType", Type.GetType("System.String"));
            dtTable.Columns.Add("PaymentId", Type.GetType("System.String"));
            dtTable.Columns.Add("colNo", Type.GetType("System.String"));
            dtTable.Columns.Add("ItemLevel", Type.GetType("System.String"));
            dtTable.Columns.Add("ParentId", Type.GetType("System.String"));

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
                    ListItem item = new ListItem();
                    item.Text = dr["Name"].ToString();
                    item.Value = dr["Id"].ToString();

                    for (int k = 0; k < 13; k++)
                    {
                        string month = Func.ParseString(k).PadLeft(2, '0');
                        string yearmonthTmp = DateTime.Now.Year.ToString() + month;
                        dtTable.Rows.Add(yearmonthTmp, building, item.Text, item.Value, k, dr["ItemLevel"].ToString(), dr["ParentId"].ToString());
                    }

                    GetChildItems(dr["Id"].ToString(), dt, dtTable, j);
                }
            }
            using (SqlBulkCopy copy = new SqlBulkCopy(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
            {
                copy.DestinationTableName = "BD_PaymentReportMonth";
                copy.BatchSize = 3000;
                copy.BulkCopyTimeout = 99999;
                copy.ColumnMappings.Add(0, "YearMonth");
                copy.ColumnMappings.Add(1, "BuildingId");
                copy.ColumnMappings.Add(2, "PaymentType");
                copy.ColumnMappings.Add(3, "PaymentId");
                copy.ColumnMappings.Add(4, "colNo");
                copy.ColumnMappings.Add(5, "ItemLevel");
                copy.ColumnMappings.Add(6, "ParentId");

                copy.WriteToServer(dtTable);
            }
            using (SqlConnection con = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
            {
                con.Open();
                using (SqlCommand cm = new SqlCommand("sp_PaymentMonthReport", con))
                {
                    try
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@BuildingId", building);
                        cm.Parameters.AddWithValue("@Year", drpYear.SelectedValue);

                        cm.Parameters.AddWithValue("@Created", DateTime.Now.ToString("yyyyMMddHHmmss"));
                        cm.Parameters.AddWithValue("@CreatedBy", Page.User.Identity.Name);
                        cm.Parameters.AddWithValue("@Modified", DateTime.Now.ToString("yyyyMMddHHmmss"));
                        cm.Parameters.AddWithValue("@ModifiedBy", Page.User.Identity.Name);

                        cm.CommandTimeout = 9999;

                        int ret = cm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        ApplicationLog.WriteError(ex);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            DataSet ds = new DataSet();
            string sql = string.Empty;

            sql = " SELECT id,YearMonth,BuildingId,PaymentType,isnull(InVND,0) InVND,isnull(InUSD,0) InUSD,isnull(OutVND,0) OutVND,isnull(OutUSD,0) OutUSD,Created,CreatedBy,Modified,ModifiedBy,PaymentId,colNo,bold,ItemLevel,ParentId";
            sql += " FROM BD_PaymentReportMonth ";
            sql += " WHERE BuildingId = '" + building + "' ";
            sql += " order by yearmonth, id";

            using (SqlDatabase db = new SqlDatabase())
            {
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    if (ds != null)
                    {
                        C1XLBook xlbBook = new C1XLBook();

                        string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\BaoCaoThuChiThang.xlsx");
                        if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BaoCaoThuChiThang"))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BaoCaoThuChiThang"));
                        }

                        string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
                        string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BaoCaoThuChiThang\BaoCaoThuChiThang" + strDT + ".xlsx";
                        string strFilePathExport = "Building/" + Func.ParseString(Session["__BUILDINGID__"]) + "/BaoCaoThuChiThang/BaoCaoThuChiThang" + strDT + ".xlsx";

                        string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

                        File.Copy(fileName, fileNameDes);

                        xlbBook.Load(fileNameDes);

                        string sheet = "BaoCao";

                        XLSheet xlsSheet = xlbBook.Sheets[sheet];

                        xlsSheet[0, 2].Value = xlsSheet[0, 2].Value.ToString().Replace("{%TOA_NHA%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + building + "'"));
                        xlsSheet[0, 2].Value = xlsSheet[0, 2].Value.ToString().Replace("{%NAM_THANG%}", "NĂM " + drpYear.SelectedValue);

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
                        decimal inSumVND = 0;
                        decimal outSumVND = 0;

                        DataTable dtReport = ds.Tables[0];
                        foreach (DataRow rowType in dtReport.Rows)
                        {
                            string PaymentType = rowType["PaymentType"].ToString();
                            //string InVND = rowType["InVND"].ToString();
                            //string InUSD = rowType["InUSD"].ToString();
                            //string OutVND = rowType["OutVND"].ToString();
                            //string OutUSD = rowType["OutUSD"].ToString();
                            string PaymentId = rowType["PaymentId"].ToString();
                            int colNo = Func.ParseInt(rowType["colNo"].ToString());
                            string id = rowType["yearmonth"].ToString();
                            string ParentId = rowType["ParentId"].ToString();
                            string itemLevel = rowType["ItemLevel"].ToString();
                            //string PaymentId = rowType["PaymentId"].ToString();
                            //xlsSheet[2, j].Value = id;
                            //xlsSheet[3, j].Value = Budget;
                            //j += 2;
                            XLStyle xlstStyleAll = new XLStyle(xlbBook);
                            xlstStyleAll.WordWrap = false;
                            xlstStyleAll.Font = new Font("", 8, FontStyle.Regular);
                            xlstStyleAll.SetBorderColor(Color.Black);
                            xlstStyleAll.BorderBottom = XLLineStyleEnum.Thin;
                            xlstStyleAll.BorderTop = XLLineStyleEnum.Thin;
                            xlstStyleAll.BorderLeft = XLLineStyleEnum.Thin;
                            xlstStyleAll.BorderRight = XLLineStyleEnum.Thin;
                            xlstStyleAll.Format = "#,##0.00_);(#,##0.00)";

                            XLStyle xlstStyleLeft = new XLStyle(xlbBook);
                            xlstStyleLeft.WordWrap = false;
                            xlstStyleLeft.Font = new Font("", 8, FontStyle.Regular);
                            xlstStyleLeft.SetBorderColor(Color.Black);
                            xlstStyleLeft.BorderBottom = XLLineStyleEnum.Thin;
                            xlstStyleLeft.BorderTop = XLLineStyleEnum.Thin;
                            xlstStyleLeft.BorderLeft = XLLineStyleEnum.Thin;
                            xlstStyleLeft.Format = "#,##0.00_);(#,##0.00)";

                            XLStyle xlstStyleRight = new XLStyle(xlbBook);
                            xlstStyleRight.WordWrap = false;
                            xlstStyleRight.Font = new Font("", 8, FontStyle.Regular);
                            xlstStyleRight.SetBorderColor(Color.Black);
                            xlstStyleRight.BorderBottom = XLLineStyleEnum.Thin;
                            xlstStyleRight.BorderTop = XLLineStyleEnum.Thin;
                            xlstStyleRight.BorderRight = XLLineStyleEnum.Thin;
                            xlstStyleRight.Format = "#,##0.00_);(#,##0.00)";

                            XLStyle xlstStyleMiddle = new XLStyle(xlbBook);
                            xlstStyleMiddle.WordWrap = false;
                            xlstStyleMiddle.Font = new Font("", 8, FontStyle.Regular);
                            xlstStyleMiddle.SetBorderColor(Color.Black);
                            xlstStyleMiddle.BorderBottom = XLLineStyleEnum.Thin;
                            xlstStyleMiddle.BorderTop = XLLineStyleEnum.Thin;
                            xlstStyleMiddle.Format = "#,##0.00_);(#,##0.00)";

                            xlsSheet[k, 2].Style = xlstStyleLeft;
                            xlsSheet[k, 3].Style = xlstStyleMiddle;
                            xlsSheet[k, 4].Style = xlstStyleMiddle;
                            xlsSheet[k, 5].Style = xlstStyleMiddle;
                            xlsSheet[k, 6].Style = xlstStyleRight;

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

                            if (!bsId.Equals(id))
                            {
                                if (k > 5)
                                {
                                    lastrow = k;
                                    xlsSheet[k, 2].Value = alpha[level1 + 1];
                                    xlsSheet[k, 3].Value = "CÂN ĐỐI THU - CHI (Phần Lãi)";
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
                            xlsSheet[k, colData].Value = rowType["InVND"];
                            xlsSheet[k, 0].Value = PaymentId;

                            if (PaymentId.Equals("9"))
                            {
                                inSumVND = Convert.ToDecimal(rowType["InVND"]);
                            }
                            else if (PaymentId.Equals("10"))
                            {
                                outSumVND = Convert.ToDecimal(rowType["InVND"]);
                            }

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
                                xlstStyleLast.Format = "#,##0.00_);(#,##0.00)";

                                xlsSheet[k, colData].Value = inSumVND - outSumVND;
                                xlsSheet[k, colData].Style = xlstStyleLast;
                            }
                        }
                        xlbBook.Save(fileNameDes);
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);
                    }
                }
            }
        }
    }
}
