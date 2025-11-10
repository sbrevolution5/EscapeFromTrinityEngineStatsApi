using EscapeFromTrinityEngineStats.Models;

namespace StatisticsApi.Services
{
    public interface IFetchDataService
    {
        Task<List<GameResult>> GameResultsForVersion(string version);
        Task<GameResult> GetSingleGameResult(int Id);
    }
}