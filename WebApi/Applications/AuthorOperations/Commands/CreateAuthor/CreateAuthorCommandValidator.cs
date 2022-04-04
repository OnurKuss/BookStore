using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Applications.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator: AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x=> x.Model.FirstName).NotEmpty().MinimumLength(4);
            RuleFor(x => x.Model.LastName).NotEmpty().MinimumLength(4);
        }
    }
}
