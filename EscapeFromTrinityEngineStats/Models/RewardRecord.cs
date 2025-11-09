using EscapeFromTrinityEngineStats.Models.InputDto;
using EscapeFromTrinityEngineStats.Models.Relationships;

namespace EscapeFromTrinityEngineStats.Models
{
    public class RewardRecord
    {
        public int Id { get; set; }
        public int GoldGained { get; set; }
        public virtual List<CardChoiceRecord> CardChoiceRecords { get; set; }
        public virtual List<PassiveRecord> PassiveRecords { get; set; }
        public virtual List<RewardUpgradedCards> UpgradedCards { get; set; }
        public virtual List<RewardRemovedCards> RemovedCards { get; set; }
        public virtual List<RewardGivenTradeCards> GivenTradeCards { get; set; }
        public virtual List<RewardRecievedTradeCards> RecievedTradeCards { get; set; }
        public virtual List<RewardJunkCards> JunkRewards { get; set; }
    }
}
