using EscapeFromTrinityEngineStats.Models;
using Microsoft.EntityFrameworkCore;
using StatisticsApi.Context;
using StatisticsApi.Extensions;
using System;

namespace StatisticsApi.Services
{
    public class FetchDataService : IFetchDataService
    {
        private readonly StatisticsDbContext _dbContext;

        public FetchDataService(StatisticsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GameResult>> GameResultsForVersion(string version)
        {
            return await _dbContext.GameResults.IncludeAllRoomRecords().Where(g => g.GameVersion == version).ToListAsync();
        }
        public async Task<GameResult> GetSingleGameResult(int Id)
        {
            return await _dbContext.GameResults.IncludeAllRoomRecords().FirstOrDefaultAsync(g => g.Id == Id);
        }

    }
}
