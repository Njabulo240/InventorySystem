using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.User
{
    public record UserRoleDto
    {
        public string? RoleName { get; set; }
    }

    public record UserRoleForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
    }

    public record UserRoleForUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
    }
}
