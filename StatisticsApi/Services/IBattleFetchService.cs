using EscapeFromTrinityEngineStats.Models;
using StatisticsApi.OutputDtos;

namespace StatisticsApi.Services
{
    public interface IBattleFetchService
    {
        
        Task<IEnumerable<BattleRecord>> GetAllBattleRecordsAsync();
        Task<BattleStatsOutputDto> GetBattleStats(int versionId = 0);
    }
}