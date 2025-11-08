using EscapeFromTrinityEngineStats.Models;
using EscapeFromTrinityEngineStats.Models.InputDto;
using Microsoft.AspNetCore.Mvc;
using StatisticsApi.Context;
using StatisticsApi.Services;

namespace StatisticsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameResultController : ControllerBase
    {
        private readonly StatisticsDbContext _dbContext;
        private readonly IDtoConverterService _dtoConverterService;

        private readonly ILogger<GameResultController> _logger;

        public GameResultController(ILogger<GameResultController> logger, StatisticsDbContext dbContext, IDtoConverterService dtoConverterService)
        {
            _logger = logger;
            _dbContext = dbContext;
            _dtoConverterService = dtoConverterService;
        }
        [HttpPost]
        public async Task PostGameResultAsync(GameResultDto input)
        {
            var result = await _dtoConverterService.GameResultFromDtoAsync(input);
            _dbContext.GameResults.Add(result);
        }

        [HttpGet]
        public IEnumerable<GameResult> GetAllResults()
        {
            List<GameResult> res = new List<GameResult>();
            return res;
        }
    }
}
