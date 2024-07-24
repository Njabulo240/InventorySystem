using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"),
                    Name = "Laptops"
                },
                new Category
                {
                    Id = new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"),
                    Name = "Desktops"
                },

                new Category
                {
                    Id = new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"),
                    Name = "Printers"
                },
                new Category
                {
                    Id = new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"),
                    Name = "Mobile Phone"
                }

            );
        }
    }
}
