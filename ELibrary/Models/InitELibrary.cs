using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ELibrary.Models
{
    public class InitELibrary : DropCreateDatabaseAlways<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            //context.Books.Add(new Book { Id = 1, Title = "Bug-Jargal", DateOfPublication = new DateTime(1818, 01, 01), Author = new Author { Id = 1, Name = "Victor Hugo" }, Customer = new Customer { Id = 1, Email = "test@gmail.com", Name = "Test" } });
            //context.Books.Add(new Book { Id = 2, Title = "Notre-Dame de Paris", DateOfPublication = new DateTime(1831, 01, 01), Author = new Author { Id = 1, Name = "Victor Hugo" }, Customer = new Customer { Id = 1, Email = "test@gmail.com", Name = "Test" } });
            //context.Books.Add(new Book { Id = 3, Title = "Les Fleurs du mal", DateOfPublication = new DateTime(1857, 01, 01), Author = new Author { Id = 2, Name = "Charles Baudelaire" }, Customer = new Customer { Id = 2, Email = "toto@gmail.com", Name = "Toto" } });
            //context.Books.Add(new Book { Id = 4, Title = "Lorenzaccio ", DateOfPublication = new DateTime(1834, 01, 01), Author = new Author { Id = 3, Name = "Alfred De Musset" }, Customer = new Customer { Id = 2, Email = "toto@gmail.com", Name = "Toto" } });
            //context.Books.Add(new Book { Id = 5, Title = "Il ne faut jurer de rien", DateOfPublication = new DateTime(1836, 01, 01), Author = new Author { Id = 3, Name = "Alfred De Musset" }, Customer = new Customer { Id = 2, Email = "toto@gmail.com", Name = "Toto" } });

            Author author1 = new Author { Id = 1, Name = "Victor Hugo" };
            Author author2 = new Author { Id = 2, Name = "Charles Baudelaire" };
            Author author3 = new Author { Id = 5, Name = "Alfred De Musset" };

            Customer customer1 = new Customer { Id = 1, Email = "test@gmail.com", Name = "Test" };
            Customer customer2 = new Customer { Id = 2, Email = "toto@gmail.com", Name = "Toto" };

            context.Authors.Add(author1);
            context.Authors.Add(author2);
            context.Authors.Add(author3);

            context.Customers.Add(customer1);
            context.Customers.Add(customer2);

            context.Books.Add(new Book { Id = 1, Title = "Bug-Jargal", DateOfPublication = new DateTime(1818, 01, 01), Author = author1, Customer = customer1 });
            context.Books.Add(new Book { Id = 2, Title = "Notre-Dame de Paris", DateOfPublication = new DateTime(1831, 01, 01), Author = author1, Customer = customer1 });
            context.Books.Add(new Book { Id = 3, Title = "Les Fleurs du mal", DateOfPublication = new DateTime(1857, 01, 01), Author = author2, Customer = customer2 });
            context.Books.Add(new Book { Id = 4, Title = "Lorenzaccio ", DateOfPublication = new DateTime(1834, 01, 01), Author = author3, Customer = customer2 });
            context.Books.Add(new Book { Id = 5, Title = "Il ne faut jurer de rien", DateOfPublication = new DateTime(1836, 01, 01), Author = author3, Customer = customer2 });

            base.Seed(context);
        }
    }
}