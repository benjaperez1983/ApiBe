using Shared.Dtos;

namespace Application.ApiBE
{
    public interface ISymbolService
    {
        Task<Root> GetSymbolHistoricalDataAsync(string symbol, int days);
        Task<List<Performance>> GetWeekPerformanceComparison(string symbol, int days); 
    }
}
