using StatisticsApi.Models.Instances;

namespace StatisticsApi.Models
{
    public class CardChoiceRecord
    {
        public int Id { get; set; }
        public virtual List<CardInstance> CardChoices { get; set; }
        public virtual CardInstance CardPicked { get; set; }
        public int LevelNumber;
        public int FloorNumber;
        public int RerollCount;
        public virtual List<CardInstance> RerolledCards { get; set; }
        public bool UpgradePicked;
        public bool DuplicatePicked;
        public int TeamworkSpent;

    }
}
