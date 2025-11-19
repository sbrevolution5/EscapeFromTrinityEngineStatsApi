using EscapeFromTrinityEngineStats.Models;
using EscapeFromTrinityEngineStats.Models.InputDto;
using EscapeFromTrinityEngineStats.Models.Instances;
using EscapeFromTrinityEngineStats.Models.Relationships;
using Microsoft.EntityFrameworkCore;
using StatisticsApi.Context;
using System.Xml.Linq;

namespace StatisticsApi.Services
{
    public class DtoConverterService : IDtoConverterService
    {
        private readonly StatisticsDbContext _context;
        public HashSet<CardInstance> CardInstances { get; private set; } = new HashSet<CardInstance>();
        public HashSet<PassiveInstance> PassiveInstances { get; private set; } = new HashSet<PassiveInstance>();
        public HashSet<BattleInstance> BattleInstances { get; private set; } = new HashSet<BattleInstance>();
        public HashSet<EventInstance> EventInstances { get; private set; } = new HashSet<EventInstance>();
        public HashSet<CharacterInstance> CharacterInstances { get; private set; } = new HashSet<CharacterInstance>();
        public GameVersion GameVersion { get; private set; }
        public DtoConverterService(StatisticsDbContext context)
        {
            _context = context;
        }
        public async Task<GameResult> GameResultFromDtoAsync(GameResultDto input)
        {
            CardInstances = await _context.CardInstances.Include(c=>c.CharacterInstance).ToHashSetAsync();
            PassiveInstances = await _context.PassiveInstances.ToHashSetAsync();
            BattleInstances = await _context.BattleInstances.ToHashSetAsync();
            EventInstances = await _context.EventInstances.ToHashSetAsync();
            CharacterInstances = await _context.CharacterInstances.ToHashSetAsync();
            var result = new GameResult();
            GameVersion = await GetOrCreateGameVersionAsync(input.GameVersion);
            if (GameVersion is not null)
            {

                result.GameVersion = GameVersion;
                result.GameVersionId = GameVersion.Id;
            }
            else
            {
                throw new InvalidDataException("Failure to find game version in database!");
            }
                result.RunPerk = input.RunPerk;
            result.Win = input.Win;
            result.RemainingGold = input.RemainingGold;
            result.TotalGoldEarned = input.TotalGoldEarned;
            result.TotalTeamworkEarned = input.TotalTeamworkEarned;
            result.PlayerId = input.PlayerId;
            result.Rooms = GetRoomsFromDto(input.RoomDtos);
            result.Characters = await GetCharactersFromDtoAsync(input);
            result.Passives = GetPassivesFromDto(input.PassiveDtos);
            result.Abandoned = input.Abandoned;
            _context.GameResults.Add(result);
            await _context.SaveChangesAsync();
            return result;
        }

        private async Task<GameVersion> GetOrCreateGameVersionAsync(string gameVersion)
        {
            gameVersion = gameVersion.Trim();

            var instance = await _context.GameVersions
                .FirstOrDefaultAsync(g => g.VersionName == gameVersion);

            if (instance != null)
                return instance;

            instance = new GameVersion
            {
                VersionName = gameVersion
            };

            _context.GameVersions.Add(instance);
            await _context.SaveChangesAsync();
            
            return await _context.GameVersions
                .FirstOrDefaultAsync(g => g.VersionName == gameVersion);
        }

        private List<RoomRecord> GetRoomsFromDto(List<RoomRecordDto> input)
        {
            var result = new List<RoomRecord>();
            foreach (var item in input)
            {
                result.Add(GetRoomFromDto(item));
            }
            return result;
        }

        private RoomRecord GetRoomFromDto(RoomRecordDto item)
        {
            var result = new RoomRecord();
            result.FloorNumber = item.FloorNumber;
            result.LevelNumber = item.LevelNumber;
            if (item.ShopRecordDto is not null)
            {
                result.ShopRecord = GetShopRecordFromDto(item.ShopRecordDto);
            }
            else
            {
                if (item.RewardRecordDto is not null)
                {
                    result.RewardRecord = GetRewardRecordFromDto(item.RewardRecordDto);
                }
                if (item.BattleRecordDto is not null)
                {
                    result.BattleRecord = GetBattleRecordFromDto(item.BattleRecordDto);
                }
                else if (item.EventRecordDto is not null)
                {
                    result.EventRecord = GetEventRecordFromDto(item.EventRecordDto);
                }
            }
            
            _context.RoomRecords.Add(result);
            return result;
        }

