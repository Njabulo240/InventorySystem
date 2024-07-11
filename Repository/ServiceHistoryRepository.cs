using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ServiceHistoryRepository : RepositoryBase<ServiceHistory>, IServiceHistoryRepository
    {
        public ServiceHistoryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateServiceHistory(ServiceHistory serviceHistory)
        {
            Create(serviceHistory);
        }

        public void DeleteServiceHistory(ServiceHistory serviceHistory)
        {
            Delete(serviceHistory);
        }

        public async Task<IEnumerable<ServiceHistory>> GetAllServiceHistoriesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(sh => sh.ServiceDate).ToListAsync();
        }

        public async Task<ServiceHistory> GetServiceHistoryByIdAsync(Guid serviceHistoryId, bool trackChanges)
        {
            return await FindByCondition(sh => sh.Id.Equals(serviceHistoryId), trackChanges)
     .FirstOrDefaultAsync();
        }

        public void UpdateServiceHistory(ServiceHistory serviceHistory)
        {
            Update(serviceHistory);
        }
    }
}
