namespace Contracts
{
    public interface IRepositoryManager
    {
        IDeviceRepository Device { get; }
        ICategoryRepository Category { get; }
        IBrandRepository Brand { get; }
        ISupplierRepository Supplier { get; }
        IEmployeeRepository Employee { get; }
        IOfficeRepository Office { get; }
        IDeviceAssignmentRepository DeviceAssignment { get; }
        IMaintenanceScheduleRepository MaintenanceSchedule { get; }
        IServiceHistoryRepository ServiceHistory { get; }
        void SaveAsync();
    }
}
