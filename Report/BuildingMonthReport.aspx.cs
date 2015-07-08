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
    public partial class BuildingMonthReport : PageBase
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
            C1XLBook xlbBook = new C1XLBook();
            XLStyle xlstStyle = new XLStyle(xlbBook);
            xlstStyle.AlignHorz = XLAlignHorzEnum.Left;
            xlstStyle.WordWrap = true;
            xlstStyle.Font = new Font("", 8, FontStyle.Regular);
            xlstStyle.SetBorderColor(Color.Black);
            xlstStyle.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyle.BorderTop = XLLineStyleEnum.Thin;
            xlstStyle.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyle.BorderRight = XLLineStyleEnum.Thin;
            //xlstStyle.Format = "#,##0.00_);(#,##0.00)";
            xlstStyle.AlignVert = XLAlignVertEnum.Top;


            XLStyle xlstStyleN = new XLStyle(xlbBook);
            xlstStyleN.AlignHorz = XLAlignHorzEnum.Right;
            xlstStyleN.WordWrap = true;
            xlstStyleN.Font = new Font("", 8, FontStyle.Regular);
            xlstStyleN.SetBorderColor(Color.Black);
            xlstStyleN.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleN.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleN.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleN.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleN.Format = "#,##0.00_);(#,##0.00)";
            xlstStyleN.AlignVert = XLAlignVertEnum.Top;


            XLStyle xlstStyleS = new XLStyle(xlbBook);
            xlstStyleS.AlignHorz = XLAlignHorzEnum.Left;
            xlstStyleS.WordWrap = true;
            xlstStyleS.Font = new Font("", 8, FontStyle.Bold);
            xlstStyleS.SetBorderColor(Color.Black);
            xlstStyleS.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleS.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleS.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleS.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleS.Format = "#,##0.00_);(#,##0.00)";
            xlstStyleS.AlignVert = XLAlignVertEnum.Top;

            string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\BaoCaoThang.xlsx");
            if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BaoCaoThang"))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BaoCaoThang"));
            }

            string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BaoCaoThang\BaoCaoThang" + strDT + ".xlsx";
            string strFilePathExport = "Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + "/BaoCaoThang/BaoCaoThang" + strDT + ".xlsx";

            string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

            File.Copy(fileName, fileNameDes);

            xlbBook.Load(fileNameDes);

            DataSet ds = new DataSet();
            string sql = string.Empty;

            sql = " SELECT *";
            sql += " FROM Report_BuildingInfo where delflag = '0'";
            //sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' ";
            //sql += " AND ((NgayKetThuc is null) OR ";
            //sql += "      (NgayKetThuc is not null and substring(NgayKetThuc,1,6) >= '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'))";

            using (SqlDatabase db = new SqlDatabase())
            {
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    if (ds != null)
                    {
                        XLSheet xlsSheetMenu = xlbBook.Sheets["Menu"];
                        xlsSheetMenu[2, 1].Value = xlsSheetMenu[2, 1].Value.ToString().Replace("{%THANG%}", drpMonth.SelectedValue + "/" + drpYear.SelectedValue);

                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            int stt = 0;
                            string id = rowType["id"].ToString();
                            string sheet = rowType["Sheet"].ToString();
                            int NumOfCol = Func.ParseInt(rowType["NoOfColumn"].ToString());
                            string SqlSelect = rowType["SqlSelect"].ToString().Replace("{%NAM_THANG%}", drpYear.SelectedValue + drpMonth.SelectedValue);
                            SqlSelect = SqlSelect.Replace("{%TOA_NHA%}", Func.ParseString(Session["__BUILDINGID__"]));
                            int CellY = Func.ParseInt(rowType["CellBeginY"].ToString());
                            int CellX = Func.ParseInt(rowType["CellBeginX"].ToString());
                            string[] Col = rowType["SumCol"].ToString().Split(',');

                            decimal[] SumCol = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
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
                                        xlsSheet[CellY + stt, CellX].Value = Func.ParseString(++stt);

                                        for (int k = 0; k < NumOfCol; k++)
                                        {
                                            string tmp = rowSheet[k].ToString();

                                            xlsSheet[CellY + stt - 1, CellX + k + 1].Value = rowSheet[k];
                                            xlsSheet[CellY + stt - 1, CellX + k + 1].Style = xlstStyle;

                                            switch (rowSheet[k].GetType().Name)
                                            {
                                                case "Decimal":
                                                    //xlsSheet[CellY + stt - 1, CellX + k + 1].Value = Func.ParseDouble(tmp);
                                                    //break;
                                                    SumCol[k] += Convert.ToDecimal(rowSheet[k]);
                                                    xlsSheet[CellY + stt - 1, CellX + k + 1].Style = xlstStyleN;

                                                    break;
                                                case "Double":
                                                    //xlsSheet[CellY + stt - 1, CellX + k + 1].Value = Func.ParseDouble(tmp);
                                                    SumCol[k] += Convert.ToDecimal(rowSheet[k]);
                                                    xlsSheet[CellY + stt - 1, CellX + k + 1].Style = xlstStyleN;

                                                    break;
                                                //break;
                                                case "Int32":
                                                    //xlsSheet[CellY + stt - 1, CellX + k + 1].Value = Func.ParseInt(tmp);
                                                    SumCol[k] += Convert.ToDecimal(rowSheet[k]);
                                                    xlsSheet[CellY + stt - 1, CellX + k + 1].Style = xlstStyleN;

                                                    break;
                                                //break;
                                                case "Single":
                                                    SumCol[k] += Convert.ToDecimal(rowSheet[k]);
                                                    xlsSheet[CellY + stt - 1, CellX + k + 1].Style = xlstStyleN;

                                                    break;

                                                //xlsSheet[CellY + stt - 1, CellX + k + 1].Value = rowSheet[k];// Func.ParseInt(tmp);
                                                //xlsSheet[CellY + stt - 1, CellX + k + 1].Style = xlstStyleN;
                                                default:
                                                    xlsSheet[CellY + stt - 1, CellX + k + 1].Value = tmp;
                                                    xlsSheet[CellY + stt - 1, CellX + k + 1].Style = xlstStyle;
                                                    break;
                                            }
                                            //xlsSheet[CellY + stt - 1, CellX + k + 1].Value = tmp;
                                            //xlsSheet[CellY + stt - 1, CellX + k + 1].Style = xlstStyle;
                                        }
                                    }
                                    if (!String.IsNullOrEmpty(Col[0]))
                                    {
                                        for (int m = 0; m < NumOfCol + 1; m++)
                                        {
                                            xlsSheet[CellY + stt, m].Style = xlstStyleS;
                                        }
                                    }
                                    if (!String.IsNullOrEmpty(Col[0]))
                                    {
                                        xlsSheet[CellY + stt, 0].Value = "Tổng cộng";
                                        XLCellRange mrCell = new XLCellRange(CellY + stt, CellY + stt, 0, Func.ParseInt(Col[0]));
                                        xlsSheet.MergedCells.Add(mrCell);
                                        for (int m = 0; m <= Func.ParseInt(Col[0]); m++)
                                        {
                                            xlsSheet[CellY + stt, m].Style = xlstStyleS;
                                        }
                                    }
                                    for (int m = 0; m < Col.Length; m++)
                                    {
                                        if (!String.IsNullOrEmpty(Col[m]))
                                        {
                                            xlsSheet[CellY + stt, CellX + Func.ParseInt(Col[m]) + 1].Value = SumCol[Func.ParseInt(Col[m])];
                                            xlsSheet[CellY + stt, CellX + Func.ParseInt(Col[m]) + 1].Style = xlstStyleS;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            ds = new DataSet();
            sql = string.Empty;

            sql = " SELECT *";
            sql += " FROM Report_BuildingInfo where delflag = '2'";

            using (SqlDatabase db = new SqlDatabase())
            {
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            int stt = 0;
                            string id = rowType["id"].ToString();
                            string sheet = rowType["Sheet"].ToString();
                            int NumOfCol = Func.ParseInt(rowType["NoOfColumn"].ToString());
                            string SqlSelect = rowType["SqlSelect"].ToString().Replace("{%NAM_THANG%}", drpYear.SelectedValue + drpMonth.SelectedValue);
                            SqlSelect = SqlSelect.Replace("{%TOA_NHA%}", Func.ParseString(Session["__BUILDINGID__"]));
                            int CellY = Func.ParseInt(rowType["CellBeginY"].ToString());
                            int CellX = Func.ParseInt(rowType["CellBeginX"].ToString());
                            string[] Col = rowType["SumCol"].ToString().Split(',');

                            decimal[] SumCol = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                            XLCellRange mrCell = new XLCellRange(0, 0, 0, 0);

                            string group = "";
                            int i = 0;
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
                                        string col11 = rowSheet[NumOfCol].ToString();

                                        if (!group.Equals(col11))
                                        {
                                            xlsSheet[CellY + i, CellX].Value = col11;
                                            group = col11;

                                            for (int k = 0; k <= NumOfCol; k++)
                                            {
                                                xlsSheet[CellY + i, CellX + k].Style = xlstStyleS;
                                            }
                                            mrCell = new XLCellRange(CellY + i, CellY + i, 0, NumOfCol);
                                            xlsSheet.MergedCells.Add(mrCell);

                                            xlsSheet[CellY + i, CellX].Style = xlstStyleS;
                                            i++;
                                        }
                                        xlsSheet[CellY + i, CellX + 0].Value = ++stt;
                                        xlsSheet[CellY + i, CellX + 0].Style = xlstStyle;

                                        for (int m = 1; m <= NumOfCol; m++)
                                        {
                                            xlsSheet[CellY + i, CellX + m].Value = rowSheet[m - 1];
                                            xlsSheet[CellY + i, CellX + m].Style = xlstStyle;
                                        }
                                        ++i;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            xlbBook.Save(fileNameDes);
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('../" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);
        }
    }
    public class DeptInfo
    {
        public string CustomerId
        {
            get;
            set;
        }

        public string Customer
        {
            get;
            set;
        }

        public decimal RentUSD
        {
            get;
            set;
        }
        public decimal RentVND
        {
            get;
            set;
        }

        public decimal ManagerUSD
        {
            get;
            set;

        }
        public decimal ManagerVND
        {
            get;
            set;

        }

        public decimal ElecUSD
        {
            get;
            set;

        }
        public decimal ElecVND
        {
            get;
            set;

        }

        public decimal WaterUSD
        {
            get;
            set;

        }
        public decimal WaterVND
        {
            get;
            set;

        }

        public decimal ParkingUSD
        {
            get;
            set;

        }
        public decimal ParkingVND
        {
            get;
            set;

        }

        public decimal ExtraUSD
        {
            get;
            set;

        }
        public decimal ExtraVND
        {
            get;
            set;

        }

        public decimal ServiceUSD
        {
            get;
            set;

        }
        public decimal ServiceVND
        {
            get;
            set;

        }
        public decimal RentPaidUSD
        {
            get;
            set;

        }
        public decimal RentPaidVND
        {
            get;
            set;
        }

        public decimal ManagerPaidUSD
        {
            get;
            set;
        }
        public decimal ManagerPaidVND
        {
            get;
            set;
        }

        public decimal ElecPaidUSD
        {
            get;
            set;
        }
        public decimal ElecPaidVND
        {
            get;
            set;
        }

        public decimal WaterPaidUSD
        {
            get;
            set;
        }
        public decimal WaterPaidVND
        {
            get;
            set;
        }

        public decimal ParkingPaidUSD
        {
            get;
            set;
        }
        public decimal ParkingPaidVND
        {
            get;
            set;
        }

        public decimal ExtraPaidUSD
        {
            get;
            set;
        }
        public decimal ExtraPaidVND
        {
            get;
            set;
        }

        public decimal ServicePaidUSD
        {
            get;
            set;
        }
        public decimal ServicePaidVND
        {
            get;
            set;
        }


        public decimal BookingPaidUSD
        {
            get;
            set;

        }
        public decimal BookingUSD
        {
            get;
            set;

        }
        public decimal BookingVND
        {
            get;
            set;

        }
        public decimal BookingPaidVND
        {
            get;
            set;
        }
        public string YearMonth
        {
            get;
            set;
        }
        // Default constructor:
        public DeptInfo()
        {
        }

        public decimal RentDeptUSD()
        {
            return this.RentUSD - this.RentPaidUSD;
        }
        public decimal RentDeptVND()
        {
            return this.RentVND - this.RentPaidVND;
        }

        public decimal ManagerDeptUSD()
        {
            return this.ManagerUSD - this.ManagerPaidUSD;
        }
        public decimal ManagerDeptVND()
        {
            return this.ManagerVND - this.ManagerPaidVND;
        }

        public decimal ElecDeptUSD()
        {
            return this.ElecUSD - this.ElecPaidUSD;
        }
        public decimal ElecDeptVND()
        {
            return this.ElecVND - this.ElecPaidVND;
        }

        public decimal WaterDeptUSD()
        {
            return this.WaterUSD - this.WaterPaidUSD;
        }
        public decimal WaterDeptVND()
        {
            return this.WaterVND - this.WaterPaidVND;
        }

        public decimal ParkingDeptUSD()
        {
            return this.ParkingUSD - this.ParkingPaidUSD;
        }
        public decimal ParkingDeptVND()
        {
            return this.ParkingVND - this.ParkingPaidVND;
        }

        public decimal ExtraDeptUSD()
        {
            return this.ExtraUSD - this.ExtraPaidUSD;
        }
        public decimal ExtraDeptVND()
        {
            return this.ExtraVND - this.ExtraPaidVND;
        }

        public decimal ServiceDeptUSD()
        {
            return this.ServiceUSD - this.ServicePaidUSD;
        }
        public decimal ServiceDeptVND()
        {
            return this.ServiceVND - this.ServicePaidVND;
        }

        public decimal BookingDeptUSD()
        {
            return this.BookingUSD - this.BookingPaidUSD;
        }
        public decimal BookingDeptVND()
        {
            return this.BookingVND - this.BookingPaidVND;
        }

        public decimal SumUSD()
        {
            return this.RentUSD + this.ManagerUSD + this.ParkingUSD + this.ElecUSD + this.WaterUSD + this.ExtraUSD + this.ServiceUSD + this.BookingUSD;
        }
        public decimal SumVND()
        {
            return this.RentVND + this.ManagerVND + this.ParkingVND + this.ElecVND + this.WaterVND + this.ExtraVND + this.ServiceVND + this.BookingVND;
        }

        public decimal SumPaidUSD()
        {
            return this.RentPaidUSD + this.ManagerPaidUSD + this.ParkingPaidUSD + this.ElecPaidUSD + this.WaterPaidUSD + this.ExtraPaidUSD + this.ServicePaidUSD + this.BookingPaidUSD;
        }
        public decimal SumPaidVND()
        {
            return this.RentPaidVND + this.ManagerPaidVND + this.ParkingPaidVND + this.ElecPaidVND + this.WaterPaidVND + this.ExtraPaidVND + this.ServicePaidVND + this.BookingPaidVND;
        }
    }
}
