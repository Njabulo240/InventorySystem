using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DTO.Device;

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

        public async Task<IEnumerable<Device>> GetAllAvailableDevicesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(ow => ow.Name)
               .Include(d => d.Category)
               .Include(d => d.Brand)
               .Include(d => d.Supplier)
               .Where(d => d.IsAvailable == true)
               .ToListAsync();
        }

        public async Task<IEnumerable<Device>> GetAllDevicesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(ow => ow.Name)
                 .Include(d => d.Category)
                 .Include(d => d.Brand)
                 .Include(d => d.Supplier)
                 .Where(d => d.IsFaulty == false)
                 .ToListAsync();
        }

        public async Task<IEnumerable<Device>> GetAllFaultDevicesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(ow => ow.Name)
             .Include(d => d.Category)
             .Include(d => d.Brand)
             .Include(d => d.Supplier)
             .Where(d => d.IsFaulty == true)
             .ToListAsync();
        }

        public async Task<Device> GetDeviceByIdAsync(Guid deviceId, bool trackChanges)
        {
            return await FindByCondition(device => device.Id.Equals(deviceId), trackChanges)
              .FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<CategoryDeviceCountDto>> GetDeviceCountPerCategoryAsync(bool trackChanges)
        {
            var result = await FindAll(trackChanges)
                           .Include(d => d.Category)
                           .GroupBy(d => d.Category.Name)
                           .Select(g => new CategoryDeviceCountDto
                           {
                               CategoryName = g.Key,
                               TotalDevices = g.Count(),
                               Available = g.Count(d => d.IsAvailable),
                               Faulty = g.Count(d => d.IsFaulty)
                           }).ToListAsync();

            return result;
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