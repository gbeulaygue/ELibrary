using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Models
{
    public interface IDal : IDisposable
    {
        List<Book> GetAllBooks();
        Book GetBook(int id);
        Book GetBook(string idStr);
        List<Author> GetAllAuthors();
        Author GetAuthor(int id);
        Author GetAuthor(string idStr);
        List<Book> GetAllBooksFromAuthor(int id);
        Book SearchBook(string search);
        void CreateAuthor(string name);
        void ModifyAuthor(int id, string name);
        void CreateBook(string title, DateTime parutionDate, string idAuthor);
        void ModifyBook(int id, string title, DateTime parutionDate, string idAuthor);
        void GenerateData();
    }
}
