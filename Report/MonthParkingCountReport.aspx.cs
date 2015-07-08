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
    public partial class MonthParkingCountReport : PageBase
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
            sql += " FROM v_MonthParkingCount";
            sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' ";
            sql += " Order By CompanyName";

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
                        string fileName = HttpContext.Current.Server.MapPath(@"\Report\Template\THSLXT_tpl.xlsx");

                        xlbBook.Load(fileName);
                        XLSheet xlsSheet = xlbBook.Sheets["DANH SÁCH BẢO VỆ"];
                        //xlsSheet.Name = drpMonth.SelectedValue + "_" + drpYear.SelectedValue;

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
                            //xlsSheet[i, 2 + j].Value = j;
                            //DateTime date = new DateTime(Func.ParseInt(drpYear.SelectedValue), Func.ParseInt(drpMonth.SelectedValue), j);
                            //xlsSheet[i + 1, 2 + j].Value = dictionary[date.DayOfWeek.ToString().ToLower()];

                            //xlsSheet[i, 2 + j].Style = xlstStyle01;
                            //xlsSheet[i + 1, 2 + j].Style = xlstStyle01;
                            //if (j == DateTime.DaysInMonth(Func.ParseInt(drpYear.SelectedValue), Func.ParseInt(drpMonth.SelectedValue)))
                            //{
                            //    break;
                            //}
                        }

                        //i++;
                        //DataTable dt = ds.Tables[0];
                        //foreach (DataRow rowType in dt.Rows)
                        //{
                        //    int No = i;
                        //    i++;
                        //    string StaffId = rowType["StaffId"].ToString();
                        //    string Name = rowType["Name"].ToString();

                        //    xlsSheet[i, 0].Value = No;
                        //    xlsSheet[i, 1].Value = StaffId;
                        //    xlsSheet[i, 2].Value = Name;

                        //    xlsSheet[i, 0].Style = xlstStyle01;
                        //    xlsSheet[i, 1].Style = xlstStyle01;
                        //    xlsSheet[i, 2].Style = xlstStyle01;

                        //}

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
                        string fileName1 = HttpContext.Current.Server.MapPath(@"\Report\Template\THSLXT_tpl_1.xlsx");

                        xlbBook.Save(fileName1);
                        //Session["ZipFilePath"] = null;
                        //Session["ZipFilePath"] = fileName;

                        //ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('../Staff/DataTmp/" + name + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);

                    }
                }
            }
        }
    }
}
