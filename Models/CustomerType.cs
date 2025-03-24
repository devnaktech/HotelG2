using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Midterm.Models
{
    public class CustomerType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerTypeName { get; set; } = string.Empty;
    }
}
