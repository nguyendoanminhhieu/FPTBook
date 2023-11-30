using FPTBook.Models;

namespace FPTBook.Repository.IRepository
{
    public interface IBookRepository : IRepository<Book>
    {
        void Update(Book entity);
    }
}
