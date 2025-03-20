using BooksManager.Helpers.DbContexts;
using BooksManager.Models.Entity;
using Microsoft.Data.SqlClient;

namespace BooksManager.Interfaces
{
    public interface IBooksRepository
    {
        public Task<List<mstBook>> getAllSortListBooksAPI();
        public Task<List<mstBook>> getAllSortListBooksAPIWithAuthorAndTitle();
        public Task<decimal> getTotalPriceBooksAPI();
        public string saveListDetailsToDatabaseAPI(List<mstBook> books);
        public Task<List<mstBook>> getAllSortListBooksProcedure();
        public Task<List<mstBook>> getAllSortListBooksProcedureWithAuthorAndTitle();
    }
}
