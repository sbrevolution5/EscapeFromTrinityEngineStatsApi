using EscapeFromTrinityEngineStats.Models;
using EscapeFromTrinityEngineStats.Models.InputDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StatisticsApi.Context;
using StatisticsApi.Services;
using System.Threading.Tasks;

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
            await _dbContext.SaveChangesAsync();
        }

        [HttpGet]
        public async Task<IEnumerable<GameResult>> GetAllResults()
        {
            List<GameResult> res = await _dbContext.GameResults.ToListAsync();
            return res;
        }
    }
}
