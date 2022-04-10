using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                new Book
                {
                    // Id = 1,
                    Tittle = "Lean Startup",
                    GenreId = 1, //Personal Growth
                    AuthorId = 1, //Eric Ries
                    PageCount = 200,
                    PublishDate = new DateTime(2021, 05, 11)
                },
                new Book
                {
                    //  Id = 2,
                    Tittle = "Herland",
                    GenreId = 2, //Science Fiction
                    AuthorId = 2,
                    PageCount = 250, 
                    PublishDate = new DateTime(2010, 08, 18)
                },
                new Book
                {
                    // Id = 3,
                    Tittle = "Dune",
                    GenreId = 3,
                    AuthorId = 3,
                    PageCount = 540,
                    PublishDate = new DateTime(2021, 12, 21)
                });

        }
    }
}
