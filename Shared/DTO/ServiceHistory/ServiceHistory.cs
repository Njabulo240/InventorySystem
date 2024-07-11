using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.ServiceHistory
{
    public class ServiceHistoryForCreationDto
    {
        [Required(ErrorMessage = "Device ID is required")]
        public Guid DeviceId { get; set; }

        [Required(ErrorMessage = "Service Date is required")]
        public DateTime ServiceDate { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(200, ErrorMessage = "Description can't be longer than 200 characters")]
        public string? Description { get; set; }
    }

    public class ServiceHistoryForUpdateDto
    {
        [Required(ErrorMessage = "Device ID is required")]
        public Guid DeviceId { get; set; }

        [Required(ErrorMessage = "Service Date is required")]
        public DateTime ServiceDate { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(200, ErrorMessage = "Description can't be longer than 200 characters")]
        public string Description { get; set; }
    }

    public class ServiceHistoryDto
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public DateTime ServiceDate { get; set; }
        public string? Description { get; set; }
    }

}