        private RewardRecord? GetRewardRecordFromDto(RewardRecordDto rewardRecordDto)
        {
            var result = new RewardRecord();
            result.Version = GameVersion;
            result.VersionId = GameVersion.Id;

            result.GoldGained = rewardRecordDto.GoldGained;
            if (rewardRecordDto.GivenTradeCards is not null && rewardRecordDto.GivenTradeCards.Count > 0)
            {
                result.GivenTradeCards = GetGivenTradeCardsFromDto(rewardRecordDto, result);
            }
            if (rewardRecordDto.RecievedTradeCards is not null && rewardRecordDto.RecievedTradeCards.Count > 0)
            {
                result.RecievedTradeCards = GetRecievedTradeCardsFromDto(rewardRecordDto, result);
            }
            if (rewardRecordDto.JunkRewards is not null && rewardRecordDto.JunkRewards.Count > 0)
            {
                result.JunkRewards = GetJunkRewardsFromDto(rewardRecordDto, result);
            }
            if (rewardRecordDto.RemovedCards is not null && rewardRecordDto.RemovedCards.Count > 0)
            {
                result.RemovedCards = GetRemovedCardsFromDto(rewardRecordDto, result);
            }
            if (rewardRecordDto.UpgradedCards is not null && rewardRecordDto.UpgradedCards.Count > 0)
            {
                result.UpgradedCards = GetUpgradedCardsFromDto(rewardRecordDto, result);
            }
            if (rewardRecordDto.CardChoiceRecordDtos is not null && rewardRecordDto.CardChoiceRecordDtos.Count > 0)
            {
                result.CardChoiceRecords = GetCardChoicesFromDto(rewardRecordDto, result);
            }
            if (rewardRecordDto.PassiveRecordDtos is not null && rewardRecordDto.PassiveRecordDtos.Count > 0)
            {
                result.PassiveRecords = GetPassivesFromDto(rewardRecordDto.PassiveRecordDtos);
            }
            _context.RewardRecords.Add(result);
            return result;


        }

        private List<RewardJunkCards> GetJunkRewardsFromDto(RewardRecordDto dto, RewardRecord record)
        {
            var result = new List<RewardJunkCards>();
            foreach (var item in dto.JunkRewards)
            {
                result.Add(new RewardJunkCards()
                {
                    RewardRecord = record,
                    CardRecord = GetCardRecordFromDto(item)

                });
            }
            
            _context.RewardJunkCards.AddRange(result);
            return result;
        }

        private List<RewardRemovedCards> GetRemovedCardsFromDto(RewardRecordDto dto, RewardRecord record)
        {
            var result = new List<RewardRemovedCards>();
            foreach (var item in dto.RemovedCards)
            {
                result.Add(new RewardRemovedCards()
                {
                    RewardRecord = record,
                    CardRecord = GetCardRecordFromDto(item)

                });
            }
            _context.RewardRemovedCards.AddRange(result);
            return result;
        }

        private List<RewardUpgradedCards> GetUpgradedCardsFromDto(RewardRecordDto dto, RewardRecord record)
        {
            var result = new List<RewardUpgradedCards>();
            foreach (var item in dto.UpgradedCards)
            {
                result.Add(new RewardUpgradedCards()
                {
                    RewardRecord = record,
                    CardRecord = GetCardRecordFromDto(item)

                });
            }
            _context.RewardUpgradedCards.AddRange(result);
            return result;
        }

        private List<CardChoiceRecord> GetCardChoicesFromDto(RewardRecordDto dto, RewardRecord record)
        {
            var result = new List<CardChoiceRecord>();
            foreach (var item in dto.CardChoiceRecordDtos)
            {
                result.Add(CreateCardChoiceDto(item));

            }
            return result;
        }

