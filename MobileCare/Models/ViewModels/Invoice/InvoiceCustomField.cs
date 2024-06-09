using System.Text.Json.Serialization;

namespace MobileCare.Models.ViewModels.Invoice
{
    public class InvoiceCustomField
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("value")]
        public required string Value { get; set; }
    }
}
