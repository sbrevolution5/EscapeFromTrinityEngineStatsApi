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
            var res = new List<CardPickRateDto>();
            var cardChoices = await _context.CardChoiceRecords
                .Include(c => c.CardChoices)
                    .ThenInclude(c => c.CardInstance)
                    .ThenInclude(c => c.CharacterInstance)
                .Include(c => c.CardPicked)
                    .ThenInclude(c=> c.CharacterInstance).ToListAsync();
            var cards = await _context.CardInstances.ToListAsync();
            foreach (var r in cards)
            {
                var outDto = new CardPickRateDto()
                {
                    AvailableCount = cardChoices
                    .Where(c => c.CardChoices.Any(c => c.CardInstanceId == r.Id))
                    .Count(),
                    PickedCount = cardChoices
                    .Where(c => c.CardPicked.Id == r.Id)
                    .Count(),
                    CardInstanceId = r.Id,
                    CardName = r.Name,
                    CharacterName = r.CharacterInstance != null ? r.CharacterInstance.Name : "Neutral",
                };
                res.Add(outDto);
            }
            return res;
        }
    }
}
