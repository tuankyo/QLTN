using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections;
using Gnt.Transaction;
namespace Man
{
    public class UserControlBase : System.Web.UI.UserControl
    {

        #region Fields
        private ArrayList _errors;
        private PageBase _page;
        private string _virtualPath;
        private string _errorMessage = string.Empty;
        protected TransactionFactoryImpl factory = (TransactionFactoryImpl)TransactionFactory.Factory;
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion Fields
       
        #region Contructors
        protected override void Construct()
        {
            base.Construct();
            _errors = new ArrayList();
        }
        #endregion Contructors

        #region Properties
        public string ErrorMessage
        {
            get { return this._errorMessage; }
            set { this._errorMessage = value; }
        }
        private bool _isReload = false;

        public bool IsReLoad
        {
            get { return this._isReload; }
            set { this._isReload = value; }
        }

        //public bool IsInit
        //{
        //    get { return (bool?)ViewState["IsInit" + this.ID] ?? false; }
        //    set { ViewState["IsInit" + this.ID] = value; }
        //}

        public IList Errors
        {
            get { return _errors; }
        }
        public PageBase PageBase
        {
            get { return _page; }
            set { this._page = value; }
        }

        public string VirtualPath
        { 
            get {return _virtualPath;}
            set {this._virtualPath = value;}
        }
        #endregion Properties

        #region Methods
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
        protected override void OnLoad(EventArgs e)
        {

            // Debugger.Initialize();
            try
            {
                base.OnLoad(e);
                string method = Page.Request.HttpMethod;
                if (method.Equals("GET"))
                {
                    DoInit();
                    DoGet();
                }
                else if (method.Equals("POST"))
                {
                    if (_isReload)
                    {
                        DoInit();
                        DoGet();
                    }
                    else
                    {
                        DoPost();
                    }
                }
                
            }
            catch (Exception te)
            {
                log.Error("", te);
            }

        }

        protected virtual void DoInit() { }
        protected virtual void DoGet()
        {

        }

        protected virtual void DoPost()
        {
           // throw new NotImplementedException();
        }

        public void Execute(ITransaction trans)
        {
            try
            {
                _errorMessage = string.Empty;
                System.Diagnostics.Debug.Assert(trans != null);
                trans.Execute();
            }
            catch (TransactionException te)
            {
                _errorMessage = te.Message;
                _errors.Add(te);
                log.Error("", te);
                OperationLogger.WriteInfo(Constants.LogOperationSongId, Constants.LogActionInsertId, te.ToString(), Page.User.Identity.Name);
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
                _errors.Add(e);
                log.Error("", e);
                OperationLogger.WriteInfo(Constants.LogOperationSongId, Constants.LogActionInsertId, e.ToString(), Page.User.Identity.Name);
            }
        }

        public void HandleError(Exception ex)
        {
            _errorMessage = ex.Message;
            log.Error("", ex);

        }

        public string QueryString(string param)
        {
            return Request.QueryString[param] == null ? "" : Request.QueryString[param];
        }

        public string QueryParam(string param)
        {
            return Request.Params[param] == null ? "" : Request.Params[param];
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

        public void Update()
        {
            DoInit();
            DoGet();
        }

        //public void ReInit()
        //{
        //    DoInit();
        //}
        #endregion Methods
    }
}
