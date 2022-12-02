using Application.Prices.Commands.AddEdit;
using MediatR;
using Shared.Dtos;
using System.Text.Json;

namespace Application.ApiBE
{
    public class SymbolService : ISymbolService
    {
        private readonly string symbolToCompare = "SYP";
        readonly SymbolConfig config;
        readonly IMediator mediator;
        public SymbolService(IMediator mediator, SymbolConfig config)
        {
            this.mediator = mediator;
            this.config = config;
        }
        public async Task<Root> GetSymbolHistoricalDataAsync(string symbol, int days)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{config.BaseAddress}{symbol}"),
                Headers =
                    {
                        { "X-RapidAPI-Key", config.Key },
                        { "X-RapidAPI-Host", config.Host },
                    },
            };
            var obj = new Root();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    obj = JsonSerializer.Deserialize<Root>(body,
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    obj!.symbol = symbol;
                }
            }
            return obj;
        }
        public async Task<List<Performance>> GetWeekPerformanceComparison(string symbol, int days)
        {
            var symbolToCompare = "SPY";
            var symbolHistoricalRootData = await GetSymbolHistoricalDataAsync(symbol, days);
            symbolHistoricalRootData.prices = symbolHistoricalRootData!.prices.Take(days).OrderBy(x => x.date).ToList();
            var symbolHistoricalData = symbolHistoricalRootData.prices;

            await PersistDataAsync(symbolHistoricalRootData);

            var spyHistoricalRootData = await GetSymbolHistoricalDataAsync(symbol, days);
            var spyHistoricalData = spyHistoricalRootData!.prices.Take(days).OrderBy(x => x.date).ToList();

            var result = new List<Performance>();

            for (int i = 0; i < days; i++)
            {
                var symbolPerformance = GetPerformance(symbolHistoricalData[i]);
                var spyPerformance = GetPerformance(spyHistoricalData[i]);

                symbolPerformance.symbol = symbol;
                symbolPerformance.percent = i == 0 ? 0 : (symbolHistoricalData[i].close!.Value - symbolHistoricalData[i - 1].close!.Value) * 100 / symbolHistoricalData[i - 1].close!.Value;

                spyPerformance.symbol = symbolToCompare;
                spyPerformance.percent = i == 0 ? 0 : (spyHistoricalData[i].close!.Value - spyHistoricalData[i - 1].close!.Value) * 100 / spyHistoricalData[i - 1].close!.Value;
                result.Add(symbolPerformance);
                result.Add(spyPerformance);
            }
            return result;
        }
        private Performance GetPerformance(Price price)
        {
            var performance = new Performance();
            DateTime startDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            DateTime time = startDate.AddSeconds(price.date!.Value);
            performance.date = new DateTime(1970, 1, 1).AddSeconds(price.date!.Value);
            performance.close = price.close!.Value;
            return performance;
        }
        private async Task PersistDataAsync(Root rootPrices)
        {
            await mediator.Send(new AddPricesCommand(rootPrices));
        }
    }
}
