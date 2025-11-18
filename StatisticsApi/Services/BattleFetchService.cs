using EscapeFromTrinityEngineStats.Models;
using Microsoft.EntityFrameworkCore;
using StatisticsApi.Context;
using StatisticsApi.OutputDtos;
using System.Security.Cryptography;

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
        public async Task<BattleStatsOutputDto> GetBattleStats(int versionId = 0)
        {
            List<BattleRecord> records = new();
            var versionName = "";
            if (versionId == 0)
            {
                records = await _context.BattleRecords.Include(b => b.BattleInstance).Include(b => b.Version).ToListAsync();
            }
            else
            {
                records = await _context.BattleRecords.Include(b => b.BattleInstance).Include(b => b.Version).Where(b => b.VersionId == versionId).ToListAsync();
                versionName = records.FirstOrDefault()?.Version.VersionName;
            }
            var res = new BattleStatsOutputDto()
            {
                VersionId = versionId,
                VersionName = versionName,
            };
            var battles = new List<BattleInstanceOutputDto>();
            var instances = records.Select(b => b.BattleInstance).DistinctBy(b=>b.Id).ToList();
            foreach (var instance in instances)
            {
                var instanceRecords = records.Where(b => b.BattleInstance.Id == instance.Id).ToList();
                var instanceDto = new BattleInstanceOutputDto();
                if (instanceRecords.Count != 0)
                {
                    instanceDto.AverageCardsPlayed = instanceRecords.Average(b => b.Character1CardsPlayed + b.Character2CardsPlayed + b.Character3CardsPlayed);
                    instanceDto.AverageDamageDealt = instanceRecords.Average(b => b.Character1CardsPlayed + b.Character2CardsPlayed + b.Character3CardsPlayed);
                    instanceDto.AverageDamageTaken = instanceRecords.Average(b => GetDamageTaken(b));
                    instanceDto.AverageDamageTakenWhenInactive = instanceRecords.Where(b => b.CharacterResting != -1).Average(b => GetDamageTaken(b, b.CharacterResting));
                    instanceDto.AverageFloor = instanceRecords.Average(b => b.FloorEncountered * (b.LevelEncountered + 1));
                    instanceDto.AverageNumberOfDowns = instanceRecords.Average(GetDowns);
                    instanceDto.AverageTeamworkGained = instanceRecords.Average(b => b.TeamworkEnd - b.TeamworkStart);
                    instanceDto.AverageTurnsElapsed = instanceRecords.Average(b => b.RoundsElapsed);
                    instanceDto.Name = instance.Name;
                    instanceDto.Tier = instance.Tier;
                    instanceDto.NumberOfBattles = instanceRecords.Count;
                    instanceDto.Wins = instanceRecords.Where(b => b.WonBattle).Count();

                    if (instanceDto.NumberOfBattles > 0)
                    {
                        instanceDto.RestingRatio = instanceRecords.Where(i => i.CharacterResting != -1).Count() / instanceDto.NumberOfBattles;
                        instanceDto.CharacterDownedRatio = instanceRecords.Where(CharacterDownedInBattle).Count() / instanceDto.NumberOfBattles;
                        instanceDto.Winrate = instanceDto.Wins / instanceDto.NumberOfBattles;
                    }
                    res.BattleObjects.Add(instanceDto);
                }
            }
            return res;
        }
        private bool CharacterDownedInBattle(BattleRecord b)
        {
            if (b.Character1Downed || b.Character2Downed || b.Character3Downed)
            {
                return true;
            }
            return false;
        }
        private double GetDowns(BattleRecord b)
        {
            var res = 0;
            if (b.Character1Downed)
            {
                res++;
            }
            if (b.Character2Downed)
            {
                res++;
            }
            if (b.Character3Downed)
            {
                res++;
            }
            return res;
        }

        private double GetDamageTaken(BattleRecord b, int restSlot = -1)
        {
            var c1 = 0;
            if (restSlot != 0)
            {
                c1 = b.Character1HpStart - b.Character1HpEnd;
            }
            var c2 = 0;
            if (restSlot != 1)
            {

                c2 = b.Character2HpStart - b.Character2HpEnd;
            }
            var c3 = 0;
            if (restSlot != 2)
            {
                c3 = b.Character3HpStart - b.Character3HpEnd;
            }
            return c1 + c2 + c3;
        }
    }
}
