using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.DeviceAssignment
{
    public class DeviceAssignmentForCreationDto
    {
        [Required(ErrorMessage = "Device ID is required")]
        public Guid DeviceId { get; set; }

        [Required(ErrorMessage = "Employee ID is required")]
        public Guid EmployeeId { get; set; }

        [Required(ErrorMessage = "Assigned Date is required")]
        public DateTime AssignedDate { get; set; } = DateTime.Now;
    }

    public class DeviceAssignmentForOfficeDto
    {
        [Required(ErrorMessage = "Device ID is required")]
        public Guid DeviceId { get; set; }

        [Required(ErrorMessage = "Office ID is required")]
        public Guid OfficeId { get; set; }

        [Required(ErrorMessage = "Assigned Date is required")]
        public DateTime AssignedDate { get; set; } = DateTime.Now;
    }
    public class DeviceAssignmentForUpdateDto
    {
        [Required(ErrorMessage = "Device ID is required")]
        public Guid DeviceId { get; set; }

        [Required(ErrorMessage = "Employee ID is required")]
        public Guid EmployeeId { get; set; }

        [Required(ErrorMessage = "Assigned Date is required")]
        public DateTime AssignedDate { get; set; }
    }

    public class DeviceAssignmentDto
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public string? SerialNumber { get; set; }
        public string? CategoryName { get; set; }
        public string? BrandName { get; set; }
        public string? Name { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime AssignedDate { get; set; }
    }

}
