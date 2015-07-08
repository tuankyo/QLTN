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
    public partial class BuidingRoomInfo : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            sql += " FROM vBuildingRoomInfo";
            sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' ";

            using (SqlDatabase db = new SqlDatabase())
            {
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    db.Close();

                    string selectDate = Func.FormatYYYYmmdd(txtDate.Text);
                    if (ds != null)
                    {
                        C1XLBook xlbBook = new C1XLBook();
                        string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\TongHopDienTichTrong.xls");
                        if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])));
                        }

                        string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
                        string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\TongHopDienTich" + strDT + ".xls";
                        string strFilePathExport = "Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + "/TongHopDienTich" + strDT + ".xls";

                        string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

                        //string fileNameDes = HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\TongHopDienTich" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
                        File.Copy(fileName, fileNameDes);

                        xlbBook.Load(fileNameDes);
                        XLSheet xlsSheet = xlbBook.Sheets["TongHop"];
                        //xlsSheet.Name = drpMonth.SelectedValue + "_" + drpYear.SelectedValue;

                        int i = 4;
                        XLCellRange mrCell = new XLCellRange(0, 0, 0, 2);
                        xlsSheet.MergedCells.Add(mrCell);

                        XLStyle xlstStyle = new XLStyle(xlbBook);
                        xlstStyle.AlignHorz = XLAlignHorzEnum.Center;
                        xlstStyle.Font = new Font("", 12, FontStyle.Bold);
                        xlstStyle.SetBorderColor(Color.Black);

                        XLStyle xlstStyle01 = new XLStyle(xlbBook);
                        xlstStyle01.AlignHorz = XLAlignHorzEnum.Center;
                        xlstStyle01.Font = new Font("", 10, FontStyle.Bold);
                        xlstStyle.SetBorderColor(Color.Black);

                        xlsSheet[1, 0].Value = xlsSheet[1, 0].Value.ToString().Replace("{%BUILDING%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'"));
                        xlsSheet[0, 0].Value = xlsSheet[0, 0].Value.ToString().Replace("{%NGAY%}", txtDate.Text);

                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            string col01 = rowType[0].ToString();
                            string col02 = rowType[1].ToString();
                            string col03 = rowType[2].ToString();
                            string col04 = rowType[3].ToString();
                            string col05 = rowType[4].ToString();
                            string col06 = rowType[5].ToString();

                            xlsSheet[i, 0].Value = col02;
                            xlsSheet[i, 1].Value = col03;
                            xlsSheet[i, 2].Value = col04;
                            xlsSheet[i, 3].Value = col05;
                            xlsSheet[i, 4].Value = DbHelper.GetScalar("Select sum(Area) from vRentRoom Where BuildingId = '" + col01 + "' and Regional ='" + col02 + "' and Floor = '" + col03 + "' and (BeginContract <= '" + selectDate + "' and (EndContract >= '" + selectDate + "' or EndContract is null))");
                            xlsSheet[i, 5].Value = col05;

                            xlsSheet[i, 0].Style = xlstStyle01;
                            xlsSheet[i, 1].Style = xlstStyle01;
                            xlsSheet[i, 2].Style = xlstStyle01;
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
