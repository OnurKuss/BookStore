using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.Applications.BookOperations
{
    public class UpdatedBookCommand
    {
        public UpdatedBookModel Model { get; set; }
        public int BookId { get; set; }

        private readonly BookStoreDbContext _dbContext;

        public UpdatedBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handler()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book == null)
                throw new InvalidOperationException("Güncelleme geçersiz");

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
            book.Tittle = Model.Tittle != default ? Model.Tittle : book.Tittle;
            
            _dbContext.SaveChanges();
        }
    }

    public class UpdatedBookModel
    {
        public string Tittle { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
