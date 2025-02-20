namespace HotelG2.Models
{
    public sealed class Department
    {
        public int Id { get; set; }

        public required string DepartmentName { get; set; }

        public string? Description { get; set; }
    }
}
