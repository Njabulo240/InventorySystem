using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.MaintenanceSchedule
{
    public class MaintenanceScheduleForCreationDto
    {
        [Required(ErrorMessage = "Device ID is required")]
        public Guid DeviceId { get; set; }

        [Required(ErrorMessage = "Scheduled Date is required")]
        public DateTime ScheduledDate { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(200, ErrorMessage = "Description can't be longer than 200 characters")]
        public string? Description { get; set; }
    }

    public class MaintenanceScheduleForUpdateDto
    {
        [Required(ErrorMessage = "Device ID is required")]
        public Guid DeviceId { get; set; }

        [Required(ErrorMessage = "Scheduled Date is required")]
        public DateTime ScheduledDate { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(200, ErrorMessage = "Description can't be longer than 200 characters")]
        public string Description { get; set; }
    }

    public class MaintenanceScheduleDto
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string? Description { get; set; }
    }

}
