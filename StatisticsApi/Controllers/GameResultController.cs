using EscapeFromTrinityEngineStats.Models;
using EscapeFromTrinityEngineStats.Models.InputDto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StatisticsApi.Context;
using StatisticsApi.Services;
using System.Threading.Tasks;

namespace StatisticsApi.Controllers
{
    [ApiController]
    
    [Route("api/[controller]")]
    public class GameResultController : ControllerBase
    {
        private readonly StatisticsDbContext _dbContext;
        private readonly IDtoConverterService _dtoConverterService;
        private readonly IFetchDataService _fetchData;

        private readonly ILogger<GameResultController> _logger;

        public GameResultController(ILogger<GameResultController> logger, StatisticsDbContext dbContext, IDtoConverterService dtoConverterService, IFetchDataService fetchData)
        {
            _logger = logger;
            _dbContext = dbContext;
            _dtoConverterService = dtoConverterService;
            _fetchData = fetchData;
        }
        [HttpPost]
        public async Task PostGameResultAsync([FromBody] GameResultDto input)
        {
            var result = await _dtoConverterService.GameResultFromDtoAsync(input);
            
        }
        [HttpGet]
        public async Task<IEnumerable<GameResult>> GetAllResults()
        {
            List<GameResult> res = await _fetchData.GetAllGameResultsAsync();
            return res;
        }
    }
}
