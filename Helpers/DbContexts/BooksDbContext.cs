using BooksManager.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BooksManager.Helpers.DbContexts
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options) { }

        public DbSet<mstBook> Books { get; set; }
    }
}
