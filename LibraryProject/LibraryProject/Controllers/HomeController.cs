using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models.Entity;

namespace LibraryProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbLibraryEntities _db = new DbLibraryEntities();
        [HttpGet]
        public ActionResult Index()
        {
            var books = _db.Books.ToList();
            return View(books);
        }
        [HttpPost]
        public ActionResult Index(Contacts contact)
        {
            _db.Contacts.Add(contact);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}