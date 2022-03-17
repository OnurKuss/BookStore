using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(
                new Book
                {
                   // Id = 1,
                    Tittle = "Lean Startup",
                    GenreId = 1, //Personal Growth
                    PageCount = 200,
                    PublishDate = new DateTime(2021, 05, 11)
                },
                new Book
                {
                  //  Id = 2,
                    Tittle = "Herland",
                    GenreId = 2, //Science Fiction
                    PageCount = 250,
                    PublishDate = new DateTime(2010, 08, 18)
                },
                new Book
                {
                   // Id = 3,
                    Tittle = "Dune",
                    GenreId = 2,
                    PageCount = 540,
                    PublishDate = new DateTime(2021, 12, 21)
                });

                context.SaveChanges();
            }
        }
    }
}

