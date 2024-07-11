using Entities.Models;

namespace Contracts
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync(bool trackChanges);
        Task<Supplier> GetSupplierByIdAsync(Guid supplierId, bool trackChanges);
        void CreateSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(Supplier supplier);
    }
}
