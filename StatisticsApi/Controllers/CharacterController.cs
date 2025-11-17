using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StatisticsApi.OutputDtos;
using StatisticsApi.Services;
using System;

namespace StatisticsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterFetchService _characterFetchService;

        public CharacterController(ICharacterFetchService characterFetchService)
        {
            _characterFetchService = characterFetchService;
        }

        [HttpGet("{versionId}")]
        public async Task<CharacterPopularityOutputDto> GetCharacterPopularityForVersionAsync(int versionId)
        {
            return await _characterFetchService.GetCharacterPopularityAsync(versionId);
        }
        [HttpGet]
        public async Task<CharacterPopularityOutputDto> GetCharacterPopularityAsync()
        {
            return await _characterFetchService.GetCharacterPopularityAsync();

        }
    }
}
