using System.Collections.Generic;

namespace prj_console
{
    public class BookBusinessLogic
    {

        // BLL

        private BookDataAccess bookDAL;

        // constructor
        public BookBusinessLogic()
        {
            bookDAL = new BookDataAccess(); // inst: of data access class
        }

        public List<Book> GetBooks()
        {
            return bookDAL.GetBooks(); 
        }

        public Book GetBookByTitle(string title)
        {
            return bookDAL.GetBookByTitle(title);
        }

    }
}