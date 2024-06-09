using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileCare.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ApplicationUser")]
        public int ApplicationUserId { get; set; }
        [Required]

        [ForeignKey("Address")]
        public int AddressId { get; set; }
    }
}
