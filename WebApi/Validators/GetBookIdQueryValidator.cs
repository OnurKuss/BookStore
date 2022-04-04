using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Applications.BookOperations;

namespace WebApi.Validators
{
    public class GetBookIdQueryValidator:AbstractValidator<GetBooksIdQuery>
    {
        public GetBookIdQueryValidator()
        {
            RuleFor(g => g.BookId).GreaterThan(0);
        }
    }
}
