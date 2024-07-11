using Microsoft.AspNetCore.Identity;

namespace Entities.Identity
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
