using System;
using System.Collections.Generic;
using System.Linq;

namespace prj_console
{
    public class BookDataAccess
    {

        // DAL

        private List<Book> books;

        public BookDataAccess() // ctor
        {
            books =  new List<Book>() {
                new Book {Title = "Title 1", Description = "Description 1"},
                new Book {Title = "Title 2", Description = "Description 2"},
                new Book {Title = "Title 3", Description = "Description 3"}
            };
        }

        public List<Book> GetBooks()
        {
            return books;
            //
            //return new List<Book>(); // List of Book Object
        }

        public Book GetBookByTitle(string title)
        {
            var book = books.FirstOrDefault( b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            return book;
            //
            //return new Book(); // Empty Book Object
        }

    }
}