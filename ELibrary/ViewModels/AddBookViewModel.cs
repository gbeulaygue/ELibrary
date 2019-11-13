using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ELibrary.Models;

namespace ELibrary.ViewModels
{
    public class AddBookViewModel
    {
        public Book Book { get; set; }
        public List<Author> Authors { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrWhiteSpace(Book.Title))
            {
                yield return new ValidationResult("You must enter a title", new[] { "Book" });
            }
        }
    }
}