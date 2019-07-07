using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELibrary.Models;

namespace ELibrary.ViewModels
{
    public class BookViewModel
    {
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; }
    }
}