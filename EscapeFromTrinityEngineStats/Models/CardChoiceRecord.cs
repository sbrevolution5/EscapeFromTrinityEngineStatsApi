using EscapeFromTrinityEngineStats.Models.Instances;
using EscapeFromTrinityEngineStats.Models.Relationships;

namespace EscapeFromTrinityEngineStats.Models
{
    public class CardChoiceRecord
    {
        public int Id { get; set; }
        public int VersionId { get; set; }

        public virtual GameVersion Version { get; set; }
        public virtual List<CardChoiceCardInstance> CardChoices { get; set; } = [];
        public virtual CardInstance CardPicked { get; set; } 
        public int LevelNumber { get; set; }
        public int FloorNumber { get; set; }
        public int RerollCount { get; set; }
        public virtual List<RerolledCardCardInstance> RerolledCards { get; set; } = [];
        public bool UpgradePicked { get; set; }
        public bool DuplicatePicked { get; set; }
        public int TeamworkSpent { get; set; }

    }
}
