namespace Entities.Models
{
    public class DeviceAssignment
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public Device? Device { get; set; }
        public Guid? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public Guid? OfficeId { get; set; }
        public Office? Office { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public bool IsActive { get; set; }
    }


}
