using Microsoft.EntityFrameworkCore;
using StatisticsApi.Context;
using StatisticsApi.OutputDtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticsApi.Services
{
    public class CardPickRateService : ICardPickRateService
    {
        private readonly StatisticsDbContext _context;
        public CardPickRateService(StatisticsDbContext context)
        {
            _context = context;
        }

        // If versionId is null, returns rates across all versions (per-version rows).
        public async Task<List<CardPickRateDto>> GetCardPickRatesAsync(int? versionId = null)
        {
            // availability: times card appeared among choices (per version)
            var availability = _context.CardChoiceCards
                .Join(_context.CardChoiceRecords,
                    cc => cc.CardChoiceRecordId,
                    cr => cr.Id,
                    (cc, cr) => new { cr.VersionId, cc.CardInstanceId })
                .Where(x => !versionId.HasValue || x.VersionId == versionId.Value)
                .GroupBy(x => new { x.VersionId, x.CardInstanceId })
                .Select(g => new { g.Key.VersionId, g.Key.CardInstanceId, AvailableCount = g.Count() });

            // picks: times card was picked (per version)
            var picks = _context.CardChoiceRecords
                .Where(r => !versionId.HasValue || r.VersionId == versionId.Value)
                .GroupBy(r => new { r.VersionId, CardInstanceId = r.CardPicked.Id })
                .Select(g => new { g.Key.VersionId, g.Key.CardInstanceId, PickedCount = g.Count() });

            var query =
                from a in availability
                join ci in _context.CardInstances on a.CardInstanceId equals ci.Id
                join gv in _context.GameVersions on a.VersionId equals gv.Id
                join p in picks on new { a.VersionId, a.CardInstanceId } equals new { p.VersionId, p.CardInstanceId } into pj
                from p in pj.DefaultIfEmpty()
                select new CardPickRateDto
                {
                    VersionId = a.VersionId,
                    VersionName = gv.VersionName,
                    CardInstanceId = a.CardInstanceId,
                    CardName = ci.Name,
                    AvailableCount = a.AvailableCount,
                    PickedCount = p != null ? p.PickedCount : 0,
                    PickRate = (double)(p != null ? p.PickedCount : 0) / a.AvailableCount
                };

            return await query
                .OrderByDescending(r => r.PickRate)
                .ThenBy(r => r.VersionName)
                .ToListAsync();
        }
    }
}
