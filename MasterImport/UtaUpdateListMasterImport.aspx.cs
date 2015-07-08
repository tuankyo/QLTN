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
    public partial class UtaUpdateListMasterImport : PageBase
    {
        private string importType = "3";
        private string TypeId = "2";

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


            string sql = "Select Count(*) from SongImport where (Status = '0' or Status = '' or Status is null) and SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "'";
            int count = Func.ParseInt(DbHelper.GetScalar(sql));
            divUpdate.Visible = true;
            if (count > 0)
            {
                btnRegister.Visible = false;
            }

            btnGetNotExistsID.Visible = false;
            sql = "Select Count(*) from SongMediaTemp where (Status = '0' or Status = '' or Status is null) and SessionId = '" + Session.SessionID + "' and TypeId = '" + TypeId + "' and ImportType = '" + importType + "'";
            count = Func.ParseInt(DbHelper.GetScalar(sql));
            divUpdate.Visible = true;
            if (count > 0)
            {
                mvldMessage.AddError("既存しない着うた曲IDがあります。CSVﾌｧｲﾙを修正してください");
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
                    Func.SetGridTextValue(item, "ltrSongTitleReading", Func.ToolTipByteLen(Func.ParseString(row["SongTitleReading"]), 10));
                    Func.SetGridTextValue(item, "ltrArtistId", Func.ParseString(row["ArtistId"]));
                    //Func.SetGridTextValue(item, "ltrArtistName", Func.ToolTipByteLen(Func.ParseString(row["ArtistName"]), 10));
                    Func.SetGridTextValue(item, "ltrGenreId", Func.ParseString(row["GenreId"]));
                    Func.SetGridTextValue(item, "ltrAlbumId", Func.ParseString(row["AlbumId"]));
                    //Func.SetGridTextValue(item, "ltrAlbumTitle", Func.ToolTipByteLen(Func.ParseString(row["AlbumTitle"]), 10));
                    //Func.SetGridTextValue(item, "ltrAlbumTitleReadingFull", Func.ToolTipByteLen(Func.ParseString(row["AlbumTitleReadingFull"]), 10));
                    Func.SetGridTextValue(item, "ltrLabelId", Func.ParseString(row["LabelId"]));
                    //Func.SetGridTextValue(item, "ltrLabelName", Func.ToolTipByteLen(Func.ParseString(row["LabelName"]), 10));
                    Func.SetGridTextValue(item, "ltrContractorId", Func.ParseString(row["ContractorId"]));
                    Func.SetGridTextValue(item, "ltrIVT", Func.ParseString(row["IVT"]));
                    Func.SetGridTextValue(item, "ltrIVTType", Func.ParseString(row["IVTType"]));
                    Func.SetGridTextValue(item, "ltrCopyrightOrg", Func.ParseString(row["CopyrightOrg"]));
                    Func.SetGridTextValue(item, "ltrJasracWorksCode", Func.ParseString(row["JasracWorksCode"]));
                    Func.SetGridTextValue(item, "ltrIsrcNo", Func.ParseString(row["IsrcNo"]));

                    LinkButton btnShow = (LinkButton)item.FindControl("btnShow");
                    btnShow.CommandArgument = Func.ParseString(row["SongId"]);

                    Literal tmp = null;
                    if ("0".Equals(Func.ParseString(row["Status"])) || "".Equals(Func.ParseString(row["Status"])))
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
            kind = "SongMediaTemp";

            try
            {
                string select = " SongMediaId WIDm, SongId FID";
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
            kind = "SongMediaTemp";

            try
            {
                string select = " SongMediaId WID, SongId FID";
                ds = DbHelper.GetMstrData(kind, select, "SessionId = '" + Session.SessionID + "' and TypeId = '" + TypeId + "' and (Status = '0' or Status = '' or Status is null) and ImportType = '" + importType + "'", "0", "");

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
                string set = "";
                if (chkTitle.Checked)
                {
                    set += ",Title = SMT.Title";
                }

                if (chkFileName.Checked)
                {
                    set += ",FileName = SMT.FileName";
                }
                if (chkIsrcNo.Checked)
                {
                    set += ",IsrcNo = SMT.ISRCNo";
                }
                if (chkPrice.Checked)
                {
                    set += ",rate=SMT.rate,Price=SMT.Price,PriceNoTax=SMT.PriceNoTax,BuyUnique=SMT.BuyUnique ,CopyrightFeeUnique=SMT.CopyrightFeeUnique ,KDDICommissionUnique=SMT.KDDICommissionUnique,ProfitUnique=SMT.ProfitUnique";
                }
                if (chkHaishinDate.Checked)
                {
                    set += ",HaishinDate=SMT.HaishinDate";
                }
                if (chkHaishinEndDate.Checked)
                {
                    set += ",HaishinEndDate=SMT.HaishinEndDate";
                }
                if ("".Equals(set))
                {
                    mvldMessage.AddError("更新項目を選んでください。");
                    return;
                }
                DbHelper.ExecuteNonQuery(   "INSERT INTO SongLog " +
                                            "       (SongMediaId,TypeId,Price,Rate,ContractorId,CopyrightOrg,HaishinDate,HaishinEndDate,IsrcNo,DelFlag,BaseDataUpdated,BaseDataUpdator,CommonDataUpdated,CommonDataUpdator,Created,Creator,Comment) " +
                                            "Select " +
                                            "        SI.SongMediaId,'" + TypeId + "',SM.Price,SM.Rate,S.ContractorId,S.CopyrightOrg,SM.HaishinDate,SM.HaishinEndDate,SM.IsrcNo,'0',S.Updated,S.Updator,SM.Updated,SM.Updator,'" + created + "', '" + creator + "', '着うた更新一括' " +
                                            "From Song S, SongMedia SM, SongMediaTemp SMT " +
                                            "Where S.SongId = SM.SongId and SM.SongMediaId = SMT.SongMediaId AND SessionId = '" + Session.SessionID + "' AND ImportType = '" + importType + "' and SMT.TypeId = '" + TypeId + "' and SM.TypeId = '" + TypeId + "'");

                //Uta                //Video
                string update = " Update SongMedia Set "+//Flag=SMT.Flag,"+//,ReserveFlag='1',ImodeFlag='1',SBankFlag='1',FineFlag='1'," +
                                " DelFlag='0', Updated ='" + updated + "' , Updator='" + updator + "' , Created='" + created + "' , Creator='" + creator + "' " + set +
                                " FROM SongMedia SM, SongMediaTemp SMT where SM.SongMediaId = SMT.SongMediaId AND SessionId = '" + Session.SessionID + "' AND ImportType = '" + importType + "' and SMT.TypeId = '" + TypeId + "' and SM.TypeId = '" + TypeId + "'";
                DbHelper.ExecuteNonQuery(update);
                      
                //update = " Update SongMedia Set ReserveFlag = '0',ImodeFlag='0', SBankFlag='0', FineFlag='0'" +
                //                " From  SongMediaTemp , Song where SongMediaTemp.SongId = Song.SongId and SessionId = '" + Session.SessionID + "' and SongMediaTemp.SongMediaId = SongMedia.SongMediaId and Song.ContractorId in ('KY0092','KY0111','KY0039') and SongMediaTemp.ImportType = '" + importType + "'";
                //DbHelper.ExecuteNonQuery(update);

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
