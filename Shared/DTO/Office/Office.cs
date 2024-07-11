using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.Office
{
    public class OfficeForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string? Name { get; set; }

        [StringLength(100, ErrorMessage = "Location can't be longer than 100 characters")]
        public string? Location { get; set; }
    }

    public class OfficeForUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "Location can't be longer than 100 characters")]
        public string Location { get; set; }
    }

    public class OfficeDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
    }

}
