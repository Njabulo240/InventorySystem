namespace Entities.Models
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ContactInfo { get; set; }
        public List<Device>? Devices { get; set; }
    }

}
