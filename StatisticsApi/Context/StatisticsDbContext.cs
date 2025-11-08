using EscapeFromTrinityEngineStats.Models;
using EscapeFromTrinityEngineStats.Models.Instances;
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
