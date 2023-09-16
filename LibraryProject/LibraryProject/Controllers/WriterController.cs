using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models.Entity;

namespace LibraryProject.Controllers
{
    public class WriterController : Controller
    {
        private readonly DbLibraryEntities _libraryEntities = new DbLibraryEntities();
        public ActionResult Index()
        {
            var writers = _libraryEntities.Writers.ToList();
            return View(writers);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
    }
}