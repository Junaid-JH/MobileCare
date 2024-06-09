namespace MobileCare.Models.ViewModels
{
    public class BookingActivityViewModel
    {
        public int BookingId { get; set; }
        public int ActivityId { get; set; }
        public required string PatientName { get; set; }
        public string? BookingNote { get; set; }
        public required string Title { get; set; }
        public string? ActivityNote { get; set; }
    }
}
