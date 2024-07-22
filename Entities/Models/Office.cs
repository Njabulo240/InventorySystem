namespace Entities.Models
{
    public class Office
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public List<DeviceAssignment>? DeviceAssignments { get; set; }
    }

}
