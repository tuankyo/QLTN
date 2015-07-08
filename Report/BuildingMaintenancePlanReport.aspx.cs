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
    public partial class BuildingMaintenancePlanReport : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int i = 2010; i < 2050; i++)
                {
                    drpYear.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i), Func.ParseString(i)));
                }
                drpYear.Items.FindByValue(DateTime.Now.AddMonths(-3).ToString("yyyy")).Selected = true;

                for (int i = 1; i < 13; i++)
                {
                    drpMonth.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
                }
                drpMonth.Items.FindByValue(DateTime.Now.AddMonths(-3).ToString("MM")).Selected = true;


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
            DataSet ds = new DataSet();
            string sql = string.Empty;

            sql = " SELECT *";
            sql += " FROM Report_BuildingInfo where id = 40";

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
                        xlstStyle.AlignHorz = XLAlignHorzEnum.Center;
                        xlstStyle.WordWrap = true;
                        xlstStyle.Font = new Font("", 8, FontStyle.Regular);
                        xlstStyle.SetBorderColor(Color.Black);
                        xlstStyle.BorderBottom = XLLineStyleEnum.Thin;
                        xlstStyle.BorderTop = XLLineStyleEnum.Thin;
                        xlstStyle.BorderLeft = XLLineStyleEnum.Thin;
                        xlstStyle.BorderRight = XLLineStyleEnum.Thin;

                        string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\DinhKyBaoTri.xlsx");
                        if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])));
                        }

                        string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
                        string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\DinhKyBaoTri" + strDT + ".xlsx";
                        string strFilePathExport = "Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + "/DinhKyBaoTri" + strDT + ".xlsx";

                        string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

                        //string fileNameDes = HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\TongHopDienTich" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx");
                        File.Copy(fileName, fileNameDes);

                        xlbBook.Load(fileNameDes);

                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            int stt = 0;
                            string id = rowType["id"].ToString();
                            string sheet = "Report";
                            int NumOfCol = Func.ParseInt(rowType["NoOfColumn"].ToString());
                            string SqlSelect = rowType["SqlSelect"].ToString();
                            SqlSelect = SqlSelect.Replace("{%TU_NAM_THANG%}", drpYear.SelectedValue + drpMonth.SelectedValue);
                            SqlSelect = SqlSelect.Replace("{%DEN_NAM_THANG%}", drpYearTo.SelectedValue + drpMonthTo.SelectedValue);

                            SqlSelect = SqlSelect.Replace("{%TOA_NHA%}", Func.ParseString(Session["__BUILDINGID__"]));
                            int CellY = Func.ParseInt(rowType["CellBeginY"].ToString());
                            int CellX = Func.ParseInt(rowType["CellBeginX"].ToString());

                            using (SqlCommand cmSheet = db.CreateCommand(SqlSelect))
                            {
                                DataSet dsSheet = new DataSet();
                                SqlDataAdapter daSheet = new SqlDataAdapter(cmSheet);
                                daSheet.Fill(dsSheet);
                                if (dsSheet != null)
                                {
                                    XLSheet xlsSheet = xlbBook.Sheets[sheet];

                                    DataTable dtSheet = dsSheet.Tables[0];
                                    foreach (DataRow rowSheet in dtSheet.Rows)
                                    {
                                        xlsSheet[CellY + stt, CellX].Style = xlstStyle;
                                        xlsSheet[CellY + stt, CellX].Value = ++stt;

                                        for (int k = 0; k < NumOfCol; k++)
                                        {
                                            string tmp = rowSheet[k].ToString();
                                            switch (rowSheet[k].GetType().Name)
                                            {
                                                case "Decimal":
                                                    xlsSheet[CellY + stt - 1, CellX + k + 1].Value = Func.ParseDouble(tmp);
                                                    break;

                                                case "Double":
                                                    xlsSheet[CellY + stt - 1, CellX + k + 1].Value = Func.ParseDouble(tmp);

                                                    break;
                                                case "Int32":
                                                    xlsSheet[CellY + stt - 1, CellX + k + 1].Value = Func.ParseInt(tmp);

                                                    break;
                                                case "Single":
                                                    xlsSheet[CellY + stt - 1, CellX + k + 1].Value = Func.ParseInt(tmp);
                                                    break;
                                                default:
                                                    xlsSheet[CellY + stt - 1, CellX + k + 1].Value = tmp;
                                                    break;
                                            }
                                            //xlsSheet[CellY + stt - 1, CellX + k + 1].Value = tmp;
                                            xlsSheet[CellY + stt - 1, CellX + k + 1].Style = xlstStyle;
                                        }
                                    }
                                }
                            }
                            //xlsSheet.Name = drpMonth.SelectedValue + "_" + drpYear.SelectedValue;

                            //int i = 4;
                            //XLCellRange mrCell = new XLCellRange(0, 0, 0, 2);
                            //xlsSheet.MergedCells.Add(mrCell);

                            //XLStyle xlstStyle = new XLStyle(xlbBook);
                            //xlstStyle.AlignHorz = XLAlignHorzEnum.Center;
                            //xlstStyle.WordWrap = true;
                            //xlstStyle.Font = new Font("", 8, FontStyle.Regular);
                            //xlstStyle.SetBorderColor(Color.Black);
                            //xlstStyle.BorderBottom = XLLineStyleEnum.Thin;
                            //xlstStyle.BorderTop = XLLineStyleEnum.Thin;
                            //xlstStyle.BorderLeft = XLLineStyleEnum.Thin;
                            //xlstStyle.BorderRight = XLLineStyleEnum.Thin;

                            //XLStyle xlstStyle01 = new XLStyle(xlbBook);
                            //xlstStyle01.AlignHorz = XLAlignHorzEnum.Center;
                            //xlstStyle01.Font = new Font("", 10, FontStyle.Bold);
                            //xlstStyle.SetBorderColor(Color.Black);

                            //xlsSheet[1, 0].Value = xlsSheet[1, 0].Value.ToString().Replace("{%TOA_NHA%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'"));
                            //xlsSheet[0, 0].Value = xlsSheet[0, 0].Value.ToString().Replace("{%THANG%}", drpMonth.SelectedValue + "/" + drpYear.SelectedValue);

                            //xlsSheet[i, 0].Value = ++stt;
                            //xlsSheet[i, 1].Value = col03;
                            //xlsSheet[i, 2].Value = col04;
                            //xlsSheet[i, 3].Value = col05;
                            //xlsSheet[i, 4].Value = col06;
                            //xlsSheet[i, 5].Value = col07;
                            //xlsSheet[i, 6].Value = col08;
                            //xlsSheet[i, 7].Value = col09;

                            //xlsSheet[i, 0].Style = xlstStyle;
                            //xlsSheet[i, 1].Style = xlstStyle;
                            //xlsSheet[i, 2].Style = xlstStyle;
                            //xlsSheet[i, 3].Style = xlstStyle;
                            //xlsSheet[i, 4].Style = xlstStyle;
                            //xlsSheet[i, 5].Style = xlstStyle;
                            //xlsSheet[i, 6].Style = xlstStyle;
                            //xlsSheet[i, 7].Style = xlstStyle;
                            //++i;
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
                        //string name = "KhaiBaoLichLamViec_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx";
                        //string fileName = Path.Combine(tmpFolder, name);
                        //                        string fileNameDes = HttpContext.Current.Server.MapPath(@"\Report\Template\THSLXT_tpl_1.xlsxx");
                        xlbBook.Save(fileNameDes);
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('../" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);

                    }
                }
            }
        }
    }
}
