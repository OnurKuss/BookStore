using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Applications.BookOperations
{
    public class GetBooksIdQuery
    {
        public int BookId { get; set; }

        private readonly BookStoreDbContext _dbContext;

        private readonly IMapper _mapper;

        public GetBooksIdQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookIdViewModel Handler()
        {
            var book = _dbContext.Books.Include(x=> x.Genre).SingleOrDefault(b => b.Id == BookId);
            if (book == null)
                throw new InvalidOperationException("Kitap Bulunamdı");

            var getByBookId = _mapper.Map<BookIdViewModel>(book);
            //};
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
