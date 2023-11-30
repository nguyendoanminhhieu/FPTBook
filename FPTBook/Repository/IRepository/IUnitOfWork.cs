using FPTBook.Data;

namespace FPTBook.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IBookRepository BookRepository { get; }
        void Save();

    }
}
