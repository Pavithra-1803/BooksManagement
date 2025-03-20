using BooksManager.Models.Entity;

namespace BooksManager.Models.DTOs
{
    public class BooksViewModel
    {
        public List<mstBook> books { get; set; }
        public List<mstBook> booksWithAuthorAndTitle { get; set; }
        public decimal totalPrice { get; set; }
        public List<mstBook> booksFromProcedure { get; set; }
        public List<mstBook> booksFromProcedureWithAuthorAndTitle { get; set; }
    }

}
