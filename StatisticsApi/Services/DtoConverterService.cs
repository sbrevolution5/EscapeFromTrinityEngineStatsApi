using EscapeFromTrinityEngineStats.Models;
using EscapeFromTrinityEngineStats.Models.InputDto;
using EscapeFromTrinityEngineStats.Models.Instances;
using EscapeFromTrinityEngineStats.Models.Relationships;
using Microsoft.EntityFrameworkCore;
using StatisticsApi.Context;
using System.Xml.Linq;

namespace StatisticsApi.Services
{
    public class DtoConverterService :IDtoConverterService
    {
        private readonly StatisticsDbContext _context;
        public HashSet<CardInstance> CardInstances { get; private set; } = new HashSet<CardInstance>();
        public HashSet<PassiveInstance> PassiveInstances { get; private set; } = new HashSet<PassiveInstance>();
        public HashSet<BattleInstance> BattleInstances { get; private set; } = new HashSet<BattleInstance>();
        public HashSet<EventInstance> EventInstances { get; private set; } = new HashSet<EventInstance>();
        public DtoConverterService(StatisticsDbContext context)
        {
            _context = context;
        }
        public async Task<GameResult> GameResultFromDtoAsync(GameResultDto input)
        {
            CardInstances = await _context.CardInstances.ToHashSetAsync();
            PassiveInstances = await _context.PassiveInstances.ToHashSetAsync();
            BattleInstances = await _context.BattleInstances.ToHashSetAsync();
            EventInstances = await _context.EventInstances.ToHashSetAsync();
            var result = new GameResult();
            result.GameVersion = input.GameVersion;
            result.RunPerk = input.RunPerk;
            result.Win = input.Win;
            result.RemainingGold = input.RemainingGold;
            result.TotalGoldEarned = input.TotalGoldEarned;
            result.TotalTeamworkEarned = input.TotalTeamworkEarned;
            result.PlayerId = input.PlayerId;
            result.Rooms = await GetRoomsFromDto(input.RoomDtos);
            result.Characters = await GetCharactersFromDtoAsync(input);
            result.Passives = await GetPassivesFromDto(input.PassiveDtos);
            _context.GameResults.Add(result);
            await _context.SaveChangesAsync();
            return result;
        }

        private async Task<List<RoomRecord>> GetRoomsFromDto(List<RoomRecordDto> input)
        {
            var result = new List<RoomRecord>();
            foreach (var item in input)
            {
                result.Add(await GetRoomFromDtoAsync(item));
            }
            return result;
        }

        private async Task<RoomRecord> GetRoomFromDtoAsync(RoomRecordDto item)
        {
            var result = new RoomRecord();
            result.FloorNumber = item.FloorNumber;
            result.LevelNumber = item.LevelNumber;
            if (item.ShopRecordDto is not null)
            {
                result.ShopRecord = await GetShopRecordFromDtoAsync(item.ShopRecordDto);
            }
            else
            {
                if (item.RewardRecordDto is not null)
                {
                    result.RewardRecord = await GetRewardRecordFromDtoAsync(item.RewardRecordDto);
                }
                if (item.BattleRecordDto is not null)
                {
                    result.BattleRecord = await GetBattleRecordFromDtoAsync(item.BattleRecordDto);
                }
                else if (item.EventRecordDto is not null)
                {
                    result.EventRecord = await GetEventRecordFromDtoAsync(item.EventRecordDto);
                }
            }
            return result;
        }

