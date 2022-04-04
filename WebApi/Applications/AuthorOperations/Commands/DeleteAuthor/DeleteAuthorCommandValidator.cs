using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Applications.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidator:AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
        }
    }
}
