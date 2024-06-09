using System.Text.Json.Serialization;

namespace MobileCare.Models.ViewModels.Invoice
{
    public class InvoiceField
    {
        [JsonPropertyName("tax")]
        public required string Tax { get; set; }
    }
}
