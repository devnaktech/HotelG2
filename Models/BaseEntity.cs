namespace LMC103.Models
{
    public abstract class BaseEntity
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Gender { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? Description { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime? Updated { get; set; } = DateTime.Now;
    }
}
