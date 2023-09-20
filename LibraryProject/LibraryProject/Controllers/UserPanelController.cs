using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models.Entity;

namespace LibraryProject.Controllers
{
    public class UserPanelController : Controller
    {   
        private readonly DbLibraryEntities _db = new DbLibraryEntities();

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            var userName = (string)Session["Username"];
            var user = _db.Members.FirstOrDefault(x => x.MemberUsername == userName);
            return View(user);
        }

        [HttpPost]
        public ActionResult Index(Members members)
        {
            var userName = (string)Session["Username"];
            var member = _db.Members.FirstOrDefault(x => x.MemberUsername == userName);
            if (member != null)
            {
                member.MemberImage = members.MemberImage;
                member.MemberPhone = members.MemberPhone;
                member.MemberSchool = members.MemberSchool;
                member.MemberPassword = members.MemberPassword;
                _db.SaveChanges();
                return View();
            }
            return View();
        }
    }
}