        private async Task<RewardRecord?> GetRewardRecordFromDtoAsync(RewardRecordDto rewardRecordDto)
        {
            var result = new RewardRecord();
            result.GoldGained = rewardRecordDto.GoldGained;
            if (rewardRecordDto.GivenTradeCards is not null && rewardRecordDto.GivenTradeCards.Count > 0)
            {
                result.GivenTradeCards = await GetGivenTradeCardsFromDtoAsync(rewardRecordDto, result);
            }
            if (rewardRecordDto.RecievedTradeCards is not null && rewardRecordDto.RecievedTradeCards.Count > 0)
            {
                result.RecievedTradeCards = await GetRecievedTradeCardsFromDtoAsync(rewardRecordDto, result);
            }
            if (rewardRecordDto.JunkRewards is not null && rewardRecordDto.JunkRewards.Count > 0)
            {
                result.JunkRewards = await GetJunkRewardsFromDtoAsync(rewardRecordDto, result);
            }
            if (rewardRecordDto.RemovedCards is not null && rewardRecordDto.RemovedCards.Count > 0)
            {
                result.RemovedCards = await GetRemovedCardsFromDtoAsync(rewardRecordDto, result);
            }
            if (rewardRecordDto.UpgradedCards is not null && rewardRecordDto.UpgradedCards.Count > 0)
            {
                result.UpgradedCards = await GetUpgradedCardsFromDtoAsync(rewardRecordDto, result);
            }
            if (rewardRecordDto.CardChoiceRecordDtos is not null && rewardRecordDto.CardChoiceRecordDtos.Count > 0)
            {
                result.CardChoiceRecords = await GetCardChoicesFromDtoAsync(rewardRecordDto, result);
            }
            if (rewardRecordDto.PassiveRecordDtos is not null && rewardRecordDto.PassiveRecordDtos.Count > 0)
            {
                result.PassiveRecords = await GetPassivesFromDto(rewardRecordDto.PassiveRecordDtos);
            }
            return result;


        }

        private async Task<List<RewardJunkCards>> GetJunkRewardsFromDtoAsync(RewardRecordDto dto, RewardRecord record)
        {
            var result = new List<RewardJunkCards>();
            foreach (var item in dto.GivenTradeCards)
            {
                result.Add(new RewardJunkCards()
                {
                    RewardRecord = record,
                    CardRecord = await GetCardRecordFromDtoAsync(item)

                });
            }
            return result;
        }

        private async Task<List<RewardRemovedCards>> GetRemovedCardsFromDtoAsync(RewardRecordDto dto, RewardRecord record)
        {
            var result = new List<RewardRemovedCards>();
            foreach (var item in dto.RemovedCards)
            {
                result.Add(new RewardRemovedCards()
                {
                    RewardRecord = record,
                    CardRecord = await GetCardRecordFromDtoAsync(item)

                });
            }
            return result;
        }

        private async Task<List<RewardUpgradedCards>> GetUpgradedCardsFromDtoAsync(RewardRecordDto dto, RewardRecord record)
        {
            var result = new List<RewardUpgradedCards>();
            foreach (var item in dto.UpgradedCards)
            {
                result.Add(new RewardUpgradedCards()
                {
                    RewardRecord = record,
                    CardRecord = await GetCardRecordFromDtoAsync(item)

                });
            }
            return result;
        }

        private async Task<List<CardChoiceRecord>> GetCardChoicesFromDtoAsync(RewardRecordDto dto, RewardRecord record)
        {
            var result = new List<CardChoiceRecord>();
            foreach (var item in dto.CardChoiceRecordDtos)
            {
                result.Add(await CreateCardChoiceDtoAsync(item));

            }
            return result;
        }

        private async Task<CardChoiceRecord> CreateCardChoiceDtoAsync(CardChoiceRecordDto item)
        {
            var result = new CardChoiceRecord();
            result.RerolledCards = new List<RerolledCardCardInstance>();
            result.UpgradePicked = item.UpgradePicked;
            result.CardPicked = await GetOrCreateCardInstanceAsync(item.CardPicked);
            result.CardChoices = new List<CardChoiceCardInstance>();
            foreach (var choice in item.CardChoices)
            {
                result.CardChoices.Add(await GetCardChoiceCardInstanceAsync(choice, result));
            }
            if (item.RerolledCards is not null && result.RerolledCards.Count > 0)
            {
                foreach (var card in item.RerolledCards)
                {
                    result.RerolledCards.Add(await GetRerolledCardFromDtoAsync(card, result));
                }
            }
            return result;
        }

        private async Task<RerolledCardCardInstance> GetRerolledCardFromDtoAsync(string card, CardChoiceRecord record)
        {
            var result = new RerolledCardCardInstance()
            {
                CardChoiceRecord = record,
                CardInstance = await GetOrCreateCardInstanceAsync(card)

            };
            return result;
        }


