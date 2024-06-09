using System.ComponentModel.DataAnnotations;

namespace MobileCare.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string StreetAddress { get; set; }

        [Required]
        public required string Suburb { get; set; }

        [Required]
        public required string City { get; set; }

        [Required]
        public required string PostalCode { get; set; }

        [Required]
        public required string Country { get; set; }
    }
}
