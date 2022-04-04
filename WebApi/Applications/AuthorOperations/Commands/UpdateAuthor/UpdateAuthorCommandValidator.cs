using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Applications.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator: AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.FirstName).MinimumLength(4).When(x => x.Model.FirstName.Trim() != string.Empty);
            RuleFor(command => command.Model.LastName).MinimumLength(4).When(x => x.Model.LastName.Trim() != string.Empty);
        }
    }
}
