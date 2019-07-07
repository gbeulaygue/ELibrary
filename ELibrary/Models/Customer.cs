using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ELibrary.Models
{
    public class Customer
    {
        [Key,Required]
        public string Email { get; set; }
        public string Name { get; set; }
        //public virtual List<Book> Books { get; set; }
    }
}