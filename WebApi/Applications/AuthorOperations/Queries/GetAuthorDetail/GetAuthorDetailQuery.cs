using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.Applications.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author==null)
            {
                throw new InvalidOperationException("Yazar bulunamadı");
            }

            return _mapper.Map<AuthorDetailViewModel>(author);
        }
        public class AuthorDetailViewModel
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

    }
}
