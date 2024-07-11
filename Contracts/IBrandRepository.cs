using Entities.Models;

namespace Contracts
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllBrandsAsync(bool trackChanges);
        Task<Brand> GetBrandByIdAsync(Guid brandId, bool trackChanges);
        void CreateBrand(Brand brand);
        void UpdateBrand(Brand brand);
        void DeleteBrand(Brand brand);
    }
}
