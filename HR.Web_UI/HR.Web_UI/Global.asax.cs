

using HR.Core.Models;
using HR.DataAccess.EF;
using HR.Web_UI.Models;
using HR.Web_UI.Models.ViewModels.Account;
using HR.Web_UI.Services;
using HR.Web_UI.Services.ServicesInferface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace HR.Web_UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        CurrentUserModel CurrentUser;
        /*
         http://www.dotnetcurry.com/showarticle.aspx?ID=126
            BeginRequest 
            AuthenticateRequest 
            AuthorizeRequest 
            AcquireRequestState 
            ResolveRequestCache 
            Page Constructor 
            PreRequestHandlerExecute 
            Page.Init 
            Page.Load 
            PostRequestHandlerExecute 
            ReleaseRequestState 
            UpdateRequestCache 
            EndRequest 
            PreSendRequestHeaders 
            PreSendRequestContent 
         
         */

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

        protected void Session_Start(Object sender, EventArgs e)
        {
            Session["init"] = 0;
        }


        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        //let us take out the username now                
                        string username = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                        string roles = string.Empty;

                        var authService = (IAccountService)DependencyResolver.Current.GetService(typeof(IAccountService));

                        Account user = authService.GetUserByName(username);


                        //Kierownik jest kierownikiem i pracownikiem
                        //Osoba z działu HR tez jest pracownikiem hr i normalnym pracownikiem
                        if(user.AccountType == Core.Enums.AccountType.Pracownik)
                            roles = Enum.GetName(user.AccountType.GetType(), user.AccountType);
                        else if (user.AccountType == Core.Enums.AccountType.Kierownik)
                        {
                            roles = Enum.GetName(user.AccountType.GetType(), user.AccountType);
                            roles += ";" + Enum.GetName(user.AccountType.GetType(), HR.Core.Enums.AccountType.Pracownik);
                        }
                        else
                        {
                            roles = Enum.GetName(user.AccountType.GetType(), user.AccountType);
                            roles += ";" + Enum.GetName(user.AccountType.GetType(), HR.Core.Enums.AccountType.Pracownik);
                        }
                        //let us extract the roles from our own custom cookie


                        //Let us set the Pricipal with our user specific details
                        HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(
                          new System.Security.Principal.GenericIdentity(username, "Forms"), roles.Split(';'));
                    }
                    catch (Exception)
                    {
                        //somehting went wrong
                    }
                }
            }
        } 

    }
}
