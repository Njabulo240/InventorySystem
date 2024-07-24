using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasData(
                // Devices for Laptops category
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop X1",
                    SerialNumber = "SN123456",
                    CategoryId = new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"),
                    BrandId = new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"),
                    SupplierId = new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662"),
                    IsFaulty = false
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop X2",
                    SerialNumber = "SN789012",
                    CategoryId = new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"),
                    BrandId = new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"),
                    SupplierId = new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662"),
                    IsFaulty = false
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop X3",
                    SerialNumber = "SN345678",
                    CategoryId = new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"),
                    BrandId = new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"),
                    SupplierId = new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662"),
                    IsFaulty = false
                },

                // Devices for Desktops category
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Desktop Y1",
                    SerialNumber = "SN246810",
                    CategoryId = new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"),
                    BrandId = new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"),
                    SupplierId = new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0"),
                    IsFaulty = false
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Desktop Y2",
                    SerialNumber = "SN567890",
                    CategoryId = new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"),
                    BrandId = new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"),
                    SupplierId = new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0"),
                    IsFaulty = false
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Desktop Y3",
                    SerialNumber = "SN112233",
                    CategoryId = new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"),
                    BrandId = new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"),
                    SupplierId = new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0"),
                    IsFaulty = false
                },

                // Devices for Printers category (example)
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Printer Z1",
                    SerialNumber = "SN987654",
                    CategoryId = new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"),
                    BrandId = new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"),
                    SupplierId = new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"),
                    IsFaulty = false
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Printer Z2",
                    SerialNumber = "SN456789",
                    CategoryId = new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"),
                    BrandId = new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"),
                    SupplierId = new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"),
                    IsFaulty = false
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Printer Z3",
                    SerialNumber = "SN135790",
                    CategoryId = new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"),
                    BrandId = new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"),
                    SupplierId = new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"),
                    IsFaulty = false
                },
                 new Device
                 {
                     Id = Guid.NewGuid(),
                     Name = "Mobile Phone M1",
                     SerialNumber = "SN789012",
                     CategoryId = new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"),
                     BrandId = new Guid("302a431a-2f54-4768-8a34-b6414f3909df"),
                     SupplierId = new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"),
                     IsFaulty = false
                 },
            new Device
            {
                Id = Guid.NewGuid(),
                Name = "Mobile Phone M2",
                SerialNumber = "SN456789",
                CategoryId = new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"),
                BrandId = new Guid("302a431a-2f54-4768-8a34-b6414f3909df"),
                SupplierId = new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"),
                IsFaulty = false
            },
            new Device
            {
                Id = Guid.NewGuid(),
                Name = "Mobile Phone M3",
                SerialNumber = "SN135790",
                CategoryId = new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"),
                BrandId = new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"),
                SupplierId = new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"),
                IsFaulty = false
            }
            );
        }
    }

}
