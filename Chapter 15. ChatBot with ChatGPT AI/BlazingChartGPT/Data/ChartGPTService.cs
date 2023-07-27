using Newtonsoft.Json;
using System.Text;

namespace BlazingChartGPT.Data
{
    public class ChartGPTService
    {
        private readonly HttpClient _httpClient;

        public ChartGPTService(string baseUrl, string apiKey)
        {
            _httpClient = new();
            _httpClient.BaseAddress = new Uri(baseUrl);
            _httpClient.DefaultRequestHeaders.Add("authorization", $"Bearer {apiKey}");
        }

        public async Task<string> GetResponse(string query)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _httpClient.BaseAddress)
            {
                Content = new StringContent("{\"model\": \"text-davinci-001\", \"prompt\": \"" + 
                                            query +
                                            "\",\"temperature\": 1,\"max_tokens\": 100}",
                                            Encoding.UTF8,
                                            "application/json")
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseString = JsonConvert.DeserializeObject<dynamic>(responseContent);

            return responseString!.choices[0].text;
        }
    }
}

