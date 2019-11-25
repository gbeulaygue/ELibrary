using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ELibrary.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string Name { get; set; }
    }
}