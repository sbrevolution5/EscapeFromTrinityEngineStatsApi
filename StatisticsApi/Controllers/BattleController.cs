using EscapeFromTrinityEngineStats.Models;
using Microsoft.AspNetCore.Mvc;
using StatisticsApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StatisticsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleController : ControllerBase
    {
        private readonly IBattleFetchService _battleService;

        public BattleController(IBattleFetchService battleService)
        {
            _battleService = battleService;
        }

        // GET: api/<BattleController>
        [HttpGet]
        public async Task<IEnumerable<BattleRecord>> GetAsync()
        {
            return await _battleService.GetAllBattleRecordsAsync();
        }

        // GET api/<BattleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST api/<BattleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BattleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BattleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
