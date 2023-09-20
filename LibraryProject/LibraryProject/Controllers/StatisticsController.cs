using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models.Entity;

namespace LibraryProject.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly DbLibraryEntities _db=new DbLibraryEntities();
        public ActionResult Index()
        {
            ViewBag.totalBooks = _db.Books.ToList().Count;
            ViewBag.totalMembers = _db.Members.ToList().Count;
            ViewBag.rentedBooks = _db.Books.Where(x => x.Status == false).ToList().Count;
            ViewBag.totalSavings = _db.Penalties.ToList().Sum(x => x.PenaltyAmount);
            return View();
        }
    }
}