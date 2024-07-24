using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasData(
                new Supplier
                {
                    Id = new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"),
                    Name = "CompuParts Eswatini",
                    ContactInfo = "Contact info for CompuParts"
                },
                new Supplier
                {
                    Id = new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0"),
                    Name = "DataNet Eswatini",
                    ContactInfo = "Contact info for DataNet"
                },
                new Supplier
                {
                    Id = new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662"),
                    Name = "Omega IT Eswatini",
                    ContactInfo = "Contact info for Omega IT"
                }
            );
        }
    }
}
