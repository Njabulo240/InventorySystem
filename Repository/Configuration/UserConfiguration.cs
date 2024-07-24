using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = "a2bd32c0-d75e-4966-8274-758e273da3fb",
                    UserName = "user@example.com",
                    NormalizedUserName = "USER@EXAMPLE.COM",
                    Email = "user@example.com",
                    NormalizedEmail = "USER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<User>().HashPassword(null, "Password.123"),
                    SecurityStamp = string.Empty,
                    FirstName = "John",
                    LastName = "Doe"
                },
                 new User
                 {
                     Id = "d7930984-3648-45c8-b33e-7b902e1166b4",
                     UserName = "user2@example.com",
                     NormalizedUserName = "USER2@EXAMPLE.COM",
                     Email = "user2@example.com",
                     NormalizedEmail = "USER2@EXAMPLE.COM",
                     EmailConfirmed = true,
                     PasswordHash = new PasswordHasher<User>().HashPassword(null, "Password.123"),
                     SecurityStamp = string.Empty,
                     FirstName = "John2",
                     LastName = "Doe2"
                 }
            // Add more users as needed
            );
        }
    }
}
