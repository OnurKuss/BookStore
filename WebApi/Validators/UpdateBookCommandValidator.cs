using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Applications.BookOperations;

namespace WebApi.Validators
{
    public class UpdateBookCommandValidator:AbstractValidator<UpdatedBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(u => u.BookId).GreaterThan(0);
            RuleFor(u => u.Model.GenreId).GreaterThan(0);
            RuleFor(u => u.Model.PageCount).GreaterThan(0);
            RuleFor(u => u.Model.Tittle).NotEmpty().MinimumLength(4);
            RuleFor(u => u.Model.PublishDate).LessThan(DateTime.Now.Date);
        }
    }
}
