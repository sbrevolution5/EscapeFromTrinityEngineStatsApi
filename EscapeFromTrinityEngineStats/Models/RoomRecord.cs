using StatisticsApi.Models.Instances;

namespace StatisticsApi.Models
{
    public class RoomRecord
    {
        public int Id { get; set; }
        public virtual BattleRecord? BattleRecord { get; set; }
        public virtual EventRecord? EventRecord { get; set; }
        public virtual ShopRecord? ShopRecord { get; set; }
        public virtual RewardRecord? RewardRecord { get; set; }
    }
}
