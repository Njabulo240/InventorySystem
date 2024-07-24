using Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(
              new UserRole
              {
                  Id = "cfa9978f-2afd-4786-9cf9-97b4493f4d34",
                  Name = "Admin",
                  NormalizedName = "ADMIN",
                  DateCreated = new DateTime(2015, 10, 13),
              },
              new UserRole
              {
                  Id = "6a670f0d-a08f-4bba-b1fd-9b6df6e42d70",
                  Name = "User",
                  NormalizedName = "USER",
                  DateCreated = new DateTime(2015, 10, 13),
              }
            );
        }
    }
}
