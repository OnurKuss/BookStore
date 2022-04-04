using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.Applications.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _context;

        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author==null)
            {
                throw new InvalidOperationException("Yazar bulunamadı!");
            }
            var delete = _context.Authors.Any(x => x.IsBookPublished == true);
            if (delete)
            {
                throw new InvalidOperationException("Yazarın yayında olan kitabı var! Bu yüzden silinemez!");
            }
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
    
}
