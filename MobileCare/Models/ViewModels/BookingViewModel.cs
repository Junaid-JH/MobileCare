namespace MobileCare.Models.ViewModels
{
    public class BookingViewModel
    {
        public int BookingId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public required string PatientFullName { get; set; }
        public required string CareworkerFullName { get; set; }
        public int ApplicationUserId { get; set; }
        public int PatientId { get; set; }
        public required string StreetAddress { get; set; }
        public required string Suburb { get; set; }
        public required string City { get; set; }
        public required string PostalCode { get; set; }
        public required string Country { get; set; }
    }
}
