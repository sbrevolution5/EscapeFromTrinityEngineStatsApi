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
            var query =
                from cc in _context.CardChoiceCards
                join cr in _context.CardChoiceRecords on cc.CardChoiceRecordId equals cr.Id
                join ci in _context.CardInstances on cc.CardInstanceId equals ci.Id
                join gv in _context.GameVersions on cr.VersionId equals gv.Id
                where !versionId.HasValue || cr.VersionId == versionId.Value
                group new { cc, cr } by new
                {
                    VersionId = cr.VersionId,
                    VersionName = gv.VersionName,
                    CardInstanceId = cc.CardInstanceId,
                    CardName = ci.Name
                } into g
                let available = g.Count()
                // Use EF.Property to reference the FK column (CardPickedId) so EF translates to SQL instead of client-evaluating navigation access.
                let picked = g.Count(x => EF.Property<int?>(x.cr, "CardPickedId") == x.cc.CardInstanceId)
                select new CardPickRateDto
                {
                    VersionId = g.Key.VersionId,
                    VersionName = g.Key.VersionName,
                    CardInstanceId = g.Key.CardInstanceId,
                    CardName = g.Key.CardName,
                    AvailableCount = available,
                    PickedCount = picked,
                    PickRate = available == 0 ? 0.0 : (double)picked / (double)available
                };

            return await query
                .OrderByDescending(r => r.PickRate)
                .ThenBy(r => r.VersionName)
                .ToListAsync();
        }
    }
}
