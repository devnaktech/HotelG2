namespace LMC103.Models
{
    public sealed class Customer : BaseEntity
    {
        public int CustomerId { get; set; }

        public decimal? Income { get; set; } = 0;

        public decimal? Expense { get; set; } = 0;

        public string? IdCard { get; set; } = string.Empty;

        public string? PasswordNo { get; set; } = string.Empty;
    }
}
