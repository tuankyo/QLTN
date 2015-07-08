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
using Gnt.Data;
using Man.Utils;
using Gnt.Data.DBCommand;
using System.Data.SqlClient;
using BusinessObjects;
using Gnt.Transaction;
using System.Text;

namespace Man.MasterImport
{
    public partial class ListUpdateTextImport : PageBase
    {
        public string[,] resultSync = new string[20, 3];
        private bool commonUpdateFlg = false;

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
        /// List data
        /// </summary>
        private void ShowData()
        {
            SqlDatabase db = new SqlDatabase();
            string sql = string.Empty;
            if (!Func.IsValid(ListSortExpression))
            {
                ListSortExpression = "Id";
                ListSortDirection = SortDirection.Descending;
            }
            try
            {
                //件数を数える
                sql += " SELECT COUNT(*) ";
                sql += " FROM SongAlbumArtistTmp ";
                sql += " WHERE (ID IS NOT NULL) and SessionId = '" + Session.SessionID + "' and ImportType = '" + hidImportType.Value + "'";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //検索条件で取得情報のSQL文を作成する
                sql = " SELECT *,ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum  ";
                sql += " FROM SongAlbumArtistTmp ";
                sql += " WHERE (ID IS NOT NULL) and SessionId = '" + Session.SessionID + "' and ImportType = '" + hidImportType.Value + "'";
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
        /// Init values
        /// </summary>
        protected override void DoInit()
        {
            btnUpdate.OnClientClick = "return confirm('更新開始です。よろしいですか？');";
            /*
            DbHelper.FillList(lstSiteSend, "SELECT Id, Name FROM Site where DelFlag=0 and TypeId = '"+ hidTypeId.Value +"' ", "Name", "Id");
            lstSiteSend.Items.Add(new ListItem("全サイト", "0"));
            Func.SortByValue(lstSiteSend);
            lstSiteSend.Items[0].Selected = true;
             */
        }

        protected override void DoPost()
        {
            //Handle postback from popup
            string eventTarget = Func.ParseString(Request["__EVENTTARGET"]);
            string eventArgument = Func.ParseString(Request["__EVENTARGUMENT"]);
            if (eventTarget.StartsWith("PopUp"))
            {
                if (eventTarget == "PopUpEditAlbum")
                {
                    ShowData();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidImportType.Value = Session["ImportType"].ToString();

                lblFolderPath.Text = Func.ParseString((string)Session["FolderPath"]);

                PopupWidth = 850;
                PopupHeight = 450;
                PopupName = "EditAlbum";

                ShowData();
            }
        }
        /// <summary>
        /// ページ押下処理
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void pager_PageIndexChanged(object source, PagerPageChangedEventArgs args)
        {
            ShowData();
        }
        /// <summary>
        /// グリッドにボタン押下処理
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string command = e.CommandName;
            string colName = string.Empty;
            if (command.StartsWith("Sort"))
            {
                if (string.Compare(command, "SortId") == 0)
                {
                    colName = "Id";
                }
                else if (string.Compare(command, "SortTitle") == 0)
                {
                    colName = "Title";
                }
                else if (string.Compare(command, "SortArtistId") == 0)
                {
                    colName = "ArtistId";
                }
                else if (string.Compare(command, "SortArtistName") == 0)
                {
                    colName = "ArtistName";
                }
                else if (string.Compare(command, "SortAlbumId") == 0)
                {
                    colName = "AlbumId";
                }
                else if (string.Compare(command, "SortAlbumName") == 0)
                {
                    colName = "AlbumName";
                }
                else if (string.Compare(command, "SortContractorId") == 0)
                {
                    colName = "ContractorId";
                }
                else if (string.Compare(command, "SortContractorName") == 0)
                {
                    colName = "ContractorName";
                }
                else if (string.Compare(command, "SortPRText") == 0)
                {
                    colName = "PRText";
                }
                else if (string.Compare(command, "SortCdID") == 0)
                {
                    colName = "CDID";
                }
                else if (string.Compare(command, "SortSaleDate") == 0)
                {
                    colName = "SaleDate";
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
        /// グリッドのコンテンツを設定する処理
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

                    Func.SetGridTextValue(item, "ltrId", Func.ParseString(row["Id"]));
                    Func.SetGridTextValue(item, "ltrTitle", Func.ParseString(row["Title"]));
                    Func.SetGridTextValue(item, "ltrArtistId", Func.ParseString(row["ArtistId"]));
                    Func.SetGridTextValue(item, "ltrArtistName", Func.ParseString(row["ArtistName"]));
                    Func.SetGridTextValue(item, "ltrAlbumId", Func.ParseString(row["AlbumId"]));
                    Func.SetGridTextValue(item, "ltrAlbumName", Func.ParseString(row["AlbumName"]));
                    Func.SetGridTextValue(item, "ltrContractorId", Func.ParseString(row["ContractorId"]));
                    Func.SetGridTextValue(item, "ltrContractorName", Func.ParseString(row["ContractorName"]));
                    Func.SetGridTextValue(item, "ltrPRText", Func.ParseString(row["PRText"]));
                    Func.SetGridTextValue(item, "ltrCDID", Func.ParseString(row["CDID"]));
                    Func.SetGridTextValue(item, "ltrSaleDate", Func.FormatYmd(row["SaleDate"].ToString().Replace("/","")));
                    Func.SetGridTextValue(item, "ltrComment", Func.ParseString(row["Comment"]));
                    Func.SetGridTextValue(item, "ltrProfile", Func.ParseString(row["Profile"]));
                    // Binh add start
                    Func.SetGridTextValue(item, "ltrGenre01", Func.ParseString(row["GenreId01"]));
                    Func.SetGridTextValue(item, "ltrGenre02", Func.ParseString(row["GenreId02"]));
                    // Binh add end
                    Func.SetGridTextValue(item, "ltrJacket", Func.ParseString(row["JacketFlag"]));

                    HtmlTableCell tdTitle = (HtmlTableCell)item.FindControl("tdTitle");
                    HtmlTableCell tdArtistId = (HtmlTableCell)item.FindControl("tdArtistId");
                    HtmlTableCell tdArtistName = (HtmlTableCell)item.FindControl("tdArtistName");
                    HtmlTableCell tdAlbumId = (HtmlTableCell)item.FindControl("tdAlbumId");
                    HtmlTableCell tdAlbumName = (HtmlTableCell)item.FindControl("tdAlbumName");
                    HtmlTableCell tdContractorId = (HtmlTableCell)item.FindControl("tdContractorId");
                    HtmlTableCell tdContractorName = (HtmlTableCell)item.FindControl("tdContractorName");
                    HtmlTableCell tdPRText = (HtmlTableCell)item.FindControl("tdPRText");
                    HtmlTableCell tdCDID = (HtmlTableCell)item.FindControl("tdCDID");
                    HtmlTableCell tdSaleDate = (HtmlTableCell)item.FindControl("tdSaleDate");
                    HtmlTableCell tdComment = (HtmlTableCell)item.FindControl("tdComment");
                    HtmlTableCell tdProfile = (HtmlTableCell)item.FindControl("tdProfile");
                    // Binh add start
                    HtmlTableCell tdGenre01 = (HtmlTableCell)item.FindControl("tdGenre01");
                    HtmlTableCell tdGenre02 = (HtmlTableCell)item.FindControl("tdGenre02");
                    // Binh add end
                    HtmlTableCell tdJacket = (HtmlTableCell)item.FindControl("tdJacket");

                    tdTitle.Visible = false;
                    tdArtistId.Visible = false;
                    tdArtistName.Visible = false;
                    tdAlbumId.Visible = false;
                    tdAlbumName.Visible = false;
                    tdContractorId.Visible = false;
                    tdContractorName.Visible = true;
                    tdPRText.Visible = false;
                    tdCDID.Visible = false;
                    tdSaleDate.Visible = false;
                    tdComment.Visible = false;
                    tdProfile.Visible = false;
                    // Binh add start
                    tdGenre01.Visible = false;
                    tdGenre02.Visible = false;
                    // Binh add end
                    tdJacket.Visible = false;

                    if ("1".Equals(hidImportType.Value))
                    {
                        tdTitle.Visible = true;
                        tdArtistId.Visible = true;
                        tdArtistName.Visible = true;
                        tdAlbumId.Visible = true;
                        tdAlbumName.Visible = true;
                        tdContractorId.Visible = true;
                        //tdContractorName.Visible = true;
                        tdPRText.Visible = true;

                    }
                    else if ("2".Equals(hidImportType.Value))
                    {
                        //tdTitle.Visible = true;
                        tdAlbumName.Visible = true;
                        tdCDID.Visible = true;
                        tdSaleDate.Visible = true;
                        tdComment.Visible = true;
                        tdArtistId.Visible = true;
                        tdArtistName.Visible = true;
                        tdJacket.Visible = true;
                    }
                    else if ("3".Equals(hidImportType.Value))
                    {
                        tdArtistName.Visible = true;
                        tdProfile.Visible = true;
                        // Binh add start
                        tdGenre01.Visible = true;
                        tdGenre02.Visible = true;
                        // Binh add end
                    }
                }
                else if (item.ItemType == ListItemType.Header)
                {
                    HtmlTableCell thTitle = (HtmlTableCell)item.FindControl("thTitle");
                    HtmlTableCell thArtistId = (HtmlTableCell)item.FindControl("thArtistId");
                    HtmlTableCell thArtistName = (HtmlTableCell)item.FindControl("thArtistName");
                    HtmlTableCell thAlbumId = (HtmlTableCell)item.FindControl("thAlbumId");
                    HtmlTableCell thAlbumName = (HtmlTableCell)item.FindControl("thAlbumName");
                    HtmlTableCell thContractorId = (HtmlTableCell)item.FindControl("thContractorId");
                    HtmlTableCell thContractorName = (HtmlTableCell)item.FindControl("thContractorName");
                    HtmlTableCell thPRText = (HtmlTableCell)item.FindControl("thPRText");
                    HtmlTableCell thCDID = (HtmlTableCell)item.FindControl("thCDID");
                    HtmlTableCell thSaleDate = (HtmlTableCell)item.FindControl("thSaleDate");
                    HtmlTableCell thComment = (HtmlTableCell)item.FindControl("thComment");
                    HtmlTableCell thProfile = (HtmlTableCell)item.FindControl("thProfile");
                    // Binh add start
                    HtmlTableCell thGenre01 = (HtmlTableCell)item.FindControl("thGenre01");
                    HtmlTableCell thGenre02 = (HtmlTableCell)item.FindControl("thGenre02");
                    // Binh add end
                    HtmlTableCell thJacket = (HtmlTableCell)item.FindControl("thJacket");

                    thTitle.Visible = false;
                    thArtistId.Visible = false;
                    thArtistName.Visible = false;
                    thAlbumId.Visible = false;
                    thAlbumName.Visible = false;
                    thContractorId.Visible = false;
                    thContractorName.Visible = true;
                    thPRText.Visible = false;
                    thCDID.Visible = false;
                    thSaleDate.Visible = false;
                    thComment.Visible = false;
                    thProfile.Visible = false;
                    // Binh add start
                    thGenre01.Visible = false;
                    thGenre02.Visible = false;
                    // Binh add end
                    thJacket.Visible = false;

                    LinkButton tmp = (LinkButton)item.FindControl("lnkId");

                    if ("1".Equals(hidImportType.Value))
                    {
                        tmp.Text = "曲ID";
                        thTitle.Visible = true;
                        thArtistId.Visible = true;
                        thArtistName.Visible = true;
                        thAlbumId.Visible = true;
                        thAlbumName.Visible = true;
                        thContractorId.Visible = true;
                        //thContractorName.Visible = true;
                        thPRText.Visible = true;

                    }
                    else if ("2".Equals(hidImportType.Value))
                    {
                        tmp.Text = "アルバムID";
                        thAlbumName.Visible = true;
                        thCDID.Visible = true;
                        thSaleDate.Visible = true;
                        thComment.Visible = true;
                        thArtistId.Visible = true;
                        thArtistName.Visible = true;
                        thJacket.Visible = true;
                    }
                    else if ("3".Equals(hidImportType.Value))
                    {
                        tmp.Text = "アーティストID";
                        thArtistName.Visible = true;
                        thProfile.Visible = true;
                        // Binh add start
                        thGenre01.Visible = true;
                        thGenre02.Visible = true;
                        // Binh add end
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

                        if (colName.EndsWith("Title"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkTitle");
                            link.Text = "曲タイトル" + img;
                        }
                        else if (colName.EndsWith("ArtistId"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkArtistId");
                            link.Text = "アーティストID" + img;
                        }
                        else if (colName.EndsWith("ArtistName"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkArtistName");
                            link.Text = "アーティスト名" + img;
                        }
                        else if (colName.EndsWith("AlbumId"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkAlbumId");
                            link.Text = "アルバムID" + img;
                        }
                        else if (colName.EndsWith("AlbumName"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkAlbumName");
                            link.Text = "アルバム名" + img;
                        }
                        else if (colName.EndsWith("ContractorId"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkContractorId");
                            link.Text = "契約者ID" + img;
                        }
                        else if (colName.EndsWith("ContractorName"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkContractorName");
                            link.Text = "契約者名" + img;
                        }
                        else if (colName.EndsWith("PRText"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkPRText");
                            link.Text = "PRText" + img;
                        }
                        else if (colName.EndsWith("CDID"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkCdID");
                            link.Text = "CdID" + img;
                        }
                        else if (colName.EndsWith("SaleDate"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkSaleDate");
                            link.Text = "発売日" + img;
                        }
                        if (colName.EndsWith("Id"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkId");
                            if ("1".Equals(hidImportType.Value))
                            {
                                link.Text = "曲ID" + img;
                            }
                            else if ("2".Equals(hidImportType.Value))
                            {
                                link.Text = "アルバムID" + img;
                            }
                            else if ("3".Equals(hidImportType.Value))
                            {
                                link.Text = "アーティストID" + img;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }

        protected string getIds()
        {
            string Ids = "";
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                CheckBox myCheckbox = (CheckBox)rptList.Items[i].Controls[1];
                if (myCheckbox != null && myCheckbox.Checked == true)
                {
                    Literal tmp = (Literal)rptList.Items[i].Controls[3];
                    Ids += "," + "'" + tmp.Text + "'";
                }
            }
            return Ids;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "";
                if ("1".Equals(hidImportType.Value))
                {
                    sql = "Update Song Set PRText = SongAlbumArtistTmp.PRText, Updator = SongAlbumArtistTmp.Updator , Updated = SongAlbumArtistTmp.Updated From Song, SongAlbumArtistTmp where Song.SongId = SongAlbumArtistTmp.Id and SessionId = '" + Session.SessionID + "' and SongAlbumArtistTmp.ImportType = '" + hidImportType.Value + "'";
                    DbHelper.ExecuteNonQuery(sql);

                    sql = "Update SongMedia Set PRText = SongAlbumArtistTmp.PRText, Updator = SongAlbumArtistTmp.Updator , Updated = SongAlbumArtistTmp.Updated From SongMedia, SongAlbumArtistTmp where SongMedia.TypeId in ('1','2') and SongMedia.SongId = SongAlbumArtistTmp.Id and SessionId = '" + Session.SessionID + "' and SongAlbumArtistTmp.ImportType = '" + hidImportType.Value + "'";
                    DbHelper.ExecuteNonQuery(sql);

                    DataSet dsSite = DbHelper.GetSiteData("", "TypeId in ('1','2')");
                    // For Each Site
                    foreach (DataRow drSite in dsSite.Tables[0].Rows)
                    {
                        string siteId = drSite["Id"].ToString();
                        sql = " Update SongSite set PRText = SM.PRText," +
                          " Updator = SM.Updator , Updated = SM.Updated  " +
                          " From SongSite, SongMedia SM, SongAlbumArtistTmp S" +
                          " where SongSite.SongId = SM.SongMediaId and SM.SongId = S.Id and SessionId = '" + Session.SessionID + "' and S.ImportType = '" + hidImportType.Value + "' and SM.TypeId in ('1','2')";
                        DbHelper.ExecuteNonQuery(sql);
                    }
                    //////////////////////////////////////
                }
                else if ("2".Equals(hidImportType.Value))
                {
                    sql = " Update Album Set Comment = SongAlbumArtistTmp.Comment, Updator = SongAlbumArtistTmp.Updator , Updated = SongAlbumArtistTmp.Updated , JacketFlag = SongAlbumArtistTmp.JacketFlag From Album, SongAlbumArtistTmp " +
                          " WHERE Album.AlbumId = SongAlbumArtistTmp.Id and SessionId = '" + Session.SessionID + "' and SongAlbumArtistTmp.ImportType = '" + hidImportType.Value + "'";
                    DbHelper.ExecuteNonQuery(sql);

                    SqlDatabase db = new SqlDatabase();
                    sql = string.Empty;
                    DataSet ds = new DataSet();
                    sql = "Select Distinct Id,SaleDate From SongAlbumArtistTmp where SessionId = '" + Session.SessionID + "' and SongAlbumArtistTmp.ImportType = '" + hidImportType.Value + "'";
                    SqlCommand cm = db.CreateCommand(sql);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    db.Close();

                    ArrayList updateSql = new ArrayList();
                    if (ds.Tables[0] != null)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DataRow dr = ds.Tables[0].Rows[i];
                            string AlbumId = dr["Id"].ToString().Replace("'", "''");
                            string saleDate = Func.FormatYmd(dr["SaleDate"].ToString()).Replace("/", "");

                            updateSql.Add("Update Album Set SaleDate = '" + saleDate + "' where AlbumId = '" + AlbumId + "'");
                        }
                    }
                    for (int i = 0; i < updateSql.Count; i++)
                    {
                        DbHelper.ExecuteNonQuery((string)updateSql[i]);
                    }
                }
                else if ("3".Equals(hidImportType.Value))
                {
                    // Binh update start
                    //sql = "Update Artist Set Profile = SongAlbumArtistTmp.Profile, Updator = SongAlbumArtistTmp.Updator , Updated = SongAlbumArtistTmp.Updated From Artist, SongAlbumArtistTmp where Artist.ArtistId = SongAlbumArtistTmp.Id and SessionId = '" + Session.SessionID + "' and SongAlbumArtistTmp.ImportType = '" + hidImportType.Value + "'";
                    sql = "Update Artist Set Profile = SongAlbumArtistTmp.Profile, GenreId01 = SongAlbumArtistTmp.GenreId01, GenreId02 = SongAlbumArtistTmp.GenreId02, Updator = SongAlbumArtistTmp.Updator , Updated = SongAlbumArtistTmp.Updated From Artist, SongAlbumArtistTmp where Artist.ArtistId = SongAlbumArtistTmp.Id and SessionId = '" + Session.SessionID + "' and SongAlbumArtistTmp.ImportType = '" + hidImportType.Value + "'";
                    // Binh update end
                    DbHelper.ExecuteNonQuery(sql);
                }

                mvldMessage.SetCompleteMessage("更新完了しました。");
                DbHelper.ExecuteNonQuery("Delete SongAlbumArtistTmp where ImportType = '" + hidImportType.Value + "' and SessionId = '" + Session.SessionID + "' ");
                Response.Redirect("../Update/UpdateFinish.aspx", false);
            }
            catch (Exception exc)
            {
                mvldMessage.AddError("エラー：" + exc.Message);
            }
        }
    }
}
