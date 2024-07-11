namespace Entities.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public List<DeviceAssignment> DeviceAssignments { get; set; }
    }

}
