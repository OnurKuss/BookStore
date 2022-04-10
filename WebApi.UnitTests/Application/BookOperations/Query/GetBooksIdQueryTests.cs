using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Applications.BookOperations;
using WebApi.DBOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Query
{
    public class GetBooksIdQueryTests: IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetBooksIdQueryTests(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Fact]
        public void WhenBookIsNotFound_Id_ShouldThrowException()
        {

            GetBooksIdQuery query = new GetBooksIdQuery(_context, _mapper);
            BookIdViewModel book = new BookIdViewModel();
            book.Tittle = "assadaads";
            book.PublishDate = "1999.01.01";
            book.PageCount = 200;
            book.Genre = "asdasdadasd";
            query.BookId = 12;
            FluentActions
                .Invoking(() => query.Handler())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı.");
        }

    }
}
