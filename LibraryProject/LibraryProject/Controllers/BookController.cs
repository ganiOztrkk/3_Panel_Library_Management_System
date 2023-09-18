using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models.Entity;

namespace LibraryProject.Controllers
{
    public class BookController : Controller
    {
        private readonly DbLibraryEntities _db = new DbLibraryEntities();
        // GET: Book
        public ActionResult Index(string search)
        {
            var books = _db.Books.ToList();
            var filteredBooks = from i in _db.Books select i;
            if (!string.IsNullOrEmpty(search))
            {
                filteredBooks = filteredBooks.Where(x => x.BookName.Contains(search));
                return View(filteredBooks.ToList());
            }
            return View(books);
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            List<SelectListItem> categories = (from i in _db.Categories.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.CategoryName,
                                                    Value = i.CategoryId.ToString()
                                                }).ToList();
            ViewBag.Categories = categories;
            List<SelectListItem> writers = (from k in _db.Writers.ToList()
                                                select new SelectListItem()
                                                {
                                                    Text = k.WriterName + " " + k.WriterSurname,
                                                    Value = k.WriterId.ToString()
                                                }).ToList();
            ViewBag.Writers = writers;
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(Books book)
        {
            if (book != null) _db.Books.Add(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBook(int id)
        {
            var book = _db.Books.Find(id);
            if (book != null)
            {
                _db.Books.Remove(book);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBook(int id)
        {
            var book = _db.Books.Find(id);
            List<SelectListItem> categories = (from i in _db.Categories.ToList()
                select new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.CategoryId.ToString()
                }).ToList();
                ViewBag.Categories = categories;

                List<SelectListItem> writers = (from k in _db.Writers.ToList()
                    select new SelectListItem()
                    {
                        Text = k.WriterName + " " + k.WriterSurname,
                        Value = k.WriterId.ToString()
                    }).ToList();
                ViewBag.Writers = writers;
            if (book != null)
            {
                return View(book);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UpdateBook(Books books)
        {
            var updatedBook = _db.Books.Find(books.BookId);
            if (updatedBook != null)
            {
                updatedBook.BookName = books.BookName;
                updatedBook.Publisher = books.Publisher;
                updatedBook.PublishYear = books.PublishYear;
                updatedBook.Status = true;
                updatedBook.Pages = books.Pages;
                var category = _db.Categories.FirstOrDefault(x => x.CategoryId == books.Categories.CategoryId);
                var writer = _db.Writers.FirstOrDefault(x => x.WriterId == books.Writers.WriterId);
                if (category != null) updatedBook.BookCategory = category.CategoryId;
                if (writer != null) updatedBook.BookWriter = writer.WriterId;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}