using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using log4net;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Reflection;
namespace Man
{
    /// <summary>
    /// Reads AppSettings and load to ICJSystem
    /// </summary>
    public sealed class ICJSystem
    {
        #region Fields
        private static ICJSystem instance = null;
        private log4net.ILog log = null;        
        private string martId = string.Empty;
        private string roleLevel1 = string.Empty ;
        private string roleLevel2 = string.Empty;
        private string roleLevel3 = string.Empty;
        private string roleLevel4 = string.Empty;
        private string applicationPath = string.Empty;
        private string outputDirectory = string.Empty;
        private string connectionString1 = string.Empty;
        private string connectionString2 = string.Empty;
        
        #endregion

        #region Properties

        public string MartId
        {
            get { return this.martId; }
            set { this.martId = value; }
        }

        public string RoleLevel1
        {
            get { return this.roleLevel1; }
            set { this.roleLevel1 = value; }
        }

        public string RoleLevel2
        {
            get { return this.roleLevel2; }
            set { this.roleLevel2 = value; }
        }

        public string RoleLevel3
        {
            get { return this.roleLevel3; }
            set { this.roleLevel3 = value; }
        }
        public string RoleLevel4
        {
            get { return this.roleLevel4; }
            set { this.roleLevel4 = value; }
        }
        public string ApplicationPath
        {
            get { return this.applicationPath; }
            set { this.applicationPath = value; }
        }

        public string OutputDirectory
        {
            get { return this.outputDirectory; }
            set { this.outputDirectory = value; }
        }

        public log4net.ILog Log
        {
            get { return log; }
            set { this.log = value; }
        }

        public string ConnectionString1
        {
            get { return this.connectionString1; }
            set { this.connectionString1 = value; }
        }

        public string ConnectionString2
        {
            get { return this.connectionString2; }
            set { this.connectionString2 = value; }
        }                

        #endregion


        private ICJSystem()
        {
            Load();
        }

        private void Load()
        {
            Type type = this.GetType();
            NameValueCollection settings = System.Configuration.ConfigurationManager.AppSettings;
            foreach (string key in settings.Keys)
            {
                foreach (PropertyInfo proper in type.GetProperties())
                {
                    if (proper.Name.Equals(key, StringComparison.OrdinalIgnoreCase))
                    {
                        try
                        {
                            proper.SetValue(this, Convert.ChangeType(settings[key], proper.PropertyType), null);
                        }
                        catch
                        {

                        }
                    }
                }
            }            
            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            connectionString1 = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
            connectionString2 = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        }

        public static ICJSystem Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ICJSystem();
                }
                return instance;
            }
        }

        public string Version()
        {
            try
            {
                return GetType().Assembly.GetName().Version.ToString();
            }
            catch
            {

            }
            return "";
        }
    }
}

