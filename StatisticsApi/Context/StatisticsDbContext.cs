using EscapeFromTrinityEngineStats.Models;
using EscapeFromTrinityEngineStats.Models.Instances;
using EscapeFromTrinityEngineStats.Models.Relationships;
using Microsoft.EntityFrameworkCore;
using StatisticsApi.Data;

namespace StatisticsApi.Context
{
    public class StatisticsDbContext : DbContext
    {
        private readonly IConfiguration Configuration;
        public StatisticsDbContext(DbContextOptions<StatisticsDbContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql(
                    DataUtility.GetConnectionString(Configuration),
            o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
        public DbSet<GameResult> GameResults { get; set; }
        public DbSet<CharacterInstance> CharacterInstances { get; set; }
        public DbSet<CardRecord> CardRecords { get; set; }
        public DbSet<PassiveRecord> PassiveRecords { get; set; }
        public DbSet<RewardRecord> RewardRecords { get; set; }
        public DbSet<RoomRecord> RoomRecords { get; set; }
        public DbSet<ShopRecord> ShopRecords { get; set; }
        public DbSet<EventRecord> EventRecords { get; set; }
        public DbSet<ShopAffordableCard> ShopAffordableCards { get; set; }
        public DbSet<ShopPurchasedCard> ShopPurchasedCards { get; set; }
        public DbSet<ShopAffordablePassive> ShopAffordablePassives { get; set; }
        public DbSet<ShopPurchasedPassive> ShopPurchasedPassives { get; set; }
    }
}
