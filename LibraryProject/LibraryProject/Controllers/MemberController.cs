using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models.Entity;
using PagedList;

namespace LibraryProject.Controllers
{
    public class MemberController : Controller
    {
        private readonly DbLibraryEntities _db = new DbLibraryEntities();
        public ActionResult Index(int page=1)
        {
            var members = _db.Members.ToList().ToPagedList(page, 3);
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
        [HttpGet]
        public ActionResult UpdateMember(int id)
        {
            var member = _db.Members.Find(id);
            return View(member);
        }
        [HttpPost]
        public ActionResult UpdateMember(Members member)
        {
            var updateMember = _db.Members.Find(member.MemberId);
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (updateMember != null)
            {
                updateMember.MemberName = member.MemberName;
                updateMember.MemberSurname = member.MemberSurname;
                updateMember.MemberPhone = member.MemberPhone;
                updateMember.MemberSchool = member.MemberSchool;
                updateMember.MemberImage = member.MemberImage;
                updateMember.MemberUsername = member.MemberUsername;
                updateMember.MemberPassword = member.MemberPassword;
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}