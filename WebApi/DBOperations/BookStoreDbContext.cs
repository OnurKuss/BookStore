using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class BookStoreDbContext:DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options):base(options)
        {  }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
