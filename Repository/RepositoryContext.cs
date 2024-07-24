using Entities.Identity;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User, UserRole, string>
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleAssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            modelBuilder.Entity<Device>()
           .HasOne(d => d.Category)
           .WithMany(c => c.Devices)
           .HasForeignKey(d => d.CategoryId);

            modelBuilder.Entity<Device>()
                .HasOne(d => d.Brand)
                .WithMany(b => b.Devices)
                .HasForeignKey(d => d.BrandId);

            modelBuilder.Entity<Device>()
                .HasOne(d => d.Supplier)
                .WithMany(s => s.Devices)
                .HasForeignKey(d => d.SupplierId);

            modelBuilder.Entity<Device>()
                .HasOne(d => d.CurrentAssignment)
                .WithOne(da => da.Device)
                .HasForeignKey<DeviceAssignment>(da => da.DeviceId);

            modelBuilder.Entity<DeviceAssignment>()
                .HasOne(da => da.Employee)
                .WithMany(e => e.DeviceAssignments)
                .HasForeignKey(da => da.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DeviceAssignment>()
                .HasOne(da => da.Office)
                .WithMany(o => o.DeviceAssignments)
                .HasForeignKey(da => da.OfficeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MaintenanceSchedule>()
                .HasOne(ms => ms.Device)
                .WithMany(d => d.MaintenanceSchedules)
                .HasForeignKey(ms => ms.DeviceId);

            modelBuilder.Entity<ServiceHistory>()
                .HasOne(sh => sh.Device)
                .WithMany(d => d.ServiceHistories)
                .HasForeignKey(sh => sh.DeviceId);
        }

        // public DbSet<Company>? Companies { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<DeviceAssignment> DeviceAssignments { get; set; }
        public DbSet<MaintenanceSchedule> MaintenanceSchedules { get; set; }
        public DbSet<ServiceHistory> ServiceHistories { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}
