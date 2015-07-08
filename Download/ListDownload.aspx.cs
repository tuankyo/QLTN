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
using System.Text;
using System.IO;
using BusinessObjects;
using Gnt.Transaction;
using Gnt.Utils.CSV;

namespace Man.Download
{
    public partial class ListDownload : PageBase
    {
        public string[,] resultSync = new string[20, 3];
        private string selMonth = string.Empty ; 
        private string chargeFlag = string.Empty; 
        private int[]  goukei = new int[31] ;

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

        /// <summary>
        /// Set where clause for search options
        /// </summary>
        private string GetWhere()
        {
            string whereClause = string.Empty;
            if (!drpSiteType.SelectedValue.Equals(""))
            {
                whereClause = " TypeId = '" + drpSiteType.SelectedValue + "' ";
            }
            else
            {
                whereClause = " TypeId IN ('1','2','3', '5') ";
            }
            if (!drpSite.SelectedValue.Equals(""))
            {
                whereClause += " AND Id = '"+drpSite.SelectedValue+"' ";
            }
            return whereClause;
        }

        /// <summary>
        /// List data
        /// </summary>
        private void ShowData()
        {
            SqlDatabase db = new SqlDatabase();
            string whereString = GetWhere();
            string sql = string.Empty;

            if (!Func.IsValid(ListSortExpression))
            {
                ListSortExpression = "Modified";
                ListSortDirection = SortDirection.Descending;
            }
            try
            {
                sql += " SELECT Id, Name " +
                      " FROM Site " +
                      " WHERE " + whereString + " AND ID <> 0 " +
                      " ORDER BY Id ";
                     
                SqlCommand cm = db.CreateCommand(sql);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataSet ds = new DataSet();
                da.Fill(ds);
                db.Close();
                rptList.DataSource = ds.Tables[0].DefaultView;
                rptList.DataBind();
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
            string sql = String.Empty;
            int currMonth = DateTime.Now.Month;
            StringBuilder sb = new StringBuilder();
            string whereString = string.Empty;
            if (drpSiteType.SelectedValue.Equals(""))
            {
                whereString = " AND TypeId IN ('1','2','3','5') ";
            }
            else
            {
                whereString = " AND TypeId = '" + drpSiteType.SelectedValue + "' ";
            }
            DbHelper.FillList(drpSite, "SELECT Id, Name FROM Site WHERE DelFlag=0 " + whereString +" ORDER BY Id ", "Name", "Id" );
            drpSite.Items.Add(new ListItem("全て", ""));
            Func.SortByValue(drpSite);
            drpSite.Items[0].Selected = true;
            int tmp = currMonth - 1;
            drpMonth.Items[tmp].Selected = true;
            selMonth = currMonth.ToString();

            for (int i = 0; i < goukei.Length; i++)
            {
                goukei[i] = 0;
            }
        }

        protected override void DoPost()
        {
            //Handle postback from popup
            string eventTarget = Func.ParseString(Request["__EVENTTARGET"]);
            string eventArgument = Func.ParseString(Request["__EVENTARGUMENT"]);
            if (eventTarget.StartsWith("PopUp"))
            {
                if (eventTarget == "PopUpEditArtist")
                {
                    ShowData();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                ShowData();
            }
        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string command = e.CommandName;
            string colName = string.Empty;
            if (command.StartsWith("Sort"))
            {
                if (string.Compare(command, "SortId") == 0)
                {
                    colName = "ArtistId";
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
                ShowData();
            }
           
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            try
            {
                if (selMonth.Equals(""))
                {
                    selMonth = DateTime.Now.ToString("MM");
                }
                string currentMonth = DateTime.Now.ToString("yyyy") + selMonth ;
                int currentDay = Func.ParseInt(DateTime.Now.ToString("dd"));
                if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
                {
                    DataRowView rowsite = (DataRowView)item.DataItem;
                    string siteId = Func.ParseString(rowsite["Id"]);
                    string siteName = Func.ParseString(rowsite["Name"]);

                    Func.SetGridTextValue(item, "ltrSiteId", siteName);
                    string whereString = string.Empty;
                    if (!drpChargeFlag.SelectedValue.Equals(""))
                    {
                        whereString = " AND ChargeFlag = '" + chargeFlag + "'";
                    }
                    string sql = "SELECT SUBSTRING(DownloadDate,7,2) AS Day, COUNT(*) AS NumDownload " +
                                " FROM Download " +
                                " WHERE SiteId = '" + siteId + "' AND DownloadMonth ='" + currentMonth + "'" + whereString +
                                " GROUP BY SUBSTRING(DownloadDate,7,2) " +
                                " ORDER BY SUBSTRING(DownloadDate,7,2) ";

                    DataTable dt = DbHelper.GetMstrData(sql).Tables[0];              

                    Hashtable tmpDay = new Hashtable();

                    foreach (DataRow row in dt.Rows)
                    {
                        tmpDay.Add(Func.ParseInt(row["Day"].ToString()),row["NumDownload"].ToString());
                    }
                    
                    string currentDate = string.Empty;
                    string link = string.Empty;
                    string tmpDate = DateTime.Now.ToString("yyyyMM");
                    for (int i = 1; i <= 31; i++)
                    {
                        currentDate = currentMonth + i.ToString().PadLeft(2, '0');
                        if (tmpDay.ContainsKey(i))
                        {
                            if (currentMonth.Equals(tmpDate))
                            {
                                link = "<a href=../batch/CollectDownload.aspx?action=do&stdt=" + currentDate + "&eddt=" + currentDate + "&siteId=" + siteId + " target='_blank'>" + Func.FormatNumber(tmpDay[i].ToString()) + "</a>";
                                Func.SetGridTextValue(item, "ltr" + i, link);
                            }
                            else
                            {
                                Func.SetGridTextValue(item, "ltr" + i, Func.FormatNumber(tmpDay[i].ToString()));
                            }
                            goukei[i - 1] += Func.ParseInt(tmpDay[i]);
                        }
                        else
                        {
                            if (currentMonth.Equals(tmpDate))
                            {
                                link = "<a href=../batch/CollectDownload.aspx?action=do&stdt=" + currentDate + "&eddt=" + currentDate + "&siteId=" + siteId + " target='_blank'><font color='red'>0</font></a>";
                                Func.SetGridTextValue(item, "ltr" + i, link);
                                HtmlTableCell header = (HtmlTableCell)item.FindControl("header" + i.ToString());
                                header.BgColor = "yellow";
                            }
                            else
                            {
                                Func.SetGridTextValue(item, "ltr" + i, "0");
                            }
                        }
                    }
                }
                else if (item.ItemType == ListItemType.Header)
                {               
                    string currentDate = string.Empty;
                    string day = string.Empty;
                    string tmpDate = DateTime.Now.ToString("yyyyMM");
                    if (currentMonth.Equals(tmpDate))
                    {
                        for (int i = 1; i <= 31; i++)
                        {
                            day = i.ToString().PadLeft(2, '0');
                            currentDate = currentMonth + day;
                            LinkButton link = (LinkButton)item.FindControl("lnkMonth" + i.ToString());
                            link.Text = "<a href=../batch/CollectDownload.aspx?action=do&stdt=" + currentDate + "&eddt=" + currentDate + " target='_blank'>" + day + "</a>"; ;
                        }
                    }
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
                    }
                }
                else if (item.ItemType == ListItemType.Footer)
                {
                    for (int i = 1; i <= 31; i++)
                    {
                        Func.SetGridTextValue(item, "ltrsum" + i, Func.FormatNumber(goukei[i-1].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }

        /// <summary>
        /// 曲メディアグリッドのデータを設定する処理
        /// </summary>
        protected void Detail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;

            if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
            {
                DataRowView row = (DataRowView)item.DataItem;

                Func.SetGridTextValue(item, "ltrSite", Func.ParseString(row["Name"]));
                Func.SetGridTextValue(item, "ltrSendResult", Func.ParseString(row["SendResult"]));
                Func.SetGridTextValue(item, "ltrPrevSynchronizer", Func.ParseString(row["PrevSynchronizer"]));
                Func.SetGridTextValue(item, "ltrPrevSynchDated", Func.Formatdmyhms(row["PrevSynchDated"]));
                Func.SetGridTextValue(item, "ltrLastSynchronizer", Func.ParseString(row["LastSynchronizer"]));
                Func.SetGridTextValue(item, "ltrLastSynchDated", Func.Formatdmyhms(row["LastSynchDated"]));
            }
        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            if (!drpChargeFlag.SelectedValue.Equals(""))
            {
                chargeFlag = drpChargeFlag.SelectedValue;
            }
            if (!drpMonth.SelectedValue.Equals("")) 
            {
                selMonth = drpMonth.SelectedValue;
            }
            ShowData();
        }

        public void drpSiteTypeChanged(object sender, EventArgs e)
        {
            string whereString = string.Empty;
            if (drpSiteType.SelectedValue.Equals(""))
            {
                whereString = " AND TypeId IN ('1','2','3') ";
            }
            else
            {
                whereString = " AND TypeId = '" + drpSiteType.SelectedValue + "' ";
            }
            DbHelper.FillList(drpSite, "SELECT Id, Name FROM Site WHERE DelFlag=0 " + whereString , "Name", "Id");
            drpSite.Items.Add(new ListItem("全て", ""));
            Func.SortByValue(drpSite);
            drpSite.Items[0].Selected = true;
        }   
    }
}
