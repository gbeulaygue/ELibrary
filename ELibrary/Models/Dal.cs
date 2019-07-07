using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ELibrary.Models
{
    public class Dal : IDal
    {
        private DataBaseContext dataBase;

        public Dal()
        {
            dataBase = new DataBaseContext();
        }

        public List<Author> GetAllAuthors()
        {
            return dataBase.Authors.ToList();
        }

        public Author GetAuthor(int id)
        {
            return dataBase.Authors.FirstOrDefault(a => a.Id == id);
        }

        public Author GetAuthor(string idStr)
        {
            int id;
            if(int.TryParse(idStr, out id))
            {
                return GetAuthor(id);
            }
            return null;
        }
        public void CreateAuthor(string name)
        {
            if(!string.IsNullOrWhiteSpace(name))
            {
                Author author = new Author { Name = name };
                dataBase.Authors.Add(author);
                dataBase.SaveChanges();
            }
        }

        public void ModifyAuthor(int id, string name)
        {
            Author author = GetAuthor(id);

            if(author != null)
            {
                author.Name = name;
                dataBase.SaveChanges();
            }
        }

        public List<Book> GetAllBooks()
        {
            return dataBase.Books.ToList();
        }

        public List<Book> GetAllBooksFromAuthor(int id)
        {
            return dataBase.Books.Where(b => b.Author.Id == id).ToList();
        }

        public Book GetBook(int id)
        {
            return dataBase.Books.FirstOrDefault(b => b.Id == id);
        }

        public Book GetBook(string idStr)
        {
            int id;
            if(int.TryParse(idStr, out id))
            {
                return GetBook(id);
            }
            return null;
        }

        public Book SearchBook(string search)
        {
            return dataBase.Books.FirstOrDefault(b => b.Title.Contains(search) || b.Author.Name.Contains(search));
        }

        public void CreateBook(string title, DateTime parutionDate, string idAuthor)
        {
            Book book = new Book
            {
                Title = title,
                DateOfPublication = parutionDate,
                Author = GetAuthor(idAuthor)
            };

            dataBase.Books.Add(book);
            dataBase.SaveChanges();
        }

        public void ModifyBook(int id, string title, DateTime parutionDate, string idAuthor)
        {
            Book book = GetBook(id);
            
            if(book != null)
            {
                book.Title = title;
                book.DateOfPublication = parutionDate;
                book.Author = GetAuthor(idAuthor);
                dataBase.SaveChanges();
            }
        }

        public void Dispose()
        {
            dataBase.Dispose();
        }

        public void GenerateData()
        {
            IDatabaseInitializer<DataBaseContext> init = new DropCreateDatabaseAlways<DataBaseContext>();
            Database.SetInitializer(init);
            init.InitializeDatabase(new DataBaseContext());

            // Authors
            Author a1 = new Author { Name = "Victor Hugo" };
            dataBase.Authors.Add(a1);
            Author a2 = new Author { Name = "Charles Baudelaire" };
            dataBase.Authors.Add(a2);
            Author a3 = new Author { Name = "Alfred De Musset" };
            dataBase.Authors.Add(a3);

            // Books
            Book l1 = new Book { Title = "Bug-Jargal", DateOfPublication = new DateTime(1818, 01, 01), Author = a1 };
            dataBase.Books.Add(l1);
            Book l2 = new Book { Title = "Notre-Dame de Paris", DateOfPublication = new DateTime(1831, 01, 01), Author = a1 };
            dataBase.Books.Add(l2);
            Book l3 = new Book { Title = "Les Fleurs du mal", DateOfPublication = new DateTime(1857, 01, 01), Author = a2 };
            dataBase.Books.Add(l3);
            Book l4 = new Book { Title = "Lorenzaccio ", DateOfPublication = new DateTime(1834, 01, 01), Author = a3 };
            dataBase.Books.Add(l4);
            Book l5 = new Book { Title = "Il ne faut jurer de rien", DateOfPublication = new DateTime(1836, 01, 01), Author = a3 };
            dataBase.Books.Add(l5);

            // Customers
            Customer c1 = new Customer { Email = "test@gmail.com", Name = "Test" };
            Customer c2 = new Customer { Email = "toto@gmail.com", Name = "Toto"};

            l1.Customer = c1;
            l2.Customer = c1;
            l3.Customer = c2;
            l4.Customer = c2;
            l5.Customer = c2;

            // Save
            dataBase.SaveChanges();
        }
    }
}