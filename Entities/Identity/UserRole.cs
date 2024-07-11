using Microsoft.AspNetCore.Identity;

namespace Entities.Identity
{
    public class UserRole : IdentityRole
    {
        public DateTime DateCreated { get; set; }
    }
}
