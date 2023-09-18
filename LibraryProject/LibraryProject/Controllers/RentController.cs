using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models.Entity;

namespace LibraryProject.Controllers
{
    public class RentController : Controller
    {
        private readonly DbLibraryEntities _db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var rents = _db.Rents.Where(x=>x.Status==true).ToList();
            return View(rents);
        }

        [HttpGet]
        public ActionResult RentBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RentBook(Rents rent)
        {
            if (rent != null)
            {
                var book = _db.Books.FirstOrDefault(x => x.BookId == rent.Book);
                if (book != null) book.Status = false;
                rent.Status = true;
                _db.Rents.Add(rent);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult ReturnBook(int id)
        {
            var book = _db.Rents.Find(id);
            if (book != null) book.Status = false;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RentHistory()
        {
            var rents = _db.Rents.Where(x=>x.Status==false).ToList();
            return View(rents);
        }

        public ActionResult DeleteRent(int id)
        {
            var rent = _db.Rents.Find(id);
            if (rent != null) _db.Rents.Remove(rent);
            _db.SaveChanges();
            return RedirectToAction("RentHistory");
        }
    }
}