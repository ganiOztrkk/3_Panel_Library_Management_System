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
            var rents = _db.Rents.Where(x => x.Status == true).ToList();
            return View(rents);
        }

        [HttpGet]
        public ActionResult RentBook()
        {
            List<SelectListItem> memberNames = (from x in _db.Members.ToList()
                                                select new SelectListItem()
                                                {
                                                    Text = x.MemberName + " " + x.MemberSurname,
                                                    Value = x.MemberId.ToString()
                                                }).ToList();
            ViewBag.MemberNames = memberNames;
            List<SelectListItem> bookNames = (from x in _db.Books.ToList().Where(y=>y.Status == true)
                                              select new SelectListItem()
                                              {
                                                  Text = x.BookName,
                                                  Value = x.BookId.ToString()
                                              }).ToList();
            ViewBag.BookNames = bookNames;
            List<SelectListItem> employeeNames = (from x in _db.Employees.ToList()
                                                  select new SelectListItem()
                                                  {
                                                      Text = x.EmployeeName,
                                                      Value = x.EmployeeId.ToString()
                                                  }).ToList();
            ViewBag.EmployeeNames = employeeNames;
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
            var rent = _db.Rents.Find(id);
            if (rent != null) rent.Status = false;
            var book = _db.Books.FirstOrDefault(x => x.BookId == rent.Book);
            if (book != null) book.Status = true;
            var penaltyDate = DateTime.Now;
            var returnDate = Convert.ToDateTime(rent.ReturnDate);
            TimeSpan retunSpan = returnDate - penaltyDate;
            if (retunSpan.Days < 0)
            {
                _db.Penalties.Add(new Penalties()
                {
                    Member = rent.Member,
                    PenaltyReason = rent.RentId,
                    PenaltyAmount = (retunSpan.Days * 10) * (-1)
                });
                _db.SaveChanges();
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RentHistory()
        {
            var rents = _db.Rents.Where(x => x.Status == false).ToList();
            return View(rents);
        }

        public ActionResult DeleteRent(int id)
        {
            var rent = _db.Rents.Find(id);
            if (rent != null) _db.Rents.Remove(rent);
            _db.SaveChanges();
            return RedirectToAction("RentHistory");
        }

        public ActionResult Savings()
        {
            var savings = _db.Penalties.ToList();
            var totalSavings = savings.Sum(x => x.PenaltyAmount);
            ViewBag.totalSavings = totalSavings;
            return View(savings);
        }
    }
}