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

namespace WebApi.UnitTests.Application.BookOperations.Command.UpdateBook
{
    public class UpdateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public UpdateBookCommandTests(CommonTestFixture textFixture)
        {
            _context = textFixture.Context;
        }

        [Fact]
        public void WhenBookIdNotFound_InvalidOperationException_ShoulBeReturn()
        {
            UpdatedBookModel bookViewModal = new UpdatedBookModel
            {
                Tittle = "Onur",
            };

            UpdatedBookCommand command = new(_context);
            command.BookId = 6;
            command.Model = bookViewModal;
            FluentActions
                .Invoking(() => command.Handler())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncelleme geçersiz");
        }
    }
        
}
