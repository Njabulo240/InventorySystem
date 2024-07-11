using AutoMapper;
using Entities.Models;
using Shared.DTO.Brand;
using Shared.DTO.Category;
using Shared.DTO.Device;
using Shared.DTO.DeviceAssignment;
using Shared.DTO.Employee;
using Shared.DTO.MaintenanceSchedule;
using Shared.DTO.Office;
using Shared.DTO.ServiceHistory;
using Shared.DTO.Supplier;
using Shared.DTO.User;

namespace InventrySystem
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<UserForRegistrationDto, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));

            CreateMap<Device, DeviceDto>();
            CreateMap<DeviceForCreationDto, Device>();
            CreateMap<DeviceForUpdateDto, Device>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryForCreationDto, Category>();
            CreateMap<CategoryForUpdateDto, Category>();

            CreateMap<Brand, BrandDto>();
            CreateMap<BrandForCreationDto, Brand>();
            CreateMap<BrandForUpdateDto, Brand>();

            CreateMap<Supplier, SupplierDto>();
            CreateMap<SupplierForCreationDto, Supplier>();
            CreateMap<SupplierForUpdateDto, Supplier>();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>();

            CreateMap<Office, OfficeDto>();
            CreateMap<OfficeForCreationDto, Office>();
            CreateMap<OfficeForUpdateDto, Office>();

            CreateMap<DeviceAssignment, DeviceAssignmentDto>();
            CreateMap<DeviceAssignmentForCreationDto, DeviceAssignment>();
            CreateMap<DeviceAssignmentForUpdateDto, DeviceAssignment>();

            CreateMap<MaintenanceSchedule, MaintenanceScheduleDto>();
            CreateMap<MaintenanceScheduleForCreationDto, MaintenanceSchedule>();
            CreateMap<MaintenanceScheduleForUpdateDto, MaintenanceSchedule>();

            CreateMap<ServiceHistory, ServiceHistoryDto>();
            CreateMap<ServiceHistoryForCreationDto, ServiceHistory>();
            CreateMap<ServiceHistoryForUpdateDto, ServiceHistory>();
        }
    }
}
