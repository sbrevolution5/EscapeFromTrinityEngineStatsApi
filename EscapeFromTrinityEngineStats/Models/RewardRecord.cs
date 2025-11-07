using EscapeFromTrinityEngineStats.Models.InputDto;

namespace EscapeFromTrinityEngineStats.Models
{
    public class RewardRecord
    {
        public int Id { get; set; }
        public int GoldGained;
        public virtual List<CardChoiceRecord> CardChoiceRecords { get; set; }
        public virtual List<PassiveRecord> PassiveRecords { get; set; }
        public virtual List<CardRecord> UpgradedCards { get; set; }
        public virtual List<CardRecord> RemovedCards { get; set; }
        public virtual List<CardRecord> GivenTradeCards { get; set; }
        public virtual List<CardRecord> RecievedTradeCards { get; set; }
    }
}
