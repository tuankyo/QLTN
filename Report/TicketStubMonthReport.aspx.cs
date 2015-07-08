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
using Gnt.Utils.FastCsv;

namespace Man.Report
{
    public partial class TicketStubMonthReport : PageBase
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

                for (int i = 1; i < 13; i++)
                {
                    drpMonth.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
                }
                drpMonth.Items.FindByValue(DateTime.Now.AddMonths(-1).ToString("MM")).Selected = true;
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
        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string sql = string.Empty;

            sql = " SELECT *";
            sql += " FROM v_TicketStubs";
            sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' ";
            sql += " AND (ReceiveDate is not null and substring(ReceiveDate,1,6) >= '" + drpYear.SelectedValue + drpMonth.SelectedValue + "')";

            using (SqlDatabase db = new SqlDatabase())
            {
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    db.Close();

                    if (ds != null)
                    {
                        C1XLBook xlbBook = new C1XLBook();
                        string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\ThongTinVeXeLuot.xls");
                        if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\ThongTinVeXeLuot"))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\ThongTinVeXeLuot"));
                        }

                        string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
                        string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\ThongTinVeXeLuot\ThongTinVeXeLuot" + strDT + ".xls";
                        string strFilePathExport = "Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + "/ThongTinVeXeLuot/ThongTinVeXeLuot" + strDT + ".xls";

                        string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

                        File.Copy(fileName, fileNameDes);

                        xlbBook.Load(fileNameDes);
                        XLSheet xlsSheet = xlbBook.Sheets["BaoCao"];

                        int i = 3;
                        XLCellRange mrCell = new XLCellRange(0, 0, 0, 2);
                        xlsSheet.MergedCells.Add(mrCell);

                        XLStyle xlstStyle = new XLStyle(xlbBook);
                        //xlstStyle.AlignHorz = XLAlignHorzEnum.Left;
                        xlstStyle.AlignVert = XLAlignVertEnum.Top;
                        xlstStyle.WordWrap = true;
                        xlstStyle.Font = new Font("", 8, FontStyle.Regular);
                        xlstStyle.SetBorderColor(Color.Black);
                        xlstStyle.BorderBottom = XLLineStyleEnum.Thin;
                        xlstStyle.BorderTop = XLLineStyleEnum.Thin;
                        xlstStyle.BorderLeft = XLLineStyleEnum.Thin;
                        xlstStyle.BorderRight = XLLineStyleEnum.Thin;
                        xlstStyle.Format = "#,##0.00_);(#,##0.00)";

                        XLStyle xlstStyle01 = new XLStyle(xlbBook);
                        xlstStyle01.AlignHorz = XLAlignHorzEnum.Center;
                        xlstStyle01.AlignVert = XLAlignVertEnum.Top;
                        xlstStyle01.WordWrap = true;
                        xlstStyle01.Font = new Font("", 8, FontStyle.Regular);
                        xlstStyle01.SetBorderColor(Color.Black);
                        xlstStyle01.BorderBottom = XLLineStyleEnum.Thin;
                        xlstStyle01.BorderTop = XLLineStyleEnum.Thin;
                        xlstStyle01.BorderLeft = XLLineStyleEnum.Thin;
                        xlstStyle01.BorderRight = XLLineStyleEnum.Thin;

                        xlsSheet[1, 0].Value = xlsSheet[1, 0].Value.ToString().Replace("{%TOA_NHA%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'"));
                        xlsSheet[1, 0].Value = xlsSheet[1, 0].Value.ToString().Replace("{%THANG%}", drpMonth.SelectedValue+"/"+drpYear.SelectedValue);

                        string seriTmp = "";
                        decimal remainTmp = 0;
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            
                            string col01 = rowType[0].ToString();
                            string col02 = rowType[1].ToString();
                            string col03 = Func.FormatDMY(rowType[2].ToString());
                            string col04 = rowType[3].ToString();
                            string col05 = rowType[4].ToString();
                            string col06 = Func.FormatDMY(rowType[5].ToString());
                            string col07 = rowType[6].ToString();
                            string col08 = rowType[7].ToString();
                            string col09 = rowType[8].ToString();
                            string col10 = rowType[9].ToString();
                            string col11 = rowType[10].ToString();
                            string col12 = rowType[11].ToString();
                            string col13 = rowType[12].ToString();

                            if (!seriTmp.Equals(col01))
                            {
                                xlsSheet[i, 0].Value = col01;
                                xlsSheet[i, 1].Value = rowType[1];
                                xlsSheet[i, 2].Value = col03;
                                xlsSheet[i, 3].Value = col04;
                                xlsSheet[i, 4].Value = col05;

                                xlsSheet[i, 0].Style = xlstStyle;
                                xlsSheet[i, 1].Style = xlstStyle;
                                xlsSheet[i, 2].Style = xlstStyle;
                                xlsSheet[i, 3].Style = xlstStyle;
                                xlsSheet[i, 4].Style = xlstStyle;

                                int remain = Func.ParseInt(col02) - Func.ParseInt(col09);
                                remainTmp = remain;
                                xlsSheet[i, 11].Value = remain;

                                seriTmp = col01;
                            }
                            else {
                                remainTmp -= Convert.ToDecimal(col09);
                                xlsSheet[i, 11].Value = remainTmp;
                            }

                            xlsSheet[i, 5].Value = col06;
                            xlsSheet[i, 6].Value = col07;
                            xlsSheet[i, 7].Value = col08;
                            xlsSheet[i, 8].Value = rowType[8];
                            xlsSheet[i, 9].Value = rowType[9];
                            xlsSheet[i, 10].Value = rowType[10];
                            xlsSheet[i,12].Value = col13;

                            xlsSheet[i, 5].Style = xlstStyle;
                            xlsSheet[i, 6].Style = xlstStyle;
                            xlsSheet[i, 7].Style = xlstStyle;
                            xlsSheet[i, 8].Style = xlstStyle;
                            xlsSheet[i, 9].Style = xlstStyle;
                            xlsSheet[i, 10].Style = xlstStyle;
                            xlsSheet[i, 11].Style = xlstStyle;
                            xlsSheet[i, 12].Style = xlstStyle;
                            ++i;
                        }

                        xlbBook.Save(fileNameDes);
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('../" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);

                    }
                }
            }
        }
    }
}
