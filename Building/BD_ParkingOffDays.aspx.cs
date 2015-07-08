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

using Gnt.Data;
using Man.Utils;
using Gnt.Data.DBCommand;
using System.Data.SqlClient;
using BusinessObjects;
using Gnt.Transaction;
using System.Text;
using C1.C1Excel;
using System.Drawing;
using System.IO;

namespace Man.Building
{
    public partial class BD_ParkingOffDays : PageBase
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

        private string popup = "PopupBillInfo";
        private string addSuccess = "Đã lưu thông tin thành công";
        private string addUnSuccess = "Lưu thông tin không thành công";


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
                }
            }
        }
        protected void btnSelectYM_Click(object sender, EventArgs e)
        {
            ShowData();
        }
        private void ShowData()
        {
            lstSelectedYearMonth.Items.Clear();
            lstYearMonth.Items.Clear();

            Hashtable days = new Hashtable();
            days.Add("Sunday", "CN");
            days.Add("Monday", "T2");
            days.Add("Tuesday", "T3");
            days.Add("Wednesday", "T4");
            days.Add("Thursday", "T5");
            days.Add("Friday", "T6");
            days.Add("Saturday", "T7");

            Hashtable offDaysList = new Hashtable();
            DataSet ds = new DataSet();
            string sql = " SELECT OffDay";
            sql += " FROM BD_ParkingOffDays";
            sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' And YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "' and delFlag = 0";
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
                            string OffDay = rowType["OffDay"].ToString();
                            if (!offDaysList.ContainsKey(OffDay))
                            {
                                offDaysList.Add(OffDay, OffDay);
                                DateTime tmp = new DateTime(Func.ParseInt(OffDay.Substring(0, 4)), Func.ParseInt(OffDay.Substring(4, 2)), Func.ParseInt(OffDay.Substring(6, 2)));
                                string dayTmp = (Func.ParseString(days[Func.ParseString(tmp.DayOfWeek)]) != "" ? Func.ParseString(days[Func.ParseString(tmp.DayOfWeek)]) : tmp.DayOfWeek + "");
                                lstSelectedYearMonth.Items.Add(new ListItem(dayTmp + tmp.ToString("(dd/MM/yyyy)"), tmp.ToString("yyyyMMdd")));
                            }
                        }
                    }
                }
            }

            DateTime firstDate = new DateTime(Func.ParseInt(drpYear.SelectedValue), Func.ParseInt(drpMonth.SelectedValue), 1);
            string tempDate = Func.ParseString(days[Func.ParseString(firstDate.DayOfWeek)]);
            if (!offDaysList.ContainsKey(firstDate.ToString("yyyyMMdd")))
            {
                lstYearMonth.Items.Add(new ListItem((tempDate != "" ? tempDate : firstDate.DayOfWeek + "") + firstDate.ToString("(dd/MM/yyyy)"), firstDate.ToString("yyyyMMdd")));
                if (tempDate == "CN")
                    lstYearMonth.Items[lstYearMonth.Items.Count - 1].Attributes.Add("style", "color:Red");
                else if (tempDate == "T7")
                    lstYearMonth.Items[lstYearMonth.Items.Count - 1].Attributes.Add("style", "color:blue");
            }

            for (int i = 1; i < 31; i++)
            {
                DateTime tmp = firstDate.AddDays(i);
                if (!offDaysList.ContainsKey(tmp.ToString("yyyyMMdd")))
                {
                    if (tmp.Month == Func.ParseInt(drpMonth.SelectedValue))
                    {
                        string dayTmp = (Func.ParseString(days[Func.ParseString(tmp.DayOfWeek)]) != "" ? Func.ParseString(days[Func.ParseString(tmp.DayOfWeek)]) : tmp.DayOfWeek + "");
                        lstYearMonth.Items.Add(new ListItem(dayTmp + tmp.ToString("(dd/MM/yyyy)"), tmp.ToString("yyyyMMdd")));
                        if (dayTmp == "CN")
                            lstYearMonth.Items[lstYearMonth.Items.Count - 1].Attributes.Add("style", "color:Red");
                        else if (dayTmp == "T7")
                            lstYearMonth.Items[lstYearMonth.Items.Count - 1].Attributes.Add("style", "color:Blue");
                    }
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PopupWidth = 600;
                PopupHeight = 450;

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

                ShowData();
            }
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            ArrayList rmList = new ArrayList();
            using (SqlConnection rConn = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
            {
                rConn.Open();
                foreach (ListItem lstItem in lstYearMonth.Items)
                {

                    if (lstItem.Selected)
                    {
                        lstSelectedYearMonth.Items.Add(lstItem);
                        rmList.Add(lstItem);

                        BD_ParkingOffDaysData data = new BD_ParkingOffDaysData();
                        ITransaction tran = factory.GetInsertObject(data);
                        data.YearMonth = drpYear.SelectedValue + drpMonth.SelectedValue;
                        data.ModifiedBy = Page.User.Identity.Name;
                        data.CreatedBy = Page.User.Identity.Name;
                        data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                        data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                        data.DelFlag = "0";
                        data.OffDay = lstItem.Value;

                        data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);

                        Execute(tran);

                        if (!HasError)
                        {
                            OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                            mvMessage.SetCompleteMessage(addSuccess);
                        }
                        else
                        {
                            OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                            mvMessage.AddError(addUnSuccess);
                        }
                    }
                }
                rConn.Close();
            }
            //for (int i = 0; i < rmList.Count; i++)
            //{
            //    lstYearMonth.Items.Remove((ListItem)rmList[i]);
            //}
            ShowData();

        }
        protected void btnUnSelect_Click(object sender, EventArgs e)
        {
            ArrayList rmList = new ArrayList();
            foreach (ListItem lstItem in lstSelectedYearMonth.Items)
            {
                if (lstItem.Selected)
                {
                    lstYearMonth.Items.Add(lstItem);
                    rmList.Add(lstItem);

                    string id = DbHelper.GetScalar("Select Id from BD_ParkingOffDays Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "' and OffDay = '" + lstItem.Value + "' and delflag = 0");
                    BD_ParkingOffDaysData data = new BD_ParkingOffDaysData();
                    ITransaction tran = factory.GetLoadObject(data, id);
                    Execute(tran);
                    if (!HasError)
                    {
                        //Get Data
                        data = (BD_ParkingOffDaysData)tran.Result;
                        data.DelFlag = "1";

                        data.ModifiedBy = Page.User.Identity.Name;
                        data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");

                        tran = factory.GetUpdateObject(data);

                        Execute(tran);

                        if (!HasError)
                        {
                        }
                        else
                        {
                        }
                    }
                }
            }
            //for (int i = 0; i < rmList.Count; i++)
            //{
            //    lstSelectedYearMonth.Items.Remove((ListItem)rmList[i]);
            //}
            ShowData();
        }

        protected void btnT7_Click(object sender, EventArgs e)
        {
            Hashtable days = new Hashtable();
            days.Add("Sunday", "CN");
            days.Add("Monday", "T2");
            days.Add("Tuesday", "T3");
            days.Add("Wednesday", "T4");
            days.Add("Thursday", "T5");
            days.Add("Friday", "T6");
            days.Add("Saturday", "T7");

            Hashtable offDaysList = new Hashtable();
            DataSet ds = new DataSet();
            string sql = " SELECT OffDay";
            sql += " FROM BD_ParkingOffDays";
            sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' And YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "' and delFlag = 0";
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
                            string OffDay = rowType["OffDay"].ToString();
                            if (!offDaysList.ContainsKey(OffDay))
                            {
                                offDaysList.Add(OffDay, OffDay);
                            }
                        }
                    }
                }
            }

            DateTime firstDate = new DateTime(Func.ParseInt(drpYear.SelectedValue), Func.ParseInt(drpMonth.SelectedValue), 1);
            string tempDate = Func.ParseString(days[Func.ParseString(firstDate.DayOfWeek)]);
            if (tempDate == "T7" && !offDaysList.ContainsKey(firstDate.ToString("yyyyMMdd")))
            {
                BD_ParkingOffDaysData data = new BD_ParkingOffDaysData();
                ITransaction tran = factory.GetInsertObject(data);
                data.YearMonth = drpYear.SelectedValue + drpMonth.SelectedValue;
                data.ModifiedBy = Page.User.Identity.Name;
                data.CreatedBy = Page.User.Identity.Name;
                data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag = "0";
                data.OffDay = firstDate.ToString("yyyyMMdd");

                data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(addSuccess);
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(addUnSuccess);
                }
            }

            for (int i = 1; i < 31; i++)
            {
                DateTime tmp = firstDate.AddDays(i);
                if (!offDaysList.ContainsKey(tmp.ToString("yyyyMMdd")))
                {
                    if (tmp.Month == Func.ParseInt(drpMonth.SelectedValue))
                    {
                        string dayTmp = (Func.ParseString(days[Func.ParseString(tmp.DayOfWeek)]) != "" ? Func.ParseString(days[Func.ParseString(tmp.DayOfWeek)]) : tmp.DayOfWeek + "");
                        if (dayTmp == "T7")
                        {
                            BD_ParkingOffDaysData data = new BD_ParkingOffDaysData();
                            ITransaction tran = factory.GetInsertObject(data);
                            data.YearMonth = drpYear.SelectedValue + drpMonth.SelectedValue;
                            data.ModifiedBy = Page.User.Identity.Name;
                            data.CreatedBy = Page.User.Identity.Name;
                            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                            data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                            data.DelFlag = "0";
                            data.OffDay = tmp.ToString("yyyyMMdd");

                            data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);

                            Execute(tran);

                            if (!HasError)
                            {
                                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                                mvMessage.SetCompleteMessage(addSuccess);
                            }
                            else
                            {
                                OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                                mvMessage.AddError(addUnSuccess);
                            }
                        }
                    }
                }
            }

            ShowData();
        }
        protected void btnCN_Click(object sender, EventArgs e)
        {
            Hashtable days = new Hashtable();
            days.Add("Sunday", "CN");
            days.Add("Monday", "T2");
            days.Add("Tuesday", "T3");
            days.Add("Wednesday", "T4");
            days.Add("Thursday", "T5");
            days.Add("Friday", "T6");
            days.Add("Saturday", "T7");

            Hashtable offDaysList = new Hashtable();
            DataSet ds = new DataSet();
            string sql = " SELECT OffDay";
            sql += " FROM BD_ParkingOffDays";
            sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' And YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "' and delFlag = 0";
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
                            string OffDay = rowType["OffDay"].ToString();
                            if (!offDaysList.ContainsKey(OffDay))
                            {
                                offDaysList.Add(OffDay, OffDay);
                            }
                        }
                    }
                }
            }

            DateTime firstDate = new DateTime(Func.ParseInt(drpYear.SelectedValue), Func.ParseInt(drpMonth.SelectedValue), 1);
            string tempDate = Func.ParseString(days[Func.ParseString(firstDate.DayOfWeek)]);
            if (tempDate == "CN" && !offDaysList.ContainsKey(firstDate.ToString("yyyyMMdd")))
            {
                BD_ParkingOffDaysData data = new BD_ParkingOffDaysData();
                ITransaction tran = factory.GetInsertObject(data);
                data.YearMonth = drpYear.SelectedValue + drpMonth.SelectedValue;
                data.ModifiedBy = Page.User.Identity.Name;
                data.CreatedBy = Page.User.Identity.Name;
                data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag = "0";
                data.OffDay = firstDate.ToString("yyyyMMdd");

                data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(addSuccess);
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(addUnSuccess);
                }
            }

            for (int i = 1; i < 31; i++)
            {
                DateTime tmp = firstDate.AddDays(i);
                if (!offDaysList.ContainsKey(tmp.ToString("yyyyMMdd")))
                {
                    if (tmp.Month == Func.ParseInt(drpMonth.SelectedValue))
                    {
                        string dayTmp = (Func.ParseString(days[Func.ParseString(tmp.DayOfWeek)]) != "" ? Func.ParseString(days[Func.ParseString(tmp.DayOfWeek)]) : tmp.DayOfWeek + "");
                        if (dayTmp == "CN")
                        {
                            BD_ParkingOffDaysData data = new BD_ParkingOffDaysData();
                            ITransaction tran = factory.GetInsertObject(data);
                            data.YearMonth = drpYear.SelectedValue + drpMonth.SelectedValue;
                            data.ModifiedBy = Page.User.Identity.Name;
                            data.CreatedBy = Page.User.Identity.Name;
                            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                            data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                            data.DelFlag = "0";
                            data.OffDay = tmp.ToString("yyyyMMdd");

                            data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);

                            Execute(tran);

                            if (!HasError)
                            {
                                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                                mvMessage.SetCompleteMessage(addSuccess);
                            }
                            else
                            {
                                OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                                mvMessage.AddError(addUnSuccess);
                            }
                        }
                    }
                }
            }

            ShowData();
        }
        protected void btnLE_Click(object sender, EventArgs e)
        {
            Hashtable days = new Hashtable();
            days.Add("Sunday", "CN");
            days.Add("Monday", "T2");
            days.Add("Tuesday", "T3");
            days.Add("Wednesday", "T4");
            days.Add("Thursday", "T5");
            days.Add("Friday", "T6");
            days.Add("Saturday", "T7");

            Hashtable HolidaysList = new Hashtable();
            HolidaysList.Add("0430", "0430");
            HolidaysList.Add("0501", "0501");
            HolidaysList.Add("0902", "0902");
            HolidaysList.Add("0101", "0101");

            Hashtable offDaysList = new Hashtable();
            DataSet ds = new DataSet();
            string sql = " SELECT OffDay";
            sql += " FROM BD_ParkingOffDays";
            sql += " WHERE BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' And YearMonth = '" + drpYear.SelectedValue + drpMonth.SelectedValue + "' and delFlag = 0";
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
                            string OffDay = rowType["OffDay"].ToString();
                            if (!offDaysList.ContainsKey(OffDay))
                            {
                                offDaysList.Add(OffDay, OffDay);
                            }
                        }
                    }
                }
            }

            DateTime firstDate = new DateTime(Func.ParseInt(drpYear.SelectedValue), Func.ParseInt(drpMonth.SelectedValue), 1);
            string tempDate = Func.ParseString(days[Func.ParseString(firstDate.DayOfWeek)]);
            if (HolidaysList.ContainsKey(firstDate.ToString("MMdd")) && !offDaysList.ContainsKey(firstDate.ToString("yyyyMMdd")))
            {
                BD_ParkingOffDaysData data = new BD_ParkingOffDaysData();
                ITransaction tran = factory.GetInsertObject(data);
                data.YearMonth = drpYear.SelectedValue + drpMonth.SelectedValue;
                data.ModifiedBy = Page.User.Identity.Name;
                data.CreatedBy = Page.User.Identity.Name;
                data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                data.DelFlag = "0";
                data.OffDay = firstDate.ToString("yyyyMMdd");

                data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(addSuccess);
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(addUnSuccess);
                }
            }

            for (int i = 1; i < 31; i++)
            {
                DateTime tmp = firstDate.AddDays(i);
                if (!offDaysList.ContainsKey(tmp.ToString("yyyyMMdd")))
                {
                    if (tmp.Month == Func.ParseInt(drpMonth.SelectedValue))
                    {
                        string dayTmp = (Func.ParseString(days[Func.ParseString(tmp.DayOfWeek)]) != "" ? Func.ParseString(days[Func.ParseString(tmp.DayOfWeek)]) : tmp.DayOfWeek + "");
                        if (HolidaysList.ContainsKey(tmp.ToString("MMdd")))
                        {
                            BD_ParkingOffDaysData data = new BD_ParkingOffDaysData();
                            ITransaction tran = factory.GetInsertObject(data);
                            data.YearMonth = drpYear.SelectedValue + drpMonth.SelectedValue;
                            data.ModifiedBy = Page.User.Identity.Name;
                            data.CreatedBy = Page.User.Identity.Name;
                            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                            data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                            data.DelFlag = "0";
                            data.OffDay = tmp.ToString("yyyyMMdd");

                            data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);

                            Execute(tran);

                            if (!HasError)
                            {
                                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                                mvMessage.SetCompleteMessage(addSuccess);
                            }
                            else
                            {
                                OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                                mvMessage.AddError(addUnSuccess);
                            }
                        }
                    }
                }
            }

            ShowData();
        }
    }
}
