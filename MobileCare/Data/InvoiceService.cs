using System.Text;
using System.Text.Json;
using MobileCare.Models.ViewModels.Invoice;

namespace MobileCare.Data
{
    public class InvoiceService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public InvoiceService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://invoice-generator.com");
            _apiKey = Environment.GetEnvironmentVariable("API_KEY");
        }

        public async Task<byte[]> GenerateInvoiceAsync(Task<InvoiceViewModel> invoice)
        {
            var json = JsonSerializer.Serialize(invoice.Result);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Add the API key to the headers
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            var response = await _httpClient.PostAsync(_httpClient.BaseAddress, content);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsByteArrayAsync();
            }

            throw new HttpRequestException(response.ReasonPhrase);
        }
    }
}
