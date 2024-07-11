using Entities.Models;

namespace Contracts
{
    public interface ICategoryRepository
    {

        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);
        Task<Category> GetCategoryByIdAsync(Guid categoryId, bool trackChanges);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
