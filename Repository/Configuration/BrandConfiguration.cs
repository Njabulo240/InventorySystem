using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand
                {
                    Id = new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"),
                    Name = "Apple"
                },
                new Brand
                {
                    Id = new Guid("302a431a-2f54-4768-8a34-b6414f3909df"),
                    Name = "Samsung"
                },
                new Brand
                {
                    Id = new Guid("14c1b3fb-57d0-48f5-aa4a-130a1ab629c0"),
                    Name = "Dell"
                },
                new Brand
                {
                    Id = new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"),
                    Name = "Lenovo"
                },
                new Brand
                {
                    Id = new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"),
                    Name = "HP"
                }
            );
        }
    }
}