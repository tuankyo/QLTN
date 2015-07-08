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
using System.Text;
using Gnt.Data;
using Gnt.Transaction;
using Man.Utils;
using System.Data.SqlClient;
using BusinessObjects;
using Gnt.Data.DBCommand;

namespace Man.MasterImport
{
    public partial class ListOtherFeeImport : PageBase
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
                ListSortExpression = "ExistFlg";
                ListSortDirection = SortDirection.Ascending;
            }
            try
            {
　              //件数を数える
                sql += " SELECT COUNT(*) ";
                sql += " FROM PaymentMonthOtherFeeTmp ";
                sql += " WHERE SessionId = '"+ Session.SessionID +"'";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //検索条件で取得情報のSQL文を作成する
                sql = " SELECT *,ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum  FROM PaymentMonthOtherFeeTmp ";
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
            string sql = "Update PaymentMonthOtherFeeTmp Set ExistFlg = 1 From MST_Flat A, PaymentMonthOtherFeeTmp B Where A.FlatID = B.TenementID + B.FlatID and SessionId = '" + Session.SessionID + "'";
            int count = Func.ParseInt(DbHelper.GetScalar(sql));

            sql = "Select Count(*) from PaymentMonthOtherFeeTmp where SessionId = '" + Session.SessionID + "' and (ExistFlg is null or  ExistFlg = 0) ";
            count = Func.ParseInt(DbHelper.GetScalar(sql));
            divUpdate.Visible = true;
            if (count > 0)
            {
                divUpdate.Visible = true;
                btnRegister.Visible = false;
                mvldMessage.AddError("Thông tin căn hộ không tồn tại, kiểm tra dữ liệu (những dòng màu vàng)");
            }

            btnRegister.OnClientClick = "return confirm('Bạn muốn Lưu Dữ Liệu');";

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
                    Func.SetGridTextValue(item, "ltrFlatId",Func.ParseString(row["FlatId"]));
                    Func.SetGridTextValue(item, "ltrName",Func.ParseString(row["Name"]));
                    Func.SetGridTextValue(item, "ltrMount", Func.ParseString(row["Mount"]));
                    Func.SetGridTextValue(item, "ltrPrice", Func.ParseString(row["Price"]));
                    Func.SetGridTextValue(item, "ltrTotal", Func.ParseString(Func.ParseInt(row["Mount"]) * Func.ParseInt(row["Price"])));

                    string ExistFlg = Func.ParseString(row["ExistFlg"]);
                    Literal tmp = null;
                    if ("0".Equals(ExistFlg) || "".Equals(ExistFlg))
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
        
        
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string delete = " Delete PaymentMonthOtherFee From PaymentMonthOtherFee A, PaymentMonthOtherFeeTmp B Where A.FlatID = B.TenementID + B.FlatID and A.YearMonth = B.YearMonth and SessionId = '" + Session.SessionID + "'";
                DbHelper.ExecuteNonQuery(delete);


                string insert = " INSERT INTO PaymentMonthOtherFee (FlatID, YearMonth, Name, mount, Price, Total, Comment, DelFlag, Created, Creator, Modified, Updator, PayFlag, TenementID)" +
                                " SELECT TenementID + FlatID, YearMonth, Name, mount, Price, mount * Price, Comment, DelFlag, Created, Creator, Modified, Updator, PayFlag, TenementID " +
                                " FROM  PaymentMonthOtherFeeTmp" +
                                " WHERE SessionId = '" + Session.SessionID + "'";
                DbHelper.ExecuteNonQuery(insert);

                DbHelper.ExecuteNonQuery("Delete From PaymentMonthOtherFeeTmp where SessionId = '" + Session.SessionID + "'");
                ShowData();
                importDiv.Visible = false;
                mvldMessage.SetCompleteMessage("Dữ liệu đã lưu, hãy kiểm tra dữ liệu.");
            }
            catch (Exception exc)
            {
                mvldMessage.AddError("Lỗi Phát Sinh：" + exc.Message);
            }
        }
    }   
}
