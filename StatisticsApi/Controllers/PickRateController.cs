using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StatisticsApi.OutputDtos;
using StatisticsApi.Services;

namespace StatisticsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickRateController : ControllerBase
    {
        private readonly ICardPickRateService _pickRateService;

        public PickRateController(ICardPickRateService pickRateService)
        {
            _pickRateService = pickRateService;
        }
        [HttpGet("{versionId}")]
        public async Task<IEnumerable<CardPickRateDto>> GetCardPickRatesForVersion(int versionId)
        {
            return await _pickRateService.GetCardPickRatesAsync(versionId);
        }
    }
}
