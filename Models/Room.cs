using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Midterm.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }

        [Required]
        [StringLength(50)]
        public string RoomName { get; set; } = string.Empty; 

        public bool IsHidden { get; set; } = false;  

        [Required]
        public int RoomTypeId { get; set; }  

        [ForeignKey("RoomTypeId")]
        public RoomType? RoomType { get; set; }
    }
}