        private async Task<CardChoiceCardInstance> GetCardChoiceCardInstanceAsync(string choice, CardChoiceRecord record)
        {

            var result = new CardChoiceCardInstance()
            {
                CardChoiceRecord = record,
                CardInstance = await GetOrCreateCardInstanceAsync(choice)

            };
            return result;
        }
        private async Task<List<RewardRecievedTradeCards>> GetRecievedTradeCardsFromDtoAsync(RewardRecordDto dto, RewardRecord record)
        {
            var result = new List<RewardRecievedTradeCards>();
            foreach (var item in dto.RecievedTradeCards)
            {
                result.Add(new RewardRecievedTradeCards()
                {
                    RewardRecord = record,
                    CardRecord = await GetCardRecordFromDtoAsync(item)

                });
            }
            return result;
        }

        private async Task<List<RewardGivenTradeCards>> GetGivenTradeCardsFromDtoAsync(RewardRecordDto dto, RewardRecord record)
        {
            var result = new List<RewardGivenTradeCards>();
            foreach (var item in dto.GivenTradeCards)
            {
                result.Add(new RewardGivenTradeCards()
                {
                    RewardRecord = record,
                    CardRecord = await GetCardRecordFromDtoAsync(item)

                });
            }
            return result;
        }

        private async Task<BattleRecord?> GetBattleRecordFromDtoAsync(BattleRecordDto battleRecordDto)
        {
            var result = new BattleRecord();
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
            result.BattleInstance = await GetOrCreateBattleInstanceAsync(battleRecordDto.Name);
            return result;
        }

        private async Task<BattleInstance> GetOrCreateBattleInstanceAsync(string name)
        {
            name = name.Trim();

            var instance = BattleInstances
                .FirstOrDefault(c => c.Name == name);
            if (instance != null)
                return instance;
            instance ??= new BattleInstance()
            {
                Name = name
            };
            _context.BattleInstances.Add(instance);
            BattleInstances.Add(instance);
            return instance;
        }

        private async Task<EventRecord> GetEventRecordFromDtoAsync(EventRecordDto eventRecordDto)
        {
            var result = new EventRecord();
            result.EventInstance = await GetOrCreateEventInstanceAsync(eventRecordDto.Name);
            result.TeamworkOnEnter = eventRecordDto.TeamworkOnEnter;
            return result;

        }

        private async Task<EventInstance> GetOrCreateEventInstanceAsync(string name)
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

        private async Task<ShopRecord?> GetShopRecordFromDtoAsync(ShopRecordDto shopRecordDto)
        {
            var result = new ShopRecord();
            result.AffordableCards = await GetAffordableCardsFromDtoAsync(shopRecordDto, result);
            result.AffordablePassives = await GetAffordablePassivesFromDtoAsync(shopRecordDto, result);
            result.PurchasedCards = await GetPurchasedCardsFromDtoAsync(shopRecordDto, result);
            result.PurchasedPassives = await GetPurchasedPassivesFromDtoAsync(shopRecordDto, result);
            result.UpgradePurchased = shopRecordDto.UpgradePurchased;
            if (shopRecordDto.UpgradePurchased && shopRecordDto.UpgradedCard is not null)
            {

                result.UpgradedCard = new CardRecord()
                {
                    CardInstance = await GetOrCreateCardInstanceAsync(shopRecordDto.UpgradedCard.Name),
                    PartySlot = shopRecordDto.UpgradedCard.PartySlot
                };
            }
            result.GoldSpent = shopRecordDto.GoldSpent;
            result.GoldEntered = shopRecordDto.GoldEntered;
            return result;
        }

