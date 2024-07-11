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
                    Id = new Guid("f26edf00-3045-400e-94b4-95c1537adfc9"),
                    Name = "Monitors"
                },
                new Category
                {
                    Id = new Guid("3ae0f960-57a5-40b3-a1b6-b21e89b037f0"),
                    Name = "Keyboards"
                },
                new Category
                {
                    Id = new Guid("4b8fa9a2-f4ec-46d3-80e3-b0e6c0cc0fca"),
                    Name = "Mice"
                },
                new Category
                {
                    Id = new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"),
                    Name = "Printers"
                },
                new Category
                {
                    Id = new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"),
                    Name = "Routers"
                },
                new Category
                {
                    Id = new Guid("d3d0e04f-640e-42bc-8f47-6c65362b0905"),
                    Name = "Servers"
                }

            );
        }
    }
}
