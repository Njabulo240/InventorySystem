using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.HasData(
                new Office
                {
                    Id = Guid.NewGuid(),
                    Name = "Office A",
                    Location = "Building 1, Floor 2"
                },
                new Office
                {
                    Id = Guid.NewGuid(),
                    Name = "Office B",
                    Location = "Building 2, Floor 1"
                },
                new Office
                {
                    Id = Guid.NewGuid(),
                    Name = "Office C",
                    Location = "Building 3, Floor 3"
                }
            );
        }
    }
}
