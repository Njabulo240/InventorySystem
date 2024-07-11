namespace Shared.DTO.User
{
    public class UserForUpdateDto
    {
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public ICollection<string>? Roles { get; init; } = new List<string>();
    }
}
