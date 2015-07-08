using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Threading;

using Gnt.Data;
using Man.Utils;
using Gnt.Data.DBCommand;
using System.Data.SqlClient;
using BusinessObjects;
using Gnt.Transaction;
using System.Text;
using Gnt.Utils.FastCsv;
using C1.C1Excel;
using System.IO;
using System.Drawing;

namespace Man.Customer
{
    public partial class CustomerList02 : PageBase
    {
        protected SortDirection ListSortDirection
        {
            get
            {
                object o = ViewState["SortDirection"];
                if (o == null)
                {
                    return SortDirection.Descending;
                }
                return (SortDirection)o;
            }
            set
            {
                ViewState["SortDirection"] = value;
            }
        }

        protected string ListSortExpression
        {
            get
            {
                object o = ViewState["SortExpression"];
                if (o == null)
                {
                    return "";
                }
                return o.ToString();
            }
            set
            {
                ViewState["SortExpression"] = value;
            }
        }

        private string popup = "PopupCustomerEdit";
        private string editPageName = "CustomerEdit";
        private string PaymentTermPage = "Paymentterm";
        private string PaymentBillDetailPage = "PaymentBillDetail";
        /// <summary>
        /// List data
        /// </summary>
        private void ShowData()
        {
            SqlDatabase db = new SqlDatabase();
            string sql = string.Empty;
            if (!Func.IsValid(ListSortExpression))
            {
                ListSortExpression = "Modified";
                ListSortDirection = SortDirection.Descending;
            }
            try
            {
                string buildingId = Func.ParseString(Session["__BUILDINGID__"]);
                //Đếm số lượng record
                sql += " Select COUNT(CustomerId) ";
                sql += " FROM Customer A";
                sql += " WHERE (CustomerId IS NOT NULL) and BuildingId = '" + buildingId + "'";
                sql += GetWhere();

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " Select A.*,B.DeptUSD,B.DeptVND,ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM Customer A left outer join (";
                sql += "        SELECT  CustomerId,BuildingId,YearMonth,sum(DeptUSD) DeptUSD,sum(DeptVND) DeptVND ";
                sql += "        FROM    v_DeptInfo Where BuildingId = '" + buildingId + "' and yearmonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";
                sql += "        group by CustomerId,BuildingId,YearMonth";
                sql += " ) As B on A.CustomerId = B.CustomerId and a.BuildingId = B.buildingId";
                sql += " WHERE A.CustomerId IS NOT NULL and A.BuildingId = '" + buildingId + "'";
                sql += GetWhere();

                //Phân trang
                sql = " Select * FROM (" + sql + ") AS TMP ";
                sql += " WHERE RowNum BETWEEN @PageIndex*@PageSize + 1  AND (@PageIndex+1)*@PageSize ORDER BY RowNum ";

                //Thực hiện câu SQL

                SqlCommand cm = db.CreateCommand(sql);
                cm.Parameters.AddWithValue("@PageIndex", pager.CurrentPageIndex);
                cm.Parameters.AddWithValue("@PageSize", pager.PageSize);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataSet ds = new DataSet();
                da.Fill(ds);
                db.Close();
                rptList.DataSource = ds.Tables[0].DefaultView;
                rptList.DataBind();
                pager.Count = count;
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }

        /// <summary>
        /// Init values
        /// </summary>
        protected override void DoInit()
        {
        }

        protected override void DoPost()
        {
            //Handle postback from popup
            string eventTarget = Func.ParseString(Request["__EVENTTARGET"]);
            string eventArgument = Func.ParseString(Request["__EVENTARGUMENT"]);
            if (eventTarget.StartsWith("Popup"))
            {
                if (eventTarget == popup)
                {
                    ShowData();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

                int days = DateTime.DaysInMonth(Func.ParseInt(drpYear.SelectedValue), Func.ParseInt(drpMonth.SelectedValue));
                txtRentDays.Text = Func.ParseString(days);

                int RentDays = Func.ParseInt(DbHelper.GetScalar("Select RentDays from BD_RentDays Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'"));
                if (RentDays > 0)
                {
                    txtRentDays.Text = Func.ParseString(RentDays);
                }

                PopupWidth = 600;
                PopupHeight = 450;
                ShowData();
                //Mst_BuildingData data = new Mst_BuildingData();
                //ITransaction tran = factory.GetLoadObject(data, Func.ParseString(Session["__BUILDINGID__"]));
                //Execute(tran);
                //if (!HasError)
                //{
                //    //Get Data
                //    data = (Mst_BuildingData)tran.Result;
                //    lblName.Text = data.Name;
                //    lblComment.Text = data.Comment;
                //    lblBuildingId.Text = data.BuildingId;
                //    lblName.Text = data.Name;
                //    lblInvestor.Text = data.Investor;
                //    lblAddress.Text = data.Address;
                //    lblPhone.Text = data.Phone;
                //    lblOwner.Text = data.Owner;
                //    lblManagerCompany.Text = data.ManagerCompany;
                //    lblManagerCompanyAgent.Text = data.ManagerCompanyAgent;
                //    lblManagerCompanyPhone.Text = data.ManagerCompanyPhone;
                //}
            }
        }

        /// </summary> Chọn trang
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void pager_PageIndexChanged(object source, PagerPageChangedEventArgs args)
        {
            ShowData();
        }

        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string command = e.CommandName;
            string colName = string.Empty;
            if (command.StartsWith("Sort"))
            {
                if (string.Compare(command, "SortID") == 0)
                {
                    colName = "ID";
                }
                else if (string.Compare(command, "SortName") == 0)
                {
                    colName = "Name";
                }
                else if (string.Compare(command, "SortModifiedBy") == 0)
                {
                    colName = "ModifiedBy";
                }
                else if (string.Compare(command, "SortModified") == 0)
                {
                    colName = "Modified";
                }


                if (colName == ListSortExpression)
                {
                    ListSortDirection = (ListSortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending);
                }
                else
                {
                    ListSortDirection = SortDirection.Descending;
                }
                ListSortExpression = colName;
                pager.CurrentPageIndex = 0;
                ShowData();
            }
            else if ("Revenue".Equals(Func.ParseString(e.CommandName)))
            {
                Response.Redirect(PaymentBillDetailPage + ".aspx?id=" + e.CommandArgument);
            }
            else if ("Payment".Equals(Func.ParseString(e.CommandName)))
            {
                PopupWidth = 600;
                PopupHeight = 500;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + PaymentTermPage + ".aspx?id=" + e.CommandArgument + "'," + PopupWidth + "," + PopupHeight + ",'" + PaymentTermPage + "', true);", true);
            }
            else if ("BillDetail".Equals(Func.ParseString(e.CommandName)))
            {
                PopupWidth = 1000;
                PopupHeight = 800;

                string billId = DbHelper.GetScalar("Select Id From PaymentBillInfo Where CustomerId = '" + e.CommandArgument + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'");
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "window.open('PaymentBillDetailReview.aspx?id=" + billId + "')", true);
            }
        }

