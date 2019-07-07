using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELibrary.Models;

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

        public ActionResult Book(string id)
        {
            Book book = dal.SearchBook(id);

            return View(book);
        }
    }
}