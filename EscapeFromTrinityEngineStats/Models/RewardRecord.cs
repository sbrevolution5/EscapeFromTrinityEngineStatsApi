namespace StatisticsApi.Models
{
    public class RewardRecord
    {
        public int Id { get; set; }
        public int GoldGained;
        public virtual List<CardChoiceRecord> CardChoiceRecords { get; set; }
        public virtual List<PassiveRecord> PassiveRecords { get; set; }
    }
}