        /// </summary>Hiển thị nội dung trên datagrid
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            try
            {
                if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
                {
                    DataRowView row = (DataRowView)item.DataItem;
                    string ID = Func.ParseString(row["CustomerId"]);
                    string Name = Func.ParseString(row["Name"]);
                    string Phone = Func.ParseString(row["Phone"]);
                    string Email = Func.ParseString(row["Email"]);
                    string ContactName = Func.ParseString(row["ContactName"]);
                    string Comment = Func.ParseString(row["Comment"]);

                    Func.SetGridLinkValue(item, "btnEdit", ID);
                    Func.SetGridTextValue(item, "ltrName", Func.ToolTipByteLen(Name, 30));
                    Func.SetGridTextValue(item, "ltrPhone", Phone);
                    Func.SetGridTextValue(item, "ltrEmail", Email);
                    Func.SetGridTextValue(item, "ltrContactName", Func.ToolTipByteLen(ContactName,20));
                    //Func.SetGridTextValue(item, "ltrComment", Func.ToolTipByteLen(Comment, 20));

                    PopupWidth = 600;
                    PopupHeight = 450;
                    LinkPopup((LinkButton)item.FindControl("btnEdit"), editPageName + ".aspx?Action=Edit&Id=" + ID);

                    ((Button)item.FindControl("btnRevenue")).CommandArgument = ID;
                    ((Button)item.FindControl("btnPayment")).CommandArgument = ID;
                    ((Button)item.FindControl("btnView")).CommandArgument = ID;

                    string ModifiedBy = Func.ParseString(row["ModifiedBy"].ToString().Trim());
                    string Modified = Func.ParseString(row["Modified"].ToString().Trim());
                    Func.SetGridTextValue(item, "ltrModifiedBy", ModifiedBy);
                    Func.SetGridTextValue(item, "ltrModified", Func.Formatdmyhms(Modified));

                    Literal resultLine = (Literal)item.FindControl("resultLine");

                    float DeptUSD = Func.ParseFloat(row["DeptUSD"]);
                    decimal DeptVND = Convert.ToDecimal(row["DeptVND"]);

                    if (DeptUSD > 0 || DeptVND > 0)
                    {
                        resultLine.Text = "style='background-color:#DDDDDD' ";
                    }
                    else if (DeptUSD == 0 && DeptVND == 0)
                    {
                        resultLine.Text = "style='background-color:#FFCCCC' ";
                    }
                    if (String.IsNullOrEmpty(Func.ParseString(row["DeptUSD"])) && String.IsNullOrEmpty(Func.ParseString(row["DeptVND"])))
                    {
                        resultLine.Text = "";
                    }
                }
                else if (item.ItemType == ListItemType.Header)
                {
                    string colName = ListSortExpression;
                    if (Func.IsValid(colName))
                    {
                        string img = string.Empty;
                        if (ListSortDirection == SortDirection.Ascending)
                        {
                            img = "<img src=\"../App_Themes/Default/Images/ASCSymbol.gif\" border=\"0\">";
                        }
                        else
                        {
                            img = "<img src=\"../App_Themes/Default/Images/DSCSymbol.gif\" border=\"0\">";
                        }

                        if (colName.EndsWith("Id"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkTypeId");
                            link.Text = "ID" + img;
                        }
                        else if (colName.EndsWith("Address"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkName");
                            link.Text = "Địa Chỉ" + img;
                        }
                        else if (colName.EndsWith("Name"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkName");
                            link.Text = "Loại Phí" + img;
                        }
                        else if (colName.EndsWith("ModifiedBy"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkModifiedBy");
                            link.Text = "Cập Nhật" + img;
                        }
                        else if (colName.EndsWith("Modified"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkModified");
                            link.Text = "Ngày Cập Nhật" + img;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PopupWidth = 600;
            PopupHeight = 450;
            ShowData();
        }
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Click(object sender, EventArgs e)
        {
            string buildingId = Func.ParseString(Session["__BUILDINGID__"]);
            string sql = "Select CustomerId, Name From Customer Where BuildingId = '" + buildingId + "' and DelFlag = 0 order by CustomerId";
            Hashtable CusList = new Hashtable();
            DataTable dtCus = DbHelper.GetDataTable(sql);
            foreach (DataRow drCus in dtCus.Rows)
            {
                if (!CusList.Contains(drCus["CustomerId"].ToString()))
                {
                    CusList.Add(drCus["CustomerId"].ToString(), drCus["Name"].ToString());
                }
            }

            Hashtable PaymentList = new Hashtable();
            sql = "Select * from v_PaymentBillDetail Where BuildingId = '" + buildingId + "' order by CustomerId";

            DataTable dt = DbHelper.GetDataTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                string CustomerId = dr["CustomerId"].ToString();
                string YearMonth = dr["YearMonth"].ToString();
                string key = CustomerId + "_" + YearMonth;
                DeptInfo tmp;

                if (!PaymentList.Contains(key))
                {
                    tmp = new DeptInfo();
                    tmp.CustomerId = CustomerId;
                    tmp.Customer = Func.ParseString(CusList[CustomerId]);
                    tmp.YearMonth = YearMonth;
                    PaymentList.Add(key, tmp);
                }
                string PaymentType = dr["PaymentType"].ToString();

                decimal MoneyUSD = Convert.ToDecimal(dr["MoneyUSD"]);
                decimal MoneyVND = Convert.ToDecimal(dr["MoneyVND"]);
                decimal PaidUSD = Convert.ToDecimal(dr["PaidUSD"]);
                decimal PaidVND = Convert.ToDecimal(dr["PaidVND"]);

                tmp = (DeptInfo)PaymentList[key];
                switch (PaymentType)
                {
                    case "1":
                        tmp.RentUSD = MoneyUSD;
                        tmp.RentVND = MoneyVND;
                        tmp.RentPaidUSD = PaidUSD;
                        tmp.RentPaidVND = PaidVND;
                        break;
                    case "2":
                        tmp.ManagerUSD = MoneyUSD;
                        tmp.ManagerVND = MoneyVND;
                        tmp.ManagerPaidUSD = PaidUSD;
                        tmp.ManagerPaidVND = PaidVND;
                        break;
                    case "3":
                        tmp.ParkingUSD = MoneyUSD;
                        tmp.ParkingVND = MoneyVND;
                        tmp.ParkingPaidUSD = PaidUSD;
                        tmp.ParkingPaidVND = PaidVND;
                        break;
                    case "4":
                        tmp.ExtraUSD = MoneyUSD;
                        tmp.ExtraVND = MoneyVND;
                        tmp.ExtraPaidUSD = PaidUSD;
                        tmp.ExtraPaidVND = PaidVND;
                        break;
                    case "5":
                        tmp.ElecUSD = MoneyUSD;
                        tmp.ElecVND = MoneyVND;
                        tmp.ElecPaidUSD = PaidUSD;
                        tmp.ElecPaidVND = PaidVND;
                        break;
                    case "6":
                        tmp.WaterUSD = MoneyUSD;
                        tmp.WaterVND = MoneyVND;
                        tmp.WaterPaidUSD = PaidUSD;
                        tmp.WaterPaidVND = PaidVND;
                        break;
                    case "7":
                        tmp.ServiceUSD = MoneyUSD;
                        tmp.ServiceVND = MoneyVND;
                        tmp.ServicePaidUSD = PaidUSD;
                        tmp.ServicePaidVND = PaidVND;
                        break;
                    case "8":
                        tmp.BookingUSD = MoneyUSD;
                        tmp.BookingVND = MoneyVND;
                        tmp.BookingPaidUSD = PaidUSD;
                        tmp.BookingPaidVND = PaidVND;
                        break;
                    default:
                        break;
                }
            }

            C1XLBook xlbBook = new C1XLBook();

            string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\BaoCaoCongNo.xlsx");
            if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BaoCaoCongNo"))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BaoCaoCongNo"));
            }

            string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BaoCaoCongNo\BaoCaoCongNo" + strDT + ".xlsx";
            string strFilePathExport = "Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + "/BaoCaoCongNo/BaoCaoCongNo" + strDT + ".xlsx";

            string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

            //string fileNameDes = HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\TongHopDienTich" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx");
            File.Copy(fileName, fileNameDes);

            xlbBook.Load(fileNameDes);

            XLStyle xlstStyle2 = new XLStyle(xlbBook);
            xlstStyle2.AlignVert = XLAlignVertEnum.Center;
            xlstStyle2.WordWrap = false;
            xlstStyle2.Font = new Font("", 8, FontStyle.Regular);
            xlstStyle2.SetBorderColor(Color.Black);
            xlstStyle2.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyle2.BorderTop = XLLineStyleEnum.Thin;
            xlstStyle2.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyle2.BorderRight = XLLineStyleEnum.Thin;
            xlstStyle2.Format = "#,##0.00_);(#,##0.00)";

            XLStyle xlstStyle1 = new XLStyle(xlbBook);
            xlstStyle1.AlignVert = XLAlignVertEnum.Center;
            xlstStyle1.WordWrap = false;
            xlstStyle1.Font = new Font("", 8, FontStyle.Regular);
            xlstStyle1.SetBorderColor(Color.Black);
            xlstStyle1.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyle1.BorderTop = XLLineStyleEnum.Thin;
            xlstStyle1.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyle1.BorderRight = XLLineStyleEnum.Thin;
            xlstStyle1.Format = "#,##0.0_);(#,##0.0)";

            XLStyle xlstStyle0 = new XLStyle(xlbBook);
            xlstStyle0.AlignVert = XLAlignVertEnum.Center;
            xlstStyle0.WordWrap = false;
            xlstStyle0.Font = new Font("", 8, FontStyle.Regular);
            xlstStyle0.SetBorderColor(Color.Black);
            xlstStyle0.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyle0.BorderTop = XLLineStyleEnum.Thin;
            xlstStyle0.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyle0.BorderRight = XLLineStyleEnum.Thin;
            xlstStyle0.Format = "#,##0_);(#,##0)";

            XLStyle xlstStyleB2 = new XLStyle(xlbBook);
            xlstStyleB2.AlignHorz = XLAlignHorzEnum.Right;
            xlstStyleB2.AlignVert = XLAlignVertEnum.Center;
            xlstStyleB2.WordWrap = false;
            xlstStyleB2.Font = new Font("", 8, FontStyle.Bold);
            xlstStyleB2.SetBorderColor(Color.Black);
            xlstStyleB2.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleB2.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleB2.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleB2.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleB2.Format = "#,##0.00_);(#,##0.00)";

            XLStyle xlstStyleB1 = new XLStyle(xlbBook);
            xlstStyleB1.AlignHorz = XLAlignHorzEnum.Right;
            xlstStyleB1.AlignVert = XLAlignVertEnum.Center;
            xlstStyleB1.WordWrap = false;
            xlstStyleB1.Font = new Font("", 8, FontStyle.Bold);
            xlstStyleB1.SetBorderColor(Color.Black);
            xlstStyleB1.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleB1.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleB1.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleB1.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleB1.Format = "#,##0.0_);(#,##0.0)";

            XLStyle xlstStyleB0 = new XLStyle(xlbBook);
            xlstStyleB0.AlignHorz = XLAlignHorzEnum.Right;
            xlstStyleB0.AlignVert = XLAlignVertEnum.Center;
            xlstStyleB0.WordWrap = false;
            xlstStyleB0.Font = new Font("", 8, FontStyle.Bold);
            xlstStyleB0.SetBorderColor(Color.Black);
            xlstStyleB0.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleB0.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleB0.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleB0.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleB0.Format = "#,##0_);(#,##0)";

            string sheet = "BaoCao";

            XLSheet xlsSheet = xlbBook.Sheets[sheet];
            int i = 5;

            decimal[] SumUsd = { 0, 0, 0, 0, 0, 0, 0, 0, };
            decimal[] SumVnd = { 0, 0, 0, 0, 0, 0, 0, 0, };

            decimal[] AllSumUsd = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            decimal[] AllSumVnd = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            xlsSheet[0, 1].Value = xlsSheet[0, 1].Value.ToString().Replace("{%TOA_NHA%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + buildingId + "'"));
            int j = 1;
            foreach (DictionaryEntry tmp in PaymentList)
            {
                string key = (string)tmp.Key;
                DeptInfo dept = (DeptInfo)tmp.Value;

                xlsSheet[i, 0 + j].Value = dept.YearMonth.Substring(4, 2) + "/" + dept.YearMonth.Substring(0, 4);
                xlsSheet[i, 1 + j].Value = dept.CustomerId;
                xlsSheet[i, 2 + j].Value = dept.Customer;

                xlsSheet[i, 3 + j].Value = dept.RentDeptUSD();
                xlsSheet[i, 4 + j].Value = dept.RentDeptVND();

                xlsSheet[i, 5 + j].Value = dept.ManagerDeptUSD();
                xlsSheet[i, 6 + j].Value = dept.ManagerDeptVND();

                xlsSheet[i, 7 + j].Value = dept.ParkingDeptUSD();
                xlsSheet[i, 8 + j].Value = dept.ParkingDeptVND();

                xlsSheet[i, 9 + j].Value = dept.ExtraDeptUSD();
                xlsSheet[i, 10 + j].Value = dept.ExtraDeptVND();

                //xlsSheet[i, 11 + j].Value = dept.ElecDeptUSD();
                xlsSheet[i, 11 + j].Value = dept.ElecDeptVND();

                //xlsSheet[i, 13 + j].Value = dept.WaterDeptUSD();
                xlsSheet[i, 12 + j].Value = dept.WaterDeptVND();

                xlsSheet[i, 13 + j].Value = dept.ServiceDeptUSD();
                xlsSheet[i, 14 + j].Value = dept.ServiceDeptVND();

                xlsSheet[i, 15 + j].Value = dept.BookingDeptUSD();
                xlsSheet[i, 16 + j].Value = dept.BookingDeptVND();


                //////////////////////////
                SumUsd[0] = dept.RentDeptUSD();
                SumVnd[0] = dept.RentDeptVND();

                SumUsd[1] = dept.ManagerDeptUSD();
                SumVnd[1] = dept.ManagerDeptVND();

                SumUsd[2] = dept.ParkingDeptUSD();
                SumVnd[2] = dept.ParkingDeptVND();

                SumUsd[3] = dept.ExtraDeptUSD();
                SumVnd[3] = dept.ExtraDeptVND();

                SumVnd[4] = dept.ElecDeptVND();

                SumVnd[5] = dept.WaterDeptVND();

                SumUsd[6] = dept.ServiceDeptUSD();
                SumVnd[6] = dept.ServiceDeptVND();

                SumUsd[7] = dept.BookingDeptUSD();
                SumVnd[7] = dept.BookingDeptVND();

                xlsSheet[i, 17 + j].Value = SumUsd[0] + SumUsd[1] + SumUsd[2] + SumUsd[3] + SumUsd[4] + SumUsd[5] + SumUsd[6] + SumUsd[7];
                xlsSheet[i, 18 + j].Value = SumVnd[0] + SumVnd[1] + SumVnd[2] + SumVnd[3] + SumVnd[4] + SumVnd[5] + SumVnd[6] + SumVnd[7];
                /////////////

                AllSumUsd[0] += dept.RentDeptUSD();
                AllSumVnd[0] += dept.RentDeptVND();

                AllSumUsd[1] += dept.ManagerDeptUSD();
                AllSumVnd[1] += dept.ManagerDeptVND();

                AllSumUsd[2] += dept.ParkingDeptUSD();
                AllSumVnd[2] += dept.ParkingDeptVND();

                AllSumUsd[3] += dept.ExtraDeptUSD();
                AllSumVnd[3] += dept.ExtraDeptVND();

                AllSumVnd[4] += dept.ElecDeptVND();

                AllSumVnd[5] += dept.WaterDeptVND();

                AllSumUsd[6] += dept.ServiceDeptUSD();
                AllSumVnd[6] += dept.ServiceDeptVND();

                AllSumUsd[7] += dept.BookingDeptUSD();
                AllSumVnd[7] += dept.BookingDeptVND();

                AllSumUsd[8] += SumUsd[0] + SumUsd[1] + SumUsd[2] + SumUsd[3] + SumUsd[4] + SumUsd[5] + SumUsd[6] + SumUsd[7];
                AllSumVnd[8] += SumVnd[0] + SumVnd[1] + SumVnd[2] + SumVnd[3] + SumVnd[4] + SumVnd[5] + SumVnd[6] + SumVnd[7];
                //////////////////////////

                for (int m = 0; m < 19; m++)
                {
                    xlsSheet[i, m + j].Style = xlstStyle1;
                }

                ///////////////////////////////////////////////////
                xlsSheet[i, 4 + j].Style = xlstStyle0;
                xlsSheet[i, 6 + j].Style = xlstStyle0;
                xlsSheet[i, 8 + j].Style = xlstStyle0;
                xlsSheet[i, 10 + j].Style = xlstStyle0;
                xlsSheet[i, 11 + j].Style = xlstStyle0;
                xlsSheet[i, 12 + j].Style = xlstStyle0;
                xlsSheet[i, 14 + j].Style = xlstStyle0;
                xlsSheet[i, 16 + j].Style = xlstStyle0;
                xlsSheet[i, 18 + j].Style = xlstStyle0;
                ///////////////////////////////////////////////////
                i++;
            }
            xlsSheet[i, 3 + j].Value = AllSumUsd[0];
            xlsSheet[i, 4 + j].Value = AllSumVnd[0];

            xlsSheet[i, 5 + j].Value = AllSumUsd[1];
            xlsSheet[i, 6 + j].Value = AllSumVnd[1];

            xlsSheet[i, 7 + j].Value = AllSumUsd[2];
            xlsSheet[i, 8 + j].Value = AllSumVnd[2];

            xlsSheet[i, 9 + j].Value = AllSumUsd[3];
            xlsSheet[i, 10 + j].Value = AllSumVnd[3];

            //xlsSheet[i, 11 + j].Value = dept.ElecDeptUSD();
            xlsSheet[i, 11 + j].Value = AllSumVnd[4];

            //xlsSheet[i, 13 + j].Value = dept.WaterDeptUSD();
            xlsSheet[i, 12 + j].Value = AllSumVnd[5];

            xlsSheet[i, 13 + j].Value = AllSumUsd[6];
            xlsSheet[i, 14 + j].Value = AllSumVnd[6];

            xlsSheet[i, 15 + j].Value = AllSumUsd[7];
            xlsSheet[i, 16 + j].Value = AllSumVnd[7];

            xlsSheet[i, 17 + j].Value = AllSumUsd[8];
            xlsSheet[i, 18 + j].Value = AllSumVnd[8];

            
            XLCellRange mrCell = new XLCellRange(i, i, 1, 3);
            xlsSheet.MergedCells.Add(mrCell);
            xlsSheet[i, 1].Value = "Tổng Cộng";

            for (int m = 0; m < 19; m++)
            {
                xlsSheet[i, m + j].Style = xlstStyleB1;
            }
            ///////////////////////////////////////
            xlsSheet[i, 4 + j].Style = xlstStyleB0;
            xlsSheet[i, 6 + j].Style = xlstStyleB0;
            xlsSheet[i, 8 + j].Style = xlstStyleB0;
            xlsSheet[i, 10 + j].Style = xlstStyleB0;
            xlsSheet[i, 11 + j].Style = xlstStyleB0;
            xlsSheet[i, 12 + j].Style = xlstStyleB0;
            xlsSheet[i, 14 + j].Style = xlstStyleB0;
            xlsSheet[i, 16 + j].Style = xlstStyleB0;
            xlsSheet[i, 18 + j].Style = xlstStyleB0;
            ///////////////////////////////////////
            xlbBook.Save(fileNameDes);
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('../" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);

        }
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport1_Click(object sender, EventArgs e)
        {
            string buildingId = Func.ParseString(Session["__BUILDINGID__"]);
            string sql = "Select CustomerId, Name From Customer Where BuildingId = '" + buildingId + "' and DelFlag = 0 order by CustomerId";
            Hashtable CusList = new Hashtable();
            DataTable dtCus = DbHelper.GetDataTable(sql);
            foreach (DataRow drCus in dtCus.Rows)
            {
                if (!CusList.Contains(drCus["CustomerId"].ToString()))
                {
                    CusList.Add(drCus["CustomerId"].ToString(), drCus["Name"].ToString());
                }
            }

            Hashtable PaymentList = new Hashtable();
            sql = "Select * from v_PaymentBillDetail Where BuildingId = '" + buildingId + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "' order by CustomerId";

            DataTable dt = DbHelper.GetDataTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                string CustomerId = dr["CustomerId"].ToString();
                string YearMonth = dr["YearMonth"].ToString();
                string key = CustomerId + "_" + YearMonth;
                DeptInfo tmp;

                if (!PaymentList.Contains(key))
                {
                    tmp = new DeptInfo();
                    tmp.CustomerId = CustomerId;
                    tmp.Customer = Func.ParseString(CusList[CustomerId]);
                    tmp.YearMonth = YearMonth;
                    PaymentList.Add(key, tmp);
                }
                string PaymentType = dr["PaymentType"].ToString();

                decimal MoneyUSD = Convert.ToDecimal(dr["MoneyUSD"]);
                decimal MoneyVND = Convert.ToDecimal(dr["MoneyVND"]);
                decimal PaidUSD = Convert.ToDecimal(dr["PaidUSD"]);
                decimal PaidVND = Convert.ToDecimal(dr["PaidVND"]);

                tmp = (DeptInfo)PaymentList[key];
                switch (PaymentType)
                {
                    case "1":
                        tmp.RentUSD = MoneyUSD;
                        tmp.RentVND = MoneyVND;
                        tmp.RentPaidUSD = PaidUSD;
                        tmp.RentPaidVND = PaidVND;
                        break;
                    case "2":
                        tmp.ManagerUSD = MoneyUSD;
                        tmp.ManagerVND = MoneyVND;
                        tmp.ManagerPaidUSD = PaidUSD;
                        tmp.ManagerPaidVND = PaidVND;
                        break;
                    case "3":
                        tmp.ParkingUSD = MoneyUSD;
                        tmp.ParkingVND = MoneyVND;
                        tmp.ParkingPaidUSD = PaidUSD;
                        tmp.ParkingPaidVND = PaidVND;
                        break;
                    case "4":
                        tmp.ExtraUSD = MoneyUSD;
                        tmp.ExtraVND = MoneyVND;
                        tmp.ExtraPaidUSD = PaidUSD;
                        tmp.ExtraPaidVND = PaidVND;
                        break;
                    case "5":
                        tmp.ElecUSD = MoneyUSD;
                        tmp.ElecVND = MoneyVND;
                        tmp.ElecPaidUSD = PaidUSD;
                        tmp.ElecPaidVND = PaidVND;
                        break;
                    case "6":
                        tmp.WaterUSD = MoneyUSD;
                        tmp.WaterVND = MoneyVND;
                        tmp.WaterPaidUSD = PaidUSD;
                        tmp.WaterPaidVND = PaidVND;
                        break;
                    case "7":
                        tmp.ServiceUSD = MoneyUSD;
                        tmp.ServiceVND = MoneyVND;
                        tmp.ServicePaidUSD = PaidUSD;
                        tmp.ServicePaidVND = PaidVND;
                        break;
                    case "8":
                        tmp.BookingUSD = MoneyUSD;
                        tmp.BookingVND = MoneyVND;
                        tmp.BookingPaidUSD = PaidUSD;
                        tmp.BookingPaidVND = PaidVND;
                        break;
                    default:
                        break;
                }
            }

            C1XLBook xlbBook = new C1XLBook();

            string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\BaoCaoCongNo_ChiTiet.xlsx");
            if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BaoCaoCongNo"))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BaoCaoCongNo"));
            }

            string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BaoCaoCongNo\BaoCaoCongNo_ChiTiet" + strDT + ".xlsx";
            string strFilePathExport = "Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + "/BaoCaoCongNo/BaoCaoCongNo_ChiTiet" + strDT + ".xlsx";

            string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

            //string fileNameDes = HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\TongHopDienTich" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx");
            File.Copy(fileName, fileNameDes);

            xlbBook.Load(fileNameDes);


            XLStyle xlstStyle2 = new XLStyle(xlbBook);
            xlstStyle2.AlignVert = XLAlignVertEnum.Center;
            xlstStyle2.WordWrap = false;
            xlstStyle2.Font = new Font("", 8, FontStyle.Regular);
            xlstStyle2.SetBorderColor(Color.Black);
            xlstStyle2.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyle2.BorderTop = XLLineStyleEnum.Thin;
            xlstStyle2.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyle2.BorderRight = XLLineStyleEnum.Thin;
            xlstStyle2.Format = "#,##0.00_);(#,##0.00)";

            XLStyle xlstStyle1 = new XLStyle(xlbBook);
            xlstStyle1.AlignVert = XLAlignVertEnum.Center;
            xlstStyle1.WordWrap = false;
            xlstStyle1.Font = new Font("", 8, FontStyle.Regular);
            xlstStyle1.SetBorderColor(Color.Black);
            xlstStyle1.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyle1.BorderTop = XLLineStyleEnum.Thin;
            xlstStyle1.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyle1.BorderRight = XLLineStyleEnum.Thin;
            xlstStyle1.Format = "#,##0.0_);(#,##0.0)";

            XLStyle xlstStyle0 = new XLStyle(xlbBook);
            xlstStyle0.AlignVert = XLAlignVertEnum.Center;
            xlstStyle0.WordWrap = false;
            xlstStyle0.Font = new Font("", 8, FontStyle.Regular);
            xlstStyle0.SetBorderColor(Color.Black);
            xlstStyle0.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyle0.BorderTop = XLLineStyleEnum.Thin;
            xlstStyle0.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyle0.BorderRight = XLLineStyleEnum.Thin;
            xlstStyle0.Format = "#,##0_);(#,##0)";

            XLStyle xlstStyleB2 = new XLStyle(xlbBook);
            xlstStyleB2.AlignHorz = XLAlignHorzEnum.Right;
            xlstStyleB2.AlignVert = XLAlignVertEnum.Center;
            xlstStyleB2.WordWrap = false;
            xlstStyleB2.Font = new Font("", 8, FontStyle.Bold);
            xlstStyleB2.SetBorderColor(Color.Black);
            xlstStyleB2.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleB2.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleB2.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleB2.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleB2.Format = "#,##0.00_);(#,##0.00)";

            XLStyle xlstStyleB1 = new XLStyle(xlbBook);
            xlstStyleB1.AlignHorz = XLAlignHorzEnum.Right;
            xlstStyleB1.AlignVert = XLAlignVertEnum.Center;
            xlstStyleB1.WordWrap = false;
            xlstStyleB1.Font = new Font("", 8, FontStyle.Bold);
            xlstStyleB1.SetBorderColor(Color.Black);
            xlstStyleB1.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleB1.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleB1.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleB1.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleB1.Format = "#,##0.0_);(#,##0.0)";

            XLStyle xlstStyleB0 = new XLStyle(xlbBook);
            xlstStyleB0.AlignHorz = XLAlignHorzEnum.Right;
            xlstStyleB0.AlignVert = XLAlignVertEnum.Center;
            xlstStyleB0.WordWrap = false;
            xlstStyleB0.Font = new Font("", 8, FontStyle.Bold);
            xlstStyleB0.SetBorderColor(Color.Black);
            xlstStyleB0.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleB0.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleB0.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleB0.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleB0.Format = "#,##0_);(#,##0)";

            string sheet = "BaoCao";

            XLSheet xlsSheet = xlbBook.Sheets[sheet];
            int i = 5;

            xlsSheet[0, 1].Value = xlsSheet[0, 1].Value.ToString().Replace("{%TOA_NHA%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + buildingId + "'"));
            int j = 1;

            decimal[] AllSumUsd = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            decimal[] AllSumVnd = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            foreach (DictionaryEntry tmp in PaymentList)
            {
                string key = (string)tmp.Key;
                DeptInfo dept = (DeptInfo)tmp.Value;

                xlsSheet[i, 0 + j].Value = dept.YearMonth.Substring(4, 2) + "/" + dept.YearMonth.Substring(0, 4);
                xlsSheet[i, 1 + j].Value = dept.CustomerId;
                xlsSheet[i, 2 + j].Value = dept.Customer;

                xlsSheet[i, 3 + j].Value = dept.RentUSD;
                xlsSheet[i, 4 + j].Value = dept.RentVND;

                xlsSheet[i, 5 + j].Value = dept.ManagerUSD;
                xlsSheet[i, 6 + j].Value = dept.ManagerVND;

                xlsSheet[i, 7 + j].Value = dept.ParkingUSD;
                xlsSheet[i, 8 + j].Value = dept.ParkingVND;

                xlsSheet[i, 9 + j].Value = dept.ExtraUSD;
                xlsSheet[i, 10 + j].Value = dept.ExtraVND;

                //xlsSheet[i, 11 + j].Value = dept.ElecUSD;
                xlsSheet[i, 11 + j].Value = dept.ElecVND;

                //xlsSheet[i, 13 + j].Value = dept.WaterUSD;
                xlsSheet[i, 12 + j].Value = dept.WaterVND;

                xlsSheet[i, 13 + j].Value = dept.ServiceUSD;
                xlsSheet[i, 14 + j].Value = dept.ServiceVND;

                xlsSheet[i, 15 + j].Value = dept.BookingUSD;
                xlsSheet[i, 16 + j].Value = dept.BookingVND;

                xlsSheet[i, 17 + j].Value = dept.SumUSD();
                xlsSheet[i, 18 + j].Value = dept.SumVND();

                //-----------------------
                xlsSheet[i, j + 19].Value = dept.RentPaidUSD;
                xlsSheet[i, j + 20].Value = dept.RentPaidVND;

                xlsSheet[i, j + 21].Value = dept.ManagerPaidUSD;
                xlsSheet[i, j + 22].Value = dept.ManagerPaidVND;

                xlsSheet[i, j + 23].Value = dept.ParkingPaidUSD;
                xlsSheet[i, j + 24].Value = dept.ParkingPaidVND;

                xlsSheet[i, j + 25].Value = dept.ExtraPaidUSD;
                xlsSheet[i, j + 26].Value = dept.ExtraPaidVND;

                //xlsSheet[i, 11 + j + 18].Value = dept.ElecPaidUSD;
                xlsSheet[i, j + 27].Value = dept.ElecPaidVND;

                //xlsSheet[i, 13 + j + 18].Value = dept.WaterPaidUSD;
                xlsSheet[i, j + 28].Value = dept.WaterPaidVND;

                xlsSheet[i, j + 29].Value = dept.ServicePaidUSD;
                xlsSheet[i, j + 30].Value = dept.ServicePaidVND;

                xlsSheet[i, j + 31].Value = dept.BookingPaidUSD;
                xlsSheet[i, j + 32].Value = dept.BookingPaidVND;

                xlsSheet[i, j + 33].Value = dept.SumPaidUSD();
                xlsSheet[i, j + 34].Value = dept.SumPaidVND();

                xlsSheet[i, j + 35].Value = dept.SumUSD() - dept.SumPaidUSD();
                xlsSheet[i, j + 36].Value = dept.SumVND() - dept.SumPaidVND();

                /////////////////
                AllSumUsd[0] += dept.RentUSD;
                AllSumVnd[0] += dept.RentVND;

                AllSumUsd[1] += dept.ManagerUSD;
                AllSumVnd[1] += dept.ManagerVND;

                AllSumUsd[2] += dept.ParkingUSD;
                AllSumVnd[2] += dept.ParkingVND;

                AllSumUsd[3] += dept.ExtraUSD;
                AllSumVnd[3] += dept.ExtraVND;

                AllSumUsd[4] += dept.ElecUSD;
                AllSumVnd[4] += dept.ElecVND;

                AllSumUsd[5] += dept.WaterUSD;
                AllSumVnd[5] += dept.WaterVND;

                AllSumUsd[6] += dept.ServiceUSD;
                AllSumVnd[6] += dept.ServiceVND;

                AllSumUsd[7] += dept.BookingUSD;
                AllSumVnd[7] += dept.BookingVND;

                AllSumUsd[8] += dept.SumUSD();
                AllSumVnd[8] += dept.SumVND();

                //-----------------------		
                AllSumUsd[9] += dept.RentPaidUSD;
                AllSumVnd[9] += dept.RentPaidVND;

                AllSumUsd[10] += dept.ManagerPaidUSD;
                AllSumVnd[10] += dept.ManagerPaidVND;

                AllSumUsd[11] += dept.ParkingPaidUSD;
                AllSumVnd[11] += dept.ParkingPaidVND;

                AllSumUsd[12] += dept.ExtraPaidUSD;
                AllSumVnd[12] += dept.ExtraPaidVND;

                AllSumUsd[13] += dept.ElecPaidUSD;
                AllSumVnd[13] += dept.ElecPaidVND;

                AllSumUsd[14] += dept.WaterPaidUSD;
                AllSumVnd[14] += dept.WaterPaidVND;

                AllSumUsd[15] += dept.ServicePaidUSD;
                AllSumVnd[15] += dept.ServicePaidVND;

                AllSumUsd[16] += dept.BookingPaidUSD;
                AllSumVnd[16] += dept.BookingPaidVND;

                AllSumUsd[17] += dept.SumPaidUSD();
                AllSumVnd[17] += dept.SumPaidVND();

                AllSumUsd[18] += dept.SumUSD() - dept.SumPaidUSD();
                AllSumVnd[18] += dept.SumVND() - dept.SumPaidVND();

                /////////////////
                for (int m = 0; m < 37; m++)
                {
                    xlsSheet[i, m + j].Style = xlstStyle1;
                }
                /////////////////////////////////////////////////////
                xlsSheet[i, 4 + j].Style = xlstStyle0;
                xlsSheet[i, 6 + j].Style = xlstStyle0;
                xlsSheet[i, 8 + j].Style = xlstStyle0;
                xlsSheet[i, 10 + j].Style = xlstStyle0;
                xlsSheet[i, 11 + j].Style = xlstStyle0;
                xlsSheet[i, 12 + j].Style = xlstStyle0;
                xlsSheet[i, 14 + j].Style = xlstStyle0;
                xlsSheet[i, 16 + j].Style = xlstStyle0;
                xlsSheet[i, 18 + j].Style = xlstStyle0;
                xlsSheet[i, j + 20].Style = xlstStyle0;
                xlsSheet[i, j + 22].Style = xlstStyle0;
                xlsSheet[i, j + 24].Style = xlstStyle0;
                xlsSheet[i, j + 26].Style = xlstStyle0;
                xlsSheet[i, j + 27].Style = xlstStyle0;
                xlsSheet[i, j + 28].Style = xlstStyle0;
                xlsSheet[i, j + 30].Style = xlstStyle0;
                xlsSheet[i, j + 32].Style = xlstStyle0;
                xlsSheet[i, j + 34].Style = xlstStyle0;
                xlsSheet[i, j + 36].Style = xlstStyle0;
                /////////////////////////////////////////////////////
                i++;
            }
            xlsSheet[i, 3 + j].Value = AllSumUsd[0];
            xlsSheet[i, 4 + j].Value = AllSumVnd[0];

            xlsSheet[i, 5 + j].Value = AllSumUsd[1];
            xlsSheet[i, 6 + j].Value = AllSumVnd[1];

            xlsSheet[i, 7 + j].Value = AllSumUsd[2];
            xlsSheet[i, 8 + j].Value = AllSumVnd[2];

            xlsSheet[i, 9 + j].Value = AllSumUsd[3];
            xlsSheet[i, 10 + j].Value = AllSumVnd[3];


            xlsSheet[i, 11 + j].Value = AllSumVnd[4];


            xlsSheet[i, 12 + j].Value = AllSumVnd[5];

            xlsSheet[i, 13 + j].Value = AllSumUsd[6];
            xlsSheet[i, 14 + j].Value = AllSumVnd[6];

            xlsSheet[i, 15 + j].Value = AllSumUsd[7];
            xlsSheet[i, 16 + j].Value = AllSumVnd[7];

            xlsSheet[i, 17 + j].Value = AllSumUsd[8];
            xlsSheet[i, 18 + j].Value = AllSumVnd[8];

            //-----------------------							                //-----------------------			
            xlsSheet[i, j + 19].Value = AllSumUsd[9];
            xlsSheet[i, j + 20].Value = AllSumVnd[9];

            xlsSheet[i, j + 21].Value = AllSumUsd[10];
            xlsSheet[i, j + 22].Value = AllSumVnd[10];

            xlsSheet[i, j + 23].Value = AllSumUsd[11];
            xlsSheet[i, j + 24].Value = AllSumVnd[11];

            xlsSheet[i, j + 25].Value = AllSumUsd[12];
            xlsSheet[i, j + 26].Value = AllSumVnd[12];


            xlsSheet[i, j + 27].Value = AllSumVnd[13];


            xlsSheet[i, j + 28].Value = AllSumVnd[14];

            xlsSheet[i, j + 29].Value = AllSumUsd[15];
            xlsSheet[i, j + 30].Value = AllSumVnd[15];

            xlsSheet[i, j + 31].Value = AllSumUsd[16];
            xlsSheet[i, j + 32].Value = AllSumVnd[16];

            xlsSheet[i, j + 33].Value = AllSumUsd[17];
            xlsSheet[i, j + 34].Value = AllSumVnd[17];

            xlsSheet[i, j + 35].Value = AllSumUsd[18];
            xlsSheet[i, j + 36].Value = AllSumVnd[18];

            XLCellRange mrCell = new XLCellRange(i, i, 1, 3);
            xlsSheet.MergedCells.Add(mrCell);
            xlsSheet[i, 1].Value = "Tổng Cộng";

            for (int m = 0; m < 37; m++)
            {
                xlsSheet[i, m + j].Style = xlstStyleB1;
            }
            ///////////////////////////////
            xlsSheet[i, 4 + j].Style = xlstStyleB0;
            xlsSheet[i, 6 + j].Style = xlstStyleB0;
            xlsSheet[i, 8 + j].Style = xlstStyleB0;
            xlsSheet[i, 10 + j].Style = xlstStyleB0;
            xlsSheet[i, 11 + j].Style = xlstStyleB0;
            xlsSheet[i, 12 + j].Style = xlstStyleB0;
            xlsSheet[i, 14 + j].Style = xlstStyleB0;
            xlsSheet[i, 16 + j].Style = xlstStyleB0;
            xlsSheet[i, 18 + j].Style = xlstStyleB0;
            xlsSheet[i, j + 20].Style = xlstStyleB0;
            xlsSheet[i, j + 22].Style = xlstStyleB0;
            xlsSheet[i, j + 24].Style = xlstStyleB0;
            xlsSheet[i, j + 26].Style = xlstStyleB0;
            xlsSheet[i, j + 27].Style = xlstStyleB0;
            xlsSheet[i, j + 28].Style = xlstStyleB0;
            xlsSheet[i, j + 30].Style = xlstStyleB0;
            xlsSheet[i, j + 32].Style = xlstStyleB0;
            xlsSheet[i, j + 34].Style = xlstStyleB0;
            xlsSheet[i, j + 36].Style = xlstStyleB0;
            ///////////////////////////////
            XLSheet source = xlbBook.Sheets["tpl"];

            for (int row = 2; row <= 4; row++)
            {
                for (int col = 1; col <= 17; col++)
                {
                    xlsSheet[row, col].Style = source[row, col].Style;
                    xlsSheet[row, col].Value = source[row, col].Value;
                }
            }

            for (int row = 6; row <= 8; row++)
            {
                for (int col = 4; col <= 23; col++)
                {
                    xlsSheet[row - 4, col + 14].Style = source[row, col].Style;
                    xlsSheet[row - 4, col + 14].Value = source[row, col].Value;
                }
            }

            mrCell = new XLCellRange(2, 4, 1, 1);
            xlsSheet.MergedCells.Add(mrCell);

            mrCell = new XLCellRange(2, 4, 2, 2);
            xlsSheet.MergedCells.Add(mrCell);

            mrCell = new XLCellRange(2, 4, 3, 3);
            xlsSheet.MergedCells.Add(mrCell);

            mrCell = new XLCellRange(2, 2, 4, 17);
            xlsSheet.MergedCells.Add(mrCell);

            mrCell = new XLCellRange(2, 2, 20, 33);
            xlsSheet.MergedCells.Add(mrCell);

            for (int m = 0; m < 17; m++)
            {
                //mrCell = new XLCellRange(2, 2, 4 + m, 17 + m);
                //xlsSheet.MergedCells.Add(mrCell);

                mrCell = new XLCellRange(3, 3, 4 + m, 5 + m);
                xlsSheet.MergedCells.Add(mrCell);

                mrCell = new XLCellRange(3, 3, 6 + m, 7 + m);
                xlsSheet.MergedCells.Add(mrCell);

                mrCell = new XLCellRange(3, 3, 8 + m, 9 + m);
                xlsSheet.MergedCells.Add(mrCell);

                mrCell = new XLCellRange(3, 3, 10 + m, 11 + m);
                xlsSheet.MergedCells.Add(mrCell);

                mrCell = new XLCellRange(3, 3, 14 + m, 15 + m);
                xlsSheet.MergedCells.Add(mrCell);

                mrCell = new XLCellRange(3, 3, 16 + m, 17 + m);
                xlsSheet.MergedCells.Add(mrCell);

                mrCell = new XLCellRange(2, 3, 18 + m, 19 + m);
                xlsSheet.MergedCells.Add(mrCell);

                mrCell = new XLCellRange(2, 3, 20 + m, 21 + m);
                xlsSheet.MergedCells.Add(mrCell);

                m += 15;
            }

            xlbBook.Save(fileNameDes);
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('../" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);

        }
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport2_Click(object sender, EventArgs e)
        {
            string buildingId = Func.ParseString(Session["__BUILDINGID__"]);
            string sql = "Select CustomerId, Name From Customer Where BuildingId = '" + buildingId + "' and DelFlag = 0 order by CustomerId";
            Hashtable CusList = new Hashtable();
            DataTable dtCus = DbHelper.GetDataTable(sql);
            foreach (DataRow drCus in dtCus.Rows)
            {
                if (!CusList.Contains(drCus["CustomerId"].ToString()))
                {
                    CusList.Add(drCus["CustomerId"].ToString(), drCus["Name"].ToString());
                }
            }

            Hashtable PaymentList = new Hashtable();
            sql = "Select * from v_PaymentBillDetailGeneral Where BuildingId = '" + buildingId + "' order by CustomerId";

            DataTable dt = DbHelper.GetDataTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                string CustomerId = dr["CustomerId"].ToString();
                string key = CustomerId;
                DeptInfo tmp;

                if (!PaymentList.Contains(key))
                {
                    tmp = new DeptInfo();
                    tmp.CustomerId = CustomerId;
                    tmp.Customer = Func.ParseString(CusList[CustomerId]);
                    PaymentList.Add(key, tmp);
                }
                string PaymentType = dr["PaymentType"].ToString();

                decimal MoneyUSD = Convert.ToDecimal(dr["MoneyUSD"]);
                decimal MoneyVND = Convert.ToDecimal(dr["MoneyVND"]);
                decimal PaidUSD = Convert.ToDecimal(dr["PaidUSD"]);
                decimal PaidVND = Convert.ToDecimal(dr["PaidVND"]);

                tmp = (DeptInfo)PaymentList[key];
                switch (PaymentType)
                {
                    case "1":
                        tmp.RentUSD = MoneyUSD;
                        tmp.RentVND = MoneyVND;
                        tmp.RentPaidUSD = PaidUSD;
                        tmp.RentPaidVND = PaidVND;
                        break;
                    case "2":
                        tmp.ManagerUSD = MoneyUSD;
                        tmp.ManagerVND = MoneyVND;
                        tmp.ManagerPaidUSD = PaidUSD;
                        tmp.ManagerPaidVND = PaidVND;
                        break;
                    case "3":
                        tmp.ParkingUSD = MoneyUSD;
                        tmp.ParkingVND = MoneyVND;
                        tmp.ParkingPaidUSD = PaidUSD;
                        tmp.ParkingPaidVND = PaidVND;
                        break;
                    case "4":
                        tmp.ExtraUSD = MoneyUSD;
                        tmp.ExtraVND = MoneyVND;
                        tmp.ExtraPaidUSD = PaidUSD;
                        tmp.ExtraPaidVND = PaidVND;
                        break;
                    case "5":
                        tmp.ElecUSD = MoneyUSD;
                        tmp.ElecVND = MoneyVND;
                        tmp.ElecPaidUSD = PaidUSD;
                        tmp.ElecPaidVND = PaidVND;
                        break;
                    case "6":
                        tmp.WaterUSD = MoneyUSD;
                        tmp.WaterVND = MoneyVND;
                        tmp.WaterPaidUSD = PaidUSD;
                        tmp.WaterPaidVND = PaidVND;
                        break;
                    case "7":
                        tmp.ServiceUSD = MoneyUSD;
                        tmp.ServiceVND = MoneyVND;
                        tmp.ServicePaidUSD = PaidUSD;
                        tmp.ServicePaidVND = PaidVND;
                        break;
                    case "8":
                        tmp.BookingUSD = MoneyUSD;
                        tmp.BookingVND = MoneyVND;
                        tmp.BookingPaidUSD = PaidUSD;
                        tmp.BookingPaidVND = PaidVND;
                        break;
                    default:
                        break;
                }
            }

            C1XLBook xlbBook = new C1XLBook();

            string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\BaoCaoCongNo_TongQuat.xlsx");
            if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BaoCaoCongNo"))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BaoCaoCongNo"));
            }

            string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\BaoCaoCongNo\BaoCaoCongNo_TongQuat" + strDT + ".xlsx";
            string strFilePathExport = "Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + "/BaoCaoCongNo/BaoCaoCongNo_TongQuat" + strDT + ".xlsx";

            string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

            //string fileNameDes = HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\TongHopDienTich" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx");
            File.Copy(fileName, fileNameDes);

            xlbBook.Load(fileNameDes);

            XLStyle xlstStyle2 = new XLStyle(xlbBook);
            xlstStyle2.AlignVert = XLAlignVertEnum.Center;
            xlstStyle2.WordWrap = false;
            xlstStyle2.Font = new Font("", 8, FontStyle.Regular);
            xlstStyle2.SetBorderColor(Color.Black);
            xlstStyle2.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyle2.BorderTop = XLLineStyleEnum.Thin;
            xlstStyle2.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyle2.BorderRight = XLLineStyleEnum.Thin;
            xlstStyle2.Format = "#,##0.00_);(#,##0.00)";

            XLStyle xlstStyle1 = new XLStyle(xlbBook);
            xlstStyle1.AlignVert = XLAlignVertEnum.Center;
            xlstStyle1.WordWrap = false;
            xlstStyle1.Font = new Font("", 8, FontStyle.Regular);
            xlstStyle1.SetBorderColor(Color.Black);
            xlstStyle1.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyle1.BorderTop = XLLineStyleEnum.Thin;
            xlstStyle1.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyle1.BorderRight = XLLineStyleEnum.Thin;
            xlstStyle1.Format = "#,##0.0_);(#,##0.0)";

            XLStyle xlstStyle0 = new XLStyle(xlbBook);
            xlstStyle0.AlignVert = XLAlignVertEnum.Center;
            xlstStyle0.WordWrap = false;
            xlstStyle0.Font = new Font("", 8, FontStyle.Regular);
            xlstStyle0.SetBorderColor(Color.Black);
            xlstStyle0.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyle0.BorderTop = XLLineStyleEnum.Thin;
            xlstStyle0.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyle0.BorderRight = XLLineStyleEnum.Thin;
            xlstStyle0.Format = "#,##0_);(#,##0)";

            XLStyle xlstStyleB2 = new XLStyle(xlbBook);
            xlstStyleB2.AlignHorz = XLAlignHorzEnum.Right;
            xlstStyleB2.AlignVert = XLAlignVertEnum.Center;
            xlstStyleB2.WordWrap = false;
            xlstStyleB2.Font = new Font("", 8, FontStyle.Bold);
            xlstStyleB2.SetBorderColor(Color.Black);
            xlstStyleB2.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleB2.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleB2.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleB2.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleB2.Format = "#,##0.00_);(#,##0.00)";

            XLStyle xlstStyleB1 = new XLStyle(xlbBook);
            xlstStyleB1.AlignHorz = XLAlignHorzEnum.Right;
            xlstStyleB1.AlignVert = XLAlignVertEnum.Center;
            xlstStyleB1.WordWrap = false;
            xlstStyleB1.Font = new Font("", 8, FontStyle.Bold);
            xlstStyleB1.SetBorderColor(Color.Black);
            xlstStyleB1.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleB1.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleB1.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleB1.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleB1.Format = "#,##0.0_);(#,##0.0)";

            XLStyle xlstStyleB0 = new XLStyle(xlbBook);
            xlstStyleB0.AlignHorz = XLAlignHorzEnum.Right;
            xlstStyleB0.AlignVert = XLAlignVertEnum.Center;
            xlstStyleB0.WordWrap = false;
            xlstStyleB0.Font = new Font("", 8, FontStyle.Bold);
            xlstStyleB0.SetBorderColor(Color.Black);
            xlstStyleB0.BorderBottom = XLLineStyleEnum.Thin;
            xlstStyleB0.BorderTop = XLLineStyleEnum.Thin;
            xlstStyleB0.BorderLeft = XLLineStyleEnum.Thin;
            xlstStyleB0.BorderRight = XLLineStyleEnum.Thin;
            xlstStyleB0.Format = "#,##0_);(#,##0)";

            decimal[] AllSumUsd = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            decimal[] AllSumVnd = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            string sheet = "BaoCao";

            XLSheet xlsSheet = xlbBook.Sheets[sheet];
            int i = 5;

            xlsSheet[0, 1].Value = xlsSheet[0, 1].Value.ToString().Replace("{%TOA_NHA%}", DbHelper.GetScalar("Select Name From Mst_Building Where BuildingId = '" + buildingId + "'"));
            int j = 1;
            foreach (DictionaryEntry tmp in PaymentList)
            {
                string key = (string)tmp.Key;
                DeptInfo dept = (DeptInfo)tmp.Value;

                xlsSheet[i, 0 + j].Value = Func.ParseString(i - 4);
                xlsSheet[i, 1 + j].Value = dept.CustomerId;
                xlsSheet[i, 2 + j].Value = dept.Customer;

                xlsSheet[i, 3 + j].Value = dept.RentUSD;
                xlsSheet[i, 4 + j].Value = dept.RentVND;

                xlsSheet[i, 5 + j].Value = dept.ManagerUSD;
                xlsSheet[i, 6 + j].Value = dept.ManagerVND;

                xlsSheet[i, 7 + j].Value = dept.ParkingUSD;
                xlsSheet[i, 8 + j].Value = dept.ParkingVND;

                xlsSheet[i, 9 + j].Value = dept.ExtraUSD;
                xlsSheet[i, 10 + j].Value = dept.ExtraVND;

                //xlsSheet[i, 11 + j].Value = dept.ElecUSD;
                xlsSheet[i, 11 + j].Value = dept.ElecVND;

                //xlsSheet[i, 13 + j].Value = dept.WaterUSD;
                xlsSheet[i, 12 + j].Value = dept.WaterVND;

                xlsSheet[i, 13 + j].Value = dept.ServiceUSD;
                xlsSheet[i, 14 + j].Value = dept.ServiceVND;

                xlsSheet[i, 15 + j].Value = dept.BookingUSD;
                xlsSheet[i, 16 + j].Value = dept.BookingVND;

                xlsSheet[i, 17 + j].Value = dept.SumUSD();
                xlsSheet[i, 18 + j].Value = dept.SumVND();

                //-----------------------
                xlsSheet[i, j + 19].Value = dept.RentPaidUSD;
                xlsSheet[i, j + 20].Value = dept.RentPaidVND;

                xlsSheet[i, j + 21].Value = dept.ManagerPaidUSD;
                xlsSheet[i, j + 22].Value = dept.ManagerPaidVND;

                xlsSheet[i, j + 23].Value = dept.ParkingPaidUSD;
                xlsSheet[i, j + 24].Value = dept.ParkingPaidVND;

                xlsSheet[i, j + 25].Value = dept.ExtraPaidUSD;
                xlsSheet[i, j + 26].Value = dept.ExtraPaidVND;

                //xlsSheet[i, 11 + j + 18].Value = dept.ElecPaidUSD;
                xlsSheet[i, j + 27].Value = dept.ElecPaidVND;

                //xlsSheet[i, 13 + j + 18].Value = dept.WaterPaidUSD;
                xlsSheet[i, j + 28].Value = dept.WaterPaidVND;

                xlsSheet[i, j + 29].Value = dept.ServicePaidUSD;
                xlsSheet[i, j + 30].Value = dept.ServicePaidVND;

                xlsSheet[i, j + 31].Value = dept.BookingPaidUSD;
                xlsSheet[i, j + 32].Value = dept.BookingPaidVND;

                xlsSheet[i, j + 33].Value = dept.SumPaidUSD();
                xlsSheet[i, j + 34].Value = dept.SumPaidVND();

                xlsSheet[i, j + 35].Value = dept.SumUSD() - dept.SumPaidUSD();
                xlsSheet[i, j + 36].Value = dept.SumVND() - dept.SumPaidVND();

                /////////////////
                AllSumUsd[0] += dept.RentUSD;
                AllSumVnd[0] += dept.RentVND;

                AllSumUsd[1] += dept.ManagerUSD;
                AllSumVnd[1] += dept.ManagerVND;

                AllSumUsd[2] += dept.ParkingUSD;
                AllSumVnd[2] += dept.ParkingVND;

                AllSumUsd[3] += dept.ExtraUSD;
                AllSumVnd[3] += dept.ExtraVND;

                AllSumUsd[4] += dept.ElecUSD;
                AllSumVnd[4] += dept.ElecVND;

                AllSumUsd[5] += dept.WaterUSD;
                AllSumVnd[5] += dept.WaterVND;

                AllSumUsd[6] += dept.ServiceUSD;
                AllSumVnd[6] += dept.ServiceVND;

                AllSumUsd[7] += dept.BookingUSD;
                AllSumVnd[7] += dept.BookingVND;

                AllSumUsd[8] += dept.SumUSD();
                AllSumVnd[8] += dept.SumVND();

                //-----------------------		
                AllSumUsd[9] += dept.RentPaidUSD;
                AllSumVnd[9] += dept.RentPaidVND;

                AllSumUsd[10] += dept.ManagerPaidUSD;
                AllSumVnd[10] += dept.ManagerPaidVND;

                AllSumUsd[11] += dept.ParkingPaidUSD;
                AllSumVnd[11] += dept.ParkingPaidVND;

                AllSumUsd[12] += dept.ExtraPaidUSD;
                AllSumVnd[12] += dept.ExtraPaidVND;

                AllSumUsd[13] += dept.ElecPaidUSD;
                AllSumVnd[13] += dept.ElecPaidVND;

                AllSumUsd[14] += dept.WaterPaidUSD;
                AllSumVnd[14] += dept.WaterPaidVND;

                AllSumUsd[15] += dept.ServicePaidUSD;
                AllSumVnd[15] += dept.ServicePaidVND;

                AllSumUsd[16] += dept.BookingPaidUSD;
                AllSumVnd[16] += dept.BookingPaidVND;

                AllSumUsd[17] += dept.SumPaidUSD();
                AllSumVnd[17] += dept.SumPaidVND();

                AllSumUsd[18] += dept.SumUSD() - dept.SumPaidUSD();
                AllSumVnd[18] += dept.SumVND() - dept.SumPaidVND();

                for (int m = 0; m < 37; m++)
                {
                    xlsSheet[i, m + j].Style = xlstStyle1;
                }
                ////////////////////////////////////////////
                xlsSheet[i, 4 + j].Style = xlstStyle0;
                xlsSheet[i, 6 + j].Style = xlstStyle0;
                xlsSheet[i, 8 + j].Style = xlstStyle0;
                xlsSheet[i, 10 + j].Style = xlstStyle0;
                xlsSheet[i, 11 + j].Style = xlstStyle0;
                xlsSheet[i, 12 + j].Style = xlstStyle0;
                xlsSheet[i, 14 + j].Style = xlstStyle0;
                xlsSheet[i, 16 + j].Style = xlstStyle0;
                xlsSheet[i, 18 + j].Style = xlstStyle0;
                xlsSheet[i, j + 20].Style = xlstStyle0;
                xlsSheet[i, j + 22].Style = xlstStyle0;
                xlsSheet[i, j + 24].Style = xlstStyle0;
                xlsSheet[i, j + 26].Style = xlstStyle0;
                xlsSheet[i, j + 27].Style = xlstStyle0;
                xlsSheet[i, j + 28].Style = xlstStyle0;
                xlsSheet[i, j + 30].Style = xlstStyle0;
                xlsSheet[i, j + 32].Style = xlstStyle0;
                xlsSheet[i, j + 34].Style = xlstStyle0;
                xlsSheet[i, j + 36].Style = xlstStyle0;

                i++;
            }
            xlsSheet[i, 3 + j].Value = AllSumUsd[0];
            xlsSheet[i, 4 + j].Value = AllSumVnd[0];

            xlsSheet[i, 5 + j].Value = AllSumUsd[1];
            xlsSheet[i, 6 + j].Value = AllSumVnd[1];

            xlsSheet[i, 7 + j].Value = AllSumUsd[2];
            xlsSheet[i, 8 + j].Value = AllSumVnd[2];

            xlsSheet[i, 9 + j].Value = AllSumUsd[3];
            xlsSheet[i, 10 + j].Value = AllSumVnd[3];


            xlsSheet[i, 11 + j].Value = AllSumVnd[4];


            xlsSheet[i, 12 + j].Value = AllSumVnd[5];

            xlsSheet[i, 13 + j].Value = AllSumUsd[6];
            xlsSheet[i, 14 + j].Value = AllSumVnd[6];

            xlsSheet[i, 15 + j].Value = AllSumUsd[7];
            xlsSheet[i, 16 + j].Value = AllSumVnd[7];

            xlsSheet[i, 17 + j].Value = AllSumUsd[8];
            xlsSheet[i, 18 + j].Value = AllSumVnd[8];

            //-----------------------							                //-----------------------			
            xlsSheet[i, j + 19].Value = AllSumUsd[9];
            xlsSheet[i, j + 20].Value = AllSumVnd[9];

            xlsSheet[i, j + 21].Value = AllSumUsd[10];
            xlsSheet[i, j + 22].Value = AllSumVnd[10];

            xlsSheet[i, j + 23].Value = AllSumUsd[11];
            xlsSheet[i, j + 24].Value = AllSumVnd[11];

            xlsSheet[i, j + 25].Value = AllSumUsd[12];
            xlsSheet[i, j + 26].Value = AllSumVnd[12];


            xlsSheet[i, j + 27].Value = AllSumVnd[13];


            xlsSheet[i, j + 28].Value = AllSumVnd[14];

            xlsSheet[i, j + 29].Value = AllSumUsd[15];
            xlsSheet[i, j + 30].Value = AllSumVnd[15];

            xlsSheet[i, j + 31].Value = AllSumUsd[16];
            xlsSheet[i, j + 32].Value = AllSumVnd[16];

            xlsSheet[i, j + 33].Value = AllSumUsd[17];
            xlsSheet[i, j + 34].Value = AllSumVnd[17];

            xlsSheet[i, j + 35].Value = AllSumUsd[18];
            xlsSheet[i, j + 36].Value = AllSumVnd[18];

            XLCellRange mrCell = new XLCellRange(i, i, 1, 3);
            xlsSheet.MergedCells.Add(mrCell);
            xlsSheet[i, 1].Value = "Tổng Cộng";

            for (int m = 0; m < 37; m++)
            {
                xlsSheet[i, m + j].Style = xlstStyleB1;
            }

            /////////////////////////////////////////
            xlsSheet[i, 4 + j].Style = xlstStyleB0;
            xlsSheet[i, 6 + j].Style = xlstStyleB0;
            xlsSheet[i, 8 + j].Style = xlstStyleB0;
            xlsSheet[i, 10 + j].Style = xlstStyleB0;
            xlsSheet[i, 11 + j].Style = xlstStyleB0;
            xlsSheet[i, 12 + j].Style = xlstStyleB0;
            xlsSheet[i, 14 + j].Style = xlstStyleB0;
            xlsSheet[i, 16 + j].Style = xlstStyleB0;
            xlsSheet[i, 18 + j].Style = xlstStyleB0;
            xlsSheet[i, j + 20].Style = xlstStyleB0;
            xlsSheet[i, j + 22].Style = xlstStyleB0;
            xlsSheet[i, j + 24].Style = xlstStyleB0;
            xlsSheet[i, j + 26].Style = xlstStyleB0;
            xlsSheet[i, j + 27].Style = xlstStyleB0;
            xlsSheet[i, j + 28].Style = xlstStyleB0;
            xlsSheet[i, j + 30].Style = xlstStyleB0;
            xlsSheet[i, j + 32].Style = xlstStyleB0;
            xlsSheet[i, j + 34].Style = xlstStyleB0;
            xlsSheet[i, j + 36].Style = xlstStyleB0;
            /////////////////////////////////////////
            XLSheet source = xlbBook.Sheets["tpl"];

            for (int row = 2; row <= 4; row++)
            {
                for (int col = 1; col <= 17; col++)
                {
                    xlsSheet[row, col].Style = source[row, col].Style;
                    xlsSheet[row, col].Value = source[row, col].Value;
                }
            }

            for (int row = 6; row <= 8; row++)
            {
                for (int col = 4; col <= 23; col++)
                {
                    xlsSheet[row - 4, col + 14].Style = source[row, col].Style;
                    xlsSheet[row - 4, col + 14].Value = source[row, col].Value;
                }
            }

            mrCell = new XLCellRange(2, 4, 1, 1);
            xlsSheet.MergedCells.Add(mrCell);

            mrCell = new XLCellRange(2, 4, 2, 2);
            xlsSheet.MergedCells.Add(mrCell);

            mrCell = new XLCellRange(2, 4, 3, 3);
            xlsSheet.MergedCells.Add(mrCell);

            mrCell = new XLCellRange(2, 2, 4, 17);
            xlsSheet.MergedCells.Add(mrCell);

            mrCell = new XLCellRange(2, 2, 20, 33);
            xlsSheet.MergedCells.Add(mrCell);

            for (int m = 0; m < 17; m++)
            {
                mrCell = new XLCellRange(3, 3, 4 + m, 5 + m);
                xlsSheet.MergedCells.Add(mrCell);

                mrCell = new XLCellRange(3, 3, 6 + m, 7 + m);
                xlsSheet.MergedCells.Add(mrCell);

                mrCell = new XLCellRange(3, 3, 8 + m, 9 + m);
                xlsSheet.MergedCells.Add(mrCell);

                mrCell = new XLCellRange(3, 3, 10 + m, 11 + m);
                xlsSheet.MergedCells.Add(mrCell);

                mrCell = new XLCellRange(3, 3, 14 + m, 15 + m);
                xlsSheet.MergedCells.Add(mrCell);

                mrCell = new XLCellRange(3, 3, 16 + m, 17 + m);
                xlsSheet.MergedCells.Add(mrCell);

                mrCell = new XLCellRange(2, 3, 18 + m, 19 + m);
                xlsSheet.MergedCells.Add(mrCell);

                mrCell = new XLCellRange(2, 3, 20 + m, 21 + m);
                xlsSheet.MergedCells.Add(mrCell);

                m += 15;
            }

            xlbBook.Save(fileNameDes);
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('../" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);

        }
        protected void btnParkingOffDays_Click(object sender, EventArgs e)
        {
            PopupWidth = 600;
            PopupHeight = 600;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('../Building/BD_ParkingOffDays.aspx'," + PopupWidth + "," + PopupHeight + ",'" + editPageName + "', true);", true);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string yearmonth = drpYear.SelectedValue + drpMonth.SelectedValue;

            if (!(yearmonth.Equals(DateTime.Now.ToString("yyyyMM")) || yearmonth.Equals((DateTime.Now.AddMonths(-1).ToString("yyyyMM")))))
            {
                mvMessage.AddError("Chỉ thực hiện được trong tháng hoặc tháng trước");
                return;
            }
            int count = DbHelper.GetCount("Select count(*) from BD_RentDays Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'");
            if (count > 0)
            {
                DbHelper.ExecuteNonQuery("Update BD_RentDays Set RentDays = " + txtRentDays.Text + ", Modified = '" + DateTime.Now.ToString("yyyyMMddHHmmss") + "', ModifiedBy = '" + Page.User.Identity.Name + "' Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'");
            }
            else
            {
                BD_RentDaysData data = new BD_RentDaysData();
                ITransaction tran = factory.GetInsertObject(data);
                data.RentDays = txtRentDays.Text.Trim();
                data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);
                data.YearMonth = drpYear.SelectedValue + drpMonth.SelectedValue;
                data.ModifiedBy = Page.User.Identity.Name;
                data.CreatedBy = Page.User.Identity.Name;
                data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag = "0";
                Execute(tran);

                if (!HasError)
                {
                }
            }
            using (SqlConnection con = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
            {
                con.Open();
                using (SqlCommand cm = new SqlCommand("sp_PaymentDetail4Building", con))
                {
                    try
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@BuildingId", Func.ParseString(Session["__BUILDINGID__"]));
                        cm.Parameters.AddWithValue("@YearMonth", yearmonth);
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
                        mvMessage.SetCompleteMessage("Đã thực hiện quyết sổ Công Nợ tháng thành công");
                        con.Close();
                    }
                }
            }
            ShowData();
        }
        private string GetWhere()
        {
            string whereClause = string.Empty;

            if (txtID.Text.Trim().Length != 0)
            {
                whereClause += " AND A.CustomerId LIKE '%" + txtID.Text.Trim() + "%'";
            }
            if (txtName.Text.Trim().Length != 0)
            {
                whereClause += " AND Name LIKE N'%" + txtName.Text.Trim() + "%'";
            }
            if (txtPhone.Text.Trim().Length != 0)
            {
                whereClause += " AND Phone LIKE '%" + txtPhone.Text.Trim() + "%'";
            }
            if (txtEmail.Text.Trim().Length != 0)
            {
                whereClause += " AND Email LIKE '%" + txtEmail.Text.Trim() + "%'";
            }
            if (txtContactName.Text.Trim().Length != 0)
            {
                whereClause += " AND ContactName LIKE N'%" + txtContactName.Text.Trim() + "%'";
            }
            if (rdoActive.Checked)
            {
                whereClause += " AND DelFlag <> 1";

            }
            else if (rdoInActive.Checked)
            {
                whereClause += " AND DelFlag = 1";
            }
            return whereClause;
        }
        protected void btnViewMulti_Click(object sender, EventArgs e)
        {
            Export();

            //ViewMultiBoth();
            return;
            string lsYearmonth = "'" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";
            //foreach (ListItem lstItem in lstSelectedYearMonth.Items)
            //{
            //    lsYearmonth += ",'" + lstItem.Value + "'";
            //}
            //if (String.IsNullOrEmpty(lsYearmonth))
            //{
            //    mvMessage.AddError("Phải chọn ít nhất 1 tháng");
            //    return;
            //}
            //lsYearmonth = lsYearmonth.Substring(1);

            int rBillNo = 0;
            int cBillNo = 1;

            int rBillDate = 0;
            int cBillDate = 10;

            int rBillMonth = 2;
            int cBillMonth = 0;

            int rContact = 5;
            int cContact = 3;

            int rCustomer = 5;
            int cCustomer = 9;

            int rContract = 7;
            int cContract = 1;

            int rRate = 11;
            int cRate = 9;

            int rRateDate = 11;
            int cRateDate = 12;

            int rRent = 15;

            int rManager = 23;

            int rParking = 31;

            int rExtra = 39;

            int rElec = 47;

            int rWater = 55;

            int rService = 63;

            int rPaid = 70;

            int rDept = 77;

            int rOffice = 88;
            int cOffice = 3;

            int rPhone = 89;
            int cPhone = 3;

            int rBank = 89;
            int cBank = 7;

            int rAccountName = 91;
            int cAccountName = 7;

            int rAccount = 92;
            int cAccount = 7;

            int rSum = 81;
            int cSum = 11;

            int rSumRead = 82;
            int cSumRead = 13;

            using (SqlDatabase db = new SqlDatabase())
            {

                DataSet ds = new DataSet();
                DataSet dsCus = new DataSet();

                string sql = string.Empty;

                string Bank = "";
                string Account = "";
                string AccountName = "";
                string Office = "";
                string OfficeAddress = "";
                string OfficePhone = "";

                ds = new DataSet();
                sql = " SELECT Bank,Account,AccountName,Office,OfficeAddress,OfficePhone";
                sql += " FROM Mst_Building";
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' ";
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);

                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            Bank = rowType["Bank"].ToString();
                            Account = rowType["Account"].ToString();
                            AccountName = rowType["AccountName"].ToString();
                            Office = rowType["Office"].ToString();
                            OfficeAddress = rowType["OfficeAddress"].ToString();
                            OfficePhone = rowType["OfficePhone"].ToString();
                        }
                    }
                }

                //Danh sách Bill
                sql = "  Select BillDate,UsdExchangeDate,UsdExchange,BillNo,B.Name,B.ContactName,A.CustomerId ";
                sql += " From	PaymentBillInfo A, Customer B";
                sql += " Where	A.BuildingId = B.BuildingId and A.CustomerId = B.CustomerId and B.DelFlag = 0 and A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";

                string BillDate = "";
                string UsdExchangeDate = "";
                string UsdExchange = "";
                string BillNo = "";
                string Name = "";
                string ContactName = "";
                string CustomerId = "";

                using (SqlCommand cmCus = db.CreateCommand(sql))
                {
                    SqlDataAdapter daCus = new SqlDataAdapter(cmCus);
                    daCus.Fill(dsCus);

                    if (dsCus != null)
                    {
                        string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");

                        DataTable dtCus = dsCus.Tables[0];
                        foreach (DataRow rowCus in dtCus.Rows)
                        {
                            BillDate = rowCus[0].ToString();
                            UsdExchangeDate = rowCus[1].ToString();
                            UsdExchange = rowCus[2].ToString();
                            BillNo = rowCus[3].ToString();
                            Name = rowCus[4].ToString();
                            ContactName = rowCus[5].ToString();
                            CustomerId = rowCus[6].ToString();

                            C1XLBook xlbBook = new C1XLBook();
                            //ShowData(drpYear.SelectedValue + drpMonth.SelectedValue);
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
                            xlstStyle.Format = "#,##0.00_);(#,##0.00)";

                            XLStyle xlstStyleH = new XLStyle(xlbBook);
                            xlstStyleH.AlignHorz = XLAlignHorzEnum.Center;
                            xlstStyleH.AlignVert = XLAlignVertEnum.Center;
                            xlstStyleH.Font = new Font("", 8, FontStyle.Bold);
                            xlstStyleH.SetBorderColor(Color.Black);
                            xlstStyleH.BorderBottom = XLLineStyleEnum.Thin;
                            xlstStyleH.BorderTop = XLLineStyleEnum.Thin;
                            xlstStyleH.BorderLeft = XLLineStyleEnum.Thin;
                            xlstStyleH.BorderRight = XLLineStyleEnum.Thin;
                            xlstStyleH.WordWrap = true;

                            XLStyle xlstStyleSum = new XLStyle(xlbBook);
                            xlstStyleSum.AlignHorz = XLAlignHorzEnum.Right;
                            xlstStyleSum.AlignVert = XLAlignVertEnum.Center;
                            xlstStyleSum.Font = new Font("", 8, FontStyle.Bold);
                            xlstStyleSum.SetBorderColor(Color.Black);
                            xlstStyleSum.BorderBottom = XLLineStyleEnum.Thin;
                            xlstStyleSum.BorderTop = XLLineStyleEnum.Thin;
                            xlstStyleSum.BorderLeft = XLLineStyleEnum.Thin;
                            xlstStyleSum.BorderRight = XLLineStyleEnum.Thin;
                            xlstStyleSum.WordWrap = true;

                            string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\BillTongQuat.xlsx");
                            if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"])));
                            }

                            string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\" + CustomerId + strDT + ".xlsx";
                            string strFilePathExport = @"../../Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + @"/" + CustomerId + strDT + ".xlsx";

                            string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

                            //string fileNameDes = HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\TongHopDienTich" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
                            File.Copy(fileName, fileNameDes);

                            xlbBook.Load(fileNameDes);
                            XLSheet xlsSheet = xlbBook.Sheets["TongHop"];

                            //Thông tin về Ngân hàng của Tòa Nhà
                            xlsSheet[rOffice, cOffice].Value = xlsSheet[rOffice, cOffice].Value.ToString().Replace("{%VAN_PHONG%}", Office);
                            xlsSheet[rPhone, cPhone].Value = xlsSheet[rPhone, cPhone].Value.ToString().Replace("{%DIEN_THOAI%}", OfficePhone);

                            xlsSheet[rBank, cBank].Value = xlsSheet[rBank, cBank].Value.ToString().Replace("{%NGAN_HANG%}", Bank);
                            xlsSheet[rAccountName, cAccountName].Value = xlsSheet[rAccountName, cAccountName].Value.ToString().Replace("{%TEN_TAI_KHOAN%}", AccountName);
                            xlsSheet[rAccount, cAccount].Value = xlsSheet[rAccount, cAccount].Value.ToString().Replace("{%SO_TAI_KHOAN%}", Account);
                            //Thông tin về Ngân hàng của Tòa Nhà

                            //Customer
                            xlsSheet[rCustomer, cCustomer].Value = xlsSheet[rCustomer, cCustomer].Value.ToString().Replace("{%TEN_CONG_TY%}", Name);
                            //Contact
                            xlsSheet[rContact, cContact].Value = xlsSheet[rContact, cContact].Value.ToString().Replace("{%NGUOI_DAI_DIEN%}", ContactName);

                            //Bill No
                            xlsSheet[rBillNo, cBillNo].Value = xlsSheet[rBillNo, cBillNo].Value.ToString().Replace("{%BILL_NO%}", BillNo);

                            //Ngay Thang Nam
                            DateTime dtime = DateTime.Today;

                            string strTmp = xlsSheet[rBillDate, cBillDate].Value.ToString().Replace("{%NGAY%}", dtime.ToString("dd"));
                            strTmp = strTmp.Replace("{%THANG%}", dtime.ToString("MM"));
                            xlsSheet[rBillDate, cBillDate].Value = strTmp.Replace("{%NAM%}", dtime.ToString("yyyy"));

                            //Nam
                            xlsSheet[rBillMonth, cBillMonth].Value = xlsSheet[rBillMonth, cBillMonth].Value.ToString().Replace("{%NAM_THANG%}", drpMonth.SelectedValue + "/" + drpYear.SelectedValue);

                            //Thông tin Tỉ giá
                            xlsSheet[rRate, cRate].Value = xlsSheet[rRate, cRate].Value.ToString().Replace("{%TI_GIA%}", UsdExchange);
                            xlsSheet[rRateDate, cRateDate].Value = xlsSheet[rRateDate, cRateDate].Value.ToString().Replace("{%NGAY_AP_DUNG%}", UsdExchangeDate);
                            //Thông tin Tỉ giá

                            Hashtable contractIdLst = new Hashtable();
                            string contract = "";

                            //Thue phong
                            ds = new DataSet();
                            sql = " Select *";
                            sql += " FROM PaymentRoom";
                            sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + CustomerId + "' and YearMonth in (" + lsYearmonth + ")";

                            int sumRow = 0;
                            int j = 0;
                            decimal[] LastSumPriceVND = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };
                            decimal[] LastSumPriceUSD = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };

                            decimal PaidPriceVND = 0;
                            decimal PaidPriceUSD = 0;

                            int line = 0;
                            using (SqlCommand cm = db.CreateCommand(sql))
                            {
                                SqlDataAdapter da = new SqlDataAdapter(cm);
                                da.Fill(ds);

                                line = rRent - 3 + j;

                                XLCellRange mCell = new XLCellRange(line, line + 2, 1, 3);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 4, 5);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 4, 5);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 2, line + 2, 4, 5);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);

                                if (ds != null)
                                {
                                    int count = 0;
                                    DataTable dt = ds.Tables[0];
                                    foreach (DataRow rowType in dt.Rows)
                                    {
                                        if (count >= 1)
                                        {
                                            xlsSheet.Rows.Insert(rRent + 1 + j);
                                            j++;
                                        }
                                        count++;
                                        int tmp = rRent + j;

                                        string ContractId = Func.ParseString(rowType["ContractId"]);
                                        string ContractNo = Func.ParseString(rowType["ContractNo"]);
                                        string YearMonth = Func.ParseString(rowType["YearMonth"]);

                                        string BeginContract = Func.ParseString(rowType["BeginContract"]);


                                        if (!contractIdLst.ContainsKey(ContractId + "(" + BeginContract.Substring(0, 10) + ")"))
                                        {
                                            contractIdLst.Add(ContractId + "(" + BeginContract.Substring(0, 10) + ")", ContractNo + "(" + BeginContract.Substring(0, 10) + ")");
                                            contract += ";" + ContractNo + "(" + BeginContract.Substring(0, 10) + ")";
                                        }

                                        xlsSheet[tmp, 1].Value = Func.ParseString(rowType["Name"]);
                                        xlsSheet[tmp, 4].Value = rowType["Area"];
                                        xlsSheet[tmp, 6].Value = rowType["MonthRentPriceUSD"];
                                        xlsSheet[tmp, 7].Value = rowType["MonthRentPriceVND"];

                                        xlsSheet[tmp, 8].Value = rowType["MonthRentSumUSD"];
                                        xlsSheet[tmp, 9].Value = rowType["MonthRentSumVND"];

                                        xlsSheet[tmp, 10].Value = rowType["VatRentPriceUSD"];
                                        xlsSheet[tmp, 11].Value = rowType["VatRentPriceVND"];

                                        xlsSheet[tmp, 12].Value = rowType["LastRentSumUSD"];
                                        xlsSheet[tmp, 13].Value = rowType["LastRentSumVND"];

                                        XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
                                        xlsSheet.MergedCells.Add(mrCell);

                                        mrCell = new XLCellRange(tmp, tmp, 4, 5);
                                        xlsSheet.MergedCells.Add(mrCell);

                                        LastSumPriceVND[0] += Convert.ToDecimal(rowType["LastRentSumVND"]);
                                        LastSumPriceUSD[0] += Convert.ToDecimal(rowType["LastRentSumUSD"]);

                                    }
                                    mCell = new XLCellRange(rRent + 1 + j, rRent + 1 + j, 1, 11);
                                    xlsSheet.MergedCells.Add(mCell);

                                    xlsSheet[rRent + 1 + j, 12].Value = LastSumPriceUSD[0];
                                    xlsSheet[rRent + 1 + j, 13].Value = LastSumPriceVND[0];

                                    for (int row = rRent + sumRow - 2; row <= rRent + dt.Rows.Count; row++)
                                    {
                                        for (int col = 1; col <= 13; col++)
                                        {
                                            xlsSheet[row, col].Style = xlstStyle;
                                        }
                                    }
                                    sumRow += dt.Rows.Count - 1;

                                    ////////////////////////
                                    for (int col = 1; col <= 11; col++)
                                    {
                                        xlsSheet[rRent + 1 + j, col].Style = xlstStyleSum;
                                    }
                                    line = rManager - 3 + j;
                                    mCell = new XLCellRange(line, line + 2, 1, 3);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 4, 5);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 4, 5);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 2, line + 2, 4, 5);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 6, 7);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 8, 9);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 10, 11);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 12, 13);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                                    xlsSheet.MergedCells.Add(mCell);

                                    count = 0;
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        if (count >= 1)
                                        {
                                            xlsSheet.Rows.Insert(rManager + 1 + j);
                                            j++;
                                        }
                                        count++;
                                        int tmp = rManager + j;

                                        xlsSheet[tmp, 1].Value = Func.ParseString(row["Name"]);
                                        xlsSheet[tmp, 4].Value = row["Area"];
                                        xlsSheet[tmp, 6].Value = row["MonthManagerPriceUSD"];
                                        xlsSheet[tmp, 7].Value = row["MonthManagerPriceVND"];

                                        xlsSheet[tmp, 8].Value = row["MonthManagerSumUSD"];
                                        xlsSheet[tmp, 9].Value = row["MonthManagerSumVND"];

                                        xlsSheet[tmp, 19].Value = row["VatManagerPriceUSD"];
                                        xlsSheet[tmp, 11].Value = row["VatManagerPriceVND"];

                                        xlsSheet[tmp, 12].Value = row["LastManagerSumUSD"];
                                        xlsSheet[tmp, 13].Value = row["LastManagerSumVND"];

                                        XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
                                        xlsSheet.MergedCells.Add(mrCell);

                                        mrCell = new XLCellRange(tmp, tmp, 4, 5);
                                        xlsSheet.MergedCells.Add(mrCell);

                                        LastSumPriceVND[1] += Convert.ToDecimal(row["LastManagerSumVND"]);
                                        LastSumPriceUSD[1] += Convert.ToDecimal(row["LastManagerSumUSD"]);
                                    }
                                    mCell = new XLCellRange(rManager + 1 + j, rManager + 1 + j, 1, 11);
                                    xlsSheet.MergedCells.Add(mCell);

                                    xlsSheet[rManager + 1 + j, 12].Value = LastSumPriceUSD[1];
                                    xlsSheet[rManager + 1 + j, 13].Value = LastSumPriceVND[1];

                                    for (int row = rManager + sumRow - 2; row <= rManager + sumRow + dt.Rows.Count; row++)
                                    {
                                        for (int col = 1; col <= 13; col++)
                                        {
                                            xlsSheet[row, col].Style = xlstStyle;
                                        }
                                    }

                                    for (int col = 1; col <= 11; col++)
                                    {
                                        xlsSheet[rManager + 1 + j, col].Style = xlstStyleSum;
                                    }
                                    sumRow += dt.Rows.Count - 1;

                                }
                            }

                            ds = new DataSet();
                            //Xuất ra toàn bộ nội dung theo Trang
                            sql = " SELECT COUNT(*) AS Num, YearMonth, TariffsParkingName, PriceVND, PriceUSD, SUM(VatVND) AS VatVND,SUM(VatUSD) AS VatUSD, SUM(SumVND) AS SumVND, SUM(SumUSD) AS SumUSD, SUM(LastPriceVND) AS LastPriceVND";
                            sql += "        , SUM(LastPriceUSD) AS LastPriceUSD";
                            sql += " FROM         dbo.PaymentParking";
                            sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + CustomerId + "' and YearMonth in (" + lsYearmonth + ")";
                            sql += " GROUP BY YearMonth, TariffsParkingName, PriceVND, PriceUSD, Vat, daysParking";

                            using (SqlCommand cm = db.CreateCommand(sql))
                            {
                                SqlDataAdapter da = new SqlDataAdapter(cm);
                                da.Fill(ds);

                                line = rParking - 3 + j;
                                XLCellRange mCell = new XLCellRange(line, line + 2, 1, 3);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 4, 5);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 4, 5);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 2, line + 2, 4, 5);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);
                                if (ds != null)
                                {
                                    int count = 0;
                                    DataTable dt = ds.Tables[0];

                                    foreach (DataRow row in dt.Rows)
                                    {
                                        if (count >= 1)
                                        {
                                            xlsSheet.Rows.Insert(rParking + 1 + j);
                                            j++;
                                        }
                                        count++;
                                        int tmp = rParking + j;

                                        string Num = Func.ParseString(row["Num"]);
                                        string TariffsParkingName = Func.ParseString(row["TariffsParkingName"]);

                                        xlsSheet[tmp, 1].Value = TariffsParkingName;
                                        xlsSheet[tmp, 4].Value = Num;
                                        xlsSheet[tmp, 6].Value = row["PriceUSD"];
                                        xlsSheet[tmp, 7].Value = row["PriceVND"];

                                        xlsSheet[tmp, 8].Value = row["SumUSD"];
                                        xlsSheet[tmp, 9].Value = row["SumVND"];

                                        xlsSheet[tmp, 10].Value = row["VatUSD"];
                                        xlsSheet[tmp, 11].Value = row["VatVND"];

                                        xlsSheet[tmp, 12].Value = row["LastPriceUSD"];
                                        xlsSheet[tmp, 13].Value = row["LastPriceVND"];

                                        XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
                                        xlsSheet.MergedCells.Add(mrCell);

                                        mrCell = new XLCellRange(tmp, tmp, 4, 5);
                                        xlsSheet.MergedCells.Add(mrCell);

                                        LastSumPriceVND[2] += Convert.ToDecimal(row["LastPriceVND"]);
                                        LastSumPriceUSD[2] += Convert.ToDecimal(row["LastPriceUSD"]);
                                    }
                                    xlsSheet[rParking + 1 + j, 12].Value = LastSumPriceUSD[2];
                                    xlsSheet[rParking + 1 + j, 13].Value = LastSumPriceVND[2];

                                    mCell = new XLCellRange(rParking + 1 + j, rParking + 1 + j, 1, 11);
                                    xlsSheet.MergedCells.Add(mCell);

                                    for (int row = rParking + sumRow - 2; row <= rParking + sumRow + dt.Rows.Count; row++)
                                    {
                                        for (int col = 1; col <= 13; col++)
                                        {
                                            xlsSheet[row, col].Style = xlstStyle;
                                        }
                                    }

                                    for (int col = 1; col <= 11; col++)
                                    {
                                        xlsSheet[rParking + 1 + j, col].Style = xlstStyleSum;
                                    }
                                    sumRow += dt.Rows.Count - 1;
                                }
                            }

                            ds = new DataSet();
                            sql = "SELECT id";
                            sql += " ,YearMonth,BuildingId,CustomerId,RoomId,ExtraHour,VAT,OtherFee01,OtherFee02";
                            sql += " ,PriceUSD,PriceVND,VatUSD,VatVND,SumUSD,SumVND,LastPriceUSD,LastPriceVND";
                            sql += " ,RentArea,dbo.fnDateTime(FromWD) BeginDate,dbo.fnDateTime(EndWD) EndDate,ExtratimeType";
                            sql += " FROM PaymentExtraTimeMonth";
                            sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + CustomerId + "' and YearMonth in (" + lsYearmonth + ")";

                            using (SqlCommand cm = db.CreateCommand(sql))
                            {
                                SqlDataAdapter da = new SqlDataAdapter(cm);
                                da.Fill(ds);
                                line = rExtra - 3 + j;
                                //Phi dien
                                XLCellRange mCell = new XLCellRange(line, line + 2, 1, 3);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 4, 4);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);

                                if (ds != null)
                                {
                                    int count = 0;
                                    DataTable dt = ds.Tables[0];

                                    foreach (DataRow row in dt.Rows)
                                    {
                                        if (count >= 1)
                                        {
                                            xlsSheet.Rows.Insert(rExtra + 1 + j);
                                            j++;
                                        }
                                        count++;
                                        int tmp = rExtra + j;

                                        string ExtraHour = Func.ParseString(row["ExtraHour"]);
                                        string BeginDate = Func.ParseString(row["BeginDate"]);
                                        string EndDate = Func.ParseString(row["EndDate"]);

                                        string ExtratimeType = Func.ParseString(row["ExtratimeType"]);

                                        xlsSheet[tmp, 1].Value = BeginDate + "~" + EndDate;
                                        xlsSheet[tmp, 5].Value = ExtraHour;

                                        xlsSheet[tmp, 4].Value = "Diện tích";
                                        if ("0".Equals(ExtratimeType))
                                        {
                                            xlsSheet[tmp, 4].Value = "m2*h";
                                        }
                                        xlsSheet[tmp, 6].Value = row["PriceUSD"];
                                        xlsSheet[tmp, 7].Value = row["PriceVND"];

                                        xlsSheet[tmp, 8].Value = row["SumUSD"];
                                        xlsSheet[tmp, 9].Value = row["SumVND"];

                                        xlsSheet[tmp, 10].Value = row["VatUSD"];
                                        xlsSheet[tmp, 11].Value = row["VatVND"];

                                        xlsSheet[tmp, 12].Value = row["LastPriceUSD"];
                                        xlsSheet[tmp, 13].Value = row["LastPriceVND"];

                                        LastSumPriceVND[3] += Convert.ToDecimal(row["LastPriceVND"]);
                                        LastSumPriceUSD[3] += Convert.ToDecimal(row["LastPriceUSD"]);

                                        XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
                                        xlsSheet.MergedCells.Add(mrCell);

                                        for (int col = 1; col <= 13; col++)
                                        {
                                            xlsSheet[tmp, col].Style = xlstStyle;
                                        }

                                    }
                                    mCell = new XLCellRange(rExtra + 1 + j, rExtra + 1 + j, 1, 11);
                                    xlsSheet.MergedCells.Add(mCell);

                                    xlsSheet[rExtra + 1 + j, 12].Value = LastSumPriceUSD[3];
                                    xlsSheet[rExtra + 1 + j, 13].Value = LastSumPriceVND[3];

                                    for (int row = rExtra + sumRow - 2; row <= rExtra + sumRow + dt.Rows.Count; row++)
                                    {
                                        for (int col = 1; col <= 13; col++)
                                        {
                                            xlsSheet[row, col].Style = xlstStyle;
                                        }
                                    }

                                    for (int col = 1; col <= 12; col++)
                                    {
                                        xlsSheet[rExtra + 1 + j, col].Style = xlstStyleSum;
                                    }
                                    sumRow += dt.Rows.Count - 1;
                                }
                            }

                            ds = new DataSet();
                            //Dien
                            //Xuất ra toàn bộ nội dung theo Trang
                            sql = " SELECT dbo.fnDateTime(A.DateFrom) DateFrom, dbo.fnDateTime(A.DateTo) DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVND, B.PriceUSD, B.SumVND, B.SumUSD, ";
                            sql += "        B.VatVND, B.VatUSD, B.LastPriceVND, B.LastPriceUSD, B.Name, B.WaterPricePercent,B.ElecPricePercent ";
                            sql += " FROM   PaymentElecWater AS A INNER JOIN ";
                            sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId";
                            sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + CustomerId + "' and TarrifsOfWaterId = 0  and A.YearMonth in (" + lsYearmonth + ")";
                            sql += " Order by A.DateFrom, B.FromIndex";

                            using (SqlCommand cm = db.CreateCommand(sql))
                            {
                                SqlDataAdapter da = new SqlDataAdapter(cm);
                                da.Fill(ds);

                                line = rElec - 3 + j;
                                //Phi dien
                                XLCellRange mCell = new XLCellRange(line, line + 2, 1, 1);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 2, 2);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 3, 3);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 4, 4);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 5, 5);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 7, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 8, 8);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 9, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 10, 10);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 11, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);

                                if (ds != null)
                                {
                                    int count = 0;
                                    DataTable dt = ds.Tables[0];
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        if (count >= 1)
                                        {
                                            xlsSheet.Rows.Insert(rElec + 1 + j);
                                            j++;

                                        }
                                        count++;
                                        int tmp = rElec + j;

                                        string DateFrom = Func.ParseString(row["DateFrom"]);
                                        string DateTo = Func.ParseString(row["DateTo"]);

                                        string FromIndex = Func.ParseString(row["FromIndex"]);
                                        string ToIndex = Func.ParseString(row["ToIndex"]);
                                        string OtherFee01 = Func.ParseString(row["OtherFee01"]);
                                        string OtherFee02 = Func.ParseString(row["OtherFee02"]);
                                        string Mount = Func.ParseString(row["Mount"]);
                                        string ElecPricePercent = Func.ParseString(row["ElecPricePercent"]);


                                        xlsSheet[tmp, 1].Value = DateFrom;
                                        xlsSheet[tmp, 2].Value = DateTo;
                                        xlsSheet[tmp, 3].Value = FromIndex;
                                        xlsSheet[tmp, 4].Value = ToIndex;
                                        xlsSheet[tmp, 5].Value = OtherFee01;
                                        xlsSheet[tmp, 6].Value = Mount;
                                        xlsSheet[tmp, 7].Value = row["PriceVND"];
                                        xlsSheet[tmp, 8].Value = row["VatVND"];

                                        xlsSheet[tmp, 9].Value = row["SumVND"];
                                        xlsSheet[tmp, 10].Value = row["OtherFee02"];
                                        xlsSheet[tmp, 11].Value = row["ElecPricePercent"];
                                        xlsSheet[tmp, 12].Value = row["LastPriceVND"];

                                        //mCell = new XLCellRange(tmp, tmp, 9, 10);
                                        //xlsSheet.MergedCells.Add(mCell);

                                        mCell = new XLCellRange(tmp, tmp, 12, 13);
                                        xlsSheet.MergedCells.Add(mCell);

                                        for (int col = 1; col <= 12; col++)
                                        {
                                            xlsSheet[tmp, col].Style = xlstStyle;
                                        }
                                        LastSumPriceVND[4] += Convert.ToDecimal(row["LastPriceVND"]);
                                        LastSumPriceUSD[4] += Convert.ToDecimal(row["LastPriceUSD"]);
                                    }
                                    xlsSheet[rElec + 1 + j, 12].Value = LastSumPriceVND[4];
                                    mCell = new XLCellRange(rElec + 1 + j, rElec + 1 + j, 1, 11);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(rElec + 1 + j, rElec + 1 + j, 12, 13);
                                    xlsSheet.MergedCells.Add(mCell);

                                    for (int row = rElec + sumRow - 2; row <= rElec + sumRow + dt.Rows.Count; row++)
                                    {
                                        for (int col = 1; col <= 13; col++)
                                        {
                                            xlsSheet[row, col].Style = xlstStyle;
                                        }
                                    }

                                    for (int col = 1; col <= 11; col++)
                                    {
                                        xlsSheet[rElec + 1 + j, col].Style = xlstStyleSum;
                                    }
                                    sumRow += dt.Rows.Count - 1;
                                }
                            }

                            ds = new DataSet();
                            //Nuoc
                            //Xuất ra toàn bộ nội dung theo Trang
                            sql = " SELECT dbo.fnDateTime(A.DateFrom) DateFrom, dbo.fnDateTime(A.DateTo) DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVND, B.PriceUSD, B.SumVND, B.SumUSD, ";
                            sql += "        B.VatVND, B.VatUSD, B.LastPriceVND, B.LastPriceUSD, B.Name, B.WaterPricePercent,B.ElecPricePercent  ";
                            sql += " FROM   PaymentElecWater AS A INNER JOIN ";
                            sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId";
                            sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + CustomerId + "' and TarrifsOfElecId = 0 and A.YearMonth in (" + lsYearmonth + ")";
                            sql += " Order by A.DateFrom, B.FromIndex";

                            using (SqlCommand cm = db.CreateCommand(sql))
                            {
                                SqlDataAdapter da = new SqlDataAdapter(cm);
                                da.Fill(ds);
                                line = rWater - 3 + j;
                                //Phi dien
                                XLCellRange mCell = new XLCellRange(line, line + 2, 1, 1);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 2, 2);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 3, 3);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 4, 4);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 6, 6);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 7, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 8, 8);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 9, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 10, 10);
                                xlsSheet.MergedCells.Add(mCell);
                                //mCell = new XLCellRange(line, line, 9, 10);
                                //xlsSheet.MergedCells.Add(mCell);

                                //mCell = new XLCellRange(line + 1, line + 2, 9, 10);
                                //xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 11, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);

                                if (ds != null)
                                {
                                    int count = 0;
                                    DataTable dt = ds.Tables[0];
                                    if (dt.Rows.Count > 0)
                                    {
                                        foreach (DataRow row in dt.Rows)
                                        {
                                            if (count >= 1)
                                            {
                                                xlsSheet.Rows.Insert(rWater + 1 + j);
                                                j++;

                                            }
                                            count++;
                                            int tmp = rWater + j;

                                            string DateFrom = Func.ParseString(row["DateFrom"]);
                                            string DateTo = Func.ParseString(row["DateTo"]);

                                            string FromIndex = Func.ParseString(row["FromIndex"]);
                                            string ToIndex = Func.ParseString(row["ToIndex"]);
                                            string OtherFee01 = Func.ParseString(row["OtherFee01"]);
                                            string OtherFee02 = Func.ParseString(row["OtherFee02"]);
                                            string Mount = Func.ParseString(row["Mount"]);
                                            string WaterPricePercent = Func.ParseString(row["WaterPricePercent"]);

                                            xlsSheet[tmp, 1].Value = DateFrom;
                                            xlsSheet[tmp, 2].Value = DateTo;
                                            xlsSheet[tmp, 3].Value = FromIndex;
                                            xlsSheet[tmp, 4].Value = ToIndex;
                                            xlsSheet[tmp, 5].Value = Mount;
                                            xlsSheet[tmp, 6].Value = row["PriceVND"];
                                            xlsSheet[tmp, 7].Value = row["OtherFee01"];
                                            xlsSheet[tmp, 8].Value = row["VatVND"];

                                            xlsSheet[tmp, 9].Value = row["SumVND"];
                                            xlsSheet[tmp, 10].Value = row["OtherFee02"];
                                            xlsSheet[tmp, 11].Value = row["WaterPricePercent"];
                                            xlsSheet[tmp, 12].Value = row["LastPriceVND"];

                                            for (int col = 1; col <= 12; col++)
                                            {
                                                xlsSheet[tmp, col].Style = xlstStyle;
                                            }
                                            LastSumPriceVND[5] += Convert.ToDecimal(row["LastPriceVND"]);
                                            LastSumPriceUSD[5] += Convert.ToDecimal(row["LastPriceUSD"]);

                                            //mCell = new XLCellRange(tmp, tmp, 9, 10);
                                            //xlsSheet.MergedCells.Add(mCell);

                                            mCell = new XLCellRange(tmp, tmp, 12, 13);
                                            xlsSheet.MergedCells.Add(mCell);
                                        }
                                        xlsSheet[rWater + 1 + j, 12].Value = LastSumPriceVND[5];
                                        mCell = new XLCellRange(rWater + 1 + j, rWater + 1 + j, 1, 11);
                                        xlsSheet.MergedCells.Add(mCell);

                                        mCell = new XLCellRange(rWater + 1 + j, rWater + 1 + j, 12, 13);
                                        xlsSheet.MergedCells.Add(mCell);

                                        for (int row = rWater + sumRow - 2; row <= rWater + sumRow + dt.Rows.Count; row++)
                                        {
                                            for (int col = 1; col <= 13; col++)
                                            {
                                                xlsSheet[row, col].Style = xlstStyle;
                                            }
                                        }
                                        for (int col = 1; col <= 11; col++)
                                        {
                                            xlsSheet[rWater + 1 + j, col].Style = xlstStyleSum;
                                        }
                                        sumRow += dt.Rows.Count - 1;
                                    }
                                }
                            }

                            //Service
                            ds = new DataSet();

                            sql = string.Empty;
                            sql = " SELECT Service,dbo.fnDateTime(ServiceDateFrom) ServiceDateFrom,dbo.fnDateTime(ServiceDateTo) ServiceDateTo,PriceVND,PriceUSD,VatUSD,VatVND,Mount,SumVND,SumUSD,LastPriceVND,LastPriceUSD ";
                            sql += " FROM   PaymentService";
                            sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + CustomerId + "' and YearMonth in (" + lsYearmonth + ")";
                            sql += " Order By ServiceDate ";

                            using (SqlCommand cm = db.CreateCommand(sql))
                            {
                                SqlDataAdapter da = new SqlDataAdapter(cm);
                                da.Fill(ds);
                                line = rService - 3 + j;
                                //Phi khác
                                XLCellRange mCell = new XLCellRange(line, line + 2, 1, 2);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 3, 3);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 4, 4);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 5, 5);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);


                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);

                                if (ds != null)
                                {
                                    int count = 0;
                                    DataTable dt = ds.Tables[0];

                                    foreach (DataRow row in dt.Rows)
                                    {
                                        if (count >= 1)
                                        {
                                            xlsSheet.Rows.Insert(rService + j);
                                            j++;

                                        }
                                        count++;
                                        int tmp = rService + j;

                                        string Service = Func.ParseString(row["Service"]);
                                        string ServiceDateFrom = Func.ParseString(row["ServiceDateFrom"]);
                                        string ServiceDateTo = Func.ParseString(row["ServiceDateTo"]);

                                        string Mount = Func.ParseString(row["Mount"]);

                                        xlsSheet[tmp, 1].Value = Service;
                                        xlsSheet[tmp, 3].Value = ServiceDateFrom;
                                        xlsSheet[tmp, 4].Value = ServiceDateTo;
                                        xlsSheet[tmp, 5].Value = Mount;

                                        xlsSheet[tmp, 6].Value = row["PriceUSD"];
                                        xlsSheet[tmp, 7].Value = row["PriceVND"];

                                        xlsSheet[tmp, 8].Value = row["SumUSD"];
                                        xlsSheet[tmp, 9].Value = row["SumVND"];

                                        xlsSheet[tmp, 10].Value = row["VatUSD"];
                                        xlsSheet[tmp, 11].Value = row["VatVND"];

                                        xlsSheet[tmp, 12].Value = row["LastPriceUSD"];
                                        xlsSheet[tmp, 13].Value = row["LastPriceVND"];

                                        for (int col = 1; col <= 13; col++)
                                        {
                                            xlsSheet[tmp, col].Style = xlstStyle;
                                        }
                                        LastSumPriceVND[6] += Convert.ToDecimal(row["LastPriceVND"]);
                                        LastSumPriceUSD[6] += Convert.ToDecimal(row["LastPriceUSD"]);
                                    }
                                    xlsSheet[rService + 1 + j, 12].Value = LastSumPriceUSD[6];
                                    xlsSheet[rService + 1 + j, 13].Value = LastSumPriceVND[6];

                                    mCell = new XLCellRange(rService + 1 + j, rService + 1 + j, 1, 11);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(rService + 1 + j, rService + 1 + j, 12, 13);
                                    xlsSheet.MergedCells.Add(mCell);

                                    for (int row = rService + sumRow - 2; row <= rService + sumRow + dt.Rows.Count; row++)
                                    {
                                        for (int col = 1; col <= 13; col++)
                                        {
                                            xlsSheet[row, col].Style = xlstStyle;
                                        }
                                    }

                                    for (int col = 1; col <= 11; col++)
                                    {
                                        xlsSheet[rService + 1 + j, col].Style = xlstStyleSum;
                                    }
                                    sumRow += dt.Rows.Count - 1;

                                }
                            }

                            //Paid
                            sql = "Select  *";
                            sql += " From    PaymentBillDetail";
                            sql += " Where   BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + CustomerId + "' and YearMonth in (" + lsYearmonth + ")";
                            string strYearMonth = "";
                            int lineTmp = rPaid - 2 + j;

                            //Phi khác
                            XLCellRange mCellTmp = new XLCellRange(lineTmp, lineTmp + 1, 1, 1);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 2, 3);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 4, 5);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 6, 7);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 8, 9);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 12, 13);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            Hashtable rowNo = new Hashtable();

                            DataTable dtPaid = DbHelper.GetDataTable(sql);
                            for (int i = 0; i < dtPaid.Rows.Count; i++)
                            {
                                string PaymentType = Func.ParseString(dtPaid.Rows[i]["PaymentType"]);
                                string MoneyUSD = Func.ParseString(dtPaid.Rows[i]["MoneyUSD"]);
                                string MoneyVND = Func.ParseString(dtPaid.Rows[i]["MoneyVND"]);
                                string PaidUSD = Func.ParseString(dtPaid.Rows[i]["PaidUSD"]);
                                string PaidVND = Func.ParseString(dtPaid.Rows[i]["PaidVND"]);
                                string ExchangeType = Func.ParseString(dtPaid.Rows[i]["ExchangeType"]);
                                string YearMonth = Func.ParseString(dtPaid.Rows[i]["YearMonth"]);

                                if (!rowNo.Contains(YearMonth))
                                {
                                    if (rowNo.Count != 0)
                                    {
                                        xlsSheet.Rows.Insert(rPaid + j + 1);
                                        j++;
                                    }
                                    rowNo.Add(YearMonth, j);
                                }
                                int m = Func.ParseInt(rowNo[YearMonth]);
                                strYearMonth = YearMonth;
                                decimal tmpUSD = Convert.ToDecimal(MoneyUSD) - Convert.ToDecimal(PaidUSD);
                                decimal tmpVND = Convert.ToDecimal(MoneyVND) - Convert.ToDecimal(PaidVND);

                                PaidPriceUSD += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                                PaidPriceVND += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);

                                xlsSheet[rPaid + m, 1].Value = YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4);
                                switch (PaymentType)
                                {
                                    case "1":
                                        //Rent
                                        xlsSheet[rPaid + m, 2].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheet[rPaid + m, 3].Value = dtPaid.Rows[i]["PaidVND"];
                                        break;
                                    case "2":
                                        //Manager
                                        xlsSheet[rPaid + m, 4].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheet[rPaid + m, 5].Value = dtPaid.Rows[i]["PaidVND"];
                                        break;
                                    case "3":
                                        //Parking
                                        xlsSheet[rPaid + m, 6].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheet[rPaid + m, 7].Value = dtPaid.Rows[i]["PaidVND"];
                                        break;
                                    case "4":
                                        //Extra
                                        xlsSheet[rPaid + m, 8].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheet[rPaid + m, 9].Value = dtPaid.Rows[i]["PaidVND"];
                                        break;
                                    case "5":
                                        xlsSheet[rPaid + m, 10].Value = dtPaid.Rows[i]["PaidVND"];
                                        break;
                                    case "6":
                                        xlsSheet[rPaid + m, 11].Value = dtPaid.Rows[i]["PaidVND"];
                                        break;
                                    case "7":
                                        xlsSheet[rPaid + m, 12].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheet[rPaid + m, 13].Value = dtPaid.Rows[i]["PaidVND"];
                                        break;
                                    default:
                                        break;
                                }
                                for (int row = rPaid + m; row <= rPaid + 1 + j; row++)
                                {
                                    for (int col = 1; col <= 13; col++)
                                    {
                                        xlsSheet[row, col].Style = xlstStyle;
                                    }
                                }
                            }
                            lineTmp = rPaid - 2 + j;

                            xlsSheet[lineTmp + 3, 1].Style = xlstStyleSum;


                            lineTmp = rDept - 2 + j;
                            //Dept
                            mCellTmp = new XLCellRange(lineTmp, lineTmp + 1, 1, 1);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 2, 3);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 4, 5);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 6, 7);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 8, 9);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 12, 13);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            for (int row = lineTmp; row <= rDept + 1 + j; row++)
                            {
                                for (int col = 1; col <= 13; col++)
                                {
                                    xlsSheet[row, col].Style = xlstStyle;
                                }
                            }
                            xlsSheet[lineTmp + 3, 1].Style = xlstStyleSum;

                            decimal AllSumVND = 0;
                            decimal AllSumUSD = 0;
                            for (int i = 0; i < 7; i++)
                            {
                                AllSumVND += LastSumPriceVND[i];
                                AllSumUSD += LastSumPriceUSD[i];
                            }

                            AllSumVND -= PaidPriceVND;
                            AllSumUSD -= PaidPriceUSD;
                            AllSumVND += Convert.ToDecimal(AllSumUSD * Convert.ToDecimal(UsdExchange));

                            string strMoney = Func.docso(Convert.ToInt32(AllSumVND));

                            xlsSheet[rContract, cContract].Value = xlsSheet[rContract, cContract].Value.ToString().Replace("{%HOP_DONG%}", String.IsNullOrEmpty(contract) ? "" : contract.Substring(1));
                            xlsSheet[rSum + j, cSum].Value = Convert.ToInt32(AllSumVND);
                            xlsSheet[rSumRead + j, cSumRead].Value = xlsSheet[rSumRead + j, cSumRead].Value.ToString().Replace("{%TONG_CHU%}", strMoney.ToUpper());

                            xlbBook.Save(fileNameDes);
                            //ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);
                        }

                    }
                }
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

        public void Export()
        {
            ExportFile xfile = new ExportFile(Func.ParseString(Session["__BUILDINGID__"]), drpYear.SelectedValue + drpMonth.SelectedValue, HttpContext.Current.Server.MapPath(@"~\Report\"));
            Thread workerThread = new Thread(xfile.DoExport);
            workerThread.Start();
        }
        public void ViewMultiBoth()
        {
            int rBillNo = 0;
            int cBillNo = 1;

            int rBillDate = 0;
            int cBillDate = 10;

            int rBillMonth = 2;
            int cBillMonth = 0;

            int rContact = 5;
            int cContact = 3;

            int rCustomer = 5;
            int cCustomer = 7;

            int rContract = 7;
            int cContract = 1;

            int rRate = 11;
            int cRate = 9;

            int rRateDate = 11;
            int cRateDate = 12;

            int rRent = 15;

            int rManager = 23;

            int rParking = 31;

            int rExtra = 39;

            int rElec = 47;

            int rWater = 55;

            int rService = 63;

            int rPaid = 70;

            int rDept = 77;

            int rOffice = 88;
            int cOffice = 3;

            int rPhone = 89;
            int cPhone = 3;

            int rBank = 88;
            int cBank = 7;

            int rAccountName = 89;
            int cAccountName = 7;

            int rAccount = 90;
            int cAccount = 7;

            int rSum = 81;
            int cSum = 12;

            int rSumVND = 80;
            int cSumVND = 12;

            int rSumRead = 82;
            int cSumRead = 13;

            ////
            using (SqlDatabase db = new SqlDatabase())
            {

                DataSet ds = new DataSet();
                DataSet dsCus = new DataSet();

                string sql = string.Empty;

                string Bank = "";
                string Account = "";
                string AccountName = "";
                string Office = "";
                string OfficeAddress = "";
                string OfficePhone = "";

                ds = new DataSet();
                sql = " SELECT Bank,Account,AccountName,Office,OfficeAddress,OfficePhone";
                sql += " FROM Mst_Building";
                sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' ";
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);

                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            Bank = rowType["Bank"].ToString();
                            Account = rowType["Account"].ToString();
                            AccountName = rowType["AccountName"].ToString();
                            Office = rowType["Office"].ToString();
                            OfficeAddress = rowType["OfficeAddress"].ToString();
                            OfficePhone = rowType["OfficePhone"].ToString();
                        }
                    }
                }

                //Danh sách Bill
                sql = "  Select BillDate,UsdExchangeDate,UsdExchange,BillNo,B.Name,B.ContactName,A.CustomerId, A.YearMonths, A.Id ";
                sql += " From	PaymentBillInfo A, Customer B";
                sql += " Where	A.BuildingId = B.BuildingId and A.CustomerId = B.CustomerId and B.DelFlag = 0 and A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "'";

                string BillDate = "";
                string UsdExchangeDate = "";
                string UsdExchange = "";
                string BillNo = "";
                string Name = "";
                string ContactName = "";
                string CustomerId = "";
                string lsYearmonth = "";
                string id = "";


                string maxYearMonth = "";

                using (SqlCommand cmCus = db.CreateCommand(sql))
                {
                    SqlDataAdapter daCus = new SqlDataAdapter(cmCus);
                    daCus.Fill(dsCus);

                    if (dsCus != null)
                    {
                        string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");

                        DataTable dtCus = dsCus.Tables[0];
                        foreach (DataRow rowCus in dtCus.Rows)
                        {
                            BillDate = rowCus[0].ToString();
                            UsdExchangeDate = rowCus[1].ToString();
                            UsdExchange = rowCus[2].ToString();
                            BillNo = rowCus[3].ToString();
                            Name = rowCus[4].ToString();
                            ContactName = rowCus[5].ToString();
                            CustomerId = rowCus[6].ToString();
                            lsYearmonth = rowCus[7].ToString();
                            id = rowCus[8].ToString();

                            string[] strTmpYearMonth = lsYearmonth.Split(',');

                            for (int l = 0; l < strTmpYearMonth.Length; l++)
                            {
                                string tmp = strTmpYearMonth[l];
                                if (maxYearMonth == "")
                                    maxYearMonth = tmp;
                                if (maxYearMonth.CompareTo(tmp) < 0)
                                    maxYearMonth = tmp;
                            }


                            C1XLBook xlbBook = new C1XLBook();
                            //ShowData(drpYear.SelectedValue + drpMonth.SelectedValue);
                            XLStyle xlstStyle2 = new XLStyle(xlbBook);
                            xlstStyle2.AlignHorz = XLAlignHorzEnum.Center;
                            xlstStyle2.AlignVert = XLAlignVertEnum.Center;
                            xlstStyle2.WordWrap = true;
                            xlstStyle2.Font = new Font("", 8, FontStyle.Regular);
                            xlstStyle2.SetBorderColor(Color.Black);
                            xlstStyle2.BorderBottom = XLLineStyleEnum.Thin;
                            xlstStyle2.BorderTop = XLLineStyleEnum.Thin;
                            xlstStyle2.BorderLeft = XLLineStyleEnum.Thin;
                            xlstStyle2.BorderRight = XLLineStyleEnum.Thin;
                            xlstStyle2.Format = "#,##0.00_);(#,##0.00)";

                            XLStyle xlstStyle1 = new XLStyle(xlbBook);
                            xlstStyle1.AlignHorz = XLAlignHorzEnum.Center;
                            xlstStyle1.AlignVert = XLAlignVertEnum.Center;
                            xlstStyle1.WordWrap = true;
                            xlstStyle1.Font = new Font("", 8, FontStyle.Regular);
                            xlstStyle1.SetBorderColor(Color.Black);
                            xlstStyle1.BorderBottom = XLLineStyleEnum.Thin;
                            xlstStyle1.BorderTop = XLLineStyleEnum.Thin;
                            xlstStyle1.BorderLeft = XLLineStyleEnum.Thin;
                            xlstStyle1.BorderRight = XLLineStyleEnum.Thin;
                            xlstStyle1.Format = "#,##0.0_);(#,##0.0)";

                            XLStyle xlstStyle0 = new XLStyle(xlbBook);
                            xlstStyle0.AlignHorz = XLAlignHorzEnum.Center;
                            xlstStyle0.AlignVert = XLAlignVertEnum.Center;
                            xlstStyle0.WordWrap = true;
                            xlstStyle0.Font = new Font("", 8, FontStyle.Regular);
                            xlstStyle0.SetBorderColor(Color.Black);
                            xlstStyle0.BorderBottom = XLLineStyleEnum.Thin;
                            xlstStyle0.BorderTop = XLLineStyleEnum.Thin;
                            xlstStyle0.BorderLeft = XLLineStyleEnum.Thin;
                            xlstStyle0.BorderRight = XLLineStyleEnum.Thin;
                            xlstStyle0.Format = "#,##0_);(#,##0)";

                            XLStyle xlstStyleH = new XLStyle(xlbBook);
                            xlstStyleH.AlignHorz = XLAlignHorzEnum.Center;
                            xlstStyleH.AlignVert = XLAlignVertEnum.Center;
                            xlstStyleH.Font = new Font("", 8, FontStyle.Bold);
                            xlstStyleH.SetBorderColor(Color.Black);
                            xlstStyleH.BorderBottom = XLLineStyleEnum.Thin;
                            xlstStyleH.BorderTop = XLLineStyleEnum.Thin;
                            xlstStyleH.BorderLeft = XLLineStyleEnum.Thin;
                            xlstStyleH.BorderRight = XLLineStyleEnum.Thin;
                            xlstStyleH.WordWrap = true;

                            XLStyle xlstStyleSum2 = new XLStyle(xlbBook);
                            xlstStyleSum2.AlignHorz = XLAlignHorzEnum.Right;
                            xlstStyleSum2.AlignVert = XLAlignVertEnum.Center;
                            xlstStyleSum2.Font = new Font("", 8, FontStyle.Bold);
                            xlstStyleSum2.SetBorderColor(Color.Black);
                            xlstStyleSum2.BorderBottom = XLLineStyleEnum.Thin;
                            xlstStyleSum2.BorderTop = XLLineStyleEnum.Thin;
                            xlstStyleSum2.BorderLeft = XLLineStyleEnum.Thin;
                            xlstStyleSum2.BorderRight = XLLineStyleEnum.Thin;
                            xlstStyleSum2.WordWrap = true;

                            XLStyle xlstStyleSum1 = new XLStyle(xlbBook);
                            xlstStyleSum1.AlignHorz = XLAlignHorzEnum.Right;
                            xlstStyleSum1.AlignVert = XLAlignVertEnum.Center;
                            xlstStyleSum1.Font = new Font("", 8, FontStyle.Bold);
                            xlstStyleSum1.SetBorderColor(Color.Black);
                            xlstStyleSum1.BorderBottom = XLLineStyleEnum.Thin;
                            xlstStyleSum1.BorderTop = XLLineStyleEnum.Thin;
                            xlstStyleSum1.BorderLeft = XLLineStyleEnum.Thin;
                            xlstStyleSum1.BorderRight = XLLineStyleEnum.Thin;
                            xlstStyleSum1.WordWrap = true;
                            xlstStyleSum1.Format = "#,##0.0_);(#,##0.0)";

                            XLStyle xlstStyleSum0 = new XLStyle(xlbBook);
                            xlstStyleSum0.AlignHorz = XLAlignHorzEnum.Right;
                            xlstStyleSum0.AlignVert = XLAlignVertEnum.Center;
                            xlstStyleSum0.Font = new Font("", 8, FontStyle.Bold);
                            xlstStyleSum0.SetBorderColor(Color.Black);
                            xlstStyleSum0.BorderBottom = XLLineStyleEnum.Thin;
                            xlstStyleSum0.BorderTop = XLLineStyleEnum.Thin;
                            xlstStyleSum0.BorderLeft = XLLineStyleEnum.Thin;
                            xlstStyleSum0.BorderRight = XLLineStyleEnum.Thin;
                            xlstStyleSum0.WordWrap = true;
                            xlstStyleSum0.Format = "#,##0_);(#,##0)";

                            string fileName = HttpContext.Current.Server.MapPath(@"~\Report\Template\BillTongQuat.xlsx");
                            if (!Directory.Exists(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\Bill"))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\Bill"));
                            }

                            string strFilePath = @"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\Bill\Bill" + "_" + CustomerId + "_" + BillNo + id + "_" + strDT + ".xlsx";
                            string strFilePathExport = @"../../Report/Building/" + Func.ParseString(Session["__BUILDINGID__"]) + @"/Bill/Bill" + "_" + CustomerId + "_" + BillNo + id + "_" + strDT + ".xlsx";

                            string fileNameDes = HttpContext.Current.Server.MapPath(strFilePath);

                            //string fileNameDes = HttpContext.Current.Server.MapPath(@"~\Report\Building\" + Func.ParseString(Session["__BUILDINGID__"]) + @"\TongHopDienTich" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
                            File.Copy(fileName, fileNameDes);

                            xlbBook.Load(fileNameDes);
                            XLSheet xlsSheet = xlbBook.Sheets["TongHop"];
                            XLSheet xlsSheetEn = xlbBook.Sheets["TongHop_En"];

                            //Thông tin về Ngân hàng của Tòa Nhà
                            xlsSheet[rOffice, cOffice].Value = xlsSheet[rOffice, cOffice].Value.ToString().Replace("{%VAN_PHONG%}", Office);
                            xlsSheet[rPhone, cPhone].Value = xlsSheet[rPhone, cPhone].Value.ToString().Replace("{%DIEN_THOAI%}", OfficePhone);

                            xlsSheet[rBank, cBank].Value = xlsSheet[rBank, cBank].Value.ToString().Replace("{%NGAN_HANG%}", Bank);
                            xlsSheet[rAccountName, cAccountName].Value = xlsSheet[rAccountName, cAccountName].Value.ToString().Replace("{%TEN_TAI_KHOAN%}", AccountName);
                            xlsSheet[rAccount, cAccount].Value = xlsSheet[rAccount, cAccount].Value.ToString().Replace("{%SO_TAI_KHOAN%}", Account);
                            //Thông tin về Ngân hàng của Tòa Nhà

                            //Customer
                            xlsSheet[rCustomer, cCustomer].Value = xlsSheet[rCustomer, cCustomer].Value.ToString().Replace("{%TEN_CONG_TY%}", Name);
                            //Contact
                            xlsSheet[rContact, cContact].Value = xlsSheet[rContact, cContact].Value.ToString().Replace("{%NGUOI_DAI_DIEN%}", ContactName);

                            //Bill No
                            xlsSheet[rBillNo, cBillNo].Value = xlsSheet[rBillNo, cBillNo].Value.ToString().Replace("{%BILL_NO%}", BillNo);

                            //Ngay Thang Nam
                            DateTime dtime = DateTime.Today;

                            string strTmp = xlsSheet[rBillDate, cBillDate].Value.ToString().Replace("{%NGAY%}", dtime.ToString("dd"));
                            strTmp = strTmp.Replace("{%THANG%}", dtime.ToString("MM"));
                            xlsSheet[rBillDate, cBillDate].Value = strTmp.Replace("{%NAM%}", dtime.ToString("yyyy"));

                            //Nam
                            xlsSheet[rBillMonth, cBillMonth].Value = xlsSheet[rBillMonth, cBillMonth].Value.ToString().Replace("{%NAM_THANG%}", drpMonth.SelectedValue + "/" + drpYear.SelectedValue);

                            //Thông tin Tỉ giá
                            xlsSheet[rRate, cRate].Value = xlsSheet[rRate, cRate].Value.ToString().Replace("{%TI_GIA%}", UsdExchange);
                            xlsSheet[rRateDate, cRateDate].Value = xlsSheet[rRateDate, cRateDate].Value.ToString().Replace("{%NGAY_AP_DUNG%}", UsdExchangeDate);
                            //Thông tin Tỉ giá

                            Hashtable contractIdLst = new Hashtable();
                            string contract = "";
                            ////

                            //Thue phong
                            ds = new DataSet();
                            sql = " Select A.*, B.ContractDate";
                            sql += " FROM PaymentRoom A, RentContract B";
                            sql += " WHERE A.ContractId = B.ContractId and A.BuildingId = B.BuildingId and A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + CustomerId + "' and A.YearMonth in (" + lsYearmonth + ")";

                            int sumRow = 0;
                            int j = 0;
                            decimal[] LastSumPriceVND = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };
                            decimal[] LastSumPriceUSD = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };

                            decimal PaidPriceVND = 0;
                            decimal PaidPriceUSD = 0;

                            int line = 0;
                            using (SqlCommand cm = db.CreateCommand(sql))
                            {
                                SqlDataAdapter da = new SqlDataAdapter(cm);
                                da.Fill(ds);

                                line = rRent - 3 + j;

                                XLCellRange mCell = new XLCellRange(line, line + 2, 1, 3);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 4, 5);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 4, 5);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 2, line + 2, 4, 5);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                if (ds != null)
                                {
                                    int count = 0;
                                    DataTable dt = ds.Tables[0];
                                    int k = 0;
                                    foreach (DataRow rowType in dt.Rows)
                                    {
                                        decimal tmp01 = Convert.ToDecimal(rowType["LastRentSumUSD"]);
                                        decimal tmp02 = Convert.ToDecimal(rowType["LastRentSumVND"]);

                                        string ContractId = Func.ParseString(rowType["ContractId"]);
                                        string ContractNo = Func.ParseString(rowType["ContractNo"]);
                                        string YearMonth = Func.ParseString(rowType["YearMonth"]);
                                        string Area = Func.ParseString(rowType["Area"]);
                                        string Regional = Func.ParseString(rowType["Regional"]);
                                        string Floor = Func.ParseString(rowType["Floor"]);
                                        string BeginContract = Func.ParseString(rowType["ContractDate"]);

                                        if (!contractIdLst.ContainsKey(ContractId + "(" + Func.FormatDMY(BeginContract) + ")"))
                                        {
                                            contractIdLst.Add(ContractId + "(" + Func.FormatDMY(BeginContract) + ")", ContractNo + "(" + Func.FormatDMY(BeginContract) + ")");
                                            contract += ";" + ContractNo + "(" + Func.FormatDMY(BeginContract) + ")";
                                        }
                                        if (tmp01 > 0 || tmp02 > 0)
                                        {

                                            if (count >= 1)
                                            {
                                                xlsSheet.Rows.Insert(rRent + 1 + j);
                                                xlsSheetEn.Rows.Insert(rRent + 1 + j);
                                                j++;
                                            }
                                            count++;
                                            int tmp = rRent + j;
                                            xlsSheet[tmp, 1].Value = Name;
                                            xlsSheet[tmp, 4].Value = rowType["Area"];
                                            xlsSheet[tmp, 6].Value = rowType["MonthRentPriceUSD"];
                                            xlsSheet[tmp, 7].Value = rowType["MonthRentPriceVND"];

                                            xlsSheet[tmp, 8].Value = rowType["MonthRentSumUSD"];
                                            xlsSheet[tmp, 9].Value = rowType["MonthRentSumVND"];

                                            xlsSheet[tmp, 10].Value = rowType["VatRentPriceUSD"];
                                            xlsSheet[tmp, 11].Value = rowType["VatRentPriceVND"];

                                            xlsSheet[tmp, 12].Value = rowType["LastRentSumUSD"];
                                            xlsSheet[tmp, 13].Value = rowType["LastRentSumVND"];

                                            XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
                                            xlsSheet.MergedCells.Add(mrCell);

                                            mrCell = new XLCellRange(tmp, tmp, 4, 5);
                                            xlsSheet.MergedCells.Add(mrCell);


                                            ////EN
                                            xlsSheetEn[tmp, 1].Value = Name;
                                            xlsSheetEn[tmp, 4].Value = rowType["Area"];
                                            xlsSheetEn[tmp, 6].Value = rowType["MonthRentPriceUSD"];
                                            xlsSheetEn[tmp, 7].Value = rowType["MonthRentPriceVND"];

                                            xlsSheetEn[tmp, 8].Value = rowType["MonthRentSumUSD"];
                                            xlsSheetEn[tmp, 9].Value = rowType["MonthRentSumVND"];

                                            xlsSheetEn[tmp, 10].Value = rowType["VatRentPriceUSD"];
                                            xlsSheetEn[tmp, 11].Value = rowType["VatRentPriceVND"];

                                            xlsSheetEn[tmp, 12].Value = rowType["LastRentSumUSD"];
                                            xlsSheetEn[tmp, 13].Value = rowType["LastRentSumVND"];

                                            mrCell = new XLCellRange(tmp, tmp, 1, 3);
                                            xlsSheetEn.MergedCells.Add(mrCell);

                                            mrCell = new XLCellRange(tmp, tmp, 4, 5);
                                            xlsSheetEn.MergedCells.Add(mrCell);
                                            ////EN


                                            LastSumPriceVND[0] += Convert.ToDecimal(rowType["LastRentSumVND"]);
                                            LastSumPriceUSD[0] += Convert.ToDecimal(rowType["LastRentSumUSD"]);
                                        }
                                        else
                                        {
                                            k++;
                                        }
                                    }
                                    mCell = new XLCellRange(rRent + 1 + j, rRent + 1 + j, 1, 11);
                                    xlsSheet.MergedCells.Add(mCell);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    xlsSheet[rRent + 1 + j, 12].Value = LastSumPriceUSD[0];
                                    xlsSheet[rRent + 1 + j, 13].Value = LastSumPriceVND[0];

                                    xlsSheetEn[rRent + 1 + j, 12].Value = LastSumPriceUSD[0];
                                    xlsSheetEn[rRent + 1 + j, 13].Value = LastSumPriceVND[0];

                                    for (int row = rRent + sumRow; row <= rRent + dt.Rows.Count - k; row++)
                                    {
                                        for (int col = 1; col <= 13; col++)
                                        {
                                            //xlsSheet[row, col].Style = xlstStyle;
                                            //xlsSheetEn[row, col].Style = xlstStyle;
                                        }
                                    }
                                    sumRow += dt.Rows.Count - 1 - k;

                                    ////////////////////////
                                    for (int col = 1; col <= 13; col++)
                                    {
                                        //xlsSheet[rRent + 1 + j, col].Style = xlstStyleSum;
                                        //xlsSheetEn[rRent + 1 + j, col].Style = xlstStyleSum;
                                    }
                                    line = rManager - 3 + j;
                                    mCell = new XLCellRange(line, line + 2, 1, 3);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 4, 5);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 4, 5);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 2, line + 2, 4, 5);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 6, 7);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 8, 9);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 10, 11);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 12, 13);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                                    xlsSheet.MergedCells.Add(mCell);

                                    ////En
                                    mCell = new XLCellRange(line, line + 2, 1, 3);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 4, 5);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 4, 5);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 2, line + 2, 4, 5);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 6, 7);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 8, 9);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 10, 11);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 12, 13);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                                    xlsSheetEn.MergedCells.Add(mCell);
                                    ////En
                                    k = 0;
                                    count = 0;
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        decimal tmp01 = Convert.ToDecimal(row["LastManagerSumUSD"]);
                                        decimal tmp02 = Convert.ToDecimal(row["LastManagerSumVND"]);

                                        if (tmp01 > 0 || tmp02 > 0)
                                        {

                                            if (count >= 1)
                                            {
                                                xlsSheet.Rows.Insert(rManager + 1 + j);
                                                xlsSheetEn.Rows.Insert(rManager + 1 + j);
                                                j++;
                                            }
                                            count++;
                                            int tmp = rManager + j;

                                            string YearMonth = Func.ParseString(row["YearMonth"]);
                                            string Area = Func.ParseString(row["Area"]);

                                            xlsSheet[tmp, 1].Value = Name;
                                            xlsSheet[tmp, 4].Value = row["Area"];
                                            xlsSheet[tmp, 6].Value = row["MonthManagerPriceUSD"];
                                            xlsSheet[tmp, 7].Value = row["MonthManagerPriceVND"];

                                            xlsSheet[tmp, 8].Value = row["MonthManagerSumUSD"];
                                            xlsSheet[tmp, 9].Value = row["MonthManagerSumVND"];

                                            xlsSheet[tmp, 10].Value = row["VatManagerPriceUSD"];
                                            xlsSheet[tmp, 11].Value = row["VatManagerPriceVND"];

                                            xlsSheet[tmp, 12].Value = row["LastManagerSumUSD"];
                                            xlsSheet[tmp, 13].Value = row["LastManagerSumVND"];

                                            XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
                                            xlsSheet.MergedCells.Add(mrCell);

                                            mrCell = new XLCellRange(tmp, tmp, 4, 5);
                                            xlsSheet.MergedCells.Add(mrCell);

                                            ////En
                                            xlsSheetEn[tmp, 1].Value = Name;
                                            xlsSheetEn[tmp, 4].Value = row["Area"];
                                            xlsSheetEn[tmp, 6].Value = row["MonthManagerPriceUSD"];
                                            xlsSheetEn[tmp, 7].Value = row["MonthManagerPriceVND"];

                                            xlsSheetEn[tmp, 8].Value = row["MonthManagerSumUSD"];
                                            xlsSheetEn[tmp, 9].Value = row["MonthManagerSumVND"];

                                            xlsSheetEn[tmp, 10].Value = row["VatManagerPriceUSD"];
                                            xlsSheetEn[tmp, 11].Value = row["VatManagerPriceVND"];

                                            xlsSheetEn[tmp, 12].Value = row["LastManagerSumUSD"];
                                            xlsSheetEn[tmp, 13].Value = row["LastManagerSumVND"];

                                            mrCell = new XLCellRange(tmp, tmp, 1, 3);
                                            xlsSheetEn.MergedCells.Add(mrCell);

                                            mrCell = new XLCellRange(tmp, tmp, 4, 5);
                                            xlsSheetEn.MergedCells.Add(mrCell);
                                            ////En
                                            LastSumPriceVND[1] += Convert.ToDecimal(row["LastManagerSumVND"]);
                                            LastSumPriceUSD[1] += Convert.ToDecimal(row["LastManagerSumUSD"]);
                                        }
                                        else { k++; }
                                    }
                                    mCell = new XLCellRange(rManager + 1 + j, rManager + 1 + j, 1, 11);
                                    xlsSheet.MergedCells.Add(mCell);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    xlsSheet[rManager + 1 + j, 12].Value = LastSumPriceUSD[1];
                                    xlsSheet[rManager + 1 + j, 13].Value = LastSumPriceVND[1];

                                    xlsSheetEn[rManager + 1 + j, 12].Value = LastSumPriceUSD[1];
                                    xlsSheetEn[rManager + 1 + j, 13].Value = LastSumPriceVND[1];

                                    for (int row = rManager + sumRow; row <= rManager + sumRow + dt.Rows.Count - k; row++)
                                    {
                                        for (int col = 1; col <= 13; col++)
                                        {
                                            //xlsSheet[row, col].Style = xlstStyle;
                                            //xlsSheetEn[row, col].Style = xlstStyle;
                                        }
                                    }

                                    for (int col = 1; col <= 13; col++)
                                    {
                                        //xlsSheet[rManager + 1 + j, col].Style = xlstStyleSum;
                                        //xlsSheetEn[rManager + 1 + j, col].Style = xlstStyleSum;
                                    }
                                    sumRow += dt.Rows.Count - 1 - k;
                                }
                            }

                            ds = new DataSet();
                            //Xuất ra toàn bộ nội dung theo Trang
                            sql = " SELECT COUNT(*) AS Num, YearMonth, TariffsParkingName, PriceVND, PriceUSD, SUM(VatVND) AS VatVND,SUM(VatUSD) AS VatUSD, SUM(SumVND) AS SumVND, SUM(SumUSD) AS SumUSD, SUM(LastPriceVND) AS LastPriceVND";
                            sql += "        , SUM(LastPriceUSD) AS LastPriceUSD";
                            sql += " FROM         dbo.PaymentParking";
                            sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + CustomerId + "' and YearMonth in (" + lsYearmonth + ")";

                            sql += " GROUP BY YearMonth, TariffsParkingName, PriceVND, PriceUSD, Vat, daysParking";
                            sql += " HAVING (SUM(LastPriceVND) >0 or SUM(LastPriceUSD) >0)";
                            using (SqlCommand cm = db.CreateCommand(sql))
                            {
                                SqlDataAdapter da = new SqlDataAdapter(cm);
                                da.Fill(ds);

                                line = rParking - 3 + j;
                                XLCellRange mCell = new XLCellRange(line, line + 2, 1, 3);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 4, 5);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 4, 5);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 2, line + 2, 4, 5);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);

                                ////En
                                mCell = new XLCellRange(line, line + 2, 1, 3);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 4, 5);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 4, 5);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 2, line + 2, 4, 5);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 6, 7);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 8, 9);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 10, 11);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                                xlsSheetEn.MergedCells.Add(mCell);
                                ////En
                                if (ds != null)
                                {
                                    int count = 0;
                                    DataTable dt = ds.Tables[0];

                                    foreach (DataRow row in dt.Rows)
                                    {
                                        if (count >= 1)
                                        {
                                            xlsSheet.Rows.Insert(rParking + 1 + j);
                                            xlsSheetEn.Rows.Insert(rParking + 1 + j);
                                            j++;
                                        }
                                        count++;
                                        int tmp = rParking + j;

                                        string Num = Func.ParseString(row["Num"]);
                                        string TariffsParkingName = Func.ParseString(row["TariffsParkingName"]);

                                        xlsSheet[tmp, 1].Value = TariffsParkingName;
                                        xlsSheet[tmp, 4].Value = Num;
                                        xlsSheet[tmp, 6].Value = row["PriceUSD"];
                                        xlsSheet[tmp, 7].Value = row["PriceVND"];

                                        xlsSheet[tmp, 8].Value = row["SumUSD"];
                                        xlsSheet[tmp, 9].Value = row["SumVND"];

                                        xlsSheet[tmp, 10].Value = row["VatUSD"];
                                        xlsSheet[tmp, 11].Value = row["VatVND"];

                                        xlsSheet[tmp, 12].Value = row["LastPriceUSD"];
                                        xlsSheet[tmp, 13].Value = row["LastPriceVND"];

                                        XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
                                        xlsSheet.MergedCells.Add(mrCell);

                                        mrCell = new XLCellRange(tmp, tmp, 4, 5);
                                        xlsSheet.MergedCells.Add(mrCell);

                                        /////En
                                        xlsSheetEn[tmp, 1].Value = TariffsParkingName;
                                        xlsSheetEn[tmp, 4].Value = Num;
                                        xlsSheetEn[tmp, 6].Value = row["PriceUSD"];
                                        xlsSheetEn[tmp, 7].Value = row["PriceVND"];

                                        xlsSheetEn[tmp, 8].Value = row["SumUSD"];
                                        xlsSheetEn[tmp, 9].Value = row["SumVND"];

                                        xlsSheetEn[tmp, 10].Value = row["VatUSD"];
                                        xlsSheetEn[tmp, 11].Value = row["VatVND"];

                                        xlsSheetEn[tmp, 12].Value = row["LastPriceUSD"];
                                        xlsSheetEn[tmp, 13].Value = row["LastPriceVND"];

                                        mrCell = new XLCellRange(tmp, tmp, 1, 3);
                                        xlsSheetEn.MergedCells.Add(mrCell);

                                        mrCell = new XLCellRange(tmp, tmp, 4, 5);
                                        xlsSheetEn.MergedCells.Add(mrCell);
                                        /////En
                                        LastSumPriceVND[2] += Convert.ToDecimal(row["LastPriceVND"]);
                                        LastSumPriceUSD[2] += Convert.ToDecimal(row["LastPriceUSD"]);
                                    }
                                    xlsSheet[rParking + 1 + j, 12].Value = LastSumPriceUSD[2];
                                    xlsSheet[rParking + 1 + j, 13].Value = LastSumPriceVND[2];

                                    mCell = new XLCellRange(rParking + 1 + j, rParking + 1 + j, 1, 11);
                                    xlsSheet.MergedCells.Add(mCell);


                                    /////En
                                    xlsSheetEn[rParking + 1 + j, 12].Value = LastSumPriceUSD[2];
                                    xlsSheetEn[rParking + 1 + j, 13].Value = LastSumPriceVND[2];

                                    mCell = new XLCellRange(rParking + 1 + j, rParking + 1 + j, 1, 11);
                                    xlsSheetEn.MergedCells.Add(mCell);
                                    /////En

                                    for (int row = rParking + sumRow; row <= rParking + sumRow + dt.Rows.Count; row++)
                                    {
                                        for (int col = 1; col <= 13; col++)
                                        {
                                            //xlsSheet[row, col].Style = xlstStyle;
                                            //xlsSheetEn[row, col].Style = xlstStyle;
                                        }
                                    }

                                    for (int col = 1; col <= 13; col++)
                                    {
                                        //xlsSheet[rParking + 1 + j, col].Style = xlstStyleSum;
                                        //xlsSheetEn[rParking + 1 + j, col].Style = xlstStyleSum;
                                    }
                                    sumRow += dt.Rows.Count - 1;
                                }
                            }

                            ds = new DataSet();
                            sql = "SELECT id";
                            sql += " ,YearMonth,BuildingId,CustomerId,RoomId,ExtraHour,VAT,OtherFee01,OtherFee02";
                            sql += " ,PriceUSD,PriceVND,VatUSD,VatVND,SumUSD,SumVND,IsNull(LastPriceUSD,0) LastPriceUSD      ,IsNull(LastPriceVND,0) LastPriceVND ";
                            sql += " ,RentArea,dbo.fnDateTime(FromWD) BeginDate,dbo.fnDateTime(EndWD) EndDate,ExtratimeType";
                            sql += " FROM PaymentExtraTimeMonth";
                            sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + CustomerId + "' and YearMonth in (" + lsYearmonth + ")";

                            using (SqlCommand cm = db.CreateCommand(sql))
                            {
                                SqlDataAdapter da = new SqlDataAdapter(cm);
                                da.Fill(ds);
                                line = rExtra - 3 + j;
                                //Phi dien
                                XLCellRange mCell = new XLCellRange(line, line + 2, 1, 3);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 4, 4);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);


                                /////En
                                mCell = new XLCellRange(line, line + 2, 1, 3);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 4, 4);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 6, 7);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 8, 9);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 10, 11);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                                xlsSheetEn.MergedCells.Add(mCell);
                                /////En
                                if (ds != null)
                                {
                                    int count = 0;
                                    DataTable dt = ds.Tables[0];

                                    foreach (DataRow row in dt.Rows)
                                    {
                                        if (count >= 1)
                                        {
                                            xlsSheet.Rows.Insert(rExtra + 1 + j);
                                            xlsSheetEn.Rows.Insert(rExtra + 1 + j);
                                            j++;
                                        }
                                        count++;
                                        int tmp = rExtra + j;

                                        string ExtraHour = Func.ParseString(row["ExtraHour"]);
                                        string BeginDate = Func.ParseString(row["BeginDate"]);
                                        string EndDate = Func.ParseString(row["EndDate"]);

                                        string ExtratimeType = Func.ParseString(row["ExtratimeType"]);

                                        xlsSheet[tmp, 1].Value = BeginDate + "~" + EndDate;
                                        xlsSheet[tmp, 5].Value = ExtraHour;

                                        xlsSheet[tmp, 4].Value = "Diện tích";
                                        if ("0".Equals(ExtratimeType))
                                        {
                                            xlsSheet[tmp, 4].Value = "m2*h";
                                        }
                                        xlsSheet[tmp, 6].Value = row["PriceUSD"];
                                        xlsSheet[tmp, 7].Value = row["PriceVND"];

                                        xlsSheet[tmp, 8].Value = row["SumUSD"];
                                        xlsSheet[tmp, 9].Value = row["SumVND"];

                                        xlsSheet[tmp, 10].Value = row["VatUSD"];
                                        xlsSheet[tmp, 11].Value = row["VatVND"];

                                        xlsSheet[tmp, 12].Value = row["LastPriceUSD"];
                                        xlsSheet[tmp, 13].Value = row["LastPriceVND"];

                                        LastSumPriceVND[3] += Convert.ToDecimal(row["LastPriceVND"]);
                                        LastSumPriceUSD[3] += Convert.ToDecimal(row["LastPriceUSD"]);

                                        XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
                                        xlsSheet.MergedCells.Add(mrCell);
                                        //////En
                                        xlsSheetEn[tmp, 1].Value = BeginDate + "~" + EndDate;
                                        xlsSheetEn[tmp, 5].Value = ExtraHour;

                                        xlsSheetEn[tmp, 4].Value = "Di?n tích";
                                        if ("0".Equals(ExtratimeType))
                                        {
                                            xlsSheetEn[tmp, 4].Value = "m2*h";
                                        }
                                        xlsSheetEn[tmp, 6].Value = row["PriceUSD"];
                                        xlsSheetEn[tmp, 7].Value = row["PriceVND"];

                                        xlsSheetEn[tmp, 8].Value = row["SumUSD"];
                                        xlsSheetEn[tmp, 9].Value = row["SumVND"];

                                        xlsSheetEn[tmp, 10].Value = row["VatUSD"];
                                        xlsSheetEn[tmp, 11].Value = row["VatVND"];

                                        xlsSheetEn[tmp, 12].Value = row["LastPriceUSD"];
                                        xlsSheetEn[tmp, 13].Value = row["LastPriceVND"];

                                        //LastSumPriceVND[3] += Convert.ToDecimal(row["LastPriceVND"]);
                                        //LastSumPriceUSD[3] += Convert.ToDecimal(row["LastPriceUSD"]);

                                        mrCell = new XLCellRange(tmp, tmp, 1, 3);
                                        xlsSheetEn.MergedCells.Add(mrCell);
                                        //////En

                                        for (int col = 1; col <= 13; col++)
                                        {
                                            //xlsSheet[tmp, col].Style = xlstStyle;
                                            //xlsSheetEn[tmp, col].Style = xlstStyle;
                                        }

                                    }
                                    mCell = new XLCellRange(rExtra + 1 + j, rExtra + 1 + j, 1, 11);
                                    xlsSheet.MergedCells.Add(mCell);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    xlsSheet[rExtra + 1 + j, 12].Value = LastSumPriceUSD[3];
                                    xlsSheet[rExtra + 1 + j, 13].Value = LastSumPriceVND[3];

                                    xlsSheetEn[rExtra + 1 + j, 12].Value = LastSumPriceUSD[3];
                                    xlsSheetEn[rExtra + 1 + j, 13].Value = LastSumPriceVND[3];

                                    for (int row = rExtra + sumRow; row <= rExtra + sumRow + dt.Rows.Count; row++)
                                    {
                                        for (int col = 1; col <= 13; col++)
                                        {
                                            //xlsSheet[row, col].Style = xlstStyle;
                                            //xlsSheetEn[row, col].Style = xlstStyle;
                                        }
                                    }

                                    for (int col = 1; col <= 13; col++)
                                    {
                                        //xlsSheet[rExtra + 1 + j, col].Style = xlstStyleSum;
                                        //xlsSheetEn[rExtra + 1 + j, col].Style = xlstStyleSum;
                                    }
                                    sumRow += dt.Rows.Count - 1;
                                }
                            }

                            ds = new DataSet();
                            //Dien
                            //Xuất ra toàn bộ nội dung theo Trang
                            sql = " SELECT dbo.fnDateTime(A.DateFrom) DateFrom, dbo.fnDateTime(A.DateTo) DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVND, B.PriceUSD, B.SumVND, B.SumUSD, ";
                            sql += "        B.VatVND, B.VatUSD ,IsNull(B.LastPriceUSD,0) LastPriceUSD      ,IsNull(B.LastPriceVND,0) LastPriceVND , B.Name, B.WaterPricePercent,B.ElecPricePercent ";
                            sql += " FROM   PaymentElecWater AS A INNER JOIN ";
                            sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId";
                            sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + CustomerId + "' and TarrifsOfWaterId = 0  and A.YearMonth in (" + lsYearmonth + ")";
                            sql += " Order by A.DateFrom, B.FromIndex";

                            using (SqlCommand cm = db.CreateCommand(sql))
                            {
                                SqlDataAdapter da = new SqlDataAdapter(cm);
                                da.Fill(ds);

                                line = rElec - 3 + j;
                                //Phi dien
                                XLCellRange mCell = new XLCellRange(line, line + 2, 1, 1);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 2, 2);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 3, 3);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 4, 4);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 5, 5);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 7, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 8, 8);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 9, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 10, 10);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 11, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);
                                /////En
                                mCell = new XLCellRange(line, line + 2, 1, 1);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 2, 2);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 3, 3);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 4, 4);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 5, 5);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 7, 7);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 8, 8);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 9, 9);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 10, 10);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 11, 11);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 12, 13);
                                xlsSheetEn.MergedCells.Add(mCell);
                                /////En

                                for (int col = 1; col < 13; col++)
                                {
                                    xlsSheet[line, col].Style = xlstStyleH;
                                    xlsSheet[line + 1, col].Style = xlstStyleH;
                                    xlsSheet[line + 2, col].Style = xlstStyleH;

                                    xlsSheetEn[line, col].Style = xlstStyleH;
                                    xlsSheetEn[line + 1, col].Style = xlstStyleH;
                                    xlsSheetEn[line + 2, col].Style = xlstStyleH;
                                }

                                if (ds != null)
                                {
                                    int count = 0;
                                    DataTable dt = ds.Tables[0];
                                    if (dt.Rows.Count > 0)
                                    {
                                        foreach (DataRow row in dt.Rows)
                                        {
                                            if (count >= 1)
                                            {
                                                xlsSheet.Rows.Insert(rElec + 1 + j);
                                                xlsSheetEn.Rows.Insert(rElec + 1 + j);
                                                j++;

                                            }
                                            count++;
                                            int tmp = rElec + j;

                                            string DateFrom = Func.ParseString(row["DateFrom"]);
                                            string DateTo = Func.ParseString(row["DateTo"]);

                                            string FromIndex = Func.ParseString(row["FromIndex"]);
                                            string ToIndex = Func.ParseString(row["ToIndex"]);
                                            string OtherFee01 = Func.ParseString(row["OtherFee01"]);
                                            string OtherFee02 = Func.ParseString(row["OtherFee02"]);
                                            string Mount = Func.ParseString(row["Mount"]);
                                            string ElecPricePercent = Func.ParseString(row["ElecPricePercent"]);

                                            xlsSheet[tmp, 1].Value = DateFrom;
                                            xlsSheet[tmp, 2].Value = DateTo;
                                            xlsSheet[tmp, 3].Value = FromIndex;
                                            xlsSheet[tmp, 4].Value = ToIndex;
                                            xlsSheet[tmp, 5].Value = OtherFee01;
                                            xlsSheet[tmp, 6].Value = Mount;
                                            xlsSheet[tmp, 7].Value = row["PriceVND"];
                                            xlsSheet[tmp, 8].Value = row["VatVND"];

                                            xlsSheet[tmp, 9].Value = row["SumVND"];
                                            xlsSheet[tmp, 10].Value = row["OtherFee02"];
                                            xlsSheet[tmp, 11].Value = row["ElecPricePercent"];
                                            xlsSheet[tmp, 12].Value = row["LastPriceVND"];

                                            mCell = new XLCellRange(tmp, tmp, 12, 13);
                                            xlsSheet.MergedCells.Add(mCell);


                                            /////En
                                            xlsSheetEn[tmp, 1].Value = DateFrom;
                                            xlsSheetEn[tmp, 2].Value = DateTo;
                                            xlsSheetEn[tmp, 3].Value = FromIndex;
                                            xlsSheetEn[tmp, 4].Value = ToIndex;
                                            xlsSheetEn[tmp, 5].Value = OtherFee01;
                                            xlsSheetEn[tmp, 6].Value = Mount;
                                            xlsSheetEn[tmp, 7].Value = row["PriceVND"];
                                            xlsSheetEn[tmp, 8].Value = row["VatVND"];

                                            xlsSheetEn[tmp, 9].Value = row["SumVND"];
                                            xlsSheetEn[tmp, 10].Value = row["OtherFee02"];
                                            xlsSheetEn[tmp, 11].Value = row["ElecPricePercent"];
                                            xlsSheetEn[tmp, 12].Value = row["LastPriceVND"];

                                            mCell = new XLCellRange(tmp, tmp, 12, 13);
                                            xlsSheetEn.MergedCells.Add(mCell);
                                            /////En
                                            for (int col = 1; col <= 12; col++)
                                            {
                                                //xlsSheet[tmp, col].Style = xlstStyle;
                                                //xlsSheetEn[tmp, col].Style = xlstStyle;
                                            }
                                            LastSumPriceVND[4] += Convert.ToDecimal(row["LastPriceVND"]);
                                            LastSumPriceUSD[4] += Convert.ToDecimal(row["LastPriceUSD"]);
                                        }
                                        xlsSheet[rElec + 1 + j, 12].Value = LastSumPriceVND[4];
                                        mCell = new XLCellRange(rElec + 1 + j, rElec + 1 + j, 1, 11);
                                        xlsSheet.MergedCells.Add(mCell);

                                        mCell = new XLCellRange(rElec + 1 + j, rElec + 1 + j, 12, 13);
                                        xlsSheet.MergedCells.Add(mCell);


                                        xlsSheetEn[rElec + 1 + j, 12].Value = LastSumPriceVND[4];
                                        mCell = new XLCellRange(rElec + 1 + j, rElec + 1 + j, 1, 11);
                                        xlsSheetEn.MergedCells.Add(mCell);

                                        mCell = new XLCellRange(rElec + 1 + j, rElec + 1 + j, 12, 13);
                                        xlsSheetEn.MergedCells.Add(mCell);

                                        for (int col = 1; col <= 13; col++)
                                        {
                                            //xlsSheet[rElec + 1 + j, col].Style = xlstStyleSum;
                                            //xlsSheetEn[rElec + 1 + j, col].Style = xlstStyleSum;
                                        }
                                        sumRow += dt.Rows.Count - 1;
                                    }
                                }
                            }

                            ds = new DataSet();
                            //Nuoc
                            //Xuất ra toàn bộ nội dung theo Trang
                            sql = " SELECT dbo.fnDateTime(A.DateFrom) DateFrom, dbo.fnDateTime(A.DateTo) DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVND, B.PriceUSD, B.SumVND, B.SumUSD, ";
                            sql += "        B.VatVND, B.VatUSD,IsNull(B.LastPriceUSD,0) LastPriceUSD,IsNull(B.LastPriceVND,0) LastPriceVND, B.Name, B.WaterPricePercent,B.ElecPricePercent  ";
                            sql += " FROM   PaymentElecWater AS A INNER JOIN ";
                            sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId";
                            sql += " WHERE A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.CustomerId = '" + CustomerId + "' and TarrifsOfElecId = 0 and A.YearMonth in (" + lsYearmonth + ")";
                            sql += " Order by A.DateFrom, B.FromIndex";

                            using (SqlCommand cm = db.CreateCommand(sql))
                            {
                                SqlDataAdapter da = new SqlDataAdapter(cm);
                                da.Fill(ds);
                                line = rWater - 3 + j;
                                //Phi dien
                                XLCellRange mCell = new XLCellRange(line, line + 2, 1, 1);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 2, 2);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 3, 3);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 4, 4);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 6, 6);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 7, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 8, 8);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 9, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 10, 10);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 11, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);


                                /////En
                                mCell = new XLCellRange(line, line + 2, 1, 1);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 2, 2);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 3, 3);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 4, 4);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 6, 6);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 7, 7);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 8, 8);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 9, 9);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 10, 10);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 11, 11);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 12, 13);
                                xlsSheetEn.MergedCells.Add(mCell);
                                /////En

                                for (int col = 1; col < 13; col++)
                                {
                                    xlsSheet[line, col].Style = xlstStyleH;
                                    xlsSheet[line + 1, col].Style = xlstStyleH;
                                    xlsSheet[line + 2, col].Style = xlstStyleH;

                                    xlsSheetEn[line, col].Style = xlstStyleH;
                                    xlsSheetEn[line + 1, col].Style = xlstStyleH;
                                    xlsSheetEn[line + 2, col].Style = xlstStyleH;
                                }

                                if (ds != null)
                                {
                                    int count = 0;
                                    DataTable dt = ds.Tables[0];
                                    if (dt.Rows.Count > 0)
                                    {
                                        foreach (DataRow row in dt.Rows)
                                        {
                                            if (count >= 1)
                                            {
                                                xlsSheet.Rows.Insert(rWater + 1 + j);
                                                xlsSheetEn.Rows.Insert(rWater + 1 + j);
                                                j++;
                                            }
                                            count++;
                                            int tmp = rWater + j;

                                            string DateFrom = Func.ParseString(row["DateFrom"]);
                                            string DateTo = Func.ParseString(row["DateTo"]);

                                            string FromIndex = Func.ParseString(row["FromIndex"]);
                                            string ToIndex = Func.ParseString(row["ToIndex"]);
                                            string OtherFee01 = Func.ParseString(row["OtherFee01"]);
                                            string OtherFee02 = Func.ParseString(row["OtherFee02"]);
                                            string Mount = Func.ParseString(row["Mount"]);

                                            xlsSheet[tmp, 1].Value = DateFrom;
                                            xlsSheet[tmp, 2].Value = DateTo;
                                            xlsSheet[tmp, 3].Value = FromIndex;
                                            xlsSheet[tmp, 4].Value = ToIndex;
                                            xlsSheet[tmp, 5].Value = Mount;
                                            xlsSheet[tmp, 6].Value = row["PriceVND"];
                                            xlsSheet[tmp, 7].Value = row["OtherFee01"];
                                            xlsSheet[tmp, 8].Value = row["VatVND"];

                                            xlsSheet[tmp, 9].Value = row["SumVND"];
                                            xlsSheet[tmp, 10].Value = row["OtherFee02"];
                                            xlsSheet[tmp, 11].Value = row["WaterPricePercent"];
                                            xlsSheet[tmp, 12].Value = row["LastPriceVND"];


                                            /////En
                                            xlsSheetEn[tmp, 1].Value = DateFrom;
                                            xlsSheetEn[tmp, 2].Value = DateTo;
                                            xlsSheetEn[tmp, 3].Value = FromIndex;
                                            xlsSheetEn[tmp, 4].Value = ToIndex;
                                            xlsSheetEn[tmp, 5].Value = Mount;
                                            xlsSheetEn[tmp, 6].Value = row["PriceVND"];
                                            xlsSheetEn[tmp, 7].Value = row["OtherFee01"];
                                            xlsSheetEn[tmp, 8].Value = row["VatVND"];

                                            xlsSheetEn[tmp, 9].Value = row["SumVND"];
                                            xlsSheetEn[tmp, 10].Value = row["OtherFee02"];
                                            xlsSheetEn[tmp, 11].Value = row["WaterPricePercent"];
                                            xlsSheetEn[tmp, 12].Value = row["LastPriceVND"];

                                            /////En
                                            for (int col = 1; col <= 12; col++)
                                            {
                                                //xlsSheet[tmp, col].Style = xlstStyle;
                                                //xlsSheetEn[tmp, col].Style = xlstStyle;
                                            }
                                            LastSumPriceVND[5] += Convert.ToDecimal(row["LastPriceVND"]);
                                            LastSumPriceUSD[5] += Convert.ToDecimal(row["LastPriceUSD"]);

                                            mCell = new XLCellRange(tmp, tmp, 12, 13);
                                            xlsSheet.MergedCells.Add(mCell);
                                            xlsSheetEn.MergedCells.Add(mCell);
                                        }
                                        xlsSheet[rWater + 1 + j, 12].Value = LastSumPriceVND[5];
                                        xlsSheetEn[rWater + 1 + j, 12].Value = LastSumPriceVND[5];
                                        mCell = new XLCellRange(rWater + 1 + j, rWater + 1 + j, 1, 11);
                                        xlsSheet.MergedCells.Add(mCell);
                                        xlsSheetEn.MergedCells.Add(mCell);

                                        mCell = new XLCellRange(rWater + 1 + j, rWater + 1 + j, 12, 13);
                                        xlsSheet.MergedCells.Add(mCell);
                                        xlsSheetEn.MergedCells.Add(mCell);

                                        for (int col = 1; col <= 13; col++)
                                        {
                                            //xlsSheet[rWater + 1 + j, col].Style = xlstStyleSum;
                                            //xlsSheetEn[rWater + 1 + j, col].Style = xlstStyleSum;
                                        }
                                        sumRow += dt.Rows.Count - 1;
                                    }
                                }
                            }

                            //Service
                            ds = new DataSet();

                            sql = string.Empty;
                            sql = " SELECT Service,dbo.fnDateTime(ServiceDateFrom) ServiceDateFrom,dbo.fnDateTime(ServiceDateTo) ServiceDateTo,PriceVND,PriceUSD,VatUSD,VatVND,Mount,Unit,SumVND,SumUSD,isnull(LastPriceVND,0) LastPriceVND,isnull(LastPriceUSD,0) LastPriceUSD";
                            sql += " FROM   PaymentService";
                            sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + CustomerId + "' and YearMonth in (" + lsYearmonth + ")";
                            sql += " Order By ServiceDate ";

                            using (SqlCommand cm = db.CreateCommand(sql))
                            {
                                SqlDataAdapter da = new SqlDataAdapter(cm);
                                da.Fill(ds);
                                line = rService - 3 + j;
                                //Phi khác
                                XLCellRange mCell = new XLCellRange(line, line + 2, 1, 1);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 2, 2);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 3, 3);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 4, 4);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 5, 5);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                /////En
                                mCell = new XLCellRange(line, line + 2, 1, 1);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 2, 2);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 3, 3);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 4, 4);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 5, 5);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 6, 7);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 8, 9);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 10, 11);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                xlsSheetEn.MergedCells.Add(mCell);
                                /////En
                                for (int col = 1; col < 13; col++)
                                {
                                    xlsSheet[line, col].Style = xlstStyleH;
                                    xlsSheet[line + 1, col].Style = xlstStyleH;
                                    xlsSheet[line + 2, col].Style = xlstStyleH;

                                    xlsSheetEn[line, col].Style = xlstStyleH;
                                    xlsSheetEn[line + 1, col].Style = xlstStyleH;
                                    xlsSheetEn[line + 2, col].Style = xlstStyleH;
                                }
                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                if (ds != null)
                                {
                                    int count = 0;
                                    DataTable dt = ds.Tables[0];

                                    if (dt.Rows.Count > 0)
                                    {

                                        foreach (DataRow row in dt.Rows)
                                        {
                                            if (count >= 1)
                                            {
                                                xlsSheet.Rows.Insert(rService + 1 + j);
                                                xlsSheetEn.Rows.Insert(rService + 1 + j);
                                                j++;
                                            }
                                            count++;
                                            int tmp = rService + j;



                                            string Service = Func.ParseString(row["Service"]);
                                            string ServiceDateFrom = Func.ParseString(row["ServiceDateFrom"]);
                                            string ServiceDateTo = Func.ParseString(row["ServiceDateTo"]);

                                            string Mount = Func.ParseString(row["Mount"]);

                                            xlsSheet[tmp, 1].Value = Service;
                                            xlsSheet[tmp, 2].Value = Func.ParseString(row["Unit"]);
                                            xlsSheet[tmp, 3].Value = ServiceDateFrom;
                                            xlsSheet[tmp, 4].Value = ServiceDateTo;
                                            xlsSheet[tmp, 5].Value = Mount;

                                            xlsSheet[tmp, 6].Value = row["PriceUSD"];
                                            xlsSheet[tmp, 7].Value = row["PriceVND"];

                                            xlsSheet[tmp, 8].Value = row["SumUSD"];
                                            xlsSheet[tmp, 9].Value = row["SumVND"];

                                            xlsSheet[tmp, 10].Value = row["VatUSD"];
                                            xlsSheet[tmp, 11].Value = row["VatVND"];

                                            xlsSheet[tmp, 12].Value = row["LastPriceUSD"];
                                            xlsSheet[tmp, 13].Value = row["LastPriceVND"];

                                            /////En
                                            xlsSheetEn[tmp, 1].Value = Service;
                                            xlsSheetEn[tmp, 2].Value = Func.ParseString(row["Unit"]);
                                            xlsSheetEn[tmp, 3].Value = ServiceDateFrom;
                                            xlsSheetEn[tmp, 4].Value = ServiceDateTo;
                                            xlsSheetEn[tmp, 5].Value = Mount;

                                            xlsSheetEn[tmp, 6].Value = row["PriceUSD"];
                                            xlsSheetEn[tmp, 7].Value = row["PriceVND"];

                                            xlsSheetEn[tmp, 8].Value = row["SumUSD"];
                                            xlsSheetEn[tmp, 9].Value = row["SumVND"];

                                            xlsSheetEn[tmp, 10].Value = row["VatUSD"];
                                            xlsSheetEn[tmp, 11].Value = row["VatVND"];

                                            xlsSheetEn[tmp, 12].Value = row["LastPriceUSD"];
                                            xlsSheetEn[tmp, 13].Value = row["LastPriceVND"];
                                            /////En

                                            for (int col = 1; col <= 13; col++)
                                            {
                                                //xlsSheet[tmp, col].Style = xlstStyle;
                                                //xlsSheetEn[tmp, col].Style = xlstStyle;
                                            }
                                            LastSumPriceVND[6] += Convert.ToDecimal(row["LastPriceVND"]);
                                            LastSumPriceUSD[6] += Convert.ToDecimal(row["LastPriceUSD"]);
                                        }
                                        xlsSheet[rService + 1 + j, 12].Value = LastSumPriceUSD[6];
                                        xlsSheet[rService + 1 + j, 13].Value = LastSumPriceVND[6];

                                        xlsSheetEn[rService + 1 + j, 12].Value = LastSumPriceUSD[6];
                                        xlsSheetEn[rService + 1 + j, 13].Value = LastSumPriceVND[6];

                                        mCell = new XLCellRange(rService + 1 + j, rService + 1 + j, 1, 11);
                                        xlsSheet.MergedCells.Add(mCell);
                                        xlsSheetEn.MergedCells.Add(mCell);

                                        for (int col = 1; col <= 13; col++)
                                        {
                                            //xlsSheet[rService + 1 + j, col].Style = xlstStyleSum;
                                            //xlsSheetEn[rService + 1 + j, col].Style = xlstStyleSum;
                                        }
                                        sumRow += dt.Rows.Count - 1;
                                    }
                                }
                            }

                            //Paid
                            sql = "Select  *";
                            sql += " From    PaymentBillDetail";
                            sql += " Where   BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + CustomerId + "' and YearMonth in (" + lsYearmonth + ") and YearMonth < " + maxYearMonth + "";
                            string strYearMonth = "";
                            int lineTmp = rPaid - 2 + j;

                            //Paid
                            XLCellRange mCellTmp = new XLCellRange(lineTmp, lineTmp + 1, 1, 1);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 2, 3);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 4, 5);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 6, 7);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 8, 9);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 12, 13);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            /////En
                            mCellTmp = new XLCellRange(lineTmp, lineTmp + 1, 1, 1);
                            xlsSheetEn.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 2, 3);
                            xlsSheetEn.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 4, 5);
                            xlsSheetEn.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 6, 7);
                            xlsSheetEn.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 8, 9);
                            xlsSheetEn.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 12, 13);
                            xlsSheetEn.MergedCells.Add(mCellTmp);
                            /////En
                            Hashtable rowNo = new Hashtable();
                            decimal[] PaidSumVND = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };
                            decimal[] PaidSumUSD = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };

                            DataTable dtPaid = DbHelper.GetDataTable(sql);
                            for (int i = 0; i < dtPaid.Rows.Count; i++)
                            {
                                string PaymentType = Func.ParseString(dtPaid.Rows[i]["PaymentType"]);
                                string MoneyUSD = Func.ParseString(dtPaid.Rows[i]["MoneyUSD"]);
                                string MoneyVND = Func.ParseString(dtPaid.Rows[i]["MoneyVND"]);
                                string PaidUSD = Func.ParseString(dtPaid.Rows[i]["PaidUSD"]);
                                string PaidVND = Func.ParseString(dtPaid.Rows[i]["PaidVND"]);
                                string ExchangeType = Func.ParseString(dtPaid.Rows[i]["ExchangeType"]);
                                string YearMonth = Func.ParseString(dtPaid.Rows[i]["YearMonth"]);

                                if (!rowNo.Contains(YearMonth))
                                {
                                    if (rowNo.Count != 0)
                                    {
                                        xlsSheet.Rows.Insert(rPaid + j + 1);
                                        xlsSheetEn.Rows.Insert(rPaid + j + 1);
                                        j++;
                                    }
                                    rowNo.Add(YearMonth, j);
                                }
                                int m = Func.ParseInt(rowNo[YearMonth]);
                                strYearMonth = YearMonth;
                                decimal tmpUSD = Convert.ToDecimal(MoneyUSD) - Convert.ToDecimal(PaidUSD);
                                decimal tmpVND = Convert.ToDecimal(MoneyVND) - Convert.ToDecimal(PaidVND);

                                PaidPriceUSD += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                                PaidPriceVND += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);

                                xlsSheet[rPaid + m, 1].Value = YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4);
                                xlsSheetEn[rPaid + m, 1].Value = YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4);
                                switch (PaymentType)
                                {
                                    case "1":
                                        //Rent
                                        xlsSheet[rPaid + m, 2].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheet[rPaid + m, 3].Value = dtPaid.Rows[i]["PaidVND"];

                                        xlsSheetEn[rPaid + m, 2].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheetEn[rPaid + m, 3].Value = dtPaid.Rows[i]["PaidVND"];

                                        PaidSumUSD[0] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                                        PaidSumVND[0] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);

                                        break;
                                    case "2":
                                        //Manager
                                        xlsSheet[rPaid + m, 4].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheet[rPaid + m, 5].Value = dtPaid.Rows[i]["PaidVND"];

                                        xlsSheetEn[rPaid + m, 4].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheetEn[rPaid + m, 5].Value = dtPaid.Rows[i]["PaidVND"];

                                        PaidSumUSD[1] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                                        PaidSumVND[1] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);

                                        break;
                                    case "3":
                                        //Parking
                                        xlsSheet[rPaid + m, 6].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheet[rPaid + m, 7].Value = dtPaid.Rows[i]["PaidVND"];

                                        xlsSheetEn[rPaid + m, 6].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheetEn[rPaid + m, 7].Value = dtPaid.Rows[i]["PaidVND"];

                                        PaidSumUSD[2] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                                        PaidSumVND[2] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
                                        break;
                                    case "4":
                                        //Extra
                                        xlsSheet[rPaid + m, 8].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheet[rPaid + m, 9].Value = dtPaid.Rows[i]["PaidVND"];

                                        xlsSheetEn[rPaid + m, 8].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheetEn[rPaid + m, 9].Value = dtPaid.Rows[i]["PaidVND"];

                                        PaidSumUSD[3] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                                        PaidSumVND[3] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
                                        break;
                                    case "5":
                                        xlsSheet[rPaid + m, 10].Value = dtPaid.Rows[i]["PaidVND"];
                                        xlsSheetEn[rPaid + m, 10].Value = dtPaid.Rows[i]["PaidVND"];

                                        PaidSumUSD[4] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                                        PaidSumVND[4] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
                                        break;
                                    case "6":
                                        xlsSheet[rPaid + m, 11].Value = dtPaid.Rows[i]["PaidVND"];
                                        xlsSheetEn[rPaid + m, 11].Value = dtPaid.Rows[i]["PaidVND"];

                                        PaidSumUSD[5] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                                        PaidSumVND[5] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
                                        break;
                                    case "7":
                                        xlsSheet[rPaid + m, 12].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheet[rPaid + m, 13].Value = dtPaid.Rows[i]["PaidVND"];

                                        xlsSheetEn[rPaid + m, 12].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheetEn[rPaid + m, 13].Value = dtPaid.Rows[i]["PaidVND"];
                                        break;
                                    default:
                                        break;
                                }
                                for (int row = rPaid + m; row <= rPaid + 1 + j; row++)
                                {
                                    for (int col = 1; col <= 13; col++)
                                    {
                                        //xlsSheet[row, col].Style = xlstStyle;
                                    }
                                }
                            }
                            lineTmp = rPaid - 2 + j;

                            xlsSheet[lineTmp + 3, 2].Value = PaidSumUSD[0];
                            xlsSheet[lineTmp + 3, 3].Value = PaidSumVND[0];
                            xlsSheet[lineTmp + 3, 4].Value = PaidSumUSD[1];
                            xlsSheet[lineTmp + 3, 5].Value = PaidSumVND[1];
                            xlsSheet[lineTmp + 3, 6].Value = PaidSumUSD[2];
                            xlsSheet[lineTmp + 3, 7].Value = PaidSumVND[2];
                            xlsSheet[lineTmp + 3, 8].Value = PaidSumUSD[3];
                            xlsSheet[lineTmp + 3, 9].Value = PaidSumVND[3];
                            xlsSheet[lineTmp + 3, 10].Value = PaidSumVND[4];
                            xlsSheet[lineTmp + 3, 11].Value = PaidSumVND[5];
                            xlsSheet[lineTmp + 3, 12].Value = PaidSumUSD[6];
                            xlsSheet[lineTmp + 3, 13].Value = PaidSumVND[6];

                            /////En
                            xlsSheetEn[lineTmp + 3, 2].Value = PaidSumUSD[0];
                            xlsSheetEn[lineTmp + 3, 3].Value = PaidSumVND[0];
                            xlsSheetEn[lineTmp + 3, 4].Value = PaidSumUSD[1];
                            xlsSheetEn[lineTmp + 3, 5].Value = PaidSumVND[1];
                            xlsSheetEn[lineTmp + 3, 6].Value = PaidSumUSD[2];
                            xlsSheetEn[lineTmp + 3, 7].Value = PaidSumVND[2];
                            xlsSheetEn[lineTmp + 3, 8].Value = PaidSumUSD[3];
                            xlsSheetEn[lineTmp + 3, 9].Value = PaidSumVND[3];
                            xlsSheetEn[lineTmp + 3, 10].Value = PaidSumVND[4];
                            xlsSheetEn[lineTmp + 3, 11].Value = PaidSumVND[5];
                            xlsSheetEn[lineTmp + 3, 12].Value = PaidSumUSD[6];
                            xlsSheetEn[lineTmp + 3, 13].Value = PaidSumVND[6];
                            /////En

                            for (int col = 1; col <= 13; col++)
                            {
                                //xlsSheet[lineTmp + 3, col].Style = xlstStyleSum;
                                //xlsSheetEn[lineTmp + 3, col].Style = xlstStyleSum;
                            }

                            ///////////////DEPT
                            sql = "  Select *";
                            sql += " From   v_DeptBill";
                            sql += " Where  BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + CustomerId + "' and YearMonth not in (" + lsYearmonth + ") and YearMonth < " + maxYearMonth + "";
                            sql += " And    (DeptUsd <> 0 or DeptVnd <> 0)";
                            strYearMonth = "";
                            lineTmp = rDept - 2 + j;

                            //Paid
                            mCellTmp = new XLCellRange(lineTmp, lineTmp + 1, 1, 1);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 2, 3);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 4, 5);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 6, 7);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 8, 9);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 12, 13);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            //////En
                            mCellTmp = new XLCellRange(lineTmp, lineTmp + 1, 1, 1);
                            xlsSheetEn.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 2, 3);
                            xlsSheetEn.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 4, 5);
                            xlsSheetEn.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 6, 7);
                            xlsSheetEn.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 8, 9);
                            xlsSheetEn.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 12, 13);
                            xlsSheetEn.MergedCells.Add(mCellTmp);
                            //////En
                            rowNo = new Hashtable();
                            decimal DeptPriceVND = 0;
                            decimal DeptPriceUSD = 0;

                            decimal[] DeptSumVND = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };
                            decimal[] DeptSumUSD = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };


                            DataTable dtDept = DbHelper.GetDataTable(sql);
                            for (int i = 0; i < dtDept.Rows.Count; i++)
                            {
                                string PaymentType = Func.ParseString(dtDept.Rows[i]["PaymentType"]);
                                string DeptUSD = Func.ParseString(dtDept.Rows[i]["DeptUSD"]);
                                string DeptVND = Func.ParseString(dtDept.Rows[i]["DeptVND"]);
                                string YearMonth = Func.ParseString(dtDept.Rows[i]["YearMonth"]);

                                if (!rowNo.Contains(YearMonth))
                                {
                                    if (rowNo.Count != 0)
                                    {
                                        xlsSheet.Rows.Insert(rDept + j + 1);
                                        xlsSheetEn.Rows.Insert(rDept + j + 1);
                                        j++;
                                    }
                                    rowNo.Add(YearMonth, j);
                                }
                                int m = Func.ParseInt(rowNo[YearMonth]);
                                strYearMonth = YearMonth;

                                DeptPriceUSD += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                                DeptPriceVND += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);

                                xlsSheet[rDept + m, 1].Value = YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4);
                                xlsSheetEn[rDept + m, 1].Value = YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4);

                                switch (PaymentType)
                                {
                                    case "1":
                                        //Rent
                                        xlsSheet[rDept + m, 2].Value = dtDept.Rows[i]["DeptUSD"];
                                        xlsSheet[rDept + m, 3].Value = dtDept.Rows[i]["DeptVND"];

                                        xlsSheetEn[rDept + m, 2].Value = dtDept.Rows[i]["DeptUSD"];
                                        xlsSheetEn[rDept + m, 3].Value = dtDept.Rows[i]["DeptVND"];

                                        DeptSumUSD[0] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                                        DeptSumVND[0] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);

                                        break;
                                    case "2":
                                        //Manager
                                        xlsSheet[rDept + m, 4].Value = dtDept.Rows[i]["DeptUSD"];
                                        xlsSheet[rDept + m, 5].Value = dtDept.Rows[i]["DeptVND"];

                                        xlsSheetEn[rDept + m, 4].Value = dtDept.Rows[i]["DeptUSD"];
                                        xlsSheetEn[rDept + m, 5].Value = dtDept.Rows[i]["DeptVND"];

                                        DeptSumUSD[1] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                                        DeptSumVND[1] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);

                                        break;
                                    case "3":
                                        //Parking
                                        xlsSheet[rDept + m, 6].Value = dtDept.Rows[i]["DeptUSD"];
                                        xlsSheet[rDept + m, 7].Value = dtDept.Rows[i]["DeptVND"];

                                        xlsSheetEn[rDept + m, 6].Value = dtDept.Rows[i]["DeptUSD"];
                                        xlsSheetEn[rDept + m, 7].Value = dtDept.Rows[i]["DeptVND"];

                                        DeptSumUSD[2] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                                        DeptSumVND[2] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
                                        break;
                                    case "4":
                                        //Extra
                                        xlsSheet[rDept + m, 8].Value = dtDept.Rows[i]["DeptUSD"];
                                        xlsSheet[rDept + m, 9].Value = dtDept.Rows[i]["DeptVND"];

                                        xlsSheetEn[rDept + m, 8].Value = dtDept.Rows[i]["DeptUSD"];
                                        xlsSheetEn[rDept + m, 9].Value = dtDept.Rows[i]["DeptVND"];

                                        DeptSumUSD[3] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                                        DeptSumVND[3] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
                                        break;
                                    case "5":
                                        xlsSheet[rDept + m, 10].Value = dtDept.Rows[i]["DeptVND"];
                                        xlsSheetEn[rDept + m, 10].Value = dtDept.Rows[i]["DeptVND"];

                                        DeptSumUSD[4] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                                        DeptSumVND[4] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
                                        break;
                                    case "6":
                                        xlsSheet[rDept + m, 11].Value = dtDept.Rows[i]["DeptVND"];
                                        xlsSheetEn[rDept + m, 11].Value = dtDept.Rows[i]["DeptVND"];

                                        DeptSumUSD[5] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                                        DeptSumVND[5] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
                                        break;
                                    case "7":
                                        xlsSheet[rDept + m, 12].Value = dtDept.Rows[i]["DeptUSD"];
                                        xlsSheet[rDept + m, 13].Value = dtDept.Rows[i]["DeptVND"];

                                        xlsSheetEn[rDept + m, 12].Value = dtDept.Rows[i]["DeptUSD"];
                                        xlsSheetEn[rDept + m, 13].Value = dtDept.Rows[i]["DeptVND"];

                                        DeptSumUSD[6] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                                        DeptSumVND[6] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
                                        break;
                                    default:
                                        break;
                                }
                                for (int row = rDept + m; row <= rDept + 1 + j; row++)
                                {
                                    for (int col = 1; col <= 13; col++)
                                    {
                                        //xlsSheet[row, col].Style = xlstStyle;
                                        //xlsSheetEn[row, col].Style = xlstStyle;
                                    }
                                }
                            }
                            lineTmp = rDept - 2 + j;

                            xlsSheet[lineTmp + 3, 2].Value = DeptSumUSD[0];
                            xlsSheet[lineTmp + 3, 3].Value = DeptSumVND[0];
                            xlsSheet[lineTmp + 3, 4].Value = DeptSumUSD[1];
                            xlsSheet[lineTmp + 3, 5].Value = DeptSumVND[1];
                            xlsSheet[lineTmp + 3, 6].Value = DeptSumUSD[2];
                            xlsSheet[lineTmp + 3, 7].Value = DeptSumVND[2];
                            xlsSheet[lineTmp + 3, 8].Value = DeptSumUSD[3];
                            xlsSheet[lineTmp + 3, 9].Value = DeptSumVND[3];
                            xlsSheet[lineTmp + 3, 10].Value = DeptSumVND[4];
                            xlsSheet[lineTmp + 3, 11].Value = DeptSumVND[5];
                            xlsSheet[lineTmp + 3, 12].Value = DeptSumUSD[6];
                            xlsSheet[lineTmp + 3, 13].Value = DeptSumVND[6];


                            //////En
                            xlsSheetEn[lineTmp + 3, 2].Value = DeptSumUSD[0];
                            xlsSheetEn[lineTmp + 3, 3].Value = DeptSumVND[0];
                            xlsSheetEn[lineTmp + 3, 4].Value = DeptSumUSD[1];
                            xlsSheetEn[lineTmp + 3, 5].Value = DeptSumVND[1];
                            xlsSheetEn[lineTmp + 3, 6].Value = DeptSumUSD[2];
                            xlsSheetEn[lineTmp + 3, 7].Value = DeptSumVND[2];
                            xlsSheetEn[lineTmp + 3, 8].Value = DeptSumUSD[3];
                            xlsSheetEn[lineTmp + 3, 9].Value = DeptSumVND[3];
                            xlsSheetEn[lineTmp + 3, 10].Value = DeptSumVND[4];
                            xlsSheetEn[lineTmp + 3, 11].Value = DeptSumVND[5];
                            xlsSheetEn[lineTmp + 3, 12].Value = DeptSumUSD[6];
                            xlsSheetEn[lineTmp + 3, 13].Value = DeptSumVND[6];
                            //////En
                            for (int col = 1; col <= 13; col++)
                            {
                                //xlsSheet[lineTmp + 3, col].Style = xlstStyleSum;
                                //xlsSheetEn[lineTmp + 3, col].Style = xlstStyleSum;
                            }

                            //xlsSheet[lineTmp + 3, 1].Style = xlstStyleSum;
                            //xlsSheetEn[lineTmp + 3, 1].Style = xlstStyleSum;

                            decimal AllSumVND = 0;
                            decimal AllSumUSD = 0;
                            for (int i = 0; i < 7; i++)
                            {
                                AllSumVND += LastSumPriceVND[i];
                                AllSumUSD += LastSumPriceUSD[i];
                            }

                            AllSumVND -= PaidPriceVND;
                            AllSumUSD -= PaidPriceUSD;

                            AllSumVND += DeptPriceVND;
                            AllSumUSD += DeptPriceUSD;

                            xlsSheet[rSumVND + j, cSumVND].Value = Func.FormatNumber_New(AllSumUSD);
                            xlsSheet[rSumVND + j, cSumVND].Value += "(USD)";
                            xlsSheet[rSumVND + j, cSumVND + 1].Value = Func.FormatNumber_New(AllSumVND);
                            xlsSheet[rSumVND + j, cSumVND + 1].Value += "(VND)";

                            xlsSheetEn[rSumVND + j, cSumVND].Value = Func.FormatNumber_New(AllSumUSD);
                            xlsSheetEn[rSumVND + j, cSumVND].Value += "(USD)";
                            xlsSheetEn[rSumVND + j, cSumVND + 1].Value = Func.FormatNumber_New(AllSumVND);
                            xlsSheetEn[rSumVND + j, cSumVND + 1].Value += "(VND)";

                            AllSumVND += Convert.ToDecimal(AllSumUSD * Convert.ToDecimal(UsdExchange));

                            string strMoney = Func.docso(Convert.ToInt32(AllSumVND));
                            string strMoneyEn = Func.DocSo_En(Convert.ToInt32(AllSumVND));

                            xlsSheet[rContract, cContract].Value = xlsSheet[rContract, cContract].Value.ToString().Replace("{%HOP_DONG%}", String.IsNullOrEmpty(contract) ? "" : contract.Substring(1));
                            xlsSheet[rSum + j, cSum].Value = Convert.ToInt32(AllSumVND);

                            mCellTmp = new XLCellRange(rSum + j, rSum + j, cSum, cSum + 1);
                            xlsSheet.MergedCells.Add(mCellTmp);
                            //xlsSheet[rSum + j, cSum].Style = xlstStyleSum;
                            //xlsSheet[rSum + j, cSum + 1].Style = xlstStyleSum;
                            xlsSheet[rSumRead + j, cSumRead].Value = xlsSheet[rSumRead + j, cSumRead].Value.ToString().Replace("{%TONG_CHU%}", strMoney.ToUpper());


                            xlsSheetEn[rContract, cContract].Value = xlsSheetEn[rContract, cContract].Value.ToString().Replace("{%HOP_DONG%}", String.IsNullOrEmpty(contract) ? "" : contract.Substring(1));
                            xlsSheetEn[rSum + j, cSum].Value = Convert.ToInt32(AllSumVND);

                            mCellTmp = new XLCellRange(rSum + j, rSum + j, cSum, cSum + 1);
                            xlsSheetEn.MergedCells.Add(mCellTmp);
                            //xlsSheetEn[rSum + j, cSum].Style = xlstStyleSum;
                            //xlsSheetEn[rSum + j, cSum + 1].Style = xlstStyleSum;
                            xlsSheetEn[rSumRead + j, cSumRead].Value = xlsSheetEn[rSumRead + j, cSumRead].Value.ToString().Replace("{%TONG_CHU%}", strMoneyEn.ToUpper());

                            xlbBook.Save(fileNameDes);
                            xlbBook.Clear();
                            //ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);
                        }
                    }
                }
            }
        }
    }
    public class ExportFile
    {
        private string sYearMonth = "";
        private string sYear = "";
        private string sMonth = "";
        private string sBuildingId = "";
        private string sFilePath = "";
        public ExportFile(string buildingId, string yearmonth, string filePath)
        {
            sBuildingId = buildingId;
            sYearMonth = yearmonth;
            sYear = yearmonth.Substring(0, 4);
            sMonth = yearmonth.Substring(4, 2);
            sFilePath = filePath;
        }
        public void DoExport()
        {
            int rBillNo = 0;
            int cBillNo = 1;

            int rBillDate = 0;
            int cBillDate = 10;

            int rBillMonth = 2;
            int cBillMonth = 0;

            int rContact = 5;
            int cContact = 3;

            int rCustomer = 5;
            int cCustomer = 7;

            int rContract = 7;
            int cContract = 1;

            int rRate = 11;
            int cRate = 9;

            int rRateDate = 11;
            int cRateDate = 12;

            int rRent = 15;

            int rManager = 23;

            int rParking = 31;

            int rExtra = 39;

            int rElec = 47;

            int rWater = 55;

            int rService = 63;

            int rPaid = 70;

            int rDept = 77;

            int rOffice = 88;
            int cOffice = 3;

            int rPhone = 89;
            int cPhone = 3;

            int rBank = 88;
            int cBank = 7;

            int rAccountName = 89;
            int cAccountName = 7;

            int rAccount = 90;
            int cAccount = 7;

            int rSum = 81;
            int cSum = 12;

            int rSumVND = 80;
            int cSumVND = 12;

            int rSumRead = 82;
            int cSumRead = 13;

            ////
            using (SqlDatabase db = new SqlDatabase())
            {

                DataSet ds = new DataSet();
                DataSet dsCus = new DataSet();

                string sql = string.Empty;

                string Bank = "";
                string Account = "";
                string AccountName = "";
                string Office = "";
                string OfficeAddress = "";
                string OfficePhone = "";

                ds = new DataSet();
                sql = " SELECT Bank,Account,AccountName,Office,OfficeAddress,OfficePhone";
                sql += " FROM Mst_Building";
                sql += " WHERE BuildingId = '" + sBuildingId + "' ";
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);

                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow rowType in dt.Rows)
                        {
                            Bank = rowType["Bank"].ToString();
                            Account = rowType["Account"].ToString();
                            AccountName = rowType["AccountName"].ToString();
                            Office = rowType["Office"].ToString();
                            OfficeAddress = rowType["OfficeAddress"].ToString();
                            OfficePhone = rowType["OfficePhone"].ToString();
                        }
                    }
                }

                //Danh sách Bill
                sql = "  Select BillDate,UsdExchangeDate,UsdExchange,BillNo,B.Name,B.ContactName,A.CustomerId, A.YearMonths, A.Id ";
                sql += " From	PaymentBillInfo A, Customer B";
                sql += " Where	A.BuildingId = B.BuildingId and A.CustomerId = B.CustomerId and B.DelFlag = 0 and A.BuildingId = '" + sBuildingId + "' and YearMonth = '" + sYearMonth + "'";

                string BillDate = "";
                string UsdExchangeDate = "";
                string UsdExchange = "";
                string BillNo = "";
                string Name = "";
                string ContactName = "";
                string CustomerId = "";
                string lsYearmonth = "";
                string id = "";


                string maxYearMonth = "";

                using (SqlCommand cmCus = db.CreateCommand(sql))
                {
                    SqlDataAdapter daCus = new SqlDataAdapter(cmCus);
                    daCus.Fill(dsCus);

                    if (dsCus != null)
                    {
                        string strDT = DateTime.Now.ToString("yyyyMMddHHmmss");

                        DataTable dtCus = dsCus.Tables[0];
                        foreach (DataRow rowCus in dtCus.Rows)
                        {
                            BillDate = rowCus[0].ToString();
                            UsdExchangeDate = rowCus[1].ToString();
                            UsdExchange = rowCus[2].ToString();
                            BillNo = rowCus[3].ToString();
                            Name = rowCus[4].ToString();
                            ContactName = rowCus[5].ToString();
                            CustomerId = rowCus[6].ToString();
                            lsYearmonth = rowCus[7].ToString();
                            id = rowCus[8].ToString();

                            string[] strTmpYearMonth = lsYearmonth.Split(',');

                            for (int l = 0; l < strTmpYearMonth.Length; l++)
                            {
                                string tmp = strTmpYearMonth[l];
                                if (maxYearMonth == "")
                                    maxYearMonth = tmp;
                                if (maxYearMonth.CompareTo(tmp) < 0)
                                    maxYearMonth = tmp;
                            }


                            C1XLBook xlbBook = new C1XLBook();
                            //ShowData(drpYear.SelectedValue + drpMonth.SelectedValue);
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
                            xlstStyle.Format = "#,##0.00_);(#,##0.00)";

                            XLStyle xlstStyleH = new XLStyle(xlbBook);
                            xlstStyleH.AlignHorz = XLAlignHorzEnum.Center;
                            xlstStyleH.AlignVert = XLAlignVertEnum.Center;
                            xlstStyleH.Font = new Font("", 8, FontStyle.Bold);
                            xlstStyleH.SetBorderColor(Color.Black);
                            xlstStyleH.BorderBottom = XLLineStyleEnum.Thin;
                            xlstStyleH.BorderTop = XLLineStyleEnum.Thin;
                            xlstStyleH.BorderLeft = XLLineStyleEnum.Thin;
                            xlstStyleH.BorderRight = XLLineStyleEnum.Thin;
                            xlstStyleH.WordWrap = true;

                            XLStyle xlstStyleSum = new XLStyle(xlbBook);
                            xlstStyleSum.AlignHorz = XLAlignHorzEnum.Right;
                            xlstStyleSum.AlignVert = XLAlignVertEnum.Center;
                            xlstStyleSum.Font = new Font("", 8, FontStyle.Bold);
                            xlstStyleSum.SetBorderColor(Color.Black);
                            xlstStyleSum.BorderBottom = XLLineStyleEnum.Thin;
                            xlstStyleSum.BorderTop = XLLineStyleEnum.Thin;
                            xlstStyleSum.BorderLeft = XLLineStyleEnum.Thin;
                            xlstStyleSum.BorderRight = XLLineStyleEnum.Thin;
                            xlstStyleSum.WordWrap = true;

                            string fileName = sFilePath + @"\Template\BillTongQuat.xlsx";
                            if (!Directory.Exists(sFilePath + @"\Building\" + sBuildingId + @"\Bill"))
                            {
                                Directory.CreateDirectory(sFilePath + @"\Report\Building\" + sBuildingId + @"\Bill");
                            }

                            string strFilePath = sFilePath + @"\Building\" + sBuildingId + @"\Bill\Bill" + "_" + CustomerId + "_" + BillNo + id + "_" + strDT + ".xlsx";
                            string strFilePathExport = sFilePath.Replace(@"\","/") + @"/Building/" + sBuildingId + @"/Bill/Bill" + "_" + CustomerId + "_" + BillNo + id + "_" + strDT + ".xlsx";

                            string fileNameDes = strFilePath;

                            //string fileNameDes = HttpContext.Current.Server.MapPath(@"~\Report\Building\" + sBuildingId + @"\TongHopDienTich" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
                            File.Copy(fileName, fileNameDes);

                            xlbBook.Load(fileNameDes);
                            XLSheet xlsSheet = xlbBook.Sheets["TongHop"];
                            XLSheet xlsSheetEn = xlbBook.Sheets["TongHop_En"];

                            //Thông tin về Ngân hàng của Tòa Nhà
                            xlsSheet[rOffice, cOffice].Value = xlsSheet[rOffice, cOffice].Value.ToString().Replace("{%VAN_PHONG%}", Office);
                            xlsSheet[rPhone, cPhone].Value = xlsSheet[rPhone, cPhone].Value.ToString().Replace("{%DIEN_THOAI%}", OfficePhone);

                            xlsSheet[rBank, cBank].Value = xlsSheet[rBank, cBank].Value.ToString().Replace("{%NGAN_HANG%}", Bank);
                            xlsSheet[rAccountName, cAccountName].Value = xlsSheet[rAccountName, cAccountName].Value.ToString().Replace("{%TEN_TAI_KHOAN%}", AccountName);
                            xlsSheet[rAccount, cAccount].Value = xlsSheet[rAccount, cAccount].Value.ToString().Replace("{%SO_TAI_KHOAN%}", Account);
                            //Thông tin về Ngân hàng của Tòa Nhà

                            //Customer
                            xlsSheet[rCustomer, cCustomer].Value = xlsSheet[rCustomer, cCustomer].Value.ToString().Replace("{%TEN_CONG_TY%}", Name);
                            //Contact
                            xlsSheet[rContact, cContact].Value = xlsSheet[rContact, cContact].Value.ToString().Replace("{%NGUOI_DAI_DIEN%}", ContactName);

                            //Bill No
                            xlsSheet[rBillNo, cBillNo].Value = xlsSheet[rBillNo, cBillNo].Value.ToString().Replace("{%BILL_NO%}", BillNo);

                            ///////////////////////////////////////////
                            //Thông tin về Ngân hàng của Tòa Nhà
                            xlsSheetEn[rOffice, cOffice].Value = xlsSheetEn[rOffice, cOffice].Value.ToString().Replace("{%VAN_PHONG%}", Office);
                            xlsSheetEn[rPhone, cPhone].Value = xlsSheetEn[rPhone, cPhone].Value.ToString().Replace("{%DIEN_THOAI%}", OfficePhone);

                            xlsSheetEn[rBank, cBank].Value = xlsSheetEn[rBank, cBank].Value.ToString().Replace("{%NGAN_HANG%}", Bank);
                            xlsSheetEn[rAccountName, cAccountName].Value = xlsSheetEn[rAccountName, cAccountName].Value.ToString().Replace("{%TEN_TAI_KHOAN%}", AccountName);
                            xlsSheetEn[rAccount, cAccount].Value = xlsSheetEn[rAccount, cAccount].Value.ToString().Replace("{%SO_TAI_KHOAN%}", Account);
                            //Thông tin về Ngân hàng của Tòa Nhà

                            //Customer
                            xlsSheetEn[rCustomer, cCustomer].Value = xlsSheetEn[rCustomer, cCustomer].Value.ToString().Replace("{%TEN_CONG_TY%}", Name);
                            //Contact
                            xlsSheetEn[rContact, cContact].Value = xlsSheetEn[rContact, cContact].Value.ToString().Replace("{%NGUOI_DAI_DIEN%}", ContactName);

                            //Bill No
                            xlsSheetEn[rBillNo, cBillNo].Value = xlsSheetEn[rBillNo, cBillNo].Value.ToString().Replace("{%BILL_NO%}", BillNo);
                            ///////////////////////////////////////////
                            //Ngay Thang Nam
                            DateTime dtime = DateTime.Today;

                            string strTmp = xlsSheet[rBillDate, cBillDate].Value.ToString().Replace("{%NGAY%}", dtime.ToString("dd"));
                            strTmp = strTmp.Replace("{%THANG%}", dtime.ToString("MM"));
                            xlsSheet[rBillDate, cBillDate].Value = strTmp.Replace("{%NAM%}", dtime.ToString("yyyy"));

                            strTmp = xlsSheetEn[rBillDate, cBillDate].Value.ToString().Replace("{%NGAY%}", dtime.ToString("dd"));
                            strTmp = strTmp.Replace("{%THANG%}", dtime.ToString("MM"));
                            xlsSheetEn[rBillDate, cBillDate].Value = strTmp.Replace("{%NAM%}", dtime.ToString("yyyy"));

                            //Nam
                            xlsSheet[rBillMonth, cBillMonth].Value = xlsSheet[rBillMonth, cBillMonth].Value.ToString().Replace("{%NAM_THANG%}", sMonth + "/" + sYear);
                            xlsSheetEn[rBillMonth, cBillMonth].Value = xlsSheetEn[rBillMonth, cBillMonth].Value.ToString().Replace("{%NAM_THANG%}", sMonth + "/" + sYear);

                            //Thông tin Tỉ giá
                            xlsSheet[rRate, cRate].Value = xlsSheet[rRate, cRate].Value.ToString().Replace("{%TI_GIA%}", UsdExchange);
                            xlsSheet[rRateDate, cRateDate].Value = xlsSheet[rRateDate, cRateDate].Value.ToString().Replace("{%NGAY_AP_DUNG%}", UsdExchangeDate);
                            //Thông tin Tỉ giá
                            xlsSheetEn[rRate, cRate].Value = xlsSheetEn[rRate, cRate].Value.ToString().Replace("{%TI_GIA%}", UsdExchange);
                            xlsSheetEn[rRateDate, cRateDate].Value = xlsSheetEn[rRateDate, cRateDate].Value.ToString().Replace("{%NGAY_AP_DUNG%}", UsdExchangeDate);

                            Hashtable contractIdLst = new Hashtable();
                            string contract = "";
                            ////

                            //Thue phong
                            ds = new DataSet();
                            sql = " Select A.*, B.ContractDate";
                            sql += " FROM PaymentRoom A, RentContract B";
                            sql += " WHERE A.ContractId = B.ContractId and A.BuildingId = B.BuildingId and A.BuildingId = '" + sBuildingId + "' and A.CustomerId = '" + CustomerId + "' and A.YearMonth in (" + lsYearmonth + ")";

                            int sumRow = 0;
                            int j = 0;
                            decimal[] LastSumPriceVND = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };
                            decimal[] LastSumPriceUSD = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };

                            decimal PaidPriceVND = 0;
                            decimal PaidPriceUSD = 0;

                            int line = 0;
                            using (SqlCommand cm = db.CreateCommand(sql))
                            {
                                SqlDataAdapter da = new SqlDataAdapter(cm);
                                da.Fill(ds);

                                line = rRent - 3 + j;

                                XLCellRange mCell = new XLCellRange(line, line + 2, 1, 3);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 4, 5);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 4, 5);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 2, line + 2, 4, 5);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                if (ds != null)
                                {
                                    int count = 0;
                                    DataTable dt = ds.Tables[0];
                                    int k = 0;
                                    foreach (DataRow rowType in dt.Rows)
                                    {
                                        decimal tmp01 = Convert.ToDecimal(rowType["LastRentSumUSD"]);
                                        decimal tmp02 = Convert.ToDecimal(rowType["LastRentSumVND"]);

                                        string ContractId = Func.ParseString(rowType["ContractId"]);
                                        string ContractNo = Func.ParseString(rowType["ContractNo"]);
                                        string YearMonth = Func.ParseString(rowType["YearMonth"]);
                                        string Area = Func.ParseString(rowType["Area"]);
                                        string Regional = Func.ParseString(rowType["Regional"]);
                                        string Floor = Func.ParseString(rowType["Floor"]);
                                        string BeginContract = Func.ParseString(rowType["ContractDate"]);

                                        if (!contractIdLst.ContainsKey(ContractId + "(" + Func.FormatDMY(BeginContract) + ")"))
                                        {
                                            contractIdLst.Add(ContractId + "(" + Func.FormatDMY(BeginContract) + ")", ContractNo + "(" + Func.FormatDMY(BeginContract) + ")");
                                            contract += ";" + ContractNo + "(" + Func.FormatDMY(BeginContract) + ")";
                                        }
                                        if (tmp01 > 0 || tmp02 > 0)
                                        {

                                            if (count >= 1)
                                            {
                                                xlsSheet.Rows.Insert(rRent + 1 + j);
                                                xlsSheetEn.Rows.Insert(rRent + 1 + j);
                                                j++;
                                            }
                                            count++;
                                            int tmp = rRent + j;
                                            xlsSheet[tmp, 1].Value = Name;
                                            xlsSheet[tmp, 4].Value = rowType["Area"];
                                            xlsSheet[tmp, 6].Value = rowType["MonthRentPriceUSD"];
                                            xlsSheet[tmp, 7].Value = rowType["MonthRentPriceVND"];

                                            xlsSheet[tmp, 8].Value = rowType["MonthRentSumUSD"];
                                            xlsSheet[tmp, 9].Value = rowType["MonthRentSumVND"];

                                            xlsSheet[tmp, 10].Value = rowType["VatRentPriceUSD"];
                                            xlsSheet[tmp, 11].Value = rowType["VatRentPriceVND"];

                                            xlsSheet[tmp, 12].Value = rowType["LastRentSumUSD"];
                                            xlsSheet[tmp, 13].Value = rowType["LastRentSumVND"];

                                            XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
                                            xlsSheet.MergedCells.Add(mrCell);

                                            mrCell = new XLCellRange(tmp, tmp, 4, 5);
                                            xlsSheet.MergedCells.Add(mrCell);


                                            ////EN
                                            xlsSheetEn[tmp, 1].Value = Name;
                                            xlsSheetEn[tmp, 4].Value = rowType["Area"];
                                            xlsSheetEn[tmp, 6].Value = rowType["MonthRentPriceUSD"];
                                            xlsSheetEn[tmp, 7].Value = rowType["MonthRentPriceVND"];

                                            xlsSheetEn[tmp, 8].Value = rowType["MonthRentSumUSD"];
                                            xlsSheetEn[tmp, 9].Value = rowType["MonthRentSumVND"];

                                            xlsSheetEn[tmp, 10].Value = rowType["VatRentPriceUSD"];
                                            xlsSheetEn[tmp, 11].Value = rowType["VatRentPriceVND"];

                                            xlsSheetEn[tmp, 12].Value = rowType["LastRentSumUSD"];
                                            xlsSheetEn[tmp, 13].Value = rowType["LastRentSumVND"];

                                            mrCell = new XLCellRange(tmp, tmp, 1, 3);
                                            xlsSheetEn.MergedCells.Add(mrCell);

                                            mrCell = new XLCellRange(tmp, tmp, 4, 5);
                                            xlsSheetEn.MergedCells.Add(mrCell);
                                            ////EN


                                            LastSumPriceVND[0] += Convert.ToDecimal(rowType["LastRentSumVND"]);
                                            LastSumPriceUSD[0] += Convert.ToDecimal(rowType["LastRentSumUSD"]);
                                        }
                                        else
                                        {
                                            k++;
                                        }
                                    }
                                    mCell = new XLCellRange(rRent + 1 + j, rRent + 1 + j, 1, 11);
                                    xlsSheet.MergedCells.Add(mCell);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    xlsSheet[rRent + 1 + j, 12].Value = LastSumPriceUSD[0];
                                    xlsSheet[rRent + 1 + j, 13].Value = LastSumPriceVND[0];

                                    xlsSheetEn[rRent + 1 + j, 12].Value = LastSumPriceUSD[0];
                                    xlsSheetEn[rRent + 1 + j, 13].Value = LastSumPriceVND[0];

                                    for (int row = rRent + sumRow; row <= rRent + dt.Rows.Count - k; row++)
                                    {
                                        for (int col = 1; col <= 13; col++)
                                        {
                                            xlsSheet[row, col].Style = xlstStyle;
                                            xlsSheetEn[row, col].Style = xlstStyle;
                                        }
                                    }
                                    sumRow += dt.Rows.Count - 1 - k;

                                    ////////////////////////
                                    for (int col = 1; col <= 13; col++)
                                    {
                                        xlsSheet[rRent + 1 + j, col].Style = xlstStyleSum;
                                        xlsSheetEn[rRent + 1 + j, col].Style = xlstStyleSum;
                                    }
                                    line = rManager - 3 + j;
                                    mCell = new XLCellRange(line, line + 2, 1, 3);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 4, 5);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 4, 5);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 2, line + 2, 4, 5);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 6, 7);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 8, 9);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 10, 11);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 12, 13);
                                    xlsSheet.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                                    xlsSheet.MergedCells.Add(mCell);

                                    ////En
                                    mCell = new XLCellRange(line, line + 2, 1, 3);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 4, 5);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 4, 5);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 2, line + 2, 4, 5);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 6, 7);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 8, 9);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 10, 11);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line, line, 12, 13);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                                    xlsSheetEn.MergedCells.Add(mCell);
                                    ////En
                                    k = 0;
                                    count = 0;
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        decimal tmp01 = Convert.ToDecimal(row["LastManagerSumUSD"]);
                                        decimal tmp02 = Convert.ToDecimal(row["LastManagerSumVND"]);

                                        if (tmp01 > 0 || tmp02 > 0)
                                        {

                                            if (count >= 1)
                                            {
                                                xlsSheet.Rows.Insert(rManager + 1 + j);
                                                xlsSheetEn.Rows.Insert(rManager + 1 + j);
                                                j++;
                                            }
                                            count++;
                                            int tmp = rManager + j;

                                            string YearMonth = Func.ParseString(row["YearMonth"]);
                                            string Area = Func.ParseString(row["Area"]);

                                            xlsSheet[tmp, 1].Value = Name;
                                            xlsSheet[tmp, 4].Value = row["Area"];
                                            xlsSheet[tmp, 6].Value = row["MonthManagerPriceUSD"];
                                            xlsSheet[tmp, 7].Value = row["MonthManagerPriceVND"];

                                            xlsSheet[tmp, 8].Value = row["MonthManagerSumUSD"];
                                            xlsSheet[tmp, 9].Value = row["MonthManagerSumVND"];

                                            xlsSheet[tmp, 10].Value = row["VatManagerPriceUSD"];
                                            xlsSheet[tmp, 11].Value = row["VatManagerPriceVND"];

                                            xlsSheet[tmp, 12].Value = row["LastManagerSumUSD"];
                                            xlsSheet[tmp, 13].Value = row["LastManagerSumVND"];

                                            XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
                                            xlsSheet.MergedCells.Add(mrCell);

                                            mrCell = new XLCellRange(tmp, tmp, 4, 5);
                                            xlsSheet.MergedCells.Add(mrCell);

                                            ////En
                                            xlsSheetEn[tmp, 1].Value = Name;
                                            xlsSheetEn[tmp, 4].Value = row["Area"];
                                            xlsSheetEn[tmp, 6].Value = row["MonthManagerPriceUSD"];
                                            xlsSheetEn[tmp, 7].Value = row["MonthManagerPriceVND"];

                                            xlsSheetEn[tmp, 8].Value = row["MonthManagerSumUSD"];
                                            xlsSheetEn[tmp, 9].Value = row["MonthManagerSumVND"];

                                            xlsSheetEn[tmp, 10].Value = row["VatManagerPriceUSD"];
                                            xlsSheetEn[tmp, 11].Value = row["VatManagerPriceVND"];

                                            xlsSheetEn[tmp, 12].Value = row["LastManagerSumUSD"];
                                            xlsSheetEn[tmp, 13].Value = row["LastManagerSumVND"];

                                            mrCell = new XLCellRange(tmp, tmp, 1, 3);
                                            xlsSheetEn.MergedCells.Add(mrCell);

                                            mrCell = new XLCellRange(tmp, tmp, 4, 5);
                                            xlsSheetEn.MergedCells.Add(mrCell);
                                            ////En
                                            LastSumPriceVND[1] += Convert.ToDecimal(row["LastManagerSumVND"]);
                                            LastSumPriceUSD[1] += Convert.ToDecimal(row["LastManagerSumUSD"]);
                                        }
                                        else { k++; }
                                    }
                                    mCell = new XLCellRange(rManager + 1 + j, rManager + 1 + j, 1, 11);
                                    xlsSheet.MergedCells.Add(mCell);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    xlsSheet[rManager + 1 + j, 12].Value = LastSumPriceUSD[1];
                                    xlsSheet[rManager + 1 + j, 13].Value = LastSumPriceVND[1];

                                    xlsSheetEn[rManager + 1 + j, 12].Value = LastSumPriceUSD[1];
                                    xlsSheetEn[rManager + 1 + j, 13].Value = LastSumPriceVND[1];

                                    for (int row = rManager + sumRow; row <= rManager + sumRow + dt.Rows.Count - k; row++)
                                    {
                                        for (int col = 1; col <= 13; col++)
                                        {
                                            xlsSheet[row, col].Style = xlstStyle;
                                            xlsSheetEn[row, col].Style = xlstStyle;
                                        }
                                    }

                                    for (int col = 1; col <= 13; col++)
                                    {
                                        xlsSheet[rManager + 1 + j, col].Style = xlstStyleSum;
                                        xlsSheetEn[rManager + 1 + j, col].Style = xlstStyleSum;
                                    }
                                    sumRow += dt.Rows.Count - 1 - k;
                                }
                            }

                            ds = new DataSet();
                            //Xuất ra toàn bộ nội dung theo Trang
                            sql = " SELECT COUNT(*) AS Num, YearMonth, TariffsParkingName, PriceVND, PriceUSD, SUM(VatVND) AS VatVND,SUM(VatUSD) AS VatUSD, SUM(SumVND) AS SumVND, SUM(SumUSD) AS SumUSD, SUM(LastPriceVND) AS LastPriceVND";
                            sql += "        , SUM(LastPriceUSD) AS LastPriceUSD";
                            sql += " FROM         dbo.PaymentParking";
                            sql += " WHERE BuildingId = '" + sBuildingId + "' and CustomerId = '" + CustomerId + "' and YearMonth in (" + lsYearmonth + ")";

                            sql += " GROUP BY YearMonth, TariffsParkingName, PriceVND, PriceUSD, Vat, daysParking";
                            sql += " HAVING (SUM(LastPriceVND) >0 or SUM(LastPriceUSD) >0)";
                            using (SqlCommand cm = db.CreateCommand(sql))
                            {
                                SqlDataAdapter da = new SqlDataAdapter(cm);
                                da.Fill(ds);

                                line = rParking - 3 + j;
                                XLCellRange mCell = new XLCellRange(line, line + 2, 1, 3);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 4, 5);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 4, 5);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 2, line + 2, 4, 5);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);

                                ////En
                                mCell = new XLCellRange(line, line + 2, 1, 3);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 4, 5);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 4, 5);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 2, line + 2, 4, 5);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 6, 7);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 8, 9);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 10, 11);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                                xlsSheetEn.MergedCells.Add(mCell);
                                ////En
                                if (ds != null)
                                {
                                    int count = 0;
                                    DataTable dt = ds.Tables[0];

                                    foreach (DataRow row in dt.Rows)
                                    {
                                        if (count >= 1)
                                        {
                                            xlsSheet.Rows.Insert(rParking + 1 + j);
                                            xlsSheetEn.Rows.Insert(rParking + 1 + j);
                                            j++;
                                        }
                                        count++;
                                        int tmp = rParking + j;

                                        string Num = Func.ParseString(row["Num"]);
                                        string TariffsParkingName = Func.ParseString(row["TariffsParkingName"]);

                                        xlsSheet[tmp, 1].Value = TariffsParkingName;
                                        xlsSheet[tmp, 4].Value = Num;
                                        xlsSheet[tmp, 6].Value = row["PriceUSD"];
                                        xlsSheet[tmp, 7].Value = row["PriceVND"];

                                        xlsSheet[tmp, 8].Value = row["SumUSD"];
                                        xlsSheet[tmp, 9].Value = row["SumVND"];

                                        xlsSheet[tmp, 10].Value = row["VatUSD"];
                                        xlsSheet[tmp, 11].Value = row["VatVND"];

                                        xlsSheet[tmp, 12].Value = row["LastPriceUSD"];
                                        xlsSheet[tmp, 13].Value = row["LastPriceVND"];

                                        XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
                                        xlsSheet.MergedCells.Add(mrCell);

                                        mrCell = new XLCellRange(tmp, tmp, 4, 5);
                                        xlsSheet.MergedCells.Add(mrCell);

                                        /////En
                                        xlsSheetEn[tmp, 1].Value = TariffsParkingName;
                                        xlsSheetEn[tmp, 4].Value = Num;
                                        xlsSheetEn[tmp, 6].Value = row["PriceUSD"];
                                        xlsSheetEn[tmp, 7].Value = row["PriceVND"];

                                        xlsSheetEn[tmp, 8].Value = row["SumUSD"];
                                        xlsSheetEn[tmp, 9].Value = row["SumVND"];

                                        xlsSheetEn[tmp, 10].Value = row["VatUSD"];
                                        xlsSheetEn[tmp, 11].Value = row["VatVND"];

                                        xlsSheetEn[tmp, 12].Value = row["LastPriceUSD"];
                                        xlsSheetEn[tmp, 13].Value = row["LastPriceVND"];

                                        mrCell = new XLCellRange(tmp, tmp, 1, 3);
                                        xlsSheetEn.MergedCells.Add(mrCell);

                                        mrCell = new XLCellRange(tmp, tmp, 4, 5);
                                        xlsSheetEn.MergedCells.Add(mrCell);
                                        /////En
                                        LastSumPriceVND[2] += Convert.ToDecimal(row["LastPriceVND"]);
                                        LastSumPriceUSD[2] += Convert.ToDecimal(row["LastPriceUSD"]);
                                    }
                                    xlsSheet[rParking + 1 + j, 12].Value = LastSumPriceUSD[2];
                                    xlsSheet[rParking + 1 + j, 13].Value = LastSumPriceVND[2];

                                    mCell = new XLCellRange(rParking + 1 + j, rParking + 1 + j, 1, 11);
                                    xlsSheet.MergedCells.Add(mCell);


                                    /////En
                                    xlsSheetEn[rParking + 1 + j, 12].Value = LastSumPriceUSD[2];
                                    xlsSheetEn[rParking + 1 + j, 13].Value = LastSumPriceVND[2];

                                    mCell = new XLCellRange(rParking + 1 + j, rParking + 1 + j, 1, 11);
                                    xlsSheetEn.MergedCells.Add(mCell);
                                    /////En

                                    for (int row = rParking + sumRow; row <= rParking + sumRow + dt.Rows.Count; row++)
                                    {
                                        for (int col = 1; col <= 13; col++)
                                        {
                                            xlsSheet[row, col].Style = xlstStyle;
                                            xlsSheetEn[row, col].Style = xlstStyle;
                                        }
                                    }

                                    for (int col = 1; col <= 13; col++)
                                    {
                                        xlsSheet[rParking + 1 + j, col].Style = xlstStyleSum;
                                        xlsSheetEn[rParking + 1 + j, col].Style = xlstStyleSum;
                                    }
                                    sumRow += dt.Rows.Count - 1;
                                }
                            }

                            ds = new DataSet();
                            sql = "SELECT id";
                            sql += " ,YearMonth,BuildingId,CustomerId,RoomId,ExtraHour,VAT,OtherFee01,OtherFee02";
                            sql += " ,PriceUSD,PriceVND,VatUSD,VatVND,SumUSD,SumVND,IsNull(LastPriceUSD,0) LastPriceUSD      ,IsNull(LastPriceVND,0) LastPriceVND ";
                            sql += " ,RentArea,dbo.fnDateTime(FromWD) BeginDate,dbo.fnDateTime(EndWD) EndDate,ExtratimeType";
                            sql += " FROM PaymentExtraTimeMonth";
                            sql += " WHERE BuildingId = '" + sBuildingId + "' and CustomerId = '" + CustomerId + "' and YearMonth in (" + lsYearmonth + ")";

                            using (SqlCommand cm = db.CreateCommand(sql))
                            {
                                SqlDataAdapter da = new SqlDataAdapter(cm);
                                da.Fill(ds);
                                line = rExtra - 3 + j;
                                //Phi dien
                                XLCellRange mCell = new XLCellRange(line, line + 2, 1, 3);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 4, 4);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);


                                /////En
                                mCell = new XLCellRange(line, line + 2, 1, 3);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 4, 4);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 6, 7);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 8, 9);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 10, 11);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                                xlsSheetEn.MergedCells.Add(mCell);
                                /////En
                                if (ds != null)
                                {
                                    int count = 0;
                                    DataTable dt = ds.Tables[0];

                                    foreach (DataRow row in dt.Rows)
                                    {
                                        if (count >= 1)
                                        {
                                            xlsSheet.Rows.Insert(rExtra + 1 + j);
                                            xlsSheetEn.Rows.Insert(rExtra + 1 + j);
                                            j++;
                                        }
                                        count++;
                                        int tmp = rExtra + j;

                                        string ExtraHour = Func.ParseString(row["ExtraHour"]);
                                        string BeginDate = Func.ParseString(row["BeginDate"]);
                                        string EndDate = Func.ParseString(row["EndDate"]);

                                        string ExtratimeType = Func.ParseString(row["ExtratimeType"]);

                                        xlsSheet[tmp, 1].Value = BeginDate + "~" + EndDate;
                                        xlsSheet[tmp, 5].Value = ExtraHour;

                                        xlsSheet[tmp, 4].Value = "Diện tích";
                                        if ("0".Equals(ExtratimeType))
                                        {
                                            xlsSheet[tmp, 4].Value = "m2*h";
                                        }
                                        xlsSheet[tmp, 6].Value = row["PriceUSD"];
                                        xlsSheet[tmp, 7].Value = row["PriceVND"];

                                        xlsSheet[tmp, 8].Value = row["SumUSD"];
                                        xlsSheet[tmp, 9].Value = row["SumVND"];

                                        xlsSheet[tmp, 10].Value = row["VatUSD"];
                                        xlsSheet[tmp, 11].Value = row["VatVND"];

                                        xlsSheet[tmp, 12].Value = row["LastPriceUSD"];
                                        xlsSheet[tmp, 13].Value = row["LastPriceVND"];

                                        LastSumPriceVND[3] += Convert.ToDecimal(row["LastPriceVND"]);
                                        LastSumPriceUSD[3] += Convert.ToDecimal(row["LastPriceUSD"]);

                                        XLCellRange mrCell = new XLCellRange(tmp, tmp, 1, 3);
                                        xlsSheet.MergedCells.Add(mrCell);
                                        //////En
                                        xlsSheetEn[tmp, 1].Value = BeginDate + "~" + EndDate;
                                        xlsSheetEn[tmp, 5].Value = ExtraHour;

                                        xlsSheetEn[tmp, 4].Value = "Di?n tích";
                                        if ("0".Equals(ExtratimeType))
                                        {
                                            xlsSheetEn[tmp, 4].Value = "m2*h";
                                        }
                                        xlsSheetEn[tmp, 6].Value = row["PriceUSD"];
                                        xlsSheetEn[tmp, 7].Value = row["PriceVND"];

                                        xlsSheetEn[tmp, 8].Value = row["SumUSD"];
                                        xlsSheetEn[tmp, 9].Value = row["SumVND"];

                                        xlsSheetEn[tmp, 10].Value = row["VatUSD"];
                                        xlsSheetEn[tmp, 11].Value = row["VatVND"];

                                        xlsSheetEn[tmp, 12].Value = row["LastPriceUSD"];
                                        xlsSheetEn[tmp, 13].Value = row["LastPriceVND"];

                                        //LastSumPriceVND[3] += Convert.ToDecimal(row["LastPriceVND"]);
                                        //LastSumPriceUSD[3] += Convert.ToDecimal(row["LastPriceUSD"]);

                                        mrCell = new XLCellRange(tmp, tmp, 1, 3);
                                        xlsSheetEn.MergedCells.Add(mrCell);
                                        //////En

                                        for (int col = 1; col <= 13; col++)
                                        {
                                            xlsSheet[tmp, col].Style = xlstStyle;
                                            xlsSheetEn[tmp, col].Style = xlstStyle;
                                        }

                                    }
                                    mCell = new XLCellRange(rExtra + 1 + j, rExtra + 1 + j, 1, 11);
                                    xlsSheet.MergedCells.Add(mCell);
                                    xlsSheetEn.MergedCells.Add(mCell);

                                    xlsSheet[rExtra + 1 + j, 12].Value = LastSumPriceUSD[3];
                                    xlsSheet[rExtra + 1 + j, 13].Value = LastSumPriceVND[3];

                                    xlsSheetEn[rExtra + 1 + j, 12].Value = LastSumPriceUSD[3];
                                    xlsSheetEn[rExtra + 1 + j, 13].Value = LastSumPriceVND[3];

                                    for (int row = rExtra + sumRow; row <= rExtra + sumRow + dt.Rows.Count; row++)
                                    {
                                        for (int col = 1; col <= 13; col++)
                                        {
                                            xlsSheet[row, col].Style = xlstStyle;
                                            xlsSheetEn[row, col].Style = xlstStyle;
                                        }
                                    }

                                    for (int col = 1; col <= 13; col++)
                                    {
                                        xlsSheet[rExtra + 1 + j, col].Style = xlstStyleSum;
                                        xlsSheetEn[rExtra + 1 + j, col].Style = xlstStyleSum;
                                    }
                                    sumRow += dt.Rows.Count - 1;
                                }
                            }

                            ds = new DataSet();
                            //Dien
                            //Xuất ra toàn bộ nội dung theo Trang
                            sql = " SELECT dbo.fnDateTime(A.DateFrom) DateFrom, dbo.fnDateTime(A.DateTo) DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVND, B.PriceUSD, B.SumVND, B.SumUSD, ";
                            sql += "        B.VatVND, B.VatUSD ,IsNull(B.LastPriceUSD,0) LastPriceUSD      ,IsNull(B.LastPriceVND,0) LastPriceVND , B.Name, B.WaterPricePercent,B.ElecPricePercent ";
                            sql += " FROM   PaymentElecWater AS A INNER JOIN ";
                            sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId";
                            sql += " WHERE A.BuildingId = '" + sBuildingId + "' and A.CustomerId = '" + CustomerId + "' and TarrifsOfWaterId = 0  and A.YearMonth in (" + lsYearmonth + ")";
                            sql += " Order by A.DateFrom, B.FromIndex";

                            using (SqlCommand cm = db.CreateCommand(sql))
                            {
                                SqlDataAdapter da = new SqlDataAdapter(cm);
                                da.Fill(ds);

                                line = rElec - 3 + j;
                                //Phi dien
                                XLCellRange mCell = new XLCellRange(line, line + 2, 1, 1);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 2, 2);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 3, 3);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 4, 4);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 5, 5);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 7, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 8, 8);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 9, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 10, 10);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 11, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);
                                /////En
                                mCell = new XLCellRange(line, line + 2, 1, 1);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 2, 2);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 3, 3);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 4, 4);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 5, 5);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 7, 7);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 8, 8);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 9, 9);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 10, 10);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 11, 11);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 12, 13);
                                xlsSheetEn.MergedCells.Add(mCell);
                                /////En

                                for (int col = 1; col < 13; col++)
                                {
                                    xlsSheet[line, col].Style = xlstStyleH;
                                    xlsSheet[line + 1, col].Style = xlstStyleH;
                                    xlsSheet[line + 2, col].Style = xlstStyleH;

                                    xlsSheetEn[line, col].Style = xlstStyleH;
                                    xlsSheetEn[line + 1, col].Style = xlstStyleH;
                                    xlsSheetEn[line + 2, col].Style = xlstStyleH;
                                }

                                if (ds != null)
                                {
                                    int count = 0;
                                    DataTable dt = ds.Tables[0];
                                    if (dt.Rows.Count > 0)
                                    {
                                        foreach (DataRow row in dt.Rows)
                                        {
                                            if (count >= 1)
                                            {
                                                xlsSheet.Rows.Insert(rElec + 1 + j);
                                                xlsSheetEn.Rows.Insert(rElec + 1 + j);
                                                j++;

                                            }
                                            count++;
                                            int tmp = rElec + j;

                                            string DateFrom = Func.ParseString(row["DateFrom"]);
                                            string DateTo = Func.ParseString(row["DateTo"]);

                                            string FromIndex = Func.ParseString(row["FromIndex"]);
                                            string ToIndex = Func.ParseString(row["ToIndex"]);
                                            string OtherFee01 = Func.ParseString(row["OtherFee01"]);
                                            string OtherFee02 = Func.ParseString(row["OtherFee02"]);
                                            string Mount = Func.ParseString(row["Mount"]);
                                            string ElecPricePercent = Func.ParseString(row["ElecPricePercent"]);

                                            xlsSheet[tmp, 1].Value = DateFrom;
                                            xlsSheet[tmp, 2].Value = DateTo;
                                            xlsSheet[tmp, 3].Value = FromIndex;
                                            xlsSheet[tmp, 4].Value = ToIndex;
                                            xlsSheet[tmp, 5].Value = OtherFee01;
                                            xlsSheet[tmp, 6].Value = Mount;
                                            xlsSheet[tmp, 7].Value = row["PriceVND"];
                                            xlsSheet[tmp, 8].Value = row["VatVND"];

                                            xlsSheet[tmp, 9].Value = row["SumVND"];
                                            xlsSheet[tmp, 10].Value = row["OtherFee02"];
                                            xlsSheet[tmp, 11].Value = row["ElecPricePercent"];
                                            xlsSheet[tmp, 12].Value = row["LastPriceVND"];

                                            mCell = new XLCellRange(tmp, tmp, 12, 13);
                                            xlsSheet.MergedCells.Add(mCell);


                                            /////En
                                            xlsSheetEn[tmp, 1].Value = DateFrom;
                                            xlsSheetEn[tmp, 2].Value = DateTo;
                                            xlsSheetEn[tmp, 3].Value = FromIndex;
                                            xlsSheetEn[tmp, 4].Value = ToIndex;
                                            xlsSheetEn[tmp, 5].Value = OtherFee01;
                                            xlsSheetEn[tmp, 6].Value = Mount;
                                            xlsSheetEn[tmp, 7].Value = row["PriceVND"];
                                            xlsSheetEn[tmp, 8].Value = row["VatVND"];

                                            xlsSheetEn[tmp, 9].Value = row["SumVND"];
                                            xlsSheetEn[tmp, 10].Value = row["OtherFee02"];
                                            xlsSheetEn[tmp, 11].Value = row["ElecPricePercent"];
                                            xlsSheetEn[tmp, 12].Value = row["LastPriceVND"];

                                            mCell = new XLCellRange(tmp, tmp, 12, 13);
                                            xlsSheetEn.MergedCells.Add(mCell);
                                            /////En
                                            for (int col = 1; col <= 12; col++)
                                            {
                                                xlsSheet[tmp, col].Style = xlstStyle;
                                                xlsSheetEn[tmp, col].Style = xlstStyle;
                                            }
                                            LastSumPriceVND[4] += Convert.ToDecimal(row["LastPriceVND"]);
                                            LastSumPriceUSD[4] += Convert.ToDecimal(row["LastPriceUSD"]);
                                        }
                                        xlsSheet[rElec + 1 + j, 12].Value = LastSumPriceVND[4];
                                        mCell = new XLCellRange(rElec + 1 + j, rElec + 1 + j, 1, 11);
                                        xlsSheet.MergedCells.Add(mCell);

                                        mCell = new XLCellRange(rElec + 1 + j, rElec + 1 + j, 12, 13);
                                        xlsSheet.MergedCells.Add(mCell);


                                        xlsSheetEn[rElec + 1 + j, 12].Value = LastSumPriceVND[4];
                                        mCell = new XLCellRange(rElec + 1 + j, rElec + 1 + j, 1, 11);
                                        xlsSheetEn.MergedCells.Add(mCell);

                                        mCell = new XLCellRange(rElec + 1 + j, rElec + 1 + j, 12, 13);
                                        xlsSheetEn.MergedCells.Add(mCell);

                                        for (int col = 1; col <= 13; col++)
                                        {
                                            xlsSheet[rElec + 1 + j, col].Style = xlstStyleSum;
                                            xlsSheetEn[rElec + 1 + j, col].Style = xlstStyleSum;
                                        }
                                        sumRow += dt.Rows.Count - 1;
                                    }
                                }
                            }

                            ds = new DataSet();
                            //Nuoc
                            //Xuất ra toàn bộ nội dung theo Trang
                            sql = " SELECT dbo.fnDateTime(A.DateFrom) DateFrom, dbo.fnDateTime(A.DateTo) DateTo, A.Vat, B.id, B.UsedElecWaterId, B.FromIndex, B.ToIndex, B.OtherFee01, B.OtherFee02, B.Mount, B.PriceVND, B.PriceUSD, B.SumVND, B.SumUSD, ";
                            sql += "        B.VatVND, B.VatUSD,IsNull(B.LastPriceUSD,0) LastPriceUSD,IsNull(B.LastPriceVND,0) LastPriceVND, B.Name, B.WaterPricePercent,B.ElecPricePercent  ";
                            sql += " FROM   PaymentElecWater AS A INNER JOIN ";
                            sql += "        PaymentElecWaterDetail AS B ON A.UsedElecWaterId = B.UsedElecWaterId";
                            sql += " WHERE A.BuildingId = '" + sBuildingId + "' and A.CustomerId = '" + CustomerId + "' and TarrifsOfElecId = 0 and A.YearMonth in (" + lsYearmonth + ")";
                            sql += " Order by A.DateFrom, B.FromIndex";

                            using (SqlCommand cm = db.CreateCommand(sql))
                            {
                                SqlDataAdapter da = new SqlDataAdapter(cm);
                                da.Fill(ds);
                                line = rWater - 3 + j;
                                //Phi dien
                                XLCellRange mCell = new XLCellRange(line, line + 2, 1, 1);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 2, 2);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 3, 3);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 4, 4);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 6, 6);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 7, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 8, 8);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 9, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 10, 10);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 11, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);


                                /////En
                                mCell = new XLCellRange(line, line + 2, 1, 1);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 2, 2);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 3, 3);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 4, 4);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 6, 6);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 7, 7);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 8, 8);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 9, 9);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 10, 10);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 11, 11);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 12, 13);
                                xlsSheetEn.MergedCells.Add(mCell);
                                /////En

                                for (int col = 1; col < 13; col++)
                                {
                                    xlsSheet[line, col].Style = xlstStyleH;
                                    xlsSheet[line + 1, col].Style = xlstStyleH;
                                    xlsSheet[line + 2, col].Style = xlstStyleH;

                                    xlsSheetEn[line, col].Style = xlstStyleH;
                                    xlsSheetEn[line + 1, col].Style = xlstStyleH;
                                    xlsSheetEn[line + 2, col].Style = xlstStyleH;
                                }

                                if (ds != null)
                                {
                                    int count = 0;
                                    DataTable dt = ds.Tables[0];
                                    if (dt.Rows.Count > 0)
                                    {
                                        foreach (DataRow row in dt.Rows)
                                        {
                                            if (count >= 1)
                                            {
                                                xlsSheet.Rows.Insert(rWater + 1 + j);
                                                xlsSheetEn.Rows.Insert(rWater + 1 + j);
                                                j++;
                                            }
                                            count++;
                                            int tmp = rWater + j;

                                            string DateFrom = Func.ParseString(row["DateFrom"]);
                                            string DateTo = Func.ParseString(row["DateTo"]);

                                            string FromIndex = Func.ParseString(row["FromIndex"]);
                                            string ToIndex = Func.ParseString(row["ToIndex"]);
                                            string OtherFee01 = Func.ParseString(row["OtherFee01"]);
                                            string OtherFee02 = Func.ParseString(row["OtherFee02"]);
                                            string Mount = Func.ParseString(row["Mount"]);

                                            xlsSheet[tmp, 1].Value = DateFrom;
                                            xlsSheet[tmp, 2].Value = DateTo;
                                            xlsSheet[tmp, 3].Value = FromIndex;
                                            xlsSheet[tmp, 4].Value = ToIndex;
                                            xlsSheet[tmp, 5].Value = Mount;
                                            xlsSheet[tmp, 6].Value = row["PriceVND"];
                                            xlsSheet[tmp, 7].Value = row["OtherFee01"];
                                            xlsSheet[tmp, 8].Value = row["VatVND"];

                                            xlsSheet[tmp, 9].Value = row["SumVND"];
                                            xlsSheet[tmp, 10].Value = row["OtherFee02"];
                                            xlsSheet[tmp, 11].Value = row["WaterPricePercent"];
                                            xlsSheet[tmp, 12].Value = row["LastPriceVND"];


                                            /////En
                                            xlsSheetEn[tmp, 1].Value = DateFrom;
                                            xlsSheetEn[tmp, 2].Value = DateTo;
                                            xlsSheetEn[tmp, 3].Value = FromIndex;
                                            xlsSheetEn[tmp, 4].Value = ToIndex;
                                            xlsSheetEn[tmp, 5].Value = Mount;
                                            xlsSheetEn[tmp, 6].Value = row["PriceVND"];
                                            xlsSheetEn[tmp, 7].Value = row["OtherFee01"];
                                            xlsSheetEn[tmp, 8].Value = row["VatVND"];

                                            xlsSheetEn[tmp, 9].Value = row["SumVND"];
                                            xlsSheetEn[tmp, 10].Value = row["OtherFee02"];
                                            xlsSheetEn[tmp, 11].Value = row["WaterPricePercent"];
                                            xlsSheetEn[tmp, 12].Value = row["LastPriceVND"];

                                            /////En
                                            for (int col = 1; col <= 12; col++)
                                            {
                                                xlsSheet[tmp, col].Style = xlstStyle;
                                                xlsSheetEn[tmp, col].Style = xlstStyle;
                                            }
                                            LastSumPriceVND[5] += Convert.ToDecimal(row["LastPriceVND"]);
                                            LastSumPriceUSD[5] += Convert.ToDecimal(row["LastPriceUSD"]);

                                            mCell = new XLCellRange(tmp, tmp, 12, 13);
                                            xlsSheet.MergedCells.Add(mCell);
                                            xlsSheetEn.MergedCells.Add(mCell);
                                        }
                                        xlsSheet[rWater + 1 + j, 12].Value = LastSumPriceVND[5];
                                        xlsSheetEn[rWater + 1 + j, 12].Value = LastSumPriceVND[5];
                                        mCell = new XLCellRange(rWater + 1 + j, rWater + 1 + j, 1, 11);
                                        xlsSheet.MergedCells.Add(mCell);
                                        xlsSheetEn.MergedCells.Add(mCell);

                                        mCell = new XLCellRange(rWater + 1 + j, rWater + 1 + j, 12, 13);
                                        xlsSheet.MergedCells.Add(mCell);
                                        xlsSheetEn.MergedCells.Add(mCell);

                                        for (int col = 1; col <= 13; col++)
                                        {
                                            xlsSheet[rWater + 1 + j, col].Style = xlstStyleSum;
                                            xlsSheetEn[rWater + 1 + j, col].Style = xlstStyleSum;
                                        }
                                        sumRow += dt.Rows.Count - 1;
                                    }
                                }
                            }

                            //Service
                            ds = new DataSet();

                            sql = string.Empty;
                            sql = " SELECT Service,dbo.fnDateTime(ServiceDateFrom) ServiceDateFrom,dbo.fnDateTime(ServiceDateTo) ServiceDateTo,PriceVND,PriceUSD,VatUSD,VatVND,Mount,Unit,SumVND,SumUSD,isnull(LastPriceVND,0) LastPriceVND,isnull(LastPriceUSD,0) LastPriceUSD";
                            sql += " FROM   PaymentService";
                            sql += " WHERE BuildingId = '" + sBuildingId + "' and CustomerId = '" + CustomerId + "' and YearMonth in (" + lsYearmonth + ")";
                            sql += " Order By ServiceDate ";

                            using (SqlCommand cm = db.CreateCommand(sql))
                            {
                                SqlDataAdapter da = new SqlDataAdapter(cm);
                                da.Fill(ds);
                                line = rService - 3 + j;
                                //Phi khác
                                XLCellRange mCell = new XLCellRange(line, line + 2, 1, 1);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 2, 2);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 3, 3);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 4, 4);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 5, 5);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                xlsSheet.MergedCells.Add(mCell);

                                /////En
                                mCell = new XLCellRange(line, line + 2, 1, 1);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 2, 2);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 3, 3);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line + 2, 4, 4);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 2, 5, 5);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 6, 7);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 6, 7);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 8, 9);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 8, 9);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line, line, 10, 11);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 10, 11);
                                xlsSheetEn.MergedCells.Add(mCell);
                                /////En
                                for (int col = 1; col < 13; col++)
                                {
                                    xlsSheet[line, col].Style = xlstStyleH;
                                    xlsSheet[line + 1, col].Style = xlstStyleH;
                                    xlsSheet[line + 2, col].Style = xlstStyleH;

                                    xlsSheetEn[line, col].Style = xlstStyleH;
                                    xlsSheetEn[line + 1, col].Style = xlstStyleH;
                                    xlsSheetEn[line + 2, col].Style = xlstStyleH;
                                }
                                mCell = new XLCellRange(line, line, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                mCell = new XLCellRange(line + 1, line + 1, 12, 13);
                                xlsSheet.MergedCells.Add(mCell);
                                xlsSheetEn.MergedCells.Add(mCell);

                                if (ds != null)
                                {
                                    int count = 0;
                                    DataTable dt = ds.Tables[0];

                                    if (dt.Rows.Count > 0)
                                    {

                                        foreach (DataRow row in dt.Rows)
                                        {
                                            if (count >= 1)
                                            {
                                                xlsSheet.Rows.Insert(rService + 1 + j);
                                                xlsSheetEn.Rows.Insert(rService + 1 + j);
                                                j++;
                                            }
                                            count++;
                                            int tmp = rService + j;



                                            string Service = Func.ParseString(row["Service"]);
                                            string ServiceDateFrom = Func.ParseString(row["ServiceDateFrom"]);
                                            string ServiceDateTo = Func.ParseString(row["ServiceDateTo"]);

                                            string Mount = Func.ParseString(row["Mount"]);

                                            xlsSheet[tmp, 1].Value = Service;
                                            xlsSheet[tmp, 2].Value = Func.ParseString(row["Unit"]);
                                            xlsSheet[tmp, 3].Value = ServiceDateFrom;
                                            xlsSheet[tmp, 4].Value = ServiceDateTo;
                                            xlsSheet[tmp, 5].Value = Mount;

                                            xlsSheet[tmp, 6].Value = row["PriceUSD"];
                                            xlsSheet[tmp, 7].Value = row["PriceVND"];

                                            xlsSheet[tmp, 8].Value = row["SumUSD"];
                                            xlsSheet[tmp, 9].Value = row["SumVND"];

                                            xlsSheet[tmp, 10].Value = row["VatUSD"];
                                            xlsSheet[tmp, 11].Value = row["VatVND"];

                                            xlsSheet[tmp, 12].Value = row["LastPriceUSD"];
                                            xlsSheet[tmp, 13].Value = row["LastPriceVND"];

                                            /////En
                                            xlsSheetEn[tmp, 1].Value = Service;
                                            xlsSheetEn[tmp, 2].Value = Func.ParseString(row["Unit"]);
                                            xlsSheetEn[tmp, 3].Value = ServiceDateFrom;
                                            xlsSheetEn[tmp, 4].Value = ServiceDateTo;
                                            xlsSheetEn[tmp, 5].Value = Mount;

                                            xlsSheetEn[tmp, 6].Value = row["PriceUSD"];
                                            xlsSheetEn[tmp, 7].Value = row["PriceVND"];

                                            xlsSheetEn[tmp, 8].Value = row["SumUSD"];
                                            xlsSheetEn[tmp, 9].Value = row["SumVND"];

                                            xlsSheetEn[tmp, 10].Value = row["VatUSD"];
                                            xlsSheetEn[tmp, 11].Value = row["VatVND"];

                                            xlsSheetEn[tmp, 12].Value = row["LastPriceUSD"];
                                            xlsSheetEn[tmp, 13].Value = row["LastPriceVND"];
                                            /////En

                                            for (int col = 1; col <= 13; col++)
                                            {
                                                xlsSheet[tmp, col].Style = xlstStyle;
                                                xlsSheetEn[tmp, col].Style = xlstStyle;
                                            }
                                            LastSumPriceVND[6] += Convert.ToDecimal(row["LastPriceVND"]);
                                            LastSumPriceUSD[6] += Convert.ToDecimal(row["LastPriceUSD"]);
                                        }
                                        xlsSheet[rService + 1 + j, 12].Value = LastSumPriceUSD[6];
                                        xlsSheet[rService + 1 + j, 13].Value = LastSumPriceVND[6];

                                        xlsSheetEn[rService + 1 + j, 12].Value = LastSumPriceUSD[6];
                                        xlsSheetEn[rService + 1 + j, 13].Value = LastSumPriceVND[6];

                                        mCell = new XLCellRange(rService + 1 + j, rService + 1 + j, 1, 11);
                                        xlsSheet.MergedCells.Add(mCell);
                                        xlsSheetEn.MergedCells.Add(mCell);

                                        for (int col = 1; col <= 13; col++)
                                        {
                                            xlsSheet[rService + 1 + j, col].Style = xlstStyleSum;
                                            xlsSheetEn[rService + 1 + j, col].Style = xlstStyleSum;
                                        }
                                        sumRow += dt.Rows.Count - 1;
                                    }
                                }
                            }

                            //Paid
                            sql = "Select  *";
                            sql += " From    PaymentBillDetail";
                            sql += " Where   BuildingId = '" + sBuildingId + "' and CustomerId = '" + CustomerId + "' and YearMonth in (" + lsYearmonth + ") and YearMonth < " + maxYearMonth + "";
                            string strYearMonth = "";
                            int lineTmp = rPaid - 2 + j;

                            //Paid
                            XLCellRange mCellTmp = new XLCellRange(lineTmp, lineTmp + 1, 1, 1);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 2, 3);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 4, 5);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 6, 7);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 8, 9);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 12, 13);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            /////En
                            mCellTmp = new XLCellRange(lineTmp, lineTmp + 1, 1, 1);
                            xlsSheetEn.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 2, 3);
                            xlsSheetEn.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 4, 5);
                            xlsSheetEn.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 6, 7);
                            xlsSheetEn.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 8, 9);
                            xlsSheetEn.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 12, 13);
                            xlsSheetEn.MergedCells.Add(mCellTmp);
                            /////En
                            Hashtable rowNo = new Hashtable();
                            decimal[] PaidSumVND = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };
                            decimal[] PaidSumUSD = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };

                            DataTable dtPaid = DbHelper.GetDataTable(sql);
                            for (int i = 0; i < dtPaid.Rows.Count; i++)
                            {
                                string PaymentType = Func.ParseString(dtPaid.Rows[i]["PaymentType"]);
                                string MoneyUSD = Func.ParseString(dtPaid.Rows[i]["MoneyUSD"]);
                                string MoneyVND = Func.ParseString(dtPaid.Rows[i]["MoneyVND"]);
                                string PaidUSD = Func.ParseString(dtPaid.Rows[i]["PaidUSD"]);
                                string PaidVND = Func.ParseString(dtPaid.Rows[i]["PaidVND"]);
                                string ExchangeType = Func.ParseString(dtPaid.Rows[i]["ExchangeType"]);
                                string YearMonth = Func.ParseString(dtPaid.Rows[i]["YearMonth"]);

                                if (!rowNo.Contains(YearMonth))
                                {
                                    if (rowNo.Count != 0)
                                    {
                                        xlsSheet.Rows.Insert(rPaid + j + 1);
                                        xlsSheetEn.Rows.Insert(rPaid + j + 1);
                                        j++;
                                    }
                                    rowNo.Add(YearMonth, j);
                                }
                                int m = Func.ParseInt(rowNo[YearMonth]);
                                strYearMonth = YearMonth;
                                decimal tmpUSD = Convert.ToDecimal(MoneyUSD) - Convert.ToDecimal(PaidUSD);
                                decimal tmpVND = Convert.ToDecimal(MoneyVND) - Convert.ToDecimal(PaidVND);

                                PaidPriceUSD += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                                PaidPriceVND += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);

                                xlsSheet[rPaid + m, 1].Value = YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4);
                                xlsSheetEn[rPaid + m, 1].Value = YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4);
                                switch (PaymentType)
                                {
                                    case "1":
                                        //Rent
                                        xlsSheet[rPaid + m, 2].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheet[rPaid + m, 3].Value = dtPaid.Rows[i]["PaidVND"];

                                        xlsSheetEn[rPaid + m, 2].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheetEn[rPaid + m, 3].Value = dtPaid.Rows[i]["PaidVND"];

                                        PaidSumUSD[0] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                                        PaidSumVND[0] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);

                                        break;
                                    case "2":
                                        //Manager
                                        xlsSheet[rPaid + m, 4].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheet[rPaid + m, 5].Value = dtPaid.Rows[i]["PaidVND"];

                                        xlsSheetEn[rPaid + m, 4].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheetEn[rPaid + m, 5].Value = dtPaid.Rows[i]["PaidVND"];

                                        PaidSumUSD[1] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                                        PaidSumVND[1] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);

                                        break;
                                    case "3":
                                        //Parking
                                        xlsSheet[rPaid + m, 6].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheet[rPaid + m, 7].Value = dtPaid.Rows[i]["PaidVND"];

                                        xlsSheetEn[rPaid + m, 6].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheetEn[rPaid + m, 7].Value = dtPaid.Rows[i]["PaidVND"];

                                        PaidSumUSD[2] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                                        PaidSumVND[2] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
                                        break;
                                    case "4":
                                        //Extra
                                        xlsSheet[rPaid + m, 8].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheet[rPaid + m, 9].Value = dtPaid.Rows[i]["PaidVND"];

                                        xlsSheetEn[rPaid + m, 8].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheetEn[rPaid + m, 9].Value = dtPaid.Rows[i]["PaidVND"];

                                        PaidSumUSD[3] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                                        PaidSumVND[3] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
                                        break;
                                    case "5":
                                        xlsSheet[rPaid + m, 10].Value = dtPaid.Rows[i]["PaidVND"];
                                        xlsSheetEn[rPaid + m, 10].Value = dtPaid.Rows[i]["PaidVND"];

                                        PaidSumUSD[4] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                                        PaidSumVND[4] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
                                        break;
                                    case "6":
                                        xlsSheet[rPaid + m, 11].Value = dtPaid.Rows[i]["PaidVND"];
                                        xlsSheetEn[rPaid + m, 11].Value = dtPaid.Rows[i]["PaidVND"];

                                        PaidSumUSD[5] += Convert.ToDecimal(dtPaid.Rows[i]["PaidUSD"]);
                                        PaidSumVND[5] += Convert.ToDecimal(dtPaid.Rows[i]["PaidVND"]);
                                        break;
                                    case "7":
                                        xlsSheet[rPaid + m, 12].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheet[rPaid + m, 13].Value = dtPaid.Rows[i]["PaidVND"];

                                        xlsSheetEn[rPaid + m, 12].Value = dtPaid.Rows[i]["PaidUSD"];
                                        xlsSheetEn[rPaid + m, 13].Value = dtPaid.Rows[i]["PaidVND"];
                                        break;
                                    default:
                                        break;
                                }
                                for (int row = rPaid + m; row <= rPaid + 1 + j; row++)
                                {
                                    for (int col = 1; col <= 13; col++)
                                    {
                                        xlsSheet[row, col].Style = xlstStyle;
                                    }
                                }
                            }
                            lineTmp = rPaid - 2 + j;

                            xlsSheet[lineTmp + 3, 2].Value = PaidSumUSD[0];
                            xlsSheet[lineTmp + 3, 3].Value = PaidSumVND[0];
                            xlsSheet[lineTmp + 3, 4].Value = PaidSumUSD[1];
                            xlsSheet[lineTmp + 3, 5].Value = PaidSumVND[1];
                            xlsSheet[lineTmp + 3, 6].Value = PaidSumUSD[2];
                            xlsSheet[lineTmp + 3, 7].Value = PaidSumVND[2];
                            xlsSheet[lineTmp + 3, 8].Value = PaidSumUSD[3];
                            xlsSheet[lineTmp + 3, 9].Value = PaidSumVND[3];
                            xlsSheet[lineTmp + 3, 10].Value = PaidSumVND[4];
                            xlsSheet[lineTmp + 3, 11].Value = PaidSumVND[5];
                            xlsSheet[lineTmp + 3, 12].Value = PaidSumUSD[6];
                            xlsSheet[lineTmp + 3, 13].Value = PaidSumVND[6];

                            /////En
                            xlsSheetEn[lineTmp + 3, 2].Value = PaidSumUSD[0];
                            xlsSheetEn[lineTmp + 3, 3].Value = PaidSumVND[0];
                            xlsSheetEn[lineTmp + 3, 4].Value = PaidSumUSD[1];
                            xlsSheetEn[lineTmp + 3, 5].Value = PaidSumVND[1];
                            xlsSheetEn[lineTmp + 3, 6].Value = PaidSumUSD[2];
                            xlsSheetEn[lineTmp + 3, 7].Value = PaidSumVND[2];
                            xlsSheetEn[lineTmp + 3, 8].Value = PaidSumUSD[3];
                            xlsSheetEn[lineTmp + 3, 9].Value = PaidSumVND[3];
                            xlsSheetEn[lineTmp + 3, 10].Value = PaidSumVND[4];
                            xlsSheetEn[lineTmp + 3, 11].Value = PaidSumVND[5];
                            xlsSheetEn[lineTmp + 3, 12].Value = PaidSumUSD[6];
                            xlsSheetEn[lineTmp + 3, 13].Value = PaidSumVND[6];
                            /////En

                            for (int col = 1; col <= 13; col++)
                            {
                                xlsSheet[lineTmp + 3, col].Style = xlstStyleSum;
                                xlsSheetEn[lineTmp + 3, col].Style = xlstStyleSum;
                            }

                            ///////////////DEPT
                            sql = "  Select *";
                            sql += " From   v_DeptBill";
                            sql += " Where  BuildingId = '" + sBuildingId + "' and CustomerId = '" + CustomerId + "' and YearMonth not in (" + lsYearmonth + ") and YearMonth < " + maxYearMonth + "";
                            sql += " And    (DeptUsd <> 0 or DeptVnd <> 0)";
                            strYearMonth = "";
                            lineTmp = rDept - 2 + j;

                            //Paid
                            mCellTmp = new XLCellRange(lineTmp, lineTmp + 1, 1, 1);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 2, 3);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 4, 5);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 6, 7);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 8, 9);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 12, 13);
                            xlsSheet.MergedCells.Add(mCellTmp);

                            //////En
                            mCellTmp = new XLCellRange(lineTmp, lineTmp + 1, 1, 1);
                            xlsSheetEn.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 2, 3);
                            xlsSheetEn.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 4, 5);
                            xlsSheetEn.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 6, 7);
                            xlsSheetEn.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 8, 9);
                            xlsSheetEn.MergedCells.Add(mCellTmp);

                            mCellTmp = new XLCellRange(lineTmp, lineTmp, 12, 13);
                            xlsSheetEn.MergedCells.Add(mCellTmp);
                            //////En
                            rowNo = new Hashtable();
                            decimal DeptPriceVND = 0;
                            decimal DeptPriceUSD = 0;

                            decimal[] DeptSumVND = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };
                            decimal[] DeptSumUSD = new decimal[7] { 0, 0, 0, 0, 0, 0, 0 };


                            DataTable dtDept = DbHelper.GetDataTable(sql);
                            for (int i = 0; i < dtDept.Rows.Count; i++)
                            {
                                string PaymentType = Func.ParseString(dtDept.Rows[i]["PaymentType"]);
                                string DeptUSD = Func.ParseString(dtDept.Rows[i]["DeptUSD"]);
                                string DeptVND = Func.ParseString(dtDept.Rows[i]["DeptVND"]);
                                string YearMonth = Func.ParseString(dtDept.Rows[i]["YearMonth"]);

                                if (!rowNo.Contains(YearMonth))
                                {
                                    if (rowNo.Count != 0)
                                    {
                                        xlsSheet.Rows.Insert(rDept + j + 1);
                                        xlsSheetEn.Rows.Insert(rDept + j + 1);
                                        j++;
                                    }
                                    rowNo.Add(YearMonth, j);
                                }
                                int m = Func.ParseInt(rowNo[YearMonth]);
                                strYearMonth = YearMonth;

                                DeptPriceUSD += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                                DeptPriceVND += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);

                                xlsSheet[rDept + m, 1].Value = YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4);
                                xlsSheetEn[rDept + m, 1].Value = YearMonth.Substring(4, 2) + "/" + YearMonth.Substring(0, 4);

                                switch (PaymentType)
                                {
                                    case "1":
                                        //Rent
                                        xlsSheet[rDept + m, 2].Value = dtDept.Rows[i]["DeptUSD"];
                                        xlsSheet[rDept + m, 3].Value = dtDept.Rows[i]["DeptVND"];

                                        xlsSheetEn[rDept + m, 2].Value = dtDept.Rows[i]["DeptUSD"];
                                        xlsSheetEn[rDept + m, 3].Value = dtDept.Rows[i]["DeptVND"];

                                        DeptSumUSD[0] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                                        DeptSumVND[0] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);

                                        break;
                                    case "2":
                                        //Manager
                                        xlsSheet[rDept + m, 4].Value = dtDept.Rows[i]["DeptUSD"];
                                        xlsSheet[rDept + m, 5].Value = dtDept.Rows[i]["DeptVND"];

                                        xlsSheetEn[rDept + m, 4].Value = dtDept.Rows[i]["DeptUSD"];
                                        xlsSheetEn[rDept + m, 5].Value = dtDept.Rows[i]["DeptVND"];

                                        DeptSumUSD[1] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                                        DeptSumVND[1] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);

                                        break;
                                    case "3":
                                        //Parking
                                        xlsSheet[rDept + m, 6].Value = dtDept.Rows[i]["DeptUSD"];
                                        xlsSheet[rDept + m, 7].Value = dtDept.Rows[i]["DeptVND"];

                                        xlsSheetEn[rDept + m, 6].Value = dtDept.Rows[i]["DeptUSD"];
                                        xlsSheetEn[rDept + m, 7].Value = dtDept.Rows[i]["DeptVND"];

                                        DeptSumUSD[2] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                                        DeptSumVND[2] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
                                        break;
                                    case "4":
                                        //Extra
                                        xlsSheet[rDept + m, 8].Value = dtDept.Rows[i]["DeptUSD"];
                                        xlsSheet[rDept + m, 9].Value = dtDept.Rows[i]["DeptVND"];

                                        xlsSheetEn[rDept + m, 8].Value = dtDept.Rows[i]["DeptUSD"];
                                        xlsSheetEn[rDept + m, 9].Value = dtDept.Rows[i]["DeptVND"];

                                        DeptSumUSD[3] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                                        DeptSumVND[3] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
                                        break;
                                    case "5":
                                        xlsSheet[rDept + m, 10].Value = dtDept.Rows[i]["DeptVND"];
                                        xlsSheetEn[rDept + m, 10].Value = dtDept.Rows[i]["DeptVND"];

                                        DeptSumUSD[4] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                                        DeptSumVND[4] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
                                        break;
                                    case "6":
                                        xlsSheet[rDept + m, 11].Value = dtDept.Rows[i]["DeptVND"];
                                        xlsSheetEn[rDept + m, 11].Value = dtDept.Rows[i]["DeptVND"];

                                        DeptSumUSD[5] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                                        DeptSumVND[5] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
                                        break;
                                    case "7":
                                        xlsSheet[rDept + m, 12].Value = dtDept.Rows[i]["DeptUSD"];
                                        xlsSheet[rDept + m, 13].Value = dtDept.Rows[i]["DeptVND"];

                                        xlsSheetEn[rDept + m, 12].Value = dtDept.Rows[i]["DeptUSD"];
                                        xlsSheetEn[rDept + m, 13].Value = dtDept.Rows[i]["DeptVND"];

                                        DeptSumUSD[6] += Convert.ToDecimal(dtDept.Rows[i]["DeptUSD"]);
                                        DeptSumVND[6] += Convert.ToDecimal(dtDept.Rows[i]["DeptVND"]);
                                        break;
                                    default:
                                        break;
                                }
                                for (int row = rDept + m; row <= rDept + 1 + j; row++)
                                {
                                    for (int col = 1; col <= 13; col++)
                                    {
                                        xlsSheet[row, col].Style = xlstStyle;
                                        xlsSheetEn[row, col].Style = xlstStyle;
                                    }
                                }
                            }
                            lineTmp = rDept - 2 + j;

                            xlsSheet[lineTmp + 3, 2].Value = DeptSumUSD[0];
                            xlsSheet[lineTmp + 3, 3].Value = DeptSumVND[0];
                            xlsSheet[lineTmp + 3, 4].Value = DeptSumUSD[1];
                            xlsSheet[lineTmp + 3, 5].Value = DeptSumVND[1];
                            xlsSheet[lineTmp + 3, 6].Value = DeptSumUSD[2];
                            xlsSheet[lineTmp + 3, 7].Value = DeptSumVND[2];
                            xlsSheet[lineTmp + 3, 8].Value = DeptSumUSD[3];
                            xlsSheet[lineTmp + 3, 9].Value = DeptSumVND[3];
                            xlsSheet[lineTmp + 3, 10].Value = DeptSumVND[4];
                            xlsSheet[lineTmp + 3, 11].Value = DeptSumVND[5];
                            xlsSheet[lineTmp + 3, 12].Value = DeptSumUSD[6];
                            xlsSheet[lineTmp + 3, 13].Value = DeptSumVND[6];


                            //////En
                            xlsSheetEn[lineTmp + 3, 2].Value = DeptSumUSD[0];
                            xlsSheetEn[lineTmp + 3, 3].Value = DeptSumVND[0];
                            xlsSheetEn[lineTmp + 3, 4].Value = DeptSumUSD[1];
                            xlsSheetEn[lineTmp + 3, 5].Value = DeptSumVND[1];
                            xlsSheetEn[lineTmp + 3, 6].Value = DeptSumUSD[2];
                            xlsSheetEn[lineTmp + 3, 7].Value = DeptSumVND[2];
                            xlsSheetEn[lineTmp + 3, 8].Value = DeptSumUSD[3];
                            xlsSheetEn[lineTmp + 3, 9].Value = DeptSumVND[3];
                            xlsSheetEn[lineTmp + 3, 10].Value = DeptSumVND[4];
                            xlsSheetEn[lineTmp + 3, 11].Value = DeptSumVND[5];
                            xlsSheetEn[lineTmp + 3, 12].Value = DeptSumUSD[6];
                            xlsSheetEn[lineTmp + 3, 13].Value = DeptSumVND[6];
                            //////En
                            for (int col = 1; col <= 13; col++)
                            {
                                xlsSheet[lineTmp + 3, col].Style = xlstStyleSum;
                                xlsSheetEn[lineTmp + 3, col].Style = xlstStyleSum;
                            }

                            xlsSheet[lineTmp + 3, 1].Style = xlstStyleSum;
                            xlsSheetEn[lineTmp + 3, 1].Style = xlstStyleSum;

                            decimal AllSumVND = 0;
                            decimal AllSumUSD = 0;
                            for (int i = 0; i < 7; i++)
                            {
                                AllSumVND += LastSumPriceVND[i];
                                AllSumUSD += LastSumPriceUSD[i];
                            }

                            AllSumVND -= PaidPriceVND;
                            AllSumUSD -= PaidPriceUSD;

                            AllSumVND += DeptPriceVND;
                            AllSumUSD += DeptPriceUSD;

                            xlsSheet[rSumVND + j, cSumVND].Value = Func.FormatNumber_New(AllSumUSD);
                            xlsSheet[rSumVND + j, cSumVND].Value += "(USD)";
                            xlsSheet[rSumVND + j, cSumVND + 1].Value = Func.FormatNumber_New(AllSumVND);
                            xlsSheet[rSumVND + j, cSumVND + 1].Value += "(VND)";

                            xlsSheetEn[rSumVND + j, cSumVND].Value = Func.FormatNumber_New(AllSumUSD);
                            xlsSheetEn[rSumVND + j, cSumVND].Value += "(USD)";
                            xlsSheetEn[rSumVND + j, cSumVND + 1].Value = Func.FormatNumber_New(AllSumVND);
                            xlsSheetEn[rSumVND + j, cSumVND + 1].Value += "(VND)";

                            AllSumVND += Convert.ToDecimal(AllSumUSD * Convert.ToDecimal(UsdExchange));

                            string strMoney = Func.docso(Convert.ToInt32(AllSumVND));
                            string strMoneyEn = Func.DocSo_En(Convert.ToInt32(AllSumVND));

                            xlsSheet[rContract, cContract].Value = xlsSheet[rContract, cContract].Value.ToString().Replace("{%HOP_DONG%}", String.IsNullOrEmpty(contract) ? "" : contract.Substring(1));
                            xlsSheet[rSum + j, cSum].Value = Convert.ToInt32(AllSumVND);

                            mCellTmp = new XLCellRange(rSum + j, rSum + j, cSum, cSum + 1);
                            xlsSheet.MergedCells.Add(mCellTmp);
                            xlsSheet[rSum + j, cSum].Style = xlstStyleSum;
                            xlsSheet[rSum + j, cSum + 1].Style = xlstStyleSum;
                            xlsSheet[rSumRead + j, cSumRead].Value = xlsSheet[rSumRead + j, cSumRead].Value.ToString().Replace("{%TONG_CHU%}", strMoney.ToUpper());


                            xlsSheetEn[rContract, cContract].Value = xlsSheetEn[rContract, cContract].Value.ToString().Replace("{%HOP_DONG%}", String.IsNullOrEmpty(contract) ? "" : contract.Substring(1));
                            xlsSheetEn[rSum + j, cSum].Value = Convert.ToInt32(AllSumVND);

                            mCellTmp = new XLCellRange(rSum + j, rSum + j, cSum, cSum + 1);
                            xlsSheetEn.MergedCells.Add(mCellTmp);
                            xlsSheetEn[rSum + j, cSum].Style = xlstStyleSum;
                            xlsSheetEn[rSum + j, cSum + 1].Style = xlstStyleSum;
                            xlsSheetEn[rSumRead + j, cSumRead].Value = xlsSheetEn[rSumRead + j, cSumRead].Value.ToString().Replace("{%TONG_CHU%}", strMoneyEn.ToUpper());

                            xlbBook.Save(fileNameDes);
                            xlbBook.Clear();
                            //ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + strFilePathExport + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);
                        }
                    }
                }
            }
        }
    }
}
