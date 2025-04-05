using Microsoft.AspNetCore.Components;

namespace ForExFlow.Shared.Pages
{
    public partial class ForexComponent : ComponentBase
    {
        [Inject]
        private Services.IForexRateService ForexService { get; set; }

        private Dictionary<string, decimal> ExchangeRates;
        private string BaseCurrency = "USD";
        private List<string> Currencies = new List<string> { "USD", "EUR", "GBP", "JPY", "AUD" };
        private decimal userInput = 1; // Default input value (1, meaning no multiplication by default)

        protected override async Task OnInitializedAsync()
        {
            await FetchExchangeRates();
        }

        private async Task FetchExchangeRates()
        {
            ExchangeRates = await ForexService.GetExchangeRatesAsync(BaseCurrency);
        }

        private async Task OnBaseCurrencyChange(ChangeEventArgs e)
        {
            BaseCurrency = e.Value?.ToString() ?? "USD";
            await FetchExchangeRates();
        }

        private decimal MultiplyRate(decimal rate)
        {
            return rate * userInput;
        }

        private void ConvertRates()
        {
            StateHasChanged();
        }
    }
}
