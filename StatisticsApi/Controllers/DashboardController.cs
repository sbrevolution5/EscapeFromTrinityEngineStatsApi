using EscapeFromTrinityEngineStats.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StatisticsApi.Context;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StatisticsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly StatisticsDbContext _context;
        // GET: api/<DashboardController>
        [HttpGet]
        public async Task<GameVersion> GetAsync()
        {
            return await _context.GameVersions.OrderByDescending(g => g.Id).FirstOrDefaultAsync();
        }

        // GET api/<DashboardController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DashboardController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DashboardController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DashboardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
