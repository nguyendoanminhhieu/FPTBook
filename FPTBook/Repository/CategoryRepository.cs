using FPTBook.Data;
using FPTBook.Models;
using FPTBook.Repository.IRepository;

namespace FPTBook.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public CategoryRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
        }
        public void Update(Category entity)
        {
            _dbContext.Categories.Update(entity);
        }
    }
}
