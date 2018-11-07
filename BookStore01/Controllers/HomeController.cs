using BookStore01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore01.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();
        public ActionResult Index()
        {
            var books = db.Books.ToList<Book>();
            ViewBag.Books = books;
            ViewBag.Genres = db.Genres.ToList<Genre>();
            return View();
        }

        [HttpPost]
        public ActionResult DeleteBook(int id)
        {
            var book = db.Books.FirstOrDefault(s => s.Id == id);
            if (book != null)
            {
                db.Entry(book).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            ViewBag.Books = db.Books.ToList<Book>();
            ViewBag.Genres = db.Genres.ToList<Genre>();
            return PartialView("ShowBooks");
        }

        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            ViewBag.Books = db.Books.ToList<Book>();
            ViewBag.Genres = db.Genres.ToList<Genre>();
            return PartialView("ShowBooks");
        }
    }
}