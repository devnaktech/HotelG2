
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Midterm.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        public bool IsHidden { get; set; } = false;

        [Required]
        [StringLength(50)]
        public string CustomerCode { get; set; } = string.Empty;

        [Required]
        public int CustomerTypeId { get; set; }

        [ForeignKey("CustomerTypeId")]
        public CustomerType? CustomerType { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [StringLength(2)]
        public string Sex { get; set; } = string.Empty;

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string PassportNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Country { get; set; } = string.Empty;
    }
}
