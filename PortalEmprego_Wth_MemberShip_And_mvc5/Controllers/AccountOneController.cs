using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortalEmprego_Wth_MemberShip_And_mvc5.Models;
using WebMatrix.WebData;


namespace PortalEmprego_Wth_MemberShip_And_mvc5.Controllers
{
    public class AccountOneController : Controller
    {
        //
        // GET: /AccountOne/
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel logindata, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (WebSecurity.Login(logindata.UserName, logindata.Password))
                {
                    if (returnUrl != null)
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }


                }
                else
                {
                    ModelState.AddModelError("", "Sorry the username already exist");
                    return View(logindata);
                }

            }
            ModelState.AddModelError("", "Sorry the username already exist");
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel registerdata)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(registerdata.UserName, registerdata.Password);
                    return RedirectToAction("Index", "Home");
                }
                catch (System.Web.Security.MembershipCreateUserException ex)
                {
                    ModelState.AddModelError("", "Sorry the username already exist");
                    return View(ModelState);
                }

            }

            ModelState.AddModelError("", "Sorry the username already exist");
            return View(ModelState);
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }



    }
}