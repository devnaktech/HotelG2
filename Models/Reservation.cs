using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Midterm.Models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationId { get; set; }

        public bool IsHidden { get; set; } = false;

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        public bool IsCheckIn { get; set; } = false;

        [Required]
        public int NumberOfDays { get; set; }

        [Required]
        public int NumberOfAdults { get; set; }

        [Required]
        public int NumberOfChildren { get; set; }

        [StringLength(500)]
        public string? Memo { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        public bool IsCheckOut { get; set; } = false;

        // Navigation property for related ReservationDetails
        public ICollection<ReservationDetail>? ReservationDetails { get; set; }
    }
}
