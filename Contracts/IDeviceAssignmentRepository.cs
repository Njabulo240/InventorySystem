using Entities.Models;

namespace Contracts
{
    public interface IDeviceAssignmentRepository
    {
        Task<IEnumerable<DeviceAssignment>> GetAllDeviceAssignmentsAsync(bool trackChanges);
        Task<DeviceAssignment> GetDeviceAssignmentByIdAsync(Guid deviceAssignmentId, bool trackChanges);
        void CreateDeviceAssignment(DeviceAssignment deviceAssignment);
        void UpdateDeviceAssignment(DeviceAssignment deviceAssignment);
        void DeleteDeviceAssignment(DeviceAssignment deviceAssignment);
    }
}
