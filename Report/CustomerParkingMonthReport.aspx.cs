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
    public partial class CustomerParkingMonthReport : PageBase
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
            C1XLBook xlbBook = new C1XLBook();
            string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\GuixeThang.xlsx");
            if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\GuixeThang"))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\GuixeThang"));
            }

            string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\GuixeThang\GuiXeThang" + strDT + ".xlsx";
            string strFilePathExport = "Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + "/GuixeThang/GuiXeThang" + strDT + ".xlsx";

            string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

            File.Copy(fileName, fileNameDes);

            xlbBook.Load(fileNameDes);

            sql = " SELECT *";
            sql += " FROM v_GuiXeThang";
            sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' ";
            sql += " AND substring(NgayGui,1,6) <= '" + drpYear.SelectedValue + drpMonth.SelectedValue + "' AND ((NgayKetThuc is null) OR ";
            sql += "      (NgayKetThuc is not null and rtrim(LTRIM(NgayKetThuc)) <> '' and substring(NgayKetThuc,1,6) >= '" + drpYear.SelectedValue + drpMonth.SelectedValue + "')) Order by CustomerId";

            string[] sheetName = { "Oto", "XeMay", "XeDap", "Oto_HetHD", "XeMay_HetHD", "XeDap_HetHD" };
            int[] lines = { 4, 4, 4, 4, 4, 4 };

            using (SqlDatabase db = new SqlDatabase())
            {
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    db.Close();

                    if (ds != null)
                    {
                        int i = 4;
                        XLCellRange mrCell = new XLCellRange(0, 0, 0, 2);

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

                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            XLSheet xlsSheet = xlbBook.Sheets[sheetName[Func.ParseInt(rowType[10]) - 1]];

                            string col01 = rowType[0].ToString();
                            string col02 = rowType[1].ToString();
                            string col03 = rowType[2].ToString();
                            string col04 = rowType[3].ToString();
                            string col05 = rowType[4].ToString();
                            string col06 = rowType[5].ToString();
                            string col07 = Func.FormatDMY(rowType[6].ToString());
                            string col08 = Func.FormatDMY(rowType[7].ToString());
                            string col09 = rowType[8].ToString();

                            i = lines[Func.ParseInt(rowType[10]) - 1];

                            xlsSheet[i, 0].Value = i - 3;
                            xlsSheet[i, 1].Value = col03;
                            xlsSheet[i, 2].Value = col04;
                            xlsSheet[i, 3].Value = col05;
                            xlsSheet[i, 4].Value = col06;
                            xlsSheet[i, 5].Value = col07;
                            xlsSheet[i, 6].Value = col08;
                            xlsSheet[i, 7].Value = col09;

                            xlsSheet[i, 0].Style = xlstStyle01;
                            xlsSheet[i, 1].Style = xlstStyle;
                            xlsSheet[i, 2].Style = xlstStyle;
                            xlsSheet[i, 3].Style = xlstStyle01;
                            xlsSheet[i, 4].Style = xlstStyle;
                            xlsSheet[i, 5].Style = xlstStyle01;
                            xlsSheet[i, 6].Style = xlstStyle01;
                            xlsSheet[i, 7].Style = xlstStyle;
                            //++i;
                            lines[Func.ParseInt(rowType[10]) - 1]++;
                        }
                    }


                }
            }
            ///////////////////////////////////////
            sql = " SELECT *";
            sql += " FROM v_GuiXeThang";
            sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' ";
            sql += " AND ((substring(NgayGui,1,6) > '" + drpYear.SelectedValue + drpMonth.SelectedValue + "') OR ";
            sql += "      (NgayKetThuc is not null and rtrim(LTRIM(NgayKetThuc)) <> '' and substring(NgayKetThuc,1,6) < '" + drpYear.SelectedValue + drpMonth.SelectedValue + "')) Order by CustomerId";

            ds = new DataSet();
            using (SqlDatabase db = new SqlDatabase())
            {
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    db.Close();

                    if (ds != null)
                    {
                        int i = 4;
                        XLCellRange mrCell = new XLCellRange(0, 0, 0, 2);
                        //xlsSheet.MergedCells.Add(mrCell);

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

                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            XLSheet xlsSheet = xlbBook.Sheets[sheetName[Func.ParseInt(rowType[10]) + 2]];

                            string col01 = rowType[0].ToString();
                            string col02 = rowType[1].ToString();
                            string col03 = rowType[2].ToString();
                            string col04 = rowType[3].ToString();
                            string col05 = rowType[4].ToString();
                            string col06 = rowType[5].ToString();
                            string col07 = Func.FormatDMY(rowType[6].ToString());
                            string col08 = Func.FormatDMY(rowType[7].ToString());
                            string col09 = rowType[8].ToString();

                            i = lines[Func.ParseInt(rowType[10]) + 2];

                            xlsSheet[i, 0].Value = i - 3;
                            xlsSheet[i, 1].Value = col03;
                            xlsSheet[i, 2].Value = col04;
                            xlsSheet[i, 3].Value = col05;
                            xlsSheet[i, 4].Value = col06;
                            xlsSheet[i, 5].Value = col07;
                            xlsSheet[i, 6].Value = col08;
                            xlsSheet[i, 7].Value = col09;

                            xlsSheet[i, 0].Style = xlstStyle01;
                            xlsSheet[i, 1].Style = xlstStyle;
                            xlsSheet[i, 2].Style = xlstStyle;
                            xlsSheet[i, 3].Style = xlstStyle01;
                            xlsSheet[i, 4].Style = xlstStyle;
                            xlsSheet[i, 5].Style = xlstStyle01;
                            xlsSheet[i, 6].Style = xlstStyle01;
                            xlsSheet[i, 7].Style = xlstStyle;
                            lines[Func.ParseInt(rowType[10]) + 2]++;
                        }
                    }


                }
            }
            ///////////////////////////////////////

            XLSheet sheet = xlbBook.Sheets["OTo"];
            sheet[1, 0].Value = sheet[1, 0].Value.ToString().Replace("{%TOA_NHA%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'"));
            sheet[0, 0].Value = sheet[0, 0].Value.ToString().Replace("{%THANG%}", drpMonth.SelectedValue + "/" + drpYear.SelectedValue);

            sheet = xlbBook.Sheets["OTo"];
            sheet[1, 0].Value = sheet[1, 0].Value.ToString().Replace("{%TOA_NHA%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'"));
            sheet[0, 0].Value = sheet[0, 0].Value.ToString().Replace("{%THANG%}", drpMonth.SelectedValue + "/" + drpYear.SelectedValue);

            sheet = xlbBook.Sheets["OTo"];
            sheet[1, 0].Value = sheet[1, 0].Value.ToString().Replace("{%TOA_NHA%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'"));
            sheet[0, 0].Value = sheet[0, 0].Value.ToString().Replace("{%THANG%}", drpMonth.SelectedValue + "/" + drpYear.SelectedValue);

            sheet = xlbBook.Sheets["OTo"];
            sheet[1, 0].Value = sheet[1, 0].Value.ToString().Replace("{%TOA_NHA%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'"));
            sheet[0, 0].Value = sheet[0, 0].Value.ToString().Replace("{%THANG%}", drpMonth.SelectedValue + "/" + drpYear.SelectedValue);

            sheet = xlbBook.Sheets["OTo"];
            sheet[1, 0].Value = sheet[1, 0].Value.ToString().Replace("{%TOA_NHA%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'"));
            sheet[0, 0].Value = sheet[0, 0].Value.ToString().Replace("{%THANG%}", drpMonth.SelectedValue + "/" + drpYear.SelectedValue);

            sheet = xlbBook.Sheets["XeMay"];
            sheet[1, 0].Value = sheet[1, 0].Value.ToString().Replace("{%TOA_NHA%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'"));
            sheet[0, 0].Value = sheet[0, 0].Value.ToString().Replace("{%THANG%}", drpMonth.SelectedValue + "/" + drpYear.SelectedValue);

            sheet = xlbBook.Sheets["XeDap"];
            sheet[1, 0].Value = sheet[1, 0].Value.ToString().Replace("{%TOA_NHA%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'"));
            sheet[0, 0].Value = sheet[0, 0].Value.ToString().Replace("{%THANG%}", drpMonth.SelectedValue + "/" + drpYear.SelectedValue);

            sheet = xlbBook.Sheets["OTo_HetHD"];
            sheet[1, 0].Value = sheet[1, 0].Value.ToString().Replace("{%TOA_NHA%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'"));
            sheet[0, 0].Value = sheet[0, 0].Value.ToString().Replace("{%THANG%}", drpMonth.SelectedValue + "/" + drpYear.SelectedValue);

            sheet = xlbBook.Sheets["XeMay_HetHD"];
            sheet[1, 0].Value = sheet[1, 0].Value.ToString().Replace("{%TOA_NHA%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'"));
            sheet[0, 0].Value = sheet[0, 0].Value.ToString().Replace("{%THANG%}", drpMonth.SelectedValue + "/" + drpYear.SelectedValue);

            sheet = xlbBook.Sheets["XeDap_HetHD"];
            sheet[1, 0].Value = sheet[1, 0].Value.ToString().Replace("{%TOA_NHA%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'"));
            sheet[0, 0].Value = sheet[0, 0].Value.ToString().Replace("{%THANG%}", drpMonth.SelectedValue + "/" + drpYear.SelectedValue);
            xlbBook.Save(fileNameDes);
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('../" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);

        }
    }
}