        private async Task<List<ShopAffordableCard>> GetAffordableCardsFromDtoAsync(ShopRecordDto dto, ShopRecord record)
        {
            var result = new List<ShopAffordableCard>();
            foreach (var item in dto.AffordableCards)
            {
                result.Add(new ShopAffordableCard()
                {
                    ShopRecord = record,
                    CardInstance = await GetOrCreateCardInstanceAsync(item)

                });
            }
            return result;
        }
        private async Task<List<ShopAffordablePassive>> GetAffordablePassivesFromDtoAsync(ShopRecordDto dto, ShopRecord record)
        {
            var result = new List<ShopAffordablePassive>();
            foreach (var item in dto.AffordablePassives)
            {
                result.Add(new ShopAffordablePassive()
                {
                    ShopRecord = record,
                    PassiveInstance = await GetOrCreatePassiveInstanceAsync(item)

                });
            }
            return result;
        }
        private async Task<List<ShopPurchasedPassive>> GetPurchasedPassivesFromDtoAsync(ShopRecordDto dto, ShopRecord record)
        {
            var result = new List<ShopPurchasedPassive>();
            foreach (var item in dto.PurchasedPassives)
            {
                result.Add(new ShopPurchasedPassive()
                {
                    ShopRecord = record,
                    PassiveInstance = await GetOrCreatePassiveInstanceAsync(item)


                });
            }
            return result;
        }
        private async Task<List<ShopPurchasedCard>> GetPurchasedCardsFromDtoAsync(ShopRecordDto dto, ShopRecord record)
        {
            var result = new List<ShopPurchasedCard>();
            foreach (var item in dto.PurchasedPassives)
            {
                result.Add(new ShopPurchasedCard()
                {
                    ShopRecord = record,
                    CardInstance = await GetOrCreateCardInstanceAsync(item)


                });
            }
            return result;
        }

        private async Task<List<CharacterRecord>> GetCharactersFromDtoAsync(GameResultDto input)
        {
            var result = new List<CharacterRecord>();
            foreach (var c in input.CharacterDtos)
            {
                result.Add(await CharacterFromDtoAsync(c));
            }
            return result;
        }

        private async Task<CharacterRecord> CharacterFromDtoAsync(CharacterRecordDto c)
        {
            var result = new CharacterRecord();
            result.CharacterInstance = await GetOrCreateCharacterInstanceAsync(c.Name);
            List<CardRecord> deckResult = await GetDecklistFromCharacterDto(c);
            result.DeckRecord = deckResult;
            return result;
        }

        private async Task<List<CardRecord>> GetDecklistFromCharacterDto(CharacterRecordDto c)
        {
            var result = new List<CardRecord>();
            //This should be fetched at start of process and held as a parameter of the class
            foreach (var card in c.DeckRecord)
            {
                result.Add(await GetCardRecordFromDtoAsync(card));
            }
            return result;

        }

        private async Task<CardRecord> GetCardRecordFromDtoAsync(CardRecordDto card)
        {
            var result = new CardRecord();

            result.CardInstance = await GetOrCreateCardInstanceAsync(card.Name);
            result.PartySlot = card.PartySlot;
            return result;
        }

        private async Task<CharacterInstance> GetOrCreateCharacterInstanceAsync(string name)
        {
            name = name.Trim();

            var instance = await _context.CharacterInstances
                .FirstOrDefaultAsync(c => c.Name == name);

            if (instance != null)
                return instance;

            instance = new CharacterInstance
            {
                Name = name
            };

            _context.CharacterInstances.Add(instance);

            return instance;
        }

        private async Task<List<PassiveRecord>> GetPassivesFromDto(List<PassiveRecordDto> input)
        {
            var result = new List<PassiveRecord>();
            foreach (var item in input)
            {
                result.Add(await GetPassiveRecordFromDtoAsync(item));
            }
            return result;
        }

        private async Task<PassiveRecord> GetPassiveRecordFromDtoAsync(PassiveRecordDto item)
        {
            var result = new PassiveRecord();
            result.PassiveInstance = await GetOrCreatePassiveInstanceAsync(item.Name);
            return result;
        }

        private async Task<PassiveInstance> GetOrCreatePassiveInstanceAsync(string name)
        {
            name = name.Trim();

            var instance = PassiveInstances
                .FirstOrDefault(c => c.Name == name);
            if (instance != null)
                return instance;
            instance ??= new PassiveInstance
            {
                Name = name
            };
            _context.PassiveInstances.Add(instance);
            PassiveInstances.Add(instance);
            return instance;
        }

        private async Task<CardInstance> GetOrCreateCardInstanceAsync(string name)
        {
            name = name.Trim();

            var instance = CardInstances
                .FirstOrDefault(c => c.Name == name);
            if (instance != null)
                return instance;
            instance ??= new CardInstance
            {
                Name = name
            };
            _context.CardInstances.Add(instance);
            CardInstances.Add(instance);
            return instance;
        }
    }
}
