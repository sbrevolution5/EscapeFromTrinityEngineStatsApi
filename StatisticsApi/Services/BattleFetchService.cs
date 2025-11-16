using EscapeFromTrinityEngineStats.Models;
using Microsoft.EntityFrameworkCore;
using StatisticsApi.Context;

namespace StatisticsApi.Services
{
    public class BattleFetchService : IBattleFetchService
    {
        private readonly StatisticsDbContext _context;

        public BattleFetchService(StatisticsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BattleRecord>> GetAllBattleRecordsAsync()
        {
            return await _context.BattleRecords.Include(b => b.BattleInstance).Include(b => b.Version).ToListAsync();
        }
    }
}
