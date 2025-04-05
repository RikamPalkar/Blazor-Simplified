namespace ForExFlow.Shared.Services
{
    public interface IForexRateService
    {
        Task<Dictionary<string, decimal>> GetExchangeRatesAsync(string inputCurrency);
    }
}
