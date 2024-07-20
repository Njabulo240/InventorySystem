using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.Supplier
{
    public class SupplierForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string? Name { get; set; }

        [StringLength(100, ErrorMessage = "Contact can't be longer than 100 characters")]
        public string? ContactInfo { get; set; }
    }

    public class SupplierForUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string? Name { get; set; }

        [StringLength(100, ErrorMessage = "Contact can't be longer than 100 characters")]
        public string? ContactInfo { get; set; }
    }

    public class SupplierDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ContactInfo { get; set; }
    }

}
