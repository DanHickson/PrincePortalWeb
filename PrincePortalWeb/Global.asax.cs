using PrincePortalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using static PrincePortalWeb.Startup;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;


namespace PrincePortalWeb
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ApplicationDbContext dbContext = new ApplicationDbContext();
            Startup.IdentityRoleHelper.DefaultAdminUserandRole(dbContext);

            //set email settings
            GlobalVariables.SMTPHOST = "smtp.gmail.com";
            GlobalVariables.SMTPUSER = "ahix78911@gmail.com";
            GlobalVariables.SMTPPASS = "Nuclear22789";
            GlobalVariables.SMTPPORT = 587;
            GlobalVariables.princeportaladdress = "www.google.co.uk";
            GlobalVariables.FROMEMAILADDRESS = "ADMIN@PRINCE.CO.UK";

            AreaRegistration.RegisterAllAreas();
            RouteConfig2.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig2.RegisterBundles(BundleTable.Bundles);

        }

        public static class GlobalVariables
        {
            //variables to store email settings
            public static string SMTPHOST { get; set; }
            public static string SMTPUSER { get; set; }
            public static string SMTPPASS { get; set; }
            public static int SMTPPORT { get; set; }
            public static string princeportaladdress { get; set; }
            public static string FROMEMAILADDRESS { get; set; }
  


        }
    }
}