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
    public partial class NewListMasterImport : PageBase
    {
        private string importType = "1";

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
                ListSortExpression = "SongId";
                ListSortDirection = SortDirection.Descending;
            }
            try
            {
                //件数を数える
                sql += " SELECT COUNT(SongId) ";
                sql += " FROM SongImport ";
                sql += " WHERE (SongId IS NOT NULL) and SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "'";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //検索条件で取得情報のSQL文を作成する
                sql = " SELECT *,ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum  FROM SongImport ";
                sql += " WHERE (SongId IS NOT NULL) and SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "'";

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
            string sql = "Select Count(*) from SongImport where (AlbumId = 'ERROR' or ArtistId = 'ERROR') and SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "'";
            int count = Func.ParseInt(DbHelper.GetScalar(sql));
            divUpdate.Visible = true;
            if (count > 0)
            {
                btnRegister.Visible = false;
            }

            btnGetExistsID.Visible = false;
            sql = "Select Count(*) from SongMediaTemp where Status = '1' and SessionId = '" + Session.SessionID + "' and TypeId in ('2','3') and ImportType = '" + importType + "'";
            count = Func.ParseInt(DbHelper.GetScalar(sql));
            divUpdate.Visible = true;
            if (count > 0)
            {
                mvldMessage.AddError("既に既存している着うた曲IDがあります。CSVﾌｧｲﾙを修正してください");
                btnGetExistsID.Visible = true;
                btnRegister.Visible = false;
            }

            /*
            DbHelper.FillList(lstSiteSend, "SELECT Id, Name FROM Site where DelFlag=0","Name", "Id");
            lstSiteSend.Items.Add(new ListItem("全サイト", "0"));
            Func.SortByValue(lstSiteSend);
            lstSiteSend.Items[0].Selected = true;
            */

            btnRegister.OnClientClick = "return confirm('登録します。よろしいですか？');";

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
            else if (command.Equals("Delete"))
            {
                try
                {
                    string sql = "UPDATE Song set DelFlag=1 WHERE SongId='" + id + "'";
                    if (DbHelper.ExecuteNonQuery(sql) > 0)
                    {
                        ShowData();
                        OperationLogger.WriteInfo(Constants.LogOperationSongId, Constants.LogActionDeleteId, "削除完了しました。", Page.User.Identity.Name);
                        mvldMessage.SetCompleteMessage("削除完了しました。");
                    }
                    else
                    {
                        OperationLogger.WriteError(Constants.LogOperationSongId, Constants.LogActionDeleteId, "削除中にエラーが発生しました。", Page.User.Identity.Name);
                        mvldMessage.AddError("削除中にエラーが発生しました。");
                    }
                }
                catch (Exception ex)
                {
                    OperationLogger.WriteError(Constants.LogOperationSongId, Constants.LogActionDeleteId, "削除中にエラーが発生しました。", Page.User.Identity.Name);
                    ApplicationLog.WriteError(ex);
                }
            }
            else if (command.Equals("ShowMedia"))
            {
                try
                {
                    Panel panDetail = (Panel)e.Item.FindControl("panMediaDetail");
                    panDetail.Visible = true;

                    LinkButton lnk = (LinkButton)e.Item.FindControl("btnShow");
                    lnk.CommandName = "HideMedia";
                    lnk.Text = "閉じる";
                    Repeater detailList = (Repeater)e.Item.FindControl("rptListMedia");
                    detailList.ItemDataBound += new RepeaterItemEventHandler(this.DetailMedia_ItemDataBound);
                    detailList.ItemCommand += new RepeaterCommandEventHandler(this.DetailMedia_ItemCommand);
                    ShowDetailData(detailList, id, panDetail);
                    AddExpand(id);
                }
                catch (Exception ex)
                {
                    OperationLogger.WriteError(Constants.LogOperationSongId, Constants.LogActionDeleteId, "削除中にエラーが発生しました。", Page.User.Identity.Name);
                    ApplicationLog.WriteError(ex);
                }
            }
            else if (command.Equals("HideMedia"))
            {
                Panel panDetail = (Panel)e.Item.FindControl("panMediaDetail");
                panDetail.Visible = false;
                LinkButton lnk = (LinkButton)e.Item.FindControl("btnShow");
                lnk.CommandName = "ShowMedia";
                lnk.Text = "開く";
                RemoveExpand(id);
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
                    Func.SetGridTextValue(item, "ltrSongId", Func.ParseString(row["SongId"]));
                    Func.SetGridTextValue(item, "ltrSongTitle", Func.ToolTipByteLen(Func.ParseString(row["SongTitle"]), 10));
                    Func.SetGridTextValue(item, "ltrSongDcSearchTitle", Func.ToolTipByteLen(Func.ParseString(row["DcSearchTitle"]), 10));
                    Func.SetGridTextValue(item, "ltrSongTitleReading", Func.ToolTipByteLen(Func.ParseString(row["SongTitleReading"]), 10));
                    Func.SetGridTextValue(item, "ltrArtistId", Func.ParseString(row["ArtistId"]));
                    Func.SetGridTextValue(item, "ltrArtistName", Func.ToolTipByteLen(Func.ParseString(row["ArtistName"]), 10));
                    Func.SetGridTextValue(item, "ltrGenreId", Func.ParseString(row["GenreId"]));
                    Func.SetGridTextValue(item, "ltrAlbumId", Func.ParseString(row["AlbumId"]));
                    Func.SetGridTextValue(item, "ltrAlbumTitle", Func.ToolTipByteLen(Func.ParseString(row["AlbumTitle"]), 10));
                    Func.SetGridTextValue(item, "ltrAlbumTitleReadingFull", Func.ToolTipByteLen(Func.ParseString(row["AlbumTitleReadingFull"]), 10));
                    Func.SetGridTextValue(item, "ltrLabelId", Func.ParseString(row["LabelId"]));
                    Func.SetGridTextValue(item, "ltrLabelName", Func.ToolTipByteLen(Func.ParseString(row["LabelName"]), 10));
                    Func.SetGridTextValue(item, "ltrContractorId", Func.ParseString(row["ContractorId"]));
                    Func.SetGridTextValue(item, "ltrIVT", Func.ParseString(row["IVT"]));
                    Func.SetGridTextValue(item, "ltrIVTType", Func.ParseString(row["IVTType"]));
                    Func.SetGridTextValue(item, "ltrCopyrightContractId", Func.ParseString(row["CopyrightContractId"]));
                    Func.SetGridTextValue(item, "ltrJasracWorksCode", Func.ParseString(row["JasracWorksCode"]));
                    Func.SetGridTextValue(item, "ltrIsrcNo", Func.ParseString(row["IsrcNo"]));

                    LinkButton btnShow = (LinkButton)item.FindControl("btnShow");
                    btnShow.CommandArgument = Func.ParseString(row["SongId"]);

                    Literal tmp = null;
                    if ("ERROR".Equals(Func.ParseString(row["AlbumId"])) || "ERROR".Equals(Func.ParseString(row["ArtistId"])))
                    {
                        tmp = (Literal)item.FindControl("ltrBg");
                        tmp.Text = " style=\"background-color:Orange;\" ";
                    }

                    else if ("1".Equals(Func.ParseString(row["Status"])))
                    {
                        tmp = (Literal)item.FindControl("ltrBg");
                        tmp.Text = " style=\"background-color:Yellow;\" ";
                    }
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

                        if (colName.EndsWith("SongId"))
                        {
                            Func.SetGridLinkValue(item, "lnkSongId", "ID" + img);
                        }
                        if (colName.EndsWith("SongTitle"))
                        {
                            Func.SetGridLinkValue(item, "lnkSongTitle", "曲名" + img);
                        }
                        if (colName.EndsWith("SongDcSearchTitle"))
                        {
                            Func.SetGridLinkValue(item, "lnkSongDcSearchTitle", "DC登録検索曲名" + img);
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
                            Func.SetGridLinkValue(item, "lnkCopyrightContractId", "著作権管理団体" + img);
                        }
                        if (colName.EndsWith("JasracWorksCode"))
                        {
                            Func.SetGridLinkValue(item, "lnkJasracWorksCode", "JASRAC作品コード" + img);
                        }
                        if (colName.EndsWith("IsrcNo"))
                        {
                            Func.SetGridLinkValue(item, "lnkIsrcNo", "ISRC" + img);
                        }
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
        /// <summary>
        /// 曲メディアグリッドのデータを取得する処理
        /// </summary>
        /// <param name="rpt"></param>
        /// <param name="parentId"></param>
        /// <param name="panDetail"></param>
        private void ShowDetailData(Repeater rpt, string parentId, Panel panDetail)
        {
            SqlDatabase db = new SqlDatabase();
            SqlCommand cm = db.CreateCommand("Select * from SongMediaTemp where SongId = '" + parentId + "' and SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "'");
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            db.Close();
            rpt.DataSource = ds.Tables[0].DefaultView;
            rpt.DataBind();
            rpt.Visible = true;
            panDetail.Visible = true;
        }
        /// <summary>
        /// 曲メディアグリッドのボタンの押下処理
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void DetailMedia_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
        }
        /// <summary>
        /// 曲メディアグリッドのデータを設定する処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DetailMedia_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;

            if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
            {
                DataRowView row = (DataRowView)item.DataItem;
                Literal ltr = (Literal)item.FindControl("ltrID");
                ltr.Text = Func.ParseString(row["SongMediaId"]);

                ltr = (Literal)item.FindControl("ltrTitle");
                ltr.Text = Func.ParseString(row["Title"]);

                ltr = (Literal)item.FindControl("ltrType");
                ltr.Text = DbHelper.GetScalar("Select Type from Type where TypeId = '" + Func.ParseString(row["TypeId"]) + "'");

                PopupHeight = 300;
                PopupName = "EditSongMedia";
            }
            else if (item.ItemType == ListItemType.Header)
            {

            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            string csv = "";
            DataSet dsSite = new DataSet();
            DataSet ds = new DataSet();
            string kind = "";
            kind = "SongImport";

            try
            {
                string select = " SongId WID ,UtaOnly ｳﾀのみ ,FullOnly ﾌﾙのみ ,Video ﾋﾞﾃﾞｵｸﾘｯﾌﾟ ,Common 共通 ,Branch 枝番 ,TitleFullChar '曲名(全角)' ,SongTitle '曲名(半角)' , " +
                                " SongTitleYomFullChar '曲名ヨミ(全角）' ,SongTitleReading '曲名ﾖﾐ(半角)' , RemoveDateFull '解禁日（フル）' ,RemoveDateUta '解禁日（うた）' , AlphabetTitle 曲名英表記," +
                                " RemoveDateVideo '解禁日（ﾋﾞﾃﾞｵｸﾘｯﾌﾟ）' ,HaishinEndDate 配信停止日 ,HaishinEndDateUta '配信停止日（うた）' ,HaishinEndDateVideo '配信停止日（ビデオ）' ,ArtistId ｱｰﾃｨｽﾄID , " +
                                " ArtistName 'ｱｰﾃｨｽﾄ名(半角)' ,ArtistNameReading 'ｱｰﾃｨｽﾄ名ﾖﾐ(全角)' ,ArtistNameReadingFull 'ｱｰﾃｨｽﾄ名ﾖﾐ(半角)' ,AlphabetName ｱｰﾃｨｽﾄ名英表記,GenreId ｼﾞｬﾝﾙ ,AlbumId ｱﾙﾊﾞﾑID , " +
                                " AlbumTitle 'ｱﾙﾊﾞﾑ名(半角)' ,AlbumTitleReading 'ｱﾙﾊﾞﾑ名ヨミ(全角)' ,AlbumTitleReadingFull 'ｱﾙﾊﾞﾑ名ﾖﾐ(半角)' ,AlbumCdId CD品番, SaleDate 発売日,SongArranger 収録曲順 , " +
                                " TrackNumber ﾄﾗｯｸﾅﾝﾊﾞｰ ,Price 価格 ,PriceUta '価格(うた)' ,PriceVideo '価格（ﾋﾞﾃﾞｵｸﾘｯﾌﾟ）' ,LabelId ﾚｰﾍﾞﾙID ,LabelName 'ﾚｰﾍﾞﾙ名(半角)' , " +
                                " ContractorId 契約者名 ,IVT 歌詞区分 ,IVTType IVT区分 ,CopyrightOrg 著作権団体 ,JasracWorksCode 著作権管理番号 , " +
                                " IsrcNo ISRC番号 ,SongWriter 作詞者 ,SongComposer 作曲者 ,SongTranslator 訳詞者 ,Point1 切り出し表記1 ,Sabi1 cut開始1 ,Sabi1End cut終了1 ,Point2 切り出し表記2 ,Sabi2 cut開始2 , " +
                                " Sabi2End cut終了2 ,Point3 切り出し表記3 ,Sabi3 cut開始3 ,Sabi3End cut終了3 ,PRText 備考 ,Flag fineflag ,UtaTitleA うたﾀｲﾄﾙ名A ,UtaTitleB うたﾀｲﾄﾙ名B ,UtaTitleC うたﾀｲﾄﾙ名C , " +
                                " UtaTitleD うたﾀｲﾄﾙ名D ,UtaTitleE うたﾀｲﾄﾙ名E ,UtaTitleF うたﾀｲﾄﾙ名F ,UtaTitleG うたﾀｲﾄﾙ名G ,UtaTitleH うたﾀｲﾄﾙ名H ,UtaTitleI うたﾀｲﾄﾙ名I ,UtaTitleJ うたﾀｲﾄﾙ名J ,UtaTitleK うたﾀｲﾄﾙ名K ,UtaTitleL うたﾀｲﾄﾙ名L ,UtaTitleM うたﾀｲﾄﾙ名M , " +
                                " UtaTitleN うたﾀｲﾄﾙ名N ,UtaTitleO うたﾀｲﾄﾙ名O ,UtaTitleP うたﾀｲﾄﾙ名P ,UtaTitleQ うたﾀｲﾄﾙ名Q ,UtaTitleR うたﾀｲﾄﾙ名R ,UtaIsrcNoA うたISRCA ,UtaIsrcNoB うたISRCB , " +
                                " UtaIsrcNoC うたISRCC ,UtaIsrcNoD うたISRCD ,UtaIsrcNoE うたISRCE ,UtaIsrcNoF うたISRCF ,UtaIsrcNoG うたISRCG ,UtaIsrcNoH うたISRCH ,UtaIsrcNoI うたISRCI ,UtaIsrcNoJ うたISRCJ , " +
                                " UtaIsrcNoK うたISRCK ,UtaIsrcNoL うたISRCL ,UtaIsrcNoM うたISRCM ,UtaIsrcNoN うたISRCN ,UtaIsrcNoO うたISRCO ,UtaIsrcNoP うたISRCP ,UtaIsrcNoQ うたISRCQ ,UtaIsrcNoR うたISRCR ,VideoBranchName ﾋﾞﾃﾞｵ枝番名V , " +
                                " VideoIsrcNo ﾋﾞﾃﾞｵISRCV ,FullFileName フルファイル名 ,UtaFileNameA うたファイル名A ,UtaFileNameB うたファイル名B ,UtaFileNameC うたファイル名C ,UtaFileNameD うたファイル名D ,UtaFileNameE うたファイル名E ,UtaFileNameF うたファイル名F , " +
                                " UtaFileNameG うたファイル名G ,UtaFileNameH うたファイル名H ,UtaFileNameI うたファイル名I ,UtaFileNameJ うたファイル名J ,UtaFileNameK うたファイル名K ,UtaFileNameL うたファイル名L ,UtaFileNameM うたファイル名M ,UtaFileNameN うたファイル名N , " +
                                " UtaFileNameO うたファイル名O ,UtaFileNameP うたファイル名P ,UtaFileNameQ うたファイル名Q ,UtaFileNameR うたファイル名R, VideoFileName ビデオファイル名V  ";
                ds = DbHelper.GetMstrData(kind, select, "SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "'", "0", "");

                if (ds != null)
                {
                    csv = Func.CreateCSV(ds, true);
                }

            }
            catch (Exception ex)
            {
                ICJSystem.Instance.Log.Error(ex.Message);
            }
            Session["DownloadCsvContent"] = csv;
            Session["Kind"] = kind;
            mvldMessage.SetCompleteMessage("CSV出力完了しました。");
        }
        protected void btnGetExistsID_Click(object sender, EventArgs e)
        {
            string csv = "";
            DataSet dsSite = new DataSet();
            DataSet ds = new DataSet();
            string kind = "";
            kind = "SongMediaTemp";

            try
            {
                string select = " SongMediaId WID, SongId FID";
                ds = DbHelper.GetMstrData(kind, select, "SessionId = '" + Session.SessionID + "' and TypeId in ('2','3') and Status = '1' and ImportType = '" + importType + "'", "0", "");

                if (ds != null)
                {
                    csv = Func.CreateCSV(ds, true);
                }

            }
            catch (Exception ex)
            {
                ICJSystem.Instance.Log.Error(ex.Message);
            }
            Session["DownloadCsvContent"] = csv;
            Session["Kind"] = kind;
            mvldMessage.SetCompleteMessage("CSV出力完了しました。");
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string[] yomiArray = { "ｱｲｳｴｵ", "ｶｷｸｹｺ", "ｻｼｽﾃﾓ", "ﾀﾁﾂﾃﾄ", "ﾅﾆﾇﾈﾉ", "ﾊﾋﾌﾍﾎ", "ﾏﾐﾑﾒﾓ", "ﾔﾕﾖ", "ﾗﾘﾙﾚﾛ", "ﾜｦﾝ" };
            string[] yomi = { "ｱ", "ｶ", "ｻ", "ﾀ", "ﾅ", "ﾊ", "ﾏ", "ﾔ", "ﾗ", "ﾜ" };

            try
            {
                string updator = Page.User.Identity.Name;
                string creator = Page.User.Identity.Name;
                string created = DateTime.Now.ToString("yyyyMMddHHmmss");
                string updated = DateTime.Now.ToString("yyyyMMddHHmmss");

                SqlDatabase db = new SqlDatabase();
                string sql = string.Empty;
                DataSet ds = new DataSet();
                sql = "Select Distinct AlbumId,AlbumTitle,AlbumTitleReadingFull,AlbumCdId,SaleDate From SongImport where AlbumId not in (Select AlbumId from Album) and SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "'";
                SqlCommand cm = db.CreateCommand(sql);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(ds);
                db.Close();

                if (ds.Tables[0] != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];
                        string AlbumId = dr["AlbumId"].ToString().Replace("'", "''");
                        string AlbumTitle = dr["AlbumTitle"].ToString().Replace("'", "''");
                        string AlbumTitleReadingFull = dr["AlbumTitleReadingFull"].ToString().Replace("'", "''");
                        string AlbumCdId = dr["AlbumCdId"].ToString().Replace("'", "''");
                        string firstYomi = AlbumTitleReadingFull.Substring(0, 1);
                        string saleDate = Func.FormatYmd(dr["SaleDate"].ToString()).Replace("/", "");

                        for (int j = 0; j < yomiArray.Length; j++)
                        {
                            if (yomiArray[j].IndexOf(firstYomi) > 0)
                            {
                                firstYomi = yomi[j];
                            }
                        }
                        DbHelper.ExecuteNonQuery("INSERT INTO Album (AlbumId,Title,TitleReading,TitleReadingFull,CdId,SaleDate, DelFlag,Updated,Updator,Created,Creator)" +
                            " values('" + AlbumId + "','" + AlbumTitle + "','" + firstYomi + "','" + AlbumTitleReadingFull + "','" + AlbumCdId + "','" + saleDate + "','0','" + updated + "','" + updator + "','" + created + "','" + creator + "')");
                    }
                }

                sql = string.Empty;
                ds = new DataSet();
                sql = "Select Distinct ArtistId,ArtistName,ArtistNameReadingFull,AlphabetName From SongImport where ArtistId not in (Select ArtistId from Artist) and SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "'";
                cm = db.CreateCommand(sql);
                da = new SqlDataAdapter(cm);
                da.Fill(ds);
                db.Close();

                if (ds.Tables[0] != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];
                        string ArtistId = dr["ArtistId"].ToString().Replace("'", "''");
                        string ArtistName = dr["ArtistName"].ToString().Replace("'", "''");
                        string ArtistNameReadingFull = dr["ArtistNameReadingFull"].ToString().Replace("'", "''");
                        string firstYomi = ArtistNameReadingFull.Substring(0, 1);
                        string alphabetName = dr["AlphabetName"].ToString().Replace("'", "''");
                        for (int j = 0; j < yomiArray.Length; j++)
                        {
                            if (yomiArray[j].IndexOf(firstYomi) > 0)
                            {
                                firstYomi = yomi[j];
                            }
                        }
                        DbHelper.ExecuteNonQuery("INSERT INTO Artist (ArtistId,Name,NameReading,NameReadingFull,AlphabetName,DelFlag,Updated,Updator,Created,Creator)" +
                            " values('" + ArtistId + "','" + ArtistName + "','" + firstYomi + "','" + ArtistNameReadingFull + "','" + alphabetName + "','0','" + updated + "','" + updator + "','" + created + "','" + creator + "')");
                    }
                }

                sql = string.Empty;
                ds = new DataSet();
                sql = "Select Distinct LabelId,LabelName From SongImport where LabelId not in (Select LabelId from Label) and SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "'";
                cm = db.CreateCommand(sql);
                da = new SqlDataAdapter(cm);
                da.Fill(ds);
                db.Close();

                if (ds.Tables[0] != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];
                        string LabelId = dr["LabelId"].ToString().Replace("'", "''");
                        string LabelName = dr["LabelName"].ToString().Replace("'", "''");
                        DbHelper.ExecuteNonQuery("INSERT INTO Label (LabelId,Name,DelFlag,Updated,Updator,Created,Creator)" +
                            " values('" + LabelId + "','" + LabelName + "','0','" + updated + "','" + updator + "','" + created + "','" + creator + "')");
                    }
                }

                //新規
                //Full
                string insert = " INSERT INTO Song  (SongId,     Title,TitleReadingFull ,TitleReading, AlphabetTitle, ArtistId,GenreId,AlbumId,LabelId,ContractorId,IVT," +
                                " IVTType,CopyrightContractId,JasracWorksCode,SongWriter                     ,SongComposer                       , PRText,DelFlag,Updated , Updator, Created, Creator, DcSearchTitle, SbSearchTitle)	" +
                                " Select             SongId, SongTitle, SongTitleReading,    SongYomi, AlphabetTitle, ArtistId,GenreId,AlbumId,LabelId,ContractorId,cast(IVT as varchar(1))," +
                                " cast(IVTType as varchar(1)),CopyrightContractId,JasracWorksCode,cast(SongWriter as varchar(100)),cast(SongComposer as varchar(100)),PRText,'0','" + updated + "','" + updator + "','" + created + "','" + creator + "', DcSearchTitle, SongTitle from  SongImport where SessionId = '" + Session.SessionID + "' and SongImport.ImportType = '" + importType + "' and SongId not in (Select SongId from Song)";

                DbHelper.ExecuteNonQuery(insert);

                //Full
                insert = " INSERT INTO SongMedia (SongMediaId,SongId,Title    ,FileName,TypeId,IsrcNo,Rate     ,Price,PRText,Flag,HaishinDate   ,HaishinEndDate, PriceNoTax,BuyUnique,CopyrightFeeUnique,KDDICommissionUnique,ProfitUnique,ReserveFlag,ImodeFlag,SBankFlag, ImodeNoTrialFlag,SBankNoTrialFlag,EzwebNoTrialFlag,FineFlag,Point1,sabi1,Sabi1End,Point2,Sabi2,Sabi2End, Point3,Sabi3, Sabi3End,DelFlag,Updated , Updator, Created, Creator, SbSearchTitle)	" +
                                " Select          SongId,     SongId,SongTitle,FullFileName,'1',   IsrcNo,HbunRitsu,Price,PRText,Flag,RemoveDateFull,HaishinEndDate,PriceNoTax,BuyUnique,CopyrightFeeUnique,KDDICommissionUnique,ProfitUnique,'1','1','1','1','1','1','1',Point1,RIGHT('0000000' + sabi1, 7),RIGHT('0000000' + Sabi1End, 7),Point2,RIGHT('0000000' + Sabi2, 7),RIGHT('0000000' + Sabi2End, 7),Point3,RIGHT('0000000' + Sabi3, 7),RIGHT('0000000' + Sabi3End, 7),'0','" + updated + "','" + updator + "','" + created + "','" + creator + "', SongTitle from  SongImport where SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "' and SongId not in (Select SongMediaId from SongMedia Where TypeId = '1')";
                DbHelper.ExecuteNonQuery(insert);

                string update = " Update SongMedia Set ReserveFlag = '0',ImodeFlag='0', SBankFlag='0', FineFlag='0', ImodeNoTrialFlag='0',SBankNoTrialFlag='0',EzwebNoTrialFlag='0'" +
                                " From  SongImport, Song where SongImport.SongId = Song.SongId and SessionId = '" + Session.SessionID + "' and SongImport.SongId = SongMedia.SongMediaId and Song.ContractorId in ('KY0092','KY0111','KY0039','KY0261') and SongImport.ImportType = '" + importType + "'";
                DbHelper.ExecuteNonQuery(update);

                //Uta                //Video
                insert = " INSERT INTO SongMedia (SongMediaId,SongId,Title,FileName,TypeId,IsrcNo,rate,Price,PRText,Flag,HaishinDate,HaishinEndDate,PriceNoTax,BuyUnique,CopyrightFeeUnique,KDDICommissionUnique,ProfitUnique,ReserveFlag,ImodeFlag,SBankFlag,FineFlag,DelFlag,Updated , Updator, Created, Creator, SbSearchTitle) " +
                         " Select SongMediaId,SongId,Title,FileName,TypeId,ISRCNo,rate,Price,PRText,Flag,HaishinDate,HaishinEndDate,PriceNoTax,BuyUnique,CopyrightFeeUnique,KDDICommissionUnique,ProfitUnique,'1','1','1','1','0','" + updated + "','" + updator + "','" + created + "','" + creator + "', Title from  SongMediaTemp where SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "'";
                DbHelper.ExecuteNonQuery(insert);

                update = " Update SongMedia Set ReserveFlag = '0',ImodeFlag='0', SBankFlag='0', FineFlag='0'" +
                         " From  SongMediaTemp , Song where SongMediaTemp.SongId = Song.SongId and SessionId = '" + Session.SessionID + "' and SongMediaTemp.SongMediaId = SongMedia.SongMediaId and Song.ContractorId in ('KY0092','KY0111','KY0039','KY0261') and SongMediaTemp.ImportType = '" + importType + "'";
                DbHelper.ExecuteNonQuery(update);

                DbHelper.ExecuteNonQuery("Delete From SongImport where SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "'");
                DbHelper.ExecuteNonQuery("Delete From SongMediaTemp where SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "'");
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
