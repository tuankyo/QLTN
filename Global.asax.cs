using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Gnt.Configuration;
using Gnt.Transaction;
using log4net;
namespace Man
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            string appPath = Server.MapPath(Context.Request.ApplicationPath);
            ApplicationConfiguration.Start(appPath);
            TransactionFactoryImpl fac = new TransactionFactoryImpl();
            TransactionFactory.SetFactory(fac);
            log4net.Config.XmlConfigurator.Configure();
            ICJSystem system = ICJSystem.Instance;
            ICJSystem.Instance.ApplicationPath = appPath;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}