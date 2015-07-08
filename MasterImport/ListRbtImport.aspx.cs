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
    public partial class ListRbtImport : PageBase
    {
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
                sql += " WHERE (SongId IS NOT NULL) and SessionId = '"+ Session.SessionID +"'";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //検索条件で取得情報のSQL文を作成する
                sql = " SELECT *,ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum  FROM SongImport ";
                sql += " WHERE (SongId IS NOT NULL) and SessionId = '" + Session.SessionID + "'";

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
            string sql = "Select Count(*) from SongImport where AlbumId = 'ERROR' and SessionId = '"+ Session.SessionID +"'";
            int count = Func.ParseInt(DbHelper.GetScalar(sql));
            divUpdate.Visible = true;
            if (count > 0)
            {
                divUpdate.Visible = false;
            }

            sql = "Select Count(*) from SongImport where Status = '1' and SessionId = '" + Session.SessionID + "'";
            count = Func.ParseInt(DbHelper.GetScalar(sql));
            divUpdate.Visible = true;
            if (count > 0)
            {
                divUpdate.Visible = false;
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

            }else if (command.Equals("Delete"))
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
                    Func.SetGridTextValue(item, "ltrSongId",Func.ParseString(row["SongId"]));
                    Func.SetGridTextValue(item, "ltrSongTitle",Func.ToolTipByteLen(Func.ParseString(row["SongTitle"]),10));
                    Func.SetGridTextValue(item, "ltrSongTitleReading",Func.ToolTipByteLen(Func.ParseString(row["SongTitleReading"]),10));
                    Func.SetGridTextValue(item, "ltrArtistId",Func.ParseString(row["ArtistId"]));
                    Func.SetGridTextValue(item, "ltrArtistName",Func.ToolTipByteLen(Func.ParseString(row["ArtistName"]),10));
                    Func.SetGridTextValue(item, "ltrGenreId",Func.ParseString(row["GenreId"]));
                    Func.SetGridTextValue(item, "ltrAlbumId",Func.ParseString(row["AlbumId"]));
                    Func.SetGridTextValue(item, "ltrAlbumTitle",Func.ToolTipByteLen(Func.ParseString(row["AlbumTitle"]),10));
                    Func.SetGridTextValue(item, "ltrAlbumTitleReadingFull",Func.ToolTipByteLen(Func.ParseString(row["AlbumTitleReadingFull"]),10));
                    Func.SetGridTextValue(item, "ltrLabelId",Func.ParseString(row["LabelId"]));
                    Func.SetGridTextValue(item, "ltrLabelName",Func.ToolTipByteLen(Func.ParseString(row["LabelName"]),10));
                    Func.SetGridTextValue(item, "ltrContractorId",Func.ParseString(row["ContractorId"]));
                    Func.SetGridTextValue(item, "ltrIVT",Func.ParseString(row["IVT"]));
                    Func.SetGridTextValue(item, "ltrIVTType",Func.ParseString(row["IVTType"]));
                    Func.SetGridTextValue(item, "ltrCopyrightOrg",Func.ParseString(row["CopyrightOrg"]));
                    Func.SetGridTextValue(item, "ltrJasracWorksCode",Func.ParseString(row["JasracWorksCode"]));
                    Func.SetGridTextValue(item, "ltrIsrcNo",Func.ParseString(row["IsrcNo"]));

                    LinkButton btnShow = (LinkButton)item.FindControl("btnShow");
                    btnShow.CommandArgument = Func.ParseString(row["SongId"]);

                    Literal tmp = null;
                    if ("ERROR".Equals(Func.ParseString(row["AlbumId"])))
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
                            Func.SetGridLinkValue(item,"lnkLabelName","レーベル名" + img);
                        }
                        if (colName.EndsWith("ContractorId"))
                        {
                            Func.SetGridLinkValue(item,"lnkContractorId","契約者ID" + img);
                        }
                        if (colName.EndsWith("IVT"))
                        {
                            Func.SetGridLinkValue(item,"lnkIVT","IVT" + img);
                        }
                        if (colName.EndsWith("IVTType"))
                        {
                            Func.SetGridLinkValue(item, "lnkIVTType","IVT区分" + img);
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
            SongMediaTempData data = new SongMediaTempData();

            ISearchTransaction tran = factory.GetSearchObject(data);
            tran.Where = data.ColSongId + "='" + parentId + "' and SessionId = '"+ Session.SessionID +"'";
            tran.AddOrder(data.ColCreated, false);
            Execute(tran);
            if (!HasError)
            {
                if (tran.Count > 0)
                {
                    rpt.DataSource = tran.Result;
                    rpt.DataBind();
                }
                rpt.Visible = true;
            }
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
            SongMediaTempData data = (SongMediaTempData)item.DataItem;
            //TypeData type = (TypeData)data.GetSongMediaType();

            if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
            {

                Literal ltr = (Literal)item.FindControl("ltrID");
                ltr.Text = data.SongMediaId;

                ltr = (Literal)item.FindControl("ltrTitle");
                ltr.Text = data.Title;

                ltr = (Literal)item.FindControl("ltrType");
                ltr.Text = DbHelper.GetScalar("Select Type from Type where TypeId = '" + data.TypeId + "'");

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
                string select = " SongId WID ,UtaOnly ｳﾀのみ ,FullOnly ﾌﾙのみ ,Video ﾋﾞﾃﾞｵｸﾘｯﾌﾟ ,Common 共通 ,Branch 枝番 ,TitleFullChar '曲名(全角)' ,SongTitle '曲名(半角)' , "+
                                " SongTitleYomFullChar '曲名ヨミ(全角）' ,SongTitleReading '曲名ﾖﾐ(半角)' ,HaishinDate 配信予定日 ,RemoveDateFull '解禁日（フル）' ,RemoveDateUta '解禁日（うた）' , "+
                                " RemoveDateVideo '解禁日（ﾋﾞﾃﾞｵｸﾘｯﾌﾟ）' ,HaishinEndDate 配信停止日 ,HaishinEndDateUta '配信停止日（うた）' ,HaishinEndDateVideo '配信停止日（ビデオ）' ,ArtistId ｱｰﾃｨｽﾄID , "+
                                " ArtistName 'ｱｰﾃｨｽﾄ名(半角)' ,ArtistNameReading 'ｱｰﾃｨｽﾄ名ﾖﾐ(全角)' ,ArtistNameReadingFull 'ｱｰﾃｨｽﾄ名ﾖﾐ(半角)' ,GenreId ｼﾞｬﾝﾙ ,AlbumId ｱﾙﾊﾞﾑID , "+
                                " AlbumTitle 'ｱﾙﾊﾞﾑ名(半角)' ,AlbumTitleReading 'ｱﾙﾊﾞﾑ名ヨミ(全角)' ,AlbumTitleReadingFull 'ｱﾙﾊﾞﾑ名ﾖﾐ(半角)' ,AlbumCdId CD品番 ,SongArranger 収録曲順 , "+
                                " TrackNumber ﾄﾗｯｸﾅﾝﾊﾞｰ ,Price 価格 ,PriceUta '価格(うた)' ,PriceVideo '価格（ﾋﾞﾃﾞｵｸﾘｯﾌﾟ）' ,LabelId ﾚｰﾍﾞﾙID ,LabelName 'ﾚｰﾍﾞﾙ名(半角)' , "+
                                " ContractorId 契約者名 ,IVT 歌詞区分 ,IVTType IVT区分 ,CopyrightOrg 著作権団体 ,JasracWorksCode 著作権管理番号 ,IsrcNoVideo 'ISRC番号（ﾋﾞﾃﾞｵｸﾘｯﾌﾟ）' ,IsrcNoUta 'ISRC番号(うた)' , "+
                                " IsrcNo ISRC番号 ,SongWriter 作詞者 ,SongComposer 作曲者 ,SongTranslator 訳詞者 ,Point1 切り出し表記1 ,Sabi1 cut開始1 ,Sabi1End cut終了1 ,Point2 切り出し表記2 ,Sabi2 cut開始2 , "+
                                " Sabi2End cut終了2 ,Point3 切り出し表記3 ,Sabi3 cut開始3 ,Sabi3End cut終了3 ,PRText 備考 ,Flag fineflag ,UtaTitleA うたﾀｲﾄﾙ名A ,UtaTitleB うたﾀｲﾄﾙ名B ,UtaTitleC うたﾀｲﾄﾙ名C , "+
                                " UtaTitleD うたﾀｲﾄﾙ名D ,UtaTitleE うたﾀｲﾄﾙ名E ,UtaTitleF うたﾀｲﾄﾙ名F ,UtaTitleG うたﾀｲﾄﾙ名G ,UtaTitleH うたﾀｲﾄﾙ名H ,UtaTitleI うたﾀｲﾄﾙ名I ,UtaTitleJ うたﾀｲﾄﾙ名J ,UtaTitleK うたﾀｲﾄﾙ名K ,UtaTitleL うたﾀｲﾄﾙ名L ,UtaTitleM うたﾀｲﾄﾙ名M , "+
                                " UtaTitleN うたﾀｲﾄﾙ名N ,UtaTitleO うたﾀｲﾄﾙ名O ,UtaTitleP うたﾀｲﾄﾙ名P ,UtaTitleQ うたﾀｲﾄﾙ名Q ,UtaTitleR うたﾀｲﾄﾙ名R ,UtaIsrcNoA うたISRCA ,UtaIsrcNoB うたISRCB , "+
                                " UtaIsrcNoC うたISRCC ,UtaIsrcNoD うたISRCD ,UtaIsrcNoE うたISRCE ,UtaIsrcNoF うたISRCF ,UtaIsrcNoG うたISRCG ,UtaIsrcNoH うたISRCH ,UtaIsrcNoI うたISRCI ,UtaIsrcNoJ うたISRCJ , "+
                                " UtaIsrcNoK うたISRCK ,UtaIsrcNoL うたISRCL ,UtaIsrcNoM うたISRCM ,UtaIsrcNoN うたISRCN ,UtaIsrcNoO うたISRCO ,UtaIsrcNoP うたISRCP ,UtaIsrcNoQ うたISRCQ ,UtaIsrcNoR うたISRCR ,VideoBranchName ﾋﾞﾃﾞｵ枝番名V , "+
                                " VideoIsrcNo ﾋﾞﾃﾞｵISRCV ,FullFileName フルファイル名 ,UtaFileNameA うたファイル名A ,UtaFileNameB うたファイル名B ,UtaFileNameC うたファイル名C ,UtaFileNameD うたファイル名D ,UtaFileNameE うたファイル名E ,UtaFileNameF うたファイル名F , "+
                                " UtaFileNameG うたファイル名G ,UtaFileNameH うたファイル名H ,UtaFileNameI うたファイル名I ,UtaFileNameJ うたファイル名J ,UtaFileNameK うたファイル名K ,UtaFileNameL うたファイル名L ,UtaFileNameM うたファイル名M ,UtaFileNameN うたファイル名N , "+
                                " UtaFileNameO うたファイル名O ,UtaFileNameP うたファイル名P ,UtaFileNameQ うたファイル名Q ,UtaFileNameR うたファイル名R  ";
                ds = DbHelper.GetMstrData(kind, select, "SessionId = '"+ Session.SessionID +"'", "0", "");

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
            try
            {
                string updator = Page.User.Identity.Name;
                string creator = Page.User.Identity.Name;
                string created = DateTime.Now.ToString("yyyyMMddHHmmss");
                string updated = DateTime.Now.ToString("yyyyMMddHHmmss");

                DbHelper.ExecuteNonQuery("INSERT INTO Album Select AlbumId,AlbumTitle,AlbumTitleReading,AlbumTitleReadingFull,'',AlbumCdId,null,null,null,'0','" + updated + "','" + updator + "','" + created + "','" + creator + "' From SongImport where AlbumId not in (Select AlbumId from Album) and SessionId = '" + Session.SessionID + "'");
                DbHelper.ExecuteNonQuery("INSERT INTO Label Select LabelId,LabelName,'','0','" + updated + "','" + updator + "','" + created + "','" + creator + "' From SongImport where LabelId not in (Select LabelId from Label) and SessionId = '" + Session.SessionID + "'");
                DbHelper.ExecuteNonQuery("INSERT INTO Artist Select ArtistId,ArtistName,ArtistNameReading,ArtistNameReadingFull,null,null,null,null,null,null,null,'0','" + updated + "','" + updator + "','" + created + "','" + creator + "' From SongImport where ArtistId not in (Select ArtistId from Artist) and SessionId = '" + Session.SessionID + "'");

                DataSet ds = new DataSet();
                //Full
                string insert = " INSERT INTO Song  (SongId,Title,TitleReadingFull,ArtistId,GenreId,AlbumId,Price,LabelId,ContractorId,IVT,"+
                                " IVTType,CopyrightOrg,JasracWorksCode,IsrcNo,SongWriter,SongComposer,Point1,Sabi1,Sabi1End,Point2,Sabi2,Sabi2End,Point3,Sabi3, " +
                                " Sabi3End,PRText,Flag, Rate,HaishinDate,PriceNoTax,BuyUnique,CopyrightFeeUnique,KDDICommissionUnique,ProfitUnique,DelFlag,Updated , Updator, Created, Creator)	" +
                                " Select SongId,SongTitle,SongTitleReading,ArtistId,GenreId,AlbumId,Price,LabelId,ContractorId,IVT,IVTType,CopyrightOrg,JasracWorksCode,IsrcNo,cast(SongWriter as varchar(100)),cast(SongComposer as varchar(100)),Point1,Sabi1,Sabi1End,Point2,Sabi2,Sabi2End,Point3,Sabi3,Sabi3End,PRText,Flag,HbunRitsu,RemoveDateFull,PriceNoTax,BuyUnique,CopyrightFeeUnique,KDDICommissionUnique,ProfitUnique,'0','" + updated + "','" + updator + "','" + created + "','" + creator + "' from  SongImport where SessionId = '" + Session.SessionID + "'";
                if (DbHelper.ExecuteNonQuery(insert) == 0)
                {
                    mvldMessage.AddError("エラーを発生:ファイルフォーマットを修正してください");
                    return;
                }

                //Uta                //Video
                insert = " INSERT INTO SongMedia (SongMediaId,SongId,Title,FileName,TypeId,IsrcNo,rate,Price,PRText,Flag,HaishinDate,PriceNoTax,BuyUnique,CopyrightFeeUnique,KDDICommissionUnique,ProfitUnique,DelFlag,Updated , Updator, Created, Creator) " +
                         " Select SongMediaId,SongId,Title,FileName,TypeId,ISRCNo,rate,Price,PRText,Flag,HaishinDate,PriceNoTax,BuyUnique,CopyrightFeeUnique,KDDICommissionUnique,ProfitUnique,'0','" + updated + "','" + updator + "','" + created + "','" + creator + "' from  SongMediaTemp where SessionId = '" + Session.SessionID + "' and TypeId='2'";
                DbHelper.ExecuteNonQuery(insert);

                DataSet dsSite = new DataSet();
                string SiteSelectIds = "";
                foreach (ListItem lstItem in lstSiteSend.Items)
                {
                    if (lstItem.Selected)
                    {
                        SiteSelectIds += "," + "'" + lstItem.Value + "'";
                    }
                }
                if (SiteSelectIds == "")
                {
                    //error !  please select site id.
                    mvldMessage.AddError("サイトを選択してください \r\n 注意：全サイトを選択すれば、全サイトが反映される。");
                    return;
                }
                else
                {
                    SiteSelectIds = SiteSelectIds.Substring(1);
                }
                if ("'0'".Equals(SiteSelectIds))
                {
                    SiteSelectIds = "";
                }
                dsSite = DbHelper.GetSiteData(!"".Equals(SiteSelectIds) ? SiteSelectIds : "","");


                string siteId = "";
                string siteUrl = "";
                string siteType = "";

                SqlDatabase db = new SqlDatabase();
                string sql = string.Empty;
                ds = new DataSet();
                sql = "Select TypeId , Type from Type where Delflag = '0'";
                SqlCommand cm = db.CreateCommand(sql);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(ds);
                db.Close();

                if (ds.Tables[0] != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];
                        string typeId = dr["TypeId"].ToString();
                        foreach (DataRow drSite in dsSite.Tables[0].Rows)
                        {
                            string filename = DateTime.Now.ToString("yyyyMMdd") + ".csv";
                            siteId = drSite["Id"].ToString();
                            siteUrl = drSite["Url"].ToString();
                            siteType = drSite["TypeId"].ToString();

                            if (typeId.Equals(siteType))
                            {
                                if ("1".Equals(typeId))
                                {
                                    insert = " INSERT INTO SongSite  (SiteId, SongId,Title,Price,IsrcNo, PRText,Flag, Rate,HaishinDate,PriceNoTax,BuyUnique,CopyrightFeeUnique,KDDICommissionUnique,ProfitUnique,DelFlag,Updated , Updator, Created, Creator)	" +
                                    " Select '" + siteId + "',SongId,SongTitle,Price,IsrcNo,PRText,Flag, HBunritsu,RemoveDateFull,PriceNoTax,BuyUnique,CopyrightFeeUnique,KDDICommissionUnique,ProfitUnique,DelFlag,Updated , Updator, Created, Creator from  SongImport where SessionId = '" + Session.SessionID + "'";
                                    DbHelper.ExecuteNonQuery(insert);
                                }
                                else
                                {
                                    insert = " INSERT INTO SongSite (SiteId, SongId,Title,Price,IsrcNo,PRText,Flag, Rate,HaishinDate,PriceNoTax,BuyUnique,CopyrightFeeUnique,KDDICommissionUnique,ProfitUnique,DelFlag,Updated , Updator, Created, Creator) " +
                                             " Select '" + siteId + "', SongMediaId,Title,Price,IsrcNo,PRText,Flag, Rate,HaishinDate,PriceNoTax,BuyUnique,CopyrightFeeUnique,KDDICommissionUnique,ProfitUnique,DelFlag,Updated , Updator, Created, Creator from  SongMediaTemp where SessionId = '" + Session.SessionID + "' and TypeId = '" + siteType + "'";
                                    DbHelper.ExecuteNonQuery(insert);
                                }
                            }
                        }
                    }
                }
                DbHelper.ExecuteNonQuery("Delete From SongImport where SessionId = '"+ Session.SessionID +"'");
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
