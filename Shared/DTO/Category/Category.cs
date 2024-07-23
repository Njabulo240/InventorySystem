using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.Category
{
    public class CategoryForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string? Name { get; set; }
    }

    public class CategoryForUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string? Name { get; set; }
    }

    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }

}
