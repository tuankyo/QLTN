using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using Gnt.Data;
using Gnt.Transaction;
using Man.Utils;
using System.Data.SqlClient;
using BusinessObjects;
using Gnt.Data.DBCommand;

namespace Man.ImportMaster
{
    public partial class ListRbtDownloadImportAu : PageBase
    {
        private string importType = "1";
        private string CarrierId = "2";

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

        private void ShowData()
        {
            PopupWidth = 850;
            PopupName = "ListSyncSong";

            SqlDatabase db = new SqlDatabase();
            string sql = string.Empty;
            if (!Func.IsValid(ListSortExpression))
            {
                ListSortExpression = "DownloadDate";
                ListSortDirection = SortDirection.Descending;
            }
            try
            {
                //件数を数える
                sql += " SELECT COUNT(*) ";
                sql += " FROM RbtDownloadImportAuTmp ";
                sql += " WHERE SessionId = '" + Session.SessionID + "'";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //検索条件で取得情報のSQL文を作成する
                sql = " SELECT *,ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum  FROM RbtDownloadImportAuTmp ";
                sql += " WHERE SessionId = '" + Session.SessionID + "'";

                //ページによるレコーダを取得する


                sql = " SELECT *,RowNum FROM (" + sql + ") AS TMP ";
                sql += " WHERE RowNum BETWEEN @PageIndex*@PageSize + 1  AND (@PageIndex+1)*@PageSize ORDER BY TMP.RowNum ";

                //SQL文を実行する
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

        protected override void DoInit()
        {
            divUpdate.Visible = true;
            btnRegister.OnClientClick = "return confirm('登録します。よろしいですか？');";
            txtPayMonth.Text = DateTime.Now.AddMonths(-1).ToString("yyyyMM");
            try
            {

            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }

        protected override void DoGet()
        {
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        protected override void DoPost()
        {
            //Handle postback from popup
            string eventTarget = Func.ParseString(Request["__EVENTTARGET"]);
            string eventArgument = Func.ParseString(Request["__EVENTARGUMENT"]);
            if (eventTarget.StartsWith("PopUpSong"))
            {
                ShowData();
            }
        }

        protected void pager_PageIndexChanged(object source, PagerPageChangedEventArgs args)
        {
            ShowData();
        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string command = e.CommandName;
            string colName = string.Empty;
            string id = Func.ParseString(e.CommandArgument);
            
        }

        /// <summary>
        /// メイングリッドのデータを設定する処理
        /// </summary>
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

                    string DownloadDate = Func.FormatDate(row["DownloadDate"], "yyyy/MM/dd HH:mm:ss");
                    Func.SetGridTextValue(item, "ltrDownloadDate", DownloadDate);
                    Func.SetGridTextValue(item, "ltrServiceSupportCode", Func.ParseString(row["ServiceSupportCode"]));
                    Func.SetGridTextValue(item, "ltrServiceSupportName", Func.ParseString(row["ServiceSupportName"]));
                    Func.SetGridTextValue(item, "ltrServiceCode", Func.ParseString(row["ServiceCode"]));
                    Func.SetGridTextValue(item, "ltrServiceName", Func.ParseString(row["ServiceName"]));
                    Func.SetGridTextValue(item, "ltrChargeType", Func.ParseString(row["ChargeType"]));
                    Func.SetGridTextValue(item, "ltrPrice", Func.ParseString(row["Price"]));
                    Func.SetGridTextValue(item, "ltrSiteCode", Func.ParseString(row["SiteCode"]));
                    Func.SetGridTextValue(item, "ltrSiteName", Func.ParseString(row["SiteName"]));
                    Func.SetGridTextValue(item, "ltrUserId", Func.ParseString(row["UserId"]));
                    Func.SetGridTextValue(item, "ltrContentCode", Func.ParseString(row["ContentCode"]));
                    Func.SetGridTextValue(item, "ltrTerminalFlag", Func.ParseString(row["TerminalFlag"]));
                    Func.SetGridTextValue(item, "ltrBeginMonth", Func.ParseString(row["BeginMonth"]));
                }
                else if (item.ItemType == ListItemType.Header)
                {
                    PopupHeight = 800;
                    PopupName = "EditSongMain";
                    string colName = ListSortExpression;
                    if (Func.IsValid(colName))
                    {
                        string img = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string payMonth = string.Empty;
            string licenseHouse = string.Empty;
            //string songHeader = string.Empty;

            //mvldMessage.CheckRequired(drpSongHeader, "曲IDの先頭を選択してください。");
            mvldMessage.CheckRequired(txtPayMonth, "実績年月を入力してください。");

            if (!mvldMessage.IsValid) return;

            //songHeader = drpSongHeader.SelectedValue;
            payMonth = txtPayMonth.Text.Trim();
            payMonth = payMonth.Replace("年", "");
            payMonth = payMonth.Replace("月", "");

            if ((payMonth.Length != 6) || (int.Parse(payMonth.Substring(4, 2)) > 12))
            {
                mvldMessage.AddError("実績年月を正しく入力してください。");
                return;
            }
            if (!payMonth.Equals(DateTime.Now.AddMonths(-1).ToString("yyyyMM")))
            {
                mvldMessage.AddError("現在、先月のみ実行できます");
                return;
            }
            try
            {
                string updator = Page.User.Identity.Name;
                string creator = Page.User.Identity.Name;
                string created = DateTime.Now.ToString("yyyyMMddHHmmss");
                string updated = DateTime.Now.ToString("yyyyMMddHHmmss");

                ArrayList sqlInsert = new ArrayList();

                DataTable dt = null;
                string sql = string.Empty;
                StringBuilder sb = new StringBuilder();
                try
                {
                    sql = " SELECT * FROM RbtDownloadImportAuTmp WHERE SessionId = '" + Session.SessionID + "' ";
                    dt = DbHelper.GetDataTable(sql);
                }
                catch (Exception ex)
                {
                    ApplicationLog.WriteError(ex);
                }
                
                string carrierId = "2";  //Au

                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        int iBeginMonth = Func.ParseInt(row["BeginMonth"].ToString());
                        string downloadDate = string.Empty;
                        string serviceCode = Func.ParseString(row["ServiceCode"]);
                        string sql_siteid = "SELECT Id FROM Site WHERE ServiceCode = '" + serviceCode + "'";
                        string siteId = DbHelper.GetScalar(sql_siteid);
                        string userId = "";// Func.ParseString(row["UserId"]);
                        //string songMediaId = songHeader + Func.ParseString(row["ContentCode"]).PadLeft(5,'0') + "A";
                        string songMediaId = DbHelper.GetScalar("Select SongMediaId From SongMedia Where AuId = '" + Func.ParseString(row["ContentCode"]).PadLeft(5, '0') + "'");
                        // QDo start 101129
                        downloadDate = Func.ParseString(row["DownloadDate"].ToString());
                        sql = " INSERT INTO Download ( SiteId, CarrierId, DownloadDate, DownloadType, UserId, CarrierModel, SongMediaId, ChargeFlag, DownloadCid, Updated, ProductId, DownloadMonth)" +
                              " VALUES ( '" + siteId + "', '" + carrierId + "', '" + downloadDate + "', 1, '" + userId + "', '', '" + songMediaId + "',1, '', CONVERT(VARCHAR, CURRENT_TIMESTAMP, 112) + REPLACE(CONVERT(VARCHAR, CURRENT_TIMESTAMP, 108),':',''),'', '" + payMonth + "');";
                        sqlInsert.Add(sql);
                        // QDo end 101129
                       //if(iBeginMonth == 1)
                       //{
                       //    downloadDate = Func.ParseString(row["DownloadDate"].ToString().Substring(0, 8)) + "010000";
                       //     sql = " INSERT INTO Download ( SiteId, CarrierId, DownloadDate, DownloadType, UserId, CarrierModel, SongMediaId, ChargeFlag, DownloadCid, Updated, ProductId, DownloadMonth)" +
                       //           " VALUES ( '" + siteId + "', '" + carrierId + "', '" + downloadDate + "', 1, '" + userId + "', '', '" + songMediaId + "',1, '', CONVERT(VARCHAR, CURRENT_TIMESTAMP, 112) + REPLACE(CONVERT(VARCHAR, CURRENT_TIMESTAMP, 108),':',''),'', '" + payMonth + "');";
                       //     sqlInsert.Add(sql);
                       //}
                       //else if (iBeginMonth == 2)
                       //{
                       //    downloadDate = payMonth + "01000000";
                       //    sql = " INSERT INTO Download ( SiteId, CarrierId, DownloadDate, DownloadType, UserId, CarrierModel, SongMediaId, ChargeFlag, DownloadCid, Updated, ProductId, DownloadMonth)" +
                       //          " VALUES ( '" + siteId + "', '" + carrierId + "', '" + downloadDate + "', 1, '" + userId + "', '', '" + songMediaId + "',1, '', CONVERT(VARCHAR, CURRENT_TIMESTAMP, 112) + REPLACE(CONVERT(VARCHAR, CURRENT_TIMESTAMP, 108),':',''),'', '" + payMonth + "');";
                       //    sqlInsert.Add(sql);
                       //}
                    }
                    catch (Exception exc)
                    {
                        mvldMessage.AddError("エラーを発生：" + exc.Message);
                    }
                }

                string strSiteId = "";
                string sql_rs = "SELECT DISTINCT S.Id FROM Site S , RbtDownloadImportAuTmp T WHERE S.ServiceCode = T.ServiceCode And SessionId = '" + Session.SessionID + "'";
                DataTable dt_rs = DbHelper.GetMstrData(sql_rs).Tables[0];
                foreach (DataRow row_rs in dt_rs.Rows)
                {
                    try
                    {
                        strSiteId += "'"+ Func.ParseString(row_rs["Id"]) + "',";
                    }
                    catch (Exception exc)
                    {
                        ApplicationLog.WriteError(exc);
                    }
                }
                strSiteId = strSiteId.Substring(0, strSiteId.Length - 1);
                string sql_del = "DELETE FROM Download WHERE DownloadMonth ='" + payMonth + "' AND SiteId IN (" + strSiteId + ") and CarrierId = '"+ CarrierId +"'";
                DbHelper.ExecuteNonQuery(sql_del);

                for (int i = 0; i < sqlInsert.Count; i++)
                {
                    DbHelper.ExecuteNonQuery((string)sqlInsert[i]);
                }

                DbHelper.ExecuteNonQuery("Delete From RbtDownloadImportAuTmp where SessionId = '" + Session.SessionID + "'");
                ShowData();
                Response.Redirect("../MasterImport/ImportFinish.aspx", false);
                mvldMessage.SetCompleteMessage("登録完了しました。");
            }
            catch (Exception exc)
            {
                mvldMessage.AddError("エラーを発生：" + exc.Message);
            }
        }
    }
}
