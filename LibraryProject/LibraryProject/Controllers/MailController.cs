using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models.Entity;

namespace LibraryProject.Controllers
{
    public class MailController : Controller
    {
        private readonly DbLibraryEntities _db = new DbLibraryEntities();
        public ActionResult Inbox()
        {
            var messages = _db.Contacts.ToList();
            ViewBag.unreadedMessage = _db.Contacts.Count(x => x.Status == false);
            return View(messages);
        }

        public ActionResult ViewMail(int id)
        {
            var mail = _db.Contacts.Find(id);
            if (mail != null) mail.Status = true;
            _db.SaveChanges();
            return View(mail);
        }

        public ActionResult MarkUnread(int id)
        {
            var mail = _db.Contacts.Find(id);
            if (mail != null) mail.Status = false;
            _db.SaveChanges();
            return RedirectToAction("Inbox");
        }
    }
}