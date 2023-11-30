using FPTBook.Data;
using FPTBook.Models;
using FPTBook.Repository.IRepository;

namespace FPTBook.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public BookRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
        }

        public void Update(Book entity)
        {
            _dbContext.Books.Update(entity);
        }
    }
}
