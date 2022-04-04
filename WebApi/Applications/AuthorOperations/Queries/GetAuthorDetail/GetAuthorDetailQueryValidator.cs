using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Applications.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQueryValidator:AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailQueryValidator()
        {
            RuleFor(x => x.AuthorId).GreaterThan(0);
        }
    }
}
