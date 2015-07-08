/*  
  Author : Nguyen Lam Thao
  Email  : nguyenlam.thao@gg-net.co.jp
  Date   : 2007-12-05
  Company: Gnt 
*/
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Gnt.Transaction;
using System.IO;
using System.Collections;
using Gnt.Data;
using Gnt.Data.DBCommand;
using BusinessObjects;
using Man.Utils;
using System.Data.SqlClient;

namespace Man
{
    /// <summary>
    /// This is a custom page, all pages should be inherited 
    /// Purpose: 
    ///  + Handles actions, executions, error on this advertise projects's ways
    ///  + Customizes  themes
    ///  + Checks security, check permison whether enable/disable any of buttons
    /// </summary>
    public class PageBase : System.Web.UI.Page
    {
        private ObjectStateFormatter _formatter = new ObjectStateFormatter();
        /// <summary>
        /// Error messages 
        /// </summary>
        private string _errorMessage = string.Empty;

        private int _PopupWidth = 0;
        private int _PopupHeight = 0;
        private string _PopupName = string.Empty;
        /// <summary>
        /// Is error when executing an transaction
        /// </summary>
        private ArrayList _errors = new ArrayList();

        /// <summary>
        /// Business Logic factory - create one transaction to execute one of CRUP actions
        /// </summary>
        protected TransactionFactory factory = TransactionFactory.Factory;
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Properties
        public string ErrorMessage
        {
            get { return this._errorMessage; }
            set { this._errorMessage = value; }
        }

        public int PopupWidth
        {
            get { return this._PopupWidth; }
            set { this._PopupWidth = value; }
        }
        public int PopupHeight
        {
            get { return this._PopupHeight; }
            set { this._PopupHeight = value; }
        }

        public string PopupName
        {
            get { return this._PopupName; }
            set { this._PopupName = value; }
        }

        public IList Errors
        {
            get { return _errors; }
        }

        #endregion Properties

        public virtual void loadUserControl(string path) { }

        public virtual void loadUserControl(Control control) { }

        public virtual bool HasError
        {
            get { return (_errors.Count > 0); }
        }
        public void AddError(Exception e)
        {
            _errors.Add(e);
        }
        public void Remove(Exception e)
        {
            _errors.Remove(e);
        }

        /// <summary>
        /// Executes transaction
        /// </summary>
        /// <param name="trans"></param>
        public void Execute(ITransaction tran)
        {
            try
            {
                _errors = new ArrayList();
                _errorMessage = string.Empty;
                tran.Execute();
            }
            catch (TransactionException te)
            {
                _errorMessage = te.Message;
                _errors.Add(te);
                //ApplicationLog.WriteError(te);
                log.Error("", te);
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
                _errors.Add(e);
                log.Error("", e);
            }
        }


        protected override void OnLoad(EventArgs e)
        {
            if (String.IsNullOrEmpty(Func.ParseString(Session["__BUILDINGID__"])))
            {
                string sql = "SELECT BuildingId FROM aspnet_Membership ";
                sql += " WHERE UserId=(SELECT UserId FROM aspnet_Users WHERE UserName='" + Page.User.Identity.Name + "')";
                string buildingId = Func.ParseString(DbHelper.GetScalar(sql));
                Session["__BUILDINGID__"] = (buildingId.Length != 0 ? buildingId : null);

                if (String.IsNullOrEmpty(Func.ParseString(Session["__BUILDINGID__"])))
                {
                    Response.Redirect("~/Login.aspx?ReturnUrl=" + Request.RawUrl);
                }
                return;
            }

            base.OnLoad(e);
            try
            {
                string method = Page.Request.HttpMethod;
                if (method.Equals("GET"))
                {
                    DoInit();
                    DoGet();
                }
                else if (method.Equals("POST"))
                {
                    DoPost();
                }
            }
            catch (Exception te)
            {
                log.Error("", te);
            }
        }


        protected virtual void DoInit()
        {

        }

        protected virtual void DoGet()
        {

        }

        protected override void SavePageStateToPersistenceMedium(object viewState)
        {
            MemoryStream ms = new MemoryStream();
            _formatter.Serialize(ms, viewState);
            byte[] viewStateArray = ms.ToArray();
            ScriptManager.RegisterHiddenField(this, "__CUSTOMVIEWSTATE", Convert.ToBase64String(CompressViewState.Compress(viewStateArray)));
        }
        protected override object
            LoadPageStateFromPersistenceMedium()
        {
            string vsString = Request.Form["__CUSTOMVIEWSTATE"];
            byte[] bytes = Convert.FromBase64String(vsString);
            bytes = CompressViewState.Decompress(bytes);
            return _formatter.Deserialize(Convert.ToBase64String(bytes));
        }

        protected virtual void DoPost()
        {
            //    throw new NotImplementedException();
        }

