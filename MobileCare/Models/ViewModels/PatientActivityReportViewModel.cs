namespace MobileCare.Models.ViewModels
{
    public class PatientActivityReportViewModel
    {
        public int ApplicationUserId { get; set; }
        public DateTime Date { get; set; }
        public required string PatientFullName { get; set; }
        public required string Title { get; set; }
        public string? ActivityReport { get; set; }
    }
}
