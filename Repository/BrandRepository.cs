using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        public BrandRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateBrand(Brand brand)
        {
            Create(brand);
        }

        public void DeleteBrand(Brand brand)
        {
            Delete(brand);
        }

        public async Task<IEnumerable<Brand>> GetAllBrandsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(b => b.Name).ToListAsync();
        }

        public async Task<Brand> GetBrandByIdAsync(Guid brandId, bool trackChanges)
        {
            return await FindByCondition(brand => brand.Id.Equals(brandId), trackChanges)
     .FirstOrDefaultAsync();
        }

        public void UpdateBrand(Brand brand)
        {
            Update(brand);
        }
    }
}
