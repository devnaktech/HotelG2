namespace Midterm.Models
{
    public class BaseEntity
    {
        public required string FirstName { get; set; } = string.Empty;
        public required string LastName { get; set; } = string.Empty;
        public required string Gender { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}