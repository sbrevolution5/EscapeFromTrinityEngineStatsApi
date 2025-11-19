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
            //modelBuilder.Entity<GameResult>(g =>
            //{
            //    g.HasOne(g => g.GameVersion);
            //});
            //modelBuilder.Entity<CardChoiceRecord>(g =>
            //{
            //    g.HasOne(g => g.Version);
            //});
            //modelBuilder.Entity<BattleRecord>(g =>
            //{
            //    g.HasOne(g => g.Version);
            //});
            //modelBuilder.Entity<CharacterRecord>(g =>
            //{
            //    g.HasOne(g => g.Version);
            //});
            //modelBuilder.Entity<EventRecord>(g =>
            //{
            //    g.HasOne(g => g.Version);
            //});
            //modelBuilder.Entity<RewardRecord>(g =>
            //{
            //    g.HasOne(g => g.Version);
            //});
            //modelBuilder.Entity<ShopRecord>(g =>
            //{
            //    g.HasOne(g => g.Version);
            //});
            modelBuilder.Entity<ShopAffordableCard>(e =>
            {
                e.HasKey(e => new { e.ShopRecordId, e.CardInstanceId });
                e.HasOne(e => e.ShopRecord)
                .WithMany(s => s.AffordableCards)
                .HasForeignKey(e => e.ShopRecordId);
                e.HasOne(e => e.CardInstance)
                .WithMany()
                .HasForeignKey(e => e.CardInstanceId);
            });
            modelBuilder.Entity<ShopAffordablePassive>(e =>
            {
                e.HasKey(e => new { e.ShopRecordId, e.PassiveInstanceId });
                e.HasOne(e => e.ShopRecord)
                .WithMany(s => s.AffordablePassives)
                .HasForeignKey(e => e.ShopRecordId);
                e.HasOne(e => e.PassiveInstance)
                .WithMany()
                .HasForeignKey(e => e.PassiveInstanceId);
            });
            modelBuilder.Entity<ShopPurchasedCard>(e =>
            {
                e.HasKey(e => new { e.ShopRecordId, e.CardInstanceId });
                e.HasOne(e => e.ShopRecord)
                .WithMany(s => s.PurchasedCards)
                .HasForeignKey(e => e.ShopRecordId);
                e.HasOne(e => e.CardInstance)
                .WithMany()
                .HasForeignKey(e => e.CardInstanceId);
            });
            modelBuilder.Entity<ShopPurchasedPassive>(e =>
            {
                e.HasKey(e => new { e.ShopRecordId, e.PassiveInstanceId });
                e.HasOne(e => e.ShopRecord)
                .WithMany(s => s.PurchasedPassives)
                .HasForeignKey(e => e.ShopRecordId);
                e.HasOne(e => e.PassiveInstance)
                .WithMany()
                .HasForeignKey(e => e.PassiveInstanceId);
            });
            modelBuilder.Entity<RewardGivenTradeCards>(e =>
            {
                e.HasKey(e => new { e.RewardRecordId, e.CardRecordId});
                e.HasOne(e => e.RewardRecord)
                .WithMany(s => s.GivenTradeCards)
                .HasForeignKey(e => e.RewardRecordId);
                e.HasOne(e => e.CardRecord)
                .WithMany()
                .HasForeignKey(e => e.CardRecordId);
            });
            modelBuilder.Entity<RewardJunkCards>(e =>
            {
                e.HasKey(e => new { e.RewardRecordId, e.CardRecordId});
                e.HasOne(e => e.RewardRecord)
                .WithMany(s => s.JunkRewards)
                .HasForeignKey(e => e.RewardRecordId)
                .OnDelete(DeleteBehavior.Cascade);
                e.HasOne(e => e.CardRecord)
                .WithMany()
                .HasForeignKey(e => e.CardRecordId)
                .OnDelete(DeleteBehavior.Cascade);

            });
            modelBuilder.Entity<RewardUpgradedCards>(e =>
            {
                e.HasKey(e => new { e.RewardRecordId, e.CardRecordId});
                e.HasOne(e => e.RewardRecord)
                .WithMany(s => s.UpgradedCards)
                .HasForeignKey(e => e.RewardRecordId);
                e.HasOne(e => e.CardRecord)
                .WithMany()
                .HasForeignKey(e => e.CardRecordId);
            });
            modelBuilder.Entity<RewardRecievedTradeCards>(e =>
            {
                e.HasKey(e => new { e.RewardRecordId, e.CardRecordId});
                e.HasOne(e => e.RewardRecord)
                .WithMany(s => s.RecievedTradeCards)
                .HasForeignKey(e => e.RewardRecordId);
                e.HasOne(e => e.CardRecord)
                .WithMany()
                .HasForeignKey(e => e.CardRecordId);
            });
            modelBuilder.Entity<RewardRemovedCards>(e =>
            {
                e.HasKey(e => new { e.RewardRecordId, e.CardRecordId});
                e.HasOne(e => e.RewardRecord)
                .WithMany(s => s.RemovedCards)
                .HasForeignKey(e => e.RewardRecordId);
                e.HasOne(e => e.CardRecord)
                .WithMany()
                .HasForeignKey(e => e.CardRecordId);
            });
            modelBuilder.Entity<CardChoiceCardInstance>(e =>
            {
                e.HasKey(e => new { e.CardChoiceRecordId, e.CardInstanceId});
                e.HasOne(e => e.CardChoiceRecord)
                .WithMany(s => s.CardChoices)
                .HasForeignKey(e => e.CardChoiceRecordId);
                e.HasOne(e => e.CardInstance)
                .WithMany()
                .HasForeignKey(e => e.CardInstanceId);
            });
            modelBuilder.Entity<RerolledCardCardInstance>(e =>
            {
                e.HasKey(e => new { e.CardChoiceRecordId, e.CardInstanceId});
                e.HasOne(e => e.CardChoiceRecord)
                .WithMany(s => s.RerolledCards)
                .HasForeignKey(e => e.CardChoiceRecordId);
                e.HasOne(e => e.CardInstance)
                .WithMany()
                .HasForeignKey(e => e.CardInstanceId);
            });

        }
        public DbSet<BattleRecord> BattleRecords { get; set; }
        public DbSet<CharacterRecord> CharacterRecords { get; set; }
        public DbSet<GameResult> GameResults { get; set; }
        public DbSet<GameVersion> GameVersions { get; set; }
        public DbSet<CharacterInstance> CharacterInstances { get; set; }
        public DbSet<CardInstance> CardInstances { get; set; }
        public DbSet<EventInstance> EventInstances { get; set; }
        public DbSet<PassiveInstance> PassiveInstances { get; set; }
        public DbSet<BattleInstance> BattleInstances { get; set; }
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
        public DbSet<RewardGivenTradeCards> RewardGivenTradeCards { get;set; }
        public DbSet<RewardJunkCards> RewardJunkCards { get; set; }
        public DbSet<RewardRecievedTradeCards> RewardRecievedTradeCards { get; set; }
        public DbSet<RewardRemovedCards> RewardRemovedCards { get; set; }
        public DbSet<RewardUpgradedCards> RewardUpgradedCards { get; set; }
        public DbSet<CardChoiceCardInstance> CardChoiceCards { get; set; }
        public DbSet<CardChoiceRecord> CardChoiceRecords { get; set; }
        public DbSet<RerolledCardCardInstance> RerolledCardCardInstances { get; set; }

    }
}
