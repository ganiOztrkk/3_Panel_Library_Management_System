using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models.Entity;

namespace LibraryProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DbLibraryEntities _db = new DbLibraryEntities();
        // GET: Category
        public ActionResult Index()
        {
            var categories = _db.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Categories category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var category = _db.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category != null) _db.Categories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var category = _db.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Categories category)
        {
            var updatedCategory = _db.Categories.Find(category.CategoryId);
            if (updatedCategory != null) updatedCategory.CategoryName = category.CategoryName;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}