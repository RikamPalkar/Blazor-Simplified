using RestSharp;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace ForExFlow.Shared.Services
{
    public class ForexRateService : IForexRateService
    {
        private readonly RestClient _client;

        public ForexRateService()
        {
            _client = new RestClient("https://api.exchangerate-api.com/v4/latest/");
        }

        public async Task<Dictionary<string, decimal>> GetExchangeRatesAsync(string baseCurrency)
        {
            var url = $"{baseCurrency}";
            var request = new RestRequest(url, Method.Get);
            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to fetch exchange rates.");
            }

            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var data = JsonSerializer.Deserialize<ExchangeRateResponse>(response.Content, options);

            if (data == null || data.Rates == null)
            {
                throw new Exception("No exchange rates found in the response.");
            }
            return data.Rates;
        }

        private class ExchangeRateResponse
        {
            public string Base { get; set; }
            public string Date { get; set; }
            public Dictionary<string, decimal> Rates { get; set; }
            public string Provider { get; set; }
            public string WarningUpgradeToV6 { get; set; }
            public string Terms { get; set; }
            public int TimeLastUpdated { get; set; }
        }
    }
}
