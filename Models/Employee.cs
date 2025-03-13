namespace Midterm.Models
{
    public class Employee : BaseEntity
    {
        public int EmployeeId { get; set; }
        public decimal? Salary { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public DateTime? HireDate { get; set; }


        public string? Position { get; set; }
    }
}