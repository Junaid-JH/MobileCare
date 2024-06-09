using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileCare.Models
{
    public class BookingActivity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Booking")]
        public int BookingId { get; set; }

        [Required]
        [ForeignKey("ActivityOption")]
        public int ActivityId { get; set; }
        public string? BookingNote { get; set; }
        public string? ActivityNote { get; set; }
        public int Hours { get; set; }
    }
}
