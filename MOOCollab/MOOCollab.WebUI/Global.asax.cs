using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MOOCollab.DataAccess.MOOCollabContext;
using MOOCollab.WebUI.App_Start;
using WebMatrix.WebData;

namespace MOOCollab.WebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();            
            
            ////Uncomment to drop database
            //DatabaseSetup.DropDatabase(dropDb:false);
//            WebSecurity.InitializeDatabaseConnection("MOOCollab2Context", "Users", "Id", "UserName", autoCreateTables: true);
            
            WebSecuritySetup.SetupConnection();


            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
    }
}