        public string QueryString(string param)
        {
            return Request.QueryString[param] == null ? "" : Request.QueryString[param];
        }

        public string QueryParam(string param)
        {
            return Request.Params[param] == null ? "" : Request.Params[param];
        }

        public string RequestContext(string param)
        {
            return HttpContext.Current.Request.Params[param] == null ? "" : HttpContext.Current.Request.Params[param];
        }

        public string SafeQueryString(string param)
        {
            param = Request.QueryString[param] == null ? "" : Request.QueryString[param];
            if (param != string.Empty)
            {
                param = param.Replace("'", "''");
                param = KillSqlKeyword(param);
            }
            return param;
        }

        private string KillSqlKeyword(string param)
        {
            string[] badWords = { "select", ";", "drop", "--", "insert", "delete", "create", "xp_" };
            for (int i = 0; i < badWords.Length; i++)
            {
                param = param.Replace(badWords[i], "");
            }
            return param;
        }

        /// <summary>
        /// Writes logs an exception
        /// </summary>
        /// <param name="ex"></param>
        public void HandleError(Exception ex)
        {
            _errorMessage = ex.Message;
            log.Error("", ex);
        }
        protected ArrayList ListDetailExpand
        {
            get { return (ArrayList)ViewState["ExpandDetailId"]; }
            set { ViewState["ExpandDetailId"] = value; }
        }

        protected void AddExpand(string id)
        {
            ArrayList detailIds = (ArrayList)ViewState["ExpandDetailId"];
            if (detailIds == null)
            {
                detailIds = new ArrayList();
            }
            detailIds.Add(id);
            ViewState["ExpandDetailId"] = detailIds;
        }

        protected void RemoveExpand(string id)
        {
            ArrayList detailIds = (ArrayList)ViewState["ExpandDetailId"];
            if (detailIds != null)
            {
                detailIds.Remove(id);
                ViewState["ExpandDetailId"] = detailIds;
            }
        }
        protected void RemoveExpandAll()
        {
            ArrayList detailIds = (ArrayList)ViewState["ExpandDetailId"];
            if (detailIds != null)
            {
                detailIds.Clear();
            }
        }

        //public void syncLog()
        //{
        //    SqlDatabase db = new SqlDatabase();
        //    SqlCommand cm = db.CreateCommand("SELECT Id, Name FROM Site where DelFlag=0 and Id <> 0");
        //    SqlDataReader reader = cm.ExecuteReader();
        //    int countRec = 0;
        //    bool skip = false;
        //    Hashtable siteList = new Hashtable();
        //    while (reader.Read())
        //    {
        //        siteList.Add(reader[0], reader[1]);
        //    }
        //    string[,] resultSync;
        //    resultSync = new string[20, 3];
        //    resultSync = (string[,])Session["resultSync"];
        //    string kind = ((string)Session["TableName"]).ToLower();
        //    string key = (string)Session["Key"];
        //    string action = (string)Session["Action"];
        //    string lastSynchronizer = Page.User.Identity.Name;
        //    string lastSynchDated = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        //    string[] lines = new string[100];
        //    string[] results = new string[3];

        //    if (resultSync is System.Array)
        //    {
        //        for (int i = 0; i < resultSync.GetLength(0); ++i)
        //        {
        //            skip = false;
        //            string siteName = "";

        //            for (int j = 0; j < resultSync.GetLength(1); ++j)
        //            {
        //                if (!string.IsNullOrEmpty(resultSync[i, j]))
        //                {
        //                    foreach (DictionaryEntry de in siteList)
        //                    {
        //                        if (de.Key.ToString().Equals("" + i))
        //                        {
        //                            siteName = de.Value.ToString();
        //                            break;
        //                        }
        //                    }

        //                    lines = resultSync[i, j].Split('\n');
        //                    foreach (string line in lines)
        //                    {
        //                        if (!skip)
        //                        {
        //                            skip = true;
        //                        }
        //                        else
        //                        {
        //                            if (!string.IsNullOrEmpty(line))
        //                            {
        //                                countRec++;
        //                                if ("updatemass".Equals(action.ToLower()) || "updateonly".Equals(action.ToLower()))
        //                                {
        //                                    results = line.Split(',');
        //                                    string sql = "";
        //                                    string id = (string)results[0];

        //                                    int count = 0;

        //                                    string ModifiedStatus = "";
        //                                    if ("203".Equals((string)results[1]) || "204".Equals((string)results[1]))
        //                                    {
        //                                        ModifiedStatus = "1";
        //                                    }

        //                                    if (!("songmedia".Equals(kind) || "songsite".Equals(kind) || "vfullsongsite".Equals(kind) || "vutasongsite".Equals(kind) || "vvideosongsite".Equals(kind)))
        //                                    {
        //                                        string sqlCount = " Select count(*) from " + kind + "Site WHERE " + key + "='" + id + "' and SiteId = '" + i + "'";
        //                                        count = DbHelper.GetCount(sqlCount);

