using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models.Entity;

namespace LibraryProject.Controllers
{
    public class MemberController : Controller
    {
        private readonly DbLibraryEntities _db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var members = _db.Members.ToList();
            return View(members);
        }

        [HttpGet]
        public ActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMember(Members member)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _db.Members.Add(member);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteMember(int id)
        {
            var member = _db.Members.Find(id);
            if (member != null) _db.Members.Remove(member);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateMember(int id)
        {
            var member = _db.Members.Find(id);
            return View(member);
        }
        [HttpPost]
        public ActionResult UpdateMember(Members member)
        {
            return View();
        }
    }
}