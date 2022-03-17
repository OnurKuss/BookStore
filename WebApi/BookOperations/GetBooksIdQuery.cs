using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations
{
    public class GetBooksIdQuery
    {
        public int BookId { get; set; }

        private readonly BookStoreDbContext _dbContext;
        
        public GetBooksIdQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BookIdViewModel Handler()
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == BookId);
            if (book == null)
                throw new InvalidOperationException("Kitap Bulunamdı");

            var getByBookId = new BookIdViewModel
            {
                Tittle = book.Tittle,
                PageCount = book.PageCount,
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy")
            };
            return getByBookId;
        }
    }
    public class BookIdViewModel
    {
        public string Tittle { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
