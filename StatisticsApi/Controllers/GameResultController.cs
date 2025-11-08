using EscapeFromTrinityEngineStats.Models;
using EscapeFromTrinityEngineStats.Models.InputDto;
using Microsoft.AspNetCore.Mvc;
using StatisticsApi.Context;

namespace StatisticsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameResultController : ControllerBase
    {
        private readonly StatisticsDbContext _dbContext;


        private readonly ILogger<GameResultController> _logger;

        public GameResultController(ILogger<GameResultController> logger, StatisticsDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        [HttpPost]
        public void PostGameResult(GameResultDto input)
        {
            var result = new GameResult();
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
