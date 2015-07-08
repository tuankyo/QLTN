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
    public partial class BuildingWaterMonthReport : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy");
                txtToDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

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
            sql += " FROM Report_BuildingInfo where id = 42";

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

                        string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\NuocTieuThuThang.xlsx");
                        if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\NuocTieuThuThang"))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\NuocTieuThuThang"));
                        }

                        string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
                        string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\NuocTieuThuThang\NuocTieuThuThang" + strDT + ".xlsx";
                        string strFilePathExport = "Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + "/NuocTieuThuThang/NuocTieuThuThang" + strDT + ".xlsx";

                        string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

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
                            SqlSelect = SqlSelect.Replace("{%DATE_FROM%}", Func.FormatYYYYmmdd(txtFromDate.Text));
                            SqlSelect = SqlSelect.Replace("{%DATE_TO%}", Func.FormatYYYYmmdd(txtToDate.Text));
                            SqlSelect = SqlSelect.Replace("{%TOA_NHA%}", Func.ParseString(Session["__BUILDINGID__"]));

                            XLSheet xlsSheet = xlbBook.Sheets[sheet];
                            xlsSheet[0, 1].Value = xlsSheet[0, 1].Value.ToString().Replace("{%TOA_NHA%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'"));
                            xlsSheet[0, 1].Value = xlsSheet[0, 1].Value.ToString().Replace("{%THANG_NAM%}", txtFromDate.Text + "~" + txtToDate.Text);

                            int CellY = Func.ParseInt(rowType["CellBeginY"].ToString());
                            int CellX = Func.ParseInt(rowType["CellBeginX"].ToString());

                            using (SqlCommand cmSheet = db.CreateCommand(SqlSelect))
                            {
                                DataSet dsSheet = new DataSet();
                                SqlDataAdapter daSheet = new SqlDataAdapter(cmSheet);
                                daSheet.Fill(dsSheet);
                                if (dsSheet != null)
                                {

                                    DataTable dtSheet = dsSheet.Tables[0];
                                    foreach (DataRow rowSheet in dtSheet.Rows)
                                    {
                                        xlsSheet[CellY + stt, CellX].Style = xlstStyle;
                                        xlsSheet[CellY + stt, CellX].Value = ++stt + "";
                                        for (int k = 0; k < NumOfCol; k++)
                                        {
                                            xlsSheet[CellY + stt - 1, CellX + k + 1].Value = rowSheet[k];
                                            xlsSheet[CellY + stt - 1, CellX + k + 1].Style = xlstStyle;
                                        }
                                    }
                                }
                            }

                        }
                        xlbBook.Save(fileNameDes);
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('../" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);

                    }
                }
            }
        }
    }
}
