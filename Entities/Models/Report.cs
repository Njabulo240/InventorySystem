namespace Entities.Models
{
    public class Report
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime GeneratedDate { get; set; }
        public string? Content { get; set; }
    }

}
