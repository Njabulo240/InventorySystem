using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateCategory(Category category)
        {
            Create(category);
        }

        public void DeleteCategory(Category category)
        {
            Delete(category);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(Guid categoryId, bool trackChanges)
        {
            return await FindByCondition(category => category.Id.Equals(categoryId), trackChanges)
           .FirstOrDefaultAsync();
        }

        public void UpdateCategory(Category category)
        {
            Update(category);
        }
    }
}