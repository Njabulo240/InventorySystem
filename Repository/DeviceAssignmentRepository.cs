using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DeviceAssignmentRepository : RepositoryBase<DeviceAssignment>, IDeviceAssignmentRepository
    {
        public DeviceAssignmentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateDeviceAssignment(DeviceAssignment deviceAssignment)
        {
            Create(deviceAssignment);
        }

        public void DeleteDeviceAssignment(DeviceAssignment deviceAssignment)
        {
            Delete(deviceAssignment);
        }

        public async Task<IEnumerable<DeviceAssignment>> GetAllDeviceAssignmentsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(da => da.AssignedDate).ToListAsync();
        }

        public async Task<DeviceAssignment> GetDeviceAssignmentByIdAsync(Guid deviceAssignmentId, bool trackChanges)
        {
            return await FindByCondition(da => da.Id.Equals(deviceAssignmentId), trackChanges)
             .FirstOrDefaultAsync();
        }

        public void UpdateDeviceAssignment(DeviceAssignment deviceAssignment)
        {
            Update(deviceAssignment);
        }
    }
}
