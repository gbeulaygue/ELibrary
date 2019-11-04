using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELibrary.Models;

namespace ELibrary.ViewModels
{
    public class SearchBooksViewModel
    {
        public string Search { get; set; }
        public List<Book> Books { get; set; }
    }
}