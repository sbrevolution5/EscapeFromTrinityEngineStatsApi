using Microsoft.EntityFrameworkCore;
using StatisticsApi.Models;
using StatisticsApi.Models.Instances;

namespace StatisticsApi.Context
{
    public class StatisticsDbContext : DbContext
    {
        public DbSet<GameResult> GameResults { get; set; }
        public DbSet<CharacterInstance> CharacterInstances { get; set; }
        public DbSet<CardRecord> CardRecords { get; set; }
        public DbSet<PassiveRecord> PassiveRecords { get; set; }
        public DbSet<RewardRecord> RewardRecords { get; set; }
        public DbSet<RoomRecord> RoomRecords { get; set; }
        public DbSet<ShopRecord> ShopRecords { get; set; }
        public DbSet<EventRecord> EventRecords { get; set; }
    }
}
