using EscapeFromTrinityEngineStats.Models;
using Microsoft.EntityFrameworkCore;
using StatisticsApi.Context;
using StatisticsApi.OutputDtos;

namespace StatisticsApi.Services
{
    public class CharacterFetchService : ICharacterFetchService
    {
        private readonly StatisticsDbContext _context;

        public CharacterFetchService(StatisticsDbContext context)
        {
            _context = context;
        }

        public async Task<CharacterPopularityOutputDto> GetCharacterPopularityAsync(int versionId = 0)
        {
            var characters = await _context.CharacterInstances.ToListAsync();
            List<GameResult> results = await _context.GameResults.Include(g => g.Characters).ThenInclude(c => c.CharacterInstance).ToListAsync();
            var res = new CharacterPopularityOutputDto();
            if (versionId != 0)
            {
                res.VersionId = versionId;
                res.SpecificVersion = true;
                res.TotalGames = results.Count;
            }
            foreach (var character in characters)
            {
                res.Characters.Add(
                    new CharacterInstancePopularityOutputDto()
                    {
                        Name = character.Name,
                        Plays = results.Where(g => g.Characters.Any(c => c.CharacterInstance == character)).Count(),
                        Wins = results.Where(g => g.Characters.Any(c => c.CharacterInstance == character) && g.Win).Count()
                    });
            }
            return res;
        }
    }
}
