using AutoMapper;
using FluentAssertions;
using System;
using System.Linq;
using WebApi.Applications.BookOperations;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Command.CreateBook
{
    public class CreateBookCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperation_ShouldBeReturn()
        {
            //arrange(Hazırlık)
            var book = new Book() { Tittle = "Test", PageCount = 100, PublishDate = new DateTime(1999, 08, 27), AuthorId = 1, GenreId = 1, };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = new CreateBookModel() { Tittle = book.Tittle };

            //act & assert (Çalıştırma - Doğrulama)
            FluentActions
                .Invoking(() => command.Handler())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");
        }

        [Fact]
        public void WhenValidInputAreGiven_Book_ShouldBeCreated()
        {
            //arrange
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            CreateBookModel model = new CreateBookModel()
            {
                Tittle = "Hobbit",
                PageCount = 1000,
                PublishDate = DateTime.Now.Date.AddYears(-1),
                GenreId = 1,
                AuthorId = 1
            };
            command.Model = model;

            //act
            FluentActions.Invoking(() => command.Handler()).Invoke();

            //assert
            var book = _context.Books.SingleOrDefault(book => book.Tittle == model.Tittle);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);
            book.GenreId.Should().Be(model.GenreId);
        }
    }
}
