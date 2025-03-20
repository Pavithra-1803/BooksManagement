using BooksManager.Helpers.DbContexts;
using BooksManager.Interfaces;
using BooksManager.Models.Entity;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BooksManager.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly string _connectionString;
        private readonly BooksDbContext _booksDbContext;

        public BooksRepository(IConfiguration configuration, BooksDbContext booksDbContext)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _booksDbContext = booksDbContext;
        }

        public async Task<List<mstBook>> getAllSortListBooksAPI()
        {
            var vResult = await _booksDbContext.Books.OrderBy(a=>a.Publisher).ThenBy(a=>a.AuthorLastName).ThenBy(a=>a.AuthorFirstName).ThenBy(a=>a.Title).ToListAsync();
            return vResult;
        }

        public async Task<List<mstBook>> getAllSortListBooksAPIWithAuthorAndTitle()
        {
            var vResult = await _booksDbContext.Books.OrderBy(a => a.AuthorLastName).ThenBy(a => a.AuthorFirstName).ThenBy(a => a.Title).ToListAsync();
            return vResult;
        }

        public async Task<decimal> getTotalPriceBooksAPI()
        {
            var vResult = await _booksDbContext.Books.SumAsync(a => a.Price);
            return vResult;
        }

        public string saveListDetailsToDatabaseAPI(List<mstBook> books)
        {
            _booksDbContext.Books.AddRange(books);
            _booksDbContext.SaveChanges();
            return "Books added successfully";
        }

        public async Task<List<mstBook>> getAllSortListBooksProcedure()
        {
            using var connection = new SqlConnection(_connectionString);
            var vResult = (await connection.QueryAsync<mstBook>("exec getAllSortListBooks")).AsList();
            List<mstBook> booksList = vResult;
            return booksList;
        }

        public async Task<List<mstBook>> getAllSortListBooksProcedureWithAuthorAndTitle()
        {
            using var connection = new SqlConnection(_connectionString);
            var vResult = (await connection.QueryAsync<mstBook>("exec getAllSortListBooksWithAuthorAndTitle")).AsList();
            List<mstBook> booksList = vResult;
            return booksList;
        }

    }
}
