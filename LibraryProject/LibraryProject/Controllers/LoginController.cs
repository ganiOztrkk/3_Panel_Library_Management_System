using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LibraryProject.Models.Entity;

namespace LibraryProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly DbLibraryEntities _db = new DbLibraryEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Members member)
        {
            var user = _db.Members.FirstOrDefault(x =>
                x.MemberUsername == member.MemberUsername && x.MemberPassword == member.MemberPassword);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(member.MemberUsername,false);
                Session["Username"] = user.MemberUsername.ToString();
                return RedirectToAction("Index", "UserPanel");
            }
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Members member)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _db.Members.Add(member);
            _db.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}