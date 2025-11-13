using Microsoft.EntityFrameworkCore;
using StatisticsApi.Context;
using StatisticsApi.OutputDtos;

namespace StatisticsApi.Services
{
    public class DashboardDataService : IDashboardDataService
    {
        private readonly StatisticsDbContext _context;

        public DashboardDataService(StatisticsDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardStatsDto> GetDashboardStatsAsync()
        {
            var res = new DashboardStatsDto();
            var v = await _context.GameVersions.OrderByDescending(g => g.VersionName).FirstOrDefaultAsync();
            res.CurrentVersion = v.VersionName;
            res.GamesPlayed = await _context.GameResults.CountAsync();
            res.CurrentWinrate = (await _context.GameResults.Where(g=>g.Win).CountAsync()) / res.GamesPlayed;
            res.TotalChoices = await _context.CardChoiceRecords.CountAsync();
            return res;
        }

    }
}
