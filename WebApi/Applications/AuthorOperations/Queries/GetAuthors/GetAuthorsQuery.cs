using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorViewModel> Handle()
        {
            var authors = _context.Authors.OrderBy(x => x.Id).ToList<Author>();
            List<AuthorViewModel> resultObj = _mapper.Map<List<AuthorViewModel>>(authors);
            return resultObj;
        }

        public class AuthorViewModel
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string BirthDay { get; set; }
        }

    }
    
}
