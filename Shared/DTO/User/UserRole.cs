using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.User
{
    public record UserRoleDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public record UserRoleForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }

    public record UserRoleForUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
    }
}
