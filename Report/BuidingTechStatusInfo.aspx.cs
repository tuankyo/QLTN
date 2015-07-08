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
    public partial class BuidingTechStatusInfo : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy hh:mm:ss");
                txtToDate.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
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
            sql += " FROM v_BuildingTechStatusInfo";
            sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and StatusDate >= '"+ Func.FormatYYYYmmdd(txtFromDate.Text.Substring(0,10))   +"' and StatusDate <= '"+ Func.FormatYYYYmmdd(txtToDate.Text.Substring(0,10))   +"'";

            
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
                        string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\SuCoKyThuat.xls");
                        if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\SuCoKyThuat"))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\SuCoKyThuat"));
                        }
                        string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
                        string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\SuCoKyThuat\SuCoKyThuat" + strDT + ".xls";
                        string strFilePathExport = "Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + "/SuCoKyThuat/SuCoKyThuat" + strDT + ".xls";

                        string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);
                        File.Copy(fileName, fileNameDes);

                        xlbBook.Load(fileNameDes);
                        XLSheet xlsSheet = xlbBook.Sheets["SuCoKyThuat"];

                        int i = 3;
                        XLCellRange mrCell = new XLCellRange(0, 0, 0, 2);
                        xlsSheet.MergedCells.Add(mrCell);

                        XLStyle xlstStyle = new XLStyle(xlbBook);
                        xlstStyle.AlignHorz = XLAlignHorzEnum.Left;
                        xlstStyle.AlignVert = XLAlignVertEnum.Top;
                        xlstStyle.WordWrap = true;
                        xlstStyle.Font = new Font("", 8, FontStyle.Regular);
                        xlstStyle.SetBorderColor(Color.Black);
                        xlstStyle.BorderBottom = XLLineStyleEnum.Thin;
                        xlstStyle.BorderTop = XLLineStyleEnum.Thin;
                        xlstStyle.BorderLeft = XLLineStyleEnum.Thin;
                        xlstStyle.BorderRight = XLLineStyleEnum.Thin;

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

                        xlsSheet[0, 0].Value = xlsSheet[0, 0].Value.ToString().Replace("{%BUILDING%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'"));
                        xlsSheet[1, 0].Value = xlsSheet[1, 0].Value.ToString().Replace("{%TU_NGAY%}", txtFromDate.Text);
                        xlsSheet[1, 0].Value = xlsSheet[1, 0].Value.ToString().Replace("{%DEN_NGAY%}", txtToDate.Text);

                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            string col01 = Func.FormatDMY(rowType[0].ToString());
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
                            string col12 = rowType[11].ToString();

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

                            xlsSheet[i, 0].Style = xlstStyle01;
                            xlsSheet[i, 1].Style = xlstStyle;
                            xlsSheet[i, 2].Style = xlstStyle;
                            xlsSheet[i, 3].Style = xlstStyle;
                            xlsSheet[i, 4].Style = xlstStyle;
                            xlsSheet[i, 5].Style = xlstStyle;
                            xlsSheet[i, 6].Style = xlstStyle;
                            xlsSheet[i, 7].Style = xlstStyle;
                            xlsSheet[i, 8].Style = xlstStyle;
                            xlsSheet[i, 9].Style = xlstStyle;
                            xlsSheet[i, 10].Style = xlstStyle;
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
