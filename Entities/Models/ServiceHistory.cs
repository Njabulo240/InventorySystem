namespace Entities.Models
{
    public class ServiceHistory
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public Device Device { get; set; }
        public DateTime ServiceDate { get; set; }
        public string Description { get; set; }
        public string PerformedBy { get; set; }
    }

}
