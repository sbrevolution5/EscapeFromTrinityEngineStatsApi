using EscapeFromTrinityEngineStats.Models;
using Microsoft.EntityFrameworkCore;

namespace StatisticsApi.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<GameResult> IncludeShopRecordDetails(
    this IQueryable<GameResult> query)
        {
            return query
                .Include(g => g.Rooms)
                    .ThenInclude(r => r.ShopRecord)
                        .ThenInclude(s => s.AffordableCards)
                .Include(g => g.Rooms)
                    .ThenInclude(r => r.ShopRecord)
                        .ThenInclude(s => s.PurchasedCards)
                .Include(g => g.Rooms)
                    .ThenInclude(r => r.ShopRecord)
                        .ThenInclude(s => s.AffordablePassives)
                .Include(g => g.Rooms)
                    .ThenInclude(r => r.ShopRecord)
                        .ThenInclude(s => s.PurchasedPassives)
                .Include(g => g.Rooms)
                    .ThenInclude(r => r.ShopRecord)
                        .ThenInclude(s => s.UpgradedCard);
        }
        public static IQueryable<GameResult> IncludeRewardRecordDetails(
    this IQueryable<GameResult> query)
        {
            return query
                .Include(g => g.Rooms)
                    .ThenInclude(r => r.RewardRecord)
                        .ThenInclude(rr => rr.CardChoiceRecords)
                        .ThenInclude(r => r.CardChoices)
                        .ThenInclude(c => c.CardInstance)
                .Include(g => g.Rooms)
                    .ThenInclude(r => r.RewardRecord)
                        .ThenInclude(rr => rr.CardChoiceRecords)
                        .ThenInclude(r => r.CardPicked)
                .Include(g => g.Rooms)
                    .ThenInclude(r => r.RewardRecord)
                        .ThenInclude(rr => rr.PassiveRecords)
                        .ThenInclude(r => r.PassiveInstance)
                .Include(g => g.Rooms)
                    .ThenInclude(r => r.RewardRecord)
                        .ThenInclude(rr => rr.UpgradedCards)
                        .ThenInclude(r => r.CardRecord)
                        .ThenInclude(c => c.CardInstance)
                .Include(g => g.Rooms)
                    .ThenInclude(r => r.RewardRecord)
                        .ThenInclude(rr => rr.RemovedCards)
                        .ThenInclude(r => r.CardRecord)
                        .ThenInclude(c => c.CardInstance)
                .Include(g => g.Rooms)
                    .ThenInclude(r => r.RewardRecord)
                        .ThenInclude(rr => rr.GivenTradeCards)
                        .ThenInclude(r => r.CardRecord)
                        .ThenInclude(c => c.CardInstance)
                .Include(g => g.Rooms)
                    .ThenInclude(r => r.RewardRecord)
                        .ThenInclude(rr => rr.RecievedTradeCards)
                        .ThenInclude(r => r.CardRecord)
                        .ThenInclude(c => c.CardInstance)
                .Include(g => g.Rooms)
                    .ThenInclude(r => r.RewardRecord)
                        .ThenInclude(rr => rr.JunkRewards);
        }
        public static IQueryable<GameResult> IncludeBattleRecordDetails(
    this IQueryable<GameResult> query)
        {
            return query
                .Include(g => g.Rooms)
                    .ThenInclude(r => r.BattleRecord)
                        .ThenInclude(br => br.BattleInstance);
        }
        public static IQueryable<GameResult> IncludeEventRecordDetails(
    this IQueryable<GameResult> query)
        {
            return query
                .Include(g => g.Rooms)
                    .ThenInclude(r => r.EventRecord)
                        .ThenInclude(er => er.EventInstance);
        }
        public static IQueryable<GameResult> IncludeAllRoomRecords(
    this IQueryable<GameResult> query)
        {
            return query
                .IncludeShopRecordDetails()
                .IncludeRewardRecordDetails()
                .IncludeBattleRecordDetails()
                .IncludeEventRecordDetails();
        }
        public static IQueryable<GameResult> IncludeAllSubRecords(this IQueryable<GameResult> query)
        {
            return query
                .Include(g => g.GameVersion)
                .IncludeCharacterDetails()
                .IncludePassiveDetails()
                .IncludeAllRoomRecords();
        }
        public static IQueryable<GameResult> IncludeCharacterDetails(this IQueryable<GameResult> query)
        {

            return query.Include(g => g.Characters)
                    .ThenInclude(c => c.CharacterInstance)
                    .Include(g=>g.Characters)
                    .ThenInclude(c=>c.DeckRecord);   
        }
        public static IQueryable<GameResult> IncludePassiveDetails(this IQueryable<GameResult> query)
        {
            return query.Include(g => g.Passives)
                    .ThenInclude(p => p.PassiveInstance);
        }

    }


}