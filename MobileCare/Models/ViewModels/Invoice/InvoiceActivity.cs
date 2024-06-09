using System.Text.Json.Serialization;

namespace MobileCare.Models.ViewModels.Invoice
{
    public class InvoiceActivity
    {
        [JsonPropertyName("name")]
        public required string Title { get; set; }

        [JsonPropertyName("quantity")]
        public int Hours { get; set; }

        [JsonPropertyName("unit_cost")]
        public double RatePerHour { get; set; }
    }
}