        private CardChoiceRecord CreateCardChoiceDto(CardChoiceRecordDto item)
        {
            var result = new CardChoiceRecord();
            result.Version = GameVersion;
            result.VersionId = GameVersion.Id;
            result.RerolledCards = new List<RerolledCardCardInstance>();
            result.UpgradePicked = item.UpgradePicked;
            result.CardPicked = GetOrCreateCardInstance(item.CardPicked);
            result.CardChoices = new List<CardChoiceCardInstance>();
            foreach (var choice in item.CardChoices)
            {
                result.CardChoices.Add(GetCardChoiceCardInstance(choice, result));
            }
            if (item.RerolledCards is not null && item.RerolledCards.Count > 0)
            {
                foreach (var card in item.RerolledCards)
                {
                    result.RerolledCards.Add(GetRerolledCardFromDto(card, result));
                }
            }
            _context.CardChoiceRecords.Add(result);
            return result;
        }

        private RerolledCardCardInstance GetRerolledCardFromDto(string card, CardChoiceRecord record)
        {
            var result = new RerolledCardCardInstance()
            {
                CardChoiceRecord = record,
                CardInstance = GetOrCreateCardInstance(card)

            };
            _context.RerolledCardCardInstances.Add(result);
            return result;
        }


        private CardChoiceCardInstance GetCardChoiceCardInstance(string choice, CardChoiceRecord record)
        {

            var result = new CardChoiceCardInstance()
            {
                CardChoiceRecord = record,
                CardInstance = GetOrCreateCardInstance(choice)

            };
            _context.CardChoiceCards.Add(result);
            return result;
        }
        private List<RewardRecievedTradeCards> GetRecievedTradeCardsFromDto(RewardRecordDto dto, RewardRecord record)
        {
            var result = new List<RewardRecievedTradeCards>();
            foreach (var item in dto.RecievedTradeCards)
            {
                result.Add(new RewardRecievedTradeCards()
                {
                    RewardRecord = record,
                    CardRecord = GetCardRecordFromDto(item)

                });
            }
            _context.RewardRecievedTradeCards.AddRange(result);
            return result;
        }

        private List<RewardGivenTradeCards> GetGivenTradeCardsFromDto(RewardRecordDto dto, RewardRecord record)
        {
            var result = new List<RewardGivenTradeCards>();
            foreach (var item in dto.GivenTradeCards)
            {
                result.Add(new RewardGivenTradeCards()
                {
                    RewardRecord = record,
                    CardRecord = GetCardRecordFromDto(item)

                });
            }
            _context.RewardGivenTradeCards.AddRange(result);
            return result;
        }

        private BattleRecord? GetBattleRecordFromDto(BattleRecordDto battleRecordDto)
        {
            var result = new BattleRecord();
            result.Version = GameVersion;
            result.VersionId = GameVersion.Id;
            result.Character1CardsPlayed = battleRecordDto.Character1CardsPlayed;
            result.Character2CardsPlayed = battleRecordDto.Character2CardsPlayed;
            result.Character3CardsPlayed = battleRecordDto.Character3CardsPlayed;
            result.Character1HpEnd = battleRecordDto.Character1HpEnd;
            result.Character2HpEnd = battleRecordDto.Character2HpEnd;
            result.Character3HpEnd = battleRecordDto.Character3HpEnd;
            result.Character1HpStart = battleRecordDto.Character1HpStart;
            result.Character2HpStart = battleRecordDto.Character2HpStart;
            result.Character3HpStart = battleRecordDto.Character3HpStart;
            result.Character1DamageDealt = battleRecordDto.Character1DamageDealt;
            result.Character2DamageDealt = battleRecordDto.Character2DamageDealt;
            result.Character3DamageDealt = battleRecordDto.Character3DamageDealt;
            result.Character1Downed = battleRecordDto.Character1Downed;
            result.Character2Downed = battleRecordDto.Character2Downed;
            result.Character3Downed = battleRecordDto.Character3Downed;
            result.CharacterResting = battleRecordDto.CharacterResting;
            result.FloorEncountered = battleRecordDto.FloorEncountered;
            result.GoldGained = battleRecordDto.GoldGained;
            result.TeamworkEnd = battleRecordDto.TeamworkEnd;
            result.TeamworkStart = battleRecordDto.TeamworkStart;
            result.RoundsElapsed = battleRecordDto.RoundsElapsed;
            result.LevelEncountered = battleRecordDto.LevelEncountered;
            result.BattleInstance = GetOrCreateBattleInstance(battleRecordDto.Name, battleRecordDto.Tier);
            result.WonBattle = battleRecordDto.WonBattle;
            _context.BattleRecords.Add(result);
            return result;
        }

