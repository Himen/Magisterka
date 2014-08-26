using HR.DataAccess.GLOBAL.UnityOfWorks;
using HR.Web_UI.Models.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HR.Core.Models;
using HR.Web_UI.Services.ServicesInferface;

namespace HR.Web_UI.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        IAccountService accountService;
        // GET: Account
        public AccountController(IAccountService _accountService)
        {
            this.accountService = _accountService;
        }

        [Authorize(Roles = "HR")]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Account ac = accountService.GetUserByName(model.UserName);
                if (ac != null)
                {
                    CurrentUserModel cr = accountService.MapAccount(ac);
                    CurrentUser = cr;
                    CurrenrUserName = cr.UserName;

                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Hasło lub login jest nieprawidłowe. Spróbuj ponownie.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            CurrentUser = null;
            CurrenrUserName = null;

            return RedirectToAction("Index", "Common");
        }
    }
}