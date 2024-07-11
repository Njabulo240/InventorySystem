using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateSupplier(Supplier supplier)
        {
            Create(supplier);
        }

        public void DeleteSupplier(Supplier supplier)
        {
            Delete(supplier);
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(s => s.Name).ToListAsync();
        }

        public async Task<Supplier> GetSupplierByIdAsync(Guid supplierId, bool trackChanges)
        {
            return await FindByCondition(supplier => supplier.Id.Equals(supplierId), trackChanges)
            .FirstOrDefaultAsync();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            Update(supplier);
        }
    }
}
