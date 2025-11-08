using EscapeFromTrinityEngineStats.Models;
using EscapeFromTrinityEngineStats.Models.InputDto;
using EscapeFromTrinityEngineStats.Models.Instances;
using Microsoft.EntityFrameworkCore;
using StatisticsApi.Context;

namespace StatisticsApi.Services
{
    public class DtoConverterService
    {
        private readonly StatisticsDbContext _context;

        public DtoConverterService(StatisticsDbContext context)
        {
            _context = context;
        }

        public GameResult GameResultFromDto(GameResultDto input)
        {
            var result = new GameResult();
            result.GameVersion = input.GameVersion;
            result.RunPerk = input.RunPerk;
            result.Win = input.Win;
            result.RemainingGold = input.RemainingGold;
            result.TotalGoldEarned = input.TotalGoldEarned;
            result.TotalTeamworkEarned = input.TotalTeamworkEarned;
            result.PlayerId = input.PlayerId;
            result.Rooms = GetRoomsFromDto(input);
            result.Characters = GetCharactersFromDto(input);
            result.Passives = GetPassivesFromDto(input);
            return result;
        }

        private List<RoomRecord> GetRoomsFromDto(GameResultDto input)
        {
            throw new NotImplementedException();
        }

        private List<CharacterRecord> GetCharactersFromDto(GameResultDto input)
        {
            throw new NotImplementedException();
        }

        private List<PassiveRecord> GetPassivesFromDto(GameResultDto input)
        {
            throw new NotImplementedException();
        }
        private async Task<CardInstance> GetOrCreateCardInstanceAsync(string name)
        {
            name = name.Trim();

            var instance = await _context.CardInstances
                .FirstOrDefaultAsync(c => c.Name == name);

            if (instance != null)
                return instance;

            instance = new CardInstance
            {
                Name = name
                // other fields if needed…
            };

            _context.CardInstances.Add(instance);
            await _context.SaveChangesAsync();

            return instance;
        }
    }
}
