using StatisticsApi.Models.Instances;

namespace StatisticsApi.Models
{
    public class RoomRecord
    {
        public int Id { get; set; }
        public virtual BattleInstance? BattleInstance { get; set; }
        public virtual EventInstance? EventInstance { get; set; }
        public virtual ShopRecord? ShopRecord { get; set; }
        public virtual RewardRecord? RewardRecord { get; set; }
    }
}
