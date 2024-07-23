using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.Device
{
    public class DeviceForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Serial Number is required")]
        [StringLength(100, ErrorMessage = "Serial Number can't be longer than 100 characters")]
        public string? SerialNumber { get; set; }

        [Required(ErrorMessage = "Category ID is required")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Brand ID is required")]
        public Guid BrandId { get; set; }

        [Required(ErrorMessage = "Supplier ID is required")]
        public Guid SupplierId { get; set; }

        public bool IsFaulty { get; set; }
    }

    public class DeviceForUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Serial Number is required")]
        [StringLength(100, ErrorMessage = "Serial Number can't be longer than 100 characters")]
        public string? SerialNumber { get; set; }

        [Required(ErrorMessage = "Category ID is required")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Brand ID is required")]
        public Guid BrandId { get; set; }

        [Required(ErrorMessage = "Supplier ID is required")]
        public Guid SupplierId { get; set; }

        public bool IsFaulty { get; set; }
    }

    public class DeviceForAvailableUpdateDto
    {
        public bool IsAvailable { get; set; } = false;
    }

    public class DeviceDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? SerialNumber { get; set; }
        public Guid CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public Guid BrandId { get; set; }
        public string? BrandName { get; set; }
        public Guid SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public bool IsFaulty { get; set; }
    }

}
