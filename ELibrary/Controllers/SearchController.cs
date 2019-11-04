using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELibrary.Models;
using ELibrary.ViewModels;

namespace ELibrary.Controllers
{
    public class SearchController : Controller
    {
        private IDal dal;

        public SearchController()
        {
            dal = new Dal();
        }

        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Book()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Book(string id)
        {
            Book book = dal.SearchBook(id);

            return View(book);
        }

        public ActionResult Books()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Books(SearchBooksViewModel _searchBooksViewModel)
        {
            SearchBooksViewModel searchBooksViewModel = new SearchBooksViewModel()
            {
                Search = _searchBooksViewModel.Search,
                Books = dal.SearchBooks(_searchBooksViewModel.Search)
            };

            return View(searchBooksViewModel);
        }
    }
}