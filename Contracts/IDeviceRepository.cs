using Entities.Models;

namespace Contracts
{
    public interface IDeviceRepository
    {

        Task<IEnumerable<Device>> GetAllDevicesAsync(bool trackChanges);
        Task<Device> GetDeviceByIdAsync(Guid deviceId, bool trackChanges);
        Task<Device> GetDeviceWithDetailsAsync(Guid deviceId, bool trackChanges);
        void CreateDevice(Device device);
        void UpdateDevice(Device device);
        void DeleteDevice(Device device);
    }
}
