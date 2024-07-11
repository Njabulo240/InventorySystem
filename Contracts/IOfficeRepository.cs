using Entities.Models;

namespace Contracts
{
    public interface IOfficeRepository
    {
        Task<IEnumerable<Office>> GetAllOfficesAsync(bool trackChanges);
        Task<Office> GetOfficeByIdAsync(Guid officeId, bool trackChanges);
        void CreateOffice(Office office);
        void UpdateOffice(Office office);
        void DeleteOffice(Office office);
    }
}
