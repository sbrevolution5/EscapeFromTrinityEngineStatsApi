using EscapeFromTrinityEngineStats.Models.Instances;
using EscapeFromTrinityEngineStats.Models.Relationships;

namespace EscapeFromTrinityEngineStats.Models
{
    public class CardChoiceRecord
    {
        public int Id { get; set; }
        public virtual List<CardChoiceCardInstance> CardChoices { get; set; }
        public virtual CardInstance CardPicked { get; set; }
        public int LevelNumber;
        public int FloorNumber;
        public int RerollCount;
        public virtual List<RerolledCardCardInstance> RerolledCards { get; set; }
        public bool UpgradePicked;
        public bool DuplicatePicked;
        public int TeamworkSpent;

    }
}
