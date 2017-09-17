using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDIPrgrm.Models;
using System.Web.Security;

namespace SDIPrgrm.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoLogin(UserDetails u)
        {
            EmployeeBusinessLayer bal = new EmployeeBusinessLayer();
            if (bal.IsValidUser(u))
            {
                FormsAuthentication.SetAuthCookie(u.UserName, false);
                return this.RedirectToAction("EmployeeUI", "Employee");
            }
            else
            {
                ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                return View("Login");
            }
        }
    }
}