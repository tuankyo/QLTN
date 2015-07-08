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
    public partial class BuidingMaintenanceReport : PageBase
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

                for (int i = 2010; i < 2050; i++)
                {
                    drpYearTo.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i), Func.ParseString(i)));
                }
                drpYearTo.Items.FindByValue(DateTime.Now.ToString("yyyy")).Selected = true;

                for (int i = 1; i < 13; i++)
                {
                    drpMonthTo.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
                }
                drpMonthTo.Items.FindByValue(DateTime.Now.ToString("MM")).Selected = true;
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
            string type = Func.ParseString(Request["type"]);

            DataSet ds = new DataSet();
            string sql = string.Empty;

            //sql = " SELECT *";
            //sql += " FROM v_BuildingStatusInfo";
            //sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and StatusDate >= '" + Func.FormatYYYYmmdd(txtFromDate.Text.Substring(0, 10)) + "' and StatusDate <= '" + Func.FormatYYYYmmdd(txtToDate.Text.Substring(0, 10)) + "' and Type = '" + type + "'";

            sql = "  SELECT  right('0'+convert(varchar,[Month]),2) + '/' + convert(varchar,[Year]),[Week],MainName,SubName";
            sql += " ,dbo.fnDateTime(ExecDate),ExecCompany,ExecDescription,ExecComment,ExecConfirmer,ModifiedBy,dbo.fnDateTime(Modified)";
            sql += " FROM BD_Maintenance ";
            sql += " WHERE    BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' ";
            sql += " and  convert(varchar,[Year]) + right('0'+convert(varchar,[Month]),2) >= '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";
            sql += " and  convert(varchar,[Year]) + right('0'+convert(varchar,[Month]),2) <= '" + drpYearTo.SelectedValue + drpMonthTo.SelectedValue + "'";
            sql += " and DelFlag = '0'  ";
            sql += " and UPPER(IsMaintenance) = 'X'  ";
            sql += " Order by  right('0'+convert(varchar,[Month]),2) + '/' + convert(varchar,[Year]), MainName, SubName,Week ";

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
                        string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\KeHoachBaoTri.xlsx");
                        if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\KeHoachBaoTri"))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\KeHoachBaoTri"));
                        }
                        string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");

                        string strFilePath = "";
                        string strFilePathExport = "";

                        strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\KeHoachBaoTri\KeHoachBaoTri" + strDT + ".xlsx";
                        strFilePathExport = "Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + "/KeHoachBaoTri/KeHoachBaoTri" + strDT + ".xlsx";

                        string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);
                        File.Copy(fileName, fileNameDes);

                        xlbBook.Load(fileNameDes);
                        string sheet = "KeHoachBaoTri";

                        XLSheet xlsSheet = xlbBook.Sheets[sheet];

                        int i = 3;
                        XLCellRange mrCell = new XLCellRange(0, 0, 0, 2);
                        xlsSheet.MergedCells.Add(mrCell);

                        XLStyle xlstStyle = new XLStyle(xlbBook);
                        xlstStyle.AlignHorz = XLAlignHorzEnum.Center;
                        xlstStyle.AlignVert = XLAlignVertEnum.Center;
                        xlstStyle.WordWrap = true;
                        xlstStyle.Font = new Font("", 8, FontStyle.Regular);
                        xlstStyle.SetBorderColor(Color.Black);
                        xlstStyle.BorderBottom = XLLineStyleEnum.Thin;
                        xlstStyle.BorderTop = XLLineStyleEnum.Thin;
                        xlstStyle.BorderLeft = XLLineStyleEnum.Thin;
                        xlstStyle.BorderRight = XLLineStyleEnum.Thin;

                        XLStyle xlstStyleB = new XLStyle(xlbBook);
                        xlstStyleB.AlignHorz = XLAlignHorzEnum.Left;
                        xlstStyleB.AlignVert = XLAlignVertEnum.Top;
                        xlstStyleB.WordWrap = false;
                        xlstStyleB.Font = new Font("", 8, FontStyle.Regular);
                        xlstStyleB.SetBorderColor(Color.Black);
                        xlstStyleB.BorderBottom = XLLineStyleEnum.Thin;
                        xlstStyleB.BorderTop = XLLineStyleEnum.Thin;
                        xlstStyleB.BorderLeft = XLLineStyleEnum.Thin;
                        xlstStyleB.BorderRight = XLLineStyleEnum.Thin;

                        xlsSheet[0, 0].Value = xlsSheet[0, 0].Value.ToString().Replace("{%BUILDING%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'"));
                        string tmp = Func.ParseString( xlsSheet[1, 0].Value);
                        tmp = tmp.Replace("{%NAM%}", drpYear.SelectedValue);
                        tmp = tmp.Replace("{%THANG%}", drpMonth.SelectedValue);
                        tmp = tmp.Replace("{%NAM_TO%}", drpYearTo.SelectedValue);
                        tmp = tmp.Replace("{%THANG_TO%}", drpMonthTo.SelectedValue);
                        xlsSheet[1, 0].Value = tmp;

                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            string col01 = rowType[0].ToString();
                            string col02 = rowType[1].ToString();
                            string col03 = rowType[2].ToString();
                            string col04 = rowType[3].ToString();
                            string col05 = rowType[4].ToString();
                            string col06 = rowType[5].ToString();
                            string col07 = rowType[6].ToString();
                            string col08 = rowType[7].ToString();
                            string col09 = rowType[8].ToString();
                            string col10 = rowType[9].ToString();
                            string col11 = rowType[10].ToString();

                            xlsSheet[i, 0].Value = col01;
                            xlsSheet[i, 1].Value = col02;
                            xlsSheet[i, 2].Value = col03;
                            xlsSheet[i, 3].Value = col04;
                            xlsSheet[i, 4].Value = col05;
                            xlsSheet[i, 5].Value = col06;
                            xlsSheet[i, 6].Value = col07;
                            xlsSheet[i, 7].Value = col08;
                            xlsSheet[i, 8].Value = col09;
                            xlsSheet[i, 9].Value = col10;
                            xlsSheet[i, 10].Value = col11;

                            xlsSheet[i, 0].Style = xlstStyle;
                            xlsSheet[i, 1].Style = xlstStyleB;
                            xlsSheet[i, 2].Style = xlstStyleB;
                            xlsSheet[i, 3].Style = xlstStyleB;
                            xlsSheet[i, 4].Style = xlstStyleB;
                            xlsSheet[i, 5].Style = xlstStyleB;
                            xlsSheet[i, 6].Style = xlstStyleB;
                            xlsSheet[i, 7].Style = xlstStyleB;
                            xlsSheet[i, 8].Style = xlstStyleB;
                            xlsSheet[i, 9].Style = xlstStyleB;
                            xlsSheet[i, 10].Style = xlstStyleB;
                            xlsSheet[i, 11].Style = xlstStyleB;
                            ++i;
                        }

                        ////ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('/CSV/DownloadZipFile.aspx'," + PopupWidth + "," + PopupHeight + ",'EditFlat', true);", true);

                        ////xlsSheet[i++, 0].Value = "Ghi chú:";
                        //DataSet ds1 = new DataSet();
                        //sql = string.Empty;

                        //sql = " SELECT *";
                        //sql += " FROM BD_WorkingHour";
                        //sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and DelFlag <> 1";
                        //sql += " Order By Name";

                        //using (SqlCommand cm1 = db.CreateCommand(sql))
                        //{
                        //    SqlDataAdapter da1 = new SqlDataAdapter(cm1);
                        //    da1.Fill(ds1);
                        //    db.Close();

                        //    if (ds != null)
                        //    {

                        //        xlsSheet[i++ + 1, 0].Value = "Ghi chú:";
                        //        DataTable dt1 = ds1.Tables[0];
                        //        foreach (DataRow rowType in dt1.Rows)
                        //        {
                        //            i++;
                        //            string Ma = rowType["WorkingHourId"].ToString();
                        //            string Name = rowType["Name"].ToString();
                        //            xlsSheet[i, 0].Value = Ma + ":";
                        //            xlsSheet[i, 1].Value = Name;
                        //        }
                        //        xlsSheet[i + 1, 0].Value = "OF:";
                        //        xlsSheet[i + 1, 1].Value = "OF: nghỉ";
                        //    }
                        //}
                        //string dataPath = HttpContext.Current.Server.MapPath(@"\Building\Staff\DataTmp");
                        //string tmpFolder = dataPath;
                        //if (!Directory.Exists(tmpFolder))
                        //{
                        //    Directory.CreateDirectory(tmpFolder);
                        //}
                        //string name = "KhaiBaoLichLamViec_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                        //string fileName = Path.Combine(tmpFolder, name);
                        //                        string fileNameDes = HttpContext.Current.Server.MapPath(@"\Report\Template\THSLXT_tpl_1.xlsx");

                        xlbBook.Save(fileNameDes);
                        //Session["ZipFilePath"] = null;
                        //Session["ZipFilePath"] = fileName;

                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('../" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);

                    }
                }
            }
        }
    }
}
