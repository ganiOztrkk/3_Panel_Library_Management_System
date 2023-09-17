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
        private readonly DbLibraryEntities _db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var writers = _db.Writers.ToList();
            return View(writers);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writers writer)
        {
            _db.Writers.Add(writer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteWriter(int id)
        {
            var writer = _db.Writers.Find(id);
            if (writer != null) _db.Writers.Remove(writer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var writer = _db.Writers.Find(id);
            return View(writer);
        }

        [HttpPost]
        public ActionResult UpdateWriter(Writers writer)
        {
            var updatedWriter = _db.Writers.Find(writer.WriterId);
            if (updatedWriter != null)
            {
                updatedWriter.WriterName = writer.WriterName;
                updatedWriter.WriterSurname = writer.WriterSurname;
                updatedWriter.WriterDetail = writer.WriterDetail;
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}