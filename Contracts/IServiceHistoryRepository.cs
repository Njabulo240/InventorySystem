using Entities.Models;

namespace Contracts
{
    public interface IServiceHistoryRepository
    {
        Task<IEnumerable<ServiceHistory>> GetAllServiceHistoriesAsync(bool trackChanges);
        Task<ServiceHistory> GetServiceHistoryByIdAsync(Guid serviceHistoryId, bool trackChanges);
        void CreateServiceHistory(ServiceHistory serviceHistory);
        void UpdateServiceHistory(ServiceHistory serviceHistory);
        void DeleteServiceHistory(ServiceHistory serviceHistory);
    }
}
