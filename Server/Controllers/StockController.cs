using Application.ApiBE;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StockController : ControllerBase
    {
        readonly ISymbolService _symbolService;
        public StockController(ISymbolService symbolService)
        {
            _symbolService = symbolService;
        }

        [HttpGet]
        public async Task<ActionResult<Root>> LoadSymbolResultDto(string symbol) 
        {
            var result = await _symbolService.GetSymbolHistoricalDataAsync(symbol,7);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<Performance>>> LoadPerformanceComparison(string symbol)
        {
            var result = await _symbolService.GetWeekPerformanceComparison(symbol, 7);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
