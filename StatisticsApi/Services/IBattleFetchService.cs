using EscapeFromTrinityEngineStats.Models;

namespace StatisticsApi.Services
{
    public interface IBattleFetchService
    {
        
        Task<IEnumerable<BattleRecord>> GetAllBattleRecordsAsync();
    }
}