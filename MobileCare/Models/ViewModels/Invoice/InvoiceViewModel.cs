using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MobileCare.Models.ViewModels.Invoice
{
    public class InvoiceViewModel
    {
        [JsonPropertyName("from")]
        public required string From { get; set; }

        [JsonPropertyName("to")]
        public required string To { get; set; }

        [JsonPropertyName("logo")]
        public required string Logo { get; set; }

        [JsonPropertyName("number")]
        public required string Number { get; set; }

        [JsonPropertyName("currency")]
        public required string Currency { get; set; }

        [JsonPropertyName("due_date")]
        public required string DueDate { get; set; }

        [JsonPropertyName("fields")]
        public InvoiceField Fields { get; set; }

        [JsonPropertyName("tax")]
        public int Tax { get; set; }

        [JsonPropertyName("notes")]
        public required string Notes { get; set; }

        [JsonPropertyName("terms")]
        public required string Terms { get; set; }

        [JsonPropertyName("item_header")]
        public required string ItemHeader { get; set; }

        [JsonPropertyName("quantity_header")]
        public required string QuantityHeader { get; set; }

        [JsonPropertyName("custom_fields")]
        public List<InvoiceCustomField> InvoiceCustomFields { get; set; }

        [JsonPropertyName("items")]
        public List<InvoiceActivity> InvoiceActivities { get; set; }
    }
}
