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
    public partial class NewListKaraokeImport : PageBase
    {
        //private string importType = "1";

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
                sql += " SELECT COUNT(*) ";
                sql += " FROM SongMediaKaraokeTmp ";
                sql += " WHERE (SongMediaId IS NOT NULL) and SessionId = '" + Session.SessionID + "'";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //検索条件で取得情報のSQL文を作成する
                sql = " SELECT *,ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum  FROM SongMediaKaraokeTmp ";
                sql += " WHERE (SongMediaId IS NOT NULL) and SessionId = '" + Session.SessionID + "'";

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
                    Func.SetGridTextValue(item, "ltrSongId", Func.ParseString(row["SongId"]));
                    Func.SetGridTextValue(item, "ltrSongMediaId", Func.ParseString(row["SongMediaId"]));
                    Func.SetGridTextValue(item, "ltrTitle", Func.ToolTipByteLen(Func.ParseString(row["Title"]), 10));
                    Func.SetGridTextValue(item, "ltrArtistId", Func.ParseString(row["ArtistId"]));
                    Func.SetGridTextValue(item, "ltrGenreId", Func.ParseString(row["GenreId"]));
                    Func.SetGridTextValue(item, "ltrAlbumId", Func.ParseString(row["AlbumId"]));
                    Func.SetGridTextValue(item, "ltrLabelId", Func.ParseString(row["LabelId"]));
                    Func.SetGridTextValue(item, "ltrContractorId", Func.ParseString(row["ContractorId"]));
                    Func.SetGridTextValue(item, "ltrCopyrightOrg", Func.ParseString(row["CopyrightOrg"]));
                    Func.SetGridTextValue(item, "ltrJasracWorksCode", Func.ParseString(row["JasracWorksCode"]));
                    Func.SetGridTextValue(item, "ltrIsrcNo", Func.ParseString(row["IsrcNo"]));
                    Func.SetGridTextValue(item, "ltrPrice", Func.Currency(row["Price"]));

                    Literal tmp = null;
                    if ("".Equals(Func.ParseString(row["Status"])) || "2".Equals(Func.ParseString(row["Status"])))
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
            try
            {
                string updator = Page.User.Identity.Name;
                string creator = Page.User.Identity.Name;
                string created = DateTime.Now.ToString("yyyyMMddHHmmss");
                string updated = DateTime.Now.ToString("yyyyMMddHHmmss");
                
                //新規                
                //Uta                //Video
                string insert = " INSERT INTO SongMedia (SongMediaId,SongId,Title,TypeId,IsrcNo,rate,Price,PRText,HaishinDate,HaishinEndDate,PriceNoTax,BuyUnique,CopyrightFeeUnique,KDDICommissionUnique,ProfitUnique,Flag,DelFlag,Updated , Updator, Created, Creator) " +
                                " Select SongMediaId,SongId,Title,'5',ISRCNo,rate,Price,PRText,HaishinDate,HaishinEndDate,PriceNoTax,BuyUnique,CopyrightFeeUnique,KDDICommissionUnique,ProfitUnique,'1', '0','" + updated + "','" + updator + "','" + created + "','" + creator + "' from  SongMediaKaraokeTmp where SessionId = '" + Session.SessionID + "' ";
                DbHelper.ExecuteNonQuery(insert);


                //ArtistOtherテーブルにアーティストID Karaoke
                insert = "Insert into ArtistOther (ArtistOtherId         ,Name,AlphabetName,NameReading,NameReadingFull,Profile,PhotoFlag,NdFlag,ASite,BSite,AddId,ArtistNameO,DelFlag,Created,Creator,Updated , Updator) " +
                            "         Select  Replace(A.ArtistId,'-','K'),A.Name,A.AlphabetName,A.NameReading,A.NameReadingFull,A.Profile,A.PhotoFlag,A.NdFlag,A.ASite,A.BSite,A.AddId,A.ArtistNameO,A.DelFlag,A.Updated,A.Updator,'" + updated + "','" + updator + "'"+
                            "         From	Artist A " +
                            "         Where	A.ArtistId in (" +
                            "                               Select	S.ArtistId" +
                            "                               From    Song S, SongMediaKaraokeTmp T                 " +
                            "                               Where   S.SongId = T.SongId And SessionId = '" + Session.SessionID + "')" +
                            "         And Replace(A.ArtistId,'-','K') not in (Select ArtistOtherId From ArtistOther)";
                DbHelper.ExecuteNonQuery(insert);

                //ArtistOtherテーブルにアーティストID Karaoke
                insert = "Insert into AlbumOther (  AlbumOtherId              ,Title,TitleReading,TitleReadingFull,Comment,CdId,JacketFlag,PlFlag,SaleDate,DelFlag,Created,Creator,Updated , Updator) " +
                         "              Select      Replace(A.AlbumId,'-','K'),A.Title,A.TitleReading,A.TitleReadingFull,A.Comment,A.CdId,A.JacketFlag,A.PlFlag,A.SaleDate,A.DelFlag,A.Updated,A.Updator,'" + updated + "','" + updator + "'" +
                         "              From        Album A "+
                         "              Where   A.AlbumId in ("+
                         "                                      Select  S.AlbumId"+
                         "                                      From    Song S, SongMediaKaraokeTmp T" +
                         "                                      Where   S.SongId = T.SongId And SessionId = '" + Session.SessionID + "')"+
                         "              And Replace(A.AlbumId,'-','K') not in (Select AlbumOtherId From AlbumOther)";
                DbHelper.ExecuteNonQuery(insert);

                string update = "Update SongMedia Set ArtistOtherId = Replace(S.ArtistId,'-','K'), AlbumOtherId = Replace(S.AlbumId,'-','K')" +
                                "         From    SongMedia SM, Song S, SongMediaKaraokeTmp T" +
                                "         Where   S.SongId = SM.SongId and SM.SongMediaId = T.SongMediaId And SessionId = '" + Session.SessionID + "' and SM.TypeId = '5'";
                DbHelper.ExecuteNonQuery(update);

                DbHelper.ExecuteNonQuery("Delete From SongMediaKaraokeTmp where SessionId = '" + Session.SessionID + "'");
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
