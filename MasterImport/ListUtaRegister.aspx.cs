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
    public partial class ListUtaRegister : PageBase
    {
        public string[,] resultSync = new string[20, 3];
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
                    ListSortExpression = "SongId";
                    ListSortDirection = SortDirection.Descending;
            }
            try
            {
                string siteCon = string.Empty;
                string siteId = string.Empty;

                //件数を数える
                sql += " SELECT COUNT(*) ";
                sql += " FROM FileGetter";
                sql += " WHERE SessionId = '" + Session.SessionID + "' and  FuncId = '"+ hidFuncId.Value +"'";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //検索条件で取得情報のSQL文を作成する
                sql += " SELECT [SessionId],[FuncId],[SongId],[Extension],[FsizeGetter],[CID],[LID],[file01],[fileSize01],[file02],[fileSize02],[file03],[fileSize03],[file04],[fileSize04],[NGflg],[Title],[ExistsFlg],[Selected],ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM FileGetter ";
                sql += " WHERE SessionId = '" + Session.SessionID + "' and  FuncId = '" + hidFuncId.Value + "'";

                //ページによるレコーダを取得する
                sql = " SELECT [SessionId],[FuncId],[SongId],[Extension],[FsizeGetter],[CID],[LID],[file01],[fileSize01],[file02],[fileSize02],[file03],[fileSize03],[file04],[fileSize04],[NGflg],[Title],[ExistsFlg],[Selected],RowNum FROM (" + sql + ") AS TMP ";
                sql += " WHERE RowNum BETWEEN @PageIndex*@PageSize + 1  AND (@PageIndex+1)*@PageSize ORDER BY RowNum ";

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
                hidFuncId.Value = Func.ParseString((int)Session["FuncId"]);
                hidTypeId.Value = (string)Session["TypeId"];
                hidCareer.Value = (string)Session["Career"];

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
                if(string.Compare(command,"SortId")==0)
                {
                    colName = "SongId";
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
            else if (String.Compare(command, "Delete") == 0)
            {
                //削除ボタン押下処理
                try
                {
                    string id = Func.ParseString(e.CommandArgument);
                    string sql = "Delete FileGetter WHERE SongId='" + id + "' and SessionId = '" + Session.SessionID + "' and FuncId = '" + hidFuncId.Value + "' ";
                    if (DbHelper.ExecuteNonQuery(sql) > 0)
                    {
                        ShowData();
                        OperationLogger.WriteInfo(Constants.LogOperationArtistId, Constants.LogActionDeleteId, "削除完了しました。", Page.User.Identity.Name);
                        mvldMessage.SetCompleteMessage("削除完了しました。");
                    }
                    else
                    {
                        OperationLogger.WriteError(Constants.LogOperationArtistId, Constants.LogActionDeleteId, "削除中にエラーが発生しました。", Page.User.Identity.Name);
                        mvldMessage.AddError("削除中にエラーが発生しました。");
                    }
                }
                catch (Exception ex)
                {
                    ApplicationLog.WriteError(ex);
                    OperationLogger.WriteError(Constants.LogOperationArtistId, Constants.LogActionDeleteId, "削除中にエラーが発生しました。", Page.User.Identity.Name);
                }
            }
            else if (String.Compare(command, "ChangeNg") == 0)
            {
                //削除ボタン押下処理
                try
                {
                    string id = Func.ParseString(e.CommandArgument);
                    string sql = "Delete FileGetter WHERE SongId='" + id + "' and SessionId = '" + Session.SessionID + "' and FuncId = '" + hidFuncId.Value + "'";
                    if (DbHelper.ExecuteNonQuery(sql) > 0)
                    {
                        ShowData();
                        OperationLogger.WriteInfo(Constants.LogOperationArtistId, Constants.LogActionDeleteId, "削除完了しました。", Page.User.Identity.Name);
                        mvldMessage.SetCompleteMessage("削除完了しました。");
                    }
                    else
                    {
                        OperationLogger.WriteError(Constants.LogOperationArtistId, Constants.LogActionDeleteId, "削除中にエラーが発生しました。", Page.User.Identity.Name);
                        mvldMessage.AddError("削除中にエラーが発生しました。");
                    }
                }
                catch (Exception ex)
                {
                    ApplicationLog.WriteError(ex);
                    OperationLogger.WriteError(Constants.LogOperationArtistId, Constants.LogActionDeleteId, "削除中にエラーが発生しました。", Page.User.Identity.Name);
                }
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
                    Func.SetGridTextValue(item, "ltrId", Func.ParseString(row["SongId"]));
                    Func.SetGridTextValue(item, "ltrExtension", Func.ParseString(row["Extension"]));

                    Button btnDelete = (Button)item.FindControl("btnDelete");
                    btnDelete.CommandArgument = Func.ParseString(row["SongId"]);
                    btnDelete.OnClientClick = "return confirm('削除開始です。よろしいですか？');";
                }
                else if (item.ItemType == ListItemType.Header)
                {
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

                        if (colName.EndsWith("Id"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkId");
                            link.Text = "ID" + img;
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

        protected void btnSiteUpd_Click(object sender, EventArgs e)
        {
            UpdateMedia();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UpdateMedia()
        {
            try
            {
                string updator = Page.User.Identity.Name;
                string creator = Page.User.Identity.Name;
                string created = DateTime.Now.ToString("yyyyMMddHHmmss");
                string updated = DateTime.Now.ToString("yyyyMMddHHmmss");

                string sql = " Insert into SongMedia(SongId, SongMediaId, TypeId, DelFlag, Created, Creator, Updated, Updator) "+
                             " Select Extension,SongId,'" + hidTypeId.Value + "','0', '" + created + "' , '" + creator + "' , '" + updated + "' , '" + updator + "' from FileGetter where SessionId = '"+ Session.SessionID + "' and FuncId = '"+ hidFuncId.Value +"' ";
                DbHelper.ExecuteNonQuery(sql);
                DbHelper.ExecuteNonQuery("Delete FileGetter where SessionId = '"+ Session.SessionID + "' and FuncId = '"+ hidFuncId.Value +"'");
                Response.Redirect("../MasterImport/ImportFinish.aspx", false);
                mvldMessage.SetCompleteMessage("登録完了しました。");
            }
            catch (Exception exc)
            {
                mvldMessage.AddError("エラーを発生：" + exc.Message);
            }
        }
        /*
        protected void insertFULLtoUTA_EDA(string WID, string EDA, string typeId)
        {

            if ("".Equals(WID) || WID == null)
            {
                return;
            }
            if ("".Equals(EDA) || EDA == null)
            {
                return;
            }

            SongMediaData songMediaData = new SongMediaData();
            ISearchTransaction tran = factory.GetSearchObject(songMediaData);
            tran.Where = songMediaData.ColSongMediaId + "='" + WID + EDA + "' and " + songMediaData.ColDelFlag + "='0'";
            Execute(tran);
            if (!HasError)
            {
                if (tran.Count != 1)
                {
                    SongData songData = new SongData();
                    ISearchTransaction tranExist = factory.GetSearchObject(songData);
                    tranExist.Where = songData.ColSongId + "='" + WID + "' and " + songData.ColDelFlag + "='0'";
                    Execute(tranExist);
                    if (!HasError)
                    {
                        if (tranExist.Count == 1)
                        {
                            SongMediaData data = new SongMediaData();
                            ITransaction tranIns = factory.GetInsertObject(data);
                            data.SongId = WID;
                            data.SongMediaId = WID + EDA;
                            data.DelFlag = "0";
                            data.TypeId = typeId;

                            data.Updator = Page.User.Identity.Name;
                            data.Creator = Page.User.Identity.Name;
                            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                            data.Updated = DateTime.Now.ToString("yyyyMMddHHmmss");

                            Execute(tranIns);
                        }
                    }
                }
            }
        }
        public void syncLog()
        {
            SqlDatabase db = new SqlDatabase();
            SqlCommand cm = db.CreateCommand("SELECT Id, Name FROM Site where DelFlag=0");
            SqlDataReader reader = cm.ExecuteReader();
            int countRec = 0;
            bool skip = false;
            Hashtable siteList = new Hashtable();
            while (reader.Read())
            {
                siteList.Add(reader[0], reader[1]);
            }
            string[,] resultSync;
            resultSync = new string[20, 3];
            resultSync = (string[,])Session["resultSync"];
            string kind = (string)Session["TableName"];
            string key = (string)Session["Key"];
            string action = (string)Session["Action"];
            string lastSynchronizer = Page.User.Identity.Name;
            string lastSynchDated = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string[] lines = new string[100];
            string[] results = new string[3];

            if (resultSync is System.Array)
            {
                for (int i = 0; i < resultSync.GetLength(0); ++i)
                {
                    skip = false;
                    string siteName = "";

                    for (int j = 0; j < resultSync.GetLength(1); ++j)
                    {
                        if (!string.IsNullOrEmpty(resultSync[i, j]))
                        {
                            foreach (DictionaryEntry de in siteList)
                            {
                                if (de.Key.ToString().Equals("" + i))
                                {
                                    siteName = de.Value.ToString();
                                    break;
                                }
                            }

                            lines = resultSync[i, j].Split('\n');
                            foreach (string line in lines)
                            {
                                if (!skip)
                                {
                                    skip = true;
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(line))
                                    {
                                        countRec++;
                                        if ("updatemass".Equals(action.ToLower()) || "updateonly".Equals(action.ToLower()) || "updateonlymass".Equals(action.ToLower()))
                                        {
                                            results = line.Split(',');
                                            string sql = "";
                                            string id = (string)results[0];

                                            string sqlCount = " Select count(*) from " + kind + "Site WHERE " + key + "='" + id + "' and SiteId = '" + i + "'";
                                            int count = DbHelper.GetCount(sqlCount);

                                            if (!"SONG".Equals(kind.ToUpper()))
                                            {
                                                sql = "UPDATE " + kind + "Site set sendResult = '" + (string)results[2] + "'";
                                                sql += " , PrevSynchronizer = LastSynchronizer, PrevSynchDated = LastSynchDated, LastSynchronizer = '" + lastSynchronizer + "' ";
                                                sql += " , LastSynchDated = '" + DateTime.Now.ToString("yyyyMMddHHmmss") + "', DelFlag = '0' WHERE " + key + "='" + id + "' and SiteId = '" + i + "'";
                                                if (count == 0)
                                                {
                                                    sql = "Insert into " + kind + "Site (" + key + ", SiteId, LastSynchronizer, LastSynchDated, SendResult, DelFlag) values('" + id + "', '" + i + "', '" + lastSynchronizer + "', '" + DateTime.Now.ToString("yyyyMMddHHmmss") + "', '" + (string)results[2] + "', '0')";
                                                }
                                            }
                                            else
                                            {
                                                sql = "UPDATE " + kind + "Site set sendResult = '" + (string)results[2] + "'";
                                                sql += " , PrevSynchronizer = LastSynchronizer, PrevSynchDated = LastSynchDated, LastSynchronizer = '" + lastSynchronizer + "' ";
                                                sql += " , Updator = '" + lastSynchronizer + "', Updated = '" + DateTime.Now.ToString("yyyyMMddHHmmss") + "'";
                                                sql += " , LastSynchDated = '" + DateTime.Now.ToString("yyyyMMddHHmmss") + "', DelFlag = '0' WHERE " + key + "='" + id + "' and SiteId = '" + i + "'";

                                                if (count == 0)
                                                {
                                                    sql = "Insert into " + kind + "Site (" + key + ", SiteId, LastSynchronizer, LastSynchDated, SendResult, DelFlag,Creator, Created) values('" + id + "', '" + i + "', '" + lastSynchronizer + "', '" + DateTime.Now.ToString("yyyyMMddHHmmss") + "', '" + (string)results[2] + "', '0','" + lastSynchronizer + "','" + DateTime.Now.ToString("yyyyMMddHHmmss") + "')";
                                                }
                                            }
                                            DbHelper.ExecuteNonQuery(sql);

                                            //編集した値をDBに既存データを取得して設定する。
                                            SynLogData data = new SynLogData();
                                            ITransaction tran = factory.GetInsertObject(data);
                                            data.SynKey = id;
                                            data.SynResult = (string)(results[1] + "(" + results[2] + ")");
                                            data.SynSite = siteName;
                                            data.SynTable = kind;
                                            data.SynPerson = lastSynchronizer;
                                            data.SynDate = lastSynchDated;
                                            data.Action = (string)Session["FuncAction"];

                                            Execute(tran);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            DataSet dsList = (DataSet)Session["InvalidList"];
            if (dsList != null && dsList.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsList.Tables[0].Rows)
                {
                    string id = Func.ParseString(dr[0]);
                    string Name = "invalid status.Can't not update";

                    //編集した値をDBに既存データを取得して設定する。
                    SynLogData data = new SynLogData();
                    ITransaction tran = factory.GetInsertObject(data);
                    data.SynKey = id;
                    data.SynResult = Name;
                    data.SynSite = "";
                    data.SynTable = kind;
                    data.SynPerson = Page.User.Identity.Name;
                    data.SynDate = DateTime.Now.ToString();

                    Execute(tran);
                }
            }
        }
         */ 
    }
}
