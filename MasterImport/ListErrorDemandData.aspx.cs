using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gnt.Data;
using System.Data.SqlClient;
using System.Data;
using Man.Utils;
using System.Web.UI.HtmlControls;

namespace Man.MasterImport
{
    public partial class ListErrorDemandData : PageBase
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
            string ImportTableTemp = "";
            if (!Func.IsValid(ListSortExpression))
            {
                ListSortExpression = "BuyInfoId";
                ListSortDirection = SortDirection.Ascending;
            }
            try
            {
                ImportTableTemp = "ErrorDemandDataTempt";
                //件数を数える
                sql += " SELECT COUNT(*) ";
                sql += " FROM " + ImportTableTemp + " ";
                sql += " WHERE SessionId = '" + Session.SessionID + "'";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //検索条件で取得情報のSQL文を作成する
                sql = " SELECT *,ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum  ";
                sql += " FROM " + ImportTableTemp + " ";
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
                //if (hidImportType.Value == "SY0002")
                //{
                rptErrorDemandDataList.DataSource = ds.Tables[0].DefaultView;
                rptErrorDemandDataList.DataBind();

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
                //hidImportType.Value = Session["ImportType"].ToString();

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
        

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string updator = Page.User.Identity.Name;
                string creator = Page.User.Identity.Name;
                string created = DateTime.Now.ToString("yyyyMMddHHmmss");
                string updated = DateTime.Now.ToString("yyyyMMddHHmmss");
                //if ("SY0002".Equals(hidImportType.Value))
                //{
                    string delete = "DELETE FROM ErrorDemandData WHERE ErrorDemandData.id in" +
                        " ( select E.id from ErrorDemandData E, ErrorDemandDataTempt ET " +
                        " where E.BuyInfoId = ET.BuyInfoId and E.DemandErrorProcessDateTime = ET.DemandErrorProcessDateTime)";
                    DbHelper.ExecuteNonQuery(delete);

                    string insert = "INSERT INTO ErrorDemandData " +
                        "(BuyInfoId, SeviceProviderDemandID, ServiceType, CalculateCatagoryName, SeviceProviderCode, SeviceProviderName, SeviceCode, SeviceName, MoneyType,"+
                        " MoneyPattern,MoneyTotalSum,OrderDetailNum,ProductCode,ProductName,ServiceProviderProductCode,ProductQuantity,QuantityUnit,SubscriberId, "+
                        "MoneyStatus,AuBusinessType,MoneyDateTime,ReceiptYearMonthDate,DeleteYearMonthDate,ReplyYearMonth,BranchId,ContentCode,CopyWriterType, "+
                        "ExactCalcProcessYearMonth,DemandErrorProcessDateTime,SessionId,DelFlag,Updated,Updator,Created,Creator ) " +
                        "Select " +
                        "BuyInfoId, SeviceProviderDemandID, ServiceType, CalculateCatagoryName, SeviceProviderCode, SeviceProviderName,SeviceCode,SeviceName,MoneyType, " +
                        "MoneyPattern,MoneyTotalSum,OrderDetailNum,ProductCode,ProductName,ServiceProviderProductCode,ProductQuantity,QuantityUnit,SubscriberId, " +
                        "MoneyStatus,AuBusinessType,MoneyDateTime,ReceiptYearMonthDate,DeleteYearMonthDate,ReplyYearMonth, BranchId,ContentCode,CopyWriterType, " +
                        "ExactCalcProcessYearMonth,DemandErrorProcessDateTime,SessionId,DelFlag,'" + updated + "','" + updator + "','" + created + "','" + creator + "' " +
                        "From ErrorDemandDataTempt E " +
                        "Where E.SessionId = '" + Session.SessionID + "'";
                    DbHelper.ExecuteNonQuery(insert);
                //}
                //else if ("SY0004".Equals(hidImportType.Value))
                //{
                //    string delete = "DELETE FROM CopyrightManageGroupDetailImport WHERE CopyrightManageGroupDetailImport.id in" +
                //        " ( select C.id from CopyrightManageGroupDetailImport C, CopyrightManageGroupDetailImportTemp CT " +
                //        " where C.ConsentNumber = CT.ConsentNumber and C.ActualResultYearMonthOriginal = CT.ActualResultYearMonth and C.CopyrightContractId='SY0004')";
                //    DbHelper.ExecuteNonQuery(delete);

                //    string updateTaxIncludePrice = " UPDATE CopyrightManageGroupDetailImportTemp " + 
                //                                    " SET InfoFee_TaxIncludePrice = B.PriceNoTax " +
                //                                    " FROM CopyrightManageGroupDetailImportTemp C, " +
                //                                    " SongMedia B " +
                //                                    " WHERE SUBSTRING(C.InterfaceKeyCode_NotifyNumber,0,9) = B.SongMediaId " +
                //                                    " AND C.CopyrightContractId = 'SY0004' " +
                //                                    " AND C.SessionId = '" + Session.SessionID + "'";

                //    DbHelper.ExecuteNonQuery(updateTaxIncludePrice);

                //    string insert = "INSERT INTO CopyrightManageGroupDetailImport " +
                //            "(CopyrightContractId,ConsentNumber,InterfaceKeyCode_NotifyNumber,ActualResultYearMonth,ActualResultYearMonthOriginal,ContentBranch_JRCUserCode,SongComposer_UseClassification,WorksCode,IVTType,WorksName," +
                //            "ArtistName,SongWriter_Copyrighter,CollectionRatio,RequestCount_UseCount,UseFeeRate,UseRate,PriceDeductionRate,CalculationTargerCount," +
                //            "UseFeePrice,ContentUnitUseFee,Comment,SessionId,DelFlag,Updated,Updator,Created,Creator, CopyrightContractRate) " +
                //            "Select " +
                //            "CopyrightContractId,ConsentNumber,InterfaceKeyCode_NotifyNumber,(SUBSTRING(ActualResultYearMonth,0,5)+SUBSTRING(ActualResultYearMonth,6,2)),ActualResultYearMonth,ContentBranch_JRCUserCode,SongComposer_UseClassification,WorksCode,IVTType,WorksName," +
                //            "ArtistName,SongWriter_Copyrighter,CollectionRatio,RequestCount_UseCount,UseFeeRate,UseRate,PriceDeductionRate,CalculationTargerCount," +
                //            "UseFeePrice,ContentUnitUseFee,Comment,SessionId,DelFlag,'" + updated + "','" + updator + "','" + created + "','" + creator + "' " + ", CopyrightContractRate " +
                //            "From CopyrightManageGroupDetailImportTemp C " +
                //            "Where C.SessionId = '" + Session.SessionID + "'";
                //    DbHelper.ExecuteNonQuery(insert);
                //}

                mvldMessage.SetCompleteMessage("更新完了しました。");
                //DbHelper.ExecuteNonQuery("Delete SongAlbumArtistTmp where ImportType = '" + hidImportType.Value + "' and SessionId = '" + Session.SessionID + "' ");
                DbHelper.ExecuteNonQuery("Delete ErrorDemandDataTempt where SessionId = '" + Session.SessionID + "' ");
                Response.Redirect("../Payment/ImportFinish.aspx", false);
            }
            catch (Exception exc)
            {
                mvldMessage.AddError("エラー：" + exc.Message);
            }
        }

      

        protected void rptErrorDemandDataList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            try
            {
                if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
                {
                    DataRowView row = (DataRowView)item.DataItem;

                    Func.SetGridTextValue(item, "ltrBuyInfoId", Func.ParseString(row["BuyInfoId"]));
                    Func.SetGridTextValue(item, "ltrSeviceProviderDemandID", Func.ParseString(row["SeviceProviderDemandID"]));
                    Func.SetGridTextValue(item, "ltrServiceType", Func.ParseString(row["ServiceType"]));
                    Func.SetGridTextValue(item, "ltrCalculateCatagoryName", Func.ParseString(row["CalculateCatagoryName"]));
                    Func.SetGridTextValue(item, "ltrSeviceProviderCode", Func.ParseString(row["SeviceProviderCode"]));
                    Func.SetGridTextValue(item, "ltrSeviceProviderName", Func.ParseString(row["SeviceProviderName"]));
                    Func.SetGridTextValue(item, "ltrSeviceCode", Func.ParseString(row["SeviceCode"]));
                    Func.SetGridTextValue(item, "ltrSeviceName", Func.ParseString(row["SeviceName"]));
                    Func.SetGridTextValue(item, "ltrMoneyType", Func.ParseString(row["MoneyType"]));
                    Func.SetGridTextValue(item, "ltrMoneyPattern", Func.ParseString(row["MoneyPattern"]));
                    Func.SetGridTextValue(item, "ltrMoneyTotalSum", Func.ParseString(row["MoneyTotalSum"]));
                    Func.SetGridTextValue(item, "ltrOrderDetailNum", Func.ParseString(row["OrderDetailNum"]));
                    Func.SetGridTextValue(item, "ltrProductCode", Func.ParseString(row["ProductCode"]));
                    Func.SetGridTextValue(item, "ltrProductName", Func.ParseString(row["ProductName"]));
                    Func.SetGridTextValue(item, "ltrServiceProviderProductCode", Func.ParseString(row["ServiceProviderProductCode"]));
                    Func.SetGridTextValue(item, "ltrProductQuantity", Func.ParseString(row["ProductQuantity"]));
                    Func.SetGridTextValue(item, "ltrQuantityUnit", Func.ParseString(row["QuantityUnit"]));
                    Func.SetGridTextValue(item, "ltrSubscriberId", Func.ParseString(row["SubscriberId"]));
                    Func.SetGridTextValue(item, "ltrMoneyStatus", Func.ParseString(row["MoneyStatus"]));
                    Func.SetGridTextValue(item, "ltrAuBusinessType", Func.ParseString(row["AuBusinessType"]));
                    Func.SetGridTextValue(item, "ltrMoneyDateTime", Func.ParseString(row["MoneyDateTime"]));
                    Func.SetGridTextValue(item, "ltrReceiptYearMonthDate", Func.ParseString(row["ReceiptYearMonthDate"]));
                    Func.SetGridTextValue(item, "ltrDeleteYearMonthDate", Func.ParseString(row["DeleteYearMonthDate"]));
                    Func.SetGridTextValue(item, "ltrReplyYearMonth", Func.ParseString(row["ReplyYearMonth"]));
                    Func.SetGridTextValue(item, "ltrBranchId", Func.ParseString(row["BranchId"]));
                    Func.SetGridTextValue(item, "ltrContentCode", Func.ParseString(row["ContentCode"]));
                    Func.SetGridTextValue(item, "ltrCopyWriterType", Func.ParseString(row["CopyWriterType"]));
                    Func.SetGridTextValue(item, "ltrExactCalcProcessYearMonth", Func.ParseString(row["ExactCalcProcessYearMonth"]));
                    Func.SetGridTextValue(item, "ltrDemandErrorProcessDateTime", Func.ParseString(row["DemandErrorProcessDateTime"]));

                    //Func.SetGridTextValue(item, "ltrCollectionRatio", Func.FormatYmd(row["SaleDate"].ToString().Replace("/","")));
                    //HtmlTableCell tdInterfaceKeyCode = (HtmlTableCell)item.FindControl("tdInterfaceKeyCode");
                    //HtmlTableCell tdContentType = (HtmlTableCell)item.FindControl("tdContentType");
                    //HtmlTableCell tdContentBranch = (HtmlTableCell)item.FindControl("tdContentBranch");
                    //HtmlTableCell tdMedleyType = (HtmlTableCell)item.FindControl("tdMedleyType");
                    //HtmlTableCell tdMedleyBranch = (HtmlTableCell)item.FindControl("tdMedleyBranch");
                    //HtmlTableCell tdCollectCode = (HtmlTableCell)item.FindControl("tdCollectCode");
                    //HtmlTableCell tdJasracWorksCode = (HtmlTableCell)item.FindControl("tdJasracWorksCode");
                    //HtmlTableCell tdJasracWorksName = (HtmlTableCell)item.FindControl("tdJasracWorksName");
                    //HtmlTableCell tdSubTitle = (HtmlTableCell)item.FindControl("tdSubTitle");
                    //HtmlTableCell tdSongWriter = (HtmlTableCell)item.FindControl("tdSongWriter");
                    //HtmlTableCell tdSongTranslator = (HtmlTableCell)item.FindControl("tdSongTranslator");
                    //HtmlTableCell tdSongComposer = (HtmlTableCell)item.FindControl("tdSongComposer");
                    //HtmlTableCell tdSongArranger = (HtmlTableCell)item.FindControl("tdSongArranger");
                    //HtmlTableCell tdArtistName = (HtmlTableCell)item.FindControl("tdArtistName");
                    //HtmlTableCell tdInfoFee = (HtmlTableCell)item.FindControl("tdInfoFee");
                    //HtmlTableCell tdIVTType = (HtmlTableCell)item.FindControl("tdIVTType");
                    //HtmlTableCell tdOriginalTranslationType = (HtmlTableCell)item.FindControl("tdOriginalTranslationType");
                    //HtmlTableCell tdImportType = (HtmlTableCell)item.FindControl("tdImportType");
                    //HtmlTableCell tdRequestCount = (HtmlTableCell)item.FindControl("tdRequestCount");
                    //HtmlTableCell tdWorksOutsideType = (HtmlTableCell)item.FindControl("tdWorksOutsideType");
                    //HtmlTableCell tdContentUnitUseFee = (HtmlTableCell)item.FindControl("tdContentUnitUseFee");
                    //HtmlTableCell tdApplyRate = (HtmlTableCell)item.FindControl("tdApplyRate");
                    //HtmlTableCell tdCollectionRatio = (HtmlTableCell)item.FindControl("tdCollectionRatio");
                    //HtmlTableCell tdDeleteAddType = (HtmlTableCell)item.FindControl("tdDeleteAddType");
                    //HtmlTableCell tdRequestCalculateResultCode = (HtmlTableCell)item.FindControl("tdRequestCalculateResultCode");
                    //HtmlTableCell tdConsentNumber = (HtmlTableCell)item.FindControl("tdConsentNumber");
                    //HtmlTableCell tdActualResultYearMonth = (HtmlTableCell)item.FindControl("tdActualResultYearMonth");
                }
                else if (item.ItemType == ListItemType.Header)
                {
                    HtmlTableCell thBuyInfoId = (HtmlTableCell)item.FindControl("thBuyInfoId");
                    HtmlTableCell thSeviceProviderDemandID = (HtmlTableCell)item.FindControl("thSeviceProviderDemandID");

                    HtmlTableCell thServiceType = (HtmlTableCell)item.FindControl("thServiceType");

                    HtmlTableCell thCalculateCatagoryName = (HtmlTableCell)item.FindControl("thCalculateCatagoryName");

                    HtmlTableCell thSeviceProviderCode = (HtmlTableCell)item.FindControl("thSeviceProviderCode");

                    HtmlTableCell thSeviceProviderName = (HtmlTableCell)item.FindControl("thSeviceProviderName");

                    HtmlTableCell thSeviceCode = (HtmlTableCell)item.FindControl("thSeviceCode");

                    HtmlTableCell thSeviceName = (HtmlTableCell)item.FindControl("thSeviceName");

                    HtmlTableCell thMoneyType = (HtmlTableCell)item.FindControl("thMoneyType");

                    HtmlTableCell thMoneyPattern = (HtmlTableCell)item.FindControl("thMoneyPattern");

                    HtmlTableCell thMoneyTotalSum = (HtmlTableCell)item.FindControl("thMoneyTotalSum");

                    HtmlTableCell thOrderDetailNum = (HtmlTableCell)item.FindControl("thOrderDetailNum");

                    HtmlTableCell thProductCode = (HtmlTableCell)item.FindControl("thProductCode");

                    HtmlTableCell thProductName = (HtmlTableCell)item.FindControl("thProductName");

                    HtmlTableCell thServiceProviderProductCode = (HtmlTableCell)item.FindControl("thServiceProviderProductCode");

                    HtmlTableCell thProductQuantity = (HtmlTableCell)item.FindControl("thProductQuantity");

                    HtmlTableCell thQuantityUnit = (HtmlTableCell)item.FindControl("thQuantityUnit");

                    HtmlTableCell thSubscriberId = (HtmlTableCell)item.FindControl("thSubscriberId");

                    HtmlTableCell thMoneyStatus = (HtmlTableCell)item.FindControl("thMoneyStatus");

                    HtmlTableCell thAuBusinessType = (HtmlTableCell)item.FindControl("thAuBusinessType");

                    HtmlTableCell thMoneyDateTime = (HtmlTableCell)item.FindControl("thMoneyDateTime");

                    HtmlTableCell thReceiptYearMonthDate = (HtmlTableCell)item.FindControl("thReceiptYearMonthDate");

                    HtmlTableCell thDeleteYearMonthDate = (HtmlTableCell)item.FindControl("thDeleteYearMonthDate");

                    HtmlTableCell thReplyYearMonth = (HtmlTableCell)item.FindControl("thReplyYearMonth");

                    HtmlTableCell thBranchId = (HtmlTableCell)item.FindControl("thBranchId");

                    HtmlTableCell thContentCode = (HtmlTableCell)item.FindControl("thContentCode");

                    HtmlTableCell thCopyWriterType = (HtmlTableCell)item.FindControl("thCopyWriterType");

                    HtmlTableCell thExactCalcProcessYearMonth = (HtmlTableCell)item.FindControl("thExactCalcProcessYearMonth");

                    HtmlTableCell thDemandErrorProcessDateTime = (HtmlTableCell)item.FindControl("thDemandErrorProcessDateTime");

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

                        if (colName.EndsWith("BuyInfoId"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkBuyInfoId");
                            link.Text = "購入情報番号" + img;
                        }
                        else if (colName.EndsWith("SeviceProviderDemandID"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkSeviceProviderDemandID");
                            link.Text = "サービス提供者側要求ID" + img;
                        }
                        else if (colName.EndsWith("ServiceType"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkServiceType");
                            link.Text = "サービス分類" + img;
                        }
                        else if (colName.EndsWith("CalculateCatagoryName"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkCalculateCatagoryName");
                            link.Text = "集計カテゴリ名" + img;
                        }
                        else if (colName.EndsWith("SeviceProviderCode"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkSeviceProviderCode");
                            link.Text = "サービス提供者コード" + img;
                        }
                        else if (colName.EndsWith("SeviceProviderName"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkSeviceProviderName");
                            link.Text = "サービス提供者名" + img;
                        }
                        else if (colName.EndsWith("SeviceCode"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkSeviceCode");
                            link.Text = "サービスコード" + img;
                        }
                        else if (colName.EndsWith("SeviceName"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkSeviceName");
                            link.Text = "サービス名" + img;
                        }
                        else if (colName.EndsWith("MoneyType"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkMoneyType");
                            link.Text = "課金種別" + img;
                        }
                        else if (colName.EndsWith("MoneyPattern"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkMoneyPattern");
                            link.Text = "課金パターン" + img;
                        }
                        else if (colName.EndsWith("MoneyTotalSum"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkMoneyTotalSum");
                            link.Text = "課金合計金額" + img;
                        }
                        // --------------------------------------------------------------
                        else if (colName.EndsWith("OrderDetailNum"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkOrderDetailNum");
                            link.Text = "注文明細数" + img;
                        }
                        else if (colName.EndsWith("ProductCode"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkProductCode");
                            link.Text = "商品コード" + img;
                        }
                        else if (colName.EndsWith("ProductName"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkProductName");
                            link.Text = "商品名(EZ表示用)" + img;
                        }
                        else if (colName.EndsWith("ServiceProviderProductCode"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkServiceProviderProductCode");
                            link.Text = "サービス提供者側商品コード" + img;
                        }
                        else if (colName.EndsWith("ProductQuantity"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkProductQuantity");
                            link.Text = "商品数量" + img;
                        }
                        else if (colName.EndsWith("QuantityUnit"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkQuantityUnit");
                            link.Text = "数量単位" + img;
                        }
                        else if (colName.EndsWith("SubscriberId"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkSubscriberId");
                            link.Text = "サブスクライバID" + img;
                        }
                        else if (colName.EndsWith("MoneyStatus"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkMoneyStatus");
                            link.Text = "課金ステータス" + img;
                        }
                        else if (colName.EndsWith("AuBusinessType"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkAuBusinessType");
                            link.Text = "au事業者区分" + img;
                        }
                        else if (colName.EndsWith("MoneyDateTime"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkMoneyDateTime");
                            link.Text = "課金日時" + img;
                        }
                        else if (colName.EndsWith("ReceiptYearMonthDate"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkReceiptYearMonthDate");
                            link.Text = "収納年月日" + img;
                        }
                        else if (colName.EndsWith("DeleteYearMonthDate"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkDeleteYearMonthDate");
                            link.Text = "取消年月日" + img;
                        }
                        else if (colName.EndsWith("ReplyYearMonth"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkReplyYearMonth");
                            link.Text = "返戻年月" + img;
                        }
                        else if (colName.EndsWith("BranchId"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkBranchId");
                            link.Text = "枝番" + img;
                        }
                        else if (colName.EndsWith("ContentCode"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkContentCode");
                            link.Text = "コンテンツコード" + img;
                        }
                        else if (colName.EndsWith("CopyWriterType"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkCopyWriterType");
                            link.Text = "債権区分" + img;
                        }
                        else if (colName.EndsWith("ExactCalcProcessYearMonth"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkExactCalcProcessYearMonth");
                            link.Text = "精算処理年月" + img;
                        }
                        else if (colName.EndsWith("DemandErrorProcessDateTime"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkDemandErrorProcessDateTime");
                            link.Text = "請求エラー処理日時" + img;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }

        protected void rptErrorDemandDataList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string command = e.CommandName;
            string colName = string.Empty;
            if (command.StartsWith("Sort"))
            {
                if (string.Compare(command, "SortBuyInfoId") == 0)
                {
                    colName = "BuyInfoId";
                }
                else if (string.Compare(command, "SortSeviceProviderDemandID") == 0)
                {
                    colName = "SeviceProviderDemandID";
                }
                else if (string.Compare(command, "SortServiceType") == 0)
                {
                    colName = "ServiceType";
                }
                else if (string.Compare(command, "SortCalculateCatagoryName") == 0)
                {
                    colName = "CalculateCatagoryName";
                }
                else if (string.Compare(command, "SortSeviceProviderCode") == 0)
                {
                    colName = "SeviceProviderCode";
                }
                else if (string.Compare(command, "SortSeviceProviderName") == 0)
                {
                    colName = "SeviceProviderName";
                }
                else if (string.Compare(command, "SortSeviceCode") == 0)
                {
                    colName = "SeviceCode";
                }
                else if (string.Compare(command, "SortSeviceName") == 0)
                {
                    colName = "SeviceName";
                }
                else if (string.Compare(command, "SortMoneyType") == 0)
                {
                    colName = "MoneyType";
                }
                else if (string.Compare(command, "SortMoneyPattern") == 0)
                {
                    colName = "MoneyPattern";
                }
                else if (string.Compare(command, "SortMoneyTotalSum") == 0)
                {
                    colName = "MoneyTotalSum";
                }
                // -------------------------------------------------------------
                else if (string.Compare(command, "SortOrderDetailNum") == 0)
                {
                    colName = "OrderDetailNum";
                }

                else if (string.Compare(command, "SortProductCode") == 0)
                {
                    colName = "ProductCode";
                }
                else if (string.Compare(command, "SortProductName") == 0)
                {
                    colName = "ProductName";
                }
                else if (string.Compare(command, "SortServiceProviderProductCode") == 0)
                {
                    colName = "ServiceProviderProductCode";
                }
                else if (string.Compare(command, "SortProductQuantity") == 0)
                {
                    colName = "ProductQuantity";
                }
                else if (string.Compare(command, "SortQuantityUnit") == 0)
                {
                    colName = "QuantityUnit";
                }
                else if (string.Compare(command, "SortSubscriberId") == 0)
                {
                    colName = "SubscriberId";
                }
                else if (string.Compare(command, "SortMoneyStatus") == 0)
                {
                    colName = "MoneyStatus";
                }
                else if (string.Compare(command, "SortAuBusinessType") == 0)
                {
                    colName = "AuBusinessType";
                }
                else if (string.Compare(command, "SortMoneyDateTime") == 0)
                {
                    colName = "MoneyDateTime";
                }
                else if (string.Compare(command, "SortReceiptYearMonthDate") == 0)
                {
                    colName = "ReceiptYearMonthDate";
                }
                else if (string.Compare(command, "SortDeleteYearMonthDate") == 0)
                {
                    colName = "DeleteYearMonthDate";
                }
                else if (string.Compare(command, "SortReplyYearMonth") == 0)
                {
                    colName = "ReplyYearMonth";
                }
                else if (string.Compare(command, "SortBranchId") == 0)
                {
                    colName = "BranchId";
                }
                else if (string.Compare(command, "SortContentCode") == 0)
                {
                    colName = "ContentCode";
                }
                else if (string.Compare(command, "SortCopyWriterType") == 0)
                {
                    colName = "CopyWriterType";
                }
                else if (string.Compare(command, "SortExactCalcProcessYearMonth") == 0)
                {
                    colName = "ExactCalcProcessYearMonth";
                }
                else if (string.Compare(command, "SortDemandErrorProcessDateTime") == 0)
                {
                    colName = "DemandErrorProcessDateTime";
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
    }
}
