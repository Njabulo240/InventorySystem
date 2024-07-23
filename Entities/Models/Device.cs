namespace Entities.Models
{
    public class Device
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? SerialNumber { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public Guid BrandId { get; set; }
        public Brand? Brand { get; set; }
        public Guid SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public bool IsFaulty { get; set; }
        public bool IsAvailable { get; set; }
        public DeviceAssignment? CurrentAssignment { get; set; }
        public List<MaintenanceSchedule>? MaintenanceSchedules { get; set; }
        public List<ServiceHistory>? ServiceHistories { get; set; }
    }


}
