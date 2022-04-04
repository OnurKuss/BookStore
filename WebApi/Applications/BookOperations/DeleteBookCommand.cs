using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.Applications.BookOperations
{
    public class DeleteBookCommand
    {
        public int BookId { get; set; }

        private readonly BookStoreDbContext _dbContext;
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handler()
        {
            var deleteBook = _dbContext.Books.SingleOrDefault(b => b.Id == BookId);
            if (deleteBook == null)
                throw new InvalidOperationException("Kitap bulunamdı");

            _dbContext.Books.Remove(deleteBook);
            _dbContext.SaveChanges();
        }
    }
}
