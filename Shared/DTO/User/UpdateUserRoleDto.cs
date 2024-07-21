using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.User
{
    public class UpdateUserRoleDto
    {
        [Required]
        public List<string>? Roles { get; set; }
    }
}
