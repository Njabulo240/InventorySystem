using Entities.Models;
using Shared.DTO.Device;

namespace Contracts
{
    public interface IDeviceRepository
    {

        Task<IEnumerable<Device>> GetAllDevicesAsync(bool trackChanges);
        Task<IEnumerable<Device>> GetAllAvailableDevicesAsync(bool trackChanges);
        Task<IEnumerable<Device>> GetAllFaultDevicesAsync(bool trackChanges);
        Task<Device> GetDeviceByIdAsync(Guid deviceId, bool trackChanges);
        Task<Device> GetDeviceWithDetailsAsync(Guid deviceId, bool trackChanges);
        Task<IEnumerable<CategoryDeviceCountDto>> GetDeviceCountPerCategoryAsync(bool trackChanges);
        void CreateDevice(Device device);
        void UpdateDevice(Device device);
        void DeleteDevice(Device device);
    }
}
