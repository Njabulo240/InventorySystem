namespace Entities.Models
{
    public class MaintenanceSchedule
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public Device Device { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }

}
