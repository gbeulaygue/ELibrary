using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateOfPublication { get; set; }
        public virtual Author Author { get; set; }
        public virtual Customer Customer { get; set; }
    }
}