        private BattleInstance GetOrCreateBattleInstance(string name, int tier)
        {
            name = name.Trim();

            var instance = BattleInstances
                .FirstOrDefault(c => c.Name == name);
            if (instance != null)
            {
                instance.Tier = tier;
                return instance;
            }
            instance ??= new BattleInstance()
            {
                Name = name,
                Tier = tier
            };
            _context.BattleInstances.Add(instance);
            BattleInstances.Add(instance);
            return instance;
        }

        private EventRecord GetEventRecordFromDto(EventRecordDto eventRecordDto)
        {
            var result = new EventRecord();
            result.Version = GameVersion;
            result.VersionId = GameVersion.Id;

            result.EventInstance = GetOrCreateEventInstance(eventRecordDto.Name);
            result.TeamworkOnEnter = eventRecordDto.TeamworkOnEnter;
            _context.EventRecords.Add(result);
            return result;

        }

        private EventInstance GetOrCreateEventInstance(string name)
        {
            name = name.Trim();

            var instance = EventInstances
                .FirstOrDefault(c => c.Name == name);
            if (instance != null)
                return instance;
            instance ??= new EventInstance
            {
                Name = name
            };
            _context.EventInstances.Add(instance);
            EventInstances.Add(instance);
            return instance;
        }

        private ShopRecord? GetShopRecordFromDto(ShopRecordDto shopRecordDto)
        {
            var result = new ShopRecord();
            result.Version = GameVersion;
            result.VersionId = GameVersion.Id;
            result.AffordableCards = GetAffordableCardsFromDto(shopRecordDto, result);
            result.AffordablePassives = GetAffordablePassivesFromDto(shopRecordDto, result);
            result.PurchasedCards = GetPurchasedCardsFromDto(shopRecordDto, result);
            result.PurchasedPassives = GetPurchasedPassivesFromDto(shopRecordDto, result);
            result.UpgradePurchased = shopRecordDto.UpgradePurchased;
            if (shopRecordDto.UpgradePurchased && shopRecordDto.UpgradedCard is not null)
            {

                result.UpgradedCard = new CardRecord()
                {
                    CardInstance = GetOrCreateCardInstance(shopRecordDto.UpgradedCard.Name),
                    PartySlot = shopRecordDto.UpgradedCard.PartySlot
                };
            }
            result.GoldSpent = shopRecordDto.GoldSpent;
            result.GoldEntered = shopRecordDto.GoldEntered;
            _context.ShopRecords.Add(result);
            return result;
        }

        private List<ShopAffordableCard> GetAffordableCardsFromDto(ShopRecordDto dto, ShopRecord record)
        {
            var result = new List<ShopAffordableCard>();
            foreach (var item in dto.AffordableCards)
            {
                result.Add(new ShopAffordableCard()
                {
                    ShopRecord = record,
                    CardInstance = GetOrCreateCardInstance(item)

                });
            }
            _context.ShopAffordableCards.AddRange(result);
            return result;
        }
        private List<ShopAffordablePassive> GetAffordablePassivesFromDto(ShopRecordDto dto, ShopRecord record)
        {
            var result = new List<ShopAffordablePassive>();
            foreach (var item in dto.AffordablePassives)
            {
                result.Add(new ShopAffordablePassive()
                {
                    ShopRecord = record,
                    PassiveInstance = GetOrCreatePassiveInstance(item)

                });
            }
            _context.ShopAffordablePassives.AddRange(result);
            return result;
        }
        private List<ShopPurchasedPassive> GetPurchasedPassivesFromDto(ShopRecordDto dto, ShopRecord record)
        {
            var result = new List<ShopPurchasedPassive>();
            foreach (var item in dto.PurchasedPassives)
            {
                result.Add(new ShopPurchasedPassive()
                {
                    ShopRecord = record,
                    PassiveInstance = GetOrCreatePassiveInstance(item)


                });
            }
            _context.ShopPurchasedPassives.AddRange(result);
            return result;
        }
        private List<ShopPurchasedCard> GetPurchasedCardsFromDto(ShopRecordDto dto, ShopRecord record)
        {
            var result = new List<ShopPurchasedCard>();
            foreach (var item in dto.PurchasedCards)
            {
                result.Add(new ShopPurchasedCard()
                {
                    ShopRecord = record,
                    CardInstance = GetOrCreateCardInstance(item)
                });
            }
            _context.ShopPurchasedCards.AddRange(result);
            return result;
        }

