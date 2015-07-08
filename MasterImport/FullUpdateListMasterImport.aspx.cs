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
    public partial class FullUpdateListMasterImport : PageBase
    {
        private string importType = "2";
        private string TypeId = "1";

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
            
            if (!Roles.IsUserInRole("Administrators"))
            {
                chkPrice.Enabled = false;
                chkHaishinDate.Enabled = false;
                chkHaishinEndDate.Enabled = false;
            }

            string sql = "Select Count(*) from SongImport where (Status = '' or Status = '0' or Status is null) and SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "'";
            int count = Func.ParseInt(DbHelper.GetScalar(sql));
            divUpdate.Visible = true;
            btnGetNotExistsID.Visible = false;
            if (count > 0)
            {
                mvldMessage.AddError("既存しない着フル曲IDがあります。CSVﾌｧｲﾙを修正してください");
                btnGetNotExistsID.Visible = true;
                btnRegister.Visible = false;
            }

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

                else if (String.Compare(command, "SortSongTitleYomFullChar") == 0)
                {
                    colName = "SongTitleYomFullChar";
                }

                else if (String.Compare(command, "SortRemoveDateFull") == 0)
                {
                    colName = "RemoveDateFull";
                }
                else if (String.Compare(command, "SortHaishinEndDate") == 0)
                {
                    colName = "HaishinEndDate";
                }

                else if (String.Compare(command, "SortPrice") == 0)
                {
                    colName = "Price";
                }

                else if (String.Compare(command, "SortIsrcNo") == 0)
                {
                    colName = "IsrcNo";
                }

                else if (String.Compare(command, "SortPoint1") == 0)
                {
                    colName = "Point1";
                }

                else if (String.Compare(command, "SortSabi1") == 0)
                {
                    colName = "Sabi1";
                }

                else if (String.Compare(command, "SortSabi1End") == 0)
                {
                    colName = "Sabi1End";
                }

                else if (String.Compare(command, "SortPoint2") == 0)
                {
                    colName = "Point2";
                }

                else if (String.Compare(command, "SortSabi2") == 0)
                {
                    colName = "Sabi2";
                }

                else if (String.Compare(command, "SortSabi2End") == 0)
                {
                    colName = "Sabi2End";
                }

                else if (String.Compare(command, "SortPoint3") == 0)
                {
                    colName = "Point3";
                }

                else if (String.Compare(command, "SortSabi3") == 0)
                {
                    colName = "Sabi3";
                }

                else if (String.Compare(command, "SortSabi3End") == 0)
                {
                    colName = "Sabi3End";
                }

                else if (String.Compare(command, "SortFlag") == 0)
                {
                    colName = "Flag";
                }

                else if (String.Compare(command, "SortFullFileName") == 0)
                {
                    colName = "FullFineName";
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

                    Func.SetGridTextValue(item, "ltrSongId", Func.ParseString(row["SongId"]));
                    Func.SetGridTextValue(item, "ltrSongTitle", Func.ParseString(row["SongTitle"]));
                    Func.SetGridTextValue(item, "ltrSongTitleReading", Func.ParseString(row["SongTitleReading"]));
                    Func.SetGridTextValue(item, "ltrRemoveDateFull", Func.FormatYmd(row["RemoveDateFull"]));
                    Func.SetGridTextValue(item, "ltrHaishinEndDate", Func.FormatYmd(row["HaishinEndDate"]));
                    Func.SetGridTextValue(item, "ltrPrice", Func.ParseString(row["Price"]));
                    Func.SetGridTextValue(item, "ltrIsrcNo", Func.ParseString(row["IsrcNo"]));
                    Func.SetGridTextValue(item, "ltrPoint1", Func.ParseString(row["Point1"]));
                    Func.SetGridTextValue(item, "ltrSabi1", Func.ParseString(row["Sabi1"]));
                    Func.SetGridTextValue(item, "ltrSabi1End", Func.ParseString(row["Sabi1End"]));
                    Func.SetGridTextValue(item, "ltrPoint2", Func.ParseString(row["Point2"]));
                    Func.SetGridTextValue(item, "ltrSabi2", Func.ParseString(row["Sabi2"]));
                    Func.SetGridTextValue(item, "ltrSabi2End", Func.ParseString(row["Sabi2End"]));
                    Func.SetGridTextValue(item, "ltrPoint3", Func.ParseString(row["Point3"]));
                    Func.SetGridTextValue(item, "ltrSabi3", Func.ParseString(row["Sabi3"]));
                    Func.SetGridTextValue(item, "ltrSabi3End", Func.ParseString(row["Sabi3End"]));
                    Func.SetGridTextValue(item, "ltrFlag", Func.ParseString(row["Flag"]));
                    Func.SetGridTextValue(item, "ltrFullFileName", Func.ParseString(row["FullFileName"]));

                    Literal tmp = null;
                    if ("0".Equals(Func.ParseString(row["Status"])) || "".Equals(Func.ParseString(row["Status"])))
                    {
                        tmp = (Literal)item.FindControl("ltrBg");
                        tmp.Text = " style=\"background-color:Orange;\" ";
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
                        if (colName.EndsWith("SongTitleYomFullChar"))
                        {
                            Func.SetGridLinkValue(item, "lnkSongTitleReading", "曲名ﾖﾐ" + img);
                        }
                        if (colName.EndsWith("RemoveDateFull"))
                        {
                            Func.SetGridLinkValue(item, "lnkRemoveDateFull", "配信日" + img);
                        }
                        if (colName.EndsWith("HaishinEndDate"))
                        {
                            Func.SetGridLinkValue(item, "lnkHaishinEndDate", "配信停止日" + img);
                        }
                        if (colName.EndsWith("Price"))
                        {
                            Func.SetGridLinkValue(item, "lnkPrice", "Price" + img);
                        }
                        if (colName.EndsWith("IsrcNo"))
                        {
                            Func.SetGridLinkValue(item, "lnkIsrcNo", "ISRC" + img);
                        }
                        if (colName.EndsWith("Point1"))
                        {
                            Func.SetGridLinkValue(item, "lnkPoint1", "切り出し表記1" + img);
                        }
                        if (colName.EndsWith("Sabi1"))
                        {
                            Func.SetGridLinkValue(item, "lnkSabi1", "cut開始1" + img);
                        }
                        if (colName.EndsWith("Sabi1End"))
                        {
                            Func.SetGridLinkValue(item, "lnkSabi1End", "cut終了1" + img);
                        }
                        if (colName.EndsWith("Point2"))
                        {
                            Func.SetGridLinkValue(item, "lnkPoint2", "切り出し表記2" + img);
                        }
                        if (colName.EndsWith("Sabi2"))
                        {
                            Func.SetGridLinkValue(item, "lnkSabi2", "cut開始2" + img);
                        }
                        if (colName.EndsWith("Sabi2End"))
                        {
                            Func.SetGridLinkValue(item, "lnkSabi2End", "cut終了2" + img);
                        }
                        if (colName.EndsWith("Point3"))
                        {
                            Func.SetGridLinkValue(item, "lnkPoint3", "切り出し表記3" + img);
                        }
                        if (colName.EndsWith("Sabi3"))
                        {
                            Func.SetGridLinkValue(item, "lnkSabi3", "cut開始3" + img);
                        }
                        if (colName.EndsWith("Sabi3End"))
                        {
                            Func.SetGridLinkValue(item, "lnkSabi3End", "cut終了3" + img);
                        }
                        if (colName.EndsWith("Flag"))
                        {
                            Func.SetGridLinkValue(item, "lnkFlag", "fineFlag" + img);
                        }
                        if (colName.EndsWith("FullFileName"))
                        {
                            Func.SetGridLinkValue(item, "lnkFullFileName", "ファイル名" + img);
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
                                " SongTitleYomFullChar '曲名ヨミ(全角）' ,SongTitleReading '曲名ﾖﾐ(半角)' , RemoveDateFull '解禁日（フル）' ,RemoveDateUta '解禁日（うた）' , " +
                                " RemoveDateVideo '解禁日（ﾋﾞﾃﾞｵｸﾘｯﾌﾟ）' ,HaishinEndDate 配信停止日 ,HaishinEndDateUta '配信停止日（うた）' ,HaishinEndDateVideo '配信停止日（ビデオ）' ,ArtistId ｱｰﾃｨｽﾄID , " +
                                " ArtistName 'ｱｰﾃｨｽﾄ名(半角)' ,ArtistNameReading 'ｱｰﾃｨｽﾄ名ﾖﾐ(全角)' ,ArtistNameReadingFull 'ｱｰﾃｨｽﾄ名ﾖﾐ(半角)' ,GenreId ｼﾞｬﾝﾙ ,AlbumId ｱﾙﾊﾞﾑID , " +
                                " AlbumTitle 'ｱﾙﾊﾞﾑ名(半角)' ,AlbumTitleReading 'ｱﾙﾊﾞﾑ名ヨミ(全角)' ,AlbumTitleReadingFull 'ｱﾙﾊﾞﾑ名ﾖﾐ(半角)' ,AlbumCdId CD品番 ,SongArranger 収録曲順 , " +
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
        protected void btnGetNotExistsID_Click(object sender, EventArgs e)
        {
            string csv = "";
            DataSet dsSite = new DataSet();
            DataSet ds = new DataSet();
            string kind = "";
            kind = "SongImport";

            try
            {
                string select = " SongId WID";
                ds = DbHelper.GetMstrData(kind, select, "SessionId = '" + Session.SessionID + "' and (Status = '0' or Status = '' or Status is null)  and ImportType = '" + importType + "'", "0", "");

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

                string set = "";
                if (chkTitle.Checked)
                {
                    set += ",Title = SI.SongTitle";
                }
                if (chkFileName.Checked)
                {
                    set += ",FileName = SI.FullFileName";
                }
                if (chkIsrcNo.Checked)
                {
                    set += ",IsrcNo=SI.IsrcNo";
                }
                if (chkPrice.Checked)
                {
                    set += ",Rate=SI.HbunRitsu, Price=SI.Price, PriceNoTax=SI.PriceNoTax, BuyUnique=SI.BuyUnique, CopyrightFeeUnique=SI.CopyrightFeeUnique, KDDICommissionUnique=SI.KDDICommissionUnique, ProfitUnique=SI.ProfitUnique";
                }
                if (chkHaishinDate.Checked)
                {
                    set += ",HaishinDate=SI.RemoveDateFull";
                }
                if (chkHaishinEndDate.Checked)
                {
                    set += ",HaishinEndDate=SI.HaishinEndDate";
                }
                if (chkFlag.Checked)
                {
                    set += " ,Flag=SI.Flag";
                }
                if (chkPoint1.Checked)
                {
                    set += ",Point1=SI.Point1";
                }
                if (chksabi1.Checked)
                {
                    set += ",sabi1=RIGHT('0000000' + SI.sabi1, 7)";
                }
                if (chkSabi1End.Checked)
                {
                    set += ",Sabi1End=RIGHT('0000000' + SI.Sabi1End, 7)";
                }
                if (chkPoint2.Checked)
                {
                    set += ",Point2=SI.Point2";
                }
                if (chkSabi2.Checked)
                {
                    set += ",Sabi2=RIGHT('0000000' + SI.Sabi2, 7)";
                }
                if (chkSabi2End.Checked)
                {
                    set += ",Sabi2End=RIGHT('0000000' + SI.Sabi2End, 7)";
                }
                if (chkPoint3.Checked)
                {
                    set += ",Point3=SI.Point3";
                }
                if (chkSabi3.Checked)
                {
                    set += ",Sabi3=RIGHT('0000000' + SI.Sabi3, 7)";
                }
                if (chkSabi3End.Checked)
                {
                    set += ",Sabi3End=RIGHT('0000000' + SI.Sabi3End, 7)";
                }

                if ("".Equals(set) && !(chkIVT.Checked || chkAlphabetTitle.Checked))
                {
                    mvldMessage.AddError("更新項目を選んでください。");
                }
                DbHelper.ExecuteNonQuery(   "INSERT INTO SongLog " +
                                            "       (SongMediaId,TypeId,Price,Rate,ContractorId,CopyrightOrg,HaishinDate,HaishinEndDate,IsrcNo,DelFlag,BaseDataUpdated,BaseDataUpdator,CommonDataUpdated,CommonDataUpdator,Created,Creator,Comment) " +
                                            "Select " +
                                            "        SI.SongMediaId,'"+ TypeId +"',SM.Price,SM.Rate,S.ContractorId,S.CopyrightOrg,SM.HaishinDate,SM.HaishinEndDate,SM.IsrcNo,'0',S.Updated,S.Updator,SM.Updated,SM.Updator,'" + created + "', '" + creator + "' , '着フル更新一括'" +
                                            "From Song S, SongMedia SM, SongImport SI " +
                                            "Where S.SongId = SM.SongId and SI.SongId = SM.SongMediaId and SM.TypeId = '" + TypeId + "' and Si.SessionId = '" + Session.SessionID + "' and Si.ImportType = '" + importType + "' ");
                //更新
                string update = " Update Song set ReserveFlag='1', Updated='" + updated + "', Updator='" + updator + "', Created='" + created + "', Creator='" + creator + "' " + set + (chkIVT.Checked ? ",IVT=SI.IVT" : "") + (chkAlphabetTitle.Checked ? ",AlphabetTitle=SI.AlphabetTitle" : "") +
                                " FROM Song S, SongMedia SM,SongImport SI where SM.SongId = S.SongId and SM.SongMediaId = SI.SongId and SM.TypeId = '"+ TypeId +"' and Si.SessionId = '" + Session.SessionID + "' and Si.ImportType = '" + importType + "'";
                DbHelper.ExecuteNonQuery(update);

                //更新
                update = " Update SongMedia set ReserveFlag='1',DelFlag='0',Updated='" + updated + "' , Updator='" + updator + "', Created='" + created + "', Creator='" + creator + "' " + set +
                         " FROM SongMedia SM,SongImport SI where SM.SongMediaId = SI.SongId and SM.TypeId = '"+ TypeId +"' and Si.SessionId = '" + Session.SessionID + "' and Si.ImportType = '" + importType + "'";
                DbHelper.ExecuteNonQuery(update);

                update = " Update SongMedia set ImodeFlag='1',SBankFlag='1',FineFlag='1',ImodeNoTrialFlag='1',SBankNoTrialFlag='1',EzwebNoTrialFlag='1',DelFlag='0',Updated='" + updated + "' , Updator='" + updator + "', Created='" + created + "', Creator='" + creator + "' " +
                                " FROM SongMedia SM,SongImport SI where SM.SongMediaId = SI.SongId and SM.TypeId = '" + TypeId + "' and Si.SessionId = '" + Session.SessionID + "' and Si.ImportType = '" + importType + "' and Replace(CONVERT(varchar, SM.HaishinDate, 111),'/','') > '" + DateTime.Now.ToString("yyyyMMdd") + "'";
                DbHelper.ExecuteNonQuery(update);

                update = " Update SongSite Set ImodeFlag='1',SBankFlag='1',FineFlag='1', ImodeNoTrialFlag='1',SBankNoTrialFlag='1',EzwebNoTrialFlag='1', " +
                                " Updated='" + updated + "' , Updator='" + updator + "', Created='" + created + "', Creator='" + creator + "' " + (chkTitle.Checked ? ", Title = SI.SongTitle" : "") +
                                " FROM SongSite, SongMedia SM, SongImport SI where SM.SongMediaId = SI.SongId and SongSite.SongId = SI.SongId and SM.TypeId = '" + TypeId + "' and SI.SessionId = '" + Session.SessionID + "' and Si.ImportType = '" + importType + "' and Replace(CONVERT(varchar, SM.HaishinDate, 111),'/','') > '" + DateTime.Now.ToString("yyyyMMdd") + "'";
                DbHelper.ExecuteNonQuery(update);

                update = " Update SongMedia Set ReserveFlag = '0',ImodeFlag='0', SBankFlag='0', FineFlag='0',ImodeNoTrialFlag='0',SBankNoTrialFlag='0',EzwebNoTrialFlag='0'," +
                         "                      Updated='" + updated + "' , Updator='" + updator + "', Created='" + created + "', Creator='" + creator + "' " +
                         " From  SongImport, Song where SongImport.SongId = Song.SongId and SessionId = '" + Session.SessionID + "' and SongImport.SongId = SongMedia.SongMediaId and Song.ContractorId in ('KY0092','KY0111','KY0039','KY0261') and SongImport.ImportType = '" + importType + "'";
                DbHelper.ExecuteNonQuery(update);

                update = " Update SongSite Set ImodeNoTrialFlag='0',SBankNoTrialFlag='0',EzwebNoTrialFlag='0', " +
                        " Updated='" + updated + "' , Updator='" + updator + "', Created='" + created + "', Creator='" + creator + "' " + 
                        " FROM SongSite, Song S, SongImport SI where SongSite.SongId = SI.SongID and SI.SongId = S.SongId and SessionId = '" + Session.SessionID + "' and S.ContractorId in ('KY0092','KY0111','KY0039') and SI.ImportType = '" + importType + "'";
                DbHelper.ExecuteNonQuery(update);

                DbHelper.ExecuteNonQuery("Delete From SongImport where SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "'");
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
