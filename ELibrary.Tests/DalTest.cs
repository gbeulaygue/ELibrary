using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ELibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ELibrary.Tests
{
    [TestClass]
    public class DalTest
    {
        private IDal dal;

        [TestInitialize]
        public void Init_BeforeEveryTest()
        {
            IDatabaseInitializer<DataBaseContext> init = new DropCreateDatabaseAlways<DataBaseContext>();
            Database.SetInitializer(init);
            init.InitializeDatabase(new DataBaseContext());

            dal = new Dal();
        }

        [TestCleanup]
        public void AfterEveryTest()
        {
            dal.Dispose();
        }

        [TestMethod]
        public void CreateAuthor_WithANewAuthor_GetAllAuthorsSendTheAuthorBackWell()
        {
            dal.CreateAuthor("John");
            List<Author> authors = dal.GetAllAuthors();

            Assert.IsNotNull(authors);
            Assert.AreEqual(1, authors.Count);
            Assert.AreEqual("John", authors[0].Name);
        }

        [TestMethod]
        public void CreateAuthor_WithTwoNewAuthors_GetAllAuthorsSendTheAuthorsBackWell()
        {
            dal.CreateAuthor("John");
            dal.CreateAuthor("Do");
            List<Author> authors = dal.GetAllAuthors();

            Assert.IsNotNull(authors);
            Assert.AreEqual(2, authors.Count);
            Assert.AreEqual("John", authors[0].Name);
            Assert.AreEqual("Do", authors[1].Name);
        }

        [TestMethod]
        public void CreateAuthor_WithNewAuthor_GetTheNewAuthorWithIdSendItBackWell()
        {
            dal.CreateAuthor("John");
            Author author = dal.GetAuthor(1);

            Assert.IsNotNull(author);
            Assert.AreEqual("John", author.Name);
        }

        [TestMethod]
        public void CreateAuthor_WithNewAuthor_GetTheNewAuthorWithStringIdSendItBackWell()
        {
            dal.CreateAuthor("John");
            Author author = dal.GetAuthor("1");

            Assert.IsNotNull(author);
            Assert.AreEqual("John", author.Name);
        }


        [TestMethod]
        public void CreateAuthor_WithANewAuthor_ModifyAuthorByCHangingName_GetAllAuthorsSendTheAuthorBackWell()
        {
            dal.CreateAuthor("John");
            List<Author> authors = dal.GetAllAuthors();
            dal.ModifyAuthor(authors[0].Id, "Do");
            authors = dal.GetAllAuthors();

            Assert.IsNotNull(authors);
            Assert.AreEqual(1, authors.Count);
            Assert.AreEqual("Do", authors[0].Name);
        }

        [TestMethod]
        public void GetAuthor_AuthorNonExistent_ReturnNull()
        {
            Author author = dal.GetAuthor(1);

            Assert.IsNull(author);
        }

        [TestMethod]
        public void GetAuthor_IdNotNumerical_RetourneNull()
        {
            Author author = dal.GetAuthor("1");

            Assert.IsNull(author);
        }

        [TestMethod]
        public void GetAuthor_AuthorExistent_ReturnAuthor()
        {
            dal.CreateAuthor("John");
            Author author = dal.GetAuthor(1);

            Assert.IsNotNull(author);
            Assert.AreEqual("John", author.Name);
        }

        [TestMethod]
        public void GetAuthor_IdNumerical_RetourneAuthor()
        {
            dal.CreateAuthor("John");
            Author author = dal.GetAuthor("1");

            Assert.IsNotNull(author);
            Assert.AreEqual("John", author.Name);
        }

        [TestMethod]
        public void CreateBook_WithANewBook_GetAllBooksSendTheBookBackWell()
        {
            dal.CreateAuthor("John");
            dal.CreateBook("The Lord Of The Ring", new DateTime(1954, 07, 29),"1");
            List<Book> books = dal.GetAllBooks();

            Assert.IsNotNull(books);
            Assert.AreEqual(1, books.Count);
            Assert.AreEqual("The Lord Of The Ring", books[0].Title);
            Assert.AreEqual(new DateTime(1954, 07, 29), books[0].DateOfPublication);
            Assert.AreEqual(books[0].Author.Name, "John");
        }

        [TestMethod]
        public void CreateBook_WithTwoNewBooks_GetAllBooksSendTheBooksBackWell()
        {
            dal.CreateAuthor("John");
            dal.CreateAuthor("Do");
            dal.CreateBook("The Lord Of The Ring", new DateTime(1954, 07, 29), "1");
            dal.CreateBook("Harry Potter", new DateTime(2001, 12, 05), "2");
            List<Book> books = dal.GetAllBooks();

            Assert.IsNotNull(books);
            Assert.AreEqual(2, books.Count);
            Assert.AreEqual("The Lord Of The Ring", books[0].Title);
            Assert.AreEqual(new DateTime(1954, 07, 29), books[0].DateOfPublication);
            Assert.AreEqual(books[0].Author.Name, "John");
            Assert.AreEqual("Harry Potter", books[1].Title);
            Assert.AreEqual(new DateTime(2001, 12, 05), books[1].DateOfPublication);
            Assert.AreEqual(books[1].Author.Name, "Do");
        }

        [TestMethod]
        public void CreateBook_WithANewBook_ModifyBookByCHangingTitleAndDate_GetAllBooksSendTheBookBackWell()
        {
            dal.CreateAuthor("John");
            dal.CreateAuthor("Do");
            dal.CreateBook("The Lord Of The Ring", new DateTime(1954, 07, 29), "1");
            List<Book> books = dal.GetAllBooks();
            dal.ModifyBook(books[0].Id, "Harry Potter", new DateTime(2001, 12, 05), "2");
            books = dal.GetAllBooks();

            Assert.IsNotNull(books);
            Assert.AreEqual(1, books.Count);
            Assert.AreEqual("Harry Potter", books[0].Title);
            Assert.AreEqual(new DateTime(2001, 12, 05), books[0].DateOfPublication);
            Assert.AreEqual(books[0].Author.Name, "Do");
        }

        [TestMethod]
        public void GetBook_BookNonExistent_ReturnNull()
        {
            Book book = dal.GetBook(1);

            Assert.IsNull(book);
        }

        [TestMethod]
        public void GetBook_IdNotNumerical_RetourneNull()
        {
            Book book = dal.GetBook("1");

            Assert.IsNull(book);
        }

        [TestMethod]
        public void GetBook_BookExistent_ReturnBook()
        {
            dal.CreateBook("The Lord Of The Ring", new DateTime(1954, 07, 29), "1");
            Book book = dal.GetBook(1);

            Assert.IsNotNull(book);
            Assert.AreEqual("The Lord Of The Ring", book.Title);
            Assert.AreEqual(new DateTime(1954, 07, 29), book.DateOfPublication);
        }

        [TestMethod]
        public void GetBook_IdNumerical_RetourneBook()
        {
            dal.CreateBook("The Lord Of The Ring", new DateTime(1954, 07, 29), "1");
            Book book = dal.GetBook("1");

            Assert.IsNotNull(book);
            Assert.AreEqual("The Lord Of The Ring", book.Title);
            Assert.AreEqual(new DateTime(1954, 07, 29), book.DateOfPublication);
        }

        [TestMethod]
        public void GetAllBooksFromAuthor_CreateAuthor_CreateBookWithTheAuthor_ReturnBackWellAllBooksFromTheAuthorId()
        {
            dal.CreateAuthor("John");
            dal.CreateBook("The Lord Of The Ring", new DateTime(1954, 07, 29), "1");
            dal.CreateBook("Harry Potter", new DateTime(2001, 12, 05), "1");

            List<Book> books = dal.GetAllBooksFromAuthor(1);

            Assert.IsNotNull(books);
            Assert.AreEqual(2, books.Count);
            Assert.AreEqual("The Lord Of The Ring", books[0].Title);
            Assert.AreEqual(new DateTime(1954, 07, 29), books[0].DateOfPublication);
            Assert.AreEqual(books[0].Author.Name, "John");
            Assert.AreEqual("Harry Potter", books[1].Title);
            Assert.AreEqual(new DateTime(2001, 12, 05), books[1].DateOfPublication);
            Assert.AreEqual(books[1].Author.Name, "John");
        }

        [TestMethod]
        public void SearchBook_CreateAAuthorAndABook_SearchTheBookWithAStringContainsInBookName_ReturnTheGoodBook()
        {
            dal.CreateAuthor("John");
            dal.CreateBook("The Lord Of The Ring", new DateTime(1954, 07, 29), "1");

            Book book = dal.SearchBook("Lord");

            Assert.IsNotNull(book);
            Assert.AreEqual("The Lord Of The Ring", book.Title);
            Assert.AreEqual(new DateTime(1954, 07, 29), book.DateOfPublication);
            Assert.AreEqual(book.Author.Name, "John");
        }

        [TestMethod]
        public void SearchBook_CreateAAuthorAndABook_SearchTheBookWithAStringNotContainInBookName_ReturnNull()
        {
            dal.CreateAuthor("John");
            dal.CreateBook("The Lord Of The Ring", new DateTime(1954, 07, 29), "1");

            Book book = dal.SearchBook("Harry");

            Assert.IsNull(book);
        }

        [TestMethod]
        public void SearchBook_CreateAAuthorAndABook_SearchTheBookWithAStringConainsInAuthorName_ReturnTheGoodBook()
        {
            dal.CreateAuthor("John");
            dal.CreateBook("The Lord Of The Ring", new DateTime(1954, 07, 29), "1");

            Book book = dal.SearchBook("John");

            Assert.IsNotNull(book);
            Assert.AreEqual("The Lord Of The Ring", book.Title);
            Assert.AreEqual(new DateTime(1954, 07, 29), book.DateOfPublication);
            Assert.AreEqual(book.Author.Name, "John");
        }

        [TestMethod]
        public void SearchBook_CreateAAuthorAndABook_SearchTheBookWithAStringStringNotContainsInAuthorName_ReturnNull()
        {
            dal.CreateAuthor("John");
            dal.CreateBook("The Lord Of The Ring", new DateTime(1954, 07, 29), "1");

            Book book = dal.SearchBook("Do");

            Assert.IsNull(book);
        }
    }
}