        private async Task<List<CharacterRecord>> GetCharactersFromDtoAsync(GameResultDto input)
        {
            var result = new List<CharacterRecord>();
            foreach (var c in input.CharacterDtos)
            {
                result.Add(await CharacterFromDtoAsync(c));
            }
            _context.CharacterRecords.AddRange(result);
            return result;
        }

        private async Task<CharacterRecord> CharacterFromDtoAsync(CharacterRecordDto c)
        {
            var result = new CharacterRecord();
            result.Version = GameVersion;
            result.VersionId = GameVersion.Id;
            result.CharacterInstance = GetOrCreateCharacterInstance(c.Name);
            result.PartySlot = c.PartySlot;
            List<CardRecord> deckResult = GetDecklistFromCharacterDto(c);
            result.DeckRecord = deckResult;
            return result;
        }

        private List<CardRecord> GetDecklistFromCharacterDto(CharacterRecordDto c)
        {
            var result = new List<CardRecord>();
            foreach (var card in c.DeckRecord)
            {
                result.Add(GetCardRecordFromDto(card));
            }
            _context.CardRecords.AddRange(result);
            return result;
        }

        private CardRecord GetCardRecordFromDto(CardRecordDto card)
        {
            var result = new CardRecord();

            result.CardInstance = GetOrCreateCardInstance(card.Name, card.Rarity, card.CharacterName);
            result.PartySlot = card.PartySlot;
            return result;
        }

        private CharacterInstance GetOrCreateCharacterInstance(string name)
        {
            name = name.Trim();

            var instance = CharacterInstances
                .FirstOrDefault(c => c.Name == name);

            if (instance != null)
                return instance;

            instance = new CharacterInstance
            {
                Name = name
            };
            CharacterInstances.Add(instance);
            _context.CharacterInstances.Add(instance);
            return instance;
        }

        private List<PassiveRecord> GetPassivesFromDto(List<PassiveRecordDto> input)
        {
            var result = new List<PassiveRecord>();
            foreach (var item in input)
            {
                result.Add(GetPassiveRecordFromDto(item));
            }
            _context.PassiveRecords.AddRange(result);
            return result;
        }

        private PassiveRecord GetPassiveRecordFromDto(PassiveRecordDto item)
        {
            var result = new PassiveRecord();
            result.PassiveInstance = GetOrCreatePassiveInstance(item.Name, item.Rarity);
            return result;
        }

        private PassiveInstance GetOrCreatePassiveInstance(string name, int rarity=-1)
        {
            name = name.Trim();

            var instance = PassiveInstances
                .FirstOrDefault(c => c.Name == name);
            if (instance != null)
            {
                if (rarity >= 0)
                {

                instance.Rarity = rarity;
                }
                return instance;
            }
            instance ??= new PassiveInstance
            {
                Name = name
            };
            if (rarity >= 0)
            {
                instance.Rarity = rarity;
            }
            _context.PassiveInstances.Add(instance);
            PassiveInstances.Add(instance);
            return instance;
        }

        private CardInstance GetOrCreateCardInstance(string name, int rarity = -1, string? cName = null)
        {
            name = name.Trim();

            var instance = CardInstances
                .FirstOrDefault(c => c.Name == name);
            if (instance != null)
            {
                if (rarity >= 0)
                {
                    instance.Rarity = rarity;
                }
                if (!string.IsNullOrWhiteSpace(cName) && cName != "junk" && (instance.CharacterInstance == null || instance.CharacterInstance.Name != cName))
                {
                    instance.CharacterInstance = GetOrCreateCharacterInstance(cName);
                    instance.CharacterInstanceId = instance.CharacterInstance.Id;
                }
                return instance;
            }
            instance ??= new CardInstance
            {
                Name = name,
            };
            if (rarity >= 0)
            {
                instance.Rarity = rarity;
            }
            if (!string.IsNullOrWhiteSpace(cName) && cName != "junk")
            {
                instance.CharacterInstance = GetOrCreateCharacterInstance(cName);
                instance.CharacterInstanceId = instance.CharacterInstance.Id;
            }
            _context.CardInstances.Add(instance);
            CardInstances.Add(instance);
            return instance;
        }
    }
}
