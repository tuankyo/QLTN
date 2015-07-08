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
    public partial class ListRbtDownloadImport : PageBase
    {
        private string importType = "1";
        private string CarrierId = "0";

        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
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
        /// 
        /// </summary>
        private void ShowData()
        {
            PopupWidth = 850;
            PopupName = "ListSyncSong";

            SqlDatabase db = new SqlDatabase();
            string sql = string.Empty;
            if (!Func.IsValid(ListSortExpression))
            {
                ListSortExpression = "ContentId";
                ListSortDirection = SortDirection.Descending;
            }
            try
            {
                //件数を数える
                sql += " SELECT COUNT(*) ";
                sql += " FROM RbtDownloadImportTmp ";
                sql += " WHERE SessionId = '" + Session.SessionID + "'";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //検索条件で取得情報のSQL文を作成する
                sql = " SELECT *,ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum  FROM RbtDownloadImportTmp ";
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

        /// <summary>
        /// Init values and component
        /// </summary>
        protected override void DoInit()
        {

            divUpdate.Visible = true;

            btnRegister.OnClientClick = "return confirm('登録します。よろしいですか？');";

            DbHelper.FillList(drpSite, "SELECT Id, Name FROM Site WHERE DelFlag=0 AND TypeId = '4' AND RbtCarrierType = '0' ", "Name", "Id");
            txtPayMonth.Text = DateTime.Now.AddMonths(-1).ToString("yyyyMM");
            try
            {

            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }

        /// <summary>
        /// Do Get
        /// </summary>
        protected override void DoGet()
        {
            if (!IsPostBack)
            {
                ShowData();
            }
        }
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void pager_PageIndexChanged(object source, PagerPageChangedEventArgs args)
        {
            ShowData();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string command = e.CommandName;
            string colName = string.Empty;
            string id = Func.ParseString(e.CommandArgument);

            if (command.StartsWith("Sort"))
            {
                if (String.Compare(command, "SortSongId") == 0)
                {
                    colName = "SongId";
                }
                else if (String.Compare(command, "SortSongTitle") == 0)
                {
                    colName = "SongTitle";
                }
                else if (String.Compare(command, "SortSongTitleReading") == 0)
                {
                    colName = "SongTitleReading";
                }
                else if (String.Compare(command, "SortArtistId") == 0)
                {
                    colName = "ArtistId";
                }
                else if (String.Compare(command, "SortArtistName") == 0)
                {
                    colName = "ArtistName";
                }
                else if (String.Compare(command, "SortGenreId") == 0)
                {
                    colName = "GenreId";
                }
                else if (String.Compare(command, "SortAlbumId") == 0)
                {
                    colName = "AlbumId";
                }
                else if (String.Compare(command, "SortAlbumTitle") == 0)
                {
                    colName = "AlbumTitle";
                }
                else if (String.Compare(command, "SortAlbumTitleReadingFull") == 0)
                {
                    colName = "AlbumTitleReadingFull";
                }
                else if (string.Compare(command, "SortLabelId") == 0)
                {
                    colName = "LabelId";
                }
                else if (string.Compare(command, "SortLabelName") == 0)
                {
                    colName = "LabelName";
                }
                else if (string.Compare(command, "SortContractorId") == 0)
                {
                    colName = "ContractorId";
                }
                else if (string.Compare(command, "SortIVT") == 0)
                {
                    colName = "IVT";
                }
                else if (string.Compare(command, "SortIVTType") == 0)
                {
                    colName = "IVTType";
                }
                else if (string.Compare(command, "SortCopyrightOrg") == 0)
                {
                    colName = "CopyrightOrg";
                }
                else if (string.Compare(command, "SortJasracWorksCode") == 0)
                {
                    colName = "JasracWorksCode";
                }
                else if (string.Compare(command, "SortIsrcNo") == 0)
                {
                    colName = "IsrcNo";
                }
                else if (string.Compare(command, "SortPrice") == 0)
                {
                    colName = "Price";
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

                    Func.SetGridTextValue(item, "ltrContentId", Func.ParseString(row["ContentId"]));
                    Func.SetGridTextValue(item, "ltrCpId", Func.ParseString(row["CpId"]));
                    Func.SetGridTextValue(item, "ltrSiteId", Func.ParseString(row["SiteId"]));
                    Func.SetGridTextValue(item, "ltrContentName", Func.ParseString(row["ContentName"]));
                    Func.SetGridTextValue(item, "ltrArtistName", Func.ParseString(row["ArtistName"]));
                    Func.SetGridTextValue(item, "ltrFeeFlag", Func.ParseString(row["FeeFlag"]));
                    Func.SetGridTextValue(item, "ltrCharge", Func.ParseString(row["Charge"]));
                    Func.SetGridTextValue(item, "ltrBeginMonth", Func.ParseString(row["BeginMonth"]));
                    Func.SetGridTextValue(item, "ltrDay01", Func.ParseString(row["Day01"]));
                    Func.SetGridTextValue(item, "ltrDay02", Func.ParseString(row["Day02"]));
                    Func.SetGridTextValue(item, "ltrDay03", Func.ParseString(row["Day03"]));
                    Func.SetGridTextValue(item, "ltrDay04", Func.ParseString(row["Day04"]));
                    Func.SetGridTextValue(item, "ltrDay05", Func.ParseString(row["Day05"]));
                    Func.SetGridTextValue(item, "ltrDay06", Func.ParseString(row["Day06"]));
                    Func.SetGridTextValue(item, "ltrDay07", Func.ParseString(row["Day07"]));
                    Func.SetGridTextValue(item, "ltrDay08", Func.ParseString(row["Day08"]));
                    Func.SetGridTextValue(item, "ltrDay09", Func.ParseString(row["Day09"]));
                    Func.SetGridTextValue(item, "ltrDay10", Func.ParseString(row["Day10"]));
                    Func.SetGridTextValue(item, "ltrDay11", Func.ParseString(row["Day11"]));
                    Func.SetGridTextValue(item, "ltrDay12", Func.ParseString(row["Day12"]));
                    Func.SetGridTextValue(item, "ltrDay13", Func.ParseString(row["Day13"]));
                    Func.SetGridTextValue(item, "ltrDay14", Func.ParseString(row["Day14"]));
                    Func.SetGridTextValue(item, "ltrDay15", Func.ParseString(row["Day15"]));
                    Func.SetGridTextValue(item, "ltrDay16", Func.ParseString(row["Day16"]));
                    Func.SetGridTextValue(item, "ltrDay17", Func.ParseString(row["Day17"]));
                    Func.SetGridTextValue(item, "ltrDay18", Func.ParseString(row["Day18"]));
                    Func.SetGridTextValue(item, "ltrDay19", Func.ParseString(row["Day19"]));
                    Func.SetGridTextValue(item, "ltrDay20", Func.ParseString(row["Day20"]));
                    Func.SetGridTextValue(item, "ltrDay21", Func.ParseString(row["Day21"]));
                    Func.SetGridTextValue(item, "ltrDay22", Func.ParseString(row["Day22"]));
                    Func.SetGridTextValue(item, "ltrDay23", Func.ParseString(row["Day23"]));
                    Func.SetGridTextValue(item, "ltrDay24", Func.ParseString(row["Day24"]));
                    Func.SetGridTextValue(item, "ltrDay25", Func.ParseString(row["Day25"]));
                    Func.SetGridTextValue(item, "ltrDay26", Func.ParseString(row["Day26"]));
                    Func.SetGridTextValue(item, "ltrDay27", Func.ParseString(row["Day27"]));
                    Func.SetGridTextValue(item, "ltrDay28", Func.ParseString(row["Day28"]));
                    Func.SetGridTextValue(item, "ltrDay29", Func.ParseString(row["Day29"]));
                    Func.SetGridTextValue(item, "ltrDay30", Func.ParseString(row["Day30"]));
                    Func.SetGridTextValue(item, "ltrDay31", Func.ParseString(row["Day31"]));

                }
                else if (item.ItemType == ListItemType.Header)
                {
                    PopupHeight = 800;
                    PopupName = "EditSongMain";
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
                        /*
                                                if (colName.EndsWith("SongId"))
                                                {
                                                    Func.SetGridLinkValue(item, "lnkSongId", "ID" + img);
                                                }
                                                if (colName.EndsWith("SongTitle"))
                                                {
                                                    Func.SetGridLinkValue(item, "lnkSongTitle", "曲名" + img);
                                                }
                                                else if (colName.EndsWith("SongTitleReading"))
                                                {
                                                    Func.SetGridLinkValue(item, "lnkSongTitleReading", "曲名ﾖﾐ" + img);
                                                }
                                                else if (colName.EndsWith("ArtistId"))
                                                {
                                                    Func.SetGridLinkValue(item, "lnkArtistId", "アーティストID" + img);
                                                }
                                                else if (colName.EndsWith("ArtistName"))
                                                {
                                                    Func.SetGridLinkValue(item, "lnkArtistName", "アーティスト名" + img);
                                                }
                                                else if (colName.EndsWith("GenreId"))
                                                {
                                                    Func.SetGridLinkValue(item, "lnkGenreId", "ジャンルID" + img);
                                                }
                                                else if (colName.EndsWith("AlbumId"))
                                                {
                                                    Func.SetGridLinkValue(item, "lnkAlbumId", "アルバムID" + img);
                                                }
                                                else if (colName.EndsWith("AlbumTitle"))
                                                {
                                                    Func.SetGridLinkValue(item, "lnkAlbumTitle", "アルバム名" + img);
                                                }
                                                else if (colName.EndsWith("AlbumTitleReadingFull"))
                                                {
                                                    Func.SetGridLinkValue(item, "lnkAlbumTitleReadingFull", "アルバム名ﾖﾐ" + img);
                                                }
                                                else if (colName.EndsWith("LabelId"))
                                                {
                                                    Func.SetGridLinkValue(item, "lnkLabelId", "レーベル" + img);
                                                }
                                                else if (colName.EndsWith("LabelName"))
                                                {
                                                    Func.SetGridLinkValue(item, "lnkLabelName", "レーベル名" + img);
                                                }
                                                if (colName.EndsWith("ContractorId"))
                                                {
                                                    Func.SetGridLinkValue(item, "lnkContractorId", "契約者ID" + img);
                                                }
                                                if (colName.EndsWith("IVT"))
                                                {
                                                    Func.SetGridLinkValue(item, "lnkIVT", "IVT" + img);
                                                }
                                                if (colName.EndsWith("IVTType"))
                                                {
                                                    Func.SetGridLinkValue(item, "lnkIVTType", "IVT区分" + img);
                                                }
                                                if (colName.EndsWith("CopyrightOrg"))
                                                {
                                                    Func.SetGridLinkValue(item, "lnkCopyrightOrg", "著作権管理団体" + img);
                                                }
                                                if (colName.EndsWith("JasracWorksCode"))
                                                {
                                                    Func.SetGridLinkValue(item, "lnkJasracWorksCode", "JASRAC作品コード" + img);
                                                }
                                                if (colName.EndsWith("IsrcNo"))
                                                {
                                                    Func.SetGridLinkValue(item, "lnkIsrcNo", "ISRC" + img);
                                                }
                                                if (colName.EndsWith("Price"))
                                                {
                                                    Func.SetGridLinkValue(item, "lnkPrice", "Price" + img);
                                                }
                        */
                    }
                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string payMonth = string.Empty;
            string licenseHouse = string.Empty;

            mvldMessage.CheckRequired(txtPayMonth, "実績年月を入力してください。");

            if (!mvldMessage.IsValid) return;

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
                    sql = " Select * from RbtDownloadImportTmp where SessionId = '" + Session.SessionID + "'";
                    dt = DbHelper.GetDataTable(sql);
                }
                catch (Exception ex)
                {
                    ApplicationLog.WriteError(ex);
                }

                string carrierType = DbHelper.GetScalar("Select RbtCarrierType from Site where Id = '" + drpSite.SelectedValue + "'");

                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        string strContentId = row["ContentId"].ToString();
                        string songMediaId = strContentId.Substring(strContentId.Length - 9, 9);
                        int iBeginMonth = Func.ParseInt(row["BeginMonth"].ToString());

                        for (int i = 0; i < iBeginMonth; i++)
                        {
                            string date = payMonth + "01010000";
                            sql = " INSERT INTO Download ( SiteId, CarrierId, DownloadDate, DownloadType, UserId, CarrierModel, SongMediaId, ChargeFlag, DownloadCid, Updated, ProductId, DownloadMonth)" +
                                  " VALUES ( '" + drpSite.SelectedValue + "', '" + carrierType + "', '" + date + "', 1, '', '', '" + songMediaId + "',1, '', CONVERT(VARCHAR, CURRENT_TIMESTAMP, 112) + REPLACE(CONVERT(VARCHAR, CURRENT_TIMESTAMP, 108),':',''),'', '" + payMonth + "');";
                            sqlInsert.Add(sql);
                        }

                        for (int i = 1; i <= 31; i++)
                        {
                            string strDay = Func.ParseString(i).PadLeft(2, '0');
                            int iDay = Func.ParseInt(row["Day" + strDay].ToString());

                            if (iDay != 0)
                            {
                                for (int j = 0; j < iDay; j++)
                                {
                                    string date = payMonth + strDay + "000000";
                                    sql = " INSERT INTO Download ( SiteId, CarrierId, DownloadDate, DownloadType, UserId, CarrierModel, SongMediaId, ChargeFlag, DownloadCid, Updated, ProductId, DownloadMonth)" +
                                          " VALUES ( '" + drpSite.SelectedValue + "', '" + carrierType + "', '" + date + "', 1, '', '', '" + songMediaId + "',1, '', CONVERT(VARCHAR, CURRENT_TIMESTAMP, 112) + REPLACE(CONVERT(VARCHAR, CURRENT_TIMESTAMP, 108),':',''),'', '" + payMonth + "');";
                                    sqlInsert.Add(sql);
                                }
                            }
                        }
                    }
                    catch (Exception exc)
                    {

                    }
                }

                DbHelper.ExecuteNonQuery("Delete from Download where SiteId = '" + drpSite.SelectedValue + "' and DownloadMonth = '" + payMonth + "' and CarrierId = '" + CarrierId + "'");
                for (int i = 0; i < sqlInsert.Count; i++)
                {
                    DbHelper.ExecuteNonQuery((string)sqlInsert[i]);
                }

                // QDo start 101118
                string sqlCSV = "   insert into RbtDownloadImportCsv  "
                        + "  (  "
                        + "  [SessionId]  "
                        + "  ,[ContentId]  "
                        + "  ,[CpId]  "
                        + "  ,[SiteId]  "
                        + "  ,[ContentName]  "
                        + "  ,[ArtistName]  "
                        + "  ,[FeeFlag]  "
                        + "  ,[Charge]  "
                        + "  ,[BeginMonth]  "
                        + "  ,[Day01]  "
                        + "  ,[Day02]  "
                        + "  ,[Day03]  "
                        + "  ,[Day04]  "
                        + "  ,[Day05]  "
                        + "  ,[Day06]  "
                        + "  ,[Day07]  "
                        + "  ,[Day08]  "
                        + "  ,[Day09]  "
                        + "  ,[Day10]  "
                        + "  ,[Day11]  "
                        + "  ,[Day12]  "
                        + "  ,[Day13]  "
                        + "  ,[Day14]  "
                        + "  ,[Day15]  "
                        + "  ,[Day16]  "
                        + "  ,[Day17]  "
                        + "  ,[Day18]  "
                        + "  ,[Day19]  "
                        + "  ,[Day20]  "
                        + "  ,[Day21]  "
                        + "  ,[Day22]  "
                        + "  ,[Day23]  "
                        + "  ,[Day24]  "
                        + "  ,[Day25]  "
                        + "  ,[Day26]  "
                        + "  ,[Day27]  "
                        + "  ,[Day28]  "
                        + "  ,[Day29]  "
                        + "  ,[Day30]  "
                        + "  ,[Day31]  "
                        + "  ,[CarrierId]  "
                        + "  ,[SiteNumber]  "
                        + "  ,[DownloadMonth]  "
                        + "  ,[Updated]  "
                        + "  ,[Updator]  "
                        + "  ,[Created]  "
                        + "  ,[Creator]  "
                        + "  )  "
                        + "  select    "
                        + "  [SessionId]  "
                        + "  ,[ContentId]  "
                        + "  ,[CpId]  "
                        + "  ,[SiteId]  "
                        + "  ,[ContentName]  "
                        + "  ,[ArtistName]  "
                        + "  ,[FeeFlag]  "
                        + "  ,[Charge]  "
                        + "  ,[BeginMonth]  "
                        + "  ,[Day01]  "
                        + "  ,[Day02]  "
                        + "  ,[Day03]  "
                        + "  ,[Day04]  "
                        + "  ,[Day05]  "
                        + "  ,[Day06]  "
                        + "  ,[Day07]  "
                        + "  ,[Day08]  "
                        + "  ,[Day09]  "
                        + "  ,[Day10]  "
                        + "  ,[Day11]  "
                        + "  ,[Day12]  "
                        + "  ,[Day13]  "
                        + "  ,[Day14]  "
                        + "  ,[Day15]  "
                        + "  ,[Day16]  "
                        + "  ,[Day17]  "
                        + "  ,[Day18]  "
                        + "  ,[Day19]  "
                        + "  ,[Day20]  "
                        + "  ,[Day21]  "
                        + "  ,[Day22]  "
                        + "  ,[Day23]  "
                        + "  ,[Day24]  "
                        + "  ,[Day25]  "
                        + "  ,[Day26]  "
                        + "  ,[Day27]  "
                        + "  ,[Day28]  "
                        + "  ,[Day29]  "
                        + "  ,[Day30]  "
                        + "  ,[Day31]  "
                        + "  , '" + CarrierId + "'"
                        + "  , '" + drpSite.SelectedValue + "'"
                        + "  , '" + payMonth + "'"
                        + "  ,[Updated]  "
                        + "  ,[Updator]  "
                        + "  ,[Created]  "
                        + "  ,[Creator]  "
                        + "  from RbtDownloadImportTmp  ";
                DbHelper.ExecuteNonQuery(sqlCSV);
                // QDo end 101118

                DbHelper.ExecuteNonQuery("Delete From RbtDownloadImportTmp where SessionId = '" + Session.SessionID + "'");
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
