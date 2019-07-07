using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELibrary.Models;

namespace ELibrary.Controllers
{
    public class DisplayController : Controller
    {
        private IDal dal;

        public DisplayController()
        {
            dal = new Dal();
        }

        // GET: Display
        public ActionResult Index()
        {
            List<Book> books = dal.GetAllBooks();

            return View(books);
        }

        public ActionResult Authors()
        {
            List<Author> authors = dal.GetAllAuthors();

            return View(authors);
        }

        public ActionResult Author(int id)
        {
            List<Book> books = dal.GetAllBooksFromAuthor(id);

            return View(books);
        }

        public ActionResult Book(int id)
        {
            Book book = dal.GetBook(id);

            return View(book);
        }

        public ActionResult GenerateData()
        {
            dal.GenerateData();

            return View();
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            dal.CreateBook(book.Title, book.DateOfPublication, book.Author.Id.ToString());

            return View("Index");
        }

        public ActionResult CreateAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAuthor(Author author)
        {
            dal.CreateAuthor(author.Name);

            return View();
        }

    }
}