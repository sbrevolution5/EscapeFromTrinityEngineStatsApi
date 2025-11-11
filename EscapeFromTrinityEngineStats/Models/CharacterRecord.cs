using EscapeFromTrinityEngineStats.Models.Instances;

namespace EscapeFromTrinityEngineStats.Models
{
    public class CharacterRecord
    {
        public int Id { get; set; }
        public int VersionId { get; set; }
        public virtual GameVersion Version { get; set; }

        public virtual CharacterInstance CharacterInstance { get; set; }
        public virtual List<CardRecord> DeckRecord { get; set; } = [];
        public int PartySlot { get; set; }
    }
}
