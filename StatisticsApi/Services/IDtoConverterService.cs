using EscapeFromTrinityEngineStats.Models;
using EscapeFromTrinityEngineStats.Models.InputDto;

namespace StatisticsApi.Services
{
    public interface IDtoConverterService
    {
        public Task<GameResult> GameResultFromDtoAsync(GameResultDto input);
    }
}
