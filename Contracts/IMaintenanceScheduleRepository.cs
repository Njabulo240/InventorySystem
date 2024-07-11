using Entities.Models;

namespace Contracts
{
    public interface IMaintenanceScheduleRepository
    {
        Task<IEnumerable<MaintenanceSchedule>> GetAllMaintenanceSchedulesAsync(bool trackChanges);
        Task<MaintenanceSchedule> GetMaintenanceScheduleByIdAsync(Guid maintenanceScheduleId, bool trackChanges);
        void CreateMaintenanceSchedule(MaintenanceSchedule maintenanceSchedule);
        void UpdateMaintenanceSchedule(MaintenanceSchedule maintenanceSchedule);
        void DeleteMaintenanceSchedule(MaintenanceSchedule maintenanceSchedule);
    }
}
