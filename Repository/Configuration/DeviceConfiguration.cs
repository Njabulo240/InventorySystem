using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            // Define device data
            builder.HasData(
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop X1",
                    SerialNumber = "SN123456",
                    CategoryId = new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"),
                    BrandId = new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"),
                    SupplierId = new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0"),
                    IsFaulty = false
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Desktop Y2",
                    SerialNumber = "SN654321",
                    CategoryId = new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"),
                    BrandId = new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"),
                    SupplierId = new Guid("7360be35-feab-46c7-b250-bdf5f894bdc9"),
                    IsFaulty = false
                }

            );
        }
    }
}
