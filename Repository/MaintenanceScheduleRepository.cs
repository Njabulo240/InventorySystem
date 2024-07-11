using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class MaintenanceScheduleRepository : RepositoryBase<MaintenanceSchedule>, IMaintenanceScheduleRepository
    {
        public MaintenanceScheduleRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateMaintenanceSchedule(MaintenanceSchedule maintenanceSchedule)
        {
            Create(maintenanceSchedule);
        }

        public void DeleteMaintenanceSchedule(MaintenanceSchedule maintenanceSchedule)
        {
            Delete(maintenanceSchedule);
        }

        public async Task<IEnumerable<MaintenanceSchedule>> GetAllMaintenanceSchedulesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(ms => ms.DeviceId).ToListAsync();
        }

        public async Task<MaintenanceSchedule> GetMaintenanceScheduleByIdAsync(Guid maintenanceScheduleId, bool trackChanges)
        {
            return await FindByCondition(ms => ms.Id.Equals(maintenanceScheduleId), trackChanges)
    .FirstOrDefaultAsync();
        }

        public void UpdateMaintenanceSchedule(MaintenanceSchedule maintenanceSchedule)
        {
            Update(maintenanceSchedule);
        }
    }
}