        //                                        sql = "UPDATE " + kind + "Site set sendResult = '" + (string)results[2] + "'";
        //                                        sql += " , PrevSynchronizer = LastSynchronizer, PrevSynchDated = LastSynchDated, LastSynchronizer = '" + lastSynchronizer + "' ";
        //                                        sql += " , LastSynchDated = '" + DateTime.Now.ToString("yyyyMMddHHmmss") + "', DelFlag = '0' WHERE " + key + "='" + id + "' and SiteId = '" + i + "'";
        //                                        if (count == 0)
        //                                        {
        //                                            sql = "Insert into " + kind + "Site (" + key + ", SiteId, LastSynchronizer, LastSynchDated, SendResult, DelFlag) values('" + id + "', '" + i + "', '" + lastSynchronizer + "', '" + DateTime.Now.ToString("yyyyMMddHHmmss") + "', '" + (string)results[2] + "', '0')";
        //                                        }
        //                                    }
        //                                    else
        //                                    {
        //                                        string sqlCount = " Select count(*) from SongSite WHERE SongId ='" + id + "' and SiteId = '" + i + "'";
        //                                        count = DbHelper.GetCount(sqlCount);

        //                                        sql = "UPDATE SongSite set sendResult = '" + (string)results[2] + "'";
        //                                        sql += " , PrevSynchronizer = LastSynchronizer, PrevSynchDated = LastSynchDated, LastSynchronizer = '" + lastSynchronizer + "' ";
        //                                        sql += " , ModifiedBy = '" + lastSynchronizer + "', Modified = '" + DateTime.Now.ToString("yyyyMMddHHmmss") + "'";
        //                                        sql += " , LastSynchDated = '" + DateTime.Now.ToString("yyyyMMddHHmmss") + "', DelFlag = '0' , ModifiedStatus = '" + ModifiedStatus + "' WHERE " + key + "='" + id + "' and SiteId = '" + i + "'";

        //                                        if (count == 0)
        //                                        {
        //                                            sql = "Insert into SongSite (" + key + ", SiteId, LastSynchronizer, LastSynchDated, SendResult, DelFlag,Creator, Created) values('" + id + "', '" + i + "', '" + lastSynchronizer + "', '" + DateTime.Now.ToString("yyyyMMddHHmmss") + "', '" + (string)results[2] + "', '0','" + lastSynchronizer + "','" + DateTime.Now.ToString("yyyyMMddHHmmss") + "')";
        //                                        }
        //                                    }
        //                                    DbHelper.ExecuteNonQuery(sql);

        //                                    //編集した値をDBに既存データを取得して設定する。
        //                                    SynLogData data = new SynLogData();
        //                                    ITransaction tran = factory.GetInsertObject(data);
        //                                    data.SynKey = id;
        //                                    data.SynResult = (string)(results[1] + "(" + results[2] + ")");
        //                                    data.SynSite = siteName;
        //                                    data.SynTable = kind;
        //                                    data.SynPerson = lastSynchronizer;
        //                                    data.SynDate = lastSynchDated;
        //                                    data.Action = (string)Session["FuncAction"];

        //                                    Execute(tran);
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    DataSet dsList = (DataSet)Session["InvalidList"];
        //    if (dsList != null && dsList.Tables[0].Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dsList.Tables[0].Rows)
        //        {
        //            string id = Func.ParseString(dr[0]);
        //            string Name = "invalid status.Can't not update";

        //            //編集した値をDBに既存データを取得して設定する。
        //            SynLogData data = new SynLogData();
        //            ITransaction tran = factory.GetInsertObject(data);
        //            data.SynKey = id;
        //            data.SynResult = Name;
        //            data.SynSite = "";
        //            data.SynTable = kind;
        //            data.SynPerson = Page.User.Identity.Name;
        //            data.SynDate = DateTime.Now.ToString();

        //            Execute(tran);
        //        }
        //    }
        //}

        public void LinkPopup(LinkButton lnkBtn, string url)
        {
            lnkBtn.OnClientClick = "PopUp('" + url + "'," + PopupWidth + "," + PopupHeight + ",'" + PopupName + "', true); return false;";
        }
        public void ImageButtonPopup(ImageButton lnkBtn, string url)
        {
            lnkBtn.OnClientClick = "PopUp('" + url + "'," + PopupWidth + "," + PopupHeight + ",'" + PopupName + "', true); return false;";
        }
        public void ButtonPopup(Button btn, string url)
        {
            btn.OnClientClick = "PopUp('" + url + "'," + PopupWidth + "," + PopupHeight + ",'" + PopupName + "', true); return false;";
        }
    }
}
