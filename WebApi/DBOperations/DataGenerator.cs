using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

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

                context.AddRange(
                    new Author
                    {
                        FirstName = "Eric",
                        LastName = "Ries",
                        BirthDay = "05.06.1895",
                        IsBookPublished=true
                    },
                    new Author
                    {
                        FirstName = "Charlotte",
                        LastName = "Perkins Gilman",
                        BirthDay = "01.01.1976",
                        IsBookPublished = true
                    },
                    new Author
                    {
                        FirstName = "Frank",
                        LastName = "Herbert",
                        BirthDay = "01.01.1985",
                        IsBookPublished = true
                    });

                context.AddRange(
                    new Genre
                    {
                        Name = "Personel Growth",
                    },
                    new Genre
                    {
                        Name = "Science Fiction",
                    },
                    new Genre
                    {
                        Name = "Noval",
                    });

                context.Books.AddRange(
                new Book
                {
                    // Id = 1,
                    Tittle = "Lean Startup",
                    GenreId = 1, //Personal Growth
                    AuthorId=1, //Eric Ries
                    PageCount = 200,
                    PublishDate = new DateTime(2021, 05, 11)
                },
                new Book
                {
                    //  Id = 2,
                    Tittle = "Herland",
                    GenreId = 2, //Science Fiction
                    AuthorId = 2,
                    PageCount = 250, //
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

                context.SaveChanges();
            }
        }
    }
}

