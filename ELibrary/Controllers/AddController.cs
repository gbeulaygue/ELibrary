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
            AddBookViewModel addBookViewModel = new AddBookViewModel()
            {
                Book = new Book(),
                Authors = dal.GetAllAuthors()
            };

            return View(addBookViewModel);
        }

        [HttpPost]
        public ActionResult Book(AddBookViewModel _addBookViewModel)
        {
            if (!ModelState.IsValid)
            {
                AddBookViewModel addBookViewModel = new AddBookViewModel()
                {
                    Book = new Book(),
                    Authors = dal.GetAllAuthors()
                };
                return View(addBookViewModel);
            }
            if (dal.existBook(_addBookViewModel.Book.Title))
            {
                AddBookViewModel addBookViewModel = new AddBookViewModel()
                {
                    Book = _addBookViewModel.Book,
                    Authors = dal.GetAllAuthors()
                };
                ModelState.AddModelError("Title", "This book name already exists");
                return View(addBookViewModel);
            }
            dal.CreateBook(_addBookViewModel.Book.Title, _addBookViewModel.Book.DateOfPublication, _addBookViewModel.Book.Author.Id.ToString());
            return RedirectToAction("Index");
        }
    }
}