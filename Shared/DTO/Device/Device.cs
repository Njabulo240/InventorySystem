using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.Device
{
    public class DeviceForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Category ID is required")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Brand ID is required")]
        public Guid BrandId { get; set; }

        [Required(ErrorMessage = "Supplier ID is required")]
        public Guid SupplierId { get; set; }

        [StringLength(200, ErrorMessage = "Description can't be longer than 200 characters")]
        public string? Description { get; set; }
    }

    public class DeviceForUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category ID is required")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Brand ID is required")]
        public Guid BrandId { get; set; }

        [Required(ErrorMessage = "Supplier ID is required")]
        public Guid SupplierId { get; set; }

        [StringLength(200, ErrorMessage = "Description can't be longer than 200 characters")]
        public string? Description { get; set; }
    }

    public class DeviceDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public Guid SupplierId { get; set; }
        public string? Description { get; set; }
    }

}
