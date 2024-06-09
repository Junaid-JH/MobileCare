using System.ComponentModel.DataAnnotations;

namespace MobileCare.Models
{
    public class ActivityOption
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }
        public double RatePerHour { get; set; }
    }
}
