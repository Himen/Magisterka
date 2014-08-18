

using HR.Core.Models;
using HR.DataAccess.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HR.Web_UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_BeginRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;

            string culture = null;
            if (context.Request.UserLanguages != null && Request.UserLanguages.Length > 0)
            {
                culture = Request.UserLanguages[0];
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }
    }
}
