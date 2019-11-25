using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELibrary.Models;
using ELibrary.ViewModels;

namespace ELibrary.Controllers
{
    public class AddController : Controller
    {
        private IDal dal;
        
        public AddController()
        {
            dal = new Dal();
        }

        public AddController(IDal dalIOC)
        {
            dal = dalIOC;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Book()
        {
            List<Author> listOfAuthors = dal.GetAllAuthors();

            ViewBag.listOfAuthors = new SelectList(listOfAuthors, "Id", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult Book(Book _book)
        {
            //if (dal.existBook(_book.Title))
            //{
            //    List<Author> listOfAuthors = dal.GetAllAuthors();
            //    ViewBag.listOfAuthors = new SelectList(listOfAuthors, "Id", "Name");

            //    ModelState.AddModelError("Book.Title", "This book name already exists");
            //    return View(_book);
            //}
            //if (!ModelState.IsValid)
            //{
            //    List<Author> listOfAuthors = dal.GetAllAuthors();
            //    ViewBag.listOfAuthors = new SelectList(listOfAuthors, "Id", "Name");

            //    return View(_book);
            //}
            //string authorStr = Request.QueryString[""];
            //dal.CreateBook(_book.Title, _book.DateOfPublication, Id.ToString());
            //return RedirectToAction("Index");
            List<Author> listOfAuthors = dal.GetAllAuthors();

            ViewBag.listOfAuthors = new SelectList(listOfAuthors, "Id", "Name");
            return View();
        }

        public ActionResult Author()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Author(Author _author)
        {
            if(!ModelState.IsValid)
            {
                return View(_author);
            }
            dal.CreateAuthor(_author.Name);
            return View();
        }
    }
}