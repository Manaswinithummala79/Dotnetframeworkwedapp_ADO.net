using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Dotnetframeworkwedapp_ADO.net
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize counter
            Application["TotalUsers"] = 0;
        }

        void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["TotalUsers"] = (int)Application["TotalUsers"] + 1;
            Application.UnLock();
        }

        void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["TotalUsers"] = (int)Application["TotalUsers"] - 1;
            Application.UnLock();
        }
    }
}