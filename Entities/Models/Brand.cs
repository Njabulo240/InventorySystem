namespace Entities.Models
{
    public class Brand
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public List<Device>? Devices { get; set; }
    }

}
