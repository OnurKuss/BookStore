using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper= mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.FirstName == Model.FirstName && x.LastName == Model.LastName);
            if (author != null)
            {
                throw new InvalidOperationException("Yazar zaten mevcut");
            }

            author = _mapper.Map<Author>(Model);
            _context.Add(author);
            _context.SaveChanges();
        }
    }

    public class CreateAuthorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDay { get; set; }
    }
}
