using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DeviceRepository : RepositoryBase<Device>, IDeviceRepository
    {
        public DeviceRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateDevice(Device device)
        {
            Create(device);
        }

        public void DeleteDevice(Device device)
        {
            Delete(device);
        }

        public async Task<IEnumerable<Device>> GetAllDevicesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(ow => ow.Name).ToListAsync();
        }

        public async Task<Device> GetDeviceByIdAsync(Guid deviceId, bool trackChanges)
        {
            return await FindByCondition(device => device.Id.Equals(deviceId), trackChanges)
              .FirstOrDefaultAsync();

        }

        public async Task<Device> GetDeviceWithDetailsAsync(Guid deviceId, bool trackChanges)
        {
            return await FindByCondition(device => device.Id.Equals(deviceId), trackChanges)
              .Include(d => d.Category)
              .Include(d => d.Brand)
              .Include(d => d.Supplier)
              .Include(d => d.CurrentAssignment)
              .FirstOrDefaultAsync();
        }

        public void UpdateDevice(Device device)
        {
            Update(device);
        }
    }
}