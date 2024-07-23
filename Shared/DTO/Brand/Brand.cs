using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.Brand
{
    public class BrandForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string? Name { get; set; }
    }

    public class BrandForUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string? Name { get; set; }
    }

    public class BrandDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }

}
