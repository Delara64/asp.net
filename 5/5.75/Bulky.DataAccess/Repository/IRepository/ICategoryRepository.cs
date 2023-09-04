using BulkyBookBook.Models;

namespace BulkyBookBook.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
        void Save();
    }
}