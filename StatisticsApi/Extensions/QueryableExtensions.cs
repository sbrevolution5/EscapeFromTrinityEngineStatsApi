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
                .Include(g => g.Rooms)
                    .ThenInclude(r => r.RewardRecord)
                        .ThenInclude(rr => rr.PassiveRecords)
                .Include(g => g.Rooms)
                    .ThenInclude(r => r.RewardRecord)
                        .ThenInclude(rr => rr.UpgradedCards)
                .Include(g => g.Rooms)
                    .ThenInclude(r => r.RewardRecord)
                        .ThenInclude(rr => rr.RemovedCards)
                .Include(g => g.Rooms)
                    .ThenInclude(r => r.RewardRecord)
                        .ThenInclude(rr => rr.GivenTradeCards)
                .Include(g => g.Rooms)
                    .ThenInclude(r => r.RewardRecord)
                        .ThenInclude(rr => rr.RecievedTradeCards)
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


    }


}