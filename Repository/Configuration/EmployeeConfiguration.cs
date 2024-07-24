using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Doe",
                    EmployeeNumber = "EMP001",
                    Position = "Software Engineer",
                    Email = "john.doe@example.com"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jane",
                    LastName = "Smith",
                    EmployeeNumber = "EMP002",
                    Position = "Project Manager",
                    Email = "jane.smith@example.com"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Alice",
                    LastName = "Johnson",
                    EmployeeNumber = "EMP003",
                    Position = "HR Coordinator",
                    Email = "alice.johnson@example.com"
                }
            );
        }
    }
}
