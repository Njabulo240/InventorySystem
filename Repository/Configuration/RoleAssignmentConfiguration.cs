using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class RoleAssignmentConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "a2bd32c0-d75e-4966-8274-758e273da3fb",
                    RoleId = "cfa9978f-2afd-4786-9cf9-97b4493f4d34"
                }
            );
        }
    }
}
